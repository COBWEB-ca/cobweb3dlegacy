Public Class utility
    Private Sub utility_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim interaction(1) As Integer

        For i = 1 To Form1.total
            If generator.agentlocation(i, 4) = Form5.holdera And frmexchange.ComboBox1.SelectedIndex = 0 Then
                interaction(0) = generator.agentlocation(i, 13)
                interaction(1) = i
                Exit For
            ElseIf generator.agentlocation(i, 4) = Form5.holderb And frmexchange.ComboBox1.SelectedIndex = 1 Then
                interaction(0) = generator.agentlocation(i, 13)
                interaction(1) = i
                Exit For
            End If
        Next

        If interaction(0) = 1 Then
            RadioButton1.Checked = True
        ElseIf interaction(0) = 2 Then
            RadioButton2.Checked = True
            TextBox1.Text = generator.agentlocation(interaction(1), 15)
            TextBox2.Text = generator.agentlocation(interaction(1), 16)
        ElseIf interaction(0) = 3 Then
            RadioButton5.Checked = True
            TextBox6.Text = generator.agentlocation(interaction(1), 15)
            TextBox5.Text = generator.agentlocation(interaction(1), 16)
        ElseIf interaction(0) = 4 Then
            RadioButton3.Checked = True
        ElseIf interaction(0) = 5 Then
            RadioButton4.Checked = True
        ElseIf interaction(0) = -1 Then
            RadioButton6.Checked = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If IsNumeric(TextBox1.Text) = False Or IsNumeric(TextBox2.Text) = False Or IsNumeric(TextBox5.Text) = False Or IsNumeric(TextBox6.Text) = False Then
            MessageBox.Show("Please enter numerical values only.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim holder = 0
        If frmexchange.ComboBox1.SelectedIndex = 0 Then
            holder = Form5.holdera
        ElseIf frmexchange.ComboBox1.SelectedIndex = 1 Then
            holder = Form5.holderb
        End If

        For i = 1 To Form1.total
            If generator.agentlocation(i, 4) = holder Then
                If RadioButton1.Checked = True Then
                    generator.agentlocation(i, 13) = 1 'Sqrt(XY) - agentlocation(i, 13) represents the index of the utility function being used.
                ElseIf RadioButton2.Checked = True Then
                    generator.agentlocation(i, 13) = 2 'X^a * Y^b
                    generator.agentlocation(i, 15) = CDec(TextBox1.Text)
                    generator.agentlocation(i, 16) = CDec(TextBox2.Text)
                ElseIf RadioButton5.Checked = True Then
                    generator.agentlocation(i, 13) = 3 'aX + bY
                    generator.agentlocation(i, 15) = CDec(TextBox6.Text)
                    generator.agentlocation(i, 16) = CDec(TextBox5.Text)
                ElseIf RadioButton3.Checked = True Then
                    generator.agentlocation(i, 13) = 4 'Min(X, Y)
                End If
            End If
        Next


        'If frmexchange.ComboBox1.SelectedIndex = 0 Then
        '    For i = 1 To Form1.total
        '        If generator.agentlocation(i, 4) = Form5.holdera Then
        '            If RadioButton1.Checked = True Then
        '                generator.agentlocation(i, 13) = 1 'sqrt(xy)
        '            ElseIf RadioButton2.Checked = True Then
        '                generator.agentlocation(i, 13) = 2
        '                generator.agentlocation(i, 15) = CDec(TextBox1.Text)
        '                generator.agentlocation(i, 16) = CDec(TextBox2.Text)
        '            ElseIf RadioButton5.Checked = True Then
        '                generator.agentlocation(i, 13) = 3
        '                generator.agentlocation(i, 15) = CDec(TextBox6.Text)
        '                generator.agentlocation(i, 16) = CDec(TextBox5.Text)
        '            ElseIf RadioButton3.Checked = True Then
        '                generator.agentlocation(i, 13) = 4
        '            End If
        '        End If
        '    Next
        'ElseIf frmexchange.ComboBox1.SelectedIndex = 1 Then
        '    For i = 1 To Form1.total
        '        If generator.agentlocation(i, 4) = Form5.holderb Then
        '            If RadioButton1.Checked = True Then
        '                generator.agentlocation(i, 13) = 1 'sqrt(xy)
        '            ElseIf RadioButton2.Checked = True Then
        '                generator.agentlocation(i, 13) = 2
        '                generator.agentlocation(i, 15) = CDec(TextBox1.Text)
        '                generator.agentlocation(i, 16) = CDec(TextBox2.Text)
        '            ElseIf RadioButton5.Checked = True Then
        '                generator.agentlocation(i, 13) = 3
        '                generator.agentlocation(i, 15) = CDec(TextBox6.Text)
        '                generator.agentlocation(i, 16) = CDec(TextBox5.Text)
        '            ElseIf RadioButton3.Checked = True Then
        '                generator.agentlocation(i, 13) = 4
        '            End If
        '        End If
        '    Next
        'End If

        Me.Close()
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            generator.product(Form5.holdera, Form5.holderb, 3) = 1
            RadioButton2.Checked = False
            RadioButton3.Checked = False
            RadioButton4.Checked = False
            RadioButton5.Checked = False
            RadioButton6.Checked = False
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            If IsNumeric(TextBox1.Text) And IsNumeric(TextBox2.Text) Then
                generator.product(Form5.holdera, Form5.holderb, 3) = 2
                generator.product(Form5.holdera, Form5.holderb, 4) = CDec(TextBox1.Text) 'the value of constant a
                generator.product(Form5.holdera, Form5.holderb, 5) = CDec(TextBox2.Text) 'the value of constant b
                RadioButton1.Checked = False
                RadioButton3.Checked = False
                RadioButton4.Checked = False
                RadioButton5.Checked = False
                RadioButton6.Checked = False
            End If
        End If
    End Sub

    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged
        If RadioButton5.Checked = True Then
            If IsNumeric(TextBox5.Text) And IsNumeric(TextBox6.Text) Then
                generator.product(Form5.holdera, Form5.holderb, 3) = 3 'the type of equation
                generator.product(Form5.holdera, Form5.holderb, 4) = CDec(TextBox5.Text) 'the value of constant a
                generator.product(Form5.holdera, Form5.holderb, 5) = CDec(TextBox6.Text) 'the value of constant b
                RadioButton2.Checked = False
                RadioButton3.Checked = False
                RadioButton4.Checked = False
                RadioButton1.Checked = False
                RadioButton6.Checked = False
            End If
        End If
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        If RadioButton3.Checked = True Then
            generator.product(Form5.holdera, Form5.holderb, 3) = 4
            RadioButton2.Checked = False
            RadioButton1.Checked = False
            RadioButton4.Checked = False
            RadioButton5.Checked = False
            RadioButton6.Checked = False
        End If
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        If RadioButton4.Checked = True Then
            generator.product(Form5.holdera, Form5.holderb, 3) = 5
            RadioButton2.Checked = False
            RadioButton3.Checked = False
            RadioButton1.Checked = False
            RadioButton5.Checked = False
            RadioButton6.Checked = False
        End If
    End Sub

    Private Sub RadioButton6_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton6.CheckedChanged
        If RadioButton6.Checked = True Then
            generator.product(Form5.holdera, Form5.holderb, 3) = -1 'signifies no utility function; agents exchange products regardless of utility
            RadioButton2.Checked = False
            RadioButton3.Checked = False
            RadioButton1.Checked = False
            RadioButton5.Checked = False
            RadioButton4.Checked = False
        End If
    End Sub
End Class
