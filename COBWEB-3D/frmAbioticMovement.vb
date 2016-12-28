Public Class frmAbioticMovement

    Public picabiotic As New Bitmap(Form1.sizexyx, Form1.sizexyy)
    Public gfabiotic As Graphics = System.Drawing.Graphics.FromImage(picabiotic)

    Private Sub frmAbioticMovement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i = 1 To Form1.agent
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

    Sub creatora()
        Dim sizexyx As Integer
        Dim sizexyy As Integer
        Dim sizexzx As Integer
        Dim sizexzz As Integer
        Dim sizezyz As Integer
        Dim sizezyy As Integer
        Dim res As Integer = 2073600
        Dim ratio1 As Single = Form1.yn / Form1.xn
        Dim ratio2 As Single = Form1.zn / Form1.xn
        Dim ratio3 As Single = Form1.yn / Form1.zn
        Dim cellxyx As Integer
        Dim cellxyy As Integer
        Dim cellxzx As Integer
        Dim cellxzz As Integer
        Dim cellzyz As Integer
        Dim cellzyy As Integer
        Dim sizeratio = 9 / 10

        sizexyx = (res / ratio1) ^ 0.5
        sizexyy = ratio1 * sizexyx

        sizexzx = (res / ratio2) ^ 0.5
        sizexzz = ratio2 * sizexzx

        sizezyz = (res / ratio3) ^ 0.5
        sizezyy = ratio3 * sizezyz

        cellxyx = sizexyx / Form1.xn
        cellxyy = sizexyy / Form1.yn

        cellxzx = sizexzx / Form1.xn
        cellxzz = sizexzz / Form1.zn

        cellzyz = sizezyz / Form1.zn
        cellzyy = sizezyy / Form1.yn

        gfabiotic.Clear(Color.White)
        Call grid()

        Dim rr As Integer = 0
        Dim gg As Integer = 0
        Dim bb As Integer = 255

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

        For z = 1 To Form1.zn
            For y = 1 To Form1.yn
                For x = 1 To Form1.xn

                    rr = 255 - (generator.abiotic(ComboBoxagent.SelectedIndex + 1, x, y, z) / max * 255)
                    gg = 255 - (generator.abiotic(ComboBoxagent.SelectedIndex + 1, x, y, z) / max * 255)

                    Dim diag As Single = 0
                    Dim jump As Double = cellxyx

                    For i = 1 To z - 1
                        jump = jump * (sizeratio)
                        diag = diag + jump
                    Next
                    'MessageBox.Show(diag)
                    Dim angle As Single = Math.Atan(Form1.xn / Form1.yn)
                    Dim a As Integer = Math.Sin(angle) * diag
                    Dim b As Integer = Math.Cos(angle) * diag
                    'MessageBox.Show(a & " " & b)
                    Dim topfrontrightx As Integer = a + (x * ((sizexyx - (2 * a)) / Form1.xn))
                    Dim topfrontrighty As Integer = b + ((y - 1) * ((sizexyy - (2 * b)) / Form1.yn))
                    Dim topfrontleftx As Integer = a + ((x - 1) * ((sizexyx - (2 * a)) / Form1.xn))
                    Dim topfrontlefty As Integer = b + ((y - 1) * ((sizexyy - (2 * b)) / Form1.yn))

                    Dim bottomfrontrightx As Integer = a + (x * ((sizexyx - (2 * a)) / Form1.xn))
                    Dim bottomfrontrighty As Integer = b + (y * ((sizexyy - (2 * b)) / Form1.yn))
                    Dim bottomfrontleftx As Integer = a + ((x - 1) * ((sizexyx - (2 * a)) / Form1.xn))
                    Dim bottomfrontlefty As Integer = b + (y * ((sizexyy - (2 * b)) / Form1.yn))

                    jump = jump * (sizeratio)
                    diag = diag + jump

                    angle = Math.Atan(Form1.xn / Form1.yn)
                    a = Math.Sin(angle) * diag
                    b = Math.Cos(angle) * diag

                    Dim topbackrightx As Integer = a + (x * ((sizexyx - (2 * a)) / Form1.xn))
                    Dim topbackrighty As Integer = b + ((y - 1) * ((sizexyy - (2 * b)) / Form1.yn))
                    Dim topbackleftx As Integer = a + ((x - 1) * ((sizexyx - (2 * a)) / Form1.xn))
                    Dim topbacklefty As Integer = b + ((y - 1) * ((sizexyy - (2 * b)) / Form1.yn))

                    Dim bottombackrightx As Integer = a + (x * ((sizexyx - (2 * a)) / Form1.xn))
                    Dim bottombackrighty As Integer = b + (y * ((sizexyy - (2 * b)) / Form1.yn))
                    Dim bottombackleftx As Integer = a + ((x - 1) * ((sizexyx - (2 * a)) / Form1.xn))
                    Dim bottombacklefty As Integer = b + (y * ((sizexyy - (2 * b)) / Form1.yn))


                    Dim topfrontright As New System.Drawing.Point(topfrontrightx, topfrontrighty)
                    Dim topfrontleft As New System.Drawing.Point(topfrontleftx, topfrontlefty)
                    Dim bottomfrontright As New System.Drawing.Point(bottomfrontrightx, bottomfrontrighty)
                    Dim bottomfrontleft As New System.Drawing.Point(bottomfrontleftx, bottomfrontlefty)

                    Dim topbackright As New System.Drawing.Point(topbackrightx, topbackrighty)
                    Dim topbackleft As New System.Drawing.Point(topbackleftx, topbacklefty)
                    Dim bottombackright As New System.Drawing.Point(bottombackrightx, bottombackrighty)
                    Dim bottombackleft As New System.Drawing.Point(bottombackleftx, bottombacklefty)

                    Dim backface As Point() = {topbackleft, topbackright, bottombackright, bottombackleft}
                    Dim rightface As Point() = {topbackright, bottombackright, bottomfrontright, topfrontright}
                    Dim leftface As Point() = {topbackleft, bottombackleft, bottomfrontleft, topfrontleft}
                    Dim topface As Point() = {topbackleft, topbackright, topfrontright, topfrontleft}
                    Dim bottomface As Point() = {bottombackleft, bottombackright, bottomfrontright, bottomfrontleft}
                    Dim frontface As Point() = {topfrontright, topfrontleft, bottomfrontleft, bottomfrontright}

                    Dim transparent As New SolidBrush(Color.FromArgb(25, rr, gg, bb))

                    gfabiotic.FillPolygon(transparent, backface)
                    gfabiotic.FillPolygon(transparent, rightface)
                    gfabiotic.FillPolygon(transparent, leftface)
                    gfabiotic.FillPolygon(transparent, topface)
                    gfabiotic.FillPolygon(transparent, bottomface)
                    gfabiotic.FillPolygon(transparent, frontface)
                Next

            Next
        Next

        Dim overgrid As System.Drawing.Pen = New Pen(Brushes.Black, 2)

        For x = 0 To Form1.yn
            gfabiotic.DrawLine(overgrid, 0, cellxyy * x, sizexyx, cellxyy * x)
        Next

        For y = 0 To Form1.xn
            gfabiotic.DrawLine(overgrid, cellxyx * y, 0, cellxyx * y, sizexyy)
        Next

        PictureBox1.Image = picabiotic
    End Sub

    Sub grid()
        Dim angle As Single = Math.Atan(Form1.xn / Form1.yn)
        Dim backgrid As System.Drawing.Pen = New Pen(Brushes.DarkGray, 1)
        Dim skeleton As System.Drawing.Pen = New Pen(Brushes.Gray, 1)
        Dim light As System.Drawing.Pen = New Pen(Brushes.Silver, 1)

        Dim diag As Single
        Dim jump As Single = Form1.cellxyx
        Dim a As Integer
        Dim b As Integer

        For i = 1 To Form1.zn
            jump = jump * (Form1.sizeratio)
            diag = diag + jump
            a = Math.Sin(angle) * diag
            b = Math.Cos(angle) * diag
            gfabiotic.DrawLine(backgrid, a, b, Form1.sizexyx - a, b)
            gfabiotic.DrawLine(backgrid, a, Form1.sizexyy - b, Form1.sizexyx - a, Form1.sizexyy - b)
            gfabiotic.DrawLine(backgrid, a, b, a, Form1.sizexyy - b)
            gfabiotic.DrawLine(backgrid, Form1.sizexyx - a, b, Form1.sizexyx - a, Form1.sizexyy - b)
            If i = Form1.zn Then
                Dim cell As Single
                Dim celly As Single
                cell = (Form1.sizexyx - (a * 2)) / Form1.xn
                celly = (Form1.sizexyy - (b * 2)) / Form1.yn
                For j = 1 To Form1.xn - 1
                    gfabiotic.DrawLine(backgrid, a + (cell * j), b, (Form1.cellxyx * j), 0)
                    gfabiotic.DrawLine(backgrid, a + (cell * j), Form1.sizexyy - b, (Form1.cellxyx * j), Form1.sizexyy)
                    gfabiotic.DrawLine(light, a + (cell * j), b, a + (cell * j), Form1.sizexyy - b)
                Next

                For k = 1 To Form1.yn - 1
                    gfabiotic.DrawLine(backgrid, a, b + (celly * k), 0, (Form1.cellxyy * k))
                    gfabiotic.DrawLine(backgrid, Form1.sizexyx, (Form1.cellxyy * k), Form1.sizexyx - a, b + (celly * k))
                    gfabiotic.DrawLine(light, a, b + (celly * k), Form1.sizexyx - a, b + (celly * k))
                Next
            End If
        Next

        a = Math.Sin(angle) * diag
        b = Math.Cos(angle) * diag

        gfabiotic.DrawLine(skeleton, 0, 0, a, b)
        gfabiotic.DrawLine(skeleton, Form1.sizexyx, 0, Form1.sizexyx - a, b)
        gfabiotic.DrawLine(skeleton, 0, Form1.sizexyy, a, Form1.sizexyy - b)
        gfabiotic.DrawLine(skeleton, Form1.sizexyx, Form1.sizexyy, Form1.sizexyx - a, Form1.sizexyy - b)
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
