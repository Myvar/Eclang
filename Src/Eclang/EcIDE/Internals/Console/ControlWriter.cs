namespace EcIDE.Internals.Console
{
    using System;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;

    using EcIDE.Internals.UI.ShellControl;

    public class ControlWriter : TextWriter
    {
        #region Fields

        private readonly ShellControl textbox;

        private string tmp = "";

        #endregion

        #region Constructors and Destructors

        public ControlWriter(ShellControl textbox)
        {
            this.textbox = textbox;
        }

        #endregion

        #region Public Properties

        public override Encoding Encoding
        {
            get
            {
                return Encoding.ASCII;
            }
        }

        #endregion

        #region Public Methods and Operators

        public override void Write(char value)
        {
            if (value == '\n')
            {
                textbox.WriteText(tmp);
                this.tmp = "";
            }
            else
            {
                this.tmp += Convert.ToString(value);
            }
        }

        public override void Write(string value)
        {
            textbox.WriteText(tmp);
        }

        public override void WriteLine(string value)
        {
            textbox.WriteText(value);
        }

        #endregion
    }
}