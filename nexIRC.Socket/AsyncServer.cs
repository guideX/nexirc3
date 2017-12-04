using System;
using System.Net;
using System.Net.Sockets;
namespace nexIRC.Sockets {
    /// <summary>
    /// Async Server
    /// </summary>
    public class AsyncServer {
        #region "events"
        /// <summary>
        /// Connection Accept
        /// </summary>
        public event ConnectionAcceptEventHandler ConnectionAccept;
        /// <summary>
        /// Connection Accept Event Handler
        /// </summary>
        /// <param name="socket"></param>
        public delegate void ConnectionAcceptEventHandler(AsyncSocket socket);
        #endregion
        #region "variables"
        /// <summary>
        /// Closed
        /// </summary>
        private bool _closed;
        /// <summary>
        /// Socket Port
        /// </summary>
        private int _socketPort;
        #endregion
        #region "methods"
        /// <summary>
        /// Entry Point
        /// </summary>
        /// <param name="port"></param>
        public AsyncServer(int port) {
            _socketPort = port;
        }
        /// <summary>
        /// Start
        /// </summary>
        public void Start() {
            var ip = IPAddress.Any;
            var port = _socketPort;
            var ep = new IPEndPoint(ip, port);
            if (_closed == true) {
                _closed = false;
                return;
            }
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(ep);
            socket.Listen(100);
            socket.BeginAccept(new AsyncCallback(onIncomingConnection), socket);
        }
        /// <summary>
        /// Close
        /// </summary>
        public void Close() {
            _closed = true;
        }
        /// <summary>
        /// On Incoming Connection
        /// </summary>
        /// <param name="result"></param>
        private void onIncomingConnection(IAsyncResult result) {
            var socket = (Socket)result.AsyncState;
            var connected = socket.EndAccept(result);
            if ((_closed == true)) {
                connected.Shutdown(SocketShutdown.Both);
                connected.Close();
            } else {
                if (ConnectionAccept != null) ConnectionAccept(new AsyncSocket(connected, System.Guid.NewGuid().ToString()));
            }
            socket.BeginAccept(new AsyncCallback(onIncomingConnection), socket);
        }
        #endregion
    }
}