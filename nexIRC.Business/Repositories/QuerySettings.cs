﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nexIRC.Business.Helpers;
namespace nexIRC.IrcSettings {
    /// <summary>
    /// Query Permission
    /// </summary>
    public enum QueryPermission {
        List = 1,
        EveryOne = 2,
        NoOne = 3
    }
    /// <summary>
    /// Query Settings Data
    /// </summary>
    public class QuerySettingsData {
        public QueryPermission AutoAllow { get; set; }
        public QueryPermission AutoDeny { get; set; }
        public string StandByMessage { get; set; }
        public string DeclineMessage { get; set; }
        public bool EnableSpamFilter { get; set; }
        public bool PromptUser { get; set; }
        public List<string> AutoAllowList { get; set; }
        public List<string> AutoDenyList { get; set; }
        public List<string> SpamPhrases { get; set; }
        public bool AutoShowWindow { get; set; }
        /// <summary>
        /// Entry Point
        /// </summary>
        public QuerySettingsData() {
            try {
                AutoAllowList = new List<string>();
                AutoDenyList = new List<string>();
                SpamPhrases = new List<string>();
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
    public class QuerySettings {
        private bool _useCached = false;
        private QuerySettingsData _cached;
        private string _iniFile;
        //private string _startupPath;
        /// <summary>
        /// Entry Point
        /// </summary>
        /// <param name="_startupPath"></param>
        public QuerySettings(string _startupPath) {
            try {
                _iniFile = _startupPath + @"data\config\query.ini";
            } catch (Exception ex) {
                throw ex;
            }
    
        }
        /// <summary>
        /// Get
        /// </summary>
        /// <returns></returns>
        public QuerySettingsData Get() {
            try {
                if (_useCached) {
                    return _cached;
                } else {
                    var data = new QuerySettingsData();
                    data.SpamPhrases = new List<string>();
                    data.AutoAllowList = new List<string>();
                    data.AutoDenyList = new List<string>();
                    int n = 0;
                    if (int.TryParse(IniFileHelper.ReadINI(_iniFile, "Settings", "AutoAllow", "1"), out n)) {
                        data.AutoAllow = (QueryPermission)n;
                    }
                    if (int.TryParse(IniFileHelper.ReadINI(_iniFile, "Settings", "AutoDeny", "1"), out n)) {
                        data.AutoDeny = (QueryPermission)n;
                    }
                    data.StandByMessage = IniFileHelper.ReadINI(_iniFile, "Settings", "StandByMessage", "");
                    data.DeclineMessage = IniFileHelper.ReadINI(_iniFile, "Settings", "DeclineMessage", "");
                    data.EnableSpamFilter = Convert.ToBoolean(IniFileHelper.ReadINI(_iniFile, "Settings", "EnableSpamFilter ", "True"));
                    data.PromptUser = Convert.ToBoolean(IniFileHelper.ReadINI(_iniFile, "Settings", "PromptUser", "False"));
                    var autoAllowCount = Convert.ToInt32(IniFileHelper.ReadINI(_iniFile, "Settings", "AutoAllowCount", "0"));
                    var autoDenyCount = Convert.ToInt32(IniFileHelper.ReadINI(_iniFile, "Settings", "AutoDenyCount", "0"));
                    var spamPhraseCount = Convert.ToInt32(IniFileHelper.ReadINI(_iniFile, "Settings", "SpamPhraseCount", "0"));
                    data.AutoShowWindow = Convert.ToBoolean(IniFileHelper.ReadINI(_iniFile, "Settings", "AutoShowWindow", "True"));
                    data.AutoAllowList = new List<string>();
                    for (var i = 1; i <= autoAllowCount; i++) {
                        data.AutoAllowList.Add(IniFileHelper.ReadINI(_iniFile, "AutoAllowList", i.ToString(), ""));
                    }
                    for (var i = 1; i <= autoDenyCount; i++) {
                        data.AutoDenyList.Add(IniFileHelper.ReadINI(_iniFile, "AutoDenyList", i.ToString(), ""));
                    }
                    for (var i = 1; i <= spamPhraseCount; i++) {
                        data.SpamPhrases.Add(IniFileHelper.ReadINI(_iniFile, "SpamPhrases", i.ToString(), ""));
                    }
                    _useCached = true;
                    _cached = data;
                    return data;
                }
                
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Save
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Save(QuerySettingsData data) {
            try {
                IniFileHelper.WriteINI(_iniFile, "Settings", "AutoAllow",  ((int)data.AutoAllow).ToString());
                IniFileHelper.WriteINI(_iniFile, "Settings", "AutoDeny", ((int)data.AutoDeny).ToString());
                IniFileHelper.WriteINI(_iniFile, "Settings", "StandByMessage", data.StandByMessage);
                IniFileHelper.WriteINI(_iniFile, "Settings", "DeclineMessage", data.DeclineMessage);
                IniFileHelper.WriteINI(_iniFile, "Settings", "EnableSpamFilter", data.EnableSpamFilter.ToString());
                IniFileHelper.WriteINI(_iniFile, "Settings", "PromptUser", data.PromptUser.ToString());
                IniFileHelper.WriteINI(_iniFile, "Settings", "AutoAllowCount", data.AutoAllowList.Count.ToString());
                IniFileHelper.WriteINI(_iniFile, "Settings", "AutoDenyCount", data.AutoDenyList.Count.ToString());
                IniFileHelper.WriteINI(_iniFile, "Settings", "SpamPhraseCount", data.SpamPhrases.Count.ToString());
                IniFileHelper.WriteINI(_iniFile, "Settings", "AutoShowWindow", data.AutoShowWindow.ToString());
                for (var i = 0; i <= data.AutoAllowList.Count - 1; i++) {
                    IniFileHelper.WriteINI(_iniFile, "AutoAllowList", (i + 1).ToString(), data.AutoAllowList[i]);
                }
                for (var i = 0; i <= data.AutoDenyList.Count - 1; i++) {
                    IniFileHelper.WriteINI(_iniFile, "AutoDenyList", (i + 1).ToString(), data.AutoDenyList[i]);
                }
                for (var i = 0; i <= data.SpamPhrases.Count - 1; i++) {
                    IniFileHelper.WriteINI(_iniFile, "SpamPhrases", (i + 1).ToString(), data.SpamPhrases[i]);
                }
                _useCached = false;
                return true;
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}