Imports COBWEB_3D
Imports System.Xml

Public Class Form1
    Public Const COBWEB_VERSION As String = "1.3.3"

    Private mRenderingEngine As RenderingEngine
    Private mFrameCounter As Integer = 0
    Private mFrameSkip As Integer = 0

    Private mExcelLogger As ExcelLogger

    Public tick As Integer

    ' Number of Agents
    Public agentTypeCount As Integer
    Public total As Integer

    ' The variables for the size of grid
    Public xn As Integer = 0
    Public yn As Integer = 0
    Public zn As Integer = 0

    Public visualizerange As Integer

    Private localregion As Integer

#Region "Properties"
    Public Property RenderingEngine As RenderingEngine
        Get
            Return mRenderingEngine
        End Get
        Set(value As RenderingEngine)
            mRenderingEngine = value
        End Set
    End Property
#End Region

    Sub initializeSimulation()
        mRenderingEngine = New RenderingEngine(xn, yn, zn)
        Timerxy.Interval = 1
    End Sub

    Private Sub updateSimulation()
        If (xn = 0 Or yn = 0 Or zn = 0) Then Return
        updateLogic()
        draw(True)

        tick += 1
        tslblCurrentTick.Text = tick
        logDataToGraphs()
    End Sub

    Private Sub updateLogic()
        For i = 1 To total
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
                generator.agentlocation(i, 10) = generator.agentlocation(i, 10) + 1 ' Incremenet the asexual reproduction timer
                If generator.agentlocation(i, 10) >= generator.asrtime(generator.agentlocation(i, 4)) Then ' If timer > the threshold, reproduce
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
            'new code
            Call abiotic(i, x, y, z)
            'Call reservoirrelase(i)

            Dim xdiff As Integer = Math.Abs(dx - x)
            Dim ydiff As Integer = Math.Abs(dy - y)
            Dim zdiff As Integer = Math.Abs(dz - z)

            'this large if statement is responsible for assigning the next position for an agent (allows agent to go towards its destination)
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
            'new code
            'Call swarming(i, x, y, z, 1, 1, 1)
        Next
        reservoirrelase(0)
    End Sub

    Public Sub draw(Optional ByVal ignoreSimulationLoop As Boolean = False)
        If ignoreSimulationLoop = False And isSimulationRunning() Then Return ' Optimization, its unnecessary to manually render when the simulation is running!
        If Me.mFrameCounter >= Me.mFrameSkip Then
            If Me.RenderingEngine IsNot Nothing Then
                If Me.RenderingEngine.GraphicsContext IsNot Nothing Then
                    Me.RenderingEngine.GraphicsContext.Clear(Color.White)
                    drawScene(Me.RenderingEngine.GraphicsContext)
                End If
                If Me.RenderingEngine.RenderTarget IsNot Nothing Then
                    picRenderFrame.Image = Me.RenderingEngine.RenderTarget
                End If
            End If
            mFrameCounter = 0
        Else
            mFrameCounter += 1
        End If
    End Sub

    Private Sub drawScene(ByRef graphicsContext As Graphics)
        Me.RenderingEngine.renderGrid(graphicsContext)
        drawAgents(graphicsContext)
        drawRange(graphicsContext, visualizerange)
        Me.RenderingEngine.renderGridFrontFace(graphicsContext)
    End Sub

    ''' <summary>
    ''' Logs data for each agent type to the excel graph sheets.
    ''' </summary>
    Private Sub logDataToGraphs()
        If mExcelLogger IsNot Nothing Then mExcelLogger.logDataToExcel(tick, agentTypeCount, total)
    End Sub

    Function isSimulationRunning() As Boolean
        Return tick <= tslblStopTicks.Text And Timerxy.Enabled
    End Function

#Region "Agent Interactions"
    Private goal(2) As Integer

    ''' <summary>
    ''' Enables swarming behaviour (if the neighbouring agents are facing a certain way then the current agent also faces and moves in the same direction), each swarm has a common destination 
    ''' (if agents in a swarm had different destinations, they would scatter).
    ''' </summary>
    ''' <param name="i"></param>
    ''' <param name="x"></param>
    ''' <param name="y"></param>
    ''' <param name="z"></param>
    ''' <param name="dx"></param>
    ''' <param name="dy"></param>
    ''' <param name="dz"></param>
    Sub swarming(ByVal i, ByVal x, ByVal y, ByVal z, ByVal dx, ByVal dy, ByVal dz)

        Dim direction(6) As Integer
        Dim count As Integer
        Dim avposition(5) As Decimal

        For l = 1 To 3 'the extent to which the agent sees its surroundings (can be changed)
            For xxi = (x - l) To (x + l)
                For yyi = (y - l) To (y + l)
                    For zzi = (z - l) To (y + l)
                        If xxi >= 0 And xxi <= xn And yyi >= 0 And yyi <= yn And zzi >= 0 And zzi <= zn Then 'ensure that coordinates are not out of bounds
                            For k = 1 To total
                                If generator.agentlocation(k, 0) = xxi And generator.agentlocation(k, 1) = yyi And generator.agentlocation(k, 2) = zzi And xxi <> x And yyi <> y And zzi <> z Then
                                    If generator.agentlocation(k, 3) = 1 Then
                                        direction(1) += 1
                                    ElseIf generator.agentlocation(k, 3) = 2 Then
                                        direction(2) += 1
                                    ElseIf generator.agentlocation(k, 3) = 3 Then
                                        direction(3) += 1
                                    ElseIf generator.agentlocation(k, 3) = 4 Then
                                        direction(4) += 1
                                    ElseIf generator.agentlocation(k, 3) = 5 Then
                                        direction(5) += 1
                                    ElseIf generator.agentlocation(k, 3) = 6 Then
                                        direction(6) += 1
                                    End If
                                    count += 1
                                    avposition(0) += xxi
                                    avposition(1) += yyi
                                    avposition(2) += zzi
                                End If
                            Next
                        End If
                    Next
                Next
            Next
        Next

        If count <> 0 Then
            avposition(3) = CInt(avposition(0) / count)
            avposition(4) = CInt(avposition(1) / count)
            avposition(5) = CInt(avposition(2) / count)
        End If

        If avposition(3) > xn Then
            avposition(3) = xn
        ElseIf avposition(3) < 0 Then
            avposition(3) = 0
        End If
        If avposition(4) > yn Then
            avposition(4) = yn
        ElseIf avposition(4) < 0 Then
            avposition(4) = 0
        End If
        If avposition(5) > zn Then
            avposition(5) = zn
        ElseIf avposition(5) < 0 Then
            avposition(5) = 0
        End If

        generator.agentlocation(i, 5) = avposition(3)
        generator.agentlocation(i, 6) = avposition(4)
        generator.agentlocation(i, 7) = avposition(5)

        Dim rangexupper As Integer = generator.agentrange(generator.agentlocation(i, 4), 0, 1)
        Dim rangexlower As Integer = generator.agentrange(generator.agentlocation(i, 4), 0, 0)
        Dim rangeyupper As Integer = generator.agentrange(generator.agentlocation(i, 4), 1, 1)
        Dim rangeylower As Integer = generator.agentrange(generator.agentlocation(i, 4), 1, 0)
        Dim rangezupper As Integer = generator.agentrange(generator.agentlocation(i, 4), 2, 1)
        Dim rangezlower As Integer = generator.agentrange(generator.agentlocation(i, 4), 2, 0)

        'aligns nearby agents if they are close enough together (when the average position is already occupied). if agents are alreadt aligned, then they move in the direction they are facing (ensures
        'that the swarm continues to move. (The swarm should turn if it reaches the edge of the grid rather than stopping)
        If Math.Abs(avposition(3) - x) <= 1 And Math.Abs(avposition(4) - y) <= 1 And Math.Abs(avposition(5) - z) <= 1 Then
            For g = 1 To 6
                If direction(g) = direction.ToArray.Max Then
                    'If generator.agentlocation(i, 3) = g Then

                    'If generator.agentlocation(i, 3) = 1 Then
                    '    If (y + 1) <= yn Then
                    '        generator.agentlocation(i, 6) = y + 1
                    '        generator.agentlocation(i, 5) = x
                    '        generator.agentlocation(i, 7) = z
                    '    Else
                    '        generator.agentlocation(i, 7) = CInt(Math.Floor((rangeyupper - rangeylower + 1) * Rnd())) + rangeylower
                    '        generator.agentlocation(i, 6) = CInt(Math.Floor((rangeyupper - rangeylower + 1) * Rnd())) + rangeylower
                    '        generator.agentlocation(i, 5) = CInt(Math.Floor((rangexupper - rangexlower + 1) * Rnd())) + rangexlower
                    '    End If
                    'ElseIf generator.agentlocation(i, 3) = 2 Then
                    '    If (y - 1) >= 0 Then
                    '        generator.agentlocation(i, 6) = y - 1
                    '        generator.agentlocation(i, 5) = x
                    '        generator.agentlocation(i, 7) = z
                    '    Else
                    '        generator.agentlocation(i, 7) = CInt(Math.Floor((rangeyupper - rangeylower + 1) * Rnd())) + rangeylower
                    '        generator.agentlocation(i, 6) = CInt(Math.Floor((rangeyupper - rangeylower + 1) * Rnd())) + rangeylower
                    '        generator.agentlocation(i, 5) = CInt(Math.Floor((rangexupper - rangexlower + 1) * Rnd())) + rangexlower
                    '    End If
                    'ElseIf generator.agentlocation(i, 3) = 3 Then
                    '    If (x - 1) >= 0 Then
                    '        generator.agentlocation(i, 5) = x - 1
                    '        generator.agentlocation(i, 6) = y
                    '        generator.agentlocation(i, 7) = z
                    '    Else
                    '        generator.agentlocation(i, 7) = CInt(Math.Floor((rangeyupper - rangeylower + 1) * Rnd())) + rangeylower
                    '        generator.agentlocation(i, 6) = CInt(Math.Floor((rangeyupper - rangeylower + 1) * Rnd())) + rangeylower
                    '        generator.agentlocation(i, 5) = CInt(Math.Floor((rangexupper - rangexlower + 1) * Rnd())) + rangexlower
                    '    End If
                    'ElseIf generator.agentlocation(i, 3) = 4 Then
                    '    If (x + 1) <= xn Then
                    '        generator.agentlocation(i, 5) = x + 1
                    '        generator.agentlocation(i, 6) = y
                    '        generator.agentlocation(i, 7) = z
                    '    Else
                    '        generator.agentlocation(i, 7) = CInt(Math.Floor((rangeyupper - rangeylower + 1) * Rnd())) + rangeylower
                    '        generator.agentlocation(i, 6) = CInt(Math.Floor((rangeyupper - rangeylower + 1) * Rnd())) + rangeylower
                    '        generator.agentlocation(i, 5) = CInt(Math.Floor((rangexupper - rangexlower + 1) * Rnd())) + rangexlower
                    '    End If
                    'ElseIf generator.agentlocation(i, 3) = 5 Then
                    '    If (z - 1) >= 0 Then
                    '        generator.agentlocation(i, 7) = z - 1
                    '        generator.agentlocation(i, 5) = x
                    '        generator.agentlocation(i, 6) = y
                    '    Else
                    '        generator.agentlocation(i, 7) = CInt(Math.Floor((rangeyupper - rangeylower + 1) * Rnd())) + rangeylower
                    '        generator.agentlocation(i, 6) = CInt(Math.Floor((rangeyupper - rangeylower + 1) * Rnd())) + rangeylower
                    '        generator.agentlocation(i, 5) = CInt(Math.Floor((rangexupper - rangexlower + 1) * Rnd())) + rangexlower
                    '    End If
                    'ElseIf generator.agentlocation(i, 3) = 6 Then
                    '    If (z + 1) <= zn Then
                    '        generator.agentlocation(i, 7) = z + 1
                    '        generator.agentlocation(i, 5) = x
                    '        generator.agentlocation(i, 6) = y
                    '    Else
                    '        generator.agentlocation(i, 7) = CInt(Math.Floor((rangeyupper - rangeylower + 1) * Rnd())) + rangeylower
                    '        generator.agentlocation(i, 6) = CInt(Math.Floor((rangeyupper - rangeylower + 1) * Rnd())) + rangeylower
                    '        generator.agentlocation(i, 5) = CInt(Math.Floor((rangexupper - rangexlower + 1) * Rnd())) + rangexlower
                    '        'generator.agentlocation(i, 3) = 4 'turns right

                    '    End If
                    'End If

                    'goal destination
                    If generator.agentlocation(i, 0) = goal(0) And generator.agentlocation(i, 1) = goal(1) And generator.agentlocation(i, 2) = goal(2) Then
                        goal(0) = CInt(Math.Floor((xn - 1 + 1) * Rnd())) + 1
                        goal(1) = CInt(Math.Floor((yn - 1 + 1) * Rnd())) + 1
                        goal(2) = CInt(Math.Floor((zn - 1 + 1) * Rnd())) + 1
                    End If
                    generator.agentlocation(i, 5) = goal(0)
                    generator.agentlocation(i, 6) = goal(1)
                    generator.agentlocation(i, 7) = goal(2)
                    'Else
                    '    generator.agentlocation(i, 3) = g
                    'End If
                End If
            Next
        End If
    End Sub

    Sub tradezones(ByVal opp As Integer)
        Dim conditions As Decimal = 1

        For i = 1 To 1000
            Dim xlow As Integer = generator.zones(i, 1)
            Dim xup As Integer = generator.zones(i, 2)
            Dim ylow As Integer = generator.zones(i, 3)
            Dim yup As Integer = generator.zones(i, 4)
            Dim zlow As Integer = generator.zones(i, 5)
            Dim zup As Integer = generator.zones(i, 6)
            If xlow = 0 Or xup = 0 Or ylow = 0 Or yup = 0 Or zlow = 0 Or zup = 0 Then
                Exit For
            End If

            For xi = xlow To xup
                For yi = ylow To yup
                    For zi = zlow To zup
                        For agenti = 1 To agentTypeCount
                            generator.abiotic(agenti, xi, yi, zi) = generator.zones(i, 7)
                        Next
                    Next
                Next
            Next
        Next
    End Sub

    ''' <summary>
    ''' Agents go to the zone with the highest value (ie. global maximum); essentially test code (not used by the program).
    ''' </summary>
    ''' <param name="k"></param>
    ''' <param name="x"></param>
    ''' <param name="y"></param>
    ''' <param name="z"></param>
    Sub tradezonemovement(ByVal k, ByVal x, ByVal y, ByVal z) 'agents go to the zone with the highest value (ie. global maximum); essentially test code (not used by the program)
        Dim conditions As Decimal = 0
        Dim targetrange(6) As Decimal

        For i = 1 To 1000
            Dim xlow As Integer = generator.zones(i, 1)
            Dim xup As Integer = generator.zones(i, 2)
            Dim ylow As Integer = generator.zones(i, 3)
            Dim yup As Integer = generator.zones(i, 4)
            Dim zlow As Integer = generator.zones(i, 5)
            Dim zup As Integer = generator.zones(i, 6)
            If xlow = 0 Or xup = 0 Or ylow = 0 Or yup = 0 Or zlow = 0 Or zup = 0 Then
                Exit For
            End If

            If conditions < generator.zones(i, 7) Then
                conditions = generator.zones(i, 7)
                For j = 1 To 6
                    targetrange(j) = generator.zones(i, j)
                Next
            End If
        Next

        Dim dx As Integer = CInt(Math.Floor((targetrange(2) - targetrange(1) + 1) * Rnd())) + targetrange(1)
        Dim dy As Integer = CInt(Math.Floor((targetrange(4) - targetrange(3) + 1) * Rnd())) + targetrange(3)
        Dim dz As Integer = CInt(Math.Floor((targetrange(6) - targetrange(5) + 1) * Rnd())) + targetrange(5)

        generator.agentlocation(k, 5) = dx
        generator.agentlocation(k, 6) = dy
        generator.agentlocation(k, 7) = dz
    End Sub

    ''' <summary>
    ''' Agents look at the central zone and the closest zone and determine the utility (based on distance) for both. Agents go to the zone resulting in the highest utility.
    ''' </summary>
    ''' <param name="j"></param>
    ''' <param name="x"></param>
    ''' <param name="y"></param>
    ''' <param name="z"></param>
    Sub locationutility(ByVal j, ByVal x, ByVal y, ByVal z) 'agents look at the central zone and the closest zone and determine the utility (based on distance) for both. agents go to the zone resulting in the highest utility
        Dim locationcentral(3) As Integer
        Dim locationnearest(3) As Integer

        Dim centralzone(8) As Decimal
        For i = 1 To 1000
            Dim xlow As Integer = generator.zones(i, 1)
            Dim xup As Integer = generator.zones(i, 2)
            Dim ylow As Integer = generator.zones(i, 3)
            Dim yup As Integer = generator.zones(i, 4)
            Dim zlow As Integer = generator.zones(i, 5)
            Dim zup As Integer = generator.zones(i, 6)
            If xlow = 0 Or xup = 0 Or ylow = 0 Or yup = 0 Or zlow = 0 Or zup = 0 Then
                Exit For
            End If
            If centralzone(7) < generator.zones(i, 7) Then
                For j = 1 To 7
                    centralzone(j) = generator.zones(i, j)
                Next
                centralzone(8) = i
            End If
        Next

        Dim closestzone As Integer
        Dim currentzone As Integer

        'determines current zone
        For i = 1 To 1000
            Dim xlow As Integer = generator.zones(i, 1)
            Dim xup As Integer = generator.zones(i, 2)
            Dim ylow As Integer = generator.zones(i, 3)
            Dim yup As Integer = generator.zones(i, 4)
            Dim zlow As Integer = generator.zones(i, 5)
            Dim zup As Integer = generator.zones(i, 6)
            If xlow = 0 Or xup = 0 Or ylow = 0 Or yup = 0 Or zlow = 0 Or zup = 0 Then
                Exit For
            End If
            If x >= xlow And x <= xup And y >= ylow And y <= yup And z >= zlow And z <= zup Then
                'current zone
                currentzone = i
            End If
        Next

        'determines closest zone that is not the current zone
        Dim distance As Decimal = 1000000
        Dim centraldistance As Decimal
        For i = 1 To 1000
            Dim xlow As Integer = generator.zones(i, 1)
            Dim xup As Integer = generator.zones(i, 2)
            Dim ylow As Integer = generator.zones(i, 3)
            Dim yup As Integer = generator.zones(i, 4)
            Dim zlow As Integer = generator.zones(i, 5)
            Dim zup As Integer = generator.zones(i, 6)
            Dim xavg As Decimal = (xlow + xup) / 2
            Dim yavg As Decimal = (ylow + yup) / 2
            Dim zavg As Decimal = (zlow + zup) / 2
            Dim xdiff As Decimal = Math.Abs(x - xavg)
            Dim ydiff As Decimal = Math.Abs(y - yavg)
            Dim zdiff As Decimal = Math.Abs(z - zavg)
            Dim dist As Decimal = Math.Sqrt((xdiff ^ 2) + (ydiff ^ 2) + (zdiff ^ 2))
            If xlow = 0 Or xup = 0 Or ylow = 0 Or yup = 0 Or zlow = 0 Or zup = 0 Then
                Exit For
            End If

            If distance > dist Then
                distance = dist
                If x >= xlow = False And x <= xup = False And y >= ylow = False And y <= yup = False And z >= zlow = False And z <= zup = False Then
                    closestzone = i
                End If
            End If

            If i = centralzone(8) Then 'calculates distance to central zone 
                Dim xlowi As Integer = generator.zones(i, 1)
                Dim xupi As Integer = generator.zones(i, 2)
                Dim ylowi As Integer = generator.zones(i, 3)
                Dim yupi As Integer = generator.zones(i, 4)
                Dim zlowi As Integer = generator.zones(i, 5)
                Dim zupi As Integer = generator.zones(i, 6)
                Dim xavgi As Decimal = (xlowi + xupi) / 2
                Dim yavgi As Decimal = (ylowi + yupi) / 2
                Dim zavgi As Decimal = (zlowi + zupi) / 2
                Dim xdiffi As Decimal = Math.Abs(x - xavgi)
                Dim ydiffi As Decimal = Math.Abs(y - yavgi)
                Dim zdiffi As Decimal = Math.Abs(z - zavgi)
                centraldistance = Math.Sqrt((xdiffi ^ 2) + (ydiffi ^ 2) + (zdiffi ^ 2))
            End If
        Next

        'utility calculation (for closest zone and central zone); uses distances to calculate utility
        Dim distances(2) As Decimal
        distances(1) = distance
        distances(2) = centraldistance

        Dim zonevalue(2) As Decimal
        zonevalue(1) = generator.zones(closestzone, 7)
        zonevalue(2) = generator.zones(centralzone(8), 7)

        'function (compares the utility and zone values)
        Dim centralzoneprob As Decimal = 0 'by default, agents will always prefer the central zone
        Dim closestzoneprob As Decimal = 0 'by default, agents will not go to the closest zone
        Dim utility(2) As Decimal
        Dim zonediff As Decimal = Math.Abs(zonevalue(1) - zonevalue(2))
        Dim distdiff As Decimal = Math.Abs(distances(1) - distances(2))

        utility(1) = zonevalue(1) - distances(1)
        utility(2) = zonevalue(2) - distances(2)

        If utility(2) >= utility(1) Or utility(2) < utility(1) Then
            'agent goes to a random location in the central zone
            Dim xlowi As Integer = generator.zones(centralzone(8), 1)
            Dim xupi As Integer = generator.zones(centralzone(8), 2)
            Dim ylowi As Integer = generator.zones(centralzone(8), 3)
            Dim yupi As Integer = generator.zones(centralzone(8), 4)
            Dim zlowi As Integer = generator.zones(centralzone(8), 5)
            Dim zupi As Integer = generator.zones(centralzone(8), 6)

            generator.agentlocation(j, 6) = CInt(Math.Floor((yupi - ylowi + 1) * Rnd())) + ylowi
            generator.agentlocation(j, 7) = CInt(Math.Floor((zupi - zlowi + 1) * Rnd())) + zlowi
            generator.agentlocation(j, 5) = CInt(Math.Floor((xupi - xlowi + 1) * Rnd())) + xlowi
        ElseIf utility(2) < utility(1) Then
            'agent goes to a random location in the closest zone
            Dim xlowi As Integer = generator.zones(closestzone, 1)
            Dim xupi As Integer = generator.zones(closestzone, 2)
            Dim ylowi As Integer = generator.zones(closestzone, 3)
            Dim yupi As Integer = generator.zones(closestzone, 4)
            Dim zlowi As Integer = generator.zones(closestzone, 5)
            Dim zupi As Integer = generator.zones(closestzone, 6)

            generator.agentlocation(j, 6) = CInt(Math.Floor((yupi - ylowi + 1) * Rnd())) + ylowi
            generator.agentlocation(j, 7) = CInt(Math.Floor((zupi - zlowi + 1) * Rnd())) + zlowi
            generator.agentlocation(j, 5) = CInt(Math.Floor((xupi - xlowi + 1) * Rnd())) + xlowi
        End If
    End Sub

    ''' <summary>
    ''' In the case of zones, agents scan their surroundings and go to the highest value zone they find (ie. could be local maximum or potentially the global maximum).
    ''' This prevents agents from scanning their surrounding area to avoid slowing down the program.
    ''' </summary>
    ''' <param name="j"></param>
    ''' <param name="x"></param>
    ''' <param name="y"></param>
    ''' <param name="z"></param>
    Sub abiotic(ByVal j, ByVal x, ByVal y, ByVal z) 'in the case of zones, agents scan their surroundings and go to the highest value zone they find. (ie. could be local maximum or potentially the global maximum)
        If generator.abioticenable = False Then 'prevents agents from scanning their surrounding area to avoid slowing down the program
            'Call tradezonemovement(j, x, y, z) 'for testing only
            Exit Sub
        End If

        'Try
        '    Call locationutility(j, x, y, z) 'for testing only (should be called from the timer sub)
        'Catch ex As Exception
        '    MessageBox.Show(ex.ToString)
        'End Try

        'Call tradezonemovement(j, x, y, z) 
        'Exit Sub

        'new code
        'For xi = 1 To xn
        '    For yi = 1 To yn
        '        For zi = 1 To zn
        '            For agenti = 1 To Me.agent
        '                generator.abiotic(agenti, xi, yi, zi) = generator.tradingzones(xi, yi, zi, 0)
        '            Next
        '        Next
        '    Next
        'Next

        Dim agent As Integer = generator.agentlocation(j, 4)

        Dim conditions As Integer = generator.abiotic(agent, x, y, z)
        Dim initial As Integer = generator.abiotic(agent, x, y, z)
        Dim loc(3) As Integer
        Dim localconditions(3 ^ 3) As Decimal
        Dim count As Integer = 1

        Dim rand As Integer = CInt(Math.Floor((2 - 1 + 1) * Rnd())) + 1 'prevents agent from prefering the top left corner due to the loop only starting with the smallest x,y,z values

        If rand = 1 Then
            For i = 1 To generator.agentsight 'the extent to which the agent sees its surroundings (can be changed)
                For xxi = (x - i) To (x + i)
                    For yyi = (y - i) To (y + i)
                        For zzi = (z - i) To (z + i)
                            If xxi >= 0 And xxi <= xn And yyi >= 0 And yyi <= yn And zzi >= 0 And zzi <= zn Then
                                If generator.abiotic(agent, xxi, yyi, zzi) > conditions Then
                                    loc(1) = xxi
                                    loc(2) = yyi
                                    loc(3) = zzi
                                    conditions = generator.abiotic(agent, xxi, yyi, zzi)
                                    localconditions(count) = generator.abiotic(agent, xxi, yyi, zzi)
                                    count += 1
                                End If
                            End If
                        Next
                    Next
                Next
            Next
        ElseIf rand = 2 Then
            For i = 1 To generator.agentsight 'the extent to which the agent sees its surroundings (can be changed)
                For xxi = (x + i) To (x - i) Step -1
                    For yyi = (y + i) To (y - i) Step -1
                        For zzi = (z + i) To (z - i) Step -1
                            If xxi >= 0 And xxi <= xn And yyi >= 0 And yyi <= yn And zzi >= 0 And zzi <= zn Then
                                If generator.abiotic(agent, xxi, yyi, zzi) > conditions Then
                                    loc(1) = xxi
                                    loc(2) = yyi
                                    loc(3) = zzi
                                    conditions = generator.abiotic(agent, xxi, yyi, zzi)
                                    localconditions(count) = generator.abiotic(agent, xxi, yyi, zzi)
                                    count += 1
                                End If
                            End If
                        Next
                    Next
                Next
            Next
        End If

        If conditions > initial Then 'the agent prefers to move towards more favourable regions
            generator.agentlocation(j, 5) = loc(1)
            generator.agentlocation(j, 6) = loc(2)
            generator.agentlocation(j, 7) = loc(3)
        ElseIf conditions = initial And conditions <> localconditions.ToArray.Min Then 'ensures that if another more favourable region is not found that the agent stays in favourable areas
            Dim dx, dy, dz As Integer
            Dim rangexupper As Integer = generator.agentrange(agent, 0, 1)
            Dim rangexlower As Integer = generator.agentrange(agent, 0, 0)
            Dim rangeyupper As Integer = generator.agentrange(agent, 1, 1)
            Dim rangeylower As Integer = generator.agentrange(agent, 1, 0)
            Dim rangezupper As Integer = generator.agentrange(agent, 2, 1)
            Dim rangezlower As Integer = generator.agentrange(agent, 2, 0)
            Do While dx > rangexupper Or dx < rangexlower Or dy > rangeyupper Or dy < rangeylower Or dz > rangezupper Or dz < rangezlower
                dz = CInt(Math.Floor(((z + 3) - (z - 3) + 1) * Rnd())) + (z - 3)
                dy = CInt(Math.Floor(((y + 3) - (y - 3) + 1) * Rnd())) + (y - 3)
                dx = CInt(Math.Floor(((x + 3) - (x - 3) + 1) * Rnd())) + (x - 3)
            Loop
            Dim lim As Integer = 0
            Do While generator.abiotic(agent, dx, dy, dz) < conditions And lim < 50
                Do While dx > rangexupper Or dx < rangexlower Or dy > rangeyupper Or dy < rangeylower Or dz > rangezupper Or dz < rangezlower
                    dz = CInt(Math.Floor(((z + 3) - (z - 3) + 1) * Rnd())) + (z - 3)
                    dy = CInt(Math.Floor(((y + 3) - (y - 3) + 1) * Rnd())) + (y - 3)
                    dx = CInt(Math.Floor(((x + 3) - (x - 3) + 1) * Rnd())) + (x - 3)
                Loop
                lim += 1
            Loop
            generator.agentlocation(j, 5) = dx
            generator.agentlocation(j, 6) = dy
            generator.agentlocation(j, 7) = dz
        End If
    End Sub

    ''' <summary>
    ''' Allows turn energy to depend on the local region of the agent.
    ''' </summary>
    ''' <param name="i"></param>
    ''' <returns></returns>
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

    ''' <summary>
    ''' Makes sure that any new agents being placed (after changing the initial count) are static if the agent type was previously made static by the user
    ''' </summary>
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
            'dz = CInt(Math.Floor((rangezupper - rangezlower + 1) * Rnd())) + rangezlower

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
        Dim oppType As Integer

        For opp = 1 To total
            If generator.agentlocation(opp, 0) = opponentx And generator.agentlocation(opp, 1) = opponenty And generator.agentlocation(opp, 2) = opponentz And i <> opp Then
                oppType = generator.agentlocation(opp, 4)
                If generator.action(generator.agentlocation(i, 4), oppType, 1, 0, 0) = 2 Then ' This is what limits to one interaction between agent types.
                    generator.interactioncount(generator.agentlocation(i, 4)) += 1
                    generator.interactioncount(oppType) += 1
                    Dim randomvalue As Decimal = CDec(Math.Floor(101) * Rnd())
                    If catalysispresence(i, opp) = True Then
                        If randomvalue > 0 And randomvalue <= generator.catalystprobability(generator.agentlocation(i, 4), generator.agentlocation(opp, 4)) Then
                            Call consume(opp, opponentx, opponenty, opponentz, i)
                        End If
                    Else
                        If randomvalue > 0 And randomvalue <= generator.interactionprobability(generator.agentlocation(i, 4), oppType) Then
                            Call consume(opp, opponentx, opponenty, opponentz, i)
                        End If
                    End If

                ElseIf generator.action(generator.agentlocation(i, 4), oppType, 1, 0, 0) = 1 Then
                    generator.interactioncount(generator.agentlocation(i, 4)) += 1
                    generator.interactioncount(oppType) += 1
                    Dim randomvalue As Decimal = CDec(Math.Floor(101) * Rnd())
                    If catalysispresence(i, opp) = True Then
                        If randomvalue > 0 And randomvalue <= generator.catalystprobability(generator.agentlocation(i, 4), generator.agentlocation(opp, 4)) Then
                            Call produce(generator.agentlocation(i, 4), oppType, i, opp)
                        End If
                    Else
                        If randomvalue > 0 And randomvalue <= generator.interactionprobability(generator.agentlocation(i, 4), oppType) Then
                            Call produce(generator.agentlocation(i, 4), oppType, i, opp)
                        End If
                    End If

                ElseIf generator.action(generator.agentlocation(i, 4), oppType, 1, 0, 0) = 3 Then
                    generator.interactioncount(generator.agentlocation(i, 4)) += 1
                    generator.interactioncount(oppType) += 1
                    Dim randomvalue As Decimal = CDec(Math.Floor(101) * Rnd())
                    If catalysispresence(i, opp) = True Then
                        If randomvalue > 0 And randomvalue <= generator.catalystprobability(generator.agentlocation(i, 4), generator.agentlocation(opp, 4)) Then
                            Call deminish(i, generator.agentlocation(i, 0), generator.agentlocation(i, 1), generator.agentlocation(i, 2), opp)
                        End If
                    Else
                        If randomvalue > 0 And randomvalue <= generator.interactionprobability(generator.agentlocation(i, 4), oppType) Then
                            Call deminish(i, generator.agentlocation(i, 0), generator.agentlocation(i, 1), generator.agentlocation(i, 2), opp)
                        End If
                    End If


                ElseIf generator.action(generator.agentlocation(i, 4), oppType, 1, 0, 0) = 4 Then
                    generator.interactioncount(generator.agentlocation(i, 4)) += 1
                    generator.interactioncount(oppType) += 1
                    Dim randomvalue As Decimal = CDec(Math.Floor(101) * Rnd())
                    If catalysispresence(i, opp) = True Then
                        If randomvalue > 0 And randomvalue <= generator.catalystprobability(generator.agentlocation(i, 4), generator.agentlocation(opp, 4)) Then
                            Call produce(generator.agentlocation(i, 4), oppType, i, opp)
                            Call consume(opp, opponentx, opponenty, opponentz, i)
                        End If
                    Else
                        If randomvalue > 0 And randomvalue <= generator.interactionprobability(generator.agentlocation(i, 4), oppType) Then
                            Call produce(generator.agentlocation(i, 4), oppType, i, opp)
                            Call consume(opp, opponentx, opponenty, opponentz, i)
                        End If
                    End If


                ElseIf generator.action(generator.agentlocation(i, 4), oppType, 1, 0, 0) = 5 Then
                    generator.interactioncount(generator.agentlocation(i, 4)) += 1
                    generator.interactioncount(oppType) += 1
                    Dim randomvalue As Decimal = CDec(Math.Floor(101) * Rnd())
                    If catalysispresence(i, opp) = True Then
                        If randomvalue > 0 And randomvalue <= generator.catalystprobability(generator.agentlocation(i, 4), generator.agentlocation(opp, 4)) Then
                            Call deminishconsume(i, generator.agentlocation(i, 0), generator.agentlocation(i, 1), generator.agentlocation(i, 2), opp, opponentx, opponenty, opponentz)
                        End If
                    Else
                        If randomvalue > 0 And randomvalue <= generator.interactionprobability(generator.agentlocation(i, 4), oppType) Then
                            Call deminishconsume(i, generator.agentlocation(i, 0), generator.agentlocation(i, 1), generator.agentlocation(i, 2), opp, opponentx, opponenty, opponentz)
                        End If
                    End If


                ElseIf generator.action(generator.agentlocation(i, 4), oppType, 1, 0, 0) = 6 Then
                    generator.interactioncount(generator.agentlocation(i, 4)) += 1
                    generator.interactioncount(oppType) += 1
                    Dim randomvalue As Decimal = CDec(Math.Floor(101) * Rnd())
                    If catalysispresence(i, opp) = True Then
                        If randomvalue > 0 And randomvalue <= generator.catalystprobability(generator.agentlocation(i, 4), generator.agentlocation(opp, 4)) Then
                            Call produce(generator.agentlocation(i, 4), oppType, i, opp)
                            Call deminish(i, generator.agentlocation(i, 0), generator.agentlocation(i, 1), generator.agentlocation(i, 2), 0)
                        End If
                    Else
                        If randomvalue > 0 And randomvalue <= generator.interactionprobability(generator.agentlocation(i, 4), oppType) Then
                            Call produce(generator.agentlocation(i, 4), oppType, i, opp)
                            Call deminish(i, generator.agentlocation(i, 0), generator.agentlocation(i, 1), generator.agentlocation(i, 2), 0)
                        End If
                    End If


                ElseIf generator.action(generator.agentlocation(i, 4), oppType, 1, 0, 0) = 7 Then
                    generator.interactioncount(generator.agentlocation(i, 4)) += 1
                    generator.interactioncount(oppType) += 1
                    Dim randomvalue As Decimal = CDec(Math.Floor(101) * Rnd())
                    If catalysispresence(i, opp) = True Then
                        If randomvalue > 0 And randomvalue <= generator.catalystprobability(generator.agentlocation(i, 4), generator.agentlocation(opp, 4)) Then
                            Call produce(generator.agentlocation(i, 4), oppType, i, opp)
                            Call deminishconsume(i, generator.agentlocation(i, 0), generator.agentlocation(i, 1), generator.agentlocation(i, 2), opp, opponentx, opponenty, opponentz)
                        End If
                    Else
                        If randomvalue > 0 And randomvalue <= generator.interactionprobability(generator.agentlocation(i, 4), oppType) Then
                            Call produce(generator.agentlocation(i, 4), oppType, i, opp)
                            Call deminishconsume(i, generator.agentlocation(i, 0), generator.agentlocation(i, 1), generator.agentlocation(i, 2), opp, opponentx, opponenty, opponentz)
                        End If
                    End If
                    'exchange
                ElseIf generator.action(generator.agentlocation(i, 4), oppType, 1, 0, 0) = 8 Then
                    generator.interactioncount(generator.agentlocation(i, 4)) += 1
                    generator.interactioncount(oppType) += 1
                    Dim randomvalue As Decimal = CDec(Math.Floor(101) * Rnd())
                    If catalysispresence(i, opp) = True Then
                        If randomvalue > 0 And randomvalue <= generator.catalystprobability(generator.agentlocation(i, 4), generator.agentlocation(opp, 4)) Then
                            Call exchange(i, opp)
                        End If
                    Else
                        If randomvalue > 0 And randomvalue <= generator.interactionprobability(generator.agentlocation(i, 4), oppType) Then
                            Call exchange(i, opp)
                        End If
                    End If
                End If

                If tryTransform(i, opp) Then Exit For
                'Exit For ' TODO: TEST THIS OPTIMIZATION!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            End If
        Next
    End Sub

    Function tryTransform(agentIndex As Integer, oppType As Integer) As Boolean
        Dim transformKey = New TransformationKey(generator.agentlocation(agentIndex, 4), oppType)
        If generator.transformationPlans.ContainsKey(transformKey) Then
            Dim transProp = generator.transformationPlans.Item(transformKey)
            If (generator.agentlocation(agentIndex, 11) >= transProp.xThreshold) Then
                generator.agentlocation(agentIndex, 4) = transProp.destType
                Return True
            End If
        End If
        Return False
    End Function

    ''' <summary>
    ''' Indicates whether or not a catalyst is present in close proximity to the potential interaction.
    ''' </summary>
    ''' <param name="i"></param>
    ''' <param name="opp"></param>
    ''' <returns></returns>
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

    ''' <summary>
    ''' Allows for exchanges (TODO: currently for currency and product only. a more general exchange should be made possible later).
    ''' </summary>
    ''' <param name="i"></param>
    ''' <param name="opp"></param>
    Sub exchange(ByVal i, ByVal opp)
        'new trading mechanism (for two items that can be traded)
        Dim tempagenta As Decimal = 0
        Dim tempagentb As Decimal = 0
        Dim transfer(6) As Decimal
        transfer(1) = generator.product(generator.agentlocation(i, 4), generator.agentlocation(opp, 4), 11)
        transfer(2) = generator.product(generator.agentlocation(i, 4), generator.agentlocation(opp, 4), 12)
        transfer(3) = generator.product(generator.agentlocation(i, 4), generator.agentlocation(opp, 4), 13) '0 is the default, 2 indicates a dynamic quantity
        transfer(4) = generator.product(generator.agentlocation(i, 4), generator.agentlocation(opp, 4), 14) 'the upper limit of the quantity of y that can be exchanged
        transfer(5) = generator.product(generator.agentlocation(i, 4), generator.agentlocation(opp, 4), 15) 'the values by which quantity of y is incremented
        transfer(6) = generator.product(generator.agentlocation(i, 4), generator.agentlocation(opp, 4), 16) 'the minimum quantity of y that can be exchanged
        'MessageBox.Show(transfer(4) & vbCrLf & transfer(5) & vbCrLf & transfer(6))
        Dim itypeUtilityFunction = generator.agentTypeUtilityFunction(generator.agentlocation(i, 4))
        If (generator.agentlocation(i, 11) + (transfer(1) * generator.agentlocation(i, 17))) >= 0 And (generator.agentlocation(i, 12) + (transfer(2) * generator.agentlocation(i, 17) * -1)) >= 0 Then 'prevents invalid operations (ie. sqrt(negative number))
            If itypeUtilityFunction = 1 Then 'sqrt(xy)
                tempagenta = Math.Sqrt((generator.agentlocation(i, 11) + (transfer(1) * generator.agentlocation(i, 17))) * (generator.agentlocation(i, 12) + (transfer(2) * generator.agentlocation(i, 17) * -1)))
            ElseIf itypeUtilityFunction = 2 Then 'second utility function U = (C^0.5)*(P^0.5)
                tempagenta = ((generator.agentlocation(i, 11) + (transfer(1) * generator.agentlocation(i, 17))) ^ generator.agentlocation(i, 15)) * ((generator.agentlocation(i, 12) + (transfer(2) * generator.agentlocation(i, 17) * -1)) ^ generator.agentlocation(i, 16))
            ElseIf itypeUtilityFunction = 3 Then 'third utility function ax + by
                tempagenta = (generator.agentlocation(i, 15) * ((generator.agentlocation(i, 11) + (transfer(1) * generator.agentlocation(i, 17))))) + (generator.agentlocation(i, 16) * ((generator.agentlocation(i, 12) + (transfer(2) * generator.agentlocation(i, 17) * -1))))
            ElseIf itypeUtilityFunction = 4 Then 'min(x,y)
                tempagenta = Math.Min((generator.agentlocation(i, 11) + (transfer(1) * generator.agentlocation(i, 17))), (generator.agentlocation(i, 12) + (transfer(2) * generator.agentlocation(i, 17) * -1)))
            End If
        End If
        Dim opptypeUtilityFunction = generator.agentTypeUtilityFunction(generator.agentlocation(opp, 4))
        If (generator.agentlocation(opp, 11) + (transfer(1) * generator.agentlocation(opp, 17))) >= 0 And (generator.agentlocation(opp, 12) + (transfer(2) * generator.agentlocation(opp, 17) * -1)) >= 0 Then
            If opptypeUtilityFunction = 1 Then 'sqrt(xy)
                tempagentb = Math.Sqrt((generator.agentlocation(opp, 11) + (transfer(1) * generator.agentlocation(opp, 17))) * (generator.agentlocation(opp, 12) + (transfer(2) * generator.agentlocation(opp, 17) * -1)))
            ElseIf opptypeUtilityFunction = 2 Then 'second utility function U = (C^0.5)*(P^0.5)
                tempagentb = ((generator.agentlocation(opp, 11) + (transfer(1) * generator.agentlocation(opp, 17))) ^ generator.agentlocation(opp, 15)) * ((generator.agentlocation(opp, 12) + (transfer(2) * generator.agentlocation(opp, 17) * -1)) ^ generator.agentlocation(opp, 16))
            ElseIf opptypeUtilityFunction = 3 Then 'third utility function ax + by
                tempagentb = (generator.agentlocation(opp, 15) * ((generator.agentlocation(opp, 11) + (transfer(1) * generator.agentlocation(opp, 17))))) + (generator.agentlocation(opp, 16) * ((generator.agentlocation(opp, 12) + (transfer(2) * generator.agentlocation(opp, 17) * -1))))
            ElseIf opptypeUtilityFunction = 4 Then 'min(x,y)
                tempagentb = Math.Min((generator.agentlocation(opp, 11) + (transfer(1) * generator.agentlocation(opp, 17))), (generator.agentlocation(opp, 12) + (transfer(2) * generator.agentlocation(opp, 17) * -1)))
            End If
        End If

        If tempagenta > generator.agentlocation(i, 14) And tempagentb > generator.agentlocation(opp, 14) And transfer(3) = 0 Then 'the exchange occurs
            generator.agentlocation(i, 11) += (transfer(1) * generator.agentlocation(i, 17))
            generator.agentlocation(i, 12) += (transfer(2) * generator.agentlocation(i, 17) * -1)
            generator.agentlocation(opp, 11) += (transfer(1) * generator.agentlocation(opp, 17))
            generator.agentlocation(opp, 12) += (transfer(2) * generator.agentlocation(opp, 17) * -1)
            generator.agentlocation(i, 14) = tempagenta
            generator.agentlocation(opp, 14) = tempagentb
            Call trade(opp)
            generator.agentlocation(i, 18) = transfer(1) * generator.agentlocation(i, 17)
            generator.agentlocation(i, 19) = transfer(2) * generator.agentlocation(i, 17) * -1
            generator.agentlocation(opp, 18) = transfer(1) * generator.agentlocation(opp, 17)
            generator.agentlocation(opp, 19) = transfer(2) * generator.agentlocation(opp, 17) * -1
        End If


        If transfer(3) = 2 Then
            Dim max(3) As Decimal
            Dim acceptabley(0) As Integer
            Dim acceptabletempagenta(0) As Decimal
            Dim acceptabletempagentb(0) As Decimal 'stores the new utilities that are higher than old ones per trade
            Dim t As Integer = 0 'extends the array 
            Dim directionchange As Boolean = False '

            For quantityY = transfer(6) To transfer(4) Step transfer(5) 'if an exchange is not possible at the original relative price, then the quantity of the second good traded is increased until an exchange becomes favourable
                'the quantity of the second good is increased; the quantity of the first good stays constant
                'tempagenta = 0
                'tempagentb = 0
                transfer(2) = quantityY
                If directionchange = False Then 'if a change in direction occurs, the quantity is not incremented
                    transfer(2) = quantityY
                ElseIf directionchange = True Then
                    quantityY = transfer(2)
                    directionchange = False
                End If

                If (generator.agentlocation(i, 11) + (transfer(1) * generator.agentlocation(i, 17))) >= 0 And (generator.agentlocation(i, 12) + (transfer(2) * generator.agentlocation(i, 17) * -1)) >= 0 Then 'prevents invalid operations (ie. sqrt(negative number))
                    If itypeUtilityFunction = 1 Then 'sqrt(xy)
                        tempagenta = Math.Sqrt((generator.agentlocation(i, 11) + (transfer(1) * generator.agentlocation(i, 17))) * (generator.agentlocation(i, 12) + (transfer(2) * generator.agentlocation(i, 17) * -1)))
                    ElseIf itypeUtilityFunction = 2 Then 'second utility function U = (C^0.5)*(P^0.5)
                        tempagenta = ((generator.agentlocation(i, 11) + (transfer(1) * generator.agentlocation(i, 17))) ^ generator.agentlocation(i, 15)) * ((generator.agentlocation(i, 12) + (transfer(2) * generator.agentlocation(i, 17) * -1)) ^ generator.agentlocation(i, 16))
                    ElseIf itypeUtilityFunction = 3 Then 'third utility function ax + by
                        tempagenta = (generator.agentlocation(i, 15) * ((generator.agentlocation(i, 11) + (transfer(1) * generator.agentlocation(i, 17))))) + (generator.agentlocation(i, 16) * ((generator.agentlocation(i, 12) + (transfer(2) * generator.agentlocation(i, 17) * -1))))
                    ElseIf itypeUtilityFunction = 4 Then 'min(x,y)
                        tempagenta = Math.Min((generator.agentlocation(i, 11) + (transfer(1) * generator.agentlocation(i, 17))), (generator.agentlocation(i, 12) + (transfer(2) * generator.agentlocation(i, 17) * -1)))
                    End If
                End If

                If (generator.agentlocation(opp, 11) + (transfer(1) * generator.agentlocation(opp, 17))) >= 0 And (generator.agentlocation(opp, 12) + (transfer(2) * generator.agentlocation(opp, 17) * -1)) >= 0 Then
                    If opptypeUtilityFunction = 1 Then 'sqrt(xy)
                        tempagentb = Math.Sqrt((generator.agentlocation(opp, 11) + (transfer(1) * generator.agentlocation(opp, 17))) * (generator.agentlocation(opp, 12) + (transfer(2) * generator.agentlocation(opp, 17) * -1)))
                    ElseIf opptypeUtilityFunction = 2 Then 'second utility function U = (C^0.5)*(P^0.5)
                        tempagentb = ((generator.agentlocation(opp, 11) + (transfer(1) * generator.agentlocation(opp, 17))) ^ generator.agentlocation(opp, 15)) * ((generator.agentlocation(opp, 12) + (transfer(2) * generator.agentlocation(opp, 17) * -1)) ^ generator.agentlocation(opp, 16))
                    ElseIf opptypeUtilityFunction = 3 Then 'third utility function ax + by
                        tempagentb = (generator.agentlocation(opp, 15) * ((generator.agentlocation(opp, 11) + (transfer(1) * generator.agentlocation(opp, 17))))) + (generator.agentlocation(opp, 16) * ((generator.agentlocation(opp, 12) + (transfer(2) * generator.agentlocation(opp, 17) * -1))))
                    ElseIf opptypeUtilityFunction = 4 Then 'min(x,y)
                        tempagentb = Math.Min((generator.agentlocation(opp, 11) + (transfer(1) * generator.agentlocation(opp, 17))), (generator.agentlocation(opp, 12) + (transfer(2) * generator.agentlocation(opp, 17) * -1)))
                    End If
                End If


                If tempagenta > generator.agentlocation(i, 14) And tempagentb > generator.agentlocation(opp, 14) And (generator.agentlocation(i, 17) <> generator.agentlocation(opp, 17)) Then 'the exchange occurs
                    acceptabletempagenta(t) = tempagenta   'if a potential trade improves both utilities (ie tempagent>agentlocation for both) then store the trade, and both utilities in an array. 
                    acceptabletempagentb(t) = tempagentb
                    acceptabley(t) = transfer(2)
                    ReDim Preserve acceptabley(t + 1)
                    ReDim Preserve acceptabletempagenta(t + 1)
                    ReDim Preserve acceptabletempagentb(t + 1)
                    t = t + 1
                End If
                'MessageBox.Show(transfer(2) & vbCrLf & transfer(6) & vbCrLf & transfer(4))
                'If tempagenta <= generator.agentlocation(i, 14) Then 'changes direction
                '    generator.agentlocation(i, 17) = generator.agentlocation(i, 17) * -1
                '    directionchange = True
                'End If
                'If tempagentb <= generator.agentlocation(opp, 14) Then 'changes direction
                '    generator.agentlocation(opp, 17) = generator.agentlocation(opp, 17) * -1
                '    directionchange = True
                'End If
            Next

            Dim randomnmbr As Integer = CInt(Math.Floor(Rnd() * 10)) 'just want to make the median trade random

            If t Mod 2 = 1 And t <> 0 Then
                max(1) = acceptabletempagenta((t - 1) / 2) 'cobweb will just take the median trade (randomize instead of rounding)
                max(2) = acceptabletempagentb((t - 1) / 2) ' t starts at 0 so this is kind of confusing
                max(3) = acceptabley((t - 1) / 2)

            End If




            If t Mod 2 = 0 And t <> 0 And randomnmbr Mod 2 = 1 Then
                max(1) = acceptabletempagenta((t - 2) / 2)
                max(2) = acceptabletempagentb((t - 2) / 2)
                max(3) = acceptabley((t - 2) / 2)
            ElseIf t Mod 2 = 0 And t <> 0 And randomnmbr Mod 2 = 0 Then
                max(1) = acceptabletempagenta((t) / 2)
                max(2) = acceptabletempagentb((t) / 2)
                max(3) = acceptabley((t) / 2)
            End If

            If t = 0 Then
                max(1) = acceptabletempagenta(0)
                max(2) = acceptabletempagentb(0)
                max(3) = acceptabley(0)
            End If

            If max(1) > generator.agentlocation(i, 14) And max(2) > generator.agentlocation(opp, 14) Then
                transfer(2) = max(3) 'new quantity of the second good being exchanged
                generator.agentlocation(i, 11) += (transfer(1) * generator.agentlocation(i, 17))
                generator.agentlocation(i, 12) += (transfer(2) * generator.agentlocation(i, 17) * -1)
                generator.agentlocation(opp, 11) += (transfer(1) * generator.agentlocation(opp, 17))
                generator.agentlocation(opp, 12) += (transfer(2) * generator.agentlocation(opp, 17) * -1)
                generator.agentlocation(i, 14) = max(1)
                generator.agentlocation(opp, 14) = max(2)
                Call trade(opp)
                generator.agentlocation(i, 18) = transfer(1) * generator.agentlocation(i, 17)
                generator.agentlocation(i, 19) = transfer(2) * generator.agentlocation(i, 17) * -1
                generator.agentlocation(opp, 18) = transfer(1) * generator.agentlocation(opp, 17)
                generator.agentlocation(opp, 19) = transfer(2) * generator.agentlocation(opp, 17) * -1
                t = 1
                Exit Sub
            End If

            If max(1) <= generator.agentlocation(i, 14) Then 'changes direction
                generator.agentlocation(i, 17) = generator.agentlocation(i, 17) * -1 'problem:this doesn't rerun the code, or make all the agentlocations -1 the first time.
            End If
            If max(2) <= generator.agentlocation(opp, 14) Then 'changes direction
                generator.agentlocation(opp, 17) = generator.agentlocation(opp, 17) * -1
            End If
            Exit Sub
        End If

        If tempagenta <= generator.agentlocation(i, 14) Then 'changes direction
            generator.agentlocation(i, 17) = generator.agentlocation(i, 17) * -1
        End If
        If tempagentb <= generator.agentlocation(opp, 14) Then 'changes direction
            generator.agentlocation(opp, 17) = generator.agentlocation(opp, 17) * -1
        End If
    End Sub

    Sub trade(ByVal opp)
        For i = 1 To 1000
            Dim xlow As Integer = generator.zones(i, 1)
            Dim xup As Integer = generator.zones(i, 2)
            Dim ylow As Integer = generator.zones(i, 3)
            Dim yup As Integer = generator.zones(i, 4)
            Dim zlow As Integer = generator.zones(i, 5)
            Dim zup As Integer = generator.zones(i, 6)
            If generator.agentlocation(opp, 0) > xlow And generator.agentlocation(opp, 0) < xup And generator.agentlocation(opp, 1) > ylow And generator.agentlocation(opp, 1) < yup And generator.agentlocation(opp, 2) > zlow And generator.agentlocation(opp, 2) < zup Then
                'opponent agent is in this zone
                generator.zones(i, 7) += 1 'adds 1 to the value for that zone everytime a transaction occurs in that zone
            End If
        Next
        Call tradezones(opp)
    End Sub

    Sub deminish(ByVal i, ByVal ix, ByVal iy, ByVal iz, ByVal opp)
        If generator.agentreservoir(opp, 2) > generator.agentreservoir(opp, 1) - generator.reservoirchange(generator.agentlocation(i, 4), generator.agentlocation(opp, 4), 1) Then
            Exit Sub
        End If

        If generator.agentreservoir(opp, 0) = 2 Then
            generator.agentreservoir(opp, 2) += generator.reservoirchange(generator.agentlocation(i, 4), generator.agentlocation(opp, 4), 1)
        End If

        generator.removeAgent(i)
    End Sub

    Sub consume(ByVal opp, ByVal opponentx, ByVal opponenty, ByVal opponentz, ByVal i)
        If generator.action(generator.agentlocation(i, 4), generator.agentlocation(opp, 4), 6, 0, 0) = 1 Then
            generator.agentlocation(i, 8) = generator.agentlocation(i, 8) + (generator.agentlocation(opp, 8) * (generator.action(generator.agentlocation(i, 4), generator.agentlocation(opp, 4), 3, 0, 0) / 100))
        ElseIf generator.action(generator.agentlocation(i, 4), generator.agentlocation(opp, 4), 6, 0, 0) = 2 Then
            generator.agentlocation(i, 8) = generator.agentlocation(i, 8) + generator.action(generator.agentlocation(i, 4), generator.agentlocation(opp, 4), 4, 0, 0)
        End If


        generator.removeAgent(opp)
    End Sub

    Sub produce(ByVal ag1, ByVal ag2, ByVal i, ByVal opp)
        Dim originalagent As Integer = i

        Dim totalagentstobeproduced As Integer
        For i = 1 To agentTypeCount
            totalagentstobeproduced = totalagentstobeproduced + generator.action(ag1, ag2, 2, i, 1)
        Next


        If total + totalagentstobeproduced <= generator.maxcell Then

            'energy cost in reproduction
            generator.agentlocation(i, 8) = generator.agentlocation(i, 8) - generator.action(ag1, ag2, 5, 0, 0)
            generator.agentlocation(opp, 8) = generator.agentlocation(opp, 8) - generator.action(ag1, ag2, 5, 0, 0)


            Dim indexproduced As Integer = 1
            Dim agenttobeproduced(totalagentstobeproduced) As Integer
            For i = 1 To agentTypeCount
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
                'total = total + 1
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

                generator.createAgent(agenttobeproduced(i), x, y, z, CInt(Math.Floor((6) * Rnd())) + 1, dx, dy, dz)

                'generator.occupied(x, y, z) = True

                'Dim d As Integer = CInt(Math.Floor((6) * Rnd())) + 1
                'generator.agentlocation(total, 0) = x
                'generator.agentlocation(total, 1) = y
                'generator.agentlocation(total, 2) = z
                'generator.agentlocation(total, 3) = d
                'generator.agentlocation(total, 4) = agenttobeproduced(i)
                'generator.agentlocation(total, 5) = dx
                'generator.agentlocation(total, 6) = dy
                'generator.agentlocation(total, 7) = dz
                'generator.agentlocation(total, 8) = generator.initialenergy(agenttobeproduced(i))
                'generator.agentlocation(total, 9) = 0
                'generator.agentlocation(total, 10) = 0
            Next
        End If
    End Sub

    Sub deminishconsume(ByVal i, ByVal ix, ByVal iy, ByVal iz, ByVal opp, ByVal opponentx, ByVal opponenty, ByVal opponentz)
        generator.removeAgent(i)
        generator.removeAgent(opp)
    End Sub

    Private Sub reservoirrelase(ByVal i As Integer)
        For i = 1 To total
            For j = 1 To agentTypeCount

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
                            'total = total + 1


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

                            generator.createAgent(agenttobeproduced(k), x, y, z, CInt(Math.Floor((6) * Rnd())) + 1, dx, dy, dz)
                            'generator.occupied(x, y, z) = True

                            'Dim d As Integer = CInt(Math.Floor((6) * Rnd())) + 1
                            'generator.agentlocation(total, 0) = x
                            'generator.agentlocation(total, 1) = y
                            'generator.agentlocation(total, 2) = z
                            'generator.agentlocation(total, 3) = d
                            'generator.agentlocation(total, 4) = agenttobeproduced(k)
                            'generator.agentlocation(total, 5) = dx
                            'generator.agentlocation(total, 6) = dy
                            'generator.agentlocation(total, 7) = dz
                            'generator.agentlocation(total, 8) = generator.initialenergy(agenttobeproduced(k))
                            'generator.agentlocation(total, 9) = 0
                            'generator.agentlocation(total, 10) = 0

                            generator.agentreservoir(i, 2) -= generator.reservoiragentreleased(generator.agentlocation(i, 4), j, 2)

                            If generator.agentreservoir(i, 2) < generator.reservoiragentreleased(generator.agentlocation(i, 4), j, 2) Then
                                Exit Sub
                            End If
                        Next
                        Console.WriteLine("Weird thing called")
                        draw() 'TODO: What is this? Why doesnt this code ever get executed in my own tests?
                    End If
                End If
            Next
        Next
    End Sub
    Sub asrproduce(ByVal agentType As Integer)
        If total < generator.maxcell Then
            ' total = total + 1

            Dim x As Integer = CInt(Math.Floor((xn) * Rnd())) + 1
            Dim y As Integer = CInt(Math.Floor((yn) * Rnd())) + 1
            Dim z As Integer = CInt(Math.Floor((zn) * Rnd())) + 1

            Dim dx As Integer
            Dim dy As Integer
            Dim dz As Integer
            'Dim a As Integer = generator.action(ag1, ag2, 2)
            'look here


            Dim rangexupper As Integer = generator.agentrange(agentType, 0, 1)
            Dim rangexlower As Integer = generator.agentrange(agentType, 0, 0)
            Dim rangeyupper As Integer = generator.agentrange(agentType, 1, 1)
            Dim rangeylower As Integer = generator.agentrange(agentType, 1, 0)
            Dim rangezupper As Integer = generator.agentrange(agentType, 2, 1)
            Dim rangezlower As Integer = generator.agentrange(agentType, 2, 0)

            dx = CInt(Math.Floor((rangexupper - rangexlower + 1) * Rnd())) + rangexlower
            dy = CInt(Math.Floor((rangeyupper - rangeylower + 1) * Rnd())) + rangeylower
            dz = CInt(Math.Floor((rangezupper - rangezlower + 1) * Rnd())) + rangezlower



            Dim number As Integer = 0
            Do While generator.occupied(x, y, z) = True And number < generator.maxcell
                number = number + 1
                x = CInt(Math.Floor((xn) * Rnd())) + 1
                y = CInt(Math.Floor((yn) * Rnd())) + 1
                z = CInt(Math.Floor((zn) * Rnd())) + 1
            Loop

            generator.createAgent(agentType, x, y, z, CInt(Math.Floor((6) * Rnd())) + 1, dx, dy, dz)
            'generator.occupied(x, y, z) = True

            'Dim d As Integer = CInt(Math.Floor((6) * Rnd())) + 1
            'generator.agentlocation(total, 0) = x
            'generator.agentlocation(total, 1) = y
            'generator.agentlocation(total, 2) = z
            'generator.agentlocation(total, 3) = d
            'generator.agentlocation(total, 4) = agent
            'generator.agentlocation(total, 5) = dx
            'generator.agentlocation(total, 6) = dy
            'generator.agentlocation(total, 7) = dz
            'generator.agentlocation(total, 8) = generator.initialenergy(agent)
            'generator.agentlocation(total, 9) = 0
            'generator.agentlocation(total, 10) = 0
        End If
    End Sub
#End Region

    Sub resetSimulation()
        VBMath.Randomize()
        total = 0
        tick = 0
        tslblCurrentTick.Text = tick
        generator.resetAgents()

        'changes the direction of new agents according to user input
        For i = 1 To agentTypeCount
            If generator.agentdirection(i) <> 0 Then
                For a = 1 To total
                    If generator.agentlocation(a, 4) = i Then
                        generator.agentlocation(a, 3) = generator.agentdirection(i)
                    End If
                Next
            End If
        Next

        draw()
    End Sub

    Sub drawAgents(ByRef graphicsContext As Graphics)
        sortAgentsZBuffer(Me.RenderingEngine.Prespective)
        For i = 1 To total
            Dim x As Integer = generator.agentlocation(i, 0)
            Dim y As Integer = generator.agentlocation(i, 1)
            Dim z As Integer = generator.agentlocation(i, 2)
            Dim d As Integer = generator.agentlocation(i, 3)
            Dim ag As Integer = generator.agentlocation(i, 4)
            Dim color As Color = generator.agentcolour(ag)
            RenderingEngine.renderAgent(x, y, z, d, color, graphicsContext,
                                                generator.staticagent(i) = 2, generator.agentreservoir(i, 0) = 2, generator.agentreservoir(i, 1), generator.agentreservoir(i, 2))
        Next
    End Sub

    ''' <summary>
    ''' Test code - produces a semi-transparent cube (made up of smaller cubes) to show the target range of an agent on the ZY view
    ''' </summary>
    ''' <param name="agentIndex">The agent to show the target range of.</param>
    Sub drawRange(ByRef graphicsContext As Graphics, ByVal agentIndex As Integer)
        If agentIndex <= 0 Then Return

        Dim xstart As Integer = 0
        Dim xend As Integer = 0
        Dim ystart As Integer = 0
        Dim yend As Integer = 0
        Dim zstart As Integer = 0
        Dim zend As Integer = 0
        Dim color As Color = Color.FromArgb(25, 153, 204, 255)

        If generator.excludeagent(agentIndex, 0) = 2 Then
            xstart = generator.excludeagent(agentIndex, 2)
            xend = generator.excludeagent(agentIndex, 1)
            ystart = generator.excludeagent(agentIndex, 4)
            yend = generator.excludeagent(agentIndex, 3)
            zstart = generator.excludeagent(agentIndex, 6)
            zend = generator.excludeagent(agentIndex, 5)
            color = Color.FromArgb(25, 255, 153, 153)
        Else
            xstart = generator.agentrange(agentIndex, 0, 0)
            xend = generator.agentrange(agentIndex, 0, 1)
            ystart = generator.agentrange(agentIndex, 1, 0)
            yend = generator.agentrange(agentIndex, 1, 1)
            zstart = generator.agentrange(agentIndex, 2, 0)
            zend = generator.agentrange(agentIndex, 2, 1)
        End If
        Me.RenderingEngine.renderRange(color, graphicsContext,
                           xstart, xend, ystart, yend, zstart, zend)
    End Sub

    Sub changePrespective(ByVal newPrespective As Prespective)
        Me.RenderingEngine.Prespective = newPrespective
        XZTopViewToolStripMenuItem.Enabled = True
        ZYSideViewToolStripMenuItem.Enabled = True
        XYSideViewToolStripMenuItem.Enabled = True
        Select Case newPrespective
            Case Prespective.XY
                viewlabel.Text = "Side View (x,y)"
                XYSideViewToolStripMenuItem.Enabled = False
            Case Prespective.XZ
                viewlabel.Text = "Top View (x,z)"
                XZTopViewToolStripMenuItem.Enabled = False
            Case Prespective.ZY
                viewlabel.Text = "Side View (z,y)"
                ZYSideViewToolStripMenuItem.Enabled = False
        End Select
        draw()
    End Sub

    Sub changeDepthOfField(ByVal newDoF As Double)
        Me.RenderingEngine.SizeRatio = newDoF
        draw()
    End Sub

    ''' <summary>
    ''' Sorting is done as a "Z-buffer" for rendering - inefficient but we have no other choice.
    ''' Agents with a smaller index (ie. 1, 2 etc) have a larger z-value
    ''' </summary>
    ''' <param name="prespective">The prespective to determine the axis to be buffered as the projected Z-axis</param>
    Sub sortAgentsZBuffer(ByVal prespective As Prespective)
        For index = 2 To total + 1
            Dim tempz As Integer = generator.agentlocation(index, 2)
            Dim tempx As Integer = generator.agentlocation(index, 0)
            Dim tempy As Integer = generator.agentlocation(index, 1)

            Dim previousposition As Integer = index - 1

            Dim tempProjectedZ = tempz
            Dim tempProjectedComparisonZ = generator.agentlocation(previousposition, 2)
            Select Case prespective
                Case Prespective.XZ
                    tempProjectedZ = tempy
                    tempProjectedComparisonZ = generator.agentlocation(previousposition, 1)
                Case Prespective.ZY
                    tempProjectedZ = tempx
                    tempProjectedComparisonZ = generator.agentlocation(previousposition, 0)
            End Select

            Do While tempProjectedZ > tempProjectedComparisonZ And previousposition >= 1
                generator.swapAgentIndices(previousposition, previousposition + 1)
                previousposition = previousposition - 1
            Loop
        Next
    End Sub

