﻿Option Explicit On
Option Strict On
Imports nexIRC.clsIrcNumerics
Imports nexIRC.Modules
Imports nexIRC.nexIRC.MainWindow.clsMainWindowUI
Imports nexIRC.Business.Helpers

Public Class clsProcessNumeric
    Private Delegate Sub StatusDataDelegate(ByVal lStatusIndex As Integer, ByVal lData As String)
    Private Delegate Sub JoinPartDelegate(ByVal lStatusIndex As Integer, ByVal lData As String)
    Private Delegate Sub QuitDelegate(ByVal lStatusIndex As Integer, ByVal lData As String)
    Private Delegate Sub ProcessReplaceStringDelegate1(ByVal lStatusIndex As Integer, ByVal lType As eStringTypes, ByVal r1 As String)
    Public WithEvents lIrcNumericHelper As New clsIrcNumericHelper

    Public Sub ProcessDataArrivalLine(ByVal lStatusIndex As Integer, ByVal lData As String)
        Try
            Dim splt() As String, splt2() As String, splt3() As String, splt4() As String, i As Integer, n As Integer, msg As String, msg2 As String, msg3 As String, b As Boolean
            lData = Trim(lData)
            If (lData.Length = 0) Then
                Exit Sub
            End If
            If Left(LCase(lData), 21) = "error :closing link: " Then
                lStatus.CloseStatusConnection(lStatusIndex, False)
                Exit Sub
            End If
            lStatus.Raw_AddText(lStatusIndex, lData, True)
            If Left(LCase(lData), 7) = "version" Then
                If lSettings.lIRC.iSettings.sExtendedMessages = True Then lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sVERSION_REQUEST)
                msg = lStrings.ReturnReplacedString(eStringTypes.sVERSION_REPLY)
                lStatus.SendSocket(lStatusIndex, msg)
                Exit Sub
            End If
            If Left(LCase(lData), 13) = "notice auth :" Then
                splt2 = Split(lData, ":")
                lStatus.ActiveIndex = lStatusIndex
                If InStr(UCase(splt2(1)), "/QUOTE PASS ") <> 0 Then
                    Dim ps() As String
                    ps = Split(splt2(1), "/")
                    msg = Replace(ps(1), "QUOTE PASS", "")
                    lStatus.DoStatusSocket(lStatusIndex, "PASS " & msg)
                    Exit Sub
                End If
                lStatus.Notices_Add(lStatusIndex, Replace(splt2(1), "***", ""))
                Exit Sub
            End If
            If InStr(LCase(lData), "notice auth :", CompareMethod.Text) <> 0 Then
                splt2 = Split(lData, ":")
                Select Case UBound(splt2)
                    Case 1
                        lStatus.Notices_Add(lStatusIndex, splt2(1))
                    Case 2
                        lStatus.Notices_Add(lStatusIndex, splt2(1), splt2(2))
                End Select
                Exit Sub
            End If
            If Left(LCase(Trim(lData)), 10) = "*** notice" Then
                lStatus.Notices_Add(lStatusIndex, lData)
                Exit Sub
            End If
            splt = Split(lData, " ")
            If (UBound(splt) > 0) Then
                If (splt(1) = "NOTICE") Then
                    Dim noticeSource As String = splt(0).Remove(0, 1)
                    Dim noticeNickName As String = splt(2)
                    lData = lData.Remove(0, noticeSource.Length + splt(1).Length + noticeNickName.Length + 5).Trim()
                    If (lData.ToLower().Contains("you are now identified for")) Then
                        lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sNICKSERV_LOGIN, noticeNickName)
                        mdiMain.tspQueryPrompt.Visible = False
                    ElseIf lData.ToLower().Contains("nickname is registered") Then
                        mdiMain.ShowQueryBar("This nickname is registered, proceed with NickServ login?", eInfoBar.iNickServ_NickTaken)
                        mdiMain.lblQueryPrompt.Tag = 5
                    Else
                        lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sINCOMING_NOTICE, noticeSource, lData)
                    End If
                    Exit Sub
                End If
            End If
            If Left(LCase(lData), 6) = "ping :" Then
                lStatus.SendSocket(lStatusIndex, "PONG :" & Right(lData, Len(lData) - 6))
                If lSettings.lIRC.iSettings.sExtendedMessages = True Then lStatus.AddText("Ping? Pong!", lStatusIndex)
                Exit Sub
            End If
            If InStr(LCase(lData), "version") <> 0 Then
                msg = lData
                msg = Trim(Replace(msg, "", ""))
                If LCase(msg) = "version" Then Exit Sub
            End If
            'splt = Split(lData, " ")
            If InStr(lData, " 001 ") <> 0 And Left(lData, 1) = ":" Or InStr(lData, " 433 ") <> 0 And Left(lData, 1) = ":" Then
                lStatus.StatusServerName(lStatusIndex) = Replace(splt(0), ":", "")
                lStatus.UpdateCaption(lStatusIndex, lStatus.NickName(lStatusIndex), lStatus.StatusServerName(lStatusIndex))
            End If
            If Left(lData, 1) = ":" Then
                If UBound(splt) > 2 Then
                    If Left(splt(3), 1) <> ":" Then
                        splt(3) = ":" & splt(3)
                        msg = ""
                        For i = 0 To UBound(splt)
                            If Len(msg) <> 0 Then
                                msg = msg & " " & splt(i)
                            Else
                                msg = splt(i)
                            End If
                        Next i
                    Else
                        msg = lData
                    End If
                Else
                    msg = ""
                End If
                splt2 = Split(msg, ":")
                If UBound(splt) <> 0 Then
                    If IsNumeric(splt(1)) = True Then
                        Select Case Convert.ToInt32(Trim(splt(1)))
                            Case 1
                                lStatus.DoModes(lStatusIndex)
                                If lSettings.lIRC.iSettings.sPopupChannelFolders = True Then
                                    lChannelFolder.Show(lStatusIndex)
                                End If
                                lIrcNumericHelper.l001 = lStrings.ReturnReplacedString(eStringTypes.sRPL_WELCOME, Modules.IrcSettings.IrcNetworks.GetById(lStatus.NetworkIndex(lStatusIndex)).Description, splt2(2))
                                Exit Sub
                            Case 2
                                msg2 = Replace(TextHelper.ParseData(splt2(2), "host is ", ","), "ost is ", "")
                                msg2 = Replace(msg2, "host is ", "")
                                msg3 = TextHelper.ParseData(splt2(2), "version ", Right(splt2(2), 2)) & Right(splt2(2), 3)
                                msg3 = Replace(msg3, "ersion", "")
                                msg3 = Replace(msg3, "version", "")
                                lIrcNumericHelper.l002 = lStrings.ReturnReplacedString(eStringTypes.sRPL_YOURHOST, msg2, msg3)
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    If Len(lIrcNumericHelper.l001) <> 0 And Len(lIrcNumericHelper.l002) <> 0 And Len(lIrcNumericHelper.l003) <> 0 And Len(lIrcNumericHelper.l004) <> 0 Then lStatus.ProcessWelcomeMessage(lStatusIndex, lIrcNumericHelper.l001, lIrcNumericHelper.l002, lIrcNumericHelper.l003, lIrcNumericHelper.l004)
                                End If
                                Exit Sub
                            Case 3
                                msg2 = TextHelper.ParseData(splt2(2), "created", Convert.ToString(Right(splt2(2), 1)))
                                msg2 = Replace(splt2(2), "reated", "")
                                lIrcNumericHelper.l003 = lStrings.ReturnReplacedString(eStringTypes.sRPL_CREATED, msg2)
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    If Len(lIrcNumericHelper.l001) <> 0 And Len(lIrcNumericHelper.l002) <> 0 And Len(lIrcNumericHelper.l003) <> 0 And Len(lIrcNumericHelper.l004) <> 0 Then lStatus.ProcessWelcomeMessage(lStatusIndex, lIrcNumericHelper.l001, lIrcNumericHelper.l002, lIrcNumericHelper.l003, lIrcNumericHelper.l004)
                                End If
                                Exit Sub
                            Case 4
                                splt3 = Split(splt2(2), " ")
                                lIrcNumericHelper.l004 = lStrings.ReturnReplacedString(eStringTypes.sRPL_MYINFO, splt3(0), splt3(1), splt3(2), splt3(3))
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    If Len(lIrcNumericHelper.l001) <> 0 And Len(lIrcNumericHelper.l002) <> 0 And Len(lIrcNumericHelper.l003) <> 0 And Len(lIrcNumericHelper.l004) <> 0 Then lStatus.ProcessWelcomeMessage(lStatusIndex, lIrcNumericHelper.l001, lIrcNumericHelper.l002, lIrcNumericHelper.l003, lIrcNumericHelper.l004)
                                End If
                                lIrcNumericHelper.DoNotify(lStatusIndex)
                                Exit Sub
                            Case 5
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_ISUPPORT, splt2(2))
                                End If
                                lIrcNumericHelper.ProcessISUPPORT(lData)
                                Exit Sub
                            Case 6
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_MAP, splt2(2))
                                End If
                                Exit Sub
                            Case 7
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_MAPEND, splt2(2))
                                End If
                                Exit Sub
                            Case 8
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_SNOMASK, splt2(2))
                                End If
                                Exit Sub
                            Case 9
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_STATMEMTOT, splt2(2))
                                End If
                                Exit Sub
                            Case 10
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_BOUNCE_2, splt2(2))
                                End If
                                Exit Sub
                            Case 20
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_PLEASEWAIT, splt2(2))
                                End If
                                Exit Sub
                            Case 200
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_TRACELINK, splt2(2))
                                End If
                                Exit Sub
                            Case 201
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_TRACECONNECTING, splt2(2))
                                End If
                                Exit Sub
                            Case 202
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_TRACEHANDSHAKE, splt3(1), splt3(2))
                                End If
                                Exit Sub
                            Case 203
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_TRACEUNKNOWN, splt3(1), splt3(4))
                                End If
                                Exit Sub
                            Case 204
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_TRACEOPERATOR, splt3(1), splt3(2))
                                End If
                                Exit Sub
                            Case 205
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_TRACEUSER, splt3(1), splt3(2))
                                End If
                                Exit Sub
                            Case 206
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_TRACESERVER, splt3(1), splt3(4), splt3(5), splt3(6))
                                End If
                                Exit Sub
                            Case 207
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_TRACESERVICE, splt3(1), splt3(2), splt3(3), splt3(4))
                                End If
                                Exit Sub
                            Case 208
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_TRACENEWTYPE, splt3(0), splt3(2))
                                End If
                                Exit Sub
                            Case 209
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_TRACECLASS, splt3(1), splt3(2))
                                End If
                                Exit Sub
                            Case 210
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_TRACERECONNECT, splt2(2))
                                End If
                                Exit Sub
                            Case 211
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_STATSLINKINFO, splt3(0), splt3(1), splt3(2), splt3(3), splt3(4), splt3(5), splt3(6))
                                End If
                                Exit Sub
                            Case 212
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_STATSCOMMANDS, splt3(0), splt3(1), splt3(2), splt3(3))
                                End If
                                Exit Sub
                            Case 213
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_STATSCLINE, splt3(1), splt3(3), splt3(4), splt3(5))
                                End If
                                Exit Sub
                            Case 214
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_STATSNLINE, splt3(1), splt3(3), splt3(4), splt3(5))
                                End If
                                Exit Sub
                            Case 215
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_STATSILINE, splt3(1), splt3(3), splt3(4), splt3(5))
                                End If
                                Exit Sub
                            Case 216
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_STATSKLINE, splt3(1), splt3(3), splt3(4), splt3(5))
                                End If
                                Exit Sub
                            Case 218
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_STATSYLINE, splt3(1), splt3(2), splt3(3), splt3(4))
                                End If
                                Exit Sub
                            Case 219
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_ENDOFSTATS, splt3(0), Replace(splt3(1), ":", ""))
                                End If
                                Exit Sub
                            Case 221
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_UMODEIS, splt3(0), splt3(1))
                                End If
                                Exit Sub
                            Case 234
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_SERVLIST, splt3(0), splt3(1), splt3(2), splt3(3), splt3(4), splt3(5))
                                End If
                                Exit Sub
                            Case 235
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_SERVLISTEND, splt3(0), splt3(1), splt3(2))
                                End If
                                Exit Sub
                            Case 241
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_STATSLLINE, splt3(1), splt3(3), splt3(4))
                                End If
                                Exit Sub
                            Case 242
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_STATSUPTIME, splt2(2))
                                End If
                                Exit Sub
                            Case 243
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_STATSOLINE, splt3(1), splt3(3), splt3(4))
                                End If
                                Exit Sub
                            Case 244
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_STATSHLINE, splt3(1), splt3(3))
                                End If
                                Exit Sub
                            Case 250
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    If UBound(splt2) > 2 Then
                                        lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_STATSCONN, splt2(3))
                                    End If
                                End If
                                Exit Sub
                            Case 251
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lIrcNumericHelper.l251 = lStrings.ReturnReplacedString(eStringTypes.sRPL_LUSERCLIENT, splt2(2))
                                    If lStatus.TimerWaitForLUsersEnabled(lStatusIndex) = False Then lStatus.TimerWaitForLUsersEnabled(lStatusIndex) = True
                                End If
                                Exit Sub
                            Case 252
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lIrcNumericHelper.l252 = lStrings.ReturnReplacedString(eStringTypes.sRPL_LUSEROP, splt2(2))
                                    If lStatus.TimerWaitForLUsersEnabled(lStatusIndex) = False Then lStatus.TimerWaitForLUsersEnabled(lStatusIndex) = True
                                End If
                                Exit Sub
                            Case 253
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lIrcNumericHelper.l253 = lStrings.ReturnReplacedString(eStringTypes.sRPL_LUSERUNKNOWN, splt2(2))
                                    If lStatus.TimerWaitForLUsersEnabled(lStatusIndex) = False Then lStatus.TimerWaitForLUsersEnabled(lStatusIndex) = True
                                End If
                                Exit Sub
                            Case 254
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    lIrcNumericHelper.l254 = lStrings.ReturnReplacedString(eStringTypes.sRPL_LUSERCHANNELS, splt2(2))
                                    If lStatus.TimerWaitForLUsersEnabled(lStatusIndex) = False Then lStatus.TimerWaitForLUsersEnabled(lStatusIndex) = True
                                End If
                                Exit Sub
                            Case 255
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lIrcNumericHelper.l255 = lStrings.ReturnReplacedString(eStringTypes.sRPL_LUSERME, splt2(2))
                                    If lStatus.TimerWaitForLUsersEnabled(lStatusIndex) = False Then lStatus.TimerWaitForLUsersEnabled(lStatusIndex) = True
                                End If
                                Exit Sub
                            Case 256
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_ADMINME, splt2(2))
                                End If
                                Exit Sub
                            Case 257
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_ADMINLOC1, splt2(2))
                                End If
                                Exit Sub
                            Case 258
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_ADMINLOC2, splt2(2))
                                End If
                                Exit Sub
                            Case 259
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_ADMINEMAIL, splt2(2))
                                End If
                                Exit Sub
                            Case 261
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_TRACELOG, Replace(splt2(2), ":", ""))
                                End If
                                Exit Sub
                            Case 262
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_TRACEEND, Replace(splt2(2), ":", ""))
                                End If
                                Exit Sub
                            Case 263
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_TRYAGAIN, splt2(3))
                                End If
                                Exit Sub
                            Case 265
                                lIrcNumericHelper.l265 = lStrings.ReturnReplacedString(eStringTypes.sRPL_LOCALUSERS, splt2(2) & ": " & splt2(3))
                                If lStatus.TimerWaitForLUsersEnabled(lStatusIndex) = False Then lStatus.TimerWaitForLUsersEnabled(lStatusIndex) = True
                                Exit Sub
                            Case 266
                                lStatus.TimerWaitForLUsersEnabled(lStatusIndex) = False
                                lIrcNumericHelper.l266 = lStrings.ReturnReplacedString(eStringTypes.sRPL_GLOBALUSERS, splt2(2) & ": " & splt2(3))
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                        lIrcNumericHelper.ProcessLUsersCommand(lStatusIndex)
                                    End If
                                End If
                                Exit Sub
                            Case 292
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_HELP, splt2(2))
                                End If
                                Exit Sub
                            Case 300
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_NONE, splt2(2))
                                End If
                                Exit Sub
                            Case 301
                                splt3 = Split(splt2(2), ":")
                                lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_AWAY, splt3(0), splt3(1))
                                Exit Sub
                            Case 302
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(Replace(splt2(2), ":", ""), " ")
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_USERHOST, splt2(2))
                                    Exit Sub
                                End If
                            Case 303
                                splt3 = Split(splt2(2), " ")
                                lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sNOTIFY_LIST_BEGIN)
                                For i = 0 To UBound(splt3)
                                    If Len(splt3(i)) <> 0 Then
                                        msg2 = splt3(i)
                                        n = lSettings.FindNotifyIndex(Trim(msg2))
                                        If Len(lSettings.lNotify.nNotify(n).nNetwork) = 0 Then
                                            lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_ISON, msg2, lSettings.lNotify.nNotify(n).nMessage)
                                            lStatus.AddToNotifyList(lStatusIndex, msg2)
                                        Else
                                            'If lSettings.lNotify.nNotify(n).nNetwork = lSettings.lNetworks.nNetwork(lStatus.NetworkIndex(lStatusIndex)).nDescription Or Len(LCase(Trim(lSettings.lNotify.nNotify(n).nNetwork))) <> 0 Then
                                            If lSettings.lNotify.nNotify(n).nNetwork = Modules.IrcSettings.IrcNetworks.GetById(lStatus.NetworkIndex(lStatusIndex)).Description Or Len(LCase(Trim(lSettings.lNotify.nNotify(n).nNetwork))) <> 0 Then
                                                lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_ISON, msg2, lSettings.lNotify.nNotify(n).nMessage)
                                                lStatus.AddToNotifyList(lStatusIndex, msg2)
                                            End If
                                        End If
                                    End If
                                Next i
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sNOTIFY_LIST_END)
                                Exit Sub
                            Case 305
                                lSettings.SetAwayStatus(False)
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_UNAWAY, Replace(splt2(2), ":", ""))
                                Exit Sub
                            Case 306
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lSettings.SetAwayStatus(True)
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_NOWAWAY, Replace(splt2(2), ":", ""))
                                    Exit Sub
                                End If
                            Case 311
                                splt3 = Split(Replace(splt2(2), "* :", ""), " ")
                                If Len(Replace(splt3(4), ":", "")) <> 0 Then
                                    lIrcNumericHelper.l311 = lStrings.ReturnReplacedString(eStringTypes.sRPL_WHOISUSER, splt3(0), Replace(splt3(1), "n=", ""), splt3(2), Replace(splt3(4), ":", ""))
                                Else
                                    lIrcNumericHelper.l311 = lStrings.ReturnReplacedString(eStringTypes.sRPL_WHOISUSER, splt3(0), Replace(splt3(1), "n=", ""), splt3(2), "unknown")
                                End If
                                lIrcNumericHelper.lWhoisUser = splt3(0)
                                If lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = False Then lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = True
                                Exit Sub
                            Case 312
                                splt3 = Split(splt2(2), ":")
                                If UBound(splt3) <> 0 Then
                                    lIrcNumericHelper.l312 = lStrings.ReturnReplacedString(eStringTypes.sRPL_WHOISSERVER, Trim(Replace(splt3(1), ":", "")))
                                    If lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = False Then lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = True
                                End If
                                Exit Sub
                            Case 313
                                splt3 = Split(splt2(2), ":")
                                lIrcNumericHelper.l313 = lStrings.ReturnReplacedString(eStringTypes.sRPL_WHOISOPERATOR, splt3(0), splt3(1))
                                If lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = False Then lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = True
                                Exit Sub
                            Case 314
                                splt3 = Split(splt2(2), " ")
                                If UBound(splt3) = 4 Then lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_WHOWASUSER, splt3(0), splt3(1), splt3(2), Trim(Replace(splt3(4), ":", "")))
                                If lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = False Then lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = True
                                Exit Sub
                            Case 315
                                splt3 = Split(splt2(2), ":")
                                lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_ENDOFWHO, splt3(0))
                                If lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = False Then lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = True
                                Exit Sub
                            Case 316
                                lIrcNumericHelper.l316 = lStrings.ReturnReplacedString(eStringTypes.sRPL_WHOISCHANOP, splt2(2))
                                If lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = False Then lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = True
                                Exit Sub
                            Case 317
                                splt3 = Split(splt2(2), " ")
                                lIrcNumericHelper.l317 = lStrings.ReturnReplacedString(eStringTypes.sRPL_WHOISIDLE, Replace(splt3(1), ":", ""))
                                If lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = False Then lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = True
                                Exit Sub
                            Case 318
                                lIrcNumericHelper.ProcessWhoisCommand(lStatusIndex)
                                lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = False
                                Exit Sub
                            Case 319
                                splt3 = Split(splt2(2), ":")
                                If UBound(splt3) <> 0 Then
                                    lIrcNumericHelper.l319 = lStrings.ReturnReplacedString(eStringTypes.sRPL_WHOISCHANNELS, splt3(1))
                                End If
                                If lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = False Then lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = True
                                Exit Sub
                            Case 321
                                lChannelLists.NewChannelList(lStatusIndex)
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_LISTSTART)
                                'lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sCHANNEL_LIST_WAIT)
                                Exit Sub
                            Case 322
                                lChannelLists.Add(lChannelLists.ReturnChannelListIndex(lStatusIndex), lData)
                                Application.DoEvents()
                                Exit Sub
                            Case 323
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_LISTEND)
                                lChannelLists.StatusDescription(lChannelLists.ReturnChannelListIndex(lStatusIndex)) = lStatus.GetObject(lStatusIndex).sDescription
                                lChannelLists.Display(lChannelLists.ReturnChannelListIndex(lStatusIndex))
                                Exit Sub
                            Case 324
                                splt3 = Split(splt2(2), " ")
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_CHANNELMODEIS, splt3(0), splt3(1), splt3(2))
                                Exit Sub
                            Case 328
                                splt3 = Split(splt2(2), " ")
                                msg2 = splt2(3) & ":" & splt2(4)
                                msg = lStrings.ReturnReplacedString(eStringTypes.sRPL_CHANNEL_URL, splt3(0), msg2)
                                i = lChannels.Find(lStatusIndex, splt3(0))
                                lChannels.URL(i) = msg2
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    If i <> 0 Then
                                        lChannels.DoChannelColor(lChannels.Find(lStatusIndex, splt3(0)), msg)
                                    Else
                                        lStatus.AddText(msg, lStatusIndex)
                                    End If
                                End If
                                'If lIRC.iSettings.sAutoNavigateChannelUrls = True And lIRC.iSettings.sShowBrowser = True Then mdiMain.BrowseURL(msg2)
                                Exit Sub
                            Case 330

                                Exit Sub
                            Case 331
                                lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_NOTOPIC, splt2(2))
                                Exit Sub
                            Case 332
                                lChannels.Topic(lStatusIndex, lData)
                                Exit Sub
                            Case 333
                                splt(3) = Trim(Replace(splt(3), ":", ""))
                                msg = lStrings.ReturnReplacedString(eStringTypes.sRPL_TOPICWHOTIME, splt(3), Trim(splt(4)), lIrcNumericHelper.ReturnTimeStamp(splt(5)))
                                i = lChannels.Find(lStatusIndex, splt(3))
                                If i <> 0 Then
                                    lChannels.DoChannelColor(lChannels.Find(lStatusIndex, splt2(2)), msg)
                                Else
                                    lStatus.AddText(msg, lStatusIndex)
                                End If
                                Exit Sub
                            Case 338
                                lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_WHOISACTUALLY, splt2(2))
                                Exit Sub
                            Case 341
                                splt3 = Split(splt2(2))
                                lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_INVITING, splt3(0), splt3(1))
                                Exit Sub
                            Case 342
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_SUMMONING, splt2(3))
                                End If
                                Exit Sub
                            Case 346
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_INVITELIST, splt2(2))
                                End If
                                Exit Sub
                            Case 347
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_ENDOFINVITELIST, splt2(2))
                                End If
                                Exit Sub
                            Case 348
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_EXCEPTLIST, splt2(2))
                                End If
                                Exit Sub
                            Case 349
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_ENDOFEXCEPTLIST, splt2(2))
                                End If
                                Exit Sub
                            Case 351
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    msg = splt2(3)
                                    splt3 = Split(splt2(2), " ")
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_VERSION, splt3(0), splt3(1), msg)
                                End If
                                Exit Sub
                            Case 352
                                splt3 = Split(splt2(2), " ")
                                splt4 = Split(splt2(3), " ")
                                lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_WHOREPLY, splt3(0), splt3(1), splt3(2), splt3(3), splt3(4), splt3(5), splt4(0), Right(splt2(3), Len(splt2(3)) - Len(splt4(0))))
                                Exit Sub
                            Case 353
                                n = lChannels.Find(lStatusIndex, Trim(splt(4)))
                                If n <> 0 Then
                                    splt = Split(splt2(3), " ")
                                    For i = 0 To UBound(splt)
                                        If splt(i).Length <> 0 Then lChannels.AddToNickListQue(n, splt(i).Trim())
                                    Next i
                                End If
                                Exit Sub
                            Case 364
                                splt3 = Split(splt2(2), " ")
                                If UBound(splt2) <> 2 Then
                                    splt4 = Split(splt2(3), " ")
                                    If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                        lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_LINKS, splt3(0), splt3(1), splt4(0), splt4(1))
                                    End If
                                    lStatus.AddToServerLinks(lStatusIndex, splt3(0), "6667")
                                End If
                                Exit Sub
                            Case 365
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_ENDOFLINKS)
                                End If
                                Exit Sub
                            Case 366
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_ENDOFNAMES, splt2(2))
                                    For ii As Integer = 1 To lChannels.Count
                                        If (lChannels.Window(ii) IsNot Nothing) Then
                                            lChannels.EnableDelayNamesTimer(ii)
                                        End If
                                    Next ii
                                End If
                                Exit Sub
                            Case 367
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_BANLIST, splt3(0), splt3(1))
                                End If
                                Exit Sub
                            Case 368
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_ENDOFBANLIST, Trim(splt2(2)))
                                End If
                                Exit Sub
                            Case 369
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_ENDOFWHOWAS, splt2(2))
                                End If
                                Exit Sub
                            Case 371
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    If Len(splt2(2)) <> 0 Then
                                        lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_INFO, splt2(2))
                                        Exit Sub
                                    End If
                                End If
                            Case 372
                                If lSettings.lIRC.iSettings.sMOTDInOwnWindow = True Then
                                    lStatus.Motd_AddText(lStatusIndex, lStrings.ReturnReplacedString(eStringTypes.sRPL_MOTD, splt2(2)))
                                Else
                                    If lSettings.lIRC.iSettings.sHideMOTD = False Then
                                        lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_MOTD, splt2(2))
                                    End If
                                End If
                                Exit Sub
                            Case 374
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_ENDOFINFO)
                                End If
                                Exit Sub
                            Case 375
                                If lSettings.lIRC.iSettings.sMOTDInOwnWindow = True Then
                                    lStatus.Motd_AddText(lStatusIndex, lStrings.ReturnReplacedString(eStringTypes.sRPL_MOTDSTART, Modules.IrcSettings.IrcNetworks.GetById(lStatus.NetworkIndex(lStatusIndex)).Description))
                                Else
                                    If lSettings.lIRC.iSettings.sHideMOTD = False Then
                                        lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_MOTDSTART, Modules.IrcSettings.IrcNetworks.GetById(lStatus.NetworkIndex(lStatusIndex)).Description)
                                    End If
                                End If
                                Exit Sub
                            Case 376
                                If lSettings.lIRC.iSettings.sMOTDInOwnWindow = True Then
                                    lStatus.Motd_AddText(lStatusIndex, lStrings.ReturnReplacedString(eStringTypes.sRPL_ENDOFMOTD))
                                    Exit Sub
                                Else
                                    If lSettings.lIRC.iSettings.sHideMOTD = False Then
                                        lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_ENDOFMOTD)
                                    End If
                                End If
                                Exit Sub
                            Case 378
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lIrcNumericHelper.l378 = lStrings.ReturnReplacedString(eStringTypes.sRPL_WHOISHOST, splt2(2))
                                End If
                                Exit Sub
                            Case 379
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lIrcNumericHelper.l379 = lStrings.ReturnReplacedString(eStringTypes.sRPL_WHOISMODES, splt2(2))
                                End If
                                Exit Sub
                            Case 381
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_YOUREOPER, Replace(splt2(2), ":", ""))
                                End If
                                Exit Sub
                            Case 382
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_REHASHING, Replace(splt2(2), ":", ""))
                                End If
                                Exit Sub
                            Case 383
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_YOURESERVICE, Replace(splt2(2), ":", ""))
                                End If
                                Exit Sub
                            Case 391
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_TIME, splt2(2))
                                End If
                                Exit Sub
                            Case 392
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_USERSSTART)
                                End If
                                Exit Sub
                            Case 393
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_USERS, splt3(0), splt3(1), splt3(2))
                                End If
                                Exit Sub
                            Case 394
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_ENDOFUSERS)
                                End If
                                Exit Sub
                            Case 395
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_NOUSERS)
                                End If
                                Exit Sub
                            Case 396
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_HOSTHIDDEN, splt2(2))
                                End If
                                Exit Sub
                            Case 400
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_UNKNOWNERROR, splt2(2))
                                End If
                                Exit Sub
                            Case 401
                                lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = False
                                lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NOSUCHNICK, splt2(2))
                                Exit Sub
                            Case 402
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NOSUCHSERVER, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 403
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NOSUCHCHANNEL, splt2(2))
                                End If
                                Exit Sub
                            Case 404
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_CANNOTSENDTOCHAN, splt2(2))
                                End If
                                Exit Sub
                            Case 405
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_TOOMANYCHANNELS, splt2(2))
                                End If
                                Exit Sub
                            Case 406
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_WASNOSUCHNICK, splt2(2))
                                End If
                                Exit Sub
                            Case 407
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_TOOMANYTARGETS, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 408
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NOSUCHSERVICE, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 409
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NOORIGIN, splt2(2))
                                End If
                                Exit Sub
                            Case 411
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NORECIPIENT, splt2(2))
                                End If
                                Exit Sub
                            Case 412
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NOTEXTTOSEND, splt2(2))
                                End If
                                Exit Sub
                            Case 413
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NOTOPLEVEL, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 414
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_WILDTOPLEVEL, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 415
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_BADMASK, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 421
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_UNKNOWNCOMMAND, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 422
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NOMOTD, splt2(2))
                                End If
                                Exit Sub
                            Case 423
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NOADMININFO, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 424
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NONICKNAMEGIVEN, splt2(2))
                                End If
                                Exit Sub
                            Case 431
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NONICKNAMEGIVEN)
                                End If
                            Case 432
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_ERRONEUSNICKNAME, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 433
                                lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NICKNAMEINUSE, lStatus.NickName(lStatusIndex))
                                If (lSettings.lIRC.iSettings.sAutoSelectAlternateNickname) Then
                                    Dim nn = New Random(DateTime.Now.Millisecond).Next(1, lSettings.lIRC.iNicks.nCount + 1)
                                    Dim newNick = lSettings.lIRC.iNicks.nNick(nn)
                                    If (lSettings.lIRC.iNicks.nCount <> 1) Then
                                        b = False
                                        If (lSettings.lIRC.iSettings.sPrompts) Then
                                            Dim msgboxResult = MessageBox.Show("Change nickname to " & newNick.nNick & "?", "Auto Select Nickname?", MessageBoxButtons.OKCancel)
                                            If (msgboxResult = DialogResult.OK) Then
                                                b = True
                                            End If
                                        Else
                                            b = True
                                        End If
                                        If (b) Then
                                            lSettings.lIRC.iNicks.nIndex = nn
                                            'lStatus.NickName(lStatusIndex, True) = lSettings.lIRC.iNicks.nNick(lSettings.lIRC.iNicks.nIndex).nNick
                                            lStatus.NickName(lStatusIndex, True) = newNick.nNick
                                        End If
                                    End If
                                Else
                                    If lSettings.lIRC.iSettings.sChangeNickNameWindow = True Then
                                        Dim f As New frmChangeNickName
                                        f = New frmChangeNickName
                                        f.ChangeNickName.lServerIndex = lStatusIndex
                                        f.Show()
                                    Else
                                        If (Modules.lSettings.lIRC.iSettings.sPrompts) Then
                                            mdiMain.ShowQueryBar("Nickname '" & Modules.lSettings.lIRC.iNicks.nNick(Modules.lSettings.lIRC.iNicks.nIndex).nNick & "' is taken, select another?", eInfoBar.iNicknameInUse)
                                        End If
                                    End If
                                End If
                                Exit Sub
                            Case 436
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NICKCOLLISION, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 437
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), "/")
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_UNAVAILRESOURCE, splt3(0), splt3(1), splt3(2), splt2(3))
                                End If
                                Exit Sub
                            Case 439
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_TARGETTOOFAST, splt2(2))
                                End If
                                Exit Sub
                            Case 441
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_USERNOTINCHANNEL, splt3(0), splt3(1), splt2(3))
                                End If
                                Exit Sub
                            Case 442
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NOTONCHANNEL, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 443
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_USERONCHANNEL, splt3(0), splt3(1), splt2(3))
                                End If
                                Exit Sub
                            Case 445
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_SUMMONDISABLED, splt2(2))
                                End If
                                Exit Sub
                            Case 446
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_USERSDISABLED, splt2(2))
                                End If
                                Exit Sub
                            Case 451
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NOTREGISTERED, splt2(2))
                                End If
                                Exit Sub
                            Case 461
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NEEDMOREPARAMS, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 462
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_ALREADYREGISTERED, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 463
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NOPERMFORHOST, splt2(2))
                                End If
                                Exit Sub
                            Case 464
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_PASSWDMISMATCH, splt2(2))
                                End If
                                Exit Sub
                            Case 465
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_YOUREBANNEDCREEP, splt2(2))
                                End If
                                Exit Sub
                            Case 467
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_KEYSET, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 468
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_INVALIDUSERNAME, lSettings.lIRC.iRealName, splt2(2))
                                End If
                            Case 470
                                lChannels.Redirect(lStatusIndex, lData)
                            Case 471
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_CHANNELISFULL, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 472
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_UNKNOWNMODE, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 473
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_INVITEONLYCHAN, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 474
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_BANNEDFROMCHAN, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 475
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_BADCHANNELKEY, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 477
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    msg = Right(lData, Len(lData) - (Len(splt2(1)) + Len(splt2(2)) + 2))
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NOCHANMODES, msg)
                                End If
                                Exit Sub
                            Case 478
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt3 = Split(splt2(2), " ")
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_BANLISTFULL, splt3(1), splt3(2), splt2(3))
                                End If
                                Exit Sub
                            Case 479
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    splt = Split(splt2(2), " ")
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_BADCHANNAME, splt2(3), splt2(4))
                                End If
                                Exit Sub
                            Case 481
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NOPRIVILEGES, splt2(2))
                                End If
                                Exit Sub
                            Case 482
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_CHANOPRIVSNEEDED, splt2(2), splt2(3))
                                End If
                                Exit Sub
                            Case 483
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_CANTKILLSERVER, splt2(2))
                                End If
                                Exit Sub
                            Case 484
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_RESTRICTED, splt2(2))
                                End If
                                Exit Sub
                            Case 485
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_UNIQOPRIVSNEEDED, splt2(2))
                                End If
                                Exit Sub
                            Case 491
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NOOPERHOST, splt2(2))
                                End If
                                Exit Sub
                            Case 501
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_UMODEUNKNOWNFLAG, splt2(2))
                                End If
                                Exit Sub
                            Case 502
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_USERSDONTMATCH, splt2(2))
                                End If
                                Exit Sub
                            Case 605
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_NOWOFF, splt2(1))
                                End If
                                Exit Sub
                            Case 606
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_WATCHLIST, splt2(2))
                                End If
                                Exit Sub
                            Case 607
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_ENDOFWATCHLIST)
                                End If
                                Exit Sub
                            Case 610
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sRPL_MAPMORE, splt2(3))
                                End If
                                Exit Sub
                            Case 615
                                lIrcNumericHelper.l615 = lStrings.ReturnReplacedString(eStringTypes.sRPL_WHOISMODES2, splt2(3))
                                If lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = False Then lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = True
                                Exit Sub
                            Case 616
                                lIrcNumericHelper.l616 = lStrings.ReturnReplacedString(eStringTypes.sRPL_WHOISHOST2, splt2(3))
                                If lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = False Then lStatus.TimerWaitForWhoisEnabled(lStatusIndex) = True
                                Exit Sub
                            Case 999
                                If lSettings.lIRC.iSettings.sNoIRCMessages = False Then
                                    lStrings.ProcessReplaceString(lStatusIndex, eStringTypes.sERR_NUMERIC_ERR)
                                End If
                        End Select
                    End If
                End If
            End If
            If (UBound(splt) > 0) Then
                If Trim(LCase(splt(1))) = "nick" Then
                    splt2 = Split(lData, " ")
                    splt2(2) = splt2(2).Replace(":", "")
                    splt2(0) = TextHelper.ParseData(splt2(0), ":", "!").Replace(":", "").Replace("!", "")
                    splt2(1) = lData
                    splt2(1) = Left(lData, Len(lData) - (Len(splt2(2)) + 7))
                    splt2(1) = Right(splt2(1), Len(splt2(1)) - (Len(splt2(0)) + 2))
                    lChannels.SomeoneChangedNickName(splt2(0), splt2(1), splt2(2), lStatusIndex)
                End If
                If Trim(LCase(splt(1))) = "quit" Then
                    Dim lQuitProc As New QuitDelegate(AddressOf lChannels.SomeoneQuit)
                    lStatus.GetObject(lStatusIndex).sWindow.Invoke(lQuitProc, lStatusIndex, lData)
                End If
                If Trim(LCase(splt(1))) = "nick" Then
                    lIrcNumericHelper.ProcessNickNameChange(lStatusIndex, lData)
                    Exit Sub
                End If
                Select Case LCase(Trim(splt(1)))
                    Case "join"
                        Dim lJoinProc As New JoinPartDelegate(AddressOf lChannels.SomeoneJoined)
                        lStatus.GetObject(lStatusIndex).sWindow.Invoke(lJoinProc, lStatusIndex, lData)
                        Exit Sub
                    Case "part"
                        Dim lPartProc As New JoinPartDelegate(AddressOf lChannels.SomeoneParted)
                        lStatus.GetObject(lStatusIndex).sWindow.Invoke(lPartProc, lStatusIndex, lData)
                        Exit Sub
                    Case "mode"
                        Dim lChannelModeProc As New StatusDataDelegate(AddressOf lChannels.Mode)
                        lStatus.GetObject(lStatusIndex).sWindow.Invoke(lChannelModeProc, lStatusIndex, lData)
                        Exit Sub
                End Select
                If InStr(UCase(Trim(splt(1))), "PRIVMSG") <> 0 Then
                    If InStr(lData, ":ACTION ") <> 0 Then
                        lIrcNumericHelper.ActionProc(lStatusIndex, lData)
                        Exit Sub
                    End If
                    If InStr(UCase(lData), "DCC SEND ") <> 0 Then
                        lIrcNumericHelper.DCCSendProc(lData)
                        Exit Sub
                    End If
                    If InStr(lData, "DCC CHAT chat") <> 0 Then
                        lIrcNumericHelper.DCCChatProc(lStatusIndex, lData)
                        Exit Sub
                    End If
                    If Left(lData, 1) = ":" Then lData = Right(lData, Len(lData) - 1)
                    msg3 = Right(lData, Len(lData) - (Len(splt(0)) + Len(splt(1)) + Len(splt(2)) + 3))
                    msg2 = TextHelper.ParseData(splt(0), ":", "!")
                    msg2 = lStrings.ReturnReplacedString(eStringTypes.sPRIVMSG, msg2, msg3)
                    i = lChannels.Find(lStatusIndex, splt(2))
                    If i <> 0 Then
                        lChannels.PrivMsg(i, msg2)
                        Exit Sub
                    Else
                        If Trim(msg3) <> "VERSION" Then
                            msg2 = TextHelper.ParseData(splt(0), ":", "!")
                            lStatus.PrivateMessage_Add(lStatusIndex, msg2, Right(splt(0), Len(splt(0)) - (Len(msg2) + 2)), msg3)
                            Exit Sub
                        Else
                            Exit Sub
                        End If
                    End If
                End If
                If InStr(UCase(Trim(splt(1))), "NOTICE") <> 0 Then
                    msg2 = Right(lData, Len(lData) - (Len(splt(0)) + Len(splt(1)) + Len(splt(2)) + 3))
                    msg2 = Replace(msg2, "***", "")
                    msg2 = Replace(msg2, ":", "")
                    msg3 = lStrings.ReturnReplacedString(eStringTypes.sNOTICE, Replace(splt(0), ":", ""), msg2)
                    'If lIRC.iSettings.sStringSettings.sServerInNotices = False Then
                    'msg3 = msg3 & "»"
                    'msg3 = ParseData(msg3, ":", "»")
                    'msg3 = Replace(msg3, ":", "")
                    'msg3 = Replace(msg3, "»", "")
                    'msg3 = Trim(msg3)
                    'End If
                    If lSettings.lIRC.iSettings.sNoticesInOwnWindow = True Then
                        lStatus.Notices_Add(lStatusIndex, msg3)
                    Else
                        lStatus.AddText(msg3, lStatusIndex)
                    End If
                    Exit Sub
                End If
            End If
            lStatus.AddToUnknowns(lStatusIndex, lData)
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Public Sub ProcessDataArrivalLine(ByVal lStatusIndex As Integer, ByVal lData As String)")
        End Try
    End Sub

    Public Sub ProcessReplaceStringHelper(ByVal lStatusIndex As Integer, ByVal lType As eStringTypes, ByVal r1 As String)
        Try
            Dim ProcessReplaceString As New ProcessReplaceStringDelegate1(AddressOf lStrings.ProcessReplaceString)
            lStatus.GetObject(lStatusIndex).sWindow.Invoke(ProcessReplaceString, lStatusIndex, lType, r1)
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Private Sub lStrings.ProcessReplaceStringHelper(ByVal lStatusIndex As Integer, ByVal lType As eStringTypes, ByVal r1 As String)")
        End Try
    End Sub
End Class