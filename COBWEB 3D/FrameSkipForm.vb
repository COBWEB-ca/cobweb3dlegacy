Public Class FrameSkipForm

    Private Sub FrameSkipForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Form1.mFram += 1
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub TextboxKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBxFrameSkip.KeyPress
        '97 - 122 = Ascii codes for simple letters
        '65 - 90  = Ascii codes for capital letters
        '48 - 57  = Ascii codes for numbers
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub BtnApply_Click(sender As Object, e As EventArgs) Handles BtnApply.Click

        Close()
    End Sub
End Class