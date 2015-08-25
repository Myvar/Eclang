namespace EcIDE.Internals.UI.ShellControl
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;

    internal class ShellTextBox : TextBox
    {
        #region Fields

        private readonly CommandHistory commandHistory = new CommandHistory();

        /// <summary>
        ///     Required designer variable.
        /// </summary>
        private readonly Container components = null;

        private string prompt = ">>>";

        #endregion

        #region Constructors and Destructors

        internal ShellTextBox()
        {
            // This call is required by the Windows.Forms Form Designer.
            this.InitializeComponent();
            this.printPrompt();
        }

        #endregion

        #region Public Properties

        public string Prompt
        {
            get
            {
                return this.prompt;
            }
            set
            {
                this.SetPromptText(value);
            }
        }

        #endregion

        #region Public Methods and Operators

        public string[] GetCommandHistory()
        {
            return this.commandHistory.GetCommandHistory();
        }

        public void WriteText(string text)
        {
            this.AddText(text);
        }

        #endregion

        #region Methods

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

        // Overridden to protect against deletion of contents
        // cutting the text and deleting it from the context menu
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x0302: //WM_PASTE
                case 0x0300: //WM_CUT
                case 0x000C: //WM_SETTEXT
                    if (!this.IsCaretAtWritablePosition())
                    {
                        this.MoveCaretToEndOfText();
                    }
                    break;
                case 0x0303: //WM_CLEAR
                    return;
            }
            base.WndProc(ref m);
        }

        private void AddText(string text)
        {
            this.Text += text;
            this.MoveCaretToEndOfText();
        }

        private int GetCurrentCaretColumnPosition()
        {
            string currentLine = this.GetCurrentLine();
            int currentCaretPosition = this.SelectionStart;
            return (currentCaretPosition - this.TextLength + currentLine.Length);
        }

        private string GetCurrentLine()
        {
            if (this.Lines.Length > 0)
            {
                return (string)this.Lines.GetValue(this.Lines.GetLength(0) - 1);
            }
            return "";
        }

        private string GetTextAtPrompt()
        {
            return this.GetCurrentLine().Substring(this.prompt.Length);
        }

        /// <summary>
        ///     Required method for Designer support - do not modify
        ///     the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // shellTextBox
            // 
            this.BackColor = System.Drawing.Color.Black;
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ForeColor = System.Drawing.Color.LawnGreen;
            this.Location = new System.Drawing.Point(0, 0);
            this.MaxLength = 0;
            this.Multiline = true;
            this.Name = "shellTextBox";
            this.AcceptsTab = true;
            this.AcceptsReturn = true;
            this.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Size = new System.Drawing.Size(400, 176);
            this.TabIndex = 0;
            this.Text = "";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.shellTextBox_KeyPress);
            this.KeyDown += new KeyEventHandler(this.ShellControl_KeyDown);
            // 
            // ShellControl
            // 
            this.Name = "ShellTextBox";
            this.Size = new System.Drawing.Size(400, 176);
            this.ResumeLayout(false);
        }

        private bool IsCaretAtCurrentLine()
        {
            return this.TextLength - this.SelectionStart <= this.GetCurrentLine().Length;
        }

        private bool IsCaretAtWritablePosition()
        {
            return this.IsCaretAtCurrentLine() && this.GetCurrentCaretColumnPosition() >= this.prompt.Length;
        }

        private bool IsCaretJustBeforePrompt()
        {
            return this.IsCaretAtCurrentLine() && this.GetCurrentCaretColumnPosition() == this.prompt.Length;
        }

        private bool IsTerminatorKey(Keys key)
        {
            return key == Keys.Enter;
        }

        private bool IsTerminatorKey(char keyChar)
        {
            return keyChar == 13;
        }

        private void MoveCaretToEndOfText()
        {
            this.SelectionStart = this.TextLength;
            this.ScrollToCaret();
        }

        private void ReplaceTextAtPrompt(string text)
        {
            string currentLine = this.GetCurrentLine();
            int charactersAfterPrompt = currentLine.Length - this.prompt.Length;

            if (charactersAfterPrompt == 0)
            {
                this.AddText(text);
            }
            else
            {
                this.Select(this.TextLength - charactersAfterPrompt, charactersAfterPrompt);
                this.SelectedText = text;
            }
        }

        private void SetPromptText(string val)
        {
            string currentLine = this.GetCurrentLine();
            this.Select(0, this.prompt.Length);
            this.SelectedText = val;

            this.prompt = val;
        }

        private void ShellControl_KeyDown(object sender, KeyEventArgs e)
        {
            // If the caret is anywhere else, set it back when a key is pressed.
            if (!this.IsCaretAtWritablePosition() && !(e.Control || this.IsTerminatorKey(e.KeyCode)))
            {
                this.MoveCaretToEndOfText();
            }

            // Prevent caret from moving before the prompt
            if (e.KeyCode == Keys.Left && this.IsCaretJustBeforePrompt())
            {
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (this.commandHistory.DoesNextCommandExist())
                {
                    this.ReplaceTextAtPrompt(this.commandHistory.GetNextCommand());
                }
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (this.commandHistory.DoesPreviousCommandExist())
                {
                    this.ReplaceTextAtPrompt(this.commandHistory.GetPreviousCommand());
                }
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Right)
            {
                // Performs command completion
                string currentTextAtPrompt = this.GetTextAtPrompt();
                string lastCommand = this.commandHistory.LastCommand;

                if (lastCommand != null
                    && (currentTextAtPrompt.Length == 0 || lastCommand.StartsWith(currentTextAtPrompt)))
                {
                    if (lastCommand.Length > currentTextAtPrompt.Length)
                    {
                        this.AddText(lastCommand[currentTextAtPrompt.Length].ToString());
                    }
                }
            }
        }

        private void printLine()
        {
            this.AddText(Environment.NewLine);
        }

        private void printPrompt()
        {
            string currentText = this.Text;
            if (currentText.Length != 0 && currentText[currentText.Length - 1] != '\n')
            {
                this.printLine();
            }
            this.AddText(this.prompt);
        }

        private void shellTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Handle backspace
            if (e.KeyChar == (char)8 && this.IsCaretJustBeforePrompt())
            {
                e.Handled = true;
                return;
            }

            if (this.IsTerminatorKey(e.KeyChar))
            {
                e.Handled = true;
                string currentCommand = this.GetTextAtPrompt();
                if (currentCommand.Length != 0)
                {
                    this.printLine();
                    ((ShellControl)this.Parent).FireCommandEntered(currentCommand);
                    this.commandHistory.Add(currentCommand);
                }
                this.printPrompt();
            }
        }

        #endregion

        // Substitute for buggy AppendText()
    }
}