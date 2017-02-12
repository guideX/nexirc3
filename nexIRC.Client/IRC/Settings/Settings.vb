﻿'nexIRC 3.0.31
'Sunday, Oct 4th, 2014 - guideX
Option Explicit On
Option Strict On
Imports System.Net
Imports System.IO
Imports Telerik.WinControls.UI
Imports nexIRC.Modules
Imports nexIRC.Business.Helpers
Imports nexIRC.Business
Public Class Settings
    Enum eUnsupportedIn
        uStatusWindow = 1
        uOwnWindow = 2
        uHide = 3
    End Enum

    Enum eUnknownsIn
        uStatusWindow = 1
        uOwnWindow = 2
        uHide = 3
    End Enum

    Enum ePlaylistType
        pOther = 0
        pVideo = 1
        pAudio = 2
    End Enum

    Structure gCompatibilityItem
        Public cDescription As String
        Public cEnabled As Boolean
    End Structure

    Structure gCompatibility
        Public cModified As Boolean
        Public cCompatibility() As gCompatibilityItem
        Public cCount As Integer
    End Structure

    Structure gArraySizes
        Public aCompatibility As Integer
        Public aProcess As Integer
        Public aNickList As Integer
        Public aAutoAllowList As Integer
        Public aAutoDenyList As Integer
        Public aSpamFilterCount As Integer
        Public aRecientServers As Integer
        Public aNotifyItems As Integer
        Public aNetworks As Integer
        Public aServers As Integer
        Public aNickNames As Integer
        Public aServices As Integer
        Public aServiceCommands As Integer
        Public aServiceParams As Integer
        Public aDCCIgnore As Integer
        Public aDownloadManager As Integer
        Public aChannelFolder As Integer
        Public aChannelList As Integer
        Public aStatusWindows As Integer
        Public aChannelWindows As Integer
        Public aServerLinks As Integer
        Public aQueries As Integer
        Public aStrings As Integer
        Public aPlaylists As Integer
        Public aMediaFiles As Integer
        Public aSub As Integer
    End Structure

    Structure gModes
        Public mInvisible As Boolean
        Public mWallops As Boolean
        Public mRestricted As Boolean
        Public mOperator As Boolean
        Public mLocalOperator As Boolean
        Public mServerNotices As Boolean
    End Structure

    Structure gServer
        Public sIP As String
        Public sPort As Long
        Public sDescription As String
        Public sNetworkIndex As Integer
    End Structure

    Structure gServers
        Public sModified As Boolean
        Public sCount As Integer
        Public sIndex As Integer
        Public sServer() As gServer
    End Structure

    Structure gINI
        Public iBasePath As String
        Public iCompatibility As String
        Public iMedia As String
        Public iQuery As String
        Public iQueryLogs As String
        Public iDCC As String
        Public iNetworks As String
        Public iIRC As String
        Public iNicks As String
        Public iIdent As String
        Public iServers As String
        Public iErrors As String
        Public iChannelFolders As String
        Public iText As String
        Public iStringSettings As String
        Public iNotify As String
        Public iServices As String
        Public iCommands As String
        Public iDownloadManager As String
        Public iRecientServers As String
        Public iPlaylists As String
        Public iNotepad As String
    End Structure

    Structure gNick
        Public nNick As String
    End Structure

    Structure gNicks
        Public nCount As Integer
        Public nIndex As Integer
        Public nNick() As gNick
    End Structure

    Structure gIdentdSettings
        Public iEnabled As Boolean
    End Structure

    Structure gNotify
        Public nNickName As String
        Public nMessage As String
        Public nNetwork As String
    End Structure

    Structure gNotifyList
        Public nModified As Boolean
        Public nCount As Integer
        Public nNotify() As gNotify
    End Structure

    Structure gIdentd
        Public iUserID As String
        Public iSystem As String
        Public iPort As Long
        Public iSettings As gIdentdSettings
    End Structure

    Structure gStringSettings
        Public sUnknowns As eUnknownsIn
        Public sUnsupported As eUnsupportedIn
    End Structure

    Structure gDownload
        Public dFileName As String
        Public dFilePath As String
        Public dNickName As String
    End Structure

    Structure gDownloadManager
        Public dDownload() As gDownload
        Public dCount As Integer
    End Structure

    Structure gIgnoreExtensions
        Public iCount As Integer
        Public iExtension As String
    End Structure

    Structure gWindowSize
        Public wWidth As Integer
        Public wHeight As Integer
    End Structure

    Structure gInitialWindowSizes
        Public iChannel As gWindowSize
        Public iNotice As gWindowSize
        Public lStatus As gWindowSize
    End Structure

    Structure gSettings
        Public sNetworkAvailability As Boolean
        Public sAutoAddToChannelFolder As Boolean
        Public sWindowSizes As gInitialWindowSizes
        Public sPrompts As Boolean
        Public sOper As Boolean
        Public sExtendedMessages As Boolean
        Public sNoIRCMessages As Boolean
        Public sCustomizeOnStartup As Boolean
        Public sPopupChannelFolders As Boolean
        Public sMOTDInOwnWindow As Boolean
        Public sHideMOTD As Boolean
        Public sAutoSelectAlternateNickname As Boolean
        Public sChangeNickNameWindow As Boolean
        Public sNoticesInOwnWindow As Boolean
        Public sStringSettings As gStringSettings
        Public sURL As String
        Public sShowUserAddresses As Boolean
        Public sShowRawWindow As Boolean
        Public sShowWindowsAutomatically As Boolean
        Public sAutoMaximize As Boolean
        Public sQuitMessage As String
        Public sAutoConnect As Boolean
        Public sVideoBackground As Boolean
        Public sChannelFolderCloseOnJoin As Boolean
        Public sAutoNavigateChannelUrls As Boolean
        Public sCloseWindowOnDisconnect As Boolean
        Public sTextBufferSize As Integer
    End Structure

    Structure gIRC
        Public iInitialized As Boolean
        Public iNicks As gNicks
        Public iIdent As gIdentd
        Public iSettings As gSettings
        Public iPass As String
        Public iEMail As String
        Public iRealName As String
        Public iOperName As String
        Public iOperPass As String
        Public iModes As gModes
    End Structure

    Structure gWinVisible
        Public wMain As Boolean
        Public wCustomize As Boolean
        Public wAddNetwork As Boolean
        Public wAddNickName As Boolean
        Public wEditServer As Boolean
    End Structure

    Enum eServiceType
        sNone = 0
        sChanServ = 1
        sNickServ = 2
        sMemoServ = 3
        sX = 4
    End Enum
    Structure gRecientServers
        Public sCount As Integer
        Public sItem() As String
    End Structure

    Private lAway As Boolean
    Public lArraySizes As gArraySizes
    Public lDownloadManager As gDownloadManager
    Public lINI As gINI
    Public lWinVisible As gWinVisible
    Public lIRC As gIRC
    Public lServers As gServers
    Public lNotify As gNotifyList
    Public lRecientServers As gRecientServers
    Public lCompatibility As gCompatibility
    Public lBlack As Boolean = False

    Public Function FindCompatibilityIndex(ByVal lDescription As String) As Integer
        Dim result As Integer
        Try
            For i As Integer = 1 To lCompatibility.cCount
                With lCompatibility.cCompatibility(i)
                    If LCase(Trim(.cDescription)) = LCase(Trim(lDescription)) Then
                        result = i
                        Exit For
                    End If
                End With
            Next i
            Return result
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Sub SaveCompatibility()
        Try
            Dim i As Integer
            If lCompatibility.cModified = True Then
                IniFileHelper.WriteINI(lINI.iCompatibility, "Settings", "Count", Trim(lCompatibility.cCount.ToString))
                For i = 1 To lCompatibility.cCount
                    With lCompatibility.cCompatibility(i)
                        IniFileHelper.WriteINI(lINI.iCompatibility, Trim(i.ToString), "Description", .cDescription)
                        IniFileHelper.WriteINI(lINI.iCompatibility, Trim(i.ToString), "Enabled", Trim(.cEnabled.ToString))
                    End With
                Next i
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub LoadCompatibility()
        Try
            Dim i As Integer
            lCompatibility.cCount = Convert.ToInt32(Trim(IniFileHelper.ReadINI(lINI.iCompatibility, "Settings", "Count", "0")))
            ReDim lCompatibility.cCompatibility(1000)
            For i = 1 To lCompatibility.cCount
                With lCompatibility.cCompatibility(i)
                    .cDescription = IniFileHelper.ReadINI(lINI.iCompatibility, Trim(i.ToString), "Description", "")
                    .cEnabled = Convert.ToBoolean(IniFileHelper.ReadINI(lINI.iCompatibility, Trim(i.ToString), "Enabled", "False"))
                End With
            Next i
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub AddToCompatibility(ByVal lDescription As String, ByVal lEnabled As Boolean)
        Try
            If Len(lDescription) <> 0 Then
                lCompatibility.cModified = True
                lCompatibility.cCount = lCompatibility.cCount + 1
                With lCompatibility.cCompatibility(lCompatibility.cCount)
                    .cDescription = lDescription
                    .cEnabled = lEnabled
                End With
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub RemoveFromCompatibility(ByVal lIndex As Integer)
        Try
            lCompatibility.cModified = True
            With lCompatibility.cCompatibility(lIndex)
                .cEnabled = False
                .cDescription = ""
            End With
            SortCompatibility()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub SortCompatibility()
        Try
            Dim lEnabled(lArraySizes.aCompatibility) As Boolean, lDescription(lArraySizes.aCompatibility) As String, i As Integer, c As Integer
            For i = 1 To lCompatibility.cCount
                With lCompatibility.cCompatibility(i)
                    lEnabled(i) = .cEnabled
                    lDescription(i) = .cDescription
                    .cEnabled = False
                    .cDescription = ""
                End With
            Next i
            For i = 1 To lArraySizes.aCompatibility
                If Len(lDescription(i)) <> 0 Then
                    c = c + 1
                    With lCompatibility.cCompatibility(c)
                        .cDescription = lDescription(i)
                        .cEnabled = lEnabled(i)
                    End With
                End If
            Next i
            lCompatibility.cCount = c
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub AddToRecientServerList(ByVal lServerIndex As Integer)
        Try
            Dim msg As String
            If lServerIndex <> 0 Then
                msg = lServers.sServer(lServerIndex).sIP
                If msg = lRecientServers.sItem(1) Or msg = lRecientServers.sItem(2) Or msg = lRecientServers.sItem(3) Then Exit Sub
                lRecientServers.sItem(3) = lRecientServers.sItem(2)
                lRecientServers.sItem(2) = lRecientServers.sItem(1)
                lRecientServers.sItem(1) = msg
                RefreshRecientServersMenu()
                SaveRecientServers()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub LoadRecientServers()
        Try
            Dim i As Integer
            lRecientServers.sCount = lArraySizes.aRecientServers
            ReDim lRecientServers.sItem(lRecientServers.sCount)
            For i = 1 To lRecientServers.sCount
                lRecientServers.sItem(i) = IniFileHelper.ReadINI(lINI.iRecientServers, "Items", Trim(i.ToString), "")
            Next i
            RefreshRecientServersMenu()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub RefreshRecientServersMenu()
        Try
            mdiMain.cmd_RecientServer1.Text = lRecientServers.sItem(1)
            mdiMain.cmd_RecientServer2.Text = lRecientServers.sItem(2)
            mdiMain.cmd_RecientServer3.Text = lRecientServers.sItem(3)
            If Len(mdiMain.cmd_RecientServer1.Text) = 0 Then
                mdiMain.cmd_RecientServer1.Text = "(Empty)"
                mdiMain.cmd_RecientServer1.Enabled = False
            Else
                mdiMain.cmd_RecientServer1.Enabled = True
            End If
            If Len(mdiMain.cmd_RecientServer2.Text) = 0 Then
                mdiMain.cmd_RecientServer2.Text = "(Empty)"
                mdiMain.cmd_RecientServer2.Enabled = False
            Else
                mdiMain.cmd_RecientServer2.Enabled = True
            End If
            If Len(mdiMain.cmd_RecientServer3.Text) = 0 Then
                mdiMain.cmd_RecientServer3.Text = "(Empty)"
                mdiMain.cmd_RecientServer3.Enabled = False
            Else
                mdiMain.cmd_RecientServer3.Enabled = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub SaveRecientServers()
        Try
            Dim i As Integer
            For i = 1 To lRecientServers.sCount
                IniFileHelper.WriteINI(lINI.iRecientServers, "Items", Trim(i.ToString), lRecientServers.sItem(i))
            Next i
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub WriteTextFile(ByVal lFileName As String, ByVal lData As String)
        Try
            Dim w As StreamWriter
            w = New StreamWriter(lFileName)
            w.Write(lData)
            w.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ReadTextFile(ByVal lFileName As String) As String
        Try
            Dim r As StreamReader, msg As String, msg2 As String
            r = New StreamReader(lFileName)
            msg = r.ReadLine
            msg2 = ""
            Do While Not msg Is Nothing
                If Len(msg2) <> 0 Then
                    msg2 = msg2 & Environment.NewLine & msg
                Else
                    msg2 = msg
                End If
            Loop
            ReadTextFile = msg2
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function


    Public Sub PopulateNotifyByListView(ByVal lListView As RadListView)
        Try
            Dim i As Integer, n As Integer
            For i = 0 To (lListView.Items.Count - 1)
                n = n + 1
                With lListView.Items(i)
                    lNotify.nNotify(n).nNickName = .Text
                    lNotify.nNotify(n).nNetwork = .Item(2).ToString
                    lNotify.nNotify(n).nMessage = .Item(1).ToString
                End With
            Next i
            lNotify.nCount = n
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function FindNotifyIndex(ByVal lNickName As String) As Integer
        Try
            Dim i As Integer
            FindNotifyIndex = 0
            If Len(lNickName) <> 0 Then
                For i = 1 To lNotify.nCount
                    If LCase(Trim(lNickName)) = LCase(Trim(lNotify.nNotify(i).nNickName)) Then
                        FindNotifyIndex = i
                        Exit For
                    End If
                Next i
            End If
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Function ReturnAwayStatus() As Boolean
        ReturnAwayStatus = lAway
    End Function

    Public Sub SetAwayStatus(ByVal lStatus As Boolean)
        lAway = lStatus
    End Sub

    Public Sub LoadNotifyList()
        Dim i As Integer
        ReDim lNotify.nNotify(lArraySizes.aNotifyItems)
        lNotify.nCount = Convert.ToInt32(Trim(IniFileHelper.ReadINI(lINI.iNotify, "Settings", "Count", "0")))
        If lNotify.nCount <> 0 Then
            For i = 1 To lNotify.nCount
                With lNotify.nNotify(i)
                    .nNickName = IniFileHelper.ReadINI(lINI.iNotify, Trim(Convert.ToString(i)), "NickName", "")
                    .nMessage = IniFileHelper.ReadINI(lINI.iNotify, Trim(Convert.ToString(i)), "Message", "")
                    .nNetwork = IniFileHelper.ReadINI(lINI.iNotify, Trim(Convert.ToString(i)), "Network", "")
                End With
            Next i
        End If
    End Sub

    Public Sub AddToNotifyList(ByVal _Item As gNotify)
        Try
            lNotify.nCount = lNotify.nCount + 1
            With lNotify.nNotify(lNotify.nCount)
                .nNickName = _Item.nNickName
                .nNetwork = _Item.nNetwork
                .nMessage = _Item.nMessage
            End With
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Public Sub AddToNotifyList(_Item As gNotify)")
        End Try
    End Sub

    Public Sub SaveNotifyList()
        Dim i As Integer
        If lNotify.nModified = True Then
            IniFileHelper.WriteINI(lINI.iNotify, "Settings", "Count", Trim(lNotify.nCount.ToString))
            For i = 1 To lNotify.nCount
                With lNotify.nNotify(i)
                    IniFileHelper.WriteINI(lINI.iNotify, Trim(Convert.ToString(i)), "NickName", .nNickName)
                    IniFileHelper.WriteINI(lINI.iNotify, Trim(Convert.ToString(i)), "Message", .nMessage)
                    IniFileHelper.WriteINI(lINI.iNotify, Trim(Convert.ToString(i)), "Network", .nNetwork)
                End With
            Next i
            lNotify.nModified = False
        End If
    End Sub

    Public Function ReturnOtherNickName(ByVal lUnAcceptedNick As String) As String
        Dim i As Integer
        For i = 1 To lIRC.iNicks.nCount
            With lIRC.iNicks.nNick(i)
                If LCase(.nNick) <> lUnAcceptedNick And Len(.nNick) <> 0 Then
                    ReturnOtherNickName = .nNick
                    Exit Function
                End If
            End With
        Next i
        ReturnOtherNickName = ""
    End Function

    Public Function ReturnTextINI() As String
        ReturnTextINI = lINI.iText
    End Function

    Public Function ReturnCommandsINI() As String
        ReturnCommandsINI = lINI.iCommands
    End Function

    Public Function ReturnBasePath() As String
        ReturnBasePath = lINI.iBasePath
    End Function

    Public Sub SetArraySizes()
        With lArraySizes
            .aSub = 1000
            .aCompatibility = 1000
            .aPlaylists = 500
            .aMediaFiles = 20000
            .aProcess = 20000
            .aAutoAllowList = 100
            .aAutoDenyList = 100
            .aChannelFolder = 300
            .aChannelList = 500
            .aChannelWindows = 100
            .aDCCIgnore = 100
            .aDownloadManager = 300
            .aNetworks = 1000
            .aNickList = 2000
            .aNickNames = 100
            .aNotifyItems = 100
            .aQueries = 300
            .aRecientServers = 3
            .aServerLinks = 1000
            .aServers = 3000
            .aServiceCommands = 100
            .aServiceParams = 4
            .aServices = 100
            .aSpamFilterCount = 200
            .aStatusWindows = 300
            .aStrings = 300
        End With
        'ReDim lNetworks.nNetwork(lArraySizes.aNetworks)
        ReDim lServers.sServer(lArraySizes.aServers)
        ReDim lIRC.iNicks.nNick(lArraySizes.aNickNames)
    End Sub

    Private Sub SetINIFiles()
        With lINI
            .iBasePath = Path.GetDirectoryName(Application.ExecutablePath) & "\"
            .iNotepad = lINI.iBasePath & "data\config\notepad.txt"
            .iPlaylists = lINI.iBasePath & "data\config\playlists.ini"
            .iQueryLogs = lINI.iBasePath & "data\logs\query.txt"
            .iNotify = lINI.iBasePath & "data\config\notify.ini"
            .iStringSettings = lINI.iBasePath & "data\config\stringsettings.ini"
            .iNetworks = lINI.iBasePath & "data\config\networks.ini"
            .iDCC = lINI.iBasePath & "data\config\dcc.ini"
            .iQuery = lINI.iBasePath & "data\config\query.ini"
            .iServers = lINI.iBasePath & "data\config\servers.ini"
            .iIRC = lINI.iBasePath & "data\config\settings.ini"
            .iNicks = lINI.iBasePath & "data\config\nicknames.ini"
            .iIdent = lINI.iBasePath & "data\config\Ident.ini"
            .iErrors = lINI.iBasePath & "data\config\errors.ini"
            .iChannelFolders = lINI.iBasePath & "data\config\channelfolders.ini"
            .iText = lINI.iBasePath & "data\config\text.ini"
            .iCommands = lINI.iBasePath & "data\config\commands.ini"
            .iServices = lINI.iBasePath & "data\config\services.ini"
            .iDownloadManager = lINI.iBasePath & "data\config\downloadmanager.ini"
            .iRecientServers = lINI.iBasePath & "data\config\recientservers.ini"
            .iMedia = lINI.iBasePath & "data\config\media.ini"
            .iCompatibility = lINI.iBasePath & "data\config\compatibility.ini"
        End With
    End Sub
    Private Sub LoadNickNames()
        Dim i As Integer
        With lIRC.iNicks
            .nCount = Convert.ToInt32(IniFileHelper.ReadINI(lINI.iNicks, "Settings", "Count", "0"))
            If .nCount <> 0 Then .nIndex = Convert.ToInt32(IniFileHelper.ReadINI(lINI.iNicks, "Settings", "Index", "0"))
        End With
        If lIRC.iNicks.nCount <> 0 Then
            For i = 1 To lIRC.iNicks.nCount
                With lIRC.iNicks.nNick(i)
                    .nNick = IniFileHelper.ReadINI(lINI.iNicks, Trim(Str(i)), "Nick", "")
                End With
            Next i
        End If
    End Sub

    Private Sub LoadIdent()
        With lIRC.iIdent
            .iSettings.iEnabled = Convert.ToBoolean(IniFileHelper.ReadINI(lINI.iIdent, "Settings", "Enabled", Convert.ToString(True)))
            If .iSettings.iEnabled = True Then
                .iUserID = IniFileHelper.ReadINI(lINI.iIdent, "Settings", "UserID", "")
                .iPort = Convert.ToInt64(IniFileHelper.ReadINI(lINI.iIdent, "Settings", "Port", "0"))
                .iSystem = IniFileHelper.ReadINI(lINI.iIdent, "Settings", "System", "")
            End If
        End With
    End Sub

    Private Sub LoadServers()
        Dim msg As String, msg2 As String, splt() As String, splt2() As String
        Dim lIndex As Integer
        ReDim lServers.sServer(lArraySizes.aServers)
        msg2 = My.Computer.FileSystem.ReadAllText(lINI.iServers)
        splt = Split(msg2, Environment.NewLine)
        For Each msg In splt
            If LCase(msg) = "[settings]" Then
            Else
                If Left(msg, 1) = "[" And Right(msg, 1) = "]" Then
                    lIndex = Convert.ToInt32(Trim(TextHelper.ParseData(msg, "[", "]")))
                    lServers.sCount = lIndex
                Else
                    splt2 = Split(msg, "=")
                    Select Case LCase(splt2(0))
                        Case "count"
                            lServers.sCount = Convert.ToInt32(Trim(splt2(1)))
                        Case "index"
                            lServers.sIndex = Convert.ToInt32(Trim(splt2(1)))
                        Case "description"
                            lServers.sServer(lIndex).sDescription = splt2(1).ToString
                        Case "ip"
                            lServers.sServer(lIndex).sIP = splt2(1).ToString
                        Case "networkindex"
                            lServers.sServer(lIndex).sNetworkIndex = Convert.ToInt32(Trim(splt2(1)))
                        Case "port"
                            lServers.sServer(lIndex).sPort = Convert.ToInt32(Trim(splt2(1).ToString))
                    End Select
                End If
            End If
        Next msg
        If Err.Number <> 0 Then MsgBox(Err.Description)
    End Sub

    Public Sub LoadStringSettings()
        Dim i As Integer
        With lIRC.iSettings.sStringSettings
            i = 0
            i = Convert.ToInt32(Trim(IniFileHelper.ReadINI(lINI.iStringSettings, "Settings", "Unknowns", "2")))
            Select Case i
                Case 1
                    .sUnknowns = eUnknownsIn.uStatusWindow
                Case 2
                    .sUnknowns = eUnknownsIn.uOwnWindow
                Case 3
                    .sUnknowns = eUnknownsIn.uHide
            End Select
            i = 0
            i = Convert.ToInt32(Trim(IniFileHelper.ReadINI(lINI.iStringSettings, "Settings", "Unsupported", "2")))
            Select Case i
                Case 1
                    .sUnsupported = eUnsupportedIn.uStatusWindow
                Case 2
                    .sUnsupported = eUnsupportedIn.uOwnWindow
                Case 3
                    .sUnsupported = eUnsupportedIn.uHide
            End Select
            '.sServerInNotices = Convert.ToBoolean(Trim(IniFileHelper.ReadINI(lINI.iStringSettings, "Settings", "ServerInNotices", "True")))
        End With
    End Sub

    Private Sub LoadDownloadManager()
        Dim i As Integer
        ReDim lDownloadManager.dDownload(lArraySizes.aDownloadManager)
        With lDownloadManager
            .dCount = Convert.ToInt32(Trim(IniFileHelper.ReadINI(lINI.iDownloadManager, "Settings", "Count", "0")))
            For i = 1 To .dCount
                .dDownload(i).dFileName = IniFileHelper.ReadINI(lINI.iDownloadManager, Trim(i.ToString), "FileName", "")
                .dDownload(i).dFilePath = IniFileHelper.ReadINI(lINI.iDownloadManager, Trim(i.ToString), "FilePath", "")
                .dDownload(i).dNickName = IniFileHelper.ReadINI(lINI.iDownloadManager, Trim(i.ToString), "NickName", "")
            Next i
        End With
    End Sub

    Public Sub SetListViewToDownloadManager(ByVal lListView As ListView)
        Dim i As Integer
        For i = 1 To lDownloadManager.dCount
            With lDownloadManager.dDownload(i)
                lListView.Items.Add(.dFileName, 0)
            End With
        Next i
    End Sub

    Public Sub LoadSettings()
        If lIRC.iInitialized = False Then
            mdiMain.SetLoadingFormProgress("Setting INI Files", 5)
            SetINIFiles()
            mdiMain.SetLoadingFormProgress("Loading Recient Servers", 11)
            LoadRecientServers()
            mdiMain.SetLoadingFormProgress("Loading Services", 12)
            lSettings_Services.LoadServices()
            mdiMain.SetLoadingFormProgress("Loading String Settings", 15)
            LoadStringSettings()
            'mdiMain.SetLoadingFormProgress("Loading Channel Folders", 17)
            'LoadChannelFolders()
            mdiMain.SetLoadingFormProgress("Loading Nicknames", 22)
            LoadNickNames()
            mdiMain.SetLoadingFormProgress("Loading Ident", 25)
            LoadIdent()
            'mdiMain.SetLoadingFormProgress("Loading Networks", 27)
            'LoadNetworks()
            mdiMain.SetLoadingFormProgress("Loading Servers", 32)
            LoadServers()
            mdiMain.SetLoadingFormProgress("Loading Modes", 50)
            LoadModes()
            mdiMain.SetLoadingFormProgress("Loading Notify List", 52)
            LoadNotifyList()
            mdiMain.SetLoadingFormProgress("Loading Bot Commands", 55)
            lStrings.LoadCommands()
            mdiMain.SetLoadingFormProgress("Loading Compatibility", 60)
            LoadCompatibility()
            mdiMain.SetLoadingFormProgress("Loading DCC Settings", 65)
            lSettings_DCC.LoadDCCSettings()
            mdiMain.SetLoadingFormProgress("Loading Download Manager", 68)
            LoadDownloadManager()
            mdiMain.SetLoadingFormProgress("Loading IRC Settings", 70)
            With lIRC.iSettings
                .sChannelFolderCloseOnJoin = Convert.ToBoolean(IniFileHelper.ReadINI(lINI.iIRC, "Settings", "ChannelFolderCloseOnJoin", "True"))
                .sShowUserAddresses = Convert.ToBoolean(IniFileHelper.ReadINI(lINI.iIRC, "Settings", "ShowUserAddresses", "True"))
                .sHideMOTD = Convert.ToBoolean(IniFileHelper.ReadINI(lINI.iIRC, "Settings", "HideMOTD", "True"))
                .sPrompts = Convert.ToBoolean(IniFileHelper.ReadINI(lINI.iIRC, "Settings", "Prompts", "True"))
                .sShowRawWindow = Convert.ToBoolean(IniFileHelper.ReadINI(lINI.iIRC, "Settings", "ShowRawWindow", "False"))
                .sExtendedMessages = Convert.ToBoolean(IniFileHelper.ReadINI(lINI.iIRC, "Settings", "ExtendedMessages", "True"))
                .sNoIRCMessages = Convert.ToBoolean(IniFileHelper.ReadINI(lINI.iIRC, "Settings", "NoIRCMessages", "False"))
                .sCustomizeOnStartup = Convert.ToBoolean(IniFileHelper.ReadINI(lINI.iIRC, "Settings", "ShowCustomizeOnStartup", "False"))
                .sPopupChannelFolders = Convert.ToBoolean(IniFileHelper.ReadINI(lINI.iIRC, "Settings", "PopupChannelFolders", "True"))
                .sMOTDInOwnWindow = Convert.ToBoolean(IniFileHelper.ReadINI(lINI.iIRC, "Settings", "MOTDInOwnWindow", "True"))
                .sAutoSelectAlternateNickname = Convert.ToBoolean(IniFileHelper.ReadINI(lINI.iIRC, "Settings", "AutoSelectAlternateNickname", "True"))
                .sChangeNickNameWindow = Convert.ToBoolean(IniFileHelper.ReadINI(lINI.iIRC, "Settings", "ChangeNickNameWindow", "True"))
                .sNoticesInOwnWindow = Convert.ToBoolean(IniFileHelper.ReadINI(lINI.iIRC, "Settings", "NoticesInOwnWindow", "True"))
                .sURL = IniFileHelper.ReadINI(lINI.iIRC, "Settings", "URL", "http://www.bing.com")
                .sShowWindowsAutomatically = Convert.ToBoolean(IniFileHelper.ReadINI(lINI.iIRC, "Settings", "ShowWindowsAutomatically", "False"))
                .sAutoMaximize = Convert.ToBoolean(IniFileHelper.ReadINI(lINI.iIRC, "Settings", "AutoMaximize", "False"))
                .sQuitMessage = IniFileHelper.ReadINI(lINI.iIRC, "Settings", "QuitMessage", "nexIRC - http://www.team-nexgen.org/")
                .sAutoConnect = Convert.ToBoolean(IniFileHelper.ReadINI(lINI.iIRC, "Settings", "AutoConnect", "False"))
                .sVideoBackground = Convert.ToBoolean(IniFileHelper.ReadINI(lINI.iIRC, "Settings", "VideoBackground", "True"))
                .sAutoNavigateChannelUrls = Convert.ToBoolean(IniFileHelper.ReadINI(lINI.iIRC, "Settings", "AutoNavigateChannelUrls", "True"))
                .sCloseWindowOnDisconnect = Convert.ToBoolean(IniFileHelper.ReadINI(lINI.iIRC, "Settings", "CloseWindowOnDisconnect", "False"))
                .sAutoAddToChannelFolder = Convert.ToBoolean(IniFileHelper.ReadINI(lINI.iIRC, "Settings", "AutoAddToChannelFolder", "True"))
                .sWindowSizes.iChannel.wWidth = Convert.ToInt32(Trim(IniFileHelper.ReadINI(lINI.iIRC, "Settings", "InitialChannelWidth", "600")))
                .sWindowSizes.iChannel.wHeight = Convert.ToInt32(Trim(IniFileHelper.ReadINI(lINI.iIRC, "Settings", "InitialChannelHeight", "200")))
                .sWindowSizes.lStatus.wWidth = Convert.ToInt32(Trim(IniFileHelper.ReadINI(lINI.iIRC, "Settings", "InitialStatusWidth", "600")))
                .sWindowSizes.lStatus.wHeight = Convert.ToInt32(Trim(IniFileHelper.ReadINI(lINI.iIRC, "Settings", "InitialStatusHeight", "200")))
                .sWindowSizes.iNotice.wWidth = Convert.ToInt32(Trim(IniFileHelper.ReadINI(lINI.iIRC, "Settings", "InitialNoticeWidth", "600")))
                .sWindowSizes.iNotice.wHeight = Convert.ToInt32(Trim(IniFileHelper.ReadINI(lINI.iIRC, "Settings", "InitialNoticeHeight", "200")))
                .sTextBufferSize = Convert.ToInt32(IniFileHelper.ReadINI(lINI.iIRC, "Settings", "TextBufferSize", "150"))
            End With
            With lIRC
                .iEMail = IniFileHelper.ReadINI(lINI.iIRC, "Settings", "EMail", "user@team-nexgen.org")
                .iPass = IniFileHelper.ReadINI(lINI.iIRC, "Settings", "Password", "")
                .iRealName = IniFileHelper.ReadINI(lINI.iIRC, "Settings", "RealName", "nexIRC User")
                .iOperName = IniFileHelper.ReadINI(lINI.iIRC, "Settings", "OperName", "")
                .iOperPass = IniFileHelper.ReadINI(lINI.iIRC, "Settings", "OperPass", "")
            End With
        End If
        mdiMain.SetLoadingFormProgress("Loading Strings", 80)
        lStrings.LoadStrings()
        'mdiMain.SetLoadingFormProgress("Loading Query Settings", 95)
    End Sub

    Public Sub SaveWindowSizes()
        With lIRC.iSettings
            IniFileHelper.WriteINI(lINI.iIRC, "Settings", "InitialChannelWidth", .sWindowSizes.iChannel.wWidth.ToString.Trim)
            IniFileHelper.WriteINI(lINI.iIRC, "Settings", "InitialChannelHeight", .sWindowSizes.iChannel.wHeight.ToString.Trim)
            IniFileHelper.WriteINI(lINI.iIRC, "Settings", "InitialStatusWidth", .sWindowSizes.lStatus.wWidth.ToString.Trim)
            IniFileHelper.WriteINI(lINI.iIRC, "Settings", "InitialStatusHeight", .sWindowSizes.lStatus.wHeight.ToString.Trim)
            IniFileHelper.WriteINI(lINI.iIRC, "Settings", "InitialNoticeWidth", .sWindowSizes.iNotice.wWidth.ToString.Trim)
            IniFileHelper.WriteINI(lINI.iIRC, "Settings", "InitialNoticeHeight", .sWindowSizes.iNotice.wHeight.ToString.Trim)
        End With
    End Sub

    Public Sub StartupSettings()
        With lIRC.iSettings
            If .sCustomizeOnStartup = True Then
                frmCustomize.Show()
            End If
        End With
    End Sub

    Public Function FindDownloadManagerIndexByFileName(ByVal fileName As String) As Integer
        Dim i As Integer, result As Integer
        Try
            If (Not String.IsNullOrEmpty(fileName)) Then
                For i = 1 To lDownloadManager.dCount
                    With lDownloadManager.dDownload(i)
                        If LCase(fileName) = LCase(.dFileName) Then
                            result = i
                            Exit For
                        End If
                    End With
                Next i
            End If
            Return result
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Sub AddToDownloadManager(ByVal lFile As String, ByVal lNickname As String, Optional ByVal lShowDownloadManager As Boolean = False)
        Dim msg As String, msg2 As String
        msg = System.IO.Path.GetFileName(lFile)
        msg2 = Left(lFile, Len(lFile) - Len(msg))
        If Len(msg) <> 0 And Len(msg2) <> 0 And Len(lNickname) <> 0 Then
            If FindDownloadManagerIndexByFileName(msg) = 0 Then
                lDownloadManager.dCount = lDownloadManager.dCount + 1
                With lDownloadManager.dDownload(lDownloadManager.dCount)
                    .dFileName = msg
                    .dFilePath = msg2
                    .dNickName = lNickname
                End With
                SaveDownloadManagerSettings()
                If lShowDownloadManager = True Then frmDownloadManager.Show()
            End If
        End If
    End Sub

    Public Sub RemoveFromDownloadManager(ByVal lIndex As Integer)
        If lIndex <> 0 Then
            With lDownloadManager.dDownload(lIndex)
                .dFileName = ""
                .dFilePath = ""
                .dNickName = ""
                IniFileHelper.WriteINI(lINI.iDownloadManager, Trim(lIndex.ToString), "FileName", "")
                IniFileHelper.WriteINI(lINI.iDownloadManager, Trim(lIndex.ToString), "FilePath", "")
                IniFileHelper.WriteINI(lINI.iDownloadManager, Trim(lIndex.ToString), "NickName", "")
            End With
        End If
    End Sub

    Private Sub SaveDownloadManagerSettings()
        Dim lFileName(300) As String, lFilePath(300) As String, lNickName(300) As String, i As Integer, n As Integer
        For i = 1 To lDownloadManager.dCount
            With lDownloadManager.dDownload(i)
                If Len(.dFileName) <> 0 And Len(.dFilePath) <> 0 And Len(.dNickName) <> 0 Then
                    n = n + 1
                    lFileName(n) = .dFileName
                    lFilePath(n) = .dFilePath
                    lNickName(n) = .dNickName
                End If
            End With
        Next i
        If n <> 0 Then
            IniFileHelper.WriteINI(lINI.iDownloadManager, "Settings", "Count", Trim(lDownloadManager.dCount.ToString))
            For i = 1 To n
                IniFileHelper.WriteINI(lINI.iDownloadManager, Trim(i.ToString), "FileName", lFileName(i))
                IniFileHelper.WriteINI(lINI.iDownloadManager, Trim(i.ToString), "FilePath", lFilePath(i))
                IniFileHelper.WriteINI(lINI.iDownloadManager, Trim(i.ToString), "NickName", lNickName(i))
            Next i
        End If
    End Sub

    Private Sub SaveIdentdSettings()
        With lIRC.iIdent
            IniFileHelper.WriteINI(lINI.iIdent, "Settings", "UserID", .iUserID)
            IniFileHelper.WriteINI(lINI.iIdent, "Settings", "System", .iSystem)
            IniFileHelper.WriteINI(lINI.iIdent, "Settings", "Port", Trim(Convert.ToString(.iPort)))
            IniFileHelper.WriteINI(lINI.iIdent, "Settings", "Enabled", Trim(.iSettings.iEnabled.ToString))
        End With
    End Sub

    Public Function ReturnNickIndex(ByVal nickName As String) As Integer
        Dim i As Integer, result As Integer
        Try
            If (Not String.IsNullOrEmpty(nickName)) Then
                For i = 1 To lIRC.iNicks.nCount
                    With lIRC.iNicks.nNick(i)
                        If (nickName.ToLower() = .nNick.ToLower) Then
                            result = i
                            Exit For
                        End If
                    End With
                Next i
            End If
            Return result
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Private Sub SaveNickNames()
        Dim nickNames As List(Of String), i As Integer, nickName As String, n As Integer
        Try
            nickNames = New List(Of String)
            For i = 1 To lIRC.iNicks.nCount
                If (Not String.IsNullOrEmpty(lIRC.iNicks.nNick(i).nNick)) Then
                    nickNames.Add(lIRC.iNicks.nNick(i).nNick)
                End If
            Next i
            nickNames = nickNames.Distinct().ToList()
            n = 0
            For Each nickName In nickNames
                n = n + 1
                IniFileHelper.WriteINI(lINI.iNicks, n.ToString(), "Nick", nickName)
            Next nickName
            If (lIRC.iNicks.nIndex <> 0) Then IniFileHelper.WriteINI(lINI.iNicks, "Settings", "Index", lIRC.iNicks.nIndex.ToString())
            If (lIRC.iNicks.nIndex <> 0) Then IniFileHelper.WriteINI(lINI.iNicks, "Settings", "Count", n.ToString())
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub SaveSettings()
        With lIRC.iSettings
            IniFileHelper.WriteINI(lINI.iIRC, "Settings", "TextBufferSize", .sTextBufferSize.ToString().Trim())
            IniFileHelper.WriteINI(lINI.iIRC, "Settings", "AutoNavigateChannelUrls", Trim(.sAutoNavigateChannelUrls.ToString))
            IniFileHelper.WriteINI(lINI.iIRC, "Settings", "ChannelFolderCloseOnJoin", Trim(.sChannelFolderCloseOnJoin.ToString))
            IniFileHelper.WriteINI(lINI.iIRC, "Settings", "VideoBackground", Trim(.sVideoBackground.ToString))
            IniFileHelper.WriteINI(lINI.iIRC, "Settings", "QuitMessage", .sQuitMessage)
            IniFileHelper.WriteINI(lINI.iIRC, "Settings", "Prompts", Trim(.sPrompts.ToString))
            IniFileHelper.WriteINI(lINI.iIRC, "Settings", "ShowUserAddresses", Trim(.sShowUserAddresses.ToString))
            IniFileHelper.WriteINI(lINI.iIRC, "Settings", "URL", .sURL)
            IniFileHelper.WriteINI(lINI.iIRC, "Settings", "MOTDInOwnWindow", Trim(.sMOTDInOwnWindow.ToString))
            IniFileHelper.WriteINI(lINI.iIRC, "Settings", "PopupChannelFolders", Trim(.sPopupChannelFolders.ToString))
            IniFileHelper.WriteINI(lINI.iIRC, "Settings", "ShowCustomizeOnStartup", Trim(.sCustomizeOnStartup.ToString))
            IniFileHelper.WriteINI(lINI.iIRC, "Settings", "NoIRCMessages", Trim(.sNoIRCMessages.ToString))
            IniFileHelper.WriteINI(lINI.iIRC, "Settings", "ExtendedMessages", Trim(.sExtendedMessages.ToString))
            IniFileHelper.WriteINI(lINI.iIRC, "Settings", "ChangeNickNameWindow", Trim(.sChangeNickNameWindow.ToString))
            IniFileHelper.WriteINI(lINI.iIRC, "Settings", "AutoSelectAlternateNickname", Trim(.sAutoSelectAlternateNickname.ToString))
            IniFileHelper.WriteINI(lINI.iIRC, "Settings", "NoticesInOwnWindow", Trim(.sNoticesInOwnWindow.ToString))
            IniFileHelper.WriteINI(lINI.iIRC, "Settings", "HideMOTD", Trim(.sHideMOTD.ToString))
            IniFileHelper.WriteINI(lINI.iIRC, "Settings", "ShowRawWindow", Trim(.sShowRawWindow.ToString))
            IniFileHelper.WriteINI(lINI.iIRC, "Settings", "ShowWindowsAutomatically", Trim(.sShowWindowsAutomatically.ToString))
            IniFileHelper.WriteINI(lINI.iIRC, "Settings", "AutoMaximize", Trim(.sAutoMaximize.ToString))
            IniFileHelper.WriteINI(lINI.iIRC, "Settings", "AutoConnect", Trim(.sAutoConnect.ToString))
            IniFileHelper.WriteINI(lINI.iIRC, "Settings", "CloseWindowOnDisconnect", Trim(.sCloseWindowOnDisconnect.ToString))
            SaveWindowSizes()
        End With
        With lIRC.iSettings.sStringSettings
            IniFileHelper.WriteINI(lINI.iStringSettings, "Settings", "Unknowns", Trim(Str(.sUnknowns)))
            IniFileHelper.WriteINI(lINI.iStringSettings, "Settings", "Unsupported", Trim(Str(.sUnsupported)))
        End With
        With lIRC.iModes
            IniFileHelper.WriteINI(lINI.iIRC, "Settings", "Invisible", Trim(.mInvisible.ToString))
            IniFileHelper.WriteINI(lINI.iIRC, "Settings", "LocalOperator", Trim(.mLocalOperator.ToString))
            IniFileHelper.WriteINI(lINI.iIRC, "Settings", "Operator", Trim(.mOperator.ToString))
            IniFileHelper.WriteINI(lINI.iIRC, "Settings", "Restricted", Trim(.mRestricted.ToString))
            IniFileHelper.WriteINI(lINI.iIRC, "Settings", "ServerNotices", Trim(.mServerNotices.ToString))
            IniFileHelper.WriteINI(lINI.iIRC, "Settings", "Wallops", Trim(.mWallops.ToString))
        End With
        With lIRC
            IniFileHelper.WriteINI(lINI.iIRC, "Settings", "OperName", .iOperName)
            IniFileHelper.WriteINI(lINI.iIRC, "Settings", "OperPass", .iOperPass)
            IniFileHelper.WriteINI(lINI.iIRC, "Settings", "EMail", .iEMail)
            IniFileHelper.WriteINI(lINI.iIRC, "Settings", "Password", .iPass)
            IniFileHelper.WriteINI(lINI.iIRC, "Settings", "RealName", .iRealName)
        End With
        SaveCompatibility()
        SaveRecientServers()
        lSettings_Services.SaveServices()
        SaveIdentdSettings()
        SaveNickNames()
        SaveServers()
        SaveNotifyList()
        lSettings_DCC.SaveDCCSettings()
        SaveDownloadManagerSettings()
    End Sub

    Public Function AddServer(ByVal lDescription As String, ByVal lIp As String, ByVal lNetworkIndex As Integer, ByVal lPort As Long) As Integer
        If Len(lDescription) <> 0 And Len(lIp) <> 0 Then
            lServers.sModified = True
            lServers.sCount = lServers.sCount + 1
            With lServers.sServer(lServers.sCount)
                .sDescription = lDescription
                .sIP = lIp
                .sNetworkIndex = lNetworkIndex
                .sPort = lPort
            End With
            SaveServers()
            If lWinVisible.wCustomize = True Then frmCustomize.lCustomize.RefreshServers(frmCustomize.ServersListView, lNetworkIndex)
        End If
        AddServer = lServers.sCount
    End Function

    'Public Function AddNetwork(ByVal lDescription As String) As Integer
    'If Len(lDescription) <> 0 Then
    'lNetworks.nCount = lNetworks.nCount + 1
    'With lNetworks.nNetwork(lNetworks.nCount)
    '.nDescription = lDescription
    'End With
    'If lWinVisible.wCustomize = True Then
    'frmCustomize.lCustomize.RefreshNetworks(frmCustomize.cboNetworks)
    'frmCustomize.cboNetworks.Text = lDescription
    'End If
    'End If
    ''SaveNetworks()
    'AddNetwork = lNetworks.nCount
    'End Function

    Public Sub SaveServers()
        Dim i As Integer
        IniFileHelper.WriteINI(lINI.iServers, "Settings", "Count", lServers.sCount.ToString().Trim)
        IniFileHelper.WriteINI(lINI.iServers, "Settings", "Index", lServers.sIndex.ToString().Trim)
        For i = 1 To lServers.sCount
            With lServers.sServer(i)
                IniFileHelper.WriteINI(lINI.iServers, Trim(Convert.ToString(i)), "Ip", .sIP)
                IniFileHelper.WriteINI(lINI.iServers, Trim(Convert.ToString(i)), "Port", Trim(Convert.ToString(.sPort)))
                IniFileHelper.WriteINI(lINI.iServers, Trim(Convert.ToString(i)), "Description", .sDescription)
                IniFileHelper.WriteINI(lINI.iServers, Trim(Convert.ToString(i)), "NetworkIndex", Trim(.sNetworkIndex.ToString))
            End With
        Next i
    End Sub

    Public Function FindServerIndexByIp(ByVal lIp As String) As Integer
        Dim i As Integer, result As Integer
        Try
            If (Not String.IsNullOrEmpty(lIp)) Then
                For i = 1 To lServers.sCount
                    With lServers.sServer(i)
                        If (.sIP.ToLower() = lIp.ToLower()) Then
                            result = i
                            Exit For
                        End If
                    End With
                Next i
            End If
            Return result
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Function FindServerIndex(ByVal lDescription As String) As Integer
        Dim i As Integer, result As Integer
        Try
            If (Not String.IsNullOrEmpty(lDescription)) Then
                For i = 1 To lServers.sCount
                    With lServers.sServer(i)
                        If .sDescription.ToLower() = lDescription.ToLower() Then
                            result = i
                            Exit For
                        End If
                    End With
                Next i
            End If
            Return result
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    'Public Function FindNetworkIndex(ByVal description As String) As Integer
    'Dim i As Integer, result As Integer
    'Try
    'If (description = Nothing) Then description = ""
    'For i = 1 To lNetworks.nCount
    'If (description.Trim().ToLower() = lNetworks.nNetwork(i).nDescription.Trim().ToLower()) Then
    'result = i
    'Exit For
    'End If
    'Next i
    'Return result
    ''Catch ex As Exception
    ''Throw ex
    ''Return Nothing
    ''End Try
    'End Function

    Public Sub FillComboWithServers(ByVal lCombo As ComboBox, Optional ByVal lNetworkIndex As Integer = 0, Optional ByVal lClearCombo As Boolean = False)
        Try
            Dim i As Integer
            If lClearCombo = True Then lCombo.Items.Clear()
            For i = 1 To lServers.sCount
                With lServers.sServer(i)
                    If (.sDescription IsNot Nothing) Then
                        If (.sDescription.Length <> 0) Then
                            If lNetworkIndex <> 0 Then
                                If lNetworkIndex = .sNetworkIndex Then
                                    lCombo.Items.Add(.sDescription)
                                End If
                            Else
                                lCombo.Items.Add(.sDescription)
                            End If
                        End If
                    End If
                End With
            Next i
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Public Sub FillComboWithServers(Optional ByVal lServerIndex As Integer = 0)")
        End Try
    End Sub

    Public Sub FillRadComboWithNetworks(ByVal _RadDropDownList As RadDropDownList, Optional ByVal _Clear As Boolean = False)
        Try
            If _Clear = True Then _RadDropDownList.Items.Clear()
            For Each network In Modules.IrcSettings.IrcNetworks.Get()
                If (Not String.IsNullOrEmpty(network.Description)) Then
                    _RadDropDownList.Items.Add(network.Description)
                End If
            Next network
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub FillComboWithNetworks(ByVal lCombo As ComboBox, Optional ByVal lClearCombo As Boolean = False)
        Try
            'Dim i As Integer
            If lClearCombo = True Then lCombo.Items.Clear()
            For Each network In Modules.IrcSettings.IrcNetworks.Get()
                If (Not String.IsNullOrEmpty(network.Description)) Then
                    lCombo.Items.Add(network.Description)
                End If
            Next network
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function FindNickNameIndex(ByVal lNickName As String) As Integer
        Dim result As Integer
        Try
            Dim i As Integer
            If Len(lNickName) <> 0 Then
                For i = 1 To lIRC.iNicks.nCount
                    With lIRC.iNicks.nNick(i)
                        If LCase(lNickName) = LCase(.nNick) Then
                            result = i
                            Exit For
                        End If
                    End With
                Next i
            End If
            Return result
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Function AddNickName(ByVal lNickName As String) As Integer
        Dim result As Integer
        Try
            If Len(lNickName) <> 0 Then
                If FindNickNameIndex(lNickName) <> 0 Then Return 0
                lIRC.iNicks.nCount = lIRC.iNicks.nCount + 1
                With lIRC.iNicks.nNick(lIRC.iNicks.nCount)
                    .nNick = lNickName
                    result = lIRC.iNicks.nCount
                End With
                SaveNickNames()
                If lWinVisible.wCustomize = True Then frmCustomize.cboMyNickNames.Items.Add(lNickName)
            End If
            Return result
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Function ShowPrompts() As Boolean
        Try
            With lIRC.iSettings
                Return .sPrompts
            End With
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Sub LoadModes()
        Try
            With lIRC.iModes
                .mInvisible = Convert.ToBoolean(IniFileHelper.ReadINI(lINI.iIRC, "Settings", "Invisible", "True"))
                .mLocalOperator = Convert.ToBoolean(IniFileHelper.ReadINI(lINI.iIRC, "Settings", "LocalOperator", "False"))
                .mOperator = Convert.ToBoolean(IniFileHelper.ReadINI(lINI.iIRC, "Settings", "Operator", "False"))
                .mRestricted = Convert.ToBoolean(IniFileHelper.ReadINI(lINI.iIRC, "Settings", "Restricted", "False"))
                .mServerNotices = Convert.ToBoolean(IniFileHelper.ReadINI(lINI.iIRC, "Settings", "ServerNotices", "True"))
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub RemoveServer(ByVal lIndex As Integer)
        Try
            If lIndex <> 0 Then
                lServers.sModified = True
                With lServers.sServer(lIndex)
                    .sDescription = ""
                    .sIP = ""
                    .sNetworkIndex = 0
                    .sPort = 0
                End With
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class