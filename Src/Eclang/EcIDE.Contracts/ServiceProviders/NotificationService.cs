namespace EcIDE.Contracts.ServiceProviders
{
    using System.Drawing;

    using EcIDE.Addins;

    using Telerik.WinControls.UI;

    public class NotificationService : IServiceProvider
    {
        #region Fields

        private readonly RadDesktopAlert rda;

        #endregion

        #region Constructors and Destructors

        public NotificationService(RadDesktopAlert rda)
        {
            this.rda = rda;
        }

        #endregion

        #region Public Methods and Operators

        public Notification[] GetNotifications()
        {
            return NotificationCenter.ToArray();
        }

        public void Show(Image icon, string title, string message)
        {
            NotificationCenter.not = this.rda;
            NotificationCenter.ShowNotification(icon, title, message);
        }

        #endregion
    }
}