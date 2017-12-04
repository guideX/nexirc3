using nexIRC.Models.Global;
using System.Collections.Generic;
using System.Linq;
using Telerik.WinControls.UI;
namespace nexIRC.UI.Windows {
    /// <summary>
    /// Customize
    /// </summary>
    public partial class frmCustomize : Telerik.WinControls.UI.RadForm {
        /// <summary>
        /// Global
        /// </summary>
        private GlobalObjectModel _global;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="global"></param>
        public frmCustomize(GlobalObjectModel global) {
            InitializeComponent();
            _global = global;
        }
        /// <summary>
        /// Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCustomize_Load(object sender, System.EventArgs e) {
            lvwServers.DoubleClick += LvwServers_DoubleClick;
            lvwServers.Columns.Add("Description");
            lvwServers.Columns.Add("IP");
            lvwServers.Columns.Add("Port");
            radLabel1.BackColor = rpvServer.BackColor;
            foreach (var n in _global.Networks) {
                cboNetworks.Items.Add(n.Description);
            }
            var servers = _global.Servers.Where(s => s.ServerID == _global.ServerIndex);
            if (servers.Any()) {
                var server = servers.FirstOrDefault();
                var networks = _global.Networks.Where(n => n.NetworkID == server.NetworkID);
                if (networks.Any()) {
                    var network = networks.FirstOrDefault();
                    cboNetworks.Text = network.Description;
                    var objs = new List<ListViewDataItem>();
                    foreach (var ser in _global.Servers.Where(ss => ss.NetworkID == network.NetworkID)) {
                        var item = new ListViewDataItem();
                        item.SubItems.Add(server.Description);
                        item.SubItems.Add(ser.IP);
                        item.SubItems.Add(ser.Port.ToString());
                        objs.Add(item);
                    }
                    FillServers(objs);
                }
            }
        }
        /// <summary>
        /// ListView Servers Double Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LvwServers_DoubleClick(object sender, System.EventArgs e) {
            var serverItem = lvwServers.SelectedItem;
            var networks = _global.Networks.Where(s => s.Description == serverItem[0].ToString()).ToList();
            if (networks.Any()) {
                var servers = _global.Servers.Where(s => s.IP == serverItem[1].ToString()).ToList();
                if (servers.Any()) {
                    var server = servers.FirstOrDefault();
                    //_global
                      //  (_global.ServerIndex);
                    this.Close();
                }
            }
        }
        /// <summary>
        /// Fill Servers
        /// </summary>
        /// <param name="objs"></param>
        private void FillServers(List<ListViewDataItem> objs) {
            lvwServers.Items.Clear();
            foreach(var item in objs) lvwServers.Items.Add(item);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboNetworks_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e) {
            var networks = _global.Networks.Where(n => n.Description == cboNetworks.Text);
            if (networks.Any()) {
                var network = networks.FirstOrDefault();
                var objs = new List<ListViewDataItem>();
                foreach (var server in _global.Servers.Where(s => s.NetworkID == network.NetworkID)) {
                    var item = new ListViewDataItem();
                    item.SubItems.Add(server.Description);
                    item.SubItems.Add(server.IP);
                    item.SubItems.Add(server.Port.ToString());
                    objs.Add(item);
                }
                FillServers(objs);
            }
        }

        private void cmdCancel_Click(object sender, System.EventArgs e) {
            this.Close();
            this.Dispose();
        }

        private void lvwServers_SelectedItemChanged(object sender, ListViewItemEventArgs e) {

        }

        private void cmdAddNetwork_Click(object sender, System.EventArgs e) {

        }

        private void cmdDel_Click(object sender, System.EventArgs e) {

        }

        private void cmdAddServer_Click(object sender, System.EventArgs e) {

        }

        private void cmdRemoveServer_Click(object sender, System.EventArgs e) {

        }
    }
}