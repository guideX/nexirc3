using System;
using nexIRC.Business.Interfaces;
using nexIRC.Models.Global;
using nexIRC.Models.DataArrival;
namespace nexIRC.Business.Business {
    /// <summary>
    /// Data Arrival Business
    /// </summary>
    public class DataArrivalBusiness : IDataArrivalBusiness, IDisposable {
        /// <summary>
        /// Global Object
        /// </summary>
        private GlobalObjectModel _globalObject;
        /// <summary>
        /// Data Arrival Business
        /// </summary>
        public DataArrivalBusiness(GlobalObjectModel globalObject) {
            _globalObject = globalObject;
        }
        /// <summary>
        /// Data Arrival
        /// </summary>
        /// <param name="data"></param>
        /// <param name="statusID"></param>
        public void DataArrival(string data, int statusID) {
            using (var reader = new System.IO.StringReader(data)) {
                _globalObject.Status[statusID].DataArrival.Add(new DataArrivalModel() {
                    Data = reader.ReadLine()
                });
            }
        }
        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose() {
        }
    }
}