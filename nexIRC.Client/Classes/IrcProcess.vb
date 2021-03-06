﻿Option Explicit On
Option Strict On
'nexIRC 3.0.31
'Sunday, Oct 4th, 2014 - guideX
Imports nexIRC.Models.Process
Imports nexIRC.Modules
Public Class IrcProcess
    Private Delegate Sub ProcessInDataDelegate(ByVal statusIndex As Integer, ByVal data As String)
    Private _busy As Boolean = False
    Private _processes As New List(Of ProcessModel)
    Private WithEvents processTimer As Timer

    Private Sub processTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles processTimer.Tick
        Try
            Dim n As Integer, i As Integer, processes As List(Of ProcessModel) = _processes
            processes = New List(Of ProcessModel)
            If _busy = True Then Exit Sub
            If (processes.Count <> 0) Then
                For i = 0 To processes.Count - 1
                    If (Not String.IsNullOrEmpty(processes(i).Param)) Then
                        n = n + 1
                        _busy = True
                        lProcessNumeric.ProcessDataArrivalLine(processes(i).StatusID, processes(i).Param)
                        _busy = False
                        Initialize()
                        'Dim lProcessDataArrivalLine As New ProcessInDataDelegate(AddressOf lProcessNumeric.ProcessDataArrivalLine)
                        'Try
                        '_busy = True
                        'lStatus.GetObject(processes(i).StatusID).sWindow.Invoke(lProcessDataArrivalLine, processes(i).StatusID, processes(i).Param)
                        '_busy = False
                        'Catch ex As Exception
                        '_busy = False
                        'Initialize()
                        'End Try
                        'Exit Sub
                    End If
                Next i
                processTimer.Enabled = False
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Property Busy() As Boolean
        Get
            Try
                Return _busy
            Catch ex As Exception
                Throw ex
                Return Nothing
            End Try
        End Get
        Set(value As Boolean)
            Try
                _busy = value
            Catch ex As Exception
                Throw ex
            End Try
        End Set
    End Property

    Public Sub Add(statusId As Integer, data As String)
        Try
            Dim process As New ProcessModel
            process.Param = data
            process.StatusID = statusId
            _processes.Add(process)
            If processTimer.Enabled = False Then processTimer.Enabled = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Initialize()
        Try
            processTimer = New Timer
            _processes = New List(Of ProcessModel)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class