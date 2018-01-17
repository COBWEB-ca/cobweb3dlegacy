<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TransformationOptionsForm
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
        Me.CboxAgent1 = New System.Windows.Forms.CheckBox()
        Me.CboxAgent2 = New System.Windows.Forms.CheckBox()
        Me.ComboAgent1 = New System.Windows.Forms.ComboBox()
        Me.ComboAgent2 = New System.Windows.Forms.ComboBox()
        Me.BtnApply = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'CboxAgent1
        '
        Me.CboxAgent1.AutoSize = True
        Me.CboxAgent1.Location = New System.Drawing.Point(13, 15)
        Me.CboxAgent1.Name = "CboxAgent1"
        Me.CboxAgent1.Size = New System.Drawing.Size(185, 17)
        Me.CboxAgent1.TabIndex = 20
        Me.CboxAgent1.Text = "Agent type %s transforms to type: "
        Me.CboxAgent1.UseVisualStyleBackColor = True
        '
        'CboxAgent2
        '
        Me.CboxAgent2.AutoSize = True
        Me.CboxAgent2.Location = New System.Drawing.Point(13, 42)
        Me.CboxAgent2.Name = "CboxAgent2"
        Me.CboxAgent2.Size = New System.Drawing.Size(185, 17)
        Me.CboxAgent2.TabIndex = 21
        Me.CboxAgent2.Text = "Agent type %s transforms to type: "
        Me.CboxAgent2.UseVisualStyleBackColor = True
        '
        'ComboAgent1
        '
        Me.ComboAgent1.FormattingEnabled = True
        Me.ComboAgent1.Location = New System.Drawing.Point(250, 11)
        Me.ComboAgent1.Name = "ComboAgent1"
        Me.ComboAgent1.Size = New System.Drawing.Size(167, 21)
        Me.ComboAgent1.TabIndex = 22
        '
        'ComboAgent2
        '
        Me.ComboAgent2.FormattingEnabled = True
        Me.ComboAgent2.Location = New System.Drawing.Point(250, 38)
        Me.ComboAgent2.Name = "ComboAgent2"
        Me.ComboAgent2.Size = New System.Drawing.Size(167, 21)
        Me.ComboAgent2.TabIndex = 23
        '
        'BtnApply
        '
        Me.BtnApply.Location = New System.Drawing.Point(275, 90)
        Me.BtnApply.Name = "BtnApply"
        Me.BtnApply.Size = New System.Drawing.Size(142, 37)
        Me.BtnApply.TabIndex = 24
        Me.BtnApply.Text = "Apply"
        Me.BtnApply.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(13, 90)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(142, 37)
        Me.BtnCancel.TabIndex = 25
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'TransformationOptionsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(432, 138)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnApply)
        Me.Controls.Add(Me.ComboAgent2)
        Me.Controls.Add(Me.ComboAgent1)
        Me.Controls.Add(Me.CboxAgent2)
        Me.Controls.Add(Me.CboxAgent1)
        Me.Name = "TransformationOptionsForm"
        Me.Text = "TransformationOptionsForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CboxAgent1 As CheckBox
    Friend WithEvents CboxAgent2 As CheckBox
    Friend WithEvents ComboAgent1 As ComboBox
    Friend WithEvents ComboAgent2 As ComboBox
    Friend WithEvents BtnApply As Button
    Friend WithEvents BtnCancel As Button
End Class
