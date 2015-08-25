namespace EcIDE.UI
{
    using Telerik.WinControls.UI;

    partial class NotificationPopup
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

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.popupItems = new Telerik.WinControls.UI.RadListControl();
            ((System.ComponentModel.ISupportInitialize)(this.popupItems)).BeginInit();
            this.SuspendLayout();
            // 
            // popupItems
            // 
            this.popupItems.AutoSizeItems = true;
            this.popupItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.popupItems.Location = new System.Drawing.Point(0, 0);
            this.popupItems.Name = "popupItems";
            this.popupItems.Size = new System.Drawing.Size(146, 158);
            this.popupItems.TabIndex = 0;
            // 
            // NotificationPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(146, 158);
            this.Controls.Add(this.popupItems);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NotificationPopup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            ((System.ComponentModel.ISupportInitialize)(this.popupItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public RadListControl popupItems;

    }
}
