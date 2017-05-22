Public Class exchangedata

    Private oExcel As Object
    Private oBook As Object
    Private oSheet As Object
    Private oSheet2 As Object
    Private oSheet3 As Object
    Private logged As Boolean
    Private exceldir As String
    Private currentcell As Integer
    Private previoustick As Integer

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        oBook.SaveAs(exceldir)
        oBook.close()

        oBook = Nothing
        oExcel.Quit()
        oExcel = Nothing
        logged = False

        Timer1.Stop()
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If previoustick <> Form1.tick Then
            Dim l1 As String = "Agent:" & vbCrLf
            Dim l2 As String = "Agent name:" & vbCrLf
            Dim l3 As String = "X Exchanged Previously" & vbCrLf
            Dim l4 As String = "Total Quantity of X" & vbCrLf
            Dim l5 As String = "Total Quantity of Y" & vbCrLf
            Dim l6 As String = "Utility" & vbCrLf
            Dim l7 As String = "Y Exchanged Previously" & vbCrLf
            Dim l8 As String = "Summary:" & vbCrLf

            Dim totalutility As Decimal
            Dim totalagents As Integer
            Dim min As Decimal = 1000000000
            Dim max As Decimal = 0
            Dim uti(Form1.total) As Decimal
            Dim x As Integer
            Dim y As Integer

            For i = 1 To Form1.total
                If generator.agentlocation(i, 14) <> 0 Then
                    l1 &= i & vbCrLf
                    l2 &= generator.agentname(generator.agentlocation(i, 4)) & vbCrLf
                    totalutility += generator.agentlocation(i, 14)
                    x += generator.agentlocation(i, 11)
                    y += generator.agentlocation(i, 12)
                    totalagents += 1
                    If max < generator.agentlocation(i, 14) Then
                        max = generator.agentlocation(i, 14)
                    End If
                    If min > generator.agentlocation(i, 14) And generator.agentlocation(i, 14) <> 0 Then
                        min = generator.agentlocation(i, 14)
                    End If
                    uti(i) = generator.agentlocation(i, 14)
                    l3 &= generator.agentlocation(i, 18) & vbCrLf
                    l4 &= generator.agentlocation(i, 11) & vbCrLf
                    l5 &= generator.agentlocation(i, 12) & vbCrLf
                    l6 &= Decimal.Round(generator.agentlocation(i, 14), 2, MidpointRounding.AwayFromZero) & vbCrLf
                    l7 &= generator.agentlocation(i, 19) & vbCrLf
                End If
            Next

            l8 &= "Total Utility: " & Decimal.Round(totalutility, 2, MidpointRounding.AwayFromZero) & vbCrLf
            l8 &= "Total Number of agents in market: " & totalagents & vbCrLf
            If totalagents > 0 Then
                l8 &= "Average agent Utility: " & Decimal.Round(totalutility / totalagents, 2, MidpointRounding.AwayFromZero) & vbCrLf
            End If
            l8 &= "Total quantity of X in market: " & x & vbCrLf
            l8 &= "Total quantity of Y in market: " & y

            Label1.Text = l1
            Label2.Text = l2
            Label3.Text = l3
            Label4.Text = l4
            Label5.Text = l5
            Label6.Text = l6
            Label7.Text = l7
            Label8.Text = l8

            Dim diff As Decimal = max - min
            Dim range As Decimal = diff / 20 '20 different slots
            Dim slot(19) As Integer
            For i = 0 To Form1.total
                For j = 0 To 19
                    If uti(i) >= ((j * range) + min) And uti(i) <= (((j + 1) * range) + min) And uti(i) <> 0 Then
                        slot(j) += 1
                        Exit For
                    End If
                Next
            Next

            Chart1.Series("Utility Histogram").Points.Clear()
            For j = 0 To 19
                Dim avg As Decimal = ((((j * range) + min)) + ((((j + 1) * range) + min))) / 2
                Chart1.Series("Utility Histogram").Points.AddXY(avg, slot(j))
            Next

            If logged = True Then
                currentcell += 1
                oSheet.cells(currentcell, 1) = Form1.tick
                oSheet.cells(currentcell, 2) = totalagents
                oSheet.cells(currentcell, 3) = x
                oSheet.cells(currentcell, 4) = y
                oSheet.cells(currentcell, 5) = Decimal.Round(totalutility, 2, MidpointRounding.AwayFromZero)
                oSheet.cells(currentcell, 6) = Decimal.Round(totalutility / totalagents, 2, MidpointRounding.AwayFromZero)
            End If
            previoustick = Form1.tick
        End If
    End Sub

    Private Sub export_data()
        SaveFileDialog1.ShowDialog()

        oExcel = CreateObject("Excel.Application")
        oExcel.sheetsinnewworkbook = 1
        oBook = oExcel.Workbooks.Add
        oSheet = oBook.Worksheets(1)
        oSheet.name = "Exchange Summary"

        oSheet.Cells(1, 1) = "Tick"
        oSheet.cells(1, 2) = "Total Agents"
        oSheet.cells(1, 3) = "Total X"
        oSheet.cells(1, 4) = "Total Y"
        oSheet.cells(1, 5) = "Total Utility"
        oSheet.cells(1, 6) = "Average Agent Utility"

        currentcell = 1
    End Sub

    Private Sub exchangedata_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        previoustick = 0
        Timer1.Start()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Call export_data()
        logged = True
    End Sub

    Private Sub SaveFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk
        Dim Filetosaveas As String = SaveFileDialog1.FileName
        exceldir = SaveFileDialog1.FileName
    End Sub
End Class
