'nexIRC 3.0.31
'Sunday, Oct 4th, 2014 - guideX
Option Explicit On
Option Strict Off
Imports nexIRC.clsIrcNumerics
Imports nexIRC.Modules
Imports nexIRC.nexIRC.MainWindow.clsMainWindowUI
Imports nexIRC.Classes.Communications
Imports Telerik.WinControls.UI
Imports nexIRC.Settings
Imports nexIRC.Business.Enums
Imports nexIRC.Business.Helpers

Namespace IRC.Status
    Public Class Status
#Region "STRUCTURES"
        Public Structure gLinks
            Public sTreeNode As TreeNode
            Public sTreeNodeVisible As Boolean
            Public sVisible As Boolean
            Public sWindow As frmServerLinks
            Public sLink() As gLink
            Public sLinkCount As Integer
        End Structure
        Public Structure gLink
            Public lServerIP As String
            Public lPort As String
        End Structure
        Public Structure gUnknowns
            Public uTreeNode As TreeNode
            Public uTreeNodeVisible As Boolean
            Public uVisible As Boolean
            Public uWindow As frmNoticeWindow
            Public uData As String
        End Structure
        Public Structure gUnsupported
            Public uTreeNode As TreeNode
            Public uTreeNodeVisible As Boolean
            Public uVisible As Boolean
            Public uWindow As frmNoticeWindow
            Public uData As String
        End Structure
        Public Structure gMotdWindow
            Public mWindow As frmNoticeWindow
            Public mVisible As Boolean
            Public mTreeNode As TreeNode
            Public mTreeNodeVisible As Boolean
            Public mData As String
        End Structure
        Public Structure gNoticesWindow
            Public nWindow As frmNoticeWindow
            Public nVisible As Boolean
            Public nTreeNode As TreeNode
            Public nTreeNodeVisible As Boolean
            Public nData As String
        End Structure
        Public Structure gNotifyItems
            Public nTreeNode As TreeNode
            Public nTreeNodeVisible As Boolean
            Public nCount As Integer
            Public nNotify() As gNotifyItem
        End Structure
        Public Structure gNotifyItem
            Public nNickname As String
        End Structure
        Public Structure gRaw
            Public rRawWindow As frmRaw
            Public rVisible As Boolean
            Public rOutData As String
            Public rTreeNode As TreeNode
            Public rTreeNodeVisible As Boolean
            Public rInData As String
        End Structure
        Public Structure gPrivateMessage
            Public pName As String
            Public pWindow As frmNoticeWindow
            Public pVisible As Boolean
            Public pTreeNode As TreeNode
            Public pTreeNodeVisible As Boolean
            Public pStatusIndex As Integer
            Public pHost As String
            Public pWindowBarItem As ToolStripItem
            Public pWindowInitiated As Boolean
            Public pFirstMessage As String
        End Structure
        Public Structure gPrivateMessages
            Public pCount As Integer
            Public pPrivateMessage() As gPrivateMessage
        End Structure
        Public Structure gStatusPrimitives
            Public sNickName As String
            Public sRemoteIP As String
            Public sRemotePort As Long
            Public sServerDescription As String
            Public sPass As String
            Public sEmail As String
            Public sRealName As String
            Public sOperNick As String
            Public sOperPass As String
            Public sNetworkIndex As Integer
            Public sServerName As String
            Public sInitialText As String
        End Structure
        Public Structure gSupportedModes
            Public sUserModes As String
            Public sChannelModes As String
        End Structure
        Public Structure gStatus
            Public sServerVersion As String
            Public sSupportedModes As gSupportedModes
            Public sPrimitives As gStatusPrimitives
            Public sTreeNode As TreeNode
            Public sTreeNodeVisible As Boolean
            Public sTreeNodeStatus As TreeNode
            Public sPrivateMessages As gPrivateMessages
            Public sNoticesWindow As gNoticesWindow
            Public sMotdWindow As gMotdWindow
            Public sRaw As gRaw
            Public sNotifyItems As gNotifyItems
            Public sModes As gModes
            Public sUnknowns As gUnknowns
            Public sUnsupported As gUnsupported
            Public sServerLinks As gLinks
            Public sSocket As StatusSocket
            Public sWindow As frmStatus
            Public sWindowBarItem As ToolStripItem
            Public sWindowBarItemSet As Boolean
            Public sVisible As Boolean
            Public sDoneModes As Boolean
            Public sOpen As Boolean
            Public sDescription As String
            Public sData As String
            Public sLastConnect As Long
            Public sConnecting As Boolean
            Public sServerIndex As Integer
            Public sNickBot As NickBot
        End Structure
        Public Structure gFuzzyChannelData
            Public fCount As Integer
            Public fIndex() As Integer
        End Structure
        Public Structure gStatusObjects
            Public sCount As Integer
            Public sIndex As Integer
            Public sStatusObject() As gStatus
        End Structure
#End Region
#Region "PRIVATE VARIABLES"
        Private lClosing As Boolean
        Private lStatusObjects As gStatusObjects
