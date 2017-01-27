Public Class frmCatalysis

    Public ii As Integer
    Public aa As Integer

    Private Sub frmCatalysis_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i = 1 To Form1.agent
            ComboBoxagent.Items.Add(generator.agentname(i))
        Next

        Dim interaction As Integer
        For i = 1 To Form1.agent
            For a = 1 To Form1.agent
                If generator.action(i, a, 1, 0, 0) = 1 Then

                    'reproduction only
                    For r = 1 To Form1.agent
                        If generator.action(i, a, 2, r, 1) > 0 Then
                            interaction += 1
                            ComboBox1.Items.Add(interaction.ToString & " - " & generator.agentname(i) & ", " & generator.agentname(a))
                        End If
                    Next

                ElseIf generator.action(i, a, 1, 0, 0) = 2 Then

                    'consumption only
                    interaction += 1
                    ComboBox1.Items.Add(interaction.ToString & " - " & generator.agentname(i) & ", " & generator.agentname(a))

                ElseIf generator.action(i, a, 1, 0, 0) = 3 Then

                    'diminish
                    interaction += 1
                    ComboBox1.Items.Add(interaction.ToString & " - " & generator.agentname(i) & ", " & generator.agentname(a))
                ElseIf generator.action(i, a, 1, 0, 0) = 4 Then

                    'consume and reproduce
                    interaction += 1
                    For r = 1 To Form1.agent
                        If generator.action(i, a, 2, r, 1) > 0 Then
                            ComboBox1.Items.Add(interaction.ToString & " - " & generator.agentname(i) & ", " & generator.agentname(a))
                        End If
                    Next

                ElseIf generator.action(i, a, 1, 0, 0) = 5 Then

                    'consume and diminish
                    interaction += 1
                    ComboBox1.Items.Add(interaction.ToString & " - " & generator.agentname(i) & ", " & generator.agentname(a))

                ElseIf generator.action(i, a, 1, 0, 0) = 6 Then

                    'reproduce and diminish
                    interaction += 1
                    For r = 1 To Form1.agent
                        ComboBox1.Items.Add(interaction.ToString & " - " & generator.agentname(i) & ", " & generator.agentname(a))
                    Next

                ElseIf generator.action(i, a, 1, 0, 0) = 7 Then

                    'consume, reproduce and diminish
                    interaction += 1
                    For r = 1 To Form1.agent
                        ComboBox1.Items.Add(interaction.ToString & " - " & generator.agentname(i) & ", " & generator.agentname(a))

                    Next

                End If
            Next
        Next
        TextBox6.Enabled = False
    End Sub

    Private Sub btnApply_Click(sender As Object, e As EventArgs) Handles btnApply.Click
        If IsNumeric(TextBox5.Text) = True And IsNumeric(TextBox1.Text) = True And IsNumeric(TextBox2.Text) And IsNumeric(TextBox3.Text) = True Then
            generator.catalystprobability(ii, aa) = CDec(TextBox5.Text)
            generator.catalystproximity(ii, aa, 1) = CInt(TextBox1.Text)
            generator.catalystproximity(ii, aa, 2) = CInt(TextBox2.Text)
            generator.catalystproximity(ii, aa, 3) = CInt(TextBox3.Text)
            generator.catalystagent(ii, aa) = ComboBoxagent.SelectedIndex + 1
        Else
            MessageBox.Show("Please enter numerical values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Me.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim interaction As Integer
        For i = 1 To Form1.agent
            For a = 1 To Form1.agent
                If generator.action(i, a, 1, 0, 0) = 1 Then

                    'reproduction only
                    For r = 1 To Form1.agent
                        If generator.action(i, a, 2, r, 1) > 0 Then
                            interaction += 1
                            If interaction = ComboBox1.SelectedIndex + 1 Then
                                TextBox6.Text = generator.interactionprobability(i, a)
                                TextBox5.Text = generator.catalystprobability(i, a)
                                TextBox1.Text = generator.catalystproximity(i, a, 1)
                                TextBox2.Text = generator.catalystproximity(i, a, 2)
                                TextBox3.Text = generator.catalystproximity(i, a, 3)
                                ii = i
                                aa = a
                            End If
                        End If
                    Next

                ElseIf generator.action(i, a, 1, 0, 0) = 2 Then

                    'consumption only
                    interaction += 1
                    If interaction = ComboBox1.SelectedIndex + 1 Then
                        TextBox6.Text = generator.interactionprobability(i, a)
                        TextBox5.Text = generator.catalystprobability(i, a)
                        TextBox1.Text = generator.catalystproximity(i, a, 1)
                        TextBox2.Text = generator.catalystproximity(i, a, 2)
                        TextBox3.Text = generator.catalystproximity(i, a, 3)
                        ii = i
                        aa = a
                    End If

                ElseIf generator.action(i, a, 1, 0, 0) = 3 Then

                    'diminish
                    interaction += 1
                    If interaction = ComboBox1.SelectedIndex + 1 Then
                        TextBox6.Text = generator.interactionprobability(i, a)
                        TextBox5.Text = generator.catalystprobability(i, a)
                        TextBox1.Text = generator.catalystproximity(i, a, 1)
                        TextBox2.Text = generator.catalystproximity(i, a, 2)
                        TextBox3.Text = generator.catalystproximity(i, a, 3)
                        ii = i
                        aa = a
                    End If

                ElseIf generator.action(i, a, 1, 0, 0) = 4 Then

                    'consume and reproduce
                    interaction += 1
                    For r = 1 To Form1.agent
                        If generator.action(i, a, 2, r, 1) > 0 Then
                            If interaction = ComboBox1.SelectedIndex + 1 Then
                                TextBox6.Text = generator.interactionprobability(i, a)
                                TextBox5.Text = generator.catalystprobability(i, a)
                                TextBox1.Text = generator.catalystproximity(i, a, 1)
                                TextBox2.Text = generator.catalystproximity(i, a, 2)
                                TextBox3.Text = generator.catalystproximity(i, a, 3)
                                ii = i
                                aa = a
                            End If
                        End If
                    Next

                ElseIf generator.action(i, a, 1, 0, 0) = 5 Then

                    'consume and diminish
                    interaction += 1
                    If interaction = ComboBox1.SelectedIndex + 1 Then
                        TextBox6.Text = generator.interactionprobability(i, a)
                        TextBox5.Text = generator.catalystprobability(i, a)
                        TextBox1.Text = generator.catalystproximity(i, a, 1)
                        TextBox2.Text = generator.catalystproximity(i, a, 2)
                        TextBox3.Text = generator.catalystproximity(i, a, 3)
                        ii = i
                        aa = a
                    End If

                ElseIf generator.action(i, a, 1, 0, 0) = 6 Then

                    'reproduce and diminish
                    interaction += 1
                    For r = 1 To Form1.agent
                        If interaction = ComboBox1.SelectedIndex + 1 Then
                            TextBox6.Text = generator.interactionprobability(i, a)
                            TextBox5.Text = generator.catalystprobability(i, a)
                            TextBox1.Text = generator.catalystproximity(i, a, 1)
                            TextBox2.Text = generator.catalystproximity(i, a, 2)
                            TextBox3.Text = generator.catalystproximity(i, a, 3)
                            ii = i
                            aa = a
                        End If
                    Next

                ElseIf generator.action(i, a, 1, 0, 0) = 7 Then

                    'consume, reproduce and diminish
                    interaction += 1
                    For r = 1 To Form1.agent
                        If interaction = ComboBox1.SelectedIndex + 1 Then
                            TextBox6.Text = generator.interactionprobability(i, a)
                            TextBox5.Text = generator.catalystprobability(i, a)
                            TextBox1.Text = generator.catalystproximity(i, a, 1)
                            TextBox2.Text = generator.catalystproximity(i, a, 2)
                            TextBox3.Text = generator.catalystproximity(i, a, 3)
                            ii = i
                            aa = a
                        End If
                    Next

                End If
            Next
        Next
    End Sub
End Class
