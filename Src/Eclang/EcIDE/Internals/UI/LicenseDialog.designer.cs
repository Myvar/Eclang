namespace EcIDE.UI
{
    using System.Windows.Forms;

    using EcIDE.Internals;

    partial class LicenseDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LicenseDialog));
            this.label1 = new System.Windows.Forms.Label();
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.notValidErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.licenceEdit1 = new EcIDE.Internals.LicenceEdit();
            ((System.ComponentModel.ISupportInitialize)(this.notValidErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Please enter your licence key to upgrade EcIDE";
            // 
            // okBtn
            // 
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.Enabled = false;
            this.okBtn.Location = new System.Drawing.Point(205, 59);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(102, 24);
            this.okBtn.TabIndex = 2;
            this.okBtn.Text = "OK";
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(15, 59);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(89, 24);
            this.cancelBtn.TabIndex = 3;
            this.cancelBtn.Text = "Cancel";
            // 
            // notValidErrorProvider
            // 
            this.notValidErrorProvider.ContainerControl = this;
            // 
            // licenceEdit1
            // 
            this.licenceEdit1.BackColor = System.Drawing.Color.White;
            this.licenceEdit1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.licenceEdit1.Location = new System.Drawing.Point(15, 29);
            this.licenceEdit1.Name = "licenceEdit1";
            this.licenceEdit1.Size = new System.Drawing.Size(292, 24);
            this.licenceEdit1.SplitterColor = System.Drawing.SystemColors.ControlText;
            this.licenceEdit1.TabIndex = 4;
            this.licenceEdit1.TextChanged += new System.EventHandler(this.licenceEdit1_TextChanged);
            // 
            // LicenseDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 88);
            this.Controls.Add(this.licenceEdit1);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LicenseDialog";
            this.Text = "License";
            ((System.ComponentModel.ISupportInitialize)(this.notValidErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Button okBtn;
        private Button cancelBtn;
        private ErrorProvider notValidErrorProvider;
        private LicenceEdit licenceEdit1;


    }
}
