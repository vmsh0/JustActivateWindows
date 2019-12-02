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

using System.Collections.Generic;

namespace jaw
{
    static class SkuToProductKey
    {
        private static Dictionary<string, string> skus;
        private static string overrideKey = null;

        static SkuToProductKey()
        {
            skus = new Dictionary<string, string>();

            // Server 2016
            skus.Add("Server 2016 Datacenter", "CB7KF-BWN84-R7R2Y-793K2-8XDDG");
            skus.Add("Server 2016 Standard", "WC2BQ-8NRM3-FDDYY-2BFGV-KHKQY");
            skus.Add("Server 2016 Essentials", "JCKRF-N37P4-C2D82-9YXRT-4M63B");

            // 10 Home
            skus.Add("10 Home", "TX9XD-98N7V-6WMQ6-BX7FG-H8Q99");
            skus.Add("10 Home N", "3KHY7-WNT83-DGQKR-F7HPR-844BM");
            skus.Add("10 Home Single Language", "7HNRX-D7KGG-3K4RQ-4WPJ4-YTDFH");
            skus.Add("10 Home Country Specific", "PVMJN-6DFY6-9CCP6-7BKTT-D3WVR");

            // 10 Pro
            skus.Add("10 Professional", "W269N-WFGWX-YVC9B-4J6C9-T83GX");
            skus.Add("10 Professional N", "MH37W-N47XK-V7XM9-C7227-GCQG9");
            skus.Add("10 Pro", "W269N-WFGWX-YVC9B-4J6C9-T83GX");
            skus.Add("10 Pro N", "MH37W-N47XK-V7XM9-C7227-GCQG9");

            // 10 Education
            skus.Add("10 Education", "NW6C2-QMPVW-D7KKK-3GKT6-VCFB2");
            skus.Add("10 Education N", "2WH4N-8QGBV-H22JP-CT43Q-MDWWJ");

            // 10 Enterprise
            // Note: 2015 and 2016 LTSC's probably wont't work
            //       we should find a better way to match Windows versions
            skus.Add("10 Enterprise", "NPPR9-FWDCX-D2C8J-H872K-2YT43");
            skus.Add("10 Enterprise N", "DPH2V-TTNVB-4X9Q3-TJR4H-KHJW4");
            skus.Add("10 Enterprise 2015 LTSB", "WNMTR-4C88C-JK8YV-HQ7T2-76DF9");
            skus.Add("10 Enterprise 2015 LTSB N", "2F77B-TNFGY-69QQF-B8YKP-D69TJ");
            skus.Add("10 Enterprise 2016 LTSB", "DCPHK-NFMTC-H88MJ-PFHPY-QJ4BJ");
            skus.Add("10 Enterprise 2016 LTSB N", "QFFDN-GRT3P-VKWWX-X7T3R-8B639");
            skus.Add("10 Enterprise LTSC", "M7XTQ-FN8P6-TTKYV-9D4CC-J462D");
            skus.Add("10 Enterprise N LTSC", "92NFX-8DJQP-P6BBQ-THF9C-7CG2H");

            // Old editions - we'll probably not support these
            skus.Add("8.1 Professional", "GCRJD-8NW9H-F2CDX-CCM8D-9D6T9");
            skus.Add("8.1 Professional N", "HMCNV-VVBFX-7HMBH-CTY9B-B4FXY");
            skus.Add("8.1 Enterprise", "MHF9N-XY6XB-WVXMC-BTDCT-MKKG7");
            skus.Add("8.1 Enterprise N", "TT4HM-HN7YT-62K67-RGRQJ-JFFXW");
            skus.Add("Server 2012 R2 Server Standard", "D2N9P-3P6X9-2R39C-7RTCD-MDVJX");
            skus.Add("Server 2012 R2 Datacenter", "W3GGN-FT8W3-Y4M27-J84CP-Q3VJ9");
            skus.Add("Server 2012 R2 Essentials", "KNC87-3J2TX-XB4WP-VCPJV-M4FWM");
            skus.Add("8 Professional", "NG4HW-VH26C-733KW-K6F98-J8CK4");
            skus.Add("8 Professional N", "XCVCF-2NXM9-723PB-MHCB7-2RYQQ");
            skus.Add("8 Enterprise", "32JNW-9KQ84-P47T8-D8GGY-CWCK7");
            skus.Add("8 Enterprise N", "JMNMF-RHW7P-DMY6X-RF3DR-X2BQT");
            skus.Add("Server 2012", "BN3D2-R7TKB-3YPBD-8DRP2-27GG4");
            skus.Add("Server 2012 N", "8N2M2-HWPGY-7PGT9-HGDD8-GVGGY");
            skus.Add("Server 2012 Single Language", "2WN2H-YGCQR-KFX6K-CD6TF-84YXQ");
            skus.Add("Server 2012 Country Specific", "4K36P-JN4VD-GDC6V-KDT89-DYFKP");
            skus.Add("Server 2012 Server Standard", "XC9B7-NBPP2-83J2H-RHMBY-92BT4");
            skus.Add("Server 2012 MultiPoint Standard", "HM7DN-YVMH3-46JC3-XYTG7-CYQJJ");
            skus.Add("Server 2012 MultiPoint Premium", "XNH6W-2V9GX-RGJ4K-Y8X6F-QGJ2G");
            skus.Add("Server 2012 Datacenter", "48HP8-DN98B-MYWDG-T2DCC-8W83P");
            skus.Add("7 Professional", "FJ82H-XT6CR-J8D7P-XQJJ2-GPDD4");
            skus.Add("7 Professional N", "MRPKT-YTG23-K7D7T-X2JMM-QY7MG");
            skus.Add("7 Professional E", "W82YF-2Q76Y-63HXB-FGJG9-GF7QX");
            skus.Add("7 Enterprise", "33PXH-7Y6KF-2VJC9-XBBR8-HVTHH");
            skus.Add("7 Enterprise N", "YDRBP-3D83W-TY26F-D46B2-XCKRJ");
            skus.Add("7 Enterprise E", "C29WB-22CC8-VJ326-GHFJW-H9DH4");
            skus.Add("Server 2008 R2 Web", "6TPJF-RBVHG-WBW2R-86QPH-6RTM4");
            skus.Add("Server 2008 R2 HPC edition", "TT8MH-CG224-D3D7Q-498W2-9QCTX");
            skus.Add("Server 2008 R2 Standard", "YC6KT-GKW9T-YTKYR-T4X34-R7VHC");
            skus.Add("Server 2008 R2 Enterprise", "489J6-VHDMP-X63PK-3K798-CPX3Y");
            skus.Add("Server 2008 R2 Datacenter", "74YFP-3QFB3-KQT8W-PMXWJ-7M648");
            skus.Add("Server 2008 R2 for Itanium-based Systems", "GT63C-RJFQ3-4GMB6-BRFB9-CB83V");
            skus.Add("Vista Business", "YFKBB-PQJJV-G996G-VWGXY-2V3X8");
            skus.Add("Vista Business N", "HMBQG-8H2RH-C77VX-27R82-VMQBT");
            skus.Add("Vista Enterprise", "VKK3X-68KWM-X2YGT-QR4M6-4BWMV");
            skus.Add("Vista Enterprise N", "VTC42-BM838-43QHV-84HX6-XJXKV");
            skus.Add("Web Server 2008", "WYR28-R7TFJ-3X2YQ-YCY4H-M249D");
            skus.Add("Server 2008 Standard", "TM24T-X9RMF-VWXK6-X8JC9-BFGM2");
            skus.Add("Server 2008 Standard without Hyper-V", "W7VD6-7JFBR-RX26B-YKQ3Y-6FFFJ");
            skus.Add("Server 2008 Enterprise", "YQGMW-MPWTJ-34KDK-48M3W-X4Q6V");
            skus.Add("Server 2008 Enterprise without Hyper-V", "39BXF-X8Q23-P2WWT-38T2F-G3FPG");
            skus.Add("Server 2008 HPC", "RCTX3-KWVHP-BR6TB-RB6DM-6X7HP");
            skus.Add("Server 2008 Datacenter", "7M67G-PC374-GR742-YH8V4-TCBY3");
            skus.Add("Server 2008 Datacenter without Hyper-V", "22XQ2-VRXRG-P8D42-K34TD-G3QQC");
            skus.Add("Server 2008 for Itanium-Based Systems", "4DWFP-JF3DJ-B7DTH-78FJB-PDRHK");
        }

        public static string Get(string sku)
        {
            if (overrideKey != null) return overrideKey;

            string o;

            if (skus.TryGetValue(sku, out o)) return o;
            if (skus.TryGetValue(sku.Replace("Microsoft Windows ", ""), out o)) return o;

            return null;
        }

        public static void SetOverrideKey(string k)
        {
            overrideKey = k;
        }
    }
}
