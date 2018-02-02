Public Class FrameSkipForm

    Private Sub FrameSkipForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        nudFrameSkip.Value = Form1.mFrameSkip
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub BtnApply_Click(sender As Object, e As EventArgs) Handles btnApply.Click
        Form1.mFrameSkip = Integer.Parse(nudFrameSkip.Value)
        Close()
    End Sub

    Private Sub LinkLabelReset_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblResetDefault.LinkClicked
        nudFrameSkip.Value = 0
    End Sub
End Class