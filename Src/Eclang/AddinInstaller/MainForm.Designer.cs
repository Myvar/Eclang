namespace AddinInstaller
{
    using AddinInstaller.Wizard.Steps;

    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.InstallerTimer = new System.Windows.Forms.Timer(this.components);
            this.Wizard = new AddinInstaller.Wizard.Steps.WizardControl();
            this.startStep = new WizardBase.StartStep();
            this.label1 = new System.Windows.Forms.Label();
            this.licenceStep = new AddinInstaller.Wizard.Steps.LicenceStep();
            this.installingStep = new AddinInstaller.Wizard.Steps.IntermediateStep();
            this.statusButton2 = new AddinInstaller.StatusButton();
            this.statusButton1 = new AddinInstaller.StatusButton();
            this.finishStep = new AddinInstaller.Wizard.Steps.FinishStep();
            this.label2 = new System.Windows.Forms.Label();
            this.startStep.SuspendLayout();
            this.installingStep.SuspendLayout();
            this.finishStep.SuspendLayout();
            this.SuspendLayout();
            // 
            // InstallerTimer
            // 
            this.InstallerTimer.Interval = 1;
            this.InstallerTimer.Tick += new System.EventHandler(this.InstallerTimer_Tick);
            // 
            // Wizard
            // 
            this.Wizard.BackButtonEnabled = false;
            this.Wizard.BackButtonVisible = true;
            this.Wizard.CancelButtonEnabled = true;
            this.Wizard.CancelButtonVisible = true;
            this.Wizard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Wizard.Location = new System.Drawing.Point(0, 0);
            this.Wizard.Name = "Wizard";
            this.Wizard.NextButtonEnabled = true;
            this.Wizard.NextButtonVisible = true;
            this.Wizard.Size = new System.Drawing.Size(566, 400);
            this.Wizard.WizardSteps.AddRange(new WizardBase.WizardStep[] {
            this.startStep,
            this.licenceStep,
            this.installingStep,
            this.finishStep});
            this.Wizard.FinishButtonClick += new System.EventHandler(this.Wizard_FinishButtonClick);
            // 
            // startStep
            // 
            this.startStep.BindingImage = ((System.Drawing.Image)(resources.GetObject("startStep.BindingImage")));
            this.startStep.Controls.Add(this.label1);
            this.startStep.Icon = ((System.Drawing.Image)(resources.GetObject("startStep.Icon")));
            this.startStep.Name = "startStep";
            this.startStep.Subtitle = "";
            this.startStep.Title = "Welcome to the EcIDE AddinInstaller";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(179, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Follow the steps to install the Addin";
            // 
            // licenceStep
            // 
            this.licenceStep.BindingImage = ((System.Drawing.Image)(resources.GetObject("licenceStep.BindingImage")));
            this.licenceStep.License = "";
            this.licenceStep.Name = "licenceStep";
            this.licenceStep.Title = "License Agreement.";
            this.licenceStep.Warning = "Please read the following license agreement. You must accept the terms  of this a" +
    "greement before continuing.";
            this.licenceStep.WarningFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            // 
            // installingStep
            // 
            this.installingStep.BindingImage = ((System.Drawing.Image)(resources.GetObject("installingStep.BindingImage")));
            this.installingStep.Controls.Add(this.statusButton2);
            this.installingStep.Controls.Add(this.statusButton1);
            this.installingStep.ForeColor = System.Drawing.SystemColors.ControlText;
            this.installingStep.Name = "installingStep";
            this.installingStep.Subtitle = "";
            this.installingStep.Title = "Installing Addin";
            // 
            // statusButton2
            // 
            this.statusButton2.FlatAppearance.BorderSize = 0;
            this.statusButton2.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.statusButton2.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.statusButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.statusButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.statusButton2.Location = new System.Drawing.Point(12, 105);
            this.statusButton2.Name = "statusButton2";
            this.statusButton2.Size = new System.Drawing.Size(542, 23);
            this.statusButton2.TabIndex = 1;
            this.statusButton2.Text = "Installing Dependencies ({0} of {1})";
            this.statusButton2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.statusButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.statusButton2.UseVisualStyleBackColor = true;
            this.statusButton2.WorkingStatus = AddinInstaller.StatusButton.Status.Waiting;
            // 
            // statusButton1
            // 
            this.statusButton1.FlatAppearance.BorderSize = 0;
            this.statusButton1.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.statusButton1.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.statusButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.statusButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.statusButton1.Location = new System.Drawing.Point(12, 76);
            this.statusButton1.Name = "statusButton1";
            this.statusButton1.Size = new System.Drawing.Size(542, 23);
            this.statusButton1.TabIndex = 0;
            this.statusButton1.Text = "Installing Addin";
            this.statusButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.statusButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.statusButton1.UseVisualStyleBackColor = true;
            this.statusButton1.WorkingStatus = AddinInstaller.StatusButton.Status.Waiting;
            // 
            // finishStep
            // 
            this.finishStep.BindingImage = ((System.Drawing.Image)(resources.GetObject("finishStep.BindingImage")));
            this.finishStep.Controls.Add(this.label2);
            this.finishStep.Name = "finishStep";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(256, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "The Addin was installed into EcIDE";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 400);
            this.Controls.Add(this.Wizard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Install Addin";
            this.startStep.ResumeLayout(false);
            this.startStep.PerformLayout();
            this.installingStep.ResumeLayout(false);
            this.finishStep.ResumeLayout(false);
            this.finishStep.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private WizardControl Wizard;
        private WizardBase.StartStep startStep;
        private Wizard.Steps.LicenceStep licenceStep;
        private Wizard.Steps.IntermediateStep installingStep;
        private Wizard.Steps.FinishStep finishStep;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private StatusButton statusButton2;
        private StatusButton statusButton1;
        private System.Windows.Forms.Timer InstallerTimer;
    }
}

