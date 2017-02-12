﻿//nexIRC 3.0.31
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Net;
using System.Net.Sockets;
namespace nexIRC.Sockets {
    public class AsyncSocketController {
        private SortedList _socketCol = new SortedList();
        private AsyncServer withEventsField__serverSocket;
        public event onConnectionAcceptEventHandler onConnectionAccept;
        public delegate void onConnectionAcceptEventHandler(string socketID);
        public event onSocketDisconnectedEventHandler onSocketDisconnected;
        public delegate void onSocketDisconnectedEventHandler(string socketID);
        public event onDataArrivalEventHandler onDataArrival;
        public delegate void onDataArrivalEventHandler(string socketID, string socketData, byte[] bytes, int bytesRecieved);
        private AsyncServer _serverSocket {
            get { return withEventsField__serverSocket; }
            set {
                if (withEventsField__serverSocket != null) {
                    withEventsField__serverSocket.ConnectionAccept -= m_ServerSocket_ConnectionAccept;
                }
                withEventsField__serverSocket = value;
                if (withEventsField__serverSocket != null) {
                    withEventsField__serverSocket.ConnectionAccept += m_ServerSocket_ConnectionAccept;
                }
            }
        }
        public AsyncSocketController(int tmp_Port) {
            try {
                _serverSocket = new AsyncServer(tmp_Port);
            } catch (Exception ex) {
                throw ex;
            }
        }
        public void Start() {
            try {
                _serverSocket.Start();
            } catch (Exception ex) {
                throw ex;
            }
        }
        public void StopServer() {
            try {
                _serverSocket.Close();
            } catch (Exception ex) {
                throw ex;
            }
        }
        public void Send(string tmp_SocketID, string tmp_Data, bool tmp_Return = true) {
            try {
                if (tmp_Return == true) {
                    ((AsyncSocket)_socketCol[tmp_SocketID]).Send(tmp_Data + Environment.NewLine);
                } else {
                    ((AsyncSocket)_socketCol[tmp_SocketID]).Send(tmp_Data);
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        public void Close(string tmp_SocketID) {
            try {
                ((AsyncSocket)_socketCol[tmp_SocketID]).Close();
            } catch (Exception ex) {
                throw ex;
            }
        }
        public void Add(AsyncSocket tmp_Socket) {
            try {
                _socketCol.Add(tmp_Socket.SocketID, tmp_Socket);
                tmp_Socket.SocketDisconnected += SocketDisconnected;
                tmp_Socket.SocketDataArrival += SocketDataArrival;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public int Count {
            get {
                try {
                    return _socketCol.Count;
                } catch (Exception ex) {
                    throw ex;
                }
            }
        }
        private void m_ServerSocket_ConnectionAccept(AsyncSocket tmp_Socket) {
            try {
                Add(tmp_Socket);
                if (onConnectionAccept != null) {
                    onConnectionAccept(tmp_Socket.SocketID);
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void SocketDisconnected(string socketId) {
            try {
                _socketCol.Remove(socketId);
                if (onSocketDisconnected != null) {
                    onSocketDisconnected(socketId);
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void SocketDataArrival(string socketId, string socketData, byte[] bytes, int bytesRecieved) {
            try {
                if (onDataArrival != null) {
                    onDataArrival(socketId, socketData, bytes, bytesRecieved);
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}