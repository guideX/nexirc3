﻿'nexIRC 3.0.31
'Sunday, Oct 4th, 2014 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.Modules
Imports Telerik.WinControls.RichTextBox.Model

Public Class frmStatus
#Region "Public Variables"
    Public WithEvents mdiChildWindow As New MdiChildWindow
    Public WithEvents lAutoConnectDelayTimer As New Timer
#End Region
#Region "Window Events"
#Region "txtIncoming Events"
    Private Sub txtIncoming_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtIncoming.MouseDown
        Try
            mdiChildWindow.txtIncomingColor_MouseDown(Me)
            lStatus.ActiveIndex = mdiChildWindow.MeIndex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtIncoming_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtIncoming.MouseUp
        Try
            mdiChildWindow.txtIncomingColor_MouseUp(txtIncoming.Document.Selection.GetSelectedText(), txtIncoming, txtOutgoing)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
#Region "txtOugtgoing Events"
    Private Sub txtOutgoing_Click(sender As Object, e As System.EventArgs) Handles txtOutgoing.Click
        mdiChildWindow.txtIncomingColor_MouseDown(Me)
        lStatus.ActiveIndex = mdiChildWindow.MeIndex
    End Sub
    Private Sub txtOutgoing_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOutgoing.KeyDown
        Try
            mdiChildWindow.txtOutgoing_KeyDown(e, txtOutgoing.Text)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtOutgoing_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtOutgoing.MouseDown
        Try
            'mdiChildWindow.txtIncomingColor_MouseUp(txtIncoming.Document.Selection.GetSelectedText(), txtIncoming, txtOutgoing)
            mdiChildWindow.txtIncomingColor_MouseDown(Me)
            lStatus.ActiveIndex = mdiChildWindow.MeIndex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
#Region "frmStatus Events"
    Private Sub frmStatus_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Try
            mdiChildWindow.Form_Resize(txtIncoming, txtOutgoing, Me)
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Private Sub frmStatus_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize")
        End Try
    End Sub
    Private Sub frmStatus_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            mdiChildWindow.Form_FormClosing(Me, e)
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs)")
        End Try
    End Sub
    Private Sub frmStatus_MdiChildActivate(sender As Object, e As System.EventArgs) Handles Me.MdiChildActivate
        Try
            mdiChildWindow.Form_GotFocus(Me)
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Private Sub frmStatus_MdiChildActivate(sender As Object, e As System.EventArgs) Handles Me.MdiChildActivate")
        End Try
    End Sub
    Private Sub frmStatus_GotFocus(sender As Object, e As System.EventArgs) Handles Me.GotFocus
        Try
            mdiChildWindow.Form_GotFocus(Me)
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Private Sub frmStatus_GotFocus(sender As Object, e As System.EventArgs) Handles Me.GotFocus")
        End Try
    End Sub
    Private Sub frmStatus_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            mdiChildWindow.Form_Load(mdiChildWindow.FormTypes.Status)
            txtIncoming.Cursor = Cursors.Default
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Private Sub frmStatus_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load")
        End Try
    End Sub
#End Region
#End Region
#Region "Button Events"
    Private Sub cmdDisconnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDisconnect.Click
        Try
            mdiChildWindow.cmdDisconnect_Click()
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Private Sub cmdDisconnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDisconnect.Click")
        End Try
    End Sub
    Private Sub cmdConnection_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConnection.ButtonClick
        Try
            mdiChildWindow.cmdToggleConnection_Click()
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Private Sub cmdConnection_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConnection.ButtonClick")
        End Try
    End Sub
    Private Sub cmdConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConnect.Click
        Try
            mdiChildWindow.cmdConnect_Click()
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Private Sub cmdConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConnect.Click")
        End Try
    End Sub
    Private Sub cmd_SendNewNotice_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem3.Click
        Try
            mdiChildWindow.cmdSendNewNotice_Click()
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Private Sub ToolStripMenuItem3_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem3.Click")
        End Try
    End Sub
    Private Sub cmd_ChangeNickName_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Try
            mdiChildWindow.cmdChangeNickName_Click()
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Private Sub ToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem1.Click")
        End Try
    End Sub
    Private Sub tspListChannels_Click(sender As System.Object, e As System.EventArgs) Handles tspListChannels.Click
        Try
            mdiChildWindow.cmdListChannels_Click()
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Private Sub tspListChannels_Click(sender As System.Object, e As System.EventArgs) Handles tspListChannels.Click")
        End Try
    End Sub
    Private Sub cmdBotLogin_Click(sender As System.Object, e As System.EventArgs) Handles cmdBotLogin.Click
        Try
            lStatus.GetObject(mdiChildWindow.MeIndex).sNickBot.Login()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmdBot_ButtonClick(sender As System.Object, e As System.EventArgs) Handles cmdBot.ButtonClick
        Try
            lStatus.GetObject(mdiChildWindow.MeIndex).sNickBot.LoginForm()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmdBotRegister_Click(sender As System.Object, e As System.EventArgs) Handles cmdBotRegister.Click
        Dim settings As BotSettings
        Try
            settings = New BotSettings()
            settings.Email = InputBox("Email:")
            If (Not String.IsNullOrEmpty(settings.Email)) Then
                settings.Password = InputBox("Password:")
                If (Not String.IsNullOrEmpty(settings.Password)) Then
                    lStatus.GetObject(mdiChildWindow.MeIndex).sNickBot.Register(settings)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmdBotGhost_Click(sender As System.Object, e As System.EventArgs) Handles cmdBotGhost.Click
        Dim user As String
        Try
            user = InputBox("Nickname: ")
            lStatus.GetObject(mdiChildWindow.MeIndex).sNickBot.Ghost(user)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmdClear_Click(sender As System.Object, e As System.EventArgs) Handles cmdClear.Click
        Try
            txtIncoming.Document = New RadDocument()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
