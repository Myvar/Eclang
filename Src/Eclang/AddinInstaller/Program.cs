using System;
using System.Windows.Forms;

namespace AddinInstaller
{
    using System.IO;

    using Addin.Installer;

    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length == 1)
            {
                AddinInstallerFile aif = AddinInstallerFile.Load(new FileStream(args[0], FileMode.OpenOrCreate));
                Application.Run(new MainForm(aif));
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
