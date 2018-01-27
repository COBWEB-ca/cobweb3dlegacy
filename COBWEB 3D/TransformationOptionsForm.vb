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
        Dim key1 As New TransformationKey(agentType1Index, agentType2Index)
        Dim key2 As New TransformationKey(agentType2Index, agentType1Index)
        Dim prop As New TransformationProperties
        If (mGenerator.transformationPlans.TryGetValue(key1, prop)) Then
            ComboAgent1.Enabled = True
            ComboAgent1.SelectedItem = mGenerator.agentname(prop.destType)
            TbxAgent1.Text = prop.xThreshold.ToString()
            CboxAgent1.Checked = True
        Else
            ComboAgent1.Enabled = False
            CboxAgent1.Checked = False
        End If
        If (mGenerator.transformationPlans.TryGetValue(key2, prop)) Then
            ComboAgent2.Enabled = True
            ComboAgent2.SelectedItem = mGenerator.agentname(prop.destType)
            TbxAgent2.Text = prop.xThreshold.ToString()
            CboxAgent2.Checked = True
        Else
            ComboAgent2.Enabled = False
            CboxAgent2.Checked = False
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CboxAgent1.CheckedChanged
        ComboAgent1.Enabled = CboxAgent1.Checked
    End Sub

    Private Sub CboxAgent2_CheckedChanged(sender As Object, e As EventArgs) Handles CboxAgent2.CheckedChanged
        ComboAgent2.Enabled = CboxAgent2.Checked
    End Sub

    Private Sub TextboxKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TbxAgent1.KeyPress, TbxAgent2.KeyPress
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
        If (CboxAgent1.Checked) Then
            Dim selectedDestAgent = ComboAgent1.SelectedItem
            If (selectedDestAgent IsNot Nothing) Then
                For i = 1 To mGenerator.agentname.Length
                    If (mGenerator.agentname(i).Equals(selectedDestAgent)) Then
                        Dim threshold = Integer.Parse(TbxAgent1.Text)
                        Dim transProp As New TransformationProperties(i, threshold)
                        Dim key As New TransformationKey(agentType1Index, agentType2Index)
                        If (mGenerator.transformationPlans.ContainsKey(key)) Then mGenerator.transformationPlans.Remove(key)
                        mGenerator.transformationPlans.Add(key, transProp)
                        Exit For
                    End If
                Next
            End If
        End If

        If (CboxAgent2.Checked) Then
            Dim selectedDestAgent = ComboAgent2.SelectedItem
            If (selectedDestAgent IsNot Nothing) Then
                For i = 1 To mGenerator.agentname.Length
                    If (mGenerator.agentname(i).Equals(selectedDestAgent)) Then
                        Dim threshold = Integer.Parse(TbxAgent2.Text)
                        Dim transProp As New TransformationProperties(i, threshold)
                        Dim key As New TransformationKey(agentType2Index, agentType1Index)
                        If (mGenerator.transformationPlans.ContainsKey(key)) Then mGenerator.transformationPlans.Remove(key)
                        mGenerator.transformationPlans.Add(key, transProp)
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