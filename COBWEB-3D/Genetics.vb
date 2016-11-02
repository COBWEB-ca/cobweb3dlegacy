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
            chromosomecombo.Items.Clear()
            Dim chromosome As Integer = chromosometext.Text
            For i = 1 To chromosome
                chromosomecombo.Items.Add("chromosome" & i)
            Next
        ElseIf chromosometext.Text = "" Then
            chromosomelabel2.Enabled = False
            chromosomecombo.Enabled = False
        Else
            MsgBox("Please enter numbers only")
            chromosometext.Text = ""
        End If
    End Sub
End Class