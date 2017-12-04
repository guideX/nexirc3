namespace nexIRC.Sockets {
    /// <summary>
    /// Async Server Controller
    /// </summary>
    public class AsyncServerController {
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
        /// Async Server
        /// </summary>
        private AsyncServer _asyncServer;
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
        public AsyncServerController(int port) {
            _asyncServer = new AsyncServer(port);
            _socketPort = port;
        }
        /// <summary>
        /// Start
        /// </summary>
        public void Start() {
            _asyncServer.Start();
        }
        /// <summary>
        /// Close
        /// </summary>
        public void Close() {
            _asyncServer.Close();
        }
        #endregion
    }
}
