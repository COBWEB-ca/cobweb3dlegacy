Public Class frmCrossSection
    Private newbutton(Form1.xn * Form1.yn) As Button
    Public zdimension As Integer
    Public proposedlocation(Form1.agent, Form1.xn, Form1.yn, Form1.zn) As Integer
    Public direction(Form1.agent) As Integer
    Public agentid As Integer

    Private Sub frmCrossSection_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For ii = 1 To Form1.agent
            ComboBox1.Items.Add(generator.agentname(ii))
        Next

        For ii = 1 To Form1.zn
            ComboBox2.Items.Add(ii)
        Next

        Dim i As Integer = 0
        Dim xlocation As Integer = 280
        Dim ylocation As Integer = 75

        For yd = 1 To Form1.yn
            For xd = 1 To Form1.xn
                newbutton(i) = New Button
                newbutton(i).Height = 50
                newbutton(i).Width = 50
                newbutton(i).Location = New Point(xlocation, ylocation)
                newbutton(i).BackColor = Color.Transparent
                newbutton(i).Text = "(" & xd & ", " & yd & ")"
                AddHandler newbutton(i).Click, AddressOf buttonclick
                Me.Controls.Add(newbutton(i))
                i += 1
                xlocation += 50
            Next
            xlocation = 280
            ylocation += 50
        Next

        For xx = 1 To Form1.xn
            For yy = 1 To Form1.yn
                For zz = 1 To Form1.zn
                    For aa = 1 To Form1.agent
                        proposedlocation(aa, xx, yy, zz) = 0
                    Next
                Next
            Next
        Next

        ComboBox1.SelectedIndex = 0
        ComboBox2.SelectedIndex = 0
        zdimension = 1

        Try
            For xx = 1 To Form1.xn
                For yy = 1 To Form1.yn
                    If generator.occupied(xx, yy, zdimension) = True Then
                        For i = 0 To Form1.xn * Form1.yn - 1
                            If newbutton(i).Text = "(" & xx & ", " & yy & ")" Then
                                newbutton(i).BackColor = Color.Red
                            End If
                        Next
                    End If
                Next
            Next
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        Call creatorCrossSection()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        zdimension = ComboBox2.SelectedIndex + 1
        'For i = 1 To Form1.xn * Form1.yn
        '    newbutton(i).BackColor = Color.Transparent
        'Next

        Try
            For xx = 1 To Form1.xn
                For yy = 1 To Form1.yn
                    If proposedlocation(ComboBox1.SelectedIndex + 1, xx, yy, zdimension) = 2 Then
                        For i = 0 To Form1.xn * Form1.yn - 1
                            If newbutton(i).Text = "(" & xx & ", " & yy & ")" Then
                                newbutton(i).BackColor = Color.LightSkyBlue
                            End If
                        Next
                    ElseIf proposedlocation(ComboBox1.SelectedIndex + 1, xx, yy, zdimension) = 0 Then
                        For i = 0 To Form1.xn * Form1.yn - 1
                            If newbutton(i).Text = "(" & xx & ", " & yy & ")" Then
                                newbutton(i).BackColor = Color.Transparent
                            End If
                        Next
                    End If
                    If generator.occupied(xx, yy, zdimension) = True Then
                        For i = 0 To Form1.xn * Form1.yn - 1
                            If newbutton(i).Text = "(" & xx & ", " & yy & ")" Then
                                newbutton(i).BackColor = Color.Red
                            End If
                        Next
                    End If
                Next
            Next
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        Call creatorCrossSection()
    End Sub

    Private Sub buttonclick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.BackColor = Color.Transparent Then
            sender.BackColor = Color.LightSkyBlue
            For yd = 1 To Form1.yn
                For xd = 1 To Form1.xn
                    If sender.Text = "(" & xd & ", " & yd & ")" Then
                        proposedlocation(ComboBox1.SelectedIndex + 1, xd, yd, zdimension) = 2
                    End If
                Next
            Next
        ElseIf sender.BackColor = Color.LightSkyBlue Then
            sender.BackColor = Color.Transparent
            For yd = 1 To Form1.yn
                For xd = 1 To Form1.xn
                    If sender.Text = "(" & xd & ", " & yd & ")" Then
                        proposedlocation(ComboBox1.SelectedIndex + 1, xd, yd, zdimension) = 0
                    End If
                Next
            Next
        ElseIf sender.backcolor = Color.Red Then
            MessageBox.Show("This location is already occupied.", "Invalid Location", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        Call creatorCrossSection()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call produce()
        Me.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        agentid = ComboBox1.SelectedIndex + 1

        Try
            For xx = 1 To Form1.xn
                For yy = 1 To Form1.yn
                    If proposedlocation(ComboBox1.SelectedIndex + 1, xx, yy, zdimension) = 2 Then
                        For i = 0 To Form1.xn * Form1.yn - 1
                            If newbutton(i).Text = "(" & xx & ", " & yy & ")" Then
                                newbutton(i).BackColor = Color.LightSkyBlue
                            End If
                        Next
                    ElseIf proposedlocation(ComboBox1.SelectedIndex + 1, xx, yy, zdimension) = 0 Then
                        For i = 0 To Form1.xn * Form1.yn - 1
                            If newbutton(i).Text = "(" & xx & ", " & yy & ")" Then
                                newbutton(i).BackColor = Color.Transparent
                            End If
                        Next
                    End If
                    If generator.occupied(xx, yy, zdimension) = True Then
                        For i = 0 To Form1.xn * Form1.yn - 1
                            If newbutton(i).Text = "(" & xx & ", " & yy & ")" Then
                                newbutton(i).BackColor = Color.Red
                            End If
                        Next
                    End If
                Next
            Next
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    'adds new agents 
    Sub produce()

        For xx = 1 To Form1.xn
            For yy = 1 To Form1.yn
                For zz = 1 To Form1.zn
                    For aa = 1 To Form1.agent
                        If proposedlocation(aa, xx, yy, zz) = 2 Then
                            If generator.occupied(xx, yy, zz) = False Then
                                Form1.total = Form1.total + 1
                                Dim ddx As Integer = CInt(Math.Floor((Form1.xn) * Rnd())) + 1
                                Dim ddy As Integer = CInt(Math.Floor((Form1.yn) * Rnd())) + 1
                                Dim ddz As Integer = CInt(Math.Floor((Form1.zn) * Rnd())) + 1
                                generator.agentlocation(Form1.total, 0) = xx
                                generator.agentlocation(Form1.total, 1) = yy
                                generator.agentlocation(Form1.total, 2) = zz
                                If direction(aa) = 0 Then
                                    generator.agentlocation(Form1.total, 3) = CInt(Math.Floor((6) * Rnd())) + 1
                                Else
                                    generator.agentlocation(Form1.total, 3) = direction(aa)
                                End If
                                generator.agentlocation(Form1.total, 4) = aa
                                generator.agentlocation(Form1.total, 5) = ddx
                                generator.agentlocation(Form1.total, 6) = ddy
                                generator.agentlocation(Form1.total, 7) = ddz
                                generator.agentlocation(Form1.total, 8) = generator.initialenergy(aa)
                                generator.agentlocation(Form1.total, 9) = 0
                                generator.agentlocation(Form1.total, 10) = 0
                                generator.occupied(xx, yy, zz) = True
                                generator.agentcount(aa) = 0
                                For f = 1 To Form1.total
                                    If generator.agentlocation(f, 4) = aa Then
                                        generator.agentcount(aa) += 1
                                    End If
                                Next
                            End If
                        End If
                    Next
                Next
            Next
        Next

        'placing the agents
        generator.gfxxy.Clear(Color.White)
        Call generator.gridxy()
        generator.agentchange = True
        For ii = 1 To Form1.total
            Dim xx As Integer = generator.agentlocation(ii, 0)
            Dim yy As Integer = generator.agentlocation(ii, 1)
            Dim zz As Integer = generator.agentlocation(ii, 2)
            Dim dd As Integer = generator.agentlocation(ii, 3)
            Dim agag As Integer = generator.agentlocation(ii, 4)
            Call Form1.creator(xx, yy, zz, dd, generator.agentcolour(agag), ii)
        Next
        Call generator.topgridxy()
        Call Form1.picshow()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        frmDirection.Show()
    End Sub

    Sub creatorCrossSection()
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

        sizexyx = (res / ratio1) ^ 0.5
        sizexyy = ratio1 * sizexyx

        sizexzx = (Res / ratio2) ^ 0.5
        sizexzz = ratio2 * sizexzx

        sizezyz = (Res / ratio3) ^ 0.5
        sizezyy = ratio3 * sizezyz

        cellxyx = sizexyx / Form1.xn
        cellxyy = sizexyy / Form1.yn

        cellxzx = sizexzx / Form1.xn
        cellxzz = sizexzz / Form1.zn

        cellzyz = sizezyz / Form1.zn
        cellzyy = sizezyy / Form1.yn

        generator.gfCrossSection.Clear(Color.White)

        Dim angle As Single = Math.Atan(Form1.xn / Form1.yn)
        Dim backgrid As System.Drawing.Pen = New Pen(Brushes.DarkGray, 1)
        Dim skeleton As System.Drawing.Pen = New Pen(Brushes.Gray, 1)
        Dim light As System.Drawing.Pen = New Pen(Brushes.Silver, 1)

        Dim diag As Single
        Dim jump As Single = cellxyx
        Dim a As Integer
        Dim b As Integer

        For i = 1 To 1
            jump = jump * (Form1.sizeratio)
            diag = diag + jump
            a = Math.Sin(angle) * diag
            b = Math.Cos(angle) * diag
            generator.gfCrossSection.DrawLine(backgrid, a, b, sizexyx - a, b)
            generator.gfCrossSection.DrawLine(backgrid, a, sizexyy - b, sizexyx - a, sizexyy - b)
            generator.gfCrossSection.DrawLine(backgrid, a, b, a, sizexyy - b)
            generator.gfCrossSection.DrawLine(backgrid, sizexyx - a, b, sizexyx - a, sizexyy - b)
            If i = Form1.zn Then
                Dim cell As Single
                Dim celly As Single
                cell = (sizexyx - (a * 2)) / Form1.xn
                celly = (sizexyy - (b * 2)) / Form1.yn
                For j = 1 To 1
                    generator.gfCrossSection.DrawLine(backgrid, a + (cell * j), b, (cellxyx * j), 0)
                    generator.gfCrossSection.DrawLine(backgrid, a + (cell * j), sizexyy - b, (cellxyx * j), sizexyy)
                    generator.gfCrossSection.DrawLine(light, a + (cell * j), b, a + (cell * j), sizexyy - b)
                Next

                For k = 1 To Form1.yn - 1
                    generator.gfCrossSection.DrawLine(backgrid, a, b + (celly * k), 0, (cellxyy * k))
                    generator.gfCrossSection.DrawLine(backgrid, sizexyx, (cellxyy * k), sizexyx - a, b + (celly * k))
                    generator.gfCrossSection.DrawLine(light, a, b + (celly * k), sizexyx - a, b + (celly * k))
                Next
            End If
        Next

        a = Math.Sin(angle) * diag
        b = Math.Cos(angle) * diag

        generator.gfCrossSection.DrawLine(skeleton, 0, 0, a, b)
        generator.gfCrossSection.DrawLine(skeleton, sizexyx, 0, sizexyx - a, b)
        generator.gfCrossSection.DrawLine(skeleton, 0, sizexyy, a, sizexyy - b)
        generator.gfCrossSection.DrawLine(skeleton, sizexyx, sizexyy, sizexyx - a, sizexyy - b)

        For ii = 1 To Form1.total
            Dim xx As Integer = generator.agentlocation(ii, 0)
            Dim yy As Integer = generator.agentlocation(ii, 1)
            Dim zz As Integer = generator.agentlocation(ii, 2)
            Dim dd As Integer = generator.agentlocation(ii, 3)
            Dim agag As Integer = generator.agentlocation(ii, 4)
            If zz = ComboBox2.SelectedIndex + 1 Then
                Call Form1.creatorc(xx, yy, 1, dd, generator.agentcolour(agag), ii)
            End If
        Next

        'draws new agents
        For xxi = 1 To Form1.xn
            For yyi = 1 To Form1.yn
                For zzi = 1 To Form1.zn
                    For aai = 1 To Form1.agent
                        If proposedlocation(aai, xxi, yyi, zzi) = 2 Then
                            If generator.occupied(xxi, yyi, zzi) = False Then
                                If zzi = ComboBox2.SelectedIndex + 1 Then
                                    If generator.staticagentid(aai) = 2 Then
                                        If direction(aai) = 0 Then
                                            Call Form1.creatorc(xxi, yyi, 1, CInt(Math.Floor((6) * Rnd())) + 1, generator.agentcolour(aai), -1)
                                        Else
                                            Call Form1.creatorc(xxi, yyi, 1, direction(aai), generator.agentcolour(aai), -1)
                                        End If
                                    Else
                                        If direction(aai) = 0 Then
                                            Call Form1.creatorc(xxi, yyi, 1, CInt(Math.Floor((6) * Rnd())) + 1, generator.agentcolour(aai), 0)
                                        Else
                                            Call Form1.creatorc(xxi, yyi, 1, direction(aai), generator.agentcolour(aai), 0)
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    Next
                Next
            Next
        Next

        Dim overgrid As System.Drawing.Pen = New Pen(Brushes.Black, 2)

        For x = 0 To Form1.yn
            generator.gfCrossSection.DrawLine(overgrid, 0, cellxyy * x, sizexyx, cellxyy * x)
        Next

        For y = 0 To Form1.xn
            generator.gfCrossSection.DrawLine(overgrid, cellxyx * y, 0, cellxyx * y, sizexyy)
        Next

        PictureBox1.Image = generator.picCrossSection
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        If PictureBox1.Width < 600 And PictureBox1.Height < 600 Then
            PictureBox1.Width = 600
            PictureBox1.Height = 600
            PictureBox1.BringToFront()
        Else
            PictureBox1.Width = 263
            PictureBox1.Height = 263
            PictureBox1.SendToBack()
        End If
    End Sub
End Class
