namespace EcIDE.Addins
{
    using System;
    using System.Collections.ObjectModel;
    using System.Drawing;
    using System.IO;
    using System.Reflection;
    using System.Windows.Forms;

    public class AddinRegistry : Collection<Addin>
    {
        #region Public Properties

        public string Path { get; set; }

        #endregion

        #region Public Methods and Operators

        public void Initialize(string path)
        {
            path = path.Replace(
                "[ApplicationData]",
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            path = path.Replace("[StartupPath]", Application.StartupPath);

            this.Path = path;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (!Directory.Exists(path + "\\dependencies\\"))
            {
                Directory.CreateDirectory(path + "\\dependencies\\");
            }

            foreach (string f in Directory.GetFiles(path, "*.dll"))
            {
                this.LoadAddin(f);
            }
            this.SortByPriority();
        }

        public void LoadAddin(string dll)
        {
            dll = dll.Replace("[ApplicationData]", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            dll = dll.Replace("[StartupPath]", Application.StartupPath);

            try
            {
                Assembly ass;
                ass = Assembly.LoadFile(dll);

                var addAttr = ass.GetCustomAttributes(typeof(AddinAttribute), false) as AddinAttribute[];
                if (addAttr != null && addAttr.Length != 0)
                {
                    //domain.Load(ass.FullName);

                    string manifest = "manifest.xml";

                    object[] man = ass.GetCustomAttributes(typeof(ManifestAttribute), true);
                    if (man.Length == 1)
                    {
                        if (man[0] != null)
                        {
                            var m = man[0] as ManifestAttribute;
                            manifest = m.Name;
                        }
                    }

                    Stream str = ass.GetManifestResourceStream(ass.GetName().Name + "." + manifest);

                    if (str != null)
                    {
                        string r = new StreamReader(str).ReadToEnd();
                        Addin ad = new ManifestReader().Read(ass, r);
                        try
                        {
                            ad.Icon = ad.IconPath != ""
                                ? Image.FromStream(
                                    ass.GetManifestResourceStream(ass.GetName().Name + "." + ad.IconPath))
                                : null;
                        }
                        catch (Exception)
                        {
                        }

                        ad.Priority = addAttr[0].Priority;

                        AppDomain domain = AppDomain.CreateDomain(ad.Name);

                        foreach (var dependency in ad.Dependencies)
                        {
                            domain.Load(dependency);
                        }

                        ad.Domain = domain;

                        this.Add(ad);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        #endregion

        #region Methods

        private void SortByPriority()
        {
            for (int index = 0; index < this.Count; index++)
            {
                Addin addin = this[index];
                if (addin.Priority == Priority.HighPriority)
                {
                    this.Items.RemoveAt(index);
                    this.Items.Add(addin);
                }
            }
        }

        #endregion
    }
}