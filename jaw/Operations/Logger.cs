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

using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace jaw.Operations
{
    class Logger
    {
        private static string LogPath;

        static Logger()
        {
            LogPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "jaw.log");
            if (File.Exists(LogPath)) File.Delete(LogPath);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void Log(string level, string message)
        {
            string logLine = "";

            // remove newlines from message (mostly for logging queries)
            message = message.Replace("\r\n", " ").Replace("\n", " ");

            // get first method outside this class
            StackTrace st = new StackTrace();
            int i;
            for (i = 0; i < st.FrameCount; i++)
            {
                if (st.GetFrame(i).GetMethod().DeclaringType != typeof(Logger))
                    break;
            }

            MethodBase m = st.GetFrame(i).GetMethod();
            Type c = m.DeclaringType;
            string declType = m.IsStatic ? ":" : ".";

            // get timestamp
            string timestamp = DateTime.Now.ToString(@"yyyy/MM/dd HH:mm:ss");

            // build line
            logLine += "[" + timestamp + " " + level + "] ";
            logLine += c.FullName + declType + m.Name + ": ";
            logLine += message;

            // log
            LogLine(logLine);
        }

        private static void LogLine(string line)
        {
            // inefficient, but I think it is okay
            File.AppendAllText(LogPath, line + Environment.NewLine, Encoding.UTF8);
        }

        public static void Debug(string message)
            => Log("DEBUG", message);

        public static void Info(string message)
            => Log(" INFO", message);

        public static void Error(string message)
            => Log("ERROR", message);
    }
}
