namespace EcIDE.Contracts
{
    using System.Collections.Generic;
    using System.Drawing;

    using Telerik.WinControls.UI;

    public class NotificationCenter
    {
        #region Static Fields

        public static RadDesktopAlert not;

        private static readonly List<Notification> notifications = new List<Notification>();

        #endregion

        #region Public Methods and Operators

        public static void ShowNotification(Image icon, string title, string message)
        {
            notifications.Add(new Notification { Icon = icon, Content = message, Title = title });
            not.ContentImage = icon;
            not.ContentText = message;
            not.CaptionText = title;
            not.Show();
        }

        public static Notification[] ToArray()
        {
            return notifications.ToArray();
        }

        #endregion
    }
}