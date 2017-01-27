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
	public partial class generator
	{
		public generator()
		{
			picxy = new Bitmap(Form1.Default.sizexyx, Form1.Default.sizexyy);
			gfxxy = System.Drawing.Graphics.FromImage(picxy);
			picxz = new Bitmap(Form1.Default.sizexzx, Form1.Default.sizexzz);
			gfxxz = System.Drawing.Graphics.FromImage(picxz);
			piczy = new Bitmap(Form1.Default.sizezyz, Form1.Default.sizezyy);
			gfxzy = System.Drawing.Graphics.FromImage(piczy);
			agentcount = new int[Form1.Default.agent + 1];
			agentname = new string[Form1.Default.agent + 1];
			agentrange = new int[Form1.Default.agent + 1, 3, 2];
			agentrangeabsolute = new bool[Form1.Default.agent + 1];
			agentcolour = new System.Drawing.Color[Form1.Default.agent + 1];
			initialenergy = new int[Form1.Default.agent + 1];
			stepenergy = new int[Form1.Default.agent + 1];
			bumpenergy = new int[Form1.Default.agent + 1];
			aging = new bool[Form1.Default.agent + 1];
			agelimit = new int[Form1.Default.agent + 1];
			asr = new bool[Form1.Default.agent + 1];
			asrtime = new int[Form1.Default.agent + 1];
			asrenergy = new int[Form1.Default.agent + 1];
			occupied = new bool[Form1.Default.xn + 1, Form1.Default.yn + 1, Form1.Default.zn + 1];
			action = new int[Form1.Default.agent + 1, Form1.Default.agent + 1, 7];
			maxcell = Form1.Default.xn * Form1.Default.zn * Form1.Default.yn;
			
			InitializeComponent();
			
			//Added to support default instance behavour in C#
			if (defaultInstance == null)
				defaultInstance = this;
		}
		
		#region Default Instance
		
		private static generator defaultInstance;
		
		/// <summary>
		/// Added by the VB.Net to C# Converter to support default instance behavour in C#
		/// </summary>
		public static generator Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new generator();
					defaultInstance.FormClosed += new FormClosedEventHandler(defaultInstance_FormClosed);
				}
				
				return defaultInstance;
			}
		}
		
		static void defaultInstance_FormClosed(object sender, FormClosedEventArgs e)
		{
			defaultInstance = null;
		}
		
		#endregion
		public Bitmap picxy;
		public Graphics gfxxy;
		
		public Bitmap picxz;
		public Graphics gfxxz;
		
		
		public Bitmap piczy;
		public Graphics gfxzy;
		
		public int[] agentcount;
		public string[] agentname;
		public int[,] agentlocation = new int[100001, 11];
		public int[,,] agentrange;
		public bool[] agentrangeabsolute;
		public System.Drawing.Color[] agentcolour;
		
		public int[] initialenergy;
		public int[] stepenergy;
		public int[] bumpenergy;
		public bool[] aging;
		public int[] agelimit;
		public bool[] asr;
		public int[] asrtime;
		public int[] asrenergy;
		
		public bool[,,] occupied;
		public int[,,] action;
		public int maxcell;
		
		public void topgridxy()
		{
			
			System.Drawing.Pen overgrid = new Pen(Brushes.Black, 2);
			
			for (var x = 0; x <= Form1.Default.yn; x++)
			{
				gfxxy.DrawLine(overgrid, 0, Form1.Default.cellxyy * x, Form1.Default.sizexyx, Form1.Default.cellxyy * x);
			}
			
			for (var y = 0; y <= Form1.Default.xn; y++)
			{
				gfxxy.DrawLine(overgrid, Form1.Default.cellxyx * y, 0, Form1.Default.cellxyx * y, Form1.Default.sizexyy);
			}
			
		}
		
		
		public void topgridxz()
		{
			
			System.Drawing.Pen overgrid = new Pen(Brushes.Black, 2);
			
			for (var x = 0; x <= Form1.Default.zn; x++)
			{
				gfxxz.DrawLine(overgrid, 0, Form1.Default.cellxzz * x, Form1.Default.sizexzx, Form1.Default.cellxzz * x);
			}
			
			for (var y = 0; y <= Form1.Default.xn; y++)
			{
				gfxxz.DrawLine(overgrid, Form1.Default.cellxzx * y, 0, Form1.Default.cellxzx * y, Form1.Default.sizexzz);
			}
			
		}
		
		public void topgridzy()
		{
			System.Drawing.Pen overgrid = new Pen(Brushes.Black, 2);
			
			for (var x = 0; x <= Form1.Default.yn; x++)
			{
				gfxzy.DrawLine(overgrid, 0, Form1.Default.cellzyy * x, Form1.Default.sizezyz, Form1.Default.cellzyy * x);
			}
			
			for (var y = 0; y <= Form1.Default.zn; y++)
			{
				gfxzy.DrawLine(overgrid, Form1.Default.cellzyz * y, 0, Form1.Default.cellzyz * y, Form1.Default.sizezyy);
			}
		}
		
		
		public void gridxy()
		{
			float angle = (float) (Math.Atan(Form1.Default.xn / Form1.Default.yn));
			System.Drawing.Pen backgrid = new Pen(Brushes.DarkGray, 1);
			System.Drawing.Pen skeleton = new Pen(Brushes.Gray, 1);
			System.Drawing.Pen light = new Pen(Brushes.Silver, 1);
			
			float diag = System.Convert.ToSingle(0);
			float jump = Form1.Default.cellxyx;
			int a;
			int b;
			
			for (var i = 1; i <= Form1.Default.zn; i++)
			{
				jump =  (float) (jump * (Form1.Default.sizeratio));
				diag = diag + jump;
				a = System.Convert.ToInt32(Math.Sin(angle) * diag);
				b = System.Convert.ToInt32(Math.Cos(angle) * diag);
				gfxxy.DrawLine(backgrid, a, b, Form1.Default.sizexyx - a, b);
				gfxxy.DrawLine(backgrid, a, Form1.Default.sizexyy - b, Form1.Default.sizexyx - a, Form1.Default.sizexyy - b);
				gfxxy.DrawLine(backgrid, a, b, a, Form1.Default.sizexyy - b);
				gfxxy.DrawLine(backgrid, Form1.Default.sizexyx - a, b, Form1.Default.sizexyx - a, Form1.Default.sizexyy - b);
				if (i == Form1.Default.zn)
				{
					float cell;
					float celly;
					cell = System.Convert.ToSingle((Form1.Default.sizexyx - (a * 2)) / Form1.Default.xn);
					celly = System.Convert.ToSingle((Form1.Default.sizexyy - (b * 2)) / Form1.Default.yn);
					for (var j = 1; j <= Form1.Default.xn - 1; j++)
					{
						gfxxy.DrawLine(backgrid, a + (cell * j), b, System.Convert.ToInt32(Form1.Default.cellxyx * j), 0);
						gfxxy.DrawLine(backgrid, a + (cell * j), Form1.Default.sizexyy - b, System.Convert.ToInt32(Form1.Default.cellxyx * j), Form1.Default.sizexyy);
						gfxxy.DrawLine(light, a + (cell * j), b, a + (cell * j), Form1.Default.sizexyy - b);
					}
					
					for (var k = 1; k <= Form1.Default.yn - 1; k++)
					{
						gfxxy.DrawLine(backgrid, a, b + (celly * k), 0, System.Convert.ToInt32(Form1.Default.cellxyy * k));
						gfxxy.DrawLine(backgrid, Form1.Default.sizexyx, System.Convert.ToInt32(Form1.Default.cellxyy * k), Form1.Default.sizexyx - a, b + (celly * k));
						gfxxy.DrawLine(light, a, b + (celly * k), Form1.Default.sizexyx - a, b + (celly * k));
					}
				}
			}
			
			a = System.Convert.ToInt32(Math.Sin(angle) * diag);
			b = System.Convert.ToInt32(Math.Cos(angle) * diag);
			
			gfxxy.DrawLine(skeleton, 0, 0, a, b);
			gfxxy.DrawLine(skeleton, Form1.Default.sizexyx, 0, Form1.Default.sizexyx - a, b);
			gfxxy.DrawLine(skeleton, 0, Form1.Default.sizexyy, a, Form1.Default.sizexyy - b);
			gfxxy.DrawLine(skeleton, Form1.Default.sizexyx, Form1.Default.sizexyy, Form1.Default.sizexyx - a, Form1.Default.sizexyy - b);
		}
		public void gridxz()
		{
			float angle = (float) (Math.Atan(Form1.Default.xn / Form1.Default.zn));
			System.Drawing.Pen backgrid = new Pen(Brushes.DarkGray, 1);
			System.Drawing.Pen skeleton = new Pen(Brushes.Gray, 1);
			System.Drawing.Pen light = new Pen(Brushes.Silver, 1);
			
			float diag = System.Convert.ToSingle(0);
			float jump = Form1.Default.cellxzx;
			int a;
			int b;
			
			for (var i = 1; i <= Form1.Default.yn; i++)
			{
				jump =  (float) (jump * (Form1.Default.sizeratio));
				diag = diag + jump;
				a = System.Convert.ToInt32(Math.Sin(angle) * diag);
				b = System.Convert.ToInt32(Math.Cos(angle) * diag);
				gfxxz.DrawLine(backgrid, a, b, Form1.Default.sizexzx - a, b);
				gfxxz.DrawLine(backgrid, a, Form1.Default.sizexzz - b, Form1.Default.sizexzx - a, Form1.Default.sizexzz - b);
				gfxxz.DrawLine(backgrid, a, b, a, Form1.Default.sizexzz - b);
				gfxxz.DrawLine(backgrid, Form1.Default.sizexzx - a, b, Form1.Default.sizexzx - a, Form1.Default.sizexzz - b);
				if (i == Form1.Default.yn)
				{
					float cell;
					float cellz;
					cell = System.Convert.ToSingle((Form1.Default.sizexzx - (a * 2)) / Form1.Default.xn);
					cellz = System.Convert.ToSingle((Form1.Default.sizexzz - (b * 2)) / Form1.Default.zn);
					for (var j = 1; j <= Form1.Default.xn - 1; j++)
					{
						gfxxz.DrawLine(backgrid, a + (cell * j), b, System.Convert.ToInt32(Form1.Default.cellxzx * j), 0);
						gfxxz.DrawLine(backgrid, a + (cell * j), Form1.Default.sizexzz - b, System.Convert.ToInt32(Form1.Default.cellxzx * j), Form1.Default.sizexzz);
						gfxxz.DrawLine(light, a + (cell * j), b, a + (cell * j), Form1.Default.sizexzz - b);
					}
					
					for (var k = 1; k <= Form1.Default.zn - 1; k++)
					{
						gfxxz.DrawLine(backgrid, a, b + (cellz * k), 0, System.Convert.ToInt32(Form1.Default.cellxzz * k));
						gfxxz.DrawLine(backgrid, Form1.Default.sizexzx, System.Convert.ToInt32(Form1.Default.cellxzz * k), Form1.Default.sizexzx - a, b + (cellz * k));
						gfxxz.DrawLine(light, a, b + (cellz * k), Form1.Default.sizexzx - a, b + (cellz * k));
					}
				}
			}
			
			a = System.Convert.ToInt32(Math.Sin(angle) * diag);
			b = System.Convert.ToInt32(Math.Cos(angle) * diag);
			
			gfxxz.DrawLine(skeleton, 0, 0, a, b);
			gfxxz.DrawLine(skeleton, Form1.Default.sizexzx, 0, Form1.Default.sizexzx - a, b);
			gfxxz.DrawLine(skeleton, 0, Form1.Default.sizexzz, a, Form1.Default.sizexzz - b);
			gfxxz.DrawLine(skeleton, Form1.Default.sizexzx, Form1.Default.sizexzz, Form1.Default.sizexzx - a, Form1.Default.sizexzz - b);
		}
		public void gridzy()
		{
			float angle = (float) (Math.Atan(Form1.Default.zn / Form1.Default.yn));
			System.Drawing.Pen backgrid = new Pen(Brushes.DarkGray, 1);
			System.Drawing.Pen skeleton = new Pen(Brushes.Gray, 1);
			System.Drawing.Pen light = new Pen(Brushes.Silver, 1);
			
			float diag = System.Convert.ToSingle(0);
			float jump = Form1.Default.cellzyz;
			int a;
			int b;
			
			for (var i = 1; i <= Form1.Default.xn; i++)
			{
				jump =  (float) (jump * (Form1.Default.sizeratio));
				diag = diag + jump;
				a = System.Convert.ToInt32(Math.Sin(angle) * diag);
				b = System.Convert.ToInt32(Math.Cos(angle) * diag);
				gfxzy.DrawLine(backgrid, a, b, Form1.Default.sizezyz - a, b);
				gfxzy.DrawLine(backgrid, a, Form1.Default.sizezyy - b, Form1.Default.sizezyz - a, Form1.Default.sizezyy - b);
				gfxzy.DrawLine(backgrid, a, b, a, Form1.Default.sizezyy - b);
				gfxzy.DrawLine(backgrid, Form1.Default.sizezyz - a, b, Form1.Default.sizezyz - a, Form1.Default.sizezyy - b);
				if (i == Form1.Default.xn)
				{
					int cell;
					int celly;
					cell = System.Convert.ToInt32((Form1.Default.sizezyz - (a * 2)) / Form1.Default.zn);
					celly = System.Convert.ToInt32((Form1.Default.sizezyy - (b * 2)) / Form1.Default.yn);
					for (var j = 1; j <= Form1.Default.zn - 1; j++)
					{
						gfxzy.DrawLine(backgrid, a + (cell * j), b, System.Convert.ToInt32(Form1.Default.cellzyz * j), 0);
						gfxzy.DrawLine(backgrid, a + (cell * j), Form1.Default.sizezyy - b, System.Convert.ToInt32(Form1.Default.cellzyz * j), Form1.Default.sizezyy);
						gfxzy.DrawLine(light, a + (cell * j), b, a + (cell * j), Form1.Default.sizezyy - b);
					}
					
					for (var k = 1; k <= Form1.Default.yn - 1; k++)
					{
						gfxzy.DrawLine(backgrid, a, b + (celly * k), 0, System.Convert.ToInt32(Form1.Default.cellzyy * k));
						gfxzy.DrawLine(backgrid, Form1.Default.sizezyz, System.Convert.ToInt32(Form1.Default.cellzyy * k), Form1.Default.sizezyz - a, b + (celly * k));
						gfxzy.DrawLine(light, a, b + (celly * k), Form1.Default.sizezyz - a, b + (celly * k));
					}
				}
			}
			
			a = System.Convert.ToInt32(Math.Sin(angle) * diag);
			b = System.Convert.ToInt32(Math.Cos(angle) * diag);
			
			gfxzy.DrawLine(skeleton, 0, 0, a, b);
			gfxzy.DrawLine(skeleton, Form1.Default.sizezyz, 0, Form1.Default.sizezyz - a, b);
			gfxzy.DrawLine(skeleton, 0, Form1.Default.sizezyy, a, Form1.Default.sizezyy - b);
			gfxzy.DrawLine(skeleton, Form1.Default.sizezyz, Form1.Default.sizezyy, Form1.Default.sizezyz - a, Form1.Default.sizezyy - b);
		}
		
		public void occupiedneg()
		{
			for (var x = 1; x <= Form1.Default.xn; x++)
			{
				for (var y = 1; y <= Form1.Default.yn; y++)
				{
					for (var z = 1; z <= Form1.Default.zn; z++)
					{
						occupied[x, y, z] = false;
					}
				}
			}
		}
		
		
		public void generator_Load(System.Object sender, System.EventArgs e)
		{
			
			this.Hide();
			
			
			for (var i = 1; i <= Form1.Default.agent; i++)
			{
				agentname[i] = (string) ("Agent" + i);
				initialenergy[i] = 1;
			}
			
			
			int red;
			int blue;
			int green;
			VBMath.Randomize();
			for (var i = 1; i <= Form1.Default.agent; i++)
			{
				red = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal(255 * VBMath.Rnd())))) + 1;
				blue = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal(255 * VBMath.Rnd())))) + 1;
				green = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal(255 * VBMath.Rnd())))) + 1;
				agentcolour[i] = Color.FromArgb(red, green, blue);
			}
			
			
			for (var i = 1; i <= Form1.Default.agent; i++)
			{
				agentrange[i, 0, 0] = 1;
				agentrange[i, 1, 0] = 1;
				agentrange[i, 2, 0] = 1;
				agentrange[i, 0, 1] = Form1.Default.xn;
				agentrange[i, 1, 1] = Form1.Default.yn;
				agentrange[i, 2, 1] = Form1.Default.zn;
			}
			
			
			for (var a = 1; a <= Form1.Default.agent; a++)
			{
				for (var b = 1; b <= Form1.Default.agent; b++)
				{
					action[a, b, 6] = 2;
				}
			}
			
			
			Form1.Default.TopViewToolStripMenuItem.Enabled = true;
			Form1.Default.SideViewToolStripMenuItem1.Enabled = true;
			Form1.Default.SideViewToolStripMenuItem.Enabled = false;
			Form1.Default.LogDataToolStripMenuItem.Enabled = true;
			Form1.Default.SaveProjectToolStripMenuItem.Enabled = true;
			
			gfxxy.Clear(Color.White);
			
			Form1.Default.viewlabel.Text = "Side View (x,y)";
			
			
			
			gridxy();
			
			
			
			
			
			occupiedneg();
			
			
			
			//For a = 0 To Form1.agent - 1
			//Dim agentcount As Integer = Integer.Parse(Form1.count.Substring((a * 6), 5))
			// For i = 1 To agentcount
			//Randomize()
			// Dim x As Integer = CInt(Math.Floor((Form1.xn - 1 + 1) * Rnd())) + 1
			//Dim y As Integer = CInt(Math.Floor((Form1.yn - 1 + 1) * Rnd())) + 1
			//Dim z As Integer = CInt(Math.Floor((Form1.zn - 1 + 1) * Rnd())) + 1
			//Dim directioninteger As Integer = CInt(Math.Floor((6 - 1 + 1) * Rnd())) + 1
			//Dim directionstring As String
			//If directioninteger = 1 Then
			//'directionstring = "up"
			// ElseIf directioninteger = 2 Then
			// directionstring = "down"
			// ElseIf directioninteger = 3 Then
			// directionstring = "right"
			// ElseIf directioninteger = 4 Then
			//directionstring = "left"
			//ElseIf directioninteger = 5 Then
			//directionstring = "front"
			// ElseIf directioninteger = 6 Then
			// directionstring = "back"
			// End If
			// Call Form1.creator(x, y, z, directionstring)
			//Next
			//Next
			
			
			
			
			
			
			topgridxy();
			
			
			Form1.Default.picshow();
			
		}
	}
}
