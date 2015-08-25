namespace EcIDE.Contracts
{
    using System.Drawing;

    public class Notification
    {
        #region Public Properties

        public string Content { get; set; }

        public Image Icon { get; set; }

        public bool Read { get; set; }

        public string Title { get; set; }

        #endregion
    }
}