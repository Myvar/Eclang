namespace EcIDE.Internals.Exe
{
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.IO;
    using System.Windows.Forms;

    using EcIDE.Properties;

    using Microsoft.CSharp;

    public class Compiler
    {
        #region Public Methods and Operators

        public void BuildExe(string exe, string code, bool showConsole = true)
        {
            if (File.Exists("./Build/ECLang.dll"))
            {
                File.Delete("./Build/ECLang.dll");
            }
            File.Copy("ECLang.dll", "./Build/ECLang.dll");
            File.WriteAllText("./Build/Src/Main.ec", code);
            var codeProvider = new CSharpCodeProvider();

            var parameters = new CompilerParameters();
            parameters.GenerateExecutable = true;
            parameters.OutputAssembly = "./Build/" + exe;
            parameters.ReferencedAssemblies.Add("./ECLang.dll");
            parameters.EmbeddedResources.Add("./ECLang.dll");
            parameters.EmbeddedResources.Add("./Build/Src/Main.ec");
            string Bootstrap = Resources.BootStrapCode;
            if (!showConsole)
            {
                Bootstrap = Bootstrap.Replace("/*HideConsoleReplacePoint*/", "ShowWindow(handle, SW_HIDE);");
            }

            CompilerResults results = codeProvider.CompileAssemblyFromSource(parameters, Bootstrap);
            this.Execute("./Build/" + exe);
            var dlg = new SaveFileDialog();
            dlg.Filter = "Exe file|*.exe";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(dlg.FileName))
                {
                    File.Delete(dlg.FileName);
                }
                File.Copy("./Build/" + exe, dlg.FileName);
            }
        }

        public void Execute(string exe)
        {
            var p = new ProcessStartInfo();
            p.FileName = Application.StartupPath + "\\Build\\libz.exe";

            p.Arguments = "inject-dll --assembly " + exe + " --include ./Build/*.dll --move";
            p.WindowStyle = ProcessWindowStyle.Hidden;

            Process x = Process.Start(p);
            x.WaitForExit();
        }

        #endregion
    }
}