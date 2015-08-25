using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EcIDE.Internals.Packing.vfs;
using ECLang;

namespace Packer
{
    static class Program
    {
        public static FileSystem fs = new FileSystem();
        public static Engine en = new Engine();
        [STAThread]
        static void Main()
        {
            fs.Load("./main.ecpackage");
            en.Execute(fs.GetFile("Main").Content);
        }
    }
}
