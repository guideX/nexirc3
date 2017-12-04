using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using nexIRC.Sockets.Interfaces;
namespace nexIRC.Sockets {
    /// <summary>
    /// Async Socket
    /// </summary>
    public class AsyncSocket : IAsyncSocket {
        #region "events"
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
        /// Socket ID
        /// </summary>
        private string _socketID;
        /// <summary>
        /// Temp Socket
        /// </summary>
        private Socket _tempSocket;
        /// <summary>
        /// Port
        /// </summary>
        private int _port;
        /// <summary>
        /// Use Data Arrival Buffer
        /// </summary>
        private bool _useDataArrivalBuffer;
        #endregion
        #region "properties"
        /// <summary>
        /// Socket ID
        /// </summary>
        public string SocketID {
            get {
                return _socketID;
            }
        }
        /// <summary>
        /// Connected
        /// </summary>
        public bool Connected {
            get {
                return _tempSocket.Connected;
            }
        }
        /// <summary>
        /// Port
        /// </summary>
        public int Port {
            get {
                return _port;
            }
        }
        #endregion
        #region "methods"
        /// <summary>
        /// Async Socket - Default Constructor
        /// </summary>
        public AsyncSocket(bool useDataArrivalBuffer = false) {
            _tempSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _useDataArrivalBuffer = useDataArrivalBuffer;
        }
        /// <summary>
        /// Entry Point - Connection Accept
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="socketID"></param>
        public AsyncSocket(Socket socket, string socketID, bool useDataArrivalBuffer = false) {
            _useDataArrivalBuffer = useDataArrivalBuffer;
            _socketID = socketID;
            _tempSocket = socket;
            var state = new StateObject();
            state.Socket = socket;
            socket.BeginReceive(state.Buffer, 0, state.BufferSize, 0, new AsyncCallback(onDataArrival), state);
        }
        /// <summary>
        /// Send Bytes
        /// </summary>
        /// <param name="buffer"></param>
        public void Send(byte[] buffer) {
            var state = new StateObject();
            state.Socket = _tempSocket;
            _tempSocket.BeginSend(buffer, 0, buffer.Length, 0, new AsyncCallback(onSendComplete), state);
        }
        /// <summary>
        /// Send String
        /// </summary>
        /// <param name="data"></param>
        public void Send(string data) {
            if (data != null) return;
            var state = new StateObject();
            state.Socket = _tempSocket;
            var buffer = Encoding.UTF8.GetBytes(data);
            _tempSocket.BeginSend(buffer, 0, buffer.Length, 0, new AsyncCallback(onSendComplete), state);
        }
        /// <summary>
        /// Close
        /// </summary>
        public void Close() {
            _tempSocket.Shutdown(SocketShutdown.Both);
            _tempSocket.Close();
        }
        /// <summary>
        /// Connect
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        public void Connect(string ip, int port) {
            var hostEndPoint = new IPEndPoint(Dns.GetHostEntry(ip).AddressList[0], port);
            var obj_Socket = _tempSocket;
            obj_Socket.BeginConnect(hostEndPoint, new AsyncCallback(onConnectionComplete), obj_Socket);
            _port = port;
        }
        /// <summary>
        /// On Data Arrival
        /// </summary>
        /// <param name="ar"></param>
        private void onDataArrival(IAsyncResult ar) {
            try {
                var state = (StateObject)ar.AsyncState;
                var socket = state.Socket;
                var b = socket.EndReceive(ar);
                if (b > 0) {
                    var data = Encoding.UTF8.GetString(state.Buffer, 0, b);
                    if (SocketDataArrival != null) {
                        if (_useDataArrivalBuffer) {
                            SocketDataArrival(_socketID, data, state.Buffer, b);
                        } else {
                            SocketDataArrival(_socketID, data, null, 0);
                        }
                    }
                }
                socket.BeginReceive(state.Buffer, 0, state.BufferSize, SocketFlags.None, new AsyncCallback(onDataArrival), state);
            } catch (SocketException) {
                if (SocketDisconnected != null) SocketDisconnected(_socketID);
            } catch (Exception ex) {
                if (SocketDisconnected != null) SocketDisconnected(_socketID);
                if ((!ex.Message.Contains("Cannot access a disposed object"))) throw;
            }
        }
        /// <summary>
        /// On Send Complete
        /// </summary>
        /// <param name="ar"></param>
        private void onSendComplete(IAsyncResult ar) {
            var state = (StateObject)ar.AsyncState;
            var socket = state.Socket;
        }
        /// <summary>
        /// On Connection Complete
        /// </summary>
        /// <param name="ar"></param>
        private void onConnectionComplete(IAsyncResult ar) {
            try {
                _tempSocket = (Socket)ar.AsyncState;
                _tempSocket.EndConnect(ar);
                if (SocketConnected != null) SocketConnected(null);
                var state = new StateObject();
                state.Socket = _tempSocket;
                _tempSocket.BeginReceive(state.Buffer, 0, state.BufferSize, 0, new AsyncCallback(onDataArrival), state);
            } catch (Exception ex) {
                if ((ex.Message.Contains("A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond"))) {
                    if (CouldNotConnect != null) CouldNotConnect(_socketID);
                } else {
                    throw;
                }
            }
        }
        #endregion
    }
}