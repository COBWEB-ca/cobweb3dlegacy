Public Class generator
    ' Agent Individual Parameters
    Public agentlocation(100, 22) As Decimal 'Huge array of all the individual agents in the simulation

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


    Public transformationPlans As New Dictionary(Of TransformationKey, TransformationProperties)

    Public staticagent(100000) As Integer
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
    'Public agentTypeXY(Form1.agentTypeCount, 2) As Integer
    'Public agentTypeAB(Form1.agentTypeCount, 2) As Integer

    Public abiotic(Form1.agentTypeCount, Form1.xn, Form1.yn, Form1.zn) As Integer
    Public abioticenable As Boolean
    Public interactioncount(Form1.agentTypeCount) As Integer

    'Public tradingzones(Form1.xn, Form1.yn, Form1.zn, 1) As Decimal '0 is for the actual value of the zone, 1  is the zone that the cube belongs to
    Public zones(1000, 8) As Decimal '7 is the actual value, 1-6 are for the coordinates of the zone, 1000 different zones are possible, 8 is for the number of items traded in that zone
    Public agentsight As Decimal = 4

    Public multipleiterations(1) As Decimal

    Private Sub generator_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Hide()
        ReDim agentlocation((Form1.xn * Form1.yn * Form1.zn) + 1, 22)
        ReDim staticagent((Form1.xn * Form1.yn * Form1.zn) + 1)
        ReDim agentreservoir((Form1.xn * Form1.yn * Form1.zn) + 1, 2)
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

    Public Sub resetAgents()
        ReDim agentlocation(agentlocation.GetLength(0), agentlocation.GetLength(1))
        Dim tempAgentTypeCounts(agentcount.Length)
        Array.Copy(agentcount, tempAgentTypeCounts, agentcount.Length)
        Array.Clear(agentcount, 0, agentcount.Length)
        Array.Clear(occupied, 0, occupied.Length)
        For i = 1 To Form1.agentTypeCount
            Dim type = i
            For j = 1 To tempAgentTypeCounts(type)
                Dim x As Integer = CInt(Math.Floor((Form1.xn) * Rnd())) + 1
                Dim y As Integer = CInt(Math.Floor((Form1.yn) * Rnd())) + 1
                Dim z As Integer = CInt(Math.Floor((Form1.zn) * Rnd())) + 1

                Dim dx As Integer
                Dim dy As Integer
                Dim dz As Integer

                Dim rangexupper As Integer = agentrange(type, 0, 1)
                Dim rangexlower As Integer = agentrange(type, 0, 0)
                Dim rangeyupper As Integer = agentrange(type, 1, 1)
                Dim rangeylower As Integer = agentrange(type, 1, 0)
                Dim rangezupper As Integer = agentrange(type, 2, 1)
                Dim rangezlower As Integer = agentrange(type, 2, 0)


                dx = CInt(Math.Floor((rangexupper - rangexlower + 1) * Rnd())) + rangexlower
                dy = CInt(Math.Floor((rangeyupper - rangeylower + 1) * Rnd())) + rangeylower
                dz = CInt(Math.Floor((rangezupper - rangezlower + 1) * Rnd())) + rangezlower


                Do While occupied(x, y, z) = True
                    x = CInt(Math.Floor((Form1.xn) * Rnd())) + 1
                    y = CInt(Math.Floor((Form1.yn) * Rnd())) + 1
                    z = CInt(Math.Floor((Form1.zn) * Rnd())) + 1
                Loop

                'this allows agents to start in a specific range. if all or almost all spaces in a region are occupied, the program moves onto the next agent type
                If agentstart(type, 0) = 2 Then
                    Dim maxiterations As Double
                    x = CInt(Math.Floor(((agentstart(type, 1) - agentstart(type, 2)) + 1) * Rnd()) + agentstart(type, 2))
                    y = CInt(Math.Floor(((agentstart(type, 3) - agentstart(type, 4)) + 1) * Rnd()) + agentstart(type, 4))
                    z = CInt(Math.Floor(((agentstart(type, 5) - agentstart(type, 6)) + 1) * Rnd()) + agentstart(type, 6))
                    Try
                        Do While occupied(x, y, z) = True And maxiterations < ((agentstart(type, 1) - agentstart(type, 2)) + 1) * ((agentstart(type, 3) - agentstart(type, 4)) + 1) * ((agentstart(type, 5) - agentstart(type, 6)) + 1) * 3
                            x = CInt(Math.Floor((agentstart(type, 1) - agentstart(type, 2) + 1) * Rnd()) + agentstart(type, 2))
                            y = CInt(Math.Floor((agentstart(type, 3) - agentstart(type, 4) + 1) * Rnd()) + agentstart(type, 4))
                            z = CInt(Math.Floor((agentstart(type, 5) - agentstart(type, 6) + 1) * Rnd()) + agentstart(type, 6))
                            maxiterations += 1
                        Loop
                        If maxiterations >= ((agentstart(type, 1) - agentstart(type, 2)) + 1) * ((agentstart(type, 3) - agentstart(type, 4)) + 1) * ((agentstart(type, 5) - agentstart(type, 6)) + 1) * 3 Then
                            Continue For
                        End If
                    Catch ex As Exception
                        MessageBox.Show(x & " " & y & " " & z)
                    End Try
                End If

                Dim Offset = If(i > 1, tempAgentTypeCounts(type), 0)
                createAgent(type, x, y, z, CInt(Math.Floor((6) * Rnd())) + 1, dx, dy, dz)
            Next
        Next
    End Sub

    Private Sub addAgent(index As Integer, type As Integer, x As Integer, y As Integer, z As Integer, direction As Integer, dx As Integer, dy As Integer, dz As Integer)
        'If (index >= agentlocation.GetLength(0)) Then TODO: Adapt size later?
        '    Dim temp(agentlocation.GetLength(0) * 2, agentlocation.GetLength(1)) As Decimal
        '    Array.ConstrainedCopy(agentlocation, 0, temp, 0, agentlocation.Length)
        '    agentlocation = temp
        'End If
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
    End Sub

    Private Sub createAgent(countChanges As Boolean, type As Integer, x As Integer, y As Integer, z As Integer, direction As Integer, dx As Integer, dy As Integer, dz As Integer)
        If (countChanges) Then
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
        End If
        addAgent(Form1.total, type, x, y, z, direction, dx, dy, dz)
        'generator.agentcount(newAgentType) = 0
        'For f = 1 To Form1.total
        '    If generator.agentlocation(f, 4) = newAgentType Then
        '        generator.agentcount(newAgentType) += 1
        '    End If
        'Next
    End Sub

    Public Sub createAgent(type As Integer, x As Integer, y As Integer, z As Integer, direction As Integer, dx As Integer, dy As Integer, dz As Integer)
        createAgent(True, type, x, y, z, direction, dx, dy, dz)
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
            For i = 0 To agentlocation.GetLength(1) - 1
                agentlocation(agentIndex, i) = 0
            Next
            staticagent(agentIndex) = 0
            For i = 0 To agentreservoir.GetLength(1) - 1
                agentreservoir(agentIndex, i) = 0
            Next
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
        agentcount(agentlocation(agentIndex, 4)) -= 1
        agentlocation(agentIndex, 4) = destType
        agentcount(agentlocation(destType, 4)) += 1
    End Sub

    Public Sub swapAgentIndices(srcAgentIndex As Integer, dstAgentIndex As Integer)
        ' Destination -> Temp
        Dim tempAgentParams(agentlocation.GetLength(1)) As Decimal
        For i = 0 To agentlocation.GetLength(1) - 1
            tempAgentParams(i) = agentlocation(dstAgentIndex, i)
        Next
        Dim tempStaticParam As Integer = staticagent(dstAgentIndex)
        Dim tempReservoirParams(agentreservoir.GetLength(1)) As Integer
        For i = 0 To agentreservoir.GetLength(1) - 1
            tempReservoirParams(i) = agentreservoir(dstAgentIndex, i)
        Next

        ' Source -> Destination
        For i = 0 To agentlocation.GetLength(1) - 1
            agentlocation(dstAgentIndex, i) = agentlocation(srcAgentIndex, i)
        Next
        staticagent(dstAgentIndex) = staticagent(srcAgentIndex)
        For i = 0 To agentreservoir.GetLength(1) - 1
            agentreservoir(dstAgentIndex, i) = agentreservoir(srcAgentIndex, i)
        Next

        ' Temp -> Source
        For i = 0 To agentlocation.GetLength(1) - 1
            agentlocation(srcAgentIndex, i) = tempAgentParams(i)
        Next
        staticagent(srcAgentIndex) = tempStaticParam
        For i = 0 To agentreservoir.GetLength(1) - 1
            agentreservoir(srcAgentIndex, i) = tempReservoirParams(i)
        Next
    End Sub
End Class