namespace EcIDE.Addins
{
    using System;
    using System.Reflection;
    using System.Xml;

    public class ExtensionCommand
    {
        #region Fields

        internal XmlAttributeCollection atts;

        #endregion

        #region Public Properties

        public string Name { get; internal set; }
        internal XmlNode reference { get; set; }

        internal Assembly Ass { get; set; }

        public CommandCollection<ExtensionCommand> GetNodes()
        {
            var cc = new CommandCollection<ExtensionCommand>();
            foreach (var type in AddinManager.NodesAssembly.GetTypes())
            {
                if (reference != null)
                {
                    foreach (XmlNode child in reference.ChildNodes)
                    {
                        if (child.Name == type.Name)
                        {
                            var ec = new ExtensionCommand
                                     {
                                         Name = child.Name,
                                         atts = child.Attributes,
                                         reference = child
                                     };

                            ec.Ass = AddinManager.NodesAssembly;

                            cc.Add((ExtensionCommand)ec.Populate(type));
                        }
                    }
                }
            }
            return cc;
        } 

        #endregion

        #region Public Methods and Operators

        public object Populate(Type t)
        {
            object ret = Activator.CreateInstance(t);
            foreach (XmlAttribute attribute in this.atts)
            {
                foreach (PropertyInfo propertyInfo in t.GetProperties())
                {
                    if (propertyInfo.Name == attribute.Name)
                    {
                        propertyInfo.SetValue(ret, Convert.ChangeType(attribute.Value, propertyInfo.PropertyType), null);
                    }
                }
            }
            return ret;
        }


        #endregion
    }
}