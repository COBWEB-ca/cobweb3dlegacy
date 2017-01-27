<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form4
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
        Me.components = New System.ComponentModel.Container()
        Me.labelagentnumber = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.labelX = New System.Windows.Forms.Label()
        Me.labelY = New System.Windows.Forms.Label()
        Me.labelZ = New System.Windows.Forms.Label()
        Me.labelAGENTTYPE = New System.Windows.Forms.Label()
        Me.labelENERGY = New System.Windows.Forms.Label()
        Me.labelAGE = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.VScrollBar1 = New System.Windows.Forms.VScrollBar()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'labelagentnumber
        '
        Me.labelagentnumber.AutoSize = True
        Me.labelagentnumber.Location = New System.Drawing.Point(5, 10)
        Me.labelagentnumber.Name = "labelagentnumber"
        Me.labelagentnumber.Size = New System.Drawing.Size(79, 13)
        Me.labelagentnumber.TabIndex = 0
        Me.labelagentnumber.Text = "Agent number: "
        '
        'Timer1
        '
        '
        'labelX
        '
        Me.labelX.AutoSize = True
        Me.labelX.Location = New System.Drawing.Point(133, 10)
        Me.labelX.Name = "labelX"
        Me.labelX.Size = New System.Drawing.Size(50, 13)
        Me.labelX.TabIndex = 6
        Me.labelX.Text = "X-Value: "
        '
        'labelY
        '
        Me.labelY.AutoSize = True
        Me.labelY.Location = New System.Drawing.Point(261, 10)
        Me.labelY.Name = "labelY"
        Me.labelY.Size = New System.Drawing.Size(50, 13)
        Me.labelY.TabIndex = 7
        Me.labelY.Text = "Y-Value: "
        '
        'labelZ
        '
        Me.labelZ.AutoSize = True
        Me.labelZ.Location = New System.Drawing.Point(392, 10)
        Me.labelZ.Name = "labelZ"
        Me.labelZ.Size = New System.Drawing.Size(50, 13)
        Me.labelZ.TabIndex = 8
        Me.labelZ.Text = "Z-Value: "
        '
        'labelAGENTTYPE
        '
        Me.labelAGENTTYPE.AutoSize = True
        Me.labelAGENTTYPE.Location = New System.Drawing.Point(520, 10)
        Me.labelAGENTTYPE.Name = "labelAGENTTYPE"
        Me.labelAGENTTYPE.Size = New System.Drawing.Size(68, 13)
        Me.labelAGENTTYPE.TabIndex = 9
        Me.labelAGENTTYPE.Text = "Agent Type: "
        '
        'labelENERGY
        '
        Me.labelENERGY.AutoSize = True
        Me.labelENERGY.Location = New System.Drawing.Point(657, 10)
        Me.labelENERGY.Name = "labelENERGY"
        Me.labelENERGY.Size = New System.Drawing.Size(77, 13)
        Me.labelENERGY.TabIndex = 10
        Me.labelENERGY.Text = "Agent Energy: "
        '
        'labelAGE
        '
        Me.labelAGE.AutoSize = True
        Me.labelAGE.Location = New System.Drawing.Point(790, 10)
        Me.labelAGE.Name = "labelAGE"
        Me.labelAGE.Size = New System.Drawing.Size(63, 13)
        Me.labelAGE.TabIndex = 11
        Me.labelAGE.Text = "Agent Age: "
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.labelAGE)
        Me.Panel1.Controls.Add(Me.labelENERGY)
        Me.Panel1.Controls.Add(Me.labelAGENTTYPE)
        Me.Panel1.Controls.Add(Me.labelZ)
        Me.Panel1.Controls.Add(Me.labelY)
        Me.Panel1.Controls.Add(Me.labelX)
        Me.Panel1.Controls.Add(Me.labelagentnumber)
        Me.Panel1.Location = New System.Drawing.Point(7, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(870, 464)
        Me.Panel1.TabIndex = 12
        '
        'VScrollBar1
        '
        Me.VScrollBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.VScrollBar1.LargeChange = 1
        Me.VScrollBar1.Location = New System.Drawing.Point(880, 12)
        Me.VScrollBar1.Maximum = 0
        Me.VScrollBar1.Name = "VScrollBar1"
        Me.VScrollBar1.Size = New System.Drawing.Size(20, 461)
        Me.VScrollBar1.TabIndex = 12
        '
        'Form4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(903, 488)
        Me.Controls.Add(Me.VScrollBar1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Form4"
        Me.Text = "Data"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents labelagentnumber As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents labelX As System.Windows.Forms.Label
    Friend WithEvents labelY As System.Windows.Forms.Label
    Friend WithEvents labelZ As System.Windows.Forms.Label
    Friend WithEvents labelAGENTTYPE As System.Windows.Forms.Label
    Friend WithEvents labelENERGY As System.Windows.Forms.Label
    Friend WithEvents labelAGE As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents VScrollBar1 As System.Windows.Forms.VScrollBar
End Class
