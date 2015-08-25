namespace EcIDE.Internals.UI.UIControls
{
    using System.Windows.Forms;

    using EcIDE.Addins;

    public class UIButton : ExtensionCommand
    {
        public UIButton()
        {
            button = new Button();
        }

        private Button button;

        public string text
        {
            get
            {
                return button.Text;
            }
            set
            {
                button.Text = value;
            }
        }

        public Button Get()
        {
            return button;
        }
    }
}
