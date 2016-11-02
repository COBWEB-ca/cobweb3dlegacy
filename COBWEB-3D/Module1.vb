Module Module1
    Sub asrproduce(ByVal agent As Integer)
        If Form1.total < generator.maxcell Then
            Form1.total = Form1.total + 1

            Dim x As Integer = CInt(Math.Floor((Form1.xn) * Rnd())) + 1
            Dim y As Integer = CInt(Math.Floor((Form1.yn) * Rnd())) + 1
            Dim z As Integer = CInt(Math.Floor((Form1.zn) * Rnd())) + 1

            Dim dx As Integer
            Dim dy As Integer
            Dim dz As Integer
            'Dim a As Integer = generator.action(ag1, ag2, 2)
            'look here


            Dim rangexupper As Integer = generator.agentrange(agent, 0, 1)
            Dim rangexlower As Integer = generator.agentrange(agent, 0, 0)
            Dim rangeyupper As Integer = generator.agentrange(agent, 1, 1)
            Dim rangeylower As Integer = generator.agentrange(agent, 1, 0)
            Dim rangezupper As Integer = generator.agentrange(agent, 2, 1)
            Dim rangezlower As Integer = generator.agentrange(agent, 2, 0)

            dx = CInt(Math.Floor((rangexupper - rangexlower + 1) * Rnd())) + rangexlower
            dy = CInt(Math.Floor((rangeyupper - rangeylower + 1) * Rnd())) + rangeylower
            dz = CInt(Math.Floor((rangezupper - rangezlower + 1) * Rnd())) + rangezlower



            Dim number As Integer = 0
            Do While generator.occupied(x, y, z) = True And number < generator.maxcell
                number = number + 1
                x = CInt(Math.Floor((Form1.xn) * Rnd())) + 1
                y = CInt(Math.Floor((Form1.yn) * Rnd())) + 1
                z = CInt(Math.Floor((Form1.zn) * Rnd())) + 1
            Loop


            generator.occupied(x, y, z) = True

            Dim d As Integer = CInt(Math.Floor((6) * Rnd())) + 1
            generator.agentlocation(Form1.total, 0) = x
            generator.agentlocation(Form1.total, 1) = y
            generator.agentlocation(Form1.total, 2) = z
            generator.agentlocation(Form1.total, 3) = d
            generator.agentlocation(Form1.total, 4) = agent
            generator.agentlocation(Form1.total, 5) = dx
            generator.agentlocation(Form1.total, 6) = dy
            generator.agentlocation(Form1.total, 7) = dz
            generator.agentlocation(Form1.total, 8) = generator.initialenergy(agent)
            generator.agentlocation(Form1.total, 9) = 0
            generator.agentlocation(Form1.total, 10) = 0
        End If
    End Sub
End Module
