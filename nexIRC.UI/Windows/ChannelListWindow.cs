using System;
namespace nexIRC.UI.Windows {
    public partial class ChannelListWindow : Telerik.WinControls.UI.RadForm {
        public ChannelListWindow() {
            InitializeComponent();
        }
        /// <summary>
        /// Channel List Window Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChannelListWindow_Load(object sender, EventArgs e) {
        }

        private void lvwChannels_SelectedItemChanged(object sender, Telerik.WinControls.UI.ListViewItemEventArgs e) {

        }
    }
}