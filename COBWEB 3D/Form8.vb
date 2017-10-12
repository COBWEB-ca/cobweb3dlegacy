'allows the user to manually add agents (different from changing the initial count)
Public Class frmAdd
    Public newagents As Integer

    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i = 1 To Form1.agentTypeCount
            ComboBoxagent.Items.Add(generator.agentname(i))
        Next
        TextBox1.Text = 0
        TextBox2.Text = 0
        TextBox3.Text = 0
        TextBox4.Text = 0
        TextBox5.Text = 0
        TextBox6.Text = 0
        TextBox7.Text = 0
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text <> String.Empty Then
            If IsNumeric(TextBox1.Text) Then
                newagents = CInt(TextBox1.Text)
            Else
                MessageBox.Show("Please enter an integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox1.Clear()
                TextBox1.Focus()
            End If
        End If
    End Sub

    'adds new agents randomly in a range specified by the user
    Sub produce()
        If Form1.total + newagents <= generator.maxcell Then

            Dim agenttobeproduced(newagents) As Integer
            Dim rangexupper As Integer
            Dim rangexlower As Integer
            Dim rangeyupper As Integer
            Dim rangeylower As Integer
            Dim rangezupper As Integer
            Dim rangezlower As Integer

            For i = 1 To newagents
                agenttobeproduced(i) = ComboBoxagent.SelectedIndex + 1
            Next

            For i = 1 To newagents
                Form1.total = Form1.total + 1

                If IsNumeric(TextBox2.Text) = True And IsNumeric(TextBox3.Text) And IsNumeric(TextBox4.Text) And IsNumeric(TextBox5.Text) And IsNumeric(TextBox6.Text) And IsNumeric(TextBox7.Text) Then
                    rangexupper = CInt(TextBox2.Text)
                    rangexlower = CInt(TextBox3.Text)
                    rangeyupper = CInt(TextBox4.Text)
                    rangeylower = CInt(TextBox5.Text)
                    rangezupper = CInt(TextBox6.Text)
                    rangezlower = CInt(TextBox7.Text)
                    If newagents > (rangexupper - rangexlower + 1) * (rangeyupper - rangeylower + 1) * (rangezupper - rangezlower + 1) Then
                        MessageBox.Show("The number of new agents to be added exceeds the " & ((rangexupper - rangexlower + 1) * (rangeyupper - rangeylower + 1) * (rangezupper - rangezlower + 1)) & " spaces that are available. Please enter a smaller value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                Else
                    MessageBox.Show("Please enter integer values when specifying the range of an agent.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                'allows the user to add the new agent in a specific location
                If (rangexupper - rangexlower) = 0 And (rangeyupper - rangeylower) = 0 And (rangezupper - rangezlower) = 0 And generator.occupied(rangexupper, rangeyupper, rangezupper) = False Then
                    Dim ddx As Integer = CInt(Math.Floor((Form1.xn) * Rnd())) + 1
                    Dim ddy As Integer = CInt(Math.Floor((Form1.yn) * Rnd())) + 1
                    Dim ddz As Integer = CInt(Math.Floor((Form1.zn) * Rnd())) + 1

                    generator.agentlocation(Form1.total, 0) = rangexupper
                    generator.agentlocation(Form1.total, 1) = rangeyupper
                    generator.agentlocation(Form1.total, 2) = rangezupper
                    generator.agentlocation(Form1.total, 3) = CInt(Math.Floor((6) * Rnd())) + 1
                    generator.agentlocation(Form1.total, 4) = agenttobeproduced(i)
                    generator.agentlocation(Form1.total, 5) = ddx
                    generator.agentlocation(Form1.total, 6) = ddy
                    generator.agentlocation(Form1.total, 7) = ddz
                    generator.agentlocation(Form1.total, 8) = generator.initialenergy(agenttobeproduced(i))
                    generator.agentlocation(Form1.total, 9) = 0
                    generator.agentlocation(Form1.total, 10) = 0
                    generator.agentcount(agenttobeproduced(i)) = 0
                    For f = 1 To Form1.total
                        If generator.agentlocation(f, 4) = agenttobeproduced(i) Then
                            generator.agentcount(agenttobeproduced(i)) += 1
                        End If
                    Next

                    'placing the agents
                    generator.agentchange = True
                    Form1.draw()
                    Exit Sub
                ElseIf (rangexupper - rangexlower) = 0 And (rangeyupper - rangeylower) = 0 And (rangezupper - rangezlower) = 0 And generator.occupied(rangexupper, rangeyupper, rangezupper) = True Then
                    MessageBox.Show("The location where you want to insert the agent is occupied. Please enter another location.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If


                Dim x As Integer = CInt(Math.Floor((rangexupper - rangexlower + 1) * Rnd())) + rangexlower
                Dim y As Integer = CInt(Math.Floor((rangeyupper - rangeylower + 1) * Rnd())) + rangeylower
                Dim z As Integer = CInt(Math.Floor((rangezupper - rangezlower + 1) * Rnd())) + rangezlower
                Dim dx As Integer = CInt(Math.Floor((Form1.xn) * Rnd())) + 1
                Dim dy As Integer = CInt(Math.Floor((Form1.yn) * Rnd())) + 1
                Dim dz As Integer = CInt(Math.Floor((Form1.zn) * Rnd())) + 1

                Dim number As Integer = 0
                Do While generator.occupied(x, y, z) = True And number < generator.maxcell
                    number = number + 1
                    x = CInt(Math.Floor((rangexupper - rangexlower + 1) * Rnd())) + rangexlower
                    y = CInt(Math.Floor((rangeyupper - rangeylower + 1) * Rnd())) + rangeylower
                    z = CInt(Math.Floor((rangezupper - rangezlower + 1) * Rnd())) + rangezlower
                Loop


                generator.occupied(x, y, z) = True

                Dim d As Integer = CInt(Math.Floor((6) * Rnd())) + 1
                generator.agentlocation(Form1.total, 0) = x
                generator.agentlocation(Form1.total, 1) = y
                generator.agentlocation(Form1.total, 2) = z
                generator.agentlocation(Form1.total, 3) = d
                generator.agentlocation(Form1.total, 4) = agenttobeproduced(i)
                generator.agentlocation(Form1.total, 5) = dx
                generator.agentlocation(Form1.total, 6) = dy
                generator.agentlocation(Form1.total, 7) = dz
                generator.agentlocation(Form1.total, 8) = generator.initialenergy(agenttobeproduced(i))
                generator.agentlocation(Form1.total, 9) = 0
                generator.agentlocation(Form1.total, 10) = 0

                generator.agentcount(agenttobeproduced(i)) = 0
                For f = 1 To Form1.total
                    If generator.agentlocation(f, 4) = agenttobeproduced(i) Then
                        generator.agentcount(agenttobeproduced(i)) += 1
                    End If
                Next
            Next

            'placing the agents
            generator.agentchange = True
            Form1.draw()
        Else
            MessageBox.Show("The number of new agents exceeds the number of empty spaces available. Please enter a lower value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        generator.agentchange = True
        ' Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call produce()
    End Sub

    'sets default values for the range of new agents
    Private Sub ComboBoxagent_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxagent.SelectedIndexChanged
        TextBox2.Text = generator.agentrange(ComboBoxagent.SelectedIndex + 1, 0, 1)
        TextBox3.Text = generator.agentrange(ComboBoxagent.SelectedIndex + 1, 0, 0)
        TextBox4.Text = generator.agentrange(ComboBoxagent.SelectedIndex + 1, 1, 1)
        TextBox5.Text = generator.agentrange(ComboBoxagent.SelectedIndex + 1, 1, 0)
        TextBox6.Text = generator.agentrange(ComboBoxagent.SelectedIndex + 1, 2, 1)
        TextBox7.Text = generator.agentrange(ComboBoxagent.SelectedIndex + 1, 2, 0)
    End Sub
End Class
