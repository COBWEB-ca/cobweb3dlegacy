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
        Dim xlocation As Integer = 0
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
            xlocation = 0
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
End Class
