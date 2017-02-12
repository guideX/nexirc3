'nexIRC 3.0.31
'Sunday, Oct 4th, 2014 - guideX
Option Explicit On
Option Strict On

Public Class clsVideo
    Inherits Control
    Private Declare Function mciSendString Lib "Winmm.dll" Alias "mciSendStringA" (ByVal lpszCommand As String, ByVal lpszReturnString As String, ByVal cchReturn As Integer, ByVal hwndCallback As IntPtr) As MCIERR
    Private Declare Function mciGetErrorString Lib "Winmm.dll" Alias "mciGetErrorStringA" (ByVal fdwError As Integer, ByVal lpszErrorText As String, ByVal cchErrorText As Integer) As Integer

    Public Enum Channels
        None = 0
        Left = 1
        Right = 2
        Both = 3
    End Enum

    Private Enum MCIERR As Integer
        MCIERR_NO_ERROR = 0
        'MCIERR_INVALID_DEVICE_ID = (MCIERR_BASE + 1)
        'MCIERR_UNRECOGNIZED_KEYWORD = (MCIERR_BASE + 3)
        'MCIERR_UNRECOGNIZED_COMMAND = (MCIERR_BASE + 5)
        'MCIERR_HARDWARE = (MCIERR_BASE + 6)
        'MCIERR_INVALID_DEVICE_NAME = (MCIERR_BASE + 7)
        'MCIERR_OUT_OF_MEMORY = (MCIERR_BASE + 8)
        'MCIERR_DEVICE_OPEN = (MCIERR_BASE + 9)
        'MCIERR_CANNOT_LOAD_DRIVER = (MCIERR_BASE + 10)
        'MCIERR_MISSING_COMMAND_STRING = (MCIERR_BASE + 11)
        'MCIERR_PARAM_OVERFLOW = (MCIERR_BASE + 12)
        'MCIERR_MISSING_STRING_ARGUMENT = (MCIERR_BASE + 13)
        'MCIERR_BAD_INTEGER = (MCIERR_BASE + 14)
        'MCIERR_PARSER_INTERNAL = (MCIERR_BASE + 15)
        'MCIERR_DRIVER_INTERNAL = (MCIERR_BASE + 16)
        'MCIERR_MISSING_PARAMETER = (MCIERR_BASE + 17)
        'MCIERR_UNSUPPORTED_FUNCTION = (MCIERR_BASE + 18)
        'MCIERR_FILE_NOT_FOUND = (MCIERR_BASE + 19)
        'MCIERR_DEVICE_NOT_READY = (MCIERR_BASE + 20)
        'MCIERR_INTERNAL = (MCIERR_BASE + 21)
        'MCIERR_DRIVER = (MCIERR_BASE + 22)
        'MCIERR_CANNOT_USE_ALL = (MCIERR_BASE + 23)
        'MCIERR_MULTIPLE = (MCIERR_BASE + 24)
        'MCIERR_EXTENSION_NOT_FOUND = (MCIERR_BASE + 25)
        'MCIERR_OUTOFRANGE = (MCIERR_BASE + 26)
        'MCIERR_FLAGS_NOT_COMPATIBLE = (MCIERR_BASE + 28)
        'MCIERR_FILE_NOT_SAVED = (MCIERR_BASE + 30)
        'MCIERR_DEVICE_TYPE_REQUIRED = (MCIERR_BASE + 31)
        'MCIERR_DEVICE_LOCKED = (MCIERR_BASE + 32)
        'MCIERR_DUPLICATE_ALIAS = (MCIERR_BASE + 33)
        'MCIERR_BAD_CONSTANT = (MCIERR_BASE + 34)
        'MCIERR_MUST_USE_SHAREABLE = (MCIERR_BASE + 35)
        'MCIERR_MISSING_DEVICE_NAME = (MCIERR_BASE + 36)
        'MCIERR_BAD_TIME_FORMAT = (MCIERR_BASE + 37)
        'MCIERR_NO_CLOSING_QUOTE = (MCIERR_BASE + 38)
        'MCIERR_DUPLICATE_FLAGS = (MCIERR_BASE + 39)
        'MCIERR_INVALID_FILE = (MCIERR_BASE + 40)
        'MCIERR_NULL_PARAMETER_BLOCK = (MCIERR_BASE + 41)
        'MCIERR_UNNAMED_RESOURCE = (MCIERR_BASE + 42)
        'MCIERR_NEW_REQUIRES_ALIAS = (MCIERR_BASE + 43)
        'MCIERR_NOTIFY_ON_AUTO_OPEN = (MCIERR_BASE + 44)
        'MCIERR_NO_ELEMENT_ALLOWED = (MCIERR_BASE + 45)
        'MCIERR_NONAPPLICABLE_FUNCTION = (MCIERR_BASE + 46)
        'MCIERR_ILLEGAL_FOR_AUTO_OPEN = (MCIERR_BASE + 47)
        'MCIERR_FILENAME_REQUIRED = (MCIERR_BASE + 48)
        'MCIERR_EXTRA_CHARACTERS = (MCIERR_BASE + 49)
        'MCIERR_DEVICE_NOT_INSTALLED = (MCIERR_BASE + 50)
        'MCIERR_GET_CD = (MCIERR_BASE + 51)
        'MCIERR_SET_CD = (MCIERR_BASE + 52)
        'MCIERR_SET_DRIVE = (MCIERR_BASE + 53)
        'MCIERR_DEVICE_LENGTH = (MCIERR_BASE + 54)
        'MCIERR_DEVICE_ORD_LENGTH = (MCIERR_BASE + 55)
        'MCIERR_NO_INTEGER = (MCIERR_BASE + 56)
        'MCIERR_WAVE_OUTPUTSINUSE = (MCIERR_BASE + 64)
        'MCIERR_WAVE_SETOUTPUTINUSE = (MCIERR_BASE + 65)
        'MCIERR_WAVE_INPUTSINUSE = (MCIERR_BASE + 66)
        'MCIERR_WAVE_SETINPUTINUSE = (MCIERR_BASE + 67)
        'MCIERR_WAVE_OUTPUTUNSPECIFIED = (MCIERR_BASE + 68)
        'MCIERR_WAVE_INPUTUNSPECIFIED = (MCIERR_BASE + 69)
        'MCIERR_WAVE_OUTPUTSUNSUITABLE = (MCIERR_BASE + 70)
        'MCIERR_WAVE_SETOUTPUTUNSUITABLE = (MCIERR_BASE + 71)
        'MCIERR_WAVE_INPUTSUNSUITABLE = (MCIERR_BASE + 72)
        'MCIERR_WAVE_SETINPUTUNSUITABLE = (MCIERR_BASE + 73)
        'MCIERR_SEQ_DIV_INCOMPATIBLE = (MCIERR_BASE + 80)
        'MCIERR_SEQ_PORT_INUSE = (MCIERR_BASE + 81)
        'MCIERR_SEQ_PORT_NONEXISTENT = (MCIERR_BASE + 82)
        'MCIERR_SEQ_PORT_MAPNODEVICE = (MCIERR_BASE + 83)
        'MCIERR_SEQ_PORT_MISCERROR = (MCIERR_BASE + 84)
        'MCIERR_SEQ_TIMER = (MCIERR_BASE + 85)
        'MCIERR_SEQ_PORTUNSPECIFIED = (MCIERR_BASE + 86)
        'MCIERR_SEQ_NOMIDIPRESENT = (MCIERR_BASE + 87)
        'MCIERR_NO_WINDOW = (MCIERR_BASE + 90)
        'MCIERR_CREATEWINDOW = (MCIERR_BASE + 91)
        'MCIERR_FILE_READ = (MCIERR_BASE + 92)
        'MCIERR_FILE_WRITE = (MCIERR_BASE + 93)
        'MCIERR_NO_IDENTITY = (MCIERR_BASE + 94)
        'MCIERR_CUSTOM_DRIVER_BASE = (MCIERR_BASE + 256)
    End Enum

    Public Event OnEnd(ByVal sender As Object, ByVal e As System.EventArgs)
    Private Const MCI_NOTIFY_SUCCESSFUL As Integer = &H1
    Private Const MM_MCINOTIFY As Integer = &H3B9
    Private Const MCIERR_BASE As Integer = 256
    Private pFileName As String
    Private pAlias As String
    Private pLastError As MCIERR
    Private pOpenSuccess As Boolean
    Private pSpeed As Integer
    Private pMute As Channels
    Private pBalance As Integer
    Private pVolume As Integer
    Private pRepeat As Boolean
    Private pTotalTime As Long
    Private pTotalFrames As Long
    Private pClipStart As Long
    Private pClipEnd As Long
    Private pClipFormat As String
    Private pPlaying As Boolean
    Private pPaused As Boolean

    Public ReadOnly Property [FileName]() As String
        Get
            Return pFileName
        End Get
    End Property

    Public Function [Open](ByVal File As String) As Boolean
        Try
            If pOpenSuccess = True Then
                Me.Close()
            End If
            Dim Device_Type As String = "MPEGVideo"
            Dim MciExtension As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows NT\CurrentVersion\MCI Extensions", False)
            If (Not MciExtension Is Nothing) Then
                Device_Type = Convert.ToString(MciExtension.GetValue(Replace(System.IO.Path.GetExtension(File), ".", ""), "MPEGVideo"))
            End If
            pLastError = mciSendString("open """ & File & """ type " & Device_Type & " alias " & pAlias & "  parent " & Me.Handle.ToString & " style child", vbNullString, 0, IntPtr.Zero)
            If (pLastError = MCIERR.MCIERR_NO_ERROR) Then
                pOpenSuccess = True
                pPlaying = False
                pPaused = False
                pFileName = File
                SizeMediaWindow()
                DoSpeed()
                DoMute()
                DoBalance()
                DoVolume()
                pTotalTime = GetTotalTime()
                pTotalFrames = GetTotalFrames()
                Return True
            End If
            Return False
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Function [Close]() As Boolean
        Try
            If pOpenSuccess = True Then
                pLastError = mciSendString("close " & pAlias, vbNullString, 0, IntPtr.Zero)
                If pLastError = MCIERR.MCIERR_NO_ERROR Then
                    pOpenSuccess = False
                    pPlaying = False
                    pPaused = False
                    pFileName = ""
                    pTotalTime = -1
                    pTotalFrames = -1
                    Return True
                End If
            End If
            Return False
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Function [Play]() As Boolean
        Try
            Return Me.Play(True, True, False)
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Private Function [Play](ByVal WithClipStart As Boolean, ByVal WithClipEnd As Boolean, ByVal WithPauseState As Boolean) As Boolean
        Try
            If pOpenSuccess = True Then
                If pClipFormat.Length > 0 Then
                    pLastError = mciSendString("set " & pAlias & " time format " & pClipFormat, vbNullString, 0, IntPtr.Zero)
                End If
                pLastError = mciSendString("play " & pAlias & Convert.ToString(IIf((pClipStart <> -1) And WithClipStart = True, " from " & Convert.ToString(pClipStart), "")) & Convert.ToString(IIf((pClipEnd <> -1) And WithClipEnd = True, " to " & Convert.ToString(pClipEnd), "")) & " notify", vbNullString, 0, Me.Handle)
                If pLastError = MCIERR.MCIERR_NO_ERROR Then
                    pPlaying = True
                    If WithPauseState = True And pPaused = True Then
                        Me.Pause()
                    Else
                        pPaused = False
                    End If
                End If
                Return (pLastError = MCIERR.MCIERR_NO_ERROR)
            End If
            Return False
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Function [Stop]() As Boolean
        Try
            If pOpenSuccess = True Then
                pLastError = mciSendString("stop " & pAlias, vbNullString, 0, IntPtr.Zero)
                If pLastError = MCIERR.MCIERR_NO_ERROR Then
                    pLastError = mciSendString("seek " & pAlias & " to start", vbNullString, 0, IntPtr.Zero)
                End If
                pPlaying = False
                pPaused = False
                Return (pLastError = MCIERR.MCIERR_NO_ERROR)
            End If
            Return False
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Function [Pause]() As Boolean
        Try
            If pOpenSuccess = True Then
                pLastError = mciSendString("pause " & pAlias, vbNullString, 0, IntPtr.Zero)
                pPaused = (pLastError = MCIERR.MCIERR_NO_ERROR)
                Return pPaused
            End If
            Return False
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Function [Resume]() As Boolean
        Try
            If pOpenSuccess = True And pPaused = True Then
                pLastError = mciSendString("resume " & pAlias, vbNullString, 0, IntPtr.Zero)
                pPaused = Not (pLastError = MCIERR.MCIERR_NO_ERROR)
                Return (pLastError = MCIERR.MCIERR_NO_ERROR)
            End If
            Return False
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Property Repeat() As Boolean
        Get
            Try
                Return pRepeat
            Catch ex As Exception
                Throw ex
                Return Nothing
            End Try
        End Get
        Set(ByVal Value As Boolean)
            Try
                If pRepeat <> Value Then
                    pRepeat = Value
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Set
    End Property

    Public ReadOnly Property OriginalSize() As Size
        Get
            If pOpenSuccess = True Then
                Dim SizeStr As String = Space(128)
                pLastError = mciSendString("where " & pAlias & " source", SizeStr, Len(SizeStr), IntPtr.Zero)
                If pLastError = MCIERR.MCIERR_NO_ERROR Then
                    Dim Items() As String = Split(SizeStr.Trim(), " ")
                    Return New Size(Convert.ToInt32(Items(2)), Convert.ToInt32(Items(3)))
                End If
            End If
            Return New Size
        End Get
    End Property

    Public ReadOnly Property TotalFrames() As Long
        Get
            Return pTotalFrames
        End Get
    End Property

    Public ReadOnly Property TotalTime() As Long
        Get
            Return pTotalTime
        End Get
    End Property

    Public ReadOnly Property CurrentFrame() As Long
        Get
            If pOpenSuccess = True Then
                pLastError = mciSendString("set " & pAlias & " time format frames", vbNullString, 0, IntPtr.Zero)
                If pLastError = MCIERR.MCIERR_NO_ERROR Then
                    Dim PosStr As String = Space(128)
                    pLastError = mciSendString("status " & pAlias & " position", PosStr, Len(PosStr), IntPtr.Zero)
                    Return Convert.ToInt64(PosStr.Trim())
                End If
            End If
            Return -1
        End Get
    End Property

    Public ReadOnly Property CurrentTime() As Long
        Get
            If pOpenSuccess = True Then
                pLastError = mciSendString("set " & pAlias & " time format milliseconds", vbNullString, 0, IntPtr.Zero)
                If pLastError = MCIERR.MCIERR_NO_ERROR Then
                    Dim PosStr As String = Space(128)
                    pLastError = mciSendString("status " & pAlias & " position", PosStr, Len(PosStr), IntPtr.Zero)
                    Return Convert.ToInt64(PosStr.Trim())
                End If
            End If
            Return -1
        End Get
    End Property

    Public Property Speed() As Integer
        Get
            Return pSpeed
        End Get
        Set(ByVal Value As Integer)
            If Value >= 0 And Value <= 2000 And Value <> pSpeed Then
                pSpeed = Value
                DoSpeed()
            End If
        End Set
    End Property

    Public Property Mute() As Channels
        Get
            Return pMute
        End Get
        Set(ByVal Value As Channels)
            If Value >= Channels.None And Value <= Channels.Both And Value <> pMute Then
                pMute = Value
                DoMute()
            End If
        End Set
    End Property

    Public Property Balance() As Integer
        Get
            Return pBalance
        End Get
        Set(ByVal Value As Integer)
            If Value >= 0 And Value <= 1000 And Value <> pBalance Then
                pBalance = Value
                DoBalance()
            End If
        End Set
    End Property

    Public Property Volume() As Integer
        Get
            Return pVolume
        End Get
        Set(ByVal Value As Integer)
            If Value >= 0 And Value <= 1000 And Value <> pVolume Then
                pVolume = Value
                DoVolume()
            End If
        End Set
    End Property

    Public Function MoveToStart() As Boolean
        Try
            If pOpenSuccess = True Then
                pLastError = mciSendString("seek " & pAlias & " to start", vbNullString, 0, IntPtr.Zero)
                pPlaying = False
                pPaused = False
                Return (pLastError = MCIERR.MCIERR_NO_ERROR)
            End If
            Return False
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Function MoveToEnd() As Boolean
        Try
            If pOpenSuccess = True Then
                pLastError = mciSendString("seek " & pAlias & " to end", vbNullString, 0, IntPtr.Zero)
                pPlaying = False
                pPaused = False
                Return (pLastError = MCIERR.MCIERR_NO_ERROR)
            End If
            Return False
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Function MoveToFrame(ByVal Frame As Long) As Boolean
        Try
            Return MoveToPosition(Frame, "frames")
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Function MoveToTime(ByVal Milliseconds As Long) As Boolean
        Try
            Return MoveToPosition(Milliseconds, "milliseconds")
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Private Function MoveToPosition(ByVal Index As Long, ByVal TimeFormat As String) As Boolean
        Try
            If pOpenSuccess = True Then
                pLastError = mciSendString("set " & pAlias & " time format " & TimeFormat, vbNullString, 0, IntPtr.Zero)
                If pLastError = MCIERR.MCIERR_NO_ERROR Then
                    pLastError = mciSendString("seek " & pAlias & " to " & Convert.ToString(Index), vbNullString, 0, IntPtr.Zero)
                    If pLastError = MCIERR.MCIERR_NO_ERROR Then
                        If pPlaying = True Then
                            Me.Play(False, True, True)
                        End If
                    End If
                    Return (pLastError = MCIERR.MCIERR_NO_ERROR)
                End If
            End If
            Return False
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Function ClipFrame(ByVal [Start] As Long, ByVal [End] As Long) As Boolean
        Try
            Return Clip([Start], [End], Me.CurrentFrame, "frames")
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Function ClipTime(ByVal [Start] As Long, ByVal [End] As Long) As Boolean
        Try
            Return Clip([Start], [End], Me.CurrentTime, "milliseconds")
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Private Function Clip(ByVal [Start] As Long, ByVal [End] As Long, ByVal Current As Long, ByVal TimeFormat As String) As Boolean
        Try
            If pOpenSuccess = True Then
                If [Start] <> pClipStart Or [End] <> pClipEnd Or TimeFormat <> pClipFormat Then
                    pClipStart = [Start]
                    pClipEnd = [End]
                    If pClipStart = -1 And pClipEnd = -1 Then
                        pClipFormat = ""
                    Else
                        pClipFormat = TimeFormat
                    End If
                    If pPlaying = True Then
                        Me.Play(([Start] > Current And [Start] <> -1), True, True)
                    End If
                    Return True
                End If
            End If
            Return False
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Private Function SizeMediaWindow() As Boolean
        Try
            If pOpenSuccess = True Then
                Dim OptimalSize As Size = Me.OriginalSize
                If OptimalSize.IsEmpty = False Then
                    Dim wRatio As Double = (100 / OptimalSize.Width * Me.Width) / 100
                    If OptimalSize.Height * wRatio > Me.Height Then
                        wRatio = (100 / OptimalSize.Height * Me.Height) / 100
                    End If
                    Dim wWidth As Integer = Convert.ToInt32(OptimalSize.Width * wRatio)
                    Dim wHeight As Integer = Convert.ToInt32(OptimalSize.Height * wRatio)
                    Dim wLeft As Integer = Convert.ToInt32((Me.Width - wWidth) / 2)
                    Dim wTop As Integer = Convert.ToInt32((Me.Height - wHeight) / 2)
                    pLastError = mciSendString("put " & pAlias & " window at " & Convert.ToString(wLeft) & " " & Convert.ToString(wTop) & " " & Convert.ToString(wWidth) & " " & Convert.ToString(wHeight), vbNullString, 0, IntPtr.Zero)
                    Return (pLastError = MCIERR.MCIERR_NO_ERROR)
                End If
            End If
            Return False
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Private Function DoSpeed() As Boolean
        Try
            If pOpenSuccess = True Then
                pLastError = mciSendString("set " & pAlias & " speed " & Convert.ToString(pSpeed), vbNullString, 0, IntPtr.Zero)
                Return (pLastError = MCIERR.MCIERR_NO_ERROR)
            End If
            Return False
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Private Function DoMute() As Boolean
        Try
            If pOpenSuccess = True Then
                Select Case pMute
                    Case Channels.None
                        pLastError = mciSendString("set " & pAlias & " audio all on", vbNullString, 0, IntPtr.Zero)
                    Case Channels.Both
                        pLastError = mciSendString("set " & pAlias & " audio all off", vbNullString, 0, IntPtr.Zero)
                    Case Channels.Left
                        pLastError = mciSendString("set " & pAlias & " audio left off", vbNullString, 0, IntPtr.Zero)
                        pLastError = mciSendString("set " & pAlias & " audio right on", vbNullString, 0, IntPtr.Zero)
                    Case Channels.Right
                        pLastError = mciSendString("set " & pAlias & " audio left on", vbNullString, 0, IntPtr.Zero)
                        pLastError = mciSendString("set " & pAlias & " audio right off", vbNullString, 0, IntPtr.Zero)
                End Select
                Return (pLastError = MCIERR.MCIERR_NO_ERROR)
            End If
            Return False
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Private Function DoBalance() As Boolean
        Try
            If pOpenSuccess = True Then
                pLastError = mciSendString("setaudio " & pAlias & " left volume to " & Convert.ToString(1000 - pBalance), vbNullString, 0, IntPtr.Zero)
                pLastError = mciSendString("setaudio " & pAlias & " right volume to " & Convert.ToString(pBalance), vbNullString, 0, IntPtr.Zero)
                Return (pLastError = MCIERR.MCIERR_NO_ERROR)
            End If
            Return False
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Private Function DoVolume() As Boolean
        Try
            If pOpenSuccess = True Then
                pLastError = mciSendString("setaudio " & pAlias & " volume to " & Convert.ToString(pVolume), vbNullString, 0, IntPtr.Zero)
                Return (pLastError = MCIERR.MCIERR_NO_ERROR)
            End If
            Return False
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Private Function GetTotalFrames() As Long
        Try
            If pOpenSuccess = True Then
                pLastError = mciSendString("set " & pAlias & " time format frames", vbNullString, 0, IntPtr.Zero)
                If pLastError = MCIERR.MCIERR_NO_ERROR Then
                    Dim FrameStr As String = Space(128)
                    pLastError = mciSendString("status " & pAlias & " length", FrameStr, Len(FrameStr), IntPtr.Zero)
                    If pLastError = MCIERR.MCIERR_NO_ERROR Then
                        Return Convert.ToInt64(FrameStr.Trim())
                    End If
                End If
            End If
            Return -1
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Private Function GetTotalTime() As Long
        Try
            If pOpenSuccess = True Then
                pLastError = mciSendString("set " & pAlias & " time format milliseconds", vbNullString, 0, IntPtr.Zero)
                If pLastError = MCIERR.MCIERR_NO_ERROR Then
                    Dim TimeStr As String = Space(128)
                    pLastError = mciSendString("status " & pAlias & " length", TimeStr, Len(TimeStr), IntPtr.Zero)
                    If pLastError = MCIERR.MCIERR_NO_ERROR Then
                        Return Convert.ToInt64(TimeStr.Trim())
                    End If
                End If
            End If
            Return -1
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Function GetLastError() As Integer
        Try
            Return pLastError
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Function GetErrorString() As String
        Try
            If pLastError <> MCIERR.MCIERR_NO_ERROR Then
                Dim ErrorText As String = Space(128)
                If mciGetErrorString(pLastError, ErrorText, ErrorText.Length) <> 0 Then
                    Return ErrorText.Trim()
                Else
                    Return ""
                End If
            Else
                Return ""
            End If
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Sub New()
        Try
            pFileName = ""
            pAlias = "ALIAS" & Me.Handle.ToString
            pLastError = MCIERR.MCIERR_NO_ERROR
            pOpenSuccess = False
            pSpeed = 1000
            pMute = Channels.None
            pBalance = 500
            pVolume = 500
            pRepeat = False
            pTotalTime = -1
            pTotalFrames = -1
            pClipStart = -1
            pClipEnd = -1
            pClipFormat = ""
            pPaused = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
        Try
            SizeMediaWindow()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            Me.Close()
            MyBase.Dispose(disposing)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        Try
            Select Case m.Msg
                Case MM_MCINOTIFY
                    If m.WParam.ToInt32 = MCI_NOTIFY_SUCCESSFUL Then
                        If pRepeat = True Then
                            Me.Stop()
                            Me.Play()
                        Else
                            Me.Stop()
                            Dim e As New System.EventArgs
                            RaiseEvent OnEnd(Me, e)
                            e = Nothing
                        End If
                    End If
            End Select
            MyBase.WndProc(m)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class