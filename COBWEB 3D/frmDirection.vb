﻿Public Class frmDirection
    Private Sub frmDirection_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If frmCrossSection.selectedDirection = 2 Then
            RadioButton1.Checked = True
        ElseIf frmCrossSection.selectedDirection = 1 Then
            RadioButton2.Checked = True
        ElseIf frmCrossSection.selectedDirection = 3 Then
            RadioButton3.Checked = True
        ElseIf frmCrossSection.selectedDirection = 4 Then
            RadioButton4.Checked = True
        ElseIf frmCrossSection.selectedDirection = 6 Then
            RadioButton5.Checked = True
        ElseIf frmCrossSection.selectedDirection = 5 Then
            RadioButton6.Checked = True
        ElseIf frmCrossSection.selectedDirection = 0 Then
            RadioButton7.Checked = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If RadioButton1.Checked = True Then
            frmCrossSection.selectedDirection = 2
        ElseIf RadioButton2.Checked = True Then
            frmCrossSection.selectedDirection = 1
        ElseIf RadioButton3.Checked = True Then
            frmCrossSection.selectedDirection = 3
        ElseIf RadioButton4.Checked = True Then
            frmCrossSection.selectedDirection = 4
        ElseIf RadioButton5.Checked = True Then
            frmCrossSection.selectedDirection = 6
        ElseIf RadioButton6.Checked = True Then
            frmCrossSection.selectedDirection = 5
        ElseIf RadioButton7.Checked = True Then
            frmCrossSection.selectedDirection = 0
        End If
        Me.Close()
    End Sub
End Class
