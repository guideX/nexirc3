namespace nexIRC.UI.Windows {
    partial class frmCustomize {
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
            this.radPageView1 = new Telerik.WinControls.UI.RadPageView();
            this.rpvServer = new Telerik.WinControls.UI.RadPageViewPage();
            this.cmdAddServer = new Telerik.WinControls.UI.RadButton();
            this.cmdRemoveServer = new Telerik.WinControls.UI.RadButton();
            this.cmdAddNetwork = new Telerik.WinControls.UI.RadButton();
            this.cmdDel = new Telerik.WinControls.UI.RadButton();
            this.lvwServers = new Telerik.WinControls.UI.RadListView();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.cboNetworks = new Telerik.WinControls.UI.RadDropDownList();
            this.cmdConnect = new Telerik.WinControls.UI.RadButton();
            this.cmdOK = new Telerik.WinControls.UI.RadButton();
            this.cmdCancel = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).BeginInit();
            this.radPageView1.SuspendLayout();
            this.rpvServer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAddServer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdRemoveServer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAddNetwork)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdDel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvwServers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNetworks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdConnect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPageView1
            // 
            this.radPageView1.Controls.Add(this.rpvServer);
            this.radPageView1.Location = new System.Drawing.Point(0, 0);
            this.radPageView1.Name = "radPageView1";
            this.radPageView1.SelectedPage = this.rpvServer;
            this.radPageView1.Size = new System.Drawing.Size(644, 371);
            this.radPageView1.TabIndex = 0;
            this.radPageView1.Text = "radPageView1";
            this.radPageView1.ThemeName = "Office2010Black";
            // 
            // rpvServer
            // 
            this.rpvServer.Controls.Add(this.cmdAddServer);
            this.rpvServer.Controls.Add(this.cmdRemoveServer);
            this.rpvServer.Controls.Add(this.cmdAddNetwork);
            this.rpvServer.Controls.Add(this.cmdDel);
            this.rpvServer.Controls.Add(this.lvwServers);
            this.rpvServer.Controls.Add(this.radLabel1);
            this.rpvServer.Controls.Add(this.cboNetworks);
            this.rpvServer.Location = new System.Drawing.Point(12, 38);
            this.rpvServer.Name = "rpvServer";
            this.rpvServer.Size = new System.Drawing.Size(620, 321);
            this.rpvServer.Text = "Networks";
            // 
            // cmdAddServer
            // 
            this.cmdAddServer.Location = new System.Drawing.Point(451, 286);
            this.cmdAddServer.Name = "cmdAddServer";
            this.cmdAddServer.Size = new System.Drawing.Size(80, 32);
            this.cmdAddServer.TabIndex = 5;
            this.cmdAddServer.Text = "Add";
            this.cmdAddServer.ThemeName = "Office2010Black";
            this.cmdAddServer.Click += new System.EventHandler(this.cmdAddServer_Click);
            // 
            // cmdRemoveServer
            // 
            this.cmdRemoveServer.Location = new System.Drawing.Point(537, 286);
            this.cmdRemoveServer.Name = "cmdRemoveServer";
            this.cmdRemoveServer.Size = new System.Drawing.Size(80, 32);
            this.cmdRemoveServer.TabIndex = 6;
            this.cmdRemoveServer.Text = "Remove";
            this.cmdRemoveServer.ThemeName = "Office2010Black";
            this.cmdRemoveServer.Click += new System.EventHandler(this.cmdRemoveServer_Click);
            // 
            // cmdAddNetwork
            // 
            this.cmdAddNetwork.Location = new System.Drawing.Point(499, 3);
            this.cmdAddNetwork.Name = "cmdAddNetwork";
            this.cmdAddNetwork.Size = new System.Drawing.Size(56, 20);
            this.cmdAddNetwork.TabIndex = 3;
            this.cmdAddNetwork.Text = "Add";
            this.cmdAddNetwork.ThemeName = "Office2010Black";
            this.cmdAddNetwork.Click += new System.EventHandler(this.cmdAddNetwork_Click);
            // 
            // cmdDel
            // 
            this.cmdDel.Location = new System.Drawing.Point(561, 3);
            this.cmdDel.Name = "cmdDel";
            this.cmdDel.Size = new System.Drawing.Size(56, 20);
            this.cmdDel.TabIndex = 4;
            this.cmdDel.Text = "Remove";
            this.cmdDel.ThemeName = "Office2010Black";
            this.cmdDel.Click += new System.EventHandler(this.cmdDel_Click);
            // 
            // lvwServers
            // 
            this.lvwServers.GroupItemSize = new System.Drawing.Size(200, 20);
            this.lvwServers.ItemSize = new System.Drawing.Size(200, 20);
            this.lvwServers.ItemSpacing = -1;
            this.lvwServers.Location = new System.Drawing.Point(3, 29);
            this.lvwServers.Name = "lvwServers";
            this.lvwServers.Size = new System.Drawing.Size(614, 251);
            this.lvwServers.TabIndex = 2;
            this.lvwServers.Text = "radListView1";
            this.lvwServers.ThemeName = "Office2010Black";
            this.lvwServers.ViewType = Telerik.WinControls.UI.ListViewType.DetailsView;
            this.lvwServers.SelectedItemChanged += new Telerik.WinControls.UI.ListViewItemEventHandler(this.lvwServers_SelectedItemChanged);
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(3, 5);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(49, 18);
            this.radLabel1.TabIndex = 1;
            this.radLabel1.Text = "Network";
            this.radLabel1.ThemeName = "Office2010Black";
            // 
            // cboNetworks
            // 
            this.cboNetworks.DropDownAnimationEnabled = true;
            this.cboNetworks.Location = new System.Drawing.Point(126, 3);
            this.cboNetworks.Name = "cboNetworks";
            this.cboNetworks.ShowImageInEditorArea = true;
            this.cboNetworks.Size = new System.Drawing.Size(367, 20);
            this.cboNetworks.TabIndex = 0;
            this.cboNetworks.ThemeName = "Office2010Black";
            this.cboNetworks.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cboNetworks_SelectedIndexChanged);
            // 
            // cmdConnect
            // 
            this.cmdConnect.Location = new System.Drawing.Point(395, 377);
            this.cmdConnect.Name = "cmdConnect";
            this.cmdConnect.Size = new System.Drawing.Size(80, 32);
            this.cmdConnect.TabIndex = 7;
            this.cmdConnect.Text = "Connect";
            this.cmdConnect.ThemeName = "Office2010Black";
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(481, 377);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(80, 32);
            this.cmdOK.TabIndex = 8;
            this.cmdOK.Text = "OK";
            this.cmdOK.ThemeName = "Office2010Black";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(567, 377);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(77, 32);
            this.cmdCancel.TabIndex = 9;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.ThemeName = "Office2010Black";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // frmCustomize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 421);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdConnect);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.radPageView1);
            this.Name = "frmCustomize";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.Text = "Configure";
            this.ThemeName = "Office2010Black";
            this.Load += new System.EventHandler(this.frmCustomize_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).EndInit();
            this.radPageView1.ResumeLayout(false);
            this.rpvServer.ResumeLayout(false);
            this.rpvServer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAddServer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdRemoveServer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAddNetwork)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdDel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvwServers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNetworks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdConnect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Office2010BlackTheme office2010BlackTheme1;
        private Telerik.WinControls.UI.RadPageView radPageView1;
        private Telerik.WinControls.UI.RadPageViewPage rpvServer;
        private Telerik.WinControls.UI.RadButton cmdAddServer;
        private Telerik.WinControls.UI.RadButton cmdRemoveServer;
        private Telerik.WinControls.UI.RadButton cmdAddNetwork;
        private Telerik.WinControls.UI.RadButton cmdDel;
        private Telerik.WinControls.UI.RadListView lvwServers;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadDropDownList cboNetworks;
        private Telerik.WinControls.UI.RadButton cmdConnect;
        private Telerik.WinControls.UI.RadButton cmdOK;
        private Telerik.WinControls.UI.RadButton cmdCancel;
    }
}