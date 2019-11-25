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

using jaw.Operations;
using System.Collections.Generic;
using System.Management;
using System.Net;

namespace jaw
{
    // see LicenseOps.txt for information about how all this works
    static class LicensingHelper
    {
        private const string WINDOWS_APPLICATION_ID = "55c92734-d682-4d71-983e-d6ec3f16059f"; // slmgr.vbs
        private const string WINDOWS_ACTIVE_PRODUCT_WHERE =
            "ApplicationID = \"" + WINDOWS_APPLICATION_ID + "\" AND " +
            "LicenseIsAddon = false AND " +
            "LicenseStatus <> 0";
        private const string WINDOWS_PRODUCT_WHERE = "ApplicationID = \"" + WINDOWS_APPLICATION_ID + "\"";

        public static string GetWindowsSKU()
            => WmiQuery.GetFirst("SELECT Caption FROM Win32_OperatingSystem")["caption"]?.ToString();

        public static string GetProductKey()
        {
            string regPk = WinProdKeyFind.GetWindowsProductKeyFromRegistry();
            if (regPk == null) return null;

            // check if the product key is effectively installed
            List<ManagementObject> licensedProducts = WmiQuery.GetAll(
                "SELECT ID FROM SoftwareLicensingProduct WHERE " +
                "PartialProductKey = \"" + regPk.Substring(regPk.Length - 5) + "\" AND " +
                WINDOWS_PRODUCT_WHERE
            );

            if (licensedProducts.Count > 0) return regPk;
            return null;
        }

        public static void ClearProductKeys()
        {
            // uninstall all installed Windows product keys
            Logger.Debug("Querying installed licenses");
            List<ManagementObject> licensedProducts = WmiQuery.GetAll(
                "SELECT ID FROM SoftwareLicensingProduct WHERE " + WINDOWS_ACTIVE_PRODUCT_WHERE);

            Logger.Debug("Removing " + licensedProducts.Count.ToString() + " installed license(s)");

            foreach (ManagementObject p in licensedProducts)
            {
                p.InvokeMethod("UninstallProductKey", new object[0]);
            }
        }

        public static void SetProductKey(string productKey)
        {
            // clear current product key(s)
            ClearProductKeys();

            // install new product key
            ManagementObject sls = WmiQuery.GetFirst("SELECT * FROM SoftwareLicensingService");

            Logger.Debug("Installing new Product key");
            sls.InvokeMethod("InstallProductKey", new object[] { productKey });

            // refresh licensing status
            Logger.Debug("Refreshing licensing status");
            sls.InvokeMethod("RefreshLicenseStatus", new object[0]);
        }

        // assumes correct product key is the only one installed
        public static bool KmsActivate(IPAddress ipa)
        {
            // set kms server address
            Logger.Debug("Setting KMS address");
            ManagementObject sls = WmiQuery.GetFirst("SELECT * FROM SoftwareLicensingService");
            sls.InvokeMethod("SetKeyManagementServiceMachine", new object[] { ipa.ToString() });

            // get VL product object
            Logger.Debug("Getting Volume License product object");
            ManagementObject wslp = WmiQuery.GetFirst(
                "SELECT ID FROM SoftwareLicensingProduct WHERE " + WINDOWS_ACTIVE_PRODUCT_WHERE);
            if (wslp == null)
            {
                Logger.Error("Volume License product not activated");
                return false;
            }

            // activate Windows
            Logger.Debug("Activating Windows");
            wslp.InvokeMethod("Activate", new object[0]);

            // refresh licensing status
            Logger.Debug("Refreshing licensing status");
            sls.InvokeMethod("RefreshLicenseStatus", new object[0]);

            return true;
        }
    }
}
