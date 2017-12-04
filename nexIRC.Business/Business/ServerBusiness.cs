using System;
using System.Collections.Generic;
using nexIRC.Business.Helpers;
using nexIRC.Models.Server;
namespace nexIRC.Business.Controllers {
    /// <summary>
    /// Server Controller
    /// </summary>
    public class ServerBusiness : IDisposable {
        #region "private variables"
        /// <summary>
        /// App Path
        /// </summary>
        private string _appPath { get; set; }
        /// <summary>
        /// Ini
        /// </summary>
        private string _ini { get; set; }
        #endregion
        #region "methods"
        /// <summary>
        /// Server Controller
        /// </summary>
        /// <param name="appPath"></param>
        public ServerBusiness(string appPath) {
            _appPath = appPath;
            _ini = _appPath + @"\data\config\server.ini";
        }
        /// <summary>
        /// Read All
        /// </summary>
        /// <returns></returns>
        public List<ServerModel> ReadAll() {
            var result = new List<ServerModel> { new ServerModel() };
            var c = IniFileHelper.ReadIniInt(_ini, "Settings", "Count");
            for (var i = 1; i <= c; i++) {
                var item = new ServerModel() {
                    Description = IniFileHelper.ReadINI(_ini, i.ToString(), "Description", ""),
                    NetworkID = IniFileHelper.ReadINI(_ini, i.ToString(), "NetworkID", "").ToInt(),
                    IP = IniFileHelper.ReadINI(_ini, i.ToString(), "IP", ""),
                    Port = IniFileHelper.ReadIniInt(_ini, i.ToString(), "Port"),
                    ServerID = i
                };
                if (!string.IsNullOrEmpty(item.Description)) result.Add(item);
            }
            return result;
        }
        /// <summary>
        /// Index
        /// </summary>
        /// <returns></returns>
        public int Index() {
            return IniFileHelper.ReadIniInt(_ini, "Settings", "Index");
        }
        /// <summary>
        /// Add
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public ServerModel Add(ServerModel obj) {
            var c = IniFileHelper.ReadIniInt(_ini, "Settings", "Count") + 1;
            IniFileHelper.WriteINI(_ini, c.ToString(), "Description", obj.Description);
            IniFileHelper.WriteINI(_ini, c.ToString(), "IP", obj.IP);
            IniFileHelper.WriteINI(_ini, c.ToString(), "NetworkID", obj.NetworkID.ToString());
            obj.ServerID = c - 1;
            return obj;
        }
        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="serverID"></param>
        public void Remove(int serverID) {
            IniFileHelper.WriteINI(_ini, serverID.ToString(), "Description", "");
        }
        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose() {
        }
        #endregion
    }
}