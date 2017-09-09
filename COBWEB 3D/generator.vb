Public Class generator
    Public agentcount(Form1.agent) As Integer
    Public agentname(Form1.agent) As String
    Public agentlocation(100000, 115) As Decimal
    Public agentrange(Form1.agent, 2, 1) As Integer
    Public agentrangeabsolute(Form1.agent) As Boolean
    Public agentcolour(Form1.agent) As System.Drawing.Color

    Public initialenergy(Form1.agent) As Integer
    Public stepenergy(Form1.agent) As Integer
    Public bumpenergy(Form1.agent) As Integer
    Public aging(Form1.agent) As Boolean
    Public agelimit(Form1.agent) As Integer
    Public asr(Form1.agent) As Boolean
    Public asrtime(Form1.agent) As Integer
    Public asrenergy(Form1.agent) As Integer

    Public occupied(Form1.xn, Form1.yn, Form1.zn) As Boolean
    Public action(Form1.agent, Form1.agent, 6, Form1.agent, 1) As Integer
    'it was 6, i changed it to 100
    Public maxcell As Integer = Form1.xn * Form1.zn * Form1.yn

    Public staticagent(100000) As Integer
    Public agentchange As Boolean
    Public staticagentid(Form1.agent) As Integer

    'keeps track of the probability of there being an interaction between two agents
    Public interactionprobability(Form1.agent, Form1.agent) As Decimal
    Public catalystprobability(Form1.agent, Form1.agent) As Decimal
    Public catalystproximity(Form1.agent, Form1.agent, 3) As Integer
    Public catalystagent(Form1.agent, Form1.agent) As Integer

    'keeps track of initial starting position and direction
    Public agentdirection(Form1.agent) As Integer
    Public agentstart(Form1.agent, 6) As Integer

    'allows for agents to be excluded from a particular range
    Public excludeagent(Form1.agent, 6) As Integer

    'allows for energy changes to be different in localized areas
    Public localenergychange(Form1.agent, 1000, 7) As Integer

    'allows for new agents to be produced locally (up to 1000 distinct regions are supported)
    Public localreproduction(Form1.agent, Form1.agent, Form1.agent, 3)

    'keeps track of which agents are reservoirs and their reservoir level and capacity
    Public agentreservoir(100000, 2) As Integer
    Public reservoiragentid(Form1.agent, 2) As Integer
    Public reservoirchange(Form1.agent, Form1.agent, 1) As Integer
    Public reservoiragentreleased(Form1.agent, Form1.agent, 8) As Decimal

    Public product(Form1.agent, Form1.agent, 16) As String
    Public exchange(Form1.agent, Form1.agent, 100, 10) As Decimal
    Public exchangenames(Form1.agent, Form1.agent, 100) As String
    Public agentproduct(Form1.total, 100, 2) As Decimal

    Public abiotic(Form1.agent, Form1.xn, Form1.yn, Form1.zn) As Integer
    Public abioticenable As Boolean
    Public interactioncount(Form1.agent) As Integer

    'Public tradingzones(Form1.xn, Form1.yn, Form1.zn, 1) As Decimal '0 is for the actual value of the zone, 1  is the zone that the cube belongs to
    Public zones(1000, 8) As Decimal '7 is the actual value, 1-6 are for the coordinates of the zone, 1000 different zones are possible, 8 is for the number of items traded in that zone
    Public agentsight As Decimal = 4

    Public multipleiterations(1) As Decimal

    Private Sub generator_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Hide()


        For i = 1 To Form1.agent
            agentname(i) = "Agent" & i
            initialenergy(i) = 1
        Next


        Dim red As Integer
        Dim blue As Integer
        Dim green As Integer
        Randomize()
        For i = 1 To Form1.agent
            red = CInt(Math.Floor(255 * Rnd())) + 1
            blue = CInt(Math.Floor(255 * Rnd())) + 1
            green = CInt(Math.Floor(255 * Rnd())) + 1
            agentcolour(i) = Color.FromArgb(red, green, blue)
        Next


        For i = 1 To Form1.agent
            agentrange(i, 0, 0) = 1
            agentrange(i, 1, 0) = 1
            agentrange(i, 2, 0) = 1
            agentrange(i, 0, 1) = Form1.xn
            agentrange(i, 1, 1) = Form1.yn
            agentrange(i, 2, 1) = Form1.zn
        Next


        For a = 1 To Form1.agent
            For b = 1 To Form1.agent
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
End Class