using System;
namespace nexIRC.Business.Interfaces {
    /// <summary>
    /// Data Arrival Business
    /// </summary>
    public interface IDataArrivalBusiness : IDisposable {
        /// <summary>
        /// Data Arrival
        /// </summary>
        /// <param name="data"></param>
        /// <param name="statusID"></param>
        void DataArrival(string data, int statusID);
    }
}