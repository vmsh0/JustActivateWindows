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
using System.Diagnostics;

namespace jaw.Helpers
{
    static class ProcExec
    {
        public static int Exec(string n, string w, string p)
        {
            using (Process proc = new Process())
            {
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.FileName = n;
                proc.StartInfo.CreateNoWindow = true;
                proc.StartInfo.Arguments = p;
                proc.StartInfo.RedirectStandardOutput = true;
                if (w != null) proc.StartInfo.WorkingDirectory = w;

                Logger.Info("Command: \"" + n + "\" " + p);
                Logger.Debug("Working directory: " + w);

                proc.Start();

                proc.WaitForExit();

                Logger.Debug("Exit code: " + proc.ExitCode.ToString());

                return proc.ExitCode;
            }
        }
    }
}
