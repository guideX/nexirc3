﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCustomize
    Inherits Telerik.WinControls.UI.RadForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ListViewDetailColumn1 As Telerik.WinControls.UI.ListViewDetailColumn = New Telerik.WinControls.UI.ListViewDetailColumn("Column 0", "Description")
        Dim ListViewDetailColumn2 As Telerik.WinControls.UI.ListViewDetailColumn = New Telerik.WinControls.UI.ListViewDetailColumn("Column 1", "Server")
        Dim ListViewDetailColumn3 As Telerik.WinControls.UI.ListViewDetailColumn = New Telerik.WinControls.UI.ListViewDetailColumn("Column 2", "Port")
        Dim ListViewDetailColumn4 As Telerik.WinControls.UI.ListViewDetailColumn = New Telerik.WinControls.UI.ListViewDetailColumn("Column 0", "Name")
        Dim ListViewDetailColumn5 As Telerik.WinControls.UI.ListViewDetailColumn = New Telerik.WinControls.UI.ListViewDetailColumn("Column 1", "Message")
        Dim ListViewDetailColumn6 As Telerik.WinControls.UI.ListViewDetailColumn = New Telerik.WinControls.UI.ListViewDetailColumn("Column 2", "Network")
        Dim ListViewDetailColumn7 As Telerik.WinControls.UI.ListViewDetailColumn = New Telerik.WinControls.UI.ListViewDetailColumn("Column 0", "Name")
        Dim ListViewDetailColumn8 As Telerik.WinControls.UI.ListViewDetailColumn = New Telerik.WinControls.UI.ListViewDetailColumn("Column 1", "Enabled")
        Dim ListViewDetailColumn9 As Telerik.WinControls.UI.ListViewDetailColumn = New Telerik.WinControls.UI.ListViewDetailColumn("Column 0", "Description")
        Dim ListViewDetailColumn10 As Telerik.WinControls.UI.ListViewDetailColumn = New Telerik.WinControls.UI.ListViewDetailColumn("Column 1", "Support")
        Dim ListViewDetailColumn11 As Telerik.WinControls.UI.ListViewDetailColumn = New Telerik.WinControls.UI.ListViewDetailColumn("Column 2", "Syntax")
        Dim ListViewDetailColumn12 As Telerik.WinControls.UI.ListViewDetailColumn = New Telerik.WinControls.UI.ListViewDetailColumn("Column 3", "Numeric")
        Dim ListViewDetailColumn13 As Telerik.WinControls.UI.ListViewDetailColumn = New Telerik.WinControls.UI.ListViewDetailColumn("Column 4", "Data")
        Dim RadListDataItem1 As Telerik.WinControls.UI.RadListDataItem = New Telerik.WinControls.UI.RadListDataItem()
        Dim RadListDataItem2 As Telerik.WinControls.UI.RadListDataItem = New Telerik.WinControls.UI.RadListDataItem()
        Dim RadListDataItem3 As Telerik.WinControls.UI.RadListDataItem = New Telerik.WinControls.UI.RadListDataItem()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCustomize))
        Me.RadPageView1 = New Telerik.WinControls.UI.RadPageView()
        Me.RadPageViewPage1 = New Telerik.WinControls.UI.RadPageViewPage()
        Me.lvwServers = New Telerik.WinControls.UI.RadListView()
        Me.cboNetworks = New Telerik.WinControls.UI.RadDropDownList()
        Me.cmdServersMove = New Telerik.WinControls.UI.RadButton()
        Me.cmdServersClear = New Telerik.WinControls.UI.RadButton()
        Me.cmdServerAdd = New Telerik.WinControls.UI.RadButton()
        Me.lnkNetworkAdd = New System.Windows.Forms.LinkLabel()
        Me.cmdServerDelete = New Telerik.WinControls.UI.RadButton()
        Me.lnkNetworkDelete = New System.Windows.Forms.LinkLabel()
        Me.cmdServerEdit = New Telerik.WinControls.UI.RadButton()
        Me.RadPageViewPage2 = New Telerik.WinControls.UI.RadPageViewPage()
        Me.chkIdentdEnabled = New Telerik.WinControls.UI.RadCheckBox()
        Me.txtIdentdPort = New Telerik.WinControls.UI.RadTextBox()
        Me.lblIdentdPort = New Telerik.WinControls.UI.RadLabel()
        Me.txtIdentdSystem = New Telerik.WinControls.UI.RadTextBox()
        Me.RadLabel20 = New Telerik.WinControls.UI.RadLabel()
        Me.txtIdentdUserID = New Telerik.WinControls.UI.RadTextBox()
        Me.RadLabel2 = New Telerik.WinControls.UI.RadLabel()
        Me.txtOperPassword = New Telerik.WinControls.UI.RadTextBox()
        Me.txtOperName = New Telerik.WinControls.UI.RadTextBox()
        Me.RadLabel19 = New Telerik.WinControls.UI.RadLabel()
        Me.txtPassword = New Telerik.WinControls.UI.RadTextBox()
        Me.RadLabel18 = New Telerik.WinControls.UI.RadLabel()
        Me.txtRealName = New Telerik.WinControls.UI.RadTextBox()
        Me.RadLabel17 = New Telerik.WinControls.UI.RadLabel()
        Me.txtUserEmail = New Telerik.WinControls.UI.RadTextBox()
        Me.RadLabel16 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel3 = New Telerik.WinControls.UI.RadLabel()
        Me.cboMyNickNames = New Telerik.WinControls.UI.RadDropDownList()
        Me.cmdClearMyNickName = New Telerik.WinControls.UI.RadButton()
        Me.cmdRemoveMyNickName = New Telerik.WinControls.UI.RadButton()
        Me.cmdAddMyNickName = New Telerik.WinControls.UI.RadButton()
        Me.RadPageViewPage3 = New Telerik.WinControls.UI.RadPageViewPage()
        Me.RadPageView2 = New Telerik.WinControls.UI.RadPageView()
        Me.RadPageViewPage7 = New Telerik.WinControls.UI.RadPageViewPage()
        Me.chkAutoSelectAlternateNickname = New Telerik.WinControls.UI.RadCheckBox()
        Me.txtTextBufferSize = New Telerik.WinControls.UI.RadTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkShowRawWindow = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkMOTDInOwnWindow = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkNoticesInOwnWindow = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkShowPrompts = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkShowWindowsAutomatically = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkCloseStatusWindow = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkAddToChannelFolder = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkCloseChannelFolder = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkShowNicknameWindow = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkAutoMaximize = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkPopupChannelFolder = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkVideoBackground = New Telerik.WinControls.UI.RadCheckBox()
        Me.RadPageViewPage8 = New Telerik.WinControls.UI.RadPageViewPage()
        Me.chkAutoConnect = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkShowCustomize = New Telerik.WinControls.UI.RadCheckBox()
        Me.RadPageViewPage9 = New Telerik.WinControls.UI.RadPageViewPage()
        Me.chkInvisible = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkWallops = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkRestricted = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkOperator = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkLocalOp = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkServerNotices = New Telerik.WinControls.UI.RadCheckBox()
        Me.RadPageViewPage10 = New Telerik.WinControls.UI.RadPageViewPage()
        Me.chkNoIRCMessages = New Telerik.WinControls.UI.RadCheckBox()
        Me.cmdQuerySettings = New Telerik.WinControls.UI.RadButton()
        Me.chkExtendedMessages = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkShowUserAddresses = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkHideMOTDs = New Telerik.WinControls.UI.RadCheckBox()
        Me.RadLabel5 = New Telerik.WinControls.UI.RadLabel()
        Me.RadPageViewPage4 = New Telerik.WinControls.UI.RadPageViewPage()
        Me.cmdNotifyClear = New Telerik.WinControls.UI.RadButton()
        Me.cmdNotifyRemove = New Telerik.WinControls.UI.RadButton()
        Me.cmdNotifyAdd = New Telerik.WinControls.UI.RadButton()
        Me.cboNetworkNotify = New Telerik.WinControls.UI.RadDropDownList()
        Me.RadLabel7 = New Telerik.WinControls.UI.RadLabel()
        Me.txtNotifyMessage = New Telerik.WinControls.UI.RadTextBox()
        Me.RadLabel6 = New Telerik.WinControls.UI.RadLabel()
        Me.txtNotifyNickname = New Telerik.WinControls.UI.RadTextBox()
        Me.RadLabel4 = New Telerik.WinControls.UI.RadLabel()
        Me.lvwNotify = New Telerik.WinControls.UI.RadListView()
        Me.RadPageViewPage5 = New Telerik.WinControls.UI.RadPageViewPage()
        Me.cmdCompatibilityDisable = New Telerik.WinControls.UI.RadButton()
        Me.cmdCompatibilityEnable = New Telerik.WinControls.UI.RadButton()
        Me.lvwCompatibility = New Telerik.WinControls.UI.RadListView()
        Me.cmdEditString = New Telerik.WinControls.UI.RadButton()
        Me.RadLabel9 = New Telerik.WinControls.UI.RadLabel()
        Me.RadPanel2 = New Telerik.WinControls.UI.RadPanel()
        Me.rdbUnsupportedOwn = New Telerik.WinControls.UI.RadRadioButton()
        Me.rdbUnsupportedHide = New Telerik.WinControls.UI.RadRadioButton()
        Me.rdbUnsupportedStatus = New Telerik.WinControls.UI.RadRadioButton()
        Me.RadLabel8 = New Telerik.WinControls.UI.RadLabel()
        Me.RadPanel1 = New Telerik.WinControls.UI.RadPanel()
        Me.rdbUnknownTextOwn = New Telerik.WinControls.UI.RadRadioButton()
        Me.rdbUnknownTextHide = New Telerik.WinControls.UI.RadRadioButton()
        Me.rdbUnknownTextStatus = New Telerik.WinControls.UI.RadRadioButton()
        Me.lvwStrings = New Telerik.WinControls.UI.RadListView()
        Me.RadPageViewPage6 = New Telerik.WinControls.UI.RadPageViewPage()
        Me.cmdDCCIgnoreRemove = New Telerik.WinControls.UI.RadButton()
        Me.cmdDCCIgnoreAdd = New Telerik.WinControls.UI.RadButton()
        Me.lstDCCIgnoreItems = New Telerik.WinControls.UI.RadListControl()
        Me.RadLabel15 = New Telerik.WinControls.UI.RadLabel()
        Me.cmdRemoveIgnoreExtension = New Telerik.WinControls.UI.RadButton()
        Me.cmdAddIgnoreExtension = New Telerik.WinControls.UI.RadButton()
        Me.lstIgnoreExtensions = New Telerik.WinControls.UI.RadListControl()
        Me.RadLabel14 = New Telerik.WinControls.UI.RadLabel()
        Me.txtDownloadDirectory = New Telerik.WinControls.UI.RadTextBox()
        Me.RadLabel13 = New Telerik.WinControls.UI.RadLabel()
        Me.chkPopupDownloadManager = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkAutoIgnoreExceptNotify = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkAutoCloseDialogs = New Telerik.WinControls.UI.RadCheckBox()
        Me.cboDCCFileExists = New Telerik.WinControls.UI.RadDropDownList()
        Me.RadLabel12 = New Telerik.WinControls.UI.RadLabel()
        Me.cmdNetworkSettings = New Telerik.WinControls.UI.RadButton()
        Me.RadLabel10 = New Telerik.WinControls.UI.RadLabel()
        Me.RadPanel3 = New Telerik.WinControls.UI.RadPanel()
        Me.optDccSendAcceptAll = New Telerik.WinControls.UI.RadRadioButton()
        Me.optDccSendIgnore = New Telerik.WinControls.UI.RadRadioButton()
        Me.optDccSendPrompt = New Telerik.WinControls.UI.RadRadioButton()
        Me.RadLabel11 = New Telerik.WinControls.UI.RadLabel()
        Me.RadPanel4 = New Telerik.WinControls.UI.RadPanel()
        Me.optDccChatAcceptAll = New Telerik.WinControls.UI.RadRadioButton()
        Me.optDccChatIgnore = New Telerik.WinControls.UI.RadRadioButton()
        Me.optDccChatPrompt = New Telerik.WinControls.UI.RadRadioButton()
        Me.chkNewStatus = New Telerik.WinControls.UI.RadCheckBox()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.tmrCloseMe = New System.Windows.Forms.Timer(Me.components)
        Me.cmdApplyNow = New Telerik.WinControls.UI.RadButton()
        Me.cmdOK = New Telerik.WinControls.UI.RadButton()
        Me.cmdConnectNow = New Telerik.WinControls.UI.RadButton()
        Me.cmdCancelNow = New Telerik.WinControls.UI.RadButton()
        Me.Office2010BlackTheme1 = New Telerik.WinControls.Themes.Office2010BlackTheme()
        CType(Me.RadPageView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPageView1.SuspendLayout()
        Me.RadPageViewPage1.SuspendLayout()
        CType(Me.lvwServers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboNetworks, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdServersMove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdServersClear, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdServerAdd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdServerDelete, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdServerEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPageViewPage2.SuspendLayout()
        CType(Me.chkIdentdEnabled, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIdentdPort, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblIdentdPort, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIdentdSystem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIdentdUserID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOperPassword, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOperName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPassword, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRealName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUserEmail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboMyNickNames, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdClearMyNickName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdRemoveMyNickName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdAddMyNickName, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPageViewPage3.SuspendLayout()
        CType(Me.RadPageView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPageView2.SuspendLayout()
        Me.RadPageViewPage7.SuspendLayout()
        CType(Me.chkAutoSelectAlternateNickname, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTextBufferSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkShowRawWindow, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkMOTDInOwnWindow, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkNoticesInOwnWindow, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkShowPrompts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkShowWindowsAutomatically, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkCloseStatusWindow, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkAddToChannelFolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkCloseChannelFolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkShowNicknameWindow, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkAutoMaximize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkPopupChannelFolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkVideoBackground, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPageViewPage8.SuspendLayout()
        CType(Me.chkAutoConnect, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkShowCustomize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPageViewPage9.SuspendLayout()
        CType(Me.chkInvisible, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkWallops, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkRestricted, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkOperator, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkLocalOp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkServerNotices, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPageViewPage10.SuspendLayout()
        CType(Me.chkNoIRCMessages, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdQuerySettings, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkExtendedMessages, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkShowUserAddresses, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkHideMOTDs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPageViewPage4.SuspendLayout()
        CType(Me.cmdNotifyClear, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdNotifyRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdNotifyAdd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboNetworkNotify, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNotifyMessage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNotifyNickname, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lvwNotify, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPageViewPage5.SuspendLayout()
        CType(Me.cmdCompatibilityDisable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdCompatibilityEnable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lvwCompatibility, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdEditString, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPanel2.SuspendLayout()
        CType(Me.rdbUnsupportedOwn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rdbUnsupportedHide, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rdbUnsupportedStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPanel1.SuspendLayout()
        CType(Me.rdbUnknownTextOwn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rdbUnknownTextHide, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rdbUnknownTextStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lvwStrings, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPageViewPage6.SuspendLayout()
        CType(Me.cmdDCCIgnoreRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdDCCIgnoreAdd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lstDCCIgnoreItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdRemoveIgnoreExtension, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdAddIgnoreExtension, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lstIgnoreExtensions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDownloadDirectory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkPopupDownloadManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkAutoIgnoreExceptNotify, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkAutoCloseDialogs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDCCFileExists, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdNetworkSettings, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPanel3.SuspendLayout()
        CType(Me.optDccSendAcceptAll, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optDccSendIgnore, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optDccSendPrompt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadPanel4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPanel4.SuspendLayout()
        CType(Me.optDccChatAcceptAll, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optDccChatIgnore, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optDccChatPrompt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkNewStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdApplyNow, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdOK, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdConnectNow, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdCancelNow, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RadPageView1
        '
        Me.RadPageView1.Controls.Add(Me.RadPageViewPage1)
        Me.RadPageView1.Controls.Add(Me.RadPageViewPage2)
        Me.RadPageView1.Controls.Add(Me.RadPageViewPage3)
        Me.RadPageView1.Controls.Add(Me.RadPageViewPage4)
        Me.RadPageView1.Controls.Add(Me.RadPageViewPage5)
        Me.RadPageView1.Controls.Add(Me.RadPageViewPage6)
        Me.RadPageView1.Location = New System.Drawing.Point(0, 1)
        Me.RadPageView1.Name = "RadPageView1"
        Me.RadPageView1.SelectedPage = Me.RadPageViewPage1
        Me.RadPageView1.Size = New System.Drawing.Size(542, 381)
        Me.RadPageView1.TabIndex = 31
        Me.RadPageView1.Text = "RadPageView1"
        Me.RadPageView1.ThemeName = "Office2010Black"
        '
        'RadPageViewPage1
        '
        Me.RadPageViewPage1.Controls.Add(Me.lvwServers)
        Me.RadPageViewPage1.Controls.Add(Me.cboNetworks)
        Me.RadPageViewPage1.Controls.Add(Me.cmdServersMove)
        Me.RadPageViewPage1.Controls.Add(Me.cmdServersClear)
        Me.RadPageViewPage1.Controls.Add(Me.cmdServerAdd)
        Me.RadPageViewPage1.Controls.Add(Me.lnkNetworkAdd)
        Me.RadPageViewPage1.Controls.Add(Me.cmdServerDelete)
        Me.RadPageViewPage1.Controls.Add(Me.lnkNetworkDelete)
        Me.RadPageViewPage1.Controls.Add(Me.cmdServerEdit)
        Me.RadPageViewPage1.Image = Global.nexIRC.My.Resources.Resources.web
        Me.RadPageViewPage1.Location = New System.Drawing.Point(12, 40)
        Me.RadPageViewPage1.Name = "RadPageViewPage1"
        Me.RadPageViewPage1.Size = New System.Drawing.Size(518, 329)
        Me.RadPageViewPage1.Text = "Network"
        '
        'lvwServers
        '
        Me.lvwServers.AllowEdit = False
        ListViewDetailColumn1.HeaderText = "Description"
        ListViewDetailColumn1.Width = 300.0!
        ListViewDetailColumn2.HeaderText = "Server"
        ListViewDetailColumn2.Width = 75.0!
        ListViewDetailColumn3.HeaderText = "Port"
        ListViewDetailColumn3.Width = 75.0!
        Me.lvwServers.Columns.AddRange(New Telerik.WinControls.UI.ListViewDetailColumn() {ListViewDetailColumn1, ListViewDetailColumn2, ListViewDetailColumn3})
        Me.lvwServers.EnableColumnSort = True
        Me.lvwServers.GroupItemSize = New System.Drawing.Size(200, 20)
        Me.lvwServers.ItemSize = New System.Drawing.Size(200, 20)
        Me.lvwServers.ItemSpacing = -1
        Me.lvwServers.Location = New System.Drawing.Point(3, 29)
        Me.lvwServers.MultiSelect = True
        Me.lvwServers.Name = "lvwServers"
        Me.lvwServers.Size = New System.Drawing.Size(516, 265)
        Me.lvwServers.TabIndex = 23
        Me.lvwServers.ThemeName = "Office2010Black"
        Me.lvwServers.ViewType = Telerik.WinControls.UI.ListViewType.DetailsView
        '
        'cboNetworks
        '
        Me.cboNetworks.DropDownAnimationEnabled = True
        Me.cboNetworks.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        Me.cboNetworks.Location = New System.Drawing.Point(3, 3)
        Me.cboNetworks.Name = "cboNetworks"
        Me.cboNetworks.ShowImageInEditorArea = True
        Me.cboNetworks.Size = New System.Drawing.Size(436, 20)
        Me.cboNetworks.TabIndex = 22
        Me.cboNetworks.ThemeName = "Office2010Black"
        '
        'cmdServersMove
        '
        Me.cmdServersMove.Image = Global.nexIRC.My.Resources.Resources.add1
        Me.cmdServersMove.Location = New System.Drawing.Point(377, 300)
        Me.cmdServersMove.Name = "cmdServersMove"
        Me.cmdServersMove.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        '
        '
        '
        Me.cmdServersMove.RootElement.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.cmdServersMove.Size = New System.Drawing.Size(67, 29)
        Me.cmdServersMove.TabIndex = 19
        Me.cmdServersMove.Text = "&Move"
        Me.cmdServersMove.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdServersMove.ThemeName = "Office2010Black"
        '
        'cmdServersClear
        '
        Me.cmdServersClear.Image = Global.nexIRC.My.Resources.Resources.close
        Me.cmdServersClear.Location = New System.Drawing.Point(452, 300)
        Me.cmdServersClear.Name = "cmdServersClear"
        Me.cmdServersClear.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        '
        '
        '
        Me.cmdServersClear.RootElement.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.cmdServersClear.Size = New System.Drawing.Size(67, 29)
        Me.cmdServersClear.TabIndex = 19
        Me.cmdServersClear.Text = "C&lear"
        Me.cmdServersClear.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdServersClear.ThemeName = "Office2010Black"
        '
        'cmdServerAdd
        '
        Me.cmdServerAdd.Image = Global.nexIRC.My.Resources.Resources.add
        Me.cmdServerAdd.Location = New System.Drawing.Point(3, 300)
        Me.cmdServerAdd.Name = "cmdServerAdd"
        Me.cmdServerAdd.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        '
        '
        '
        Me.cmdServerAdd.RootElement.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.cmdServerAdd.Size = New System.Drawing.Size(67, 29)
        Me.cmdServerAdd.TabIndex = 20
        Me.cmdServerAdd.Text = "&Add"
        Me.cmdServerAdd.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdServerAdd.ThemeName = "Office2010Black"
        '
        'lnkNetworkAdd
        '
        Me.lnkNetworkAdd.AutoSize = True
        Me.lnkNetworkAdd.Location = New System.Drawing.Point(449, 8)
        Me.lnkNetworkAdd.Name = "lnkNetworkAdd"
        Me.lnkNetworkAdd.Size = New System.Drawing.Size(28, 13)
        Me.lnkNetworkAdd.TabIndex = 16
        Me.lnkNetworkAdd.TabStop = True
        Me.lnkNetworkAdd.Text = "Add"
        '
        'cmdServerDelete
        '
        Me.cmdServerDelete.Image = Global.nexIRC.My.Resources.Resources.delete
        Me.cmdServerDelete.Location = New System.Drawing.Point(76, 300)
        Me.cmdServerDelete.Name = "cmdServerDelete"
        Me.cmdServerDelete.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        '
        '
        '
        Me.cmdServerDelete.RootElement.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.cmdServerDelete.Size = New System.Drawing.Size(67, 29)
        Me.cmdServerDelete.TabIndex = 19
        Me.cmdServerDelete.Text = "&Delete"
        Me.cmdServerDelete.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdServerDelete.ThemeName = "Office2010Black"
        '
        'lnkNetworkDelete
        '
        Me.lnkNetworkDelete.AutoSize = True
        Me.lnkNetworkDelete.Location = New System.Drawing.Point(481, 8)
        Me.lnkNetworkDelete.Name = "lnkNetworkDelete"
        Me.lnkNetworkDelete.Size = New System.Drawing.Size(40, 13)
        Me.lnkNetworkDelete.TabIndex = 17
        Me.lnkNetworkDelete.TabStop = True
        Me.lnkNetworkDelete.Text = "Delete"
        '
        'cmdServerEdit
        '
        Me.cmdServerEdit.Image = Global.nexIRC.My.Resources.Resources.configure
        Me.cmdServerEdit.Location = New System.Drawing.Point(149, 300)
        Me.cmdServerEdit.Name = "cmdServerEdit"
        Me.cmdServerEdit.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        '
        '
        '
        Me.cmdServerEdit.RootElement.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.cmdServerEdit.Size = New System.Drawing.Size(67, 29)
        Me.cmdServerEdit.TabIndex = 18
        Me.cmdServerEdit.Text = "&Edit"
        Me.cmdServerEdit.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdServerEdit.ThemeName = "Office2010Black"
        '
        'RadPageViewPage2
        '
        Me.RadPageViewPage2.Controls.Add(Me.chkIdentdEnabled)
        Me.RadPageViewPage2.Controls.Add(Me.txtIdentdPort)
        Me.RadPageViewPage2.Controls.Add(Me.lblIdentdPort)
        Me.RadPageViewPage2.Controls.Add(Me.txtIdentdSystem)
        Me.RadPageViewPage2.Controls.Add(Me.RadLabel20)
        Me.RadPageViewPage2.Controls.Add(Me.txtIdentdUserID)
        Me.RadPageViewPage2.Controls.Add(Me.RadLabel2)
        Me.RadPageViewPage2.Controls.Add(Me.txtOperPassword)
        Me.RadPageViewPage2.Controls.Add(Me.txtOperName)
        Me.RadPageViewPage2.Controls.Add(Me.RadLabel19)
        Me.RadPageViewPage2.Controls.Add(Me.txtPassword)
        Me.RadPageViewPage2.Controls.Add(Me.RadLabel18)
        Me.RadPageViewPage2.Controls.Add(Me.txtRealName)
        Me.RadPageViewPage2.Controls.Add(Me.RadLabel17)
        Me.RadPageViewPage2.Controls.Add(Me.txtUserEmail)
        Me.RadPageViewPage2.Controls.Add(Me.RadLabel16)
        Me.RadPageViewPage2.Controls.Add(Me.RadLabel3)
        Me.RadPageViewPage2.Controls.Add(Me.cboMyNickNames)
        Me.RadPageViewPage2.Controls.Add(Me.cmdClearMyNickName)
        Me.RadPageViewPage2.Controls.Add(Me.cmdRemoveMyNickName)
        Me.RadPageViewPage2.Controls.Add(Me.cmdAddMyNickName)
        Me.RadPageViewPage2.Image = Global.nexIRC.My.Resources.Resources.tools
        Me.RadPageViewPage2.Location = New System.Drawing.Point(12, 40)
        Me.RadPageViewPage2.Name = "RadPageViewPage2"
        Me.RadPageViewPage2.Size = New System.Drawing.Size(518, 329)
        Me.RadPageViewPage2.Text = "User"
        '
        'chkIdentdEnabled
        '
        Me.chkIdentdEnabled.BackColor = System.Drawing.Color.Transparent
        Me.chkIdentdEnabled.Location = New System.Drawing.Point(140, 137)
        Me.chkIdentdEnabled.Name = "chkIdentdEnabled"
        Me.chkIdentdEnabled.Size = New System.Drawing.Size(96, 18)
        Me.chkIdentdEnabled.TabIndex = 82
        Me.chkIdentdEnabled.Text = "Identd Enabled"
        Me.chkIdentdEnabled.ThemeName = "Office2010Black"
        '
        'txtIdentdPort
        '
        Me.txtIdentdPort.Location = New System.Drawing.Point(140, 111)
        Me.txtIdentdPort.Name = "txtIdentdPort"
        Me.txtIdentdPort.Size = New System.Drawing.Size(375, 20)
        Me.txtIdentdPort.TabIndex = 80
        Me.txtIdentdPort.TabStop = False
        Me.txtIdentdPort.ThemeName = "Office2010Black"
        '
        'lblIdentdPort
        '
        Me.lblIdentdPort.BackColor = System.Drawing.Color.Transparent
        Me.lblIdentdPort.Location = New System.Drawing.Point(7, 113)
        Me.lblIdentdPort.Name = "lblIdentdPort"
        Me.lblIdentdPort.Size = New System.Drawing.Size(65, 18)
        Me.lblIdentdPort.TabIndex = 81
        Me.lblIdentdPort.Text = "Identd Port:"
        Me.lblIdentdPort.ThemeName = "Office2010Black"
        '
        'txtIdentdSystem
        '
        Me.txtIdentdSystem.Location = New System.Drawing.Point(140, 85)
        Me.txtIdentdSystem.Name = "txtIdentdSystem"
        Me.txtIdentdSystem.Size = New System.Drawing.Size(375, 20)
        Me.txtIdentdSystem.TabIndex = 78
        Me.txtIdentdSystem.TabStop = False
        Me.txtIdentdSystem.ThemeName = "Office2010Black"
        '
        'RadLabel20
        '
        Me.RadLabel20.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel20.Location = New System.Drawing.Point(7, 87)
        Me.RadLabel20.Name = "RadLabel20"
        Me.RadLabel20.Size = New System.Drawing.Size(80, 18)
        Me.RadLabel20.TabIndex = 79
        Me.RadLabel20.Text = "Identd System:"
        Me.RadLabel20.ThemeName = "Office2010Black"
        '
        'txtIdentdUserID
        '
        Me.txtIdentdUserID.Location = New System.Drawing.Point(140, 59)
        Me.txtIdentdUserID.Name = "txtIdentdUserID"
        Me.txtIdentdUserID.Size = New System.Drawing.Size(375, 20)
        Me.txtIdentdUserID.TabIndex = 76
        Me.txtIdentdUserID.TabStop = False
        Me.txtIdentdUserID.ThemeName = "Office2010Black"
        '
        'RadLabel2
        '
        Me.RadLabel2.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel2.Location = New System.Drawing.Point(7, 61)
        Me.RadLabel2.Name = "RadLabel2"
        Me.RadLabel2.Size = New System.Drawing.Size(76, 18)
        Me.RadLabel2.TabIndex = 77
        Me.RadLabel2.Text = "Identd UserId:"
        Me.RadLabel2.ThemeName = "Office2010Black"
        '
        'txtOperPassword
        '
        Me.txtOperPassword.BackColor = System.Drawing.Color.Transparent
        Me.txtOperPassword.Location = New System.Drawing.Point(349, 239)
        Me.txtOperPassword.Name = "txtOperPassword"
        Me.txtOperPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtOperPassword.Size = New System.Drawing.Size(166, 24)
        Me.txtOperPassword.TabIndex = 75
        Me.txtOperPassword.TabStop = False
        Me.txtOperPassword.ThemeName = "Office2010Black"
        Me.txtOperPassword.UseGenericBorderPaint = True
        '
        'txtOperName
        '
        Me.txtOperName.BackColor = System.Drawing.Color.Transparent
        Me.txtOperName.Location = New System.Drawing.Point(140, 239)
        Me.txtOperName.Name = "txtOperName"
        Me.txtOperName.Size = New System.Drawing.Size(203, 24)
        Me.txtOperName.TabIndex = 73
        Me.txtOperName.TabStop = False
        Me.txtOperName.ThemeName = "Office2010Black"
        Me.txtOperName.UseGenericBorderPaint = True
        '
        'RadLabel19
        '
        Me.RadLabel19.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel19.Location = New System.Drawing.Point(7, 241)
        Me.RadLabel19.Name = "RadLabel19"
        Me.RadLabel19.Size = New System.Drawing.Size(111, 18)
        Me.RadLabel19.TabIndex = 74
        Me.RadLabel19.Text = "Oper User/Password:"
        Me.RadLabel19.ThemeName = "Office2010Black"
        '
        'txtPassword
        '
        Me.txtPassword.BackColor = System.Drawing.Color.Transparent
        Me.txtPassword.Location = New System.Drawing.Point(140, 213)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(375, 24)
        Me.txtPassword.TabIndex = 71
        Me.txtPassword.TabStop = False
        Me.txtPassword.ThemeName = "Office2010Black"
        Me.txtPassword.UseGenericBorderPaint = True
        '
        'RadLabel18
        '
        Me.RadLabel18.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel18.Location = New System.Drawing.Point(7, 215)
        Me.RadLabel18.Name = "RadLabel18"
        Me.RadLabel18.Size = New System.Drawing.Size(56, 18)
        Me.RadLabel18.TabIndex = 72
        Me.RadLabel18.Text = "Password:"
        Me.RadLabel18.ThemeName = "Office2010Black"
        '
        'txtRealName
        '
        Me.txtRealName.BackColor = System.Drawing.Color.Transparent
        Me.txtRealName.Location = New System.Drawing.Point(140, 187)
        Me.txtRealName.Name = "txtRealName"
        Me.txtRealName.Size = New System.Drawing.Size(375, 24)
        Me.txtRealName.TabIndex = 69
        Me.txtRealName.TabStop = False
        Me.txtRealName.ThemeName = "Office2010Black"
        Me.txtRealName.UseGenericBorderPaint = True
        '
        'RadLabel17
        '
        Me.RadLabel17.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel17.Location = New System.Drawing.Point(7, 189)
        Me.RadLabel17.Name = "RadLabel17"
        Me.RadLabel17.Size = New System.Drawing.Size(63, 18)
        Me.RadLabel17.TabIndex = 70
        Me.RadLabel17.Text = "Real Name:"
        Me.RadLabel17.ThemeName = "Office2010Black"
        '
        'txtUserEmail
        '
        Me.txtUserEmail.BackColor = System.Drawing.Color.Transparent
        Me.txtUserEmail.Location = New System.Drawing.Point(140, 161)
        Me.txtUserEmail.Name = "txtUserEmail"
        Me.txtUserEmail.Size = New System.Drawing.Size(375, 24)
        Me.txtUserEmail.TabIndex = 67
        Me.txtUserEmail.TabStop = False
        Me.txtUserEmail.ThemeName = "Office2010Black"
        Me.txtUserEmail.UseGenericBorderPaint = True
        '
        'RadLabel16
        '
        Me.RadLabel16.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel16.Location = New System.Drawing.Point(7, 163)
        Me.RadLabel16.Name = "RadLabel16"
        Me.RadLabel16.Size = New System.Drawing.Size(40, 18)
        Me.RadLabel16.TabIndex = 68
        Me.RadLabel16.Text = "E-mail:"
        Me.RadLabel16.ThemeName = "Office2010Black"
        '
        'RadLabel3
        '
        Me.RadLabel3.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel3.Location = New System.Drawing.Point(7, 5)
        Me.RadLabel3.Name = "RadLabel3"
        Me.RadLabel3.Size = New System.Drawing.Size(59, 18)
        Me.RadLabel3.TabIndex = 66
        Me.RadLabel3.Text = "Nickname:"
        Me.RadLabel3.ThemeName = "Office2010Black"
        '
        'cboMyNickNames
        '
        Me.cboMyNickNames.DropDownAnimationEnabled = True
        Me.cboMyNickNames.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        Me.cboMyNickNames.Location = New System.Drawing.Point(140, 3)
        Me.cboMyNickNames.Name = "cboMyNickNames"
        Me.cboMyNickNames.ShowImageInEditorArea = True
        Me.cboMyNickNames.Size = New System.Drawing.Size(375, 20)
        Me.cboMyNickNames.TabIndex = 62
        Me.cboMyNickNames.ThemeName = "Office2010Black"
        '
        'cmdClearMyNickName
        '
        Me.cmdClearMyNickName.Location = New System.Drawing.Point(394, 29)
        Me.cmdClearMyNickName.Name = "cmdClearMyNickName"
        Me.cmdClearMyNickName.Size = New System.Drawing.Size(121, 24)
        Me.cmdClearMyNickName.TabIndex = 61
        Me.cmdClearMyNickName.Text = "Clear"
        Me.cmdClearMyNickName.ThemeName = "Office2010Black"
        '
        'cmdRemoveMyNickName
        '
        Me.cmdRemoveMyNickName.Location = New System.Drawing.Point(267, 29)
        Me.cmdRemoveMyNickName.Name = "cmdRemoveMyNickName"
        Me.cmdRemoveMyNickName.Size = New System.Drawing.Size(121, 24)
        Me.cmdRemoveMyNickName.TabIndex = 60
        Me.cmdRemoveMyNickName.Text = "Remove"
        Me.cmdRemoveMyNickName.ThemeName = "Office2010Black"
        '
        'cmdAddMyNickName
        '
        Me.cmdAddMyNickName.Location = New System.Drawing.Point(140, 29)
        Me.cmdAddMyNickName.Name = "cmdAddMyNickName"
        Me.cmdAddMyNickName.Size = New System.Drawing.Size(121, 24)
        Me.cmdAddMyNickName.TabIndex = 59
        Me.cmdAddMyNickName.Text = "Add"
        Me.cmdAddMyNickName.ThemeName = "Office2010Black"
        '
        'RadPageViewPage3
        '
        Me.RadPageViewPage3.Controls.Add(Me.RadPageView2)
        Me.RadPageViewPage3.Controls.Add(Me.RadLabel5)
        Me.RadPageViewPage3.Image = Global.nexIRC.My.Resources.Resources.applications
        Me.RadPageViewPage3.Location = New System.Drawing.Point(12, 40)
        Me.RadPageViewPage3.Name = "RadPageViewPage3"
        Me.RadPageViewPage3.Size = New System.Drawing.Size(518, 329)
        Me.RadPageViewPage3.Text = "Settings"
        '
        'RadPageView2
        '
        Me.RadPageView2.Controls.Add(Me.RadPageViewPage7)
        Me.RadPageView2.Controls.Add(Me.RadPageViewPage8)
        Me.RadPageView2.Controls.Add(Me.RadPageViewPage9)
        Me.RadPageView2.Controls.Add(Me.RadPageViewPage10)
        Me.RadPageView2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadPageView2.Location = New System.Drawing.Point(0, 0)
        Me.RadPageView2.Name = "RadPageView2"
        Me.RadPageView2.SelectedPage = Me.RadPageViewPage7
        Me.RadPageView2.Size = New System.Drawing.Size(518, 329)
        Me.RadPageView2.TabIndex = 66
        Me.RadPageView2.Text = "RadPageView2"
        Me.RadPageView2.ThemeName = "Office2010Black"
        '
        'RadPageViewPage7
        '
        Me.RadPageViewPage7.Controls.Add(Me.chkAutoSelectAlternateNickname)
        Me.RadPageViewPage7.Controls.Add(Me.txtTextBufferSize)
        Me.RadPageViewPage7.Controls.Add(Me.Label1)
        Me.RadPageViewPage7.Controls.Add(Me.chkShowRawWindow)
        Me.RadPageViewPage7.Controls.Add(Me.chkMOTDInOwnWindow)
        Me.RadPageViewPage7.Controls.Add(Me.chkNoticesInOwnWindow)
        Me.RadPageViewPage7.Controls.Add(Me.chkShowPrompts)
        Me.RadPageViewPage7.Controls.Add(Me.chkShowWindowsAutomatically)
        Me.RadPageViewPage7.Controls.Add(Me.chkCloseStatusWindow)
        Me.RadPageViewPage7.Controls.Add(Me.chkAddToChannelFolder)
        Me.RadPageViewPage7.Controls.Add(Me.chkCloseChannelFolder)
        Me.RadPageViewPage7.Controls.Add(Me.chkShowNicknameWindow)
        Me.RadPageViewPage7.Controls.Add(Me.chkAutoMaximize)
        Me.RadPageViewPage7.Controls.Add(Me.chkPopupChannelFolder)
        Me.RadPageViewPage7.Controls.Add(Me.chkVideoBackground)
        Me.RadPageViewPage7.Location = New System.Drawing.Point(12, 40)
        Me.RadPageViewPage7.Name = "RadPageViewPage7"
        Me.RadPageViewPage7.Size = New System.Drawing.Size(494, 277)
        Me.RadPageViewPage7.Text = "Interface"
        '
        'chkAutoSelectAlternateNickname
        '
        Me.chkAutoSelectAlternateNickname.BackColor = System.Drawing.Color.Transparent
        Me.chkAutoSelectAlternateNickname.Location = New System.Drawing.Point(166, 51)
        Me.chkAutoSelectAlternateNickname.Name = "chkAutoSelectAlternateNickname"
        Me.chkAutoSelectAlternateNickname.Size = New System.Drawing.Size(179, 18)
        Me.chkAutoSelectAlternateNickname.TabIndex = 63
        Me.chkAutoSelectAlternateNickname.Text = "Auto Select Alternate Nickname"
        Me.chkAutoSelectAlternateNickname.ThemeName = "Office2010Black"
        '
        'txtTextBufferSize
        '
        Me.txtTextBufferSize.BackColor = System.Drawing.Color.Transparent
        Me.txtTextBufferSize.Location = New System.Drawing.Point(237, 3)
        Me.txtTextBufferSize.Name = "txtTextBufferSize"
        Me.txtTextBufferSize.Size = New System.Drawing.Size(100, 20)
        Me.txtTextBufferSize.TabIndex = 70
        Me.txtTextBufferSize.TabStop = False
        Me.txtTextBufferSize.ThemeName = "Office2010Black"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(163, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 69
        Me.Label1.Text = "Text Buffer:"
        '
        'chkShowRawWindow
        '
        Me.chkShowRawWindow.BackColor = System.Drawing.Color.Transparent
        Me.chkShowRawWindow.Location = New System.Drawing.Point(3, 194)
        Me.chkShowRawWindow.Name = "chkShowRawWindow"
        Me.chkShowRawWindow.Size = New System.Drawing.Size(124, 18)
        Me.chkShowRawWindow.TabIndex = 68
        Me.chkShowRawWindow.Text = "Raw in Own Window"
        Me.chkShowRawWindow.ThemeName = "Office2010Black"
        '
        'chkMOTDInOwnWindow
        '
        Me.chkMOTDInOwnWindow.BackColor = System.Drawing.Color.Transparent
        Me.chkMOTDInOwnWindow.Location = New System.Drawing.Point(3, 218)
        Me.chkMOTDInOwnWindow.Name = "chkMOTDInOwnWindow"
        Me.chkMOTDInOwnWindow.Size = New System.Drawing.Size(130, 18)
        Me.chkMOTDInOwnWindow.TabIndex = 67
        Me.chkMOTDInOwnWindow.Text = "Motd in Own Window"
        Me.chkMOTDInOwnWindow.ThemeName = "Office2010Black"
        '
        'chkNoticesInOwnWindow
        '
        Me.chkNoticesInOwnWindow.BackColor = System.Drawing.Color.Transparent
        Me.chkNoticesInOwnWindow.Location = New System.Drawing.Point(3, 242)
        Me.chkNoticesInOwnWindow.Name = "chkNoticesInOwnWindow"
        Me.chkNoticesInOwnWindow.Size = New System.Drawing.Size(141, 18)
        Me.chkNoticesInOwnWindow.TabIndex = 66
        Me.chkNoticesInOwnWindow.Text = "Notices in Own Window"
        Me.chkNoticesInOwnWindow.ThemeName = "Office2010Black"
        '
        'chkShowPrompts
        '
        Me.chkShowPrompts.BackColor = System.Drawing.Color.Transparent
        Me.chkShowPrompts.Location = New System.Drawing.Point(3, 3)
        Me.chkShowPrompts.Name = "chkShowPrompts"
        Me.chkShowPrompts.Size = New System.Drawing.Size(93, 18)
        Me.chkShowPrompts.TabIndex = 55
        Me.chkShowPrompts.Text = "Show Prompts"
        Me.chkShowPrompts.ThemeName = "Office2010Black"
        '
        'chkShowWindowsAutomatically
        '
        Me.chkShowWindowsAutomatically.BackColor = System.Drawing.Color.Transparent
        Me.chkShowWindowsAutomatically.Location = New System.Drawing.Point(3, 27)
        Me.chkShowWindowsAutomatically.Name = "chkShowWindowsAutomatically"
        Me.chkShowWindowsAutomatically.Size = New System.Drawing.Size(124, 18)
        Me.chkShowWindowsAutomatically.TabIndex = 56
        Me.chkShowWindowsAutomatically.Text = "Auto Show Windows"
        Me.chkShowWindowsAutomatically.ThemeName = "Office2010Black"
        '
        'chkCloseStatusWindow
        '
        Me.chkCloseStatusWindow.BackColor = System.Drawing.Color.Transparent
        Me.chkCloseStatusWindow.Location = New System.Drawing.Point(166, 75)
        Me.chkCloseStatusWindow.Name = "chkCloseStatusWindow"
        Me.chkCloseStatusWindow.Size = New System.Drawing.Size(125, 18)
        Me.chkCloseStatusWindow.TabIndex = 62
        Me.chkCloseStatusWindow.Text = "Close Status Window"
        Me.chkCloseStatusWindow.ThemeName = "Office2010Black"
        '
        'chkAddToChannelFolder
        '
        Me.chkAddToChannelFolder.BackColor = System.Drawing.Color.Transparent
        Me.chkAddToChannelFolder.Location = New System.Drawing.Point(3, 170)
        Me.chkAddToChannelFolder.Name = "chkAddToChannelFolder"
        Me.chkAddToChannelFolder.Size = New System.Drawing.Size(133, 18)
        Me.chkAddToChannelFolder.TabIndex = 62
        Me.chkAddToChannelFolder.Text = "Add to Channel Folder"
        Me.chkAddToChannelFolder.ThemeName = "Office2010Black"
        '
        'chkCloseChannelFolder
        '
        Me.chkCloseChannelFolder.BackColor = System.Drawing.Color.Transparent
        Me.chkCloseChannelFolder.Location = New System.Drawing.Point(3, 147)
        Me.chkCloseChannelFolder.Name = "chkCloseChannelFolder"
        Me.chkCloseChannelFolder.Size = New System.Drawing.Size(126, 18)
        Me.chkCloseChannelFolder.TabIndex = 62
        Me.chkCloseChannelFolder.Text = "Close Channel Folder"
        Me.chkCloseChannelFolder.ThemeName = "Office2010Black"
        '
        'chkShowNicknameWindow
        '
        Me.chkShowNicknameWindow.BackColor = System.Drawing.Color.Transparent
        Me.chkShowNicknameWindow.Location = New System.Drawing.Point(3, 123)
        Me.chkShowNicknameWindow.Name = "chkShowNicknameWindow"
        Me.chkShowNicknameWindow.Size = New System.Drawing.Size(145, 18)
        Me.chkShowNicknameWindow.TabIndex = 62
        Me.chkShowNicknameWindow.Text = "Show Nickname Window"
        Me.chkShowNicknameWindow.ThemeName = "Office2010Black"
        '
        'chkAutoMaximize
        '
        Me.chkAutoMaximize.BackColor = System.Drawing.Color.Transparent
        Me.chkAutoMaximize.Location = New System.Drawing.Point(3, 51)
        Me.chkAutoMaximize.Name = "chkAutoMaximize"
        Me.chkAutoMaximize.Size = New System.Drawing.Size(95, 18)
        Me.chkAutoMaximize.TabIndex = 59
        Me.chkAutoMaximize.Text = "Auto Maximize"
        Me.chkAutoMaximize.ThemeName = "Office2010Black"
        '
        'chkPopupChannelFolder
        '
        Me.chkPopupChannelFolder.BackColor = System.Drawing.Color.Transparent
        Me.chkPopupChannelFolder.Location = New System.Drawing.Point(3, 75)
        Me.chkPopupChannelFolder.Name = "chkPopupChannelFolder"
        Me.chkPopupChannelFolder.Size = New System.Drawing.Size(127, 18)
        Me.chkPopupChannelFolder.TabIndex = 60
        Me.chkPopupChannelFolder.Text = "Popup channel folder"
        Me.chkPopupChannelFolder.ThemeName = "Office2010Black"
        '
        'chkVideoBackground
        '
        Me.chkVideoBackground.BackColor = System.Drawing.Color.Transparent
        Me.chkVideoBackground.Location = New System.Drawing.Point(3, 99)
        Me.chkVideoBackground.Name = "chkVideoBackground"
        Me.chkVideoBackground.Size = New System.Drawing.Size(112, 18)
        Me.chkVideoBackground.TabIndex = 62
        Me.chkVideoBackground.Text = "Video Background"
        Me.chkVideoBackground.ThemeName = "Office2010Black"
        '
        'RadPageViewPage8
        '
        Me.RadPageViewPage8.Controls.Add(Me.chkAutoConnect)
        Me.RadPageViewPage8.Controls.Add(Me.chkShowCustomize)
        Me.RadPageViewPage8.Location = New System.Drawing.Point(12, 40)
        Me.RadPageViewPage8.Name = "RadPageViewPage8"
        Me.RadPageViewPage8.Size = New System.Drawing.Size(494, 277)
        Me.RadPageViewPage8.Text = "On Startup"
        '
        'chkAutoConnect
        '
        Me.chkAutoConnect.BackColor = System.Drawing.Color.Transparent
        Me.chkAutoConnect.Location = New System.Drawing.Point(3, 3)
        Me.chkAutoConnect.Name = "chkAutoConnect"
        Me.chkAutoConnect.Size = New System.Drawing.Size(89, 18)
        Me.chkAutoConnect.TabIndex = 59
        Me.chkAutoConnect.Text = "Auto Connect"
        Me.chkAutoConnect.ThemeName = "Office2010Black"
        '
        'chkShowCustomize
        '
        Me.chkShowCustomize.BackColor = System.Drawing.Color.Transparent
        Me.chkShowCustomize.Location = New System.Drawing.Point(3, 27)
        Me.chkShowCustomize.Name = "chkShowCustomize"
        Me.chkShowCustomize.Size = New System.Drawing.Size(103, 18)
        Me.chkShowCustomize.TabIndex = 60
        Me.chkShowCustomize.Text = "Show Customize"
        Me.chkShowCustomize.ThemeName = "Office2010Black"
        '
        'RadPageViewPage9
        '
        Me.RadPageViewPage9.Controls.Add(Me.chkInvisible)
        Me.RadPageViewPage9.Controls.Add(Me.chkWallops)
        Me.RadPageViewPage9.Controls.Add(Me.chkRestricted)
        Me.RadPageViewPage9.Controls.Add(Me.chkOperator)
        Me.RadPageViewPage9.Controls.Add(Me.chkLocalOp)
        Me.RadPageViewPage9.Controls.Add(Me.chkServerNotices)
        Me.RadPageViewPage9.Location = New System.Drawing.Point(12, 40)
        Me.RadPageViewPage9.Name = "RadPageViewPage9"
        Me.RadPageViewPage9.Size = New System.Drawing.Size(494, 277)
        Me.RadPageViewPage9.Text = "Server Modes"
        '
        'chkInvisible
        '
        Me.chkInvisible.BackColor = System.Drawing.Color.Transparent
        Me.chkInvisible.Location = New System.Drawing.Point(3, 3)
        Me.chkInvisible.Name = "chkInvisible"
        Me.chkInvisible.Size = New System.Drawing.Size(61, 18)
        Me.chkInvisible.TabIndex = 51
        Me.chkInvisible.Text = "Invisible"
        Me.chkInvisible.ThemeName = "Office2010Black"
        '
        'chkWallops
        '
        Me.chkWallops.BackColor = System.Drawing.Color.Transparent
        Me.chkWallops.Location = New System.Drawing.Point(3, 27)
        Me.chkWallops.Name = "chkWallops"
        Me.chkWallops.Size = New System.Drawing.Size(60, 18)
        Me.chkWallops.TabIndex = 57
        Me.chkWallops.Text = "Wallops"
        Me.chkWallops.ThemeName = "Office2010Black"
        '
        'chkRestricted
        '
        Me.chkRestricted.BackColor = System.Drawing.Color.Transparent
        Me.chkRestricted.Location = New System.Drawing.Point(3, 51)
        Me.chkRestricted.Name = "chkRestricted"
        Me.chkRestricted.Size = New System.Drawing.Size(70, 18)
        Me.chkRestricted.TabIndex = 58
        Me.chkRestricted.Text = "Restricted"
        Me.chkRestricted.ThemeName = "Office2010Black"
        '
        'chkOperator
        '
        Me.chkOperator.BackColor = System.Drawing.Color.Transparent
        Me.chkOperator.Location = New System.Drawing.Point(3, 75)
        Me.chkOperator.Name = "chkOperator"
        Me.chkOperator.Size = New System.Drawing.Size(65, 18)
        Me.chkOperator.TabIndex = 52
        Me.chkOperator.Text = "Operator"
        Me.chkOperator.ThemeName = "Office2010Black"
        '
        'chkLocalOp
        '
        Me.chkLocalOp.BackColor = System.Drawing.Color.Transparent
        Me.chkLocalOp.Location = New System.Drawing.Point(3, 99)
        Me.chkLocalOp.Name = "chkLocalOp"
        Me.chkLocalOp.Size = New System.Drawing.Size(64, 18)
        Me.chkLocalOp.TabIndex = 52
        Me.chkLocalOp.Text = "Local Op"
        Me.chkLocalOp.ThemeName = "Office2010Black"
        '
        'chkServerNotices
        '
        Me.chkServerNotices.BackColor = System.Drawing.Color.Transparent
        Me.chkServerNotices.Location = New System.Drawing.Point(3, 123)
        Me.chkServerNotices.Name = "chkServerNotices"
        Me.chkServerNotices.Size = New System.Drawing.Size(92, 18)
        Me.chkServerNotices.TabIndex = 52
        Me.chkServerNotices.Text = "Server Notices"
        Me.chkServerNotices.ThemeName = "Office2010Black"
        '
        'RadPageViewPage10
        '
        Me.RadPageViewPage10.Controls.Add(Me.chkNoIRCMessages)
        Me.RadPageViewPage10.Controls.Add(Me.cmdQuerySettings)
        Me.RadPageViewPage10.Controls.Add(Me.chkExtendedMessages)
        Me.RadPageViewPage10.Controls.Add(Me.chkShowUserAddresses)
        Me.RadPageViewPage10.Controls.Add(Me.chkHideMOTDs)
        Me.RadPageViewPage10.Location = New System.Drawing.Point(12, 40)
        Me.RadPageViewPage10.Name = "RadPageViewPage10"
        Me.RadPageViewPage10.Size = New System.Drawing.Size(494, 277)
        Me.RadPageViewPage10.Text = "IRC"
        '
        'chkNoIRCMessages
        '
        Me.chkNoIRCMessages.BackColor = System.Drawing.Color.Transparent
        Me.chkNoIRCMessages.Location = New System.Drawing.Point(3, 3)
        Me.chkNoIRCMessages.Name = "chkNoIRCMessages"
        Me.chkNoIRCMessages.Size = New System.Drawing.Size(107, 18)
        Me.chkNoIRCMessages.TabIndex = 51
        Me.chkNoIRCMessages.Text = "No IRC Messages"
        Me.chkNoIRCMessages.ThemeName = "Office2010Black"
        '
        'cmdQuerySettings
        '
        Me.cmdQuerySettings.BackColor = System.Drawing.Color.Transparent
        Me.cmdQuerySettings.Image = Global.nexIRC.My.Resources.Resources.configure
        Me.cmdQuerySettings.Location = New System.Drawing.Point(3, 111)
        Me.cmdQuerySettings.Name = "cmdQuerySettings"
        Me.cmdQuerySettings.Padding = New System.Windows.Forms.Padding(2, 0, 2, 0)
        '
        '
        '
        Me.cmdQuerySettings.RootElement.Padding = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.cmdQuerySettings.Size = New System.Drawing.Size(130, 24)
        Me.cmdQuerySettings.TabIndex = 64
        Me.cmdQuerySettings.Text = "Query Settings"
        Me.cmdQuerySettings.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdQuerySettings.ThemeName = "Office2010Black"
        '
        'chkExtendedMessages
        '
        Me.chkExtendedMessages.BackColor = System.Drawing.Color.Transparent
        Me.chkExtendedMessages.Location = New System.Drawing.Point(3, 28)
        Me.chkExtendedMessages.Name = "chkExtendedMessages"
        Me.chkExtendedMessages.Size = New System.Drawing.Size(119, 18)
        Me.chkExtendedMessages.TabIndex = 52
        Me.chkExtendedMessages.Text = "Extended Messages"
        Me.chkExtendedMessages.ThemeName = "Office2010Black"
        '
        'chkShowUserAddresses
        '
        Me.chkShowUserAddresses.BackColor = System.Drawing.Color.Transparent
        Me.chkShowUserAddresses.Location = New System.Drawing.Point(3, 52)
        Me.chkShowUserAddresses.Name = "chkShowUserAddresses"
        Me.chkShowUserAddresses.Size = New System.Drawing.Size(124, 18)
        Me.chkShowUserAddresses.TabIndex = 55
        Me.chkShowUserAddresses.Text = "Show user addresses"
        Me.chkShowUserAddresses.ThemeName = "Office2010Black"
        '
        'chkHideMOTDs
        '
        Me.chkHideMOTDs.BackColor = System.Drawing.Color.Transparent
        Me.chkHideMOTDs.Location = New System.Drawing.Point(3, 76)
        Me.chkHideMOTDs.Name = "chkHideMOTDs"
        Me.chkHideMOTDs.Size = New System.Drawing.Size(79, 18)
        Me.chkHideMOTDs.TabIndex = 62
        Me.chkHideMOTDs.Text = "Hide MOTD"
        Me.chkHideMOTDs.ThemeName = "Office2010Black"
        '
        'RadLabel5
        '
        Me.RadLabel5.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel5.Location = New System.Drawing.Point(176, 171)
        Me.RadLabel5.Name = "RadLabel5"
        Me.RadLabel5.Size = New System.Drawing.Size(25, 18)
        Me.RadLabel5.TabIndex = 50
        Me.RadLabel5.Text = "IRC:"
        '
        'RadPageViewPage4
        '
        Me.RadPageViewPage4.Controls.Add(Me.cmdNotifyClear)
        Me.RadPageViewPage4.Controls.Add(Me.cmdNotifyRemove)
        Me.RadPageViewPage4.Controls.Add(Me.cmdNotifyAdd)
        Me.RadPageViewPage4.Controls.Add(Me.cboNetworkNotify)
        Me.RadPageViewPage4.Controls.Add(Me.RadLabel7)
        Me.RadPageViewPage4.Controls.Add(Me.txtNotifyMessage)
        Me.RadPageViewPage4.Controls.Add(Me.RadLabel6)
        Me.RadPageViewPage4.Controls.Add(Me.txtNotifyNickname)
        Me.RadPageViewPage4.Controls.Add(Me.RadLabel4)
        Me.RadPageViewPage4.Controls.Add(Me.lvwNotify)
        Me.RadPageViewPage4.Image = Global.nexIRC.My.Resources.Resources.preferences
        Me.RadPageViewPage4.Location = New System.Drawing.Point(12, 40)
        Me.RadPageViewPage4.Name = "RadPageViewPage4"
        Me.RadPageViewPage4.Size = New System.Drawing.Size(518, 329)
        Me.RadPageViewPage4.Text = "Notify"
        '
        'cmdNotifyClear
        '
        Me.cmdNotifyClear.Location = New System.Drawing.Point(388, 228)
        Me.cmdNotifyClear.Name = "cmdNotifyClear"
        Me.cmdNotifyClear.Size = New System.Drawing.Size(130, 24)
        Me.cmdNotifyClear.TabIndex = 30
        Me.cmdNotifyClear.Text = "Clear"
        Me.cmdNotifyClear.ThemeName = "Office2010Black"
        '
        'cmdNotifyRemove
        '
        Me.cmdNotifyRemove.Location = New System.Drawing.Point(252, 228)
        Me.cmdNotifyRemove.Name = "cmdNotifyRemove"
        Me.cmdNotifyRemove.Size = New System.Drawing.Size(130, 24)
        Me.cmdNotifyRemove.TabIndex = 29
        Me.cmdNotifyRemove.Text = "Remove"
        Me.cmdNotifyRemove.ThemeName = "Office2010Black"
        '
        'cmdNotifyAdd
        '
        Me.cmdNotifyAdd.Location = New System.Drawing.Point(116, 228)
        Me.cmdNotifyAdd.Name = "cmdNotifyAdd"
        Me.cmdNotifyAdd.Size = New System.Drawing.Size(130, 24)
        Me.cmdNotifyAdd.TabIndex = 28
        Me.cmdNotifyAdd.Text = "Add"
        Me.cmdNotifyAdd.ThemeName = "Office2010Black"
        '
        'cboNetworkNotify
        '
        Me.cboNetworkNotify.DropDownAnimationEnabled = True
        Me.cboNetworkNotify.Location = New System.Drawing.Point(116, 310)
        Me.cboNetworkNotify.Name = "cboNetworkNotify"
        Me.cboNetworkNotify.ShowImageInEditorArea = True
        Me.cboNetworkNotify.Size = New System.Drawing.Size(402, 20)
        Me.cboNetworkNotify.TabIndex = 0
        Me.cboNetworkNotify.ThemeName = "Office2010Black"
        '
        'RadLabel7
        '
        Me.RadLabel7.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel7.Location = New System.Drawing.Point(4, 312)
        Me.RadLabel7.Name = "RadLabel7"
        Me.RadLabel7.Size = New System.Drawing.Size(51, 18)
        Me.RadLabel7.TabIndex = 26
        Me.RadLabel7.Text = "Network:"
        Me.RadLabel7.ThemeName = "Office2010Black"
        '
        'txtNotifyMessage
        '
        Me.txtNotifyMessage.Location = New System.Drawing.Point(116, 284)
        Me.txtNotifyMessage.Name = "txtNotifyMessage"
        Me.txtNotifyMessage.Size = New System.Drawing.Size(402, 20)
        Me.txtNotifyMessage.TabIndex = 27
        Me.txtNotifyMessage.TabStop = False
        Me.txtNotifyMessage.ThemeName = "Office2010Black"
        '
        'RadLabel6
        '
        Me.RadLabel6.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel6.Location = New System.Drawing.Point(4, 286)
        Me.RadLabel6.Name = "RadLabel6"
        Me.RadLabel6.Size = New System.Drawing.Size(53, 18)
        Me.RadLabel6.TabIndex = 26
        Me.RadLabel6.Text = "Message:"
        Me.RadLabel6.ThemeName = "Office2010Black"
        '
        'txtNotifyNickname
        '
        Me.txtNotifyNickname.Location = New System.Drawing.Point(116, 258)
        Me.txtNotifyNickname.Name = "txtNotifyNickname"
        Me.txtNotifyNickname.Size = New System.Drawing.Size(402, 20)
        Me.txtNotifyNickname.TabIndex = 25
        Me.txtNotifyNickname.TabStop = False
        Me.txtNotifyNickname.ThemeName = "Office2010Black"
        '
        'RadLabel4
        '
        Me.RadLabel4.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel4.Location = New System.Drawing.Point(4, 258)
        Me.RadLabel4.Name = "RadLabel4"
        Me.RadLabel4.Size = New System.Drawing.Size(59, 18)
        Me.RadLabel4.TabIndex = 24
        Me.RadLabel4.Text = "Nickname:"
        Me.RadLabel4.ThemeName = "Office2010Black"
        '
        'lvwNotify
        '
        ListViewDetailColumn4.HeaderText = "Name"
        ListViewDetailColumn4.Width = 363.0!
        ListViewDetailColumn5.HeaderText = "Message"
        ListViewDetailColumn5.Width = 75.0!
        ListViewDetailColumn6.HeaderText = "Network"
        ListViewDetailColumn6.Width = 75.0!
        Me.lvwNotify.Columns.AddRange(New Telerik.WinControls.UI.ListViewDetailColumn() {ListViewDetailColumn4, ListViewDetailColumn5, ListViewDetailColumn6})
        Me.lvwNotify.GroupItemSize = New System.Drawing.Size(200, 20)
        Me.lvwNotify.ItemSize = New System.Drawing.Size(200, 20)
        Me.lvwNotify.ItemSpacing = -1
        Me.lvwNotify.Location = New System.Drawing.Point(4, 3)
        Me.lvwNotify.Name = "lvwNotify"
        Me.lvwNotify.Size = New System.Drawing.Size(514, 219)
        Me.lvwNotify.TabIndex = 23
        Me.lvwNotify.Text = "RadListView1"
        Me.lvwNotify.ThemeName = "Office2010Black"
        Me.lvwNotify.ViewType = Telerik.WinControls.UI.ListViewType.DetailsView
        '
        'RadPageViewPage5
        '
        Me.RadPageViewPage5.Controls.Add(Me.cmdCompatibilityDisable)
        Me.RadPageViewPage5.Controls.Add(Me.cmdCompatibilityEnable)
        Me.RadPageViewPage5.Controls.Add(Me.lvwCompatibility)
        Me.RadPageViewPage5.Controls.Add(Me.cmdEditString)
        Me.RadPageViewPage5.Controls.Add(Me.RadLabel9)
        Me.RadPageViewPage5.Controls.Add(Me.RadPanel2)
        Me.RadPageViewPage5.Controls.Add(Me.RadLabel8)
        Me.RadPageViewPage5.Controls.Add(Me.RadPanel1)
        Me.RadPageViewPage5.Controls.Add(Me.lvwStrings)
        Me.RadPageViewPage5.Image = Global.nexIRC.My.Resources.Resources.film
        Me.RadPageViewPage5.Location = New System.Drawing.Point(12, 40)
        Me.RadPageViewPage5.Name = "RadPageViewPage5"
        Me.RadPageViewPage5.Size = New System.Drawing.Size(518, 329)
        Me.RadPageViewPage5.Text = "Text"
        '
        'cmdCompatibilityDisable
        '
        Me.cmdCompatibilityDisable.Location = New System.Drawing.Point(261, 306)
        Me.cmdCompatibilityDisable.Name = "cmdCompatibilityDisable"
        Me.cmdCompatibilityDisable.Size = New System.Drawing.Size(130, 24)
        Me.cmdCompatibilityDisable.TabIndex = 21
        Me.cmdCompatibilityDisable.Text = "Disable"
        Me.cmdCompatibilityDisable.ThemeName = "Office2010Black"
        '
        'cmdCompatibilityEnable
        '
        Me.cmdCompatibilityEnable.Location = New System.Drawing.Point(124, 306)
        Me.cmdCompatibilityEnable.Name = "cmdCompatibilityEnable"
        Me.cmdCompatibilityEnable.Size = New System.Drawing.Size(130, 24)
        Me.cmdCompatibilityEnable.TabIndex = 20
        Me.cmdCompatibilityEnable.Text = "Enable"
        Me.cmdCompatibilityEnable.ThemeName = "Office2010Black"
        '
        'lvwCompatibility
        '
        ListViewDetailColumn7.HeaderText = "Name"
        ListViewDetailColumn7.Width = 180.0!
        ListViewDetailColumn8.HeaderText = "Enabled"
        ListViewDetailColumn8.Width = 190.0!
        Me.lvwCompatibility.Columns.AddRange(New Telerik.WinControls.UI.ListViewDetailColumn() {ListViewDetailColumn7, ListViewDetailColumn8})
        Me.lvwCompatibility.EnableColumnSort = True
        Me.lvwCompatibility.EnableSorting = True
        Me.lvwCompatibility.GroupItemSize = New System.Drawing.Size(200, 20)
        Me.lvwCompatibility.ItemSize = New System.Drawing.Size(200, 20)
        Me.lvwCompatibility.ItemSpacing = -1
        Me.lvwCompatibility.Location = New System.Drawing.Point(124, 190)
        Me.lvwCompatibility.Name = "lvwCompatibility"
        Me.lvwCompatibility.Size = New System.Drawing.Size(394, 110)
        Me.lvwCompatibility.TabIndex = 19
        Me.lvwCompatibility.ThemeName = "Office2010Black"
        Me.lvwCompatibility.ViewType = Telerik.WinControls.UI.ListViewType.DetailsView
        '
        'cmdEditString
        '
        Me.cmdEditString.Location = New System.Drawing.Point(124, 160)
        Me.cmdEditString.Name = "cmdEditString"
        Me.cmdEditString.Size = New System.Drawing.Size(130, 24)
        Me.cmdEditString.TabIndex = 17
        Me.cmdEditString.Text = "Edit Text String"
        Me.cmdEditString.ThemeName = "Office2010Black"
        '
        'RadLabel9
        '
        Me.RadLabel9.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel9.Location = New System.Drawing.Point(12, 97)
        Me.RadLabel9.Name = "RadLabel9"
        Me.RadLabel9.Size = New System.Drawing.Size(72, 18)
        Me.RadLabel9.TabIndex = 15
        Me.RadLabel9.Text = "Unsupported"
        Me.RadLabel9.ThemeName = "Office2010Black"
        '
        'RadPanel2
        '
        Me.RadPanel2.BackColor = System.Drawing.Color.Transparent
        Me.RadPanel2.Controls.Add(Me.rdbUnsupportedOwn)
        Me.RadPanel2.Controls.Add(Me.rdbUnsupportedHide)
        Me.RadPanel2.Controls.Add(Me.rdbUnsupportedStatus)
        Me.RadPanel2.Location = New System.Drawing.Point(6, 105)
        Me.RadPanel2.Name = "RadPanel2"
        Me.RadPanel2.Size = New System.Drawing.Size(112, 79)
        Me.RadPanel2.TabIndex = 16
        Me.RadPanel2.TextAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.RadPanel2.ThemeName = "Office2010Black"
        '
        'rdbUnsupportedOwn
        '
        Me.rdbUnsupportedOwn.Location = New System.Drawing.Point(5, 32)
        Me.rdbUnsupportedOwn.Name = "rdbUnsupportedOwn"
        Me.rdbUnsupportedOwn.Size = New System.Drawing.Size(51, 18)
        Me.rdbUnsupportedOwn.TabIndex = 1
        Me.rdbUnsupportedOwn.Text = "Own"
        Me.rdbUnsupportedOwn.ThemeName = "Office2010Black"
        '
        'rdbUnsupportedHide
        '
        Me.rdbUnsupportedHide.Location = New System.Drawing.Point(5, 55)
        Me.rdbUnsupportedHide.Name = "rdbUnsupportedHide"
        Me.rdbUnsupportedHide.Size = New System.Drawing.Size(59, 18)
        Me.rdbUnsupportedHide.TabIndex = 2
        Me.rdbUnsupportedHide.Text = "Hide"
        Me.rdbUnsupportedHide.ThemeName = "Office2010Black"
        '
        'rdbUnsupportedStatus
        '
        Me.rdbUnsupportedStatus.Location = New System.Drawing.Point(5, 9)
        Me.rdbUnsupportedStatus.Name = "rdbUnsupportedStatus"
        Me.rdbUnsupportedStatus.Size = New System.Drawing.Size(59, 18)
        Me.rdbUnsupportedStatus.TabIndex = 0
        Me.rdbUnsupportedStatus.Text = "Status"
        Me.rdbUnsupportedStatus.ThemeName = "Office2010Black"
        '
        'RadLabel8
        '
        Me.RadLabel8.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel8.Location = New System.Drawing.Point(12, 3)
        Me.RadLabel8.Name = "RadLabel8"
        Me.RadLabel8.Size = New System.Drawing.Size(78, 18)
        Me.RadLabel8.TabIndex = 3
        Me.RadLabel8.Text = "Unknown Text"
        Me.RadLabel8.ThemeName = "Office2010Black"
        '
        'RadPanel1
        '
        Me.RadPanel1.BackColor = System.Drawing.Color.Transparent
        Me.RadPanel1.Controls.Add(Me.rdbUnknownTextOwn)
        Me.RadPanel1.Controls.Add(Me.rdbUnknownTextHide)
        Me.RadPanel1.Controls.Add(Me.rdbUnknownTextStatus)
        Me.RadPanel1.Location = New System.Drawing.Point(6, 11)
        Me.RadPanel1.Name = "RadPanel1"
        Me.RadPanel1.Size = New System.Drawing.Size(112, 79)
        Me.RadPanel1.TabIndex = 14
        Me.RadPanel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.RadPanel1.ThemeName = "Office2010Black"
        '
        'rdbUnknownTextOwn
        '
        Me.rdbUnknownTextOwn.Location = New System.Drawing.Point(5, 32)
        Me.rdbUnknownTextOwn.Name = "rdbUnknownTextOwn"
        Me.rdbUnknownTextOwn.Size = New System.Drawing.Size(51, 18)
        Me.rdbUnknownTextOwn.TabIndex = 1
        Me.rdbUnknownTextOwn.Text = "Own"
        Me.rdbUnknownTextOwn.ThemeName = "Office2010Black"
        '
        'rdbUnknownTextHide
        '
        Me.rdbUnknownTextHide.Location = New System.Drawing.Point(5, 55)
        Me.rdbUnknownTextHide.Name = "rdbUnknownTextHide"
        Me.rdbUnknownTextHide.Size = New System.Drawing.Size(59, 18)
        Me.rdbUnknownTextHide.TabIndex = 2
        Me.rdbUnknownTextHide.Text = "Hide"
        Me.rdbUnknownTextHide.ThemeName = "Office2010Black"
        '
        'rdbUnknownTextStatus
        '
        Me.rdbUnknownTextStatus.Location = New System.Drawing.Point(5, 9)
        Me.rdbUnknownTextStatus.Name = "rdbUnknownTextStatus"
        Me.rdbUnknownTextStatus.Size = New System.Drawing.Size(59, 18)
        Me.rdbUnknownTextStatus.TabIndex = 0
        Me.rdbUnknownTextStatus.Text = "Status"
        Me.rdbUnknownTextStatus.ThemeName = "Office2010Black"
        '
        'lvwStrings
        '
        ListViewDetailColumn9.HeaderText = "Description"
        ListViewDetailColumn9.Width = 150.0!
        ListViewDetailColumn10.HeaderText = "Support"
        ListViewDetailColumn10.Width = 50.0!
        ListViewDetailColumn11.HeaderText = "Syntax"
        ListViewDetailColumn11.Width = 50.0!
        ListViewDetailColumn12.HeaderText = "Numeric"
        ListViewDetailColumn12.Width = 50.0!
        ListViewDetailColumn13.HeaderText = "Data"
        ListViewDetailColumn13.Width = 68.0!
        Me.lvwStrings.Columns.AddRange(New Telerik.WinControls.UI.ListViewDetailColumn() {ListViewDetailColumn9, ListViewDetailColumn10, ListViewDetailColumn11, ListViewDetailColumn12, ListViewDetailColumn13})
        Me.lvwStrings.EnableColumnSort = True
        Me.lvwStrings.EnableSorting = True
        Me.lvwStrings.GroupItemSize = New System.Drawing.Size(200, 20)
        Me.lvwStrings.ItemSize = New System.Drawing.Size(200, 20)
        Me.lvwStrings.ItemSpacing = -1
        Me.lvwStrings.Location = New System.Drawing.Point(124, 11)
        Me.lvwStrings.Name = "lvwStrings"
        Me.lvwStrings.Size = New System.Drawing.Size(394, 144)
        Me.lvwStrings.TabIndex = 13
        Me.lvwStrings.ThemeName = "Office2010Black"
        Me.lvwStrings.ViewType = Telerik.WinControls.UI.ListViewType.DetailsView
        '
        'RadPageViewPage6
        '
        Me.RadPageViewPage6.Controls.Add(Me.cmdDCCIgnoreRemove)
        Me.RadPageViewPage6.Controls.Add(Me.cmdDCCIgnoreAdd)
        Me.RadPageViewPage6.Controls.Add(Me.lstDCCIgnoreItems)
        Me.RadPageViewPage6.Controls.Add(Me.RadLabel15)
        Me.RadPageViewPage6.Controls.Add(Me.cmdRemoveIgnoreExtension)
        Me.RadPageViewPage6.Controls.Add(Me.cmdAddIgnoreExtension)
        Me.RadPageViewPage6.Controls.Add(Me.lstIgnoreExtensions)
        Me.RadPageViewPage6.Controls.Add(Me.RadLabel14)
        Me.RadPageViewPage6.Controls.Add(Me.txtDownloadDirectory)
        Me.RadPageViewPage6.Controls.Add(Me.RadLabel13)
        Me.RadPageViewPage6.Controls.Add(Me.chkPopupDownloadManager)
        Me.RadPageViewPage6.Controls.Add(Me.chkAutoIgnoreExceptNotify)
        Me.RadPageViewPage6.Controls.Add(Me.chkAutoCloseDialogs)
        Me.RadPageViewPage6.Controls.Add(Me.cboDCCFileExists)
        Me.RadPageViewPage6.Controls.Add(Me.RadLabel12)
        Me.RadPageViewPage6.Controls.Add(Me.cmdNetworkSettings)
        Me.RadPageViewPage6.Controls.Add(Me.RadLabel10)
        Me.RadPageViewPage6.Controls.Add(Me.RadPanel3)
        Me.RadPageViewPage6.Controls.Add(Me.RadLabel11)
        Me.RadPageViewPage6.Controls.Add(Me.RadPanel4)
        Me.RadPageViewPage6.Image = Global.nexIRC.My.Resources.Resources.network1
        Me.RadPageViewPage6.Location = New System.Drawing.Point(12, 40)
        Me.RadPageViewPage6.Name = "RadPageViewPage6"
        Me.RadPageViewPage6.Size = New System.Drawing.Size(518, 329)
        Me.RadPageViewPage6.Text = "DCC"
        '
        'cmdDCCIgnoreRemove
        '
        Me.cmdDCCIgnoreRemove.Location = New System.Drawing.Point(399, 292)
        Me.cmdDCCIgnoreRemove.Name = "cmdDCCIgnoreRemove"
        Me.cmdDCCIgnoreRemove.Size = New System.Drawing.Size(40, 24)
        Me.cmdDCCIgnoreRemove.TabIndex = 54
        Me.cmdDCCIgnoreRemove.Text = "Delete"
        Me.cmdDCCIgnoreRemove.ThemeName = "Office2010Black"
        '
        'cmdDCCIgnoreAdd
        '
        Me.cmdDCCIgnoreAdd.Location = New System.Drawing.Point(353, 292)
        Me.cmdDCCIgnoreAdd.Name = "cmdDCCIgnoreAdd"
        Me.cmdDCCIgnoreAdd.Size = New System.Drawing.Size(40, 24)
        Me.cmdDCCIgnoreAdd.TabIndex = 53
        Me.cmdDCCIgnoreAdd.Text = "Add"
        Me.cmdDCCIgnoreAdd.ThemeName = "Office2010Black"
        '
        'lstDCCIgnoreItems
        '
        Me.lstDCCIgnoreItems.CaseSensitiveSort = True
        Me.lstDCCIgnoreItems.ItemHeight = 18
        Me.lstDCCIgnoreItems.Location = New System.Drawing.Point(353, 188)
        Me.lstDCCIgnoreItems.Name = "lstDCCIgnoreItems"
        Me.lstDCCIgnoreItems.Size = New System.Drawing.Size(165, 98)
        Me.lstDCCIgnoreItems.TabIndex = 52
        Me.lstDCCIgnoreItems.Text = "RadListControl1"
        Me.lstDCCIgnoreItems.ThemeName = "Office2010Black"
        '
        'RadLabel15
        '
        Me.RadLabel15.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel15.Location = New System.Drawing.Point(353, 165)
        Me.RadLabel15.Name = "RadLabel15"
        Me.RadLabel15.Size = New System.Drawing.Size(72, 18)
        Me.RadLabel15.TabIndex = 51
        Me.RadLabel15.Text = "Ignore Items:"
        Me.RadLabel15.ThemeName = "Office2010Black"
        '
        'cmdRemoveIgnoreExtension
        '
        Me.cmdRemoveIgnoreExtension.Location = New System.Drawing.Point(399, 135)
        Me.cmdRemoveIgnoreExtension.Name = "cmdRemoveIgnoreExtension"
        Me.cmdRemoveIgnoreExtension.Size = New System.Drawing.Size(40, 24)
        Me.cmdRemoveIgnoreExtension.TabIndex = 50
        Me.cmdRemoveIgnoreExtension.Text = "Delete"
        Me.cmdRemoveIgnoreExtension.ThemeName = "Office2010Black"
        '
        'cmdAddIgnoreExtension
        '
        Me.cmdAddIgnoreExtension.Location = New System.Drawing.Point(353, 135)
        Me.cmdAddIgnoreExtension.Name = "cmdAddIgnoreExtension"
        Me.cmdAddIgnoreExtension.Size = New System.Drawing.Size(40, 24)
        Me.cmdAddIgnoreExtension.TabIndex = 49
        Me.cmdAddIgnoreExtension.Text = "Add"
        Me.cmdAddIgnoreExtension.ThemeName = "Office2010Black"
        '
        'lstIgnoreExtensions
        '
        Me.lstIgnoreExtensions.CaseSensitiveSort = True
        Me.lstIgnoreExtensions.ItemHeight = 18
        Me.lstIgnoreExtensions.Location = New System.Drawing.Point(353, 31)
        Me.lstIgnoreExtensions.Name = "lstIgnoreExtensions"
        Me.lstIgnoreExtensions.Size = New System.Drawing.Size(165, 98)
        Me.lstIgnoreExtensions.TabIndex = 48
        Me.lstIgnoreExtensions.Text = "RadListControl1"
        Me.lstIgnoreExtensions.ThemeName = "Office2010Black"
        '
        'RadLabel14
        '
        Me.RadLabel14.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel14.Location = New System.Drawing.Point(353, 8)
        Me.RadLabel14.Name = "RadLabel14"
        Me.RadLabel14.Size = New System.Drawing.Size(97, 18)
        Me.RadLabel14.TabIndex = 47
        Me.RadLabel14.Text = "Ignore Extensions:"
        Me.RadLabel14.ThemeName = "Office2010Black"
        '
        'txtDownloadDirectory
        '
        Me.txtDownloadDirectory.Location = New System.Drawing.Point(125, 254)
        Me.txtDownloadDirectory.Name = "txtDownloadDirectory"
        Me.txtDownloadDirectory.Size = New System.Drawing.Size(134, 20)
        Me.txtDownloadDirectory.TabIndex = 46
        Me.txtDownloadDirectory.TabStop = False
        Me.txtDownloadDirectory.ThemeName = "Office2010Black"
        '
        'RadLabel13
        '
        Me.RadLabel13.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel13.Location = New System.Drawing.Point(125, 230)
        Me.RadLabel13.Name = "RadLabel13"
        Me.RadLabel13.Size = New System.Drawing.Size(108, 18)
        Me.RadLabel13.TabIndex = 45
        Me.RadLabel13.Text = "Download Directory:"
        Me.RadLabel13.ThemeName = "Office2010Black"
        '
        'chkPopupDownloadManager
        '
        Me.chkPopupDownloadManager.BackColor = System.Drawing.Color.Transparent
        Me.chkPopupDownloadManager.Location = New System.Drawing.Point(125, 111)
        Me.chkPopupDownloadManager.Name = "chkPopupDownloadManager"
        Me.chkPopupDownloadManager.Size = New System.Drawing.Size(155, 18)
        Me.chkPopupDownloadManager.TabIndex = 44
        Me.chkPopupDownloadManager.Text = "Popup Download Manager"
        Me.chkPopupDownloadManager.ThemeName = "Office2010Black"
        '
        'chkAutoIgnoreExceptNotify
        '
        Me.chkAutoIgnoreExceptNotify.BackColor = System.Drawing.Color.Transparent
        Me.chkAutoIgnoreExceptNotify.Location = New System.Drawing.Point(125, 87)
        Me.chkAutoIgnoreExceptNotify.Name = "chkAutoIgnoreExceptNotify"
        Me.chkAutoIgnoreExceptNotify.Size = New System.Drawing.Size(163, 18)
        Me.chkAutoIgnoreExceptNotify.TabIndex = 43
        Me.chkAutoIgnoreExceptNotify.Text = "Only allow users in notify list"
        Me.chkAutoIgnoreExceptNotify.ThemeName = "Office2010Black"
        '
        'chkAutoCloseDialogs
        '
        Me.chkAutoCloseDialogs.BackColor = System.Drawing.Color.Transparent
        Me.chkAutoCloseDialogs.Location = New System.Drawing.Point(125, 63)
        Me.chkAutoCloseDialogs.Name = "chkAutoCloseDialogs"
        Me.chkAutoCloseDialogs.Size = New System.Drawing.Size(137, 18)
        Me.chkAutoCloseDialogs.TabIndex = 42
        Me.chkAutoCloseDialogs.Text = "Auto Close Dcc Dialogs"
        Me.chkAutoCloseDialogs.ThemeName = "Office2010Black"
        '
        'cboDCCFileExists
        '
        Me.cboDCCFileExists.DropDownAnimationEnabled = True
        RadListDataItem1.Text = "Prompt"
        RadListDataItem1.TextWrap = True
        RadListDataItem2.Text = "Overwrite"
        RadListDataItem2.TextWrap = True
        RadListDataItem3.Text = "Ignore"
        RadListDataItem3.TextWrap = True
        Me.cboDCCFileExists.Items.Add(RadListDataItem1)
        Me.cboDCCFileExists.Items.Add(RadListDataItem2)
        Me.cboDCCFileExists.Items.Add(RadListDataItem3)
        Me.cboDCCFileExists.Location = New System.Drawing.Point(125, 303)
        Me.cboDCCFileExists.Name = "cboDCCFileExists"
        Me.cboDCCFileExists.ShowImageInEditorArea = True
        Me.cboDCCFileExists.Size = New System.Drawing.Size(134, 20)
        Me.cboDCCFileExists.TabIndex = 41
        Me.cboDCCFileExists.ThemeName = "Office2010Black"
        '
        'RadLabel12
        '
        Me.RadLabel12.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel12.Location = New System.Drawing.Point(125, 283)
        Me.RadLabel12.Name = "RadLabel12"
        Me.RadLabel12.Size = New System.Drawing.Size(135, 18)
        Me.RadLabel12.TabIndex = 40
        Me.RadLabel12.Text = "When a file already Exists:"
        Me.RadLabel12.ThemeName = "Office2010Black"
        '
        'cmdNetworkSettings
        '
        Me.cmdNetworkSettings.Location = New System.Drawing.Point(125, 8)
        Me.cmdNetworkSettings.Name = "cmdNetworkSettings"
        Me.cmdNetworkSettings.Size = New System.Drawing.Size(134, 24)
        Me.cmdNetworkSettings.TabIndex = 39
        Me.cmdNetworkSettings.Text = "Edit Network Settings"
        Me.cmdNetworkSettings.ThemeName = "Office2010Black"
        '
        'RadLabel10
        '
        Me.RadLabel10.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel10.Location = New System.Drawing.Point(12, 94)
        Me.RadLabel10.Name = "RadLabel10"
        Me.RadLabel10.Size = New System.Drawing.Size(53, 18)
        Me.RadLabel10.TabIndex = 37
        Me.RadLabel10.Text = "Dcc Send"
        Me.RadLabel10.ThemeName = "Office2010Black"
        '
        'RadPanel3
        '
        Me.RadPanel3.BackColor = System.Drawing.Color.Transparent
        Me.RadPanel3.Controls.Add(Me.optDccSendAcceptAll)
        Me.RadPanel3.Controls.Add(Me.optDccSendIgnore)
        Me.RadPanel3.Controls.Add(Me.optDccSendPrompt)
        Me.RadPanel3.Location = New System.Drawing.Point(6, 102)
        Me.RadPanel3.Name = "RadPanel3"
        Me.RadPanel3.Size = New System.Drawing.Size(112, 79)
        Me.RadPanel3.TabIndex = 38
        Me.RadPanel3.TextAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.RadPanel3.ThemeName = "Office2010Black"
        '
        'optDccSendAcceptAll
        '
        Me.optDccSendAcceptAll.Location = New System.Drawing.Point(5, 32)
        Me.optDccSendAcceptAll.Name = "optDccSendAcceptAll"
        Me.optDccSendAcceptAll.Size = New System.Drawing.Size(79, 18)
        Me.optDccSendAcceptAll.TabIndex = 1
        Me.optDccSendAcceptAll.Text = "Accept All"
        Me.optDccSendAcceptAll.ThemeName = "Office2010Black"
        '
        'optDccSendIgnore
        '
        Me.optDccSendIgnore.Location = New System.Drawing.Point(5, 55)
        Me.optDccSendIgnore.Name = "optDccSendIgnore"
        Me.optDccSendIgnore.Size = New System.Drawing.Size(59, 18)
        Me.optDccSendIgnore.TabIndex = 2
        Me.optDccSendIgnore.Text = "Ignore"
        Me.optDccSendIgnore.ThemeName = "Office2010Black"
        '
        'optDccSendPrompt
        '
        Me.optDccSendPrompt.Location = New System.Drawing.Point(5, 9)
        Me.optDccSendPrompt.Name = "optDccSendPrompt"
        Me.optDccSendPrompt.Size = New System.Drawing.Size(59, 18)
        Me.optDccSendPrompt.TabIndex = 0
        Me.optDccSendPrompt.Text = "Prompt"
        Me.optDccSendPrompt.ThemeName = "Office2010Black"
        '
        'RadLabel11
        '
        Me.RadLabel11.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel11.Location = New System.Drawing.Point(12, 0)
        Me.RadLabel11.Name = "RadLabel11"
        Me.RadLabel11.Size = New System.Drawing.Size(51, 18)
        Me.RadLabel11.TabIndex = 35
        Me.RadLabel11.Text = "Dcc Chat"
        Me.RadLabel11.ThemeName = "Office2010Black"
        '
        'RadPanel4
        '
        Me.RadPanel4.BackColor = System.Drawing.Color.Transparent
        Me.RadPanel4.Controls.Add(Me.optDccChatAcceptAll)
        Me.RadPanel4.Controls.Add(Me.optDccChatIgnore)
        Me.RadPanel4.Controls.Add(Me.optDccChatPrompt)
        Me.RadPanel4.Location = New System.Drawing.Point(6, 8)
        Me.RadPanel4.Name = "RadPanel4"
        Me.RadPanel4.Size = New System.Drawing.Size(112, 79)
        Me.RadPanel4.TabIndex = 36
        Me.RadPanel4.TextAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.RadPanel4.ThemeName = "Office2010Black"
        '
        'optDccChatAcceptAll
        '
        Me.optDccChatAcceptAll.Location = New System.Drawing.Point(5, 32)
        Me.optDccChatAcceptAll.Name = "optDccChatAcceptAll"
        Me.optDccChatAcceptAll.Size = New System.Drawing.Size(79, 18)
        Me.optDccChatAcceptAll.TabIndex = 1
        Me.optDccChatAcceptAll.Text = "Accept All"
        Me.optDccChatAcceptAll.ThemeName = "Office2010Black"
        '
        'optDccChatIgnore
        '
        Me.optDccChatIgnore.Location = New System.Drawing.Point(5, 55)
        Me.optDccChatIgnore.Name = "optDccChatIgnore"
        Me.optDccChatIgnore.Size = New System.Drawing.Size(59, 18)
        Me.optDccChatIgnore.TabIndex = 2
        Me.optDccChatIgnore.Text = "Ignore"
        Me.optDccChatIgnore.ThemeName = "Office2010Black"
        '
        'optDccChatPrompt
        '
        Me.optDccChatPrompt.Location = New System.Drawing.Point(5, 9)
        Me.optDccChatPrompt.Name = "optDccChatPrompt"
        Me.optDccChatPrompt.Size = New System.Drawing.Size(59, 18)
        Me.optDccChatPrompt.TabIndex = 0
        Me.optDccChatPrompt.Text = "Prompt"
        Me.optDccChatPrompt.ThemeName = "Office2010Black"
        '
        'chkNewStatus
        '
        Me.chkNewStatus.BackColor = System.Drawing.Color.Transparent
        Me.chkNewStatus.Location = New System.Drawing.Point(92, 388)
        Me.chkNewStatus.Name = "chkNewStatus"
        Me.chkNewStatus.Size = New System.Drawing.Size(119, 16)
        Me.chkNewStatus.TabIndex = 27
        Me.chkNewStatus.Text = "New Status Window"
        Me.chkNewStatus.ThemeName = "Office2010Black"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "accept.png")
        Me.ImageList1.Images.SetKeyName(1, "add.png")
        Me.ImageList1.Images.SetKeyName(2, "cancel.png")
        Me.ImageList1.Images.SetKeyName(3, "close.png")
        Me.ImageList1.Images.SetKeyName(4, "delete.png")
        Me.ImageList1.Images.SetKeyName(5, "edit (1).png")
        Me.ImageList1.Images.SetKeyName(6, "move.png")
        Me.ImageList1.Images.SetKeyName(7, "remove.png")
        Me.ImageList1.Images.SetKeyName(8, "web.png")
        Me.ImageList1.Images.SetKeyName(9, "user.png")
        Me.ImageList1.Images.SetKeyName(10, "configure.png")
        Me.ImageList1.Images.SetKeyName(11, "network.png")
        Me.ImageList1.Images.SetKeyName(12, "announce.png")
        Me.ImageList1.Images.SetKeyName(13, "documents.png")
        Me.ImageList1.Images.SetKeyName(14, "copy.png")
        '
        'tmrCloseMe
        '
        Me.tmrCloseMe.Interval = 200
        '
        'cmdApplyNow
        '
        Me.cmdApplyNow.Image = Global.nexIRC.My.Resources.Resources.accept
        Me.cmdApplyNow.Location = New System.Drawing.Point(363, 382)
        Me.cmdApplyNow.Name = "cmdApplyNow"
        Me.cmdApplyNow.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        '
        '
        '
        Me.cmdApplyNow.RootElement.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.cmdApplyNow.Size = New System.Drawing.Size(86, 29)
        Me.cmdApplyNow.TabIndex = 29
        Me.cmdApplyNow.Text = "&Apply"
        Me.cmdApplyNow.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdApplyNow.ThemeName = "Office2010Black"
        '
        'cmdOK
        '
        Me.cmdOK.Image = Global.nexIRC.My.Resources.Resources.accept
        Me.cmdOK.Location = New System.Drawing.Point(271, 382)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        '
        '
        '
        Me.cmdOK.RootElement.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.cmdOK.Size = New System.Drawing.Size(86, 29)
        Me.cmdOK.TabIndex = 28
        Me.cmdOK.Text = "&OK"
        Me.cmdOK.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdOK.ThemeName = "Office2010Black"
        '
        'cmdConnectNow
        '
        Me.cmdConnectNow.Image = Global.nexIRC.My.Resources.Resources.network1
        Me.cmdConnectNow.Location = New System.Drawing.Point(0, 382)
        Me.cmdConnectNow.Name = "cmdConnectNow"
        Me.cmdConnectNow.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        '
        '
        '
        Me.cmdConnectNow.RootElement.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.cmdConnectNow.Size = New System.Drawing.Size(86, 29)
        Me.cmdConnectNow.TabIndex = 26
        Me.cmdConnectNow.Text = "&Connect"
        Me.cmdConnectNow.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdConnectNow.ThemeName = "Office2010Black"
        '
        'cmdCancelNow
        '
        Me.cmdCancelNow.Image = Global.nexIRC.My.Resources.Resources.cancel
        Me.cmdCancelNow.Location = New System.Drawing.Point(456, 382)
        Me.cmdCancelNow.Name = "cmdCancelNow"
        Me.cmdCancelNow.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        '
        '
        '
        Me.cmdCancelNow.RootElement.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.cmdCancelNow.Size = New System.Drawing.Size(86, 29)
        Me.cmdCancelNow.TabIndex = 30
        Me.cmdCancelNow.Text = "Ca&ncel"
        Me.cmdCancelNow.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelNow.ThemeName = "Office2010Black"
        '
        'frmCustomize
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(543, 414)
        Me.Controls.Add(Me.RadPageView1)
        Me.Controls.Add(Me.chkNewStatus)
        Me.Controls.Add(Me.cmdApplyNow)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.cmdConnectNow)
        Me.Controls.Add(Me.cmdCancelNow)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmCustomize"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "nexIRC - Customize"
        Me.ThemeName = "Office2010Black"
        CType(Me.RadPageView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPageView1.ResumeLayout(False)
        Me.RadPageViewPage1.ResumeLayout(False)
        Me.RadPageViewPage1.PerformLayout()
        CType(Me.lvwServers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboNetworks, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdServersMove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdServersClear, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdServerAdd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdServerDelete, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdServerEdit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPageViewPage2.ResumeLayout(False)
        Me.RadPageViewPage2.PerformLayout()
        CType(Me.chkIdentdEnabled, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIdentdPort, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblIdentdPort, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIdentdSystem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIdentdUserID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOperPassword, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOperName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPassword, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRealName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUserEmail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboMyNickNames, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdClearMyNickName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdRemoveMyNickName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdAddMyNickName, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPageViewPage3.ResumeLayout(False)
        Me.RadPageViewPage3.PerformLayout()
        CType(Me.RadPageView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPageView2.ResumeLayout(False)
        Me.RadPageViewPage7.ResumeLayout(False)
        Me.RadPageViewPage7.PerformLayout()
        CType(Me.chkAutoSelectAlternateNickname, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTextBufferSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkShowRawWindow, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkMOTDInOwnWindow, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkNoticesInOwnWindow, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkShowPrompts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkShowWindowsAutomatically, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkCloseStatusWindow, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkAddToChannelFolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkCloseChannelFolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkShowNicknameWindow, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkAutoMaximize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkPopupChannelFolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkVideoBackground, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPageViewPage8.ResumeLayout(False)
        Me.RadPageViewPage8.PerformLayout()
        CType(Me.chkAutoConnect, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkShowCustomize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPageViewPage9.ResumeLayout(False)
        Me.RadPageViewPage9.PerformLayout()
        CType(Me.chkInvisible, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkWallops, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkRestricted, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkOperator, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkLocalOp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkServerNotices, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPageViewPage10.ResumeLayout(False)
        Me.RadPageViewPage10.PerformLayout()
        CType(Me.chkNoIRCMessages, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdQuerySettings, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkExtendedMessages, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkShowUserAddresses, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkHideMOTDs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPageViewPage4.ResumeLayout(False)
        Me.RadPageViewPage4.PerformLayout()
        CType(Me.cmdNotifyClear, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdNotifyRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdNotifyAdd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboNetworkNotify, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNotifyMessage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNotifyNickname, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lvwNotify, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPageViewPage5.ResumeLayout(False)
        Me.RadPageViewPage5.PerformLayout()
        CType(Me.cmdCompatibilityDisable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdCompatibilityEnable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lvwCompatibility, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdEditString, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPanel2.ResumeLayout(False)
        CType(Me.rdbUnsupportedOwn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rdbUnsupportedHide, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rdbUnsupportedStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPanel1.ResumeLayout(False)
        CType(Me.rdbUnknownTextOwn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rdbUnknownTextHide, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rdbUnknownTextStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lvwStrings, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPageViewPage6.ResumeLayout(False)
        Me.RadPageViewPage6.PerformLayout()
        CType(Me.cmdDCCIgnoreRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdDCCIgnoreAdd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lstDCCIgnoreItems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdRemoveIgnoreExtension, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdAddIgnoreExtension, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lstIgnoreExtensions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDownloadDirectory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkPopupDownloadManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkAutoIgnoreExceptNotify, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkAutoCloseDialogs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDCCFileExists, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdNetworkSettings, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPanel3.ResumeLayout(False)
        CType(Me.optDccSendAcceptAll, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optDccSendIgnore, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optDccSendPrompt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadPanel4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPanel4.ResumeLayout(False)
        CType(Me.optDccChatAcceptAll, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optDccChatIgnore, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optDccChatPrompt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkNewStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdApplyNow, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdOK, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdConnectNow, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdCancelNow, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RadPageViewPage6 As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents chkShowRawWindow As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkMOTDInOwnWindow As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents RadLabel3 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents chkNoticesInOwnWindow As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkShowPrompts As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkCloseStatusWindow As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkShowWindowsAutomatically As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents cboMyNickNames As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents RadPageViewPage7 As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents chkAddToChannelFolder As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkCloseChannelFolder As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkShowNicknameWindow As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkAutoMaximize As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkPopupChannelFolder As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkVideoBackground As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents RadPageView2 As Telerik.WinControls.UI.RadPageView
    Friend WithEvents RadPageViewPage8 As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents chkAutoConnect As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkShowCustomize As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents RadPageViewPage9 As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents chkInvisible As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkWallops As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkRestricted As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkOperator As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkLocalOp As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkServerNotices As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents RadPageViewPage10 As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents chkNoIRCMessages As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents cmdQuerySettings As Telerik.WinControls.UI.RadButton
    Friend WithEvents chkExtendedMessages As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkShowUserAddresses As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkHideMOTDs As Telerik.WinControls.UI.RadCheckBox
    Private WithEvents lvwServers As Telerik.WinControls.UI.RadListView
    Friend WithEvents RadPageViewPage1 As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents cboNetworks As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents cmdServersMove As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdServersClear As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdServerAdd As Telerik.WinControls.UI.RadButton
    Friend WithEvents lnkNetworkAdd As System.Windows.Forms.LinkLabel
    Friend WithEvents cmdServerDelete As Telerik.WinControls.UI.RadButton
    Friend WithEvents lnkNetworkDelete As System.Windows.Forms.LinkLabel
    Friend WithEvents cmdServerEdit As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadPageViewPage2 As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents cmdClearMyNickName As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdRemoveMyNickName As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdAddMyNickName As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadPageViewPage3 As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents RadLabel5 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lvwNotify As Telerik.WinControls.UI.RadListView
    Friend WithEvents RadPageViewPage4 As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents RadPageViewPage5 As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents RadPageView1 As Telerik.WinControls.UI.RadPageView
    Friend WithEvents chkNewStatus As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents cmdApplyNow As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdOK As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdConnectNow As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdCancelNow As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadLabel7 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtNotifyMessage As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel6 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtNotifyNickname As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel4 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents cboNetworkNotify As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents RadPanel1 As Telerik.WinControls.UI.RadPanel
    Friend WithEvents rdbUnknownTextOwn As Telerik.WinControls.UI.RadRadioButton
    Friend WithEvents rdbUnknownTextHide As Telerik.WinControls.UI.RadRadioButton
    Friend WithEvents rdbUnknownTextStatus As Telerik.WinControls.UI.RadRadioButton
    Friend WithEvents lvwStrings As Telerik.WinControls.UI.RadListView
    Friend WithEvents cmdEditString As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadLabel9 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadPanel2 As Telerik.WinControls.UI.RadPanel
    Friend WithEvents rdbUnsupportedOwn As Telerik.WinControls.UI.RadRadioButton
    Friend WithEvents rdbUnsupportedHide As Telerik.WinControls.UI.RadRadioButton
    Friend WithEvents rdbUnsupportedStatus As Telerik.WinControls.UI.RadRadioButton
    Friend WithEvents RadLabel8 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents cmdNotifyClear As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdNotifyRemove As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdNotifyAdd As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdNetworkSettings As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadLabel10 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadPanel3 As Telerik.WinControls.UI.RadPanel
    Friend WithEvents optDccSendAcceptAll As Telerik.WinControls.UI.RadRadioButton
    Friend WithEvents optDccSendIgnore As Telerik.WinControls.UI.RadRadioButton
    Friend WithEvents optDccSendPrompt As Telerik.WinControls.UI.RadRadioButton
    Friend WithEvents RadLabel11 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadPanel4 As Telerik.WinControls.UI.RadPanel
    Friend WithEvents optDccChatAcceptAll As Telerik.WinControls.UI.RadRadioButton
    Friend WithEvents optDccChatIgnore As Telerik.WinControls.UI.RadRadioButton
    Friend WithEvents optDccChatPrompt As Telerik.WinControls.UI.RadRadioButton
    Friend WithEvents cboDCCFileExists As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents RadLabel12 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents cmdAddIgnoreExtension As Telerik.WinControls.UI.RadButton
    Friend WithEvents lstIgnoreExtensions As Telerik.WinControls.UI.RadListControl
    Friend WithEvents RadLabel14 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtDownloadDirectory As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel13 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents chkPopupDownloadManager As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkAutoIgnoreExceptNotify As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkAutoCloseDialogs As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents cmdRemoveIgnoreExtension As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdDCCIgnoreRemove As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdDCCIgnoreAdd As Telerik.WinControls.UI.RadButton
    Friend WithEvents lstDCCIgnoreItems As Telerik.WinControls.UI.RadListControl
    Friend WithEvents RadLabel15 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents cmdCompatibilityDisable As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdCompatibilityEnable As Telerik.WinControls.UI.RadButton
    Friend WithEvents lvwCompatibility As Telerik.WinControls.UI.RadListView
    Friend WithEvents txtUserEmail As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel16 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtRealName As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel17 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtPassword As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel18 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtOperPassword As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtOperName As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel19 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents tmrCloseMe As System.Windows.Forms.Timer
    Friend WithEvents txtTextBufferSize As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtIdentdUserID As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel2 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtIdentdSystem As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel20 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtIdentdPort As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents lblIdentdPort As Telerik.WinControls.UI.RadLabel
    Friend WithEvents chkIdentdEnabled As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkAutoSelectAlternateNickname As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents Office2010BlackTheme1 As Telerik.WinControls.Themes.Office2010BlackTheme
End Class

