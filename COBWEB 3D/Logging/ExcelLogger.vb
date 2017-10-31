Public Class ExcelLogger
    Private mOutputDirectory As String
    Private oExcel As Object
    Private oBook As Object
    Private oSheet As Object
    Private oSheet2 As Object
    Private oSheet3 As Object

    Public Sub openExcelWorkbook(ByVal directory As String)
        mOutputDirectory = directory
        oExcel = CreateObject("Excel.Application")
        oExcel.sheetsinnewworkbook = 3
        oBook = oExcel.Workbooks.Add
        oSheet = oBook.Worksheets(1)
        oSheet2 = oBook.Worksheets(2)
        oSheet3 = oBook.worksheets(3)
        oSheet.name = "Population"
        oSheet2.name = "Energy"
        oSheet3.name = "Interactions"

        oSheet.Cells(1, 1) = "Tick"
        oSheet2.Cells(1, 1) = "Tick"
        oSheet3.cells(1, 1) = "Tick"
    End Sub

    Public Sub logDataToExcel(ByVal currentTick As Integer, ByVal agentTypes As Integer, ByVal total As Integer)
        If oSheet Is Nothing Or oSheet2 Is Nothing Or oSheet3 Is Nothing Then Return ' Avoid attempting to write when excel sheets are not initalized.

        Dim agentpop(agentTypes) As Integer
        For p = 1 To agentTypes
            For pop = 1 To total
                If generator.agentlocation(pop, 4) = p Then
                    agentpop(p) = agentpop(p) + 1
                End If
            Next
        Next

        oSheet.Cells(currentTick + 1, 1 + generator.multipleiterations(0) * agentTypes) = currentTick
        oSheet2.Cells(currentTick + 1, 1 + generator.multipleiterations(0) * agentTypes) = currentTick
        oSheet3.cells(currentTick + 1, 1 + generator.multipleiterations(0) * agentTypes) = currentTick
        For i = 1 To agentTypes
            oSheet.cells(1, i + 1 + generator.multipleiterations(0) * agentTypes) = generator.agentname(i) & " (" & generator.multipleiterations(0).ToString() & ")"
            oSheet2.cells(1, i + 1 + generator.multipleiterations(0) * agentTypes) = generator.agentname(i) & " (" & generator.multipleiterations(0).ToString() & ")"
            oSheet3.cells(1, i + 1 + generator.multipleiterations(0) * agentTypes) = generator.agentname(i) & " (" & generator.multipleiterations(0).ToString() & ")"
            oSheet.Cells(currentTick + 1, i + 1 + generator.multipleiterations(0) * agentTypes) = agentpop(i)
            oSheet2.Cells(currentTick + 1, i + 1 + generator.multipleiterations(0) * agentTypes) = generator.agentlocation(i, 8)
            oSheet3.cells(currentTick + 1, i + 1 + generator.multipleiterations(0) * agentTypes) = generator.interactioncount(i)
        Next
    End Sub

    Public Sub closeExcelWorkbook()
        If oBook IsNot Nothing Then
            oBook.SaveAs(mOutputDirectory)
            oBook.close()
            oBook = Nothing
        End If
        If oExcel IsNot Nothing Then
            oExcel.Quit()
            oExcel = Nothing
        End If
    End Sub
End Class