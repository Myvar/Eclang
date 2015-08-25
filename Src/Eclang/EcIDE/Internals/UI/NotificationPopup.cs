namespace EcIDE.UI
{
    using System.Windows.Forms;

    using EcIDE.Contracts;

    using Telerik.WinControls.UI;

    public partial class NotificationPopup : Form
    {
        #region Constructors and Destructors

        public NotificationPopup()
        {
            this.InitializeComponent();

            foreach (Notification notification in NotificationCenter.ToArray())
            {
                if (!notification.Read)
                {
                    var it = new RadListDataItem(notification.Content) { Image = notification.Icon };
                    this.popupItems.Items.Add(it);
                }
            }
        }

        #endregion
    }
}