namespace EcIDE
{
    using EcIDE.Addins;
    using EcIDE.Contracts;
    using EcIDE.Contracts.UI.Options;
    using EcIDE.Internals;
    using EcIDE.OptionPages;

    public partial class OptionsForm : Contracts.UI.Options.OptionsForm
    {
        private CommandCollection<IOptionPage> cmd; 
        public OptionsForm()
        {
            InitializeComponent();

            Panels.Add(new General());

            foreach (ExtensionNode node in AddinManager.GetExtensionObjects("/EcIDE/Options"))
            {
                cmd = node.CreateInstances<IOptionPage>();

                cmd.ForEach(c => c.Init(new ServiceContainer()));

                cmd.ForEach(c => Panels.Add(c.GetPage()));
            }
        }

        private void OptionsForm_OptionsSaving(object sender, System.EventArgs e)
        {
            cmd.ForEach(page => page.OnSave());
            OptionsManager.Save();
        }
    }
}
