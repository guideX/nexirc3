<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNoticeWindow
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtIncoming = New Telerik.WinControls.RichTextBox.RadRichTextBox()
        Me.txtOutgoing = New Telerik.WinControls.UI.RadTextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.txtIncoming, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.txtIncoming.SuspendLayout()
        CType(Me.txtOutgoing, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtIncoming
        '
        Me.txtIncoming.Controls.Add(Me.Button1)
        Me.txtIncoming.Location = New System.Drawing.Point(0, 0)
        Me.txtIncoming.Name = "txtIncoming"
        Me.txtIncoming.Size = New System.Drawing.Size(429, 103)
        Me.txtIncoming.TabIndex = 15
        Me.txtIncoming.Text = "RadRichTextBox1"
        '
        'txtOutgoing
        '
        Me.txtOutgoing.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOutgoing.Location = New System.Drawing.Point(0, 109)
        Me.txtOutgoing.Name = "txtOutgoing"
        Me.txtOutgoing.Size = New System.Drawing.Size(429, 24)
        Me.txtOutgoing.TabIndex = 18
        Me.txtOutgoing.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(286, 40)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmNoticeWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(434, 136)
        Me.Controls.Add(Me.txtOutgoing)
        Me.Controls.Add(Me.txtIncoming)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmNoticeWindow"
        Me.Text = "Notice Window"
        CType(Me.txtIncoming, System.ComponentModel.ISupportInitialize).EndInit()
        Me.txtIncoming.ResumeLayout(False)
        CType(Me.txtOutgoing, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtIncoming As Telerik.WinControls.RichTextBox.RadRichTextBox
    Friend WithEvents txtOutgoing As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
