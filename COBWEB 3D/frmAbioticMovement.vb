Public Class frmAbioticMovement

    Private Sub frmAbioticMovement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i = 1 To Form1.agentTypeCount
            ComboBoxagent.Items.Add(generator.agentname(i))
        Next
        ComboBoxagent.SelectedIndex = 0
        TextBox1.Text = 1
        TextBox3.Text = 1
        TextBox5.Text = 1
        TextBox2.Text = Form1.xn
        TextBox4.Text = Form1.yn
        TextBox6.Text = Form1.zn
        TextBox7.Text = 0
        TextBox8.Text = 0
        ListView1.Columns.Add("Region")
        ListView1.Columns.Add("Agent")
        ListView1.Columns.Add("X Lower Bound")
        ListView1.Columns.Add("X Upper Bound")
        ListView1.Columns.Add("Y Lower Bound")
        ListView1.Columns.Add("Y Upper Bound")
        ListView1.Columns.Add("Z Lower Bound")
        ListView1.Columns.Add("Z Upper Bound")
        ListView1.Columns.Add("Value")
        Call creatora()

        If generator.abioticenable = True Then
            Button6.Text = "Enabled"
        ElseIf generator.abioticenable = False Then
            Button6.Text = "Disabled"
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim xupper As Integer = CInt(TextBox2.Text)
        Dim xlower As Integer = CInt(TextBox1.Text)
        Dim yupper As Integer = CInt(TextBox4.Text)
        Dim ylower As Integer = CInt(TextBox3.Text)
        Dim zupper As Integer = CInt(TextBox6.Text)
        Dim zlower As Integer = CInt(TextBox5.Text)
        Dim val As Integer = CInt(TextBox7.Text)

        For x = 1 To Form1.xn
            For y = 1 To Form1.yn
                For z = 1 To Form1.zn
                    If x >= xlower And x <= xupper And y >= ylower And y <= yupper And z >= zlower And z <= zupper Then
                        generator.abiotic(ComboBoxagent.SelectedIndex + 1, x, y, z) = val
                    End If
                Next
            Next
        Next

        Call creatora()
    End Sub

    Private RenderingEngine As RenderingEngine

    Sub creatora()
        RenderingEngine = New RenderingEngine(Form1.xn, Form1.yn, Form1.zn)
        RenderingEngine.Prespective = Prespective.XY
        RenderingEngine.GraphicsContext.Clear(Color.White)

        RenderingEngine.renderGrid(RenderingEngine.GraphicsContext, 1)

        Dim max As Integer = generator.abiotic(1, 1, 1, 1)
        For i = 1 To Form1.agentTypeCount
            For xk = 1 To Form1.xn
                For yk = 1 To Form1.yn
                    For zk = 1 To Form1.zn
                        If max < generator.abiotic(i, xk, yk, zk) Then
                            max = generator.abiotic(i, xk, yk, zk)
                        End If
                    Next
                Next
            Next
        Next
        If max <= 0 Then
            max = 1
        End If

        For z = 1 To Form1.zn
            For y = 1 To Form1.yn
                For x = 1 To Form1.xn
                    RenderingEngine.renderCube(x, y, z,
                                               Color.FromArgb(25,
                                                              255 - (generator.abiotic(ComboBoxagent.SelectedIndex + 1, x, y, z) / max * 255),
                                                              255 - (generator.abiotic(ComboBoxagent.SelectedIndex + 1, x, y, z) / max * 255),
                                                              255),
                                               RenderingEngine.GraphicsContext)

                Next
            Next
        Next
        RenderingEngine.renderGridFrontFace(RenderingEngine.GraphicsContext)
        PictureBox1.Image = RenderingEngine.RenderTarget
    End Sub

    'assigns a random value from 1-100 to each possible location in 3d space
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        For xk = 1 To Form1.xn
            For yk = 1 To Form1.yn
                For zk = 1 To Form1.zn
                    generator.abiotic(ComboBoxagent.SelectedIndex + 1, xk, yk, zk) = CInt(Math.Floor((100 - 1 + 1) * Rnd())) + 1
                Next
            Next
        Next
        Call creatora()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub ComboBoxagent_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxagent.SelectedIndexChanged
        Call creatora()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        For xk = 1 To Form1.xn
            For yk = 1 To Form1.yn
                For zk = 1 To Form1.zn
                    generator.abiotic(ComboBoxagent.SelectedIndex + 1, xk, yk, zk) = 0
                Next
            Next
        Next
        Call creatora()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If Button6.Text = "Disabled" Then
            Button6.Text = "Enabled"
            generator.abioticenable = True
        ElseIf Button6.Text = "Enabled" Then
            Button6.Text = "Disabled"
            generator.abioticenable = False
        End If
    End Sub
End Class
