Public Class Form4

    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'Dim txt As String

        Dim index As String
        Dim x As String
        Dim y As String
        Dim z As String
        Dim agenttype As String
        Dim energy As String
        Dim age As String



        index = ""
        x = ""
        y = ""
        z = ""
        agenttype = ""
        energy = ""
        age = ""


        index = "Agent number: " & vbCrLf
        x = "X-Value: " & vbCrLf
        y = "Y-Value: " & vbCrLf
        z = "Z-Value: " & vbCrLf
        agenttype = "Agent Type: " & vbCrLf
        energy = "Agent Energy: " & vbCrLf
        age = "Agent Age: " & vbCrLf



        'txt = ""
        'txt = "Agent#:" & "         " & "X" & "         " & "Y" & "         " & "Z" & "         " & "agent" & "         " & "Energy" & vbCrLf




        For i = 1 To Form1.total
            'txt = txt & "     " & i & "              " & generator.agentlocation(i, 0) & "       " & generator.agentlocation(i, 1) & "       " & generator.agentlocation(i, 2) & "       " & generator.agentlocation(i, 4) & "       " & generator.agentlocation(i, 8) & vbCrLf


            index = index & i & vbCrLf
            x = x & generator.agentlocation(i, 0) & vbCrLf
            y = y & generator.agentlocation(i, 1) & vbCrLf
            z = z & generator.agentlocation(i, 2) & vbCrLf
            agenttype = agenttype & generator.agentname(generator.agentlocation(i, 4)) & vbCrLf
            energy = energy & generator.agentlocation(i, 8) & vbCrLf
            age = age & generator.agentlocation(i, 9) & vbCrLf
        Next


        labelagentnumber.Text = index
        labelX.Text = x
        labelY.Text = y
        labelZ.Text = z
        labelAGENTTYPE.Text = agenttype
        labelENERGY.Text = energy
        labelAGE.Text = age


        If (labelagentnumber.Location.Y + labelagentnumber.Size.Height + 12) > Me.Size.Height Then
            VScrollBar1.Maximum = 1 + ((labelagentnumber.Location.Y + labelagentnumber.Size.Height + 12) - Me.Size.Height) / 13
        End If

        Panel1.Location = New Point(Panel1.Location.X, VScrollBar1.Value * -13)
        Panel1.Size = New Size(Panel1.Size.Width, Panel1.Size.Height + (VScrollBar1.Value * 13) + 12)

        'labelagentnumber.Text = txt
    End Sub



End Class