using System.Collections.Generic;
using System;
using System.Linq;
using System.Drawing;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Windows.Forms;

namespace COBWEB_3D
{
	sealed class Module1
	{
		static public void asrproduce(int agent)
		{
			if (Form1.Default.total < generator.Default.maxcell)
			{
				Form1.Default.total++;
				
				int x = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((Form1.Default.xn) * VBMath.Rnd())))) + 1;
				int y = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((Form1.Default.yn) * VBMath.Rnd())))) + 1;
				int z = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((Form1.Default.zn) * VBMath.Rnd())))) + 1;
				
				int dx;
				int dy;
				int dz;
				//Dim a As Integer = generator.action(ag1, ag2, 2)
				//look here
				
				
				int rangexupper = generator.Default.agentrange[agent, 0, 1];
				int rangexlower = generator.Default.agentrange[agent, 0, 0];
				int rangeyupper = generator.Default.agentrange[agent, 1, 1];
				int rangeylower = generator.Default.agentrange[agent, 1, 0];
				int rangezupper = generator.Default.agentrange[agent, 2, 1];
				int rangezlower = generator.Default.agentrange[agent, 2, 0];
				
				dx = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((rangexupper - rangexlower + 1) * VBMath.Rnd())))) + rangexlower;
				dy = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((rangeyupper - rangeylower + 1) * VBMath.Rnd())))) + rangeylower;
				dz = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((rangezupper - rangezlower + 1) * VBMath.Rnd())))) + rangezlower;
				
				
				
				int number = 0;
				while (generator.Default.occupied[x, y, z] == true && number < generator.Default.maxcell)
				{
					number++;
					x = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((Form1.Default.xn) * VBMath.Rnd())))) + 1;
					y = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((Form1.Default.yn) * VBMath.Rnd())))) + 1;
					z = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((Form1.Default.zn) * VBMath.Rnd())))) + 1;
				}
				
				
				generator.Default.occupied[x, y, z] = true;
				
				int d = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((6) * VBMath.Rnd())))) + 1;
				generator.Default.agentlocation[Form1.Default.total, 0] = x;
				generator.Default.agentlocation[Form1.Default.total, 1] = y;
				generator.Default.agentlocation[Form1.Default.total, 2] = z;
				generator.Default.agentlocation[Form1.Default.total, 3] = d;
				generator.Default.agentlocation[Form1.Default.total, 4] = agent;
				generator.Default.agentlocation[Form1.Default.total, 5] = dx;
				generator.Default.agentlocation[Form1.Default.total, 6] = dy;
				generator.Default.agentlocation[Form1.Default.total, 7] = dz;
				generator.Default.agentlocation[Form1.Default.total, 8] = generator.Default.initialenergy[agent];
				generator.Default.agentlocation[Form1.Default.total, 9] = 0;
				generator.Default.agentlocation[Form1.Default.total, 10] = 0;
			}
		}
	}
	
}
