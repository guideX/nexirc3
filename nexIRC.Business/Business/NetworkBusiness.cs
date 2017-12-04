using System;
using System.Collections.Generic;
using nexIRC.Models.Network;
using nexIRC.Business.Helpers;
namespace nexIRC.Business.Controllers {
    /// <summary>
    /// Network Controller
    /// </summary>
    public class NetworkBusiness : IDisposable {
        /// <summary>
        /// App Path
        /// </summary>
        private string _appPath { get; set; }
        /// <summary>
        /// Ini
        /// </summary>
        private string _ini { get; set; }
        /// <summary>
        /// Network Controller
        /// </summary>
        /// <param name="appPath"></param>
        public NetworkBusiness(string appPath) {
            _appPath = appPath;
            _ini = _appPath + @"\data\config\network.ini";
        }
        /// <summary>
        /// Read All
        /// </summary>
        /// <returns></returns>
        public List<NetworkModel> ReadAll() {
            var result = new List<NetworkModel> {
                new NetworkModel()
            };
            var c = IniFileHelper.ReadIniInt(_ini, "Settings", "Count");
            for (var i = 1; i <= c; i++) {
                var item = new NetworkModel() {
                    Description = IniFileHelper.ReadINI(_ini, i.ToString(), "Description", ""),
                    NetworkID = i
                };
                if (!string.IsNullOrEmpty(item.Description)) result.Add(item);
            }
            return result;
        }
        /// <summary>
        /// Add
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public NetworkModel Add(NetworkModel obj) {
            var c = IniFileHelper.ReadIniInt(_ini, "settings", "count") + 1;
            IniFileHelper.WriteINI(_ini, c.ToString(), "description", obj.Description);
            obj.NetworkID = c;
            return obj;
        }
        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="networkID"></param>
        public void Remove(int networkID) {
            IniFileHelper.WriteINI(_ini, networkID.ToString(), "description", "");
        }
        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose() {
        }
    }
}