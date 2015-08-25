namespace AddinBuilder
{
    using System.IO;

    using Addin.Installer;

    public class Program
    {
        static void Main(string[] args)
        {
            var cmd = new CommandlineArguments(args);
            
            var aif = AddinInstallerFile.Build(File.ReadAllText(cmd["l"]), null, cmd["a"], null);
            AddinInstallerFile.Save(aif, new FileStream(cmd["out"], FileMode.OpenOrCreate));
        }
    }
}
