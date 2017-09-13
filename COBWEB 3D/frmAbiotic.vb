Public Class frmAbiotic

    Private Sub frmAbiotic_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i = 1 To Form1.agentTypeCount
            ComboBoxagent.Items.Add(generator.agentname(i))
        Next
        TextBox1.Text = 1
        TextBox3.Text = 1
        TextBox5.Text = 1
        TextBox2.Text = Form1.xn
        TextBox4.Text = Form1.yn
        TextBox6.Text = Form1.zn
        TextBox7.Text = 0
        TextBox8.Text = 0
        ListView1.Columns.Add("Region")
        ListView1.Columns.Add("Agent")
        ListView1.Columns.Add("X Lower Bound")
        ListView1.Columns.Add("X Upper Bound")
        ListView1.Columns.Add("Y Lower Bound")
        ListView1.Columns.Add("Y Upper Bound")
        ListView1.Columns.Add("Z Lower Bound")
        ListView1.Columns.Add("Z Upper Bound")
        ListView1.Columns.Add("Energy Change ")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If IsNumeric(TextBox1.Text) And IsNumeric(TextBox2.Text) And IsNumeric(TextBox3.Text) And IsNumeric(TextBox4.Text) And IsNumeric(TextBox5.Text) And IsNumeric(TextBox6.Text) And IsNumeric(TextBox7.Text) Then
            If CInt(TextBox2.Text) < CInt(TextBox1.Text) Or CInt(TextBox4.Text) < CInt(TextBox3.Text) Or CInt(TextBox6.Text) < CInt(TextBox5.Text) Then
                MessageBox.Show("The upper bound must be greater than the lower bound.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            ElseIf CInt(TextBox2.Text) > Form1.xn Or CInt(TextBox4.Text) > Form1.yn Or CInt(TextBox6.Text) > Form1.zn Then
                MessageBox.Show("The upper bound must be smaller than or equal to the dimensions of the 3D grid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            For count = 1 To 1000
                If generator.localenergychange(ComboBoxagent.SelectedIndex + 1, count, 0) = 0 Then
                    If overlapcheck() = False Then
                        generator.localenergychange(ComboBoxagent.SelectedIndex + 1, count, 1) = CInt(TextBox2.Text)
                        generator.localenergychange(ComboBoxagent.SelectedIndex + 1, count, 2) = CInt(TextBox1.Text)
                        generator.localenergychange(ComboBoxagent.SelectedIndex + 1, count, 3) = CInt(TextBox4.Text)
                        generator.localenergychange(ComboBoxagent.SelectedIndex + 1, count, 4) = CInt(TextBox3.Text)
                        generator.localenergychange(ComboBoxagent.SelectedIndex + 1, count, 5) = CInt(TextBox6.Text)
                        generator.localenergychange(ComboBoxagent.SelectedIndex + 1, count, 6) = CInt(TextBox5.Text)
                        generator.localenergychange(ComboBoxagent.SelectedIndex + 1, count, 7) = CInt(TextBox7.Text)
                        generator.localenergychange(ComboBoxagent.SelectedIndex + 1, count, 0) = 2
                        Exit For
                    Else
                        MessageBox.Show("Local regions cannot overlap. Please specify a new area.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End If
            Next
            Call listviewitems()
        Else
            MessageBox.Show("Please enter integer values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub ComboBoxagent_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxagent.SelectedIndexChanged
        Call listviewitems()
        TextBox8.Text = generator.stepenergy(ComboBoxagent.SelectedIndex + 1)
    End Sub

    Private Sub listviewitems()
        ListView1.Clear()
        ListView1.Columns.Add("Region")
        ListView1.Columns.Add("Agent")
        ListView1.Columns.Add("X Lower Bound")
        ListView1.Columns.Add("X Upper Bound")
        ListView1.Columns.Add("Y Lower Bound")
        ListView1.Columns.Add("Y Upper Bound")
        ListView1.Columns.Add("Z Lower Bound")
        ListView1.Columns.Add("Z Upper Bound")
        ListView1.Columns.Add("Energy Change ")

        For a = 1 To 1000
            If generator.localenergychange(ComboBoxagent.SelectedIndex + 1, a, 0) = 2 Then
                Dim listentry As New ListViewItem
                listentry.SubItems.Add(generator.agentname(ComboBoxagent.SelectedIndex + 1))
                listentry.SubItems.Add(generator.localenergychange(ComboBoxagent.SelectedIndex + 1, a, 2))
                listentry.SubItems.Add(generator.localenergychange(ComboBoxagent.SelectedIndex + 1, a, 1))
                listentry.SubItems.Add(generator.localenergychange(ComboBoxagent.SelectedIndex + 1, a, 4))
                listentry.SubItems.Add(generator.localenergychange(ComboBoxagent.SelectedIndex + 1, a, 3))
                listentry.SubItems.Add(generator.localenergychange(ComboBoxagent.SelectedIndex + 1, a, 6))
                listentry.SubItems.Add(generator.localenergychange(ComboBoxagent.SelectedIndex + 1, a, 5))
                listentry.SubItems.Add(generator.localenergychange(ComboBoxagent.SelectedIndex + 1, a, 7))
                listentry.SubItems(0).Text = a.ToString
                ListView1.Items.Add(listentry)
            End If
        Next
    End Sub

    Function overlapcheck() As Boolean
        For i = 1 To 1000
            If generator.localenergychange(ComboBoxagent.SelectedIndex + 1, i, 0) = 2 Then
                If generator.localenergychange(ComboBoxagent.SelectedIndex + 1, i, 1) <= CInt(TextBox2.Text) And generator.localenergychange(ComboBoxagent.SelectedIndex + 1, i, 1) >= CInt(TextBox1.Text) Or generator.localenergychange(ComboBoxagent.SelectedIndex + 1, i, 2) >= CInt(TextBox1.Text) And generator.localenergychange(ComboBoxagent.SelectedIndex + 1, i, 2) <= CInt(TextBox2.Text) Then
                    If generator.localenergychange(ComboBoxagent.SelectedIndex + 1, i, 3) <= CInt(TextBox4.Text) And generator.localenergychange(ComboBoxagent.SelectedIndex + 1, i, 3) >= CInt(TextBox3.Text) Or generator.localenergychange(ComboBoxagent.SelectedIndex + 1, i, 4) >= CInt(TextBox3.Text) And generator.localenergychange(ComboBoxagent.SelectedIndex + 1, i, 4) <= CInt(TextBox4.Text) Then
                        If generator.localenergychange(ComboBoxagent.SelectedIndex + 1, i, 5) <= CInt(TextBox6.Text) And generator.localenergychange(ComboBoxagent.SelectedIndex + 1, i, 5) >= CInt(TextBox5.Text) Or generator.localenergychange(ComboBoxagent.SelectedIndex + 1, i, 6) >= CInt(TextBox5.Text) And generator.localenergychange(ComboBoxagent.SelectedIndex + 1, i, 6) <= CInt(TextBox6.Text) Then
                            overlapcheck = True
                            Exit Function
                        End If
                    End If
                End If
            End If
        Next
        overlapcheck = False
    End Function

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        Dim input As String
        Dim remove As Integer

        If ListView1.Items.Count = 0 Then
            MessageBox.Show("There are no interactions.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        input = InputBox("Please enter the number of the region that you want to remove.", "Remove Abiotic Factor", 1)
        If input = "" Then
            Exit Sub
        End If
        If Integer.TryParse(input, remove) Then
            remove = CInt(input)
        Else
            MessageBox.Show("Please enter an integer.")
            Exit Sub
        End If

        generator.localenergychange(ComboBoxagent.SelectedIndex + 1, remove, 1) = 0
        generator.localenergychange(ComboBoxagent.SelectedIndex + 1, remove, 2) = 0
        generator.localenergychange(ComboBoxagent.SelectedIndex + 1, remove, 3) = 0
        generator.localenergychange(ComboBoxagent.SelectedIndex + 1, remove, 4) = 0
        generator.localenergychange(ComboBoxagent.SelectedIndex + 1, remove, 5) = 0
        generator.localenergychange(ComboBoxagent.SelectedIndex + 1, remove, 6) = 0
        generator.localenergychange(ComboBoxagent.SelectedIndex + 1, remove, 7) = 0
        generator.localenergychange(ComboBoxagent.SelectedIndex + 1, remove, 0) = 3
        Call sortregions(remove)
        Call listviewitems()
    End Sub

    Private Sub sortregions(ByVal remove As Integer)
        If generator.localenergychange(ComboBoxagent.SelectedIndex + 1, remove, 0) = 3 Then
            If generator.localenergychange(ComboBoxagent.SelectedIndex + 1, remove + 1, 0) = 2 Then
                For i = remove To 999
                    generator.localenergychange(ComboBoxagent.SelectedIndex + 1, i, 1) = generator.localenergychange(ComboBoxagent.SelectedIndex + 1, i + 1, 1)
                    generator.localenergychange(ComboBoxagent.SelectedIndex + 1, i, 2) = generator.localenergychange(ComboBoxagent.SelectedIndex + 1, i + 1, 2)
                    generator.localenergychange(ComboBoxagent.SelectedIndex + 1, i, 3) = generator.localenergychange(ComboBoxagent.SelectedIndex + 1, i + 1, 3)
                    generator.localenergychange(ComboBoxagent.SelectedIndex + 1, i, 4) = generator.localenergychange(ComboBoxagent.SelectedIndex + 1, i + 1, 4)
                    generator.localenergychange(ComboBoxagent.SelectedIndex + 1, i, 5) = generator.localenergychange(ComboBoxagent.SelectedIndex + 1, i + 1, 5)
                    generator.localenergychange(ComboBoxagent.SelectedIndex + 1, i, 6) = generator.localenergychange(ComboBoxagent.SelectedIndex + 1, i + 1, 6)
                    generator.localenergychange(ComboBoxagent.SelectedIndex + 1, i, 7) = generator.localenergychange(ComboBoxagent.SelectedIndex + 1, i + 1, 7)
                    generator.localenergychange(ComboBoxagent.SelectedIndex + 1, i, 0) = generator.localenergychange(ComboBoxagent.SelectedIndex + 1, i + 1, 0)
                Next
            End If
        End If
    End Sub
End Class
