Public Class frmInteractions

    Private oExcel As Object
    Private oBook As Object
    Private oSheet As Object
    Private exceldir As String

    Private Sub frmInteractions_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        lstInteractions.Columns.Add("Interaction", 100)
        lstInteractions.Columns.Add("First Agent in Interaction", 200)
        lstInteractions.Columns.Add("Second Agent in Interaction", 200)
        lstInteractions.Columns.Add("Type of Interaction", 200)
        lstInteractions.Columns.Add("Result of Interaction", 200)
        lstInteractions.Columns.Add("Energy Cost in Reproduction", 100)
        lstInteractions.Columns.Add("Consumption Energy Transfer", 100)
        lstInteractions.Columns.Add("Probability of Interaction", 100)
        lstInteractions.GridLines = True

        Call listview()

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        Dim input As String
        Dim remove As Integer
        Dim interactions As Integer
        If lstInteractions.Items.Count = 0 Then
            MessageBox.Show("There are no interactions.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        input = InputBox("Please enter the number of the interaction that you want to remove.", "Remove Interaction", 1)
        If input = "" Then
            Exit Sub
        End If
        If Integer.TryParse(input, remove) Then
            remove = CInt(input)
        Else
            MessageBox.Show("Please enter an integer.")
            Exit Sub
        End If

        For i = 1 To Form1.agent
            For a = 1 To Form1.agent
                If generator.action(i, a, 1, 0, 0) <> 0 Then
                    interactions += 1
                    If interactions = remove Then
                        generator.action(i, a, 1, 0, 0) = 0
                        generator.interactionprobability(i, a) = 0
                        generator.catalystprobability(i, a) = 0
                        generator.catalystproximity(i, a, 1) = 0
                        generator.catalystproximity(i, a, 2) = 0
                        generator.catalystproximity(i, a, 3) = 0
                        generator.catalystagent(i, a) = 0
                        lstInteractions.Items.Clear()
                        Call listview()
                        MessageBox.Show("Interaction " & remove & " was removed.", "Interaction Removed")
                        Exit Sub
                    End If
                End If
            Next
        Next
    End Sub

    Private Sub listview()
        Dim interaction As Integer
        For i = 1 To Form1.agent
            For a = 1 To Form1.agent
                If generator.action(i, a, 1, 0, 0) = 1 Then

                    'reproduction only
                    For r = 1 To Form1.agent
                        If generator.action(i, a, 2, r, 1) > 0 Then
                            interaction += 1
                            Dim interactionlisting As New ListViewItem()
                            interactionlisting.SubItems.Add(generator.agentname(i))
                            interactionlisting.SubItems.Add(generator.agentname(a))
                            interactionlisting.SubItems.Add("Reproduction")
                            interactionlisting.SubItems.Add(generator.action(i, a, 2, r, 1) & " of" & generator.agentname(r) & " are produced")
                            interactionlisting.SubItems.Add(generator.action(i, a, 5, 0, 0))
                            interactionlisting.SubItems.Add("N/A")
                            interactionlisting.SubItems.Add(FormatPercent(generator.interactionprobability(i, a) / 100))
                            interactionlisting.SubItems(0).Text = interaction.ToString
                            lstInteractions.Items.Add(interactionlisting)
                        End If
                    Next

                ElseIf generator.action(i, a, 1, 0, 0) = 2 Then

                    'consumption only
                    interaction += 1
                    Dim interactionlisting As New ListViewItem()
                    interactionlisting.SubItems.Add(generator.agentname(i))
                    interactionlisting.SubItems.Add(generator.agentname(a))
                    interactionlisting.SubItems.Add("Comsumption")
                    interactionlisting.SubItems.Add(generator.agentname(a) & " is consumed")
                    interactionlisting.SubItems.Add("N/A")
                    If generator.action(i, a, 6, 0, 0) = 1 Then
                        interactionlisting.SubItems.Add(FormatPercent(generator.action(i, a, 3, 0, 0) / 100))
                    ElseIf generator.action(i, a, 6, 0, 0) = 2 Then
                        interactionlisting.SubItems.Add(generator.action(i, a, 4, 0, 0))
                    End If
                    interactionlisting.SubItems.Add(FormatPercent(generator.interactionprobability(i, a) / 100))
                    interactionlisting.SubItems(0).Text = interaction.ToString
                    lstInteractions.Items.Add(interactionlisting)

                ElseIf generator.action(i, a, 1, 0, 0) = 3 Then

                    'diminish
                    interaction += 1
                    Dim interactionlisting As New ListViewItem()
                    interactionlisting.SubItems.Add(generator.agentname(i))
                    interactionlisting.SubItems.Add(generator.agentname(a))
                    interactionlisting.SubItems.Add("Diminish")
                    interactionlisting.SubItems.Add(generator.agentname(i) & " diminishes")
                    interactionlisting.SubItems.Add("N/A")
                    interactionlisting.SubItems.Add("N/A")
                    interactionlisting.SubItems.Add(FormatPercent(generator.interactionprobability(i, a) / 100))
                    interactionlisting.SubItems(0).Text = interaction.ToString
                    lstInteractions.Items.Add(interactionlisting)

                ElseIf generator.action(i, a, 1, 0, 0) = 4 Then

                    'consume and reproduce
                    For r = 1 To Form1.agent
                        If generator.action(i, a, 2, r, 1) > 0 Then
                            interaction += 1
                            Dim interactionlisting As New ListViewItem()
                            interactionlisting.SubItems.Add(generator.agentname(i))
                            interactionlisting.SubItems.Add(generator.agentname(a))
                            interactionlisting.SubItems.Add("Consumption & Reproduction")
                            interactionlisting.SubItems.Add(generator.agentname(a) & " is consumed and " & generator.action(i, a, 2, r, 1) & " of " & generator.agentname(r) & " are produced")
                            interactionlisting.SubItems.Add(generator.action(i, a, 5, 0, 0))
                            If generator.action(i, a, 6, 0, 0) = 1 Then
                                interactionlisting.SubItems.Add(FormatPercent(generator.action(i, a, 3, 0, 0) / 100))
                            ElseIf generator.action(i, a, 6, 0, 0) = 2 Then
                                interactionlisting.SubItems.Add(generator.action(i, a, 4, 0, 0))
                            End If
                            interactionlisting.SubItems.Add(FormatPercent(generator.interactionprobability(i, a) / 100))
                            interactionlisting.SubItems(0).Text = interaction.ToString
                            lstInteractions.Items.Add(interactionlisting)
                        End If
                    Next

                ElseIf generator.action(i, a, 1, 0, 0) = 5 Then

                    'consume and diminish
                    interaction += 1
                    Dim interactionlisting As New ListViewItem()
                    interactionlisting.SubItems.Add(generator.agentname(i))
                    interactionlisting.SubItems.Add(generator.agentname(a))
                    interactionlisting.SubItems.Add("Comsumption & Diminish")
                    interactionlisting.SubItems.Add(generator.agentname(a) & " is consumed and " & generator.agentname(i) & " diminishes")
                    interactionlisting.SubItems.Add("N/A")
                    If generator.action(i, a, 6, 0, 0) = 1 Then
                        interactionlisting.SubItems.Add(FormatPercent(generator.action(i, a, 3, 0, 0) / 100))
                    ElseIf generator.action(i, a, 6, 0, 0) = 2 Then
                        interactionlisting.SubItems.Add(generator.action(i, a, 4, 0, 0))
                    End If
                    interactionlisting.SubItems.Add(FormatPercent(generator.interactionprobability(i, a) / 100))
                    interactionlisting.SubItems(0).Text = interaction.ToString
                    lstInteractions.Items.Add(interactionlisting)

                ElseIf generator.action(i, a, 1, 0, 0) = 6 Then

                    'reproduce and diminish
                    interaction += 1
                    For r = 1 To Form1.agent
                        If generator.action(i, a, 2, r, 1) > 0 Then
                            interaction += 1
                            Dim interactionlisting As New ListViewItem()
                            interactionlisting.SubItems.Add(generator.agentname(i))
                            interactionlisting.SubItems.Add(generator.agentname(a))
                            interactionlisting.SubItems.Add("Diminish & Reproduction")
                            interactionlisting.SubItems.Add(generator.agentname(i) & " diminishes and " & generator.action(i, a, 2, r, 1) & " of " & generator.agentname(r) & " are produced")
                            interactionlisting.SubItems.Add(generator.action(i, a, 5, 0, 0))
                            interactionlisting.SubItems.Add("N/A")
                            interactionlisting.SubItems.Add(FormatPercent(generator.interactionprobability(i, a) / 100))
                            interactionlisting.SubItems(0).Text = interaction.ToString
                            lstInteractions.Items.Add(interactionlisting)
                        End If
                    Next

                ElseIf generator.action(i, a, 1, 0, 0) = 7 Then

                    'consume, reproduce and diminish
                    interaction += 1
                    For r = 1 To Form1.agent
                        If generator.action(i, a, 2, r, 1) > 0 Then
                            interaction += 1
                            Dim interactionlisting As New ListViewItem()
                            interactionlisting.SubItems.Add(generator.agentname(i))
                            interactionlisting.SubItems.Add(generator.agentname(a))
                            interactionlisting.SubItems.Add("Consumption, Diminish & Reproduction")
                            interactionlisting.SubItems.Add(generator.agentname(i) & " diminishes, " & generator.agentname(a) & " is consumed and " & generator.action(i, a, 2, r, 1) & " of " & generator.agentname(r) & " are produced")
                            interactionlisting.SubItems.Add(generator.action(i, a, 5, 0, 0))
                            If generator.action(i, a, 6, 0, 0) = 1 Then
                                interactionlisting.SubItems.Add(FormatPercent(generator.action(i, a, 3, 0, 0) / 100))
                            ElseIf generator.action(i, a, 6, 0, 0) = 2 Then
                                interactionlisting.SubItems.Add(generator.action(i, a, 4, 0, 0))
                            End If
                            interactionlisting.SubItems.Add(FormatPercent(generator.interactionprobability(i, a) / 100))
                            interactionlisting.SubItems(0).Text = interaction.ToString
                            lstInteractions.Items.Add(interactionlisting)
                        End If
                    Next

                End If
            Next
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SaveFileDialog1.ShowDialog()

        If exceldir = String.Empty Then
            Exit Sub
        End If

        oExcel = CreateObject("Excel.Application")
        oBook = oExcel.Workbooks.Add
        oSheet = oBook.Worksheets(1)
        oSheet.name = "Agent Interactions"

        oSheet.cells(1, 1) = "Interaction"
        oSheet.cells(1, 2) = "First Agent in Interaction"
        oSheet.cells(1, 3) = "Second Agent in Interaction"
        oSheet.cells(1, 4) = "Type of Interaction"
        oSheet.cells(1, 5) = "Result of Interaction"
        oSheet.cells(1, 6) = "Energy Cost in Reproduction"
        oSheet.cells(1, 7) = "Consumption Energy Transfer"
        oSheet.cells(1, 8) = "Probability of Interaction"

        Dim row As Integer = 1
        Dim col As Integer = 1

        For Each item As ListViewItem In lstInteractions.Items
            For i As Integer = 0 To item.SubItems.Count - 1
                oSheet.Cells(row + 1, col) = item.SubItems(i).Text
                col = col + 1
            Next
            row += 1
            col = 1
        Next

        oBook.SaveAs(exceldir)
        oBook.close()
        oBook = Nothing
        oExcel.Quit()
        oExcel = Nothing
        MessageBox.Show("Data was successfully exported.", "Data Export", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub SaveFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk
        Dim Filetosaveas As String = SaveFileDialog1.FileName
        exceldir = SaveFileDialog1.FileName
    End Sub
End Class
