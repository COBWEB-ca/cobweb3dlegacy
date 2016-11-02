Public Class Ratio

    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll
        Form1.sizeratio = ((TrackBar1.Value + 2) / (TrackBar1.Value + 3))
        'MsgBox(Form1.sizeratio)
        generator.gfxxy.Clear(Color.White)
        Call generator.gridxy()
        Call generator.topgridxy()
        Call Form1.picshow()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Ratio_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        TrackBar1.Value = (2 - (Form1.sizeratio * 3)) / (Form1.sizeratio - 1)
    End Sub
End Class