#End Region
#Region "STATUS"
        Private Sub SocketError(ByVal _Error As String, ByVal _SocketIndex As Integer)
            Try
                lStrings.Print(_Error, lStatusObjects.sStatusObject(_SocketIndex).sWindow.txtIncoming)
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Private Sub SocketError(_Error As String)")
            End Try
        End Sub
        Public Sub Window_Resize(ByVal id As Integer)
            Try
                If (lStatus.Window(id) IsNot Nothing) Then
                    With lStatus.Window(id)
                        .txtIncoming.Width = .ClientSize.Width
                        .txtIncoming.Height = .ClientSize.Height - (.txtOutgoing.Height + .tspStatus.ClientSize.Height)
                        .txtOutgoing.Width = .ClientSize.Width
                        .txtOutgoing.Top = .txtIncoming.Height + .tspStatus.ClientSize.Height
                    End With
                End If
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub Window_Resize(_ChannelIndex As Integer)")
            End Try
        End Sub
        Public Sub ResetForeMostWindows()
            Try
                For i As Integer = 1 To lStatusObjects.sCount
                    lStatusObjects.sStatusObject(i).sWindow.mdiChildWindow.lForeMost = False
                Next i
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub ResetForeMostWindows()")
            End Try
        End Sub
        Public Sub Minimize(ByVal _StatusIndex As Integer)
            Try
                lStatusObjects.sStatusObject(_StatusIndex).sWindow.WindowState = FormWindowState.Minimized
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub Minimize(_StatusIndex As Integer)")
            End Try
        End Sub
        Public Sub Outgoing_GotFocus(ByVal _StatusIndex As Integer)
            Try
                With lStatusObjects.sStatusObject(_StatusIndex)
                    If lSettings.lIRC.iSettings.sAutoMaximize = True Then .sWindow.WindowState = FormWindowState.Maximized
                    lStatus.ActiveIndex = _StatusIndex
                End With
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub Outgoing_GotFocus(_ChannelIndex As Integer)")
            End Try
        End Sub
        Public Sub New(ByVal _StatusObjectSize As Integer)
            Try
                ReDim lStatusObjects.sStatusObject(_StatusObjectSize)
                'ReDim lStatusObjects.sStatusObject(lArraySizes.aStatusWindows)
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub New()")
            End Try
        End Sub
        Public Sub Clear(ByVal _StatusIndex As Integer)
            Try
                With lStatusObjects.sStatusObject(_StatusIndex)
                    lChannels.ClearAll(_StatusIndex)
                    If .sMotdWindow.mTreeNodeVisible = True Then .sMotdWindow.mTreeNode = Nothing
                    If .sMotdWindow.mVisible = True Then .sMotdWindow.mWindow.Close()
                    .sMotdWindow.mTreeNodeVisible = False
                    .sMotdWindow.mWindow = Nothing
                    .sMotdWindow.mVisible = False
                    .sMotdWindow.mData = ""
                    If .sRaw.rVisible = True Then .sRaw.rRawWindow.Close()
                    If .sRaw.rTreeNodeVisible = True Then .sRaw.rTreeNode = Nothing
                    .sRaw.rTreeNodeVisible = False
                    .sRaw.rRawWindow = Nothing
                    .sRaw.rInData = ""
                    .sRaw.rOutData = ""
                    .sRaw.rVisible = False
                    If .sUnknowns.uVisible = True Then .sUnknowns.uWindow.Close()
                    If .sUnknowns.uTreeNodeVisible = True Then .sUnknowns.uTreeNode = Nothing
                    .sUnknowns.uTreeNodeVisible = False
                    .sUnknowns.uWindow = Nothing
                    .sUnknowns.uData = ""
                    .sUnknowns.uVisible = False
                    lChannelLists.Unload(lChannelLists.ReturnChannelListIndex(_StatusIndex))
                    If .sNotifyItems.nTreeNodeVisible = True Then .sNotifyItems.nTreeNode = Nothing
                    .sNotifyItems.nTreeNodeVisible = False
                    .sNotifyItems.nNotify = Nothing
                    .sNotifyItems.nCount = 0
                    If .sServerLinks.sVisible = True Then .sServerLinks.sWindow.Close()
                    If .sServerLinks.sTreeNodeVisible = True Then .sServerLinks.sTreeNode = Nothing
                    .sServerLinks.sTreeNodeVisible = False
                    .sServerLinks.sWindow = Nothing
                    .sServerLinks.sLinkCount = 0
                    .sServerLinks.sLink = Nothing
                    .sServerLinks.sVisible = False
                    .sTreeNode = Nothing
                    .sTreeNodeStatus = Nothing
                    .sDescription = ""
                    .sDoneModes = False
                    .sWindow = Nothing
                    .sVisible = False
                End With
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub ClearStatusWindow(ByVal lServerIndex As Integer)")
            End Try
        End Sub
        Public Sub SetSupportedModes(ByVal _StatusIndex As Integer, ByVal _Data As String)
            Try
                Dim splt() As String = Split(_Data, " ")
                With lStatusObjects.sStatusObject(_StatusIndex)
                    .sSupportedModes = New gSupportedModes()
                    .sSupportedModes.sUserModes = splt(3)
                    .sSupportedModes.sChannelModes = splt(4)
                End With
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub SetSupportedModes(_StatusIndex As Integer, _Data As String)")
            End Try
        End Sub
        Public Function Create(ByVal lIRCSettings As Settings.gIRC, ByVal lServerSettings As Settings.gServers) As Integer
            Try
                Dim msg As String, i As Integer
                lStatusObjects.sCount = lStatusObjects.sCount + 1
                lStatusObjects.sIndex = lStatusObjects.sCount
                i = lStatusObjects.sIndex
                With lStatusObjects.sStatusObject(i)
                    ReDim .sNotifyItems.nNotify(lSettings.lArraySizes.aNotifyItems)
                    ReDim .sServerLinks.sLink(lSettings.lArraySizes.aServerLinks)
                    ReDim .sPrivateMessages.pPrivateMessage(lSettings.lArraySizes.aQueries)
                    .sServerIndex = lServerSettings.sIndex
                    .sPrimitives.sNetworkIndex = lServerSettings.sServer(lServerSettings.sIndex).sNetworkIndex
                    .sNickBot = New NickBot(i)
                    .sWindow = New frmStatus
                    .sWindow.mdiChildWindow.FormType = MdiChildWindow.FormTypes.Status
                    .sWindow.mdiChildWindow.MeIndex = i
                    .sVisible = True
                    .sPrimitives.sEmail = lSettings.lIRC.iEMail
                    .sPrimitives.sPass = lSettings.lIRC.iPass
                    .sPrimitives.sRealName = lSettings.lIRC.iRealName
                    .sPrimitives.sOperNick = lSettings.lIRC.iOperName
                    .sPrimitives.sOperPass = lSettings.lIRC.iOperPass
                    .sWindow.Show()
                    .sWindow.Icon = mdiMain.Icon
                    .sWindow.MdiParent = mdiMain
                    .sWindow.Visible = True
                    ActiveIndex = .sWindow.mdiChildWindow.MeIndex
                    mdiMain.SetWindowFocus(.sWindow)
                    .sWindow.Width = lSettings.lIRC.iSettings.sWindowSizes.lStatus.wWidth
                    .sWindow.Height = lSettings.lIRC.iSettings.sWindowSizes.lStatus.wHeight
                    If lSettings.lIRC.iSettings.sAutoConnect = True Then .sWindow.lAutoConnectDelayTimer.Enabled = True
                    msg = NewInitialText(i)
                    .sPrimitives.sRemoteIP = lSettings.lServers.sServer(lSettings.lServers.sIndex).sIP
                    .sPrimitives.sRemotePort = lSettings.lServers.sServer(lSettings.lServers.sIndex).sPort
                    NickName(i) = lSettings.lIRC.iNicks.nNick(lSettings.lIRC.iNicks.nIndex).nNick
                    .sWindow.Text = msg
                    .sPrimitives.sInitialText = msg
                    .sWindowBarItem = mdiMain.AddWindowBar(msg, gWindowBarImageTypes.wStatus)
                    .sWindowBarItem.Tag = Trim(i.ToString)
                    .sWindowBarItemSet = True
                    .sDescription = msg
                    .sTreeNode = mdiMain.tvwConnections.Nodes.Add("", .sDescription, 2, 2)
                    .sTreeNodeVisible = True
                    .sTreeNodeStatus = .sTreeNode.Nodes.Add(lServerSettings.sServer(lServerSettings.sIndex).sIP, "Status", 0, 0)
                    .sTreeNode.Expand()
                    .sWindow.tmrQuickFocus.Enabled = True
                End With
                ActiveIndex = i
                Return lStatusObjects.sCount
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Sub SetOperSettings(ByVal lIndex As Integer, ByVal lOperNick As String, ByVal lOperPass As String)
            Try
                With lStatusObjects.sStatusObject(lIndex)
                    .sPrimitives.sOperNick = lOperNick
                    .sPrimitives.sOperPass = lOperPass
                End With
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub SetStatusOperSettings(ByVal lOperNick As String, ByVal lOperPass As String)")
            End Try
        End Sub
        Public Sub SetStatus(ByVal _Index As Integer)
            Try
                Dim _StatusText As String
                SetRemoteSettings(_Index, lSettings.lServers.sServer(lSettings.lServers.sIndex).sIP, lSettings.lServers.sServer(lSettings.lServers.sIndex).sPort)
                NetworkIndex(_Index) = lSettings.lServers.sServer(lSettings.lServers.sIndex).sNetworkIndex
                _StatusText = lStatus.NewInitialText(_Index)
                Caption(_Index) = _StatusText
                TreeNodeText(_Index) = _StatusText
                Description(_Index) = _StatusText
                WindowBarText(_Index) = _StatusText
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub SetStatus(ByVal lIndex As Integer)")
            End Try
        End Sub
        Public Sub CloseWindow(ByVal _Index As Integer)
            Try
                lStatusObjects.sStatusObject(_Index).sWindow.Close()
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub CloseWindow(_Index As Integer)")
            End Try
        End Sub
        Public Function Window(ByVal _StatusIndex As Integer) As frmStatus
            Try
                Return lStatusObjects.sStatusObject(_StatusIndex).sWindow
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Function Window(_StatusIndex As Integer) As frmStatus")
                Return Nothing
            End Try
        End Function
        Public Sub ToggleStatusWindowState(ByVal _StatusIndex As Integer, ByVal _ForeMost As Boolean)
            Try
                If _StatusIndex <> 0 Then
                    With lStatusObjects.sStatusObject(_StatusIndex)
                        If .sWindow.WindowState = FormWindowState.Normal = True Then
                            If _ForeMost = True Then
                                .sWindow.WindowState = FormWindowState.Minimized
                            Else
                                .sWindow.Focus()
                            End If
                        ElseIf .sWindow.WindowState = FormWindowState.Maximized = True Then
                            If _ForeMost = True Then
                                .sWindow.WindowState = FormWindowState.Minimized
                            Else
                                .sWindow.Focus()
                            End If
                        ElseIf .sWindow.WindowState = FormWindowState.Minimized = True Then
                            .sWindow.WindowState = FormWindowState.Normal
                        End If
                    End With
                End If
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub ToggleStatusWindowState(ByVal lIndex As Integer)")
            End Try
        End Sub
        Public Function FindByInitialText(ByVal lText As String) As Integer
            Try
                Dim _Result As Integer
                For _StatusIndex As Integer = 1 To lStatusObjects.sCount
                    With lStatusObjects.sStatusObject(_StatusIndex)
                        If LCase(Trim(.sPrimitives.sInitialText)) = LCase(Trim(lText)) Then
                            _Result = _StatusIndex
                            Exit For
                        End If
                    End With
                Next _StatusIndex
                Return _Result
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Function FindStatusIndexByInitialText(ByVal lText As String) As Integer")
                Return Nothing
            End Try
        End Function
        Public Function FindByDescription(ByVal lData As String) As Integer
            Try
                Dim i As Integer, n As Integer
                For i = 1 To lStatusObjects.sCount
                    With lStatusObjects.sStatusObject(i)
                        If Trim(LCase(.sDescription)) = Trim(LCase(lData)) Then
                            n = i
                            Exit For
                        End If
                    End With
                Next i
                Return n
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Function FindServerWindowIndexByServerDescription(ByVal lData As String) As Integer")
                Return Nothing
            End Try
        End Function
        Public Function Find(ByVal _Description As String) As Integer
            Try
                Dim i As Integer, n As Integer
                For i = 1 To lStatusObjects.sCount
                    With lStatusObjects.sStatusObject(i)
                        If .sDescription.Trim().ToLower() = _Description.Trim().ToLower() Then
                            n = i
                            Exit For
                        End If
                    End With
                Next i
                Return n
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Function FindStatusWindowIndex(ByVal lDescription As String) As Integer")
                Return Nothing
            End Try
        End Function
        Public ReadOnly Property GetObject(ByVal _Index As Integer) As gStatus
            Get
                Try
                    Return lStatusObjects.sStatusObject(_Index)
                Catch ex As Exception
                    Throw ex 'ProcessError(ex.Message, "Public ReadOnly Property GetObject(_Index As Integer) As gStatus")
                    Return Nothing
                End Try
            End Get
        End Property
        Public Property WindowBarText(ByVal _Index As Integer) As String
            Get
                Try
                    With lStatusObjects.sStatusObject(_Index)
                        If .sWindowBarItemSet = True Then
                            Return .sWindowBarItem.Text
                        Else
                            Return ""
                        End If
                    End With
                Catch ex As Exception
                    Throw ex 'ProcessError(ex.Message, "Public Property WindowBarText(ByVal _Index As Integer) As String")
                    Return Nothing
                End Try
            End Get
            Set(ByVal _Value As String)
                Try
                    With lStatusObjects.sStatusObject(_Index)
                        .sWindowBarItem.Text = _Value
                    End With
                Catch ex As Exception
                    Throw ex 'ProcessError(ex.Message, "WindowBarSetting")
                End Try
            End Set
        End Property
        Public Property TreeNodeText(ByVal _Index As Integer) As String
            Get
                Try
                    With lStatusObjects.sStatusObject(_Index)
                        If .sTreeNodeVisible = True Then
                            Return .sTreeNode.Text
                        Else
                            Return ""
                        End If
                    End With
                Catch ex As Exception
                    Throw ex 'ProcessError(ex.Message, "Public Property TreeNodeText(ByVal _Index As Integer) As String")
                    Return Nothing
                End Try
            End Get
            Set(ByVal _Value As String)
                Try
                    With lStatusObjects.sStatusObject(_Index)
                        lStatusObjects.sStatusObject(_Index).sTreeNode.Text = _Value
                    End With
                Catch ex As Exception
                    Throw ex 'ProcessError(ex.Message, "Public Property TreeNodeText(ByVal _Index As Integer) As String")
                End Try
            End Set
        End Property
        Public Property Open(ByVal index As Integer) As Boolean
            Get
                Dim result As Boolean
                Try
                    If (index <> 0) Then result = lStatusObjects.sStatusObject(index).sOpen
                    Return result
                Catch ex As Exception
                    Throw ex
                    Return Nothing
                End Try
            End Get
            Set(ByVal value As Boolean)
                Try
                    lStatusObjects.sStatusObject(index).sOpen = value
                Catch ex As Exception
                    Throw ex 'ProcessError(ex.Message, "Public Property StatusOpen(ByVal _Index As Integer) As Boolean")
                End Try
            End Set
        End Property
        Public Property ServerDescription(ByVal _Index As Integer) As String
            Get
                Try
                    Return lStatusObjects.sStatusObject(_Index).sPrimitives.sServerDescription
                Catch ex As Exception
                    Throw ex 'ProcessError(ex.Message, "Public Property ServerDescription(ByVal _Index As Integer) As String")
                    Return Nothing
                End Try
            End Get
            Set(ByVal _Value As String)
                Try
                    lStatusObjects.sStatusObject(_Index).sPrimitives.sServerDescription = _Value
                Catch ex As Exception
                    Throw ex 'ProcessError(ex.Message, "Public Property ServerDescription(ByVal _Index As Integer) As String")
                End Try
            End Set
        End Property
        Public Property Caption(ByVal _Index As Integer) As String
            Get
                Try
                    Return lStatusObjects.sStatusObject(_Index).sWindow.Text
                Catch ex As Exception
                    Throw ex 'ProcessError(ex.Message, "Public Property StatusCaption(ByVal lIndex As Integer) As String")
                    Return Nothing
                End Try
            End Get
            Set(ByVal _Value As String)
                Try
                    lStatusObjects.sStatusObject(_Index).sWindow.Text = _Value
                Catch ex As Exception
                    Throw ex 'ProcessError(ex.Message, "Public Property StatusCaption(ByVal lIndex As Integer) As String")
                End Try
            End Set
        End Property
        Public Property Description(ByVal lIndex As Integer) As String
            Get
                Try
                    Return lStatusObjects.sStatusObject(lIndex).sDescription
                Catch ex As Exception
                    Throw ex
                    Return Nothing
                End Try
            End Get
            Set(ByVal lValue As String)
                Try
                    lStatusObjects.sStatusObject(lIndex).sDescription = lValue
                Catch ex As Exception
                    Throw ex
                End Try
            End Set
        End Property
        Public Property NetworkIndex(ByVal lIndex As Integer) As Integer
            Get
                Try
                    Return lStatusObjects.sStatusObject(lIndex).sPrimitives.sNetworkIndex
                Catch ex As Exception
                    Return 0
                    Throw ex 'ProcessError(ex.Message, "Public Property StatusNetworkIndex(ByVal lIndex As Integer) As Integer")
                End Try
            End Get
            Set(ByVal lValue As Integer)
                Try
                    lStatusObjects.sStatusObject(lIndex).sPrimitives.sNetworkIndex = lValue
                Catch ex As Exception
                    Throw ex 'ProcessError(ex.Message, "Public Property StatusNetworkIndex(ByVal lIndex As Integer) As Integer")
                End Try
            End Set
        End Property
        Public Property StatusModes(ByVal lIndex As Integer) As gModes
            Get
                Try
                    Return lStatusObjects.sStatusObject(lIndex).sModes
                Catch ex As Exception
                    Throw ex 'ProcessError(ex.Message, "Public Property StatusModes(ByVal lIndex As Integer) As gModes")
                End Try
            End Get
            Set(ByVal lValue As gModes)
                Try
                    lStatusObjects.sStatusObject(lIndex).sModes = lValue
                Catch ex As Exception
                    Throw ex 'ProcessError(ex.Message, "Public Property StatusModes(ByVal lIndex As Integer) As gModes")
                End Try
            End Set
        End Property
        Public Property RealName(ByVal lIndex As Integer) As String
            Get
                Try
                    Return lStatusObjects.sStatusObject(lIndex).sPrimitives.sRealName
                Catch ex As Exception
                    Throw ex 'ProcessError(ex.Message, "Public Property RealName(ByVal lIndex As Integer) As String")
                    Return Nothing
                End Try
            End Get
            Set(ByVal lValue As String)
                Try
                    lStatusObjects.sStatusObject(lIndex).sPrimitives.sRealName = lValue
                Catch ex As Exception
                    Throw ex 'ProcessError(ex.Message, "Public Property RealName(ByVal lIndex As Integer) As String")
                End Try
            End Set
        End Property
        Public Property Email(ByVal _StatusIndex As Integer) As String
            Get
                Try
                    With lStatusObjects.sStatusObject(_StatusIndex)
                        Return .sPrimitives.sEmail
                    End With
                Catch ex As Exception
                    Throw ex 'ProcessError(ex.Message, "Public Property Email(_StatusIndex As Integer) As String")
                    Return Nothing
                End Try
            End Get
            Set(ByVal _Email As String)
                Try
                    With lStatusObjects.sStatusObject(_StatusIndex)
                        .sPrimitives.sEmail = _Email
                    End With
                Catch ex As Exception
                    Throw ex 'ProcessError(ex.Message, "Public Property Email(_StatusIndex As Integer) As String")
                End Try
            End Set
        End Property
        Public Property NickName(ByVal _StatusIndex As Integer, Optional ByVal _SendToServer As Boolean = False) As String
            Get
                Try
                    With lStatusObjects.sStatusObject(_StatusIndex)
                        Dim msg As String
                        msg = .sPrimitives.sNickName
                        Return msg
                    End With
                Catch ex As Exception
                    Throw ex 'ProcessError(ex.Message, "Public Property NickName(_StatusIndex As Integer) As String")
                    Return Nothing
                End Try
            End Get
            Set(ByVal _NickName As String)
                Try
                    Dim _Exists As Boolean = False
                    With lStatusObjects.sStatusObject(_StatusIndex)
                        .sPrimitives.sNickName = _NickName
                        If _SendToServer = True Then DoStatusSocket(_StatusIndex, "NICK :" & _NickName)
                        For _NickNameIndex As Integer = 1 To lSettings.lIRC.iNicks.nCount
                            If lSettings.lIRC.iNicks.nNick(_NickNameIndex).nNick.ToLower() = _NickName Then _Exists = True
                        Next _NickNameIndex
                        If _Exists = False Then lSettings.AddNickName(_NickName)
                        UpdateCaption(_StatusIndex, _NickName, lStatus.StatusServerName(_StatusIndex))
                    End With
                Catch ex As Exception
                    Throw ex 'ProcessError(ex.Message, "Public Property NickName(_StatusIndex As Integer) As String")
                End Try
            End Set
        End Property
        Public Sub UpdateCaption(ByVal _StatusIndex As Integer, ByVal _NickName As String, ByVal _Server As String)
            Try
                Caption(_StatusIndex) = _NickName & " on " & _Server
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub UpdateCaption(_StatusIndex As Integer, _NickName As String, _Server As String)")
            End Try
        End Sub
        Public Property StatusServerName(ByVal lIndex As Integer) As String
            Get
                Try
                    Return lStatusObjects.sStatusObject(lIndex).sPrimitives.sServerName
                Catch ex As Exception
                    Throw ex 'ProcessError(ex.Message, "Public Property StatusServerName(ByVal lIndex As Integer) As String")
                    Return Nothing
                End Try
            End Get
            Set(ByVal lValue As String)
                Try
                    lStatusObjects.sStatusObject(lIndex).sPrimitives.sServerName = lValue
                Catch ex As Exception
                    Throw ex 'ProcessError(ex.Message, "Public Property StatusServerName(ByVal lIndex As Integer) As String")
                End Try
            End Set
        End Property
        Public Property ActiveIndex() As Integer
            Get
                Try
                    Return lStatusObjects.sIndex
                Catch ex As Exception
                    Throw ex 'ProcessError(ex.Message, "Public Property ActiveIndex() As Integer")
                    Return Nothing
                End Try
            End Get
            Set(ByVal _ActiveIndex As Integer)
                Try
                    lStatusObjects.sIndex = _ActiveIndex
                Catch ex As Exception
                    Throw ex 'ProcessError(ex.Message, "Public Property ActiveIndex() As Integer")
                End Try
            End Set
        End Property
        Public Property Pass(ByVal lIndex As Integer) As String
            Get
                Try
                    Return lStatusObjects.sStatusObject(lIndex).sPrimitives.sPass
                Catch ex As Exception
                    Throw ex 'ProcessError(ex.Message, "Public ReadOnly Property Pass(ByVal lIndex As Integer) As String")
                    Return Nothing
                End Try
            End Get
            Set(ByVal lValue As String)
                Try
                    lStatusObjects.sStatusObject(lIndex).sPrimitives.sPass = lValue
                Catch ex As Exception
                    Throw ex 'ProcessError(ex.Message, "Public Property Pass(ByVal lIndex As Integer) As String")
                End Try
            End Set
        End Property
        Public Property Closing() As Boolean
            Get
                Try
                    Return lClosing
                Catch ex As Exception
                    Throw ex 'ProcessError(ex.Message, "Public Property Closing() As Boolean")
                    Return Nothing
                End Try
            End Get
            Set(ByVal _Closing As Boolean)
                Try
                    lClosing = _Closing
                Catch ex As Exception
                    Throw ex 'ProcessError(ex.Message, "Public Property Closing() As Boolean")
                End Try
            End Set
        End Property
        Public ReadOnly Property Connected(ByVal _StatusIndex As Integer) As Boolean
            Get
                Try
                    Dim _Result As Boolean = False
                    If (lStatusObjects.sStatusObject(_StatusIndex).sSocket) IsNot Nothing Then
                        _Result = lStatusObjects.sStatusObject(_StatusIndex).sSocket.Connected
                    End If
                    Return _Result
                Catch ex As Exception
                    Throw ex 'ProcessError(ex.Message, "Public Property Connected(_StatusIndex As Integer) As Boolean")
                    Return Nothing
                End Try
            End Get
            'Set(_Connected As Boolean)
            'lStatusObjects.sStatusObject(_StatusIndex).sConnected = _Connected
            'End Set
        End Property
        Public Sub ActiveStatusConnect()
            Try
                Dim i As Integer
                i = ActiveIndex()
                With lStatusObjects.sStatusObject(lStatusObjects.sIndex)
                    Connect(i)
                End With
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub ActiveStatusConnect()")
            End Try
        End Sub
        Public Sub DoModes(ByVal _StatusIndex As Integer)
            Try
                'Dim msg As String, 
                Dim _Pluses As String = "", _Minuses As String = "", _Modes As String = "", m As gModes
                m = StatusModes(_StatusIndex)
                With m
                    If InStr(lStatusObjects.sStatusObject(_StatusIndex).sSupportedModes.sUserModes, "i") <> 0 Then
                        If .mInvisible = True Then
                            _Pluses = _Pluses & "i"
                        Else
                            _Minuses = _Minuses & "i"
                        End If
                    End If
                    If InStr(lStatusObjects.sStatusObject(_StatusIndex).sSupportedModes.sUserModes, "0") <> 0 Then
                        If .mLocalOperator = True Then
                            _Pluses = _Pluses & "0"
                        Else
                            _Minuses = _Minuses & "0"
                        End If
                    End If
                    If InStr(lStatusObjects.sStatusObject(_StatusIndex).sSupportedModes.sUserModes, "o") <> 0 Then
                        If .mOperator = True Then
                            _Pluses = _Pluses & "o"
                        Else
                            _Minuses = _Minuses & "o"
                        End If
                    End If
                    If InStr(lStatusObjects.sStatusObject(_StatusIndex).sSupportedModes.sUserModes, "r") <> 0 Then
                        If .mRestricted = True Then
                            _Pluses = _Pluses & "r"
                        Else
                            _Minuses = _Minuses & "r"
                        End If
                    End If
                    If InStr(lStatusObjects.sStatusObject(_StatusIndex).sSupportedModes.sUserModes, "s") <> 0 Then
                        If .mServerNotices = True Then
                            _Pluses = _Pluses & "s"
                        Else
                            _Minuses = _Minuses & "s"
                        End If
                    End If
                    If InStr(lStatusObjects.sStatusObject(_StatusIndex).sSupportedModes.sUserModes, "w") <> 0 Then
                        If .mWallops = True Then
                            _Pluses = _Pluses & "w"
                        Else
                            _Minuses = _Minuses & "w"
                        End If
                    End If
                    If _Pluses.Length <> 0 Then _Modes = "+" & _Pluses
                    If _Minuses.Length <> 0 Then
                        If _Modes.Length <> 0 Then
                            _Modes = _Modes & "-" & _Minuses
                        Else
                            _Modes = "-" & _Minuses
                        End If
                    End If
                    If _Modes.Length <> 0 Then
                        If lSettings.lIRC.iSettings.sExtendedMessages = True Then lStrings.ProcessReplaceString(_StatusIndex, eStringTypes.sSETTING_MODES)
                        SendSocket(_StatusIndex, "MODE " & NickName(_StatusIndex) & " " & _Modes)
                    End If
                End With
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub DoModes(ByVal lStatusIndex As Integer)")
            End Try
        End Sub
        Public Sub AddText(ByVal _Data As String, ByVal _StatusIndex As Integer)
            Try
                If Len(_Data) <> 0 And _StatusIndex <> 0 Then
                    With lStatusObjects.sStatusObject(_StatusIndex)
                        If (.sVisible = False Or .sWindow.WindowState = FormWindowState.Minimized) Then
                            If .sTreeNodeStatus.ImageIndex <> 8 Then .sTreeNodeStatus.ImageIndex = 8
                            If .sTreeNodeStatus.SelectedImageIndex <> 8 Then .sTreeNodeStatus.SelectedImageIndex = 8
                            If .sWindowBarItem.ImageIndex <> 8 Then .sWindowBarItem.ImageIndex = 8
                        End If
                        .sData = _Data & Environment.NewLine & .sData
                        lStrings.Print(_Data, .sWindow.txtIncoming)
                    End With
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        Public Sub RemoveTreeView(ByVal lServerWindowIndex As Integer)
            Try
                With lStatusObjects.sStatusObject(lServerWindowIndex)
                    .sTreeNode.Remove()
                End With
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub RemoveTreeView(ByVal lServerIndex As Integer)")
            End Try
        End Sub
        Public Sub SetSeenIcon(ByVal lStatusIndex As Integer, ByVal lSeen As Boolean)
            Try
                If (lStatusIndex <= lStatusObjects.sStatusObject.Length) Then
                    With lStatusObjects.sStatusObject(lStatusIndex)
                        If lStatusIndex <> 0 Then
                            If lSeen = True Then
                                If .sTreeNodeStatus IsNot Nothing Then
                                    If .sTreeNodeStatus.ImageIndex <> 0 Then .sTreeNodeStatus.ImageIndex = 0
                                    If .sTreeNodeStatus.SelectedImageIndex <> 0 Then .sTreeNodeStatus.SelectedImageIndex = 0
                                End If
                            Else
                                If .sTreeNodeStatus.ImageIndex <> 8 Then .sTreeNodeStatus.ImageIndex = 8
                                If .sTreeNodeStatus.SelectedImageIndex <> 8 Then .sTreeNodeStatus.SelectedImageIndex = 8
                            End If
                        End If
                    End With
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        Public ReadOnly Property AllConnectionsClosed() As Boolean
            Get
                Dim _Result As Boolean = True
                For i As Integer = 1 To lStatusObjects.sCount
                    With lStatusObjects.sStatusObject(i)
                        If (.sSocket.Connected = True) Then
                            _Result = False
                        End If
                    End With
                Next i
                Return _Result
            End Get
        End Property
        Public Function QuitAll() As Boolean
            Try
                Dim result As Boolean = True
                For i As Integer = 1 To lStatusObjects.sCount
                    With lStatusObjects.sStatusObject(i)
                        If Connected(i) = True Then
                            Quit(i)
                            result = False
                        End If
                    End With
                Next i
                Return result
            Catch ex As Exception
                Throw ex
                Return Nothing
            End Try
        End Function
        Public Sub Quit(ByVal _Index As Integer)
            Try
                With lStatusObjects.sStatusObject(_Index)
                    If Len(lSettings.lIRC.iSettings.sQuitMessage) <> 0 Then
                        SendSocket(_Index, "QUIT " & lSettings.lIRC.iSettings.sQuitMessage)
                    Else
                        SendSocket(_Index, "QUIT")
                    End If
                End With
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub SendQuitMessage(ByVal lIndex As Integer)")
            End Try
        End Sub
        Public ReadOnly Property NewInitialText(ByVal _Index As Integer) As String
            Get
                Try
                    Return Modules.IrcSettings.IrcNetworks.GetById(lSettings.lServers.sServer(lSettings.lServers.sIndex).sNetworkIndex).Description & " (" & Trim(_Index.ToString().Trim()) & ")"
                Catch ex As Exception
                    Throw ex 'ProcessError(ex.Message, "Public ReadOnly Property NewInitialText(ByVal lIndex As Integer) As String")
                    Return Nothing
                End Try
            End Get
        End Property
        Public Function InitialText(ByVal lIndex As Integer) As String
            Try
                With lStatusObjects.sStatusObject(lIndex)
                    Return .sPrimitives.sInitialText
                End With
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Function ReturnStatusInitialText(ByVal lIndex As Integer) As String")
                Return Nothing
            End Try
        End Function
        Public Sub SetListBoxToConnections(ByVal lListBox As ListBox)
            Try
                Dim i As Integer
                For i = 1 To lStatusObjects.sCount
                    With lStatusObjects.sStatusObject(i)
                        lListBox.Items.Add(.sPrimitives.sInitialText)
                    End With
                Next i
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub SetListBoxToConnections(ByVal lListBox As ListBox)")
            End Try
        End Sub
        Public Sub Focus(ByVal statusIndex As Integer)
            Try
                lStatus.Window(statusIndex).Focus()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        Public Sub DblClickConnections(ByVal lTreeNode As TreeNode)
            Try
                If lTreeNode IsNot Nothing Then
                    Dim msg As String, i As Integer, n As Integer, t As Integer, e As Integer
                    If LCase(lTreeNode.Text) = "motd" Then
                        n = Find(lTreeNode.Parent.Text)
                        If n <> 0 Then
                            With lStatusObjects.sStatusObject(n)
                                If .sMotdWindow.mVisible = False Then
                                    If .sMotdWindow.mTreeNode.ImageIndex <> 3 Then .sMotdWindow.mTreeNode.ImageIndex = 3
                                    If .sMotdWindow.mTreeNode.SelectedImageIndex <> 3 Then .sMotdWindow.mTreeNode.SelectedImageIndex = 3
                                    .sMotdWindow.mWindow = New frmNoticeWindow
                                    .sMotdWindow.mWindow.Visible = False
                                    .sMotdWindow.mWindow.Show()
                                    .sMotdWindow.mVisible = True
                                    .sMotdWindow.mWindow.SetStatusIndex(n)
                                    .sMotdWindow.mWindow.Text = StatusServerName(.sWindow.mdiChildWindow.MeIndex) & " - MOTD"
                                    .sMotdWindow.mWindow.FormType = MdiChildWindow.FormTypes.MotdWindow
                                    .sMotdWindow.mWindow.DoNoticeColor(.sMotdWindow.mData)
                                    .sMotdWindow.mWindow.Visible = True
                                Else
                                    mdiMain.SetWindowFocus(.sMotdWindow.mWindow)
                                End If
                            End With
                        End If
                        Exit Sub
                    End If
                    If LCase(lTreeNode.Text) = "links" Then
                        n = Find(lTreeNode.Parent.Text)
                        If n <> 0 Then
                            With lStatusObjects.sStatusObject(n)
                                If .sServerLinks.sVisible = False Then
                                    t = NetworkIndex(.sWindow.mdiChildWindow.MeIndex)
                                    .sServerLinks.sVisible = True
                                    .sServerLinks.sWindow = New frmServerLinks
                                    .sServerLinks.sWindow.Show()
                                    .sServerLinks.sWindow.lServerLinksUI.SetStatusIndex(n)
                                    .sServerLinks.sWindow.lServerLinksUI.SetNetworkIndex(t, .sServerLinks.sWindow.cboNetworks)
                                    .sServerLinks.sWindow.cboNetworks.Text = Modules.IrcSettings.IrcNetworks.GetById(t).Description
                                    For i = 1 To .sServerLinks.sLinkCount
                                        .sServerLinks.sWindow.lServerLinksUI.AddToLinks(.sServerLinks.sLink(i).lServerIP, .sServerLinks.sLink(i).lPort, .sServerLinks.sWindow.lvwLinks)
                                    Next i
                                Else
                                    mdiMain.SetWindowFocus(.sServerLinks.sWindow)
                                End If
                            End With
                        End If
                    End If
                    If LCase(lTreeNode.Text) = "unknowns" Then
                        n = Find(lTreeNode.Parent.Text)
                        If n <> 0 Then
                            With lStatusObjects.sStatusObject(n)
                                If .sUnknowns.uVisible = False Then
                                    .sUnknowns.uVisible = True
                                    .sUnknowns.uWindow = New frmNoticeWindow
                                    .sUnknowns.uWindow.SetStatusIndex(n)
                                    .sUnknowns.uWindow.Show()
                                    .sUnknowns.uWindow.FormType = MdiChildWindow.FormTypes.Unknown
                                    .sUnknowns.uWindow.Text = "Unknowns"
                                    .sUnknowns.uWindow.DoNoticeColor(.sUnknowns.uData)
                                    If .sUnknowns.uTreeNode.ImageIndex <> 3 Then .sUnknowns.uTreeNode.ImageIndex = 3
                                    If .sUnknowns.uTreeNode.SelectedImageIndex <> 3 Then .sUnknowns.uTreeNode.SelectedImageIndex = 3
                                Else
                                    mdiMain.SetWindowFocus(.sUnknowns.uWindow)
                                End If
                            End With
                        End If
                    End If
                    If LCase(lTreeNode.Text) = "unsupported" Then
                        n = Find(lTreeNode.Parent.Text)
                        If n <> 0 Then
                            With lStatusObjects.sStatusObject(n)
                                If .sUnsupported.uVisible = False Then
                                    .sUnsupported.uVisible = True
                                    .sUnsupported.uWindow = New frmNoticeWindow
                                    .sUnsupported.uWindow.SetStatusIndex(n)
                                    .sUnsupported.uWindow.Show()
                                    .sUnsupported.uWindow.FormType = MdiChildWindow.FormTypes.Unsupported
                                    .sUnsupported.uWindow.Text = "Unsupported"
                                    .sUnsupported.uWindow.DoNoticeColor(.sUnsupported.uData)
                                    If .sUnsupported.uTreeNode.ImageIndex <> 3 Then .sUnsupported.uTreeNode.ImageIndex = 3
                                    If .sUnsupported.uTreeNode.SelectedImageIndex <> 3 Then .sUnsupported.uTreeNode.SelectedImageIndex = 3
                                Else
                                    mdiMain.SetWindowFocus(.sUnsupported.uWindow)
                                End If
                            End With
                        End If
                    End If
                    If LCase(lTreeNode.Text) = "raw" Then
                        n = Find(lTreeNode.Parent.Text)
                        If n <> 0 Then
                            With lStatusObjects.sStatusObject(n).sRaw
                                If .rVisible = False Then
                                    .rRawWindow = New frmRaw
                                    .rRawWindow.Show()
                                    .rVisible = True
                                    .rRawWindow.SetStatusIndex(n)
                                    .rRawWindow.txtInData.Text = .rInData
                                    .rRawWindow.txtOutData.Text = .rOutData
                                    .rRawWindow.Text = "nexIRC - Raw " & lStatusObjects.sStatusObject(n).sDescription
                                    If .rTreeNode.ImageIndex <> 4 Then .rTreeNode.ImageIndex = 4
                                    If .rTreeNode.SelectedImageIndex <> 4 Then .rTreeNode.SelectedImageIndex = 4
                                Else
                                    mdiMain.SetWindowFocus(.rRawWindow)
                                End If
                            End With
                        End If
                        Exit Sub
                    End If
                    If LCase(lTreeNode.Text) = "channel list" Then
                        n = Find(lTreeNode.Parent.Text)
                        If n <> 0 Then
                            lChannelLists.DoubleClick(lChannelLists.ReturnChannelListIndex(n))
                        End If
                        Exit Sub
                    End If
                    If LCase(lTreeNode.Text) = "notify" Then Exit Sub
                    If LCase(lTreeNode.Text) = "notices" Then
                        n = Find(lTreeNode.Parent.Text)
                        msg = lStatusObjects.sStatusObject(n).sPrimitives.sServerName
                        With lStatusObjects.sStatusObject(n).sNoticesWindow
                            If .nVisible = False Then
                                .nVisible = True
                                .nWindow = New frmNoticeWindow
                                .nWindow.Show()
                                .nWindow.SetStatusIndex(n)
                                .nWindow.DoNoticeColor(.nData)
                                .nWindow.FormType = MdiChildWindow.FormTypes.NoticeWindow
                                .nWindow.Text = msg & " - Notices"
                                If .nTreeNode.SelectedImageIndex <> 3 Then .nTreeNode.SelectedImageIndex = 3
                                If .nTreeNode.ImageIndex <> 3 Then .nTreeNode.ImageIndex = 3
                            Else
                                mdiMain.SetWindowFocus(.nWindow)
                            End If
                        End With
                        Exit Sub
                    End If
                    If LCase(lTreeNode.Text) = "status" Then
                        msg = lTreeNode.FullPath
                        msg = msg.Replace("\", "")
                        msg = msg.Replace("/", "")
                        msg = msg.Replace("Status", "")
                        n = FindByDescription(msg)
                        If n <> 0 Then
                            If (Not lStatus.Visible(e)) Then
                                lStatus.Visible(n) = True
                            Else
                                lStatus.Focus(n)
                            End If
                        End If
                        Exit Sub
                    End If
                    If Find(lTreeNode.Text) <> 0 Then Exit Sub
                    If LCase(lTreeNode.Parent.Text) = "notify" Then
                        e = lSettings.FindNotifyIndex(lTreeNode.Text)
                        n = Find(lTreeNode.Parent.Text)
                        If e <> 0 And n <> 0 Then
                            If e <> 0 Then
                                lStatus.PrivateMessage_Initialize(n, lTreeNode.Text)
                                Exit Sub
                            End If
                        ElseIf e <> 0 And n = 0 Then
                            n = FindByInitialText(lTreeNode.Parent.Parent.Text)
                            If e <> 0 And n <> 0 Then
                                lStatus.PrivateMessage_Initialize(n, lTreeNode.Text)
                                Exit Sub
                            End If
                        End If
                    End If
                    Dim s As Integer = Find(lTreeNode.Parent.Text)
                    e = lStatus.PrivateMessage_Find(s, lTreeNode.Text)
                    If e <> 0 Then
                        With lStatusObjects.sStatusObject(e)
                            If (Not .sPrivateMessages.pPrivateMessage(e).pVisible) Then
                                PrivateMessage_Visible(s, lTreeNode.Text) = True
                            Else
                                .sPrivateMessages.pPrivateMessage(e).pWindow.Visible = True
                                .sPrivateMessages.pPrivateMessage(e).pWindow.txtOutgoing.Focus()
                            End If
                        End With
                        Exit Sub
                    End If
                    e = lChannels.Find(Find(lTreeNode.Parent.Text), lTreeNode.Text)
                    If e <> 0 Then
                        If lChannels.Name(e).Length <> 0 Then
                            If lChannels.Visible(e) = False Then
                                lChannels.Visible(e) = True
                                With lChannels.GetObject(e)
                                    If .cTreeNode.ImageIndex <> 1 Then .cTreeNode.ImageIndex = 1
                                    If .cTreeNode.SelectedImageIndex <> 1 Then .cTreeNode.SelectedImageIndex = 1
                                    If .cWindowBarItem.ImageIndex <> 1 Then .cWindowBarItem.ImageIndex = 1
                                End With
                            Else
                                lChannels.Focus(e)
                                If lSettings.lIRC.iSettings.sAutoMaximize = True Then lChannels.Window(e).WindowState = FormWindowState.Maximized
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        Public Property Visible(ByVal index As Integer) As Boolean
            Get
                Try
                    With lStatus.lStatusObjects.sStatusObject(index)
                        Return .sVisible
                    End With
                Catch ex As Exception
                    Throw ex
                    Return Nothing
                End Try
            End Get
            Set(ByVal value As Boolean)
                Try
                    With lStatus.lStatusObjects.sStatusObject(index)
                        If (value = True And .sVisible = False) Then
                            If (.sTreeNodeStatus.ImageIndex <> 1) Then .sTreeNodeStatus.ImageIndex = 1
                            If (.sTreeNodeStatus.SelectedImageIndex <> 1) Then .sTreeNodeStatus.SelectedImageIndex = 1
                            If (.sWindowBarItem.ImageIndex <> 1) Then .sWindowBarItem.ImageIndex = 1
                        End If
                        .sVisible = value
                        .sWindow.Visible = value
                    End With
                Catch ex As Exception
                    Throw ex
                End Try
            End Set
        End Property
        Public Sub ProcessWelcomeMessage(ByVal lStatusIndex As Integer, ByVal l001 As String, ByVal l002 As String, ByVal l003 As String, ByVal l004 As String)
            Try
                AddText("-" & Environment.NewLine & l001 & Environment.NewLine & l002 & Environment.NewLine & l003 & Environment.NewLine & l004 & Environment.NewLine & "-", lStatusIndex)
                lProcessNumeric.lIrcNumericHelper.ResetMessages()
                lStatus.GetObject(lStatusIndex).sNickBot.Login()
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub ProcessWelcomeMessage(ByVal l001 As String, ByVal l002 As String, ByVal l003 As String, ByVal l004 As String)")
            End Try
        End Sub
#End Region
#Region "PRIVATE MESSAGES"
        Public Sub PrivateMessage_ToggleWindowState(ByVal _StatusIndex As Integer, ByVal _PrivateMessageIndex As Integer)
            Try
                If _PrivateMessageIndex <> 0 Then
                    With lStatusObjects.sStatusObject(_StatusIndex).sPrivateMessages.pPrivateMessage(_PrivateMessageIndex)
                        If (.pVisible = True) Then
                            If .pWindow.WindowState = FormWindowState.Normal = True Then
                                .pWindow.WindowState = FormWindowState.Minimized
                            ElseIf .pWindow.WindowState = FormWindowState.Maximized Then
                                .pWindow.WindowState = FormWindowState.Minimized
                            ElseIf .pWindow.WindowState = FormWindowState.Minimized Then
                                .pWindow.WindowState = FormWindowState.Normal
                            End If
                        Else
                            Dim b As Boolean = PrivateMessage_Visible(_StatusIndex, .pName)
                        End If
                    End With
                End If
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub PrivateMessage_ToggleWindowState(_StatusIndex As Integer, _PrivateMessageIndex As Integer)")
            End Try
        End Sub
        Public Function PrivateMessage_Find(ByVal _StatusIndex As Integer, ByVal _Name As String) As Integer
            Try
                Dim _Result As Integer = 0, _GetObject As Status.gStatus = lStatus.GetObject(_StatusIndex)
                If Len(_Name) <> 0 Then
                    For _PrivateMessageIndex As Integer = 1 To _GetObject.sPrivateMessages.pCount
                        With _GetObject.sPrivateMessages.pPrivateMessage(_PrivateMessageIndex)
                            If LCase(Trim(.pName)) = LCase(Trim(_Name)) Then
                                _Result = _PrivateMessageIndex
                                Exit For
                            End If
                        End With
                    Next _PrivateMessageIndex
                End If
                Return _Result
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Function FindPrivateMessageIndex(ByVal _StatusIndex As Integer, ByVal _Name As String) As Integer")
                Return Nothing
            End Try
        End Function
        Public Sub PrivateMessage_Initialize(ByVal _StatusIndex As Integer, ByVal _NickName As String)
            Try
                Dim _GetObject As Status.gStatus, _PrivateMessageIndex As Integer, _CreateToolStripItem As Boolean, _CreateTreeViewItem As Boolean
                If (_NickName.Length <> 0) Then
                    _PrivateMessageIndex = PrivateMessage_Find(_StatusIndex, _NickName)
                    If (_PrivateMessageIndex = 0) Then
                        _GetObject = lStatus.GetObject(_StatusIndex)
                        _PrivateMessageIndex = _GetObject.sPrivateMessages.pCount + 1
                        _GetObject.sPrivateMessages.pCount = _PrivateMessageIndex
                    End If
                    With lStatusObjects.sStatusObject(_StatusIndex).sPrivateMessages.pPrivateMessage(_PrivateMessageIndex)
                        _CreateTreeViewItem = True
                        If (lStatusObjects.sStatusObject(_StatusIndex).sTreeNode IsNot Nothing) Then
                            For Each _Node As TreeNode In lStatusObjects.sStatusObject(_StatusIndex).sTreeNode.Nodes
                                If (_Node.Tag IsNot Nothing) Then
                                    If (_Node.Text = _NickName And _Node.Tag.ToString = _StatusIndex.ToString) Then
                                        _CreateTreeViewItem = False
                                    End If
                                End If
                            Next _Node
                        End If
                        If (_CreateTreeViewItem = True) Then
                            If (lStatusObjects.sStatusObject(_StatusIndex).sTreeNode IsNot Nothing) Then
                                .pTreeNode = lStatusObjects.sStatusObject(_StatusIndex).sTreeNode.Nodes.Add(_NickName, _NickName, 3, 3)
                                .pTreeNode.Tag = _StatusIndex.ToString
                            End If

                        End If
                        .pTreeNodeVisible = True
                        .pVisible = True
                        .pName = _NickName
                        .pWindow = New frmNoticeWindow
                        .pWindow.FormType = MdiChildWindow.FormTypes.PrivateMessage
                        .pWindow.PrivateMessageNickName = _NickName
                        .pWindow.SetStatusIndex(_StatusIndex)
                        If (String.IsNullOrEmpty(.pHost)) Then
                            .pWindow.Text = .pName
                        Else
                            .pWindow.Text = .pName & " (" & .pHost & ")"
                        End If
                        .pWindow.txtOutgoing.Visible = True
                        .pWindow.TriggerResize()
                        .pWindow.Show()
                        'If (.pIncomingText IsNot Nothing) Then
                        'Dim msg As String = .pIncomingText.Replace("$message", "").Trim()
                        'If (Not String.IsNullOrEmpty(msg)) Then
                        'msg = msg.Replace("<12" & _NickName & "> $message" & vbLf, "")
                        'msg = msg.Replace("<12" & _NickName & "> $message", "")
                        'If (msg.Length <> 0) Then
                        '.pWindow.DoNoticeColor(msg)
                        'End If
                        'End If
                        'End If
                        _CreateToolStripItem = True
                        For Each _ToolStripItem As ToolStripItem In mdiMain.tspWindows.Items
                            If (_ToolStripItem.Text = .pName And _ToolStripItem.Tag.ToString = .pStatusIndex.ToString) Then
                                _CreateToolStripItem = False
                            End If
                        Next _ToolStripItem
                        If (_CreateToolStripItem = True) Then
                            .pWindowBarItem = mdiMain.AddWindowBar(.pName, gWindowBarImageTypes.wNotice)
                            .pWindowBarItem.Tag = Trim(_StatusIndex.ToString)
                        End If
                    End With
                End If
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub PrivateMessage_Initialize(ByVal _StatusIndex As Integer, ByVal _NickName As String)")
            End Try
        End Sub
        Public Sub PrivateMessage_Focus(ByVal statusIndex As Integer, ByVal privateMessageIndex As Integer)
            Try
                With lStatus.GetObject(statusIndex).sPrivateMessages.pPrivateMessage(privateMessageIndex)
                    .pWindow.txtOutgoing.Focus()
                End With
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        Public Sub PrivateMessage_Add(ByVal statusIndex As Integer, ByVal name As String, ByVal host As String, ByVal data As String, Optional ByVal forceAllow As Boolean = False)
            Dim autoAllow As Boolean, deny As Boolean, c As Boolean, privateMessageIndex As Integer, createToolStripItem As Boolean = True
            Try
                c = True
                If (Connected(statusIndex) = False) Then Exit Sub ' Exit if not connected
                For i As Integer = 1 To lStatusObjects.sStatusObject(statusIndex).sPrivateMessages.pCount
                    If (Not String.IsNullOrEmpty(lStatusObjects.sStatusObject(statusIndex).sPrivateMessages.pPrivateMessage(i).pName)) Then
                        If (lStatusObjects.sStatusObject(statusIndex).sPrivateMessages.pPrivateMessage(i).pName.ToLower().Trim() = name.ToLower().Trim()) Then
                            privateMessageIndex = i
                            Exit For
                        End If
                    End If
                Next i
                If (Not forceAllow) Then
                    If (Modules.IrcSettings.QuerySettings.Get().AutoDeny = IrcSettings.QueryPermission.EveryOne) Then ' Is the user on the auto deny list?
                        deny = True
                    ElseIf (Modules.IrcSettings.QuerySettings.Get().AutoDeny = IrcSettings.QueryPermission.List) Then
                        For i As Integer = 1 To Modules.IrcSettings.QuerySettings.Get().AutoDenyList.Count()
                            If (privateMessageIndex <> 0) Then
                                If (Not String.IsNullOrEmpty(lStatusObjects.sStatusObject(statusIndex).sPrivateMessages.pPrivateMessage(privateMessageIndex).pName) And Not String.IsNullOrEmpty(Modules.IrcSettings.QuerySettings.Get().AutoDenyList(i))) Then
                                    If (Modules.IrcSettings.QuerySettings.Get().AutoDenyList(i).ToLower() = lStatusObjects.sStatusObject(statusIndex).sPrivateMessages.pPrivateMessage(privateMessageIndex).pName.Trim().ToLower()) Then
                                        Exit Sub ' We found him, do nothing else.
                                    End If
                                End If
                            End If
                        Next i
                    End If
                    If (Modules.IrcSettings.QuerySettings.Get().AutoAllow = IrcSettings.QueryPermission.EveryOne) Then ' Is the user on the auto allow list?
                        autoAllow = True
                    ElseIf (Modules.IrcSettings.QuerySettings.Get().AutoAllow = IrcSettings.QueryPermission.List) Then
                        For i As Integer = 1 To Modules.IrcSettings.QuerySettings.Get().AutoAllowList.Count() - 1
                            If (privateMessageIndex <> 0) Then
                                If ((Not String.IsNullOrEmpty(Modules.IrcSettings.QuerySettings.Get().AutoAllowList(i))) And (Not String.IsNullOrEmpty(lStatusObjects.sStatusObject(statusIndex).sPrivateMessages.pPrivateMessage(privateMessageIndex).pName))) Then
                                    If (Modules.IrcSettings.QuerySettings.Get().AutoAllowList(i).Trim().ToLower() = lStatusObjects.sStatusObject(statusIndex).sPrivateMessages.pPrivateMessage(privateMessageIndex).pName.Trim().ToLower()) Then
                                        autoAllow = True
                                        Exit For
                                    End If
                                End If
                            End If
                        Next i
                    End If
                Else
                    autoAllow = True
                    deny = False
                End If
                If ((Not autoAllow) And (Modules.IrcSettings.QuerySettings.Get().EnableSpamFilter) And PrivateMessage_HasSpam(data)) Then Exit Sub ' If you're not auto allowing, if you have spam filter, check that data is spam free
                If ((Not autoAllow) And (deny)) Then Exit Sub ' He's not on the auto allow, and deny is true, quit here.
                If (privateMessageIndex = 0) Then
                    privateMessageIndex = (lStatusObjects.sStatusObject(statusIndex).sPrivateMessages.pCount + 1) ' Get the privateMessageIndex
                    lStatusObjects.sStatusObject(statusIndex).sPrivateMessages.pCount = privateMessageIndex ' Set the privateMessageIndex
                    With lStatusObjects.sStatusObject(statusIndex).sPrivateMessages.pPrivateMessage(privateMessageIndex)
                        .pFirstMessage = data
                        .pName = name
                        .pHost = host
                        .pStatusIndex = statusIndex
                        If (autoAllow Or (Not Modules.IrcSettings.QuerySettings.Get().PromptUser)) Then
                            .pTreeNodeVisible = True
                            .pTreeNode = lStatusObjects.sStatusObject(statusIndex).sTreeNode.Nodes.Add(.pName, .pName, 3, 3)
                            .pTreeNode.Tag = statusIndex.ToString()
                            For Each t As ToolStripItem In mdiMain.tspWindows.Items
                                If (t.Text = .pName And t.Tag.ToString = .pStatusIndex.ToString) Then
                                    createToolStripItem = False
                                End If
                            Next t
                            .pWindowBarItem = mdiMain.AddWindowBar(.pName, gWindowBarImageTypes.wNotice)
                            .pWindowBarItem.Tag = Trim(statusIndex.ToString)
                            If ((lSettings.lIRC.iSettings.sShowWindowsAutomatically = True) Or (forceAllow)) Then
                                .pWindow = New frmNoticeWindow()
                                .pWindow.FormType = MdiChildWindow.FormTypes.PrivateMessage
                                .pWindow.lMdiWindow.Form_Load(MdiChildWindow.FormTypes.PrivateMessage)
                                .pWindow.lMdiWindow.MeIndex = statusIndex
                                .pWindow.lMdiWindow.Form_Resize(.pWindow.txtIncoming, .pWindow.txtOutgoing, .pWindow)
                                .pWindow.SetStatusIndex(statusIndex)
                                .pWindow.TriggerResize()
                                .pWindow.PrivateMessageNickName = name
                                If (Not String.IsNullOrEmpty(.pHost)) Then
                                    .pWindow.Text = .pName & " (" & .pHost & ")"
                                Else
                                    .pWindow.Text = .pName
                                End If
                                .pVisible = True
                                .pWindow.Show()
                                If (lSettings.lIRC.iSettings.sAutoMaximize = True) Then .pWindow.WindowState = FormWindowState.Maximized
                                If (Not String.IsNullOrEmpty(data)) Then .pWindow.DoNoticeColor(lStrings.ReturnReplacedString(eStringTypes.sPRIVMSG, name, data))
                            End If
                        Else
                            mdiMain.tspQueryPrompt.Visible = True
                            mdiMain.lblQueryPrompt.Text = "Accept query from '" & .pName & "(" & .pHost & ")'?"
                            mdiMain.lblQueryPrompt.Tag = Trim(statusIndex.ToString) & ":" & Trim(privateMessageIndex.ToString) & ":" & data
                            Exit Sub
                        End If
                    End With
                Else
                    With lStatusObjects.sStatusObject(statusIndex).sPrivateMessages.pPrivateMessage(privateMessageIndex)
                        If (forceAllow) Then
                            .pName = name
                            .pHost = host
                            .pWindow = New frmNoticeWindow()
                            .pStatusIndex = statusIndex
                            .pWindow.FormType = MdiChildWindow.FormTypes.PrivateMessage
                            .pWindow.SetStatusIndex(statusIndex)
                            .pWindow.TriggerResize()
                            .pWindow.PrivateMessageNickName = name
                            .pTreeNodeVisible = True
                            .pTreeNode = lStatusObjects.sStatusObject(statusIndex).sTreeNode.Nodes.Add(.pName, .pName, 3, 3)
                            .pTreeNode.Tag = statusIndex.ToString()
                            For Each t As ToolStripItem In mdiMain.tspWindows.Items
                                If (t.Text = .pName And t.Tag.ToString = .pStatusIndex.ToString) Then
                                    createToolStripItem = False
                                End If
                            Next t
                            .pWindowBarItem = mdiMain.AddWindowBar(.pName, gWindowBarImageTypes.wNotice)
                            .pWindowBarItem.Tag = Trim(statusIndex.ToString)
                            .pWindow.Text = .pName & " (" & .pHost & ")"
                            .pVisible = True
                            .pWindow.Show()
                            .pWindow.lMdiWindow.Form_Load(MdiChildWindow.FormTypes.PrivateMessage)
                            .pWindow.lMdiWindow.MeIndex = statusIndex
                            .pWindow.lMdiWindow.Form_Resize(.pWindow.txtIncoming, .pWindow.txtOutgoing, .pWindow)
                            If (lSettings.lIRC.iSettings.sAutoMaximize = True) Then .pWindow.WindowState = FormWindowState.Maximized
                        End If
                        If (.pVisible) Then
                            If (Not String.IsNullOrEmpty(data)) Then .pWindow.DoNoticeColor(lStrings.ReturnReplacedString(eStringTypes.sPRIVMSG, name, data))
                        End If
                    End With
                End If
                With lStatusObjects.sStatusObject(statusIndex).sPrivateMessages.pPrivateMessage(privateMessageIndex)
                    If (.pTreeNodeVisible) Then
                        If (Not forceAllow) Then
                            If (Not .pVisible) Then
                                If (.pTreeNode.ImageIndex <> 6) Then .pTreeNode.ImageIndex = 9
                                If (.pTreeNode.SelectedImageIndex <> 6) Then .pTreeNode.SelectedImageIndex = 9
                                If (.pWindowBarItem IsNot Nothing) Then
                                    If (.pWindowBarItem.ImageIndex <> 6) Then .pWindowBarItem.ImageIndex = 9
                                End If
                            End If
                        Else
                            If (.pTreeNode.ImageIndex <> 0) Then .pTreeNode.ImageIndex = 0
                            If (.pTreeNode.SelectedImageIndex <> 0) Then .pTreeNode.SelectedImageIndex = 0
                            If (.pWindowBarItem IsNot Nothing) Then
                                If (.pWindowBarItem.ImageIndex <> 0) Then .pWindowBarItem.ImageIndex = 0
                            End If
                        End If
                    End If
                End With
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        Public Sub PrivateMessage_SetListBox(ByVal _StatusIndex As Integer, ByVal _ListBox As ListBox)
            Try
                With lStatus.GetObject(_StatusIndex)
                    For _PrivateMessageIndex As Integer = 1 To .sPrivateMessages.pCount
                        _ListBox.Items.Add(.sPrivateMessages.pPrivateMessage(_PrivateMessageIndex).pName)
                    Next _PrivateMessageIndex
                End With
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub SetListBoxToPrivateMessages(ByVal lStatusIndex As Integer, ByVal lListBox As ListBox)")
            End Try
        End Sub
        Public Function PrivateMessage_HasSpam(ByVal lData As String) As Boolean
            Try
                Dim _Result As Boolean = False
                For _SpamPhraseIndex As Integer = 1 To Modules.IrcSettings.QuerySettings.Get().SpamPhrases.Count
                    If InStr(LCase(Modules.IrcSettings.QuerySettings.Get().SpamPhrases(_SpamPhraseIndex)), LCase(lData)) <> 0 Then
                        _Result = True
                        Exit For
                    End If
                Next _SpamPhraseIndex
                Return _Result
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Function PrivateMessages_HasSpam(ByVal lData As String) As Boolean")
                Return Nothing
            End Try
        End Function
        Public Property PrivateMessage_Visible(ByVal _StatusIndex As Integer, ByVal _Name As String) As Boolean
            Get
                Try
                    Dim _PrivateMessageIndex As Integer = PrivateMessage_Find(_StatusIndex, _Name)
                    With lStatusObjects.sStatusObject(_StatusIndex).sPrivateMessages.pPrivateMessage(_PrivateMessageIndex)
                        Return .pVisible
                    End With
                Catch ex As Exception
                    Throw ex
                    Return Nothing
                End Try
            End Get
            Set(ByVal _Visible As Boolean)
                Try
                    Dim _PrivateMessageIndex As Integer = PrivateMessage_Find(_StatusIndex, _Name)
                    With lStatusObjects.sStatusObject(_StatusIndex).sPrivateMessages.pPrivateMessage(_PrivateMessageIndex)
                        If (.pWindow Is Nothing) Then
                            .pWindow = New frmNoticeWindow()
                            .pWindow.FormType = MdiChildWindow.FormTypes.PrivateMessage
                            .pWindow.SetStatusIndex(_StatusIndex)
                            .pWindow.TriggerResize()
                            .pWindow.PrivateMessageNickName = _Name
                            If (Not String.IsNullOrEmpty(.pHost)) Then
                                .pWindow.Text = .pName & " (" & .pHost & ")"
                            End If
                            .pVisible = True
                            .pWindow.Show()
                            If (Not String.IsNullOrEmpty(.pFirstMessage)) Then .pWindow.DoNoticeColor(lStrings.ReturnReplacedString(eStringTypes.sPRIVMSG, _Name, .pFirstMessage))
                            .pFirstMessage = ""
                            .pWindow.lMdiWindow.Form_Load(MdiChildWindow.FormTypes.PrivateMessage)
                            .pWindow.lMdiWindow.MeIndex = _StatusIndex
                            .pWindow.lMdiWindow.Form_Resize(.pWindow.txtIncoming, .pWindow.txtOutgoing, .pWindow)
                        End If
                        .pWindow.Visible = _Visible
                        .pVisible = _Visible
                        If (_Visible) Then
                            If .pTreeNode.ImageIndex <> 1 Then .pTreeNode.ImageIndex = 1
                            If .pTreeNode.SelectedImageIndex <> 1 Then .pTreeNode.SelectedImageIndex = 1
                            If .pWindowBarItem.ImageIndex <> 1 Then .pWindowBarItem.ImageIndex = 1
                        End If
                    End With
                Catch ex As Exception
                    Throw ex 'ProcessError(ex.Message, "Public Property PrivateMessage_Visible(_StatusIndex As Integer, _Name As String) As Boolean")
                End Try
            End Set
        End Property
        Public Sub PrivateMessage_User(ByVal _StatusIndex As Integer, ByVal _UserName As String, ByVal _Data As String)
            Try
                With lStatusObjects.sStatusObject(_StatusIndex)
                    If _StatusIndex <> 0 Then
                        SendSocket(_StatusIndex, "PRIVMSG " & _UserName & " :" & _Data)
                        AddText(">" & _UserName & "< login", _StatusIndex)
                    End If
                End With
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub PrivateMessage_User(ByVal _StatusIndex As Integer, ByVal _UserName As String, ByVal _Data As String)")
            End Try
        End Sub
#End Region
#Region "MOTD"
        Public Property Motd_Open(ByVal lIndex As Integer) As Boolean
            Get
                Try
                    Return lStatusObjects.sStatusObject(lIndex).sMotdWindow.mVisible
                Catch ex As Exception
                    Throw ex 'ProcessError(ex.Message, "Public Property MotdClosed(ByVal lIndex As Integer) As Boolean")
                    Return Nothing
                End Try
            End Get
            Set(ByVal lValue As Boolean)
                Try
                    lStatusObjects.sStatusObject(lIndex).sMotdWindow.mVisible = lValue
                Catch ex As Exception
                    Throw ex
                End Try
            End Set
        End Property
        Public Sub Motd_AddText(ByVal lIndex As Integer, ByVal lData As String)
            Try
                If lSettings.lIRC.iSettings.sMOTDInOwnWindow = True Then
                    If Len(lData) <> 0 Then
                        With lStatusObjects.sStatusObject(lIndex)
                            If .sMotdWindow.mTreeNodeVisible = False Then
                                If .sTreeNodeVisible = True Then
                                    .sMotdWindow.mTreeNode = .sTreeNode.Nodes.Add("Motd", "Motd", 3, 3)
                                    .sMotdWindow.mTreeNodeVisible = True
                                End If
                            End If
                            If .sMotdWindow.mVisible = False Then
                                If lSettings.lIRC.iSettings.sShowWindowsAutomatically = True Then
                                    .sMotdWindow.mWindow = New frmNoticeWindow
                                    .sMotdWindow.mWindow.Show()
                                    .sMotdWindow.mWindow.SetStatusIndex(lIndex)
                                    .sMotdWindow.mVisible = True
                                    .sMotdWindow.mWindow.Text = StatusServerName(.sWindow.mdiChildWindow.MeIndex) & " - MOTD"
                                    .sMotdWindow.mWindow.FormType = MdiChildWindow.FormTypes.MotdWindow
                                Else
                                    .sMotdWindow.mData = lData & Environment.NewLine & .sMotdWindow.mData
                                    If .sMotdWindow.mTreeNode.ImageIndex <> 6 Then .sMotdWindow.mTreeNode.ImageIndex = 6
                                    If .sMotdWindow.mTreeNode.SelectedImageIndex <> 6 Then .sMotdWindow.mTreeNode.SelectedImageIndex = 6
                                End If
                            Else
                                .sMotdWindow.mWindow.DoNoticeColor(lData)
                            End If
                        End With
                    End If
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
#End Region
#Region "STATUS CONNECTION"
        Public Sub ToggleConnection(ByVal _StatusIndex As Integer)
            Try
                With lStatusObjects.sStatusObject(_StatusIndex)
                    If Connected(_StatusIndex) = True And .sConnecting = False Then
                        Quit(_StatusIndex)
                    ElseIf Connected(_StatusIndex) = True And .sConnecting = True Then
                        CloseStatusConnection(_StatusIndex, True)
                    Else
                        Connect(_StatusIndex)
                    End If
                End With
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        Public Function Connect(ByVal _StatusIndex As Integer) As Boolean
            Dim result As Boolean = True
            Try
                Dim mbox As MsgBoxResult
                If (String.IsNullOrEmpty(lSettings.lIRC.iEMail)) Then
                    If (lSettings.lIRC.iSettings.sPrompts = True) Then MsgBox("Your e-mail has not been set! To configure, click Customize, then click User, then click User Settings.", MsgBoxStyle.Critical)
                    Return False
                End If
                If (String.IsNullOrEmpty(lSettings.lIRC.iNicks.nNick(lSettings.lIRC.iNicks.nIndex).nNick)) Then
                    If lSettings.lIRC.iSettings.sPrompts = True Then MsgBox("Your nickname has not been set! To configure, click Customize, then click User.", MsgBoxStyle.Critical)
                    Return False
                End If
                If (String.IsNullOrEmpty(lSettings.lIRC.iRealName)) Then
                    If lSettings.lIRC.iSettings.sPrompts = True Then MsgBox("Your real name has not been set! To configure, click Customize, then click User, then click User Settings.", MsgBoxStyle.Critical)
                    Return False
                End If
                With lStatusObjects.sStatusObject(_StatusIndex)
                    If (String.IsNullOrEmpty(NickName(_StatusIndex))) Then
                        MsgBox("You have not chosen a nickname, unable to connect.", MsgBoxStyle.Critical)
                        Return False
                    End If
                    If (Connected(_StatusIndex)) Then
                        If (lSettings.lIRC.iSettings.sPrompts) Then
                            mbox = MsgBox("You are currently connected, would you like to disconnect?", MsgBoxStyle.YesNoCancel Or MsgBoxStyle.Question)
                        Else
                            mbox = MsgBoxResult.Yes
                        End If
                        Select Case mbox
                            Case MsgBoxResult.Yes
                                CloseStatusConnection(_StatusIndex, True)
                            Case MsgBoxResult.No
                                Return False
                            Case MsgBoxResult.Cancel
                                Return False
                        End Select
                    End If
                    If (.sConnecting = True) Then
                        If (lSettings.lIRC.iSettings.sPrompts) Then
                            mbox = MsgBox("You are currently connecting, would you like to disconnect?", MsgBoxStyle.YesNoCancel Or MsgBoxStyle.Question)
                        Else
                            mbox = MsgBoxResult.Yes
                        End If
                        Select Case mbox
                            Case MsgBoxResult.Yes
                                CloseStatusConnection(_StatusIndex, True)
                            Case MsgBoxResult.No
                                Return False
                            Case MsgBoxResult.Cancel
                                Return False
                        End Select
                    End If
                    If (_StatusIndex <> 0 And .sPrimitives.sRemoteIP.Length() <> 0 And .sPrimitives.sRemotePort <> 0) Then
                        lSettings.AddToRecientServerList(lSettings.FindServerIndexByIp(.sPrimitives.sRemoteIP))
                        lSettings.SaveRecientServers()
                        .sConnecting = True
                        .sSocket = New StatusSocket()
                        .sSocket.NewSocket(_StatusIndex, .sWindow)
                        .sSocket.ConnectSocket(.sPrimitives.sRemoteIP, .sPrimitives.sRemotePort)
                        .sWindow.Visible = True
                        lProcessNumeric.lIrcNumericHelper.ResetMessages()
                        If (lSettings.lIRC.iSettings.sExtendedMessages = True) Then lStrings.ProcessReplaceString(_StatusIndex, eStringTypes.sATTEMPTING_CONNECTION, .sPrimitives.sRemoteIP, Convert.ToString(.sPrimitives.sRemotePort).Trim())
                        result = True
                    Else
                        result = False
                        If (lSettings.lIRC.iSettings.sExtendedMessages = True) Then MsgBox("Unable to connect, not enough parameters!", MsgBoxStyle.Information)
                    End If
                    If Err.Number <> 0 Then lStrings.ProcessReplaceString(_StatusIndex, eStringTypes.sCONNECTION_DENIED)
                End With
                Return result
            Catch ex As Exception
                Throw ex
                Return Nothing
            End Try
        End Function
        Public Function Disconnect(ByVal lIndex As Integer) As Boolean
            Try
                Dim i As Integer, result As Boolean = True
                If (lIndex <> 0) Then
                    With lStatusObjects.sStatusObject(lIndex)
                        If .sMotdWindow.mTreeNodeVisible = True Then
                            .sMotdWindow.mTreeNodeVisible = False
                            .sMotdWindow.mTreeNode.Remove()
                        End If
                        lChannelLists.HideTreeNode(lChannelLists.ReturnStatusIndex(lIndex))
                        If .sNoticesWindow.nTreeNodeVisible = True Then
                            .sNoticesWindow.nTreeNodeVisible = False
                            .sNoticesWindow.nTreeNode.Remove()
                        End If
                        If .sNotifyItems.nTreeNodeVisible = True Then
                            .sNotifyItems.nTreeNodeVisible = False
                            .sNotifyItems.nTreeNode.Remove()
                        End If
                        If .sRaw.rTreeNodeVisible = True Then
                            .sRaw.rTreeNodeVisible = False
                            .sRaw.rTreeNode.Remove()
                        End If
                        If .sUnknowns.uTreeNodeVisible = True Then
                            .sUnknowns.uTreeNodeVisible = False
                            .sUnknowns.uTreeNode.Remove()
                        End If
                        lChannelLists.Close(lChannelLists.ReturnChannelListIndex(lIndex))
                        If .sMotdWindow.mVisible = True Then .sMotdWindow.mWindow.Close()
                        If .sNoticesWindow.nVisible = True Then .sNoticesWindow.nWindow.Close()
                        For i = 1 To .sPrivateMessages.pCount
                            If (.sPrivateMessages.pPrivateMessage(i).pVisible) Then .sPrivateMessages.pPrivateMessage(i).pWindow.Close()
                        Next i
                        If .sRaw.rVisible = True Then .sRaw.rRawWindow.Close()
                        If .sServerLinks.sVisible = True Then .sServerLinks.sWindow.Close()
                        If .sUnknowns.uVisible = True Then .sUnknowns.uWindow.Close()
                        .sWindowBarItem.Visible = False
                    End With
                    lChannels.ClearAll(lIndex)
                End If
                Return result
            Catch ex As Exception
                Throw ex
                Return Nothing
            End Try
        End Function
        Public Sub Connect_Specify(ByVal _Server As String, ByVal _Port As Long)
            Try
                Dim i As Integer, _AddServer As frmAddServer
                If Len(_Server) <> 0 And _Port <> 0 Then
                    i = ActiveIndex()
                    If i <> 0 Then
                        SetRemoteSettings(i, _Server, _Port)
                        Connect(i)
                    Else
                        _AddServer = New frmAddServer
                        _AddServer.addServer.lConnectSetting = True
                        _AddServer.txtIP.Text = _Server
                        _AddServer.txtPort.Text = _Port.ToString().Trim()
                        _AddServer.Show()
                    End If
                End If
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub ConnectToGivenIRC(ByVal _Server As String, ByVal _Port As Long)")
            End Try
        End Sub
        Public Sub ConnectEvent(ByVal _Index As Integer)
            Try
                Dim msg As String
                With lStatusObjects.sStatusObject(_Index)
                    .sConnecting = False
                    If lSettings.lIRC.iSettings.sExtendedMessages = True Then lStrings.ProcessReplaceString(_Index, eStringTypes.sCONNECTION_ESTABLISHED)
                    If Len(lSettings.lIRC.iPass) <> 0 Then
                        If lSettings.lIRC.iSettings.sExtendedMessages = True Then lStrings.ProcessReplaceString(_Index, eStringTypes.sSENDING_PASSWORD)
                        SendSocket(_Index, "PASS " & Pass(_Index))
                    Else
                        If lSettings.lIRC.iSettings.sExtendedMessages = True Then lStrings.ProcessReplaceString(_Index, eStringTypes.sNOT_SENDING_PASSWORD)
                    End If
                    If Len(NickName(_Index)) <> 0 Then
                        lStrings.ProcessReplaceString(_Index, eStringTypes.sSENDING_NICKNAME)
                        SendSocket(_Index, "NICK " & NickName(_Index))
                        If Len(Email(_Index)) <> 0 Then
                            msg = TextHelper.LeftRight(Email(_Index), 0, InStr(Email(_Index), "@"))
                            If Len(msg) <> 0 Then
                                If lSettings.lIRC.iSettings.sExtendedMessages = True Then lStrings.ProcessReplaceString(_Index, eStringTypes.sSENDING_LOGON_INFORMATION)
                                SendSocket(_Index, "USER " & Split(RealName(_Index), " ")(0) & " 0 * :" & RealName(_Index))
                                SetStatusIconConnected(_Index)
                            End If
                        Else
                            If lSettings.ShowPrompts() = True Then MsgBox("Unable to proceed, no E-Mail address is set", MsgBoxStyle.Critical)
                        End If
                    Else
                        CloseStatusConnection(_Index, True)
                        If lSettings.ShowPrompts() = True Then MsgBox("Unable to proceed, no nickname is set", MsgBoxStyle.Critical)
                    End If
                End With
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub ConnectEvent()")
            End Try
        End Sub
        Public Sub CloseStatusConnection(ByVal _StatusIndex As Integer, ByVal _CloseSocket As Boolean)
            Try
                With lStatusObjects.sStatusObject(_StatusIndex)
                    lStrings.ProcessReplaceString(_StatusIndex, eStringTypes.sCONNECTION_CLOSED)
                    SetStatusIconDisconnected(_StatusIndex)
                    Disconnect(_StatusIndex)
                    If .sConnecting = True Or Connected(_StatusIndex) = True And _CloseSocket = True Then
                        CloseSocket(_StatusIndex)
                        NewStatusSocket(_StatusIndex)
                    End If
                    .sConnecting = False
                    If lSettings.lIRC.iSettings.sCloseWindowOnDisconnect = True Then
                        If lStatusObjects.sStatusObject(_StatusIndex).sVisible = True Then
                            lStatusObjects.sStatusObject(_StatusIndex).sWindow.Close()
                            lStatusObjects.sStatusObject(_StatusIndex).sVisible = False
                        End If
                    End If
                End With
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub CloseStatusConnection(ByVal _StatusIndex As Integer, ByVal _CloseSocket As Boolean)")
            End Try
        End Sub
        Public ReadOnly Property StatusSocketLocalPort(ByVal _Index As Integer) As Long
            Get
                Try
                    If (Not lStatusObjects.sStatusObject(_Index).sSocket Is Nothing) Then
                        Return lStatusObjects.sStatusObject(_Index).sSocket.ReturnLocalPort
                    End If
                    Return 0
                Catch ex As Exception
                    Throw ex
                    Return Nothing
                End Try
            End Get
        End Property
        Public Sub NewStatusSocket(ByVal _Index As Integer)
            Try
                With lStatusObjects.sStatusObject(_Index)
                    .sSocket = New StatusSocket
                    .sSocket.NewSocket(_Index, lStatusObjects.sStatusObject(_Index).sWindow)
                End With
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub NewStatusSocket(ByVal lIndex As Integer)")
            End Try
        End Sub
        Public Sub SendSocket(ByVal _StatusIndex As Integer, ByVal _Data As String)
            Try
                With lStatusObjects.sStatusObject(_StatusIndex)
                    If lSettings.lIRC.iSettings.sShowRawWindow = True Then Raw_AddText(_StatusIndex, _Data, False)
                    If Connected(_StatusIndex) = True Then
                        .sSocket.SendSocket(_Data)
                    End If
                End With
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub SendSocket(ByVal _Index As Integer, ByVal _Data As String)")
            End Try
        End Sub
        Public Sub CloseSocket(ByVal _StatusIndex As Integer)
            Try
                With lStatusObjects.sStatusObject(_StatusIndex)
                    If (Connected(_StatusIndex) = True) Then
                        .sSocket.CloseSocket()
                    End If
                End With
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub CloseSocket(ByVal lIndex As Integer)")
            End Try
        End Sub
        Public Sub SetStatusConnecting(ByVal lIndex As Integer, ByVal lValue As Boolean)
            Try
                With lStatusObjects.sStatusObject(lIndex)
                    .sConnecting = lValue
                    Select Case lValue
                        Case True
                            '.sWindow.cmd_Connect.Enabled = False
                            '.sWindow.cmd_Disconnect.Enabled = True
                        Case False
                            '.sWindow.cmd_Connect.Enabled = True
                            '.sWindow.cmd_Disconnect.Enabled = False
                    End Select
                End With
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub SetStatusConnecting(ByVal lIndex As Integer, ByVal lValue As Boolean)")
            End Try
        End Sub
        Public Function ReturnRemoteIP(ByVal lIndex As Integer) As String
            Try
                With lStatusObjects.sStatusObject(lIndex)
                    ReturnRemoteIP = .sPrimitives.sRemoteIP
                End With
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Function ReturnRemoteIP(ByVal lIndex As Integer) As String")
                Return Nothing
            End Try
        End Function
        Public Function ReturnRemotePort(ByVal lIndex As Integer) As Long
            Dim result As Long
            Try
                With lStatusObjects.sStatusObject(lIndex)
                    result = .sPrimitives.sRemotePort
                End With
                Return result
            Catch ex As Exception
                Throw ex
                Return Nothing
            End Try
        End Function
        Public Sub SetRemoteSettings(ByVal lIndex As Integer, ByVal lRemoteIP As String, ByVal lRemotePort As Long)
            With lStatusObjects.sStatusObject(lIndex)
                .sPrimitives.sRemoteIP = lRemoteIP
                .sPrimitives.sRemotePort = lRemotePort
            End With
        End Sub
        Public Function ReturnStatusConnecting(ByVal lIndex As Integer) As Boolean
            With lStatusObjects.sStatusObject(lIndex)
                ReturnStatusConnecting = .sConnecting
            End With
        End Function
        Public Sub SetStatusIconConnected(ByVal lStatusIndex As Integer)
            With lStatusObjects.sStatusObject(lStatusIndex)
                If .sTreeNode.ImageIndex <> 7 Then .sTreeNode.ImageIndex = 7
                If .sTreeNode.SelectedImageIndex <> 7 Then .sTreeNode.SelectedImageIndex = 7
            End With
        End Sub
        Public Sub SetStatusIconDisconnected(ByVal lStatusIndex As Integer)
            With lStatusObjects.sStatusObject(lStatusIndex)
                If .sTreeNode.ImageIndex <> 2 Then .sTreeNode.ImageIndex = 2
                If .sTreeNode.SelectedImageIndex <> 2 Then .sTreeNode.SelectedImageIndex = 2
            End With
        End Sub
        Public Sub DoStatusSocket(ByVal lIndex As Integer, ByVal lData As String)
            If lIndex <> 0 And Len(lData) <> 0 Then
                With lStatusObjects.sStatusObject(lIndex).sWindow
                    If Connected(lIndex) = True Then SendSocket(lIndex, lData)
                End With
            End If
        End Sub
#End Region
#Region "NOTICES"
        Public Sub SetNoticeData(ByVal lIndex As Integer, ByVal lData As String)
            If lIndex <> 0 Then
                With lStatusObjects.sStatusObject(lIndex)
                    .sNoticesWindow.nData = lData
                End With
            End If
        End Sub
        Public Sub Notices_Add(ByVal lIndex As Integer, ByVal lData As String, Optional ByVal lData2 As String = "")
            Try
                If lSettings.lIRC.iSettings.sNoticesInOwnWindow = True Then
                    If Len(lData) <> 0 Then
                        With lStatusObjects.sStatusObject(lIndex)
                            If .sNoticesWindow.nTreeNodeVisible = False Then
                                If .sTreeNodeVisible = True Then
                                    .sNoticesWindow.nTreeNode = .sTreeNode.Nodes.Add("Notices", "Notices", 3, 3)
                                    .sNoticesWindow.nTreeNodeVisible = True
                                End If
                            End If
                            .sNoticesWindow.nData = lData & Environment.NewLine & "�" & Environment.NewLine & .sNoticesWindow.nData
                            If .sNoticesWindow.nVisible = False Then
                                If lSettings.lIRC.iSettings.sShowWindowsAutomatically = True Then
                                    .sNoticesWindow.nVisible = True
                                    .sNoticesWindow.nWindow = New frmNoticeWindow
                                    .sNoticesWindow.nWindow.Show()
                                    .sNoticesWindow.nWindow.SetStatusIndex(lIndex)
                                    .sNoticesWindow.nWindow.FormType = MdiChildWindow.FormTypes.PrivateMessage
                                    .sNoticesWindow.nWindow.Text = StatusServerName(.sWindow.mdiChildWindow.MeIndex) & " - Notices"
                                    .sNoticesWindow.nWindow.DoNoticeColor(.sNoticesWindow.nData)
                                Else
                                    If .sNoticesWindow.nTreeNode.ImageIndex <> 6 Then .sNoticesWindow.nTreeNode.ImageIndex = 6
                                    If .sNoticesWindow.nTreeNode.SelectedImageIndex <> 6 Then .sNoticesWindow.nTreeNode.SelectedImageIndex = 6
                                End If
                            Else
                                .sNoticesWindow.nWindow.DoNoticeColor(lData & "�" & Environment.NewLine)
                            End If
                        End With
                    End If
                Else
                    If (lData2.Length <> 0) Then
                        lStrings.ProcessReplaceString(lIndex, eStringTypes.sNOTICE, lData, lData2)
                    Else
                        lStrings.ProcessReplaceString(lIndex, eStringTypes.sNOTICE, lData)
                    End If
                End If
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub AddToNotices(ByVal lIndex As Integer, ByVal lData As String)")
            End Try
        End Sub
        Public Sub Form_Closing(Optional ByRef _Form As Form = Nothing, Optional ByRef _MeIndex As Integer = 0, Optional ByRef e As System.Windows.Forms.FormClosingEventArgs = Nothing)
            Try
                Dim b As Boolean
                lSettings.lIRC.iSettings.sWindowSizes.lStatus.wWidth = _Form.Width
                lSettings.lIRC.iSettings.sWindowSizes.lStatus.wHeight = _Form.Height
                If _Form.WindowState = FormWindowState.Minimized Then _Form.WindowState = FormWindowState.Normal
                lSettings.SaveWindowSizes()
                Select Case LCase(e.CloseReason.ToString)
                    Case "mdiformclosing"
                        b = False
                    Case Else
                        b = True
                End Select
                If b = False Then Exit Sub
                _Form.Visible = False
                lStatusObjects.sStatusObject(_MeIndex).sVisible = False
                e.Cancel = True
                Exit Sub
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub Form_Closing(_Form As Form)")
            End Try
        End Sub
        Public Property Notice_Visible(ByVal _StatusIndex As Integer) As Boolean
            Get
                Try
                    With lStatusObjects.sStatusObject(_StatusIndex)
                        Return .sNoticesWindow.nVisible
                    End With
                Catch ex As Exception
                    Throw ex 'ProcessError(ex.Message, "Public Property Notice_Visible(_NoticeIndex As Integer) As Boolean")
                    Return Nothing
                End Try
            End Get
            Set(ByVal _Visible As Boolean)
                Try
                    With lStatusObjects.sStatusObject(_StatusIndex)
                        .sNoticesWindow.nVisible = _Visible
                        If _Visible = False Then
                            .sNoticesWindow.nWindow = Nothing
                        End If
                    End With
                Catch ex As Exception
                    Throw ex 'ProcessError(ex.Message, "Public Property Notice_Visible(_NoticeIndex As Integer) As Boolean")
                End Try
            End Set
        End Property
        Public Sub AddToNotifyList(ByVal lStatusIndex As Integer, ByVal lNickName As String)
            Try
                If Len(lNickName) <> 0 Then
                    With lStatusObjects.sStatusObject(lStatusIndex)
                        If .sNotifyItems.nTreeNodeVisible = False Then
                            .sNotifyItems.nTreeNodeVisible = True
                            .sNotifyItems.nTreeNode = .sTreeNode.Nodes.Add("Notify", "Notify", 3, 3)
                        End If
                        .sNotifyItems.nTreeNode.Nodes.Add(lNickName, lNickName, 3, 3)
                        .sNotifyItems.nTreeNode.Expand()
                    End With
                End If
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub AddToNotifyList(ByVal lStatusIndex As Integer, ByVal lNickName As String)")
            End Try
        End Sub

#End Region
#Region "RAW"
        Public Sub Raw_AddText(ByVal lIndex As Integer, ByVal lData As String, ByVal lInData As Boolean)
            'On Error Resume Next
            If lIndex <> 0 Then
                If lSettings.lIRC.iSettings.sShowRawWindow = False Then Exit Sub
                If lInData = True Then
                    With lStatusObjects.sStatusObject(lIndex).sRaw
                        If .rTreeNodeVisible = False Then
                            .rTreeNode = lStatusObjects.sStatusObject(lIndex).sTreeNode.Nodes.Add("Raw", "Raw", 4, 4)
                            .rTreeNodeVisible = True
                        End If
                        If .rVisible = False Then
                            If lSettings.lIRC.iSettings.sShowWindowsAutomatically = True Then
                                .rRawWindow = New frmRaw
                                'animate.Animate(.rRawWindow, animate.Effect.Center, 200, 1)
                                .rRawWindow.Show()
                                .rRawWindow.SetStatusIndex(lIndex)
                                .rRawWindow.txtInData.Text = .rInData
                                .rRawWindow.txtOutData.Text = .rOutData
                                .rRawWindow.Text = "nexIRC - Raw " & lStatusObjects.sStatusObject(lIndex).sDescription
                                .rVisible = True
                            Else
                                .rInData = .rInData & Environment.NewLine & lData
                                If .rTreeNode.ImageIndex <> 5 Then .rTreeNode.ImageIndex = 5
                                If .rTreeNode.SelectedImageIndex <> 5 Then .rTreeNode.SelectedImageIndex = 5
                            End If
                        Else
                            lStrings.DoText(lData, .rRawWindow.txtInData)
                        End If
                    End With
                Else
                    With lStatusObjects.sStatusObject(lIndex).sRaw
                        If .rTreeNodeVisible = False Then
                            .rTreeNodeVisible = True
                            .rTreeNode = lStatusObjects.sStatusObject(lIndex).sTreeNode.Nodes.Add("Raw", "Raw", 4, 4)
                        End If
                        If .rVisible = False Then
                            If lSettings.lIRC.iSettings.sShowWindowsAutomatically = True Then
                                .rRawWindow = New frmRaw
                                'animate.Animate(.rRawWindow, animate.Effect.Center, 200, 1)
                                .rRawWindow.Show()
                                .rRawWindow.txtInData.Text = .rInData
                                .rRawWindow.txtOutData.Text = .rOutData
                                .rRawWindow.SetStatusIndex(lIndex)
                                .rRawWindow.Text = "nexIRC - Raw " & lStatusObjects.sStatusObject(lIndex).sDescription
                                .rVisible = True
                            Else
                                .rOutData = .rOutData & Environment.NewLine & lData
                                If .rTreeNode.ImageIndex <> 5 Then .rTreeNode.ImageIndex = 5
                                If .rTreeNode.SelectedImageIndex <> 5 Then .rTreeNode.SelectedImageIndex = 5
                            End If
                        Else
                            lStrings.DoText(lData, .rRawWindow.txtOutData)
                        End If
                    End With
                End If
            End If
            'If Err.Number <> 0 Then Throw ex 'ProcessError(ex.Message, "Public Function ReturnChannelCount() As Integer")
        End Sub
        Public Sub SetRawData(ByVal lIndex As Integer, ByVal lInData As String, ByVal lOutData As String)
            'On Error Resume Next
            With lStatusObjects.sStatusObject(lIndex).sRaw
                .rInData = lInData
                .rOutData = lOutData
            End With
            'If Err.Number <> 0 Then Throw ex 'ProcessError(ex.Message, "Public Sub SetRawData(ByVal lInData As String, ByVal lOutData As String)")
        End Sub
        Public Sub SetRawWindowClosed(ByVal lIndex As Integer)
            'On Error Resume Next
            With lStatusObjects.sStatusObject(lIndex)
                .sRaw.rVisible = False
                .sRaw.rRawWindow = Nothing
            End With
            'If Err.Number <> 0 Then Throw ex 'ProcessError(ex.Message, "Public Sub SetRawWindowClosed(ByVal lIndex As Integer)")
        End Sub
#End Region
#Region "SERVER LINKS"
        Public Sub AddToServerLinks(ByVal lIndex As Integer, ByVal lServerIP As String, ByVal lServerPort As String)
            'On Error Resume Next
            Dim i As Integer
            If Len(lServerIP) <> 0 And Len(lServerPort) <> 0 Then
                With lStatusObjects.sStatusObject(lIndex)
                    If .sServerLinks.sTreeNodeVisible = False Then
                        .sTreeNode.Nodes.Add("Links", "Links", 3, 3)
                        .sServerLinks.sTreeNodeVisible = True
                    End If
                    If .sServerLinks.sVisible = False Then
                        If lSettings.lIRC.iSettings.sShowWindowsAutomatically = True Then
                            i = NetworkIndex(.sWindow.mdiChildWindow.MeIndex)
                            .sServerLinks.sVisible = True
                            .sServerLinks.sWindow = New frmServerLinks
                            'animate.Animate(.sServerLinks.sWindow, animate.Effect.Center, 200, 1)
                            .sServerLinks.sWindow.Show()
                            .sServerLinks.sWindow.lServerLinksUI.SetStatusIndex(lIndex)
                            .sServerLinks.sWindow.lServerLinksUI.SetNetworkIndex(i, .sServerLinks.sWindow.cboNetworks)
                            .sServerLinks.sWindow.Text = "nexIRC " & StatusServerName(.sWindow.mdiChildWindow.MeIndex) & " - Links"
                        Else
                            If .sServerLinks.sTreeNode.ImageIndex <> 6 Then .sServerLinks.sTreeNode.ImageIndex = 6
                            If .sServerLinks.sTreeNode.SelectedImageIndex <> 6 Then .sServerLinks.sTreeNode.SelectedImageIndex = 6
                            .sServerLinks.sLinkCount = .sServerLinks.sLinkCount + 1
                            .sServerLinks.sLink(.sServerLinks.sLinkCount).lServerIP = lServerIP
                            .sServerLinks.sLink(.sServerLinks.sLinkCount).lPort = lServerPort
                        End If
                    End If
                    .sServerLinks.sWindow.lServerLinksUI.AddToLinks(lServerIP, lServerPort, .sServerLinks.sWindow.lvwLinks)
                End With
            End If
            'If Err.Number <> 0 Then Throw ex 'ProcessError(ex.Message, "Public Sub AddToServerLinks(ByVal lServerIP As String, ByVal lServerPort As String)")
        End Sub
        Public Sub SetLinksWindowsVisible(ByVal lIndex As Integer, ByVal lValue As Boolean)
            'On Error Resume Next
            With lStatusObjects.sStatusObject(lIndex)
                .sServerLinks.sVisible = lValue
            End With
            'If Err.Number <> 0 Then Throw ex 'ProcessError(ex.Message, "Public Sub SetLinksWindowsVisible(ByVal lValue As Boolean)")
        End Sub
        Public Sub SaveServerLink(ByVal lIndex As Integer, ByVal lServerIP As String, ByVal lServerPort As String)
            'On Error Resume Next
            With lStatusObjects.sStatusObject(lIndex).sServerLinks
                .sLinkCount = .sLinkCount + 1
                .sLink(.sLinkCount).lServerIP = lServerIP
                .sLink(.sLinkCount).lPort = lServerPort
            End With
            'If Err.Number <> 0 Then Throw ex 'ProcessError(ex.Message, "Public Sub SaveServerLink(ByVal lIndex As Integer, ByVal lServerIP As String, ByVal lServerPort As String)")
        End Sub
        Public Sub ClearServerLinks(ByVal lIndex As Integer)
            'On Error Resume Next
            Dim i As Integer
            With lStatusObjects.sStatusObject(lIndex).sServerLinks
                For i = 1 To .sLinkCount
                    .sLink(i).lServerIP = ""
                    .sLink(i).lPort = ""
                Next i
                .sLinkCount = 0
            End With
            'If Err.Number <> 0 Then Throw ex 'ProcessError(ex.Message, "Public Sub ClearServerLinks(ByVal lIndex As Integer)")
        End Sub
#End Region
#Region "UNKNOWNS"
        Public Sub SetUnknownsData(ByVal lStatusIndex As Integer, ByVal lData As String)
            'On Error Resume Next
            With lStatusObjects.sStatusObject(lStatusIndex)
                .sUnknowns.uData = lData
            End With
            'If Err.Number <> 0 Then Throw ex 'ProcessError(ex.Message, "Public Sub SetUnknownsData(ByVal lStatusIndex As Integer)")
        End Sub
        Public Sub AddToUnknowns(ByVal lStatusIndex As Integer, ByVal lData As String)
            'On Error Resume Next
            With lStatusObjects.sStatusObject(lStatusIndex)
                If lSettings.lIRC.iSettings.sStringSettings.sUnknowns = Settings.eUnknownsIn.uStatusWindow Then
                    AddText(lData, lStatusIndex)
                ElseIf lSettings.lIRC.iSettings.sStringSettings.sUnknowns = Settings.eUnknownsIn.uOwnWindow Then
                    If .sUnknowns.uTreeNodeVisible = False Then
                        If .sTreeNodeVisible = True Then
                            .sUnknowns.uTreeNodeVisible = True
                            .sUnknowns.uTreeNode = New TreeNode
                            .sUnknowns.uTreeNode = .sTreeNode.Nodes.Add("Unknowns", "Unknowns", 3, 3)
                        End If
                    End If
                    If .sUnknowns.uVisible = False Then
                        If lSettings.lIRC.iSettings.sShowWindowsAutomatically = True Then
                            .sUnknowns.uVisible = True
                            .sUnknowns.uWindow = New frmNoticeWindow
                            .sUnknowns.uWindow.Show()
                            .sUnknowns.uWindow.SetStatusIndex(lStatusIndex)
                            .sUnknowns.uWindow.FormType = MdiChildWindow.FormTypes.Unknown
                            .sUnknowns.uWindow.Text = "Unknowns"
                            .sUnknowns.uWindow.DoNoticeColor(.sUnknowns.uData)
                        Else
                            .sUnknowns.uData = lData & Environment.NewLine & .sUnknowns.uData
                            If .sUnknowns.uTreeNode.ImageIndex <> 6 Then .sUnknowns.uTreeNode.ImageIndex = 6
                            If .sUnknowns.uTreeNode.SelectedImageIndex <> 6 Then .sUnknowns.uTreeNode.SelectedImageIndex = 6
                        End If
                    End If
                ElseIf lSettings.lIRC.iSettings.sStringSettings.sUnknowns = Settings.eUnknownsIn.uHide Then
                    Exit Sub
                End If
            End With
        End Sub
        Public Sub SetUnknownsClosed(ByVal lStatusIndex As Integer)
            Try
                With lStatusObjects.sStatusObject(lStatusIndex)
                    .sUnknowns.uWindow = Nothing
                    .sUnknowns.uVisible = False
                End With
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub SetUnknownsClosed(ByVal lStatusIndex As Integer)")
            End Try
        End Sub
#End Region
#Region "UNSUPPORTED"
        Public Sub AddToUnsupported(ByVal lStatusIndex As Integer, ByVal lData As String)
            Try
                With lStatusObjects.sStatusObject(lStatusIndex)
                    If lSettings.lIRC.iSettings.sStringSettings.sUnsupported = Settings.eUnsupportedIn.uStatusWindow Then
                        AddText(lData, lStatusIndex)
                    ElseIf lSettings.lIRC.iSettings.sStringSettings.sUnsupported = Settings.eUnsupportedIn.uOwnWindow Then
                        If .sUnsupported.uTreeNodeVisible = False Then
                            If .sTreeNodeVisible = True Then
                                .sUnsupported.uTreeNodeVisible = True
                                .sUnsupported.uTreeNode = New TreeNode
                                .sUnsupported.uTreeNode = .sTreeNode.Nodes.Add("Unknowns", "Unknowns", 3, 3)
                            End If
                        End If
                        If .sUnsupported.uVisible = False Then
                            If lSettings.lIRC.iSettings.sShowWindowsAutomatically = True Then
                                .sUnsupported.uVisible = True
                                .sUnsupported.uWindow = New frmNoticeWindow
                                .sUnsupported.uWindow.Show()
                                .sUnsupported.uWindow.SetStatusIndex(lStatusIndex)
                                .sUnsupported.uWindow.FormType = MdiChildWindow.FormTypes.Unsupported
                                .sUnsupported.uWindow.Text = "Unsupported"
                                .sUnsupported.uWindow.DoNoticeColor(.sUnsupported.uData)
                            Else
                                .sUnsupported.uData = lData & Environment.NewLine & .sUnsupported.uData
                                If .sUnsupported.uTreeNode.ImageIndex <> 6 Then .sUnsupported.uTreeNode.ImageIndex = 6
                                If .sUnsupported.uTreeNode.SelectedImageIndex <> 6 Then .sUnsupported.uTreeNode.SelectedImageIndex = 6
                            End If
                        End If
                    ElseIf lSettings.lIRC.iSettings.sStringSettings.sUnknowns = Settings.eUnknownsIn.uHide Then
                        Exit Sub
                    End If
                End With
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
#End Region
#Region "USER INPUT"
        Public Sub ProcessUserInput(ByVal _StatusIndex As Integer, ByVal _Data As String)
            Try
                Dim splt() As String, splt2() As String, l As Long, msg As String
                If TextHelper.DoLeft(_Data, 1) = "/" Then
                    _Data = TextHelper.DoRight(_Data, Len(_Data) - 1)
                    If TextHelper.DoLeft(LCase(_Data), 4) = "exit" Then
                        CloseStatusConnection(_StatusIndex, True)
                    End If
                    If TextHelper.DoLeft(LCase(_Data), 10) = "disconnect" Then
                        CloseStatusConnection(_StatusIndex, True)
                    End If
                    If TextHelper.DoLeft(LCase(_Data), 7) = "connect" Then
                        Connect(_StatusIndex)
                    End If
                    splt = Split(_Data, " ")
                    Select Case splt(0).Trim().ToLower()
                        Case "nick"
                            lStatus.NickName(ActiveIndex, True) = splt(1)
                            For nickIndex As Integer = 1 To Modules.lSettings.lIRC.iNicks.nCount - 1
                                If (Modules.lSettings.lIRC.iNicks.nNick(nickIndex).nNick = splt(1)) Then
                                    Modules.lSettings.lIRC.iNicks.nIndex = nickIndex
                                    lStrings.ProcessReplaceCommand(_StatusIndex, IrcCommandTypes.cNICK, Modules.lSettings.lIRC.iNicks.nNick(nickIndex).nNick)
                                    Exit For
                                End If
                            Next nickIndex
                            Exit Sub
                        Case "echo"
                            AddText(_Data, _StatusIndex)
                            Exit Sub
                        Case "me"
                            Dim m As IrcStrings.gCommandReturnData = lStrings.ReturnReplacedCommand(IrcCommandTypes.cACTION, lChannels.Name(lChannels.CurrentIndex), Replace(_Data, "me", ""), Modules.lSettings.lIRC.iNicks.nNick(Modules.lSettings.lIRC.iNicks.nIndex).nNick)
                            lChannels.DoChannelColor(lChannels.CurrentIndex, m.cDoColorData)
                            lStatus.SendSocket(_StatusIndex, m.cSocketData)
                            Exit Sub
                        Case "whowas"
                            lStrings.ProcessReplaceCommand(_StatusIndex, IrcCommandTypes.cWHOWAS, splt(1))
                            Exit Sub
                        Case "whois"
                            lStrings.ProcessReplaceCommand(_StatusIndex, IrcCommandTypes.cWHOIS, splt(1))
                            Exit Sub
                        Case "who"
                            msg = Replace(LCase(_Data), "/who ", "")
                            msg = Replace(LCase(_Data), "who ", "")
                            lStrings.ProcessReplaceCommand(_StatusIndex, IrcCommandTypes.cWHO, msg)
                            Exit Sub
                        Case "wallops"
                            msg = Replace(LCase(_Data), "/wallops ", "")
                            msg = Replace(LCase(_Data), "wallops ", "")
                            lStrings.ProcessReplaceCommand(_StatusIndex, IrcCommandTypes.cWALLOPS, msg)
                        Case "version"
                            If UBound(splt) = 1 Then
                                lStrings.ProcessReplaceCommand(_StatusIndex, IrcCommandTypes.cVERSION, splt(1))
                                Exit Sub
                            Else
                                lStrings.ProcessReplaceCommand(_StatusIndex, IrcCommandTypes.cVERSION, "*")
                                Exit Sub
                            End If
                        Case "userhost"
                            lStrings.ProcessReplaceCommand(_StatusIndex, IrcCommandTypes.cUSERHOST, splt(1))
                            Exit Sub
                        Case "trace"
                            lStrings.ProcessReplaceCommand(_StatusIndex, IrcCommandTypes.cTRACE, splt(1))
                            Exit Sub
                        Case "topic"
                            lStrings.ProcessReplaceCommand(_StatusIndex, IrcCommandTypes.cTOPIC, splt(1))
                            Exit Sub
                        Case "time"
                            If UBound(splt) = 1 Then
                                lStrings.ProcessReplaceCommand(_StatusIndex, IrcCommandTypes.cTIME, splt(1))
                                Exit Sub
                            Else
                                lStrings.ProcessReplaceCommand(_StatusIndex, IrcCommandTypes.cTIME, "*")
                                Exit Sub
                            End If
                        Case "stats"
                            lStrings.ProcessReplaceCommand(_StatusIndex, IrcCommandTypes.cSTATS, splt(1))
                            Exit Sub
                        Case "squit"
                            lStrings.ProcessReplaceCommand(_StatusIndex, IrcCommandTypes.cQUIT, splt(1), splt(2), splt(3), splt(4))
                            Exit Sub
                        Case "silence"
                            lStrings.ProcessReplaceCommand(_StatusIndex, IrcCommandTypes.cSTATS, splt(1))
                            Exit Sub
                        Case "quit"
                            If UBound(splt) = 0 Then
                                If Len(lSettings.lIRC.iSettings.sQuitMessage) <> 0 Then
                                    lStrings.ProcessReplaceCommand(_StatusIndex, IrcCommandTypes.cQUIT, lSettings.lIRC.iSettings.sQuitMessage)
                                Else
                                    lStrings.ProcessReplaceCommand(_StatusIndex, IrcCommandTypes.cQUIT, "Quit")
                                End If
                                Exit Sub
                            Else
                                lStrings.ProcessReplaceCommand(_StatusIndex, IrcCommandTypes.cQUIT, splt(1))
                                Exit Sub
                            End If
                            'Case "privmsg"
                            'Exit Sub
                        Case "noticetext"
                            Notices_Add(_StatusIndex, TextHelper.DoRight(_Data, Len(_Data) - 11))
                            Exit Sub
                        Case "loadstrings"
                            lStrings.ClearStrings()
                            lStrings.LoadStrings()
                            Exit Sub
                        Case "loadcommands"
                            lStrings.LoadCommands()
                            Exit Sub
                        Case "admin"
                            SendSocket(_StatusIndex, "ADMIN " & splt(1))
                            Exit Sub
                        Case "away"
                            SendSocket(_StatusIndex, "AWAY " & splt(1))
                            Exit Sub
                        Case "botmotd"
                            DoStatusSocket(_StatusIndex, "BOTMOTD " & splt(1))
                            Exit Sub
                        Case "msg", "privmsg"
                            msg = _Data.Remove(0, (splt(1).Length + 5))
                            lStatus.SendSocket(_StatusIndex, "PRIVMSG " & splt(1) & " :" & msg)
                            lStrings.ProcessReplaceCommand(_StatusIndex, IrcCommandTypes.cPRIVMSG, splt(1), splt(2))
                            Exit Sub
                        Case "processdata"
                            lProcessNumeric.ProcessDataArrivalLine(1, Right(_Data, Len(_Data) - 11))
                        Case "join"
                            msg = splt(1)
                            lChannels.Join(_StatusIndex, msg)
                            Exit Sub
                        Case "raw"
                            _Data = TextHelper.DoRight(_Data, Len(_Data) - 4)
                            SendSocket(_StatusIndex, _Data)
                            Exit Sub
                        Case "docolor"
                            AddText(_Data, _StatusIndex)
                            Exit Sub
                        Case "server"
                            If InStr(splt(1), ":") <> 0 Then
                                splt2 = Split(splt(1), ":")
                                Connect_Specify(splt2(0), Convert.ToInt64(splt2(1).Trim()))
                            Else
                                If UBound(splt) = 2 Then
                                    l = Convert.ToInt64(splt(2).Trim())
                                ElseIf UBound(splt) = 1 Then
                                    l = 6667
                                End If
                                Connect_Specify(splt(1), l)
                            End If
                            Exit Sub
                        Case Else
                            SendSocket(_StatusIndex, _Data)
                            Exit Sub
                    End Select
                End If
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public Sub ProcessUserInput(ByVal _StatusIndex As Integer, ByVal _Data As String, ByVal lTextBox As Object)")
            End Try
        End Sub
#End Region
#Region "TIMERS"
        Public Property TimerWaitForWhoisEnabled(ByVal lIndex As Integer) As Boolean
            Get
                Try
                    Return lStatusObjects.sStatusObject(lIndex).sWindow.tmrWaitForWhois.Enabled
                Catch ex As Exception
                    Throw ex 'ProcessError(ex.Message, "Public Property TimerWaitForWhoisEnabled(ByVal lIndex As Integer) As Boolean")
                    Return Nothing
                End Try
            End Get
            Set(ByVal _Value As Boolean)
                Try
                    lStatusObjects.sStatusObject(lIndex).sWindow.tmrWaitForWhois.Enabled = _Value
                Catch ex As Exception
                    Throw ex 'ProcessError(ex.Message, "Public Property TimerWaitForWhoisEnabled(ByVal lIndex As Integer) As Boolean")
                End Try
            End Set
        End Property
        Public Property TimerWaitForLUsersEnabled(ByVal lIndex As Integer) As Boolean
            Get
                Try
                    Return lStatusObjects.sStatusObject(lIndex).sWindow.tmrWaitForLUsers.Enabled
                Catch ex As Exception
                    Throw ex 'ProcessError(ex.Message, "Public Property TimerWaitForLUsersEnabled(ByVal lIndex As Integer) As Boolean")
                    Return Nothing
                End Try
            End Get
            Set(ByVal lValue As Boolean)
                Try
                    lStatusObjects.sStatusObject(lIndex).sWindow.tmrWaitForLUsers.Enabled = lValue
                Catch ex As Exception
                    Throw ex 'ProcessError(ex.Message, "Public Property TimerWaitForLUsersEnabled(ByVal lIndex As Integer) As Boolean")
                End Try
            End Set
        End Property
#End Region
    End Class
End Namespace