﻿'nexIRC 3.0.31
'Sunday, Oct 4th, 2014 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.Modules
Imports Telerik.WinControls.UI
Imports Telerik.WinControls.RichTextBox
Imports nexIRC.Business.Enums

Public Class MdiChildWindow
    Public Enum FormTypes
        Status = 1
        Channel = 2
        NoticeWindow = 3
        MotdWindow = 4
        Unknown = 5
        Unsupported = 6
        PrivateMessage = 7
    End Enum

    Public lForeMost As Boolean
    Public Event OutgoingSetFocus()
    Public Event ClearIncomingTextBoxSelection()
    Public Event ScrollToCaret()
    Public Event CloseForm()
    Public Event ClearNickList()
    Public Event IncomingTextBoxDimensions(ByVal width As Integer, ByVal height As Integer)
    Public Event OutgoingTextBoxDimensions(ByVal width As Integer, ByVal top As Integer)
    Public Event DisableGetNamesTimer()
    Public Event FormDimensions(ByVal width As Integer, ByVal height As Integer)
    Public Event FormFocus()
    Public Event FormIcon(ByVal icon As System.Drawing.Icon)
    Public Event SetParent(ByVal parentForm As Form)
    Public Event SetIncomingColors(ByVal backgroundColor As Color, ByVal foregroundColor As Color)
    Public Event SetOutgoingColors(ByVal backgroundColor As Color, ByVal foregroundColor As Color)
    Public Event SetNicklistColors(ByVal backgroundColor As Color, ByVal foregroundColor As Color)
    Public Event BringToFront()
    Public Event EmptyOutgoingTextBox()
    Public Event SetWindowState(ByVal windowState As FormWindowState)
    Public Event SetTextBoxEditAbilities()
    Public NicklistQue As New List(Of String)
    Public Event DisableNameDelayTimer()
    Public Event AddToNickList(ByVal nickName As String)
    Private ReadOnly DisableNameDelayTimerMax As Integer = 100
    Private _meIndex As Integer
    Private _formType As FormTypes
    Private _addNameDelayTimes As Integer
    Public Event NickListBeginUpdate()
    Public Event NickListEndUpdate()

    Public Sub tmrAddNameDelay_Tick()
        Try
            RaiseEvent NickListBeginUpdate()
            NicklistQue = NicklistQue.OrderBy(Function(obj) obj).ToList()
            For i As Integer = 0 To NicklistQue.Count - 1
                RaiseEvent AddToNickList(NicklistQue(i))
            Next i
            RaiseEvent NickListEndUpdate()
            RaiseEvent DisableNameDelayTimer()
            NicklistQue = New List(Of String)()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Property FormType() As FormTypes
        Get
            Try
                Return _formType
            Catch ex As Exception
                Throw ex
            End Try
        End Get
        Set(ByVal value As FormTypes)
            Try
                _formType = value
            Catch ex As Exception
                Throw ex
            End Try
        End Set
    End Property

    Public Sub cmdAddToChannelFolder_Click()
        Try
            Select Case _formType
                Case FormTypes.Channel
                    Modules.IrcSettings.ChannelFolders.Add(lChannels.Name(_meIndex), Modules.IrcSettings.IrcNetworks.GetById(lChannels.StatusIndex(_meIndex)).Description)
                    'Modules.IrcSettings.ChannelFolders.Add(lChannels.Name(_meIndex), lSettings.lNetworks.nNetwork(lChannels.StatusIndex(_meIndex)).nDescription)
            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub cmdNames_Click()
        Try
            Select Case _formType
                Case FormTypes.Channel
                    RaiseEvent ClearNickList()
                    lStrings.ProcessReplaceCommand(ReturnMeStatusIndex(), IrcCommandTypes.cNAMES, lChannels.Name(_meIndex))
            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub txtOutgoing_GotFocus()
        Try
            RaiseEvent BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub txtOutgoing_KeyDown(ByRef e As System.Windows.Forms.KeyEventArgs, ByVal text As String)
        Try
            Select Case _formType
                Case FormTypes.Status
                    If (e.KeyCode = 13) Then
                        RaiseEvent EmptyOutgoingTextBox()
                        lStatus.ProcessUserInput(_meIndex, text)
                        e.SuppressKeyPress = True
                        Exit Sub
                    End If
                Case FormTypes.Channel
                    lChannels.Outgoing_KeyDown(_meIndex, e.KeyCode)
                    If (e.KeyCode = 13) Then
                        e.SuppressKeyPress = True
                    End If
            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub txtOutgoing_KeyDown(ByRef e As System.Windows.Forms.KeyEventArgs, ByRef textBox As TextBox)
        Try
            Select Case _formType
                Case FormTypes.Status
                    Dim msg As String
                    If (e.KeyCode = 13) Then
                        msg = textBox.Text
                        textBox.Text = ""
                        lStatus.ProcessUserInput(_meIndex, msg)
                        e.SuppressKeyPress = True
                        Exit Sub
                    End If
                Case FormTypes.Channel
                    lChannels.Outgoing_KeyDown(_meIndex, e.KeyCode)
                    If (e.KeyCode = 13) Then
                        e.SuppressKeyPress = True
                    End If
            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub txtIncomingColor_MouseDown()
        Try
            lStatus.ActiveIndex = MeIndex
            RaiseEvent BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub txtIncomingColor_MouseDown(ByVal form As Form)
        Try
            RaiseEvent BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub txtIncomingColor_MouseUp(ByVal selectedText As String, ByRef txtOutgoing As TextBox)
        Try
            RaiseEvent ClearIncomingTextBoxSelection()
            If (Not String.IsNullOrEmpty(selectedText)) Then
                Clipboard.Clear()
                Clipboard.SetText(selectedText)
            End If
            RaiseEvent OutgoingSetFocus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub txtIncomingColor_MouseUp(ByVal text As String, ByVal txtIncoming As RadRichTextBox, ByVal txtOutgoing As RadTextBox)
        Try
            RaiseEvent ClearIncomingTextBoxSelection()
            If (Not String.IsNullOrEmpty(text)) Then
                Clipboard.Clear()
                Clipboard.SetText(text)
            End If
            RaiseEvent OutgoingSetFocus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Property MeIndex() As Integer
        Get
            Return _meIndex
        End Get
        Set(ByVal MeIndex As Integer)
            Try
                Select Case _formType
                    Case FormTypes.Channel
                        _meIndex = MeIndex
                        lChannels.SetChannelVisible(_meIndex, True)
                        lChannels.CurrentIndex = _meIndex
                    Case FormTypes.Status
                        _meIndex = MeIndex
                    Case FormTypes.PrivateMessage
                        _meIndex = MeIndex
                End Select
            Catch ex As Exception
                Throw ex
            End Try
        End Set
    End Property

    Public Sub Form_Resize(ByVal formClientSizeWidth As Integer, ByVal formClientSizeHeight As Integer, ByVal outgoingTextboxHeight As Integer, ByVal incomingTextBoxTop As Integer)
        Dim incomingWidth As Integer, incomingHeight As Integer
        Try
            Select Case _formType
                Case FormTypes.Status
                    incomingWidth = formClientSizeWidth
                    incomingHeight = formClientSizeHeight - (outgoingTextboxHeight + incomingTextBoxTop)
                    RaiseEvent IncomingTextBoxDimensions(incomingWidth, incomingHeight)
                    RaiseEvent OutgoingTextBoxDimensions(incomingWidth, (incomingHeight + incomingTextBoxTop))
                Case FormTypes.Channel
                    If (_meIndex <> 0) Then
                        lChannels.Window_Resize(_meIndex)
                    End If
            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Form_Resize(ByRef incomingRichTextBox As RadRichTextBox, ByRef outgoingTextBox As RadTextBox, ByRef form As Form)
        Try
            If (mdiMain.WindowState <> FormWindowState.Minimized) Then
                If (form.WindowState <> FormWindowState.Minimized) Then
                    Select Case _formType
                        Case FormTypes.PrivateMessage
                            incomingRichTextBox.Width = form.ClientSize.Width
                            incomingRichTextBox.Height = form.ClientSize.Height - (outgoingTextBox.Height + incomingRichTextBox.Top)
                            outgoingTextBox.Width = incomingRichTextBox.Width
                            outgoingTextBox.Top = incomingRichTextBox.Height + incomingRichTextBox.Top
                        Case FormTypes.NoticeWindow
                            incomingRichTextBox.Width = form.ClientSize.Width
                            incomingRichTextBox.Height = form.ClientSize.Height - (outgoingTextBox.Height + incomingRichTextBox.Top)
                            outgoingTextBox.Width = incomingRichTextBox.Width
                            outgoingTextBox.Top = incomingRichTextBox.Height + incomingRichTextBox.Top
                        Case FormTypes.Status
                            incomingRichTextBox.Width = form.ClientSize.Width
                            incomingRichTextBox.Height = form.ClientSize.Height - (outgoingTextBox.Height + incomingRichTextBox.Top)
                            outgoingTextBox.Width = incomingRichTextBox.Width
                            outgoingTextBox.Top = incomingRichTextBox.Height + incomingRichTextBox.Top
                        Case FormTypes.Channel
                            If _meIndex <> 0 Then
                                lChannels.Window_Resize(_meIndex)
                            End If
                    End Select
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub cmdChangeNickName_Click()
        Dim statusIndex As Integer
        Try
            Select Case _formType
                Case FormTypes.Channel
                    statusIndex = lChannels.StatusIndex(_meIndex)
                Case FormTypes.Status
                    statusIndex = _meIndex
            End Select
            If (statusIndex <> 0) Then
                Dim f As New frmChangeNickName
                f = New frmChangeNickName
                f.ChangeNickName.lServerIndex = _meIndex
                f.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Event SetNickBotNickName(ByVal nickName As String)
    Public Event SetNickListSortSettings()

    Public Sub Form_Load(ByVal formType As FormTypes)
        Try
            _formType = formType
            RaiseEvent FormIcon(mdiMain.Icon)
            RaiseEvent SetParent(mdiMain)
            RaiseEvent SetIncomingColors(Color.Black, Color.White)
            RaiseEvent SetOutgoingColors(Color.Blue, Color.White)
            Select Case _formType
                Case FormTypes.Status
                    lStatus.Window_Resize(_meIndex)
                    RaiseEvent SetNickBotNickName(lStatus.GetObject(_meIndex).sNickBot.BotNick())
                Case FormTypes.Channel
                    lChannels.Window_Resize(_meIndex)
                    RaiseEvent SetNicklistColors(Color.Blue, Color.White)
                    RaiseEvent SetNickListSortSettings()
            End Select
            RaiseEvent SetTextBoxEditAbilities()
            RaiseEvent FormDimensions(Convert.ToInt32((mdiMain.Width / 10) * 8), Convert.ToInt32(mdiMain.Height / 2))
            RaiseEvent FormFocus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Form_Load(ByRef incomingTextBox As RadRichTextBox, ByRef outgoingTextBox As RadTextBox, ByVal form As Form, ByVal formType As FormTypes)
        Try
            _formType = formType
            form.Icon = mdiMain.Icon
            form.MdiParent = mdiMain
            Select Case _formType
                Case FormTypes.Status
                    Form_Resize(incomingTextBox, outgoingTextBox, form)
                Case FormTypes.Channel
                    lChannels.Window_Resize(_meIndex)
                Case Else
                    '_Form.Width = lIRC.iSettings.sWindowSizes.iNotice.wWidth
                    '_Form.Height = lIRC.iSettings.sWindowSizes.iNotice.wHeight
            End Select
            form.Width = Convert.ToInt32((mdiMain.Width / 10) * 8)
            form.Height = Convert.ToInt32(mdiMain.Height / 2)
            form.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Form_GotFocus(ByVal form As Form)
        Try
            Dim statusId As Integer = ReturnMeStatusIndex()
            If (statusId <> 0) Then
                lChannels.CurrentIndex = 0
                If lSettings.lIRC.iSettings.sAutoMaximize = True Then form.WindowState = FormWindowState.Maximized
                lStatus.SetSeenIcon(statusId, True)
                lStatus.ActiveIndex = statusId
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Form_FormClosing(Optional ByRef form As Form = Nothing, Optional ByRef e As System.Windows.Forms.FormClosingEventArgs = Nothing)
        Dim splt() As String, nickName As String
        Try
            Select Case FormType
                Case FormTypes.Unknown
                    lStatus.SetUnknownsClosed(_meIndex)
                Case FormTypes.NoticeWindow
                    lStatus.Notice_Visible(_meIndex) = False
                    lSettings.lIRC.iSettings.sWindowSizes.iNotice.wWidth = form.Width
                    lSettings.lIRC.iSettings.sWindowSizes.iNotice.wHeight = form.Height
                    lSettings.SaveWindowSizes()
                Case FormTypes.PrivateMessage
                    If (form.Text.Contains(" ")) Then
                        splt = Split(form.Text, " ")
                        nickName = splt(0)
                    Else
                        nickName = form.Text
                    End If
                    lStatus.PrivateMessage_Visible(_meIndex, nickName) = False
                    e.Cancel = True
                Case FormTypes.MotdWindow
                    lStatus.Motd_Open(_meIndex) = False
                Case FormTypes.Status
                    lStatus.Form_Closing(form, _meIndex, e)
                Case FormTypes.Channel
                    lChannels.Window_Closing(form, _meIndex, e)
                Case FormTypes.PrivateMessage
            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub txtIncomingColor_TextChanged(ByVal verticalScrollMaximum As Integer)
        Try
            RaiseEvent ScrollToCaret()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub tmrGetNames_Tick(ByVal nickListItemsCount As Integer)
        Try
            Select Case _formType
                Case FormTypes.Channel
                    If nickListItemsCount = 0 Then
                        lStrings.ProcessReplaceCommand(ReturnMeStatusIndex(), IrcCommandTypes.cNAMES, lChannels.Name(MeIndex))
                    End If
            End Select
            RaiseEvent DisableGetNamesTimer()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function ReturnMeStatusIndex() As Integer
        Try
            Dim id As Integer
            Select Case _formType
                Case FormTypes.Channel
                    id = lChannels.StatusIndex(_meIndex)
                Case FormTypes.Status
                    id = _meIndex
            End Select
            Return id
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Sub cmdSendNewNotice_Click()
        Try
            Dim form As New frmSendNotice
            form.lSendNoticeUI.StatusIndex = ReturnMeStatusIndex()
            form.Visible = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub cmdToggleConnection_Click()
        Try
            lStatus.ToggleConnection(ReturnMeStatusIndex())
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub cmdConnect_Click()
        Try
            lStatus.Connect(ReturnMeStatusIndex())
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub tmrConnectDelay_Tick()
        Try
            lStatus.Connect(ReturnMeStatusIndex())
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub cmdChannelFolder_Click()
        Try
            lChannelFolder.Show(_meIndex)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub cmdDisconnect_Click()
        Try
            Dim _StatusIndex As Integer = ReturnMeStatusIndex()
            If lStatus.Connected(_StatusIndex) = True Or lStatus.ReturnStatusConnecting(_StatusIndex) = True Then
                lStatus.CloseStatusConnection(_StatusIndex, True)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub lvwNickList_DoubleClick()
        Try
            Select Case _formType
                Case FormTypes.Channel
                    lChannels.NickList_DoubleClick(_meIndex)
            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub cmdListChannels_Click()
        Try
            lStrings.ProcessReplaceCommand(ReturnMeStatusIndex(), IrcCommandTypes.cLIST)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub cmdPart_Click()
        Try
            Select Case _formType
                Case FormTypes.Channel
                    RaiseEvent CloseForm()
                    lChannels.RemoveTree(_meIndex)
                    lStrings.ProcessReplaceCommand(ReturnMeStatusIndex(), IrcCommandTypes.cPART, lChannels.Name(_meIndex))
            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub cmdHide_Click()
        Try
            Select Case _formType
                Case FormTypes.Channel
                    lChannels.Minimize(_meIndex)
                Case FormTypes.Status
                    lStatus.Minimize(_meIndex)
            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub cmdNotice_Click()
        Dim message As String
        Try
            Select Case _formType
                Case FormTypes.Channel
                    message = InputBox("Enter notice message:")
                    If (Not String.IsNullOrEmpty(message)) Then lStrings.ProcessReplaceCommand(ReturnMeStatusIndex(), IrcCommandTypes.cNOTICE, lChannels.Name(MeIndex), message)
            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class