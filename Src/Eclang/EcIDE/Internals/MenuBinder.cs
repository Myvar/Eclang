namespace EcIDE.Internals
{
    using System.Windows.Forms;

    using Addins;
    using Contracts;
    using Nodes;

    public class MenuBinder
    {
        public static void Bind(ToolStripMenuItem parent, string path)
        {
            foreach (ExtensionNode node in AddinManager.GetExtensionObjects("/EcIDE/Menu/" + path))
            {
                var cmds = node.GetCommand();

                foreach (var ec in cmds)
                {
                    var eps = ec as separator;
                    if (eps != null)
                    {
                        parent.DropDownItems.Add(new ToolStripSeparator());
                    }

                    var ep = ec as menuitem;
                    if (ep != null)
                    {
                        var target = node.CreateInstances<IMenu>()[0];

                        target.Init(new ServiceContainer());

                        var it = new ToolStripMenuItem(
                            ep.text,
                            null,
                            (sender, args) =>
                                target.GetType().GetMethod(ep.click).Invoke(target, new[] { sender, args }));

                        try
                        {
                            it.Enabled = bool.Parse(ep.enabled);
                        }
                        catch { }

                        parent.DropDownItems.Add(it);
                    }

                    var eptb = ec as textbox;
                    if (eptb != null)
                    {
                        var target = node.CreateInstances<IMenu>()[0];

                        target.Init(new ServiceContainer());

                        var tb = new ToolStripTextBox();
                        tb.TextChanged += (sender, args) => target.GetType().GetMethod(eptb.textchanged).Invoke(target, new[] { sender, args });

                        try
                        {
                            tb.Visible = bool.Parse(eptb.visible);
                        }
                        catch
                        {
                        }

                        parent.DropDownItems.Add(tb);
                    }
                }
            }
        }

        public static void Bind(MenuStrip ms)
        {
            foreach (ToolStripMenuItem item in ms.Items)
            {
                Bind(item, item.Text);
            }
        }

    }
}
