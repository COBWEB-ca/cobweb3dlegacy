Public Class generator
    Public picxy As New Bitmap(Form1.sizexyx, Form1.sizexyy)
    Public gfxxy As Graphics = System.Drawing.Graphics.FromImage(picxy)

    Public picxz As New Bitmap(Form1.sizexzx, Form1.sizexzz)
    Public gfxxz As Graphics = System.Drawing.Graphics.FromImage(picxz)

    Public picCrossSection As New Bitmap(Form1.sizexyx, Form1.sizexyy)
    Public gfCrossSection As Graphics = System.Drawing.Graphics.FromImage(picCrossSection)

    Public piczy As New Bitmap(Form1.sizezyz, Form1.sizezyy)
    Public gfxzy As Graphics = System.Drawing.Graphics.FromImage(piczy)

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

    Sub topgridxy()

        Dim overgrid As System.Drawing.Pen = New Pen(Brushes.Black, 2)

        For x = 0 To Form1.yn
            gfxxy.DrawLine(overgrid, 0, Form1.cellxyy * x, Form1.sizexyx, Form1.cellxyy * x)
        Next

        For y = 0 To Form1.xn
            gfxxy.DrawLine(overgrid, Form1.cellxyx * y, 0, Form1.cellxyx * y, Form1.sizexyy)
        Next

    End Sub


    Sub topgridxz()

        Dim overgrid As System.Drawing.Pen = New Pen(Brushes.Black, 2)

        For x = 0 To Form1.zn
            gfxxz.DrawLine(overgrid, 0, Form1.cellxzz * x, Form1.sizexzx, Form1.cellxzz * x)
        Next

        For y = 0 To Form1.xn
            gfxxz.DrawLine(overgrid, Form1.cellxzx * y, 0, Form1.cellxzx * y, Form1.sizexzz)
        Next

    End Sub

    Sub topgridzy()
        Dim overgrid As System.Drawing.Pen = New Pen(Brushes.Black, 2)

        For x = 0 To Form1.yn
            gfxzy.DrawLine(overgrid, 0, Form1.cellzyy * x, Form1.sizezyz, Form1.cellzyy * x)
        Next

        For y = 0 To Form1.zn
            gfxzy.DrawLine(overgrid, Form1.cellzyz * y, 0, Form1.cellzyz * y, Form1.sizezyy)
        Next
    End Sub


    Sub gridxy()
        Dim angle As Single = Math.Atan(Form1.xn / Form1.yn)
        Dim backgrid As System.Drawing.Pen = New Pen(Brushes.DarkGray, 1)
        Dim skeleton As System.Drawing.Pen = New Pen(Brushes.Gray, 1)
        Dim light As System.Drawing.Pen = New Pen(Brushes.Silver, 1)

        Dim diag As Single
        Dim jump As Single = Form1.cellxyx
        Dim a As Integer
        Dim b As Integer

        For i = 1 To Form1.zn
            jump = jump * (Form1.sizeratio)
            diag = diag + jump
            a = Math.Sin(angle) * diag
            b = Math.Cos(angle) * diag
            gfxxy.DrawLine(backgrid, a, b, Form1.sizexyx - a, b)
            gfxxy.DrawLine(backgrid, a, Form1.sizexyy - b, Form1.sizexyx - a, Form1.sizexyy - b)
            gfxxy.DrawLine(backgrid, a, b, a, Form1.sizexyy - b)
            gfxxy.DrawLine(backgrid, Form1.sizexyx - a, b, Form1.sizexyx - a, Form1.sizexyy - b)
            If i = Form1.zn Then
                Dim cell As Single
                Dim celly As Single
                cell = (Form1.sizexyx - (a * 2)) / Form1.xn
                celly = (Form1.sizexyy - (b * 2)) / Form1.yn
                For j = 1 To Form1.xn - 1
                    gfxxy.DrawLine(backgrid, a + (cell * j), b, (Form1.cellxyx * j), 0)
                    gfxxy.DrawLine(backgrid, a + (cell * j), Form1.sizexyy - b, (Form1.cellxyx * j), Form1.sizexyy)
                    gfxxy.DrawLine(light, a + (cell * j), b, a + (cell * j), Form1.sizexyy - b)
                Next

                For k = 1 To Form1.yn - 1
                    gfxxy.DrawLine(backgrid, a, b + (celly * k), 0, (Form1.cellxyy * k))
                    gfxxy.DrawLine(backgrid, Form1.sizexyx, (Form1.cellxyy * k), Form1.sizexyx - a, b + (celly * k))
                    gfxxy.DrawLine(light, a, b + (celly * k), Form1.sizexyx - a, b + (celly * k))
                Next
            End If
        Next

        a = Math.Sin(angle) * diag
        b = Math.Cos(angle) * diag

        gfxxy.DrawLine(skeleton, 0, 0, a, b)
        gfxxy.DrawLine(skeleton, Form1.sizexyx, 0, Form1.sizexyx - a, b)
        gfxxy.DrawLine(skeleton, 0, Form1.sizexyy, a, Form1.sizexyy - b)
        gfxxy.DrawLine(skeleton, Form1.sizexyx, Form1.sizexyy, Form1.sizexyx - a, Form1.sizexyy - b)
    End Sub

    Sub gridxz()
        Dim angle As Single = Math.Atan(Form1.xn / Form1.zn)
        Dim backgrid As System.Drawing.Pen = New Pen(Brushes.DarkGray, 1)
        Dim skeleton As System.Drawing.Pen = New Pen(Brushes.Gray, 1)
        Dim light As System.Drawing.Pen = New Pen(Brushes.Silver, 1)

        Dim diag As Single
        Dim jump As Single = Form1.cellxzx
        Dim a As Integer
        Dim b As Integer

        For i = 1 To Form1.yn
            jump = jump * (Form1.sizeratio)
            diag = diag + jump
            a = Math.Sin(angle) * diag
            b = Math.Cos(angle) * diag
            gfxxz.DrawLine(backgrid, a, b, Form1.sizexzx - a, b)
            gfxxz.DrawLine(backgrid, a, Form1.sizexzz - b, Form1.sizexzx - a, Form1.sizexzz - b)
            gfxxz.DrawLine(backgrid, a, b, a, Form1.sizexzz - b)
            gfxxz.DrawLine(backgrid, Form1.sizexzx - a, b, Form1.sizexzx - a, Form1.sizexzz - b)
            If i = Form1.yn Then
                Dim cell As Single
                Dim cellz As Single
                cell = (Form1.sizexzx - (a * 2)) / Form1.xn
                cellz = (Form1.sizexzz - (b * 2)) / Form1.zn
                For j = 1 To Form1.xn - 1
                    gfxxz.DrawLine(backgrid, a + (cell * j), b, (Form1.cellxzx * j), 0)
                    gfxxz.DrawLine(backgrid, a + (cell * j), Form1.sizexzz - b, (Form1.cellxzx * j), Form1.sizexzz)
                    gfxxz.DrawLine(light, a + (cell * j), b, a + (cell * j), Form1.sizexzz - b)
                Next

                For k = 1 To Form1.zn - 1
                    gfxxz.DrawLine(backgrid, a, b + (cellz * k), 0, (Form1.cellxzz * k))
                    gfxxz.DrawLine(backgrid, Form1.sizexzx, (Form1.cellxzz * k), Form1.sizexzx - a, b + (cellz * k))
                    gfxxz.DrawLine(light, a, b + (cellz * k), Form1.sizexzx - a, b + (cellz * k))
                Next
            End If
        Next

        a = Math.Sin(angle) * diag
        b = Math.Cos(angle) * diag

        gfxxz.DrawLine(skeleton, 0, 0, a, b)
        gfxxz.DrawLine(skeleton, Form1.sizexzx, 0, Form1.sizexzx - a, b)
        gfxxz.DrawLine(skeleton, 0, Form1.sizexzz, a, Form1.sizexzz - b)
        gfxxz.DrawLine(skeleton, Form1.sizexzx, Form1.sizexzz, Form1.sizexzx - a, Form1.sizexzz - b)
    End Sub

    Sub gridzy()
        Dim angle As Single = Math.Atan(Form1.zn / Form1.yn)
        Dim backgrid As System.Drawing.Pen = New Pen(Brushes.DarkGray, 1)
        Dim skeleton As System.Drawing.Pen = New Pen(Brushes.Gray, 1)
        Dim light As System.Drawing.Pen = New Pen(Brushes.Silver, 1)

        Dim diag As Single
        Dim jump As Single = Form1.cellzyz
        Dim a As Integer
        Dim b As Integer

        For i = 1 To Form1.xn
            jump = jump * (Form1.sizeratio)
            diag = diag + jump
            a = Math.Sin(angle) * diag
            b = Math.Cos(angle) * diag
            gfxzy.DrawLine(backgrid, a, b, Form1.sizezyz - a, b)
            gfxzy.DrawLine(backgrid, a, Form1.sizezyy - b, Form1.sizezyz - a, Form1.sizezyy - b)
            gfxzy.DrawLine(backgrid, a, b, a, Form1.sizezyy - b)
            gfxzy.DrawLine(backgrid, Form1.sizezyz - a, b, Form1.sizezyz - a, Form1.sizezyy - b)
            If i = Form1.xn Then
                Dim cell As Integer
                Dim celly As Integer
                cell = (Form1.sizezyz - (a * 2)) / Form1.zn
                celly = (Form1.sizezyy - (b * 2)) / Form1.yn
                For j = 1 To Form1.zn - 1
                    gfxzy.DrawLine(backgrid, a + (cell * j), b, (Form1.cellzyz * j), 0)
                    gfxzy.DrawLine(backgrid, a + (cell * j), Form1.sizezyy - b, (Form1.cellzyz * j), Form1.sizezyy)
                    gfxzy.DrawLine(light, a + (cell * j), b, a + (cell * j), Form1.sizezyy - b)
                Next

                For k = 1 To Form1.yn - 1
                    gfxzy.DrawLine(backgrid, a, b + (celly * k), 0, (Form1.cellzyy * k))
                    gfxzy.DrawLine(backgrid, Form1.sizezyz, (Form1.cellzyy * k), Form1.sizezyz - a, b + (celly * k))
                    gfxzy.DrawLine(light, a, b + (celly * k), Form1.sizezyz - a, b + (celly * k))
                Next
            End If
        Next

        a = Math.Sin(angle) * diag
        b = Math.Cos(angle) * diag

        gfxzy.DrawLine(skeleton, 0, 0, a, b)
        gfxzy.DrawLine(skeleton, Form1.sizezyz, 0, Form1.sizezyz - a, b)
        gfxzy.DrawLine(skeleton, 0, Form1.sizezyy, a, Form1.sizezyy - b)
        gfxzy.DrawLine(skeleton, Form1.sizezyz, Form1.sizezyy, Form1.sizezyz - a, Form1.sizezyy - b)
    End Sub

    Sub occupiedneg()
        For x = 1 To Form1.xn
            For y = 1 To Form1.yn
                For z = 1 To Form1.zn
                    occupied(x, y, z) = False
                Next
            Next
        Next
    End Sub


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


        Form1.TopViewToolStripMenuItem.Enabled = True
        Form1.SideViewToolStripMenuItem1.Enabled = True
        Form1.SideViewToolStripMenuItem.Enabled = False
        Form1.LogDataToolStripMenuItem.Enabled = True
        Form1.SaveProjectToolStripMenuItem.Enabled = True

        gfxxy.Clear(Color.White)

        Form1.viewlabel.Text = "Side View (x,y)"



        Call gridxy()





        Call occupiedneg()



        'For a = 0 To Form1.agent - 1
        'Dim agentcount As Integer = Integer.Parse(Form1.count.Substring((a * 6), 5))
        ' For i = 1 To agentcount
        'Randomize()
        ' Dim x As Integer = CInt(Math.Floor((Form1.xn - 1 + 1) * Rnd())) + 1
        'Dim y As Integer = CInt(Math.Floor((Form1.yn - 1 + 1) * Rnd())) + 1
        'Dim z As Integer = CInt(Math.Floor((Form1.zn - 1 + 1) * Rnd())) + 1
        'Dim directioninteger As Integer = CInt(Math.Floor((6 - 1 + 1) * Rnd())) + 1
        'Dim directionstring As String
        'If directioninteger = 1 Then
        ''directionstring = "up"
        ' ElseIf directioninteger = 2 Then
        ' directionstring = "down"
        ' ElseIf directioninteger = 3 Then
        ' directionstring = "right"
        ' ElseIf directioninteger = 4 Then
        'directionstring = "left"
        'ElseIf directioninteger = 5 Then
        'directionstring = "front"
        ' ElseIf directioninteger = 6 Then
        ' directionstring = "back"
        ' End If
        ' Call Form1.creator(x, y, z, directionstring)
        'Next
        'Next






        Call topgridxy()


        Call Form1.picshow()

    End Sub
End Class
