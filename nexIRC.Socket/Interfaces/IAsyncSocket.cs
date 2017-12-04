namespace nexIRC.Sockets.Interfaces {
    /// <summary>
    /// Async Socket
    /// </summary>
    public interface IAsyncSocket {
        #region "properties"
        /// <summary>
        /// Socket ID
        /// </summary>
        string SocketID { get; }
        /// <summary>
        /// Connected
        /// </summary>
        bool Connected { get; }
        /// <summary>
        /// Port
        /// </summary>
        int Port { get; }
        #endregion
        #region "methods"
        /// <summary>
        /// Async Socket - Default Constructor
        /// </summary>
        //AsyncSocket(bool useDataArrivalBuffer);
        /// <summary>
        /// Entry Point - Connection Accept
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="socketID"></param>
        //AsyncSocket(Socket socket, string socketID, bool useDataArrivalBuffer = false);
        /// <summary>
        /// Send Bytes
        /// </summary>
        /// <param name="buffer"></param>
        void Send(byte[] buffer);
        /// <summary>
        /// Send String
        /// </summary>
        /// <param name="data"></param>
        void Send(string data);
        /// <summary>
        /// Close
        /// </summary>
        void Close();
        /// <summary>
        /// Connect
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        void Connect(string ip, int port);
        #endregion
    }
}