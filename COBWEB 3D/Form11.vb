Public Class Form11

    Private picabiotic As New Bitmap(Form1.sizexyx, Form1.sizexyy)
    Private gfabiotic As Graphics = System.Drawing.Graphics.FromImage(picabiotic)

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
        'Call grid()

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

        For z = 1 To Form1.zn
            For y = 1 To Form1.yn
                For x = 1 To Form1.xn

                    'rr = 255 - (generator.abiotic(ComboBoxagent.SelectedIndex + 1, x, y, z) / max * 255)
                    'gg = 255 - (generator.abiotic(ComboBoxagent.SelectedIndex + 1, x, y, z) / max * 255)

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
                    Dim edgecolour As New Pen(Color.FromArgb(255, rr, gg, bb))

                    'gfabiotic.FillPolygon(transparent, backface)
                    'gfabiotic.FillPolygon(transparent, rightface)
                    'gfabiotic.FillPolygon(transparent, leftface)
                    'gfabiotic.FillPolygon(transparent, topface)
                    'gfabiotic.FillPolygon(transparent, bottomface)
                    'gfabiotic.FillPolygon(transparent, frontface)

                    'gfabiotic.DrawLine(edgecolour, topfrontright, topfrontleft)
                    'gfabiotic.DrawLine(edgecolour, topfrontright, bottomfrontright)
                    'gfabiotic.DrawLine(edgecolour, bottomfrontleft, bottomfrontright)
                    'gfabiotic.DrawLine(edgecolour, bottomfrontleft, topfrontleft)

                    'gfabiotic.DrawLine(edgecolour, topfrontright, topbackright)
                    'gfabiotic.DrawLine(edgecolour, topfrontleft, topbackleft)
                    'gfabiotic.DrawLine(edgecolour, bottomfrontright, bottombackright)
                    'gfabiotic.DrawLine(edgecolour, bottomfrontleft, bottombackleft)

                    'gfabiotic.DrawLine(edgecolour, topbackright, bottombackright)
                    'gfabiotic.DrawLine(edgecolour, bottombackright, bottombackleft)
                    'gfabiotic.DrawLine(edgecolour, bottombackleft, topbackleft)
                    'gfabiotic.DrawLine(edgecolour, topbackleft, topbackright)

                    For ii = 1 To 1000
                        If generator.zones(ii, 1) = 0 Or generator.zones(ii, 2) = 0 Or generator.zones(ii, 3) = 0 Or generator.zones(ii, 4) = 0 Or generator.zones(ii, 5) = 0 Or generator.zones(ii, 6) = 0 Then
                            Exit For
                        End If

                        If x >= generator.zones(ii, 1) And x <= generator.zones(ii, 2) And y >= generator.zones(ii, 3) And y <= generator.zones(ii, 4) And z >= generator.zones(ii, 5) And z <= generator.zones(ii, 6) Then
                            If x = generator.zones(ii, 1) And z = generator.zones(ii, 5) Then 'front face
                                gfabiotic.DrawLine(edgecolour, topfrontleft, bottomfrontleft)
                            End If
                            If x = generator.zones(ii, 2) And z = generator.zones(ii, 5) Then
                                gfabiotic.DrawLine(edgecolour, topfrontright, bottomfrontright)
                            End If
                            If y = generator.zones(ii, 3) And z = generator.zones(ii, 5) Then
                                gfabiotic.DrawLine(edgecolour, topfrontleft, topfrontright)
                            End If
                            If y = generator.zones(ii, 4) And z = generator.zones(ii, 5) Then
                                gfabiotic.DrawLine(edgecolour, bottomfrontleft, bottomfrontright)
                            End If

                            If x = generator.zones(ii, 1) And z = generator.zones(ii, 6) Then 'rear face
                                gfabiotic.DrawLine(edgecolour, topbackleft, bottombackleft)
                            End If
                            If x = generator.zones(ii, 2) And z = generator.zones(ii, 6) Then
                                gfabiotic.DrawLine(edgecolour, topbackright, bottombackright)
                            End If
                            If y = generator.zones(ii, 3) And z = generator.zones(ii, 6) Then
                                gfabiotic.DrawLine(edgecolour, topbackleft, topbackright)
                            End If
                            If y = generator.zones(ii, 4) And z = generator.zones(ii, 6) Then
                                gfabiotic.DrawLine(edgecolour, bottombackleft, bottombackright)
                            End If

                            If x = generator.zones(ii, 1) And y = generator.zones(ii, 3) Then 'side faces
                                gfabiotic.DrawLine(edgecolour, topfrontleft, topbackleft)
                            End If
                            If x = generator.zones(ii, 2) And y = generator.zones(ii, 3) Then
                                gfabiotic.DrawLine(edgecolour, topfrontright, topbackright)
                            End If
                            If x = generator.zones(ii, 1) And y = generator.zones(ii, 4) Then
                                gfabiotic.DrawLine(edgecolour, bottomfrontleft, bottombackleft)
                            End If
                            If x = generator.zones(ii, 2) And y = generator.zones(ii, 4) Then
                                gfabiotic.DrawLine(edgecolour, bottomfrontright, bottombackright)
                            End If
                        End If
                    Next
                Next

            Next
        Next

        'Dim overgrid As System.Drawing.Pen = New Pen(Brushes.Black, 2)

        'For x = 0 To Form1.yn
        '    gfabiotic.DrawLine(overgrid, 0, cellxyy * x, sizexyx, cellxyy * x)
        'Next

        'For y = 0 To Form1.xn
        '    gfabiotic.DrawLine(overgrid, cellxyx * y, 0, cellxyx * y, sizexyy)
        'Next

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
