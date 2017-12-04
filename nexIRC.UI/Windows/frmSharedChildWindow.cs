using System;
using nexIRC.Enum;
namespace nexIRC.UI.Windows {
    /// <summary>
    /// Shared Child Window
    /// </summary>
    public partial class frmSharedChildWindow : Telerik.WinControls.UI.RadForm {
        /// <summary>
        /// Destroyable
        /// </summary>
        public bool Destroyable { get; set; }
        /// <summary>
        /// Type
        /// </summary>
        private SharedChildWindowType _type;
        /// <summary>
        /// Guid
        /// </summary>
        private string _guid { get; set; }
        /// <summary>
        /// Get Guid
        /// </summary>
        /// <returns></returns>
        public string GetGuid() {
            return _guid;
        }
        /// <summary>
        /// Type
        /// </summary>
        /// <returns></returns>
        public SharedChildWindowType Type() {
            return _type;
        }
        /// <summary>
        /// Entry Point
        /// </summary>
        /// <param name="type"></param>
        public frmSharedChildWindow(SharedChildWindowType type, string guid) {
            InitializeComponent();
            _guid = guid;
            _type = type;
            switch (_type) {
                case SharedChildWindowType.Status:
                    txtIncoming.Visible = true;
                    txtOutgoing.Visible = true;
                    break;
            }
            ResizeWindow();
            txtOutgoing.Focus();
        }
        /// <summary>
        /// Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmSharedChildWindow_Load(object sender, EventArgs e) {
            this.Resize += FrmSharedChildWindow_Resize;
            txtIncoming.MouseDown += TxtIncoming_MouseDown;
            txtIncoming.MouseUp += TxtIncoming_MouseUp;
            txtIncoming.GotFocus += TxtIncoming_GotFocus;
        }
        /// <summary>
        /// Show Text
        /// </summary>
        /// <param name="data"></param>
        public void ShowText(string data) {
            txtIncoming.Text = txtIncoming.Text + Environment.NewLine + data;
        }
        /// <summary>
        /// Resize
        /// </summary>
        public void ResizeWindow() {
            switch (_type) {
                case SharedChildWindowType.Status:
                    txtIncoming.Width = this.ClientSize.Width;
                    txtIncoming.Height = this.ClientSize.Height - txtOutgoing.ClientSize.Height;
                    txtOutgoing.Top = this.ClientSize.Height - txtOutgoing.ClientSize.Height;
                    txtOutgoing.Width = this.ClientSize.Width;
                    break;
            }
        }
        /// <summary>
        /// Incoming Got Focus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtIncoming_GotFocus(object sender, EventArgs e) {
            txtOutgoing.Focus();
        }
        /// <summary>
        /// Incoming Mouse Up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtIncoming_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e) {
            
        }
        /// <summary>
        /// Incoming Mouse Down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtIncoming_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e) {
            
        }
        /// <summary>
        /// Resize
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSharedChildWindow_Resize(object sender, EventArgs e) {
            ResizeWindow();
        }
    }
}