namespace EcIDE.Addins
{
    using System.Collections.Generic;
    using System.Reflection;

    public class AddinManager
    {
        #region Static Fields

        public static AddinRegistry Registry = new AddinRegistry();

        public static Assembly NodesAssembly { get; set; }

        #endregion

        #region Public Methods and Operators

        public static IEnumerable<ExtensionNode> GetExtensionObjects(string path)
        {
            foreach (Addin r in Registry)
            {
                foreach (ExtensionNode en in r.ExtensionNodes)
                {
                    if (en.Path == path)
                    {
                        yield return en;
                    }
                }
            }
        }

        public static void UnLoadDomains()
        {
            foreach (Addin r in Registry)
            {
                r.Unload();
            }
        }

        #endregion
    }
}