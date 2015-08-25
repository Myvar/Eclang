namespace EcIDE.UI
{
    using System;
    using System.Windows.Forms;

    using EcIDE.Internals;

    public partial class LicenseDialog : Form
    {
        #region Constructors and Destructors

        public LicenseDialog()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Public Properties

        public string Key
        {
            get
            {
                return licenceEdit1.Text;
            }
        }

        #endregion

        #region Methods

        private void licenceEdit1_TextChanged(object sender, EventArgs e)
        {
            var k = new Validate();
            k.Key = this.licenceEdit1.Text;
            this.okBtn.Enabled = k.IsValid;
        }

        #endregion
    }
}