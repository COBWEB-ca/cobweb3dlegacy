Public Class Form9

    Private listing(Form1.agent) As Integer

    Private Sub Form9_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim count As Integer
        For i = 1 To Form1.agent
            If generator.localreproduction(Form5.holdera, Form5.holderb, i, 0) <> 0 Then
                count += 1
                ComboBox1.Items.Add(generator.agentname(i))
                listing(count) = i
            End If
        Next
        TextBox1.Text = 0
        TextBox2.Text = 0
        TextBox3.Text = 0
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        TextBox1.Text = generator.localreproduction(Form5.holdera, Form5.holderb, listing(ComboBox1.SelectedIndex + 1), 1)
        TextBox2.Text = generator.localreproduction(Form5.holdera, Form5.holderb, listing(ComboBox1.SelectedIndex + 1), 2)
        TextBox3.Text = generator.localreproduction(Form5.holdera, Form5.holderb, listing(ComboBox1.SelectedIndex + 1), 3)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If IsNumeric(TextBox1.Text) Then
            generator.localreproduction(Form5.holdera, Form5.holderb, listing(ComboBox1.SelectedIndex + 1), 1) = CInt(TextBox1.Text)
        Else
            MessageBox.Show("Please enter integer values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If IsNumeric(TextBox2.Text) Then
            generator.localreproduction(Form5.holdera, Form5.holderb, listing(ComboBox1.SelectedIndex + 1), 2) = CInt(TextBox2.Text)
        Else
            MessageBox.Show("Please enter integer values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        If IsNumeric(TextBox3.Text) Then
            generator.localreproduction(Form5.holdera, Form5.holderb, listing(ComboBox1.SelectedIndex + 1), 3) = CInt(TextBox3.Text)
        Else
            MessageBox.Show("Please enter integer values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class
