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
	public partial class Form4
	{
		public Form4()
		{
			InitializeComponent();
			
			//Added to support default instance behavour in C#
			if (defaultInstance == null)
				defaultInstance = this;
		}
		
		#region Default Instance
		
		private static Form4 defaultInstance;
		
		/// <summary>
		/// Added by the VB.Net to C# Converter to support default instance behavour in C#
		/// </summary>
		public static Form4 Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new Form4();
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
		
		public void Form4_Load(System.Object sender, System.EventArgs e)
		{
			Timer1.Start();
		}
		
		public void Timer1_Tick(System.Object sender, System.EventArgs e)
		{
			//Dim txt As String
			
			string index;
			string x;
			string y;
			string z;
			string agenttype;
			string energy;
			string age;
			
			
			
			index = "";
			x = "";
			y = "";
			z = "";
			agenttype = "";
			energy = "";
			age = "";
			
			
			index = "Agent number: " + "\r\n";
			x = "X-Value: " + "\r\n";
			y = "Y-Value: " + "\r\n";
			z = "Z-Value: " + "\r\n";
			agenttype = "Agent Type: " + "\r\n";
			energy = "Agent Energy: " + "\r\n";
			age = "Agent Age: " + "\r\n";
			
			
			
			//txt = ""
			//txt = "Agent#:" & "         " & "X" & "         " & "Y" & "         " & "Z" & "         " & "agent" & "         " & "Energy" & vbCrLf
			
			
			
			
			for (var i = 1; i <= Form1.Default.total; i++)
			{
				//txt = txt & "     " & i & "              " & generator.agentlocation(i, 0) & "       " & generator.agentlocation(i, 1) & "       " & generator.agentlocation(i, 2) & "       " & generator.agentlocation(i, 4) & "       " & generator.agentlocation(i, 8) & vbCrLf
				
				
				index = index + i + "\r\n";
				x = x + generator.Default.agentlocation[i, 0] + "\r\n";
				y = y + generator.Default.agentlocation[i, 1] + "\r\n";
				z = z + generator.Default.agentlocation[i, 2] + "\r\n";
				agenttype = agenttype + generator.Default.agentname[generator.Default.agentlocation[i, 4]] + "\r\n";
				energy = energy + generator.Default.agentlocation[i, 8] + "\r\n";
				age = age + generator.Default.agentlocation[i, 9] + "\r\n";
			}
			
			
			labelagentnumber.Text = index;
			labelX.Text = x;
			labelY.Text = y;
			labelZ.Text = z;
			labelAGENTTYPE.Text = agenttype;
			labelENERGY.Text = energy;
			labelAGE.Text = age;
			
			
			if ((labelagentnumber.Location.Y + labelagentnumber.Size.Height + 12) > this.Size.Height)
			{
				VScrollBar1.Maximum = System.Convert.ToInt32(1 + ((labelagentnumber.Location.Y + labelagentnumber.Size.Height + 12) - this.Size.Height) / 13);
			}
			
			Panel1.Location = new Point(Panel1.Location.X, VScrollBar1.Value * -13);
			Panel1.Size = new Size(Panel1.Size.Width, Panel1.Size.Height + (VScrollBar1.Value * 13) + 12);
			
			//labelagentnumber.Text = txt
		}
		
		
		
	}
}
