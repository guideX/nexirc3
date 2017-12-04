namespace nexIRC.UI.Windows {
    partial class ChannelListWindow {

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChannelListWindow));
            this.lvwChannels = new Telerik.WinControls.UI.RadListView();
            ((System.ComponentModel.ISupportInitialize)(this.lvwChannels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // lvwChannels
            // 
            this.lvwChannels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwChannels.GroupItemSize = new System.Drawing.Size(200, 20);
            this.lvwChannels.ItemSize = new System.Drawing.Size(200, 20);
            this.lvwChannels.Location = new System.Drawing.Point(0, 0);
            this.lvwChannels.Name = "lvwChannels";
            this.lvwChannels.Size = new System.Drawing.Size(539, 243);
            this.lvwChannels.TabIndex = 0;
            this.lvwChannels.Text = "radListView1";
            this.lvwChannels.ThemeName = "Office2010Black";
            this.lvwChannels.SelectedItemChanged += new Telerik.WinControls.UI.ListViewItemEventHandler(this.lvwChannels_SelectedItemChanged);
            // 
            // ChannelListWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 243);
            this.Controls.Add(this.lvwChannels);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChannelListWindow";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "nexIRC - Channel List";
            this.ThemeName = "Office2010Black";
            this.Load += new System.EventHandler(this.ChannelListWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lvwChannels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadListView lvwChannels;
    }
}