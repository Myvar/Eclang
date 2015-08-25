using System;
using System.Windows.Forms;
using EcIDE.Contracts;
using EcIDE.Contracts.ServiceProviders;

using Telerik.WinControls.UI.Docking;

namespace MyvarEcAddin
{
    using EcIDE.Addins;

    public class Menu : IMenu
    {
        private WindowService ws;
        public void Init(ServiceContainer sp)
        {
            ws = sp.GetService<WindowService>();
        }

        public void OnClick(object sender, EventArgs e)
        {
            ToolWindow con = ComponentStorage.Get("container") as ToolWindow;
            ws.Display(con);
        }

        public void OnTextChanged(object sender, EventArgs e)
        {
            MessageBox.Show((sender as ToolStripTextBox).Text);
        }
    }
}
