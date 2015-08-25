using System.Windows.Forms;

namespace AddinInstaller
{
    using System;
    using System.Drawing;
    using System.IO;

    using Addin.Installer;

    using AddinInstaller.Wizard.EventArgs;

    public partial class MainForm : Form
    {
        public AddinInstallerFile Aif { get; set; }

        public MainForm(AddinInstallerFile aif)
        {
            this.Aif = aif;
            InitializeComponent();

            licenceStep.License = aif.License;
            licenceStep.AgreementChanged += LicenceStepOnAgreementChanged;

            Wizard.NextButtonClick += Wizard_NextButtonClick;

            if (aif.Icon != null)
            {
                var ico = new MemoryStream(aif.Icon);
                startStep.Icon = new Icon(ico).ToBitmap();
            }
        }

        void Wizard_NextButtonClick(object sender, GenericCancelEventArgs<Wizard.Steps.WizardControl> tArgs)
        {
            if (Wizard.WizardSteps[Wizard.CurrentStepIndex].Name == startStep.Name)
            {
                Wizard.NextButtonEnabled = false;
            }
            if (Wizard.WizardSteps[Wizard.CurrentStepIndex].Name == licenceStep.Name)
            {
                Wizard.NextButtonEnabled = false;
                InstallerTimer.Start();
            }
        }

        private void LicenceStepOnAgreementChanged(object sender, GenericEventArgs<bool> tArgs)
        {
            this.Wizard.NextButtonEnabled = tArgs.Value;
        }

        private void Wizard_FinishButtonClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void InstallerTimer_Tick(object sender, EventArgs e)
        {
            if (statusButton1.WorkingStatus == StatusButton.Status.Done)
            {
                statusButton2.WorkingStatus = StatusButton.Status.Working;
            }
            if (statusButton1.WorkingStatus == StatusButton.Status.Waiting)
            {
                statusButton1.WorkingStatus = StatusButton.Status.Working;

                try
                {
                    File.WriteAllBytes(
                        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\EcIDE\\addins\\"
                        + Aif.Assembly.Key,
                        Aif.Assembly.Value);
                    statusButton1.WorkingStatus = StatusButton.Status.Done;
                }
                catch
                {
                    statusButton1.WorkingStatus = StatusButton.Status.Canceled;
                }
            }
            if (statusButton1.WorkingStatus == StatusButton.Status.Canceled || statusButton2.WorkingStatus == StatusButton.Status.Canceled)
            {
                Wizard.CurrentStepIndex = Wizard.WizardSteps.Count - 1;
                label2.Text = "The Addin was not installed";
                Wizard.NextButtonEnabled = true;
            }
        }
    }
}
