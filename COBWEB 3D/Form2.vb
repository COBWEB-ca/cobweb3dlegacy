Public Class Form2

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form1.xn = TextBox1.Text
        Form1.yn = TextBox2.Text
        Form1.zn = TextBox3.Text
        Form1.agentTypeCount = TextBox4.Text

        Form1.RenderingEngine.onWorldSizeChanged(Form1.xn, Form1.yn, Form1.zn)

        generator.Close()
        generator.Show()

        For i = 1 To Form1.agentTypeCount
            For j = 1 To Form1.agentTypeCount
                generator.interactionprobability(i, j) = 100
            Next
        Next

        Form1.SizeToolStripMenuItem.Enabled = True
        Form1.AIToolStripMenuItem.Enabled = True
        Form1.collisionToolStripMenuItem.Enabled = True
        Form1.AddAgentsToolStripMenuItem.Enabled = True
        Form1.CatalysisToolStripMenuItem.Enabled = True
        Form1.AbioticFactorsToolStripMenuItem.Enabled = True
        Form1.GeneticsToolStripMenuItem.Enabled = True

        Me.Close()
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub TextBox5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'If IsNumeric(chromosometext.Text) Then
        'chromosomelabel2.Enabled = True
        'chromosomecombo.Enabled = True
        'chromosomecombo.Items.Clear()
        'Dim chromosome As Integer = chromosometext.Text
        'For i = 1 To chromosome
        'chromosomecombo.Items.Add("chromosome" & i)
        'Next
        'ElseIf chromosometext.Text = "" Then
        'chromosomelabel2.Enabled = False
        'chromosomecombo.Enabled = False
        ' Else
        'MsgBox("Please enter numbers only")
        'chromosometext.Text = ""
        'End If

    End Sub

    Private Sub TabPage1_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TabPage3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextBox5_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ComboBox8_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If ComboBox8.Text <> "" Then
        'TextBox5.Enabled = True
        'End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class
