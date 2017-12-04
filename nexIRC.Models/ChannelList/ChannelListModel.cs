using System.Windows.Forms;
using System.Collections.Generic;
//using nexIRC.UI.Windows;
namespace nexIRC.Models.ChannelList {
    /// <summary>
    /// Channel List Model
    /// </summary>
    public class ChannelListModel {
        /// <summary>
        /// Visible
        /// </summary>
        public bool Visible { get; set; }
        /// <summary>
        /// Tree Node Visible
        /// </summary>
        public bool TreeNodeVisible { get; set; }
        /// <summary>
        /// Items
        /// </summary>
        public List<ChannelListItemModel> Items { get; set; }
        /// <summary>
        /// Status ID
        /// </summary>
        public int StatusID { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Window
        /// </summary>
        //public ChannelListWindow Window { get; set; }
        /// <summary>
        /// Tree View
        /// </summary>
        public TreeNode TreeNode { get; set; }
    }
}