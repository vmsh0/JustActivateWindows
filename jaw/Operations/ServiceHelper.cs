/*
 * Copyright 2019 Riccardo Paolo Bestetti
 * 
 * This file is part of Just Activate Windows.
 *
 * Just Activate Windows is free software: you can redistribute it and/or modify it under the terms of the
 * GNU General Public License as published by the Free Software Foundation, either version 3 of the License,
 * or (at your option) any later version.
 *
 * Just Activate Windows is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without
 * even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General
 * Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with Foobar.  If not, see <https://www.gnu.org/licenses/>.
 */

using jaw.Helpers;
using jaw.Operations;
using System;
using System.IO;
using System.Management;
using System.Net;
using System.Net.Sockets;

namespace jaw
{
    static class ServiceHelper
    {
        private static string servicePath =
            Path.Combine(BundleSetup.SupportFilesPath, @"vlmcsd\vlmcsd.exe");

        private static ManagementObject GetVlmcsdService()
            => WmiQuery.GetFirst(
                "SELECT * FROM Win32_Service " +
                "WHERE Name = \"vlmcsd\" AND " +
                "StartMode <> \"Disabled\""
                );

        public static bool VlmcsdRegistered()
            => GetVlmcsdService() != null;

        public static bool VlmcsdStarted()
            => (bool)GetVlmcsdService()?.GetPropertyValue("Started");

        public static void VlmcsdStart()
            => GetVlmcsdService()?.InvokeMethod("StartService", new object[0]);

        public static void DeleteVlmcsd()
            => GetVlmcsdService()?.InvokeMethod("Delete", new object[0]);

        // returns the IP address to use for activation
        public static IPAddress RegisterAndStartVlmcsd(IPAddress ipa = null)
        {
            if (ipa == null)
            {
                Logger.Debug("Generating a random IP address");

                Random rnd = new Random();

                // assuming the user is using a /24 in the 10.0.0.0/8 address space, this has a chance
                // of 1 in 65k to collide. maybe it's worth trying to detect whether the chosen
                // address space is already in use by other NICs, but it is kind of a worthless battle:
                // what if the user connects to a different network after we do this?
                // we could add a bit more randomness (we still have 6 free bits in the last octed) but I
                // don't think it's worth the hassle, especially because people usually use /24's anyway.
                // anyway, we pick a random /30 and pass its first address (.9) to vlmcsd, which will
                // configure the Tap adapter to use it. vlmcsd will then listen on all other addresses,
                // which, since we are using a /30, correspond to just the single .10
                byte[] octects = new byte[] { 10, (byte)rnd.Next(256), (byte)rnd.Next(256), 9 };
                ipa = new IPAddress(octects);
            }

            if (ipa.AddressFamily != AddressFamily.InterNetwork)
            {
                Logger.Error("Passed address is not of the right family");
                return null;
            }

            Logger.Info("Using IP address " + ipa.ToString() + " for Tap interface");

            // -s: run as a service
            // -U /n: run as "NT AUTHORITY\eNetworkService"
            // -O: tap adapter configuration
            string vlmcsdPath = Path.Combine(BundleSetup.SupportFilesPath, "vlmcsd");
            string vlmcsdExePath = Path.Combine(vlmcsdPath, "vlmcsd.exe");
            string p = "-s -U /n -O \"" + NicHelper.JAW_DEV_NAME + "\"=" + ipa.ToString() + "/30";

            ProcExec.Exec(vlmcsdExePath, vlmcsdPath, p);

            if (!VlmcsdRegistered())
            {
                Logger.Error("Failed to register vlmcsd service");
                return null;
            }

            // add firewall rule
            // TODO: this should probably be done through WMI, if possible, and we should also check
            //       if it succeeded before continuing
            ProcExec.Exec("netsh", null,
                "advfirewall firewall add rule name=\"vlmcsd\" dir=in action=allow " +
                "program=\"" + vlmcsdExePath + "\" enable=yes");

            Logger.Debug("Added firewall rule");

            // start the service
            VlmcsdStart();
            if (!VlmcsdStarted())
            {
                Logger.Error("Failed to start vlmcsd service");
                return null;
            }

            // return activation IP address as described above
            byte[] activationOctects = ipa.GetAddressBytes();
            activationOctects[3] += 1;
            return new IPAddress(activationOctects);
        }
    }
}
