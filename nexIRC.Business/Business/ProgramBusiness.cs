using System;
using System.Linq;
using System.Windows.Forms;
using nexIRC.UI.Windows;
using nexIRC.Models.Global;
using nexIRC.Models.Status;
using nexIRC.Business.Business;
using nexIRC.Business.Interfaces;
using Telerik.WinControls.UI;
namespace nexIRC.Business.Controllers {
    /// <summary>
    /// Program Controller
    /// </summary>
    public class ProgramBusiness : IDisposable {
        #region "public properties"
        /// <summary>
        /// Global Object
        /// </summary>
        public GlobalObjectModel Global { get; set; }
        /// <summary>
        /// Main Window
        /// </summary>
        public MainWindow MainWindow { get; set; }
        /// <summary>
        /// Status Controller
        /// </summary>
        public StatusBusiness Status { get; set; }
        /// <summary>
        /// Network Controller
        /// </summary>
        public NetworkBusiness Networks { get; set; }
        /// <summary>
        /// Server Controller
        /// </summary>
        public ServerBusiness Servers { get; set; }
        #endregion
        #region "private variables"
        /// <summary>
        /// Timer
        /// </summary>
        private Timer _timer;
        #endregion
        #region "methods"
        /// <summary>
        /// Program Controller
        /// </summary>
        public ProgramBusiness() {
            Global = new GlobalObjectModel();
            Global.NewStatusEvent += _globalObject_NewStatus;
            Global.FocusEvent += GlobalObject_Focus;
            Global.DisconnectEvent += GlobalObject_Disconnect;
            Global.ConnectEvent += GlobalObject_Connect;
            Status = new StatusBusiness(Global);
            Networks = new NetworkBusiness(Application.StartupPath);
            Servers = new ServerBusiness(Application.StartupPath);
            Global.Networks = Networks.ReadAll();
            Global.Servers = Servers.ReadAll();
            Global.ServerIndex = Servers.Index();
            Global.Status.Add(new StatusModel());
            MainWindow = new MainWindow(Global);
            _timer = new Timer();
            _timer.Interval = 200;
            _timer.Tick += _timer_Tick;
            _timer.Start();
        }
        /// <summary>
        /// Timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _timer_Tick(object sender, System.EventArgs e) {
            foreach (var s in Global.Status) {
                if (s.DataArrival != null && s.DataArrival.Count != 0) {
                    var da = s.DataArrival.FirstOrDefault();
                    ProcessDataArrivalLine(da.Data, s);
                    s.DataArrival.Remove(da);
                }
            }
        }
        /// <summary>
        /// Process Data Arrival Line
        /// </summary>
        /// <param name="data"></param>
        /// <param name="status"></param>
        private void ProcessDataArrivalLine(string data, StatusModel status) {
            ((frmSharedChildWindow)status.Form).ShowText(data);
        }
        /// <summary>
        /// Disconnect
        /// </summary>
        /// <param name="frm"></param>
        private void GlobalObject_Disconnect(string guid) {
            var objs = Global.Status.Where(s => s.Guid == guid);
            if (objs.Any()) {
                var obj = objs.FirstOrDefault();
                obj.Socket.Close();
            }
        }
        /// <summary>
        /// Connect
        /// </summary>
        /// <param name="frm"></param>
        private void GlobalObject_Connect(string guid) {
            var objs = Global.Status.Where(s => s.Guid == guid);
            if (objs.Any()) {
                var obj = objs.FirstOrDefault();
                var servers = Global.Servers.Where(s => s.ServerID == obj.ServerID);
                if (servers.Any()) {
                    var server = servers.FirstOrDefault();
                    obj.Socket.Connect(server.IP, server.Port);
                }
            }
        }
        /// <summary>
        /// Focus
        /// </summary>
        /// <param name="StatusID"></param>
        private void GlobalObject_Focus(string guid) {
            var objs = Global.Status.Where(s => s.Guid == guid);
            if (objs.Any()) {
                var frm = (frmSharedChildWindow)objs.FirstOrDefault().Form;
                frm.Visible = true;
                frm.Focus();
                frm.txtIncoming.Focus();
            }
        }
        /// <summary>
        /// New Status
        /// </summary>
        /// <param name="obj"></param>
        private void _globalObject_NewStatus(StatusModel obj) {
            obj.Form = new frmSharedChildWindow(Enum.SharedChildWindowType.Status, obj.Guid) { MdiParent = MainWindow };
            obj.Form.Show();
            obj.SetInvokeForm(obj.Form);
            var node = new RadTreeNode();
            var statusNode = new RadTreeNode();
            node.Text = Global.Servers[obj.ServerID].Description;
            node.ImageIndex = 1;
            statusNode.Text = "Status";
            statusNode.ImageIndex = 2;
            node.Nodes.Add(statusNode);
            obj.RadStatusStripItem = new RadButtonElement() {
                Text = "Status: " + Global.Servers[obj.ServerID].Description,
                Tag = Global.Status.Count
            };
            obj.Form.Text = Global.Servers[obj.ServerID].Description;
            Global.Status.Add(obj);
            MainWindow.radStatusStrip1.Items.Add(obj.RadStatusStripItem);
            MainWindow.radTreeView1.Nodes.Add(node);
            node.Expanded = true;
            node.Tag = obj.Guid;
            obj.RadStatusStripItem.Click += RadButton_Click;
        }
        /// <summary>
        /// Status On Data Arrival
        /// </summary>
        /// <param name="data"></param>
        private void Status_onDataArrival(string data, int statusID) {
            using (IDataArrivalBusiness b = new DataArrivalBusiness(Global)) {
                b.DataArrival(data, statusID);
            }
        }
        /// <summary>
        /// Rad Button Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadButton_Click(object sender, System.EventArgs e) {
            Global.FocusNow(((RadButtonElement)sender).Tag.ToString());
        }
        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose() {
        }
        #endregion
    }
}