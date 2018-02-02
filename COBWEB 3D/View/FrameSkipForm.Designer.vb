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
        Me.btnApply = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.nudFrameSkip = New System.Windows.Forms.NumericUpDown()
        Me.lblResetDefault = New System.Windows.Forms.LinkLabel()
        CType(Me.nudFrameSkip, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(330, 40)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Skipping the rendering of same frames can speed up the simulation run-time."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(184, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Number of Frames to Skip Rendering:"
        '
        'btnApply
        '
        Me.btnApply.Location = New System.Drawing.Point(240, 101)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(102, 38)
        Me.btnApply.TabIndex = 3
        Me.btnApply.Text = "Apply"
        Me.btnApply.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(12, 101)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(102, 38)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'nudFrameSkip
        '
        Me.nudFrameSkip.Location = New System.Drawing.Point(222, 47)
        Me.nudFrameSkip.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.nudFrameSkip.Name = "nudFrameSkip"
        Me.nudFrameSkip.Size = New System.Drawing.Size(120, 20)
        Me.nudFrameSkip.TabIndex = 5
        '
        'lblResetDefault
        '
        Me.lblResetDefault.AutoSize = True
        Me.lblResetDefault.Location = New System.Drawing.Point(270, 70)
        Me.lblResetDefault.Name = "lblResetDefault"
        Me.lblResetDefault.Size = New System.Drawing.Size(72, 13)
        Me.lblResetDefault.TabIndex = 6
        Me.lblResetDefault.TabStop = True
        Me.lblResetDefault.Text = "Reset Default"
        Me.lblResetDefault.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'FrameSkipForm
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(354, 151)
        Me.Controls.Add(Me.lblResetDefault)
        Me.Controls.Add(Me.nudFrameSkip)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrameSkipForm"
        Me.Text = "Frame Skipping"
        CType(Me.nudFrameSkip, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnApply As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents nudFrameSkip As NumericUpDown
    Friend WithEvents lblResetDefault As LinkLabel
End Class
