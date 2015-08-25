namespace AddinInstaller
{
    using System.Drawing;
    using System.Windows.Forms;

    using AddinInstaller.Properties;

    public sealed class StatusButton : Button
    {
        public enum Status
        {
            Working,
            Done,
            Waiting,
            Canceled
        }

        private Status _workingStatus;
        public Status WorkingStatus
        {
            get
            {
                return _workingStatus;
            }
            set
            {
                switch (value)
                {
                    case Status.Waiting:
                        Image = null;
                        break;
                    case Status.Working:
                        Image = Resources.ajax_loader;
                        break;
                    case Status.Done:
                        Image = Resources.check_icon;
                        break;
                    case Status.Canceled:
                        Image = Resources.cross_icon;
                        break;
                }
                _workingStatus = value;
            }
        }

        #region Constructors and Destructors

        public StatusButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.ImageAlign = ContentAlignment.MiddleLeft;
            this.TextAlign = ContentAlignment.MiddleLeft;
            this.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.FlatAppearance.BorderSize = 0;
            this.FlatAppearance.MouseDownBackColor = SystemColors.Control;
            this.FlatAppearance.MouseOverBackColor = SystemColors.Control;
        }

        #endregion
    }
}