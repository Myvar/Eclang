namespace EcIDE.Addins
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class ExtensionNode
    {
        #region Fields

        public Dictionary<string, object> Commands = new Dictionary<string, object>();

        public string Path;

        internal List<ExtensionCommand> Nodes = new List<ExtensionCommand>();

        internal Assembly ass
        {
            get
            {
                return AddinManager.NodesAssembly;
            }
        }

        #endregion

        #region Public Methods and Operators

        public CommandCollection<T> CreateInstances<T>() where T : class
        {
            return new CommandCollection<T>(this.Commands.Values.ToArray().Select(source => source as T).ToArray());
        }

        public CommandCollection<ExtensionCommand> GetCommand()
        {
            var cc = new CommandCollection<ExtensionCommand>();
            foreach (var type in ass.GetTypes())
            {
                foreach (ExtensionCommand node in this.Nodes)
                {
                    if (node.Name == type.Name)
                    {
                        cc.Add((ExtensionCommand)node.Populate(type));
                    }
                }
            }
            return cc;
        }

        #endregion
    }
}