Public Class Form3
    Private red As Integer
    Private blue As Integer
    Private green As Integer
    Public selectedagent As Integer


    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For i = 1 To Form1.agent
            ComboBoxagent.Items.Add(generator.agentname(i))
        Next
    End Sub

    Private Sub ComboBoxagent_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxagent.SelectedIndexChanged
        If ComboBoxagent.Text <> "" Then
            TextBoxcount.Enabled = True
            TextBoxname.Enabled = True
            GroupBox1.Enabled = True
            TextBoxinienergy.Enabled = True
            TextBoxstepenergy.Enabled = True
            TextBoxbumpenergy.Enabled = True
            GroupBoxaging.Enabled = True
            GroupBox3.Enabled = True
            GroupBox4.Enabled = True
            txtasr.Enabled = True
            txtasrenergy.Enabled = True
        End If



        TextBoxcount.Text = ""
        For i = 1 To Form1.agent
            If ComboBoxagent.SelectedIndex + 1 = i Then
                TextBoxcount.Text = generator.agentcount(ComboBoxagent.SelectedIndex + 1)
                TextBoxname.Text = generator.agentname(ComboBoxagent.SelectedIndex + 1)
                TrackBar4.Value = generator.agentcolour(ComboBoxagent.SelectedIndex + 1).R / 25
                TrackBar2.Value = generator.agentcolour(ComboBoxagent.SelectedIndex + 1).G / 25
                TrackBar3.Value = generator.agentcolour(ComboBoxagent.SelectedIndex + 1).B / 25
                TextBox1.Text = TrackBar4.Value * 25
                TextBox2.Text = TrackBar2.Value * 25
                TextBox3.Text = TrackBar3.Value * 25
                red = generator.agentcolour(ComboBoxagent.SelectedIndex + 1).R
                green = generator.agentcolour(ComboBoxagent.SelectedIndex + 1).G
                blue = generator.agentcolour(ComboBoxagent.SelectedIndex + 1).B
                colour.BackColor = generator.agentcolour(ComboBoxagent.SelectedIndex + 1)

                TextBoxinienergy.Text = generator.initialenergy(ComboBoxagent.SelectedIndex + 1)
                TextBoxstepenergy.Text = generator.stepenergy(ComboBoxagent.SelectedIndex + 1)
                TextBoxbumpenergy.Text = generator.bumpenergy(ComboBoxagent.SelectedIndex + 1)
                CheckBoxaging.Checked = generator.aging(ComboBoxagent.SelectedIndex + 1)
                TextBoxagelimit.Text = generator.agelimit(ComboBoxagent.SelectedIndex + 1)
                txtasr.Text = generator.asrtime(ComboBoxagent.SelectedIndex + 1)
                txtasrenergy.Text = generator.asrenergy(ComboBoxagent.SelectedIndex + 1)
                CheckBoxasr.Checked = generator.asr(ComboBoxagent.SelectedIndex + 1)
                selectedagent = ComboBoxagent.SelectedIndex + 1
            End If
        Next
    End Sub

    Private Sub TextBox5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxcount.TextChanged
        If IsNumeric(TextBoxcount.Text) Then
            generator.agentcount(ComboBoxagent.SelectedIndex + 1) = TextBoxcount.Text
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Randomize()
        Form1.total = 0
        Form1.tick = 0

        Dim number As Integer

        Dim agents(Form1.agent) As Integer

        For a = 1 To Form1.agent
            Dim agentsadded As Integer = 0
            For i = 1 To generator.agentcount(a)
                number = number + 1
                Dim x As Integer = CInt(Math.Floor((Form1.xn) * Rnd())) + 1
                Dim y As Integer = CInt(Math.Floor((Form1.yn) * Rnd())) + 1
                Dim z As Integer = CInt(Math.Floor((Form1.zn) * Rnd())) + 1

                Dim dx As Integer
                Dim dy As Integer
                Dim dz As Integer

                Dim rangexupper As Integer = generator.agentrange(a, 0, 1)
                Dim rangexlower As Integer = generator.agentrange(a, 0, 0)
                Dim rangeyupper As Integer = generator.agentrange(a, 1, 1)
                Dim rangeylower As Integer = generator.agentrange(a, 1, 0)
                Dim rangezupper As Integer = generator.agentrange(a, 2, 1)
                Dim rangezlower As Integer = generator.agentrange(a, 2, 0)



                dx = CInt(Math.Floor((rangexupper - rangexlower + 1) * Rnd())) + rangexlower
                dy = CInt(Math.Floor((rangeyupper - rangeylower + 1) * Rnd())) + rangeylower
                dz = CInt(Math.Floor((rangezupper - rangezlower + 1) * Rnd())) + rangezlower


                Do While generator.occupied(x, y, z) = True
                    x = CInt(Math.Floor((Form1.xn) * Rnd())) + 1
                    y = CInt(Math.Floor((Form1.yn) * Rnd())) + 1
                    z = CInt(Math.Floor((Form1.zn) * Rnd())) + 1
                Loop

                'this allows agents to start in a specific range. if all or almost all spaces in a region are occupied, the program moves onto the next agent type
                If generator.agentstart(a, 0) = 2 Then
                    Dim maxiterations As Double
                    x = CInt(Math.Floor(((generator.agentstart(a, 1) - generator.agentstart(a, 2)) + 1) * Rnd()) + generator.agentstart(a, 2))
                    y = CInt(Math.Floor(((generator.agentstart(a, 3) - generator.agentstart(a, 4)) + 1) * Rnd()) + generator.agentstart(a, 4))
                    z = CInt(Math.Floor(((generator.agentstart(a, 5) - generator.agentstart(a, 6)) + 1) * Rnd()) + generator.agentstart(a, 6))
                    Try
                        Do While generator.occupied(x, y, z) = True And maxiterations < 100000
                            x = CInt(Math.Floor((generator.agentstart(a, 1) - generator.agentstart(a, 2) + 1) * Rnd()) + generator.agentstart(a, 2))
                            y = CInt(Math.Floor((generator.agentstart(a, 3) - generator.agentstart(a, 4) + 1) * Rnd()) + generator.agentstart(a, 4))
                            z = CInt(Math.Floor((generator.agentstart(a, 5) - generator.agentstart(a, 6) + 1) * Rnd()) + generator.agentstart(a, 6))
                            maxiterations += 1
                        Loop
                    Catch ex As Exception
                        MessageBox.Show(x & " " & y & " " & z)
                    End Try

                    If maxiterations = 100000 Then
                        i = generator.agentcount(a) + 1
                        agents(a) = agentsadded
                    End If
                End If

                generator.occupied(x, y, z) = True

                If i <> generator.agentcount(a) + 1 Then
                    Dim d As Integer = CInt(Math.Floor((6) * Rnd())) + 1
                    generator.agentlocation(number, 0) = x
                    generator.agentlocation(number, 1) = y
                    generator.agentlocation(number, 2) = z
                    generator.agentlocation(number, 3) = d
                    generator.agentlocation(number, 4) = a
                    generator.agentlocation(number, 5) = dx
                    generator.agentlocation(number, 6) = dy
                    generator.agentlocation(number, 7) = dz
                    generator.agentlocation(number, 8) = generator.initialenergy(a)
                    generator.agentlocation(number, 9) = 0
                    generator.agentlocation(number, 10) = 0
                    agentsadded += 1
                End If

                If i = generator.agentcount(a) Then
                    agents(a) = agentsadded
                End If
            Next

        Next


        '...........................................................................................................

        For i = 1 To Form1.agent
            Form1.total = Form1.total + agents(i)
            'Form1.total = Form1.total + generator.agentcount(i)
        Next



        For index = 2 To Form1.total
            Dim tempz As Integer = generator.agentlocation(index, 2)
            Dim tempx As Integer = generator.agentlocation(index, 0)
            Dim tempy As Integer = generator.agentlocation(index, 1)
            Dim tempd As Integer = generator.agentlocation(index, 3)
            Dim tempa As Integer = generator.agentlocation(index, 4)
            Dim tempstatic As Integer = generator.staticagent(index)

            Dim tempdx As Integer = generator.agentlocation(index, 5)
            Dim tempdy As Integer = generator.agentlocation(index, 6)
            Dim tempdz As Integer = generator.agentlocation(index, 7)

            Dim tempenergy As Integer = generator.agentlocation(index, 8)
            Dim tempage As Integer = generator.agentlocation(index, 9)
            Dim tempasr As Integer = generator.agentlocation(index, 10)

            Dim previousposition As Integer = index - 1
            Do While tempz > generator.agentlocation(previousposition, 2) And previousposition >= 1
                generator.agentlocation(previousposition + 1, 0) = generator.agentlocation(previousposition, 0)
                generator.agentlocation(previousposition + 1, 1) = generator.agentlocation(previousposition, 1)
                generator.agentlocation(previousposition + 1, 2) = generator.agentlocation(previousposition, 2)
                generator.agentlocation(previousposition + 1, 3) = generator.agentlocation(previousposition, 3)
                generator.agentlocation(previousposition + 1, 4) = generator.agentlocation(previousposition, 4)

                generator.agentlocation(previousposition + 1, 5) = generator.agentlocation(previousposition, 5)
                generator.agentlocation(previousposition + 1, 6) = generator.agentlocation(previousposition, 6)
                generator.agentlocation(previousposition + 1, 7) = generator.agentlocation(previousposition, 7)

                generator.agentlocation(previousposition + 1, 8) = generator.agentlocation(previousposition, 8)
                generator.agentlocation(previousposition + 1, 9) = generator.agentlocation(previousposition, 9)
                generator.agentlocation(previousposition + 1, 10) = generator.agentlocation(previousposition, 10)

                If generator.staticagent(previousposition) = 2 Then
                    generator.staticagent(previousposition + 1) = 2
                ElseIf generator.staticagent(previousposition) = 0 Then
                    generator.staticagent(previousposition + 1) = 0
                End If

                previousposition = previousposition - 1
            Loop

            If tempstatic = 2 Then
                generator.staticagent(previousposition + 1) = 2
            ElseIf tempstatic = 0 Then
                generator.staticagent(previousposition + 1) = 0
            End If

            generator.agentlocation(previousposition + 1, 2) = tempz
            generator.agentlocation(previousposition + 1, 0) = tempx
            generator.agentlocation(previousposition + 1, 1) = tempy
            generator.agentlocation(previousposition + 1, 3) = tempd
            generator.agentlocation(previousposition + 1, 4) = tempa

            generator.agentlocation(previousposition + 1, 5) = tempdx
            generator.agentlocation(previousposition + 1, 6) = tempdy
            generator.agentlocation(previousposition + 1, 7) = tempdz

            generator.agentlocation(previousposition + 1, 8) = tempenergy
            generator.agentlocation(previousposition + 1, 9) = tempage
            generator.agentlocation(previousposition + 1, 10) = tempasr

        Next

        'changes the direction of new agents according to user input
        For i = 1 To Form1.agent
            If generator.agentdirection(i) <> 0 Then
                For a = 1 To Form1.total
                    If generator.agentlocation(a, 4) = i Then
                        generator.agentlocation(a, 3) = generator.agentdirection(i)
                    End If
                Next
            End If
        Next

        generator.gfxxy.Clear(Color.White)
        Call generator.gridxy()

        generator.agentchange = True

        ' placing the agents
        For i = 1 To Form1.total
            Dim x As Integer = generator.agentlocation(i, 0)
            Dim y As Integer = generator.agentlocation(i, 1)
            Dim z As Integer = generator.agentlocation(i, 2)
            Dim d As Integer = generator.agentlocation(i, 3)
            Dim ag As Integer = generator.agentlocation(i, 4)
            Dim s As Integer = i
            Call Form1.creator(x, y, z, d, generator.agentcolour(ag), s)
        Next


        Call generator.topgridxy()
        Call Form1.picshow()
        'Form1.PictureBox1.Image = generator.picxy


        Me.Close()

    End Sub


    Private Sub TextBoxname_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxname.Validated
        generator.agentname(ComboBoxagent.SelectedIndex + 1) = TextBoxname.Text

        ComboBoxagent.Items.Clear()
        For i = 1 To Form1.agent
            ComboBoxagent.Items.Add(generator.agentname(i))
        Next

        ComboBoxagent.Text = TextBoxname.Text
    End Sub


    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        red = TextBox1.Text
        colour.BackColor = Color.FromArgb(red, green, blue)
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        green = TextBox2.Text
        colour.BackColor = Color.FromArgb(red, green, blue)
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
        blue = TextBox3.Text
        colour.BackColor = Color.FromArgb(red, green, blue)
    End Sub

    Private Sub TrackBar4_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar4.Scroll
        red = TrackBar4.Value * 25
        TextBox1.Text = red
        colour.BackColor = Color.FromArgb(red, green, blue)
        generator.agentcolour(ComboBoxagent.SelectedIndex + 1) = colour.BackColor
    End Sub

    Private Sub TrackBar3_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar3.Scroll
        blue = TrackBar3.Value * 25
        TextBox3.Text = blue
        colour.BackColor = Color.FromArgb(red, green, blue)
        generator.agentcolour(ComboBoxagent.SelectedIndex + 1) = colour.BackColor
    End Sub

    Private Sub TrackBar2_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar2.Scroll
        green = TrackBar2.Value * 25
        TextBox2.Text = green
        colour.BackColor = Color.FromArgb(red, green, blue)
        generator.agentcolour(ComboBoxagent.SelectedIndex + 1) = colour.BackColor
    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxinienergy.TextChanged
        If IsNumeric(TextBoxinienergy.Text) Then
            generator.initialenergy(ComboBoxagent.SelectedIndex + 1) = TextBoxinienergy.Text
        End If
    End Sub

    Private Sub TextBox5_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxstepenergy.TextChanged
        If IsNumeric(TextBoxstepenergy.Text) Then
            generator.stepenergy(ComboBoxagent.SelectedIndex + 1) = TextBoxstepenergy.Text
        End If
    End Sub

    Private Sub TextBoxbumpenergy_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxbumpenergy.TextChanged
        If IsNumeric(TextBoxbumpenergy.Text) Then
            generator.bumpenergy(ComboBoxagent.SelectedIndex + 1) = TextBoxbumpenergy.Text
        End If
    End Sub

    Private Sub TextBox7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxagelimit.TextChanged
        If IsNumeric(TextBoxagelimit.Text) Then
            generator.agelimit(ComboBoxagent.SelectedIndex + 1) = TextBoxagelimit.Text
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxaging.CheckedChanged
        If CheckBoxaging.Checked = True Then
            generator.aging(ComboBoxagent.SelectedIndex + 1) = True
        ElseIf CheckBoxaging.Checked = False Then
            generator.aging(ComboBoxagent.SelectedIndex + 1) = False
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxasr.CheckedChanged
        If CheckBoxasr.Checked = True Then
            generator.asr(ComboBoxagent.SelectedIndex + 1) = True
        ElseIf CheckBoxasr.Checked = False Then
            generator.asr(ComboBoxagent.SelectedIndex + 1) = False
        End If
    End Sub

    Private Sub txtasr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtasr.TextChanged
        If IsNumeric(txtasr.Text) Then
            generator.asrtime(ComboBoxagent.SelectedIndex + 1) = txtasr.Text
        End If
    End Sub

    Private Sub txtasrenergy_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtasrenergy.TextChanged
        If IsNumeric(txtasrenergy.Text) Then
            generator.asrenergy(ComboBoxagent.SelectedIndex + 1) = txtasrenergy.Text
        End If
    End Sub

    Private Sub btnPosition_Click(sender As Object, e As EventArgs) Handles btnPosition.Click
        frmInitialProperties.Show()
    End Sub
End Class
