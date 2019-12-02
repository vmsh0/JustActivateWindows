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

// I want to thank the author of WMI Explorer for having done what Microsoft could not do
namespace jaw
{
    // this is all unchecked, it assumes requests are sane
    static class WmiQuery
    {
        static ManagementScope scope;

        static WmiQuery()
        {
            Logger.Debug("Inizializing ManagementScope...");

            scope = new ManagementScope(@"\\localhost\root\CIMV2");
            scope.Connect();

            Logger.Debug("Inizialized ManagementScope");
        }

        public static ManagementObject GetFirst(string query)
        {
            Logger.Info("Query: " + query);

            SelectQuery q = new SelectQuery(query);

            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, q);

            using (ManagementObjectCollection queryCollection = searcher.Get())
            {
                Logger.Debug("Search yielded " + queryCollection.Count.ToString() + " result(s)");

                if (queryCollection.Count >= 1)
                    foreach (ManagementObject m in queryCollection)
                        return m;
            }

            return null;
        }

        public static List<ManagementObject> GetAll(string query)
        {
            Logger.Info("Query: " + query);

            SelectQuery q = new SelectQuery(query);

            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, q);

            List<ManagementObject> objs = new List<ManagementObject>();

            // unroll to a list because i don't know c# patterns
            using (ManagementObjectCollection queryCollection = searcher.Get())
            {
                Logger.Debug("Search yielded " + queryCollection.Count.ToString() + " result(s)");

                foreach (ManagementObject m in queryCollection)
                    objs.Add(m);
            }

            return objs;
        }

        /*
         * not used -- keeping just in case
         * if this is restored, add logging
         * 
        // calls a WMI method of a class, by constructing a generic instance of the class
        public static object CallMethodStatic(string className, string methodName, object[] parms)
            => new ManagementClass(scope.Path.Path, className, null).InvokeMethod(methodName, parms);
        */
    }
}