#Region "Saving/Loading Logic"
    Function saveProjectToString() As String
        ' The Text Outputted to the Save File
        Dim save = ""

        Dim stringBuilder = New System.Text.StringBuilder()
        Dim writer = System.Xml.XmlWriter.Create(stringBuilder)
        writer.WriteStartElement("Cobweb3DConfig", "http://cobweb.ca/schema/cobweb2/config")
        writer.WriteAttributeString("cobweb-version", "1")
        writer.WriteStartElement("Environment")
        writer.WriteStartElement("Width")
        writer.WriteValue(xn)
        writer.WriteEndElement()
        writer.WriteStartElement("Height")
        writer.WriteValue(yn)
        writer.WriteEndElement()
        writer.WriteStartElement("Depth")
        writer.WriteValue(zn)
        writer.WriteEndElement()
        ' TODO: This

        ' World Sizes: <xn>_<yn>_<zn>_<number of agent types>_
        save = xn & "_" & yn & "_" & zn & "_" & agentTypeCount & "_"
        ' Type Names
        For i = 1 To agentTypeCount ' For all agent types
            ' <save>_<type name for type (i)>_  Ex: <save>_<agent name for (i)>_<agent name for (i+1)>_<agent name for (i+2)>_
            save = save & generator.agentname(i) & "_"
        Next
        ' Type Counts
        For i = 1 To agentTypeCount ' For all agent types
            ' <save>_<agent count for type (i)>_
            save = save & generator.agentcount(i) & "_"
        Next
        ' Type Initial Energy
        For i = 1 To agentTypeCount ' For all agent types
            ' <save>_<initial energy for type (i)>_
            save = save & generator.initialenergy(i) & "_"
        Next
        ' Type Step Energy Cost/Gain
        For i = 1 To agentTypeCount ' For all agent types
            save = save & generator.stepenergy(i) & "_"
        Next
        ' Type Bump Energy Cost/Gain
        For i = 1 To agentTypeCount ' For all agent types
            save = save & generator.bumpenergy(i) & "_"
        Next
        ' Type Aging
        For i = 1 To agentTypeCount ' For all agent types
            save = save & generator.aging(i) & "_"
        Next
        ' Type Age Limit
        For i = 1 To agentTypeCount ' For all agent types
            save = save & generator.agelimit(i) & "_"
        Next
        ' Type Asexual Reproduction? Bool
        For i = 1 To agentTypeCount ' For all agent types
            save = save & generator.asr(i) & "_"
        Next
        ' Type Asexual Reproduction Time
        For i = 1 To agentTypeCount ' For all agent types
            save = save & generator.asrtime(i) & "_"
        Next
        ' Type Asexual Reproduction Energy Cost
        For i = 1 To agentTypeCount ' For all agent types
            save = save & generator.asrenergy(i) & "_"
        Next
        ' Type Color
        For i = 1 To agentTypeCount ' For all agent types
            Dim colourconverter As New System.Drawing.ColorConverter
            save = save & colourconverter.ConvertToString(generator.agentcolour(i)) & "_"
        Next
        ' Type Range (absolute)
        For i = 1 To agentTypeCount ' For all agent types
            save = save & generator.agentrangeabsolute(i) & "_"
        Next
        ' Type Agent Range (coords)
        For a = 1 To agentTypeCount
            For b = 0 To 2 '0 = x, 1 = y, 2 = z
                For c = 0 To 1 '0 = min, 1 = max
                    save = save & generator.agentrange(a, b, c) & "_"
                Next
            Next
        Next
        ' Type Action Combinations
        For a = 1 To agentTypeCount
            For b = 1 To agentTypeCount
                For c = 1 To 6
                    For d = 0 To agentTypeCount
                        For ee = 0 To 1
                            save = save & generator.action(a, b, c, d, ee) & "_"
                        Next
                    Next
                Next
            Next
        Next
        '------------------- INDIVIDUALS ---------------------
        ' Individual X Locations
        For i = 1 To total
            save = save & generator.agentlocation(i, 0) & "_"
        Next
        ' Individual Y Locations
        For i = 1 To total
            save = save & generator.agentlocation(i, 1) & "_"
        Next
        ' Individual Z Locations
        For i = 1 To total
            save = save & generator.agentlocation(i, 2) & "_"
        Next
        ' Individual 
        For i = 1 To total
            save = save & generator.agentlocation(i, 4) & "_"
        Next
        ' Individual 
        For i = 1 To total
            save = save & generator.agentlocation(i, 3) & "_"
        Next
        '------------------- TYPES ---------------------
        For i = 1 To agentTypeCount
            save = save & generator.staticagentid(i) & "_"
        Next
        '------------------- INDIVIDUALS --------------------
        'saves reservoirs (issue saving reservoirs that are partially or completely filled)
        For i = 1 To total
            save = save & generator.agentreservoir(i, 0) & "_"
        Next
        'saves the capacity of reservoirs
        For i = 1 To total
            save = save & generator.agentreservoir(i, 1) & "_"
        Next
        'saves the current level in a reservoir
        For i = 1 To total
            save = save & generator.agentreservoir(i, 2) & "_"
        Next
        For i = 1 To agentTypeCount
            save = save & generator.reservoiragentid(i, 0) & "_"
        Next
        For i = 1 To agentTypeCount
            save = save & generator.reservoiragentid(i, 1) & "_"
        Next
        For i = 1 To agentTypeCount
            save = save & generator.reservoiragentid(i, 2) & "_"
        Next

        save = save & "|"
        Return save
    End Function

    Function saveProjectToXmlString() As String
        ' The Text Outputted to the Save File
        Dim save = ""
        Dim xmlWriterSettings = New XmlWriterSettings()
        xmlWriterSettings.Indent = True
        '  xmlWriterSettings.IndentChars = "     " 'note: Default is two spaces
        xmlWriterSettings.NewLineOnAttributes = False
        xmlWriterSettings.OmitXmlDeclaration = True
        Dim stringBuilder = New System.IO.StringWriter()
        Using xW = XmlWriter.Create(stringBuilder, xmlWriterSettings)

            xW.WriteStartElement("Cobweb3DConfig", "http://cobweb.ca/schema/cobweb2/config")
            xW.WriteAttributeString("cobweb3d-version", COBWEB_VERSION)


            xW.WriteStartElement("Environment")
            xW.WriteElementString("Width", xn)
            xW.WriteElementString("Height", yn)
            xW.WriteElementString("Depth", zn)
            xW.WriteEndElement()

            xW.WriteStartElement("AgentParams")
            xW.WriteElementString("AgentTypes", agentTypeCount)

            xW.WriteStartElement("AgentTypeProperties")

            Dim colourConverter As New System.Drawing.ColorConverter
            For i = 1 To agentTypeCount ' For all agent types
                ' <save>_<type name for type (i)>_  Ex: <save>_<agent name for (i)>_<agent name for (i+1)>_<agent name for (i+2)>_
                save = save & generator.agentname(i) & "_"
                xW.WriteStartElement("AgentType")
                xW.WriteAttributeString("TypeIndex", i)
                xW.WriteAttributeString("StaticAgentId", generator.staticagentid(i))
                xW.WriteElementString("AgentName", generator.agentname(i)) ' Type Names
                xW.WriteElementString("AgentCount", generator.agentcount(i)) ' Type Counts
                xW.WriteElementString("InitialEnergy", generator.initialenergy(i)) ' Type Initial Energy
                xW.WriteElementString("StepEnergy", generator.stepenergy(i)) ' Type Step Energy Cost/Gain 
                xW.WriteElementString("BumpEnergy", generator.bumpenergy(i)) ' Type Bump Energy Cost/Gain
                xW.WriteElementString("Aging", generator.aging(i)) ' Type Aging
                xW.WriteElementString("AgeLimit", generator.agelimit(i)) ' Type Age Limit
                xW.WriteElementString("AsexualReproduction", generator.asr(i)) ' Type Asexual Reproduction? Bool
                xW.WriteElementString("AsexualReproductionTime", generator.asrtime(i)) ' Type Asexual Reproduction Time in Ticks
                xW.WriteElementString("AsexualReproductionEnergy", generator.asrenergy(i)) ' Type Asexual Reproduction Energy Cost
                xW.WriteElementString("Color", colourConverter.ConvertToString(generator.agentcolour(i))) ' Type Color

                xW.WriteElementString("AbsoluteRange", generator.agentrangeabsolute(i)) ' Type Range (absolute)

                xW.WriteStartElement("CoordRange") ' Type Agent Range (coords)

                xW.WriteStartElement("X") '0 = x, 1 = y, 2 = z
                xW.WriteAttributeString("min", generator.agentrange(i, 0, 0)) '0 = min, 1 = max
                xW.WriteAttributeString("max", generator.agentrange(i, 0, 1))
                xW.WriteEndElement()

                xW.WriteStartElement("Y")
                xW.WriteAttributeString("min", generator.agentrange(i, 1, 0))
                xW.WriteAttributeString("max", generator.agentrange(i, 1, 1))
                xW.WriteEndElement()

                xW.WriteStartElement("Z")
                xW.WriteAttributeString("min", generator.agentrange(i, 2, 0))
                xW.WriteAttributeString("max", generator.agentrange(i, 2, 1))
                xW.WriteEndElement()

                xW.WriteEndElement()

                xW.WriteStartElement("ActionCombinations") ' Type Action Combinations
                For i2 = 1 To agentTypeCount
                    For i3 = 1 To 6
                        For i4 = 0 To agentTypeCount
                            For ee = 0 To 1 ' What in tarnation did ee stand for... ??
                                xW.WriteStartElement("Action")
                                xW.WriteAttributeString("Agent2", i2)
                                xW.WriteAttributeString("Agent3", i3)
                                xW.WriteAttributeString("Agent4", i4)
                                xW.WriteAttributeString("AgentEE", ee)
                                xW.WriteString(generator.action(i, i2, i3, i4, ee))
                                xW.WriteEndElement()
                                ' save = save & generator.action(i, i2, i3, i4, ee) & "_"
                            Next
                        Next
                    Next
                Next
                xW.WriteEndElement()

                xW.WriteStartElement("ReservoirProperties")
                xW.WriteAttributeString("isReservoir", generator.reservoiragentid(i, 0))
                xW.WriteAttributeString("Capacity", generator.reservoiragentid(i, 1))
                xW.WriteAttributeString("InitialLevel", generator.reservoiragentid(i, 2))
                xW.WriteEndElement()

                '------------------- INDIVIDUALS ---------------------
                xW.WriteStartElement("Agents")
                For a = 1 To total
                    xW.WriteStartElement("Agent")
                    xW.WriteAttributeString("Index", a)

                    xW.WriteStartElement("Location")
                    xW.WriteAttributeString("X", generator.agentlocation(a, 0))
                    xW.WriteAttributeString("Y", generator.agentlocation(a, 1))
                    xW.WriteAttributeString("Z", generator.agentlocation(a, 2))
                    xW.WriteEndElement()

                    xW.WriteStartElement("ExtraProperties")
                    xW.WriteAttributeString("DirectionIndex", generator.agentlocation(a, 3))
                    xW.WriteAttributeString("ColorIndex", generator.agentlocation(a, 4))
                    xW.WriteEndElement()

                    xW.WriteStartElement("ReservoirProperties")
                    xW.WriteAttributeString("isReservoir", generator.agentreservoir(a, 0))
                    xW.WriteAttributeString("Capacity", generator.agentreservoir(a, 1))
                    xW.WriteAttributeString("CurrentLevel", generator.agentreservoir(a, 2))
                    xW.WriteEndElement()

                    xW.WriteEndElement()
                Next
                xW.WriteEndElement()

                xW.WriteEndElement()
            Next

            xW.WriteEndElement()
            xW.WriteEndElement()
        End Using

        Return stringBuilder.ToString()
    End Function

    Sub loadProjectFromXmlStream(ByRef stream As System.IO.Stream)
        ' TODO: Figure this out!!!!!!!! Weird bugs...
        mRenderingEngine.onWorldSizeChanged(0, 0, 0)

        generator.Close()
        generator.Show()
        Using xR = XmlReader.Create(stream)
            While xR.Read()
                ' Check for start elements
                If xR.IsStartElement() Then

                    ' See if perls element or article element.
                    If xR.Name = "Environment" Then
                        xR.ReadToDescendant("Width")
                        xn = Integer.Parse(xR.ReadInnerXml())
                        xR.ReadToFollowing("Height")
                        yn = Integer.Parse(xR.ReadInnerXml())
                        xR.ReadToFollowing("Depth")
                        zn = Integer.Parse(xR.ReadInnerXml())

                    ElseIf xR.Name = "AgentParams" Then
                        xR.ReadToDescendant("AgentTypes")
                        agentTypeCount = Integer.Parse(xR.ReadInnerXml())

                        mRenderingEngine.onWorldSizeChanged(xn, yn, zn)

                        generator.Close()
                        generator.Show()


                        SizeToolStripMenuItem.Enabled = True
                        AIToolStripMenuItem.Enabled = True
                        collisionToolStripMenuItem.Enabled = True

                        AddAgentsToolStripMenuItem.Enabled = True
                        CatalysisToolStripMenuItem.Enabled = True
                        AbioticFactorsToolStripMenuItem.Enabled = True
                    ElseIf xR.Name = "AgentTypeProperties" Then
                        Dim colourConverter As New System.Drawing.ColorConverter
                        While (xR.Read())
                            If (xR.NodeType.Equals(XmlNodeType.EndElement)) Then
                                If (xR.Name.Equals("AgentTypeProperties")) Then
                                    Exit While
                                End If
                            ElseIf (xR.IsStartElement()) Then
                                If (xR.Name.Equals("AgentType")) Then

                                    Dim i = Integer.Parse(xR.GetAttribute("TypeIndex"))
                                    generator.staticagentid(i) = Integer.Parse(xR.GetAttribute("StaticAgentId"))

                                    xR.ReadToFollowing("AgentName")
                                    generator.agentname(i) = xR.ReadInnerXml()
                                    Console.WriteLine("agentname: " & generator.agentname(i))
                                    xR.ReadToFollowing("AgentCount")
                                    generator.agentcount(i) = Integer.Parse(xR.ReadInnerXml())
                                    xR.ReadToFollowing("InitialEnergy")
                                    generator.initialenergy(i) = Integer.Parse(xR.ReadInnerXml())
                                    xR.ReadToFollowing("StepEnergy")
                                    generator.stepenergy(i) = Integer.Parse(xR.ReadInnerXml())
                                    xR.ReadToFollowing("BumpEnergy")
                                    generator.bumpenergy(i) = Integer.Parse(xR.ReadInnerXml())
                                    xR.ReadToFollowing("Aging")
                                    generator.aging(i) = Boolean.Parse(xR.ReadInnerXml())
                                    xR.ReadToFollowing("AgeLimit")
                                    generator.agelimit(i) = Integer.Parse(xR.ReadInnerXml())
                                    xR.ReadToFollowing("AsexualReproduction")
                                    generator.asr(i) = Boolean.Parse(xR.ReadInnerXml())
                                    xR.ReadToFollowing("AsexualReproductionTime")
                                    generator.asrtime(i) = Integer.Parse(xR.ReadInnerXml())
                                    xR.ReadToFollowing("AsexualReproductionEnergy")
                                    generator.asrenergy(i) = Integer.Parse(xR.ReadInnerXml())
                                    xR.ReadToFollowing("Color")
                                    generator.agentcolour(i) = colourConverter.ConvertFrom(xR.ReadInnerXml())

                                    xR.ReadToFollowing("AbsoluteRange")
                                    generator.agentrangeabsolute(i) = Boolean.Parse(xR.ReadInnerXml())

                                    xR.ReadToFollowing("CoordRange")
                                    xR.ReadToFollowing("X")
                                    generator.agentrange(i, 0, 0) = Integer.Parse(xR.GetAttribute("min"))
                                    generator.agentrange(i, 0, 1) = Integer.Parse(xR.GetAttribute("max"))
                                    xR.ReadToFollowing("Y")
                                    generator.agentrange(i, 1, 0) = Integer.Parse(xR.GetAttribute("min"))
                                    generator.agentrange(i, 1, 1) = Integer.Parse(xR.GetAttribute("max"))
                                    xR.ReadToFollowing("Z")
                                    generator.agentrange(i, 2, 0) = Integer.Parse(xR.GetAttribute("min"))
                                    generator.agentrange(i, 2, 1) = Integer.Parse(xR.GetAttribute("max"))


                                    If (xR.ReadToFollowing("ActionCombinations")) Then
                                        While (xR.Read())
                                            If (xR.NodeType.Equals(XmlNodeType.EndElement)) Then
                                                If (xR.Name.Equals("ActionCombinations")) Then
                                                    Exit While
                                                End If
                                            End If
                                            If (xR.IsStartElement()) Then
                                                If (xR.Name.Equals("Action")) Then
                                                    generator.action(i, xR.GetAttribute("Agent2"), xR.GetAttribute("Agent3"), xR.GetAttribute("Agent4"), xR.GetAttribute("AgentEE")) = xR.ReadInnerXml()
                                                End If
                                            End If
                                        End While
                                    End If

                                    If (xR.ReadToFollowing("ReservoirProperties")) Then
                                        generator.reservoiragentid(i, 0) = xR.GetAttribute("isReservoir")
                                        generator.reservoiragentid(i, 1) = xR.GetAttribute("Capacity")
                                        generator.reservoiragentid(i, 2) = xR.GetAttribute("InitialLevel")
                                    End If

                                    If (xR.ReadToFollowing("Agents")) Then
                                        Dim a = 1
                                        While (xR.Read())
                                            If (xR.NodeType.Equals(XmlNodeType.EndElement)) Then
                                                If (xR.Name.Equals("Agents")) Then
                                                    Exit While
                                                End If
                                            End If
                                            If (xR.IsStartElement()) Then
                                                If (xR.Name.Equals("Agent")) Then
                                                    If (xR.ReadToDescendant("Location")) Then
                                                        generator.agentlocation(a, 0) = xR.GetAttribute("X")
                                                        generator.agentlocation(a, 1) = xR.GetAttribute("Y")
                                                        generator.agentlocation(a, 2) = xR.GetAttribute("Z")
                                                        If (xR.ReadToFollowing("ExtraProperties")) Then
                                                            generator.agentlocation(a, 3) = xR.GetAttribute("DirectionIndex")
                                                            generator.agentlocation(a, 4) = xR.GetAttribute("ColorIndex")
                                                        End If
                                                        If (xR.ReadToFollowing("ReservoirProperties")) Then
                                                            generator.agentreservoir(a, 0) = xR.GetAttribute("isReservoir")
                                                            generator.agentreservoir(a, 1) = xR.GetAttribute("Capacity")
                                                            generator.agentreservoir(a, 2) = xR.GetAttribute("CurrentLevel")
                                                        End If

                                                        ' ----- No idea what this does and why/how we generate it, just re-used this code snippet from old loading method. -----
                                                        Dim rangexupper As Integer = generator.agentrange(i, 0, 1)
                                                        Dim rangexlower As Integer = generator.agentrange(i, 0, 0)
                                                        Dim rangeyupper As Integer = generator.agentrange(i, 1, 1)
                                                        Dim rangeylower As Integer = generator.agentrange(i, 1, 0)
                                                        Dim rangezupper As Integer = generator.agentrange(i, 2, 1)
                                                        Dim rangezlower As Integer = generator.agentrange(i, 2, 0)
                                                        Dim dx = CInt(Math.Floor((rangexupper - rangexlower + 1) * Rnd())) + rangexlower
                                                        Dim dy = CInt(Math.Floor((rangeyupper - rangeylower + 1) * Rnd())) + rangeylower
                                                        Dim dz = CInt(Math.Floor((rangezupper - rangezlower + 1) * Rnd())) + rangezlower
                                                        generator.agentlocation(a, 5) = dx
                                                        generator.agentlocation(a, 6) = dy
                                                        generator.agentlocation(a, 7) = dz
                                                        ' ---------------------------------------------------------------------------------------------------------

                                                        generator.agentlocation(a, 8) = generator.initialenergy(i) ' Reset the agent's initial energy
                                                        generator.agentlocation(a, 9) = 0 ' Reset the agent's age to 0
                                                        generator.agentlocation(a, 10) = 0 ' Reset the asex reproduction timer to 0

                                                        a += 1
                                                    End If
                                                End If
                                            End If
                                        End While
                                    End If
                                End If
                            End If
                        End While
                    End If
                End If
            End While
        End Using
        For i = 1 To agentTypeCount
            total = total + generator.agentcount(i)
        Next

        For i = 1 To agentTypeCount
            For j = 1 To agentTypeCount
                generator.interactionprobability(i, j) = 100
            Next
        Next

        tick = 0
        Timerxy.Stop()
        draw()



        staticagentcheck()
    End Sub

    Sub loadProjectFromString(ByRef saveText As String)
        Dim import(400000) As String
        Dim n As Integer

        For i = 1 To 400000
            n = 0
            Do Until saveText.Substring(n, 1) = "_"
                n = n + 1
                import(i) = saveText.Substring(0, n)
            Loop
            If saveText.Substring(n + 1, 1) = "|" Then
                Exit For
            End If
            saveText = saveText.Substring(1 + n)
        Next

        xn = import(1)
        yn = import(2)
        zn = import(3)
        agentTypeCount = import(4)

        mRenderingEngine.onWorldSizeChanged(xn, yn, zn)

        generator.Close()
        generator.Show()


        SizeToolStripMenuItem.Enabled = True
        AIToolStripMenuItem.Enabled = True
        collisionToolStripMenuItem.Enabled = True

        AddAgentsToolStripMenuItem.Enabled = True
        CatalysisToolStripMenuItem.Enabled = True
        AbioticFactorsToolStripMenuItem.Enabled = True


        '....

        Dim lastimport As Integer

        For i = 1 To agentTypeCount
            lastimport = 4 + i
            generator.agentname(i) = import(lastimport)
        Next

        Dim tot As Integer

        For i = 1 To agentTypeCount
            lastimport = lastimport + 1
            generator.agentcount(i) = import(lastimport)
            tot += import(lastimport)
        Next


        For i = 1 To agentTypeCount
            lastimport = lastimport + 1
            generator.initialenergy(i) = import(lastimport)
        Next


        For i = 1 To agentTypeCount
            lastimport = lastimport + 1
            generator.stepenergy(i) = import(lastimport)
        Next


        For i = 1 To agentTypeCount
            lastimport = lastimport + 1
            generator.bumpenergy(i) = import(lastimport)
        Next

        For i = 1 To agentTypeCount
            lastimport = lastimport + 1
            generator.aging(i) = import(lastimport)
        Next


        For i = 1 To agentTypeCount
            lastimport = lastimport + 1
            generator.agelimit(i) = import(lastimport)
        Next

        For i = 1 To agentTypeCount
            lastimport = lastimport + 1
            generator.asr(i) = import(lastimport)
        Next


        For i = 1 To agentTypeCount
            lastimport = lastimport + 1
            generator.asrtime(i) = import(lastimport)
        Next

        For i = 1 To agentTypeCount
            lastimport = lastimport + 1
            generator.asrenergy(i) = import(lastimport)
        Next

        For i = 1 To agentTypeCount
            lastimport = lastimport + 1
            Dim colourconverter As New System.Drawing.ColorConverter
            generator.agentcolour(i) = colourconverter.ConvertFromString(import(lastimport))
        Next


        For i = 1 To agentTypeCount
            lastimport = lastimport + 1
            generator.agentrangeabsolute(i) = import(lastimport)
        Next



        For a = 1 To agentTypeCount
            For b = 0 To 2
                For c = 0 To 1
                    lastimport = lastimport + 1
                    generator.agentrange(a, b, c) = import(lastimport)
                Next
            Next
        Next


        For a = 1 To agentTypeCount
            For b = 1 To agentTypeCount
                For c = 1 To 6
                    For d = 0 To agentTypeCount
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

        For i = 1 To agentTypeCount
            lastimport += 1
            generator.staticagentid(i) = import(lastimport)
        Next

        For i = 1 To total
            lastimport += 1
            generator.agentreservoir(i, 0) = import(lastimport)
        Next

        For i = 1 To total
            lastimport += 1
            generator.agentreservoir(i, 1) = import(lastimport)
        Next

        For i = 1 To total
            lastimport += 1
            generator.agentreservoir(i, 2) = import(lastimport)
        Next

        For i = 1 To agentTypeCount
            lastimport += 1
            generator.reservoiragentid(i, 0) = import(lastimport)
        Next

        For i = 1 To agentTypeCount
            lastimport += 1
            generator.reservoiragentid(i, 1) = import(lastimport)
        Next

        For i = 1 To agentTypeCount
            lastimport += 1
            generator.reservoiragentid(i, 2) = import(lastimport)
        Next

        ''........applying the setting..............
        Randomize()
        total = 0

        Dim number As Integer
        For a = 1 To agentTypeCount
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

        ''...........................................................................................................

        For i = 1 To agentTypeCount
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


        For i = 1 To agentTypeCount
            For j = 1 To agentTypeCount
                generator.interactionprobability(i, j) = 100
            Next
        Next



        tick = 0
        Timerxy.Stop()
        draw()

        staticagentcheck()
    End Sub
