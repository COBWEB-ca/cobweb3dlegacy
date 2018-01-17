Public Class generator
    ' Agent Individual Parameters
    Public agentlocation(100000, 115) As Decimal 'Huge array of all the individual agents in the simulation

    ' Agent Type Parameterss
    Public agentcount(Form1.agentTypeCount) As Integer
    Public agentname(Form1.agentTypeCount) As String
    Public agentrange(Form1.agentTypeCount, 2, 1) As Integer
    Public agentrangeabsolute(Form1.agentTypeCount) As Boolean
    Public agentcolour(Form1.agentTypeCount) As System.Drawing.Color

    Public initialenergy(Form1.agentTypeCount) As Integer
    Public stepenergy(Form1.agentTypeCount) As Integer
    Public bumpenergy(Form1.agentTypeCount) As Integer
    Public aging(Form1.agentTypeCount) As Boolean
    Public agelimit(Form1.agentTypeCount) As Integer
    Public asr(Form1.agentTypeCount) As Boolean
    Public asrtime(Form1.agentTypeCount) As Integer
    Public asrenergy(Form1.agentTypeCount) As Integer

    Public occupied(Form1.xn, Form1.yn, Form1.zn) As Boolean
    Public maxcell As Integer = Form1.xn * Form1.zn * Form1.yn
    'it was 6, i changed it to 100
    Public action(Form1.agentTypeCount, Form1.agentTypeCount, 6, Form1.agentTypeCount, 1) As Integer

    Structure actKey
        Public AgentType1 As Integer
        Public AgentType2 As Integer
        Public Sub New(type1 As Integer, type2 As Integer)
            AgentType1 = type1
            AgentType2 = type2
        End Sub

        Public Overloads Function Equals(ob As Object) As Boolean
            If TypeOf ob Is actKey Then
                Dim c As actKey = CType(ob, actKey)
                Return AgentType1 = c.AgentType1 And AgentType2 = c.AgentType2
            Else
                Return False
            End If
        End Function

        Public Overloads Function GetHashCode() As Integer
            Return AgentType1.GetHashCode() ^ AgentType2.GetHashCode()
        End Function
    End Structure
    Public transformationPlans As New Dictionary(Of actKey, Integer)

    Public staticagent(100000) As Integer
    Public agentchange As Boolean
    Public staticagentid(Form1.agentTypeCount) As Integer

    'keeps track of the probability of there being an interaction between two agents
    Public interactionprobability(Form1.agentTypeCount, Form1.agentTypeCount) As Decimal
    Public catalystprobability(Form1.agentTypeCount, Form1.agentTypeCount) As Decimal
    Public catalystproximity(Form1.agentTypeCount, Form1.agentTypeCount, 3) As Integer
    Public catalystagent(Form1.agentTypeCount, Form1.agentTypeCount) As Integer

    'keeps track of initial starting position and direction
    Public agentdirection(Form1.agentTypeCount) As Integer
    Public agentstart(Form1.agentTypeCount, 6) As Integer

    'allows for agents to be excluded from a particular range
    Public excludeagent(Form1.agentTypeCount, 6) As Integer

    'allows for energy changes to be different in localized areas
    Public localenergychange(Form1.agentTypeCount, 1000, 7) As Integer

    'allows for new agents to be produced locally (up to 1000 distinct regions are supported)
    Public localreproduction(Form1.agentTypeCount, Form1.agentTypeCount, Form1.agentTypeCount, 3)

    'keeps track of which agents are reservoirs and their reservoir level and capacity
    Public agentreservoir(100000, 2) As Integer
    Public reservoiragentid(Form1.agentTypeCount, 2) As Integer
    Public reservoirchange(Form1.agentTypeCount, Form1.agentTypeCount, 1) As Integer
    Public reservoiragentreleased(Form1.agentTypeCount, Form1.agentTypeCount, 8) As Decimal

    Public product(Form1.agentTypeCount, Form1.agentTypeCount, 16) As String
    Public exchange(Form1.agentTypeCount, Form1.agentTypeCount, 100, 10) As Decimal
    Public exchangenames(Form1.agentTypeCount, Form1.agentTypeCount, 100) As String
    Public agentproduct(Form1.total, 100, 2) As Decimal
    Public agentTypeUtilityFunction(Form1.agentTypeCount) As Integer

    Public abiotic(Form1.agentTypeCount, Form1.xn, Form1.yn, Form1.zn) As Integer
    Public abioticenable As Boolean
    Public interactioncount(Form1.agentTypeCount) As Integer

    'Public tradingzones(Form1.xn, Form1.yn, Form1.zn, 1) As Decimal '0 is for the actual value of the zone, 1  is the zone that the cube belongs to
    Public zones(1000, 8) As Decimal '7 is the actual value, 1-6 are for the coordinates of the zone, 1000 different zones are possible, 8 is for the number of items traded in that zone
    Public agentsight As Decimal = 4

    Public multipleiterations(1) As Decimal

    Private Sub generator_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Hide()


        For i = 1 To Form1.agentTypeCount
            agentname(i) = "Agent" & i
            initialenergy(i) = 1
        Next


        Dim red As Integer
        Dim blue As Integer
        Dim green As Integer
        Randomize()
        For i = 1 To Form1.agentTypeCount
            red = CInt(Math.Floor(255 * Rnd())) + 1
            blue = CInt(Math.Floor(255 * Rnd())) + 1
            green = CInt(Math.Floor(255 * Rnd())) + 1
            agentcolour(i) = Color.FromArgb(red, green, blue)
        Next


        For i = 1 To Form1.agentTypeCount
            agentrange(i, 0, 0) = 1
            agentrange(i, 1, 0) = 1
            agentrange(i, 2, 0) = 1
            agentrange(i, 0, 1) = Form1.xn
            agentrange(i, 1, 1) = Form1.yn
            agentrange(i, 2, 1) = Form1.zn
        Next


        For a = 1 To Form1.agentTypeCount
            For b = 1 To Form1.agentTypeCount
                action(a, b, 6, 0, 0) = 2
            Next
        Next

        Array.Clear(occupied, 0, occupied.Length)

        Form1.XZTopViewToolStripMenuItem.Enabled = True
        Form1.ZYSideViewToolStripMenuItem.Enabled = True
        Form1.XYSideViewToolStripMenuItem.Enabled = False
        Form1.LogDataToolStripMenuItem.Enabled = True
        Form1.SaveProjectToolStripMenuItem.Enabled = True

        Form1.draw()
    End Sub

    Public Sub createAgent(type As Integer, x As Integer, y As Integer, z As Integer, direction As Integer, dx As Integer, dy As Integer, dz As Integer)
        If (occupied(x, y, z) = True) Then
            For i = 1 To Form1.total
                If agentlocation(i, 0) = x And agentlocation(i, 1) = y And agentlocation(i, 2) = z Then
                    If agentlocation(i, 4) <> type Then
                        agentcount(agentlocation(i, 4)) -= 1
                        agentcount(type) += 1
                    End If
                End If
            Next
        Else
            agentcount(type) += 1
            occupied(x, y, z) = True
            Form1.total += 1
        End If

        Dim index = Form1.total

        agentlocation(index, 0) = x
        agentlocation(index, 1) = y
        agentlocation(index, 2) = z
        agentlocation(index, 3) = direction
        agentlocation(index, 4) = type
        agentlocation(index, 5) = dx
        agentlocation(index, 6) = dy
        agentlocation(index, 7) = dz
        agentlocation(index, 8) = initialenergy(type)
        agentlocation(index, 9) = 0
        agentlocation(index, 10) = 0

        If staticagentid(type) = 2 Then
            staticagent(index) = 2
            If reservoiragentid(type, 1) = 2 Then
                agentreservoir(index, 0) = 2
                agentreservoir(index, 1) = reservoiragentid(type, 2)
            End If
        ElseIf staticagentid(type) = 0 Then
            staticagent(index) = 0
            agentreservoir(index, 0) = 0
            agentreservoir(index, 1) = 0
            agentreservoir(index, 2) = 0
        End If

        agentchange = True
        'For c = 1 To total
        '    If generator.staticagentid(generator.agentlocation(c, 4)) = 2 Then
        '        generator.staticagent(c) = 2
        '        If generator.reservoiragentid(generator.agentlocation(c, 4), 1) = 2 Then
        '            generator.agentreservoir(c, 0) = 2
        '            generator.agentreservoir(c, 1) = generator.reservoiragentid(generator.agentlocation(c, 4), 2)
        '        End If
        '    ElseIf generator.staticagentid(generator.agentlocation(c, 4)) = 0 Then
        '        generator.staticagent(c) = 0
        '        generator.agentreservoir(c, 0) = 0
        '        generator.agentreservoir(c, 1) = 0
        '        generator.agentreservoir(c, 2) = 0
        '    End If
        'Next

        'generator.agentcount(newAgentType) = 0
        'For f = 1 To Form1.total
        '    If generator.agentlocation(f, 4) = newAgentType Then
        '        generator.agentcount(newAgentType) += 1
        '    End If
        'Next
    End Sub

    Public Sub removeAgent(agentIndex As Integer)
        Dim x = agentlocation(agentIndex, 0)
        Dim y = agentlocation(agentIndex, 1)
        Dim z = agentlocation(agentIndex, 2)
        Dim type = agentlocation(agentIndex, 4)
        If (occupied(x, y, z) = True) Then
            agentcount(type) -= 1
            occupied(x, y, z) = False
            Form1.total -= 1
            agentlocation(agentIndex, 0) = 0
            agentlocation(agentIndex, 1) = 0
            agentlocation(agentIndex, 2) = 0
            agentlocation(agentIndex, 3) = 0
            agentlocation(agentIndex, 4) = 0
            agentlocation(agentIndex, 5) = 0
            agentlocation(agentIndex, 6) = 0
            agentlocation(agentIndex, 7) = 0
            agentlocation(agentIndex, 8) = 0
            agentlocation(agentIndex, 9) = 0
            agentlocation(agentIndex, 10) = 0
            agentchange = True
        End If
    End Sub

    Public Sub removeAgent(x As Integer, y As Integer, z As Integer)
        If (occupied(x, y, z) = True) Then
            For i = 1 To Form1.total
                If agentlocation(i, 0) = x And agentlocation(i, 1) = y And agentlocation(i, 2) = z Then
                    removeAgent(i)
                    Exit Sub
                End If
            Next
        End If
    End Sub

    Public Sub transformAgent(agentIndex As Integer, destType As Integer)
        agentlocation(agentIndex, 4) = destType
    End Sub
End Class