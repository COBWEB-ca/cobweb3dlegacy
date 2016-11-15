Public Class Form1
    'the variables for the resolution of the pic
    Public sizexyx As Integer
    Public sizexyy As Integer


    Public sizexzx As Integer
    Public sizexzz As Integer

    Public sizezyy As Integer
    Public sizezyz As Integer

    Public tick As Integer
    Public sizeratio As Double = 3 / 4

    Public agent As Integer
    Public total As Integer


    'the variables for the size of grid
    Public xn As Integer
    Public yn As Integer
    Public zn As Integer

    'size of each cell
    Public cellxyx As Single
    Public cellxyy As Single
    Public cellxzx As Single
    Public cellxzz As Single
    Public cellzyz As Single
    Public cellzyy As Single

    Dim havetodelete As Integer
    Public view As String

    Public save As String
    Public timerexit As Boolean = False

    'codes for excel file
    Private oExcel As Object
    Private oBook As Object
    Private oSheet As Object
    Private oSheet2 As Object
    Private logged As Boolean = False
    Private exceldir As String

    Public visualizerange As Integer

    Private localregion As Integer

    Private progressbartest As Integer

    Sub picshow()
        PictureBox1.Image = generator.picxy
    End Sub

    'x,y view
    Sub creator(ByVal xlocation As String, ByVal ylocation As Integer, ByVal zlocation As Integer, ByVal direction As Integer, ByVal colour As System.Drawing.Color, ByVal s As Integer)
        Dim diag As Single
        Dim jump As Double = cellxyx
        For i = 1 To zlocation - 1
            jump = jump * (sizeratio)
            diag = diag + jump
        Next
        Dim angle As Single = Math.Atan(xn / yn)
        Dim a As Integer = Math.Sin(angle) * diag
        Dim b As Integer = Math.Cos(angle) * diag

        Dim topfrontrightx As Integer = a + (xlocation * ((sizexyx - (2 * a)) / xn))
        Dim topfrontrighty As Integer = b + ((ylocation - 1) * ((sizexyy - (2 * b)) / yn))
        Dim topfrontleftx As Integer = a + ((xlocation - 1) * ((sizexyx - (2 * a)) / xn))
        Dim topfrontlefty As Integer = b + ((ylocation - 1) * ((sizexyy - (2 * b)) / yn))

        Dim bottomfrontrightx As Integer = a + (xlocation * ((sizexyx - (2 * a)) / xn))
        Dim bottomfrontrighty As Integer = b + (ylocation * ((sizexyy - (2 * b)) / yn))
        Dim bottomfrontleftx As Integer = a + ((xlocation - 1) * ((sizexyx - (2 * a)) / xn))
        Dim bottomfrontlefty As Integer = b + (ylocation * ((sizexyy - (2 * b)) / yn))

        jump = jump * (sizeratio)
        diag = diag + jump

        angle = Math.Atan(xn / yn)
        a = Math.Sin(angle) * diag
        b = Math.Cos(angle) * diag

        Dim topbackrightx As Integer = a + (xlocation * ((sizexyx - (2 * a)) / xn))
        Dim topbackrighty As Integer = b + ((ylocation - 1) * ((sizexyy - (2 * b)) / yn))
        Dim topbackleftx As Integer = a + ((xlocation - 1) * ((sizexyx - (2 * a)) / xn))
        Dim topbacklefty As Integer = b + ((ylocation - 1) * ((sizexyy - (2 * b)) / yn))

        Dim bottombackrightx As Integer = a + (xlocation * ((sizexyx - (2 * a)) / xn))
        Dim bottombackrighty As Integer = b + (ylocation * ((sizexyy - (2 * b)) / yn))
        Dim bottombackleftx As Integer = a + ((xlocation - 1) * ((sizexyx - (2 * a)) / xn))
        Dim bottombacklefty As Integer = b + (ylocation * ((sizexyy - (2 * b)) / yn))


        'generator.gfxxy.DrawLine(Pens.Red, topfrontleftx, topfrontlefty, topfrontrightx, topfrontrighty)
        'generator.gfxxy.DrawLine(Pens.Red, bottomfrontleftx, bottomfrontlefty, bottomfrontrightx, bottomfrontrighty)
        'generator.gfxxy.DrawLine(Pens.Red, topbackleftx, topbacklefty, topbackrightx, topbackrighty)
        'generator.gfxxy.DrawLine(Pens.Red, bottombackleftx, bottombacklefty, bottombackrightx, bottombackrighty)



        Dim topfrontright As New System.Drawing.Point(topfrontrightx, topfrontrighty)
        Dim topfrontleft As New System.Drawing.Point(topfrontleftx, topfrontlefty)
        Dim bottomfrontright As New System.Drawing.Point(bottomfrontrightx, bottomfrontrighty)
        Dim bottomfrontleft As New System.Drawing.Point(bottomfrontleftx, bottomfrontlefty)


        Dim topbackright As New System.Drawing.Point(topbackrightx, topbackrighty)
        Dim topbackleft As New System.Drawing.Point(topbackleftx, topbacklefty)
        Dim bottombackright As New System.Drawing.Point(bottombackrightx, bottombackrighty)
        Dim bottombackleft As New System.Drawing.Point(bottombackleftx, bottombacklefty)


        Dim dashValues As Single() = {1, 2}
        Dim graypen As New Pen(Color.Gray, 1)
        Dim myBrush As New SolidBrush(colour)
        graypen.DashPattern = dashValues

        'draws cubes for static agents
        If generator.staticagent(s) = 2 Then
            Dim backface As Point() = {topbackleft, topbackright, bottombackright, bottombackleft}
            Dim rightface As Point() = {topbackright, bottombackright, bottomfrontright, topfrontright}
            Dim leftface As Point() = {topbackleft, bottombackleft, bottomfrontleft, topfrontleft}
            Dim topface As Point() = {topbackleft, topbackright, topfrontright, topfrontleft}
            Dim bottomface As Point() = {bottombackleft, bottombackright, bottomfrontright, bottomfrontleft}
            Dim frontface As Point() = {topfrontright, topfrontleft, bottomfrontleft, bottomfrontright}
            Dim brush As New SolidBrush(Color.FromArgb(150, colour.R, colour.G, colour.B))

            generator.gfxxy.FillPolygon(brush, backface)
            generator.gfxxy.FillPolygon(brush, rightface)
            generator.gfxxy.FillPolygon(brush, leftface)
            generator.gfxxy.FillPolygon(brush, topface)
            generator.gfxxy.FillPolygon(brush, bottomface)

            If generator.agentreservoir(s, 0) = 0 Then
                generator.gfxxy.FillPolygon(brush, frontface)
            End If

            generator.gfxxy.DrawLine(Pens.Gray, topbackleft, topbackright)
            generator.gfxxy.DrawLine(Pens.Gray, topbackright, bottombackright)
            generator.gfxxy.DrawLine(Pens.Gray, bottombackright, bottombackleft)
            generator.gfxxy.DrawLine(Pens.Gray, bottombackleft, topbackleft)

            generator.gfxxy.DrawLine(Pens.Gray, topbackleft, topfrontleft)
            generator.gfxxy.DrawLine(Pens.Gray, topbackright, topfrontright)
            generator.gfxxy.DrawLine(Pens.Gray, bottombackright, bottomfrontright)
            generator.gfxxy.DrawLine(Pens.Gray, bottombackleft, bottomfrontleft)

            generator.gfxxy.DrawLine(Pens.Gray, topfrontleft, topfrontright)
            generator.gfxxy.DrawLine(Pens.Gray, topfrontright, bottomfrontright)
            generator.gfxxy.DrawLine(Pens.Gray, bottomfrontright, bottomfrontleft)
            generator.gfxxy.DrawLine(Pens.Gray, bottomfrontleft, topfrontleft)

            If generator.agentreservoir(s, 0) = 2 Then
                'new code - bars that show the capacity of the static agent
                Dim scalingfactor As Decimal = (topfrontrightx - topfrontleftx) * 0.25
                Dim progressbarlength As Decimal = Math.Abs(topfrontrighty - bottomfrontrighty)

                Dim capacity As Decimal = generator.agentreservoir(s, 1)
                Dim actuallevel As Decimal = generator.agentreservoir(s, 2)
                If actuallevel >= capacity Then
                    actuallevel = capacity
                End If

                Dim progressbarscalingfactor As Decimal = 0
                If capacity > 0 Then
                    progressbarscalingfactor = actuallevel / capacity
                End If

                Dim topfrontrightleftx As Integer = topfrontrightx - scalingfactor
                Dim topfrontrightrightx As Integer = topfrontrightx

                Dim bottomfrontrightleftx As Integer = bottomfrontrightx - scalingfactor
                Dim bottomfrontrightrightx As Integer = bottomfrontrightx

                Dim topfrontrightleft As New System.Drawing.Point(topfrontrightleftx, topfrontrighty)
                Dim topfrontrightright As New System.Drawing.Point(topfrontrightrightx, topfrontrighty)

                Dim bottomfrontrightleft As New System.Drawing.Point(bottomfrontrightleftx, bottomfrontrighty)
                Dim bottomfrontrightright As New System.Drawing.Point(bottomfrontrightrightx, bottomfrontrighty)

                Dim newy As Decimal = bottomfrontrighty - (progressbarlength * progressbarscalingfactor)
                Dim progressbarlefttop As New System.Drawing.Point(bottomfrontrightleftx, newy)
                Dim progressbarrighttop As New System.Drawing.Point(bottomfrontrightx, newy)
                generator.gfxxy.DrawLine(Pens.Black, progressbarlefttop, progressbarrighttop)

                Dim frontfaceleft As Point() = {topfrontrightleft, topfrontleft, bottomfrontleft, bottomfrontrightleft}
                Dim frontfaceright As Point() = {topfrontright, bottomfrontright, bottomfrontrightleft, topfrontrightleft}
                Dim frontfacerightbar As Point() = {bottomfrontright, bottomfrontrightleft, progressbarlefttop, progressbarrighttop}
                Dim frontfacebarfiller As Point() = {topfrontright, topfrontrightleft, progressbarlefttop, progressbarrighttop}

                Dim col As New SolidBrush(Color.FromArgb(150, Color.White.R, Color.White.G, Color.White.B))
                Dim bar As New SolidBrush(Color.FromArgb(150, Color.GreenYellow.R, Color.GreenYellow.G, Color.GreenYellow.B))

                'generator.gfxxy.FillPolygon(col, frontfaceright)
                generator.gfxxy.FillPolygon(brush, frontfaceleft)
                generator.gfxxy.FillPolygon(col, frontfacebarfiller)
                generator.gfxxy.FillPolygon(bar, frontfacerightbar)
                'new code
            End If

            Exit Sub
        End If

        If direction = 6 Then

            Dim beakx As Integer = topbackleftx + (Math.Abs(topbackleftx - topbackrightx) / 2)
            Dim beaky As Integer = topbacklefty + (Math.Abs(topbacklefty - bottombacklefty) / 2)
            Dim beak As New System.Drawing.Point(beakx, beaky)

            Dim top As Point() = {topfrontleft, beak, topfrontright}
            Dim right As Point() = {topfrontright, beak, bottomfrontright}
            Dim bottom As Point() = {bottomfrontleft, beak, bottomfrontright}
            Dim left As Point() = {topfrontleft, beak, bottomfrontleft}
            generator.gfxxy.FillPolygon(myBrush, top)
            generator.gfxxy.FillPolygon(myBrush, right)
            generator.gfxxy.FillPolygon(myBrush, bottom)
            generator.gfxxy.FillPolygon(myBrush, left)

            generator.gfxxy.DrawLine(graypen, topfrontleft, beak)
            generator.gfxxy.DrawLine(graypen, bottomfrontleft, beak)
            generator.gfxxy.DrawLine(graypen, bottomfrontright, beak)
            generator.gfxxy.DrawLine(graypen, topfrontright, beak)

            generator.gfxxy.DrawLine(Pens.Gray, topfrontleft, topfrontright)
            generator.gfxxy.DrawLine(Pens.Gray, topfrontright, bottomfrontright)
            generator.gfxxy.DrawLine(Pens.Gray, bottomfrontright, bottomfrontleft)
            generator.gfxxy.DrawLine(Pens.Gray, bottomfrontleft, topfrontleft)

        ElseIf direction = 5 Then
            Dim beakx As Integer = topfrontleftx + (Math.Abs(topfrontleftx - topfrontrightx) / 2)
            Dim beaky As Integer = topfrontlefty + (Math.Abs(topfrontlefty - bottomfrontlefty) / 2)
            Dim beak As New System.Drawing.Point(beakx, beaky)


            Dim top As Point() = {topbackleft, beak, topbackright}
            Dim right As Point() = {topbackright, beak, bottombackright}
            Dim bottom As Point() = {bottombackleft, beak, bottombackright}
            Dim left As Point() = {topbackleft, beak, bottombackleft}
            generator.gfxxy.FillPolygon(myBrush, top)
            generator.gfxxy.FillPolygon(myBrush, right)
            generator.gfxxy.FillPolygon(myBrush, bottom)
            generator.gfxxy.FillPolygon(myBrush, left)

            generator.gfxxy.DrawLine(Pens.Gray, topbackleft, beak)
            generator.gfxxy.DrawLine(Pens.Gray, bottombackleft, beak)
            generator.gfxxy.DrawLine(Pens.Gray, bottombackright, beak)
            generator.gfxxy.DrawLine(Pens.Gray, topbackright, beak)

            generator.gfxxy.DrawLine(Pens.Gray, topbackleft, topbackright)
            generator.gfxxy.DrawLine(Pens.Gray, topbackright, bottombackright)
            generator.gfxxy.DrawLine(Pens.Gray, bottombackright, bottombackleft)
            generator.gfxxy.DrawLine(Pens.Gray, bottombackleft, topbackleft)

        ElseIf direction = 2 Then
            If ylocation <= yn / 2 Then
                Dim beakx As Integer = (((Math.Abs(topbackleftx - topbackrightx) / 2) + (Math.Abs(topfrontleftx - topfrontrightx) / 2)) / 2) + ((topfrontleftx + topbackleftx) / 2)
                Dim beaky As Integer = topfrontlefty + (Math.Abs(topfrontlefty - topbacklefty) / 2)
                Dim beak As New System.Drawing.Point(beakx, beaky)
                Dim front As Point() = {bottomfrontleft, beak, bottomfrontright}
                Dim right As Point() = {bottomfrontright, beak, bottombackright}
                Dim left As Point() = {bottomfrontleft, bottombackleft, beak}
                Dim bottom As Point() = {bottomfrontleft, bottombackleft, bottombackright, bottomfrontright}
                generator.gfxxy.FillPolygon(myBrush, front)
                generator.gfxxy.FillPolygon(myBrush, right)
                generator.gfxxy.FillPolygon(myBrush, left)
                generator.gfxxy.FillPolygon(myBrush, bottom)
                generator.gfxxy.DrawLine(Pens.Gray, bottomfrontleft, beak)
                generator.gfxxy.DrawLine(Pens.Gray, bottomfrontright, beak)
                generator.gfxxy.DrawLine(Pens.Gray, bottomfrontleft, bottomfrontright)
                generator.gfxxy.DrawLine(Pens.Gray, bottomfrontleft, bottombackleft)
                generator.gfxxy.DrawLine(Pens.Gray, bottombackleft, bottombackright)
                generator.gfxxy.DrawLine(Pens.Gray, bottombackright, bottomfrontright)

                Dim ang As Single = Math.Atan(Math.Abs(beaky - bottombackrighty) / Math.Abs(beakx - bottombackrightx))
                Dim pointx As Single = bottombackrightx - (Math.Abs(bottomfrontrighty - bottombackrighty) / Math.Tan(ang))

                If pointx > bottomfrontrightx Then
                    generator.gfxxy.DrawLine(Pens.Gray, bottombackright, beak)
                Else
                    generator.gfxxy.DrawLine(graypen, bottombackright, beak)
                End If

                ang = Math.Atan(Math.Abs(beaky - bottombacklefty) / Math.Abs(beakx - bottombackleftx))
                pointx = (Math.Abs(bottomfrontlefty - bottombacklefty) / Math.Tan(ang)) + bottombackleftx


                If pointx < bottomfrontleftx Then
                    generator.gfxxy.DrawLine(Pens.Gray, beak, bottombackleft)
                Else
                    generator.gfxxy.DrawLine(graypen, beak, bottombackleft)
                End If

            ElseIf ylocation >= yn / 2 Then
                Dim beakx As Integer = (((Math.Abs(topbackleftx - topbackrightx) / 2) + (Math.Abs(topfrontleftx - topfrontrightx) / 2)) / 2) + ((topfrontleftx + topbackleftx) / 2)
                Dim beaky As Integer = topbacklefty + (Math.Abs(topfrontlefty - topbacklefty) / 2)
                Dim beak As New System.Drawing.Point(beakx, beaky)
                Dim front As Point() = {bottomfrontleft, beak, bottomfrontright}
                Dim right As Point() = {bottomfrontright, beak, bottombackright}
                Dim left As Point() = {bottomfrontleft, bottombackleft, beak}
                generator.gfxxy.FillPolygon(myBrush, front)
                generator.gfxxy.FillPolygon(myBrush, right)
                generator.gfxxy.FillPolygon(myBrush, left)
                generator.gfxxy.DrawLine(Pens.Gray, bottomfrontleft, beak)
                generator.gfxxy.DrawLine(Pens.Gray, bottomfrontright, beak)
                generator.gfxxy.DrawLine(Pens.Gray, bottomfrontleft, bottomfrontright)

                Dim ang As Single = Math.Atan(Math.Abs(beaky - bottomfrontlefty) / Math.Abs(beakx - topfrontleftx))
                Dim pointx As Single = (Math.Abs(bottombacklefty - bottomfrontlefty) / Math.Tan(ang)) + bottomfrontleftx

                If pointx < bottombackleftx Then
                    generator.gfxxy.DrawLine(graypen, bottombackleft, beak)
                    generator.gfxxy.DrawLine(graypen, bottombackleft, bottomfrontleft)
                    generator.gfxxy.DrawLine(graypen, bottombackleft, bottombackright)
                Else
                    generator.gfxxy.DrawLine(Pens.Gray, bottombackleft, bottomfrontleft)
                    generator.gfxxy.DrawLine(Pens.Gray, bottombackleft, beak)
                    generator.gfxxy.DrawLine(graypen, bottombackleft, bottombackright)
                End If

                ang = Math.Atan(Math.Abs(beaky - bottomfrontrighty) / Math.Abs(beakx - topfrontrightx))
                pointx = bottomfrontrightx - (Math.Abs(bottombackrighty - bottomfrontrighty) / Math.Tan(ang))


                If pointx < bottombackrightx Then
                    generator.gfxxy.DrawLine(Pens.Gray, beak, bottombackright)
                    generator.gfxxy.DrawLine(Pens.Gray, bottomfrontright, bottombackright)
                Else
                    generator.gfxxy.DrawLine(graypen, beak, bottombackright)
                    generator.gfxxy.DrawLine(graypen, bottomfrontright, bottombackright)
                End If

            End If

        ElseIf direction = 1 Then
            If ylocation <= yn / 2 Then
                Dim beakx As Integer = (((Math.Abs(bottombackleftx - bottombackrightx) / 2) + (Math.Abs(bottomfrontleftx - bottomfrontrightx) / 2)) / 2) + ((bottomfrontleftx + bottombackleftx) / 2)
                Dim beaky As Integer = bottomfrontlefty + (Math.Abs(bottomfrontlefty - bottombacklefty) / 2)
                Dim beak As New System.Drawing.Point(beakx, beaky)
                Dim front As Point() = {topfrontleft, beak, topfrontright}
                Dim right As Point() = {topfrontright, beak, topbackright}
                Dim left As Point() = {topfrontleft, topbackleft, beak}
                generator.gfxxy.FillPolygon(myBrush, front)
                generator.gfxxy.FillPolygon(myBrush, right)
                generator.gfxxy.FillPolygon(myBrush, left)
                generator.gfxxy.DrawLine(Pens.Gray, topfrontleft, beak)
                generator.gfxxy.DrawLine(Pens.Gray, topfrontright, beak)
                generator.gfxxy.DrawLine(Pens.Gray, topfrontleft, topfrontright)
                generator.gfxxy.DrawLine(graypen, topbackright, topbackleft)

                Dim ang As Single = Math.Atan(Math.Abs(beaky - topfrontrighty) / Math.Abs(beakx - topfrontrightx))
                Dim pointx As Single = topfrontrightx - (Math.Abs(topfrontrighty - topbackrighty) / Math.Tan(ang))

                If pointx < topbackrightx Then
                    generator.gfxxy.DrawLine(Pens.Gray, topbackright, beak)
                    generator.gfxxy.DrawLine(Pens.Gray, topfrontright, topbackright)
                Else
                    generator.gfxxy.DrawLine(graypen, topbackright, beak)
                    generator.gfxxy.DrawLine(graypen, topfrontright, topbackright)
                End If

                ang = Math.Atan(Math.Abs(beaky - topfrontlefty) / Math.Abs(beakx - topfrontleftx))
                pointx = (Math.Abs(topfrontlefty - topbacklefty) / Math.Tan(ang)) + topfrontleftx


                If pointx > topbackleftx Then
                    generator.gfxxy.DrawLine(Pens.Gray, beak, topbackleft)
                    generator.gfxxy.DrawLine(Pens.Gray, topbackleft, topfrontleft)
                Else
                    generator.gfxxy.DrawLine(graypen, beak, topbackleft)
                    generator.gfxxy.DrawLine(graypen, topbackleft, topfrontleft)
                End If

            ElseIf ylocation >= yn / 2 Then
                Dim beakx As Integer = (((Math.Abs(bottombackleftx - bottombackrightx) / 2) + (Math.Abs(bottomfrontleftx - bottomfrontrightx) / 2)) / 2) + ((bottomfrontleftx + bottombackleftx) / 2)
                Dim beaky As Integer = bottombacklefty + (Math.Abs(bottomfrontlefty - bottombacklefty) / 2)
                Dim beak As New System.Drawing.Point(beakx, beaky)
                Dim front As Point() = {topfrontleft, beak, topfrontright}
                Dim right As Point() = {topfrontright, beak, topbackright}
                Dim left As Point() = {topfrontleft, topbackleft, beak}
                Dim top As Point() = {topfrontleft, topbackleft, topbackright, topfrontright}
                generator.gfxxy.FillPolygon(myBrush, front)
                generator.gfxxy.FillPolygon(myBrush, right)
                generator.gfxxy.FillPolygon(myBrush, left)
                generator.gfxxy.FillPolygon(myBrush, top)
                generator.gfxxy.DrawLine(Pens.Gray, topfrontleft, beak)
                generator.gfxxy.DrawLine(Pens.Gray, topfrontright, beak)
                generator.gfxxy.DrawLine(Pens.Gray, topfrontleft, topfrontright)

                generator.gfxxy.DrawLine(Pens.Gray, topfrontleft, topbackleft)
                generator.gfxxy.DrawLine(Pens.Gray, topbackleft, topbackright)
                generator.gfxxy.DrawLine(Pens.Gray, topbackright, topfrontright)

                Dim ang As Single = Math.Atan(Math.Abs(beaky - topbacklefty) / Math.Abs(beakx - bottombackleftx))
                Dim pointx As Single = (Math.Abs(topfrontlefty - topbacklefty) / Math.Tan(ang)) + topbackleftx

                If pointx > topfrontleftx Then
                    generator.gfxxy.DrawLine(graypen, topbackleft, beak)
                Else
                    generator.gfxxy.DrawLine(Pens.Gray, topbackleft, beak)
                End If

                ang = Math.Atan(Math.Abs(beaky - topbackrighty) / Math.Abs(beakx - bottombackrightx))
                pointx = topbackrightx - (Math.Abs(topfrontrighty - topbackrighty) / Math.Tan(ang))


                If pointx > topfrontrightx Then
                    generator.gfxxy.DrawLine(Pens.Gray, beak, topbackright)
                Else
                    generator.gfxxy.DrawLine(graypen, beak, topbackright)
                End If
            End If


        ElseIf direction = 4 Then
            If xlocation <= xn / 2 Then

                Dim beakx As Integer = (Math.Abs(topfrontrightx - topbackrightx) / 2) + topfrontrightx
                Dim beaky As Integer = Math.Abs(topfrontrighty - bottombackrighty) / 2 + topfrontlefty
                Dim beak As New System.Drawing.Point(beakx, beaky)

                Dim top As Point() = {topfrontleft, topbackleft, beak}
                Dim middle As Point() = {topfrontleft, beak, bottomfrontleft}
                Dim bottom As Point() = {bottomfrontleft, bottombackleft, beak}

                generator.gfxxy.FillPolygon(myBrush, top)
                generator.gfxxy.FillPolygon(myBrush, middle)
                generator.gfxxy.FillPolygon(myBrush, bottom)
                generator.gfxxy.DrawLine(Pens.Gray, bottomfrontleft, beak)
                generator.gfxxy.DrawLine(Pens.Gray, bottomfrontleft, topfrontleft)
                generator.gfxxy.DrawLine(Pens.Gray, topfrontleft, beak)

                Dim ang As Single = Math.Atan((Math.Abs(topfrontrighty - bottombackrighty) / 2) / ((Math.Abs(topfrontrightx - topbackrightx) / 2) + (topfrontrightx - topfrontleftx)))
                Dim pointy As Single = (Math.Tan(ang) * (a - topfrontleftx)) + topfrontlefty

                If topbacklefty < pointy Then
                    generator.gfxxy.DrawLine(Pens.Gray, topbackleft, beak)
                    generator.gfxxy.DrawLine(Pens.Gray, topfrontleft, topbackleft)
                Else
                    generator.gfxxy.DrawLine(graypen, topfrontleft, topbackleft)
                    generator.gfxxy.DrawLine(graypen, topbackleft, beak)
                End If

                pointy = bottomfrontlefty - (Math.Tan(ang) * (a - topfrontleftx))

                If bottombacklefty < pointy Then
                    generator.gfxxy.DrawLine(graypen, bottomfrontleft, bottombackleft)
                    generator.gfxxy.DrawLine(graypen, bottombackleft, beak)
                Else
                    generator.gfxxy.DrawLine(Pens.Gray, bottomfrontleft, bottombackleft)
                    generator.gfxxy.DrawLine(Pens.Gray, bottombackleft, beak)
                End If

                generator.gfxxy.DrawLine(graypen, topbackleft, bottombackleft)


            ElseIf xlocation >= xn / 2 Then

                Dim beakx As Integer = topfrontrightx - (Math.Abs(topfrontrightx - topbackrightx) / 2)
                Dim beaky As Integer = Math.Abs(topfrontrighty - bottombackrighty) / 2 + topfrontlefty
                Dim beak As New System.Drawing.Point(beakx, beaky)

                Dim top As Point() = {topfrontleft, topbackleft, beak}
                Dim middle As Point() = {topfrontleft, beak, bottomfrontleft}
                Dim bottom As Point() = {bottomfrontleft, bottombackleft, beak}
                Dim back As Point() = {topfrontleft, bottomfrontleft, bottombackleft, topbackleft}

                generator.gfxxy.FillPolygon(myBrush, top)
                generator.gfxxy.FillPolygon(myBrush, middle)
                generator.gfxxy.FillPolygon(myBrush, bottom)
                generator.gfxxy.FillPolygon(myBrush, back)

                generator.gfxxy.DrawLine(Pens.Gray, topfrontleft, bottomfrontleft)
                generator.gfxxy.DrawLine(Pens.Gray, bottomfrontleft, bottombackleft)
                generator.gfxxy.DrawLine(Pens.Gray, bottombackleft, topbackleft)
                generator.gfxxy.DrawLine(Pens.Gray, topbackleft, topfrontleft)
                generator.gfxxy.DrawLine(Pens.Gray, bottomfrontleft, beak)

                generator.gfxxy.DrawLine(Pens.Gray, topfrontleft, beak)


                Dim ang As Single
                ang = Math.Atan((Math.Abs(beaky - bottombacklefty)) / (Math.Abs(beakx - bottombackleftx)))
                Dim pointy As Single
                pointy = bottombacklefty - (Math.Tan(ang) * (Math.Abs(topfrontleftx - topbackleftx)))
                If pointy > bottomfrontlefty Then
                    generator.gfxxy.DrawLine(Pens.Gray, bottombackleft, beak)
                Else
                    generator.gfxxy.DrawLine(graypen, bottombackleft, beak)
                End If

                ang = Math.Atan((Math.Abs(beaky - topbacklefty)) / (Math.Abs(beakx - topbackleftx)))
                pointy = topbacklefty + (Math.Tan(ang) * (Math.Abs(topfrontleftx - topbackleftx)))

                If pointy < topfrontlefty Then
                    generator.gfxxy.DrawLine(Pens.Gray, topbackleft, beak)
                Else
                    generator.gfxxy.DrawLine(graypen, topbackleft, beak)
                End If
            End If


        ElseIf direction = 3 Then
            If xlocation <= xn / 2 Then
                Dim beakx As Integer = topfrontleftx + (Math.Abs(topfrontleftx - topbackleftx) / 2)
                Dim beaky As Integer = (Math.Abs(bottomfrontlefty - topbacklefty) / 2) + topbacklefty
                Dim beak As New System.Drawing.Point(beakx, beaky)

                Dim top As Point() = {topfrontright, topbackright, beak}
                Dim middle As Point() = {topfrontright, beak, bottomfrontright}
                Dim bottom As Point() = {bottomfrontright, bottombackright, beak}
                Dim back As Point() = {bottomfrontright, bottombackright, topbackright, topfrontright}

                generator.gfxxy.FillPolygon(myBrush, top)
                generator.gfxxy.FillPolygon(myBrush, middle)
                generator.gfxxy.FillPolygon(myBrush, bottom)
                generator.gfxxy.FillPolygon(myBrush, back)
                generator.gfxxy.DrawLine(Pens.Gray, bottomfrontright, beak)
                generator.gfxxy.DrawLine(Pens.Gray, bottomfrontright, topfrontright)
                generator.gfxxy.DrawLine(Pens.Gray, topfrontright, beak)
                generator.gfxxy.DrawLine(Pens.Gray, topfrontright, topbackright)
                generator.gfxxy.DrawLine(Pens.Gray, topbackright, bottombackright)
                generator.gfxxy.DrawLine(Pens.Gray, bottombackright, bottomfrontright)

                Dim ang As Single = Math.Atan(Math.Abs(beakx - topbackrightx) / Math.Abs(beaky - topbackrighty))
                Dim pointy As Single = topbackrighty + ((topbackrightx - topfrontrightx) / Math.Tan(ang))

                If topfrontrighty > pointy Then
                    generator.gfxxy.DrawLine(Pens.Gray, topbackright, beak)
                Else
                    generator.gfxxy.DrawLine(graypen, topbackright, beak)
                End If

                ang = Math.Atan(Math.Abs(beakx - bottombackrightx) / Math.Abs(beaky - bottombackrighty))
                pointy = bottombackrighty - ((bottombackrightx - bottomfrontrightx) / Math.Tan(ang))

                If bottomfrontrighty < pointy Then
                    generator.gfxxy.DrawLine(Pens.Gray, bottombackright, beak)
                Else
                    generator.gfxxy.DrawLine(graypen, bottombackright, beak)
                End If

            ElseIf xlocation > xn / 2 Then
                Dim beakx As Integer = topfrontleftx - (Math.Abs(topfrontleftx - topbackleftx) / 2)
                Dim beaky As Integer = (Math.Abs(bottomfrontlefty - topbacklefty) / 2) + topbacklefty
                Dim beak As New System.Drawing.Point(beakx, beaky)
                Dim top As Point() = {topfrontright, topbackright, beak}
                Dim middle As Point() = {topfrontright, beak, bottomfrontright}
                Dim bottom As Point() = {bottomfrontright, bottombackright, beak}
                generator.gfxxy.FillPolygon(myBrush, top)
                generator.gfxxy.FillPolygon(myBrush, middle)
                generator.gfxxy.FillPolygon(myBrush, bottom)
                generator.gfxxy.DrawLine(Pens.Gray, bottomfrontright, beak)
                generator.gfxxy.DrawLine(Pens.Gray, bottomfrontright, topfrontright)
                generator.gfxxy.DrawLine(Pens.Gray, topfrontright, beak)
                generator.gfxxy.DrawLine(graypen, topbackright, bottombackright)

                Dim ang As Single = Math.Atan(Math.Abs(beakx - topfrontrightx) / Math.Abs(beaky - topfrontrighty))
                Dim pointy As Single = topfrontrighty + ((topfrontrightx - topbackrightx) / Math.Tan(ang))

                If topbackrighty < pointy Then
                    generator.gfxxy.DrawLine(Pens.Gray, topbackright, beak)
                    generator.gfxxy.DrawLine(Pens.Gray, topfrontright, topbackright)
                Else
                    generator.gfxxy.DrawLine(graypen, topbackright, beak)
                    generator.gfxxy.DrawLine(graypen, topfrontright, topbackright)
                End If

                ang = Math.Atan(Math.Abs(beakx - bottomfrontrightx) / Math.Abs(beaky - bottomfrontrighty))
                pointy = bottomfrontrighty - ((bottomfrontrightx - bottombackrightx) / Math.Tan(ang))

                If bottombackrighty > pointy Then
                    generator.gfxxy.DrawLine(Pens.Gray, bottombackright, beak)
                    generator.gfxxy.DrawLine(Pens.Gray, bottombackright, bottomfrontright)
                Else
                    generator.gfxxy.DrawLine(graypen, bottombackright, beak)
                    generator.gfxxy.DrawLine(graypen, bottombackright, bottomfrontright)
                End If

            End If

        End If
    End Sub

    Public Sub rangecreatorxy(ByVal s As Integer)
        'test code - produces a semi transparent cube (made up of smaller cubes) to show the target range of an agent
        Dim xstart As Integer = 0
        Dim xend As Integer = 0
        Dim ystart As Integer = 0
        Dim yend As Integer = 0
        Dim zstart As Integer = 0
        Dim zend As Integer = 0
        Dim rr As Integer = 0
        Dim gg As Integer = 0
        Dim bb As Integer = 0
        If generator.excludeagent(s, 0) = 2 Then
            xstart = generator.excludeagent(s, 2)
            xend = generator.excludeagent(s, 1)
            ystart = generator.excludeagent(s, 4)
            yend = generator.excludeagent(s, 3)
            zstart = generator.excludeagent(s, 6)
            zend = generator.excludeagent(s, 5)
            rr = 255
            gg = 153
            bb = 153
        Else
            xstart = generator.agentrange(s, 0, 0)
            xend = generator.agentrange(s, 0, 1)
            ystart = generator.agentrange(s, 1, 0)
            yend = generator.agentrange(s, 1, 1)
            zstart = generator.agentrange(s, 2, 0)
            zend = generator.agentrange(s, 2, 1)
            rr = 153
            gg = 204
            bb = 255
        End If

        For z = zstart To zend
            For y = ystart To yend
                For x = xstart To xend

                    Dim diag As Single = 0
                    Dim jump As Double = cellxyx

                    For i = 1 To z - 1
                        jump = jump * (sizeratio)
                        diag = diag + jump
                    Next
                    'MessageBox.Show(diag)
                    Dim angle As Single = Math.Atan(xn / yn)
                    Dim a As Integer = Math.Sin(angle) * diag
                    Dim b As Integer = Math.Cos(angle) * diag
                    'MessageBox.Show(a & " " & b)
                    Dim topfrontrightx As Integer = a + (x * ((sizexyx - (2 * a)) / xn))
                    Dim topfrontrighty As Integer = b + ((y - 1) * ((sizexyy - (2 * b)) / yn))
                    Dim topfrontleftx As Integer = a + ((x - 1) * ((sizexyx - (2 * a)) / xn))
                    Dim topfrontlefty As Integer = b + ((y - 1) * ((sizexyy - (2 * b)) / yn))

                    Dim bottomfrontrightx As Integer = a + (x * ((sizexyx - (2 * a)) / xn))
                    Dim bottomfrontrighty As Integer = b + (y * ((sizexyy - (2 * b)) / yn))
                    Dim bottomfrontleftx As Integer = a + ((x - 1) * ((sizexyx - (2 * a)) / xn))
                    Dim bottomfrontlefty As Integer = b + (y * ((sizexyy - (2 * b)) / yn))

                    jump = jump * (sizeratio)
                    diag = diag + jump

                    angle = Math.Atan(xn / yn)
                    a = Math.Sin(angle) * diag
                    b = Math.Cos(angle) * diag

                    Dim topbackrightx As Integer = a + (x * ((sizexyx - (2 * a)) / xn))
                    Dim topbackrighty As Integer = b + ((y - 1) * ((sizexyy - (2 * b)) / yn))
                    Dim topbackleftx As Integer = a + ((x - 1) * ((sizexyx - (2 * a)) / xn))
                    Dim topbacklefty As Integer = b + ((y - 1) * ((sizexyy - (2 * b)) / yn))

                    Dim bottombackrightx As Integer = a + (x * ((sizexyx - (2 * a)) / xn))
                    Dim bottombackrighty As Integer = b + (y * ((sizexyy - (2 * b)) / yn))
                    Dim bottombackleftx As Integer = a + ((x - 1) * ((sizexyx - (2 * a)) / xn))
                    Dim bottombacklefty As Integer = b + (y * ((sizexyy - (2 * b)) / yn))


                    Dim topfrontright As New System.Drawing.Point(topfrontrightx, topfrontrighty)
                    Dim topfrontleft As New System.Drawing.Point(topfrontleftx, topfrontlefty)
                    Dim bottomfrontright As New System.Drawing.Point(bottomfrontrightx, bottomfrontrighty)
                    Dim bottomfrontleft As New System.Drawing.Point(bottomfrontleftx, bottomfrontlefty)

                    Dim topbackright As New System.Drawing.Point(topbackrightx, topbackrighty)
                    Dim topbackleft As New System.Drawing.Point(topbackleftx, topbacklefty)
                    Dim bottombackright As New System.Drawing.Point(bottombackrightx, bottombackrighty)
                    Dim bottombackleft As New System.Drawing.Point(bottombackleftx, bottombacklefty)

                    Dim backface As Point() = {topbackleft, topbackright, bottombackright, bottombackleft}
                    Dim rightface As Point() = {topbackright, bottombackright, bottomfrontright, topfrontright}
                    Dim leftface As Point() = {topbackleft, bottombackleft, bottomfrontleft, topfrontleft}
                    Dim topface As Point() = {topbackleft, topbackright, topfrontright, topfrontleft}
                    Dim bottomface As Point() = {bottombackleft, bottombackright, bottomfrontright, bottomfrontleft}
                    Dim frontface As Point() = {topfrontright, topfrontleft, bottomfrontleft, bottomfrontright}

                    Dim transparent As New SolidBrush(Color.FromArgb(25, rr, gg, bb))

                    generator.gfxxy.FillPolygon(transparent, backface)
                    generator.gfxxy.FillPolygon(transparent, rightface)
                    generator.gfxxy.FillPolygon(transparent, leftface)
                    generator.gfxxy.FillPolygon(transparent, topface)
                    generator.gfxxy.FillPolygon(transparent, bottomface)
                    generator.gfxxy.FillPolygon(transparent, frontface)
                Next

            Next
        Next
    End Sub

    'test code
    Public Sub rangecreatorxz(ByVal s As Integer)
        'test code - produces a semi transparent cube (made up of smaller cubes) to show the target range of an agent
        Dim xstart As Integer = 0
        Dim xend As Integer = 0
        Dim ystart As Integer = 0
        Dim yend As Integer = 0
        Dim zstart As Integer = 0
        Dim zend As Integer = 0
        Dim rr As Integer = 0
        Dim gg As Integer = 0
        Dim bb As Integer = 0
        If generator.excludeagent(s, 0) = 2 Then
            xstart = generator.excludeagent(s, 2)
            xend = generator.excludeagent(s, 1)
            ystart = generator.excludeagent(s, 4)
            yend = generator.excludeagent(s, 3)
            zstart = generator.excludeagent(s, 6)
            zend = generator.excludeagent(s, 5)
            rr = 255
            gg = 153
            bb = 153
        Else
            xstart = generator.agentrange(s, 0, 0)
            xend = generator.agentrange(s, 0, 1)
            ystart = generator.agentrange(s, 1, 0)
            yend = generator.agentrange(s, 1, 1)
            zstart = generator.agentrange(s, 2, 0)
            zend = generator.agentrange(s, 2, 1)
            rr = 153
            gg = 204
            bb = 255
        End If

        For z = zstart To zend
            For y = ystart To yend
                For x = xstart To xend

                    Dim diag As Single = 0
                    Dim jump As Double = cellxzx

                    For i = 1 To y - 1
                        jump = jump * (sizeratio)
                        diag = diag + jump
                    Next
                    'MessageBox.Show(diag)
                    Dim angle As Single = Math.Atan(xn / zn)
                    Dim a As Integer = Math.Sin(angle) * diag
                    Dim b As Integer = Math.Cos(angle) * diag
                    'MessageBox.Show(a & " " & b)
                    Dim topfrontrightx As Integer = a + (x * ((sizexzx - (2 * a)) / xn))
                    Dim topfrontrighty As Integer = b + ((z - 1) * ((sizexzz - (2 * b)) / zn))
                    Dim topfrontleftx As Integer = a + ((x - 1) * ((sizexzx - (2 * a)) / xn))
                    Dim topfrontlefty As Integer = b + ((z - 1) * ((sizexzz - (2 * b)) / zn))

                    Dim bottomfrontrightx As Integer = a + (x * ((sizexzx - (2 * a)) / xn))
                    Dim bottomfrontrighty As Integer = b + (z * ((sizexzz - (2 * b)) / zn))
                    Dim bottomfrontleftx As Integer = a + ((x - 1) * ((sizexzx - (2 * a)) / xn))
                    Dim bottomfrontlefty As Integer = b + (z * ((sizexzz - (2 * b)) / zn))

                    jump = jump * (sizeratio)
                    diag = diag + jump

                    angle = Math.Atan(xn / zn)
                    a = Math.Sin(angle) * diag
                    b = Math.Cos(angle) * diag

                    Dim topbackrightx As Integer = a + (x * ((sizexzx - (2 * a)) / xn))
                    Dim topbackrighty As Integer = b + ((z - 1) * ((sizexzz - (2 * b)) / zn))
                    Dim topbackleftx As Integer = a + ((x - 1) * ((sizexzx - (2 * a)) / xn))
                    Dim topbacklefty As Integer = b + ((z - 1) * ((sizexzz - (2 * b)) / zn))

                    Dim bottombackrightx As Integer = a + (x * ((sizexzx - (2 * a)) / xn))
                    Dim bottombackrighty As Integer = b + (z * ((sizexzz - (2 * b)) / zn))
                    Dim bottombackleftx As Integer = a + ((x - 1) * ((sizexzx - (2 * a)) / xn))
                    Dim bottombacklefty As Integer = b + (z * ((sizexzz - (2 * b)) / zn))

                    Dim topfrontright As New System.Drawing.Point(topfrontrightx, topfrontrighty)
                    Dim topfrontleft As New System.Drawing.Point(topfrontleftx, topfrontlefty)
                    Dim bottomfrontright As New System.Drawing.Point(bottomfrontrightx, bottomfrontrighty)
                    Dim bottomfrontleft As New System.Drawing.Point(bottomfrontleftx, bottomfrontlefty)

                    Dim topbackright As New System.Drawing.Point(topbackrightx, topbackrighty)
                    Dim topbackleft As New System.Drawing.Point(topbackleftx, topbacklefty)
                    Dim bottombackright As New System.Drawing.Point(bottombackrightx, bottombackrighty)
                    Dim bottombackleft As New System.Drawing.Point(bottombackleftx, bottombacklefty)

                    Dim backface As Point() = {topbackleft, topbackright, bottombackright, bottombackleft}
                    Dim rightface As Point() = {topbackright, bottombackright, bottomfrontright, topfrontright}
                    Dim leftface As Point() = {topbackleft, bottombackleft, bottomfrontleft, topfrontleft}
                    Dim topface As Point() = {topbackleft, topbackright, topfrontright, topfrontleft}
                    Dim bottomface As Point() = {bottombackleft, bottombackright, bottomfrontright, bottomfrontleft}
                    Dim frontface As Point() = {topfrontright, topfrontleft, bottomfrontleft, bottomfrontright}

                    Dim transparent As New SolidBrush(Color.FromArgb(25, rr, gg, bb))

                    generator.gfxxz.FillPolygon(transparent, backface)
                    generator.gfxxz.FillPolygon(transparent, rightface)
                    generator.gfxxz.FillPolygon(transparent, leftface)
                    generator.gfxxz.FillPolygon(transparent, topface)
                    generator.gfxxz.FillPolygon(transparent, bottomface)
                    generator.gfxxz.FillPolygon(transparent, frontface)
                Next

            Next
        Next
    End Sub

    Public Sub rangecreatorzy(ByVal s As Integer)
        Dim xstart As Integer = 0
        Dim xend As Integer = 0
        Dim ystart As Integer = 0
        Dim yend As Integer = 0
        Dim zstart As Integer = 0
        Dim zend As Integer = 0
        Dim rr As Integer = 0
        Dim gg As Integer = 0
        Dim bb As Integer = 0
        If generator.excludeagent(s, 0) = 2 Then
            xstart = generator.excludeagent(s, 2)
            xend = generator.excludeagent(s, 1)
            ystart = generator.excludeagent(s, 4)
            yend = generator.excludeagent(s, 3)
            zstart = generator.excludeagent(s, 6)
            zend = generator.excludeagent(s, 5)
            rr = 255
            gg = 153
            bb = 153
        Else
            xstart = generator.agentrange(s, 0, 0)
            xend = generator.agentrange(s, 0, 1)
            ystart = generator.agentrange(s, 1, 0)
            yend = generator.agentrange(s, 1, 1)
            zstart = generator.agentrange(s, 2, 0)
            zend = generator.agentrange(s, 2, 1)
            rr = 153
            gg = 204
            bb = 255
        End If

        For z = zstart To zend
            For y = ystart To yend
                For x = xstart To xend

                    Dim diag As Single = 0
                    Dim jump As Double = cellzyz

                    For i = 1 To x - 1
                        jump = jump * (sizeratio)
                        diag = diag + jump
                    Next

                    Dim angle As Single = Math.Atan(zn / yn)
                    Dim a As Integer = Math.Sin(angle) * diag
                    Dim b As Integer = Math.Cos(angle) * diag

                    Dim topfrontrightx As Integer = a + (z * ((sizezyz - (2 * a)) / zn))
                    Dim topfrontrighty As Integer = b + ((y - 1) * ((sizezyy - (2 * b)) / yn))
                    Dim topfrontleftx As Integer = a + ((z - 1) * ((sizezyz - (2 * a)) / zn))
                    Dim topfrontlefty As Integer = b + ((y - 1) * ((sizezyy - (2 * b)) / yn))

                    Dim bottomfrontrightx As Integer = a + (z * ((sizezyz - (2 * a)) / zn))
                    Dim bottomfrontrighty As Integer = b + (y * ((sizezyy - (2 * b)) / yn))
                    Dim bottomfrontleftx As Integer = a + ((z - 1) * ((sizezyz - (2 * a)) / zn))
                    Dim bottomfrontlefty As Integer = b + (y * ((sizezyy - (2 * b)) / yn))

                    jump = jump * (sizeratio)
                    diag = diag + jump

                    angle = Math.Atan(zn / yn)
                    a = Math.Sin(angle) * diag
                    b = Math.Cos(angle) * diag

                    Dim topbackrightx As Integer = a + (z * ((sizezyz - (2 * a)) / zn))
                    Dim topbackrighty As Integer = b + ((y - 1) * ((sizezyy - (2 * b)) / yn))
                    Dim topbackleftx As Integer = a + ((z - 1) * ((sizezyz - (2 * a)) / zn))
                    Dim topbacklefty As Integer = b + ((y - 1) * ((sizezyy - (2 * b)) / yn))

                    Dim bottombackrightx As Integer = a + (z * ((sizezyz - (2 * a)) / zn))
                    Dim bottombackrighty As Integer = b + (y * ((sizezyy - (2 * b)) / yn))
                    Dim bottombackleftx As Integer = a + ((z - 1) * ((sizezyz - (2 * a)) / zn))
                    Dim bottombacklefty As Integer = b + (y * ((sizezyy - (2 * b)) / yn))

                    Dim topfrontright As New System.Drawing.Point(topfrontrightx, topfrontrighty)
                    Dim topfrontleft As New System.Drawing.Point(topfrontleftx, topfrontlefty)
                    Dim bottomfrontright As New System.Drawing.Point(bottomfrontrightx, bottomfrontrighty)
                    Dim bottomfrontleft As New System.Drawing.Point(bottomfrontleftx, bottomfrontlefty)

                    Dim topbackright As New System.Drawing.Point(topbackrightx, topbackrighty)
                    Dim topbackleft As New System.Drawing.Point(topbackleftx, topbacklefty)
                    Dim bottombackright As New System.Drawing.Point(bottombackrightx, bottombackrighty)
                    Dim bottombackleft As New System.Drawing.Point(bottombackleftx, bottombacklefty)

                    Dim backface As Point() = {topbackleft, topbackright, bottombackright, bottombackleft}
                    Dim rightface As Point() = {topbackright, bottombackright, bottomfrontright, topfrontright}
                    Dim leftface As Point() = {topbackleft, bottombackleft, bottomfrontleft, topfrontleft}
                    Dim topface As Point() = {topbackleft, topbackright, topfrontright, topfrontleft}
                    Dim bottomface As Point() = {bottombackleft, bottombackright, bottomfrontright, bottomfrontleft}
                    Dim frontface As Point() = {topfrontright, topfrontleft, bottomfrontleft, bottomfrontright}

                    Dim transparent As New SolidBrush(Color.FromArgb(25, rr, gg, bb))

                    generator.gfxzy.FillPolygon(transparent, backface)
                    generator.gfxzy.FillPolygon(transparent, rightface)
                    generator.gfxzy.FillPolygon(transparent, leftface)
                    generator.gfxzy.FillPolygon(transparent, topface)
                    generator.gfxzy.FillPolygon(transparent, bottomface)
                    generator.gfxzy.FillPolygon(transparent, frontface)
                Next
            Next
        Next
    End Sub

    Public Sub range()
        If viewlabel.Text = "Top View (x,z)" Then
            generator.gfxxz.Clear(Color.White)
            Call generator.gridxz()
            Call sortxz()

            Call placingagentsxz()
            If visualizerange <> 0 Then
                Call rangecreatorxz(visualizerange)
            End If
            Call generator.topgridxz()
            PictureBox1.Image = generator.picxz

        ElseIf viewlabel.Text = "Side View (x,y)" Then
            generator.gfxxy.Clear(Color.White)
            Call generator.gridxy()
            Call sortxy()

            Call placingagentsxy()
            If visualizerange <> 0 Then
                Call rangecreatorxy(visualizerange)
            End If
            Call generator.topgridxy()
            PictureBox1.Image = generator.picxy

        ElseIf viewlabel.Text = "Side View (z,y)" Then
            generator.gfxzy.Clear(Color.White)
            Call generator.gridzy()
            Call sortzy()

            Call placingagentszy()
            If visualizerange <> 0 Then
                Call rangecreatorzy(visualizerange)
            End If
            Call generator.topgridzy()
            PictureBox1.Image = generator.piczy
        End If
    End Sub

    Sub creatorxz(ByVal xlocation As String, ByVal ylocation As Integer, ByVal zlocation As Integer, ByVal direction As Integer, ByVal colour As System.Drawing.Color, ByVal s As Integer)
        zlocation = (zn - zlocation) + 1
        Dim diag As Single
        Dim jump As Double = cellxzx
        For i = 1 To ylocation - 1
            jump = jump * (sizeratio)
            diag = diag + jump
        Next
        Dim angle As Single = Math.Atan(xn / zn)
        Dim a As Integer = Math.Sin(angle) * diag
        Dim b As Integer = Math.Cos(angle) * diag

        Dim topfrontrightx As Integer = a + (xlocation * ((sizexzx - (2 * a)) / xn))
        Dim topfrontrighty As Integer = b + ((zlocation - 1) * ((sizexzz - (2 * b)) / zn))
        Dim topfrontleftx As Integer = a + ((xlocation - 1) * ((sizexzx - (2 * a)) / xn))
        Dim topfrontlefty As Integer = b + ((zlocation - 1) * ((sizexzz - (2 * b)) / zn))

        Dim bottomfrontrightx As Integer = a + (xlocation * ((sizexzx - (2 * a)) / xn))
        Dim bottomfrontrighty As Integer = b + (zlocation * ((sizexzz - (2 * b)) / zn))
        Dim bottomfrontleftx As Integer = a + ((xlocation - 1) * ((sizexzx - (2 * a)) / xn))
        Dim bottomfrontlefty As Integer = b + (zlocation * ((sizexzz - (2 * b)) / zn))


        jump = jump * (sizeratio)
        diag = diag + jump

        angle = Math.Atan(xn / zn)
        a = Math.Sin(angle) * diag
        b = Math.Cos(angle) * diag

        Dim topbackrightx As Integer = a + (xlocation * ((sizexzx - (2 * a)) / xn))
        Dim topbackrighty As Integer = b + ((zlocation - 1) * ((sizexzz - (2 * b)) / zn))
        Dim topbackleftx As Integer = a + ((xlocation - 1) * ((sizexzx - (2 * a)) / xn))
        Dim topbacklefty As Integer = b + ((zlocation - 1) * ((sizexzz - (2 * b)) / zn))

        Dim bottombackrightx As Integer = a + (xlocation * ((sizexzx - (2 * a)) / xn))
        Dim bottombackrighty As Integer = b + (zlocation * ((sizexzz - (2 * b)) / zn))
        Dim bottombackleftx As Integer = a + ((xlocation - 1) * ((sizexzx - (2 * a)) / xn))
        Dim bottombacklefty As Integer = b + (zlocation * ((sizexzz - (2 * b)) / zn))

        Dim topfrontright As New System.Drawing.Point(topfrontrightx, topfrontrighty)
        Dim topfrontleft As New System.Drawing.Point(topfrontleftx, topfrontlefty)
        Dim bottomfrontright As New System.Drawing.Point(bottomfrontrightx, bottomfrontrighty)
        Dim bottomfrontleft As New System.Drawing.Point(bottomfrontleftx, bottomfrontlefty)

        Dim topbackright As New System.Drawing.Point(topbackrightx, topbackrighty)
        Dim topbackleft As New System.Drawing.Point(topbackleftx, topbacklefty)
        Dim bottombackright As New System.Drawing.Point(bottombackrightx, bottombackrighty)
        Dim bottombackleft As New System.Drawing.Point(bottombackleftx, bottombacklefty)

        Dim dashValues As Single() = {1, 2}
        Dim graypen As New Pen(Color.Gray, 1)
        Dim myBrush As New SolidBrush(colour)
        graypen.DashPattern = dashValues

        'generator.gfxxz.DrawLine(Pens.Red, topfrontleftx, topfrontlefty, topfrontrightx, topfrontrighty)
        'generator.gfxxz.DrawLine(Pens.Red, bottomfrontleftx, bottomfrontlefty, bottomfrontrightx, bottomfrontrighty)
        'generator.gfxxz.DrawLine(Pens.Red, topbackleftx, topbacklefty, topbackrightx, topbackrighty)
        'generator.gfxxz.DrawLine(Pens.Red, bottombackleftx, bottombacklefty, bottombackrightx, bottombackrighty)

        'draws cubes for static agents
        If generator.staticagent(s) = 2 Then
            Dim backface As Point() = {topbackleft, topbackright, bottombackright, bottombackleft}
            Dim rightface As Point() = {topbackright, bottombackright, bottomfrontright, topfrontright}
            Dim leftface As Point() = {topbackleft, bottombackleft, bottomfrontleft, topfrontleft}
            Dim topface As Point() = {topbackleft, topbackright, topfrontright, topfrontleft}
            Dim bottomface As Point() = {bottombackleft, bottombackright, bottomfrontright, bottomfrontleft}
            Dim frontface As Point() = {topfrontright, topfrontleft, bottomfrontleft, bottomfrontright}
            Dim brush As New SolidBrush(Color.FromArgb(150, colour.R, colour.G, colour.B))
            'fills in the six faces
            generator.gfxxz.FillPolygon(brush, backface)
            generator.gfxxz.FillPolygon(brush, rightface)
            generator.gfxxz.FillPolygon(brush, leftface)
            generator.gfxxz.FillPolygon(brush, topface)
            generator.gfxxz.FillPolygon(brush, bottomface)
            If generator.agentreservoir(s, 0) = 0 Then
                generator.gfxxz.FillPolygon(brush, frontface)
            End If
            'draws the 12 edges of the cube (in the same colour)
            generator.gfxxz.DrawLine(Pens.Gray, topbackleft, topbackright)
            generator.gfxxz.DrawLine(Pens.Gray, topbackright, bottombackright)
            generator.gfxxz.DrawLine(Pens.Gray, bottombackright, bottombackleft)
            generator.gfxxz.DrawLine(Pens.Gray, bottombackleft, topbackleft)

            generator.gfxxz.DrawLine(Pens.Gray, topbackleft, topfrontleft)
            generator.gfxxz.DrawLine(Pens.Gray, topbackright, topfrontright)
            generator.gfxxz.DrawLine(Pens.Gray, bottombackright, bottomfrontright)
            generator.gfxxz.DrawLine(Pens.Gray, bottombackleft, bottomfrontleft)

            generator.gfxxz.DrawLine(Pens.Gray, topfrontleft, topfrontright)
            generator.gfxxz.DrawLine(Pens.Gray, topfrontright, bottomfrontright)
            generator.gfxxz.DrawLine(Pens.Gray, bottomfrontright, bottomfrontleft)
            generator.gfxxz.DrawLine(Pens.Gray, bottomfrontleft, topfrontleft)

            If generator.agentreservoir(s, 0) = 2 Then
                'new code - bars that show the capacity of the static agent
                Dim scalingfactor As Decimal = (topfrontrightx - topfrontleftx) * 0.25
                Dim progressbarlength As Decimal = Math.Abs(topfrontrighty - bottomfrontrighty)

                Dim capacity As Decimal = generator.agentreservoir(s, 1)
                Dim actuallevel As Decimal = generator.agentreservoir(s, 2)
                If actuallevel >= capacity Then
                    actuallevel = capacity
                End If

                Dim progressbarscalingfactor As Decimal = 0
                If capacity > 0 Then
                    progressbarscalingfactor = actuallevel / capacity
                End If

                Dim topfrontrightleftx As Integer = topfrontrightx - scalingfactor
                Dim topfrontrightrightx As Integer = topfrontrightx

                Dim bottomfrontrightleftx As Integer = bottomfrontrightx - scalingfactor
                Dim bottomfrontrightrightx As Integer = bottomfrontrightx

                Dim topfrontrightleft As New System.Drawing.Point(topfrontrightleftx, topfrontrighty)
                Dim topfrontrightright As New System.Drawing.Point(topfrontrightrightx, topfrontrighty)

                Dim bottomfrontrightleft As New System.Drawing.Point(bottomfrontrightleftx, bottomfrontrighty)
                Dim bottomfrontrightright As New System.Drawing.Point(bottomfrontrightrightx, bottomfrontrighty)

                Dim newy As Decimal = bottomfrontrighty - (progressbarlength * progressbarscalingfactor)
                Dim progressbarlefttop As New System.Drawing.Point(bottomfrontrightleftx, newy)
                Dim progressbarrighttop As New System.Drawing.Point(bottomfrontrightx, newy)
                generator.gfxxz.DrawLine(Pens.Black, progressbarlefttop, progressbarrighttop)

                Dim frontfaceleft As Point() = {topfrontrightleft, topfrontleft, bottomfrontleft, bottomfrontrightleft}
                Dim frontfaceright As Point() = {topfrontright, bottomfrontright, bottomfrontrightleft, topfrontrightleft}
                Dim frontfacerightbar As Point() = {bottomfrontright, bottomfrontrightleft, progressbarlefttop, progressbarrighttop}
                Dim frontfacebarfiller As Point() = {topfrontright, topfrontrightleft, progressbarlefttop, progressbarrighttop}

                Dim col As New SolidBrush(Color.FromArgb(150, Color.White.R, Color.White.G, Color.White.B))
                Dim bar As New SolidBrush(Color.FromArgb(150, Color.GreenYellow.R, Color.GreenYellow.G, Color.GreenYellow.B))

                'generator.gfxxy.FillPolygon(col, frontfaceright)
                generator.gfxxz.FillPolygon(brush, frontfaceleft)
                generator.gfxxz.FillPolygon(col, frontfacebarfiller)
                generator.gfxxz.FillPolygon(bar, frontfacerightbar)
                'new code
            End If

            Exit Sub
        End If

        If direction = 1 Then

            Dim beakx As Integer = topbackleftx + (Math.Abs(topbackleftx - topbackrightx) / 2)
            Dim beaky As Integer = topbacklefty + (Math.Abs(topbacklefty - bottombacklefty) / 2)
            Dim beak As New System.Drawing.Point(beakx, beaky)

            Dim top As Point() = {topfrontleft, beak, topfrontright}
            Dim right As Point() = {topfrontright, beak, bottomfrontright}
            Dim bottom As Point() = {bottomfrontleft, beak, bottomfrontright}
            Dim left As Point() = {topfrontleft, beak, bottomfrontleft}
            generator.gfxxz.FillPolygon(myBrush, top)
            generator.gfxxz.FillPolygon(myBrush, right)
            generator.gfxxz.FillPolygon(myBrush, bottom)
            generator.gfxxz.FillPolygon(myBrush, left)

            generator.gfxxz.DrawLine(graypen, topfrontleft, beak)
            generator.gfxxz.DrawLine(graypen, bottomfrontleft, beak)
            generator.gfxxz.DrawLine(graypen, bottomfrontright, beak)
            generator.gfxxz.DrawLine(graypen, topfrontright, beak)

            generator.gfxxz.DrawLine(Pens.Gray, topfrontleft, topfrontright)
            generator.gfxxz.DrawLine(Pens.Gray, topfrontright, bottomfrontright)
            generator.gfxxz.DrawLine(Pens.Gray, bottomfrontright, bottomfrontleft)
            generator.gfxxz.DrawLine(Pens.Gray, bottomfrontleft, topfrontleft)

        ElseIf direction = 2 Then
            Dim beakx As Integer = topfrontleftx + (Math.Abs(topfrontleftx - topfrontrightx) / 2)
            Dim beaky As Integer = topfrontlefty + (Math.Abs(topfrontlefty - bottomfrontlefty) / 2)
            Dim beak As New System.Drawing.Point(beakx, beaky)


            Dim top As Point() = {topbackleft, beak, topbackright}
            Dim right As Point() = {topbackright, beak, bottombackright}
            Dim bottom As Point() = {bottombackleft, beak, bottombackright}
            Dim left As Point() = {topbackleft, beak, bottombackleft}
            generator.gfxxz.FillPolygon(myBrush, top)
            generator.gfxxz.FillPolygon(myBrush, right)
            generator.gfxxz.FillPolygon(myBrush, bottom)
            generator.gfxxz.FillPolygon(myBrush, left)

            generator.gfxxz.DrawLine(Pens.Gray, topbackleft, beak)
            generator.gfxxz.DrawLine(Pens.Gray, bottombackleft, beak)
            generator.gfxxz.DrawLine(Pens.Gray, bottombackright, beak)
            generator.gfxxz.DrawLine(Pens.Gray, topbackright, beak)

            generator.gfxxz.DrawLine(Pens.Gray, topbackleft, topbackright)
            generator.gfxxz.DrawLine(Pens.Gray, topbackright, bottombackright)
            generator.gfxxz.DrawLine(Pens.Gray, bottombackright, bottombackleft)
            generator.gfxxz.DrawLine(Pens.Gray, bottombackleft, topbackleft)

        ElseIf direction = 6 Then
            If zlocation <= zn / 2 Then
                Dim beakx As Integer = (((Math.Abs(topbackleftx - topbackrightx) / 2) + (Math.Abs(topfrontleftx - topfrontrightx) / 2)) / 2) + ((topfrontleftx + topbackleftx) / 2)
                Dim beaky As Integer = topfrontlefty + (Math.Abs(topfrontlefty - topbacklefty) / 2)
                Dim beak As New System.Drawing.Point(beakx, beaky)
                Dim front As Point() = {bottomfrontleft, beak, bottomfrontright}
                Dim right As Point() = {bottomfrontright, beak, bottombackright}
                Dim left As Point() = {bottomfrontleft, bottombackleft, beak}
                Dim bottom As Point() = {bottomfrontleft, bottombackleft, bottombackright, bottomfrontright}
                generator.gfxxz.FillPolygon(myBrush, front)
                generator.gfxxz.FillPolygon(myBrush, right)
                generator.gfxxz.FillPolygon(myBrush, left)
                generator.gfxxz.FillPolygon(myBrush, bottom)
                generator.gfxxz.DrawLine(Pens.Gray, bottomfrontleft, beak)
                generator.gfxxz.DrawLine(Pens.Gray, bottomfrontright, beak)
                generator.gfxxz.DrawLine(Pens.Gray, bottomfrontleft, bottomfrontright)
                generator.gfxxz.DrawLine(Pens.Gray, bottomfrontleft, bottombackleft)
                generator.gfxxz.DrawLine(Pens.Gray, bottombackleft, bottombackright)
                generator.gfxxz.DrawLine(Pens.Gray, bottombackright, bottomfrontright)

                Dim ang As Single = Math.Atan(Math.Abs(beaky - bottombackrighty) / Math.Abs(beakx - bottombackrightx))
                Dim pointx As Single = bottombackrightx - (Math.Abs(bottomfrontrighty - bottombackrighty) / Math.Tan(ang))

                If pointx > bottomfrontrightx Then
                    generator.gfxxz.DrawLine(Pens.Gray, bottombackright, beak)
                Else
                    generator.gfxxz.DrawLine(graypen, bottombackright, beak)
                End If

                ang = Math.Atan(Math.Abs(beaky - bottombacklefty) / Math.Abs(beakx - bottombackleftx))
                pointx = (Math.Abs(bottomfrontlefty - bottombacklefty) / Math.Tan(ang)) + bottombackleftx


                If pointx < bottomfrontleftx Then
                    generator.gfxxz.DrawLine(Pens.Gray, beak, bottombackleft)
                Else
                    generator.gfxxz.DrawLine(graypen, beak, bottombackleft)
                End If

            ElseIf zlocation >= zn / 2 Then
                Dim beakx As Integer = (((Math.Abs(topbackleftx - topbackrightx) / 2) + (Math.Abs(topfrontleftx - topfrontrightx) / 2)) / 2) + ((topfrontleftx + topbackleftx) / 2)
                Dim beaky As Integer = topbacklefty + (Math.Abs(topfrontlefty - topbacklefty) / 2)
                Dim beak As New System.Drawing.Point(beakx, beaky)
                Dim front As Point() = {bottomfrontleft, beak, bottomfrontright}
                Dim right As Point() = {bottomfrontright, beak, bottombackright}
                Dim left As Point() = {bottomfrontleft, bottombackleft, beak}
                generator.gfxxz.FillPolygon(myBrush, front)
                generator.gfxxz.FillPolygon(myBrush, right)
                generator.gfxxz.FillPolygon(myBrush, left)
                generator.gfxxz.DrawLine(Pens.Gray, bottomfrontleft, beak)
                generator.gfxxz.DrawLine(Pens.Gray, bottomfrontright, beak)
                generator.gfxxz.DrawLine(Pens.Gray, bottomfrontleft, bottomfrontright)

                Dim ang As Single = Math.Atan(Math.Abs(beaky - bottomfrontlefty) / Math.Abs(beakx - topfrontleftx))
                Dim pointx As Single = (Math.Abs(bottombacklefty - bottomfrontlefty) / Math.Tan(ang)) + bottomfrontleftx

                If pointx < bottombackleftx Then
                    generator.gfxxz.DrawLine(graypen, bottombackleft, beak)
                    generator.gfxxz.DrawLine(graypen, bottombackleft, bottomfrontleft)
                    generator.gfxxz.DrawLine(graypen, bottombackleft, bottombackright)
                Else
                    generator.gfxxz.DrawLine(Pens.Gray, bottombackleft, bottomfrontleft)
                    generator.gfxxz.DrawLine(Pens.Gray, bottombackleft, beak)
                    generator.gfxxz.DrawLine(graypen, bottombackleft, bottombackright)
                End If

                ang = Math.Atan(Math.Abs(beaky - bottomfrontrighty) / Math.Abs(beakx - topfrontrightx))
                pointx = bottomfrontrightx - (Math.Abs(bottombackrighty - bottomfrontrighty) / Math.Tan(ang))


                If pointx < bottombackrightx Then
                    generator.gfxxz.DrawLine(Pens.Gray, beak, bottombackright)
                    generator.gfxxz.DrawLine(Pens.Gray, bottomfrontright, bottombackright)
                Else
                    generator.gfxxz.DrawLine(graypen, beak, bottombackright)
                    generator.gfxxz.DrawLine(graypen, bottomfrontright, bottombackright)
                End If

            End If

        ElseIf direction = 5 Then
            If zlocation <= zn / 2 Then
                Dim beakx As Integer = (((Math.Abs(bottombackleftx - bottombackrightx) / 2) + (Math.Abs(bottomfrontleftx - bottomfrontrightx) / 2)) / 2) + ((bottomfrontleftx + bottombackleftx) / 2)
                Dim beaky As Integer = bottomfrontlefty + (Math.Abs(bottomfrontlefty - bottombacklefty) / 2)
                Dim beak As New System.Drawing.Point(beakx, beaky)
                Dim front As Point() = {topfrontleft, beak, topfrontright}
                Dim right As Point() = {topfrontright, beak, topbackright}
                Dim left As Point() = {topfrontleft, topbackleft, beak}
                generator.gfxxz.FillPolygon(myBrush, front)
                generator.gfxxz.FillPolygon(myBrush, right)
                generator.gfxxz.FillPolygon(myBrush, left)
                generator.gfxxz.DrawLine(Pens.Gray, topfrontleft, beak)
                generator.gfxxz.DrawLine(Pens.Gray, topfrontright, beak)
                generator.gfxxz.DrawLine(Pens.Gray, topfrontleft, topfrontright)
                generator.gfxxz.DrawLine(graypen, topbackright, topbackleft)

                Dim ang As Single = Math.Atan(Math.Abs(beaky - topfrontrighty) / Math.Abs(beakx - topfrontrightx))
                Dim pointx As Single = topfrontrightx - (Math.Abs(topfrontrighty - topbackrighty) / Math.Tan(ang))

                If pointx < topbackrightx Then
                    generator.gfxxz.DrawLine(Pens.Gray, topbackright, beak)
                    generator.gfxxz.DrawLine(Pens.Gray, topfrontright, topbackright)
                Else
                    generator.gfxxz.DrawLine(graypen, topbackright, beak)
                    generator.gfxxz.DrawLine(graypen, topfrontright, topbackright)
                End If

                ang = Math.Atan(Math.Abs(beaky - topfrontlefty) / Math.Abs(beakx - topfrontleftx))
                pointx = (Math.Abs(topfrontlefty - topbacklefty) / Math.Tan(ang)) + topfrontleftx


                If pointx > topbackleftx Then
                    generator.gfxxz.DrawLine(Pens.Gray, beak, topbackleft)
                    generator.gfxxz.DrawLine(Pens.Gray, topbackleft, topfrontleft)
                Else
                    generator.gfxxz.DrawLine(graypen, beak, topbackleft)
                    generator.gfxxz.DrawLine(graypen, topbackleft, topfrontleft)
                End If

            ElseIf zlocation >= zn / 2 Then
                Dim beakx As Integer = (((Math.Abs(bottombackleftx - bottombackrightx) / 2) + (Math.Abs(bottomfrontleftx - bottomfrontrightx) / 2)) / 2) + ((bottomfrontleftx + bottombackleftx) / 2)
                Dim beaky As Integer = bottombacklefty + (Math.Abs(bottomfrontlefty - bottombacklefty) / 2)
                Dim beak As New System.Drawing.Point(beakx, beaky)
                Dim front As Point() = {topfrontleft, beak, topfrontright}
                Dim right As Point() = {topfrontright, beak, topbackright}
                Dim left As Point() = {topfrontleft, topbackleft, beak}
                Dim top As Point() = {topfrontleft, topbackleft, topbackright, topfrontright}
                generator.gfxxz.FillPolygon(myBrush, front)
                generator.gfxxz.FillPolygon(myBrush, right)
                generator.gfxxz.FillPolygon(myBrush, left)
                generator.gfxxz.FillPolygon(myBrush, top)
                generator.gfxxz.DrawLine(Pens.Gray, topfrontleft, beak)
                generator.gfxxz.DrawLine(Pens.Gray, topfrontright, beak)
                generator.gfxxz.DrawLine(Pens.Gray, topfrontleft, topfrontright)

                generator.gfxxz.DrawLine(Pens.Gray, topfrontleft, topbackleft)
                generator.gfxxz.DrawLine(Pens.Gray, topbackleft, topbackright)
                generator.gfxxz.DrawLine(Pens.Gray, topbackright, topfrontright)

                Dim ang As Single = Math.Atan(Math.Abs(beaky - topbacklefty) / Math.Abs(beakx - bottombackleftx))
                Dim pointx As Single = (Math.Abs(topfrontlefty - topbacklefty) / Math.Tan(ang)) + topbackleftx

                If pointx > topfrontleftx Then
                    generator.gfxxz.DrawLine(graypen, topbackleft, beak)
                Else
                    generator.gfxxz.DrawLine(Pens.Gray, topbackleft, beak)
                End If

                ang = Math.Atan(Math.Abs(beaky - topbackrighty) / Math.Abs(beakx - bottombackrightx))
                pointx = topbackrightx - (Math.Abs(topfrontrighty - topbackrighty) / Math.Tan(ang))


                If pointx > topfrontrightx Then
                    generator.gfxxz.DrawLine(Pens.Gray, beak, topbackright)
                Else
                    generator.gfxxz.DrawLine(graypen, beak, topbackright)
                End If
            End If


        ElseIf direction = 4 Then
            If xlocation <= xn / 2 Then

                Dim beakx As Integer = (Math.Abs(topfrontrightx - topbackrightx) / 2) + topfrontrightx
                Dim beaky As Integer = Math.Abs(topfrontrighty - bottombackrighty) / 2 + topfrontlefty
                Dim beak As New System.Drawing.Point(beakx, beaky)

                Dim top As Point() = {topfrontleft, topbackleft, beak}
                Dim middle As Point() = {topfrontleft, beak, bottomfrontleft}
                Dim bottom As Point() = {bottomfrontleft, bottombackleft, beak}

                generator.gfxxz.FillPolygon(myBrush, top)
                generator.gfxxz.FillPolygon(myBrush, middle)
                generator.gfxxz.FillPolygon(myBrush, bottom)
                generator.gfxxz.DrawLine(Pens.Gray, bottomfrontleft, beak)
                generator.gfxxz.DrawLine(Pens.Gray, bottomfrontleft, topfrontleft)
                generator.gfxxz.DrawLine(Pens.Gray, topfrontleft, beak)

                Dim ang As Single = Math.Atan((Math.Abs(topfrontrighty - bottombackrighty) / 2) / ((Math.Abs(topfrontrightx - topbackrightx) / 2) + (topfrontrightx - topfrontleftx)))
                Dim pointy As Single = (Math.Tan(ang) * (a - topfrontleftx)) + topfrontlefty

                If topbacklefty < pointy Then
                    generator.gfxxz.DrawLine(Pens.Gray, topbackleft, beak)
                    generator.gfxxz.DrawLine(Pens.Gray, topfrontleft, topbackleft)
                Else
                    generator.gfxxz.DrawLine(graypen, topfrontleft, topbackleft)
                    generator.gfxxz.DrawLine(graypen, topbackleft, beak)
                End If

                pointy = bottomfrontlefty - (Math.Tan(ang) * (a - topfrontleftx))

                If bottombacklefty < pointy Then
                    generator.gfxxz.DrawLine(graypen, bottomfrontleft, bottombackleft)
                    generator.gfxxz.DrawLine(graypen, bottombackleft, beak)
                Else
                    generator.gfxxz.DrawLine(Pens.Gray, bottomfrontleft, bottombackleft)
                    generator.gfxxz.DrawLine(Pens.Gray, bottombackleft, beak)
                End If

                generator.gfxxz.DrawLine(graypen, topbackleft, bottombackleft)


            ElseIf xlocation >= xn / 2 Then

                Dim beakx As Integer = topfrontrightx - (Math.Abs(topfrontrightx - topbackrightx) / 2)
                Dim beaky As Integer = Math.Abs(topfrontrighty - bottombackrighty) / 2 + topfrontlefty
                Dim beak As New System.Drawing.Point(beakx, beaky)

                Dim top As Point() = {topfrontleft, topbackleft, beak}
                Dim middle As Point() = {topfrontleft, beak, bottomfrontleft}
                Dim bottom As Point() = {bottomfrontleft, bottombackleft, beak}
                Dim back As Point() = {topfrontleft, bottomfrontleft, bottombackleft, topbackleft}

                generator.gfxxz.FillPolygon(myBrush, top)
                generator.gfxxz.FillPolygon(myBrush, middle)
                generator.gfxxz.FillPolygon(myBrush, bottom)
                generator.gfxxz.FillPolygon(myBrush, back)

                generator.gfxxz.DrawLine(Pens.Gray, topfrontleft, bottomfrontleft)
                generator.gfxxz.DrawLine(Pens.Gray, bottomfrontleft, bottombackleft)
                generator.gfxxz.DrawLine(Pens.Gray, bottombackleft, topbackleft)
                generator.gfxxz.DrawLine(Pens.Gray, topbackleft, topfrontleft)
                generator.gfxxz.DrawLine(Pens.Gray, bottomfrontleft, beak)

                generator.gfxxz.DrawLine(Pens.Gray, topfrontleft, beak)


                Dim ang As Single
                ang = Math.Atan((Math.Abs(beaky - bottombacklefty)) / (Math.Abs(beakx - bottombackleftx)))
                Dim pointy As Single
                pointy = bottombacklefty - (Math.Tan(ang) * (Math.Abs(topfrontleftx - topbackleftx)))
                If pointy > bottomfrontlefty Then
                    generator.gfxxz.DrawLine(Pens.Gray, bottombackleft, beak)
                Else
                    generator.gfxxz.DrawLine(graypen, bottombackleft, beak)
                End If

                ang = Math.Atan((Math.Abs(beaky - topbacklefty)) / (Math.Abs(beakx - topbackleftx)))
                pointy = topbacklefty + (Math.Tan(ang) * (Math.Abs(topfrontleftx - topbackleftx)))

                If pointy < topfrontlefty Then
                    generator.gfxxz.DrawLine(Pens.Gray, topbackleft, beak)
                Else
                    generator.gfxxz.DrawLine(graypen, topbackleft, beak)
                End If
            End If


        ElseIf direction = 3 Then
            If xlocation <= xn / 2 Then
                Dim beakx As Integer = topfrontleftx + (Math.Abs(topfrontleftx - topbackleftx) / 2)
                Dim beaky As Integer = (Math.Abs(bottomfrontlefty - topbacklefty) / 2) + topbacklefty
                Dim beak As New System.Drawing.Point(beakx, beaky)

                Dim top As Point() = {topfrontright, topbackright, beak}
                Dim middle As Point() = {topfrontright, beak, bottomfrontright}
                Dim bottom As Point() = {bottomfrontright, bottombackright, beak}
                Dim back As Point() = {bottomfrontright, bottombackright, topbackright, topfrontright}

                generator.gfxxz.FillPolygon(myBrush, top)
                generator.gfxxz.FillPolygon(myBrush, middle)
                generator.gfxxz.FillPolygon(myBrush, bottom)
                generator.gfxxz.FillPolygon(myBrush, back)
                generator.gfxxz.DrawLine(Pens.Gray, bottomfrontright, beak)
                generator.gfxxz.DrawLine(Pens.Gray, bottomfrontright, topfrontright)
                generator.gfxxz.DrawLine(Pens.Gray, topfrontright, beak)
                generator.gfxxz.DrawLine(Pens.Gray, topfrontright, topbackright)
                generator.gfxxz.DrawLine(Pens.Gray, topbackright, bottombackright)
                generator.gfxxz.DrawLine(Pens.Gray, bottombackright, bottomfrontright)

                Dim ang As Single = Math.Atan(Math.Abs(beakx - topbackrightx) / Math.Abs(beaky - topbackrighty))
                Dim pointy As Single = topbackrighty + ((topbackrightx - topfrontrightx) / Math.Tan(ang))

                If topfrontrighty > pointy Then
                    generator.gfxxz.DrawLine(Pens.Gray, topbackright, beak)
                Else
                    generator.gfxxz.DrawLine(graypen, topbackright, beak)
                End If

                ang = Math.Atan(Math.Abs(beakx - bottombackrightx) / Math.Abs(beaky - bottombackrighty))
                pointy = bottombackrighty - ((bottombackrightx - bottomfrontrightx) / Math.Tan(ang))

                If bottomfrontrighty < pointy Then
                    generator.gfxxz.DrawLine(Pens.Gray, bottombackright, beak)
                Else
                    generator.gfxxz.DrawLine(graypen, bottombackright, beak)
                End If

            ElseIf xlocation > xn / 2 Then
                Dim beakx As Integer = topfrontleftx - (Math.Abs(topfrontleftx - topbackleftx) / 2)
                Dim beaky As Integer = (Math.Abs(bottomfrontlefty - topbacklefty) / 2) + topbacklefty
                Dim beak As New System.Drawing.Point(beakx, beaky)
                Dim top As Point() = {topfrontright, topbackright, beak}
                Dim middle As Point() = {topfrontright, beak, bottomfrontright}
                Dim bottom As Point() = {bottomfrontright, bottombackright, beak}
                generator.gfxxz.FillPolygon(myBrush, top)
                generator.gfxxz.FillPolygon(myBrush, middle)
                generator.gfxxz.FillPolygon(myBrush, bottom)
                generator.gfxxz.DrawLine(Pens.Gray, bottomfrontright, beak)
                generator.gfxxz.DrawLine(Pens.Gray, bottomfrontright, topfrontright)
                generator.gfxxz.DrawLine(Pens.Gray, topfrontright, beak)
                generator.gfxxz.DrawLine(graypen, topbackright, bottombackright)

                Dim ang As Single = Math.Atan(Math.Abs(beakx - topfrontrightx) / Math.Abs(beaky - topfrontrighty))
                Dim pointy As Single = topfrontrighty + ((topfrontrightx - topbackrightx) / Math.Tan(ang))

                If topbackrighty < pointy Then
                    generator.gfxxz.DrawLine(Pens.Gray, topbackright, beak)
                    generator.gfxxz.DrawLine(Pens.Gray, topfrontright, topbackright)
                Else
                    generator.gfxxz.DrawLine(graypen, topbackright, beak)
                    generator.gfxxz.DrawLine(graypen, topfrontright, topbackright)
                End If

                ang = Math.Atan(Math.Abs(beakx - bottomfrontrightx) / Math.Abs(beaky - bottomfrontrighty))
                pointy = bottomfrontrighty - ((bottomfrontrightx - bottombackrightx) / Math.Tan(ang))

                If bottombackrighty > pointy Then
                    generator.gfxxz.DrawLine(Pens.Gray, bottombackright, beak)
                    generator.gfxxz.DrawLine(Pens.Gray, bottombackright, bottomfrontright)
                Else
                    generator.gfxxz.DrawLine(graypen, bottombackright, beak)
                    generator.gfxxz.DrawLine(graypen, bottombackright, bottomfrontright)
                End If

            End If
        End If
    End Sub

    Sub creatorzy(ByVal xlocation As String, ByVal ylocation As Integer, ByVal zlocation As Integer, ByVal direction As Integer, ByVal colour As System.Drawing.Color, ByVal s As Integer)
        zlocation = (zn - zlocation) + 1
        Dim diag As Single
        Dim jump As Double = cellzyz
        For i = 1 To xlocation - 1
            jump = jump * (sizeratio)
            diag = diag + jump
        Next
        Dim angle As Single = Math.Atan(zn / yn)
        Dim a As Integer = Math.Sin(angle) * diag
        Dim b As Integer = Math.Cos(angle) * diag

        Dim topfrontrightx As Integer = a + (zlocation * ((sizezyz - (2 * a)) / zn))
        Dim topfrontrighty As Integer = b + ((ylocation - 1) * ((sizezyy - (2 * b)) / yn))
        Dim topfrontleftx As Integer = a + ((zlocation - 1) * ((sizezyz - (2 * a)) / zn))
        Dim topfrontlefty As Integer = b + ((ylocation - 1) * ((sizezyy - (2 * b)) / yn))

        Dim bottomfrontrightx As Integer = a + (zlocation * ((sizezyz - (2 * a)) / zn))
        Dim bottomfrontrighty As Integer = b + (ylocation * ((sizezyy - (2 * b)) / yn))
        Dim bottomfrontleftx As Integer = a + ((zlocation - 1) * ((sizezyz - (2 * a)) / zn))
        Dim bottomfrontlefty As Integer = b + (ylocation * ((sizezyy - (2 * b)) / yn))

        jump = jump * (sizeratio)
        diag = diag + jump

        angle = Math.Atan(zn / yn)
        a = Math.Sin(angle) * diag
        b = Math.Cos(angle) * diag

        Dim topbackrightx As Integer = a + (zlocation * ((sizezyz - (2 * a)) / zn))
        Dim topbackrighty As Integer = b + ((ylocation - 1) * ((sizezyy - (2 * b)) / yn))
        Dim topbackleftx As Integer = a + ((zlocation - 1) * ((sizezyz - (2 * a)) / zn))
        Dim topbacklefty As Integer = b + ((ylocation - 1) * ((sizezyy - (2 * b)) / yn))

        Dim bottombackrightx As Integer = a + (zlocation * ((sizezyz - (2 * a)) / zn))
        Dim bottombackrighty As Integer = b + (ylocation * ((sizezyy - (2 * b)) / yn))
        Dim bottombackleftx As Integer = a + ((zlocation - 1) * ((sizezyz - (2 * a)) / zn))
        Dim bottombacklefty As Integer = b + (ylocation * ((sizezyy - (2 * b)) / yn))

        Dim topfrontright As New System.Drawing.Point(topfrontrightx, topfrontrighty)
        Dim topfrontleft As New System.Drawing.Point(topfrontleftx, topfrontlefty)
        Dim bottomfrontright As New System.Drawing.Point(bottomfrontrightx, bottomfrontrighty)
        Dim bottomfrontleft As New System.Drawing.Point(bottomfrontleftx, bottomfrontlefty)

        Dim topbackright As New System.Drawing.Point(topbackrightx, topbackrighty)
        Dim topbackleft As New System.Drawing.Point(topbackleftx, topbacklefty)
        Dim bottombackright As New System.Drawing.Point(bottombackrightx, bottombackrighty)
        Dim bottombackleft As New System.Drawing.Point(bottombackleftx, bottombacklefty)

        Dim dashValues As Single() = {1, 2}
        Dim graypen As New Pen(Color.Gray, 1)
        Dim myBrush As New SolidBrush(colour)
        graypen.DashPattern = dashValues

        'draws cubes for static agents
        If generator.staticagent(s) = 2 Then
            Dim backface As Point() = {topbackleft, topbackright, bottombackright, bottombackleft}
            Dim rightface As Point() = {topbackright, bottombackright, bottomfrontright, topfrontright}
            Dim leftface As Point() = {topbackleft, bottombackleft, bottomfrontleft, topfrontleft}
            Dim topface As Point() = {topbackleft, topbackright, topfrontright, topfrontleft}
            Dim bottomface As Point() = {bottombackleft, bottombackright, bottomfrontright, bottomfrontleft}
            Dim frontface As Point() = {topfrontright, topfrontleft, bottomfrontleft, bottomfrontright}
            Dim brush As New SolidBrush(Color.FromArgb(150, colour.R, colour.G, colour.B))

            generator.gfxzy.FillPolygon(brush, backface)
            generator.gfxzy.FillPolygon(brush, rightface)
            generator.gfxzy.FillPolygon(brush, leftface)
            generator.gfxzy.FillPolygon(brush, topface)
            generator.gfxzy.FillPolygon(brush, bottomface)
            If generator.agentreservoir(s, 0) = 0 Then
                generator.gfxzy.FillPolygon(brush, frontface)
            End If

            generator.gfxzy.DrawLine(Pens.Gray, topbackleft, topbackright)
            generator.gfxzy.DrawLine(Pens.Gray, topbackright, bottombackright)
            generator.gfxzy.DrawLine(Pens.Gray, bottombackright, bottombackleft)
            generator.gfxzy.DrawLine(Pens.Gray, bottombackleft, topbackleft)

            generator.gfxzy.DrawLine(Pens.Gray, topbackleft, topfrontleft)
            generator.gfxzy.DrawLine(Pens.Gray, topbackright, topfrontright)
            generator.gfxzy.DrawLine(Pens.Gray, bottombackright, bottomfrontright)
            generator.gfxzy.DrawLine(Pens.Gray, bottombackleft, bottomfrontleft)

            generator.gfxzy.DrawLine(Pens.Gray, topfrontleft, topfrontright)
            generator.gfxzy.DrawLine(Pens.Gray, topfrontright, bottomfrontright)
            generator.gfxzy.DrawLine(Pens.Gray, bottomfrontright, bottomfrontleft)
            generator.gfxzy.DrawLine(Pens.Gray, bottomfrontleft, topfrontleft)

            If generator.agentreservoir(s, 0) = 2 Then
                'new code - bars that show the capacity of the static agent
                Dim scalingfactor As Decimal = (topfrontrightx - topfrontleftx) * 0.25
                Dim progressbarlength As Decimal = Math.Abs(topfrontrighty - bottomfrontrighty)

                Dim capacity As Decimal = generator.agentreservoir(s, 1)
                Dim actuallevel As Decimal = generator.agentreservoir(s, 2)
                If actuallevel >= capacity Then
                    actuallevel = capacity
                End If

                Dim progressbarscalingfactor As Decimal = 0
                If capacity > 0 Then
                    progressbarscalingfactor = actuallevel / capacity
                End If

                Dim topfrontrightleftx As Integer = topfrontrightx - scalingfactor
                Dim topfrontrightrightx As Integer = topfrontrightx

                Dim bottomfrontrightleftx As Integer = bottomfrontrightx - scalingfactor
                Dim bottomfrontrightrightx As Integer = bottomfrontrightx

                Dim topfrontrightleft As New System.Drawing.Point(topfrontrightleftx, topfrontrighty)
                Dim topfrontrightright As New System.Drawing.Point(topfrontrightrightx, topfrontrighty)

                Dim bottomfrontrightleft As New System.Drawing.Point(bottomfrontrightleftx, bottomfrontrighty)
                Dim bottomfrontrightright As New System.Drawing.Point(bottomfrontrightrightx, bottomfrontrighty)

                Dim newy As Decimal = bottomfrontrighty - (progressbarlength * progressbarscalingfactor)
                Dim progressbarlefttop As New System.Drawing.Point(bottomfrontrightleftx, newy)
                Dim progressbarrighttop As New System.Drawing.Point(bottomfrontrightx, newy)
                generator.gfxzy.DrawLine(Pens.Black, progressbarlefttop, progressbarrighttop)

                Dim frontfaceleft As Point() = {topfrontrightleft, topfrontleft, bottomfrontleft, bottomfrontrightleft}
                Dim frontfaceright As Point() = {topfrontright, bottomfrontright, bottomfrontrightleft, topfrontrightleft}
                Dim frontfacerightbar As Point() = {bottomfrontright, bottomfrontrightleft, progressbarlefttop, progressbarrighttop}
                Dim frontfacebarfiller As Point() = {topfrontright, topfrontrightleft, progressbarlefttop, progressbarrighttop}

                Dim col As New SolidBrush(Color.FromArgb(150, Color.White.R, Color.White.G, Color.White.B))
                Dim bar As New SolidBrush(Color.FromArgb(150, Color.GreenYellow.R, Color.GreenYellow.G, Color.GreenYellow.B))

                'generator.gfxxy.FillPolygon(col, frontfaceright)
                generator.gfxzy.FillPolygon(brush, frontfaceleft)
                generator.gfxzy.FillPolygon(col, frontfacebarfiller)
                generator.gfxzy.FillPolygon(bar, frontfacerightbar)
                'new code
            End If

            Exit Sub
        End If

        If direction = 4 Then

            Dim beakx As Integer = topbackleftx + (Math.Abs(topbackleftx - topbackrightx) / 2)
            Dim beaky As Integer = topbacklefty + (Math.Abs(topbacklefty - bottombacklefty) / 2)
            Dim beak As New System.Drawing.Point(beakx, beaky)

            Dim top As Point() = {topfrontleft, beak, topfrontright}
            Dim right As Point() = {topfrontright, beak, bottomfrontright}
            Dim bottom As Point() = {bottomfrontleft, beak, bottomfrontright}
            Dim left As Point() = {topfrontleft, beak, bottomfrontleft}
            generator.gfxzy.FillPolygon(myBrush, top)
            generator.gfxzy.FillPolygon(myBrush, right)
            generator.gfxzy.FillPolygon(myBrush, bottom)
            generator.gfxzy.FillPolygon(myBrush, left)

            generator.gfxzy.DrawLine(graypen, topfrontleft, beak)
            generator.gfxzy.DrawLine(graypen, bottomfrontleft, beak)
            generator.gfxzy.DrawLine(graypen, bottomfrontright, beak)
            generator.gfxzy.DrawLine(graypen, topfrontright, beak)

            generator.gfxzy.DrawLine(Pens.Gray, topfrontleft, topfrontright)
            generator.gfxzy.DrawLine(Pens.Gray, topfrontright, bottomfrontright)
            generator.gfxzy.DrawLine(Pens.Gray, bottomfrontright, bottomfrontleft)
            generator.gfxzy.DrawLine(Pens.Gray, bottomfrontleft, topfrontleft)

        ElseIf direction = 3 Then
            Dim beakx As Integer = topfrontleftx + (Math.Abs(topfrontleftx - topfrontrightx) / 2)
            Dim beaky As Integer = topfrontlefty + (Math.Abs(topfrontlefty - bottomfrontlefty) / 2)
            Dim beak As New System.Drawing.Point(beakx, beaky)


            Dim top As Point() = {topbackleft, beak, topbackright}
            Dim right As Point() = {topbackright, beak, bottombackright}
            Dim bottom As Point() = {bottombackleft, beak, bottombackright}
            Dim left As Point() = {topbackleft, beak, bottombackleft}
            generator.gfxzy.FillPolygon(myBrush, top)
            generator.gfxzy.FillPolygon(myBrush, right)
            generator.gfxzy.FillPolygon(myBrush, bottom)
            generator.gfxzy.FillPolygon(myBrush, left)

            generator.gfxzy.DrawLine(Pens.Gray, topbackleft, beak)
            generator.gfxzy.DrawLine(Pens.Gray, bottombackleft, beak)
            generator.gfxzy.DrawLine(Pens.Gray, bottombackright, beak)
            generator.gfxzy.DrawLine(Pens.Gray, topbackright, beak)

            generator.gfxzy.DrawLine(Pens.Gray, topbackleft, topbackright)
            generator.gfxzy.DrawLine(Pens.Gray, topbackright, bottombackright)
            generator.gfxzy.DrawLine(Pens.Gray, bottombackright, bottombackleft)
            generator.gfxzy.DrawLine(Pens.Gray, bottombackleft, topbackleft)

        ElseIf direction = 2 Then
            If ylocation <= yn / 2 Then
                Dim beakx As Integer = (((Math.Abs(topbackleftx - topbackrightx) / 2) + (Math.Abs(topfrontleftx - topfrontrightx) / 2)) / 2) + ((topfrontleftx + topbackleftx) / 2)
                Dim beaky As Integer = topfrontlefty + (Math.Abs(topfrontlefty - topbacklefty) / 2)
                Dim beak As New System.Drawing.Point(beakx, beaky)
                Dim front As Point() = {bottomfrontleft, beak, bottomfrontright}
                Dim right As Point() = {bottomfrontright, beak, bottombackright}
                Dim left As Point() = {bottomfrontleft, bottombackleft, beak}
                Dim bottom As Point() = {bottomfrontleft, bottombackleft, bottombackright, bottomfrontright}
                generator.gfxzy.FillPolygon(myBrush, front)
                generator.gfxzy.FillPolygon(myBrush, right)
                generator.gfxzy.FillPolygon(myBrush, left)
                generator.gfxzy.FillPolygon(myBrush, bottom)
                generator.gfxzy.DrawLine(Pens.Gray, bottomfrontleft, beak)
                generator.gfxzy.DrawLine(Pens.Gray, bottomfrontright, beak)
                generator.gfxzy.DrawLine(Pens.Gray, bottomfrontleft, bottomfrontright)
                generator.gfxzy.DrawLine(Pens.Gray, bottomfrontleft, bottombackleft)
                generator.gfxzy.DrawLine(Pens.Gray, bottombackleft, bottombackright)
                generator.gfxzy.DrawLine(Pens.Gray, bottombackright, bottomfrontright)

                Dim ang As Single = Math.Atan(Math.Abs(beaky - bottombackrighty) / Math.Abs(beakx - bottombackrightx))
                Dim pointx As Single = bottombackrightx - (Math.Abs(bottomfrontrighty - bottombackrighty) / Math.Tan(ang))

                If pointx > bottomfrontrightx Then
                    generator.gfxzy.DrawLine(Pens.Gray, bottombackright, beak)
                Else
                    generator.gfxzy.DrawLine(graypen, bottombackright, beak)
                End If

                ang = Math.Atan(Math.Abs(beaky - bottombacklefty) / Math.Abs(beakx - bottombackleftx))
                pointx = (Math.Abs(bottomfrontlefty - bottombacklefty) / Math.Tan(ang)) + bottombackleftx


                If pointx < bottomfrontleftx Then
                    generator.gfxzy.DrawLine(Pens.Gray, beak, bottombackleft)
                Else
                    generator.gfxzy.DrawLine(graypen, beak, bottombackleft)
                End If

            ElseIf ylocation >= yn / 2 Then
                Dim beakx As Integer = (((Math.Abs(topbackleftx - topbackrightx) / 2) + (Math.Abs(topfrontleftx - topfrontrightx) / 2)) / 2) + ((topfrontleftx + topbackleftx) / 2)
                Dim beaky As Integer = topbacklefty + (Math.Abs(topfrontlefty - topbacklefty) / 2)
                Dim beak As New System.Drawing.Point(beakx, beaky)
                Dim front As Point() = {bottomfrontleft, beak, bottomfrontright}
                Dim right As Point() = {bottomfrontright, beak, bottombackright}
                Dim left As Point() = {bottomfrontleft, bottombackleft, beak}
                generator.gfxzy.FillPolygon(myBrush, front)
                generator.gfxzy.FillPolygon(myBrush, right)
                generator.gfxzy.FillPolygon(myBrush, left)
                generator.gfxzy.DrawLine(Pens.Gray, bottomfrontleft, beak)
                generator.gfxzy.DrawLine(Pens.Gray, bottomfrontright, beak)
                generator.gfxzy.DrawLine(Pens.Gray, bottomfrontleft, bottomfrontright)

                Dim ang As Single = Math.Atan(Math.Abs(beaky - bottomfrontlefty) / Math.Abs(beakx - topfrontleftx))
                Dim pointx As Single = (Math.Abs(bottombacklefty - bottomfrontlefty) / Math.Tan(ang)) + bottomfrontleftx

                If pointx < bottombackleftx Then
                    generator.gfxzy.DrawLine(graypen, bottombackleft, beak)
                    generator.gfxzy.DrawLine(graypen, bottombackleft, bottomfrontleft)
                    generator.gfxzy.DrawLine(graypen, bottombackleft, bottombackright)
                Else
                    generator.gfxzy.DrawLine(Pens.Gray, bottombackleft, bottomfrontleft)
                    generator.gfxzy.DrawLine(Pens.Gray, bottombackleft, beak)
                    generator.gfxzy.DrawLine(graypen, bottombackleft, bottombackright)
                End If

                ang = Math.Atan(Math.Abs(beaky - bottomfrontrighty) / Math.Abs(beakx - topfrontrightx))
                pointx = bottomfrontrightx - (Math.Abs(bottombackrighty - bottomfrontrighty) / Math.Tan(ang))


                If pointx < bottombackrightx Then
                    generator.gfxzy.DrawLine(Pens.Gray, beak, bottombackright)
                    generator.gfxzy.DrawLine(Pens.Gray, bottomfrontright, bottombackright)
                Else
                    generator.gfxzy.DrawLine(graypen, beak, bottombackright)
                    generator.gfxzy.DrawLine(graypen, bottomfrontright, bottombackright)
                End If

            End If

        ElseIf direction = 1 Then
            If ylocation <= yn / 2 Then
                Dim beakx As Integer = (((Math.Abs(bottombackleftx - bottombackrightx) / 2) + (Math.Abs(bottomfrontleftx - bottomfrontrightx) / 2)) / 2) + ((bottomfrontleftx + bottombackleftx) / 2)
                Dim beaky As Integer = bottomfrontlefty + (Math.Abs(bottomfrontlefty - bottombacklefty) / 2)
                Dim beak As New System.Drawing.Point(beakx, beaky)
                Dim front As Point() = {topfrontleft, beak, topfrontright}
                Dim right As Point() = {topfrontright, beak, topbackright}
                Dim left As Point() = {topfrontleft, topbackleft, beak}
                generator.gfxzy.FillPolygon(myBrush, front)
                generator.gfxzy.FillPolygon(myBrush, right)
                generator.gfxzy.FillPolygon(myBrush, left)
                generator.gfxzy.DrawLine(Pens.Gray, topfrontleft, beak)
                generator.gfxzy.DrawLine(Pens.Gray, topfrontright, beak)
                generator.gfxzy.DrawLine(Pens.Gray, topfrontleft, topfrontright)
                generator.gfxzy.DrawLine(graypen, topbackright, topbackleft)

                Dim ang As Single = Math.Atan(Math.Abs(beaky - topfrontrighty) / Math.Abs(beakx - topfrontrightx))
                Dim pointx As Single = topfrontrightx - (Math.Abs(topfrontrighty - topbackrighty) / Math.Tan(ang))

                If pointx < topbackrightx Then
                    generator.gfxzy.DrawLine(Pens.Gray, topbackright, beak)
                    generator.gfxzy.DrawLine(Pens.Gray, topfrontright, topbackright)
                Else
                    generator.gfxzy.DrawLine(graypen, topbackright, beak)
                    generator.gfxzy.DrawLine(graypen, topfrontright, topbackright)
                End If

                ang = Math.Atan(Math.Abs(beaky - topfrontlefty) / Math.Abs(beakx - topfrontleftx))
                pointx = (Math.Abs(topfrontlefty - topbacklefty) / Math.Tan(ang)) + topfrontleftx


                If pointx > topbackleftx Then
                    generator.gfxzy.DrawLine(Pens.Gray, beak, topbackleft)
                    generator.gfxzy.DrawLine(Pens.Gray, topbackleft, topfrontleft)
                Else
                    generator.gfxzy.DrawLine(graypen, beak, topbackleft)
                    generator.gfxzy.DrawLine(graypen, topbackleft, topfrontleft)
                End If

            ElseIf ylocation >= yn / 2 Then
                Dim beakx As Integer = (((Math.Abs(bottombackleftx - bottombackrightx) / 2) + (Math.Abs(bottomfrontleftx - bottomfrontrightx) / 2)) / 2) + ((bottomfrontleftx + bottombackleftx) / 2)
                Dim beaky As Integer = bottombacklefty + (Math.Abs(bottomfrontlefty - bottombacklefty) / 2)
                Dim beak As New System.Drawing.Point(beakx, beaky)
                Dim front As Point() = {topfrontleft, beak, topfrontright}
                Dim right As Point() = {topfrontright, beak, topbackright}
                Dim left As Point() = {topfrontleft, topbackleft, beak}
                Dim top As Point() = {topfrontleft, topbackleft, topbackright, topfrontright}
                generator.gfxzy.FillPolygon(myBrush, front)
                generator.gfxzy.FillPolygon(myBrush, right)
                generator.gfxzy.FillPolygon(myBrush, left)
                generator.gfxzy.FillPolygon(myBrush, top)
                generator.gfxzy.DrawLine(Pens.Gray, topfrontleft, beak)
                generator.gfxzy.DrawLine(Pens.Gray, topfrontright, beak)
                generator.gfxzy.DrawLine(Pens.Gray, topfrontleft, topfrontright)

                generator.gfxzy.DrawLine(Pens.Gray, topfrontleft, topbackleft)
                generator.gfxzy.DrawLine(Pens.Gray, topbackleft, topbackright)
                generator.gfxzy.DrawLine(Pens.Gray, topbackright, topfrontright)

                Dim ang As Single = Math.Atan(Math.Abs(beaky - topbacklefty) / Math.Abs(beakx - bottombackleftx))
                Dim pointx As Single = (Math.Abs(topfrontlefty - topbacklefty) / Math.Tan(ang)) + topbackleftx

                If pointx > topfrontleftx Then
                    generator.gfxzy.DrawLine(graypen, topbackleft, beak)
                Else
                    generator.gfxzy.DrawLine(Pens.Gray, topbackleft, beak)
                End If

                ang = Math.Atan(Math.Abs(beaky - topbackrighty) / Math.Abs(beakx - bottombackrightx))
                pointx = topbackrightx - (Math.Abs(topfrontrighty - topbackrighty) / Math.Tan(ang))


                If pointx > topfrontrightx Then
                    generator.gfxzy.DrawLine(Pens.Gray, beak, topbackright)
                Else
                    generator.gfxzy.DrawLine(graypen, beak, topbackright)
                End If
            End If


        ElseIf direction = 5 Then
            If zlocation <= zn / 2 Then

                Dim beakx As Integer = (Math.Abs(topfrontrightx - topbackrightx) / 2) + topfrontrightx
                Dim beaky As Integer = Math.Abs(topfrontrighty - bottombackrighty) / 2 + topfrontlefty
                Dim beak As New System.Drawing.Point(beakx, beaky)

                Dim top As Point() = {topfrontleft, topbackleft, beak}
                Dim middle As Point() = {topfrontleft, beak, bottomfrontleft}
                Dim bottom As Point() = {bottomfrontleft, bottombackleft, beak}

                generator.gfxzy.FillPolygon(myBrush, top)
                generator.gfxzy.FillPolygon(myBrush, middle)
                generator.gfxzy.FillPolygon(myBrush, bottom)
                generator.gfxzy.DrawLine(Pens.Gray, bottomfrontleft, beak)
                generator.gfxzy.DrawLine(Pens.Gray, bottomfrontleft, topfrontleft)
                generator.gfxzy.DrawLine(Pens.Gray, topfrontleft, beak)

                Dim ang As Single = Math.Atan((Math.Abs(topfrontrighty - bottombackrighty) / 2) / ((Math.Abs(topfrontrightx - topbackrightx) / 2) + (topfrontrightx - topfrontleftx)))
                Dim pointy As Single = (Math.Tan(ang) * (a - topfrontleftx)) + topfrontlefty

                If topbacklefty < pointy Then
                    generator.gfxzy.DrawLine(Pens.Gray, topbackleft, beak)
                    generator.gfxzy.DrawLine(Pens.Gray, topfrontleft, topbackleft)
                Else
                    generator.gfxzy.DrawLine(graypen, topfrontleft, topbackleft)
                    generator.gfxzy.DrawLine(graypen, topbackleft, beak)
                End If

                pointy = bottomfrontlefty - (Math.Tan(ang) * (a - topfrontleftx))

                If bottombacklefty < pointy Then
                    generator.gfxzy.DrawLine(graypen, bottomfrontleft, bottombackleft)
                    generator.gfxzy.DrawLine(graypen, bottombackleft, beak)
                Else
                    generator.gfxzy.DrawLine(Pens.Gray, bottomfrontleft, bottombackleft)
                    generator.gfxzy.DrawLine(Pens.Gray, bottombackleft, beak)
                End If

                generator.gfxzy.DrawLine(graypen, topbackleft, bottombackleft)


            ElseIf zlocation >= zn / 2 Then

                Dim beakx As Integer = topfrontrightx - (Math.Abs(topfrontrightx - topbackrightx) / 2)
                Dim beaky As Integer = Math.Abs(topfrontrighty - bottombackrighty) / 2 + topfrontlefty
                Dim beak As New System.Drawing.Point(beakx, beaky)

                Dim top As Point() = {topfrontleft, topbackleft, beak}
                Dim middle As Point() = {topfrontleft, beak, bottomfrontleft}
                Dim bottom As Point() = {bottomfrontleft, bottombackleft, beak}
                Dim back As Point() = {topfrontleft, bottomfrontleft, bottombackleft, topbackleft}

                generator.gfxzy.FillPolygon(myBrush, top)
                generator.gfxzy.FillPolygon(myBrush, middle)
                generator.gfxzy.FillPolygon(myBrush, bottom)
                generator.gfxzy.FillPolygon(myBrush, back)

                generator.gfxzy.DrawLine(Pens.Gray, topfrontleft, bottomfrontleft)
                generator.gfxzy.DrawLine(Pens.Gray, bottomfrontleft, bottombackleft)
                generator.gfxzy.DrawLine(Pens.Gray, bottombackleft, topbackleft)
                generator.gfxzy.DrawLine(Pens.Gray, topbackleft, topfrontleft)
                generator.gfxzy.DrawLine(Pens.Gray, bottomfrontleft, beak)

                generator.gfxzy.DrawLine(Pens.Gray, topfrontleft, beak)


                Dim ang As Single
                ang = Math.Atan((Math.Abs(beaky - bottombacklefty)) / (Math.Abs(beakx - bottombackleftx)))
                Dim pointy As Single
                pointy = bottombacklefty - (Math.Tan(ang) * (Math.Abs(topfrontleftx - topbackleftx)))
                If pointy > bottomfrontlefty Then
                    generator.gfxzy.DrawLine(Pens.Gray, bottombackleft, beak)
                Else
                    generator.gfxzy.DrawLine(graypen, bottombackleft, beak)
                End If

                ang = Math.Atan((Math.Abs(beaky - topbacklefty)) / (Math.Abs(beakx - topbackleftx)))
                pointy = topbacklefty + (Math.Tan(ang) * (Math.Abs(topfrontleftx - topbackleftx)))

                If pointy < topfrontlefty Then
                    generator.gfxzy.DrawLine(Pens.Gray, topbackleft, beak)
                Else
                    generator.gfxzy.DrawLine(graypen, topbackleft, beak)
                End If
            End If


        ElseIf direction = 6 Then
            If zlocation <= zn / 2 Then
                Dim beakx As Integer = topfrontleftx + (Math.Abs(topfrontleftx - topbackleftx) / 2)
                Dim beaky As Integer = (Math.Abs(bottomfrontlefty - topbacklefty) / 2) + topbacklefty
                Dim beak As New System.Drawing.Point(beakx, beaky)

                Dim top As Point() = {topfrontright, topbackright, beak}
                Dim middle As Point() = {topfrontright, beak, bottomfrontright}
                Dim bottom As Point() = {bottomfrontright, bottombackright, beak}
                Dim back As Point() = {bottomfrontright, bottombackright, topbackright, topfrontright}

                generator.gfxzy.FillPolygon(myBrush, top)
                generator.gfxzy.FillPolygon(myBrush, middle)
                generator.gfxzy.FillPolygon(myBrush, bottom)
                generator.gfxzy.FillPolygon(myBrush, back)
                generator.gfxzy.DrawLine(Pens.Gray, bottomfrontright, beak)
                generator.gfxzy.DrawLine(Pens.Gray, bottomfrontright, topfrontright)
                generator.gfxzy.DrawLine(Pens.Gray, topfrontright, beak)
                generator.gfxzy.DrawLine(Pens.Gray, topfrontright, topbackright)
                generator.gfxzy.DrawLine(Pens.Gray, topbackright, bottombackright)
                generator.gfxzy.DrawLine(Pens.Gray, bottombackright, bottomfrontright)

                Dim ang As Single = Math.Atan(Math.Abs(beakx - topbackrightx) / Math.Abs(beaky - topbackrighty))
                Dim pointy As Single = topbackrighty + ((topbackrightx - topfrontrightx) / Math.Tan(ang))

                If topfrontrighty > pointy Then
                    generator.gfxzy.DrawLine(Pens.Gray, topbackright, beak)
                Else
                    generator.gfxzy.DrawLine(graypen, topbackright, beak)
                End If

                ang = Math.Atan(Math.Abs(beakx - bottombackrightx) / Math.Abs(beaky - bottombackrighty))
                pointy = bottombackrighty - ((bottombackrightx - bottomfrontrightx) / Math.Tan(ang))

                If bottomfrontrighty < pointy Then
                    generator.gfxzy.DrawLine(Pens.Gray, bottombackright, beak)
                Else
                    generator.gfxzy.DrawLine(graypen, bottombackright, beak)
                End If

            ElseIf zlocation > zn / 2 Then
                Dim beakx As Integer = topfrontleftx - (Math.Abs(topfrontleftx - topbackleftx) / 2)
                Dim beaky As Integer = (Math.Abs(bottomfrontlefty - topbacklefty) / 2) + topbacklefty
                Dim beak As New System.Drawing.Point(beakx, beaky)
                Dim top As Point() = {topfrontright, topbackright, beak}
                Dim middle As Point() = {topfrontright, beak, bottomfrontright}
                Dim bottom As Point() = {bottomfrontright, bottombackright, beak}
                generator.gfxzy.FillPolygon(myBrush, top)
                generator.gfxzy.FillPolygon(myBrush, middle)
                generator.gfxzy.FillPolygon(myBrush, bottom)
                generator.gfxzy.DrawLine(Pens.Gray, bottomfrontright, beak)
                generator.gfxzy.DrawLine(Pens.Gray, bottomfrontright, topfrontright)
                generator.gfxzy.DrawLine(Pens.Gray, topfrontright, beak)
                generator.gfxzy.DrawLine(graypen, topbackright, bottombackright)

                Dim ang As Single = Math.Atan(Math.Abs(beakx - topfrontrightx) / Math.Abs(beaky - topfrontrighty))
                Dim pointy As Single = topfrontrighty + ((topfrontrightx - topbackrightx) / Math.Tan(ang))

                If topbackrighty < pointy Then
                    generator.gfxzy.DrawLine(Pens.Gray, topbackright, beak)
                    generator.gfxzy.DrawLine(Pens.Gray, topfrontright, topbackright)
                Else
                    generator.gfxzy.DrawLine(graypen, topbackright, beak)
                    generator.gfxzy.DrawLine(graypen, topfrontright, topbackright)
                End If

                ang = Math.Atan(Math.Abs(beakx - bottomfrontrightx) / Math.Abs(beaky - bottomfrontrighty))
                pointy = bottomfrontrighty - ((bottomfrontrightx - bottombackrightx) / Math.Tan(ang))

                If bottombackrighty > pointy Then
                    generator.gfxzy.DrawLine(Pens.Gray, bottombackright, beak)
                    generator.gfxzy.DrawLine(Pens.Gray, bottombackright, bottomfrontright)
                Else
                    generator.gfxzy.DrawLine(graypen, bottombackright, beak)
                    generator.gfxzy.DrawLine(graypen, bottombackright, bottomfrontright)
                End If

            End If

        End If

    End Sub






    Private Sub TopViewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TopViewToolStripMenuItem.Click
        viewlabel.Text = "Top View (x,z)"

        TopViewToolStripMenuItem.Enabled = False
        SideViewToolStripMenuItem.Enabled = True
        SideViewToolStripMenuItem1.Enabled = True



        generator.gfxxz.Clear(Color.White)
        Call generator.gridxz()
        Call sortxz()
        Call placingagentsxz()
        Call generator.topgridxz()
        PictureBox1.Image = generator.picxz




    End Sub

    Private Sub QuitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub SideViewToolStripMenuzItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SideViewToolStripMenuItem1.Click
        viewlabel.Text = "Side View (z,y)"
        TopViewToolStripMenuItem.Enabled = True
        SideViewToolStripMenuItem.Enabled = True
        SideViewToolStripMenuItem1.Enabled = False

        generator.gfxzy.Clear(Color.White)
        Call generator.gridzy()
        Call sortzy()
        Call placingagentszy()
        Call generator.topgridzy()
        PictureBox1.Image = generator.piczy
    End Sub

    Private Sub SideViewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SideViewToolStripMenuItem.Click
        TopViewToolStripMenuItem.Enabled = True
        SideViewToolStripMenuItem1.Enabled = True
        SideViewToolStripMenuItem.Enabled = False

        viewlabel.Text = "Side View (x,y)"

        generator.gfxxy.Clear(Color.White)
        Call generator.gridxy()
        Call sortxy()
        Call placingagentsxy()
        Call generator.topgridxy()
        PictureBox1.Image = generator.picxy

    End Sub

    Private Sub Timerxy_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timerxy.Tick

        For i = 1 To total

            If generator.agentchange = True Then
                Call staticagentcheck()
            End If

            'I know this if statment doesnt make sense but if agent gets deminished i goes above total and one agent goes missing 
            If i > total Then
                Exit For
            End If

            Dim x As Integer = generator.agentlocation(i, 0)
            Dim y As Integer = generator.agentlocation(i, 1)
            Dim z As Integer = generator.agentlocation(i, 2)
            Dim dx As Integer = generator.agentlocation(i, 5)
            Dim dy As Integer = generator.agentlocation(i, 6)
            Dim dz As Integer = generator.agentlocation(i, 7)


            generator.agentlocation(i, 9) = generator.agentlocation(i, 9) + 1

            If generator.agentlocation(i, 8) <= 0 Then
                deminish(i, x, y, z, 0)
                x = generator.agentlocation(i, 0)
                y = generator.agentlocation(i, 1)
                z = generator.agentlocation(i, 2)
                dx = generator.agentlocation(i, 5)
                dy = generator.agentlocation(i, 6)
                dz = generator.agentlocation(i, 7)
            End If

            If generator.aging(generator.agentlocation(i, 4)) = True Then
                If generator.agentlocation(i, 9) = generator.agelimit(generator.agentlocation(i, 4)) Then
                    deminish(i, x, y, z, 0)
                End If
            End If

            If generator.asr(generator.agentlocation(i, 4)) = True Then
                generator.agentlocation(i, 10) = generator.agentlocation(i, 10) + 1
                If generator.agentlocation(i, 10) = generator.asrtime(generator.agentlocation(i, 4)) Then
                    Call asrproduce(generator.agentlocation(i, 4))
                    generator.agentlocation(i, 10) = 0
                    generator.agentlocation(i, 8) = generator.agentlocation(i, 8) - generator.asrenergy(generator.agentlocation(i, 4))
                End If
            End If

            'allows for agents to remain static
            If generator.staticagent(i) = 0 Then
                If x = dx And y = dy And z = dz Then

                    'excludes an agent from a range specified by the user
                    If generator.excludeagent(generator.agentlocation(i, 4), 0) = 2 Then
                        Do
                            dx = CInt(Math.Floor((xn - 1 + 1) * Rnd())) + 1
                            dy = CInt(Math.Floor((yn - 1 + 1) * Rnd())) + 1
                            dz = CInt(Math.Floor((zn - 1 + 1) * Rnd())) + 1
                            If dx < generator.excludeagent(generator.agentlocation(i, 4), 2) Or dx > generator.excludeagent(generator.agentlocation(i, 4), 1) Or dy < generator.excludeagent(generator.agentlocation(i, 4), 4) Or dy > generator.excludeagent(generator.agentlocation(i, 4), 3) Or dz < generator.excludeagent(generator.agentlocation(i, 4), 6) Or dz > generator.excludeagent(generator.agentlocation(i, 4), 5) Then
                                Exit Do
                            End If
                        Loop
                        'MessageBox.Show(dx & " " & dy & " " & dz)
                        generator.agentlocation(i, 5) = dx
                        generator.agentlocation(i, 6) = dy
                        generator.agentlocation(i, 7) = dz
                    Else
                        Dim rangexupper As Integer = generator.agentrange(generator.agentlocation(i, 4), 0, 1)
                        Dim rangexlower As Integer = generator.agentrange(generator.agentlocation(i, 4), 0, 0)
                        Dim rangeyupper As Integer = generator.agentrange(generator.agentlocation(i, 4), 1, 1)
                        Dim rangeylower As Integer = generator.agentrange(generator.agentlocation(i, 4), 1, 0)
                        Dim rangezupper As Integer = generator.agentrange(generator.agentlocation(i, 4), 2, 1)
                        Dim rangezlower As Integer = generator.agentrange(generator.agentlocation(i, 4), 2, 0)

                        dx = CInt(Math.Floor((rangexupper - rangexlower + 1) * Rnd())) + rangexlower
                        dy = CInt(Math.Floor((rangeyupper - rangeylower + 1) * Rnd())) + rangeylower
                        dz = CInt(Math.Floor((rangezupper - rangezlower + 1) * Rnd())) + rangezlower

                        generator.agentlocation(i, 5) = dx
                        generator.agentlocation(i, 6) = dy
                        generator.agentlocation(i, 7) = dz
                    End If
                End If

            ElseIf generator.staticagent(i) = 2 Then
                dx = x
                dy = y
                dz = z
                generator.occupied(x, y, z) = True
            End If

            'Call reservoirrelase(i)

            Dim xdiff As Integer = Math.Abs(dx - x)
            Dim ydiff As Integer = Math.Abs(dy - y)
            Dim zdiff As Integer = Math.Abs(dz - z)
            If xdiff >= ydiff And xdiff >= zdiff Then

                If dx > x And generator.agentlocation(i, 3) = 4 Then
                    If generator.occupied(x + 1, y, z) = False Then
                        generator.agentlocation(i, 0) = generator.agentlocation(i, 0) + 1
                        generator.occupied(x, y, z) = False
                        generator.occupied(x + 1, y, z) = True
                        generator.agentlocation(i, 8) = generator.agentlocation(i, 8) - generator.stepenergy(generator.agentlocation(i, 4))
                    ElseIf generator.occupied(x + 1, y, z) = True Then
                        'MsgBox("contact")
                        contact(generator.agentlocation(i, 4), i)
                    End If
                ElseIf dx > x Then
                    generator.agentlocation(i, 3) = 4
                    'turn energy can be added here
                    'turn energy now depends on the local region
                    If localturnenergy(i) = True Then
                        generator.agentlocation(i, 8) = generator.agentlocation(i, 8) - generator.localenergychange(generator.agentlocation(i, 4), localregion, 7)
                    Else
                        generator.agentlocation(i, 8) = generator.agentlocation(i, 8) - generator.stepenergy(generator.agentlocation(i, 4))
                    End If
                ElseIf x > dx And generator.agentlocation(i, 3) = 3 Then
                    If generator.occupied(x - 1, y, z) = False Then
                        generator.agentlocation(i, 0) = generator.agentlocation(i, 0) - 1
                        generator.occupied(x, y, z) = False
                        generator.occupied(x - 1, y, z) = True
                        generator.agentlocation(i, 8) = generator.agentlocation(i, 8) - generator.stepenergy(generator.agentlocation(i, 4))
                    ElseIf generator.occupied(x - 1, y, z) = True Then
                        'MsgBox("contact")
                        contact(generator.agentlocation(i, 4), i)
                    End If
                ElseIf x > dx Then
                    generator.agentlocation(i, 3) = 3
                    'turn energy can be added here
                    If localturnenergy(i) = True Then
                        generator.agentlocation(i, 8) = generator.agentlocation(i, 8) - generator.localenergychange(generator.agentlocation(i, 4), localregion, 7)
                    Else
                        generator.agentlocation(i, 8) = generator.agentlocation(i, 8) - generator.stepenergy(generator.agentlocation(i, 4))
                    End If
                End If

            ElseIf ydiff >= xdiff And ydiff >= zdiff Then

                If dy > y And generator.agentlocation(i, 3) = 1 Then
                    If generator.occupied(x, y + 1, z) = False Then
                        generator.agentlocation(i, 1) = generator.agentlocation(i, 1) + 1
                        generator.occupied(x, y, z) = False
                        generator.occupied(x, y + 1, z) = True
                        generator.agentlocation(i, 8) = generator.agentlocation(i, 8) - generator.stepenergy(generator.agentlocation(i, 4))
                    ElseIf generator.occupied(x, y + 1, z) = True Then
                        'MsgBox("contact")
                        contact(generator.agentlocation(i, 4), i)
                    End If
                ElseIf dy > y Then
                    generator.agentlocation(i, 3) = 1
                    'turn energy can be added here
                    If localturnenergy(i) = True Then
                        generator.agentlocation(i, 8) = generator.agentlocation(i, 8) - generator.localenergychange(generator.agentlocation(i, 4), localregion, 7)
                    Else
                        generator.agentlocation(i, 8) = generator.agentlocation(i, 8) - generator.stepenergy(generator.agentlocation(i, 4))
                    End If
                ElseIf y > dy And generator.agentlocation(i, 3) = 2 Then
                    If generator.occupied(x, y - 1, z) = False Then
                        generator.agentlocation(i, 1) = generator.agentlocation(i, 1) - 1
                        generator.occupied(x, y, z) = False
                        generator.occupied(x, y - 1, z) = True
                        generator.agentlocation(i, 8) = generator.agentlocation(i, 8) - generator.stepenergy(generator.agentlocation(i, 4))
                    ElseIf generator.occupied(x, y - 1, z) = True Then
                        'MsgBox("contact")
                        contact(generator.agentlocation(i, 4), i)
                    End If
                ElseIf y > dy Then
                    generator.agentlocation(i, 3) = 2
                    'turn energy can be added here
                    If localturnenergy(i) = True Then
                        generator.agentlocation(i, 8) = generator.agentlocation(i, 8) - generator.localenergychange(generator.agentlocation(i, 4), localregion, 7)
                    Else
                        generator.agentlocation(i, 8) = generator.agentlocation(i, 8) - generator.stepenergy(generator.agentlocation(i, 4))
                    End If
                End If

            ElseIf zdiff >= xdiff And zdiff >= ydiff Then

                If dz > z And generator.agentlocation(i, 3) = 6 Then
                    If generator.occupied(x, y, z + 1) = False Then
                        generator.agentlocation(i, 2) = generator.agentlocation(i, 2) + 1
                        generator.occupied(x, y, z) = False
                        generator.occupied(x, y, z + 1) = True
                        generator.agentlocation(i, 8) = generator.agentlocation(i, 8) - generator.stepenergy(generator.agentlocation(i, 4))
                    ElseIf generator.occupied(x, y, z + 1) = True Then
                        'MsgBox("contact")
                        contact(generator.agentlocation(i, 4), i)
                    End If
                ElseIf dz > z Then
                    generator.agentlocation(i, 3) = 6
                    'turn energy can be added here
                    If localturnenergy(i) = True Then
                        generator.agentlocation(i, 8) = generator.agentlocation(i, 8) - generator.localenergychange(generator.agentlocation(i, 4), localregion, 7)
                    Else
                        generator.agentlocation(i, 8) = generator.agentlocation(i, 8) - generator.stepenergy(generator.agentlocation(i, 4))
                    End If
                ElseIf z > dz And generator.agentlocation(i, 3) = 5 Then
                    If generator.occupied(x, y, z - 1) = False Then
                        generator.agentlocation(i, 2) = generator.agentlocation(i, 2) - 1
                        generator.occupied(x, y, z) = False
                        generator.occupied(x, y, z - 1) = True
                        generator.agentlocation(i, 8) = generator.agentlocation(i, 8) - generator.stepenergy(generator.agentlocation(i, 4))
                    ElseIf generator.occupied(x, y, z - 1) = True Then
                        'MsgBox("contact")
                        contact(generator.agentlocation(i, 4), i)
                    End If
                ElseIf z > dz Then
                    generator.agentlocation(i, 3) = 5
                    'turn energy can be added here
                    If localturnenergy(i) = True Then
                        generator.agentlocation(i, 8) = generator.agentlocation(i, 8) - generator.localenergychange(generator.agentlocation(i, 4), localregion, 7)
                    Else
                        generator.agentlocation(i, 8) = generator.agentlocation(i, 8) - generator.stepenergy(generator.agentlocation(i, 4))
                    End If
                End If

            End If


        Next

        Call reservoirrelase(0)
        If viewlabel.Text = "Top View (x,z)" Then
            generator.gfxxz.Clear(Color.White)
            Call generator.gridxz()
            Call sortxz()

            Call placingagentsxz()
            Call generator.topgridxz()
            PictureBox1.Image = generator.picxz

        ElseIf viewlabel.Text = "Side View (x,y)" Then
            generator.gfxxy.Clear(Color.White)
            Call generator.gridxy()
            Call sortxy()

            Call placingagentsxy()
            If visualizerange <> 0 Then
                Call range()
            End If
            Call generator.topgridxy()
            PictureBox1.Image = generator.picxy

        ElseIf viewlabel.Text = "Side View (z,y)" Then
            generator.gfxzy.Clear(Color.White)
            Call generator.gridzy()
            Call sortzy()

            Call placingagentszy()
            Call generator.topgridzy()
            PictureBox1.Image = generator.piczy

        End If



        tick = tick + 1
        timelabel.Text = tick



        'excel
        If logged = True Then
            Dim agentpop(agent) As Integer
            For p = 1 To agent
                For pop = 1 To total
                    If generator.agentlocation(pop, 4) = p Then
                        agentpop(p) = agentpop(p) + 1
                    End If
                Next
            Next

            oSheet.Cells(tick + 1, 1) = tick
            oSheet2.Cells(tick + 1, 1) = tick
            For i = 1 To agent
                oSheet.Cells(tick + 1, i + 1) = agentpop(i)
                oSheet2.Cells(tick + 1, i + 1) = generator.agentlocation(i, 8)
            Next
        End If


        'only onetick control
        If timerexit = True Then
            timerexit = False
            Timerxy.Stop()
        End If



        If tick = stoplabel.Text Then
            Timerxy.Stop()
        End If

    End Sub

    'allows turn energy to depend on the local region of the agent
    Function localturnenergy(ByVal i As Integer) As Boolean
        For count = 1 To 1000
            If generator.localenergychange(generator.agentlocation(i, 4), count, 0) = 2 Then
                If generator.agentlocation(i, 0) <= generator.localenergychange(generator.agentlocation(i, 4), count, 1) And generator.agentlocation(i, 0) >= generator.localenergychange(generator.agentlocation(i, 4), count, 2) Then
                    If generator.agentlocation(i, 1) <= generator.localenergychange(generator.agentlocation(i, 4), count, 3) And generator.agentlocation(i, 1) >= generator.localenergychange(generator.agentlocation(i, 4), count, 4) Then
                        If generator.agentlocation(i, 2) <= generator.localenergychange(generator.agentlocation(i, 4), count, 5) And generator.agentlocation(i, 2) >= generator.localenergychange(generator.agentlocation(i, 4), count, 6) Then
                            localregion = count
                            localturnenergy = True
                            Exit Function
                        End If
                    End If
                End If
            End If
        Next
        localturnenergy = False
    End Function

    'makes sure that any new agents being placed (after changing the initial count) are static if the agent type was previously made static by the user
    Public Sub staticagentcheck()

        'Dim staticagenttypes(total) As Integer
        For c = 1 To total
            If generator.staticagentid(generator.agentlocation(c, 4)) = 2 Then
                generator.staticagent(c) = 2
                If generator.reservoiragentid(generator.agentlocation(c, 4), 1) = 2 Then
                    generator.agentreservoir(c, 0) = 2
                    generator.agentreservoir(c, 1) = generator.reservoiragentid(generator.agentlocation(c, 4), 2)
                End If
            ElseIf generator.staticagentid(generator.agentlocation(c, 4)) = 0 Then
                generator.staticagent(c) = 0
                generator.agentreservoir(c, 0) = 0
                generator.agentreservoir(c, 1) = 0
                generator.agentreservoir(c, 2) = 0
            End If
        Next
        'For c = 1 To total
        'If generator.staticagent(c) = 2 Then
        '   staticagenttypes(c) = generator.agentlocation(c, 4)
        ' End If
        '  Next

        '  For c = 1 To total
        'For d = 1 To total
        'If generator.agentlocation(d, 4) = staticagenttypes(c) Then
        'generator.staticagent(d) = 2
        'End If
        'Next
        '  Next
        generator.agentchange = False
    End Sub

    Sub contact(ByVal agentt As Integer, ByVal i As Integer)
        generator.agentlocation(i, 8) = generator.agentlocation(i, 8) - generator.bumpenergy(generator.agentlocation(i, 4))
        If generator.staticagent(i) = 2 Then
            Exit Sub
        End If
        Dim dx As Integer
        Dim dy As Integer
        Dim dz As Integer
        If generator.agentrangeabsolute(agentt) = False Then
            dx = CInt(Math.Floor((xn) * Rnd())) + 1
            dy = CInt(Math.Floor((yn) * Rnd())) + 1
            dz = CInt(Math.Floor((zn) * Rnd())) + 1
        ElseIf generator.agentrangeabsolute(agentt) = True Then

            Dim rangexupper As Integer = generator.agentlocation(i, 0) + 1
            Dim rangexlower As Integer = generator.agentlocation(i, 0) - 1
            Dim rangeyupper As Integer = generator.agentlocation(i, 1) + 1
            Dim rangeylower As Integer = generator.agentlocation(i, 1) - 1
            Dim rangezupper As Integer = generator.agentlocation(i, 2) + 1
            Dim rangezlower As Integer = generator.agentlocation(i, 2) - 1


            If generator.agentlocation(i, 3) = 1 Then
                dy = generator.agentlocation(i, 1)
                dz = CInt(Math.Floor((rangezupper - rangezlower + 1) * Rnd())) + rangezlower
                dx = CInt(Math.Floor((rangexupper - rangexlower + 1) * Rnd())) + rangexlower

            ElseIf generator.agentlocation(i, 3) = 2 Then
                dy = generator.agentlocation(i, 1)
                dz = CInt(Math.Floor((rangezupper - rangezlower + 1) * Rnd())) + rangezlower
                dx = CInt(Math.Floor((rangexupper - rangexlower + 1) * Rnd())) + rangexlower

            ElseIf generator.agentlocation(i, 3) = 3 Then
                dx = generator.agentlocation(i, 0)
                dy = CInt(Math.Floor((rangeyupper - rangeylower + 1) * Rnd())) + rangeylower
                dz = CInt(Math.Floor((rangezupper - rangezlower + 1) * Rnd())) + rangezlower

            ElseIf generator.agentlocation(i, 3) = 4 Then
                dx = generator.agentlocation(i, 0)
                dy = CInt(Math.Floor((rangeyupper - rangeylower + 1) * Rnd())) + rangeylower
                dz = CInt(Math.Floor((rangezupper - rangezlower + 1) * Rnd())) + rangezlower

            ElseIf generator.agentlocation(i, 3) = 5 Then
                dz = generator.agentlocation(i, 2)
                dy = CInt(Math.Floor((rangeyupper - rangeylower + 1) * Rnd())) + rangeylower
                dx = CInt(Math.Floor((rangexupper - rangexlower + 1) * Rnd())) + rangexlower

            ElseIf generator.agentlocation(i, 3) = 6 Then
                dz = generator.agentlocation(i, 2)
                dy = CInt(Math.Floor((rangeyupper - rangeylower + 1) * Rnd())) + rangeylower
                dx = CInt(Math.Floor((rangexupper - rangexlower + 1) * Rnd())) + rangexlower

            End If


            If dx > xn Then
                dx = dx - 2
            End If
            If dy > yn Then
                dy = dy - 2
            End If
            If dz > zn Then
                dz = dz - 2
            End If
            If dx < 1 Then
                dx = dx + 2
            End If
            If dy < 1 Then
                dy = dy + 2
            End If
            If dz < 1 Then
                dz = dz + 2
            End If


            'dx = CInt(Math.Floor((rangexupper - rangexlower + 1) * Rnd())) + rangexlower
            'dy = CInt(Math.Floor((rangeyupper - rangeylower + 1) * Rnd())) + rangeylower
            ' dz = CInt(Math.Floor((rangezupper - rangezlower + 1) * Rnd())) + rangezlower

        End If




        generator.agentlocation(i, 5) = dx
        generator.agentlocation(i, 6) = dy
        generator.agentlocation(i, 7) = dz




        '.......................................................................
        Dim opponentx As Integer
        Dim opponenty As Integer
        Dim opponentz As Integer
        If generator.agentlocation(i, 3) = 1 Then
            opponentx = generator.agentlocation(i, 0)
            opponenty = generator.agentlocation(i, 1) + 1
            opponentz = generator.agentlocation(i, 2)
        ElseIf generator.agentlocation(i, 3) = 2 Then
            opponentx = generator.agentlocation(i, 0)
            opponenty = generator.agentlocation(i, 1) - 1
            opponentz = generator.agentlocation(i, 2)
        ElseIf generator.agentlocation(i, 3) = 3 Then
            opponentx = generator.agentlocation(i, 0) - 1
            opponenty = generator.agentlocation(i, 1)
            opponentz = generator.agentlocation(i, 2)
        ElseIf generator.agentlocation(i, 3) = 4 Then
            opponentx = generator.agentlocation(i, 0) + 1
            opponenty = generator.agentlocation(i, 1)
            opponentz = generator.agentlocation(i, 2)
        ElseIf generator.agentlocation(i, 3) = 5 Then
            opponentx = generator.agentlocation(i, 0)
            opponenty = generator.agentlocation(i, 1)
            opponentz = generator.agentlocation(i, 2) - 1
        ElseIf generator.agentlocation(i, 3) = 6 Then
            opponentx = generator.agentlocation(i, 0)
            opponenty = generator.agentlocation(i, 1)
            opponentz = generator.agentlocation(i, 2) + 1
        End If
        'MsgBox(opponentx & " " & opponenty & " " & opponentz)
        Dim ag As Integer

        For opp = 1 To total
            If generator.agentlocation(opp, 0) = opponentx And generator.agentlocation(opp, 1) = opponenty And generator.agentlocation(opp, 2) = opponentz And i <> opp Then
                ag = generator.agentlocation(opp, 4)
                If generator.action(generator.agentlocation(i, 4), ag, 1, 0, 0) = 2 Then
                    Dim randomvalue As Integer = CInt(Math.Floor(101) * Rnd())
                    If catalysispresence(i, opp) = True Then
                        If randomvalue > 0 And randomvalue <= generator.catalystprobability(generator.agentlocation(i, 4), generator.agentlocation(opp, 4)) Then
                            Call consume(opp, opponentx, opponenty, opponentz, i)
                        End If
                    Else
                        If randomvalue > 0 And randomvalue <= generator.interactionprobability(generator.agentlocation(i, 4), ag) Then
                            Call consume(opp, opponentx, opponenty, opponentz, i)
                        End If
                    End If

                ElseIf generator.action(generator.agentlocation(i, 4), ag, 1, 0, 0) = 1 Then
                    Dim randomvalue As Integer = CInt(Math.Floor(101) * Rnd())
                    If catalysispresence(i, opp) = True Then
                        If randomvalue > 0 And randomvalue <= generator.catalystprobability(generator.agentlocation(i, 4), generator.agentlocation(opp, 4)) Then
                            Call produce(generator.agentlocation(i, 4), ag, i, opp)
                        End If
                    Else
                        If randomvalue > 0 And randomvalue <= generator.interactionprobability(generator.agentlocation(i, 4), ag) Then
                            Call produce(generator.agentlocation(i, 4), ag, i, opp)
                        End If
                    End If

                ElseIf generator.action(generator.agentlocation(i, 4), ag, 1, 0, 0) = 3 Then
                    Dim randomvalue As Integer = CInt(Math.Floor(101) * Rnd())
                    If catalysispresence(i, opp) = True Then
                        If randomvalue > 0 And randomvalue <= generator.catalystprobability(generator.agentlocation(i, 4), generator.agentlocation(opp, 4)) Then
                            Call deminish(i, generator.agentlocation(i, 0), generator.agentlocation(i, 1), generator.agentlocation(i, 2), opp)
                        End If
                    Else
                        If randomvalue > 0 And randomvalue <= generator.interactionprobability(generator.agentlocation(i, 4), ag) Then
                            Call deminish(i, generator.agentlocation(i, 0), generator.agentlocation(i, 1), generator.agentlocation(i, 2), opp)
                        End If
                    End If


                ElseIf generator.action(generator.agentlocation(i, 4), ag, 1, 0, 0) = 4 Then
                        Dim randomvalue As Integer = CInt(Math.Floor(101) * Rnd())
                        If catalysispresence(i, opp) = True Then
                            If randomvalue > 0 And randomvalue <= generator.catalystprobability(generator.agentlocation(i, 4), generator.agentlocation(opp, 4)) Then
                                Call produce(generator.agentlocation(i, 4), ag, i, opp)
                                Call consume(opp, opponentx, opponenty, opponentz, i)
                            End If
                        Else
                            If randomvalue > 0 And randomvalue <= generator.interactionprobability(generator.agentlocation(i, 4), ag) Then
                                Call produce(generator.agentlocation(i, 4), ag, i, opp)
                                Call consume(opp, opponentx, opponenty, opponentz, i)
                            End If
                        End If


                    ElseIf generator.action(generator.agentlocation(i, 4), ag, 1, 0, 0) = 5 Then
                        Dim randomvalue As Integer = CInt(Math.Floor(101) * Rnd())
                        If catalysispresence(i, opp) = True Then
                            If randomvalue > 0 And randomvalue <= generator.catalystprobability(generator.agentlocation(i, 4), generator.agentlocation(opp, 4)) Then
                                Call deminishconsume(i, generator.agentlocation(i, 0), generator.agentlocation(i, 1), generator.agentlocation(i, 2), opp, opponentx, opponenty, opponentz)
                            End If
                        Else
                            If randomvalue > 0 And randomvalue <= generator.interactionprobability(generator.agentlocation(i, 4), ag) Then
                                Call deminishconsume(i, generator.agentlocation(i, 0), generator.agentlocation(i, 1), generator.agentlocation(i, 2), opp, opponentx, opponenty, opponentz)
                            End If
                        End If


                    ElseIf generator.action(generator.agentlocation(i, 4), ag, 1, 0, 0) = 6 Then
                        Dim randomvalue As Integer = CInt(Math.Floor(101) * Rnd())
                        If catalysispresence(i, opp) = True Then
                            If randomvalue > 0 And randomvalue <= generator.catalystprobability(generator.agentlocation(i, 4), generator.agentlocation(opp, 4)) Then
                                Call produce(generator.agentlocation(i, 4), ag, i, opp)
                                Call deminish(i, generator.agentlocation(i, 0), generator.agentlocation(i, 1), generator.agentlocation(i, 2), 0)
                            End If
                        Else
                            If randomvalue > 0 And randomvalue <= generator.interactionprobability(generator.agentlocation(i, 4), ag) Then
                                Call produce(generator.agentlocation(i, 4), ag, i, opp)
                                Call deminish(i, generator.agentlocation(i, 0), generator.agentlocation(i, 1), generator.agentlocation(i, 2), 0)
                            End If
                        End If


                    ElseIf generator.action(generator.agentlocation(i, 4), ag, 1, 0, 0) = 7 Then
                        Dim randomvalue As Integer = CInt(Math.Floor(101) * Rnd())
                    If catalysispresence(i, opp) = True Then
                        If randomvalue > 0 And randomvalue <= generator.catalystprobability(generator.agentlocation(i, 4), generator.agentlocation(opp, 4)) Then
                            Call produce(generator.agentlocation(i, 4), ag, i, opp)
                            Call deminishconsume(i, generator.agentlocation(i, 0), generator.agentlocation(i, 1), generator.agentlocation(i, 2), opp, opponentx, opponenty, opponentz)
                        End If
                    Else
                        If randomvalue > 0 And randomvalue <= generator.interactionprobability(generator.agentlocation(i, 4), ag) Then
                            Call produce(generator.agentlocation(i, 4), ag, i, opp)
                            Call deminishconsume(i, generator.agentlocation(i, 0), generator.agentlocation(i, 1), generator.agentlocation(i, 2), opp, opponentx, opponenty, opponentz)
                        End If
                    End If

                End If
            End If
        Next
    End Sub

    'indicates whether or not a catalyst is present in close proximity to the potential interaction
    Function catalysispresence(ByVal i As Integer, ByVal opp As Integer) As Boolean
        For a = 1 To total
            Dim xdiff As Integer
            Dim ydiff As Integer
            Dim zdiff As Integer
            If generator.agentlocation(a, 4) = generator.catalystagent(generator.agentlocation(i, 4), generator.agentlocation(opp, 4)) Then
                xdiff = Math.Abs(generator.agentlocation(a, 0) - generator.agentlocation(i, 0))
                ydiff = Math.Abs(generator.agentlocation(a, 1) - generator.agentlocation(i, 1))
                zdiff = Math.Abs(generator.agentlocation(a, 2) - generator.agentlocation(i, 2))
                If xdiff <= generator.catalystproximity(generator.agentlocation(i, 4), generator.agentlocation(opp, 4), 1) And ydiff <= generator.catalystproximity(generator.agentlocation(i, 4), generator.agentlocation(opp, 4), 2) And zdiff <= generator.catalystproximity(generator.agentlocation(i, 4), generator.agentlocation(opp, 4), 3) Then
                    catalysispresence = True
                    Exit Function
                End If
            End If
        Next
        catalysispresence = False
    End Function

    Sub deminish(ByVal i, ByVal ix, ByVal iy, ByVal iz, ByVal opp)

        If generator.agentreservoir(opp, 2) > generator.agentreservoir(opp, 1) - generator.reservoirchange(generator.agentlocation(i, 4), generator.agentlocation(opp, 4), 1) Then
            Exit Sub
        End If

        If generator.agentreservoir(opp, 0) = 2 Then
            generator.agentreservoir(opp, 2) += generator.reservoirchange(generator.agentlocation(i, 4), generator.agentlocation(opp, 4), 1)
        End If

        generator.agentlocation(i, 0) = 0
        generator.agentlocation(i, 1) = 0
        generator.agentlocation(i, 2) = 0
        generator.agentlocation(i, 3) = 0
        generator.agentlocation(i, 4) = 0
        generator.agentlocation(i, 5) = 0
        generator.agentlocation(i, 6) = 0
        generator.agentlocation(i, 7) = 0
        generator.agentlocation(i, 8) = 0
        generator.agentlocation(i, 9) = 0
        generator.agentlocation(i, 10) = 0
        generator.occupied(ix, iy, iz) = False

        'not sure about this part
        If viewlabel.Text = "Top View (x,z)" Then
            Call sortxz()

        ElseIf viewlabel.Text = "Side View (x,y)" Then
            Call sortxy()

        ElseIf viewlabel.Text = "Side View (z,y)" Then
            Call sortzy()

        End If

        total = total - 1
    End Sub


    Sub consume(ByVal opp, ByVal opponentx, ByVal opponenty, ByVal opponentz, ByVal i)
        If generator.action(generator.agentlocation(i, 4), generator.agentlocation(opp, 4), 6, 0, 0) = 1 Then
            generator.agentlocation(i, 8) = generator.agentlocation(i, 8) + (generator.agentlocation(opp, 8) * (generator.action(generator.agentlocation(i, 4), generator.agentlocation(opp, 4), 3, 0, 0) / 100))
        ElseIf generator.action(generator.agentlocation(i, 4), generator.agentlocation(opp, 4), 6, 0, 0) = 2 Then
            generator.agentlocation(i, 8) = generator.agentlocation(i, 8) + generator.action(generator.agentlocation(i, 4), generator.agentlocation(opp, 4), 4, 0, 0)
        End If

        generator.agentlocation(opp, 0) = 0
        generator.agentlocation(opp, 1) = 0
        generator.agentlocation(opp, 2) = 0
        generator.agentlocation(opp, 3) = 0
        generator.agentlocation(opp, 4) = 0
        generator.agentlocation(opp, 5) = 0
        generator.agentlocation(opp, 6) = 0
        generator.agentlocation(opp, 7) = 0
        generator.agentlocation(opp, 8) = 0
        generator.agentlocation(opp, 9) = 0
        generator.agentlocation(opp, 10) = 0
        generator.occupied(opponentx, opponenty, opponentz) = False

        'not sure about this part
        If viewlabel.Text = "Top View (x,z)" Then
            Call sortxz()

        ElseIf viewlabel.Text = "Side View (x,y)" Then
            Call sortxy()

        ElseIf viewlabel.Text = "Side View (z,y)" Then
            Call sortzy()

        End If

        total = total - 1

    End Sub

    Sub produce(ByVal ag1, ByVal ag2, ByVal i, ByVal opp)
        Dim originalagent As Integer = i

        generator.agentchange = True

        Dim totalagentstobeproduced As Integer
        For i = 1 To agent
            totalagentstobeproduced = totalagentstobeproduced + generator.action(ag1, ag2, 2, i, 1)
        Next


        If total + totalagentstobeproduced <= generator.maxcell Then


            'energy cost in reproduction
            generator.agentlocation(i, 8) = generator.agentlocation(i, 8) - generator.action(ag1, ag2, 5, 0, 0)
            generator.agentlocation(opp, 8) = generator.agentlocation(opp, 8) - generator.action(ag1, ag2, 5, 0, 0)


            Dim indexproduced As Integer = 1
            Dim agenttobeproduced(totalagentstobeproduced) As Integer
            For i = 1 To agent
                Dim something As Integer = 0
                Do
                    If generator.action(ag1, ag2, 2, i, 1) > something Then
                        agenttobeproduced(indexproduced) = i
                        indexproduced = indexproduced + 1
                        something = something + 1
                    ElseIf something = generator.action(ag1, ag2, 2, i, 1) Then
                        Exit Do
                    End If
                Loop
            Next

            For i = 1 To totalagentstobeproduced
                total = total + 1
                Dim rangexupper As Integer = generator.agentrange(agenttobeproduced(i), 0, 1)
                Dim rangexlower As Integer = generator.agentrange(agenttobeproduced(i), 0, 0)
                Dim rangeyupper As Integer = generator.agentrange(agenttobeproduced(i), 1, 1)
                Dim rangeylower As Integer = generator.agentrange(agenttobeproduced(i), 1, 0)
                Dim rangezupper As Integer = generator.agentrange(agenttobeproduced(i), 2, 1)
                Dim rangezlower As Integer = generator.agentrange(agenttobeproduced(i), 2, 0)
                'new code
                Dim xdistance As Integer = generator.localreproduction(ag1, ag2, agenttobeproduced(i), 1)
                Dim ydistance As Integer = generator.localreproduction(ag1, ag2, agenttobeproduced(i), 2)
                Dim zdistance As Integer = generator.localreproduction(ag1, ag2, agenttobeproduced(i), 3)

                Dim xupper As Integer = generator.agentlocation(originalagent, 0) + xdistance
                If xupper > xn Then
                    xupper = xn
                End If
                Dim xlower As Integer = generator.agentlocation(originalagent, 0) - xdistance
                If xlower < 1 Then
                    xlower = 1
                End If
                Dim yupper As Integer = generator.agentlocation(originalagent, 1) + ydistance
                If yupper > yn Then
                    yupper = yn
                End If
                Dim ylower As Integer = generator.agentlocation(originalagent, 1) - ydistance
                If ylower < 1 Then
                    ylower = 1
                End If
                Dim zupper As Integer = generator.agentlocation(originalagent, 2) + zdistance
                If zupper > zn Then
                    zupper = zn
                End If
                Dim zlower As Integer = generator.agentlocation(originalagent, 2) - zdistance
                If zlower < 1 Then
                    zlower = 1
                End If
                Dim x As Integer = CInt(Math.Floor((xupper - xlower + 1) * Rnd())) + xlower
                Dim y As Integer = CInt(Math.Floor((yupper - ylower + 1) * Rnd())) + ylower
                Dim z As Integer = CInt(Math.Floor((zupper - zlower + 1) * Rnd())) + zlower
                'new code
                'Dim x As Integer = CInt(Math.Floor((xn) * Rnd())) + 1
                'Dim y As Integer = CInt(Math.Floor((yn) * Rnd())) + 1
                'Dim z As Integer = CInt(Math.Floor((zn) * Rnd())) + 1
                Dim dx As Integer = CInt(Math.Floor((rangexupper - rangexlower + 1) * Rnd())) + rangexlower
                Dim dy As Integer = CInt(Math.Floor((rangeyupper - rangeylower + 1) * Rnd())) + rangeylower
                Dim dz As Integer = CInt(Math.Floor((rangezupper - rangezlower + 1) * Rnd())) + rangezlower

                Dim number As Integer = 0
                Do While generator.occupied(x, y, z) = True And number < generator.maxcell
                    number = number + 1
                    'x = CInt(Math.Floor((xn) * Rnd())) + 1
                    'y = CInt(Math.Floor((yn) * Rnd())) + 1
                    'z = CInt(Math.Floor((zn) * Rnd())) + 1
                    x = CInt(Math.Floor((xupper - xlower + 1) * Rnd())) + xlower
                    y = CInt(Math.Floor((yupper - ylower + 1) * Rnd())) + ylower
                    z = CInt(Math.Floor((zupper - zlower + 1) * Rnd())) + zlower
                Loop


                generator.occupied(x, y, z) = True

                Dim d As Integer = CInt(Math.Floor((6) * Rnd())) + 1
                generator.agentlocation(total, 0) = x
                generator.agentlocation(total, 1) = y
                generator.agentlocation(total, 2) = z
                generator.agentlocation(total, 3) = d
                generator.agentlocation(total, 4) = agenttobeproduced(i)
                generator.agentlocation(total, 5) = dx
                generator.agentlocation(total, 6) = dy
                generator.agentlocation(total, 7) = dz
                generator.agentlocation(total, 8) = generator.initialenergy(agenttobeproduced(i))
                generator.agentlocation(total, 9) = 0
                generator.agentlocation(total, 10) = 0
            Next
        End If
    End Sub

    Sub deminishconsume(ByVal i, ByVal ix, ByVal iy, ByVal iz, ByVal opp, ByVal opponentx, ByVal opponenty, ByVal opponentz)
        generator.agentlocation(i, 0) = 0
        generator.agentlocation(i, 1) = 0
        generator.agentlocation(i, 2) = 0
        generator.agentlocation(i, 3) = 0
        generator.agentlocation(i, 4) = 0
        generator.agentlocation(i, 5) = 0
        generator.agentlocation(i, 6) = 0
        generator.agentlocation(i, 7) = 0
        generator.agentlocation(i, 8) = 0
        generator.agentlocation(i, 9) = 0
        generator.agentlocation(i, 10) = 0
        generator.occupied(ix, iy, iz) = False


        generator.agentlocation(opp, 0) = 0
        generator.agentlocation(opp, 1) = 0
        generator.agentlocation(opp, 2) = 0
        generator.agentlocation(opp, 3) = 0
        generator.agentlocation(opp, 4) = 0
        generator.agentlocation(opp, 5) = 0
        generator.agentlocation(opp, 6) = 0
        generator.agentlocation(opp, 7) = 0
        generator.agentlocation(opp, 8) = 0
        generator.agentlocation(opp, 9) = 0
        generator.agentlocation(opp, 10) = 0
        generator.occupied(opponentx, opponenty, opponentz) = False

        'not sure about this part
        If viewlabel.Text = "Top View (x,z)" Then
            Call sortxz()

        ElseIf viewlabel.Text = "Side View (x,y)" Then
            Call sortxy()

        ElseIf viewlabel.Text = "Side View (z,y)" Then
            Call sortzy()

        End If

        total = total - 2

    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Timerxy.Start()
        Timerxy.Stop()
    End Sub

    Private Sub ToolStripStatusLabel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripStatusLabel2.Click
        stoplabel.Text = InputBox("Enter the time limit:")
    End Sub

    Private Sub ToolStripStatusLabel4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripStatusLabel4.Click
        Dim input As String = InputBox("Enter speed in percentage:")
        Dim speed As Integer
        If input = "" Then
            Exit Sub
        End If

        Try
            speed = CInt(input)
        Catch ex As Exception
            MessageBox.Show("Please enter a numerical value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        If speed > 100 Then
            speed = 100
            MsgBox("Max speed: 100")
        End If
        Timerxy.Interval = (300 - ((speed * 3) - 1))
        speedbar.Value = speed
    End Sub

    Private Sub StopToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StopToolStripMenuItem.Click
        Timerxy.Stop()
        If logged = True Then
            If MessageBox.Show("Would you like to stop the excel file encryption?", "Excel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                = Windows.Forms.DialogResult.Yes Then
                oBook.SaveAs(exceldir)

                oBook.close()


                'Dim obj As New System.IO.StreamWriter(exceldir)
                'obj.Write(oBook)
                'obj.Close()

                oBook = Nothing
                oExcel.Quit()
                oExcel = Nothing
                logged = False
            End If
        End If
    End Sub

    Private Sub HelpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HelpToolStripMenuItem.Click
        Timerxy.Start()
    End Sub

    Private Sub SizeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SizeToolStripMenuItem.Click
        Form3.Show()
    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        Form2.Show()
    End Sub

    Private Sub AIToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AIToolStripMenuItem.Click
        AI.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        sizeratio = 9 / 10
    End Sub

    Private Sub FullScreenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FullScreenToolStripMenuItem.Click
        If Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None Then
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
            FullScreenToolStripMenuItem.Text = "Full Screen"
        Else
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            Me.WindowState = FormWindowState.Normal
            Me.WindowState = FormWindowState.Maximized
            FullScreenToolStripMenuItem.Text = "Exit Full Screen"
        End If


    End Sub

    Private Sub AdjustFocalPointToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdjustFocalPointToolStripMenuItem.Click
        Ratio.Show()
    End Sub


    'outputs population and energy values to a spreadsheet
    Private Sub LogDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogDataToolStripMenuItem.Click
        SaveFileDialog1.ShowDialog()
        oExcel = CreateObject("Excel.Application")
        oBook = oExcel.Workbooks.Add
        oSheet = oBook.Worksheets(1)
        oSheet2 = oBook.Worksheets(2)
        oSheet.name = "Population"
        oSheet2.name = "Energy"

        oSheet.Cells(1, 1) = "Tick"
        oSheet2.Cells(1, 1) = "Tick"
        For i = 1 To agent
            oSheet.Cells(1, i + 1) = generator.agentname(i)
            oSheet2.Cells(1, i + 1) = generator.agentname(i)
        Next

        logged = True
    End Sub

    Private Sub FoodWebToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles collisionToolStripMenuItem.Click
        Form5.Show()
    End Sub

    Private Sub DataSheetToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataSheetToolStripMenuItem.Click
        Form4.Show()
    End Sub

    Private Sub SaveFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk
        Dim Filetosaveas As String = SaveFileDialog1.FileName
        'Dim obj As New System.IO.StreamWriter(Filetosaveas)
        ' obj.Write(oBook)
        'obj.Close()
        'exceldir = SaveFileDialog1.InitialDirectory

        exceldir = SaveFileDialog1.FileName

    End Sub

    'agents with a smaller number (ie. 1, 2 etc) have a larger z-value
    Sub sortxy()
        For index = 2 To total + 1
            Dim tempz As Integer = generator.agentlocation(index, 2)
            Dim tempx As Integer = generator.agentlocation(index, 0)
            Dim tempy As Integer = generator.agentlocation(index, 1)
            Dim tempd As Integer = generator.agentlocation(index, 3)
            Dim tempa As Integer = generator.agentlocation(index, 4)
            Dim tempstatic As Integer = generator.staticagent(index)
            Dim tempreservoir(2) As Integer
            tempreservoir(0) = generator.agentreservoir(index, 0)
            tempreservoir(1) = generator.agentreservoir(index, 1)
            tempreservoir(2) = generator.agentreservoir(index, 2)

            Dim tempdx As Integer = generator.agentlocation(index, 5)
            Dim tempdy As Integer = generator.agentlocation(index, 6)
            Dim tempdz As Integer = generator.agentlocation(index, 7)

            Dim tempenergy As Integer = generator.agentlocation(index, 8)
            Dim tempage As Integer = generator.agentlocation(index, 9)
            Dim tempasr As Integer = generator.agentlocation(index, 10)

            Dim previousposition As Integer = index - 1

            Do While tempz > generator.agentlocation(previousposition, 2) And previousposition >= 1

                generator.agentlocation(previousposition + 1, 0) = generator.agentlocation(previousposition, 0)
                generator.agentlocation(previousposition + 1, 1) = generator.agentlocation(previousposition, 1)
                generator.agentlocation(previousposition + 1, 2) = generator.agentlocation(previousposition, 2)
                generator.agentlocation(previousposition + 1, 3) = generator.agentlocation(previousposition, 3)
                generator.agentlocation(previousposition + 1, 4) = generator.agentlocation(previousposition, 4)

                generator.agentlocation(previousposition + 1, 5) = generator.agentlocation(previousposition, 5)
                generator.agentlocation(previousposition + 1, 6) = generator.agentlocation(previousposition, 6)
                generator.agentlocation(previousposition + 1, 7) = generator.agentlocation(previousposition, 7)

                generator.agentlocation(previousposition + 1, 8) = generator.agentlocation(previousposition, 8)
                generator.agentlocation(previousposition + 1, 9) = generator.agentlocation(previousposition, 9)
                generator.agentlocation(previousposition + 1, 10) = generator.agentlocation(previousposition, 10)

                'makes sure the new agent is static if the previous one was static
                If generator.staticagent(previousposition) = 2 Then
                    generator.staticagent(previousposition + 1) = 2
                ElseIf generator.staticagent(previousposition) = 0 Then
                    generator.staticagent(previousposition + 1) = 0
                End If

                If generator.agentreservoir(previousposition, 0) = 2 Then
                    generator.agentreservoir(previousposition + 1, 0) = 2
                    generator.agentreservoir(previousposition + 1, 1) = generator.agentreservoir(previousposition, 1)
                    generator.agentreservoir(previousposition + 1, 2) = generator.agentreservoir(previousposition, 2)
                ElseIf generator.agentreservoir(previousposition, 0) = 0 Then
                    generator.agentreservoir(previousposition + 1, 0) = 0
                    generator.agentreservoir(previousposition + 1, 1) = 0
                    generator.agentreservoir(previousposition + 1, 2) = 0
                End If

                previousposition = previousposition - 1

            Loop

            'makes sure the new agent is static if the previous one was static
            If tempstatic = 2 Then
                generator.staticagent(previousposition + 1) = 2
            ElseIf tempstatic = 0 Then
                generator.staticagent(previousposition + 1) = 0
            End If

            If tempreservoir(0) = 2 Then
                generator.agentreservoir(previousposition + 1, 0) = 2
                generator.agentreservoir(previousposition + 1, 1) = tempreservoir(1)
                generator.agentreservoir(previousposition + 1, 2) = tempreservoir(2)
            ElseIf tempreservoir(0) = 0 Then
                generator.agentreservoir(previousposition + 1, 0) = 0
                generator.agentreservoir(previousposition + 1, 1) = 0
                generator.agentreservoir(previousposition + 1, 2) = 0
            End If

            generator.agentlocation(previousposition + 1, 2) = tempz
            generator.agentlocation(previousposition + 1, 0) = tempx
                generator.agentlocation(previousposition + 1, 1) = tempy
                generator.agentlocation(previousposition + 1, 3) = tempd
                generator.agentlocation(previousposition + 1, 4) = tempa

                generator.agentlocation(previousposition + 1, 5) = tempdx
                generator.agentlocation(previousposition + 1, 6) = tempdy
                generator.agentlocation(previousposition + 1, 7) = tempdz

                generator.agentlocation(previousposition + 1, 8) = tempenergy
                generator.agentlocation(previousposition + 1, 9) = tempage
                generator.agentlocation(previousposition + 1, 10) = tempasr


        Next
    End Sub

    Sub sortxz()
        For index = 2 To total + 1
            Dim tempz As Integer = generator.agentlocation(index, 2)
            Dim tempx As Integer = generator.agentlocation(index, 0)
            Dim tempy As Integer = generator.agentlocation(index, 1)
            Dim tempd As Integer = generator.agentlocation(index, 3)
            Dim tempa As Integer = generator.agentlocation(index, 4)
            Dim tempstatic As Integer = generator.staticagent(index)
            Dim tempreservoir(2) As Integer
            tempreservoir(0) = generator.agentreservoir(index, 0)
            tempreservoir(1) = generator.agentreservoir(index, 1)
            tempreservoir(2) = generator.agentreservoir(index, 2)

            Dim tempdx As Integer = generator.agentlocation(index, 5)
            Dim tempdy As Integer = generator.agentlocation(index, 6)
            Dim tempdz As Integer = generator.agentlocation(index, 7)

            Dim tempenergy As Integer = generator.agentlocation(index, 8)
            Dim tempage As Integer = generator.agentlocation(index, 9)
            Dim tempasr As Integer = generator.agentlocation(index, 10)

            Dim previousposition As Integer = index - 1
            Do While tempy > generator.agentlocation(previousposition, 1) And previousposition >= 1

                generator.agentlocation(previousposition + 1, 0) = generator.agentlocation(previousposition, 0)
                    generator.agentlocation(previousposition + 1, 1) = generator.agentlocation(previousposition, 1)
                    generator.agentlocation(previousposition + 1, 2) = generator.agentlocation(previousposition, 2)
                    generator.agentlocation(previousposition + 1, 3) = generator.agentlocation(previousposition, 3)
                    generator.agentlocation(previousposition + 1, 4) = generator.agentlocation(previousposition, 4)

                    generator.agentlocation(previousposition + 1, 5) = generator.agentlocation(previousposition, 5)
                    generator.agentlocation(previousposition + 1, 6) = generator.agentlocation(previousposition, 6)
                    generator.agentlocation(previousposition + 1, 7) = generator.agentlocation(previousposition, 7)

                    generator.agentlocation(previousposition + 1, 8) = generator.agentlocation(previousposition, 8)
                    generator.agentlocation(previousposition + 1, 9) = generator.agentlocation(previousposition, 9)
                    generator.agentlocation(previousposition + 1, 10) = generator.agentlocation(previousposition, 10)

                If generator.staticagent(previousposition) = 2 Then
                    generator.staticagent(previousposition + 1) = 2
                ElseIf generator.staticagent(previousposition) = 0 Then
                    generator.staticagent(previousposition + 1) = 0
                End If

                If generator.agentreservoir(previousposition, 0) = 2 Then
                    generator.agentreservoir(previousposition + 1, 0) = 2
                    generator.agentreservoir(previousposition + 1, 1) = generator.agentreservoir(previousposition, 1)
                    generator.agentreservoir(previousposition + 1, 2) = generator.agentreservoir(previousposition, 2)
                ElseIf generator.agentreservoir(previousposition, 0) = 0 Then
                    generator.agentreservoir(previousposition + 1, 0) = 0
                    generator.agentreservoir(previousposition + 1, 1) = 0
                    generator.agentreservoir(previousposition + 1, 2) = 0
                End If

                previousposition = previousposition - 1


            Loop

            If tempstatic = 2 Then
                generator.staticagent(previousposition + 1) = 2
            ElseIf tempstatic = 0 Then
                generator.staticagent(previousposition + 1) = 0
            End If

            If tempreservoir(0) = 2 Then
                generator.agentreservoir(previousposition + 1, 0) = 2
                generator.agentreservoir(previousposition + 1, 1) = tempreservoir(1)
                generator.agentreservoir(previousposition + 1, 2) = tempreservoir(2)
            ElseIf tempreservoir(0) = 0 Then
                generator.agentreservoir(previousposition + 1, 0) = 0
                generator.agentreservoir(previousposition + 1, 1) = 0
                generator.agentreservoir(previousposition + 1, 2) = 0
            End If

            generator.agentlocation(previousposition + 1, 2) = tempz
                generator.agentlocation(previousposition + 1, 0) = tempx
                generator.agentlocation(previousposition + 1, 1) = tempy
                generator.agentlocation(previousposition + 1, 3) = tempd
                generator.agentlocation(previousposition + 1, 4) = tempa

                generator.agentlocation(previousposition + 1, 5) = tempdx
                generator.agentlocation(previousposition + 1, 6) = tempdy
                generator.agentlocation(previousposition + 1, 7) = tempdz

                generator.agentlocation(previousposition + 1, 8) = tempenergy
                generator.agentlocation(previousposition + 1, 9) = tempage
                generator.agentlocation(previousposition + 1, 10) = tempasr


        Next
    End Sub

    Sub sortzy()
        For index = 2 To total + 1
            Dim tempz As Integer = generator.agentlocation(index, 2)
            Dim tempx As Integer = generator.agentlocation(index, 0)
            Dim tempy As Integer = generator.agentlocation(index, 1)
            Dim tempd As Integer = generator.agentlocation(index, 3)
            Dim tempa As Integer = generator.agentlocation(index, 4)
            Dim tempstatic As Integer = generator.staticagent(index)
            Dim tempreservoir(2) As Integer
            tempreservoir(0) = generator.agentreservoir(index, 0)
            tempreservoir(1) = generator.agentreservoir(index, 1)
            tempreservoir(2) = generator.agentreservoir(index, 2)

            Dim tempdx As Integer = generator.agentlocation(index, 5)
            Dim tempdy As Integer = generator.agentlocation(index, 6)
            Dim tempdz As Integer = generator.agentlocation(index, 7)

            Dim tempenergy As Integer = generator.agentlocation(index, 8)
            Dim tempage As Integer = generator.agentlocation(index, 9)
            Dim tempasr As Integer = generator.agentlocation(index, 10)

            Dim previousposition As Integer = index - 1
            Do While tempx > generator.agentlocation(previousposition, 0) And previousposition >= 1

                generator.agentlocation(previousposition + 1, 0) = generator.agentlocation(previousposition, 0)
                generator.agentlocation(previousposition + 1, 1) = generator.agentlocation(previousposition, 1)
                generator.agentlocation(previousposition + 1, 2) = generator.agentlocation(previousposition, 2)
                generator.agentlocation(previousposition + 1, 3) = generator.agentlocation(previousposition, 3)
                generator.agentlocation(previousposition + 1, 4) = generator.agentlocation(previousposition, 4)

                generator.agentlocation(previousposition + 1, 5) = generator.agentlocation(previousposition, 5)
                generator.agentlocation(previousposition + 1, 6) = generator.agentlocation(previousposition, 6)
                generator.agentlocation(previousposition + 1, 7) = generator.agentlocation(previousposition, 7)

                generator.agentlocation(previousposition + 1, 8) = generator.agentlocation(previousposition, 8)
                generator.agentlocation(previousposition + 1, 9) = generator.agentlocation(previousposition, 9)
                generator.agentlocation(previousposition + 1, 10) = generator.agentlocation(previousposition, 10)

                If generator.staticagent(previousposition) = 2 Then
                    generator.staticagent(previousposition + 1) = 2
                ElseIf generator.staticagent(previousposition) = 0 Then
                    generator.staticagent(previousposition + 1) = 0
                End If

                If generator.agentreservoir(previousposition, 0) = 2 Then
                    generator.agentreservoir(previousposition + 1, 0) = 2
                    generator.agentreservoir(previousposition + 1, 1) = generator.agentreservoir(previousposition, 1)
                    generator.agentreservoir(previousposition + 1, 2) = generator.agentreservoir(previousposition, 2)
                ElseIf generator.agentreservoir(previousposition, 0) = 0 Then
                    generator.agentreservoir(previousposition + 1, 0) = 0
                    generator.agentreservoir(previousposition + 1, 1) = 0
                    generator.agentreservoir(previousposition + 1, 2) = 0
                End If

                previousposition = previousposition - 1


            Loop

            If tempstatic = 2 Then
                generator.staticagent(previousposition + 1) = 2
            ElseIf tempstatic = 0 Then
                generator.staticagent(previousposition + 1) = 0
            End If

            If tempreservoir(0) = 2 Then
                generator.agentreservoir(previousposition + 1, 0) = 2
                generator.agentreservoir(previousposition + 1, 1) = tempreservoir(1)
                generator.agentreservoir(previousposition + 1, 2) = tempreservoir(2)
            ElseIf tempreservoir(0) = 0 Then
                generator.agentreservoir(previousposition + 1, 0) = 0
                generator.agentreservoir(previousposition + 1, 1) = 0
                generator.agentreservoir(previousposition + 1, 2) = 0
            End If

            generator.agentlocation(previousposition + 1, 2) = tempz
            generator.agentlocation(previousposition + 1, 0) = tempx
            generator.agentlocation(previousposition + 1, 1) = tempy
            generator.agentlocation(previousposition + 1, 3) = tempd
            generator.agentlocation(previousposition + 1, 4) = tempa

            generator.agentlocation(previousposition + 1, 5) = tempdx
            generator.agentlocation(previousposition + 1, 6) = tempdy
            generator.agentlocation(previousposition + 1, 7) = tempdz

            generator.agentlocation(previousposition + 1, 8) = tempenergy
            generator.agentlocation(previousposition + 1, 9) = tempage
            generator.agentlocation(previousposition + 1, 10) = tempasr

        Next
    End Sub

    Sub placingagentsxy()
        For i = 1 To total
            Dim x As Integer = generator.agentlocation(i, 0)
            Dim y As Integer = generator.agentlocation(i, 1)
            Dim z As Integer = generator.agentlocation(i, 2)
            Dim d As Integer = generator.agentlocation(i, 3)
            Dim ag As Integer = generator.agentlocation(i, 4)
            Dim s As Integer = i
            Call creator(x, y, z, d, generator.agentcolour(ag), s)
        Next
    End Sub

    Sub placingagentsxz()
        For i = 1 To total
            Dim x As Integer = generator.agentlocation(i, 0)
            Dim y As Integer = generator.agentlocation(i, 1)
            Dim z As Integer = generator.agentlocation(i, 2)
            Dim d As Integer = generator.agentlocation(i, 3)
            Dim ag As Integer = generator.agentlocation(i, 4)
            Dim s As Integer = i
            Call creatorxz(x, y, z, d, generator.agentcolour(ag), s)
        Next
    End Sub

    Sub placingagentszy()
        For i = 1 To total
            Dim x As Integer = generator.agentlocation(i, 0)
            Dim y As Integer = generator.agentlocation(i, 1)
            Dim z As Integer = generator.agentlocation(i, 2)
            Dim d As Integer = generator.agentlocation(i, 3)
            Dim ag As Integer = generator.agentlocation(i, 4)
            Dim s As Integer = i
            Call creatorzy(x, y, z, d, generator.agentcolour(ag), s)
        Next
    End Sub

    'doesn't save agent location
    Private Sub SaveProjectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveProjectToolStripMenuItem.Click
        save = ""
        save = xn & "_" & yn & "_" & zn & "_" & agent & "_"

        For i = 1 To agent
            save = save & generator.agentname(i) & "_"
        Next

        For i = 1 To agent
            save = save & generator.agentcount(i) & "_"
        Next

        For i = 1 To agent
            save = save & generator.initialenergy(i) & "_"
        Next

        For i = 1 To agent
            save = save & generator.stepenergy(i) & "_"
        Next

        For i = 1 To agent
            save = save & generator.bumpenergy(i) & "_"
        Next


        For i = 1 To agent
            save = save & generator.aging(i) & "_"
        Next


        For i = 1 To agent
            save = save & generator.agelimit(i) & "_"
        Next


        For i = 1 To agent
            save = save & generator.asr(i) & "_"
        Next


        For i = 1 To agent
            save = save & generator.asrtime(i) & "_"
        Next

        For i = 1 To agent
            save = save & generator.asrenergy(i) & "_"
        Next


        For i = 1 To agent
            Dim colourconverter As New System.Drawing.ColorConverter
            save = save & colourconverter.ConvertToString(generator.agentcolour(i)) & "_"
        Next


        For i = 1 To agent
            save = save & generator.agentrangeabsolute(i) & "_"
        Next


        For a = 1 To agent
            For b = 0 To 2
                For c = 0 To 1
                    save = save & generator.agentrange(a, b, c) & "_"
                Next
            Next
        Next


        For a = 1 To agent
            For b = 1 To agent
                For c = 1 To 6
                    For d = 0 To agent
                        For ee = 0 To 1
                            save = save & generator.action(a, b, c, d, ee) & "_"
                        Next
                    Next
                Next
            Next
        Next

        'saves x location
        For i = 1 To total
            save = save & generator.agentlocation(i, 0) & "_"
        Next

        'saves y location
        For i = 1 To total
            save = save & generator.agentlocation(i, 1) & "_"
        Next

        'saves z location
        For i = 1 To total
            save = save & generator.agentlocation(i, 2) & "_"
        Next

        For i = 1 To total
            save = save & generator.agentlocation(i, 4) & "_"
        Next

        For i = 1 To total
            save = save & generator.agentlocation(i, 3) & "_"
        Next

        For i = 1 To agent
            save = save & generator.staticagentid(i) & "_"
        Next

        save = save & "|"
        SaveFilepro.ShowDialog()
    End Sub

    Private Sub SaveFilepro_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SaveFilepro.FileOk
        Dim objwriter As New System.IO.StreamWriter(SaveFilepro.FileName)
        objwriter.Write(save)
        objwriter.Close()
    End Sub

    Private Sub TickToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TickToolStripMenuItem.Click
        Timerxy.Start()
        timerexit = True
    End Sub

    Private Sub CreditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreditToolStripMenuItem.Click
        MsgBox("Instructor: Dr. Brad Bass" & vbCrLf & "Programmer: Mohammad Zavvarian" & vbCrLf & "Additional programming by: Neilket Patel")
    End Sub

    Private Sub OpenProjectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenProjectToolStripMenuItem.Click
        OpenFilepro.ShowDialog()
    End Sub

    Private Sub OpenFilepro_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFilepro.FileOk
        Dim objreader As New System.IO.StreamReader(OpenFilepro.FileName)
        save = objreader.ReadToEnd
        objreader.Close()

        Dim import(400000) As String
        Dim n As Integer

        For i = 1 To 400000
            n = 0
            Do Until save.Substring(n, 1) = "_"
                n = n + 1
                import(i) = save.Substring(0, n)
            Loop
            If save.Substring(n + 1, 1) = "|" Then
                Exit For
            End If
            save = save.Substring(1 + n)
        Next


        '....

        xn = import(1)
        yn = import(2)
        zn = import(3)
        agent = import(4)

        Dim ratio1 As Single = yn / xn
        Dim ratio2 As Single = zn / xn
        Dim ratio3 As Single = yn / zn
        Dim res As Integer = 2073600

        sizexyx = (res / ratio1) ^ 0.5
        sizexyy = ratio1 * sizexyx

        sizexzx = (res / ratio2) ^ 0.5
        sizexzz = ratio2 * sizexzx

        sizezyz = (res / ratio3) ^ 0.5
        sizezyy = ratio3 * sizezyz


        cellxyx = sizexyx / xn
        cellxyy = sizexyy / yn

        cellxzx = sizexzx / xn
        cellxzz = sizexzz / zn

        cellzyz = sizezyz / zn
        cellzyy = sizezyy / yn


        generator.Close()
        generator.Show()


        SizeToolStripMenuItem.Enabled = True
        AIToolStripMenuItem.Enabled = True
        collisionToolStripMenuItem.Enabled = True



        '....

        Dim lastimport As Integer

        For i = 1 To agent
            lastimport = 4 + i
            generator.agentname(i) = import(lastimport)
        Next

        Dim tot As Integer

        For i = 1 To agent
            lastimport = lastimport + 1
            generator.agentcount(i) = import(lastimport)
            tot += import(lastimport)
        Next


        For i = 1 To agent
            lastimport = lastimport + 1
            generator.initialenergy(i) = import(lastimport)
        Next


        For i = 1 To agent
            lastimport = lastimport + 1
            generator.stepenergy(i) = import(lastimport)
        Next


        For i = 1 To agent
            lastimport = lastimport + 1
            generator.bumpenergy(i) = import(lastimport)
        Next

        For i = 1 To agent
            lastimport = lastimport + 1
            generator.aging(i) = import(lastimport)
        Next


        For i = 1 To agent
            lastimport = lastimport + 1
            generator.agelimit(i) = import(lastimport)
        Next

        For i = 1 To agent
            lastimport = lastimport + 1
            generator.asr(i) = import(lastimport)
        Next


        For i = 1 To agent
            lastimport = lastimport + 1
            generator.asrtime(i) = import(lastimport)
        Next

        For i = 1 To agent
            lastimport = lastimport + 1
            generator.asrenergy(i) = import(lastimport)
        Next

        For i = 1 To agent
            lastimport = lastimport + 1
            Dim colourconverter As New System.Drawing.ColorConverter
            generator.agentcolour(i) = colourconverter.ConvertFromString(import(lastimport))
        Next


        For i = 1 To agent
            lastimport = lastimport + 1
            generator.agentrangeabsolute(i) = import(lastimport)
        Next



        For a = 1 To agent
            For b = 0 To 2
                For c = 0 To 1
                    lastimport = lastimport + 1
                    generator.agentrange(a, b, c) = import(lastimport)
                Next
            Next
        Next


        For a = 1 To agent
            For b = 1 To agent
                For c = 1 To 6
                    For d = 0 To agent
                        For ee = 0 To 1
                            lastimport = lastimport + 1
                            generator.action(a, b, c, d, ee) = import(lastimport)
                        Next
                    Next
                Next
            Next
        Next

        Dim agloc(tot, 4)

        For i = 1 To tot
            lastimport += 1
            agloc(i, 0) = import(lastimport)
        Next

        For i = 1 To tot
            lastimport += 1
            agloc(i, 1) = import(lastimport)
        Next

        For i = 1 To tot
            lastimport += 1
            agloc(i, 2) = import(lastimport)
        Next

        For i = 1 To tot
            lastimport += 1
            agloc(i, 3) = import(lastimport)
        Next

        For i = 1 To tot
            lastimport += 1
            agloc(i, 4) = import(lastimport)
        Next

        For i = 1 To agent
            lastimport += 1
            generator.staticagentid(i) = import(lastimport)
        Next

        '........applying the setting..............
        Randomize()
        total = 0

        Dim number As Integer
        For a = 1 To agent
            Dim m As Integer = 0
            For i = 1 To generator.agentcount(a)
                number = number + 1
                Dim x As Integer = CInt(Math.Floor((xn) * Rnd())) + 1
                Dim y As Integer = CInt(Math.Floor((yn) * Rnd())) + 1
                Dim z As Integer = CInt(Math.Floor((zn) * Rnd())) + 1

                Dim dx As Integer
                Dim dy As Integer
                Dim dz As Integer

                Dim rangexupper As Integer = generator.agentrange(a, 0, 1)
                Dim rangexlower As Integer = generator.agentrange(a, 0, 0)
                Dim rangeyupper As Integer = generator.agentrange(a, 1, 1)
                Dim rangeylower As Integer = generator.agentrange(a, 1, 0)
                Dim rangezupper As Integer = generator.agentrange(a, 2, 1)
                Dim rangezlower As Integer = generator.agentrange(a, 2, 0)

                dx = CInt(Math.Floor((rangexupper - rangexlower + 1) * Rnd())) + rangexlower
                dy = CInt(Math.Floor((rangeyupper - rangeylower + 1) * Rnd())) + rangeylower
                dz = CInt(Math.Floor((rangezupper - rangezlower + 1) * Rnd())) + rangezlower


                Do While generator.occupied(x, y, z) = True
                    x = CInt(Math.Floor((xn) * Rnd())) + 1
                    y = CInt(Math.Floor((yn) * Rnd())) + 1
                    z = CInt(Math.Floor((zn) * Rnd())) + 1
                Loop


                generator.occupied(x, y, z) = True

                Dim d As Integer = CInt(Math.Floor((6) * Rnd())) + 1
                generator.agentlocation(number, 0) = x
                generator.agentlocation(number, 1) = y
                generator.agentlocation(number, 2) = z
                generator.agentlocation(number, 3) = d
                generator.agentlocation(number, 4) = a
                generator.agentlocation(number, 5) = dx
                generator.agentlocation(number, 6) = dy
                generator.agentlocation(number, 7) = dz
                generator.agentlocation(number, 8) = generator.initialenergy(a)
                generator.agentlocation(number, 9) = 0
                generator.agentlocation(number, 10) = 0

                For j = 1 To tot
                    If agloc(j, 3) = a Then
                        If j > m Then
                            m = j
                            generator.agentlocation(number, 0) = agloc(j, 0)
                            generator.agentlocation(number, 1) = agloc(j, 1)
                            generator.agentlocation(number, 2) = agloc(j, 2)
                            generator.agentlocation(number, 3) = agloc(j, 4)
                            Exit For
                        End If
                    End If
                Next

            Next
        Next


        '...........................................................................................................

        For i = 1 To agent
            total = total + generator.agentcount(i)
        Next



        For index = 2 To total
            Dim tempz As Integer = generator.agentlocation(index, 2)
            Dim tempx As Integer = generator.agentlocation(index, 0)
            Dim tempy As Integer = generator.agentlocation(index, 1)
            Dim tempd As Integer = generator.agentlocation(index, 3)
            Dim tempa As Integer = generator.agentlocation(index, 4)

            Dim tempdx As Integer = generator.agentlocation(index, 5)
            Dim tempdy As Integer = generator.agentlocation(index, 6)
            Dim tempdz As Integer = generator.agentlocation(index, 7)

            Dim tempenergy As Integer = generator.agentlocation(index, 8)
            Dim tempage As Integer = generator.agentlocation(index, 9)
            Dim tempasr As Integer = generator.agentlocation(index, 10)

            Dim previousposition As Integer = index - 1
            Do While tempz > generator.agentlocation(previousposition, 2) And previousposition >= 1
                generator.agentlocation(previousposition + 1, 0) = generator.agentlocation(previousposition, 0)
                generator.agentlocation(previousposition + 1, 1) = generator.agentlocation(previousposition, 1)
                generator.agentlocation(previousposition + 1, 2) = generator.agentlocation(previousposition, 2)
                generator.agentlocation(previousposition + 1, 3) = generator.agentlocation(previousposition, 3)
                generator.agentlocation(previousposition + 1, 4) = generator.agentlocation(previousposition, 4)

                generator.agentlocation(previousposition + 1, 5) = generator.agentlocation(previousposition, 5)
                generator.agentlocation(previousposition + 1, 6) = generator.agentlocation(previousposition, 6)
                generator.agentlocation(previousposition + 1, 7) = generator.agentlocation(previousposition, 7)

                generator.agentlocation(previousposition + 1, 8) = generator.agentlocation(previousposition, 8)
                generator.agentlocation(previousposition + 1, 9) = generator.agentlocation(previousposition, 9)
                generator.agentlocation(previousposition + 1, 10) = generator.agentlocation(previousposition, 10)

                previousposition = previousposition - 1
            Loop
            generator.agentlocation(previousposition + 1, 2) = tempz
            generator.agentlocation(previousposition + 1, 0) = tempx
            generator.agentlocation(previousposition + 1, 1) = tempy
            generator.agentlocation(previousposition + 1, 3) = tempd
            generator.agentlocation(previousposition + 1, 4) = tempa

            generator.agentlocation(previousposition + 1, 5) = tempdx
            generator.agentlocation(previousposition + 1, 6) = tempdy
            generator.agentlocation(previousposition + 1, 7) = tempdz

            generator.agentlocation(previousposition + 1, 8) = tempenergy
            generator.agentlocation(previousposition + 1, 9) = tempage
            generator.agentlocation(previousposition + 1, 10) = tempasr

        Next






        generator.gfxxy.Clear(Color.White)
        Call generator.gridxy()

        ' placing the agents
        For i = 1 To total
            Dim x As Integer = generator.agentlocation(i, 0)
            Dim y As Integer = generator.agentlocation(i, 1)
            Dim z As Integer = generator.agentlocation(i, 2)
            Dim d As Integer = generator.agentlocation(i, 3)
            Dim ag As Integer = generator.agentlocation(i, 4)
            Call creator(x, y, z, d, generator.agentcolour(ag), i)
        Next


        Call generator.topgridxy()
        Call picshow()

        tick = 0
        Call staticagentcheck()
    End Sub

    Private Sub InteractionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InteractionsToolStripMenuItem.Click
        frmInteractions.Show()
    End Sub

    Private Sub PopulationGraphToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PopulationGraphToolStripMenuItem.Click
        Form7.Show()
    End Sub

    Private Sub CatalysisToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CatalysisToolStripMenuItem.Click
        frmCatalysis.Show()
    End Sub

    Private Sub AbioticFactorsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AbioticFactorsToolStripMenuItem.Click
        frmAbiotic.Show()
    End Sub

    Private Sub reservoirrelase(ByVal i As Integer)
        For i = 1 To total
            For j = 1 To agent

                If generator.reservoiragentreleased(generator.agentlocation(i, 4), j, 1) <> 0 Then

                    If generator.agentreservoir(i, 2) < generator.reservoiragentreleased(generator.agentlocation(i, 4), j, 2) Then
                        Exit For
                    End If

                    If total + generator.reservoiragentreleased(generator.agentlocation(i, 4), j, 1) <= generator.maxcell Then

                        Dim newagents As Integer
                        Dim placeholder As Integer = generator.reservoiragentreleased(generator.agentlocation(i, 4), j, 1) \ 1
                        Dim diff As Decimal = generator.reservoiragentreleased(generator.agentlocation(i, 4), j, 1) - placeholder

                        If diff > 0 Then
                            Dim dif As Decimal = diff * 100
                            Dim randomvalue As Integer = CInt(Math.Floor(101) * Rnd())
                            If randomvalue > 0 And randomvalue <= dif Then
                                placeholder += 1
                            End If
                        End If

                        newagents = placeholder

                        Dim agenttobeproduced(newagents) As Integer
                        Dim rangexupper As Integer
                        Dim rangexlower As Integer
                        Dim rangeyupper As Integer
                        Dim rangeylower As Integer
                        Dim rangezupper As Integer
                        Dim rangezlower As Integer

                        For k = 1 To newagents
                            agenttobeproduced(k) = j
                        Next

                        For k = 1 To newagents
                            total = total + 1


                            rangexupper = generator.reservoiragentreleased(generator.agentlocation(i, 4), j, 3) + generator.agentlocation(i, 0)
                            rangexlower = generator.agentlocation(i, 0) - generator.reservoiragentreleased(generator.agentlocation(i, 4), j, 3)
                            rangeyupper = generator.reservoiragentreleased(generator.agentlocation(i, 4), j, 4) + generator.agentlocation(i, 1)
                            rangeylower = generator.agentlocation(i, 1) - generator.reservoiragentreleased(generator.agentlocation(i, 4), j, 4)
                            rangezupper = generator.reservoiragentreleased(generator.agentlocation(i, 4), j, 5) + generator.agentlocation(i, 2)
                            rangezlower = generator.agentlocation(i, 2) - generator.reservoiragentreleased(generator.agentlocation(i, 4), j, 5)

                            If rangexlower < 1 Then
                                rangexlower = 1
                            End If
                            If rangeylower < 1 Then
                                rangeylower = 1
                            End If
                            If rangezlower < 1 Then
                                rangezlower = 1
                            End If
                            If rangexupper > xn Then
                                rangexupper = xn
                            End If
                            If rangeyupper > yn Then
                                rangeyupper = yn
                            End If
                            If rangezupper > zn Then
                                rangezupper = zn
                            End If

                            Dim x As Integer = CInt(Math.Floor((rangexupper - rangexlower + 1) * Rnd())) + rangexlower
                            Dim y As Integer = CInt(Math.Floor((rangeyupper - rangeylower + 1) * Rnd())) + rangeylower
                            Dim z As Integer = CInt(Math.Floor((rangezupper - rangezlower + 1) * Rnd())) + rangezlower
                            Dim dx As Integer = CInt(Math.Floor((xn) * Rnd())) + 1
                            Dim dy As Integer = CInt(Math.Floor((yn) * Rnd())) + 1
                            Dim dz As Integer = CInt(Math.Floor((zn) * Rnd())) + 1

                            Dim number As Integer = 0
                            Do While generator.occupied(x, y, z) = True And number < generator.maxcell
                                number = number + 1
                                x = CInt(Math.Floor((rangexupper - rangexlower + 1) * Rnd())) + rangexlower
                                y = CInt(Math.Floor((rangeyupper - rangeylower + 1) * Rnd())) + rangeylower
                                z = CInt(Math.Floor((rangezupper - rangezlower + 1) * Rnd())) + rangezlower
                            Loop


                            generator.occupied(x, y, z) = True

                            Dim d As Integer = CInt(Math.Floor((6) * Rnd())) + 1
                            generator.agentlocation(total, 0) = x
                            generator.agentlocation(total, 1) = y
                            generator.agentlocation(total, 2) = z
                            generator.agentlocation(total, 3) = d
                            generator.agentlocation(total, 4) = agenttobeproduced(k)
                            generator.agentlocation(total, 5) = dx
                            generator.agentlocation(total, 6) = dy
                            generator.agentlocation(total, 7) = dz
                            generator.agentlocation(total, 8) = generator.initialenergy(agenttobeproduced(k))
                            generator.agentlocation(total, 9) = 0
                            generator.agentlocation(total, 10) = 0

                            generator.agentreservoir(i, 2) -= generator.reservoiragentreleased(generator.agentlocation(i, 4), j, 2)

                            If generator.agentreservoir(i, 2) < generator.reservoiragentreleased(generator.agentlocation(i, 4), j, 2) Then
                                Exit Sub
                            End If
                        Next

                        If viewlabel.Text = "Top View (x,z)" Then
                            'placing the agents
                            generator.gfxxz.Clear(Color.White)
                            Call generator.gridxz()
                            generator.agentchange = True
                            For iii = 1 To total
                                Dim x As Integer = generator.agentlocation(iii, 0)
                                Dim y As Integer = generator.agentlocation(iii, 1)
                                Dim z As Integer = generator.agentlocation(iii, 2)
                                Dim d As Integer = generator.agentlocation(iii, 3)
                                Dim ag As Integer = generator.agentlocation(iii, 4)
                                Call creator(x, y, z, d, generator.agentcolour(ag), iii)
                            Next
                            Call generator.topgridxz()
                            Call picshow()

                        ElseIf viewlabel.Text = "Side View (x,y)" Then
                            'placing the agents
                            generator.gfxxy.Clear(Color.White)
                            Call generator.gridxy()
                            generator.agentchange = True
                            For iii = 1 To total
                                Dim x As Integer = generator.agentlocation(iii, 0)
                                Dim y As Integer = generator.agentlocation(iii, 1)
                                Dim z As Integer = generator.agentlocation(iii, 2)
                                Dim d As Integer = generator.agentlocation(iii, 3)
                                Dim ag As Integer = generator.agentlocation(iii, 4)
                                Call creator(x, y, z, d, generator.agentcolour(ag), iii)
                            Next
                            Call generator.topgridxy()
                            Call picshow()

                        ElseIf viewlabel.Text = "Side View (z,y)" Then
                            'placing the agents
                            generator.gfxzy.Clear(Color.White)
                            Call generator.gridzy()
                            generator.agentchange = True
                            For iii = 1 To total
                                Dim x As Integer = generator.agentlocation(iii, 0)
                                Dim y As Integer = generator.agentlocation(iii, 1)
                                Dim z As Integer = generator.agentlocation(iii, 2)
                                Dim d As Integer = generator.agentlocation(iii, 3)
                                Dim ag As Integer = generator.agentlocation(iii, 4)
                                Call creator(x, y, z, d, generator.agentcolour(ag), iii)
                            Next
                            Call generator.topgridzy()
                            Call picshow()

                        End If

                    End If
                    generator.agentchange = True

                End If
            Next
        Next
    End Sub

    Private Sub InSpecificPositionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InSpecificPositionsToolStripMenuItem.Click
        frmCrossSection.Show()
    End Sub

    Private Sub InRangeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InRangeToolStripMenuItem.Click
        frmAdd.Show()
    End Sub
End Class
