namespace EcIDE.Contracts.ServiceProviders
{
    using System.Windows.Forms;

    using EcIDE.Addins;

    using Telerik.WinControls.UI.Docking;

    public class WindowService : IServiceProvider
    {
        #region Fields

        private readonly RadDock rda;

        #endregion

        #region Constructors and Destructors

        public WindowService(RadDock rda)
        {
            this.rda = rda;
        }

        #endregion

        #region Public Methods and Operators

        public void AddDocument(string title, DockPosition pos, Control c)
        {
            c.Dock = DockStyle.Fill;
            var windowTop = new DocumentWindow { Text = title, Name = title };
            windowTop.Controls.Add(c);
            this.rda.AddDocument(windowTop, pos);
        }

        public ToolWindow AddToolWindow(string title, DockPosition pos, Control c)
        {
            c.Dock = DockStyle.Fill;
            var windowTop = new ToolWindow { Text = title, Name = title };
            windowTop.Controls.Add(c);
            this.rda.DockWindow(windowTop, pos);
            return windowTop;
        }

        public void Display(ToolWindow tw)
        {
            rda.DisplayWindow(tw);
        }

        #endregion
    }
}