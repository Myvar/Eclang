namespace MyvarEcAddin.UI
{
    using EcIDE.Addins;
    using EcIDE.Contracts;
    using EcIDE.Contracts.ServiceProviders;
    using EcIDE.Contracts.UI.Options;

    public class OptionPage : OptionsPanel, IOptionPage
    {
        private System.Windows.Forms.CheckBox enabledCB;
        private System.Windows.Forms.GroupBox groupBox1;

        private OptionsService os;

        public OptionPage()
        {
            CategoryPath = "Addins\\Myvar";
            DisplayName = "Myvar";

            this.InitializeComponent();
        }

        public void Init(ServiceContainer sp)
        {
            os = sp.GetService<OptionsService>();

            enabledCB.Checked = os.Get<bool>("myvar_enabled");
        }

        public OptionsPanel GetPage()
        {
            return this;
        }

        public void OnSave()
        {
            os.Add("myvar_enabled", enabledCB.Checked);
        }

        private void InitializeComponent()
        {
            this.enabledCB = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // enabledCB
            // 
            this.enabledCB.AutoSize = true;
            this.enabledCB.Checked = true;
            this.enabledCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enabledCB.Location = new System.Drawing.Point(6, 19);
            this.enabledCB.Name = "enabledCB";
            this.enabledCB.Size = new System.Drawing.Size(65, 17);
            this.enabledCB.TabIndex = 0;
            this.enabledCB.Text = "Enabled";
            this.enabledCB.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.enabledCB);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General";
            // 
            // OptionPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.groupBox1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "OptionPage";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

    }
}
