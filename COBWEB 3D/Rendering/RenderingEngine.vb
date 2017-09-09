Imports COBWEB_3D

Public Class RenderingEngine
    Public mRenderTarget As Bitmap
    Public Shared mGraphicsContext As Graphics

    Private mPrespective As Prespective = Prespective.XY
    Private mSizeRatio As Double = 3 / 4

    Private mWorldSize_X, mWorldSize_Y, mWorldSize_Z As Integer

    ' The variables for the resolution of the picture
    Private mResolution As Integer = 2073600

    Private mSizeXY_X, mSizeXY_Y As Integer
    Private mSizeXZ_X, mSizeXZ_Z As Integer
    Private mSizeZY_Z, mSizeZY_Y As Integer

    Private mCellXY_X, mCellXY_Y As Integer 'Pixels
    Private mCellXZ_X, mCellXZ_Z As Integer
    Private mCellZY_Z, mCellZY_Y As Integer

    Public Property Prespective As Prespective
        Get
            Return mPrespective
        End Get
        Set(value As Prespective)
            mPrespective = value
            recreateRenderTarget()
        End Set
    End Property
    Public Property SizeRatio As Double
        Get
            Return mSizeRatio
        End Get
        Set(value As Double)
            mSizeRatio = value
        End Set
    End Property

    Public Sub New(ByVal worldSizeX As Integer, ByVal worldSizeY As Integer, ByVal worldSizeZ As Integer)
        onWorldSizeChanged(worldSizeX, worldSizeY, worldSizeZ)
    End Sub

    Public Sub onWorldSizeChanged(ByVal worldSizeX As Integer, ByVal worldSizeY As Integer, ByVal worldSizeZ As Integer)
        mWorldSize_X = worldSizeX
        mWorldSize_Y = worldSizeY
        mWorldSize_Z = worldSizeZ
        calculateResolutionDimensions()
    End Sub

    Private Sub calculateResolutionDimensions()
        If (mWorldSize_X = 0 Or mWorldSize_Y = 0 Or mWorldSize_Z = 0) Then Return ' Avoid division by zero!
        Dim ratio1 As Single = mWorldSize_Y / mWorldSize_X
        Dim ratio2 As Single = mWorldSize_Z / mWorldSize_X
        Dim ratio3 As Single = mWorldSize_Y / mWorldSize_Z

        mSizeXY_X = (mResolution / ratio1) ^ 0.5
        mSizeXY_Y = ratio1 * mSizeXY_X

        mSizeXZ_X = (mResolution / ratio2) ^ 0.5
        mSizeXZ_Z = ratio2 * mSizeXZ_X

        mSizeZY_Z = (mResolution / ratio3) ^ 0.5
        mSizeZY_Y = ratio3 * mSizeZY_Z

        mCellXY_X = mSizeXY_X / mWorldSize_X
        mCellXY_Y = mSizeXY_Y / mWorldSize_Y

        mCellXZ_X = mSizeXZ_X / mWorldSize_X
        mCellXZ_Z = mSizeXZ_Z / mWorldSize_Z

        mCellZY_Z = mSizeZY_Z / mWorldSize_Z
        mCellZY_Y = mSizeZY_Y / mWorldSize_Y

        recreateRenderTarget()
    End Sub

    Private Sub recreateRenderTarget()
        If mRenderTarget IsNot Nothing Then mRenderTarget.Dispose()
        If mGraphicsContext IsNot Nothing Then mGraphicsContext.Dispose()
        Select Case mPrespective
            Case Prespective.XY
                mRenderTarget = New Bitmap(mSizeXY_X, mSizeXY_Y)
            Case Prespective.XZ
                mRenderTarget = New Bitmap(mSizeXZ_X, mSizeXZ_Z)
            Case Prespective.ZY
                mRenderTarget = New Bitmap(mSizeZY_Z, mSizeZY_Y)
        End Select

        mGraphicsContext = Graphics.FromImage(mRenderTarget)
    End Sub

    Public Sub renderGrid(ByRef graphicsContext As Graphics, Optional ByVal depth As Integer = Integer.MaxValue)
        Dim backgrid As System.Drawing.Pen = New Pen(Brushes.DarkGray, 1)
        Dim skeleton As System.Drawing.Pen = New Pen(Brushes.Gray, 1)
        Dim light As System.Drawing.Pen = New Pen(Brushes.Silver, 1)

        Dim jumpHorizontal As Single = mCellXY_X
        Dim jumpVertical As Single = mCellXY_Y

        Dim projHorizontalCellSize = mSizeXY_X
        Dim projVerticalCellSize = mSizeXY_Y

        Dim projHorizontalWorldSize = mWorldSize_X
        Dim projVerticalWorldSize = mWorldSize_Y
        Dim projDepthWorldSize = mWorldSize_Z

        ' Project the coordinates to our perspective
        Select Case Prespective
            Case Prespective.XZ 'Top
                jumpHorizontal = mCellXZ_X
                jumpVertical = mCellXZ_Z

                projHorizontalCellSize = mSizeXZ_X
                projVerticalCellSize = mSizeXZ_Z

                projHorizontalWorldSize = mWorldSize_X
                projVerticalWorldSize = mWorldSize_Z
                projDepthWorldSize = mWorldSize_Y

            Case Prespective.ZY
                jumpHorizontal = mCellZY_Z
                jumpVertical = mCellZY_Y

                projHorizontalCellSize = mSizeZY_Z
                projVerticalCellSize = mSizeZY_Y

                projHorizontalWorldSize = mWorldSize_Z
                projVerticalWorldSize = mWorldSize_Y
                projDepthWorldSize = mWorldSize_X
        End Select

        Dim angle As Single = Math.Atan(projHorizontalWorldSize / projVerticalWorldSize)
        Dim a As Integer
        Dim b As Integer
        Dim jump As Double = jumpHorizontal
        Dim diag As Single
        For i = 1 To Math.Min(projDepthWorldSize, depth)
            jump = jump * Me.SizeRatio
            diag = diag + jump
            a = Math.Sin(angle) * diag
            b = Math.Cos(angle) * diag
            graphicsContext.DrawLine(backgrid, a, b, projHorizontalCellSize - a, b)
            graphicsContext.DrawLine(backgrid, a, projVerticalCellSize - b, projHorizontalCellSize - a, projVerticalCellSize - b)
            graphicsContext.DrawLine(backgrid, a, b, a, projVerticalCellSize - b)
            graphicsContext.DrawLine(backgrid, projHorizontalCellSize - a, b, projHorizontalCellSize - a, projVerticalCellSize - b)
            If i = Math.Min(projDepthWorldSize, depth) Then
                Dim cell As Single = (projHorizontalCellSize - (a * 2)) / projHorizontalWorldSize
                Dim celly As Single = (projVerticalCellSize - (b * 2)) / projVerticalWorldSize
                For j = 1 To projHorizontalWorldSize - 1
                    graphicsContext.DrawLine(backgrid, a + (cell * j), b, (jumpHorizontal * j), 0)
                    graphicsContext.DrawLine(backgrid, a + (cell * j), projVerticalCellSize - b, (jumpHorizontal * j), projVerticalCellSize)
                    graphicsContext.DrawLine(light, a + (cell * j), b, a + (cell * j), projVerticalCellSize - b)
                Next

                For k = 1 To projVerticalWorldSize - 1
                    graphicsContext.DrawLine(backgrid, a, b + (celly * k), 0, (jumpVertical * k))
                    graphicsContext.DrawLine(backgrid, projHorizontalCellSize, (jumpVertical * k), projHorizontalCellSize - a, b + (celly * k))
                    graphicsContext.DrawLine(light, a, b + (celly * k), projHorizontalCellSize - a, b + (celly * k))
                Next
            End If
        Next

        a = Math.Sin(angle) * diag
        b = Math.Cos(angle) * diag

        graphicsContext.DrawLine(skeleton, 0, 0, a, b)
        graphicsContext.DrawLine(skeleton, projHorizontalCellSize, 0, projHorizontalCellSize - a, b)
        graphicsContext.DrawLine(skeleton, 0, projVerticalCellSize, a, projVerticalCellSize - b)
        graphicsContext.DrawLine(skeleton, projHorizontalCellSize, projVerticalCellSize, projHorizontalCellSize - a, projVerticalCellSize - b)
    End Sub

    Public Sub renderGridFrontFace(ByRef graphicsContext As Graphics)
        Dim overgrid As System.Drawing.Pen = New Pen(Brushes.Black, 2)

        Dim projHorizontalWorldSize = mWorldSize_X
        Dim projVerticalWorldSize = mWorldSize_Y

        Dim jumpHorizontal As Single = mCellXY_X
        Dim jumpVertical As Single = mCellXY_Y

        Dim projHorizontalCellSize = mSizeXY_X
        Dim projVerticalCellSize = mSizeXY_Y

        ' Project the coordinates to our perspective
        Select Case Prespective
            Case Prespective.XZ 'Top
                jumpHorizontal = mCellXZ_X
                jumpVertical = mCellXZ_Z

                projHorizontalCellSize = mSizeXZ_X
                projVerticalCellSize = mSizeXZ_Z

                projHorizontalWorldSize = mWorldSize_X
                projVerticalWorldSize = mWorldSize_Z

            Case Prespective.ZY
                jumpHorizontal = mCellZY_Z
                jumpVertical = mCellZY_Y

                projHorizontalCellSize = mSizeZY_Z
                projVerticalCellSize = mSizeZY_Y

                projHorizontalWorldSize = mWorldSize_Z
                projVerticalWorldSize = mWorldSize_Y
        End Select

        For projVertical = 0 To projVerticalWorldSize
            graphicsContext.DrawLine(overgrid, 0, jumpVertical * projVertical, projHorizontalCellSize, jumpVertical * projVertical)
        Next

        For projHorizontal = 0 To projHorizontalWorldSize
            graphicsContext.DrawLine(overgrid, jumpHorizontal * projHorizontal, 0, jumpHorizontal * projHorizontal, projVerticalCellSize)
        Next
    End Sub

    Public Sub renderAgent(ByVal xlocation As Integer, ByVal ylocation As Integer, ByVal zlocation As Integer, ByVal direction As Integer, ByVal colour As System.Drawing.Color, ByRef graphicsContext As Graphics,
                           Optional ByVal isStatic As Boolean = False, Optional ByVal isReservoir As Boolean = False, Optional ByVal reservoirCapacity As Integer = 0, Optional ByVal reservoirLevel As Integer = 0)
        Dim jump As Double = mCellXY_Y
        Dim projHorizontal = xlocation
        Dim projVertical = ylocation
        Dim projDepth = zlocation

        Dim projHorizontalCellSize = mSizeXY_X
        Dim projVerticalCellSize = mSizeXY_Y

        Dim projHorizontalWorldSize = mWorldSize_X
        Dim projVerticalWorldSize = mWorldSize_Y

        ' Project the coordinates to our perspective
        Select Case Prespective
            Case Prespective.XZ 'Top
                jump = mCellXZ_X

                zlocation = mWorldSize_Z - zlocation + 1

                projHorizontal = xlocation
                projVertical = zlocation
                projDepth = ylocation

                projHorizontalCellSize = mSizeXZ_X
                projVerticalCellSize = mSizeXZ_Z

                projHorizontalWorldSize = mWorldSize_X
                projVerticalWorldSize = mWorldSize_Z

                Select Case direction
                    Case 1 'XY Down
                        direction = 6
                    Case 2 'XY Up
                        direction = 5
                    Case 3 'XY Left
                        direction = 3
                    Case 4 'XY Right
                        direction = 4
                    Case 5 'XY Backwards
                        direction = 1
                    Case 6 'XY Forwards
                        direction = 2
                End Select
            Case Prespective.ZY
                jump = mCellZY_Z

                zlocation = mWorldSize_Z - zlocation + 1

                projHorizontal = zlocation
                projVertical = ylocation
                projDepth = xlocation

                projHorizontalCellSize = mSizeZY_Z
                projVerticalCellSize = mSizeZY_Y

                projHorizontalWorldSize = mWorldSize_Z
                projVerticalWorldSize = mWorldSize_Y

                zlocation = mWorldSize_Z - zlocation + 1

                Select Case direction
                    Case 1 'XY Down
                        direction = 1
                    Case 2 'XY Up
                        direction = 2
                    Case 3 'XY Left
                        direction = 6
                    Case 4 'XY Right
                        direction = 5
                    Case 5 'XY Backwards
                        direction = 4
                    Case 6 'XY Forwards
                        direction = 3
                End Select
        End Select

        Dim diag As Single
        For i = 1 To projDepth - 1
            jump = jump * Me.SizeRatio
            diag = diag + jump
        Next

