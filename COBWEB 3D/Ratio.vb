Public Class Ratio

    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll
        Form1.changeDepthOfField((TrackBar1.Value + 2) / (TrackBar1.Value + 3))
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Ratio_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        TrackBar1.Value = (2 - (Form1.RenderingEngine.SizeRatio * 3)) / (Form1.RenderingEngine.SizeRatio - 1)
    End Sub
End Class