namespace EcIDE.Internals.UI.ShellControl
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    ///     Summary description for ShellControl.
    /// </summary>
    public class ShellControl : UserControl
    {
        #region Fields

        /// <summary>
        ///     Required designer variable.
        /// </summary>
        private readonly Container components = null;

        private ShellTextBox shellTextBox;

        #endregion

        #region Constructors and Destructors

        public ShellControl()
        {
            // This call is required by the Windows.Forms Form Designer.
            this.InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call
        }

        #endregion

        #region Public Events

        public event EventCommandEntered CommandEntered;

        #endregion

        #region Public Properties

        public string Prompt
        {
            get
            {
                return this.shellTextBox.Prompt;
            }
            set
            {
                this.shellTextBox.Prompt = value;
            }
        }

        public Color ShellTextBackColor
        {
            get
            {
                return this.shellTextBox != null ? this.shellTextBox.BackColor : Color.Black;
            }
            set
            {
                if (this.shellTextBox != null)
                {
                    this.shellTextBox.BackColor = value;
                }
            }
        }

        public Font ShellTextFont
        {
            get
            {
                return this.shellTextBox != null ? this.shellTextBox.Font : new Font("Tahoma", 8);
            }
            set
            {
                if (this.shellTextBox != null)
                {
                    this.shellTextBox.Font = value;
                }
            }
        }

        public Color ShellTextForeColor
        {
            get
            {
                return this.shellTextBox != null ? this.shellTextBox.ForeColor : Color.Green;
            }
            set
            {
                if (this.shellTextBox != null)
                {
                    this.shellTextBox.ForeColor = value;
                }
            }
        }

        #endregion

        #region Public Methods and Operators

        public void Clear()
        {
            this.shellTextBox.Clear();
        }

        public string[] GetCommandHistory()
        {
            return this.shellTextBox.GetCommandHistory();
        }

        public void WriteText(string text)
        {
            this.shellTextBox.WriteText(text);
        }

        #endregion

        #region Methods

        internal void FireCommandEntered(string command)
        {
            this.OnCommandEntered(command);
        }

        /// <summary>
        ///     Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.components != null)
                {
                    this.components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        protected virtual void OnCommandEntered(string command)
        {
            if (this.CommandEntered != null)
            {
                this.CommandEntered(command, new CommandEnteredEventArgs(command));
            }
        }

        /// <summary>
        ///     Required method for Designer support - do not modify
        ///     the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.shellTextBox = new ShellTextBox();
            this.SuspendLayout();
            // 
            // shellTextBox
            // 
            this.shellTextBox.AcceptsReturn = true;
            this.shellTextBox.AcceptsTab = true;
            this.shellTextBox.BackColor = System.Drawing.Color.Black;
            this.shellTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shellTextBox.ForeColor = System.Drawing.Color.LawnGreen;
            this.shellTextBox.Location = new System.Drawing.Point(0, 0);
            this.shellTextBox.Multiline = true;
            this.shellTextBox.Name = "shellTextBox";
            this.shellTextBox.Prompt = ">>>";
            this.shellTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.shellTextBox.BackColor = System.Drawing.Color.Black;
            this.shellTextBox.Font = new System.Drawing.Font(
                "Tahoma",
                8.25F,
                System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point,
                ((System.Byte)(0)));
            this.shellTextBox.ForeColor = System.Drawing.Color.LawnGreen;
            this.shellTextBox.Size = new System.Drawing.Size(232, 216);
            this.shellTextBox.TabIndex = 0;
            this.shellTextBox.Text = "";
            // 
            // ShellControl
            // 
            this.Controls.Add(this.shellTextBox);
            this.Name = "ShellControl";
            this.Size = new System.Drawing.Size(232, 216);
            this.ResumeLayout(false);
        }

        #endregion
    }

    public class CommandEnteredEventArgs : EventArgs
    {
        #region Fields

        private readonly string command;

        #endregion

        #region Constructors and Destructors

        public CommandEnteredEventArgs(string command)
        {
            this.command = command;
        }

        #endregion

        #region Public Properties

        public string Command
        {
            get
            {
                return this.command;
            }
        }

        #endregion
    }

    public delegate void EventCommandEntered(object sender, CommandEnteredEventArgs e);
}