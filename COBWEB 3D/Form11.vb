Public Class Form11

    Private RenderingEngine As RenderingEngine
    Sub creatora()
        RenderingEngine = New RenderingEngine(Form1.xn, Form1.yn, Form1.zn)
        RenderingEngine.Prespective = Prespective.XY
        RenderingEngine.GraphicsContext.Clear(Color.White)
        RenderingEngine.SizeRatio = 9 / 10
        RenderingEngine.renderGrid(RenderingEngine.GraphicsContext)

        Dim rr As Integer = 255
        Dim gg As Integer = 0
        Dim bb As Integer = 0

        Dim max As Integer = generator.abiotic(1, 1, 1, 1)
        For i = 1 To Form1.agent
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

        For ii = 1 To 1000
            If generator.zones(ii, 1) = 0 Or generator.zones(ii, 2) = 0 Or generator.zones(ii, 3) = 0 Or generator.zones(ii, 4) = 0 Or generator.zones(ii, 5) = 0 Or generator.zones(ii, 6) = 0 Then
                Continue For ' Exit if invalid zone field range
            End If
            RenderingEngine.renderCubeWireframe(generator.zones(ii, 1), generator.zones(ii, 3), generator.zones(ii, 5), Color.Orange, RenderingEngine.GraphicsContext,
                                                (generator.zones(ii, 2) - generator.zones(ii, 1)),
                                                (generator.zones(ii, 4) - generator.zones(ii, 3)),
                                                (generator.zones(ii, 6) - generator.zones(ii, 5)))
        Next
        PictureBox1.Image = RenderingEngine.RenderTarget
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Form11_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call creatora()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If IsNumeric(TextBox11.Text) = False Then
            MessageBox.Show("Please enter numerical values only.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim segment As Integer = CInt(TextBox11.Text)
        If segment = 0 Then
            MessageBox.Show("The size of a zone must be 1 or greater.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim i As Integer = 0

        For zi = 1 To Form1.zn Step segment
            For yi = 1 To Form1.yn Step segment
                For xi = 1 To Form1.xn Step segment
                    i += 1
                    Dim xup As Integer = xi + segment - 1
                    Dim yup As Integer = yi + segment - 1
                    Dim zup As Integer = zi + segment - 1
                    If xup > Form1.xn Then
                        xup = Form1.xn
                    End If
                    If yup > Form1.yn Then
                        yup = Form1.yn
                    End If
                    If zup > Form1.zn Then
                        zup = Form1.zn
                    End If

                    generator.zones(i, 1) = xi
                    generator.zones(i, 2) = xup
                    generator.zones(i, 3) = yi
                    generator.zones(i, 4) = yup
                    generator.zones(i, 5) = zi
                    generator.zones(i, 6) = zup
                    generator.zones(i, 7) = 0
                    generator.zones(i, 8) = 0

                Next
            Next
        Next

        For ii = i + 1 To 1000
            For o = 1 To 6
                generator.zones(ii, o) = 0
            Next
        Next

        Call creatora()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            generator.abioticenable = True
            CheckBox2.Checked = False
        Else
            generator.abioticenable = False
            CheckBox2.Checked = True
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            CheckBox1.Checked = False
        Else
            CheckBox1.Checked = True
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If IsNumeric(TextBox1.Text) Then
            TextBox1.BackColor = Color.White
            generator.agentsight = CInt(TextBox1.Text)
        Else
            TextBox1.BackColor = Color.Yellow
        End If
    End Sub
End Class