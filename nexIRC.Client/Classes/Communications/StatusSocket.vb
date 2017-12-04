Option Explicit On
Option Strict Off
Imports nexIRC.clsIrcNumerics
Imports nexIRC.Modules
Imports nexIRC.Sockets

Namespace Classes.Communications
    Public Enum SocketType
        Status = 1
        Ident = 2
    End Enum

    Public Class StatusSocketObject
        Public Event DataArrival(data As String)
        Private WithEvents _socket As AsyncSocketController
        Private _statusID As Integer
        Private _invoke As Form
        Private _socketType As SocketType = SocketType.Status

        Public WriteOnly Property SetSocketType() As SocketType
            Set(value As SocketType)
                _socketType = value
            End Set
        End Property

        Public WriteOnly Property PassSocket(invokeForm As Form) As AsyncSocketController
            Set(value As AsyncSocketController)
                _socket = value
                _invoke = invokeForm
            End Set
        End Property

        Public Function Connected() As Boolean
            If (_socket IsNot Nothing) Then
                Return _socket.Connected
            Else
                Return False
            End If
        End Function

        Public Sub NewSocket(ByVal id As Integer, ByVal form As Form)
            _socket = New AsyncSocketController(form)
            _statusID = id
            _invoke = New Form
            _invoke = form
        End Sub

        Public Sub SendSocket(ByVal data As String)
            If (Connected() = True) Then _socket.Send(data & Environment.NewLine)
        End Sub

        Public Sub CloseSocket()
            If Connected() = True Then _socket.Close()
        End Sub

        Public Sub ConnectSocket(ByVal ip As String, ByVal port As Long)
            If Connected() = False Then _socket.Connect(ip, port)
        End Sub

        Private Sub socket_CouldNotConnect(SocketID As String) Handles _socket.CouldNotConnect
            lStrings.ProcessReplaceString(_statusID, eStringTypes.sCOULD_NOT_CONNECT, lStatus.ServerDescription(_statusID))
        End Sub

        Private Sub lSocket_socketConnected(ByVal socketID As String) Handles _socket.SocketConnected
            lStatus.ConnectEvent(_statusID)
        End Sub

        Public Function Port() As Integer
            Return _socket.Port
        End Function

        Private Sub lSocket_socketDataArrival(ByVal socketID As String, ByVal socketData As String, ByVal bytes() As Byte, ByVal lByteRead As Integer) Handles _socket.SocketDataArrival
            Select Case _socketType
                Case SocketType.Status
                    lProcessNumeric.lIrcNumericHelper.ProcessDataArrival(_statusID, socketData)
                Case SocketType.Ident
                    RaiseEvent DataArrival(socketData)
            End Select
        End Sub

        Private Sub socket_socketDisconnected(ByVal socketId As String) Handles _socket.SocketDisconnected
            lStatus.CloseStatusConnection(_statusID, False)
        End Sub
    End Class
End Namespace