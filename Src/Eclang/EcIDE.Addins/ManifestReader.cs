namespace EcIDE.Addins
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Xml;

    public class ManifestReader
    {
        #region Public Methods and Operators

        public Addin Read(Assembly ass, string manifest)
        {
            var a = new Addin();

            var xml = new XmlDocument();
            xml.LoadXml(manifest);

            string ns = xml.DocumentElement.NamespaceURI;

            foreach (XmlNode c in xml.FirstChild.ChildNodes)
            {
                if (c.Name == "meta")
                {
                    foreach (XmlNode meta in c.ChildNodes)
                    {
                        switch (meta.Name)
                        {
                            case "author":
                                a.Author = meta.InnerText;
                                break;
                            case "version":
                                a.Version = meta.InnerText;
                                break;
                            case "name":
                                a.Name = meta.InnerText;
                                break;
                            case "icon":
                                a.IconPath = meta.InnerText;
                                break;
                        }
                    }
                }
                else if (c.Name == "extension")
                {
                    var en = new ExtensionNode();
                    en.Path = c.Attributes["path"].Value;

                    foreach (XmlNode cc in c.ChildNodes)
                    {
                        if (cc.Name == "command")
                        {
                            string cls = cc.Attributes["class"].Value.Replace("{namespace}", ns);

                            en.Commands.Add(cls, Activator.CreateInstance(ass.GetType(cls)));
                        }
                        else
                        {
                            var ec = new ExtensionCommand { Name = cc.Name };
                            ec.atts = cc.Attributes;
                            ec.reference = cc;
                            en.Nodes.Add(ec);
                        }
                    }

                    a.ExtensionNodes.Add(en);
                }
                else if (c.Name == "dependencies")
                {
                    foreach (XmlNode dc in c.ChildNodes)
                    {
                        if (dc.Name == "dependency")
                        {
                            if (File.Exists(dc.Attributes["path"].Value))
                            {
                                a.Dependencies.Add(File.ReadAllBytes(dc.Attributes["path"].Value));
                            }
                            else
                            {
                                throw new AddinException(
                                    "Dependency '" + dc.Attributes["path"].Value + "' does not exist!");
                            }
                        }
                    }
                }
            }

            return a;
        }

        #endregion
    }
}