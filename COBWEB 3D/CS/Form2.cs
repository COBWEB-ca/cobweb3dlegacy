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
	public partial class Form2
	{
		public Form2()
		{
			InitializeComponent();
			
			//Added to support default instance behavour in C#
			if (defaultInstance == null)
				defaultInstance = this;
		}
		
		#region Default Instance
		
		private static Form2 defaultInstance;
		
		/// <summary>
		/// Added by the VB.Net to C# Converter to support default instance behavour in C#
		/// </summary>
		public static Form2 Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new Form2();
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
		
		public void Button1_Click(System.Object sender, System.EventArgs e)
		{
			Form1.Default.xn = int.Parse(TextBox1.Text);
			Form1.Default.yn = int.Parse(TextBox2.Text);
			Form1.Default.zn = int.Parse(TextBox3.Text);
			Form1.Default.agent = int.Parse(TextBox4.Text);
			
			float ratio1 = Form1.Default.yn / Form1.Default.xn;
			float ratio2 = Form1.Default.zn / Form1.Default.xn;
			float ratio3 = Form1.Default.yn / Form1.Default.zn;
			int res = 2073600;
			
			Form1.Default.sizexyx = System.Convert.ToInt32(Math.Pow((res / ratio1), 0.5));
			Form1.Default.sizexyy = System.Convert.ToInt32(ratio1 * Form1.Default.sizexyx);
			
			Form1.Default.sizexzx = System.Convert.ToInt32(Math.Pow((res / ratio2), 0.5));
			Form1.Default.sizexzz = System.Convert.ToInt32(ratio2 * Form1.Default.sizexzx);
			
			Form1.Default.sizezyz = System.Convert.ToInt32(Math.Pow((res / ratio3), 0.5));
			Form1.Default.sizezyy = System.Convert.ToInt32(ratio3 * Form1.Default.sizezyz);
			
			
			Form1.Default.cellxyx = Form1.Default.sizexyx / Form1.Default.xn;
			Form1.Default.cellxyy = Form1.Default.sizexyy / Form1.Default.yn;
			
			Form1.Default.cellxzx = Form1.Default.sizexzx / Form1.Default.xn;
			Form1.Default.cellxzz = Form1.Default.sizexzz / Form1.Default.zn;
			
			Form1.Default.cellzyz = Form1.Default.sizezyz / Form1.Default.zn;
			Form1.Default.cellzyy = Form1.Default.sizezyy / Form1.Default.yn;
			
			
			generator.Default.Close();
			generator.Default.Show();
			
			
			Form1.Default.SizeToolStripMenuItem.Enabled = true;
			Form1.Default.AIToolStripMenuItem.Enabled = true;
			Form1.Default.collisionToolStripMenuItem.Enabled = true;
			this.Close();
			
			
			
		}
		
		private void PictureBox1_Click(System.Object sender, System.EventArgs e)
		{
			
		}
		
		public void TextBox4_TextChanged(System.Object sender, System.EventArgs e)
		{
			
		}
		
		private void TextBox5_TextChanged(System.Object sender, System.EventArgs e)
		{
			
			//If IsNumeric(chromosometext.Text) Then
			//chromosomelabel2.Enabled = True
			//chromosomecombo.Enabled = True
			//chromosomecombo.Items.Clear()
			//Dim chromosome As Integer = chromosometext.Text
			//For i = 1 To chromosome
			//chromosomecombo.Items.Add("chromosome" & i)
			//Next
			//ElseIf chromosometext.Text = "" Then
			//chromosomelabel2.Enabled = False
			//chromosomecombo.Enabled = False
			// Else
			//MsgBox("Please enter numbers only")
			//chromosometext.Text = ""
			//End If
			
		}
		
		private void TabPage1_Click(object sender, System.EventArgs e)
		{
			
		}
		
		private void TabPage3_Click(System.Object sender, System.EventArgs e)
		{
			
		}
		
		private void TextBox5_TextChanged_1(System.Object sender, System.EventArgs e)
		{
			
		}
		
		private void ComboBox8_SelectedIndexChanged(System.Object sender, System.EventArgs e)
		{
			//If ComboBox8.Text <> "" Then
			//TextBox5.Enabled = True
			//End If
		}
	}
}
