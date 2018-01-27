Imports Microsoft.Office.Interop.Excel

Public Class ExcelLogger
    Private mOutputDirectory As String
    Private oExcel As Microsoft.Office.Interop.Excel.Application
    Private oBook As Workbook
    Private oSheet As Worksheet
    Private oSheet2 As Worksheet
    Private oSheet3 As Worksheet

    Private beganWriting As Boolean

    Public Sub openExcelWorkbook(ByVal directory As String)
        mOutputDirectory = directory
        oExcel = New Microsoft.Office.Interop.Excel.Application
        oExcel.sheetsinnewworkbook = 3
        oBook = oExcel.Workbooks.Add
        oSheet = oBook.Worksheets(1)
        oSheet2 = oBook.Worksheets(2)
        oSheet3 = oBook.worksheets(3)
        oSheet.name = "Population"
        oSheet2.name = "Energy"
        oSheet3.Name = "Interaction Counts"
        oSheet.Cells(2, 1) = "Tick"
        oSheet2.Cells(2, 1) = "Tick"
        oSheet3.Cells(2, 1) = "Tick"
        beganWriting = False
    End Sub

    Public Sub logDataToExcel(ByVal currentTick As Integer, ByVal agentTypes As Integer, ByVal total As Integer)
        If oSheet Is Nothing Or oSheet2 Is Nothing Or oSheet3 Is Nothing Then Return ' Avoid attempting to write when excel sheets are not initalized.
        If Not beganWriting Or currentTick <= 1 Then writeMetaData(agentTypes)
        oSheet.Cells(currentTick + 2, 1 + generator.multipleiterations(0) * agentTypes) = currentTick
        oSheet2.Cells(currentTick + 2, 1 + generator.multipleiterations(0) * agentTypes) = currentTick
        oSheet3.Cells(currentTick + 2, 1 + generator.multipleiterations(0) * agentTypes) = currentTick
        For i = 1 To agentTypes
            oSheet.Cells(currentTick + 2, i + 1 + generator.multipleiterations(0) * agentTypes) = generator.agentcount(i)
            oSheet2.Cells(currentTick + 2, i + 1 + generator.multipleiterations(0) * agentTypes) = generator.agentlocation(i, 8)
            oSheet3.Cells(currentTick + 2, i + 1 + generator.multipleiterations(0) * agentTypes) = generator.interactioncount(i)
        Next
    End Sub

    Private Sub writeMetaData(ByVal agentTypes As Integer)
        For i = 1 To agentTypes
            oSheet.Cells(2, i + 1 + generator.multipleiterations(0) * agentTypes) = generator.agentname(i)
            oSheet2.Cells(2, i + 1 + generator.multipleiterations(0) * agentTypes) = generator.agentname(i)
            oSheet3.Cells(2, i + 1 + generator.multipleiterations(0) * agentTypes) = generator.agentname(i)
        Next
        oSheet.Cells(1, 1 + 1 + (generator.multipleiterations(0) * agentTypes)) = "Simulation Iteration: " & generator.multipleiterations(0).ToString()
        With oSheet.Range(oSheet.Cells(1, 1 + 1 + (generator.multipleiterations(0) * agentTypes)), oSheet.Cells(1, agentTypes + 1 + (generator.multipleiterations(0) * agentTypes)))
            .HorizontalAlignment = Constants.xlCenter
            .VerticalAlignment = Constants.xlCenter
            .Merge()
        End With

        oSheet2.Cells(1, 1 + 1 + (generator.multipleiterations(0) * agentTypes)) = "Simulation Iteration: " & generator.multipleiterations(0).ToString()
        With oSheet2.Range(oSheet2.Cells(1, 1 + 1 + (generator.multipleiterations(0) * agentTypes)), oSheet2.Cells(1, agentTypes + 1 + (generator.multipleiterations(0) * agentTypes)))
            .HorizontalAlignment = Constants.xlCenter
            .VerticalAlignment = Constants.xlCenter
            .Merge()
        End With

        oSheet3.Cells(1, 1 + 1 + (generator.multipleiterations(0) * agentTypes)) = "Simulation Iteration: " & generator.multipleiterations(0).ToString()
        With oSheet3.Range(oSheet3.Cells(1, 1 + 1 + (generator.multipleiterations(0) * agentTypes)), oSheet3.Cells(1, agentTypes + 1 + (generator.multipleiterations(0) * agentTypes)))
            .HorizontalAlignment = Constants.xlCenter
            .VerticalAlignment = Constants.xlCenter
            .Merge()
        End With
        beganWriting = True
    End Sub

    Public Sub closeExcelWorkbook()
        Try
            If oBook IsNot Nothing Then
                oBook.SaveAs(mOutputDirectory)
                oBook.Close()
                oBook = Nothing
            End If
            If oExcel IsNot Nothing Then
                oExcel.Quit()
                oExcel = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Oops", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Try
                If oBook IsNot Nothing Then
                    oBook.Close()
                    oBook = Nothing
                End If
                If oExcel IsNot Nothing Then
                    oExcel.Quit()
                    oExcel = Nothing
                End If
            Catch ex2 As Exception
                MessageBox.Show(ex2.Message, "Oops", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Finally
            beganWriting = False
        End Try
    End Sub
End Class