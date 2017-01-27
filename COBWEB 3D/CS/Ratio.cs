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
	public partial class Ratio
	{
		public Ratio()
		{
			InitializeComponent();
			
			//Added to support default instance behavour in C#
			if (defaultInstance == null)
				defaultInstance = this;
		}
		
		#region Default Instance
		
		private static Ratio defaultInstance;
		
		/// <summary>
		/// Added by the VB.Net to C# Converter to support default instance behavour in C#
		/// </summary>
		public static Ratio Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new Ratio();
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
		
		public void TrackBar1_Scroll(System.Object sender, System.EventArgs e)
		{
			Form1.Default.sizeratio = System.Convert.ToDouble((TrackBar1.Value + 2) / (TrackBar1.Value + 3));
			//MsgBox(Form1.sizeratio)
			generator.Default.gfxxy.Clear(Color.White);
			generator.Default.gridxy();
			generator.Default.topgridxy();
			Form1.Default.picshow();
		}
		
		public void Button1_Click(System.Object sender, System.EventArgs e)
		{
			this.Close();
		}
		
		public void Ratio_Load(System.Object sender, System.EventArgs e)
		{
			TrackBar1.Value = System.Convert.ToInt32((2 - (Form1.Default.sizeratio * 3)) / (Form1.Default.sizeratio - 1));
		}
	}
}
