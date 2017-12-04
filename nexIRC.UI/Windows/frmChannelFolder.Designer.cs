namespace nexIRC.UI.Windows {
    partial class frmChannelFolder {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChannelFolder));
            this.chkCloseOnJoin = new Telerik.WinControls.UI.RadCheckBox();
            this.chkPopupOnConnect = new Telerik.WinControls.UI.RadCheckBox();
            this.lnkJumpToChannelList = new System.Windows.Forms.LinkLabel();
            this.lstChannels = new Telerik.WinControls.UI.RadListControl();
            this.cboNetwork = new Telerik.WinControls.UI.RadDropDownList();
            this.lblNetwork = new Telerik.WinControls.UI.RadLabel();
            this.cmdJoin = new Telerik.WinControls.UI.RadButton();
            this.cmdAdd = new Telerik.WinControls.UI.RadButton();
            this.cmdRemove = new Telerik.WinControls.UI.RadButton();
            this.cmdClose = new Telerik.WinControls.UI.RadButton();
            this.RadLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txtChannel = new Telerik.WinControls.UI.RadTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chkCloseOnJoin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPopupOnConnect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstChannels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNetwork)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNetwork)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdJoin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdRemove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RadLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChannel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // chkCloseOnJoin
            // 
            this.chkCloseOnJoin.ForeColor = System.Drawing.Color.White;
            this.chkCloseOnJoin.Location = new System.Drawing.Point(12, 275);
            this.chkCloseOnJoin.Name = "chkCloseOnJoin";
            // 
            // 
            // 
            this.chkCloseOnJoin.RootElement.ForeColor = System.Drawing.Color.White;
            this.chkCloseOnJoin.Size = new System.Drawing.Size(86, 18);
            this.chkCloseOnJoin.TabIndex = 18;
            this.chkCloseOnJoin.Text = "Close on Join";
            // 
            // chkPopupOnConnect
            // 
            this.chkPopupOnConnect.ForeColor = System.Drawing.Color.White;
            this.chkPopupOnConnect.Location = new System.Drawing.Point(12, 251);
            this.chkPopupOnConnect.Name = "chkPopupOnConnect";
            // 
            // 
            // 
            this.chkPopupOnConnect.RootElement.ForeColor = System.Drawing.Color.White;
            this.chkPopupOnConnect.Size = new System.Drawing.Size(114, 18);
            this.chkPopupOnConnect.TabIndex = 17;
            this.chkPopupOnConnect.Text = "Popup on Connect";
            // 
            // lnkJumpToChannelList
            // 
            this.lnkJumpToChannelList.AutoSize = true;
            this.lnkJumpToChannelList.Location = new System.Drawing.Point(182, 280);
            this.lnkJumpToChannelList.Name = "lnkJumpToChannelList";
            this.lnkJumpToChannelList.Size = new System.Drawing.Size(114, 13);
            this.lnkJumpToChannelList.TabIndex = 16;
            this.lnkJumpToChannelList.TabStop = true;
            this.lnkJumpToChannelList.Text = "Jump to Channel List";
            // 
            // lstChannels
            // 
            this.lstChannels.CaseSensitiveSort = true;
            this.lstChannels.ItemHeight = 18;
            this.lstChannels.Location = new System.Drawing.Point(12, 108);
            this.lstChannels.Name = "lstChannels";
            this.lstChannels.Size = new System.Drawing.Size(197, 137);
            this.lstChannels.TabIndex = 15;
            this.lstChannels.Text = "Channel Folder";
            this.lstChannels.ThemeName = "Office2010Black";
            // 
            // cboNetwork
            // 
            this.cboNetwork.DropDownAnimationEnabled = true;
            this.cboNetwork.Location = new System.Drawing.Point(12, 78);
            this.cboNetwork.Name = "cboNetwork";
            this.cboNetwork.ShowImageInEditorArea = true;
            this.cboNetwork.Size = new System.Drawing.Size(197, 20);
            this.cboNetwork.TabIndex = 7;
            this.cboNetwork.ThemeName = "Office2010Black";
            // 
            // lblNetwork
            // 
            this.lblNetwork.ForeColor = System.Drawing.Color.White;
            this.lblNetwork.Location = new System.Drawing.Point(12, 58);
            this.lblNetwork.Name = "lblNetwork";
            // 
            // 
            // 
            this.lblNetwork.RootElement.ForeColor = System.Drawing.Color.White;
            this.lblNetwork.Size = new System.Drawing.Size(51, 18);
            this.lblNetwork.TabIndex = 14;
            this.lblNetwork.Text = "Network:";
            // 
            // cmdJoin
            // 
            this.cmdJoin.Location = new System.Drawing.Point(220, 78);
            this.cmdJoin.Name = "cmdJoin";
            this.cmdJoin.Size = new System.Drawing.Size(76, 24);
            this.cmdJoin.TabIndex = 12;
            this.cmdJoin.Text = "Join";
            this.cmdJoin.ThemeName = "Office2010Black";
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(220, 108);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(76, 24);
            this.cmdAdd.TabIndex = 8;
            this.cmdAdd.Text = "Add";
            this.cmdAdd.ThemeName = "Office2010Black";
            // 
            // cmdRemove
            // 
            this.cmdRemove.Location = new System.Drawing.Point(220, 138);
            this.cmdRemove.Name = "cmdRemove";
            this.cmdRemove.Size = new System.Drawing.Size(76, 24);
            this.cmdRemove.TabIndex = 9;
            this.cmdRemove.Text = "Remove";
            this.cmdRemove.ThemeName = "Office2010Black";
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(220, 221);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(76, 24);
            this.cmdClose.TabIndex = 10;
            this.cmdClose.Text = "Close";
            this.cmdClose.ThemeName = "Office2010Black";
            // 
            // RadLabel1
            // 
            this.RadLabel1.ForeColor = System.Drawing.Color.White;
            this.RadLabel1.Location = new System.Drawing.Point(12, 12);
            this.RadLabel1.Name = "RadLabel1";
            // 
            // 
            // 
            this.RadLabel1.RootElement.ForeColor = System.Drawing.Color.White;
            this.RadLabel1.Size = new System.Drawing.Size(156, 18);
            this.RadLabel1.TabIndex = 13;
            this.RadLabel1.Text = "Enter name of channel to join:";
            // 
            // txtChannel
            // 
            this.txtChannel.Location = new System.Drawing.Point(12, 32);
            this.txtChannel.Name = "txtChannel";
            this.txtChannel.Size = new System.Drawing.Size(197, 20);
            this.txtChannel.TabIndex = 11;
            this.txtChannel.TabStop = false;
            this.txtChannel.ThemeName = "Office2010Black";
            // 
            // frmChannelFolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 318);
            this.Controls.Add(this.chkCloseOnJoin);
            this.Controls.Add(this.chkPopupOnConnect);
            this.Controls.Add(this.lnkJumpToChannelList);
            this.Controls.Add(this.lstChannels);
            this.Controls.Add(this.cboNetwork);
            this.Controls.Add(this.lblNetwork);
            this.Controls.Add(this.cmdJoin);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.cmdRemove);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.RadLabel1);
            this.Controls.Add(this.txtChannel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmChannelFolder";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Channel Folder";
            this.ThemeName = "Office2010Black";
            this.Load += new System.EventHandler(this.frmChannelFolder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chkCloseOnJoin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPopupOnConnect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstChannels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNetwork)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNetwork)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdJoin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdRemove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RadLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChannel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal Telerik.WinControls.UI.RadCheckBox chkCloseOnJoin;
        internal Telerik.WinControls.UI.RadCheckBox chkPopupOnConnect;
        internal System.Windows.Forms.LinkLabel lnkJumpToChannelList;
        internal Telerik.WinControls.UI.RadListControl lstChannels;
        internal Telerik.WinControls.UI.RadDropDownList cboNetwork;
        internal Telerik.WinControls.UI.RadLabel lblNetwork;
        internal Telerik.WinControls.UI.RadButton cmdJoin;
        internal Telerik.WinControls.UI.RadButton cmdAdd;
        internal Telerik.WinControls.UI.RadButton cmdRemove;
        internal Telerik.WinControls.UI.RadButton cmdClose;
        internal Telerik.WinControls.UI.RadLabel RadLabel1;
        internal Telerik.WinControls.UI.RadTextBox txtChannel;
    }
}