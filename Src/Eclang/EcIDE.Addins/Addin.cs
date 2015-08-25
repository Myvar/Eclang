namespace EcIDE.Addins
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    public class Addin
    {
        #region Fields

        public List<byte[]> Dependencies = new List<byte[]>();

        public AppDomain Domain;

        public List<ExtensionNode> ExtensionNodes = new List<ExtensionNode>();

        public Priority Priority = Priority.Normal;

        #endregion

        #region Public Properties

        public string Author { get; set; }

        public Image Icon { get; set; }

        public string Name { get; set; }

        public string Version { get; set; }

        #endregion

        #region Properties

        internal string IconPath { get; set; }

        #endregion

        #region Public Methods and Operators

        public void Unload()
        {
            AppDomain.Unload(this.Domain);
        }

        #endregion
    }
}