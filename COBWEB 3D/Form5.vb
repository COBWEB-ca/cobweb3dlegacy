Public Class Form5
    ' variables for production
    Public holdera As Integer
    Public holderb As Integer

    'if the user changes the interaction between two agents, the default probability will be 100%
    Sub check()
        If CheckBoxconsume.Checked = False And CheckBoxproduce.Checked = False And CheckBoxdeminish.Checked = True Then
            'MessageBox.Show(generator.action(ComboBoxagent.SelectedIndex + 1, ComboBox1.SelectedIndex + 1, 1, 0, 0))
            generator.action(ComboBoxagent.SelectedIndex + 1, ComboBox1.SelectedIndex + 1, 1, 0, 0) = 3
        ElseIf CheckBoxconsume.Checked = True And CheckBoxproduce.Checked = False And CheckBoxdeminish.Checked = True Then
            generator.action(ComboBoxagent.SelectedIndex + 1, ComboBox1.SelectedIndex + 1, 1, 0, 0) = 5
        ElseIf CheckBoxconsume.Checked = False And CheckBoxproduce.Checked = True And CheckBoxdeminish.Checked = True Then
            generator.action(ComboBoxagent.SelectedIndex + 1, ComboBox1.SelectedIndex + 1, 1, 0, 0) = 6
        ElseIf CheckBoxconsume.Checked = True And CheckBoxproduce.Checked = False And CheckBoxdeminish.Checked = False Then
            generator.action(ComboBoxagent.SelectedIndex + 1, ComboBox1.SelectedIndex + 1, 1, 0, 0) = 2
        ElseIf CheckBoxconsume.Checked = False And CheckBoxproduce.Checked = True And CheckBoxdeminish.Checked = False Then
            generator.action(ComboBoxagent.SelectedIndex + 1, ComboBox1.SelectedIndex + 1, 1, 0, 0) = 1
        ElseIf CheckBoxconsume.Checked = True And CheckBoxproduce.Checked = True And CheckBoxdeminish.Checked = False Then
            generator.action(ComboBoxagent.SelectedIndex + 1, ComboBox1.SelectedIndex + 1, 1, 0, 0) = 4
        ElseIf CheckBoxconsume.Checked = True And CheckBoxproduce.Checked = True And CheckBoxdeminish.Checked = True Then
            generator.action(ComboBoxagent.SelectedIndex + 1, ComboBox1.SelectedIndex + 1, 1, 0, 0) = 7
        ElseIf CheckBox1.Checked = True And CheckBoxconsume.Checked = False And CheckBoxdeminish.Checked = False And CheckBoxproduce.Checked = False Then
            generator.action(ComboBoxagent.SelectedIndex + 1, ComboBox1.SelectedIndex + 1, 1, 0, 0) = 8 'exchange
        ElseIf CheckBoxconsume.Checked = False And CheckBoxproduce.Checked = False And CheckBoxdeminish.Checked = False Then
            generator.action(ComboBoxagent.SelectedIndex + 1, ComboBox1.SelectedIndex + 1, 1, 0, 0) = 0
        End If

        TextBox4.Text = generator.interactionprobability(ComboBoxagent.SelectedIndex + 1, ComboBox1.SelectedIndex + 1)

        If generator.reservoiragentid(ComboBox1.SelectedIndex + 1, 1) = 2 And CheckBoxconsume.Checked = False And CheckBoxproduce.Checked = False And CheckBoxdeminish.Checked = True Then
            CheckBox3.Enabled = True
            TextBox5.Enabled = True
            Button3.Enabled = True
            Button4.Enabled = True
            CheckBox3.Text = "Add value to reservoir of " & generator.agentname(ComboBox1.SelectedIndex + 1)
            TextBox5.Text = generator.reservoirchange(ComboBoxagent.SelectedIndex + 1, ComboBox1.SelectedIndex + 1, 1)
        ElseIf generator.reservoiragentid(ComboBox1.SelectedIndex + 1, 1) = 0 Or CheckBoxconsume.Checked = True Or CheckBoxproduce.Checked = True Or CheckBoxdeminish.Checked = False Then
            CheckBox3.Enabled = False
            TextBox5.Enabled = False
            Button3.Enabled = False
            Button4.Enabled = False
            TextBox5.Clear()
            CheckBox3.Text = "This option is not available."
        End If
    End Sub

    Private Sub Form5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For i = 1 To Form1.agentTypeCount
            ComboBoxagent.Items.Add(generator.agentname(i))
            ComboBox1.Items.Add(generator.agentname(i))
        Next

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxproduce.CheckedChanged

        Call check()
        If CheckBoxproduce.Checked = True Then
            Button2.Enabled = True
        ElseIf CheckBoxproduce.Checked = False Then
            Button2.Enabled = False
        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxconsume.CheckedChanged
        Call check()

    End Sub


    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxdeminish.CheckedChanged
        Call check()
    End Sub

    Private Sub ComboBoxagent_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxagent.SelectedIndexChanged
        Dim a = ComboBoxagent.SelectedIndex + 1
        Dim b = ComboBox1.SelectedIndex + 1
        If generator.action(a, b, 1, 0, 0) = 1 Then
            CheckBoxconsume.Checked = False
            CheckBoxproduce.Checked = True
            CheckBoxdeminish.Checked = False
            CheckBox1.Checked = False
        ElseIf generator.action(a, b, 1, 0, 0) = 2 Then
            CheckBoxconsume.Checked = True
            CheckBoxproduce.Checked = False
            CheckBoxdeminish.Checked = False
            CheckBox1.Checked = False
        ElseIf generator.action(a, b, 1, 0, 0) = 3 Then
            CheckBoxconsume.Checked = False
            CheckBoxproduce.Checked = False
            CheckBoxdeminish.Checked = True
            CheckBox1.Checked = False
        ElseIf generator.action(a, b, 1, 0, 0) = 4 Then
            CheckBoxconsume.Checked = True
            CheckBoxproduce.Checked = True
            CheckBoxdeminish.Checked = False
            CheckBox1.Checked = False
        ElseIf generator.action(a, b, 1, 0, 0) = 5 Then
            CheckBoxconsume.Checked = True
            CheckBoxproduce.Checked = False
            CheckBoxdeminish.Checked = True
            CheckBox1.Checked = False
        ElseIf generator.action(a, b, 1, 0, 0) = 6 Then
            CheckBoxconsume.Checked = False
            CheckBoxproduce.Checked = True
            CheckBoxdeminish.Checked = True
            CheckBox1.Checked = False
        ElseIf generator.action(a, b, 1, 0, 0) = 7 Then
            CheckBoxconsume.Checked = True
            CheckBoxproduce.Checked = True
            CheckBoxdeminish.Checked = True
            CheckBox1.Checked = False
        ElseIf generator.action(a, b, 1, 0, 0) = 8 Then
            CheckBox1.Checked = True
            CheckBoxdeminish.Checked = False
            CheckBoxconsume.Checked = False
            CheckBoxproduce.Checked = False
        ElseIf generator.action(a, b, 1, 0, 0) = 0 Then
            CheckBoxconsume.Checked = False
            CheckBoxproduce.Checked = False
            CheckBoxdeminish.Checked = False
            CheckBox1.Checked = False
        End If


        'ComboBox2.SelectedIndex = generator.action(a, b, 2) - 1
        TextBox1.Text = generator.action(a, b, 3, 0, 0)
        TextBox2.Text = generator.action(a, b, 4, 0, 0)
        TextBox3.Text = generator.action(a, b, 5, 0, 0)
        TextBox4.Text = generator.interactionprobability(a, b)
        If generator.action(a, b, 6, 0, 0) = 1 Then
            RadioButton1.Checked = True
        ElseIf generator.action(a, b, 6, 0, 0) = 2 Then
            RadioButton2.Checked = True
        End If

        CheckBoxTransform.Checked = loadTransformationOptions(a, b)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim a = ComboBoxagent.SelectedIndex + 1
        Dim b = ComboBox1.SelectedIndex + 1

        If generator.action(a, b, 1, 0, 0) = 1 Then
            CheckBoxconsume.Checked = False
            CheckBoxproduce.Checked = True
            CheckBoxdeminish.Checked = False
            CheckBox1.Checked = False
        ElseIf generator.action(a, b, 1, 0, 0) = 2 Then
            CheckBoxconsume.Checked = True
            CheckBoxproduce.Checked = False
            CheckBoxdeminish.Checked = False
            CheckBox1.Checked = False
        ElseIf generator.action(a, b, 1, 0, 0) = 3 Then
            CheckBoxconsume.Checked = False
            CheckBoxproduce.Checked = False
            CheckBoxdeminish.Checked = True
            CheckBox1.Checked = False
        ElseIf generator.action(a, b, 1, 0, 0) = 4 Then
            CheckBoxconsume.Checked = True
            CheckBoxproduce.Checked = True
            CheckBoxdeminish.Checked = False
            CheckBox1.Checked = False
        ElseIf generator.action(a, b, 1, 0, 0) = 5 Then
            CheckBoxconsume.Checked = True
            CheckBoxproduce.Checked = False
            CheckBoxdeminish.Checked = True
            CheckBox1.Checked = False
        ElseIf generator.action(a, b, 1, 0, 0) = 6 Then
            CheckBoxconsume.Checked = False
            CheckBoxproduce.Checked = True
            CheckBoxdeminish.Checked = True
            CheckBox1.Checked = False
        ElseIf generator.action(a, b, 1, 0, 0) = 7 Then
            CheckBoxconsume.Checked = True
            CheckBoxproduce.Checked = True
            CheckBoxdeminish.Checked = True
            CheckBox1.Checked = False
        ElseIf generator.action(a, b, 1, 0, 0) = 8 Then
            CheckBox1.Checked = True
            CheckBoxdeminish.Checked = False
            CheckBoxconsume.Checked = False
            CheckBoxproduce.Checked = False
        ElseIf generator.action(a, b, 1, 0, 0) = 0 Then
            CheckBoxconsume.Checked = False
            CheckBoxproduce.Checked = False
            CheckBoxdeminish.Checked = False
            CheckBox1.Checked = False
        End If

        'ComboBox2.SelectedIndex = generator.action(a, b, 2) - 1
        TextBox1.Text = generator.action(a, b, 3, 0, 0)
        TextBox2.Text = generator.action(a, b, 4, 0, 0)
        TextBox3.Text = generator.action(a, b, 5, 0, 0)
        TextBox4.Text = generator.interactionprobability(a, b)
        If generator.action(a, b, 6, 0, 0) = 1 Then
            RadioButton1.Checked = True
        ElseIf generator.action(a, b, 6, 0, 0) = 2 Then
            RadioButton2.Checked = True
        End If

        If generator.reservoiragentid(ComboBox1.SelectedIndex + 1, 1) = 2 And CheckBoxconsume.Checked = False And CheckBoxproduce.Checked = False And CheckBoxdeminish.Checked = True Then
            CheckBox3.Enabled = True
            TextBox5.Enabled = True
            Button3.Enabled = True
            Button4.Enabled = True
            CheckBox3.Text = "Add value to reservoir of " & generator.agentname(ComboBox1.SelectedIndex + 1)
            TextBox5.Text = generator.reservoirchange(ComboBoxagent.SelectedIndex + 1, ComboBox1.SelectedIndex + 1, 1)
            If generator.reservoiragentid(ComboBox1.SelectedIndex + 1, 1) = 2 Then
                CheckBox3.Checked = True
            Else
                CheckBox3.Checked = False
            End If
        ElseIf generator.reservoiragentid(ComboBox1.SelectedIndex + 1, 1) = 0 Or CheckBoxconsume.Checked = True Or CheckBoxproduce.Checked = True Or CheckBoxdeminish.Checked = False Then
            CheckBox3.Enabled = False
            TextBox5.Enabled = False
            Button3.Enabled = False
            Button3.Enabled = False
            TextBox5.Clear()
            CheckBox3.Text = "This option is not available."
        End If

        CheckBoxTransform.Checked = loadTransformationOptions(a, b)
    End Sub

    Private Function loadTransformationOptions(agentA As Integer, agentB As Integer) As Boolean
        Dim key1 As New TransformationKey(agentA, agentB)
        Dim key2 As New TransformationKey(agentB, agentA)
        Return generator.transformationPlans.ContainsKey(key1) Or generator.transformationPlans.ContainsKey(key2)
    End Function

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged
        If IsNumeric(TextBox1.Text) Then
            generator.action(ComboBoxagent.SelectedIndex + 1, ComboBox1.SelectedIndex + 1, 3, 0, 0) = TextBox1.Text
        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox2.TextChanged
        If IsNumeric(TextBox2.Text) Then
            generator.action(ComboBoxagent.SelectedIndex + 1, ComboBox1.SelectedIndex + 1, 4, 0, 0) = TextBox2.Text
        End If
    End Sub

    Private Sub TextBox3_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox3.TextChanged
        If IsNumeric(TextBox3.Text) Then
            generator.action(ComboBoxagent.SelectedIndex + 1, ComboBox1.SelectedIndex + 1, 5, 0, 0) = TextBox3.Text
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton1.CheckedChanged
        generator.action(ComboBoxagent.SelectedIndex + 1, ComboBox1.SelectedIndex + 1, 6, 0, 0) = 1
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton2.CheckedChanged
        generator.action(ComboBoxagent.SelectedIndex + 1, ComboBox1.SelectedIndex + 1, 6, 0, 0) = 2
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        holdera = ComboBoxagent.SelectedIndex + 1
        holderb = ComboBox1.SelectedIndex + 1
        productions.Show()
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        If IsNumeric(TextBox4.Text) Then
            generator.interactionprobability(ComboBoxagent.SelectedIndex + 1, ComboBox1.SelectedIndex + 1) = CDec(TextBox4.Text)
        End If
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        If IsNumeric(TextBox5.Text) Then
            generator.reservoirchange(ComboBoxagent.SelectedIndex + 1, ComboBox1.SelectedIndex + 1, 1) = CInt(TextBox5.Text)
        Else
            MessageBox.Show("The value added to the reservoir upon interaction must be an integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged_1(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked = True Then
            If IsNumeric(TextBox5.Text) Then
                generator.reservoirchange(ComboBoxagent.SelectedIndex + 1, ComboBox1.SelectedIndex + 1, 1) = CInt(TextBox5.Text)
            Else
                MessageBox.Show("The value added to the reservoir upon interaction must be an integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox5.Clear()
                TextBox5.Focus()
            End If
        ElseIf CheckBox3.Checked = False Then
            generator.reservoirchange(ComboBoxagent.SelectedIndex + 1, ComboBox1.SelectedIndex + 1, 1) = 0
            TextBox5.Text = 0
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        holdera = ComboBoxagent.SelectedIndex + 1
        holderb = ComboBox1.SelectedIndex + 1
        Form10.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim result As Integer = MessageBox.Show("Would you like the probability of an interaction to vary linearly as a function of the reservoir level/reservoir capacity ratio?", "Probability Function", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            Button4.BackColor = Color.GreenYellow
        ElseIf result = DialogResult.No Then
            Button4.BackColor = Color.Red
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged_1(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            CheckBoxconsume.Checked = False
            CheckBoxdeminish.Checked = False
            CheckBoxproduce.Checked = False
            CheckBoxconsume.Enabled = False
            CheckBoxdeminish.Enabled = False
            CheckBoxproduce.Enabled = False
            Button5.Enabled = True
        Else
            CheckBoxconsume.Enabled = True
            CheckBoxdeminish.Enabled = True
            CheckBoxproduce.Enabled = True
            Button5.Enabled = False
        End If
        Call check()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If ComboBoxagent.SelectedIndex < 0 Or ComboBox1.SelectedIndex < 0 Then
            MessageBox.Show("Please select agents.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        holdera = ComboBoxagent.SelectedIndex + 1
        holderb = ComboBox1.SelectedIndex + 1
        frmexchange.Show()
    End Sub

    Private Sub BtnTransfOptions_Click(sender As Object, e As EventArgs) Handles BtnTransfOptions.Click
        If ComboBoxagent.SelectedIndex < 0 Or ComboBox1.SelectedIndex < 0 Then
            MessageBox.Show("Please select agents.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        holdera = ComboBoxagent.SelectedIndex + 1
        holderb = ComboBox1.SelectedIndex + 1
        Dim transformationOptionsForm As New TransformationOptionsForm(generator, holdera, holderb)
        transformationOptionsForm.Show()
    End Sub
End Class
