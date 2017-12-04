using nexIRC.Models.Network;
using nexIRC.Models.Server;
using nexIRC.Models.Status;
using System.Collections.Generic;
namespace nexIRC.Models.Global {
    /// <summary>
    /// Global Object Model
    /// </summary>
    public class GlobalObjectModel {
        #region "variables
        /// <summary>
        /// Networks
        /// </summary>
        public List<NetworkModel> Networks { get; set; }
        /// <summary>
        /// Servers
        /// </summary>
        public List<ServerModel> Servers { get; set; }
        /// <summary>
        /// Server Index
        /// </summary>
        public int ServerIndex { get; set; }
        /// <summary>
        /// Status
        /// </summary>
        public List<StatusModel> Status { get; set; }
        #endregion
        #region "events"
        /// <summary>
        /// Connect Event
        /// </summary>
        public event Connect_EventHandler ConnectEvent;
        /// <summary>
        /// Disconnect Event
        /// </summary>
        public event Disconnect_EventHandler DisconnectEvent;
        /// <summary>
        /// New Status
        /// </summary>
        public event NewStatus_EventHandler NewStatusEvent;
        /// <summary>
        /// Focus
        /// </summary>
        public event Focus_EventHandler FocusEvent;
        #endregion
        #region "delegates"
        /// <summary>
        /// Connect
        /// </summary>
        /// <param name="frm"></param>
        public delegate void Connect_EventHandler(string guid);
        /// <summary>
        /// Disconnect
        /// </summary>
        /// <param name="frm"></param>
        public delegate void Disconnect_EventHandler(string guid);
        /// <summary>
        /// Connection Accept Event Handler
        /// </summary>
        /// <param name="socket"></param>
        public delegate void NewStatus_EventHandler(StatusModel obj);
        /// <summary>
        /// Focus Event Handler
        /// </summary>
        /// <param name="StatusID"></param>
        //public delegate void Focus_EventHandler(int StatusID);
        public delegate void Focus_EventHandler(string guid);
        #endregion
        #region "methods"
        /// <summary>
        /// Global Object Model
        /// </summary>
        public GlobalObjectModel() {
            Status = new List<StatusModel>();
            Servers = new List<ServerModel>();
            Networks = new List<NetworkModel>();
        }
        /// <summary>
        /// Connect
        /// </summary>
        /// <param name="activeForm"></param>
        public void Connect(string guid) {
            if (ConnectEvent != null) ConnectEvent(guid);
        }
        /// <summary>
        /// Disconnect
        /// </summary>
        /// <param name="activeForm"></param>
        public void Disconnect(string guid) {
            if (DisconnectEvent != null) DisconnectEvent(guid);
        }
        /// <summary>
        /// New Status
        /// </summary>
        public void NewStatus(int serverID) {
            if (NewStatusEvent != null) NewStatusEvent(new StatusModel() {
                ServerID = serverID
            });
        }
        /// <summary>
        /// Focus
        /// </summary>
        /// <param name="StatusID"></param>
        public void FocusNow(string guid) {
            if (FocusEvent != null) FocusEvent(guid);
        }
        #endregion
    }
}