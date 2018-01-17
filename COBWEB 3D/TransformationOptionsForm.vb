Public Class TransformationOptionsForm
    Private agentType1Index As Integer
    Private agentType2Index As Integer
    Private mGenerator As generator

    Public Sub New(ByRef generator As generator, holderATypeIndex As Integer, holderBTypeIndex As Integer)
        MyBase.New()
        InitializeComponent() ' This call is required by the Windows Form Designer.
        mGenerator = generator
        agentType1Index = holderATypeIndex
        agentType2Index = holderBTypeIndex
    End Sub

    Private Sub AddRangeSkipNulls(items As ComboBox.ObjectCollection, itemsToAdd As Object())
        For Each item As Object In itemsToAdd
            If item IsNot Nothing Then items.Add(item)
        Next
    End Sub

    Private Sub TransformationOptionsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CboxAgent1.Text = String.Format("{0} transforms to type: ", mGenerator.agentname(agentType1Index))
        CboxAgent2.Text = String.Format("{0} transforms to type: ", mGenerator.agentname(agentType2Index))

        AddRangeSkipNulls(ComboAgent1.Items, mGenerator.agentname)
        AddRangeSkipNulls(ComboAgent2.Items, mGenerator.agentname)
        ComboAgent1.Enabled = False
        ComboAgent2.Enabled = False
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CboxAgent1.CheckedChanged
        ComboAgent1.Enabled = CboxAgent1.Checked
    End Sub

    Private Sub CboxAgent2_CheckedChanged(sender As Object, e As EventArgs) Handles CboxAgent2.CheckedChanged
        ComboAgent2.Enabled = CboxAgent2.Checked
    End Sub

    Private Sub BtnApply_Click(sender As Object, e As EventArgs) Handles BtnApply.Click
        If (CboxAgent1.Checked) Then
            Dim selectedDestAgent = ComboAgent1.SelectedItem
            If (selectedDestAgent IsNot Nothing) Then
                Dim index = 0
                For i = 1 To mGenerator.agentname.Length
                    If (mGenerator.agentname(i).Equals(selectedDestAgent)) Then
                        ' TODO: handle.
                        mGenerator.transformationPlans.Add(New generator.actKey(agentType1Index, agentType2Index), selectedDestAgent)
                        Exit For
                    End If
                Next
            End If
        End If

        If (CboxAgent2.Checked) Then
            Dim selectedDestAgent = ComboAgent2.SelectedItem
            If (selectedDestAgent IsNot Nothing) Then
                Dim index = 0
                For i = 1 To mGenerator.agentname.Length
                    If (mGenerator.agentname(i).Equals(selectedDestAgent)) Then
                        ' TODO: handle.
                        mGenerator.transformationPlans.Add(New generator.actKey(agentType2Index, agentType1Index), selectedDestAgent)
                        Exit For
                    End If
                Next
            End If
        End If
        Close()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
End Class