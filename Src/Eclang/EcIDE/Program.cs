namespace EcIDE
{
    using System;
    using System.Windows.Forms;

    using EcIDE.Addins;

    internal static class Program
    {
        #region Methods

        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AddinManager.NodesAssembly = typeof(Nodes.menuitem).Assembly;

            AddinManager.Registry.LoadAddin(@"[StartupPath]\EcIDE.Core.dll");
            AddinManager.Registry.Initialize(@"[ApplicationData]\EcIDE\addins\");

            Application.Run(new MainForm());
        }

        #endregion
    }
}