#Region "Timer Events"
    Private Sub lAutoConnectDelayTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lAutoConnectDelayTimer.Tick
        Try
            mdiChildWindow.tmrConnectDelay_Tick()
            lAutoConnectDelayTimer.Enabled = False
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Private Sub lAutoConnectDelayTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lAutoConnectDelayTimer.Tick")
        End Try
    End Sub
    Private Sub tmrQuickFocus_Tick(sender As Object, e As System.EventArgs) Handles tmrQuickFocus.Tick
        Try
            tmrQuickFocus.Enabled = False
            txtOutgoing.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
#Region "Class Events"
    Private Sub lMdiChildWindow_SetTextBoxEditAbilities() Handles mdiChildWindow.SetTextBoxEditAbilities
        Try
            txtIncoming.IsReadOnly = True
            txtIncoming.IsSelectionEnabled = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub lMdiChildWindow_BringToFront() Handles mdiChildWindow.BringToFront
        Try
            Me.Focus()
            Me.BringToFront()
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Private Sub lMdiChildWindow_BringToFront() Handles mdiChildWindow.BringToFront")
        End Try
    End Sub
    Private Sub lMdiChildWindow_ClearIncomingTextBoxSelection() Handles mdiChildWindow.ClearIncomingTextBoxSelection
        Try
            txtIncoming.Document.Selection.Clear()
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Private Sub lMdiChildWindow_ClearIncomingTextBoxSelection() Handles mdiChildWindow.ClearIncomingTextBoxSelection")
        End Try
    End Sub
    Private Sub lMdiChildWindow_CloseForm() Handles mdiChildWindow.CloseForm
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Private Sub lMdiChildWindow_CloseForm() Handles mdiChildWindow.CloseForm")
        End Try
    End Sub
    Private Sub lMdiChildWindow_EmptyOutgoingTextBox() Handles mdiChildWindow.EmptyOutgoingTextBox
        Try
            txtOutgoing.Text = ""
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Private Sub lMdiChildWindow_EmptyOutgoingTextBox() Handles mdiChildWindow.EmptyOutgoingTextBox")
        End Try
    End Sub
    Private Sub lMdiChildWindow_FormDimensions(width As Integer, height As Integer) Handles mdiChildWindow.FormDimensions
        Try
            Me.Width = width
            Me.Height = height
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Private Sub lMdiChildWindow_FormDimensions(width As Integer, height As Integer) Handles mdiChildWindow.FormDimensions")
        End Try
    End Sub
    Private Sub lMdiChildWindow_FormFocus() Handles mdiChildWindow.FormFocus
        Try
            Me.Focus()
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Private Sub lMdiChildWindow_FormFocus() Handles mdiChildWindow.FormFocus")
        End Try
    End Sub
    Private Sub lMdiChildWindow_FormIcon(icon As System.Drawing.Icon) Handles mdiChildWindow.FormIcon
        Try
            Me.Icon = icon
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Private Sub lMdiChildWindow_FormIcon(icon As System.Drawing.Icon) Handles mdiChildWindow.FormIcon")
        End Try
    End Sub
    Private Sub lMdiChildWindow_IncomingTextBoxDimensions(width As Integer, height As Integer) Handles mdiChildWindow.IncomingTextBoxDimensions
        Try
            txtIncoming.Width = width
            txtIncoming.Height = height
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Private Sub lMdiChildWindow_IncomingTextBoxDimensions(width As Integer, height As Integer) Handles mdiChildWindow.IncomingTextBoxDimensions")
        End Try
    End Sub
    Private Sub lMdiChildWindow_OutgoingSetFocus() Handles mdiChildWindow.OutgoingSetFocus
        Try
            txtOutgoing.Focus()
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Private Sub lMdiChildWindow_OutgoingSetFocus() Handles mdiChildWindow.OutgoingSetFocus")
        End Try
    End Sub
    Private Sub lMdiChildWindow_OutgoingTextBoxDimensions(width As Integer, top As Integer) Handles mdiChildWindow.OutgoingTextBoxDimensions
        Try
            txtOutgoing.Width = width
            txtOutgoing.Top = top
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Private Sub lMdiChildWindow_OutgoingTextBoxDimensions(width As Integer, top As Integer) Handles mdiChildWindow.OutgoingTextBoxDimensions")
        End Try
    End Sub
    Private Sub lMdiChildWindow_ScrollToCaret() Handles mdiChildWindow.ScrollToCaret
        Try
            If (txtIncoming IsNot Nothing) Then
                If (txtIncoming.Document IsNot Nothing) Then
                    If (txtIncoming.Document.CaretPosition IsNot Nothing) Then
                        txtIncoming.Document.CaretPosition.MoveToLastPositionInDocument()
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Private Sub lMdiChildWindow_ScrollToCaret() Handles mdiChildWindow.ScrollToCaret")
        End Try
    End Sub
    Private Sub lMdiChildWindow_SetIncomingColors(backgroundColor As System.Drawing.Color, foregroundColor As System.Drawing.Color) Handles mdiChildWindow.SetIncomingColors
        Try
            txtIncoming.RichTextBoxElement.PageBackground = backgroundColor
            txtIncoming.RichTextBoxElement.ForeColor = foregroundColor
            txtIncoming.RichTextBoxElement.BorderWidth = 0
            txtIncoming.RichTextBoxElement.BackColor = backgroundColor
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Private Sub lMdiChildWindow_SetIncomingColors(backgroundColor As System.Drawing.Color, foregroundColor As System.Drawing.Color) Handles mdiChildWindow.SetIncomingColors")
        End Try
    End Sub
    Private Sub mdiChildWindow_SetNickBotNickName(nickName As String) Handles mdiChildWindow.SetNickBotNickName
        Try
            cmdBot.Visible = True
            cmdBot.Text = nickName
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub lMdiChildWindow_SetOutgoingColors(backgroundColor As System.Drawing.Color, foregroundColor As System.Drawing.Color) Handles mdiChildWindow.SetOutgoingColors
        Try
            txtOutgoing.TextBoxElement.BackColor = backgroundColor
            txtOutgoing.TextBoxElement.ForeColor = foregroundColor
            txtOutgoing.TextBoxElement.ShowBorder = False
            txtOutgoing.TextBoxElement.Border.Width = 0
            txtOutgoing.TextBoxElement.Border.BackColor = Color.Black
            txtOutgoing.TextBoxElement.Border.ForeColor = Color.Black
            txtOutgoing.TextBoxElement.Border.Visibility = Telerik.WinControls.ElementVisibility.Collapsed
            txtOutgoing.TextBoxElement.BorderThickness = New System.Windows.Forms.Padding(0)
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Private Sub lMdiChildWindow_SetOutgoingColors(backgroundColor As System.Drawing.Color, foregroundColor As System.Drawing.Color) Handles mdiChildWindow.SetOutgoingColors")
        End Try
    End Sub
    Private Sub lMdiChildWindow_SetParent(parentForm As System.Windows.Forms.Form) Handles mdiChildWindow.SetParent
        Try
            Me.MdiParent = parentForm
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Private Sub lMdiChildWindow_SetParent(parentForm As System.Windows.Forms.Form) Handles mdiChildWindow.SetParent")
        End Try
    End Sub
    Private Sub lMdiChildWindow_SetWindowState(windowState As System.Windows.Forms.FormWindowState) Handles mdiChildWindow.SetWindowState
        Try
            Me.WindowState = windowState
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Private Sub lMdiChildWindow_SetWindowState(windowState As System.Windows.Forms.FormWindowState) Handles mdiChildWindow.SetWindowState")
        End Try
    End Sub
#End Region
End Class