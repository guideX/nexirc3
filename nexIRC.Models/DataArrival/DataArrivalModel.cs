using System;
namespace nexIRC.Models.DataArrival {
    /// <summary>
    /// Data Arrival Model
    /// </summary>
    public class DataArrivalModel {
        /// <summary>
        /// Active
        /// </summary>
        public bool Active { get; set; }
        /// <summary>
        /// Data
        /// </summary>
        public string Data { get; set; }
        /// <summary>
        /// Time Stamp
        /// </summary>
        public DateTime TimeStamp { get; set; }
        /// <summary>
        /// Data Arrival Model
        /// </summary>
        public DataArrivalModel() {
            TimeStamp = DateTime.Now;
            Active = true;
        }
    }
}