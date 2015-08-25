namespace EcIDE.Internals.Project
{
    using System.Collections.Generic;
    using System.IO;
    using System.Windows.Markup;
    using System.Xaml;

    [ContentProperty("Body")]
    public class ProjectFile
    {
        #region Constructors and Destructors

        public ProjectFile()
        {
            this.Body = new Body();
            this.Sources = new List<string>();
        }

        #endregion

        #region Public Properties

        public Body Body { get; set; }

        public Header ProjectHeader { get; set; }

        public List<string> Sources { get; set; } 

        #endregion

        #region Public Methods and Operators

        public static ProjectFile Load(string file)
        {
            var p = XamlServices.Load(file) as ProjectFile;
            return p;
        }

        public static void Save(string file, ref ProjectFile pf)
        {
            File.WriteAllText(file, XamlServices.Save(pf));
        }

        #endregion
    }

    [ContentProperty("Properties")]
    public class Body
    {
        #region Constructors and Destructors

        public Body()
        {
            this.Properties = new Dictionary<string, object>();
        }

        #endregion

        #region Public Properties

        public Dictionary<string, object> Properties { get; set; }

        #endregion
    }

    public class Header
    {
        #region Public Properties

        public string Name { get; set; }

        public ProjectType Type { get; set; }

        #endregion
    }

    public enum ProjectType
    {
        WindowsFormsApplication = 0,

        WindowsConsoleApplication = 1
    }
}