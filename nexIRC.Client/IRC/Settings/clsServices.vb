﻿'nexIRC 3.0.31
'Sunday, Oct 4th, 2014 - guideX
Option Explicit On
Option Strict On
'Imports nexIRC.Classes.IO
Imports nexIRC.Modules
Imports nexIRC.Settings
Imports nexIRC.Business.Helpers

Namespace nexIRC.IRC.Settings
    Public Class clsServices
        Public Structure gServiceParam
            Public sParam As String
        End Structure

        Public Structure gServiceCommand
            Public sCommand As String
            Public sLevel As Integer
            Public sServiceParam() As gServiceParam
            Public sServiceParamCount As Integer
        End Structure

        Public Structure gServiceCommands
            Public sServiceCommand() As gServiceCommand
            Public sServiceCommandCount As Integer
        End Structure

        Public Structure gService
            Public sName As String
            Public sType As eServiceType
            Public sTypeCustom As Integer
            Public sNetwork As String
            Public sServerCommands As gServiceCommands
        End Structure

        Public Structure gServices
            Public sCount As Integer
            Public sService() As gService
        End Structure

        Public Structure gX
            Public xLoginNickName As String
            Public xLoginPassword As String
            Public xEnable As Boolean
            Public xShowOnConnect As Boolean
            Public xLoginOnConnect As Boolean
            Public xCreateAnAccountURL As String
            Public xLongName As String
        End Structure

        Public Structure gNickServ
            Public nLoginNickname As String
            Public nLoginPassword As String
            Public nShowOnConnect As Boolean
            Public nLoginOnConnect As Boolean
        End Structure

        Public lServices As gServices
        Public lX As gX
        Public lNickServ As gNickServ

        Public Sub AddService(ByVal lName As String, ByVal lType As eServiceType)
            Try
                lServices.sCount = lServices.sCount + 1
                If Len(lName) <> 0 And lType <> eServiceType.sNone Then
                    With lServices.sService(lServices.sCount)
                        .sName = lName
                        .sType = lType
                    End With
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub LoadServices()
            Try
                Dim i As Integer, n As Integer, t As Integer, e As Integer
                lServices.sCount = Convert.ToInt32(IniFileHelper.ReadINI(lSettings.lINI.iServices, "Settings", "Count", "0"))
                ReDim lServices.sService(lSettings.lArraySizes.aServices)
                If lServices.sCount <> 0 Then
                    For i = 1 To lServices.sCount
                        With lServices.sService(i)
                            ReDim .sServerCommands.sServiceCommand(lSettings.lArraySizes.aServiceCommands)
                            ReDim .sServerCommands.sServiceCommand(i).sServiceParam(lSettings.lArraySizes.aServiceParams)
                            .sName = IniFileHelper.ReadINI(lSettings.lINI.iServices, Trim(Str(i)), "Name", "")
                            e = Convert.ToInt32(IniFileHelper.ReadINI(lSettings.lINI.iServices, Trim(Str(i)), "Type", "0"))
                            Select Case e
                                Case 0
                                    .sType = eServiceType.sNone
                                Case 1
                                    .sType = eServiceType.sChanServ
                                Case 2
                                    .sType = eServiceType.sNickServ
                                Case 3
                                    .sType = eServiceType.sX
                                Case Else
                                    .sTypeCustom = e
                            End Select
                            .sNetwork = IniFileHelper.ReadINI(lSettings.lINI.iServices, Trim(Str(i)), "Network", "")
                            .sServerCommands.sServiceCommandCount = Convert.ToInt32(Trim(IniFileHelper.ReadINI(lSettings.lINI.iServices, Trim(Str(i)), "CommandCount", "0")))
                            If .sServerCommands.sServiceCommandCount <> 0 Then
                                For n = 1 To .sServerCommands.sServiceCommandCount
                                    .sServerCommands.sServiceCommand(n).sCommand = IniFileHelper.ReadINI(lSettings.lINI.iServices, Trim(Convert.ToString(i)), "Command" & Trim(Convert.ToString(n)), "")
                                    .sServerCommands.sServiceCommand(n).sServiceParamCount = Convert.ToInt32(Trim(IniFileHelper.ReadINI(lSettings.lINI.iServices, Trim(Convert.ToString(i)), "Command" & Trim(Convert.ToString(n)) & "ParamCount", "0")))
                                    If .sServerCommands.sServiceCommand(n).sServiceParamCount <> 0 Then
                                        For t = 1 To .sServerCommands.sServiceCommand(n).sServiceParamCount
                                            .sServerCommands.sServiceCommand(n).sServiceParam(t).sParam = IniFileHelper.ReadINI(lSettings.lINI.iServices, Trim(Convert.ToString(i)), "Command" & Trim(Convert.ToString(n)) & "Param" & Trim(Convert.ToString(t)), "")
                                        Next t
                                    End If
                                Next n
                            End If
                        End With
                    Next i
                End If
                'With lX
                '.xLoginNickName = IniFileHelper.ReadINI(lSettings.lINI.iServices, "X", "LoginNickName", "")
                '.xLoginPassword = IniFileHelper.ReadINI(lSettings.lINI.iServices, "X", "LoginPassword", "")
                '.xCreateAnAccountURL = IniFileHelper.ReadINI(lSettings.lINI.iServices, "X", "CreateAnAccountURL", "http://cservice.undernet.org/live/newuser.php")
                '.xEnable = Convert.ToBoolean(IniFileHelper.ReadINI(lSettings.lINI.iServices, "X", "Enable", "True"))
                '.xLoginOnConnect = Convert.ToBoolean(IniFileHelper.ReadINI(lSettings.lINI.iServices, "X", "LoginOnConnect", "False"))
                '.xShowOnConnect = Convert.ToBoolean(IniFileHelper.ReadINI(lSettings.lINI.iServices, "X", "ShowOnConnect", "True"))
                '.xLongName = IniFileHelper.ReadINI(lSettings.lINI.iServices, "X", "LongName", "x@channels.undernet.org")
                'End With
                With lNickServ
                    '.nEnable = Convert.ToBoolean(IniFileHelper.ReadINI(lINI.iServices, "NickServ", "Enable", "False"))
                    .nLoginNickname = IniFileHelper.ReadINI(lSettings.lINI.iServices, "NickServ", "LoginNickname", "")
                    .nLoginPassword = IniFileHelper.ReadINI(lSettings.lINI.iServices, "NickServ", "LoginPassword", "")
                    .nLoginOnConnect = Convert.ToBoolean(IniFileHelper.ReadINI(lSettings.lINI.iServices, "NickServ", "LoginOnConnect", "False"))
                    .nShowOnConnect = Convert.ToBoolean(IniFileHelper.ReadINI(lSettings.lINI.iServices, "NickServ", "ShowOnConnect", "True"))
                End With
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub SaveServices()
            Try
                Dim i As Integer
                IniFileHelper.WriteINI(lSettings.lINI.iServices, "Settings", "Count", Trim(lServices.sCount.ToString))
                If lServices.sCount <> 0 Then
                    For i = 1 To lServices.sCount
                        With lServices.sService(i)
                            IniFileHelper.WriteINI(lSettings.lINI.iServices, Trim(Str(i)), "Name", .sName)
                            IniFileHelper.WriteINI(lSettings.lINI.iServices, Trim(Str(i)), "Type", Convert.ToString(.sType))
                        End With
                    Next i
                End If
                'IniFileHelper.WriteINI(lSettings.lINI.iServices, "X", "LoginNickName", lX.xLoginNickName)
                'IniFileHelper.WriteINI(lSettings.lINI.iServices, "X", "LoginPassword", lX.xLoginPassword)
                'IniFileHelper.WriteINI(lSettings.lINI.iServices, "X", "Enable", Convert.ToString(lX.xEnable))
                'IniFileHelper.WriteINI(lSettings.lINI.iServices, "X", "LoginOnConnect", Convert.ToString(lX.xLoginOnConnect))
                'IniFileHelper.WriteINI(lSettings.lINI.iServices, "X", "ShowOnConnect", Convert.ToString(lX.xShowOnConnect))
                'IniFileHelper.WriteINI(lSettings.lINI.iServices, "X", "LongName", lX.xLongName)
                IniFileHelper.WriteINI(lSettings.lINI.iServices, "NickServ", "LoginNickname", lNickServ.nLoginNickname)
                IniFileHelper.WriteINI(lSettings.lINI.iServices, "NickServ", "LoginPassword", lNickServ.nLoginPassword)
                IniFileHelper.WriteINI(lSettings.lINI.iServices, "NickServ", "LoginOnConnect", Convert.ToString(lNickServ.nLoginOnConnect))
                IniFileHelper.WriteINI(lSettings.lINI.iServices, "NickServ", "ShowOnConnect", Convert.ToString(lNickServ.nShowOnConnect))
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
    End Class
End Namespace