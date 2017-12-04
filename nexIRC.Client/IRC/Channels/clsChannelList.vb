Option Explicit On
Option Strict On
Imports nexIRC.Modules
Imports nexIRC.Business.Helpers
Imports nexIRC.Business.Enums
Imports nexIRC.Models.ChannelList
Imports nexIRC.Models.Forms

Public Class clsChannelListUI
    Public Event SaveColumnWidths()
    Public lSortOrder As SortOrder
    Private lCurrentChannel As String
    Private lMeIndex As Integer
    Public Sub cmdAddToChannelFolder_Click(ByVal channel As String)
        Try
            Modules.IrcSettings.ChannelFolders.Add(channel, Modules.IrcSettings.IrcNetworks.GetDefault().Description)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub cmdRefresh_Click(ByVal form As Form)
        Try
            Dim n As Integer = lStatus.ActiveIndex
            lStrings.ProcessReplaceCommand(n, IrcCommandTypes.cLIST, lStatus.ServerDescription(n))
            form.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public WriteOnly Property MeIndex() As Integer
        Set(ByVal _MeIndex As Integer)
            Try
                lMeIndex = _MeIndex
                lChannelLists.SetOpen(lMeIndex)
            Catch ex As Exception
                Throw ex
            End Try
        End Set
    End Property
    Public Sub FormClosed(ByVal _ChannelsListView As ListView, ByVal _FormLeft As Integer, ByVal _FormTop As Integer, ByVal _FormWidth As Integer, ByVal _FormHeight As Integer)
        Try
            IniFileHelper.WriteINI(lSettings.lINI.iIRC, "ChannelList", "Left", _FormLeft.ToString)
            IniFileHelper.WriteINI(lSettings.lINI.iIRC, "ChannelList", "Top", _FormTop.ToString)
            IniFileHelper.WriteINI(lSettings.lINI.iIRC, "ChannelList", "Width", _FormWidth.ToString)
            IniFileHelper.WriteINI(lSettings.lINI.iIRC, "ChannelList", "Height", _FormHeight.ToString)
            lChannelLists.SetClosed(lMeIndex)
            RaiseEvent SaveColumnWidths()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub ResetList(ByVal _ListView As ListView)
        Try
            _ListView.Items.Clear()
            _ListView.View = View.Details
            _ListView.HeaderStyle = ColumnHeaderStyle.Clickable
            _ListView.Columns.Add("Channel", Convert.ToInt32(Trim(IniFileHelper.ReadINI(lSettings.lINI.iIRC, "lvwChannels_ColumnWidth", "1", "150"))), HorizontalAlignment.Left)
            _ListView.Columns.Add("Topic", Convert.ToInt32(Trim(IniFileHelper.ReadINI(lSettings.lINI.iIRC, "lvwChannels_ColumnWidth", "2", "350"))), HorizontalAlignment.Left)
            _ListView.Columns.Add("Users", Convert.ToInt32(Trim(IniFileHelper.ReadINI(lSettings.lINI.iIRC, "lvwChannels_ColumnWidth", "3", "100"))), HorizontalAlignment.Left)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Load(ByVal _Form As Form, ByVal _ListView As ListView)
        Try
            _Form.Left = Convert.ToInt32(Trim(IniFileHelper.ReadINI(lSettings.lINI.iIRC, "ChannelList", "Left", "300")))
            _Form.Top = Convert.ToInt32(Trim(IniFileHelper.ReadINI(lSettings.lINI.iIRC, "ChannelList", "Top", "300")))
            _Form.Width = Convert.ToInt32(Trim(IniFileHelper.ReadINI(lSettings.lINI.iIRC, "ChannelList", "Width", "300")))
            _Form.Height = Convert.ToInt32(Trim(IniFileHelper.ReadINI(lSettings.lINI.iIRC, "ChannelList", "Height", "300")))
            _Form.MdiParent() = mdiMain
            _Form.Icon = mdiMain.Icon
            ResetList(_ListView)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Resize(ByVal _ListView As ListView, ByVal _Form As Form, ByVal _ToolStripHeight As Integer)
        Try
            _ListView.Width = _Form.ClientSize.Width
            _ListView.Height = _Form.ClientSize.Height - _ToolStripHeight
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub DoubleClick(ByVal _ListView As ListView)
        Try
            Dim i As Integer
            For i = 0 To _ListView.SelectedItems.Count
                lChannels.Join(lChannelLists.ReturnStatusIndex(lMeIndex), lCurrentChannel)
            Next i
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub ItemSelectionChanged(ByVal _ListView As ListView, ByVal _ItemIndex As Integer)
        Try
            lCurrentChannel = _ListView.Items(_ItemIndex).Text
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
Public Class clsChannelList

    Private lChannelLists As List(Of ChannelListModel)
    Public Function ReturnChannelListIndex(ByVal _StatusIndex As Integer) As Integer
        Try
            Dim n As Integer = 0
            For i As Integer = 1 To lChannelLists.Count
                If lChannelLists(i).StatusID = _StatusIndex Then
                    n = i
                End If
            Next i
            Return n
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function
    Public Function ReturnStatusIndex(ByVal _ChannelListIndex As Integer) As Integer
        Try
            If (lChannelLists IsNot Nothing) Then
                Return lChannelLists(_ChannelListIndex).StatusID
            Else
                Return 0
            End If
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function
    Public Sub NewChannelList(ByVal _StatusIndex As Integer)
        Try
            Dim b As Boolean = False, _ChannelListIndex As Integer
            For i As Integer = 1 To lChannelLists.Count
                If _StatusIndex = lChannelLists(i).StatusID Then
                    _ChannelListIndex = i
                    b = True
                End If
            Next i
            If b = False Then
                lChannelLists.cCount = lChannelLists.cCount + 1
                ReDim lChannelLists.cChannelList(lChannelLists.cCount)
                With lChannelLists.cChannelList(lChannelLists.cCount)
                    .StatusID = _StatusIndex
                    .TreeNodeVisible = True
                    .TreeNode = lStatus.GetObject(_StatusIndex).sTreeNode.Nodes.Add("Channel List", "Channel List", 1)
                    .Window = New NexircFormModel
                End With
            Else
                With lChannelLists.cChannelList(_ChannelListIndex)
                    .StatusID = _StatusIndex
                    .Window = New NexircFormModel
                    .Items = New List(Of ChannelListItemModel)
                    .Window.MeIndex = _ChannelListIndex
                End With
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Clear(ByVal _ChannelListIndex As Integer)
        Try
            With lChannelLists.cChannelList(_ChannelListIndex)
                .Window.lvwChannels.Clear()
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Unload(ByVal _ChannelListIndex As Integer)
        Try
            If lChannelLists.cCount <> 0 Then
                With lChannelLists.cChannelList(_ChannelListIndex)
                    If .Visible = True Then .Window.Close()
                    If .TreeNodeVisible = True Then .TreeNode = Nothing
                    .TreeNodeVisible = False
                    .Visible = False
                    .Window = Nothing
                End With
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public WriteOnly Property StatusDescription(ByVal _ChannelListIndex As Integer) As String
        Set(ByVal _StatusDescription As String)
            Try
                lChannelLists.cChannelList(_ChannelListIndex).Description = _StatusDescription
            Catch ex As Exception
                Throw ex
            End Try
        End Set
    End Property
    Public Sub Display(ByVal _ChannelListIndex As Integer)
        Try
            With lChannelLists.cChannelList(_ChannelListIndex)
                '.cWindow.Text = "Channel List [" & lStatusObjects.sStatusObject(lStatusIndex).sDescription & "]"
                .Window = New NexircFormModel()
                .Window.Text = "Channel List [" & lStatus.Window(.StatusID).Text & "]"
                .Window.lvwChannels.Items.Clear()
                .Window.Show()
                SetItems(_ChannelListIndex)
                .Window.MeIndex = _ChannelListIndex
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub SetItems(ByVal _ChannelListIndex As Integer)
        Try
            Dim _Item As ListViewItem
            With lChannelLists.cChannelList(_ChannelListIndex)
                For i As Integer = 1 To .Items.Count
                    _Item = .Window.lvwChannels.Items.Add(.Items(i).Channel)
                    _Item.SubItems.Add(.Items(i).Topic)
                    _Item.SubItems.Add(.Items(i).UserCount.ToString)
                Next i
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Close(ByVal _ChannelListIndex As Integer)
        If (lChannelLists.cChannelList IsNot Nothing) Then
            With lChannelLists.cChannelList(_ChannelListIndex)
                If .Visible = True Then .Window.Close()
            End With
        End If
    End Sub
    Public Sub HideTreeNode(ByVal _ChannelListIndex As Integer)
        If (lChannelLists.cChannelList IsNot Nothing) Then
            With lChannelLists.cChannelList(_ChannelListIndex)
                If .TreeNodeVisible = True Then
                    .TreeNodeVisible = False
                    .TreeNode.Remove()
                End If
            End With
        End If
    End Sub
    Public Sub DoubleClick(ByVal _ChannelListIndex As Integer)
        Try
            With lChannelLists.cChannelList(_ChannelListIndex)
                If .Visible = False Then
                    Display(_ChannelListIndex)
                Else
                    .Window.Focus()
                    Exit Sub
                End If
            End With
            With lChannelLists.cChannelList(_ChannelListIndex)
                'With lStatusObjects.sStatusObject(n)
                If .Visible = False Then
                    'Display(_ChannelListIndex)
                    SetItems(_ChannelListIndex)
                    '.cWindow = New frmChannelList
                    '.cWindow.Show()
                    '.cVisible = True
                    '.cWindow.SetStatusIndex(n)
                    'SetChannelListItems(n, .sChannelList.cWindow.lvwChannels)
                Else
                    'mdiMain.SetWindowFocus(.sChannelList.cWindow)
                    mdiMain.SetWindowFocus(.Window)
                End If
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function DoesChannelExist(ByVal _ChannelListIndex As Integer, ByVal _Channel As String) As Boolean
        Try
            Dim _Result As Boolean = False
            With lChannelLists.cChannelList(_ChannelListIndex)
                For i As Integer = 1 To .Items.Count
                    If .Items(i).Channel.ToLower() = _Channel.ToLower() = True Then
                        _Result = True
                    End If
                Next i
            End With
            Return _Result
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function
    Public Sub Add(ByVal channelListID As Integer, ByVal data As String)
        Dim splt() As String, splt2() As String, i As Integer, msg As String
        If Left(data, 1) <> ":" Then data = ":" & data
        If Len(data) <> 0 Then
            data = Trim(data)
            splt = Split(data, ":")
            splt2 = Split(splt(1), " ")
            i = Len(splt2(0)) + Len(splt2(1)) + Len(splt2(2)) + Len(splt2(3)) + Len(splt2(4)) + 7
            msg = Right(data, Len(data) - i)
            msg = TextHelper.StripColorCodes(msg)
            If msg = Nothing Then msg = ""
            If DoesChannelExist(channelListID, splt2(3)) = False Then
                Dim item = New ChannelListItemModel
                item.Channel = splt2(3)
                item.Topic = msg
                If (IsNumeric(splt2(4))) Then
                    item.UserCount = Convert.ToInt32(splt2(4))
                End If
                lChannelLists.cChannelList(channelListID).Items.Add(item)
                If (Not lChannelLists.cChannelList(channelListID).TreeNodeVisible) Then
                    lChannelLists.cChannelList(channelListID).TreeNodeVisible = True
                End If
            End If
        End If
    End Sub
    Public Sub SetOpen(ByVal _ChannelListIndex As Integer)
        With lChannelLists.cChannelList(_ChannelListIndex)
            .Visible = True
        End With
    End Sub
    Public Sub SetClosed(ByVal channelListID As Integer)
        With lChannelLists.cChannelList(channelListID)
            .Visible = False
            .Window = Nothing
        End With
    End Sub
End Class