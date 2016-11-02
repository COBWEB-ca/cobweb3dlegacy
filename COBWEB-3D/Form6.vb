Public Class productions

    Private Sub Form6_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        For i = 1 To Form1.agent
            ComboBox1.Items.Add(generator.agentname(i))
        Next

        Call listviewclear()
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NumericUpDown1.ValueChanged
        generator.action(Form5.holdera, Form5.holderb, 2, ComboBox1.SelectedIndex + 1, 1) = NumericUpDown1.Value
        generator.localreproduction(Form5.holdera, Form5.holderb, ComboBox1.SelectedIndex + 1, 0) = NumericUpDown1.Value
        generator.localreproduction(Form5.holdera, Form5.holderb, ComboBox1.SelectedIndex + 1, 1) = Form1.xn
        generator.localreproduction(Form5.holdera, Form5.holderb, ComboBox1.SelectedIndex + 1, 2) = Form1.yn
        generator.localreproduction(Form5.holdera, Form5.holderb, ComboBox1.SelectedIndex + 1, 3) = Form1.zn
        Call listviewclear()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        NumericUpDown1.Value = generator.action(Form5.holdera, Form5.holderb, 2, ComboBox1.SelectedIndex + 1, 1)
        Call listviewclear()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Form5.Activate()
        ListView1.Clear()
        Me.Close()
    End Sub

    Sub listviewclear()
        ListView1.Clear()
        ListView1.Columns.Add("Agent to be Produced", 225)
        ListView1.Columns.Add("Number of Agents to be Produced", 225)
        ListView1.GridLines = True
        For i = 1 To Form1.agent
            If generator.action(Form5.holdera, Form5.holderb, 2, i, 1) <> 0 Then
                Dim agentproduction As New ListViewItem
                agentproduction.SubItems.Add(generator.action(Form5.holdera, Form5.holderb, 2, i, 1))
                agentproduction.SubItems(0).Text = generator.agentname(i)
                ListView1.Items.Add(agentproduction)
            End If
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form9.Show()
    End Sub
End Class
