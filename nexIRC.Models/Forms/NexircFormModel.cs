using System.Windows.Forms;
namespace nexIRC.Models.Forms {
    /// <summary>
    /// nexIRC Form Model
    /// </summary>
    public class NexircFormModel : Form {
        /// <summary>
        /// Me Index
        /// </summary>
        public int MeIndex { get; set; }
        /// <summary>
        /// lvwChannels
        /// </summary>
        public ListView lvwChannels { get; set; }
    }
}