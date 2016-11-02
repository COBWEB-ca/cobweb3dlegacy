Public Class frmInitialProperties
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If IsNumeric(TextBox2.Text) And IsNumeric(TextBox3.Text) And IsNumeric(TextBox4.Text) And IsNumeric(TextBox5.Text) And IsNumeric(TextBox6.Text) And IsNumeric(TextBox7.Text) Then
            If (CInt(TextBox2.Text) - CInt(TextBox3.Text)) < 0 Or (CInt(TextBox4.Text) - CInt(TextBox5.Text)) < 0 Or (CInt(TextBox6.Text) - CInt(TextBox7.Text)) < 0 Then
                MessageBox.Show("The different between the upper and lower bounds for x, y and z must be positive.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If RadioButton1.Checked = True Then
                generator.agentdirection(Form3.selectedagent) = 2
            ElseIf RadioButton2.Checked = True Then
                generator.agentdirection(Form3.selectedagent) = 1
            ElseIf RadioButton3.Checked = True Then
                generator.agentdirection(Form3.selectedagent) = 3
            ElseIf RadioButton4.Checked = True Then
                generator.agentdirection(Form3.selectedagent) = 4
            ElseIf RadioButton5.Checked = True Then
                generator.agentdirection(Form3.selectedagent) = 6
            ElseIf RadioButton6.Checked = True Then
                generator.agentdirection(Form3.selectedagent) = 5
            ElseIf RadioButton7.Checked = True Then
                generator.agentdirection(Form3.selectedagent) = 0
            End If
            If TextBox3.Text <> 1 Or TextBox5.Text <> 1 Or TextBox7.Text <> 1 Or TextBox2.Text <> Form1.xn Or TextBox4.Text <> Form1.yn Or TextBox6.Text <> Form1.zn Then
                generator.agentstart(Form3.selectedagent, 1) = CInt(TextBox2.Text)
                generator.agentstart(Form3.selectedagent, 2) = CInt(TextBox3.Text)
                generator.agentstart(Form3.selectedagent, 3) = CInt(TextBox4.Text)
                generator.agentstart(Form3.selectedagent, 4) = CInt(TextBox5.Text)
                generator.agentstart(Form3.selectedagent, 5) = CInt(TextBox6.Text)
                generator.agentstart(Form3.selectedagent, 6) = CInt(TextBox7.Text)
                generator.agentstart(Form3.selectedagent, 0) = 2
            Else
                generator.agentstart(Form3.selectedagent, 0) = 0
            End If
        Else
            MessageBox.Show("Please enter integer values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Me.Close()
    End Sub

    Private Sub frmInitialProperties_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RadioButton7.Checked = True
        TextBox3.Text = 1
        TextBox5.Text = 1
        TextBox7.Text = 1
        TextBox2.Text = Form1.xn
        TextBox4.Text = Form1.yn
        TextBox6.Text = Form1.zn
    End Sub
End Class
