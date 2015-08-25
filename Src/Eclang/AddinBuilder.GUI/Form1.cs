using System;
using System.Windows.Forms;

namespace AddinBuilder.GUI
{
    using System.IO;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LicenseBrowseButton_Click(object sender, EventArgs e)
        {
            if (ofdLicense.ShowDialog() == DialogResult.OK)
            {
                var f = Path.GetFileName(ofdLicense.FileName);
                tblicense.Text = f;
            }
        }

        private void IconBrowseButton_Click(object sender, EventArgs e)
        {
            if (ofdIcon.ShowDialog() == DialogResult.OK)
            {
                var f = Path.GetFileName(ofdLicense.FileName);
                tbIcon.Text = f;
            }
        }

        private void AssemblyBrowseButton_Click(object sender, EventArgs e)
        {
            if (ofdAssembly.ShowDialog() == DialogResult.OK)
            {
                var f = Path.GetFileName(ofdLicense.FileName);
                tbAssembly.Text = f;
            }
        }
    }
}
