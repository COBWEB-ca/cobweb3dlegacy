Public Class Genetics

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text <> "" Then
            chromosomelabel.Enabled = True
            chromosometext.Enabled = True
            ploidylabel.Enabled = True
            ploidycombo.Enabled = True
            plasmidlabel.Enabled = True
            plasmidtext.Enabled = True
            jumpinggenecheck.Enabled = True
            mutationcheck.Enabled = True
            crossovercheck.Enabled = True
        End If
    End Sub

    Private Sub Genetics_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For i = 1 To Form1.agent
            ComboBox1.Items.Add(generator.agentname(i))
        Next
    End Sub

    Private Sub chromosometext_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chromosometext.TextChanged
        If IsNumeric(chromosometext.Text) Then
            chromosomelabel2.Enabled = True
            chromosomecombo.Enabled = True
            TextBox7.Enabled = True
            TextBox6.Enabled = True
            Button5.Enabled = True
            Button6.Enabled = True
            Label16.Enabled = True
            Label14.Enabled = True
            chromosomecombo.Items.Clear()
            Dim chromosome As Integer = chromosometext.Text
            For i = 1 To chromosome
                chromosomecombo.Items.Add("chromosome" & i)
            Next
        ElseIf chromosometext.Text = "" Then
            chromosomelabel2.Enabled = False
            chromosomecombo.Enabled = False
            TextBox7.Enabled = False
            TextBox6.Enabled = False
            Button5.Enabled = False
            Button6.Enabled = False
            Label16.Enabled = False
            Label14.Enabled = False
        Else
            MsgBox("Please enter numbers only")
            chromosometext.Text = ""
        End If
    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        If IsNumeric(TextBox6.Text) Then
            If CInt(TextBox6.Text) > 0 Then
                ComboBox3.Enabled = True
                TextBox9.Enabled = True
                For i = 1 To CInt(TextBox6.Text)
                    ComboBox3.Items.Add("Gene " & i)
                Next
            Else
                ComboBox3.Enabled = False
                TextBox9.Enabled = False
            End If
        Else
            ComboBox3.Enabled = False
            TextBox9.Enabled = False
        End If
    End Sub
End Class
