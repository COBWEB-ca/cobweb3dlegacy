<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInteractions
    Inherits System.Windows.Forms.Form

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
        Me.lstInteractions = New System.Windows.Forms.ListView()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.SuspendLayout()
        '
        'lstInteractions
        '
        Me.lstInteractions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstInteractions.Location = New System.Drawing.Point(12, 12)
        Me.lstInteractions.Name = "lstInteractions"
        Me.lstInteractions.Size = New System.Drawing.Size(1037, 493)
        Me.lstInteractions.TabIndex = 0
        Me.lstInteractions.UseCompatibleStateImageBehavior = False
        Me.lstInteractions.View = System.Windows.Forms.View.Details
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.Location = New System.Drawing.Point(860, 521)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(189, 35)
        Me.btnExit.TabIndex = 2
        Me.btnExit.Text = "Close"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnRemove
        '
        Me.btnRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRemove.Location = New System.Drawing.Point(12, 521)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(189, 35)
        Me.btnRemove.TabIndex = 3
        Me.btnRemove.Text = "Remove Interaction"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button1.Location = New System.Drawing.Point(440, 521)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(189, 35)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Export Data"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmInteractions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1061, 568)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.lstInteractions)
        Me.Name = "frmInteractions"
        Me.Text = "Interactions"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lstInteractions As ListView
    Friend WithEvents btnExit As Button
    Friend WithEvents btnRemove As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
End Class
