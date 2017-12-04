namespace nexIRC.Models.Files {
    /// <summary>
    /// File Model
    /// </summary>
    public class FileModel {
        /// <summary>
        /// File Number
        /// </summary>
        public int FileNumber { get; set; }
        /// <summary>
        /// Buffer Size
        /// </summary>
        public long BufferSize { get; set; }
        /// <summary>
        /// File Length
        /// </summary>
        public long FileLength { get; set; }
        /// <summary>
        /// Bytes Sent
        /// </summary>
        public long BytesSent { get; set; }
    }
}