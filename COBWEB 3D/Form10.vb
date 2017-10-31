Public Class Form10
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Form10_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i = 1 To Form1.agentTypeCount
            ComboBox1.Items.Add(generator.agentname(i))
        Next
        ListView1.View = View.Details
        Call listviewclear()
        TextBox1.Text = 0
        TextBox2.Text = 1
        TextBox3.Text = 1
        TextBox4.Text = 1
        TextBox5.Text = 0
    End Sub

    Sub listviewclear()
        ListView1.Clear()
        ListView1.Columns.Add("Agent to be Produced", 225)
        ListView1.Columns.Add("Number of Agents to be Produced per Tick", 225)
        ListView1.Columns.Add("Per Agent Decrease in Reservoir Value")
        ListView1.Columns.Add("X Distance")
        ListView1.Columns.Add("Y Distace")
        ListView1.Columns.Add("Z Distance")
        ListView1.GridLines = True

        For i = 1 To Form1.agentTypeCount
            If generator.reservoiragentreleased(Form5.holderb, i, 1) <> 0 Then
                Dim listentry As New ListViewItem
                listentry.SubItems.Add(generator.reservoiragentreleased(Form5.holderb, i, 1))
                listentry.SubItems.Add(generator.reservoiragentreleased(Form5.holderb, i, 2))
                listentry.SubItems.Add(generator.reservoiragentreleased(Form5.holderb, i, 3))
                listentry.SubItems.Add(generator.reservoiragentreleased(Form5.holderb, i, 4))
                listentry.SubItems.Add(generator.reservoiragentreleased(Form5.holderb, i, 5))
                listentry.SubItems(0).Text = generator.agentname(i)
                ListView1.Items.Add(listentry)
            End If
        Next
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Call listviewclear()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If IsNumeric(TextBox1.Text) And IsNumeric(TextBox2.Text) And IsNumeric(TextBox3.Text) And IsNumeric(TextBox4.Text) And IsNumeric(TextBox5.Text) Then
            generator.reservoiragentreleased(Form5.holderb, ComboBox1.SelectedIndex + 1, 1) = CDec(TextBox5.Text)
            generator.reservoiragentreleased(Form5.holderb, ComboBox1.SelectedIndex + 1, 2) = CDec(TextBox1.Text)
            generator.reservoiragentreleased(Form5.holderb, ComboBox1.SelectedIndex + 1, 3) = CDec(TextBox4.Text)
            generator.reservoiragentreleased(Form5.holderb, ComboBox1.SelectedIndex + 1, 4) = CDec(TextBox2.Text)
            generator.reservoiragentreleased(Form5.holderb, ComboBox1.SelectedIndex + 1, 5) = CDec(TextBox3.Text)
            generator.reservoiragentreleased(Form5.holderb, ComboBox1.SelectedIndex + 1, 6) = Form5.holdera
            generator.reservoiragentreleased(Form5.holderb, ComboBox1.SelectedIndex + 1, 7) = Form5.holderb
            Call listviewclear()
        Else
            MessageBox.Show("Please enter numerical values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
    End Sub
End Class
