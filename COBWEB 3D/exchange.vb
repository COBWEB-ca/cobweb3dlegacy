Public Class frmexchange
    Private Sub exchange_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GroupBox2.Text = generator.agentname(Form5.holdera) & " Initial Properties"
        GroupBox3.Text = generator.agentname(Form5.holderb) & " Initial Properties"

        ComboBox1.Items.Add(generator.agentname(Form5.holdera))
        ComboBox1.Items.Add(generator.agentname(Form5.holderb))

        If generator.product(Form5.holdera, Form5.holderb, 16) <> "" Then
            TextBox1.Text = generator.product(Form5.holdera, Form5.holderb, 16)
        Else
            TextBox1.Text = 0
        End If

        If generator.product(Form5.holdera, Form5.holderb, 14) <> "" Then
            TextBox2.Text = generator.product(Form5.holdera, Form5.holderb, 14)
        Else
            TextBox2.Text = 0
        End If

        If generator.product(Form5.holdera, Form5.holderb, 15) <> "" Then
            TextBox5.Text = generator.product(Form5.holdera, Form5.holderb, 15)
        Else
            TextBox5.Text = 0
        End If

        If generator.product(Form5.holdera, Form5.holderb, 12) <> "" Then
            TextBox11.Text = generator.product(Form5.holdera, Form5.holderb, 12)
        Else
            TextBox11.Text = 0
        End If

        If generator.product(Form5.holdera, Form5.holderb, 11) <> "" Then
            TextBox12.Text = generator.product(Form5.holdera, Form5.holderb, 16)
        Else
            TextBox12.Text = 0
        End If
    End Sub

    'assigns agents as buyers or seller and calculates the initial utiity 
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If IsNumeric(TextBox3.Text) = False Or IsNumeric(TextBox4.Text) = False Or IsNumeric(TextBox7.Text) = False Or IsNumeric(TextBox8.Text) = False Or IsNumeric(TextBox11.Text) = False Or IsNumeric(TextBox12.Text) = False Then
            MessageBox.Show("Please enter numerical values only.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        For i = 1 To Form1.total
            If generator.agentlocation(i, 4) = Form5.holdera Then
                generator.agentlocation(i, 11) = CDec(TextBox3.Text)
                generator.agentlocation(i, 12) = CDec(TextBox4.Text)
                generator.agentlocation(i, 17) = 1
            End If
            If generator.agentlocation(i, 4) = Form5.holderb Then
                generator.agentlocation(i, 11) = CDec(TextBox7.Text)
                generator.agentlocation(i, 12) = CDec(TextBox8.Text)
                generator.agentlocation(i, 17) = 1
            End If
        Next

        For i = 1 To Form1.total
            If generator.agentlocation(i, 11) <> 0 And generator.agentlocation(i, 12) <> 0 Then
                If generator.agentlocation(i, 13) = 1 Then 'sqrt(xy)
                    generator.agentlocation(i, 14) = Math.Sqrt((generator.agentlocation(i, 11)) * (generator.agentlocation(i, 12)))
                ElseIf generator.agentlocation(i, 13) = 2 Then 'second utility function U = (C^0.5)*(P^0.5)
                    generator.agentlocation(i, 14) = ((generator.agentlocation(i, 11)) ^ generator.agentlocation(i, 15)) * ((generator.agentlocation(i, 12)) ^ generator.agentlocation(i, 16))
                ElseIf generator.agentlocation(i, 13) = 3 Then 'third utility function
                    generator.agentlocation(i, 14) = (generator.agentlocation(i, 15) * ((generator.agentlocation(i, 11) + (1 * generator.agentlocation(i, 17))))) + (generator.agentlocation(i, 16) * ((generator.agentlocation(i, 12) + (1 * generator.agentlocation(i, 17) * -1))))
                ElseIf generator.agentlocation(i, 13) = 4 Then 'min(x,y)
                    generator.agentlocation(i, 14) = Math.Min((generator.agentlocation(i, 11) + (1 * generator.agentlocation(i, 17))), (generator.agentlocation(i, 12) + (1 * generator.agentlocation(i, 17) * -1)))
                End If
            End If
        Next

        generator.product(Form5.holdera, Form5.holderb, 11) = CDec(TextBox12.Text)
        generator.product(Form5.holdera, Form5.holderb, 12) = CDec(TextBox11.Text)
        generator.product(Form5.holdera, Form5.holderb, 16) = CInt(TextBox1.Text)
        generator.product(Form5.holdera, Form5.holderb, 14) = CInt(TextBox2.Text)
        generator.product(Form5.holdera, Form5.holderb, 15) = CInt(TextBox5.Text)

        Form5.Show()
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        utility.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            generator.product(Form5.holdera, Form5.holderb, 13) = 2
        ElseIf checkbox1.checked = False Then
            generator.product(Form5.holdera, Form5.holderb, 13) = 0
        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If IsNumeric(TextBox2.Text) Then
            generator.product(Form5.holdera, Form5.holderb, 14) = CInt(TextBox2.Text)
        End If
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        If IsNumeric(TextBox5.Text) Then
            generator.product(Form5.holdera, Form5.holderb, 15) = CInt(TextBox5.Text)
        End If
    End Sub

    Private Sub TextBox11_TextChanged(sender As Object, e As EventArgs) Handles TextBox11.TextChanged
        TextBox1.Text = TextBox11.Text
        TextBox2.Text = CInt(TextBox11.Text) + 10
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If IsNumeric(TextBox1.Text) Then
            generator.product(Form5.holdera, Form5.holderb, 16) = CInt(TextBox1.Text)
        End If
    End Sub
End Class
