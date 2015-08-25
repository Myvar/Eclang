using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace EcIDE.Internals.Packing
{
    public static class Ziper
    {
        //7z <command> [<switch>...] <base_archive_name> [<arguments>...]
        public static void Excute(string cmd, string switches, string archivename, string sourceName, string args)
        {
            ProcessStartInfo p = new ProcessStartInfo();
            p.FileName = "7za.exe";

            p.Arguments = cmd + " " + switches + " \"" + archivename + "\" \"" + sourceName + "\"";
            p.WindowStyle = ProcessWindowStyle.Hidden;

            Process x = Process.Start(p);
            x.WaitForExit();
        }
    }
}
