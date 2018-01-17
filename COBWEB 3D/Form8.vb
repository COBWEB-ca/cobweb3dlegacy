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

            Dim newAgentType = ComboBoxagent.SelectedIndex + 1
            Dim rangexupper As Integer
            Dim rangexlower As Integer
            Dim rangeyupper As Integer
            Dim rangeylower As Integer
            Dim rangezupper As Integer
            Dim rangezlower As Integer

            For i = 1 To newagents
                'Form1.total = Form1.total + 1

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

                ' If the entered boundary is one cell, simply add one agent to the point if there is room and exit.
                If (rangexupper - rangexlower) = 0 And (rangeyupper - rangeylower) = 0 And (rangezupper - rangezlower) = 0 Then
                    If generator.occupied(rangexupper, rangeyupper, rangezupper) = True Then
                        MessageBox.Show("The location where you want to insert the agent is occupied. Please enter another location.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else
                        Dim ddx As Integer = CInt(Math.Floor((Form1.xn) * Rnd())) + 1
                        Dim ddy As Integer = CInt(Math.Floor((Form1.yn) * Rnd())) + 1
                        Dim ddz As Integer = CInt(Math.Floor((Form1.zn) * Rnd())) + 1
                        generator.createAgent(newAgentType, rangexupper, rangeyupper, rangezupper, CInt(Math.Floor((6) * Rnd())) + 1, ddx, ddy, ddz)
                        Form1.draw()
                    End If
                    Exit Sub
                End If

                Dim x As Integer = CInt(Math.Floor((rangexupper - rangexlower + 1) * Rnd())) + rangexlower
                Dim y As Integer = CInt(Math.Floor((rangeyupper - rangeylower + 1) * Rnd())) + rangeylower
                Dim z As Integer = CInt(Math.Floor((rangezupper - rangezlower + 1) * Rnd())) + rangezlower
                Dim dx As Integer = CInt(Math.Floor((Form1.xn) * Rnd())) + 1
                Dim dy As Integer = CInt(Math.Floor((Form1.yn) * Rnd())) + 1
                Dim dz As Integer = CInt(Math.Floor((Form1.zn) * Rnd())) + 1

                ' Search for a non-occupied cell if (x, y, z) is occupied.
                Dim number As Integer = 0
                Do While generator.occupied(x, y, z) = True And number < generator.maxcell
                    number = number + 1
                    x = CInt(Math.Floor((rangexupper - rangexlower + 1) * Rnd())) + rangexlower
                    y = CInt(Math.Floor((rangeyupper - rangeylower + 1) * Rnd())) + rangeylower
                    z = CInt(Math.Floor((rangezupper - rangezlower + 1) * Rnd())) + rangezlower
                Loop
                generator.createAgent(newAgentType, x, y, z, CInt(Math.Floor((6) * Rnd())) + 1, dx, dy, dz)
            Next
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
