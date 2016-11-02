Public Class Form7
    Private combo As Integer

    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
        Chart1.Series("Total Agent Population").Points.AddXY(Form1.tick, Form1.total)
        For i = 1 To Form1.agent
            ComboBoxagent.Items.Add(generator.agentname(i))
        Next
        ComboBoxagent.Items.Add("All Agents Only")
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Form1.tick > 0 Then
            Chart1.Series("Total Agent Population").Points.AddXY(Form1.tick, Form1.total)
            If combo <> 0 Then
                Dim pop As Integer = 0
                For i = 1 To Form1.total
                    If generator.agentlocation(i, 4) = combo Then
                        pop += 1
                    End If
                Next
                Chart1.Series(generator.agentname(combo)).Points.AddXY(Form1.tick, pop)
            End If
        End If
    End Sub

    Private Sub ComboBoxagent_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxagent.SelectedIndexChanged
        If combo = 0 Then
            Chart1.Series.Add(generator.agentname(ComboBoxagent.SelectedIndex + 1))
            Chart1.Series(1).ChartType = DataVisualization.Charting.SeriesChartType.Spline
        ElseIf ComboBoxagent.SelectedIndex <> Form1.agent Then
            Chart1.Series(1).Points.Clear()
            Chart1.Series(1).Name = generator.agentname(ComboBoxagent.SelectedIndex + 1)
            Chart1.Series(1).ChartType = DataVisualization.Charting.SeriesChartType.Spline
        ElseIf ComboBoxagent.SelectedIndex = Form1.agent Then
            combo = 0
            Chart1.Series.RemoveAt(1)
            Exit Sub
        End If
        combo = ComboBoxagent.SelectedIndex + 1
    End Sub
End Class
