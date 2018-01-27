Public Structure TransformationKey
    Public AgentType1 As Integer
    Public AgentType2 As Integer
    Public Sub New(type1 As Integer, type2 As Integer)
        AgentType1 = type1
        AgentType2 = type2
    End Sub

    Public Overloads Function Equals(ob As Object) As Boolean
        If TypeOf ob Is TransformationKey Then
            Dim c As TransformationKey = CType(ob, TransformationKey)
            Return AgentType1 = c.AgentType1 And AgentType2 = c.AgentType2
        Else
            Return False
        End If
    End Function

    Public Overloads Function GetHashCode() As Integer
        Return AgentType1.GetHashCode() ^ AgentType2.GetHashCode()
    End Function
End Structure