#End Region

#Region "User Interface Event Handlers"
    ' Adam: Update loop
    Private Sub Timerxy_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timerxy.Tick
        If tick = 0 Then
            If generator.multipleiterations(0) > 0 Then
                tslblStatus.Visible = True
                tslblStatus.Text = "Iterations Left: " & generator.multipleiterations(0)
            End If
        End If

        updateSimulation()

        If tick = tslblStopTicks.Text Then
            If generator.multipleiterations(0) = 0 Then

                tslblStatus.Visible = False
                Timerxy.Stop()
            Else
                generator.multipleiterations(0) -= 1
                tick = 0
                tslblStatus.Visible = True
                tslblStatus.Text = "Iterations Left: " & generator.multipleiterations(0)

                resetSimulation()
            End If
        End If
    End Sub

#Region "Change View"
    Private Sub TopViewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XZTopViewToolStripMenuItem.Click
        changePrespective(Prespective.XZ)
    End Sub

    Private Sub SideViewToolStripMenuzItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZYSideViewToolStripMenuItem.Click
        changePrespective(Prespective.ZY)
    End Sub

    Private Sub SideViewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XYSideViewToolStripMenuItem.Click
        changePrespective(Prespective.XY)
    End Sub
#End Region

    Private Sub QuitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ToolStripStatusLabel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslblStopLabel.Click
        Dim input As String
        input = InputBox("Enter the time limit:")
        If IsNumeric(input) = False Then
            MessageBox.Show("Please enter a numerical value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        tslblStopTicks.Text = CInt(input)
    End Sub

    Private Sub ToolStripStatusLabel4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslblSpeedLabel.Click
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
        tsprgSpeed.Value = speed
    End Sub

    Private Sub StopToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StopToolStripMenuItem.Click
        Timerxy.Stop()
        If (mExcelLogger IsNot Nothing) Then
            If MessageBox.Show("Would you like to stop the excel file encryption?", "Excel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                    = Windows.Forms.DialogResult.Yes Then
                If (mExcelLogger IsNot Nothing) Then mExcelLogger.closeExcelWorkbook()
            End If
        End If
    End Sub

    Private Sub StartToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartToolStripMenuItem.Click
        If (xn = 0 Or yn = 0 Or zn = 0) Then Return
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

    Private Sub FullScreenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FullScreenToolStripMenuItem.Click
        ToggleFullscreen()
    End Sub

    Private Sub ToggleFullscreen()
        If Me.FormBorderStyle = FormBorderStyle.None Then
            FullscreenOff()
        Else
            FullscreenOn()
        End If
    End Sub

    Private Sub FullscreenOff()
        Me.FormBorderStyle = FormBorderStyle.Sizable
        FullScreenToolStripMenuItem.Text = "Full Screen"
    End Sub

    Private Sub FullscreenOn()
        Me.FormBorderStyle = FormBorderStyle.None
        Me.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Maximized
        FullScreenToolStripMenuItem.Text = "Exit Full Screen"
    End Sub

    Sub Form1_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = ChrW(27) And Me.FormBorderStyle = FormBorderStyle.None Then
            FullscreenOff()
        End If
    End Sub

    Private Sub AdjustFocalPointToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdjustFocalPointToolStripMenuItem.Click
        Ratio.Show()
    End Sub

    'outputs population and energy values to a spreadsheet
    Private Sub LogDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogDataToolStripMenuItem.Click
        Try
            SaveFileDialogLogData.ShowDialog()
        Catch ex As Exception
            MessageBox.Show("Please ensure that Excel creates 2 or more worksheets when a new spreadsheet is created." & vbCrLf & vbCrLf & ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FoodWebToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles collisionToolStripMenuItem.Click
        Form5.Show()
    End Sub

    Private Sub DataSheetToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataSheetToolStripMenuItem.Click
        Form4.Show()
    End Sub

    Private Sub SaveFileDialogLogData_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialogLogData.FileOk
        If mExcelLogger Is Nothing Then mExcelLogger = New ExcelLogger()
        mExcelLogger.openExcelWorkbook(SaveFileDialogLogData.FileName)
    End Sub


#Region "Project Saving/Loading"
    'saves agent location
    Private Sub SaveProjectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveProjectToolStripMenuItem.Click
        SaveFilepro.ShowDialog()
    End Sub

    Private Sub SaveFilepro_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SaveFilepro.FileOk
        Using objwriter = New System.IO.StreamWriter(SaveFilepro.FileName)
            Try
                objwriter.Write(saveProjectToString())
            Catch ex As Exception
                MessageBox.Show("Failed to save the project, please send the developer a screenshot of the error." & vbCrLf & vbCrLf & ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub OpenProjectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenProjectToolStripMenuItem.Click
        OpenFilepro.ShowDialog()
    End Sub

    Private Sub OpenFilepro_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFilepro.FileOk
        'Try TODO: FIGURE OUT XML SAVING/LOADING
        '    ' Encode the XML string in a UTF-8 byte array
        '    ' Dim encodedString = Encoding.UTF8.GetBytes(objreader.ReadToEnd())
        '    Dim x = New XmlDocument()
        '    x.Load(OpenFilepro.FileName)
        '    Dim xmlStream = New System.IO.MemoryStream()
        '    x.Save(xmlStream)

        '    xmlStream.Flush() '//Adjust this If you want read your data 
        '    xmlStream.Position = 0
        '    loadProjectFromXmlStream(xmlStream)
        '    xmlStream.Dispose()
        '    'loadProjectFromStream(OpenFilepro.FileName)
        '    'loadProjectFromStream(OpenFilepro.OpenFile())
        '    '  loadProjectFromString(objreader.ReadToEnd)
        'Catch ex As Exception
        '    MessageBox.Show("Failed to load the project, it may be corrupt." & vbCrLf & vbCrLf & ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Try
        '        Using objreader = New System.IO.StreamReader(OpenFilepro.FileName)
        '            loadProjectFromString(objreader.ReadToEnd)
        '            '  loadProjectFromString(objreader.ReadToEnd)
        '        End Using
        '    Catch ex2 As Exception
        '        MessageBox.Show("Failed to load the project, it may be corrupt." & vbCrLf & vbCrLf & ex2.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    End Try
        'End Try
        Try
            Using objreader = New System.IO.StreamReader(OpenFilepro.FileName)
                loadProjectFromString(objreader.ReadToEnd)
                '  loadProjectFromString(objreader.ReadToEnd)
            End Using
        Catch ex2 As Exception
            MessageBox.Show("Failed to load the project, it may be corrupt." & vbCrLf & vbCrLf & ex2.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

    Private Sub TickToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TickButtonToolStripMenuItem.Click
        updateSimulation()
    End Sub

    Private Sub CreditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreditToolStripMenuItem.Click
        MsgBox("Instructor: Dr. Brad Bass" & vbCrLf & "Programmer: Mohammad Zavvarian" & vbCrLf & "Additional programming by: Neilket Patel" & vbCrLf & "Maintained by: Adam Adli (adam.adli@mail.utoronto.ca)")
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
        'frmAbiotic.Show()
    End Sub

    Private Sub InSpecificPositionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InSpecificPositionsToolStripMenuItem.Click
        frmCrossSection.Show()
    End Sub

    Private Sub InRangeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InRangeToolStripMenuItem.Click
        frmAdd.Show()
    End Sub

    Private Sub DataOnExchangesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataOnExchangesToolStripMenuItem.Click
        exchangedata.Show()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        MessageBox.Show("Cobweb 3D" & vbCrLf & "Version: " & COBWEB_VERSION & vbCrLf & "Release Date: September 13, 2017", "About", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub AbioticFactorsEnergyChangeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AbioticFactorsEnergyChangeToolStripMenuItem.Click
        frmAbiotic.Show()
    End Sub

    Private Sub AbioticFactorsNonrandomMovementToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AbioticFactorsNonrandomMovementToolStripMenuItem.Click
        frmAbioticMovement.Show()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initializeSimulation()
        goal(0) = 9
        goal(1) = 9
        goal(2) = 4
    End Sub

    Private Sub EconomicZonesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EconomicZonesToolStripMenuItem.Click
        Form11.Show()
    End Sub

    Private Sub GeneticsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GeneticsToolStripMenuItem.Click
        Genetics.Show()
    End Sub

    Private Sub AutomaticRunsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AutomaticRunsToolStripMenuItem.Click
        automaticiterations.Show()
    End Sub

    Private Sub ResetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetToolStripMenuItem.Click
        Timerxy.Stop()
        resetSimulation()
    End Sub
#End Region
End Class