using System.Net.Sockets;
namespace nexIRC.Sockets {
    /// <summary>
    /// State Object
    /// </summary>
    public class StateObject {
        /// <summary>
        /// Work Socket
        /// </summary>
        public Socket Socket { get; set; }
        /// <summary>
        /// Buffer Size
        /// </summary>
        public int BufferSize;
        /// <summary>
        /// Buffer
        /// </summary>
        public byte[] Buffer;
        /// <summary>
        /// Constructor
        /// </summary>
        public StateObject() {
            BufferSize = 32767;
            Buffer = new byte[BufferSize];
        }
    }
}