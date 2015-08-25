namespace EcIDE.Internals
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    [DefaultEvent("TextChanged")]
    public partial class LicenceEdit : UserControl
    {
        #region Constants

        private const int WM_PASTE = 0x0302;

        #endregion

        #region Constructors and Destructors

        public LicenceEdit()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Public Events

        public new event EventHandler TextChanged;

        #endregion

        #region Public Properties

        public new Color BackColor
        {
            get
            {
                return this.textBox1.BackColor;
            }
            set
            {
                this.textBox1.BackColor = value;
                this.textBox2.BackColor = value;
                this.textBox3.BackColor = value;
                this.textBox4.BackColor = value;
                base.BackColor = value;
            }
        }

        public new Font Font
        {
            get
            {
                return this.textBox1.Font;
            }
            set
            {
                this.textBox1.Font = value;
                this.textBox2.Font = value;
                this.textBox3.Font = value;
                this.textBox4.Font = value;
                base.Font = value;
            }
        }

        public new Color ForeColor
        {
            get
            {
                return this.textBox1.ForeColor;
            }
            set
            {
                this.textBox1.ForeColor = value;
                this.textBox2.ForeColor = value;
                this.textBox3.ForeColor = value;
                this.textBox4.ForeColor = value;
                base.ForeColor = value;
            }
        }

        public Color SplitterColor
        {
            get
            {
                return this.label1.ForeColor;
            }
            set
            {
                this.label1.ForeColor = value;
                this.label2.ForeColor = value;
                this.label3.ForeColor = value;
            }
        }

        public new string Text
        {
            get
            {
                return this.textBox1.Text + "-" + this.textBox2.Text + "-" + this.textBox3.Text + "-"
                       + this.textBox4.Text;
            }
            set
            {
                this.TextChanged(this, null);
                this.parse(value);
            }
        }

        #endregion

        #region Methods

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_PASTE)
            {
                this.parse(Clipboard.GetText());
            }
            base.WndProc(ref m);
        }

        private void parse(string tp)
        {
            string[] spl = tp.Split('-');

            this.textBox1.Text = spl[0];
            this.textBox2.Text = spl[1];
            this.textBox3.Text = spl[2];
            this.textBox4.Text = spl[3];
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Text = Clipboard.GetText();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.TextChanged(this, null);
            if (this.textBox1.TextLength == this.textBox1.MaxLength)
            {
                this.label1.Visible = true;
                this.textBox2.Focus();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            this.TextChanged(this, null);
            if (this.textBox2.TextLength == this.textBox2.MaxLength)
            {
                this.label2.Visible = true;
                this.textBox3.Focus();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            this.TextChanged(this, null);
            if (this.textBox3.TextLength == this.textBox3.MaxLength)
            {
                this.label3.Visible = true;
                this.textBox4.Focus();
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            this.TextChanged(this, null);
        }

        #endregion
    }
}