﻿'nexIRC 3.0.31
'Sunday, Oct 4th, 2014 - guideX
Option Explicit On
Option Strict On
Imports Telerik.WinControls.UI
'Imports nexIRC.Classes.IO
'Imports nexIRC.Classes.UI
'Imports nexIRC.IRC.Customize
Imports nexIRC.Modules
Imports nexIRC.nexIRC.IRC.Settings.clsDCC
Imports nexIRC.IRC.Customize
Imports nexIRC.Settings2
Imports nexIRC.Business.Helpers
Imports nexIRC.Business.Enums

Public Class frmCustomize
    Public WithEvents lCustomize As New clsCustomize

    Public Sub EventApply()
        Dim textBufferSize As Integer
        Try
            If (IsNumeric(txtTextBufferSize.Text)) Then
                textBufferSize = Convert.ToInt32(txtTextBufferSize.Text)
            End If
            lCustomize.Apply_Settings_Servers(lvwServers, cboNetworks.Text)
            lCustomize.Apply_Settings_User(cboMyNickNames,
                "",
                txtUserEmail.Text,
                txtPassword.Text,
                txtRealName.Text,
                txtOperName.Text,
                txtOperPassword.Text
            )
            lCustomize.Apply_Settings_Interface(
                chkShowPrompts.Checked,
                chkShowWindowsAutomatically.Checked,
                chkAutoMaximize.Checked,
                chkPopupChannelFolder.Checked,
                chkVideoBackground.Checked,
                chkShowNicknameWindow.Checked,
                chkCloseChannelFolder.Checked,
                chkAddToChannelFolder.Checked,
                False,
                chkCloseStatusWindow.Checked,
                chkShowRawWindow.Checked,
                chkMOTDInOwnWindow.Checked,
                chkNoticesInOwnWindow.Checked,
                textBufferSize,
                chkAutoSelectAlternateNickname.Checked
            )
            lCustomize.Apply_Settings_Startup(
                chkAutoConnect.Checked,
                chkShowCustomize.Checked,
                False
            )
            lCustomize.Apply_Settings_Startup(
                chkAutoConnect.Checked,
                chkShowCustomize.Checked,
                False
            )
            lCustomize.Apply_Settings_ServerModes(
                chkInvisible.Checked,
                chkWallops.Checked,
                chkRestricted.Checked,
                chkOperator.Checked,
                chkLocalOp.Checked,
                chkServerNotices.Checked
            )
            lCustomize.Apply_Settings_IRC(
                chkNoIRCMessages.Checked,
                chkExtendedMessages.Checked,
                chkShowUserAddresses.Checked,
                chkHideMOTDs.Checked
            )
            lCustomize.Apply_Settings_Text(rdbUnknownTextStatus.IsChecked,
                rdbUnknownTextOwn.IsChecked,
                rdbUnknownTextHide.IsChecked,
                rdbUnsupportedStatus.IsChecked,
                rdbUnsupportedOwn.IsChecked,
                rdbUnsupportedHide.IsChecked
            )
            lCustomize.Apply_Settings_DCC(optDccChatPrompt.IsChecked,
                optDccChatAcceptAll.IsChecked,
                optDccChatIgnore.IsChecked,
                optDccSendPrompt.IsChecked,
                optDccSendAcceptAll.IsChecked,
                optDccSendIgnore.IsChecked,
                chkAutoCloseDialogs.Checked,
                chkAutoIgnoreExceptNotify.Checked,
                chkPopupDownloadManager.Checked,
                txtDownloadDirectory.Text
            )
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public ReadOnly Property ServersListView() As RadListView
        Get
            Try
                Return lvwNotify
            Catch ex As Exception
                Throw ex
                Return Nothing
            End Try
        End Get
    End Property

    Private Sub InitSettings()
        'Try
        Dim i As Integer, _ListViewItem As ListViewDataItem
            For i = 1 To lSettings.lCompatibility.cCount
                If (lSettings.lCompatibility.cCompatibility(i).cEnabled = True) Then
                    _ListViewItem = New ListViewDataItem()
                    _ListViewItem.SubItems.Add(lSettings.lCompatibility.cCompatibility(i).cDescription)
                    _ListViewItem.SubItems.Add(lSettings.lCompatibility.cCompatibility(i).cEnabled.ToString())
                    lvwCompatibility.Items.Add(_ListViewItem)
                End If
            Next i
            lvwCompatibility.SelectedIndex = 0
            lStrings.PopulateListViewWithStrings(lvwStrings)
            'For i = 1 To lSettings.lNetworks.nCount
            'With lSettings.lNetworks.nNetwork(i)
            'cboNetworkNotify.Items.Add(.nDescription)
            'End With
            'Next i
            Dim networks = Modules.IrcSettings.IrcNetworks.Get()
            For Each network In networks
                cboNetworkNotify.Items.Add(network.Description)
            Next network
            For i = 1 To lSettings.lNotify.nCount
                With lSettings.lNotify.nNotify(i)
                    lCustomize.AddToNotifyListView(.nNickName, .nMessage, .nNetwork, lvwNotify)
                End With
            Next i
            For i = 1 To lSettings.lIRC.iNicks.nCount
                With lSettings.lIRC.iNicks.nNick(i)
                    If (Not String.IsNullOrEmpty(.nNick)) Then
                        cboMyNickNames.Items.Add(.nNick)
                    End If
                End With
            Next i
            cboMyNickNames.Text = lSettings.lIRC.iNicks.nNick(lSettings.lIRC.iNicks.nIndex).nNick
            With lSettings.lIRC.iModes
                chkInvisible.Checked = .mInvisible
                chkLocalOp.Checked = .mLocalOperator
                chkOperator.Checked = .mOperator
                chkRestricted.Checked = .mRestricted
                chkServerNotices.Checked = .mServerNotices
                chkWallops.Checked = .mWallops
            End With
            With lSettings_DCC.lDCC
                Select Case .dChatPrompt
                    Case eDccPrompt.ePrompt
                        optDccChatPrompt.IsChecked = True
                    Case eDccPrompt.eAcceptAll
                        optDccChatAcceptAll.IsChecked = True
                    Case eDccPrompt.eIgnore
                        optDccChatIgnore.IsChecked = True
                End Select
                Select Case .dSendPrompt
                    Case eDccPrompt.ePrompt
                        optDccSendPrompt.IsChecked = True
                    Case eDccPrompt.eAcceptAll
                        optDccSendAcceptAll.IsChecked = True
                    Case eDccPrompt.eIgnore
                        optDccSendIgnore.IsChecked = True
                End Select
                txtDownloadDirectory.Text = lSettings_DCC.lDCC.dDownloadDirectory
                chkAutoIgnoreExceptNotify.Checked = lSettings_DCC.lDCC.dAutoIgnore
                chkAutoCloseDialogs.Checked = lSettings_DCC.lDCC.dAutoCloseDialogs
                chkPopupDownloadManager.Checked = lSettings_DCC.lDCC.dPopupDownloadManager
                Select Case .dFileExistsAction
                    Case eDccFileExistsAction.dPrompt
                        cboDCCFileExists.SelectedIndex = 0
                    Case eDccFileExistsAction.dOverwrite
                        cboDCCFileExists.SelectedIndex = 1
                    Case eDccFileExistsAction.dIgnore
                        cboDCCFileExists.SelectedIndex = 2
                End Select
                For i = 1 To .dIgnorelist.dCount
                    Select Case .dIgnorelist.dItem(i).dType
                        Case gDCCIgnoreType.dNicknames
                            If (Not String.IsNullOrEmpty(.dIgnorelist.dItem(i).dData)) Then lstDCCIgnoreItems.Items.Add(.dIgnorelist.dItem(i).dData)
                        Case gDCCIgnoreType.dHostnames
                            If (Not String.IsNullOrEmpty(.dIgnorelist.dItem(i).dData)) Then lstDCCIgnoreItems.Items.Add(.dIgnorelist.dItem(i).dData)
                        Case gDCCIgnoreType.dFileTypes
                            If (Not String.IsNullOrEmpty(.dIgnorelist.dItem(i).dData)) Then lstIgnoreExtensions.Items.Add(.dIgnorelist.dItem(i).dData)
                    End Select
                Next i
            End With
            With lSettings.lIRC.iSettings
                txtTextBufferSize.Text = .sTextBufferSize.ToString()
                'txtURL.Text = .sURL
                chkCloseChannelFolder.Checked = .sChannelFolderCloseOnJoin
                chkAddToChannelFolder.Checked = .sAutoAddToChannelFolder
                chkCloseStatusWindow.Checked = .sCloseWindowOnDisconnect
                'chkBrowseChannelURLs.Checked = .sAutoNavigateChannelUrls
                chkShowUserAddresses.Checked = .sShowUserAddresses
                chkHideMOTDs.Checked = .sHideMOTD
                chkShowPrompts.Checked = .sPrompts
                chkExtendedMessages.Checked = .sExtendedMessages
                chkNoIRCMessages.Checked = .sNoIRCMessages
                chkShowCustomize.Checked = .sCustomizeOnStartup
                chkPopupChannelFolder.Checked = .sPopupChannelFolders
                chkShowNicknameWindow.Checked = .sChangeNickNameWindow
                chkAutoSelectAlternateNickname.Checked = .sAutoSelectAlternateNickname
                'chkShowBrowser.Checked = .sShowBrowser
                chkShowWindowsAutomatically.Checked = .sShowWindowsAutomatically
                chkAutoMaximize.Checked = .sAutoMaximize
                chkAutoConnect.Checked = .sAutoConnect
                chkVideoBackground.Checked = .sVideoBackground
            End With
            If (networks.Count <> 0) Then
                For Each network In networks
                    If (Not String.IsNullOrEmpty(network.Description)) Then
                        cboNetworks.Items.Add(network.Description)
                        cboNetworks.Text = Modules.IrcSettings.IrcNetworks.GetDefault().Description
                        lCustomize.RefreshServers(lvwServers, Modules.IrcSettings.IrcNetworks.GetDefault().Id)
                    End If
                Next
            End If
            'If lSettings.lNetworks.nCount <> 0 Then
            'For i = 1 To lSettings.lNetworks.nCount
            'With lSettings.lNetworks.nNetwork(i)
            'If (Not String.IsNullOrEmpty(.nDescription)) Then
            'cboNetworks.Items.Add(.nDescription)
            'End If
            'End With
            'Next i
            'cboNetworks.Text = lSettings.lNetworks.nNetwork(lSettings.lNetworks.nIndex).nDescription
            'lCustomize.lStartupNetwork = lSettings.lNetworks.nNetwork(lSettings.lNetworks.nIndex).nDescription
            'lCustomize.RefreshServers(lvwServers, lSettings.lNetworks.nIndex)
            'End If
            lSettings.lServers.sIndex = Convert.ToInt32(IniFileHelper.ReadINI(lSettings.lINI.iServers, "Settings", "Index", "0"))
            chkMOTDInOwnWindow.Checked = lSettings.lIRC.iSettings.sMOTDInOwnWindow
            chkNoticesInOwnWindow.Checked = lSettings.lIRC.iSettings.sNoticesInOwnWindow
            chkShowRawWindow.Checked = lSettings.lIRC.iSettings.sShowRawWindow
            With lSettings.lIRC
                txtUserEmail.Text = .iEMail
                txtPassword.Text = .iPass
                txtRealName.Text = .iRealName
                txtOperName.Text = .iOperName
                txtOperPassword.Text = .iOperPass
            End With
            Select Case lSettings.lIRC.iSettings.sStringSettings.sUnsupported
                Case Settings.eUnsupportedIn.uOwnWindow
                    rdbUnsupportedOwn.IsChecked = True
                Case Settings.eUnsupportedIn.uHide
                    rdbUnsupportedHide.IsChecked = True
                Case Settings.eUnsupportedIn.uStatusWindow
                    rdbUnsupportedStatus.IsChecked = True
            End Select
            Select Case lSettings.lIRC.iSettings.sStringSettings.sUnknowns
                Case Settings.eUnknownsIn.uStatusWindow
                    rdbUnknownTextStatus.IsChecked = True
                Case Settings.eUnknownsIn.uHide
                    rdbUnknownTextHide.IsChecked = True
                Case Settings.eUnknownsIn.uOwnWindow
                    rdbUnknownTextOwn.IsChecked = True
            End Select
        'Catch ex As Exception
        'Throw ex
        'End Try
    End Sub

    Public Sub ClearServers()
        Try
            lCustomize.ClearServers(lvwServers)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UpdateSelectedServer(ByVal _Description As String, ByVal _Ip As String, ByVal _Port As String)
        Try
            lCustomize.UpdateSelectedServer(lvwServers, _Description, _Ip, _Port)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub frmCustomize_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            lCustomize.frmCustomize_FormClosed()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub frmCustomize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lCustomize.Form_Load(Me, cmdCancelNow, lvwServers)
        InitSettings()
        With lSettings.lIRC.iIdent
            txtIdentdPort.Text = .iPort.ToString
            txtIdentdSystem.Text = .iSystem
            txtIdentdUserID.Text = .iUserID
            chkIdentdEnabled.Checked = .iSettings.iEnabled
        End With
        Me.Width = 551
        Me.Height = 448
    End Sub
    Private Sub lnkNetworkAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkNetworkAdd.Click
        Try
            lCustomize.lnkNetworkAdd_Click()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmdAddServer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdServerAdd.Click
        Try
            If (cboNetworks.SelectedItem IsNot Nothing) Then
                lCustomize.lnkAddServer_Click(cboNetworks.SelectedItem.Text)
            Else
                lCustomize.lnkAddServer_Click("")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmdNotifyAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNotifyAdd.Click
        lCustomize.cmdNotifyAdd_Click(lvwNotify)
    End Sub
    Private Sub cmdClearNotify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNotifyClear.Click
        lCustomize.cmdClearNotify_Click(lvwNotify)
    End Sub
    Private Sub cmdEditString_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEditString.Click
        lCustomize.cmdEditString_Click(lvwStrings)
    End Sub
    Private Sub lvwNotify_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwNotify.SelectedItemChanged
        lCustomize.lvwNotify_SelectedIndexChanged(lvwNotify, txtNotifyNickname, txtNotifyMessage, cboNetworkNotify)
    End Sub
    Private Sub cmdDCCIgnoreAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDCCIgnoreAdd.Click
        Try
            lCustomize.cmdDCCIgnoreAdd_Click()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub lstDCCIgnoreItems_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstDCCIgnoreItems.MouseClick
        Try
            lCustomize.lstDCCIgnoreItems_MouseClick(lstDCCIgnoreItems)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmdDCCIgnoreRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDCCIgnoreRemove.Click
        Try
            lCustomize.cmdDCCIgnoreRemove_Click(lstDCCIgnoreItems)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmdRemoveNotify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNotifyRemove.Click
        Try
            lCustomize.cmdRemoveNotify_Click(lvwNotify)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmdEditIdentSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            lCustomize.cmdEditIdentSettings_Click()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmdNetworkSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNetworkSettings.Click
        Try
            lCustomize.cmdNetworkSettings_Click()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub lnkNetworkDelete_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkNetworkDelete.LinkClicked
        Try
            lCustomize.lnkNetworkDelete_LinkClicked(cboNetworks)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub lnkNetworkAdd_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkNetworkAdd.LinkClicked
        Try
            lCustomize.lnkNetworkAdd_LinkClicked()
            'animate.Animate(f, animate.Effect.Center, 200, 1)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmdServerEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdServerEdit.Click
        Try
            lCustomize.cmdServerEdit_Click(lvwServers)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmdServerDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdServerDelete.Click
        Try
            lCustomize.cmdServerDelete_Click(lvwServers)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmdServersClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdServersClear.Click
        Try
            lCustomize.cmdServersClear_Click(cboNetworks.Text, lvwServers)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmdServersMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdServersMove.Click
        Try
            If (lvwServers.SelectedItem IsNot Nothing) Then
                lCustomize.cmdServersMove_Click(cboNetworks.Text, lvwServers.SelectedItem.Item(1).ToString)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmdConnectNow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConnectNow.Click
        Try
            If lCustomize.cmdConnectNow_Click(chkNewStatus.Checked, Me) Then
                With lSettings.lIRC.iIdent
                    .iPort = CType(txtIdentdPort.Text, Integer)
                    .iSettings.iEnabled = chkIdentdEnabled.Checked
                    .iSystem = txtIdentdSystem.Text
                    .iUserID = txtIdentdUserID.Text
                End With
                EventApply()
                lSettings.SaveSettings()
            End If
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Try
            If lCustomize.cmdOK_Click(chkNewStatus.Checked, Me) Then
                With lSettings.lIRC.iIdent
                    .iPort = CType(txtIdentdPort.Text, Integer)
                    .iSettings.iEnabled = chkIdentdEnabled.Checked
                    .iSystem = txtIdentdSystem.Text
                    .iUserID = txtIdentdUserID.Text
                End With
                EventApply()
            End If
            lSettings.SaveSettings()
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmdApplyNow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApplyNow.Click
        Try
            With lSettings.lIRC.iIdent
                .iPort = CType(txtIdentdPort.Text, Integer)
                .iSettings.iEnabled = chkIdentdEnabled.Checked
                .iSystem = txtIdentdSystem.Text
                .iUserID = txtIdentdUserID.Text
            End With
            EventApply()
            lCustomize.cmdApplyNow_Click(Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmdCancelNow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelNow.Click
        Try
            lCustomize.cmdCancelNow_Click(Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cboNetworks_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.Data.PositionChangedEventArgs) Handles cboNetworks.SelectedIndexChanged
        Try
            lCustomize.cboNetworks_SelectedIndexChanged(cboNetworks.SelectedItem.Text, lvwServers)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmdAddMyNickName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddMyNickName.Click
        Try
            lCustomize.cmdAddNickName_Click()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmdRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemoveMyNickName.Click
        Try
            lCustomize.cmdRemoveNickName(cboMyNickNames)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmdClearMyNickName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearMyNickName.Click
        Try
            lCustomize.cmdClearMyNickName_Click(cboMyNickNames)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmdQuerySettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdQuerySettings.Click
        Try
            lCustomize.cmdQuerySettings_Click()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtNotifyNickname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNotifyNickname.TextChanged
        Try
            lCustomize.txtNotifyNickname_TextChanged(txtNotifyNickname.Text, lvwNotify)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtNotifyMessage_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNotifyMessage.TextChanged
        Try
            lCustomize.txtNotifyMessage_TextChanged(txtNotifyMessage.Text, lvwNotify)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cboNetworkNotify_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.Data.PositionChangedEventArgs) Handles cboNetworkNotify.SelectedIndexChanged
        Try
            lCustomize.txtNotifyNetwork_TextChanged(cboNetworkNotify.Text, lvwNotify)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmdRemoveIgnoreExtension_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemoveIgnoreExtension.Click
        Try
            lCustomize.cmdRemoveIgnoreExtension_Click(lstIgnoreExtensions)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmdAddIgnoreExtension_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddIgnoreExtension.Click
        Try
            lCustomize.cmdAddIgnoreExtension_Click(lstIgnoreExtensions)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub lstDCCIgnoreItems_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstDCCIgnoreItems.Click
        Try
            lCustomize.lstDCCIgnoreItems_Click(cmdDCCIgnoreAdd)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub lstIgnoreExtensions_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstIgnoreExtensions.SelectedIndexChanged
        Try
            lCustomize.lstIgnoreExtensions_SelectedIndexChanged(cmdDCCIgnoreRemove)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub lvwServers_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwServers.DoubleClick
        Try
            lCustomize.lvwServers_DoubleClick(chkNewStatus, Me)
            'Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub lCustomize_Apply() Handles lCustomize.Apply
        Try
            EventApply()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmdCompatibilityEnable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCompatibilityEnable.Click
        Try
            lCustomize.cmdCompatibilityEnable_Click(lvwCompatibility.SelectedItem.Item(0).ToString(), lvwCompatibility.SelectedItem)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmdCompatibilityDisable_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCompatibilityDisable.Click
        Try
            lCustomize.cmdCompatibilityDisable_Click(lvwCompatibility.SelectedItem.Item(0).ToString(), lvwCompatibility.SelectedItem)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub lvwServers_SelectedItemChanged(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.ListViewItemEventArgs) Handles lvwServers.SelectedItemChanged

    End Sub

    Private Sub lCustomize_Close() Handles lCustomize.Close
        Try
            tmrCloseMe.Interval = 200
            tmrCloseMe.Enabled = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub lCustomize_Save() Handles lCustomize.Save
        Try
            lSettings.SaveSettings()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tmrCloseMe_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrCloseMe.Tick
        Try
            tmrCloseMe.Enabled = False
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub lstIgnoreExtensions_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.Data.PositionChangedEventArgs) Handles lstIgnoreExtensions.SelectedIndexChanged

    End Sub

    Private Sub lvwNotify_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.ListViewItemEventArgs) Handles lvwNotify.SelectedItemChanged

    End Sub
End Class