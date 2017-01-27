Public Class AI

    Private reservoircapacity As Integer = 0

    'adding the ability to make agents static (stay stationary). 
    Private Sub AI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For i = 1 To Form1.agent
            ComboBoxagent.Items.Add(generator.agentname(i))
        Next
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        If IsNumeric(TextBox1.Text) Then
            If generator.excludeagent(ComboBoxagent.SelectedIndex + 1, 0) = 0 Then
                generator.agentrange(ComboBoxagent.SelectedIndex + 1, 0, 0) = TextBox1.Text
            Else
                CheckBox3.Checked = False
                Call clearexclude()
            End If
        End If
        Call rangeview()
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        If IsNumeric(TextBox2.Text) Then
            If generator.excludeagent(ComboBoxagent.SelectedIndex + 1, 0) = 0 Then
                generator.agentrange(ComboBoxagent.SelectedIndex + 1, 0, 1) = TextBox2.Text
            Else
                CheckBox3.Checked = False
                Call clearexclude()
            End If
        End If
        Call rangeview()
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
        If IsNumeric(TextBox3.Text) Then
            generator.agentrange(ComboBoxagent.SelectedIndex + 1, 1, 0) = TextBox3.Text
        Else
            CheckBox3.Checked = False
            Call clearexclude()
        End If
        Call rangeview()
    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged
        If IsNumeric(TextBox4.Text) Then
            If generator.excludeagent(ComboBoxagent.SelectedIndex + 1, 0) = 0 Then
                generator.agentrange(ComboBoxagent.SelectedIndex + 1, 1, 1) = TextBox4.Text
            Else
                CheckBox3.Checked = False
                Call clearexclude()
            End If
        End If
        Call rangeview()
    End Sub

    Private Sub TextBox5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox5.TextChanged
        If IsNumeric(TextBox5.Text) Then
            If generator.excludeagent(ComboBoxagent.SelectedIndex + 1, 0) = 0 Then
                generator.agentrange(ComboBoxagent.SelectedIndex + 1, 2, 0) = TextBox5.Text
            Else
                CheckBox3.Checked = False
                Call clearexclude()
            End If
        End If
        Call rangeview()
    End Sub

    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.TextChanged
        If IsNumeric(TextBox6.Text) Then
            If generator.excludeagent(ComboBoxagent.SelectedIndex + 1, 0) = 0 Then
                generator.agentrange(ComboBoxagent.SelectedIndex + 1, 2, 1) = TextBox6.Text
            Else
                CheckBox3.Checked = False
                Call clearexclude()
            End If
        End If
        Call rangeview()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub ComboBoxagent_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxagent.SelectedIndexChanged
        TextBox1.Text = generator.agentrange(ComboBoxagent.SelectedIndex + 1, 0, 0)
        TextBox2.Text = generator.agentrange(ComboBoxagent.SelectedIndex + 1, 0, 1)
        TextBox3.Text = generator.agentrange(ComboBoxagent.SelectedIndex + 1, 1, 0)
        TextBox4.Text = generator.agentrange(ComboBoxagent.SelectedIndex + 1, 1, 1)
        TextBox5.Text = generator.agentrange(ComboBoxagent.SelectedIndex + 1, 2, 0)
        TextBox6.Text = generator.agentrange(ComboBoxagent.SelectedIndex + 1, 2, 1)
        CheckBox1.Checked = generator.agentrangeabsolute(ComboBoxagent.SelectedIndex + 1)
        For i = 1 To Form1.total
            If generator.agentlocation(i, 4) = ComboBoxagent.SelectedIndex + 1 Then
                If generator.staticagent(i) = 2 Then
                    chkStatic.Checked = True
                    If generator.agentreservoir(i, 0) = 2 Then
                        CheckBox4.Checked = True
                    Else
                        CheckBox4.Checked = False
                    End If
                Else
                    chkStatic.Checked = False
                    CheckBox4.Checked = False
                End If
            End If
        Next
        If Form1.visualizerange = ComboBoxagent.SelectedIndex + 1 Then
            CheckBox2.Checked = True
        Else
            CheckBox2.Checked = False
        End If
        If generator.excludeagent(ComboBoxagent.SelectedIndex + 1, 0) = 2 Then
            CheckBox3.Checked = True
        Else
            CheckBox3.Checked = False
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        generator.agentrangeabsolute(ComboBoxagent.SelectedIndex + 1) = CheckBox1.Checked
    End Sub

    Private Sub chkStatic_CheckedChanged(sender As Object, e As EventArgs) Handles chkStatic.CheckedChanged
        If chkStatic.Checked = True Then
            CheckBox4.Enabled = True
            For i = 1 To Form1.total
                If generator.agentlocation(i, 4) = ComboBoxagent.SelectedIndex + 1 Then
                    generator.staticagent(i) = 2
                End If
            Next
            generator.staticagentid(ComboBoxagent.SelectedIndex + 1) = 2
        ElseIf chkStatic.Checked = False Then
            CheckBox4.Enabled = False
            CheckBox4.Checked = False
            For i = 1 To Form1.total
                If generator.agentlocation(i, 4) = ComboBoxagent.SelectedIndex + 1 Then
                    generator.staticagent(i) = 0
                End If
            Next
            generator.staticagentid(ComboBoxagent.SelectedIndex + 1) = 0
        End If

        generator.gfxxy.Clear(Color.White)
        Call generator.gridxy()

        generator.agentchange = True

        ' placing the agents
        For i = 1 To Form1.total
            Dim x As Integer = generator.agentlocation(i, 0)
            Dim y As Integer = generator.agentlocation(i, 1)
            Dim z As Integer = generator.agentlocation(i, 2)
            Dim d As Integer = generator.agentlocation(i, 3)
            Dim ag As Integer = generator.agentlocation(i, 4)
            Call Form1.creator(x, y, z, d, generator.agentcolour(ag), i)
        Next


        Call generator.topgridxy()
        Call Form1.picshow()
        'Form1.PictureBox1.Image = generator.picxy

    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        Call rangeview()
    End Sub

    Sub rangeview()
        generator.agentchange = True

        If CheckBox2.Checked = True Then
            Form1.visualizerange = ComboBoxagent.SelectedIndex + 1
            Call Form1.range()
        Else
            Form1.visualizerange = 0
            Call Form1.range()
        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked = True Then
            Try
                If CInt(TextBox2.Text) < CInt(TextBox1.Text) Or CInt(TextBox4.Text) < CInt(TextBox3.Text) Or CInt(TextBox6.Text) < (TextBox5.Text) Then
                    MessageBox.Show("Please enter a valid range. The upper bound must be greater than the lower bound.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                generator.excludeagent(ComboBoxagent.SelectedIndex + 1, 1) = CInt(TextBox2.Text)
                generator.excludeagent(ComboBoxagent.SelectedIndex + 1, 2) = CInt(TextBox1.Text)
                generator.excludeagent(ComboBoxagent.SelectedIndex + 1, 3) = CInt(TextBox4.Text)
                generator.excludeagent(ComboBoxagent.SelectedIndex + 1, 4) = CInt(TextBox3.Text)
                generator.excludeagent(ComboBoxagent.SelectedIndex + 1, 5) = CInt(TextBox6.Text)
                generator.excludeagent(ComboBoxagent.SelectedIndex + 1, 6) = CInt(TextBox5.Text)
                generator.excludeagent(ComboBoxagent.SelectedIndex + 1, 0) = 2
                'CheckBox1.Enabled = False
                Call rangeview()
            Catch ex As Exception
                MessageBox.Show("Please enter integer values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        ElseIf CheckBox3.Checked = False Then
            Call clearexclude()
            If IsNumeric(TextBox1.Text) And IsNumeric(TextBox2.Text) And IsNumeric(TextBox3.Text) And IsNumeric(TextBox4.Text) And IsNumeric(TextBox5.Text) And IsNumeric(TextBox6.Text) Then
                generator.agentrange(ComboBoxagent.SelectedIndex + 1, 0, 0) = TextBox1.Text
                generator.agentrange(ComboBoxagent.SelectedIndex + 1, 0, 1) = TextBox2.Text
                generator.agentrange(ComboBoxagent.SelectedIndex + 1, 1, 0) = TextBox3.Text
                generator.agentrange(ComboBoxagent.SelectedIndex + 1, 1, 1) = TextBox4.Text
                generator.agentrange(ComboBoxagent.SelectedIndex + 1, 2, 0) = TextBox5.Text
                generator.agentrange(ComboBoxagent.SelectedIndex + 1, 2, 1) = TextBox6.Text
                'CheckBox1.Enabled = True
                Call rangeview()
            End If
        End If
    End Sub

    Sub clearexclude()
        generator.excludeagent(ComboBoxagent.SelectedIndex + 1, 0) = 0
        generator.excludeagent(ComboBoxagent.SelectedIndex + 1, 6) = 0
        generator.excludeagent(ComboBoxagent.SelectedIndex + 1, 1) = 0
        generator.excludeagent(ComboBoxagent.SelectedIndex + 1, 2) = 0
        generator.excludeagent(ComboBoxagent.SelectedIndex + 1, 3) = 0
        generator.excludeagent(ComboBoxagent.SelectedIndex + 1, 4) = 0
        generator.excludeagent(ComboBoxagent.SelectedIndex + 1, 5) = 0
        CheckBox1.Enabled = True
    End Sub

    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.CheckedChanged
        If CheckBox4.Checked = True Then
            Button2.Enabled = True
            For i = 1 To Form1.total
                If generator.agentlocation(i, 4) = ComboBoxagent.SelectedIndex + 1 Then
                    generator.agentreservoir(i, 0) = 2
                    generator.agentreservoir(i, 1) = 100
                    generator.reservoiragentid(ComboBoxagent.SelectedIndex + 1, 2) = 100
                End If
            Next
            generator.reservoiragentid(ComboBoxagent.SelectedIndex + 1, 1) = 2
        ElseIf CheckBox4.Checked = False Then
            Button2.Enabled = False
            For i = 1 To Form1.total
                If generator.agentlocation(i, 4) = ComboBoxagent.SelectedIndex + 1 Then
                    generator.agentreservoir(i, 0) = 0
                    generator.agentreservoir(i, 1) = 0
                    generator.agentreservoir(i, 2) = 0
                End If
            Next
            generator.reservoiragentid(ComboBoxagent.SelectedIndex + 1, 1) = 0
        End If

        generator.gfxxy.Clear(Color.White)
        Call generator.gridxy()

        generator.agentchange = True

        ' placing the agents
        For i = 1 To Form1.total
            Dim x As Integer = generator.agentlocation(i, 0)
            Dim y As Integer = generator.agentlocation(i, 1)
            Dim z As Integer = generator.agentlocation(i, 2)
            Dim d As Integer = generator.agentlocation(i, 3)
            Dim ag As Integer = generator.agentlocation(i, 4)
            Call Form1.creator(x, y, z, d, generator.agentcolour(ag), i)
        Next

        Call generator.topgridxy()
        Call Form1.picshow()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim input As String
        input = InputBox("Please enter the reservoir capacity.", "Reservoir Settings", 100)
        If input = "" Then
            Exit Sub
        End If
        If Integer.TryParse(input, reservoircapacity) Then
            If CInt(input) <= 0 Then
                MessageBox.Show("Reservoir capacity must be greater than 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            reservoircapacity = CInt(input)
        Else
            MessageBox.Show("Please enter an integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If


        For i = 1 To Form1.total
            If generator.agentlocation(i, 4) = ComboBoxagent.SelectedIndex + 1 Then
                generator.agentreservoir(i, 0) = 2
                generator.agentreservoir(i, 1) = input
                generator.reservoiragentid(ComboBoxagent.SelectedIndex + 1, 2) = input
            End If
        Next

    End Sub

    Private Sub CheckBox5_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox5.CheckedChanged
        If CheckBox5.Checked = True Then

        Else

        End If
    End Sub

    Private Sub CheckBox6_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox6.CheckedChanged
        If CheckBox6.Checked = True Then

        Else

        End If
    End Sub
End Class
