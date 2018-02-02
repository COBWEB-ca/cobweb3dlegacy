<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrameSkipForm
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtBxFrameSkip = New System.Windows.Forms.TextBox()
        Me.BtnApply = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(355, 40)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Skipping the rendering of same frames can speed up the simulation run-time."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(246, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Number of Frames to Skip Rendering:"
        '
        'txtBxFrameSkip
        '
        Me.txtBxFrameSkip.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBxFrameSkip.Location = New System.Drawing.Point(265, 49)
        Me.txtBxFrameSkip.Name = "txtBxFrameSkip"
        Me.txtBxFrameSkip.Size = New System.Drawing.Size(103, 41)
        Me.txtBxFrameSkip.TabIndex = 2
        Me.txtBxFrameSkip.Text = "0"
        '
        'BtnApply
        '
        Me.BtnApply.Location = New System.Drawing.Point(265, 92)
        Me.BtnApply.Name = "BtnApply"
        Me.BtnApply.Size = New System.Drawing.Size(102, 43)
        Me.BtnApply.TabIndex = 3
        Me.BtnApply.Text = "Apply"
        Me.BtnApply.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(15, 92)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(102, 43)
        Me.BtnCancel.TabIndex = 4
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'FrameSkipForm
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(383, 150)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnApply)
        Me.Controls.Add(Me.txtBxFrameSkip)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrameSkipForm"
        Me.Text = "Frame Skipping"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtBxFrameSkip As TextBox
    Friend WithEvents BtnApply As Button
    Friend WithEvents BtnCancel As Button
End Class
