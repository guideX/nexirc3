using System;
using System.Collections.Generic;
using nexIRC.Models.DataArrival;
using nexIRC.Sockets;
using Telerik.WinControls.UI;
namespace nexIRC.Models.Status {
    /// <summary>
    /// Status Model
    /// </summary>
    public class StatusModel {
        #region "public properties"
        /// <summary>
        /// Data Arrival
        /// </summary>
        public List<DataArrivalModel> DataArrival { get; set; }
        /// <summary>
        /// Guid
        /// </summary>
        public string Guid { get; set; }
        /// <summary>
        /// Status ID
        /// </summary>
        public int StatusID { get; set; }
        /// <summary>
        /// Server ID
        /// </summary>
        public int ServerID { get; set; }
        /// <summary>
        /// Form
        /// </summary>
        public RadForm Form { get; set; }
        /// <summary>
        /// Rad Status Strip Item
        /// </summary>
        public RadButtonElement RadStatusStripItem { get; set; }
        /// <summary>
        /// Socket
        /// </summary>
        public AsyncSocketController Socket { get; set; }
        #endregion
        #region "methods"
        /// <summary>
        /// Status Model
        /// </summary>
        public StatusModel() {
            Guid = System.Guid.NewGuid().ToString();
        }
        /// <summary>
        /// Set Invoke Form
        /// </summary>
        /// <param name="frm"></param>
        public void SetInvokeForm(RadForm frm) {
            Socket = new AsyncSocketController(frm, true, true);
            Socket.SocketDataArrival += Socket_SocketDataArrival;
            DataArrival = new List<DataArrivalModel>();
        }
        /// <summary>
        /// Socket Data Arrival
        /// </summary>
        /// <param name="socketID"></param>
        /// <param name="data"></param>
        /// <param name="bytes"></param>
        /// <param name="bytesRead"></param>
        private void Socket_SocketDataArrival(string socketID, string data, byte[] bytes, int bytesRead) {
            DataArrival.Add(new DataArrivalModel() { Active = true, Data = data.Trim(), TimeStamp = DateTime.Now });
        }
        #endregion
    }
}