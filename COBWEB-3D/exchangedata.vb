Public Class exchangedata
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Timer1.Stop()
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim l1 As String = "Agent:" & vbCrLf
        Dim l2 As String = "Agent name:" & vbCrLf
        Dim l3 As String = "Buyer/Seller" & vbCrLf
        Dim l4 As String = "Quantity of X" & vbCrLf
        Dim l5 As String = "Quantity of Y" & vbCrLf
        Dim l6 As String = "Utility" & vbCrLf
        Dim l7 As String = "Price" & vbCrLf
        Dim l8 As String = "Summary:" & vbCrLf

        Dim totalutility As Decimal
        Dim totalagents As Integer
        Dim min As Decimal = 1000000000
        Dim max As Decimal = 0
        Dim uti(Form1.total) As Decimal

        For i = 1 To Form1.total
            If generator.agentlocation(i, 14) <> 0 Then
                l1 &= i & vbCrLf
                l2 &= generator.agentname(generator.agentlocation(i, 4)) & vbCrLf
                totalutility += generator.agentlocation(i, 14)
                totalagents += 1
                If max < generator.agentlocation(i, 14) Then
                    max = generator.agentlocation(i, 14)
                End If
                If min > generator.agentlocation(i, 14) And generator.agentlocation(i, 14) <> 0 Then
                    min = generator.agentlocation(i, 14)
                End If
                uti(i) = generator.agentlocation(i, 14)
                l4 &= generator.agentlocation(i, 11) & vbCrLf
                l5 &= generator.agentlocation(i, 12) & vbCrLf
                l6 &= Decimal.Round(generator.agentlocation(i, 14), 2, MidpointRounding.AwayFromZero) & vbCrLf
                l7 &= Decimal.Round(generator.agentlocation(i, 15), 2, MidpointRounding.AwayFromZero) & vbCrLf
            End If
        Next

        l8 &= "Total Utility: " & Decimal.Round(totalutility, 2, MidpointRounding.AwayFromZero) & vbCrLf
        l8 &= "Total Number of agents in market: " & totalagents & vbCrLf
        If totalagents > 0 Then
            l8 &= "Average agent Utility: " & Decimal.Round(totalutility / totalagents, 2, MidpointRounding.AwayFromZero)
        End If
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
    End Sub

    Private Sub exchangedata_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub

    'Sub data()
    '    SaveFileDialog1.ShowDialog()
    '    oExcel = CreateObject("Excel.Application")
    '    oExcel.sheetsinnewworkbook = 2
    '    oBook = oExcel.Workbooks.Add
    '    oSheet = oBook.Worksheets(1)
    '    oSheet2 = oBook.Worksheets(2)
    '    oSheet.name = "Population"
    'End Sub
End Class
