namespace AddinBuilder.GUI
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tblicense = new System.Windows.Forms.TextBox();
            this.tbIcon = new System.Windows.Forms.TextBox();
            this.tbAssembly = new System.Windows.Forms.TextBox();
            this.BtnBuild = new System.Windows.Forms.Button();
            this.LicenseBrowseButton = new System.Windows.Forms.Button();
            this.IconBrowseButton = new System.Windows.Forms.Button();
            this.AssemblyBrowseButton = new System.Windows.Forms.Button();
            this.ofdLicense = new System.Windows.Forms.OpenFileDialog();
            this.ofdIcon = new System.Windows.Forms.OpenFileDialog();
            this.ofdAssembly = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "License-File";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Icon";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Assembly";
            // 
            // tblicense
            // 
            this.tblicense.Location = new System.Drawing.Point(82, 10);
            this.tblicense.Name = "tblicense";
            this.tblicense.Size = new System.Drawing.Size(166, 20);
            this.tblicense.TabIndex = 3;
            // 
            // tbIcon
            // 
            this.tbIcon.Location = new System.Drawing.Point(82, 35);
            this.tbIcon.Name = "tbIcon";
            this.tbIcon.Size = new System.Drawing.Size(166, 20);
            this.tbIcon.TabIndex = 4;
            // 
            // tbAssembly
            // 
            this.tbAssembly.Location = new System.Drawing.Point(82, 57);
            this.tbAssembly.Name = "tbAssembly";
            this.tbAssembly.Size = new System.Drawing.Size(166, 20);
            this.tbAssembly.TabIndex = 5;
            // 
            // BtnBuild
            // 
            this.BtnBuild.Location = new System.Drawing.Point(210, 92);
            this.BtnBuild.Name = "BtnBuild";
            this.BtnBuild.Size = new System.Drawing.Size(75, 23);
            this.BtnBuild.TabIndex = 6;
            this.BtnBuild.Text = "Build";
            this.BtnBuild.UseVisualStyleBackColor = true;
            // 
            // LicenseBrowseButton
            // 
            this.LicenseBrowseButton.Location = new System.Drawing.Point(255, 10);
            this.LicenseBrowseButton.Name = "LicenseBrowseButton";
            this.LicenseBrowseButton.Size = new System.Drawing.Size(30, 23);
            this.LicenseBrowseButton.TabIndex = 7;
            this.LicenseBrowseButton.Text = "...";
            this.LicenseBrowseButton.UseVisualStyleBackColor = true;
            this.LicenseBrowseButton.Click += new System.EventHandler(this.LicenseBrowseButton_Click);
            // 
            // IconBrowseButton
            // 
            this.IconBrowseButton.Location = new System.Drawing.Point(255, 33);
            this.IconBrowseButton.Name = "IconBrowseButton";
            this.IconBrowseButton.Size = new System.Drawing.Size(30, 23);
            this.IconBrowseButton.TabIndex = 8;
            this.IconBrowseButton.Text = "...";
            this.IconBrowseButton.UseVisualStyleBackColor = true;
            this.IconBrowseButton.Click += new System.EventHandler(this.IconBrowseButton_Click);
            // 
            // AssemblyBrowseButton
            // 
            this.AssemblyBrowseButton.Location = new System.Drawing.Point(255, 57);
            this.AssemblyBrowseButton.Name = "AssemblyBrowseButton";
            this.AssemblyBrowseButton.Size = new System.Drawing.Size(30, 23);
            this.AssemblyBrowseButton.TabIndex = 9;
            this.AssemblyBrowseButton.Text = "...";
            this.AssemblyBrowseButton.UseVisualStyleBackColor = true;
            this.AssemblyBrowseButton.Click += new System.EventHandler(this.AssemblyBrowseButton_Click);
            // 
            // ofdLicense
            // 
            this.ofdLicense.Filter = "License File (*.txt||*.rtf)|*.txt||*.rtf";
            // 
            // ofdIcon
            // 
            this.ofdIcon.Filter = "Icon File (*.ico)|*.ico";
            // 
            // ofdAssembly
            // 
            this.ofdAssembly.Filter = "Assembly (*.dll)|*.dll";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 127);
            this.Controls.Add(this.AssemblyBrowseButton);
            this.Controls.Add(this.IconBrowseButton);
            this.Controls.Add(this.LicenseBrowseButton);
            this.Controls.Add(this.BtnBuild);
            this.Controls.Add(this.tbAssembly);
            this.Controls.Add(this.tbIcon);
            this.Controls.Add(this.tblicense);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "AddinInstaller Builder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tblicense;
        private System.Windows.Forms.TextBox tbIcon;
        private System.Windows.Forms.TextBox tbAssembly;
        private System.Windows.Forms.Button BtnBuild;
        private System.Windows.Forms.Button LicenseBrowseButton;
        private System.Windows.Forms.Button IconBrowseButton;
        private System.Windows.Forms.Button AssemblyBrowseButton;
        private System.Windows.Forms.OpenFileDialog ofdLicense;
        private System.Windows.Forms.OpenFileDialog ofdIcon;
        private System.Windows.Forms.OpenFileDialog ofdAssembly;
    }
}

