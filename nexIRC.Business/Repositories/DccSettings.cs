using System;
using System.Net;
using nexIRC.Business.Helpers;
using nexIRC.Business.Enums;
namespace nexIRC.Business.Repositories {
    /// <summary>
    /// Dcc Ignore Type
    /// </summary>
    public enum DCCIgnoreType {
        Nicknames = 1,
        Hostnames = 2,
        FileTypes = 3
    }
    /// <summary>
    /// Dcc Ignore Item
    /// </summary>
    public struct DCCIgnoreItem {
        public DCCIgnoreType Type;
        public string Data;
    }
    /// <summary>
    /// Dcc Ignore List
    /// </summary>
    public struct DCCIgnoreList {
        public int Count;
        public DCCIgnoreItem[] Item;
    }
    /// <summary>
    /// Dcc
    /// </summary>
    public struct DCC {
        public DccFileExistsAction FileExistsAction;
        public DccPrompt ChatPrompt;
        public DccPrompt SendPrompt;
        public DCCIgnoreType Type;
        public bool UseIpAddress;
        public string CustomIpAddress;
        public DCCIgnoreList Ignorelist;
        public string SendPort;
        public bool RandomizePort;
        public long BufferSize;
        public bool AutoIgnore;
        public bool AutoCloseDialogs;
        public string DownloadDirectory;
        public bool PopupDownloadManager;
    }
    /// <summary>
    /// Dcc Settings
    /// </summary>
    public static class DccSettings {
        /// <summary>
        /// Return Outside Ip Address
        /// </summary>
        /// <returns></returns>
        public static string IpAddress() {
            try {
                WebClient client = new WebClient();
                string baseurl = "http://checkip.dyndns.org:8245/";
                System.IO.Stream data = default(System.IO.Stream);
                System.IO.StreamReader reader = default(System.IO.StreamReader);
                string s = null;
                client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR1.0.3705;)");
                data = client.OpenRead(baseurl);
                reader = new System.IO.StreamReader(data);
                s = reader.ReadToEnd();
                data.Close();
                reader.Close();
                s = s.Replace("<html><head><title>Current IP Check</title></head><body>", "").Replace("</body></html>", "").ToString();
                s = s.Replace("Current IP Address: ", "");
                return s;
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Load Dcc Settings
        /// </summary>
        /// <param name="ini"></param>
        /// <param name="startupPath"></param>
        /// <returns></returns>
        public static DCC Read(string startupPath) {
            var ini = startupPath + @"\data\config\dcc.ini";
            var dcc = new DCC();
            var i = 0;
            var n = 0;
            dcc.FileExistsAction = (DccFileExistsAction)Convert.ToInt32(IniFileHelper.ReadINI(ini, "Settings", "FileExistsAction", "1"));
            n = Convert.ToInt32(IniFileHelper.ReadINI(ini, "Settings", "ChatPrompt", "1"));
            if (n == 1) {
                dcc.ChatPrompt = DccPrompt.Prompt;
            } else if (n == 2) {
                dcc.ChatPrompt = DccPrompt.AcceptAll;
            } else if (n == 3) {
                dcc.ChatPrompt = DccPrompt.Ignore;
            }
            n = Convert.ToInt32(IniFileHelper.ReadINI(ini, "Settings", "SendPrompt", "1"));
            if (n == 1) {
                dcc.SendPrompt = DccPrompt.Prompt;
            } else if (n == 2) {
                dcc.SendPrompt = DccPrompt.AcceptAll;
            } else if (n == 3) {
                dcc.SendPrompt = DccPrompt.Ignore;
            }
            dcc.PopupDownloadManager = Convert.ToBoolean(IniFileHelper.ReadINI(ini, "Settings", "PopupDownloadManager", "False"));
            dcc.DownloadDirectory = IniFileHelper.ReadINI(ini, "Settings", "DownloadDirectory", "");
            if (string.IsNullOrEmpty(dcc.DownloadDirectory) == true)
                dcc.DownloadDirectory = startupPath + "\\";
            dcc.DownloadDirectory = dcc.DownloadDirectory.Replace("\\\\", "");
            dcc.BufferSize = Convert.ToInt64(IniFileHelper.ReadINI(ini, "Settings", "BufferSize", "1024"));
            dcc.UseIpAddress = Convert.ToBoolean(IniFileHelper.ReadINI(ini, "Settings", "UseIpAddress", "False"));
            dcc.CustomIpAddress = IniFileHelper.ReadINI(ini, "Settings", "CustomIpAddress", "");
            if (dcc.CustomIpAddress.Length == 0) {
                dcc.CustomIpAddress = DccSettings.IpAddress();
            }
            dcc.Ignorelist.Count = Convert.ToInt32(IniFileHelper.ReadINI(ini, "Settings", "IgnoreCount", "0"));
            dcc.SendPort = IniFileHelper.ReadINI(ini, "Settings", "SendPort", "1024");
            dcc.RandomizePort = Convert.ToBoolean(IniFileHelper.ReadINI(ini, "Settings", "RandomizePort", "True"));
            dcc.Ignorelist.Count = Convert.ToInt32(IniFileHelper.ReadINI(ini, "Settings", "IgnoreCount", dcc.Ignorelist.Count.ToString()));
            dcc.AutoIgnore = Convert.ToBoolean(IniFileHelper.ReadINI(ini, "Settings", "AutoIgnore", "True"));
            dcc.AutoCloseDialogs = Convert.ToBoolean(IniFileHelper.ReadINI(ini, "Settings", "AutoCloseDialogs", "False"));
            for (i = 1; i <= dcc.Ignorelist.Count; i++) {
                //var _with2 = dcc.dIgnorelist.dItem[i];
                dcc.Ignorelist.Item[i].Data = IniFileHelper.ReadINI(ini, i.ToString(), "Data", "");
                dcc.Type = (DCCIgnoreType)Convert.ToInt32(IniFileHelper.ReadINI(ini, i.ToString(), "Type", "0"));
                switch (dcc.Type) {
                    case DCCIgnoreType.Nicknames:
                        dcc.Type = DCCIgnoreType.Nicknames;
                        break;
                    case DCCIgnoreType.Hostnames:
                        dcc.Type = DCCIgnoreType.Hostnames;
                        break;
                    case DCCIgnoreType.FileTypes:
                        dcc.Type = DCCIgnoreType.FileTypes;
                        break;
                }
            }
            return dcc;
        }
        /// <summary>
        /// Save Dcc Settings
        /// </summary>
        /// <param name="ini"></param>
        /// <param name="dcc"></param>
        public static void SaveDCCSettings(string ini, DCC dcc) {
            try {
                int i = 0;
                IniFileHelper.WriteINI(ini, "Settings", "PopupDownloadManager", dcc.PopupDownloadManager.ToString());
                IniFileHelper.WriteINI(ini, "Settings", "DownloadDirectory", dcc.DownloadDirectory);
                IniFileHelper.WriteINI(ini, "Settings", "FileExistsAction", dcc.FileExistsAction.ToString());
                IniFileHelper.WriteINI(ini, "Settings", "IgnoreCount", dcc.Ignorelist.Count.ToString());
                for (i = 1; i <= dcc.Ignorelist.Count; i++) {
                    IniFileHelper.WriteINI(ini, i.ToString().Trim(), "Data", dcc.Ignorelist.Item[i].Data.ToString());
                    IniFileHelper.WriteINI(ini, i.ToString().Trim(), "Type", dcc.Ignorelist.Item[i].Type.ToString());
                }
                if (dcc.ChatPrompt == DccPrompt.Prompt) {
                    IniFileHelper.WriteINI(ini, "Settings", "ChatPrompt", "1");
                } else if (dcc.ChatPrompt == DccPrompt.AcceptAll) {
                    IniFileHelper.WriteINI(ini, "Settings", "ChatPrompt", "2");
                } else if (dcc.ChatPrompt == DccPrompt.Ignore) {
                    IniFileHelper.WriteINI(ini, "Settings", "ChatPrompt", "3");
                }
                if (dcc.SendPrompt == DccPrompt.Prompt) {
                    IniFileHelper.WriteINI(ini, "Settings", "SendPrompt", "1");
                } else if (dcc.SendPrompt == DccPrompt.AcceptAll) {
                    IniFileHelper.WriteINI(ini, "Settings", "SendPrompt", "2");
                } else if (dcc.SendPrompt == DccPrompt.Ignore) {
                    IniFileHelper.WriteINI(ini, "Settings", "SendPrompt", "3");
                }
                IniFileHelper.WriteINI(ini, "Settings", "UseIpAddress", dcc.UseIpAddress.ToString());
                IniFileHelper.WriteINI(ini, "Settings", "CustomIpAddress", dcc.CustomIpAddress);
                IniFileHelper.WriteINI(ini, "Settings", "IgnoreCount", dcc.Ignorelist.Count.ToString());
                IniFileHelper.WriteINI(ini, "Settings", "SendPort", dcc.SendPort.ToString());
                IniFileHelper.WriteINI(ini, "Settings", "RandomizePort", dcc.RandomizePort.ToString());
                IniFileHelper.WriteINI(ini, "Settings", "BufferSize", dcc.BufferSize.ToString());
                IniFileHelper.WriteINI(ini, "Settings", "AutoIgnore", dcc.AutoIgnore.ToString());
                IniFileHelper.WriteINI(ini, "Settings", "AutoCloseDialogs", dcc.AutoCloseDialogs.ToString());
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}