#Region "Rendering"
        Dim angle As Single = Math.Atan(projHorizontalWorldSize / projVerticalWorldSize)
        Dim a As Integer = Math.Sin(angle) * diag
        Dim b As Integer = Math.Cos(angle) * diag

        Dim topfrontrightx As Integer = a + (projHorizontal * ((projHorizontalCellSize - (2 * a)) / projHorizontalWorldSize))
        Dim topfrontrighty As Integer = b + ((projVertical - 1) * ((projVerticalCellSize - (2 * b)) / projVerticalWorldSize))
        Dim topfrontleftx As Integer = a + ((projHorizontal - 1) * ((projHorizontalCellSize - (2 * a)) / projHorizontalWorldSize))
        Dim topfrontlefty As Integer = b + ((projVertical - 1) * ((projVerticalCellSize - (2 * b)) / projVerticalWorldSize))

        Dim bottomfrontrightx As Integer = a + (projHorizontal * ((projHorizontalCellSize - (2 * a)) / projHorizontalWorldSize))
        Dim bottomfrontrighty As Integer = b + (projVertical * ((projVerticalCellSize - (2 * b)) / projVerticalWorldSize))
        Dim bottomfrontleftx As Integer = a + ((projHorizontal - 1) * ((projHorizontalCellSize - (2 * a)) / projHorizontalWorldSize))
        Dim bottomfrontlefty As Integer = b + (projVertical * ((projVerticalCellSize - (2 * b)) / projVerticalWorldSize))

        jump = jump * (SizeRatio)
        diag = diag + jump

        angle = Math.Atan(projHorizontalWorldSize / projVerticalWorldSize)
        a = Math.Sin(angle) * diag
        b = Math.Cos(angle) * diag

        Dim topbackrightx As Integer = a + (projHorizontal * ((projHorizontalCellSize - (2 * a)) / projHorizontalWorldSize))
        Dim topbackrighty As Integer = b + ((projVertical - 1) * ((projVerticalCellSize - (2 * b)) / projVerticalWorldSize))
        Dim topbackleftx As Integer = a + ((projHorizontal - 1) * ((projHorizontalCellSize - (2 * a)) / projHorizontalWorldSize))
        Dim topbacklefty As Integer = b + ((projVertical - 1) * ((projVerticalCellSize - (2 * b)) / projVerticalWorldSize))

        Dim bottombackrightx As Integer = a + (projHorizontal * ((projHorizontalCellSize - (2 * a)) / projHorizontalWorldSize))
        Dim bottombackrighty As Integer = b + (projVertical * ((projVerticalCellSize - (2 * b)) / projVerticalWorldSize))
        Dim bottombackleftx As Integer = a + ((projHorizontal - 1) * ((projHorizontalCellSize - (2 * a)) / projHorizontalWorldSize))
        Dim bottombacklefty As Integer = b + (projVertical * ((projVerticalCellSize - (2 * b)) / projVerticalWorldSize))

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
        If isStatic Then
            Dim backface As Point() = {topbackleft, topbackright, bottombackright, bottombackleft}
            Dim rightface As Point() = {topbackright, bottombackright, bottomfrontright, topfrontright}
            Dim leftface As Point() = {topbackleft, bottombackleft, bottomfrontleft, topfrontleft}
            Dim topface As Point() = {topbackleft, topbackright, topfrontright, topfrontleft}
            Dim bottomface As Point() = {bottombackleft, bottombackright, bottomfrontright, bottomfrontleft}
            Dim frontface As Point() = {topfrontright, topfrontleft, bottomfrontleft, bottomfrontright}
            Dim brush As New SolidBrush(Color.FromArgb(150, colour.R, colour.G, colour.B))

            graphicsContext.FillPolygon(brush, backface)
            graphicsContext.FillPolygon(brush, rightface)
            graphicsContext.FillPolygon(brush, leftface)
            graphicsContext.FillPolygon(brush, topface)
            graphicsContext.FillPolygon(brush, bottomface)

            If isReservoir = False Then
                graphicsContext.FillPolygon(brush, frontface)
            End If

            graphicsContext.DrawLine(Pens.Gray, topbackleft, topbackright)
            graphicsContext.DrawLine(Pens.Gray, topbackright, bottombackright)
            graphicsContext.DrawLine(Pens.Gray, bottombackright, bottombackleft)
            graphicsContext.DrawLine(Pens.Gray, bottombackleft, topbackleft)

            graphicsContext.DrawLine(Pens.Gray, topbackleft, topfrontleft)
            graphicsContext.DrawLine(Pens.Gray, topbackright, topfrontright)
            graphicsContext.DrawLine(Pens.Gray, bottombackright, bottomfrontright)
            graphicsContext.DrawLine(Pens.Gray, bottombackleft, bottomfrontleft)

            graphicsContext.DrawLine(Pens.Gray, topfrontleft, topfrontright)
            graphicsContext.DrawLine(Pens.Gray, topfrontright, bottomfrontright)
            graphicsContext.DrawLine(Pens.Gray, bottomfrontright, bottomfrontleft)
            graphicsContext.DrawLine(Pens.Gray, bottomfrontleft, topfrontleft)

            If isReservoir Then
                'new code - bars that show the capacity of the static agent
                Dim scalingfactor As Decimal = (topfrontrightx - topfrontleftx) * 0.25
                Dim progressbarlength As Decimal = Math.Abs(topfrontrighty - bottomfrontrighty)

                Dim progressbarscalingfactor As Decimal = 0
                If reservoirCapacity > 0 Then
                    progressbarscalingfactor = Math.Max(reservoirLevel / reservoirCapacity, 1)
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
                graphicsContext.DrawLine(Pens.Black, progressbarlefttop, progressbarrighttop)

                Dim frontfaceleft As Point() = {topfrontrightleft, topfrontleft, bottomfrontleft, bottomfrontrightleft}
                Dim frontfaceright As Point() = {topfrontright, bottomfrontright, bottomfrontrightleft, topfrontrightleft}
                Dim frontfacerightbar As Point() = {bottomfrontright, bottomfrontrightleft, progressbarlefttop, progressbarrighttop}
                Dim frontfacebarfiller As Point() = {topfrontright, topfrontrightleft, progressbarlefttop, progressbarrighttop}

                Dim col As New SolidBrush(Color.FromArgb(150, Color.White.R, Color.White.G, Color.White.B))
                Dim bar As New SolidBrush(Color.FromArgb(150, Color.GreenYellow.R, Color.GreenYellow.G, Color.GreenYellow.B))

                'graphicsContext.FillPolygon(col, frontfaceright)
                graphicsContext.FillPolygon(brush, frontfaceleft)
                graphicsContext.FillPolygon(col, frontfacebarfiller)
                graphicsContext.FillPolygon(bar, frontfacerightbar)
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
            graphicsContext.FillPolygon(myBrush, top)
            graphicsContext.FillPolygon(myBrush, right)
            graphicsContext.FillPolygon(myBrush, bottom)
            graphicsContext.FillPolygon(myBrush, left)

            graphicsContext.DrawLine(graypen, topfrontleft, beak)
            graphicsContext.DrawLine(graypen, bottomfrontleft, beak)
            graphicsContext.DrawLine(graypen, bottomfrontright, beak)
            graphicsContext.DrawLine(graypen, topfrontright, beak)

            graphicsContext.DrawLine(Pens.Gray, topfrontleft, topfrontright)
            graphicsContext.DrawLine(Pens.Gray, topfrontright, bottomfrontright)
            graphicsContext.DrawLine(Pens.Gray, bottomfrontright, bottomfrontleft)
            graphicsContext.DrawLine(Pens.Gray, bottomfrontleft, topfrontleft)

        ElseIf direction = 5 Then
            Dim beakx As Integer = topfrontleftx + (Math.Abs(topfrontleftx - topfrontrightx) / 2)
            Dim beaky As Integer = topfrontlefty + (Math.Abs(topfrontlefty - bottomfrontlefty) / 2)
            Dim beak As New System.Drawing.Point(beakx, beaky)


            Dim top As Point() = {topbackleft, beak, topbackright}
            Dim right As Point() = {topbackright, beak, bottombackright}
            Dim bottom As Point() = {bottombackleft, beak, bottombackright}
            Dim left As Point() = {topbackleft, beak, bottombackleft}
            graphicsContext.FillPolygon(myBrush, top)
            graphicsContext.FillPolygon(myBrush, right)
            graphicsContext.FillPolygon(myBrush, bottom)
            graphicsContext.FillPolygon(myBrush, left)

            graphicsContext.DrawLine(Pens.Gray, topbackleft, beak)
            graphicsContext.DrawLine(Pens.Gray, bottombackleft, beak)
            graphicsContext.DrawLine(Pens.Gray, bottombackright, beak)
            graphicsContext.DrawLine(Pens.Gray, topbackright, beak)

            graphicsContext.DrawLine(Pens.Gray, topbackleft, topbackright)
            graphicsContext.DrawLine(Pens.Gray, topbackright, bottombackright)
            graphicsContext.DrawLine(Pens.Gray, bottombackright, bottombackleft)
            graphicsContext.DrawLine(Pens.Gray, bottombackleft, topbackleft)

        ElseIf direction = 2 Then
            If projVertical <= projVerticalWorldSize / 2 Then
                Dim beakx As Integer = (((Math.Abs(topbackleftx - topbackrightx) / 2) + (Math.Abs(topfrontleftx - topfrontrightx) / 2)) / 2) + ((topfrontleftx + topbackleftx) / 2)
                Dim beaky As Integer = topfrontlefty + (Math.Abs(topfrontlefty - topbacklefty) / 2)
                Dim beak As New System.Drawing.Point(beakx, beaky)
                Dim front As Point() = {bottomfrontleft, beak, bottomfrontright}
                Dim right As Point() = {bottomfrontright, beak, bottombackright}
                Dim left As Point() = {bottomfrontleft, bottombackleft, beak}
                Dim bottom As Point() = {bottomfrontleft, bottombackleft, bottombackright, bottomfrontright}
                graphicsContext.FillPolygon(myBrush, front)
                graphicsContext.FillPolygon(myBrush, right)
                graphicsContext.FillPolygon(myBrush, left)
                graphicsContext.FillPolygon(myBrush, bottom)
                graphicsContext.DrawLine(Pens.Gray, bottomfrontleft, beak)
                graphicsContext.DrawLine(Pens.Gray, bottomfrontright, beak)
                graphicsContext.DrawLine(Pens.Gray, bottomfrontleft, bottomfrontright)
                graphicsContext.DrawLine(Pens.Gray, bottomfrontleft, bottombackleft)
                graphicsContext.DrawLine(Pens.Gray, bottombackleft, bottombackright)
                graphicsContext.DrawLine(Pens.Gray, bottombackright, bottomfrontright)

                Dim ang As Single = Math.Atan(Math.Abs(beaky - bottombackrighty) / Math.Abs(beakx - bottombackrightx))
                Dim pointx As Single = bottombackrightx - (Math.Abs(bottomfrontrighty - bottombackrighty) / Math.Tan(ang))

                If pointx > bottomfrontrightx Then
                    graphicsContext.DrawLine(Pens.Gray, bottombackright, beak)
                Else
                    graphicsContext.DrawLine(graypen, bottombackright, beak)
                End If

                ang = Math.Atan(Math.Abs(beaky - bottombacklefty) / Math.Abs(beakx - bottombackleftx))
                pointx = (Math.Abs(bottomfrontlefty - bottombacklefty) / Math.Tan(ang)) + bottombackleftx


                If pointx < bottomfrontleftx Then
                    graphicsContext.DrawLine(Pens.Gray, beak, bottombackleft)
                Else
                    graphicsContext.DrawLine(graypen, beak, bottombackleft)
                End If

            ElseIf projVertical >= projVerticalWorldSize / 2 Then
                Dim beakx As Integer = (((Math.Abs(topbackleftx - topbackrightx) / 2) + (Math.Abs(topfrontleftx - topfrontrightx) / 2)) / 2) + ((topfrontleftx + topbackleftx) / 2)
                Dim beaky As Integer = topbacklefty + (Math.Abs(topfrontlefty - topbacklefty) / 2)
                Dim beak As New System.Drawing.Point(beakx, beaky)
                Dim front As Point() = {bottomfrontleft, beak, bottomfrontright}
                Dim right As Point() = {bottomfrontright, beak, bottombackright}
                Dim left As Point() = {bottomfrontleft, bottombackleft, beak}
                graphicsContext.FillPolygon(myBrush, front)
                graphicsContext.FillPolygon(myBrush, right)
                graphicsContext.FillPolygon(myBrush, left)
                graphicsContext.DrawLine(Pens.Gray, bottomfrontleft, beak)
                graphicsContext.DrawLine(Pens.Gray, bottomfrontright, beak)
                graphicsContext.DrawLine(Pens.Gray, bottomfrontleft, bottomfrontright)

                Dim ang As Single = Math.Atan(Math.Abs(beaky - bottomfrontlefty) / Math.Abs(beakx - topfrontleftx))
                Dim pointx As Single = (Math.Abs(bottombacklefty - bottomfrontlefty) / Math.Tan(ang)) + bottomfrontleftx

                If pointx < bottombackleftx Then
                    graphicsContext.DrawLine(graypen, bottombackleft, beak)
                    graphicsContext.DrawLine(graypen, bottombackleft, bottomfrontleft)
                    graphicsContext.DrawLine(graypen, bottombackleft, bottombackright)
                Else
                    graphicsContext.DrawLine(Pens.Gray, bottombackleft, bottomfrontleft)
                    graphicsContext.DrawLine(Pens.Gray, bottombackleft, beak)
                    graphicsContext.DrawLine(graypen, bottombackleft, bottombackright)
                End If

                ang = Math.Atan(Math.Abs(beaky - bottomfrontrighty) / Math.Abs(beakx - topfrontrightx))
                pointx = bottomfrontrightx - (Math.Abs(bottombackrighty - bottomfrontrighty) / Math.Tan(ang))


                If pointx < bottombackrightx Then
                    graphicsContext.DrawLine(Pens.Gray, beak, bottombackright)
                    graphicsContext.DrawLine(Pens.Gray, bottomfrontright, bottombackright)
                Else
                    graphicsContext.DrawLine(graypen, beak, bottombackright)
                    graphicsContext.DrawLine(graypen, bottomfrontright, bottombackright)
                End If

            End If

        ElseIf direction = 1 Then
            If projVertical <= projVerticalWorldSize / 2 Then
                Dim beakx As Integer = (((Math.Abs(bottombackleftx - bottombackrightx) / 2) + (Math.Abs(bottomfrontleftx - bottomfrontrightx) / 2)) / 2) + ((bottomfrontleftx + bottombackleftx) / 2)
                Dim beaky As Integer = bottomfrontlefty + (Math.Abs(bottomfrontlefty - bottombacklefty) / 2)
                Dim beak As New System.Drawing.Point(beakx, beaky)
                Dim front As Point() = {topfrontleft, beak, topfrontright}
                Dim right As Point() = {topfrontright, beak, topbackright}
                Dim left As Point() = {topfrontleft, topbackleft, beak}
                graphicsContext.FillPolygon(myBrush, front)
                graphicsContext.FillPolygon(myBrush, right)
                graphicsContext.FillPolygon(myBrush, left)
                graphicsContext.DrawLine(Pens.Gray, topfrontleft, beak)
                graphicsContext.DrawLine(Pens.Gray, topfrontright, beak)
                graphicsContext.DrawLine(Pens.Gray, topfrontleft, topfrontright)
                graphicsContext.DrawLine(graypen, topbackright, topbackleft)

                Dim ang As Single = Math.Atan(Math.Abs(beaky - topfrontrighty) / Math.Abs(beakx - topfrontrightx))
                Dim pointx As Single = topfrontrightx - (Math.Abs(topfrontrighty - topbackrighty) / Math.Tan(ang))

                If pointx < topbackrightx Then
                    graphicsContext.DrawLine(Pens.Gray, topbackright, beak)
                    graphicsContext.DrawLine(Pens.Gray, topfrontright, topbackright)
                Else
                    graphicsContext.DrawLine(graypen, topbackright, beak)
                    graphicsContext.DrawLine(graypen, topfrontright, topbackright)
                End If

                ang = Math.Atan(Math.Abs(beaky - topfrontlefty) / Math.Abs(beakx - topfrontleftx))
                pointx = (Math.Abs(topfrontlefty - topbacklefty) / Math.Tan(ang)) + topfrontleftx


                If pointx > topbackleftx Then
                    graphicsContext.DrawLine(Pens.Gray, beak, topbackleft)
                    graphicsContext.DrawLine(Pens.Gray, topbackleft, topfrontleft)
                Else
                    graphicsContext.DrawLine(graypen, beak, topbackleft)
                    graphicsContext.DrawLine(graypen, topbackleft, topfrontleft)
                End If

            ElseIf projVertical >= projVerticalWorldSize / 2 Then
                Dim beakx As Integer = (((Math.Abs(bottombackleftx - bottombackrightx) / 2) + (Math.Abs(bottomfrontleftx - bottomfrontrightx) / 2)) / 2) + ((bottomfrontleftx + bottombackleftx) / 2)
                Dim beaky As Integer = bottombacklefty + (Math.Abs(bottomfrontlefty - bottombacklefty) / 2)
                Dim beak As New System.Drawing.Point(beakx, beaky)
                Dim front As Point() = {topfrontleft, beak, topfrontright}
                Dim right As Point() = {topfrontright, beak, topbackright}
                Dim left As Point() = {topfrontleft, topbackleft, beak}
                Dim top As Point() = {topfrontleft, topbackleft, topbackright, topfrontright}
                graphicsContext.FillPolygon(myBrush, front)
                graphicsContext.FillPolygon(myBrush, right)
                graphicsContext.FillPolygon(myBrush, left)
                graphicsContext.FillPolygon(myBrush, top)
                graphicsContext.DrawLine(Pens.Gray, topfrontleft, beak)
                graphicsContext.DrawLine(Pens.Gray, topfrontright, beak)
                graphicsContext.DrawLine(Pens.Gray, topfrontleft, topfrontright)

                graphicsContext.DrawLine(Pens.Gray, topfrontleft, topbackleft)
                graphicsContext.DrawLine(Pens.Gray, topbackleft, topbackright)
                graphicsContext.DrawLine(Pens.Gray, topbackright, topfrontright)

                Dim ang As Single = Math.Atan(Math.Abs(beaky - topbacklefty) / Math.Abs(beakx - bottombackleftx))
                Dim pointx As Single = (Math.Abs(topfrontlefty - topbacklefty) / Math.Tan(ang)) + topbackleftx

                If pointx > topfrontleftx Then
                    graphicsContext.DrawLine(graypen, topbackleft, beak)
                Else
                    graphicsContext.DrawLine(Pens.Gray, topbackleft, beak)
                End If

                ang = Math.Atan(Math.Abs(beaky - topbackrighty) / Math.Abs(beakx - bottombackrightx))
                pointx = topbackrightx - (Math.Abs(topfrontrighty - topbackrighty) / Math.Tan(ang))


                If pointx > topfrontrightx Then
                    graphicsContext.DrawLine(Pens.Gray, beak, topbackright)
                Else
                    graphicsContext.DrawLine(graypen, beak, topbackright)
                End If
            End If


        ElseIf direction = 4 Then
            If projHorizontal <= projHorizontalWorldSize / 2 Then

                Dim beakx As Integer = (Math.Abs(topfrontrightx - topbackrightx) / 2) + topfrontrightx
                Dim beaky As Integer = Math.Abs(topfrontrighty - bottombackrighty) / 2 + topfrontlefty
                Dim beak As New System.Drawing.Point(beakx, beaky)

                Dim top As Point() = {topfrontleft, topbackleft, beak}
                Dim middle As Point() = {topfrontleft, beak, bottomfrontleft}
                Dim bottom As Point() = {bottomfrontleft, bottombackleft, beak}

                graphicsContext.FillPolygon(myBrush, top)
                graphicsContext.FillPolygon(myBrush, middle)
                graphicsContext.FillPolygon(myBrush, bottom)
                graphicsContext.DrawLine(Pens.Gray, bottomfrontleft, beak)
                graphicsContext.DrawLine(Pens.Gray, bottomfrontleft, topfrontleft)
                graphicsContext.DrawLine(Pens.Gray, topfrontleft, beak)

                Dim ang As Single = Math.Atan((Math.Abs(topfrontrighty - bottombackrighty) / 2) / ((Math.Abs(topfrontrightx - topbackrightx) / 2) + (topfrontrightx - topfrontleftx)))
                Dim pointy As Single = (Math.Tan(ang) * (a - topfrontleftx)) + topfrontlefty

                If topbacklefty < pointy Then
                    graphicsContext.DrawLine(Pens.Gray, topbackleft, beak)
                    graphicsContext.DrawLine(Pens.Gray, topfrontleft, topbackleft)
                Else
                    graphicsContext.DrawLine(graypen, topfrontleft, topbackleft)
                    graphicsContext.DrawLine(graypen, topbackleft, beak)
                End If

                pointy = bottomfrontlefty - (Math.Tan(ang) * (a - topfrontleftx))

                If bottombacklefty < pointy Then
                    graphicsContext.DrawLine(graypen, bottomfrontleft, bottombackleft)
                    graphicsContext.DrawLine(graypen, bottombackleft, beak)
                Else
                    graphicsContext.DrawLine(Pens.Gray, bottomfrontleft, bottombackleft)
                    graphicsContext.DrawLine(Pens.Gray, bottombackleft, beak)
                End If

                graphicsContext.DrawLine(graypen, topbackleft, bottombackleft)


            ElseIf projHorizontal >= projHorizontalWorldSize / 2 Then

                Dim beakx As Integer = topfrontrightx - (Math.Abs(topfrontrightx - topbackrightx) / 2)
                Dim beaky As Integer = Math.Abs(topfrontrighty - bottombackrighty) / 2 + topfrontlefty
                Dim beak As New System.Drawing.Point(beakx, beaky)

                Dim top As Point() = {topfrontleft, topbackleft, beak}
                Dim middle As Point() = {topfrontleft, beak, bottomfrontleft}
                Dim bottom As Point() = {bottomfrontleft, bottombackleft, beak}
                Dim back As Point() = {topfrontleft, bottomfrontleft, bottombackleft, topbackleft}

                graphicsContext.FillPolygon(myBrush, top)
                graphicsContext.FillPolygon(myBrush, middle)
                graphicsContext.FillPolygon(myBrush, bottom)
                graphicsContext.FillPolygon(myBrush, back)

                graphicsContext.DrawLine(Pens.Gray, topfrontleft, bottomfrontleft)
                graphicsContext.DrawLine(Pens.Gray, bottomfrontleft, bottombackleft)
                graphicsContext.DrawLine(Pens.Gray, bottombackleft, topbackleft)
                graphicsContext.DrawLine(Pens.Gray, topbackleft, topfrontleft)
                graphicsContext.DrawLine(Pens.Gray, bottomfrontleft, beak)

                graphicsContext.DrawLine(Pens.Gray, topfrontleft, beak)


                Dim ang As Single
                ang = Math.Atan((Math.Abs(beaky - bottombacklefty)) / (Math.Abs(beakx - bottombackleftx)))
                Dim pointy As Single
                pointy = bottombacklefty - (Math.Tan(ang) * (Math.Abs(topfrontleftx - topbackleftx)))
                If pointy > bottomfrontlefty Then
                    graphicsContext.DrawLine(Pens.Gray, bottombackleft, beak)
                Else
                    graphicsContext.DrawLine(graypen, bottombackleft, beak)
                End If

                ang = Math.Atan((Math.Abs(beaky - topbacklefty)) / (Math.Abs(beakx - topbackleftx)))
                pointy = topbacklefty + (Math.Tan(ang) * (Math.Abs(topfrontleftx - topbackleftx)))

                If pointy < topfrontlefty Then
                    graphicsContext.DrawLine(Pens.Gray, topbackleft, beak)
                Else
                    graphicsContext.DrawLine(graypen, topbackleft, beak)
                End If
            End If


        ElseIf direction = 3 Then
            If projHorizontal <= projHorizontalWorldSize / 2 Then
                Dim beakx As Integer = topfrontleftx + (Math.Abs(topfrontleftx - topbackleftx) / 2)
                Dim beaky As Integer = (Math.Abs(bottomfrontlefty - topbacklefty) / 2) + topbacklefty
                Dim beak As New System.Drawing.Point(beakx, beaky)

                Dim top As Point() = {topfrontright, topbackright, beak}
                Dim middle As Point() = {topfrontright, beak, bottomfrontright}
                Dim bottom As Point() = {bottomfrontright, bottombackright, beak}
                Dim back As Point() = {bottomfrontright, bottombackright, topbackright, topfrontright}

                graphicsContext.FillPolygon(myBrush, top)
                graphicsContext.FillPolygon(myBrush, middle)
                graphicsContext.FillPolygon(myBrush, bottom)
                graphicsContext.FillPolygon(myBrush, back)
                graphicsContext.DrawLine(Pens.Gray, bottomfrontright, beak)
                graphicsContext.DrawLine(Pens.Gray, bottomfrontright, topfrontright)
                graphicsContext.DrawLine(Pens.Gray, topfrontright, beak)
                graphicsContext.DrawLine(Pens.Gray, topfrontright, topbackright)
                graphicsContext.DrawLine(Pens.Gray, topbackright, bottombackright)
                graphicsContext.DrawLine(Pens.Gray, bottombackright, bottomfrontright)

                Dim ang As Single = Math.Atan(Math.Abs(beakx - topbackrightx) / Math.Abs(beaky - topbackrighty))
                Dim pointy As Single = topbackrighty + ((topbackrightx - topfrontrightx) / Math.Tan(ang))

                If topfrontrighty > pointy Then
                    graphicsContext.DrawLine(Pens.Gray, topbackright, beak)
                Else
                    graphicsContext.DrawLine(graypen, topbackright, beak)
                End If

                ang = Math.Atan(Math.Abs(beakx - bottombackrightx) / Math.Abs(beaky - bottombackrighty))
                pointy = bottombackrighty - ((bottombackrightx - bottomfrontrightx) / Math.Tan(ang))

                If bottomfrontrighty < pointy Then
                    graphicsContext.DrawLine(Pens.Gray, bottombackright, beak)
                Else
                    graphicsContext.DrawLine(graypen, bottombackright, beak)
                End If

            ElseIf projHorizontal > projHorizontalWorldSize / 2 Then
                Dim beakx As Integer = topfrontleftx - (Math.Abs(topfrontleftx - topbackleftx) / 2)
                Dim beaky As Integer = (Math.Abs(bottomfrontlefty - topbacklefty) / 2) + topbacklefty
                Dim beak As New System.Drawing.Point(beakx, beaky)
                Dim top As Point() = {topfrontright, topbackright, beak}
                Dim middle As Point() = {topfrontright, beak, bottomfrontright}
                Dim bottom As Point() = {bottomfrontright, bottombackright, beak}
                graphicsContext.FillPolygon(myBrush, top)
                graphicsContext.FillPolygon(myBrush, middle)
                graphicsContext.FillPolygon(myBrush, bottom)
                graphicsContext.DrawLine(Pens.Gray, bottomfrontright, beak)
                graphicsContext.DrawLine(Pens.Gray, bottomfrontright, topfrontright)
                graphicsContext.DrawLine(Pens.Gray, topfrontright, beak)
                graphicsContext.DrawLine(graypen, topbackright, bottombackright)

                Dim ang As Single = Math.Atan(Math.Abs(beakx - topfrontrightx) / Math.Abs(beaky - topfrontrighty))
                Dim pointy As Single = topfrontrighty + ((topfrontrightx - topbackrightx) / Math.Tan(ang))

                If topbackrighty < pointy Then
                    graphicsContext.DrawLine(Pens.Gray, topbackright, beak)
                    graphicsContext.DrawLine(Pens.Gray, topfrontright, topbackright)
                Else
                    graphicsContext.DrawLine(graypen, topbackright, beak)
                    graphicsContext.DrawLine(graypen, topfrontright, topbackright)
                End If

                ang = Math.Atan(Math.Abs(beakx - bottomfrontrightx) / Math.Abs(beaky - bottomfrontrighty))
                pointy = bottomfrontrighty - ((bottomfrontrightx - bottombackrightx) / Math.Tan(ang))

                If bottombackrighty > pointy Then
                    graphicsContext.DrawLine(Pens.Gray, bottombackright, beak)
                    graphicsContext.DrawLine(Pens.Gray, bottombackright, bottomfrontright)
                Else
                    graphicsContext.DrawLine(graypen, bottombackright, beak)
                    graphicsContext.DrawLine(graypen, bottombackright, bottomfrontright)
                End If
            End If
        End If
