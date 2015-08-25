namespace EcIDE.Internals.Console
{
    using System;
    using System.IO;
    using System.Windows.Forms;

    public class TextBoxReader : TextReader
    {
        #region Fields

        public Boolean snd = false;

        #endregion

        #region Public Methods and Operators

        public override string ReadLine()
        {
            while (true)
            {
                Application.DoEvents();
                ;
                if (this.snd)
                {
                    this.snd = false;
                    return MainForm.sndtxt;
                }
            }
        }

        #endregion
    }
}