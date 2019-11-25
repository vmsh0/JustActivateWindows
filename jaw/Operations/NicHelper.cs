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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;

namespace jaw
{
    internal class Tap0901Device : IEquatable<Tap0901Device>
    {
        ManagementBaseObject m;

        public string InstanceId => m?["PNPDeviceID"].ToString();

        public bool IsJawDevice => DeviceName?.Equals(NicHelper.JAW_DEV_NAME) ?? false;

        public string DeviceName => m?["NetConnectionID"].ToString();

        public Tap0901Device(ManagementBaseObject m)
        {
            this.m = m;
        }

        public void Remove()
        {
            Logger.Info("Removing Tap device " + DeviceName);

            NicHelper.Devcon("remove @" + InstanceId);
            m = null;
        }

        public void Rename(string n)
        {
            Logger.Info("Renaming Tap device " + DeviceName + " to " + n);

            NicHelper.Netsh(
                "interface set interface name=\"" + DeviceName + "\" newname=\"" + n + "\""
                );
            m = null;
        }

        public override bool Equals(object obj) => Equals(obj as Tap0901Device);

        public bool Equals(Tap0901Device other)
            => other != null && InstanceId == other.InstanceId;

        public override int GetHashCode()
            => -676353417 + EqualityComparer<string>.Default.GetHashCode(InstanceId);
    }

    static class NicHelper
    {
        public const string JAW_DEV_NAME = "jaw";

        public static int Devcon(string p)
            => ProcExec.Exec(Path.Combine(BundleSetup.SupportFilesPath, @"tap\tapinstall.exe"),
                Path.Combine(BundleSetup.SupportFilesPath, "tap"), p);

        public static int Netsh(string p)
            => ProcExec.Exec("netsh", null, p);

        public static List<Tap0901Device> GetAllTap0901Devices()
        {
            List<ManagementObject> devs = WmiQuery.GetAll(
                "SELECT NetConnectionID, PNPDeviceID FROM Win32_NetworkAdapter " +
                "WHERE ServiceName = 'tap0901'"
                );

            List<Tap0901Device> wrappedDevs = new List<Tap0901Device>();
            
            foreach (ManagementObject m in devs)
                wrappedDevs.Add(new Tap0901Device(m));

            Logger.Debug("Found " + wrappedDevs.Count.ToString() + " Tap device(s)");

            return wrappedDevs;
        }

        public static bool InstallAndRenameTap0901Device()
        {
            Logger.Info("Installing jaw Tap device...");

            List<Tap0901Device> before = GetAllTap0901Devices();

            Devcon("install OemVista.inf tap0901");

            List<Tap0901Device> diff = GetAllTap0901Devices().Except(before).ToList();

            if (diff.Count != 1)
            {
                Logger.Error("Tap device installation failed");
                return false;
            }

            Tap0901Device newDev = diff.First();
            newDev.Rename(JAW_DEV_NAME);

            return JawDevInstalled();
        }

        public static void DeleteTap0901JawDev()
            => GetTap0901JawDev()?.Remove();

        private static Tap0901Device GetTap0901JawDev()
            => GetAllTap0901Devices().Find((dev) => dev.IsJawDevice);

        public static bool JawDevInstalled()
            => GetTap0901JawDev() != null;
    }
}
