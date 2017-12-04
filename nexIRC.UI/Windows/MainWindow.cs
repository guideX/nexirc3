using System;
using System.Windows.Forms;
using nexIRC.Models.Global;
namespace nexIRC.UI.Windows {
    /// <summary>
    /// Main Window
    /// </summary>
    public partial class MainWindow : Telerik.WinControls.UI.RadForm {
        #region "variables"
        /// <summary>
        /// Global Object Model
        /// </summary>
        private GlobalObjectModel _globalObject;
        #endregion
        #region "methods"
        /// <summary>
        /// Entry Point
        /// </summary>
        /// <param name="globalObject"></param>
        public MainWindow(GlobalObjectModel globalObject) {
            InitializeComponent();
            _globalObject = globalObject;
        }
        /// <summary>
        /// Main Window Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Load(object sender, EventArgs e) {
            FormClosing += MainWindow_FormClosing;
            FormClosed += MainWindow_FormClosed;
            mnuNewStatus.Click += mnuNewStatus_Click;
            mnuConnect.Click += mnuConnect_Click;
            mnuDisconnect.Click += mnuDisconnect_Click;
            _globalObject.NewStatus(_globalObject.ServerIndex);
        }
        /// <summary>
        /// Disconnect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuDisconnect_Click(object sender, EventArgs e) {
            _globalObject.Disconnect(((frmSharedChildWindow)this.ActiveMdiChild).GetGuid());
        }
        /// <summary>
        /// Connect Menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuConnect_Click(object sender, EventArgs e) {
            _globalObject.Connect(((frmSharedChildWindow)this.ActiveMdiChild).GetGuid());
        }
        /// <summary>
        /// New Status Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuNewStatus_Click(object sender, EventArgs e) {
            _globalObject.NewStatus(_globalObject.ServerIndex);
        }
        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdConfigure_Click(object sender, EventArgs e) {
            var c = new frmCustomize(_globalObject);
            c.Show();
        }
        /// <summary>
        /// Form Closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e) {

        }
        /// <summary>
        /// Form Closing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e) {
            foreach (var status in _globalObject.Status) {
                var frm = (frmSharedChildWindow)status.Form;
                if (frm != null) frm.Destroyable = true;
            }
        }
        /// <summary>
        /// Selected Node Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radTreeView1_SelectedNodeChanged(object sender, Telerik.WinControls.UI.RadTreeViewEventArgs e) {
            switch (e.Node.Text) {
                case "Status":
                    _globalObject.FocusNow(e.Node.Parent.Tag.ToString());
                    break;
            }
        }
        #endregion
    }
}