Public Class Form2

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form1.xn = TextBox1.Text
        Form1.yn = TextBox2.Text
        Form1.zn = TextBox3.Text
        Form1.agent = TextBox4.Text

        Dim ratio1 As Single = Form1.yn / Form1.xn
        Dim ratio2 As Single = Form1.zn / Form1.xn
        Dim ratio3 As Single = Form1.yn / Form1.zn
        Dim res As Integer = 2073600

        Form1.sizexyx = (res / ratio1) ^ 0.5
        Form1.sizexyy = ratio1 * Form1.sizexyx

        Form1.sizexzx = (res / ratio2) ^ 0.5
        Form1.sizexzz = ratio2 * Form1.sizexzx

        Form1.sizezyz = (res / ratio3) ^ 0.5
        Form1.sizezyy = ratio3 * Form1.sizezyz


        Form1.cellxyx = Form1.sizexyx / Form1.xn
        Form1.cellxyy = Form1.sizexyy / Form1.yn

        Form1.cellxzx = Form1.sizexzx / Form1.xn
        Form1.cellxzz = Form1.sizexzz / Form1.zn

        Form1.cellzyz = Form1.sizezyz / Form1.zn
        Form1.cellzyy = Form1.sizezyy / Form1.yn


        generator.Close()
        generator.Show()

        For i = 1 To Form1.agent
            For j = 1 To Form1.agent
                generator.interactionprobability(i, j) = 100
            Next
        Next

        Form1.SizeToolStripMenuItem.Enabled = True
        Form1.AIToolStripMenuItem.Enabled = True
        Form1.collisionToolStripMenuItem.Enabled = True
        Form1.AddAgentsToolStripMenuItem.Enabled = True
        Form1.CatalysisToolStripMenuItem.Enabled = True
        Form1.AbioticFactorsToolStripMenuItem.Enabled = True
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
