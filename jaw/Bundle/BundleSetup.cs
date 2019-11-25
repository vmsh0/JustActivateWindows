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

using Ionic.Zip;
using jaw.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jaw
{
    static class BundleSetup
    {
        public static string SupportFilesPath { get; private set; }

        public static void Setup()
        {
            SupportFilesPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Windows),
                    "jaw"
                    );

            // if jaw directory doesn't exist ask before creating, otherwise silently update files
            if (!Directory.Exists(SupportFilesPath))
            {
                DialogResult choice = MessageBox.Show(
                    "The application will now install support files to " + SupportFilesPath + ". These " +
                    "files are necessary to the activation process and to keep Windows activated.\n" +
                    "\n" +
                    "The support files are extracted to the current Windows directory to be " +
                    "compatible with multiple Windows installations on the same disk.\n" +
                    "\n" +
                    "Press \"OK\" to proceed or \"Cancel\" to exit.",
                    "Support files extraction",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question
                    );

                if (choice != DialogResult.OK)
                {
                    Environment.Exit(0);
                }
            }

            ZipFile bundle = ZipFile.Read(new MemoryStream(Resources.supportFiles64));
            bundle.ExtractAll(SupportFilesPath, ExtractExistingFileAction.DoNotOverwrite);
        }
    }
}
