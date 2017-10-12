Public Class frmCrossSection
    Private Const EMPTY_LOCATION As Integer = -9901

    Public proposedlocation(Form1.xn, Form1.yn, Form1.zn) As Integer

    Public currentZ As Integer
    Public selectedDirection As Integer
    Public selectedAgentType As Integer

    Private newbutton(Form1.xn * Form1.yn) As CrossSectionButton

    Private Sub frmCrossSection_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For xx = 1 To Form1.xn
            For yy = 1 To Form1.yn
                For zz = 0 To Form1.zn
                    proposedlocation(xx, yy, zz) = EMPTY_LOCATION
                Next
            Next
        Next

        For ii = 1 To Form1.agentTypeCount
            ComboBox1.Items.Add(generator.agentname(ii))
        Next

        For ii = 1 To Form1.zn
            ComboBox2.Items.Add(ii)
        Next

        Dim i As Integer = 0
        Dim xlocation As Integer = 280
        Dim ylocation As Integer = 75

        For yd = 1 To Form1.yn
            For xd = 1 To Form1.xn
                newbutton(i) = New CrossSectionButton(xd, yd)
                newbutton(i).Height = 50
                newbutton(i).Width = 50
                newbutton(i).Location = New Point(xlocation, ylocation)
                AddHandler newbutton(i).Click, AddressOf buttonclick
                Me.Controls.Add(newbutton(i))
                i += 1
                xlocation += 50
            Next
            xlocation = 280
            ylocation += 50
        Next


        ComboBox1.SelectedIndex = 0
        ComboBox2.SelectedIndex = 0
        currentZ = 1

        Call renderCrossSection()
    End Sub

    Private Sub clearProposedLocations()
        For xx = 1 To Form1.xn
            For yy = 1 To Form1.yn
                For zz = 1 To Form1.zn
                    proposedlocation(xx, yy, zz) = EMPTY_LOCATION
                Next
            Next
        Next
        refreshCrossSectionButtons()
    End Sub

    Private Sub refreshCrossSectionButtons()
        Try
            For i = 0 To Form1.xn * Form1.yn - 1
                If generator.occupied(newbutton(i).WorldX, newbutton(i).WorldY, currentZ) = True Then
                    newbutton(i).BackColor = Color.Red
                Else
                    If proposedlocation(newbutton(i).WorldX, newbutton(i).WorldY, currentZ) = EMPTY_LOCATION Then
                        newbutton(i).BackColor = Color.Transparent
                    ElseIf proposedlocation(newbutton(i).WorldX, newbutton(i).WorldY, currentZ) = selectedAgentType Then
                        newbutton(i).BackColor = Color.LightSkyBlue
                    Else
                        newbutton(i).BackColor = Color.Gray
                    End If
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        currentZ = ComboBox2.SelectedIndex + 1
        refreshCrossSectionButtons()
        renderCrossSection()
    End Sub

    Private Sub buttonclicked(ByVal sender As CrossSectionButton, ByVal x As Integer, ByVal y As Integer)
        If generator.occupied(x, y, currentZ) = True Then
            MessageBox.Show("This location is already occupied.", "Invalid Location", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            If proposedlocation(x, y, currentZ) = EMPTY_LOCATION Then
                sender.BackColor = Color.LightSkyBlue
                proposedlocation(x, y, currentZ) = selectedAgentType + 1
                renderCrossSection()
            ElseIf proposedlocation(x, y, currentZ) = selectedAgentType + 1 Then
                sender.BackColor = Color.Transparent
                proposedlocation(x, y, currentZ) = EMPTY_LOCATION
                renderCrossSection()
            End If
        End If
    End Sub

    Private Sub buttonclick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If (sender.GetType.Equals(GetType(CrossSectionButton))) Then
            buttonclicked(sender, sender.WorldX, sender.WorldY)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call produce()
        ' Me.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        selectedAgentType = ComboBox1.SelectedIndex + 1
        refreshCrossSectionButtons()
    End Sub

    'adds new agents 
    Sub produce()
        For xx = 1 To Form1.xn
            For yy = 1 To Form1.yn
                For zz = 1 To Form1.zn
                    If proposedlocation(xx, yy, zz) <> EMPTY_LOCATION Then
                        If generator.occupied(xx, yy, zz) = False Then
                            Form1.total = Form1.total + 1
                            Dim ddx As Integer = CInt(Math.Floor((Form1.xn) * Rnd())) + 1
                            Dim ddy As Integer = CInt(Math.Floor((Form1.yn) * Rnd())) + 1
                            Dim ddz As Integer = CInt(Math.Floor((Form1.zn) * Rnd())) + 1
                            generator.agentlocation(Form1.total, 0) = xx
                            generator.agentlocation(Form1.total, 1) = yy
                            generator.agentlocation(Form1.total, 2) = zz
                            If selectedDirection = 0 Then
                                generator.agentlocation(Form1.total, 3) = CInt(Math.Floor((6) * Rnd())) + 1
                            Else
                                generator.agentlocation(Form1.total, 3) = selectedDirection
                            End If
                            generator.agentlocation(Form1.total, 4) = proposedlocation(xx, yy, zz)
                            generator.agentlocation(Form1.total, 5) = ddx
                            generator.agentlocation(Form1.total, 6) = ddy
                            generator.agentlocation(Form1.total, 7) = ddz
                            generator.agentlocation(Form1.total, 8) = generator.initialenergy(proposedlocation(xx, yy, zz))
                            generator.agentlocation(Form1.total, 9) = 0
                            generator.agentlocation(Form1.total, 10) = 0
                            generator.occupied(xx, yy, zz) = True
                            generator.agentcount(proposedlocation(xx, yy, zz)) = 0
                            For f = 1 To Form1.total
                                If generator.agentlocation(f, 4) = proposedlocation(xx, yy, zz) Then
                                    generator.agentcount(proposedlocation(xx, yy, zz)) += 1
                                End If
                            Next
                        End If
                    End If
                Next
            Next
        Next

        generator.agentchange = True
        Form1.draw()

        clearProposedLocations()
        renderCrossSection()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        frmDirection.Show()
    End Sub

    Private RenderingEngine As RenderingEngine

    Sub renderCrossSection()
        If (RenderingEngine Is Nothing) Then
            RenderingEngine = New RenderingEngine(Form1.xn, Form1.yn, Form1.zn)
            RenderingEngine.Prespective = Prespective.XY
        End If

        RenderingEngine.GraphicsContext.Clear(Color.White)
        RenderingEngine.renderGrid(RenderingEngine.GraphicsContext, 1)

        For ii = 1 To Form1.total
            Dim xx As Integer = generator.agentlocation(ii, 0)
            Dim yy As Integer = generator.agentlocation(ii, 1)
            Dim zz As Integer = generator.agentlocation(ii, 2)
            Dim dd As Integer = generator.agentlocation(ii, 3)
            Dim agag As Integer = generator.agentlocation(ii, 4)
            If zz = ComboBox2.SelectedIndex + 1 Then
                RenderingEngine.renderAgent(xx, yy, 1, dd, generator.agentcolour(agag), RenderingEngine.GraphicsContext,
                                             generator.staticagent(agag) = 2, generator.agentreservoir(agag, 0) = 2, generator.agentreservoir(agag, 1), generator.agentreservoir(agag, 2))
            End If
        Next

        'draws new agents
        For xxi = 1 To Form1.xn
            For yyi = 1 To Form1.yn
                For zzi = 1 To Form1.zn
                    For aai = 1 To Form1.agentTypeCount
                        If proposedlocation(xxi, yyi, zzi) = aai Then
                            If generator.occupied(xxi, yyi, zzi) = False Then
                                If zzi = ComboBox2.SelectedIndex + 1 Then
                                    If selectedDirection = 0 Then
                                        RenderingEngine.renderAgent(xxi, yyi, 1, CInt(Math.Floor((6) * Rnd())) + 1, generator.agentcolour(aai), RenderingEngine.GraphicsContext, generator.staticagentid(aai) = 2)
                                    Else
                                        RenderingEngine.renderAgent(xxi, yyi, 1, selectedDirection, generator.agentcolour(aai), RenderingEngine.GraphicsContext, generator.staticagentid(aai) = 2)
                                    End If
                                End If
                            End If
                        End If
                    Next
                Next
            Next
        Next

        RenderingEngine.renderGridFrontFace(RenderingEngine.GraphicsContext)

        PictureBox1.Image = RenderingEngine.RenderTarget
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        If PictureBox1.Width < 600 And PictureBox1.Height < 600 Then
            PictureBox1.Width = 600
            PictureBox1.Height = 600
            PictureBox1.BringToFront()
        Else
            PictureBox1.Width = 263
            PictureBox1.Height = 263
            PictureBox1.SendToBack()
        End If
    End Sub

    Class CrossSectionButton
        Inherits Button

        Private wX As Integer
        Private wY As Integer
        Public ReadOnly Property WorldX As Integer
            Get
                Return wX
            End Get
        End Property
        Public ReadOnly Property WorldY As Integer
            Get
                Return wY
            End Get
        End Property

        Public Sub New(ByVal worldX As Integer, ByVal worldY As Integer)
            MyBase.New()
            wX = worldX
            wY = worldY
            BackColor = Color.Transparent
            Text = "(" & worldX & ", " & worldY & ")"
        End Sub
    End Class
End Class