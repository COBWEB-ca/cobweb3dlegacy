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
	public partial class Form1
	{
		public Form1()
		{
			InitializeComponent();
			
			//Added to support default instance behavour in C#
			if (defaultInstance == null)
				defaultInstance = this;
		}
		
		#region Default Instance
		
		private static Form1 defaultInstance;
		
		/// <summary>
		/// Added by the VB.Net to C# Converter to support default instance behavour in C#
		/// </summary>
		public static Form1 Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new Form1();
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
		//the variables for the resolution of the pic
		public int sizexyx;
		public int sizexyy;
		
		
		public int sizexzx;
		public int sizexzz;
		
		public int sizezyy;
		public int sizezyz;
		
		public int tick;
		public double sizeratio = System.Convert.ToDouble(3 / 4);
		
		public int agent;
		public int total;
		
		
		//the variables for the size of grid
		public int xn;
		public int yn;
		public int zn;
		
		//size of each cell
		public float cellxyx;
		public float cellxyy;
		public float cellxzx;
		public float cellxzz;
		public float cellzyz;
		public float cellzyy;
		
		int havetodelete;
		public string view;
		
		public string save;
		public bool timerexit = false;
		
		//codes for excel file
		private object oExcel;
		private object oBook;
		private object oSheet;
		private bool logged = false;
		private string exceldir;
		
		
		
		
		
		
		
		
		
		
		public void picshow()
		{
			PictureBox1.Image = generator.Default.picxy;
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		public void creator(string xlocation, int ylocation, int zlocation, string direction, System.Drawing.Color colour)
		{
			float diag = System.Convert.ToSingle(0);
			double jump = cellxyx;
			for (var i = 1; i <= zlocation - 1; i++)
			{
				jump = jump * (sizeratio);
				diag =  (float) (diag + jump);
			}
			float angle = (float) (Math.Atan(xn / yn));
			int a = System.Convert.ToInt32(Math.Sin(angle) * diag);
			int b = System.Convert.ToInt32(Math.Cos(angle) * diag);
			
			int topfrontrightx = a + (int.Parse(xlocation) * ((sizexyx - (2 * a)) / xn) );
			int topfrontrighty = b + ((ylocation - 1) * ((sizexyy - (2 * b)) / yn));
			int topfrontleftx = a + ((int.Parse(xlocation) - 1 ) * ((sizexyx - (2 * a)) / xn));
			int topfrontlefty = b + ((ylocation - 1) * ((sizexyy - (2 * b)) / yn));
			
			int bottomfrontrightx = a + (int.Parse(xlocation) * ((sizexyx - (2 * a)) / xn) );
			int bottomfrontrighty = b + (ylocation * ((sizexyy - (2 * b)) / yn));
			int bottomfrontleftx = a + ((int.Parse(xlocation) - 1 ) * ((sizexyx - (2 * a)) / xn));
			int bottomfrontlefty = b + (ylocation * ((sizexyy - (2 * b)) / yn));
			
			jump = jump * (sizeratio);
			diag =  (float) (diag + jump);
			
			angle = (float) (Math.Atan(xn / yn));
			a = System.Convert.ToInt32(Math.Sin(angle) * diag);
			b = System.Convert.ToInt32(Math.Cos(angle) * diag);
			
			int topbackrightx = a + (int.Parse(xlocation) * ((sizexyx - (2 * a)) / xn) );
			int topbackrighty = b + ((ylocation - 1) * ((sizexyy - (2 * b)) / yn));
			int topbackleftx = a + ((int.Parse(xlocation) - 1 ) * ((sizexyx - (2 * a)) / xn));
			int topbacklefty = b + ((ylocation - 1) * ((sizexyy - (2 * b)) / yn));
			
			int bottombackrightx = a + (int.Parse(xlocation) * ((sizexyx - (2 * a)) / xn) );
			int bottombackrighty = b + (ylocation * ((sizexyy - (2 * b)) / yn));
			int bottombackleftx = a + ((int.Parse(xlocation) - 1 ) * ((sizexyx - (2 * a)) / xn));
			int bottombacklefty = b + (ylocation * ((sizexyy - (2 * b)) / yn));
			
			
			//generator.gfxxy.DrawLine(Pens.Red, topfrontleftx, topfrontlefty, topfrontrightx, topfrontrighty)
			//generator.gfxxy.DrawLine(Pens.Red, bottomfrontleftx, bottomfrontlefty, bottomfrontrightx, bottomfrontrighty)
			//generator.gfxxy.DrawLine(Pens.Red, topbackleftx, topbacklefty, topbackrightx, topbackrighty)
			//generator.gfxxy.DrawLine(Pens.Red, bottombackleftx, bottombacklefty, bottombackrightx, bottombackrighty)
			
			
			
			System.Drawing.Point topfrontright = new System.Drawing.Point(topfrontrightx, topfrontrighty);
			System.Drawing.Point topfrontleft = new System.Drawing.Point(topfrontleftx, topfrontlefty);
			System.Drawing.Point bottomfrontright = new System.Drawing.Point(bottomfrontrightx, bottomfrontrighty);
			System.Drawing.Point bottomfrontleft = new System.Drawing.Point(bottomfrontleftx, bottomfrontlefty);
			
			System.Drawing.Point topbackright = new System.Drawing.Point(topbackrightx, topbackrighty);
			System.Drawing.Point topbackleft = new System.Drawing.Point(topbackleftx, topbacklefty);
			System.Drawing.Point bottombackright = new System.Drawing.Point(bottombackrightx, bottombackrighty);
			System.Drawing.Point bottombackleft = new System.Drawing.Point(bottombackleftx, bottombacklefty);
			
			
			float[] dashValues = new float[] {1, 2};
			Pen graypen = new Pen(Color.Gray, 1);
			SolidBrush myBrush = new SolidBrush(colour);
			graypen.DashPattern = dashValues;
			
			if (direction == "back")
			{
				
				int beakx = topbackleftx + (Math.Abs(topbackleftx - topbackrightx) / 2);
				int beaky = topbacklefty + (Math.Abs(topbacklefty - bottombacklefty) / 2);
				System.Drawing.Point beak = new System.Drawing.Point(beakx, beaky);
				
				Point[] top = new Point[] {topfrontleft, beak, topfrontright};
				Point[] right = new Point[] {topfrontright, beak, bottomfrontright};
				Point[] bottom = new Point[] {bottomfrontleft, beak, bottomfrontright};
				Point[] left = new Point[] {topfrontleft, beak, bottomfrontleft};
				generator.Default.gfxxy.FillPolygon(myBrush, top);
				generator.Default.gfxxy.FillPolygon(myBrush, right);
				generator.Default.gfxxy.FillPolygon(myBrush, bottom);
				generator.Default.gfxxy.FillPolygon(myBrush, left);
				
				generator.Default.gfxxy.DrawLine(graypen, topfrontleft, beak);
				generator.Default.gfxxy.DrawLine(graypen, bottomfrontleft, beak);
				generator.Default.gfxxy.DrawLine(graypen, bottomfrontright, beak);
				generator.Default.gfxxy.DrawLine(graypen, topfrontright, beak);
				
				generator.Default.gfxxy.DrawLine(Pens.Gray, topfrontleft, topfrontright);
				generator.Default.gfxxy.DrawLine(Pens.Gray, topfrontright, bottomfrontright);
				generator.Default.gfxxy.DrawLine(Pens.Gray, bottomfrontright, bottomfrontleft);
				generator.Default.gfxxy.DrawLine(Pens.Gray, bottomfrontleft, topfrontleft);
				
			}
			else if (direction == "front")
			{
				int beakx = topfrontleftx + (Math.Abs(topfrontleftx - topfrontrightx) / 2);
				int beaky = topfrontlefty + (Math.Abs(topfrontlefty - bottomfrontlefty) / 2);
				System.Drawing.Point beak = new System.Drawing.Point(beakx, beaky);
				
				
				Point[] top = new Point[] {topbackleft, beak, topbackright};
				Point[] right = new Point[] {topbackright, beak, bottombackright};
				Point[] bottom = new Point[] {bottombackleft, beak, bottombackright};
				Point[] left = new Point[] {topbackleft, beak, bottombackleft};
				generator.Default.gfxxy.FillPolygon(myBrush, top);
				generator.Default.gfxxy.FillPolygon(myBrush, right);
				generator.Default.gfxxy.FillPolygon(myBrush, bottom);
				generator.Default.gfxxy.FillPolygon(myBrush, left);
				
				generator.Default.gfxxy.DrawLine(Pens.Gray, topbackleft, beak);
				generator.Default.gfxxy.DrawLine(Pens.Gray, bottombackleft, beak);
				generator.Default.gfxxy.DrawLine(Pens.Gray, bottombackright, beak);
				generator.Default.gfxxy.DrawLine(Pens.Gray, topbackright, beak);
				
				generator.Default.gfxxy.DrawLine(Pens.Gray, topbackleft, topbackright);
				generator.Default.gfxxy.DrawLine(Pens.Gray, topbackright, bottombackright);
				generator.Default.gfxxy.DrawLine(Pens.Gray, bottombackright, bottombackleft);
				generator.Default.gfxxy.DrawLine(Pens.Gray, bottombackleft, topbackleft);
				
			}
			else if (direction == "up")
			{
				if (ylocation <= yn / 2)
				{
					int beakx = System.Convert.ToInt32((((Math.Abs(topbackleftx - topbackrightx) / 2) + (Math.Abs(topfrontleftx - topfrontrightx) / 2)) / 2) + ((topfrontleftx + topbackleftx) / 2));
					int beaky = topfrontlefty + (Math.Abs(topfrontlefty - topbacklefty) / 2);
					System.Drawing.Point beak = new System.Drawing.Point(beakx, beaky);
					Point[] front = new Point[] {bottomfrontleft, beak, bottomfrontright};
					Point[] right = new Point[] {bottomfrontright, beak, bottombackright};
					Point[] left = new Point[] {bottomfrontleft, bottombackleft, beak};
					Point[] bottom = new Point[] {bottomfrontleft, bottombackleft, bottombackright, bottomfrontright};
					generator.Default.gfxxy.FillPolygon(myBrush, front);
					generator.Default.gfxxy.FillPolygon(myBrush, right);
					generator.Default.gfxxy.FillPolygon(myBrush, left);
					generator.Default.gfxxy.FillPolygon(myBrush, bottom);
					generator.Default.gfxxy.DrawLine(Pens.Gray, bottomfrontleft, beak);
					generator.Default.gfxxy.DrawLine(Pens.Gray, bottomfrontright, beak);
					generator.Default.gfxxy.DrawLine(Pens.Gray, bottomfrontleft, bottomfrontright);
					generator.Default.gfxxy.DrawLine(Pens.Gray, bottomfrontleft, bottombackleft);
					generator.Default.gfxxy.DrawLine(Pens.Gray, bottombackleft, bottombackright);
					generator.Default.gfxxy.DrawLine(Pens.Gray, bottombackright, bottomfrontright);
					
					float ang = (float) (Math.Atan(System.Convert.ToDouble(Math.Abs(beaky - bottombackrighty) / Math.Abs(beakx - bottombackrightx))));
					float pointx =  (float) (bottombackrightx - (Math.Abs(bottomfrontrighty - bottombackrighty) / Math.Tan(ang)));
					
					if (pointx > bottomfrontrightx)
					{
						generator.Default.gfxxy.DrawLine(Pens.Gray, bottombackright, beak);
					}
					else
					{
						generator.Default.gfxxy.DrawLine(graypen, bottombackright, beak);
					}
					
					ang = (float) (Math.Atan(System.Convert.ToDouble(Math.Abs(beaky - bottombacklefty) / Math.Abs(beakx - bottombackleftx))));
					pointx = System.Convert.ToSingle((Math.Abs(bottomfrontlefty - bottombacklefty) / Math.Tan(ang)) + bottombackleftx);
					
					
					if (pointx < bottomfrontleftx)
					{
						generator.Default.gfxxy.DrawLine(Pens.Gray, beak, bottombackleft);
					}
					else
					{
						generator.Default.gfxxy.DrawLine(graypen, beak, bottombackleft);
					}
					
				}
				else if (ylocation >= yn / 2)
				{
					int beakx = System.Convert.ToInt32((((Math.Abs(topbackleftx - topbackrightx) / 2) + (Math.Abs(topfrontleftx - topfrontrightx) / 2)) / 2) + ((topfrontleftx + topbackleftx) / 2));
					int beaky = topbacklefty + (Math.Abs(topfrontlefty - topbacklefty) / 2);
					System.Drawing.Point beak = new System.Drawing.Point(beakx, beaky);
					Point[] front = new Point[] {bottomfrontleft, beak, bottomfrontright};
					Point[] right = new Point[] {bottomfrontright, beak, bottombackright};
					Point[] left = new Point[] {bottomfrontleft, bottombackleft, beak};
					generator.Default.gfxxy.FillPolygon(myBrush, front);
					generator.Default.gfxxy.FillPolygon(myBrush, right);
					generator.Default.gfxxy.FillPolygon(myBrush, left);
					generator.Default.gfxxy.DrawLine(Pens.Gray, bottomfrontleft, beak);
					generator.Default.gfxxy.DrawLine(Pens.Gray, bottomfrontright, beak);
					generator.Default.gfxxy.DrawLine(Pens.Gray, bottomfrontleft, bottomfrontright);
					
					float ang = (float) (Math.Atan(System.Convert.ToDouble(Math.Abs(beaky - bottomfrontlefty) / Math.Abs(beakx - topfrontleftx))));
					float pointx = System.Convert.ToSingle((Math.Abs(bottombacklefty - bottomfrontlefty) / Math.Tan(ang)) + bottomfrontleftx);
					
					if (pointx < bottombackleftx)
					{
						generator.Default.gfxxy.DrawLine(graypen, bottombackleft, beak);
						generator.Default.gfxxy.DrawLine(graypen, bottombackleft, bottomfrontleft);
						generator.Default.gfxxy.DrawLine(graypen, bottombackleft, bottombackright);
					}
					else
					{
						generator.Default.gfxxy.DrawLine(Pens.Gray, bottombackleft, bottomfrontleft);
						generator.Default.gfxxy.DrawLine(Pens.Gray, bottombackleft, beak);
						generator.Default.gfxxy.DrawLine(graypen, bottombackleft, bottombackright);
					}
					
					ang = (float) (Math.Atan(System.Convert.ToDouble(Math.Abs(beaky - bottomfrontrighty) / Math.Abs(beakx - topfrontrightx))));
					pointx =  (float) (bottomfrontrightx - (Math.Abs(bottombackrighty - bottomfrontrighty) / Math.Tan(ang)));
					
					
					if (pointx < bottombackrightx)
					{
						generator.Default.gfxxy.DrawLine(Pens.Gray, beak, bottombackright);
						generator.Default.gfxxy.DrawLine(Pens.Gray, bottomfrontright, bottombackright);
					}
					else
					{
						generator.Default.gfxxy.DrawLine(graypen, beak, bottombackright);
						generator.Default.gfxxy.DrawLine(graypen, bottomfrontright, bottombackright);
					}
					
				}
				
			}
			else if (direction == "down")
			{
				if (ylocation <= yn / 2)
				{
					int beakx = System.Convert.ToInt32((((Math.Abs(bottombackleftx - bottombackrightx) / 2) + (Math.Abs(bottomfrontleftx - bottomfrontrightx) / 2)) / 2) + ((bottomfrontleftx + bottombackleftx) / 2));
					int beaky = bottomfrontlefty + (Math.Abs(bottomfrontlefty - bottombacklefty) / 2);
					System.Drawing.Point beak = new System.Drawing.Point(beakx, beaky);
					Point[] front = new Point[] {topfrontleft, beak, topfrontright};
					Point[] right = new Point[] {topfrontright, beak, topbackright};
					Point[] left = new Point[] {topfrontleft, topbackleft, beak};
					generator.Default.gfxxy.FillPolygon(myBrush, front);
					generator.Default.gfxxy.FillPolygon(myBrush, right);
					generator.Default.gfxxy.FillPolygon(myBrush, left);
					generator.Default.gfxxy.DrawLine(Pens.Gray, topfrontleft, beak);
					generator.Default.gfxxy.DrawLine(Pens.Gray, topfrontright, beak);
					generator.Default.gfxxy.DrawLine(Pens.Gray, topfrontleft, topfrontright);
					generator.Default.gfxxy.DrawLine(graypen, topbackright, topbackleft);
					
					float ang = (float) (Math.Atan(System.Convert.ToDouble(Math.Abs(beaky - topfrontrighty) / Math.Abs(beakx - topfrontrightx))));
					float pointx =  (float) (topfrontrightx - (Math.Abs(topfrontrighty - topbackrighty) / Math.Tan(ang)));
					
					if (pointx < topbackrightx)
					{
						generator.Default.gfxxy.DrawLine(Pens.Gray, topbackright, beak);
						generator.Default.gfxxy.DrawLine(Pens.Gray, topfrontright, topbackright);
					}
					else
					{
						generator.Default.gfxxy.DrawLine(graypen, topbackright, beak);
						generator.Default.gfxxy.DrawLine(graypen, topfrontright, topbackright);
					}
					
					ang = (float) (Math.Atan(System.Convert.ToDouble(Math.Abs(beaky - topfrontlefty) / Math.Abs(beakx - topfrontleftx))));
					pointx = System.Convert.ToSingle((Math.Abs(topfrontlefty - topbacklefty) / Math.Tan(ang)) + topfrontleftx);
					
					
					if (pointx > topbackleftx)
					{
						generator.Default.gfxxy.DrawLine(Pens.Gray, beak, topbackleft);
						generator.Default.gfxxy.DrawLine(Pens.Gray, topbackleft, topfrontleft);
					}
					else
					{
						generator.Default.gfxxy.DrawLine(graypen, beak, topbackleft);
						generator.Default.gfxxy.DrawLine(graypen, topbackleft, topfrontleft);
					}
					
				}
				else if (ylocation >= yn / 2)
				{
					int beakx = System.Convert.ToInt32((((Math.Abs(bottombackleftx - bottombackrightx) / 2) + (Math.Abs(bottomfrontleftx - bottomfrontrightx) / 2)) / 2) + ((bottomfrontleftx + bottombackleftx) / 2));
					int beaky = bottombacklefty + (Math.Abs(bottomfrontlefty - bottombacklefty) / 2);
					System.Drawing.Point beak = new System.Drawing.Point(beakx, beaky);
					Point[] front = new Point[] {topfrontleft, beak, topfrontright};
					Point[] right = new Point[] {topfrontright, beak, topbackright};
					Point[] left = new Point[] {topfrontleft, topbackleft, beak};
					Point[] top = new Point[] {topfrontleft, topbackleft, topbackright, topfrontright};
					generator.Default.gfxxy.FillPolygon(myBrush, front);
					generator.Default.gfxxy.FillPolygon(myBrush, right);
					generator.Default.gfxxy.FillPolygon(myBrush, left);
					generator.Default.gfxxy.FillPolygon(myBrush, top);
					generator.Default.gfxxy.DrawLine(Pens.Gray, topfrontleft, beak);
					generator.Default.gfxxy.DrawLine(Pens.Gray, topfrontright, beak);
					generator.Default.gfxxy.DrawLine(Pens.Gray, topfrontleft, topfrontright);
					
					generator.Default.gfxxy.DrawLine(Pens.Gray, topfrontleft, topbackleft);
					generator.Default.gfxxy.DrawLine(Pens.Gray, topbackleft, topbackright);
					generator.Default.gfxxy.DrawLine(Pens.Gray, topbackright, topfrontright);
					
					float ang = (float) (Math.Atan(System.Convert.ToDouble(Math.Abs(beaky - topbacklefty) / Math.Abs(beakx - bottombackleftx))));
					float pointx = System.Convert.ToSingle((Math.Abs(topfrontlefty - topbacklefty) / Math.Tan(ang)) + topbackleftx);
					
					if (pointx > topfrontleftx)
					{
						generator.Default.gfxxy.DrawLine(graypen, topbackleft, beak);
					}
					else
					{
						generator.Default.gfxxy.DrawLine(Pens.Gray, topbackleft, beak);
					}
					
					ang = (float) (Math.Atan(System.Convert.ToDouble(Math.Abs(beaky - topbackrighty) / Math.Abs(beakx - bottombackrightx))));
					pointx =  (float) (topbackrightx - (Math.Abs(topfrontrighty - topbackrighty) / Math.Tan(ang)));
					
					
					if (pointx > topfrontrightx)
					{
						generator.Default.gfxxy.DrawLine(Pens.Gray, beak, topbackright);
					}
					else
					{
						generator.Default.gfxxy.DrawLine(graypen, beak, topbackright);
					}
				}
				
				
			}
			else if (direction == "right")
			{
				if (int.Parse(xlocation) <= xn / 2 )
				{
					
					int beakx = System.Convert.ToInt32((Math.Abs(topfrontrightx - topbackrightx) / 2) + topfrontrightx);
					int beaky = System.Convert.ToInt32(Math.Abs(topfrontrighty - bottombackrighty) / 2 + topfrontlefty);
					System.Drawing.Point beak = new System.Drawing.Point(beakx, beaky);
					
					Point[] top = new Point[] {topfrontleft, topbackleft, beak};
					Point[] middle = new Point[] {topfrontleft, beak, bottomfrontleft};
					Point[] bottom = new Point[] {bottomfrontleft, bottombackleft, beak};
					
					generator.Default.gfxxy.FillPolygon(myBrush, top);
					generator.Default.gfxxy.FillPolygon(myBrush, middle);
					generator.Default.gfxxy.FillPolygon(myBrush, bottom);
					generator.Default.gfxxy.DrawLine(Pens.Gray, bottomfrontleft, beak);
					generator.Default.gfxxy.DrawLine(Pens.Gray, bottomfrontleft, topfrontleft);
					generator.Default.gfxxy.DrawLine(Pens.Gray, topfrontleft, beak);
					
					float ang = (float) (Math.Atan(System.Convert.ToDouble((Math.Abs(topfrontrighty - bottombackrighty) / 2) / ((Math.Abs(topfrontrightx - topbackrightx) / 2) + (topfrontrightx - topfrontleftx)))));
					float pointy = System.Convert.ToSingle((Math.Tan(ang) * (a - topfrontleftx)) + topfrontlefty);
					
					if (topbacklefty < pointy)
					{
						generator.Default.gfxxy.DrawLine(Pens.Gray, topbackleft, beak);
						generator.Default.gfxxy.DrawLine(Pens.Gray, topfrontleft, topbackleft);
					}
					else
					{
						generator.Default.gfxxy.DrawLine(graypen, topfrontleft, topbackleft);
						generator.Default.gfxxy.DrawLine(graypen, topbackleft, beak);
					}
					
					pointy =  (float) (bottomfrontlefty - (Math.Tan(ang) * (a - topfrontleftx)));
					
					if (bottombacklefty < pointy)
					{
						generator.Default.gfxxy.DrawLine(graypen, bottomfrontleft, bottombackleft);
						generator.Default.gfxxy.DrawLine(graypen, bottombackleft, beak);
					}
					else
					{
						generator.Default.gfxxy.DrawLine(Pens.Gray, bottomfrontleft, bottombackleft);
						generator.Default.gfxxy.DrawLine(Pens.Gray, bottombackleft, beak);
					}
					
					generator.Default.gfxxy.DrawLine(graypen, topbackleft, bottombackleft);
					
					
				}
				else if (int.Parse(xlocation) >= xn / 2 )
				{
					
					int beakx = topfrontrightx - (Math.Abs(topfrontrightx - topbackrightx) / 2);
					int beaky = System.Convert.ToInt32(Math.Abs(topfrontrighty - bottombackrighty) / 2 + topfrontlefty);
					System.Drawing.Point beak = new System.Drawing.Point(beakx, beaky);
					
					Point[] top = new Point[] {topfrontleft, topbackleft, beak};
					Point[] middle = new Point[] {topfrontleft, beak, bottomfrontleft};
					Point[] bottom = new Point[] {bottomfrontleft, bottombackleft, beak};
					Point[] back = new Point[] {topfrontleft, bottomfrontleft, bottombackleft, topbackleft};
					
					generator.Default.gfxxy.FillPolygon(myBrush, top);
					generator.Default.gfxxy.FillPolygon(myBrush, middle);
					generator.Default.gfxxy.FillPolygon(myBrush, bottom);
					generator.Default.gfxxy.FillPolygon(myBrush, back);
					
					generator.Default.gfxxy.DrawLine(Pens.Gray, topfrontleft, bottomfrontleft);
					generator.Default.gfxxy.DrawLine(Pens.Gray, bottomfrontleft, bottombackleft);
					generator.Default.gfxxy.DrawLine(Pens.Gray, bottombackleft, topbackleft);
					generator.Default.gfxxy.DrawLine(Pens.Gray, topbackleft, topfrontleft);
					generator.Default.gfxxy.DrawLine(Pens.Gray, bottomfrontleft, beak);
					
					generator.Default.gfxxy.DrawLine(Pens.Gray, topfrontleft, beak);
					
					
					float ang;
					ang = (float) (Math.Atan(System.Convert.ToDouble((Math.Abs(beaky - bottombacklefty)) / (Math.Abs(beakx - bottombackleftx)))));
					float pointy;
					pointy =  (float) (bottombacklefty - (Math.Tan(ang) * (Math.Abs(topfrontleftx - topbackleftx))));
					if (pointy > bottomfrontlefty)
					{
						generator.Default.gfxxy.DrawLine(Pens.Gray, bottombackleft, beak);
					}
					else
					{
						generator.Default.gfxxy.DrawLine(graypen, bottombackleft, beak);
					}
					
					ang = (float) (Math.Atan(System.Convert.ToDouble((Math.Abs(beaky - topbacklefty)) / (Math.Abs(beakx - topbackleftx)))));
					pointy =  (float) (topbacklefty + (Math.Tan(ang) * (Math.Abs(topfrontleftx - topbackleftx))));
					
					if (pointy < topfrontlefty)
					{
						generator.Default.gfxxy.DrawLine(Pens.Gray, topbackleft, beak);
					}
					else
					{
						generator.Default.gfxxy.DrawLine(graypen, topbackleft, beak);
					}
				}
				
				
			}
			else if (direction == "left")
			{
				if (int.Parse(xlocation) <= xn / 2 )
				{
					int beakx = topfrontleftx + (Math.Abs(topfrontleftx - topbackleftx) / 2);
					int beaky = System.Convert.ToInt32((Math.Abs(bottomfrontlefty - topbacklefty) / 2) + topbacklefty);
					System.Drawing.Point beak = new System.Drawing.Point(beakx, beaky);
					
					Point[] top = new Point[] {topfrontright, topbackright, beak};
					Point[] middle = new Point[] {topfrontright, beak, bottomfrontright};
					Point[] bottom = new Point[] {bottomfrontright, bottombackright, beak};
					Point[] back = new Point[] {bottomfrontright, bottombackright, topbackright, topfrontright};
					
					generator.Default.gfxxy.FillPolygon(myBrush, top);
					generator.Default.gfxxy.FillPolygon(myBrush, middle);
					generator.Default.gfxxy.FillPolygon(myBrush, bottom);
					generator.Default.gfxxy.FillPolygon(myBrush, back);
					generator.Default.gfxxy.DrawLine(Pens.Gray, bottomfrontright, beak);
					generator.Default.gfxxy.DrawLine(Pens.Gray, bottomfrontright, topfrontright);
					generator.Default.gfxxy.DrawLine(Pens.Gray, topfrontright, beak);
					generator.Default.gfxxy.DrawLine(Pens.Gray, topfrontright, topbackright);
					generator.Default.gfxxy.DrawLine(Pens.Gray, topbackright, bottombackright);
					generator.Default.gfxxy.DrawLine(Pens.Gray, bottombackright, bottomfrontright);
					
					float ang = (float) (Math.Atan(System.Convert.ToDouble(Math.Abs(beakx - topbackrightx) / Math.Abs(beaky - topbackrighty))));
					float pointy =  (float) (topbackrighty + ((topbackrightx - topfrontrightx) / Math.Tan(ang)));
					
					if (topfrontrighty > pointy)
					{
						generator.Default.gfxxy.DrawLine(Pens.Gray, topbackright, beak);
					}
					else
					{
						generator.Default.gfxxy.DrawLine(graypen, topbackright, beak);
					}
					
					ang = (float) (Math.Atan(System.Convert.ToDouble(Math.Abs(beakx - bottombackrightx) / Math.Abs(beaky - bottombackrighty))));
					pointy =  (float) (bottombackrighty - ((bottombackrightx - bottomfrontrightx) / Math.Tan(ang)));
					
					if (bottomfrontrighty < pointy)
					{
						generator.Default.gfxxy.DrawLine(Pens.Gray, bottombackright, beak);
					}
					else
					{
						generator.Default.gfxxy.DrawLine(graypen, bottombackright, beak);
					}
					
				}
				else if (int.Parse(xlocation) > xn / 2 )
				{
					int beakx = topfrontleftx - (Math.Abs(topfrontleftx - topbackleftx) / 2);
					int beaky = System.Convert.ToInt32((Math.Abs(bottomfrontlefty - topbacklefty) / 2) + topbacklefty);
					System.Drawing.Point beak = new System.Drawing.Point(beakx, beaky);
					Point[] top = new Point[] {topfrontright, topbackright, beak};
					Point[] middle = new Point[] {topfrontright, beak, bottomfrontright};
					Point[] bottom = new Point[] {bottomfrontright, bottombackright, beak};
					generator.Default.gfxxy.FillPolygon(myBrush, top);
					generator.Default.gfxxy.FillPolygon(myBrush, middle);
					generator.Default.gfxxy.FillPolygon(myBrush, bottom);
					generator.Default.gfxxy.DrawLine(Pens.Gray, bottomfrontright, beak);
					generator.Default.gfxxy.DrawLine(Pens.Gray, bottomfrontright, topfrontright);
					generator.Default.gfxxy.DrawLine(Pens.Gray, topfrontright, beak);
					generator.Default.gfxxy.DrawLine(graypen, topbackright, bottombackright);
					
					float ang = (float) (Math.Atan(System.Convert.ToDouble(Math.Abs(beakx - topfrontrightx) / Math.Abs(beaky - topfrontrighty))));
					float pointy =  (float) (topfrontrighty + ((topfrontrightx - topbackrightx) / Math.Tan(ang)));
					
					if (topbackrighty < pointy)
					{
						generator.Default.gfxxy.DrawLine(Pens.Gray, topbackright, beak);
						generator.Default.gfxxy.DrawLine(Pens.Gray, topfrontright, topbackright);
					}
					else
					{
						generator.Default.gfxxy.DrawLine(graypen, topbackright, beak);
						generator.Default.gfxxy.DrawLine(graypen, topfrontright, topbackright);
					}
					
					ang = (float) (Math.Atan(System.Convert.ToDouble(Math.Abs(beakx - bottomfrontrightx) / Math.Abs(beaky - bottomfrontrighty))));
					pointy =  (float) (bottomfrontrighty - ((bottomfrontrightx - bottombackrightx) / Math.Tan(ang)));
					
					if (bottombackrighty > pointy)
					{
						generator.Default.gfxxy.DrawLine(Pens.Gray, bottombackright, beak);
						generator.Default.gfxxy.DrawLine(Pens.Gray, bottombackright, bottomfrontright);
					}
					else
					{
						generator.Default.gfxxy.DrawLine(graypen, bottombackright, beak);
						generator.Default.gfxxy.DrawLine(graypen, bottombackright, bottomfrontright);
					}
					
				}
				
			}
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		public void creatorxz(string xlocation, int ylocation, int zlocation, string direction, System.Drawing.Color colour)
		{
			zlocation = System.Convert.ToInt32((zn - zlocation) + 1);
			float diag = System.Convert.ToSingle(0);
			double jump = cellxzx;
			for (var i = 1; i <= ylocation - 1; i++)
			{
				jump = jump * (sizeratio);
				diag =  (float) (diag + jump);
			}
			float angle = (float) (Math.Atan(xn / zn));
			int a = System.Convert.ToInt32(Math.Sin(angle) * diag);
			int b = System.Convert.ToInt32(Math.Cos(angle) * diag);
			
			int topfrontrightx = a + (int.Parse(xlocation) * ((sizexzx - (2 * a)) / xn) );
			int topfrontrighty = b + ((zlocation - 1) * ((sizexzz - (2 * b)) / zn));
			int topfrontleftx = a + ((int.Parse(xlocation) - 1 ) * ((sizexzx - (2 * a)) / xn));
			int topfrontlefty = b + ((zlocation - 1) * ((sizexzz - (2 * b)) / zn));
			
			int bottomfrontrightx = a + (int.Parse(xlocation) * ((sizexzx - (2 * a)) / xn) );
			int bottomfrontrighty = b + (zlocation * ((sizexzz - (2 * b)) / zn));
			int bottomfrontleftx = a + ((int.Parse(xlocation) - 1 ) * ((sizexzx - (2 * a)) / xn));
			int bottomfrontlefty = b + (zlocation * ((sizexzz - (2 * b)) / zn));
			
			
			jump = jump * (sizeratio);
			diag =  (float) (diag + jump);
			
			angle = (float) (Math.Atan(xn / zn));
			a = System.Convert.ToInt32(Math.Sin(angle) * diag);
			b = System.Convert.ToInt32(Math.Cos(angle) * diag);
			
			int topbackrightx = a + (int.Parse(xlocation) * ((sizexzx - (2 * a)) / xn) );
			int topbackrighty = b + ((zlocation - 1) * ((sizexzz - (2 * b)) / zn));
			int topbackleftx = a + ((int.Parse(xlocation) - 1 ) * ((sizexzx - (2 * a)) / xn));
			int topbacklefty = b + ((zlocation - 1) * ((sizexzz - (2 * b)) / zn));
			
			int bottombackrightx = a + (int.Parse(xlocation) * ((sizexzx - (2 * a)) / xn) );
			int bottombackrighty = b + (zlocation * ((sizexzz - (2 * b)) / zn));
			int bottombackleftx = a + ((int.Parse(xlocation) - 1 ) * ((sizexzx - (2 * a)) / xn));
			int bottombacklefty = b + (zlocation * ((sizexzz - (2 * b)) / zn));
			
			System.Drawing.Point topfrontright = new System.Drawing.Point(topfrontrightx, topfrontrighty);
			System.Drawing.Point topfrontleft = new System.Drawing.Point(topfrontleftx, topfrontlefty);
			System.Drawing.Point bottomfrontright = new System.Drawing.Point(bottomfrontrightx, bottomfrontrighty);
			System.Drawing.Point bottomfrontleft = new System.Drawing.Point(bottomfrontleftx, bottomfrontlefty);
			
			System.Drawing.Point topbackright = new System.Drawing.Point(topbackrightx, topbackrighty);
			System.Drawing.Point topbackleft = new System.Drawing.Point(topbackleftx, topbacklefty);
			System.Drawing.Point bottombackright = new System.Drawing.Point(bottombackrightx, bottombackrighty);
			System.Drawing.Point bottombackleft = new System.Drawing.Point(bottombackleftx, bottombacklefty);
			
			float[] dashValues = new float[] {1, 2};
			Pen graypen = new Pen(Color.Gray, 1);
			SolidBrush myBrush = new SolidBrush(colour);
			graypen.DashPattern = dashValues;
			
			//generator.gfxxz.DrawLine(Pens.Red, topfrontleftx, topfrontlefty, topfrontrightx, topfrontrighty)
			//generator.gfxxz.DrawLine(Pens.Red, bottomfrontleftx, bottomfrontlefty, bottomfrontrightx, bottomfrontrighty)
			//generator.gfxxz.DrawLine(Pens.Red, topbackleftx, topbacklefty, topbackrightx, topbackrighty)
			//generator.gfxxz.DrawLine(Pens.Red, bottombackleftx, bottombacklefty, bottombackrightx, bottombackrighty)
			
			if (direction == "down")
			{
				
				int beakx = topbackleftx + (Math.Abs(topbackleftx - topbackrightx) / 2);
				int beaky = topbacklefty + (Math.Abs(topbacklefty - bottombacklefty) / 2);
				System.Drawing.Point beak = new System.Drawing.Point(beakx, beaky);
				
				Point[] top = new Point[] {topfrontleft, beak, topfrontright};
				Point[] right = new Point[] {topfrontright, beak, bottomfrontright};
				Point[] bottom = new Point[] {bottomfrontleft, beak, bottomfrontright};
				Point[] left = new Point[] {topfrontleft, beak, bottomfrontleft};
				generator.Default.gfxxz.FillPolygon(myBrush, top);
				generator.Default.gfxxz.FillPolygon(myBrush, right);
				generator.Default.gfxxz.FillPolygon(myBrush, bottom);
				generator.Default.gfxxz.FillPolygon(myBrush, left);
				
				generator.Default.gfxxz.DrawLine(graypen, topfrontleft, beak);
				generator.Default.gfxxz.DrawLine(graypen, bottomfrontleft, beak);
				generator.Default.gfxxz.DrawLine(graypen, bottomfrontright, beak);
				generator.Default.gfxxz.DrawLine(graypen, topfrontright, beak);
				
				generator.Default.gfxxz.DrawLine(Pens.Gray, topfrontleft, topfrontright);
				generator.Default.gfxxz.DrawLine(Pens.Gray, topfrontright, bottomfrontright);
				generator.Default.gfxxz.DrawLine(Pens.Gray, bottomfrontright, bottomfrontleft);
				generator.Default.gfxxz.DrawLine(Pens.Gray, bottomfrontleft, topfrontleft);
				
			}
			else if (direction == "up")
			{
				int beakx = topfrontleftx + (Math.Abs(topfrontleftx - topfrontrightx) / 2);
				int beaky = topfrontlefty + (Math.Abs(topfrontlefty - bottomfrontlefty) / 2);
				System.Drawing.Point beak = new System.Drawing.Point(beakx, beaky);
				
				
				Point[] top = new Point[] {topbackleft, beak, topbackright};
				Point[] right = new Point[] {topbackright, beak, bottombackright};
				Point[] bottom = new Point[] {bottombackleft, beak, bottombackright};
				Point[] left = new Point[] {topbackleft, beak, bottombackleft};
				generator.Default.gfxxz.FillPolygon(myBrush, top);
				generator.Default.gfxxz.FillPolygon(myBrush, right);
				generator.Default.gfxxz.FillPolygon(myBrush, bottom);
				generator.Default.gfxxz.FillPolygon(myBrush, left);
				
				generator.Default.gfxxz.DrawLine(Pens.Gray, topbackleft, beak);
				generator.Default.gfxxz.DrawLine(Pens.Gray, bottombackleft, beak);
				generator.Default.gfxxz.DrawLine(Pens.Gray, bottombackright, beak);
				generator.Default.gfxxz.DrawLine(Pens.Gray, topbackright, beak);
				
				generator.Default.gfxxz.DrawLine(Pens.Gray, topbackleft, topbackright);
				generator.Default.gfxxz.DrawLine(Pens.Gray, topbackright, bottombackright);
				generator.Default.gfxxz.DrawLine(Pens.Gray, bottombackright, bottombackleft);
				generator.Default.gfxxz.DrawLine(Pens.Gray, bottombackleft, topbackleft);
				
			}
			else if (direction == "back")
			{
				if (zlocation <= zn / 2)
				{
					int beakx = System.Convert.ToInt32((((Math.Abs(topbackleftx - topbackrightx) / 2) + (Math.Abs(topfrontleftx - topfrontrightx) / 2)) / 2) + ((topfrontleftx + topbackleftx) / 2));
					int beaky = topfrontlefty + (Math.Abs(topfrontlefty - topbacklefty) / 2);
					System.Drawing.Point beak = new System.Drawing.Point(beakx, beaky);
					Point[] front = new Point[] {bottomfrontleft, beak, bottomfrontright};
					Point[] right = new Point[] {bottomfrontright, beak, bottombackright};
					Point[] left = new Point[] {bottomfrontleft, bottombackleft, beak};
					Point[] bottom = new Point[] {bottomfrontleft, bottombackleft, bottombackright, bottomfrontright};
					generator.Default.gfxxz.FillPolygon(myBrush, front);
					generator.Default.gfxxz.FillPolygon(myBrush, right);
					generator.Default.gfxxz.FillPolygon(myBrush, left);
					generator.Default.gfxxz.FillPolygon(myBrush, bottom);
					generator.Default.gfxxz.DrawLine(Pens.Gray, bottomfrontleft, beak);
					generator.Default.gfxxz.DrawLine(Pens.Gray, bottomfrontright, beak);
					generator.Default.gfxxz.DrawLine(Pens.Gray, bottomfrontleft, bottomfrontright);
					generator.Default.gfxxz.DrawLine(Pens.Gray, bottomfrontleft, bottombackleft);
					generator.Default.gfxxz.DrawLine(Pens.Gray, bottombackleft, bottombackright);
					generator.Default.gfxxz.DrawLine(Pens.Gray, bottombackright, bottomfrontright);
					
					float ang = (float) (Math.Atan(System.Convert.ToDouble(Math.Abs(beaky - bottombackrighty) / Math.Abs(beakx - bottombackrightx))));
					float pointx =  (float) (bottombackrightx - (Math.Abs(bottomfrontrighty - bottombackrighty) / Math.Tan(ang)));
					
					if (pointx > bottomfrontrightx)
					{
						generator.Default.gfxxz.DrawLine(Pens.Gray, bottombackright, beak);
					}
					else
					{
						generator.Default.gfxxz.DrawLine(graypen, bottombackright, beak);
					}
					
					ang = (float) (Math.Atan(System.Convert.ToDouble(Math.Abs(beaky - bottombacklefty) / Math.Abs(beakx - bottombackleftx))));
					pointx = System.Convert.ToSingle((Math.Abs(bottomfrontlefty - bottombacklefty) / Math.Tan(ang)) + bottombackleftx);
					
					
					if (pointx < bottomfrontleftx)
					{
						generator.Default.gfxxz.DrawLine(Pens.Gray, beak, bottombackleft);
					}
					else
					{
						generator.Default.gfxxz.DrawLine(graypen, beak, bottombackleft);
					}
					
				}
				else if (zlocation >= zn / 2)
				{
					int beakx = System.Convert.ToInt32((((Math.Abs(topbackleftx - topbackrightx) / 2) + (Math.Abs(topfrontleftx - topfrontrightx) / 2)) / 2) + ((topfrontleftx + topbackleftx) / 2));
					int beaky = topbacklefty + (Math.Abs(topfrontlefty - topbacklefty) / 2);
					System.Drawing.Point beak = new System.Drawing.Point(beakx, beaky);
					Point[] front = new Point[] {bottomfrontleft, beak, bottomfrontright};
					Point[] right = new Point[] {bottomfrontright, beak, bottombackright};
					Point[] left = new Point[] {bottomfrontleft, bottombackleft, beak};
					generator.Default.gfxxz.FillPolygon(myBrush, front);
					generator.Default.gfxxz.FillPolygon(myBrush, right);
					generator.Default.gfxxz.FillPolygon(myBrush, left);
					generator.Default.gfxxz.DrawLine(Pens.Gray, bottomfrontleft, beak);
					generator.Default.gfxxz.DrawLine(Pens.Gray, bottomfrontright, beak);
					generator.Default.gfxxz.DrawLine(Pens.Gray, bottomfrontleft, bottomfrontright);
					
					float ang = (float) (Math.Atan(System.Convert.ToDouble(Math.Abs(beaky - bottomfrontlefty) / Math.Abs(beakx - topfrontleftx))));
					float pointx = System.Convert.ToSingle((Math.Abs(bottombacklefty - bottomfrontlefty) / Math.Tan(ang)) + bottomfrontleftx);
					
					if (pointx < bottombackleftx)
					{
						generator.Default.gfxxz.DrawLine(graypen, bottombackleft, beak);
						generator.Default.gfxxz.DrawLine(graypen, bottombackleft, bottomfrontleft);
						generator.Default.gfxxz.DrawLine(graypen, bottombackleft, bottombackright);
					}
					else
					{
						generator.Default.gfxxz.DrawLine(Pens.Gray, bottombackleft, bottomfrontleft);
						generator.Default.gfxxz.DrawLine(Pens.Gray, bottombackleft, beak);
						generator.Default.gfxxz.DrawLine(graypen, bottombackleft, bottombackright);
					}
					
					ang = (float) (Math.Atan(System.Convert.ToDouble(Math.Abs(beaky - bottomfrontrighty) / Math.Abs(beakx - topfrontrightx))));
					pointx =  (float) (bottomfrontrightx - (Math.Abs(bottombackrighty - bottomfrontrighty) / Math.Tan(ang)));
					
					
					if (pointx < bottombackrightx)
					{
						generator.Default.gfxxz.DrawLine(Pens.Gray, beak, bottombackright);
						generator.Default.gfxxz.DrawLine(Pens.Gray, bottomfrontright, bottombackright);
					}
					else
					{
						generator.Default.gfxxz.DrawLine(graypen, beak, bottombackright);
						generator.Default.gfxxz.DrawLine(graypen, bottomfrontright, bottombackright);
					}
					
				}
				
			}
			else if (direction == "front")
			{
				if (zlocation <= zn / 2)
				{
					int beakx = System.Convert.ToInt32((((Math.Abs(bottombackleftx - bottombackrightx) / 2) + (Math.Abs(bottomfrontleftx - bottomfrontrightx) / 2)) / 2) + ((bottomfrontleftx + bottombackleftx) / 2));
					int beaky = bottomfrontlefty + (Math.Abs(bottomfrontlefty - bottombacklefty) / 2);
					System.Drawing.Point beak = new System.Drawing.Point(beakx, beaky);
					Point[] front = new Point[] {topfrontleft, beak, topfrontright};
					Point[] right = new Point[] {topfrontright, beak, topbackright};
					Point[] left = new Point[] {topfrontleft, topbackleft, beak};
					generator.Default.gfxxz.FillPolygon(myBrush, front);
					generator.Default.gfxxz.FillPolygon(myBrush, right);
					generator.Default.gfxxz.FillPolygon(myBrush, left);
					generator.Default.gfxxz.DrawLine(Pens.Gray, topfrontleft, beak);
					generator.Default.gfxxz.DrawLine(Pens.Gray, topfrontright, beak);
					generator.Default.gfxxz.DrawLine(Pens.Gray, topfrontleft, topfrontright);
					generator.Default.gfxxz.DrawLine(graypen, topbackright, topbackleft);
					
					float ang = (float) (Math.Atan(System.Convert.ToDouble(Math.Abs(beaky - topfrontrighty) / Math.Abs(beakx - topfrontrightx))));
					float pointx =  (float) (topfrontrightx - (Math.Abs(topfrontrighty - topbackrighty) / Math.Tan(ang)));
					
					if (pointx < topbackrightx)
					{
						generator.Default.gfxxz.DrawLine(Pens.Gray, topbackright, beak);
						generator.Default.gfxxz.DrawLine(Pens.Gray, topfrontright, topbackright);
					}
					else
					{
						generator.Default.gfxxz.DrawLine(graypen, topbackright, beak);
						generator.Default.gfxxz.DrawLine(graypen, topfrontright, topbackright);
					}
					
					ang = (float) (Math.Atan(System.Convert.ToDouble(Math.Abs(beaky - topfrontlefty) / Math.Abs(beakx - topfrontleftx))));
					pointx = System.Convert.ToSingle((Math.Abs(topfrontlefty - topbacklefty) / Math.Tan(ang)) + topfrontleftx);
					
					
					if (pointx > topbackleftx)
					{
						generator.Default.gfxxz.DrawLine(Pens.Gray, beak, topbackleft);
						generator.Default.gfxxz.DrawLine(Pens.Gray, topbackleft, topfrontleft);
					}
					else
					{
						generator.Default.gfxxz.DrawLine(graypen, beak, topbackleft);
						generator.Default.gfxxz.DrawLine(graypen, topbackleft, topfrontleft);
					}
					
				}
				else if (zlocation >= zn / 2)
				{
					int beakx = System.Convert.ToInt32((((Math.Abs(bottombackleftx - bottombackrightx) / 2) + (Math.Abs(bottomfrontleftx - bottomfrontrightx) / 2)) / 2) + ((bottomfrontleftx + bottombackleftx) / 2));
					int beaky = bottombacklefty + (Math.Abs(bottomfrontlefty - bottombacklefty) / 2);
					System.Drawing.Point beak = new System.Drawing.Point(beakx, beaky);
					Point[] front = new Point[] {topfrontleft, beak, topfrontright};
					Point[] right = new Point[] {topfrontright, beak, topbackright};
					Point[] left = new Point[] {topfrontleft, topbackleft, beak};
					Point[] top = new Point[] {topfrontleft, topbackleft, topbackright, topfrontright};
					generator.Default.gfxxz.FillPolygon(myBrush, front);
					generator.Default.gfxxz.FillPolygon(myBrush, right);
					generator.Default.gfxxz.FillPolygon(myBrush, left);
					generator.Default.gfxxz.FillPolygon(myBrush, top);
					generator.Default.gfxxz.DrawLine(Pens.Gray, topfrontleft, beak);
					generator.Default.gfxxz.DrawLine(Pens.Gray, topfrontright, beak);
					generator.Default.gfxxz.DrawLine(Pens.Gray, topfrontleft, topfrontright);
					
					generator.Default.gfxxz.DrawLine(Pens.Gray, topfrontleft, topbackleft);
					generator.Default.gfxxz.DrawLine(Pens.Gray, topbackleft, topbackright);
					generator.Default.gfxxz.DrawLine(Pens.Gray, topbackright, topfrontright);
					
					float ang = (float) (Math.Atan(System.Convert.ToDouble(Math.Abs(beaky - topbacklefty) / Math.Abs(beakx - bottombackleftx))));
					float pointx = System.Convert.ToSingle((Math.Abs(topfrontlefty - topbacklefty) / Math.Tan(ang)) + topbackleftx);
					
					if (pointx > topfrontleftx)
					{
						generator.Default.gfxxz.DrawLine(graypen, topbackleft, beak);
					}
					else
					{
						generator.Default.gfxxz.DrawLine(Pens.Gray, topbackleft, beak);
					}
					
					ang = (float) (Math.Atan(System.Convert.ToDouble(Math.Abs(beaky - topbackrighty) / Math.Abs(beakx - bottombackrightx))));
					pointx =  (float) (topbackrightx - (Math.Abs(topfrontrighty - topbackrighty) / Math.Tan(ang)));
					
					
					if (pointx > topfrontrightx)
					{
						generator.Default.gfxxz.DrawLine(Pens.Gray, beak, topbackright);
					}
					else
					{
						generator.Default.gfxxz.DrawLine(graypen, beak, topbackright);
					}
				}
				
				
			}
			else if (direction == "right")
			{
				if (int.Parse(xlocation) <= xn / 2 )
				{
					
					int beakx = System.Convert.ToInt32((Math.Abs(topfrontrightx - topbackrightx) / 2) + topfrontrightx);
					int beaky = System.Convert.ToInt32(Math.Abs(topfrontrighty - bottombackrighty) / 2 + topfrontlefty);
					System.Drawing.Point beak = new System.Drawing.Point(beakx, beaky);
					
					Point[] top = new Point[] {topfrontleft, topbackleft, beak};
					Point[] middle = new Point[] {topfrontleft, beak, bottomfrontleft};
					Point[] bottom = new Point[] {bottomfrontleft, bottombackleft, beak};
					
					generator.Default.gfxxz.FillPolygon(myBrush, top);
					generator.Default.gfxxz.FillPolygon(myBrush, middle);
					generator.Default.gfxxz.FillPolygon(myBrush, bottom);
					generator.Default.gfxxz.DrawLine(Pens.Gray, bottomfrontleft, beak);
					generator.Default.gfxxz.DrawLine(Pens.Gray, bottomfrontleft, topfrontleft);
					generator.Default.gfxxz.DrawLine(Pens.Gray, topfrontleft, beak);
					
					float ang = (float) (Math.Atan(System.Convert.ToDouble((Math.Abs(topfrontrighty - bottombackrighty) / 2) / ((Math.Abs(topfrontrightx - topbackrightx) / 2) + (topfrontrightx - topfrontleftx)))));
					float pointy = System.Convert.ToSingle((Math.Tan(ang) * (a - topfrontleftx)) + topfrontlefty);
					
					if (topbacklefty < pointy)
					{
						generator.Default.gfxxz.DrawLine(Pens.Gray, topbackleft, beak);
						generator.Default.gfxxz.DrawLine(Pens.Gray, topfrontleft, topbackleft);
					}
					else
					{
						generator.Default.gfxxz.DrawLine(graypen, topfrontleft, topbackleft);
						generator.Default.gfxxz.DrawLine(graypen, topbackleft, beak);
					}
					
					pointy =  (float) (bottomfrontlefty - (Math.Tan(ang) * (a - topfrontleftx)));
					
					if (bottombacklefty < pointy)
					{
						generator.Default.gfxxz.DrawLine(graypen, bottomfrontleft, bottombackleft);
						generator.Default.gfxxz.DrawLine(graypen, bottombackleft, beak);
					}
					else
					{
						generator.Default.gfxxz.DrawLine(Pens.Gray, bottomfrontleft, bottombackleft);
						generator.Default.gfxxz.DrawLine(Pens.Gray, bottombackleft, beak);
					}
					
					generator.Default.gfxxz.DrawLine(graypen, topbackleft, bottombackleft);
					
					
				}
				else if (int.Parse(xlocation) >= xn / 2 )
				{
					
					int beakx = topfrontrightx - (Math.Abs(topfrontrightx - topbackrightx) / 2);
					int beaky = System.Convert.ToInt32(Math.Abs(topfrontrighty - bottombackrighty) / 2 + topfrontlefty);
					System.Drawing.Point beak = new System.Drawing.Point(beakx, beaky);
					
					Point[] top = new Point[] {topfrontleft, topbackleft, beak};
					Point[] middle = new Point[] {topfrontleft, beak, bottomfrontleft};
					Point[] bottom = new Point[] {bottomfrontleft, bottombackleft, beak};
					Point[] back = new Point[] {topfrontleft, bottomfrontleft, bottombackleft, topbackleft};
					
					generator.Default.gfxxz.FillPolygon(myBrush, top);
					generator.Default.gfxxz.FillPolygon(myBrush, middle);
					generator.Default.gfxxz.FillPolygon(myBrush, bottom);
					generator.Default.gfxxz.FillPolygon(myBrush, back);
					
					generator.Default.gfxxz.DrawLine(Pens.Gray, topfrontleft, bottomfrontleft);
					generator.Default.gfxxz.DrawLine(Pens.Gray, bottomfrontleft, bottombackleft);
					generator.Default.gfxxz.DrawLine(Pens.Gray, bottombackleft, topbackleft);
					generator.Default.gfxxz.DrawLine(Pens.Gray, topbackleft, topfrontleft);
					generator.Default.gfxxz.DrawLine(Pens.Gray, bottomfrontleft, beak);
					
					generator.Default.gfxxz.DrawLine(Pens.Gray, topfrontleft, beak);
					
					
					float ang;
					ang = (float) (Math.Atan(System.Convert.ToDouble((Math.Abs(beaky - bottombacklefty)) / (Math.Abs(beakx - bottombackleftx)))));
					float pointy;
					pointy =  (float) (bottombacklefty - (Math.Tan(ang) * (Math.Abs(topfrontleftx - topbackleftx))));
					if (pointy > bottomfrontlefty)
					{
						generator.Default.gfxxz.DrawLine(Pens.Gray, bottombackleft, beak);
					}
					else
					{
						generator.Default.gfxxz.DrawLine(graypen, bottombackleft, beak);
					}
					
					ang = (float) (Math.Atan(System.Convert.ToDouble((Math.Abs(beaky - topbacklefty)) / (Math.Abs(beakx - topbackleftx)))));
					pointy =  (float) (topbacklefty + (Math.Tan(ang) * (Math.Abs(topfrontleftx - topbackleftx))));
					
					if (pointy < topfrontlefty)
					{
						generator.Default.gfxxz.DrawLine(Pens.Gray, topbackleft, beak);
					}
					else
					{
						generator.Default.gfxxz.DrawLine(graypen, topbackleft, beak);
					}
				}
				
				
			}
			else if (direction == "left")
			{
				if (int.Parse(xlocation) <= xn / 2 )
				{
					int beakx = topfrontleftx + (Math.Abs(topfrontleftx - topbackleftx) / 2);
					int beaky = System.Convert.ToInt32((Math.Abs(bottomfrontlefty - topbacklefty) / 2) + topbacklefty);
					System.Drawing.Point beak = new System.Drawing.Point(beakx, beaky);
					
					Point[] top = new Point[] {topfrontright, topbackright, beak};
					Point[] middle = new Point[] {topfrontright, beak, bottomfrontright};
					Point[] bottom = new Point[] {bottomfrontright, bottombackright, beak};
					Point[] back = new Point[] {bottomfrontright, bottombackright, topbackright, topfrontright};
					
					generator.Default.gfxxz.FillPolygon(myBrush, top);
					generator.Default.gfxxz.FillPolygon(myBrush, middle);
					generator.Default.gfxxz.FillPolygon(myBrush, bottom);
					generator.Default.gfxxz.FillPolygon(myBrush, back);
					generator.Default.gfxxz.DrawLine(Pens.Gray, bottomfrontright, beak);
					generator.Default.gfxxz.DrawLine(Pens.Gray, bottomfrontright, topfrontright);
					generator.Default.gfxxz.DrawLine(Pens.Gray, topfrontright, beak);
					generator.Default.gfxxz.DrawLine(Pens.Gray, topfrontright, topbackright);
					generator.Default.gfxxz.DrawLine(Pens.Gray, topbackright, bottombackright);
					generator.Default.gfxxz.DrawLine(Pens.Gray, bottombackright, bottomfrontright);
					
					float ang = (float) (Math.Atan(System.Convert.ToDouble(Math.Abs(beakx - topbackrightx) / Math.Abs(beaky - topbackrighty))));
					float pointy =  (float) (topbackrighty + ((topbackrightx - topfrontrightx) / Math.Tan(ang)));
					
					if (topfrontrighty > pointy)
					{
						generator.Default.gfxxz.DrawLine(Pens.Gray, topbackright, beak);
					}
					else
					{
						generator.Default.gfxxz.DrawLine(graypen, topbackright, beak);
					}
					
					ang = (float) (Math.Atan(System.Convert.ToDouble(Math.Abs(beakx - bottombackrightx) / Math.Abs(beaky - bottombackrighty))));
					pointy =  (float) (bottombackrighty - ((bottombackrightx - bottomfrontrightx) / Math.Tan(ang)));
					
					if (bottomfrontrighty < pointy)
					{
						generator.Default.gfxxz.DrawLine(Pens.Gray, bottombackright, beak);
					}
					else
					{
						generator.Default.gfxxz.DrawLine(graypen, bottombackright, beak);
					}
					
				}
				else if (int.Parse(xlocation) > xn / 2 )
				{
					int beakx = topfrontleftx - (Math.Abs(topfrontleftx - topbackleftx) / 2);
					int beaky = System.Convert.ToInt32((Math.Abs(bottomfrontlefty - topbacklefty) / 2) + topbacklefty);
					System.Drawing.Point beak = new System.Drawing.Point(beakx, beaky);
					Point[] top = new Point[] {topfrontright, topbackright, beak};
					Point[] middle = new Point[] {topfrontright, beak, bottomfrontright};
					Point[] bottom = new Point[] {bottomfrontright, bottombackright, beak};
					generator.Default.gfxxz.FillPolygon(myBrush, top);
					generator.Default.gfxxz.FillPolygon(myBrush, middle);
					generator.Default.gfxxz.FillPolygon(myBrush, bottom);
					generator.Default.gfxxz.DrawLine(Pens.Gray, bottomfrontright, beak);
					generator.Default.gfxxz.DrawLine(Pens.Gray, bottomfrontright, topfrontright);
					generator.Default.gfxxz.DrawLine(Pens.Gray, topfrontright, beak);
					generator.Default.gfxxz.DrawLine(graypen, topbackright, bottombackright);
					
					float ang = (float) (Math.Atan(System.Convert.ToDouble(Math.Abs(beakx - topfrontrightx) / Math.Abs(beaky - topfrontrighty))));
					float pointy =  (float) (topfrontrighty + ((topfrontrightx - topbackrightx) / Math.Tan(ang)));
					
					if (topbackrighty < pointy)
					{
						generator.Default.gfxxz.DrawLine(Pens.Gray, topbackright, beak);
						generator.Default.gfxxz.DrawLine(Pens.Gray, topfrontright, topbackright);
					}
					else
					{
						generator.Default.gfxxz.DrawLine(graypen, topbackright, beak);
						generator.Default.gfxxz.DrawLine(graypen, topfrontright, topbackright);
					}
					
					ang = (float) (Math.Atan(System.Convert.ToDouble(Math.Abs(beakx - bottomfrontrightx) / Math.Abs(beaky - bottomfrontrighty))));
					pointy =  (float) (bottomfrontrighty - ((bottomfrontrightx - bottombackrightx) / Math.Tan(ang)));
					
					if (bottombackrighty > pointy)
					{
						generator.Default.gfxxz.DrawLine(Pens.Gray, bottombackright, beak);
						generator.Default.gfxxz.DrawLine(Pens.Gray, bottombackright, bottomfrontright);
					}
					else
					{
						generator.Default.gfxxz.DrawLine(graypen, bottombackright, beak);
						generator.Default.gfxxz.DrawLine(graypen, bottombackright, bottomfrontright);
					}
					
				}
				
			}
			
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		public void creatorzy(string xlocation, int ylocation, int zlocation, string direction, System.Drawing.Color colour)
		{
			zlocation = System.Convert.ToInt32((zn - zlocation) + 1);
			float diag = System.Convert.ToSingle(0);
			double jump = cellzyz;
			for (var i = 1; i <= int.Parse(xlocation) - 1 ; i++)
			{
				jump = jump * (sizeratio);
				diag =  (float) (diag + jump);
			}
			float angle = (float) (Math.Atan(zn / yn));
			int a = System.Convert.ToInt32(Math.Sin(angle) * diag);
			int b = System.Convert.ToInt32(Math.Cos(angle) * diag);
			
			int topfrontrightx = a + (zlocation * ((sizezyz - (2 * a)) / zn));
			int topfrontrighty = b + ((ylocation - 1) * ((sizezyy - (2 * b)) / yn));
			int topfrontleftx = a + ((zlocation - 1) * ((sizezyz - (2 * a)) / zn));
			int topfrontlefty = b + ((ylocation - 1) * ((sizezyy - (2 * b)) / yn));
			
			int bottomfrontrightx = a + (zlocation * ((sizezyz - (2 * a)) / zn));
			int bottomfrontrighty = b + (ylocation * ((sizezyy - (2 * b)) / yn));
			int bottomfrontleftx = a + ((zlocation - 1) * ((sizezyz - (2 * a)) / zn));
			int bottomfrontlefty = b + (ylocation * ((sizezyy - (2 * b)) / yn));
			
			jump = jump * (sizeratio);
			diag =  (float) (diag + jump);
			
			angle = (float) (Math.Atan(zn / yn));
			a = System.Convert.ToInt32(Math.Sin(angle) * diag);
			b = System.Convert.ToInt32(Math.Cos(angle) * diag);
			
			int topbackrightx = a + (zlocation * ((sizezyz - (2 * a)) / zn));
			int topbackrighty = b + ((ylocation - 1) * ((sizezyy - (2 * b)) / yn));
			int topbackleftx = a + ((zlocation - 1) * ((sizezyz - (2 * a)) / zn));
			int topbacklefty = b + ((ylocation - 1) * ((sizezyy - (2 * b)) / yn));
			
			int bottombackrightx = a + (zlocation * ((sizezyz - (2 * a)) / zn));
			int bottombackrighty = b + (ylocation * ((sizezyy - (2 * b)) / yn));
			int bottombackleftx = a + ((zlocation - 1) * ((sizezyz - (2 * a)) / zn));
			int bottombacklefty = b + (ylocation * ((sizezyy - (2 * b)) / yn));
			
			System.Drawing.Point topfrontright = new System.Drawing.Point(topfrontrightx, topfrontrighty);
			System.Drawing.Point topfrontleft = new System.Drawing.Point(topfrontleftx, topfrontlefty);
			System.Drawing.Point bottomfrontright = new System.Drawing.Point(bottomfrontrightx, bottomfrontrighty);
			System.Drawing.Point bottomfrontleft = new System.Drawing.Point(bottomfrontleftx, bottomfrontlefty);
			
			System.Drawing.Point topbackright = new System.Drawing.Point(topbackrightx, topbackrighty);
			System.Drawing.Point topbackleft = new System.Drawing.Point(topbackleftx, topbacklefty);
			System.Drawing.Point bottombackright = new System.Drawing.Point(bottombackrightx, bottombackrighty);
			System.Drawing.Point bottombackleft = new System.Drawing.Point(bottombackleftx, bottombacklefty);
			
			float[] dashValues = new float[] {1, 2};
			Pen graypen = new Pen(Color.Gray, 1);
			SolidBrush myBrush = new SolidBrush(colour);
			graypen.DashPattern = dashValues;
			
			if (direction == "right")
			{
				
				int beakx = topbackleftx + (Math.Abs(topbackleftx - topbackrightx) / 2);
				int beaky = topbacklefty + (Math.Abs(topbacklefty - bottombacklefty) / 2);
				System.Drawing.Point beak = new System.Drawing.Point(beakx, beaky);
				
				Point[] top = new Point[] {topfrontleft, beak, topfrontright};
				Point[] right = new Point[] {topfrontright, beak, bottomfrontright};
				Point[] bottom = new Point[] {bottomfrontleft, beak, bottomfrontright};
				Point[] left = new Point[] {topfrontleft, beak, bottomfrontleft};
				generator.Default.gfxzy.FillPolygon(myBrush, top);
				generator.Default.gfxzy.FillPolygon(myBrush, right);
				generator.Default.gfxzy.FillPolygon(myBrush, bottom);
				generator.Default.gfxzy.FillPolygon(myBrush, left);
				
				generator.Default.gfxzy.DrawLine(graypen, topfrontleft, beak);
				generator.Default.gfxzy.DrawLine(graypen, bottomfrontleft, beak);
				generator.Default.gfxzy.DrawLine(graypen, bottomfrontright, beak);
				generator.Default.gfxzy.DrawLine(graypen, topfrontright, beak);
				
				generator.Default.gfxzy.DrawLine(Pens.Gray, topfrontleft, topfrontright);
				generator.Default.gfxzy.DrawLine(Pens.Gray, topfrontright, bottomfrontright);
				generator.Default.gfxzy.DrawLine(Pens.Gray, bottomfrontright, bottomfrontleft);
				generator.Default.gfxzy.DrawLine(Pens.Gray, bottomfrontleft, topfrontleft);
				
			}
			else if (direction == "left")
			{
				int beakx = topfrontleftx + (Math.Abs(topfrontleftx - topfrontrightx) / 2);
				int beaky = topfrontlefty + (Math.Abs(topfrontlefty - bottomfrontlefty) / 2);
				System.Drawing.Point beak = new System.Drawing.Point(beakx, beaky);
				
				
				Point[] top = new Point[] {topbackleft, beak, topbackright};
				Point[] right = new Point[] {topbackright, beak, bottombackright};
				Point[] bottom = new Point[] {bottombackleft, beak, bottombackright};
				Point[] left = new Point[] {topbackleft, beak, bottombackleft};
				generator.Default.gfxzy.FillPolygon(myBrush, top);
				generator.Default.gfxzy.FillPolygon(myBrush, right);
				generator.Default.gfxzy.FillPolygon(myBrush, bottom);
				generator.Default.gfxzy.FillPolygon(myBrush, left);
				
				generator.Default.gfxzy.DrawLine(Pens.Gray, topbackleft, beak);
				generator.Default.gfxzy.DrawLine(Pens.Gray, bottombackleft, beak);
				generator.Default.gfxzy.DrawLine(Pens.Gray, bottombackright, beak);
				generator.Default.gfxzy.DrawLine(Pens.Gray, topbackright, beak);
				
				generator.Default.gfxzy.DrawLine(Pens.Gray, topbackleft, topbackright);
				generator.Default.gfxzy.DrawLine(Pens.Gray, topbackright, bottombackright);
				generator.Default.gfxzy.DrawLine(Pens.Gray, bottombackright, bottombackleft);
				generator.Default.gfxzy.DrawLine(Pens.Gray, bottombackleft, topbackleft);
				
			}
			else if (direction == "up")
			{
				if (ylocation <= yn / 2)
				{
					int beakx = System.Convert.ToInt32((((Math.Abs(topbackleftx - topbackrightx) / 2) + (Math.Abs(topfrontleftx - topfrontrightx) / 2)) / 2) + ((topfrontleftx + topbackleftx) / 2));
					int beaky = topfrontlefty + (Math.Abs(topfrontlefty - topbacklefty) / 2);
					System.Drawing.Point beak = new System.Drawing.Point(beakx, beaky);
					Point[] front = new Point[] {bottomfrontleft, beak, bottomfrontright};
					Point[] right = new Point[] {bottomfrontright, beak, bottombackright};
					Point[] left = new Point[] {bottomfrontleft, bottombackleft, beak};
					Point[] bottom = new Point[] {bottomfrontleft, bottombackleft, bottombackright, bottomfrontright};
					generator.Default.gfxzy.FillPolygon(myBrush, front);
					generator.Default.gfxzy.FillPolygon(myBrush, right);
					generator.Default.gfxzy.FillPolygon(myBrush, left);
					generator.Default.gfxzy.FillPolygon(myBrush, bottom);
					generator.Default.gfxzy.DrawLine(Pens.Gray, bottomfrontleft, beak);
					generator.Default.gfxzy.DrawLine(Pens.Gray, bottomfrontright, beak);
					generator.Default.gfxzy.DrawLine(Pens.Gray, bottomfrontleft, bottomfrontright);
					generator.Default.gfxzy.DrawLine(Pens.Gray, bottomfrontleft, bottombackleft);
					generator.Default.gfxzy.DrawLine(Pens.Gray, bottombackleft, bottombackright);
					generator.Default.gfxzy.DrawLine(Pens.Gray, bottombackright, bottomfrontright);
					
					float ang = (float) (Math.Atan(System.Convert.ToDouble(Math.Abs(beaky - bottombackrighty) / Math.Abs(beakx - bottombackrightx))));
					float pointx =  (float) (bottombackrightx - (Math.Abs(bottomfrontrighty - bottombackrighty) / Math.Tan(ang)));
					
					if (pointx > bottomfrontrightx)
					{
						generator.Default.gfxzy.DrawLine(Pens.Gray, bottombackright, beak);
					}
					else
					{
						generator.Default.gfxzy.DrawLine(graypen, bottombackright, beak);
					}
					
					ang = (float) (Math.Atan(System.Convert.ToDouble(Math.Abs(beaky - bottombacklefty) / Math.Abs(beakx - bottombackleftx))));
					pointx = System.Convert.ToSingle((Math.Abs(bottomfrontlefty - bottombacklefty) / Math.Tan(ang)) + bottombackleftx);
					
					
					if (pointx < bottomfrontleftx)
					{
						generator.Default.gfxzy.DrawLine(Pens.Gray, beak, bottombackleft);
					}
					else
					{
						generator.Default.gfxzy.DrawLine(graypen, beak, bottombackleft);
					}
					
				}
				else if (ylocation >= yn / 2)
				{
					int beakx = System.Convert.ToInt32((((Math.Abs(topbackleftx - topbackrightx) / 2) + (Math.Abs(topfrontleftx - topfrontrightx) / 2)) / 2) + ((topfrontleftx + topbackleftx) / 2));
					int beaky = topbacklefty + (Math.Abs(topfrontlefty - topbacklefty) / 2);
					System.Drawing.Point beak = new System.Drawing.Point(beakx, beaky);
					Point[] front = new Point[] {bottomfrontleft, beak, bottomfrontright};
					Point[] right = new Point[] {bottomfrontright, beak, bottombackright};
					Point[] left = new Point[] {bottomfrontleft, bottombackleft, beak};
					generator.Default.gfxzy.FillPolygon(myBrush, front);
					generator.Default.gfxzy.FillPolygon(myBrush, right);
					generator.Default.gfxzy.FillPolygon(myBrush, left);
					generator.Default.gfxzy.DrawLine(Pens.Gray, bottomfrontleft, beak);
					generator.Default.gfxzy.DrawLine(Pens.Gray, bottomfrontright, beak);
					generator.Default.gfxzy.DrawLine(Pens.Gray, bottomfrontleft, bottomfrontright);
					
					float ang = (float) (Math.Atan(System.Convert.ToDouble(Math.Abs(beaky - bottomfrontlefty) / Math.Abs(beakx - topfrontleftx))));
					float pointx = System.Convert.ToSingle((Math.Abs(bottombacklefty - bottomfrontlefty) / Math.Tan(ang)) + bottomfrontleftx);
					
					if (pointx < bottombackleftx)
					{
						generator.Default.gfxzy.DrawLine(graypen, bottombackleft, beak);
						generator.Default.gfxzy.DrawLine(graypen, bottombackleft, bottomfrontleft);
						generator.Default.gfxzy.DrawLine(graypen, bottombackleft, bottombackright);
					}
					else
					{
						generator.Default.gfxzy.DrawLine(Pens.Gray, bottombackleft, bottomfrontleft);
						generator.Default.gfxzy.DrawLine(Pens.Gray, bottombackleft, beak);
						generator.Default.gfxzy.DrawLine(graypen, bottombackleft, bottombackright);
					}
					
					ang = (float) (Math.Atan(System.Convert.ToDouble(Math.Abs(beaky - bottomfrontrighty) / Math.Abs(beakx - topfrontrightx))));
					pointx =  (float) (bottomfrontrightx - (Math.Abs(bottombackrighty - bottomfrontrighty) / Math.Tan(ang)));
					
					
					if (pointx < bottombackrightx)
					{
						generator.Default.gfxzy.DrawLine(Pens.Gray, beak, bottombackright);
						generator.Default.gfxzy.DrawLine(Pens.Gray, bottomfrontright, bottombackright);
					}
					else
					{
						generator.Default.gfxzy.DrawLine(graypen, beak, bottombackright);
						generator.Default.gfxzy.DrawLine(graypen, bottomfrontright, bottombackright);
					}
					
				}
				
			}
			else if (direction == "down")
			{
				if (ylocation <= yn / 2)
				{
					int beakx = System.Convert.ToInt32((((Math.Abs(bottombackleftx - bottombackrightx) / 2) + (Math.Abs(bottomfrontleftx - bottomfrontrightx) / 2)) / 2) + ((bottomfrontleftx + bottombackleftx) / 2));
					int beaky = bottomfrontlefty + (Math.Abs(bottomfrontlefty - bottombacklefty) / 2);
					System.Drawing.Point beak = new System.Drawing.Point(beakx, beaky);
					Point[] front = new Point[] {topfrontleft, beak, topfrontright};
					Point[] right = new Point[] {topfrontright, beak, topbackright};
					Point[] left = new Point[] {topfrontleft, topbackleft, beak};
					generator.Default.gfxzy.FillPolygon(myBrush, front);
					generator.Default.gfxzy.FillPolygon(myBrush, right);
					generator.Default.gfxzy.FillPolygon(myBrush, left);
					generator.Default.gfxzy.DrawLine(Pens.Gray, topfrontleft, beak);
					generator.Default.gfxzy.DrawLine(Pens.Gray, topfrontright, beak);
					generator.Default.gfxzy.DrawLine(Pens.Gray, topfrontleft, topfrontright);
					generator.Default.gfxzy.DrawLine(graypen, topbackright, topbackleft);
					
					float ang = (float) (Math.Atan(System.Convert.ToDouble(Math.Abs(beaky - topfrontrighty) / Math.Abs(beakx - topfrontrightx))));
					float pointx =  (float) (topfrontrightx - (Math.Abs(topfrontrighty - topbackrighty) / Math.Tan(ang)));
					
					if (pointx < topbackrightx)
					{
						generator.Default.gfxzy.DrawLine(Pens.Gray, topbackright, beak);
						generator.Default.gfxzy.DrawLine(Pens.Gray, topfrontright, topbackright);
					}
					else
					{
						generator.Default.gfxzy.DrawLine(graypen, topbackright, beak);
						generator.Default.gfxzy.DrawLine(graypen, topfrontright, topbackright);
					}
					
					ang = (float) (Math.Atan(System.Convert.ToDouble(Math.Abs(beaky - topfrontlefty) / Math.Abs(beakx - topfrontleftx))));
					pointx = System.Convert.ToSingle((Math.Abs(topfrontlefty - topbacklefty) / Math.Tan(ang)) + topfrontleftx);
					
					
					if (pointx > topbackleftx)
					{
						generator.Default.gfxzy.DrawLine(Pens.Gray, beak, topbackleft);
						generator.Default.gfxzy.DrawLine(Pens.Gray, topbackleft, topfrontleft);
					}
					else
					{
						generator.Default.gfxzy.DrawLine(graypen, beak, topbackleft);
						generator.Default.gfxzy.DrawLine(graypen, topbackleft, topfrontleft);
					}
					
				}
				else if (ylocation >= yn / 2)
				{
					int beakx = System.Convert.ToInt32((((Math.Abs(bottombackleftx - bottombackrightx) / 2) + (Math.Abs(bottomfrontleftx - bottomfrontrightx) / 2)) / 2) + ((bottomfrontleftx + bottombackleftx) / 2));
					int beaky = bottombacklefty + (Math.Abs(bottomfrontlefty - bottombacklefty) / 2);
					System.Drawing.Point beak = new System.Drawing.Point(beakx, beaky);
					Point[] front = new Point[] {topfrontleft, beak, topfrontright};
					Point[] right = new Point[] {topfrontright, beak, topbackright};
					Point[] left = new Point[] {topfrontleft, topbackleft, beak};
					Point[] top = new Point[] {topfrontleft, topbackleft, topbackright, topfrontright};
					generator.Default.gfxzy.FillPolygon(myBrush, front);
					generator.Default.gfxzy.FillPolygon(myBrush, right);
					generator.Default.gfxzy.FillPolygon(myBrush, left);
					generator.Default.gfxzy.FillPolygon(myBrush, top);
					generator.Default.gfxzy.DrawLine(Pens.Gray, topfrontleft, beak);
					generator.Default.gfxzy.DrawLine(Pens.Gray, topfrontright, beak);
					generator.Default.gfxzy.DrawLine(Pens.Gray, topfrontleft, topfrontright);
					
					generator.Default.gfxzy.DrawLine(Pens.Gray, topfrontleft, topbackleft);
					generator.Default.gfxzy.DrawLine(Pens.Gray, topbackleft, topbackright);
					generator.Default.gfxzy.DrawLine(Pens.Gray, topbackright, topfrontright);
					
					float ang = (float) (Math.Atan(System.Convert.ToDouble(Math.Abs(beaky - topbacklefty) / Math.Abs(beakx - bottombackleftx))));
					float pointx = System.Convert.ToSingle((Math.Abs(topfrontlefty - topbacklefty) / Math.Tan(ang)) + topbackleftx);
					
					if (pointx > topfrontleftx)
					{
						generator.Default.gfxzy.DrawLine(graypen, topbackleft, beak);
					}
					else
					{
						generator.Default.gfxzy.DrawLine(Pens.Gray, topbackleft, beak);
					}
					
					ang = (float) (Math.Atan(System.Convert.ToDouble(Math.Abs(beaky - topbackrighty) / Math.Abs(beakx - bottombackrightx))));
					pointx =  (float) (topbackrightx - (Math.Abs(topfrontrighty - topbackrighty) / Math.Tan(ang)));
					
					
					if (pointx > topfrontrightx)
					{
						generator.Default.gfxzy.DrawLine(Pens.Gray, beak, topbackright);
					}
					else
					{
						generator.Default.gfxzy.DrawLine(graypen, beak, topbackright);
					}
				}
				
				
			}
			else if (direction == "front")
			{
				if (zlocation <= zn / 2)
				{
					
					int beakx = System.Convert.ToInt32((Math.Abs(topfrontrightx - topbackrightx) / 2) + topfrontrightx);
					int beaky = System.Convert.ToInt32(Math.Abs(topfrontrighty - bottombackrighty) / 2 + topfrontlefty);
					System.Drawing.Point beak = new System.Drawing.Point(beakx, beaky);
					
					Point[] top = new Point[] {topfrontleft, topbackleft, beak};
					Point[] middle = new Point[] {topfrontleft, beak, bottomfrontleft};
					Point[] bottom = new Point[] {bottomfrontleft, bottombackleft, beak};
					
					generator.Default.gfxzy.FillPolygon(myBrush, top);
					generator.Default.gfxzy.FillPolygon(myBrush, middle);
					generator.Default.gfxzy.FillPolygon(myBrush, bottom);
					generator.Default.gfxzy.DrawLine(Pens.Gray, bottomfrontleft, beak);
					generator.Default.gfxzy.DrawLine(Pens.Gray, bottomfrontleft, topfrontleft);
					generator.Default.gfxzy.DrawLine(Pens.Gray, topfrontleft, beak);
					
					float ang = (float) (Math.Atan(System.Convert.ToDouble((Math.Abs(topfrontrighty - bottombackrighty) / 2) / ((Math.Abs(topfrontrightx - topbackrightx) / 2) + (topfrontrightx - topfrontleftx)))));
					float pointy = System.Convert.ToSingle((Math.Tan(ang) * (a - topfrontleftx)) + topfrontlefty);
					
					if (topbacklefty < pointy)
					{
						generator.Default.gfxzy.DrawLine(Pens.Gray, topbackleft, beak);
						generator.Default.gfxzy.DrawLine(Pens.Gray, topfrontleft, topbackleft);
					}
					else
					{
						generator.Default.gfxzy.DrawLine(graypen, topfrontleft, topbackleft);
						generator.Default.gfxzy.DrawLine(graypen, topbackleft, beak);
					}
					
					pointy =  (float) (bottomfrontlefty - (Math.Tan(ang) * (a - topfrontleftx)));
					
					if (bottombacklefty < pointy)
					{
						generator.Default.gfxzy.DrawLine(graypen, bottomfrontleft, bottombackleft);
						generator.Default.gfxzy.DrawLine(graypen, bottombackleft, beak);
					}
					else
					{
						generator.Default.gfxzy.DrawLine(Pens.Gray, bottomfrontleft, bottombackleft);
						generator.Default.gfxzy.DrawLine(Pens.Gray, bottombackleft, beak);
					}
					
					generator.Default.gfxzy.DrawLine(graypen, topbackleft, bottombackleft);
					
					
				}
				else if (zlocation >= zn / 2)
				{
					
					int beakx = topfrontrightx - (Math.Abs(topfrontrightx - topbackrightx) / 2);
					int beaky = System.Convert.ToInt32(Math.Abs(topfrontrighty - bottombackrighty) / 2 + topfrontlefty);
					System.Drawing.Point beak = new System.Drawing.Point(beakx, beaky);
					
					Point[] top = new Point[] {topfrontleft, topbackleft, beak};
					Point[] middle = new Point[] {topfrontleft, beak, bottomfrontleft};
					Point[] bottom = new Point[] {bottomfrontleft, bottombackleft, beak};
					Point[] back = new Point[] {topfrontleft, bottomfrontleft, bottombackleft, topbackleft};
					
					generator.Default.gfxzy.FillPolygon(myBrush, top);
					generator.Default.gfxzy.FillPolygon(myBrush, middle);
					generator.Default.gfxzy.FillPolygon(myBrush, bottom);
					generator.Default.gfxzy.FillPolygon(myBrush, back);
					
					generator.Default.gfxzy.DrawLine(Pens.Gray, topfrontleft, bottomfrontleft);
					generator.Default.gfxzy.DrawLine(Pens.Gray, bottomfrontleft, bottombackleft);
					generator.Default.gfxzy.DrawLine(Pens.Gray, bottombackleft, topbackleft);
					generator.Default.gfxzy.DrawLine(Pens.Gray, topbackleft, topfrontleft);
					generator.Default.gfxzy.DrawLine(Pens.Gray, bottomfrontleft, beak);
					
					generator.Default.gfxzy.DrawLine(Pens.Gray, topfrontleft, beak);
					
					
					float ang;
					ang = (float) (Math.Atan(System.Convert.ToDouble((Math.Abs(beaky - bottombacklefty)) / (Math.Abs(beakx - bottombackleftx)))));
					float pointy;
					pointy =  (float) (bottombacklefty - (Math.Tan(ang) * (Math.Abs(topfrontleftx - topbackleftx))));
					if (pointy > bottomfrontlefty)
					{
						generator.Default.gfxzy.DrawLine(Pens.Gray, bottombackleft, beak);
					}
					else
					{
						generator.Default.gfxzy.DrawLine(graypen, bottombackleft, beak);
					}
					
					ang = (float) (Math.Atan(System.Convert.ToDouble((Math.Abs(beaky - topbacklefty)) / (Math.Abs(beakx - topbackleftx)))));
					pointy =  (float) (topbacklefty + (Math.Tan(ang) * (Math.Abs(topfrontleftx - topbackleftx))));
					
					if (pointy < topfrontlefty)
					{
						generator.Default.gfxzy.DrawLine(Pens.Gray, topbackleft, beak);
					}
					else
					{
						generator.Default.gfxzy.DrawLine(graypen, topbackleft, beak);
					}
				}
				
				
			}
			else if (direction == "back")
			{
				if (zlocation <= zn / 2)
				{
					int beakx = topfrontleftx + (Math.Abs(topfrontleftx - topbackleftx) / 2);
					int beaky = System.Convert.ToInt32((Math.Abs(bottomfrontlefty - topbacklefty) / 2) + topbacklefty);
					System.Drawing.Point beak = new System.Drawing.Point(beakx, beaky);
					
					Point[] top = new Point[] {topfrontright, topbackright, beak};
					Point[] middle = new Point[] {topfrontright, beak, bottomfrontright};
					Point[] bottom = new Point[] {bottomfrontright, bottombackright, beak};
					Point[] back = new Point[] {bottomfrontright, bottombackright, topbackright, topfrontright};
					
					generator.Default.gfxzy.FillPolygon(myBrush, top);
					generator.Default.gfxzy.FillPolygon(myBrush, middle);
					generator.Default.gfxzy.FillPolygon(myBrush, bottom);
					generator.Default.gfxzy.FillPolygon(myBrush, back);
					generator.Default.gfxzy.DrawLine(Pens.Gray, bottomfrontright, beak);
					generator.Default.gfxzy.DrawLine(Pens.Gray, bottomfrontright, topfrontright);
					generator.Default.gfxzy.DrawLine(Pens.Gray, topfrontright, beak);
					generator.Default.gfxzy.DrawLine(Pens.Gray, topfrontright, topbackright);
					generator.Default.gfxzy.DrawLine(Pens.Gray, topbackright, bottombackright);
					generator.Default.gfxzy.DrawLine(Pens.Gray, bottombackright, bottomfrontright);
					
					float ang = (float) (Math.Atan(System.Convert.ToDouble(Math.Abs(beakx - topbackrightx) / Math.Abs(beaky - topbackrighty))));
					float pointy =  (float) (topbackrighty + ((topbackrightx - topfrontrightx) / Math.Tan(ang)));
					
					if (topfrontrighty > pointy)
					{
						generator.Default.gfxzy.DrawLine(Pens.Gray, topbackright, beak);
					}
					else
					{
						generator.Default.gfxzy.DrawLine(graypen, topbackright, beak);
					}
					
					ang = (float) (Math.Atan(System.Convert.ToDouble(Math.Abs(beakx - bottombackrightx) / Math.Abs(beaky - bottombackrighty))));
					pointy =  (float) (bottombackrighty - ((bottombackrightx - bottomfrontrightx) / Math.Tan(ang)));
					
					if (bottomfrontrighty < pointy)
					{
						generator.Default.gfxzy.DrawLine(Pens.Gray, bottombackright, beak);
					}
					else
					{
						generator.Default.gfxzy.DrawLine(graypen, bottombackright, beak);
					}
					
				}
				else if (zlocation > zn / 2)
				{
					int beakx = topfrontleftx - (Math.Abs(topfrontleftx - topbackleftx) / 2);
					int beaky = System.Convert.ToInt32((Math.Abs(bottomfrontlefty - topbacklefty) / 2) + topbacklefty);
					System.Drawing.Point beak = new System.Drawing.Point(beakx, beaky);
					Point[] top = new Point[] {topfrontright, topbackright, beak};
					Point[] middle = new Point[] {topfrontright, beak, bottomfrontright};
					Point[] bottom = new Point[] {bottomfrontright, bottombackright, beak};
					generator.Default.gfxzy.FillPolygon(myBrush, top);
					generator.Default.gfxzy.FillPolygon(myBrush, middle);
					generator.Default.gfxzy.FillPolygon(myBrush, bottom);
					generator.Default.gfxzy.DrawLine(Pens.Gray, bottomfrontright, beak);
					generator.Default.gfxzy.DrawLine(Pens.Gray, bottomfrontright, topfrontright);
					generator.Default.gfxzy.DrawLine(Pens.Gray, topfrontright, beak);
					generator.Default.gfxzy.DrawLine(graypen, topbackright, bottombackright);
					
					float ang = (float) (Math.Atan(System.Convert.ToDouble(Math.Abs(beakx - topfrontrightx) / Math.Abs(beaky - topfrontrighty))));
					float pointy =  (float) (topfrontrighty + ((topfrontrightx - topbackrightx) / Math.Tan(ang)));
					
					if (topbackrighty < pointy)
					{
						generator.Default.gfxzy.DrawLine(Pens.Gray, topbackright, beak);
						generator.Default.gfxzy.DrawLine(Pens.Gray, topfrontright, topbackright);
					}
					else
					{
						generator.Default.gfxzy.DrawLine(graypen, topbackright, beak);
						generator.Default.gfxzy.DrawLine(graypen, topfrontright, topbackright);
					}
					
					ang = (float) (Math.Atan(System.Convert.ToDouble(Math.Abs(beakx - bottomfrontrightx) / Math.Abs(beaky - bottomfrontrighty))));
					pointy =  (float) (bottomfrontrighty - ((bottomfrontrightx - bottombackrightx) / Math.Tan(ang)));
					
					if (bottombackrighty > pointy)
					{
						generator.Default.gfxzy.DrawLine(Pens.Gray, bottombackright, beak);
						generator.Default.gfxzy.DrawLine(Pens.Gray, bottombackright, bottomfrontright);
					}
					else
					{
						generator.Default.gfxzy.DrawLine(graypen, bottombackright, beak);
						generator.Default.gfxzy.DrawLine(graypen, bottombackright, bottomfrontright);
					}
					
				}
				
			}
			
		}
		
		
		
		
		
		
		public void TopViewToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
		{
			viewlabel.Text = "Top View (x,z)";
			
			TopViewToolStripMenuItem.Enabled = false;
			SideViewToolStripMenuItem.Enabled = true;
			SideViewToolStripMenuItem1.Enabled = true;
			
			
			
			generator.Default.gfxxz.Clear(Color.White);
			generator.Default.gridxz();
			sortxz();
			placingagentsxz();
			generator.Default.topgridxz();
			PictureBox1.Image = generator.Default.picxz;
			
			
			
			
		}
		
		public void QuitToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
		{
			this.Close();
		}
		
		private void Panel1_Paint(System.Object sender, System.Windows.Forms.PaintEventArgs e)
		{
			
		}
		
		public void SideViewToolStripMenuzItem1_Click(System.Object sender, System.EventArgs e)
		{
			viewlabel.Text = "Side View (z,y)";
			TopViewToolStripMenuItem.Enabled = true;
			SideViewToolStripMenuItem.Enabled = true;
			SideViewToolStripMenuItem1.Enabled = false;
			
			generator.Default.gfxzy.Clear(Color.White);
			generator.Default.gridzy();
			sortzy();
			placingagentszy();
			generator.Default.topgridzy();
			PictureBox1.Image = generator.Default.piczy;
		}
		
		public void SideViewToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
		{
			TopViewToolStripMenuItem.Enabled = true;
			SideViewToolStripMenuItem1.Enabled = true;
			SideViewToolStripMenuItem.Enabled = false;
			
			viewlabel.Text = "Side View (x,y)";
			
			generator.Default.gfxxy.Clear(Color.White);
			generator.Default.gridxy();
			sortxy();
			placingagentsxy();
			generator.Default.topgridxy();
			PictureBox1.Image = generator.Default.picxy;
			
		}
		
		public void Timerxy_Tick(System.Object sender, System.EventArgs e)
		{
			
			
			for (var i = 1; i <= total; i++)
			{
				
				//I know this if statment doesnt make sense but if agent gets deminished i goes above total and one agent goes missing
				if (i > total)
				{
					break;
				}
				
				int x = generator.Default.agentlocation[i, 0];
				int y = generator.Default.agentlocation[i, 1];
				int z = generator.Default.agentlocation[i, 2];
				int dx = generator.Default.agentlocation[i, 5];
				int dy = generator.Default.agentlocation[i, 6];
				int dz = generator.Default.agentlocation[i, 7];
				
				
				generator.Default.agentlocation[i, 9] = System.Convert.ToInt32(generator.Default.agentlocation[i, 9] + 1);
				
				if (generator.Default.agentlocation[i, 8] == 0)
				{
					deminish(i, x, y, z);
					x = generator.Default.agentlocation[i, 0];
					y = generator.Default.agentlocation[i, 1];
					z = generator.Default.agentlocation[i, 2];
					dx = generator.Default.agentlocation[i, 5];
					dy = generator.Default.agentlocation[i, 6];
					dz = generator.Default.agentlocation[i, 7];
				}
				
				if (generator.Default.aging[generator.Default.agentlocation[i, 4]] == true)
				{
					if (generator.Default.agentlocation[i, 9] == generator.Default.agelimit[generator.Default.agentlocation[i, 4]])
					{
						deminish(i, x, y, z);
					}
				}
				
				if (generator.Default.asr[generator.Default.agentlocation[i, 4]] == true)
				{
					generator.Default.agentlocation[i, 10] = System.Convert.ToInt32(generator.Default.agentlocation[i, 10] + 1);
					if (generator.Default.agentlocation[i, 10] == generator.Default.asrtime[generator.Default.agentlocation[i, 4]])
					{
						Module1.asrproduce(generator.Default.agentlocation[i, 4]);
						generator.Default.agentlocation[i, 10] = 0;
						generator.Default.agentlocation[i, 8] = System.Convert.ToInt32(generator.Default.agentlocation[i, 8] - generator.Default.asrenergy[generator.Default.agentlocation[i, 4]]);
					}
				}
				
				if (x == dx & y == dy & z == dz)
				{
					
					int rangexupper = generator.Default.agentrange[generator.Default.agentlocation[i, 4], 0, 1];
					int rangexlower = generator.Default.agentrange[generator.Default.agentlocation[i, 4], 0, 0];
					int rangeyupper = generator.Default.agentrange[generator.Default.agentlocation[i, 4], 1, 1];
					int rangeylower = generator.Default.agentrange[generator.Default.agentlocation[i, 4], 1, 0];
					int rangezupper = generator.Default.agentrange[generator.Default.agentlocation[i, 4], 2, 1];
					int rangezlower = generator.Default.agentrange[generator.Default.agentlocation[i, 4], 2, 0];
					
					dx = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((rangexupper - rangexlower + 1) * VBMath.Rnd())))) + rangexlower;
					dy = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((rangeyupper - rangeylower + 1) * VBMath.Rnd())))) + rangeylower;
					dz = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((rangezupper - rangezlower + 1) * VBMath.Rnd())))) + rangezlower;
					
					generator.Default.agentlocation[i, 5] = dx;
					generator.Default.agentlocation[i, 6] = dy;
					generator.Default.agentlocation[i, 7] = dz;
				}
				
				int xdiff = Math.Abs(dx - x);
				int ydiff = Math.Abs(dy - y);
				int zdiff = Math.Abs(dz - z);
				if (xdiff >= ydiff & xdiff >= zdiff)
				{
					
					if (dx > x & generator.Default.agentlocation[i, 3] == 4)
					{
						if (generator.Default.occupied[x + 1, y, z] == false)
						{
							generator.Default.agentlocation[i, 0] = System.Convert.ToInt32(generator.Default.agentlocation[i, 0] + 1);
							generator.Default.occupied[x, y, z] = false;
							generator.Default.occupied[x + 1, y, z] = true;
							generator.Default.agentlocation[i, 8] = System.Convert.ToInt32(generator.Default.agentlocation[i, 8] - generator.Default.stepenergy[generator.Default.agentlocation[i, 4]]);
						}
						else if (generator.Default.occupied[x + 1, y, z] == true)
						{
							//MsgBox("contact")
							contact(generator.Default.agentlocation[i, 4], System.Convert.ToInt32(i));
						}
					}
					else if (dx > x)
					{
						generator.Default.agentlocation[i, 3] = 4;
						//turn energy can be added here
						generator.Default.agentlocation[i, 8] = System.Convert.ToInt32(generator.Default.agentlocation[i, 8] - generator.Default.stepenergy[generator.Default.agentlocation[i, 4]]);
					}
					else if (x > dx & generator.Default.agentlocation[i, 3] == 3)
					{
						if (generator.Default.occupied[x - 1, y, z] == false)
						{
							generator.Default.agentlocation[i, 0] = System.Convert.ToInt32(generator.Default.agentlocation[i, 0] - 1);
							generator.Default.occupied[x, y, z] = false;
							generator.Default.occupied[x - 1, y, z] = true;
							generator.Default.agentlocation[i, 8] = System.Convert.ToInt32(generator.Default.agentlocation[i, 8] - generator.Default.stepenergy[generator.Default.agentlocation[i, 4]]);
						}
						else if (generator.Default.occupied[x - 1, y, z] == true)
						{
							//MsgBox("contact")
							contact(generator.Default.agentlocation[i, 4], System.Convert.ToInt32(i));
						}
					}
					else if (x > dx)
					{
						generator.Default.agentlocation[i, 3] = 3;
						//turn energy can be added here
						generator.Default.agentlocation[i, 8] = System.Convert.ToInt32(generator.Default.agentlocation[i, 8] - generator.Default.stepenergy[generator.Default.agentlocation[i, 4]]);
					}
					
				}
				else if (ydiff >= xdiff & ydiff >= zdiff)
				{
					
					if (dy > y & generator.Default.agentlocation[i, 3] == 1)
					{
						if (generator.Default.occupied[x, y + 1, z] == false)
						{
							generator.Default.agentlocation[i, 1] = System.Convert.ToInt32(generator.Default.agentlocation[i, 1] + 1);
							generator.Default.occupied[x, y, z] = false;
							generator.Default.occupied[x, y + 1, z] = true;
							generator.Default.agentlocation[i, 8] = System.Convert.ToInt32(generator.Default.agentlocation[i, 8] - generator.Default.stepenergy[generator.Default.agentlocation[i, 4]]);
						}
						else if (generator.Default.occupied[x, y + 1, z] == true)
						{
							//MsgBox("contact")
							contact(generator.Default.agentlocation[i, 4], System.Convert.ToInt32(i));
						}
					}
					else if (dy > y)
					{
						generator.Default.agentlocation[i, 3] = 1;
						//turn energy can be added here
						generator.Default.agentlocation[i, 8] = System.Convert.ToInt32(generator.Default.agentlocation[i, 8] - generator.Default.stepenergy[generator.Default.agentlocation[i, 4]]);
					}
					else if (y > dy & generator.Default.agentlocation[i, 3] == 2)
					{
						if (generator.Default.occupied[x, y - 1, z] == false)
						{
							generator.Default.agentlocation[i, 1] = System.Convert.ToInt32(generator.Default.agentlocation[i, 1] - 1);
							generator.Default.occupied[x, y, z] = false;
							generator.Default.occupied[x, y - 1, z] = true;
							generator.Default.agentlocation[i, 8] = System.Convert.ToInt32(generator.Default.agentlocation[i, 8] - generator.Default.stepenergy[generator.Default.agentlocation[i, 4]]);
						}
						else if (generator.Default.occupied[x, y - 1, z] == true)
						{
							//MsgBox("contact")
							contact(generator.Default.agentlocation[i, 4], System.Convert.ToInt32(i));
						}
					}
					else if (y > dy)
					{
						generator.Default.agentlocation[i, 3] = 2;
						//turn energy can be added here
						generator.Default.agentlocation[i, 8] = System.Convert.ToInt32(generator.Default.agentlocation[i, 8] - generator.Default.stepenergy[generator.Default.agentlocation[i, 4]]);
					}
					
				}
				else if (zdiff >= xdiff & zdiff >= ydiff)
				{
					
					if (dz > z & generator.Default.agentlocation[i, 3] == 6)
					{
						if (generator.Default.occupied[x, y, z + 1] == false)
						{
							generator.Default.agentlocation[i, 2] = System.Convert.ToInt32(generator.Default.agentlocation[i, 2] + 1);
							generator.Default.occupied[x, y, z] = false;
							generator.Default.occupied[x, y, z + 1] = true;
							generator.Default.agentlocation[i, 8] = System.Convert.ToInt32(generator.Default.agentlocation[i, 8] - generator.Default.stepenergy[generator.Default.agentlocation[i, 4]]);
						}
						else if (generator.Default.occupied[x, y, z + 1] == true)
						{
							//MsgBox("contact")
							contact(generator.Default.agentlocation[i, 4], System.Convert.ToInt32(i));
						}
					}
					else if (dz > z)
					{
						generator.Default.agentlocation[i, 3] = 6;
						//turn energy can be added here
						generator.Default.agentlocation[i, 8] = System.Convert.ToInt32(generator.Default.agentlocation[i, 8] - generator.Default.stepenergy[generator.Default.agentlocation[i, 4]]);
					}
					else if (z > dz & generator.Default.agentlocation[i, 3] == 5)
					{
						if (generator.Default.occupied[x, y, z - 1] == false)
						{
							generator.Default.agentlocation[i, 2] = System.Convert.ToInt32(generator.Default.agentlocation[i, 2] - 1);
							generator.Default.occupied[x, y, z] = false;
							generator.Default.occupied[x, y, z - 1] = true;
							generator.Default.agentlocation[i, 8] = System.Convert.ToInt32(generator.Default.agentlocation[i, 8] - generator.Default.stepenergy[generator.Default.agentlocation[i, 4]]);
						}
						else if (generator.Default.occupied[x, y, z - 1] == true)
						{
							//MsgBox("contact")
							contact(generator.Default.agentlocation[i, 4], System.Convert.ToInt32(i));
						}
					}
					else if (z > dz)
					{
						generator.Default.agentlocation[i, 3] = 5;
						//turn energy can be added here
						generator.Default.agentlocation[i, 8] = System.Convert.ToInt32(generator.Default.agentlocation[i, 8] - generator.Default.stepenergy[generator.Default.agentlocation[i, 4]]);
					}
					
				}
			}
			
			
			
			if (viewlabel.Text == "Top View (x,z)")
			{
				generator.Default.gfxxz.Clear(Color.White);
				generator.Default.gridxz();
				sortxz();
				placingagentsxz();
				generator.Default.topgridxz();
				PictureBox1.Image = generator.Default.picxz;
				
			}
			else if (viewlabel.Text == "Side View (x,y)")
			{
				generator.Default.gfxxy.Clear(Color.White);
				generator.Default.gridxy();
				sortxy();
				placingagentsxy();
				generator.Default.topgridxy();
				PictureBox1.Image = generator.Default.picxy;
				
			}
			else if (viewlabel.Text == "Side View (z,y)")
			{
				generator.Default.gfxzy.Clear(Color.White);
				generator.Default.gridzy();
				sortzy();
				placingagentszy();
				generator.Default.topgridzy();
				PictureBox1.Image = generator.Default.piczy;
				
			}
			
			
			
			tick++;
			timelabel.Text = tick.ToString();
			
			
			
			//excel
			if (logged == true)
			{
				int[] agentpop = new int[agent + 1];
				for (var p = 1; p <= agent; p++)
				{
					for (var pop = 1; pop <= total; pop++)
					{
						if (generator.Default.agentlocation[pop, 4] == p)
						{
							agentpop[p] = System.Convert.ToInt32(agentpop[p] + 1);
						}
					}
				}
				
				oSheet.Cells(tick + 1, 1) = tick;
				for (var i = 1; i <= agent; i++)
				{
					oSheet.Cells(tick + 1, i + 1) = agentpop[i];
				}
			}
			
			
			//only onetick control
			if (timerexit == true)
			{
				timerexit = false;
				Timerxy.Stop();
			}
			
			
			
			if (tick == int.Parse(stoplabel.Text))
			{
				Timerxy.Stop();
			}
			
		}
		public void contact(int agentt, int i)
		{
			generator.Default.agentlocation[i, 8] = System.Convert.ToInt32(generator.Default.agentlocation[i, 8] - generator.Default.bumpenergy[generator.Default.agentlocation[i, 4]]);
			int dx = System.Convert.ToInt32(0);
			int dy = System.Convert.ToInt32(0);
			int dz = System.Convert.ToInt32(0);
			if (generator.Default.agentrangeabsolute[agentt] == false)
			{
				dx = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((xn) * VBMath.Rnd())))) + 1;
				dy = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((yn) * VBMath.Rnd())))) + 1;
				dz = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((zn) * VBMath.Rnd())))) + 1;
			}
			else if (generator.Default.agentrangeabsolute[agentt] == true)
			{
				
				int rangexupper = System.Convert.ToInt32(generator.Default.agentlocation[i, 0] + 1);
				int rangexlower = System.Convert.ToInt32(generator.Default.agentlocation[i, 0] - 1);
				int rangeyupper = System.Convert.ToInt32(generator.Default.agentlocation[i, 1] + 1);
				int rangeylower = System.Convert.ToInt32(generator.Default.agentlocation[i, 1] - 1);
				int rangezupper = System.Convert.ToInt32(generator.Default.agentlocation[i, 2] + 1);
				int rangezlower = System.Convert.ToInt32(generator.Default.agentlocation[i, 2] - 1);
				
				
				if (generator.Default.agentlocation[i, 3] == 1)
				{
					dy = generator.Default.agentlocation[i, 1];
					dz = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((rangezupper - rangezlower + 1) * VBMath.Rnd())))) + rangezlower;
					dx = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((rangexupper - rangexlower + 1) * VBMath.Rnd())))) + rangexlower;
					
				}
				else if (generator.Default.agentlocation[i, 3] == 2)
				{
					dy = generator.Default.agentlocation[i, 1];
					dz = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((rangezupper - rangezlower + 1) * VBMath.Rnd())))) + rangezlower;
					dx = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((rangexupper - rangexlower + 1) * VBMath.Rnd())))) + rangexlower;
					
				}
				else if (generator.Default.agentlocation[i, 3] == 3)
				{
					dx = generator.Default.agentlocation[i, 0];
					dy = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((rangeyupper - rangeylower + 1) * VBMath.Rnd())))) + rangeylower;
					dz = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((rangezupper - rangezlower + 1) * VBMath.Rnd())))) + rangezlower;
					
				}
				else if (generator.Default.agentlocation[i, 3] == 4)
				{
					dx = generator.Default.agentlocation[i, 0];
					dy = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((rangeyupper - rangeylower + 1) * VBMath.Rnd())))) + rangeylower;
					dz = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((rangezupper - rangezlower + 1) * VBMath.Rnd())))) + rangezlower;
					
				}
				else if (generator.Default.agentlocation[i, 3] == 5)
				{
					dz = generator.Default.agentlocation[i, 2];
					dy = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((rangeyupper - rangeylower + 1) * VBMath.Rnd())))) + rangeylower;
					dx = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((rangexupper - rangexlower + 1) * VBMath.Rnd())))) + rangexlower;
					
				}
				else if (generator.Default.agentlocation[i, 3] == 6)
				{
					dz = generator.Default.agentlocation[i, 2];
					dy = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((rangeyupper - rangeylower + 1) * VBMath.Rnd())))) + rangeylower;
					dx = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((rangexupper - rangexlower + 1) * VBMath.Rnd())))) + rangexlower;
					
				}
				
				
				if (dx > xn)
				{
					dx = dx - 2;
				}
				if (dy > yn)
				{
					dy = dy - 2;
				}
				if (dz > zn)
				{
					dz = dz - 2;
				}
				if (dx < 1)
				{
					dx = dx + 2;
				}
				if (dy < 1)
				{
					dy = dy + 2;
				}
				if (dz < 1)
				{
					dz = dz + 2;
				}
				
				
				//dx = CInt(Math.Floor((rangexupper - rangexlower + 1) * Rnd())) + rangexlower
				//dy = CInt(Math.Floor((rangeyupper - rangeylower + 1) * Rnd())) + rangeylower
				// dz = CInt(Math.Floor((rangezupper - rangezlower + 1) * Rnd())) + rangezlower
				
			}
			generator.Default.agentlocation[i, 5] = dx;
			generator.Default.agentlocation[i, 6] = dy;
			generator.Default.agentlocation[i, 7] = dz;
			
			
			
			//.......................................................................
			int opponentx = System.Convert.ToInt32(0);
			int opponenty = System.Convert.ToInt32(0);
			int opponentz = System.Convert.ToInt32(0);
			if (generator.Default.agentlocation[i, 3] == 1)
			{
				opponentx = generator.Default.agentlocation[i, 0];
				opponenty = System.Convert.ToInt32(generator.Default.agentlocation[i, 1] + 1);
				opponentz = generator.Default.agentlocation[i, 2];
			}
			else if (generator.Default.agentlocation[i, 3] == 2)
			{
				opponentx = generator.Default.agentlocation[i, 0];
				opponenty = System.Convert.ToInt32(generator.Default.agentlocation[i, 1] - 1);
				opponentz = generator.Default.agentlocation[i, 2];
			}
			else if (generator.Default.agentlocation[i, 3] == 3)
			{
				opponentx = System.Convert.ToInt32(generator.Default.agentlocation[i, 0] - 1);
				opponenty = generator.Default.agentlocation[i, 1];
				opponentz = generator.Default.agentlocation[i, 2];
			}
			else if (generator.Default.agentlocation[i, 3] == 4)
			{
				opponentx = System.Convert.ToInt32(generator.Default.agentlocation[i, 0] + 1);
				opponenty = generator.Default.agentlocation[i, 1];
				opponentz = generator.Default.agentlocation[i, 2];
			}
			else if (generator.Default.agentlocation[i, 3] == 5)
			{
				opponentx = generator.Default.agentlocation[i, 0];
				opponenty = generator.Default.agentlocation[i, 1];
				opponentz = System.Convert.ToInt32(generator.Default.agentlocation[i, 2] + 1);
			}
			else if (generator.Default.agentlocation[i, 3] == 6)
			{
				opponentx = generator.Default.agentlocation[i, 0];
				opponenty = generator.Default.agentlocation[i, 1];
				opponentz = System.Convert.ToInt32(generator.Default.agentlocation[i, 2] - 1);
			}
			
			int ag;
			
			for (var opp = 1; opp <= total; opp++)
			{
				if (generator.Default.agentlocation[opp, 0] == opponentx & generator.Default.agentlocation[opp, 1] == opponenty & generator.Default.agentlocation[opp, 2] == opponentz & i != opp)
				{
					ag = generator.Default.agentlocation[opp, 4];
					if (generator.Default.action[generator.Default.agentlocation[i, 4], ag, 1] == 2)
					{
						consume(opp, opponentx, opponenty, opponentz, i);
					}
					else if (generator.Default.action[generator.Default.agentlocation[i, 4], ag, 1] == 1)
					{
						produce(generator.Default.agentlocation[i, 4], ag, i, opp);
					}
					else if (generator.Default.action[generator.Default.agentlocation[i, 4], ag, 1] == 3)
					{
						deminish(i, generator.Default.agentlocation[i, 0], generator.Default.agentlocation[i, 1], generator.Default.agentlocation[i, 2]);
					}
					else if (generator.Default.action[generator.Default.agentlocation[i, 4], ag, 1] == 4)
					{
						produce(generator.Default.agentlocation[i, 4], ag, i, opp);
						consume(opp, opponentx, opponenty, opponentz, i);
					}
					else if (generator.Default.action[generator.Default.agentlocation[i, 4], ag, 1] == 5)
					{
						consume(opp, opponentx, opponenty, opponentz, i);
						deminish(i, generator.Default.agentlocation[i, 0], generator.Default.agentlocation[i, 1], generator.Default.agentlocation[i, 2]);
					}
					else if (generator.Default.action[generator.Default.agentlocation[i, 4], ag, 1] == 6)
					{
						produce(generator.Default.agentlocation[i, 4], ag, i, opp);
						deminish(i, generator.Default.agentlocation[i, 0], generator.Default.agentlocation[i, 1], generator.Default.agentlocation[i, 2]);
					}
					else if (generator.Default.action[generator.Default.agentlocation[i, 4], ag, 1] == 7)
					{
						//Call produce(generator.agentlocation(i, 4), ag, i, opp)
						//Call deminish(i, generator.agentlocation(i, 0), generator.agentlocation(i, 1), generator.agentlocation(i, 2))
						//Call consume(opp, opponentx, opponenty, opponentz, i)
						
						total++;
						
						generator.Default.agentlocation[i, 0] = 0;
						generator.Default.agentlocation[i, 1] = 0;
						generator.Default.agentlocation[i, 2] = 0;
						generator.Default.occupied[generator.Default.agentlocation[i, 0], generator.Default.agentlocation[i, 1], generator.Default.agentlocation[i, 2]] = false;
						
						
						if (generator.Default.action[generator.Default.agentlocation[i, 4], generator.Default.agentlocation[opp, 4], 6] == 1)
						{
							generator.Default.agentlocation[i, 8] = System.Convert.ToInt32(generator.Default.agentlocation[i, 8] + (generator.Default.agentlocation[opp, 8] * (generator.Default.action[generator.Default.agentlocation[i, 4], generator.Default.agentlocation[opp, 4], 3] / 100)));
						}
						else if (generator.Default.action[generator.Default.agentlocation[i, 4], generator.Default.agentlocation[opp, 4], 6] == 2)
						{
							generator.Default.agentlocation[i, 8] = System.Convert.ToInt32(generator.Default.agentlocation[i, 8] + generator.Default.action[generator.Default.agentlocation[i, 4], generator.Default.agentlocation[opp, 4], 4]);
						}
						
						generator.Default.agentlocation[opp, 0] = 0;
						generator.Default.agentlocation[opp, 1] = 0;
						generator.Default.agentlocation[opp, 2] = 0;
						generator.Default.occupied[opponentx, opponenty, opponentz] = false;
						
						
						
						generator.Default.agentlocation[i, 8] = System.Convert.ToInt32(generator.Default.agentlocation[i, 8] - generator.Default.action[generator.Default.agentlocation[i, 4], ag, 5]);
						generator.Default.agentlocation[opp, 8] = System.Convert.ToInt32(generator.Default.agentlocation[opp, 8] - generator.Default.action[generator.Default.agentlocation[i, 4], ag, 5]);
						
						int x = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((xn) * VBMath.Rnd())))) + 1;
						int y = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((yn) * VBMath.Rnd())))) + 1;
						int z = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((zn) * VBMath.Rnd())))) + 1;
						
						int dx2;
						int dy2;
						int dz2;
						int a = generator.Default.action[generator.Default.agentlocation[i, 4], ag, 2];
						
						
						int rangexupper = generator.Default.agentrange[a, 0, 1];
						int rangexlower = generator.Default.agentrange[a, 0, 0];
						int rangeyupper = generator.Default.agentrange[a, 1, 1];
						int rangeylower = generator.Default.agentrange[a, 1, 0];
						int rangezupper = generator.Default.agentrange[a, 2, 1];
						int rangezlower = generator.Default.agentrange[a, 2, 0];
						
						dx2 = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((rangexupper - rangexlower + 1) * VBMath.Rnd())))) + rangexlower;
						dy2 = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((rangeyupper - rangeylower + 1) * VBMath.Rnd())))) + rangeylower;
						dz2 = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((rangezupper - rangezlower + 1) * VBMath.Rnd())))) + rangezlower;
						
						
						
						int number = 0;
						while (generator.Default.occupied[x, y, z] == true && number < generator.Default.maxcell)
						{
							number++;
							x = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((xn) * VBMath.Rnd())))) + 1;
							y = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((yn) * VBMath.Rnd())))) + 1;
							z = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((zn) * VBMath.Rnd())))) + 1;
						}
						
						
						generator.Default.occupied[x, y, z] = true;
						
						int d = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((6) * VBMath.Rnd())))) + 1;
						generator.Default.agentlocation[total, 0] = x;
						generator.Default.agentlocation[total, 1] = y;
						generator.Default.agentlocation[total, 2] = z;
						generator.Default.agentlocation[total, 3] = d;
						generator.Default.agentlocation[total, 4] = a;
						generator.Default.agentlocation[total, 5] = dx2;
						generator.Default.agentlocation[total, 6] = dy2;
						generator.Default.agentlocation[total, 7] = dz2;
						generator.Default.agentlocation[total, 8] = generator.Default.initialenergy[a];
						generator.Default.agentlocation[total, 9] = 0;
						generator.Default.agentlocation[total, 10] = 0;
						
						if (viewlabel.Text == "Top View (x,z)")
						{
							sortxz();
							
						}
						else if (viewlabel.Text == "Side View (x,y)")
						{
							sortxy();
							
						}
						else if (viewlabel.Text == "Side View (z,y)")
						{
							sortzy();
							
						}
						
						total = total - 2;
						
					}
				}
			}
			
			
		}
		
		public void deminish(object i, object ix, object iy, object iz)
		{
			total--;
			generator.Default.agentlocation[ (int) (i), 0] = 0;
			generator.Default.agentlocation[ (int) (i), 1] = 0;
			generator.Default.agentlocation[ (int) (i), 2] = 0;
			generator.Default.occupied[ (int) (ix),  (int) (iy),  (int) (iz)] = false;
			
			//not sure about this part
			if (viewlabel.Text == "Top View (x,z)")
			{
				sortxz();
				
			}
			else if (viewlabel.Text == "Side View (x,y)")
			{
				sortxy();
				
			}
			else if (viewlabel.Text == "Side View (z,y)")
			{
				sortzy();
				
			}
			
		}
		
		
		public void consume(object opp, object opponentx, object opponenty, object opponentz, object i)
		{
			if (generator.Default.action[generator.Default.agentlocation[ (int) (i), 4], generator.Default.agentlocation[ (int) (opp), 4], 6] == 1)
			{
				generator.Default.agentlocation[ (int) (i), 8] = System.Convert.ToInt32(generator.Default.agentlocation[ (int) (i), 8] + (generator.Default.agentlocation[ (int) (opp), 8] * (generator.Default.action[generator.Default.agentlocation[ (int) (i), 4], generator.Default.agentlocation[ (int) (opp), 4], 3] / 100)));
			}
			else if (generator.Default.action[generator.Default.agentlocation[ (int) (i), 4], generator.Default.agentlocation[ (int) (opp), 4], 6] == 2)
			{
				generator.Default.agentlocation[ (int) (i), 8] = System.Convert.ToInt32(generator.Default.agentlocation[ (int) (i), 8] + generator.Default.action[generator.Default.agentlocation[ (int) (i), 4], generator.Default.agentlocation[ (int) (opp), 4], 4]);
			}
			total--;
			generator.Default.agentlocation[ (int) (opp), 0] = 0;
			generator.Default.agentlocation[ (int) (opp), 1] = 0;
			generator.Default.agentlocation[ (int) (opp), 2] = 0;
			generator.Default.occupied[ (int) (opponentx),  (int) (opponenty),  (int) (opponentz)] = false;
		}
		
		public void produce(object ag1, object ag2, object i, object opp)
		{
			if (total < generator.Default.maxcell)
			{
				total++;
				
				//energy cost in reproduction
				generator.Default.agentlocation[ (int) (i), 8] = System.Convert.ToInt32(generator.Default.agentlocation[ (int) (i), 8] - generator.Default.action[ (int) (ag1),  (int) (ag2), 5]);
				generator.Default.agentlocation[ (int) (opp), 8] = System.Convert.ToInt32(generator.Default.agentlocation[ (int) (opp), 8] - generator.Default.action[ (int) (ag1),  (int) (ag2), 5]);
				
				int x = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((xn) * VBMath.Rnd())))) + 1;
				int y = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((yn) * VBMath.Rnd())))) + 1;
				int z = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((zn) * VBMath.Rnd())))) + 1;
				
				int dx;
				int dy;
				int dz;
				int a = generator.Default.action[ (int) (ag1),  (int) (ag2), 2];
				
				
				int rangexupper = generator.Default.agentrange[a, 0, 1];
				int rangexlower = generator.Default.agentrange[a, 0, 0];
				int rangeyupper = generator.Default.agentrange[a, 1, 1];
				int rangeylower = generator.Default.agentrange[a, 1, 0];
				int rangezupper = generator.Default.agentrange[a, 2, 1];
				int rangezlower = generator.Default.agentrange[a, 2, 0];
				
				dx = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((rangexupper - rangexlower + 1) * VBMath.Rnd())))) + rangexlower;
				dy = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((rangeyupper - rangeylower + 1) * VBMath.Rnd())))) + rangeylower;
				dz = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((rangezupper - rangezlower + 1) * VBMath.Rnd())))) + rangezlower;
				
				
				
				int number = 0;
				while (generator.Default.occupied[x, y, z] == true && number < generator.Default.maxcell)
				{
					number++;
					x = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((xn) * VBMath.Rnd())))) + 1;
					y = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((yn) * VBMath.Rnd())))) + 1;
					z = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((zn) * VBMath.Rnd())))) + 1;
				}
				
				
				generator.Default.occupied[x, y, z] = true;
				
				int d = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((6) * VBMath.Rnd())))) + 1;
				generator.Default.agentlocation[total, 0] = x;
				generator.Default.agentlocation[total, 1] = y;
				generator.Default.agentlocation[total, 2] = z;
				generator.Default.agentlocation[total, 3] = d;
				generator.Default.agentlocation[total, 4] = a;
				generator.Default.agentlocation[total, 5] = dx;
				generator.Default.agentlocation[total, 6] = dy;
				generator.Default.agentlocation[total, 7] = dz;
				generator.Default.agentlocation[total, 8] = generator.Default.initialenergy[a];
				generator.Default.agentlocation[total, 9] = 0;
				generator.Default.agentlocation[total, 10] = 0;
			}
		}
		
		
		
		private void Button2_Click(System.Object sender, System.EventArgs e)
		{
			Timerxy.Start();
			Timerxy.Stop();
		}
		
		public void ToolStripStatusLabel2_Click(System.Object sender, System.EventArgs e)
		{
			stoplabel.Text = Interaction.InputBox("Enter the time limit:", "", "", -1, -1);
		}
		
		public void ToolStripStatusLabel4_Click(System.Object sender, System.EventArgs e)
		{
			int speed = int.Parse(Interaction.InputBox("Enter speed in percentage:", "", "", -1, -1));
			if (speed > 100)
			{
				speed = 100;
				MessageBox.Show("Max speed: 100");
			}
			Timerxy.Interval = System.Convert.ToInt32(300 - ((speed * 3) - 1));
			speedbar.Value = speed;
		}
		
		public void StopToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
		{
			Timerxy.Stop();
			if (logged == true)
			{
				if (MessageBox.Show("Would you like to stop the excel file encryption?", "Excel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
					oBook.SaveAs(exceldir);
					
					oBook.close();
					
					
					//Dim obj As New System.IO.StreamWriter(exceldir)
					//obj.Write(oBook)
					//obj.Close()
					
					oBook = null;
					oExcel.Quit();
					oExcel = null;
				}
				
			}
		}
		
		public void HelpToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
		{
			Timerxy.Start();
		}
		
		public void SizeToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
		{
			Form3.Default.Show();
		}
		
		public void NewToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
		{
			Form2.Default.Show();
		}
		
		public void AIToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
		{
			AI.Default.Show();
		}
		
		private void Button1_Click(System.Object sender, System.EventArgs e)
		{
			sizeratio = System.Convert.ToDouble(9 / 10);
		}
		
		public void FullScreenToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
		{
			if (this.FormBorderStyle == FormBorderStyle.None)
			{
				this.FormBorderStyle = FormBorderStyle.Sizable;
				FullScreenToolStripMenuItem.Text = "Full Screen";
			}
			else
			{
				this.FormBorderStyle = FormBorderStyle.None;
				this.WindowState = FormWindowState.Normal;
				this.WindowState = FormWindowState.Maximized;
				FullScreenToolStripMenuItem.Text = "Exit Full Screen";
			}
			
			
		}
		
		public void AdjustFocalPointToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
		{
			Ratio.Default.Show();
		}
		
		
		
		public void LogDataToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
		{
			SaveFileDialog1.ShowDialog();
			oExcel = Interaction.CreateObject("Excel.Application", "");
			oBook = oExcel.Workbooks.Add;
			oSheet = oBook.Worksheets(1);
			oSheet.name = "Population";
			
			oSheet.Cells(1, 1) = "Tick";
			for (var i = 1; i <= agent; i++)
			{
				oSheet.Cells(1, i + 1) = generator.Default.agentname[i];
			}
			
			logged = true;
			
			
		}
		
		public void FoodWebToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
		{
			Form5.Default.Show();
		}
		
		
		
		public void DataSheetToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
		{
			Form4.Default.Show();
		}
		
		public void SaveFileDialog1_FileOk(System.Object sender, System.ComponentModel.CancelEventArgs e)
		{
			string Filetosaveas = SaveFileDialog1.FileName;
			//Dim obj As New System.IO.StreamWriter(Filetosaveas)
			// obj.Write(oBook)
			//obj.Close()
			//exceldir = SaveFileDialog1.InitialDirectory
			
			exceldir = SaveFileDialog1.FileName;
			
		}
		
		
		public void sortxy()
		{
			for (var index = 2; index <= total + 1; index++)
			{
				int tempz = generator.Default.agentlocation[index, 2];
				int tempx = generator.Default.agentlocation[index, 0];
				int tempy = generator.Default.agentlocation[index, 1];
				int tempd = generator.Default.agentlocation[index, 3];
				int tempa = generator.Default.agentlocation[index, 4];
				
				int tempdx = generator.Default.agentlocation[index, 5];
				int tempdy = generator.Default.agentlocation[index, 6];
				int tempdz = generator.Default.agentlocation[index, 7];
				
				int tempenergy = generator.Default.agentlocation[index, 8];
				int tempage = generator.Default.agentlocation[index, 9];
				int tempasr = generator.Default.agentlocation[index, 10];
				
				int previousposition = System.Convert.ToInt32(index - 1);
				while (tempz > generator.Default.agentlocation[previousposition, 2] && previousposition >= 1)
				{
					generator.Default.agentlocation[previousposition + 1, 0] = generator.Default.agentlocation[previousposition, 0];
					generator.Default.agentlocation[previousposition + 1, 1] = generator.Default.agentlocation[previousposition, 1];
					generator.Default.agentlocation[previousposition + 1, 2] = generator.Default.agentlocation[previousposition, 2];
					generator.Default.agentlocation[previousposition + 1, 3] = generator.Default.agentlocation[previousposition, 3];
					generator.Default.agentlocation[previousposition + 1, 4] = generator.Default.agentlocation[previousposition, 4];
					
					generator.Default.agentlocation[previousposition + 1, 5] = generator.Default.agentlocation[previousposition, 5];
					generator.Default.agentlocation[previousposition + 1, 6] = generator.Default.agentlocation[previousposition, 6];
					generator.Default.agentlocation[previousposition + 1, 7] = generator.Default.agentlocation[previousposition, 7];
					
					generator.Default.agentlocation[previousposition + 1, 8] = generator.Default.agentlocation[previousposition, 8];
					generator.Default.agentlocation[previousposition + 1, 9] = generator.Default.agentlocation[previousposition, 9];
					generator.Default.agentlocation[previousposition + 1, 10] = generator.Default.agentlocation[previousposition, 10];
					
					previousposition--;
				}
				generator.Default.agentlocation[previousposition + 1, 2] = tempz;
				generator.Default.agentlocation[previousposition + 1, 0] = tempx;
				generator.Default.agentlocation[previousposition + 1, 1] = tempy;
				generator.Default.agentlocation[previousposition + 1, 3] = tempd;
				generator.Default.agentlocation[previousposition + 1, 4] = tempa;
				
				generator.Default.agentlocation[previousposition + 1, 5] = tempdx;
				generator.Default.agentlocation[previousposition + 1, 6] = tempdy;
				generator.Default.agentlocation[previousposition + 1, 7] = tempdz;
				
				generator.Default.agentlocation[previousposition + 1, 8] = tempenergy;
				generator.Default.agentlocation[previousposition + 1, 9] = tempage;
				generator.Default.agentlocation[previousposition + 1, 10] = tempasr;
				
			}
		}
		public void sortxz()
		{
			for (var index = 2; index <= total + 1; index++)
			{
				int tempz = generator.Default.agentlocation[index, 2];
				int tempx = generator.Default.agentlocation[index, 0];
				int tempy = generator.Default.agentlocation[index, 1];
				int tempd = generator.Default.agentlocation[index, 3];
				int tempa = generator.Default.agentlocation[index, 4];
				
				int tempdx = generator.Default.agentlocation[index, 5];
				int tempdy = generator.Default.agentlocation[index, 6];
				int tempdz = generator.Default.agentlocation[index, 7];
				
				int tempenergy = generator.Default.agentlocation[index, 8];
				int tempage = generator.Default.agentlocation[index, 9];
				int tempasr = generator.Default.agentlocation[index, 10];
				
				int previousposition = System.Convert.ToInt32(index - 1);
				while (tempy > generator.Default.agentlocation[previousposition, 1] && previousposition >= 1)
				{
					generator.Default.agentlocation[previousposition + 1, 0] = generator.Default.agentlocation[previousposition, 0];
					generator.Default.agentlocation[previousposition + 1, 1] = generator.Default.agentlocation[previousposition, 1];
					generator.Default.agentlocation[previousposition + 1, 2] = generator.Default.agentlocation[previousposition, 2];
					generator.Default.agentlocation[previousposition + 1, 3] = generator.Default.agentlocation[previousposition, 3];
					generator.Default.agentlocation[previousposition + 1, 4] = generator.Default.agentlocation[previousposition, 4];
					
					generator.Default.agentlocation[previousposition + 1, 5] = generator.Default.agentlocation[previousposition, 5];
					generator.Default.agentlocation[previousposition + 1, 6] = generator.Default.agentlocation[previousposition, 6];
					generator.Default.agentlocation[previousposition + 1, 7] = generator.Default.agentlocation[previousposition, 7];
					
					generator.Default.agentlocation[previousposition + 1, 8] = generator.Default.agentlocation[previousposition, 8];
					generator.Default.agentlocation[previousposition + 1, 9] = generator.Default.agentlocation[previousposition, 9];
					generator.Default.agentlocation[previousposition + 1, 10] = generator.Default.agentlocation[previousposition, 10];
					
					previousposition--;
				}
				generator.Default.agentlocation[previousposition + 1, 2] = tempz;
				generator.Default.agentlocation[previousposition + 1, 0] = tempx;
				generator.Default.agentlocation[previousposition + 1, 1] = tempy;
				generator.Default.agentlocation[previousposition + 1, 3] = tempd;
				generator.Default.agentlocation[previousposition + 1, 4] = tempa;
				
				generator.Default.agentlocation[previousposition + 1, 5] = tempdx;
				generator.Default.agentlocation[previousposition + 1, 6] = tempdy;
				generator.Default.agentlocation[previousposition + 1, 7] = tempdz;
				
				generator.Default.agentlocation[previousposition + 1, 8] = tempenergy;
				generator.Default.agentlocation[previousposition + 1, 9] = tempage;
				generator.Default.agentlocation[previousposition + 1, 10] = tempasr;
			}
		}
		public void sortzy()
		{
			for (var index = 2; index <= total + 1; index++)
			{
				int tempz = generator.Default.agentlocation[index, 2];
				int tempx = generator.Default.agentlocation[index, 0];
				int tempy = generator.Default.agentlocation[index, 1];
				int tempd = generator.Default.agentlocation[index, 3];
				int tempa = generator.Default.agentlocation[index, 4];
				
				int tempdx = generator.Default.agentlocation[index, 5];
				int tempdy = generator.Default.agentlocation[index, 6];
				int tempdz = generator.Default.agentlocation[index, 7];
				
				int tempenergy = generator.Default.agentlocation[index, 8];
				int tempage = generator.Default.agentlocation[index, 9];
				int tempasr = generator.Default.agentlocation[index, 10];
				
				int previousposition = System.Convert.ToInt32(index - 1);
				while (tempx > generator.Default.agentlocation[previousposition, 0] && previousposition >= 1)
				{
					generator.Default.agentlocation[previousposition + 1, 0] = generator.Default.agentlocation[previousposition, 0];
					generator.Default.agentlocation[previousposition + 1, 1] = generator.Default.agentlocation[previousposition, 1];
					generator.Default.agentlocation[previousposition + 1, 2] = generator.Default.agentlocation[previousposition, 2];
					generator.Default.agentlocation[previousposition + 1, 3] = generator.Default.agentlocation[previousposition, 3];
					generator.Default.agentlocation[previousposition + 1, 4] = generator.Default.agentlocation[previousposition, 4];
					
					generator.Default.agentlocation[previousposition + 1, 5] = generator.Default.agentlocation[previousposition, 5];
					generator.Default.agentlocation[previousposition + 1, 6] = generator.Default.agentlocation[previousposition, 6];
					generator.Default.agentlocation[previousposition + 1, 7] = generator.Default.agentlocation[previousposition, 7];
					
					generator.Default.agentlocation[previousposition + 1, 8] = generator.Default.agentlocation[previousposition, 8];
					generator.Default.agentlocation[previousposition + 1, 9] = generator.Default.agentlocation[previousposition, 9];
					generator.Default.agentlocation[previousposition + 1, 10] = generator.Default.agentlocation[previousposition, 10];
					
					previousposition--;
				}
				generator.Default.agentlocation[previousposition + 1, 2] = tempz;
				generator.Default.agentlocation[previousposition + 1, 0] = tempx;
				generator.Default.agentlocation[previousposition + 1, 1] = tempy;
				generator.Default.agentlocation[previousposition + 1, 3] = tempd;
				generator.Default.agentlocation[previousposition + 1, 4] = tempa;
				
				generator.Default.agentlocation[previousposition + 1, 5] = tempdx;
				generator.Default.agentlocation[previousposition + 1, 6] = tempdy;
				generator.Default.agentlocation[previousposition + 1, 7] = tempdz;
				
				generator.Default.agentlocation[previousposition + 1, 8] = tempenergy;
				generator.Default.agentlocation[previousposition + 1, 9] = tempage;
				generator.Default.agentlocation[previousposition + 1, 10] = tempasr;
			}
		}
		
		
		public void placingagentsxy()
		{
			for (var i = 1; i <= total; i++)
			{
				int x = generator.Default.agentlocation[i, 0];
				int y = generator.Default.agentlocation[i, 1];
				int z = generator.Default.agentlocation[i, 2];
				int d = generator.Default.agentlocation[i, 3];
				int ag = generator.Default.agentlocation[i, 4];
				if (d == 1)
				{
					creator(x.ToString(), y, z, "down", generator.Default.agentcolour[ag]);
				}
				else if (d == 2)
				{
					creator(x.ToString(), y, z, "up", generator.Default.agentcolour[ag]);
				}
				else if (d == 3)
				{
					creator(x.ToString(), y, z, "left", generator.Default.agentcolour[ag]);
				}
				else if (d == 4)
				{
					creator(x.ToString(), y, z, "right", generator.Default.agentcolour[ag]);
				}
				else if (d == 5)
				{
					creator(x.ToString(), y, z, "front", generator.Default.agentcolour[ag]);
				}
				else if (d == 6)
				{
					creator(x.ToString(), y, z, "back", generator.Default.agentcolour[ag]);
				}
			}
		}
		
		public void placingagentsxz()
		{
			for (var i = 1; i <= total; i++)
			{
				int x = generator.Default.agentlocation[i, 0];
				int y = generator.Default.agentlocation[i, 1];
				int z = generator.Default.agentlocation[i, 2];
				int d = generator.Default.agentlocation[i, 3];
				int ag = generator.Default.agentlocation[i, 4];
				if (d == 1)
				{
					creatorxz(x.ToString(), y, z, "down", generator.Default.agentcolour[ag]);
				}
				else if (d == 2)
				{
					creatorxz(x.ToString(), y, z, "up", generator.Default.agentcolour[ag]);
				}
				else if (d == 3)
				{
					creatorxz(x.ToString(), y, z, "left", generator.Default.agentcolour[ag]);
				}
				else if (d == 4)
				{
					creatorxz(x.ToString(), y, z, "right", generator.Default.agentcolour[ag]);
				}
				else if (d == 5)
				{
					creatorxz(x.ToString(), y, z, "front", generator.Default.agentcolour[ag]);
				}
				else if (d == 6)
				{
					creatorxz(x.ToString(), y, z, "back", generator.Default.agentcolour[ag]);
				}
			}
		}
		
		public void placingagentszy()
		{
			for (var i = 1; i <= total; i++)
			{
				int x = generator.Default.agentlocation[i, 0];
				int y = generator.Default.agentlocation[i, 1];
				int z = generator.Default.agentlocation[i, 2];
				int d = generator.Default.agentlocation[i, 3];
				int ag = generator.Default.agentlocation[i, 4];
				if (d == 1)
				{
					creatorzy(x.ToString(), y, z, "down", generator.Default.agentcolour[ag]);
				}
				else if (d == 2)
				{
					creatorzy(x.ToString(), y, z, "up", generator.Default.agentcolour[ag]);
				}
				else if (d == 3)
				{
					creatorzy(x.ToString(), y, z, "left", generator.Default.agentcolour[ag]);
				}
				else if (d == 4)
				{
					creatorzy(x.ToString(), y, z, "right", generator.Default.agentcolour[ag]);
				}
				else if (d == 5)
				{
					creatorzy(x.ToString(), y, z, "front", generator.Default.agentcolour[ag]);
				}
				else if (d == 6)
				{
					creatorzy(x.ToString(), y, z, "back", generator.Default.agentcolour[ag]);
				}
			}
		}
		
		
		public void SaveProjectToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
		{
			save = "";
			save = System.Convert.ToString(xn + "_" + yn + "_" + zn + "_" + agent + "_");
			
			for (var i = 1; i <= agent; i++)
			{
				save = save + generator.Default.agentname[i] + "_";
			}
			
			for (var i = 1; i <= agent; i++)
			{
				save = save + generator.Default.agentcount[i] + "_";
			}
			
			for (var i = 1; i <= agent; i++)
			{
				save = save + generator.Default.initialenergy[i] + "_";
			}
			
			for (var i = 1; i <= agent; i++)
			{
				save = save + generator.Default.stepenergy[i] + "_";
			}
			
			for (var i = 1; i <= agent; i++)
			{
				save = save + generator.Default.bumpenergy[i] + "_";
			}
			
			
			for (var i = 1; i <= agent; i++)
			{
				save = save + generator.Default.aging[i] + "_";
			}
			
			
			for (var i = 1; i <= agent; i++)
			{
				save = save + generator.Default.agelimit[i] + "_";
			}
			
			
			for (var i = 1; i <= agent; i++)
			{
				save = save + generator.Default.asr[i] + "_";
			}
			
			
			for (var i = 1; i <= agent; i++)
			{
				save = save + generator.Default.asrtime[i] + "_";
			}
			
			for (var i = 1; i <= agent; i++)
			{
				save = save + generator.Default.asrenergy[i] + "_";
			}
			
			
			for (var i = 1; i <= agent; i++)
			{
				System.Drawing.ColorConverter colourconverter = new System.Drawing.ColorConverter();
				save = save + colourconverter.ConvertToString(generator.Default.agentcolour[i]) + "_";
			}
			
			
			for (var i = 1; i <= agent; i++)
			{
				save = save + generator.Default.agentrangeabsolute[i] + "_";
			}
			
			
			for (var a = 1; a <= agent; a++)
			{
				for (var b = 0; b <= 2; b++)
				{
					for (var c = 0; c <= 1; c++)
					{
						save = save + generator.Default.agentrange[a, b, c] + "_";
					}
				}
			}
			
			
			for (var a = 1; a <= agent; a++)
			{
				for (var b = 1; b <= agent; b++)
				{
					for (var c = 1; c <= 6; c++)
					{
						save = save + generator.Default.action[a, b, c] + "_";
					}
				}
			}
			
			
			
			
			save = save + "|";
			SaveFilepro.ShowDialog();
		}
		
		public void SaveFilepro_FileOk(System.Object sender, System.ComponentModel.CancelEventArgs e)
		{
			System.IO.StreamWriter objwriter = new System.IO.StreamWriter(SaveFilepro.FileName);
			objwriter.Write(save);
			objwriter.Close();
		}
		
		public void TickToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
		{
			Timerxy.Start();
			timerexit = true;
		}
		
		public void CreditToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
		{
			MessageBox.Show("Instructor: Dr. Brad Bass" + "\r\n" + "Programmer: Mohammad Zavvarian");
		}
		
		public void OpenProjectToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
		{
			OpenFilepro.ShowDialog();
		}
		
		public void OpenFilepro_FileOk(System.Object sender, System.ComponentModel.CancelEventArgs e)
		{
			System.IO.StreamReader objreader = new System.IO.StreamReader(OpenFilepro.FileName);
			save = objreader.ReadToEnd();
			objreader.Close();
			
			string[] import = new string[401];
			int n;
			
			for (var i = 1; i <= 400; i++)
			{
				n = 0;
				while (!(save.Substring(n, 1) == "_"))
				{
					n++;
					import[i] = save.Substring(0, n);
				}
				if (save.Substring(n + 1, 1) == "|")
				{
					break;
				}
				save = save.Substring(System.Convert.ToInt32(1 + n));
			}
			
			
			//....
			
			xn = int.Parse(import[1]);
			yn = int.Parse(import[2]);
			zn = int.Parse(import[3]);
			agent = int.Parse(import[4]);
			
			float ratio1 = yn / xn;
			float ratio2 = zn / xn;
			float ratio3 = yn / zn;
			int res = 2073600;
			
			sizexyx = System.Convert.ToInt32(Math.Pow((res / ratio1), 0.5));
			sizexyy = System.Convert.ToInt32(ratio1 * sizexyx);
			
			sizexzx = System.Convert.ToInt32(Math.Pow((res / ratio2), 0.5));
			sizexzz = System.Convert.ToInt32(ratio2 * sizexzx);
			
			sizezyz = System.Convert.ToInt32(Math.Pow((res / ratio3), 0.5));
			sizezyy = System.Convert.ToInt32(ratio3 * sizezyz);
			
			
			cellxyx = sizexyx / xn;
			cellxyy = sizexyy / yn;
			
			cellxzx = sizexzx / xn;
			cellxzz = sizexzz / zn;
			
			cellzyz = sizezyz / zn;
			cellzyy = sizezyy / yn;
			
			
			generator.Default.Close();
			generator.Default.Show();
			
			
			SizeToolStripMenuItem.Enabled = true;
			AIToolStripMenuItem.Enabled = true;
			collisionToolStripMenuItem.Enabled = true;
			
			
			
			//....
			
			int lastimport = System.Convert.ToInt32(0);
			
			for (var i = 1; i <= agent; i++)
			{
				lastimport = System.Convert.ToInt32(4 + i);
				generator.Default.agentname[i] = import[lastimport];
			}
			
			
			
			for (var i = 1; i <= agent; i++)
			{
				lastimport++;
				generator.Default.agentcount[i] = int.Parse(import[lastimport]);
			}
			
			
			for (var i = 1; i <= agent; i++)
			{
				lastimport++;
				generator.Default.initialenergy[i] = int.Parse(import[lastimport]);
			}
			
			
			for (var i = 1; i <= agent; i++)
			{
				lastimport++;
				generator.Default.stepenergy[i] = int.Parse(import[lastimport]);
			}
			
			
			for (var i = 1; i <= agent; i++)
			{
				lastimport++;
				generator.Default.bumpenergy[i] = int.Parse(import[lastimport]);
			}
			
			for (var i = 1; i <= agent; i++)
			{
				lastimport++;
				generator.Default.aging[i] = bool.Parse(import[lastimport]);
			}
			
			
			for (var i = 1; i <= agent; i++)
			{
				lastimport++;
				generator.Default.agelimit[i] = int.Parse(import[lastimport]);
			}
			
			for (var i = 1; i <= agent; i++)
			{
				lastimport++;
				generator.Default.asr[i] = bool.Parse(import[lastimport]);
			}
			
			
			for (var i = 1; i <= agent; i++)
			{
				lastimport++;
				generator.Default.asrtime[i] = int.Parse(import[lastimport]);
			}
			
			for (var i = 1; i <= agent; i++)
			{
				lastimport++;
				generator.Default.asrenergy[i] = int.Parse(import[lastimport]);
			}
			
			for (var i = 1; i <= agent; i++)
			{
				lastimport++;
				System.Drawing.ColorConverter colourconverter = new System.Drawing.ColorConverter();
				generator.Default.agentcolour[i] =  (System.Drawing.Color) (colourconverter.ConvertFromString(import[lastimport]));
			}
			
			
			for (var i = 1; i <= agent; i++)
			{
				lastimport++;
				generator.Default.agentrangeabsolute[i] = bool.Parse(import[lastimport]);
			}
			
			
			
			for (var a = 1; a <= agent; a++)
			{
				for (var b = 0; b <= 2; b++)
				{
					for (var c = 0; c <= 1; c++)
					{
						lastimport++;
						generator.Default.agentrange[a, b, c] = int.Parse(import[lastimport]);
					}
				}
			}
			
			
			for (var a = 1; a <= agent; a++)
			{
				for (var b = 1; b <= agent; b++)
				{
					for (var c = 1; c <= 6; c++)
					{
						lastimport++;
						generator.Default.action[a, b, c] = int.Parse(import[lastimport]);
					}
				}
			}
			
			
			
			//........applying the setting..............
			VBMath.Randomize();
			total = 0;
			
			int number = System.Convert.ToInt32(0);
			for (var a = 1; a <= agent; a++)
			{
				for (var i = 1; i <= generator.Default.agentcount[a]; i++)
				{
					number++;
					int x = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((xn) * VBMath.Rnd())))) + 1;
					int y = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((yn) * VBMath.Rnd())))) + 1;
					int z = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((zn) * VBMath.Rnd())))) + 1;
					
					int dx;
					int dy;
					int dz;
					
					int rangexupper = generator.Default.agentrange[a, 0, 1];
					int rangexlower = generator.Default.agentrange[a, 0, 0];
					int rangeyupper = generator.Default.agentrange[a, 1, 1];
					int rangeylower = generator.Default.agentrange[a, 1, 0];
					int rangezupper = generator.Default.agentrange[a, 2, 1];
					int rangezlower = generator.Default.agentrange[a, 2, 0];
					
					dx = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((rangexupper - rangexlower + 1) * VBMath.Rnd())))) + rangexlower;
					dy = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((rangeyupper - rangeylower + 1) * VBMath.Rnd())))) + rangeylower;
					dz = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((rangezupper - rangezlower + 1) * VBMath.Rnd())))) + rangezlower;
					
					
					while (generator.Default.occupied[x, y, z] == true)
					{
						x = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((xn) * VBMath.Rnd())))) + 1;
						y = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((yn) * VBMath.Rnd())))) + 1;
						z = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((zn) * VBMath.Rnd())))) + 1;
					}
					
					
					generator.Default.occupied[x, y, z] = true;
					
					int d = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((6) * VBMath.Rnd())))) + 1;
					generator.Default.agentlocation[number, 0] = x;
					generator.Default.agentlocation[number, 1] = y;
					generator.Default.agentlocation[number, 2] = z;
					generator.Default.agentlocation[number, 3] = d;
					generator.Default.agentlocation[number, 4] = System.Convert.ToInt32(a);
					generator.Default.agentlocation[number, 5] = dx;
					generator.Default.agentlocation[number, 6] = dy;
					generator.Default.agentlocation[number, 7] = dz;
					generator.Default.agentlocation[number, 8] = generator.Default.initialenergy[a];
					generator.Default.agentlocation[number, 9] = 0;
					generator.Default.agentlocation[number, 10] = 0;
					
				}
				
			}
			
			
			//...........................................................................................................
			
			for (var i = 1; i <= agent; i++)
			{
				total = total + generator.Default.agentcount[i];
			}
			
			
			
			for (var index = 2; index <= total; index++)
			{
				int tempz = generator.Default.agentlocation[index, 2];
				int tempx = generator.Default.agentlocation[index, 0];
				int tempy = generator.Default.agentlocation[index, 1];
				int tempd = generator.Default.agentlocation[index, 3];
				int tempa = generator.Default.agentlocation[index, 4];
				
				int tempdx = generator.Default.agentlocation[index, 5];
				int tempdy = generator.Default.agentlocation[index, 6];
				int tempdz = generator.Default.agentlocation[index, 7];
				
				int tempenergy = generator.Default.agentlocation[index, 8];
				int tempage = generator.Default.agentlocation[index, 9];
				int tempasr = generator.Default.agentlocation[index, 10];
				
				int previousposition = System.Convert.ToInt32(index - 1);
				while (tempz > generator.Default.agentlocation[previousposition, 2] && previousposition >= 1)
				{
					generator.Default.agentlocation[previousposition + 1, 0] = generator.Default.agentlocation[previousposition, 0];
					generator.Default.agentlocation[previousposition + 1, 1] = generator.Default.agentlocation[previousposition, 1];
					generator.Default.agentlocation[previousposition + 1, 2] = generator.Default.agentlocation[previousposition, 2];
					generator.Default.agentlocation[previousposition + 1, 3] = generator.Default.agentlocation[previousposition, 3];
					generator.Default.agentlocation[previousposition + 1, 4] = generator.Default.agentlocation[previousposition, 4];
					
					generator.Default.agentlocation[previousposition + 1, 5] = generator.Default.agentlocation[previousposition, 5];
					generator.Default.agentlocation[previousposition + 1, 6] = generator.Default.agentlocation[previousposition, 6];
					generator.Default.agentlocation[previousposition + 1, 7] = generator.Default.agentlocation[previousposition, 7];
					
					generator.Default.agentlocation[previousposition + 1, 8] = generator.Default.agentlocation[previousposition, 8];
					generator.Default.agentlocation[previousposition + 1, 9] = generator.Default.agentlocation[previousposition, 9];
					generator.Default.agentlocation[previousposition + 1, 10] = generator.Default.agentlocation[previousposition, 10];
					
					previousposition--;
				}
				generator.Default.agentlocation[previousposition + 1, 2] = tempz;
				generator.Default.agentlocation[previousposition + 1, 0] = tempx;
				generator.Default.agentlocation[previousposition + 1, 1] = tempy;
				generator.Default.agentlocation[previousposition + 1, 3] = tempd;
				generator.Default.agentlocation[previousposition + 1, 4] = tempa;
				
				generator.Default.agentlocation[previousposition + 1, 5] = tempdx;
				generator.Default.agentlocation[previousposition + 1, 6] = tempdy;
				generator.Default.agentlocation[previousposition + 1, 7] = tempdz;
				
				generator.Default.agentlocation[previousposition + 1, 8] = tempenergy;
				generator.Default.agentlocation[previousposition + 1, 9] = tempage;
				generator.Default.agentlocation[previousposition + 1, 10] = tempasr;
				
			}
			
			
			
			
			
			
			generator.Default.gfxxy.Clear(Color.White);
			generator.Default.gridxy();
			
			// placing the agents
			for (var i = 1; i <= total; i++)
			{
				int x = generator.Default.agentlocation[i, 0];
				int y = generator.Default.agentlocation[i, 1];
				int z = generator.Default.agentlocation[i, 2];
				int d = generator.Default.agentlocation[i, 3];
				int ag = generator.Default.agentlocation[i, 4];
				if (d == 1)
				{
					creator(x.ToString(), y, z, "down", generator.Default.agentcolour[ag]);
				}
				else if (d == 2)
				{
					creator(x.ToString(), y, z, "up", generator.Default.agentcolour[ag]);
				}
				else if (d == 3)
				{
					creator(x.ToString(), y, z, "left", generator.Default.agentcolour[ag]);
				}
				else if (d == 4)
				{
					creator(x.ToString(), y, z, "right", generator.Default.agentcolour[ag]);
				}
				else if (d == 5)
				{
					creator(x.ToString(), y, z, "front", generator.Default.agentcolour[ag]);
				}
				else if (d == 6)
				{
					creator(x.ToString(), y, z, "back", generator.Default.agentcolour[ag]);
				}
			}
			
			
			generator.Default.topgridxy();
			picshow();
			
			tick = 0;
		}
	}
	
}
