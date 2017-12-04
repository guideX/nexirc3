using System;
using nexIRC.Sockets.Interfaces;
using Telerik.WinControls.UI;
namespace nexIRC.Sockets {
    /// <summary>
    /// Status Socket
    /// </summary>
    public class AsyncSocketController : IAsyncSocket {
        #region "events"
        /// <summary>
        /// Form
        /// </summary>
        public RadForm InvokeForm;
        /// <summary>
        /// Socket Disconnected
        /// </summary>
        public event SocketDisconnectedEventHandler SocketDisconnected;
        /// <summary>
        /// Socket Data Arrival Event Handler
        /// </summary>
        public event SocketDataArrivalEventHandler SocketDataArrival;
        /// <summary>
        /// Socket Connected
        /// </summary>
        public event SocketConnectedEventHandler SocketConnected;
        /// <summary>
        /// Could Not Connect
        /// </summary>
        public event CouldNotConnectEventHandler CouldNotConnect;
        #endregion
        #region "delegates"
        /// <summary>
        /// Socket Disconnected Event Handler
        /// </summary>
        /// <param name="socketID"></param>
        public delegate void SocketDisconnectedEventHandler(string socketID);
        /// <summary>
        /// Socket Data Arrival Event Handler
        /// </summary>
        /// <param name="socketID"></param>
        /// <param name="data"></param>
        /// <param name="bytes"></param>
        /// <param name="bytesRead"></param>
        public delegate void SocketDataArrivalEventHandler(string socketID, string data, byte[] bytes, int bytesRead);
        /// <summary>
        /// Socket Connected Event Handler
        /// </summary>
        /// <param name="SocketID"></param>
        public delegate void SocketConnectedEventHandler(string socketID);
        /// <summary>
        /// Could Not Connect Event Handler
        /// </summary>
        /// <param name="socketID"></param>
        public delegate void CouldNotConnectEventHandler(string socketID);
        #endregion
        #region "variables"
        /// <summary>
        /// Use Invoke Form
        /// </summary>
        private bool _useInvokeForm;
        /// <summary>
        /// Socket
        /// </summary>
        private AsyncSocket _socket;
        #endregion
        #region "methods"
        /// <summary>
        /// Socket Controller
        /// </summary>
        public AsyncSocketController(RadForm form, bool useDataArrivalBuffer = false, bool useInvokeForm = true) {
            _useInvokeForm = useInvokeForm;
            if (_useInvokeForm) InvokeForm = form;
            _socket = new AsyncSocket(useDataArrivalBuffer);
            _socket.SocketConnected += _socket_SocketConnected;
            _socket.SocketDataArrival += _socket_SocketDataArrival;
            _socket.SocketDisconnected += _socket_SocketDisconnected;
            _socket.CouldNotConnect += _socket_CouldNotConnect;
        }
        /// <summary>
        /// On Socket Could Not Connect
        /// </summary>
        /// <param name="socketID"></param>
        private void onSocketCouldNotConnect(string socketID) {
            if (CouldNotConnect != null) CouldNotConnect(socketID);
        }
        /// <summary>
        /// On Socket Disconnected
        /// </summary>
        /// <param name="socketID"></param>
        private void OnSocketDisconnected(string socketID) {
            if (SocketDisconnected != null) SocketDisconnected(socketID);
        }
        /// <summary>
        /// On Socket Connected
        /// </summary>
        /// <param name="socketID"></param>
        private void OnSocketConnected(string socketID) {
            if (SocketConnected != null) SocketConnected(socketID);
        }
        /// <summary>
        /// On Socket Data Arrival
        /// </summary>
        /// <param name="socketID"></param>
        /// <param name="data"></param>
        /// <param name="bytes"></param>
        /// <param name="bytesRead"></param>
        private void OnSocketDataArrival(string socketID, string data, byte[] bytes, int bytesRead) {
            if (SocketDataArrival != null) SocketDataArrival(socketID, data, bytes, bytesRead);
        }
        /// <summary>
        /// Could Not Connect
        /// </summary>
        /// <param name="socketID"></param>
        private void _socket_CouldNotConnect(string socketID) {
            if (_useInvokeForm) {
                var obj = new CouldNotConnectEventHandler(onSocketCouldNotConnect);
                InvokeForm.Invoke(obj, socketID);
            } else {
                CouldNotConnect(SocketID);
            }
        }
        /// <summary>
        /// Socket Disconnected
        /// </summary>
        /// <param name="socketID"></param>
        private void _socket_SocketDisconnected(string socketID) {
            if (_useInvokeForm) {
                var obj = new SocketDisconnectedEventHandler(OnSocketDisconnected);
                InvokeForm.Invoke(obj, socketID);
            } else {
                SocketDisconnected(socketID);
            }
        }
        /// <summary>
        /// Socket Data Arrival
        /// </summary>
        /// <param name="socketID"></param>
        /// <param name="data"></param>
        /// <param name="bytes"></param>
        /// <param name="bytesRead"></param>
        private void _socket_SocketDataArrival(string socketID, string data, byte[] bytes, int bytesRead) {
            if (_useInvokeForm) {
                var obj = new SocketDataArrivalEventHandler(OnSocketDataArrival);
                InvokeForm.Invoke(obj, socketID, data, bytes, bytesRead);
            } else {
                SocketDataArrival(socketID, data, bytes, bytesRead);
            }
        }
        /// <summary>
        /// Socket Connected
        /// </summary>
        /// <param name="socketID"></param>
        private void _socket_SocketConnected(string socketID) {
            if (_useInvokeForm) {
                var obj = new SocketConnectedEventHandler(OnSocketConnected);
                InvokeForm.Invoke(obj, socketID);
            } else {
                SocketConnected(socketID);
            }
        }
        /// <summary>
        /// Port
        /// </summary>
        public int Port {
            get {
                return _socket.Port;
            }
        }
        /// <summary>
        /// Connected
        /// </summary>
        public bool Connected {
            get {
                return _socket.Connected;
            }
        }
        /// <summary>
        /// Socket ID
        /// </summary>
        public string SocketID {
            get {
                return _socket.SocketID;
            }
        }
        /// <summary>
        /// Send
        /// </summary>
        /// <param name="data"></param>
        public void Send(string data) {
            _socket.Send(data);
        }
        /// <summary>
        /// Close
        /// </summary>
        public void Close() {
            _socket.Close();
        }
        /// <summary>
        /// Connect
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        public void Connect(string ip, int port) {
            _socket.Connect(ip, port);
        }
        /// <summary>
        /// Send
        /// </summary>
        /// <param name="buffer"></param>
        public void Send(byte[] buffer) {
            throw new NotImplementedException();
        }
        #endregion
    }
}