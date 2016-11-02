# cobweb3d
3D simulation in VB
0:x
1:y
2:z
3:direction
4:agent
5:dx
6:dy
7:dz
8:energy
9:age
10: time from the previous asexual reproduction 

If d = 1 Then
                Call Form1.creator(x, y, z, "down", generator.agentcolour(ag))
            ElseIf d = 2 Then
                Call Form1.creator(x, y, z, "up", generator.agentcolour(ag))
            ElseIf d = 3 Then
                Call Form1.creator(x, y, z, "left", generator.agentcolour(ag))
            ElseIf d = 4 Then
                Call Form1.creator(x, y, z, "right", generator.agentcolour(ag))
            ElseIf d = 5 Then
                Call Form1.creator(x, y, z, "front", generator.agentcolour(ag))
            ElseIf d = 6 Then
                Call Form1.creator(x, y, z, "back", generator.agentcolour(ag))
            End If

timer sort added a one


1= produce
2=consume
3= deminish
4= 1+2
5= 2+3
6= 1+3
7= 1+2+3

catalyst proximity
1 - x distance
2- y distance
3 - z distance


agentstart
1 = x upper bound
2 - x lower bound
3 - y upper bound
4 - y lower bound
5 - z upper bound
6 - z lower bound

local energy changes
agents, number of different regions (limit is 1000), range, 
1 = x upper bound
2 - x lower bound
3 - y upper bound
4 - y lower bound
5 - z upper bound
6 - z lower bound
7 - energy change per tick
0 - whether or not a local energy is specified for the agent

localized agent production
1 - x distance
2 - y distance
3 - z distance

agentreservoir
1 - capacity
2 - actual level
0 - whether or not there is a reservoir for that agent

How to set up interactions to use the reservoir feature:
Agent X interacts with Agent Y and diminishes
Agent X is the agent that is supposed to disappear
Agent Y is the static agent with the reservoir

staticagentid - the types of agents that are static
2 - the agent is static
0 - the agent is not static 

reservoiragentid
2 - reservoir
0 - no reservoir
(1 - agent type, 2 - capacity)

reservoiragentreleased
agent type (static agent type), agent type released
1 - number of agents released per tick
2 - reservoir change per agent released
3 - x distance
4 - y distance
5 - z distance
6 - first agent in interaction
7 - second agent in interaction

