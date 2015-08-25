namespace EcIDE.Core
{
    using System;
    using System.Windows.Forms;

    using EcIDE.Addins;
    using EcIDE.Contracts;
    using EcIDE.Contracts.ServiceProviders;

    using FastColoredTextBoxNS;

    using Telerik.WinControls.UI.Docking;

    public class Startup : ICommand
    {
        #region Fields

        private Addin ass;

        private EditorService ed;

        private ServiceContainer sc;

        #endregion

        #region Public Methods and Operators

        public void Init(ServiceContainer sp)
        {
            this.sc = sp;
        }

        public void Run()
        {
        }

        #endregion

        #region Methods

        private void OnClick(object sender, EventArgs eventArgs)
        {
            this.ed.GetEditor().DoAutoIndent();
            this.sc.GetService<NotificationService>().Show(this.ass.Icon, this.ass.Name, "Hello Alert from Addin");
        }

        private void OnTextChanged(object sender, TextChangedEventArgs textChangedEventArgs)
        {
            MessageBox.Show((sender as FastColoredTextBox).Text);
        }

        #endregion
    }
}