#End Region
    End Sub

    Public Sub renderRange(ByVal colour As System.Drawing.Color, ByRef graphicsContext As Graphics,
                ByVal xstart As Integer, ByVal xend As Integer, ByVal ystart As Integer, ByVal yend As Integer, ByVal zstart As Integer, ByVal zend As Integer)
        Dim jumpOriginal As Double = mCellXY_X

        Dim projHorizontalCellSize = mSizeXY_X
        Dim projVerticalCellSize = mSizeXY_Y

        Dim projHorizontalSize = mWorldSize_X
        Dim projVerticalSize = mWorldSize_Y

        ' Project the coordinates to our perspective
        Select Case Prespective
            Case Prespective.XZ 'Top
                jumpOriginal = mCellXZ_X

                projHorizontalCellSize = mSizeXZ_X
                projVerticalCellSize = mSizeXZ_Z

                projHorizontalSize = mWorldSize_X
                projVerticalSize = mWorldSize_Z

            Case Prespective.ZY
                jumpOriginal = mCellZY_Z

                projHorizontalCellSize = mSizeZY_Z
                projVerticalCellSize = mSizeZY_Y

                projHorizontalSize = mWorldSize_Z
                projVerticalSize = mWorldSize_Y
        End Select

        Dim iHorizontal, iVertical, iDepth As Integer
        For z = zstart To zend
            For projVertical = ystart To yend
                For projHorizontal = xstart To xend
                    ' Project the coordinates to our perspective
                    Select Case Prespective
                        Case Prespective.XY
                            iHorizontal = projHorizontal
                            iVertical = projVertical
                            iDepth = z
                        Case Prespective.XZ 'Top
                            iHorizontal = projHorizontal
                            iVertical = projVerticalSize - z + 1
                            iDepth = projVertical
                        Case Prespective.ZY
                            iHorizontal = projHorizontalSize - z + 1
                            iVertical = projVertical
                            iDepth = projHorizontal
                    End Select

                    Dim diag As Single = 0
                    Dim jump As Double = jumpOriginal

                    For i = 1 To iDepth - 1
                        jump = jump * SizeRatio
                        diag = diag + jump
                    Next
                    'MessageBox.Show(diag)
                    Dim angle As Single = Math.Atan(projHorizontalSize / projVerticalSize)
                    Dim a As Integer = Math.Sin(angle) * diag
                    Dim b As Integer = Math.Cos(angle) * diag
                    'MessageBox.Show(a & " " & b)
                    Dim topfrontrightx As Integer = a + (iHorizontal * ((projHorizontalCellSize - (2 * a)) / projHorizontalSize))
                    Dim topfrontrighty As Integer = b + ((iVertical - 1) * ((projVerticalCellSize - (2 * b)) / projVerticalSize))
                    Dim topfrontleftx As Integer = a + ((iHorizontal - 1) * ((projHorizontalCellSize - (2 * a)) / projHorizontalSize))
                    Dim topfrontlefty As Integer = b + ((iVertical - 1) * ((projVerticalCellSize - (2 * b)) / projVerticalSize))

                    Dim bottomfrontrightx As Integer = a + (iHorizontal * ((projHorizontalCellSize - (2 * a)) / projHorizontalSize))
                    Dim bottomfrontrighty As Integer = b + (iVertical * ((projVerticalCellSize - (2 * b)) / projVerticalSize))
                    Dim bottomfrontleftx As Integer = a + ((iHorizontal - 1) * ((projHorizontalCellSize - (2 * a)) / projHorizontalSize))
                    Dim bottomfrontlefty As Integer = b + (iVertical * ((projVerticalCellSize - (2 * b)) / projVerticalSize))

                    jump = jump * SizeRatio
                    diag = diag + jump

                    angle = Math.Atan(projHorizontalSize / projVerticalSize)
                    a = Math.Sin(angle) * diag
                    b = Math.Cos(angle) * diag

                    Dim topbackrightx As Integer = a + (iHorizontal * ((projHorizontalCellSize - (2 * a)) / projHorizontalSize))
                    Dim topbackrighty As Integer = b + ((iVertical - 1) * ((projVerticalCellSize - (2 * b)) / projVerticalSize))
                    Dim topbackleftx As Integer = a + ((iHorizontal - 1) * ((projHorizontalCellSize - (2 * a)) / projHorizontalSize))
                    Dim topbacklefty As Integer = b + ((iVertical - 1) * ((projVerticalCellSize - (2 * b)) / projVerticalSize))

                    Dim bottombackrightx As Integer = a + (iHorizontal * ((projHorizontalCellSize - (2 * a)) / projHorizontalSize))
                    Dim bottombackrighty As Integer = b + (iVertical * ((projVerticalCellSize - (2 * b)) / projVerticalSize))
                    Dim bottombackleftx As Integer = a + ((iHorizontal - 1) * ((projHorizontalCellSize - (2 * a)) / projHorizontalSize))
                    Dim bottombacklefty As Integer = b + (iVertical * ((projVerticalCellSize - (2 * b)) / projVerticalSize))


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

                    Dim transparent As New SolidBrush(colour)

                    graphicsContext.FillPolygon(transparent, backface)
                    graphicsContext.FillPolygon(transparent, rightface)
                    graphicsContext.FillPolygon(transparent, leftface)
                    graphicsContext.FillPolygon(transparent, topface)
                    graphicsContext.FillPolygon(transparent, bottomface)
                    graphicsContext.FillPolygon(transparent, frontface)
                Next
            Next
        Next
    End Sub

    Public Sub renderCube(ByVal xlocation As Integer, ByVal ylocation As Integer, ByVal zlocation As Integer, ByVal colour As System.Drawing.Color, ByRef graphicsContext As Graphics)
        Dim jump As Double = mCellXY_Y
        Dim projHorizontal = xlocation
        Dim projVertical = ylocation
        Dim projDepth = zlocation

        Dim projHorizontalCellSize = mSizeXY_X
        Dim projVerticalCellSize = mSizeXY_Y

        Dim projHorizontalWorldSize = mWorldSize_X
        Dim projVerticalWorldSize = mWorldSize_Y

        ' Project the coordinates to our perspective
        Select Case Prespective
            Case Prespective.XZ 'Top
                jump = mCellXZ_X

                zlocation = mWorldSize_Z - zlocation + 1

                projHorizontal = xlocation
                projVertical = zlocation
                projDepth = ylocation

                projHorizontalCellSize = mSizeXZ_X
                projVerticalCellSize = mSizeXZ_Z

                projHorizontalWorldSize = mWorldSize_X
                projVerticalWorldSize = mWorldSize_Z
            Case Prespective.ZY
                jump = mCellZY_Z

                zlocation = mWorldSize_Z - zlocation + 1

                projHorizontal = zlocation
                projVertical = ylocation
                projDepth = xlocation

                projHorizontalCellSize = mSizeZY_Z
                projVerticalCellSize = mSizeZY_Y

                projHorizontalWorldSize = mWorldSize_Z
                projVerticalWorldSize = mWorldSize_Y

                zlocation = mWorldSize_Z - zlocation + 1
        End Select

        Dim diag As Single
        For i = 1 To projDepth - 1
            jump = jump * Me.SizeRatio
            diag = diag + jump
        Next

        Dim angle As Single = Math.Atan(projHorizontalWorldSize / projVerticalWorldSize)
        Dim a As Integer = Math.Sin(angle) * diag
        Dim b As Integer = Math.Cos(angle) * diag
        'MessageBox.Show(a & " " & b)
        Dim topfrontrightx As Integer = a + (projHorizontal * ((projHorizontalCellSize - (2 * a)) / projHorizontalWorldSize))
        Dim topfrontrighty As Integer = b + ((projVertical - 1) * ((projVerticalCellSize - (2 * b)) / projVerticalWorldSize))
        Dim topfrontleftx As Integer = a + ((projHorizontal - 1) * ((projHorizontalCellSize - (2 * a)) / projHorizontalWorldSize))
        Dim topfrontlefty As Integer = b + ((projVertical - 1) * ((projVerticalCellSize - (2 * b)) / projVerticalWorldSize))

        Dim bottomfrontrightx As Integer = a + (projHorizontal * ((projHorizontalCellSize - (2 * a)) / projHorizontalWorldSize))
        Dim bottomfrontrighty As Integer = b + (projVertical * ((projVerticalCellSize - (2 * b)) / projVerticalWorldSize))
        Dim bottomfrontleftx As Integer = a + ((projHorizontal - 1) * ((projHorizontalCellSize - (2 * a)) / projHorizontalWorldSize))
        Dim bottomfrontlefty As Integer = b + (projVertical * ((projVerticalCellSize - (2 * b)) / projVerticalWorldSize))

        jump = jump * (SizeRatio)
        diag = diag + jump

        angle = Math.Atan(projHorizontalWorldSize / projVerticalWorldSize)
        a = Math.Sin(angle) * diag
        b = Math.Cos(angle) * diag

        Dim topbackrightx As Integer = a + (projHorizontal * ((projHorizontalCellSize - (2 * a)) / projHorizontalWorldSize))
        Dim topbackrighty As Integer = b + ((projVertical - 1) * ((projVerticalCellSize - (2 * b)) / projVerticalWorldSize))
        Dim topbackleftx As Integer = a + ((projHorizontal - 1) * ((projHorizontalCellSize - (2 * a)) / projHorizontalWorldSize))
        Dim topbacklefty As Integer = b + ((projVertical - 1) * ((projVerticalCellSize - (2 * b)) / projVerticalWorldSize))

        Dim bottombackrightx As Integer = a + (projHorizontal * ((projHorizontalCellSize - (2 * a)) / projHorizontalWorldSize))
        Dim bottombackrighty As Integer = b + (projVertical * ((projVerticalCellSize - (2 * b)) / projVerticalWorldSize))
        Dim bottombackleftx As Integer = a + ((projHorizontal - 1) * ((projHorizontalCellSize - (2 * a)) / projHorizontalWorldSize))
        Dim bottombacklefty As Integer = b + (projVertical * ((projVerticalCellSize - (2 * b)) / projVerticalWorldSize))


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

        Dim transparent As New SolidBrush(colour) 'Color.FromArgb(25, rr, gg, bb))

        graphicsContext.FillPolygon(transparent, backface)
        graphicsContext.FillPolygon(transparent, rightface)
        graphicsContext.FillPolygon(transparent, leftface)
        graphicsContext.FillPolygon(transparent, topface)
        graphicsContext.FillPolygon(transparent, bottomface)
        graphicsContext.FillPolygon(transparent, frontface)
    End Sub

    Public Sub renderCubeWireframe(ByVal xlocation As Integer, ByVal ylocation As Integer, ByVal zlocation As Integer, ByVal colour As System.Drawing.Color, ByRef graphicsContext As Graphics,
                                   Optional ByVal width As Integer = 0, Optional ByVal height As Integer = 0, Optional ByVal depth As Integer = 0)
        Dim jump As Double = mCellXY_Y
        Dim projHorizontal = xlocation
        Dim projVertical = ylocation
        Dim projDepth = zlocation

        Dim projHorizontalCellSize = mSizeXY_X
        Dim projVerticalCellSize = mSizeXY_Y

        Dim projHorizontalWorldSize = mWorldSize_X
        Dim projVerticalWorldSize = mWorldSize_Y

        ' Project the coordinates to our perspective
        Select Case Prespective
            Case Prespective.XZ 'Top
                jump = mCellXZ_X

                zlocation = mWorldSize_Z - zlocation + 1

                projHorizontal = xlocation
                projVertical = zlocation
                projDepth = ylocation

                projHorizontalCellSize = mSizeXZ_X
                projVerticalCellSize = mSizeXZ_Z

                projHorizontalWorldSize = mWorldSize_X
                projVerticalWorldSize = mWorldSize_Z
            Case Prespective.ZY
                jump = mCellZY_Z

                zlocation = mWorldSize_Z - zlocation + 1

                projHorizontal = zlocation
                projVertical = ylocation
                projDepth = xlocation

                projHorizontalCellSize = mSizeZY_Z
                projVerticalCellSize = mSizeZY_Y

                projHorizontalWorldSize = mWorldSize_Z
                projVerticalWorldSize = mWorldSize_Y

                zlocation = mWorldSize_Z - zlocation + 1
        End Select

        Dim diag As Single
        For i = 1 To projDepth - 1
            jump = jump * Me.SizeRatio
            diag = diag + jump
        Next

        Dim angle As Single = Math.Atan(projHorizontalWorldSize / projVerticalWorldSize)
        Dim a As Integer = Math.Sin(angle) * diag
        Dim b As Integer = Math.Cos(angle) * diag
        'MessageBox.Show(a & " " & b)
        Dim topfrontrightx As Integer = a + ((projHorizontal + width) * ((projHorizontalCellSize - (2 * a)) / projHorizontalWorldSize))
        Dim topfrontrighty As Integer = b + ((projVertical - 1) * ((projVerticalCellSize - (2 * b)) / projVerticalWorldSize))

        Dim topfrontleftx As Integer = a + ((projHorizontal - 1) * ((projHorizontalCellSize - (2 * a)) / projHorizontalWorldSize))
        Dim topfrontlefty As Integer = b + ((projVertical - 1) * ((projVerticalCellSize - (2 * b)) / projVerticalWorldSize))

        Dim bottomfrontrightx As Integer = a + ((projHorizontal + width) * ((projHorizontalCellSize - (2 * a)) / projHorizontalWorldSize))
        Dim bottomfrontrighty As Integer = b + ((projVertical + height) * ((projVerticalCellSize - (2 * b)) / projVerticalWorldSize))
        Dim bottomfrontleftx As Integer = a + ((projHorizontal - 1) * ((projHorizontalCellSize - (2 * a)) / projHorizontalWorldSize))
        Dim bottomfrontlefty As Integer = b + ((projVertical + height) * ((projVerticalCellSize - (2 * b)) / projVerticalWorldSize))

        ' Faux depth calculations
        For i = projDepth To projDepth + depth
            jump = jump * (SizeRatio)
            diag = diag + jump
        Next
        angle = Math.Atan(projHorizontalWorldSize / projVerticalWorldSize)
        a = Math.Sin(angle) * diag
        b = Math.Cos(angle) * diag

        Dim topbackrightx As Integer = a + ((projHorizontal + width) * ((projHorizontalCellSize - (2 * a)) / projHorizontalWorldSize))
        Dim topbackrighty As Integer = b + ((projVertical - 1) * ((projVerticalCellSize - (2 * b)) / projVerticalWorldSize))

        Dim topbackleftx As Integer = a + ((projHorizontal - 1) * ((projHorizontalCellSize - (2 * a)) / projHorizontalWorldSize))
        Dim topbacklefty As Integer = b + ((projVertical - 1) * ((projVerticalCellSize - (2 * b)) / projVerticalWorldSize))

        Dim bottombackrightx As Integer = a + ((projHorizontal + width) * ((projHorizontalCellSize - (2 * a)) / projHorizontalWorldSize))
        Dim bottombackrighty As Integer = b + ((projVertical + height) * ((projVerticalCellSize - (2 * b)) / projVerticalWorldSize))
        Dim bottombackleftx As Integer = a + ((projHorizontal - 1) * ((projHorizontalCellSize - (2 * a)) / projHorizontalWorldSize))
        Dim bottombacklefty As Integer = b + ((projVertical + height) * ((projVerticalCellSize - (2 * b)) / projVerticalWorldSize))


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

        Dim edgecolour As New Pen(colour)

        graphicsContext.DrawLine(edgecolour, topfrontleft, bottomfrontleft)
        graphicsContext.DrawLine(edgecolour, topfrontright, bottomfrontright)
        graphicsContext.DrawLine(edgecolour, topfrontleft, topfrontright)
        graphicsContext.DrawLine(edgecolour, bottomfrontleft, bottomfrontright)

        graphicsContext.DrawLine(edgecolour, topbackleft, bottombackleft)
        graphicsContext.DrawLine(edgecolour, topbackright, bottombackright)
        graphicsContext.DrawLine(edgecolour, topbackleft, topbackright)
        graphicsContext.DrawLine(edgecolour, bottombackleft, bottombackright)

        graphicsContext.DrawLine(edgecolour, topfrontleft, topbackleft)
        graphicsContext.DrawLine(edgecolour, topfrontright, topbackright)
        graphicsContext.DrawLine(edgecolour, bottomfrontleft, bottombackleft)
        graphicsContext.DrawLine(edgecolour, bottomfrontright, bottombackright)
    End Sub
End Class

Public Enum Prespective
    XY = 0
    XZ = 1
    ZY = 2
End Enum

Public Enum Direction
    XPOS = 1
    XNEG = 2
    YPOS = 3
    YNEG = 4
    ZPOS = 5
    ZNEG = 6
End Enum