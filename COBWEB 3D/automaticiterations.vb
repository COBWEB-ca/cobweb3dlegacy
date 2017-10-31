Public Class automaticiterations
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub automaticiterations_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i = 1 To Form1.agentTypeCount
            ComboBox1.Items.Add(generator.agentname(i))
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If IsNumeric(TextBox1.Text) And IsNumeric(TextBox3.Text) Then
            If CInt(TextBox1.Text) > 0 Then
                generator.multipleiterations(0) = CInt(TextBox1.Text)
                generator.multipleiterations(1) = 2
            End If
        Else
            MessageBox.Show("Please enter numerical values only.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        'Dim result As Integer = MessageBox.Show("Do you want to save data for each iteration?", "Save Data", MessageBoxButtons.YesNoCancel)
        'If result = DialogResult.Yes Then

        'ElseIf result = DialogResult.No Then

        'End If
        Me.Close()
    End Sub
End Class
