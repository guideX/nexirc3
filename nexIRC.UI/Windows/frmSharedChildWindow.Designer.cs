namespace nexIRC.UI.Windows {
    partial class frmSharedChildWindow {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.office2010BlackTheme1 = new Telerik.WinControls.Themes.Office2010BlackTheme();
            this.txtIncoming = new Telerik.WinControls.UI.RadTextBox();
            this.txtOutgoing = new Telerik.WinControls.UI.RadTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtIncoming)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOutgoing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // txtIncoming
            // 
            this.txtIncoming.Location = new System.Drawing.Point(0, 0);
            this.txtIncoming.Multiline = true;
            this.txtIncoming.Name = "txtIncoming";
            // 
            // 
            // 
            this.txtIncoming.RootElement.StretchVertically = true;
            this.txtIncoming.Size = new System.Drawing.Size(347, 125);
            this.txtIncoming.TabIndex = 0;
            this.txtIncoming.TabStop = false;
            this.txtIncoming.Visible = false;
            // 
            // txtOutgoing
            // 
            this.txtOutgoing.Location = new System.Drawing.Point(0, 131);
            this.txtOutgoing.Name = "txtOutgoing";
            this.txtOutgoing.Size = new System.Drawing.Size(347, 20);
            this.txtOutgoing.TabIndex = 0;
            this.txtOutgoing.TabStop = false;
            this.txtOutgoing.Visible = false;
            // 
            // frmSharedChildWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 190);
            this.Controls.Add(this.txtOutgoing);
            this.Controls.Add(this.txtIncoming);
            this.Name = "frmSharedChildWindow";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.Text = "nexIRC";
            this.ThemeName = "Office2010Black";
            this.Load += new System.EventHandler(this.frmSharedChildWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtIncoming)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOutgoing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.Office2010BlackTheme office2010BlackTheme1;
        public Telerik.WinControls.UI.RadTextBox txtIncoming;
        public Telerik.WinControls.UI.RadTextBox txtOutgoing;
    }
}