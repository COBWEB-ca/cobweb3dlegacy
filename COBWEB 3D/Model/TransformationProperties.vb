Public Structure TransformationProperties
    Public destType As Integer
    Public xThreshold As Integer
    Public Sub New(destinationType As Integer, xTriggerhreshold As Integer)
        destType = destinationType
        xThreshold = xTriggerhreshold
    End Sub

    Public Overloads Function Equals(ob As Object) As Boolean
        If TypeOf ob Is TransformationProperties Then
            Dim c As TransformationProperties = CType(ob, TransformationProperties)
            Return destType = c.destType And xThreshold = c.xThreshold
        Else
            Return False
        End If
    End Function

    Public Overloads Function GetHashCode() As Integer
        Return destType.GetHashCode() ^ xThreshold.GetHashCode()
    End Function
End Structure
