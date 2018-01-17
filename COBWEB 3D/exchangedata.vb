Imports Microsoft.Office.Interop.Excel

Public Class exchangedata

    Private oExcel As Object
    Private oBook As Workbook
    Private oSheet As Object
    Private oSheet2 As Object
    Private oSheet3 As Object
    Private exceldir As String
    Private currentcell As Integer
    Private previoustick As Integer

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (oBook IsNot Nothing) Then
            If (exceldir IsNot Nothing) Then
                oBook.SaveAs(exceldir)
                exceldir = Nothing
            End If
            oBook.Close(SaveChanges:=False)
            oBook = Nothing
        End If
        If (oExcel IsNot Nothing) Then
            oExcel.Quit()
            oExcel = Nothing
        End If
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

            Dim totalUtilityByType(Form1.agentTypeCount)
            For i = 1 To Form1.agentTypeCount
                totalUtilityByType(i) = 0
            Next

            Dim min As Decimal = 1000000000
            Dim max As Decimal = 0
            Dim uti(Form1.total) As Decimal
            Dim x As Integer
            Dim y As Integer

            For i = 1 To Form1.total
                Dim individualUtility = generator.agentlocation(i, 14)
                If individualUtility <> 0 Then
                    l1 &= i & vbCrLf
                    l2 &= generator.agentname(generator.agentlocation(i, 4)) & vbCrLf
                    totalUtilityByType(generator.agentlocation(i, 4)) += individualUtility
                    totalutility += individualUtility
                    x += generator.agentlocation(i, 11)
                    y += generator.agentlocation(i, 12)
                    totalagents += 1
                    If max < individualUtility Then
                        max = individualUtility
                    End If
                    If min > individualUtility And individualUtility <> 0 Then
                        min = individualUtility
                    End If
                    uti(i) = individualUtility
                    l3 &= generator.agentlocation(i, 18) & vbCrLf
                    l4 &= generator.agentlocation(i, 11) & vbCrLf
                    l5 &= generator.agentlocation(i, 12) & vbCrLf
                    l6 &= Decimal.Round(individualUtility, 2, MidpointRounding.AwayFromZero) & vbCrLf
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
            ' Use agentlocation to sum values of each tyoe i=1 to total
            currentcell += 1
            oSheet.cells(currentcell, 1) = Form1.tick
            oSheet.cells(currentcell, 2) = totalagents ' Data recorded
            oSheet.cells(currentcell, 3) = x
            oSheet.cells(currentcell, 4) = y
            oSheet.cells(currentcell, 5) = Decimal.Round(totalutility, 2, MidpointRounding.AwayFromZero)
            If (totalagents <> 0) Then
                oSheet.cells(currentcell, 6) = Decimal.Round(totalutility / totalagents, 2, MidpointRounding.AwayFromZero)
                For i = 1 To Form1.agentTypeCount
                    oSheet.cells(currentcell, 6 + i) = Decimal.Round(totalUtilityByType(i) / generator.agentcount(i), 2, MidpointRounding.AwayFromZero)
                Next
            End If
            previoustick = Form1.tick
        End If
    End Sub

    Private Sub export_data()
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
        For i = 1 To Form1.agentTypeCount
            oSheet.cells(1, 6 + i) = "Agent " & generator.agentname(i) & " average utility."
        Next
        'oSheet.cells(1, 7) = "Agent 1 average utility"
        'oSheet.cells(1, 8) = "Agent 2 average utility"
        currentcell = 1
    End Sub

    Private Sub exchangedata_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        previoustick = 0
        export_data()
        Timer1.Start()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SaveFileDialog1.ShowDialog()
    End Sub

    Private Sub SaveFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk
        Dim Filetosaveas As String = SaveFileDialog1.FileName
        exceldir = SaveFileDialog1.FileName
    End Sub
End Class
