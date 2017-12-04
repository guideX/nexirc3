namespace nexIRC.UI.Windows {
    partial class MainWindow {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.office2010BlackTheme1 = new Telerik.WinControls.Themes.Office2010BlackTheme();
            this.imlToolbar = new System.Windows.Forms.ImageList(this.components);
            this.cmdConfigure = new Telerik.WinControls.UI.RadCommandBar();
            this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.cmdConnection = new Telerik.WinControls.UI.CommandBarDropDownButton();
            this.mnuNewStatus = new Telerik.WinControls.UI.RadMenuItem();
            this.mnuSep1 = new Telerik.WinControls.UI.RadMenuSeparatorItem();
            this.mnuConnect = new Telerik.WinControls.UI.RadMenuItem();
            this.mnuDisconnect = new Telerik.WinControls.UI.RadMenuItem();
            this.commandBarButton1 = new Telerik.WinControls.UI.CommandBarButton();
            this.radStatusStrip1 = new Telerik.WinControls.UI.RadStatusStrip();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.radTreeView1 = new Telerik.WinControls.UI.RadTreeView();
            ((System.ComponentModel.ISupportInitialize)(this.cmdConfigure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radStatusStrip1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTreeView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // imlToolbar
            // 
            this.imlToolbar.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlToolbar.ImageStream")));
            this.imlToolbar.TransparentColor = System.Drawing.Color.Transparent;
            this.imlToolbar.Images.SetKeyName(0, "network.png");
            // 
            // cmdConfigure
            // 
            this.cmdConfigure.AutoSize = true;
            this.cmdConfigure.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdConfigure.Location = new System.Drawing.Point(0, 0);
            this.cmdConfigure.Name = "cmdConfigure";
            this.cmdConfigure.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement1});
            this.cmdConfigure.Size = new System.Drawing.Size(808, 32);
            this.cmdConfigure.TabIndex = 1;
            this.cmdConfigure.Text = "Configure";
            this.cmdConfigure.ThemeName = "Office2010Black";
            // 
            // commandBarRowElement1
            // 
            this.commandBarRowElement1.DisplayName = null;
            this.commandBarRowElement1.MinSize = new System.Drawing.Size(25, 25);
            this.commandBarRowElement1.Strips.AddRange(new Telerik.WinControls.UI.CommandBarStripElement[] {
            this.commandBarStripElement1});
            // 
            // commandBarStripElement1
            // 
            this.commandBarStripElement1.DisplayName = "commandBarStripElement1";
            this.commandBarStripElement1.FloatingForm = null;
            this.commandBarStripElement1.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.cmdConnection,
            this.commandBarButton1});
            this.commandBarStripElement1.Name = "commandBarStripElement1";
            this.commandBarStripElement1.Text = "";
            // 
            // cmdConnection
            // 
            this.cmdConnection.AccessibleDescription = "cmdConnection";
            this.cmdConnection.AccessibleName = "cmdConnection";
            this.cmdConnection.DisplayName = "Connection";
            this.cmdConnection.DrawText = true;
            this.cmdConnection.Image = ((System.Drawing.Image)(resources.GetObject("cmdConnection.Image")));
            this.cmdConnection.ImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdConnection.ImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cmdConnection.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.mnuNewStatus,
            this.mnuSep1,
            this.mnuConnect,
            this.mnuDisconnect});
            this.cmdConnection.Name = "cmdConnection";
            this.cmdConnection.Text = "Connection";
            this.cmdConnection.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdConnection.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdConnection.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.cmdConnection.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.cmdConnection.VisibleInOverflowMenu = true;
            // 
            // mnuNewStatus
            // 
            this.mnuNewStatus.AccessibleDescription = "New Status";
            this.mnuNewStatus.AccessibleName = "New Status";
            this.mnuNewStatus.Name = "mnuNewStatus";
            this.mnuNewStatus.Text = "New Status";
            this.mnuNewStatus.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // mnuSep1
            // 
            this.mnuSep1.AccessibleDescription = "radMenuSeparatorItem1";
            this.mnuSep1.AccessibleName = "radMenuSeparatorItem1";
            this.mnuSep1.Name = "mnuSep1";
            this.mnuSep1.Text = "radMenuSeparatorItem1";
            this.mnuSep1.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // mnuConnect
            // 
            this.mnuConnect.AccessibleDescription = "Connect";
            this.mnuConnect.AccessibleName = "Connect";
            this.mnuConnect.Name = "mnuConnect";
            this.mnuConnect.Text = "Connect";
            this.mnuConnect.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // mnuDisconnect
            // 
            this.mnuDisconnect.AccessibleDescription = "Disconnect";
            this.mnuDisconnect.AccessibleName = "Disconnect";
            this.mnuDisconnect.Name = "mnuDisconnect";
            this.mnuDisconnect.Text = "Disconnect";
            this.mnuDisconnect.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // commandBarButton1
            // 
            this.commandBarButton1.AccessibleDescription = "Configure";
            this.commandBarButton1.AccessibleName = "Configure";
            this.commandBarButton1.DisplayName = "commandBarButton1";
            this.commandBarButton1.DrawText = true;
            this.commandBarButton1.Image = ((System.Drawing.Image)(resources.GetObject("commandBarButton1.Image")));
            this.commandBarButton1.ImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandBarButton1.ImageLayout = System.Windows.Forms.ImageLayout.None;
            this.commandBarButton1.Name = "commandBarButton1";
            this.commandBarButton1.Text = "Configure";
            this.commandBarButton1.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.commandBarButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandBarButton1.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.commandBarButton1.VisibleInOverflowMenu = true;
            this.commandBarButton1.Click += new System.EventHandler(this.cmdConfigure_Click);
            // 
            // radStatusStrip1
            // 
            this.radStatusStrip1.AutoSize = true;
            this.radStatusStrip1.LayoutStyle = Telerik.WinControls.UI.RadStatusBarLayoutStyle.Stack;
            this.radStatusStrip1.Location = new System.Drawing.Point(0, 495);
            this.radStatusStrip1.Name = "radStatusStrip1";
            this.radStatusStrip1.Size = new System.Drawing.Size(808, 21);
            this.radStatusStrip1.TabIndex = 2;
            this.radStatusStrip1.Text = "radStatusStrip1";
            this.radStatusStrip1.ThemeName = "Office2010Black";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "network.png");
            this.imageList1.Images.SetKeyName(1, "web.png");
            // 
            // radTreeView1
            // 
            this.radTreeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.radTreeView1.ImageList = this.imageList1;
            this.radTreeView1.Location = new System.Drawing.Point(0, 32);
            this.radTreeView1.Name = "radTreeView1";
            this.radTreeView1.Size = new System.Drawing.Size(150, 463);
            this.radTreeView1.SpacingBetweenNodes = -1;
            this.radTreeView1.TabIndex = 4;
            this.radTreeView1.Text = "radTreeView1";
            this.radTreeView1.SelectedNodeChanged += new Telerik.WinControls.UI.RadTreeView.RadTreeViewEventHandler(this.radTreeView1_SelectedNodeChanged);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(808, 516);
            this.Controls.Add(this.radTreeView1);
            this.Controls.Add(this.radStatusStrip1);
            this.Controls.Add(this.cmdConfigure);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MainWindow";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.Text = "nexIRC";
            this.ThemeName = "Office2010Black";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmdConfigure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radStatusStrip1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTreeView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.Office2010BlackTheme office2010BlackTheme1;
        private System.Windows.Forms.ImageList imlToolbar;
        private Telerik.WinControls.UI.RadCommandBar cmdConfigure;
        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
        private Telerik.WinControls.UI.CommandBarDropDownButton cmdConnection;
        private Telerik.WinControls.UI.RadMenuItem mnuConnect;
        private Telerik.WinControls.UI.RadMenuItem mnuDisconnect;
        private Telerik.WinControls.UI.CommandBarButton commandBarButton1;
        private Telerik.WinControls.UI.RadMenuItem mnuNewStatus;
        private Telerik.WinControls.UI.RadMenuSeparatorItem mnuSep1;
        public Telerik.WinControls.UI.RadStatusStrip radStatusStrip1;
        private System.Windows.Forms.ImageList imageList1;
        public Telerik.WinControls.UI.RadTreeView radTreeView1;
    }
}