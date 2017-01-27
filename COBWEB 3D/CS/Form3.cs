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
	public partial class Form3
	{
		public Form3()
		{
			InitializeComponent();
			
			//Added to support default instance behavour in C#
			if (defaultInstance == null)
				defaultInstance = this;
		}
		
		#region Default Instance
		
		private static Form3 defaultInstance;
		
		/// <summary>
		/// Added by the VB.Net to C# Converter to support default instance behavour in C#
		/// </summary>
		public static Form3 Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new Form3();
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
		private int red;
		private int blue;
		private int green;
		public void Form3_Load(System.Object sender, System.EventArgs e)
		{
			for (var i = 1; i <= Form1.Default.agent; i++)
			{
				ComboBoxagent.Items.Add(generator.Default.agentname[i]);
			}
		}
		
		public void ComboBoxagent_SelectedIndexChanged(System.Object sender, System.EventArgs e)
		{
			if (ComboBoxagent.Text != "")
			{
				TextBoxcount.Enabled = true;
				TextBoxname.Enabled = true;
				GroupBox1.Enabled = true;
				TextBoxinienergy.Enabled = true;
				TextBoxstepenergy.Enabled = true;
				TextBoxbumpenergy.Enabled = true;
				GroupBoxaging.Enabled = true;
				GroupBox3.Enabled = true;
				GroupBox4.Enabled = true;
				txtasr.Enabled = true;
				txtasrenergy.Enabled = true;
			}
			
			
			
			TextBoxcount.Text = "";
			for (var i = 1; i <= Form1.Default.agent; i++)
			{
				if (ComboBoxagent.SelectedIndex + 1 == i)
				{
					TextBoxcount.Text = System.Convert.ToString(generator.Default.agentcount[ComboBoxagent.SelectedIndex + 1]);
					TextBoxname.Text = generator.Default.agentname[ComboBoxagent.SelectedIndex + 1];
					TrackBar4.Value = System.Convert.ToInt32(generator.Default.agentcolour[ComboBoxagent.SelectedIndex + 1].R / 25);
					TrackBar2.Value = System.Convert.ToInt32(generator.Default.agentcolour[ComboBoxagent.SelectedIndex + 1].G / 25);
					TrackBar3.Value = System.Convert.ToInt32(generator.Default.agentcolour[ComboBoxagent.SelectedIndex + 1].B / 25);
					TextBox1.Text = System.Convert.ToString(TrackBar4.Value * 25);
					TextBox2.Text = System.Convert.ToString(TrackBar2.Value * 25);
					TextBox3.Text = System.Convert.ToString(TrackBar3.Value * 25);
					red = generator.Default.agentcolour[ComboBoxagent.SelectedIndex + 1].R;
					green = generator.Default.agentcolour[ComboBoxagent.SelectedIndex + 1].G;
					blue = generator.Default.agentcolour[ComboBoxagent.SelectedIndex + 1].B;
					colour.BackColor = generator.Default.agentcolour[ComboBoxagent.SelectedIndex + 1];
					
					TextBoxinienergy.Text = System.Convert.ToString(generator.Default.initialenergy[ComboBoxagent.SelectedIndex + 1]);
					TextBoxstepenergy.Text = System.Convert.ToString(generator.Default.stepenergy[ComboBoxagent.SelectedIndex + 1]);
					TextBoxbumpenergy.Text = System.Convert.ToString(generator.Default.bumpenergy[ComboBoxagent.SelectedIndex + 1]);
					CheckBoxaging.Checked = generator.Default.aging[ComboBoxagent.SelectedIndex + 1];
					TextBoxagelimit.Text = System.Convert.ToString(generator.Default.agelimit[ComboBoxagent.SelectedIndex + 1]);
					txtasr.Text = System.Convert.ToString(generator.Default.asrtime[ComboBoxagent.SelectedIndex + 1]);
					txtasrenergy.Text = System.Convert.ToString(generator.Default.asrenergy[ComboBoxagent.SelectedIndex + 1]);
				}
			}
		}
		
		public void TextBox5_TextChanged(System.Object sender, System.EventArgs e)
		{
			if (Information.IsNumeric(TextBoxcount.Text))
			{
				generator.Default.agentcount[ComboBoxagent.SelectedIndex + 1] = int.Parse(TextBoxcount.Text);
			}
		}
		
		public void Button1_Click(System.Object sender, System.EventArgs e)
		{
			VBMath.Randomize();
			Form1.Default.total = 0;
			Form1.Default.tick = 0;
			
			int number = System.Convert.ToInt32(0);
			for (var a = 1; a <= Form1.Default.agent; a++)
			{
				for (var i = 1; i <= generator.Default.agentcount[a]; i++)
				{
					number++;
					int x = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((Form1.Default.xn) * VBMath.Rnd())))) + 1;
					int y = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((Form1.Default.yn) * VBMath.Rnd())))) + 1;
					int z = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((Form1.Default.zn) * VBMath.Rnd())))) + 1;
					
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
						x = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((Form1.Default.xn) * VBMath.Rnd())))) + 1;
						y = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((Form1.Default.yn) * VBMath.Rnd())))) + 1;
						z = (System.Convert.ToInt32(Math.Floor(System.Convert.ToDecimal((Form1.Default.zn) * VBMath.Rnd())))) + 1;
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
			
			for (var i = 1; i <= Form1.Default.agent; i++)
			{
				Form1.Default.total = Form1.Default.total + generator.Default.agentcount[i];
			}
			
			
			
			for (var index = 2; index <= Form1.Default.total; index++)
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
			for (var i = 1; i <= Form1.Default.total; i++)
			{
				int x = generator.Default.agentlocation[i, 0];
				int y = generator.Default.agentlocation[i, 1];
				int z = generator.Default.agentlocation[i, 2];
				int d = generator.Default.agentlocation[i, 3];
				int ag = generator.Default.agentlocation[i, 4];
				if (d == 1)
				{
					Form1.Default.creator(x.ToString(), y, z, "down", generator.Default.agentcolour[ag]);
				}
				else if (d == 2)
				{
					Form1.Default.creator(x.ToString(), y, z, "up", generator.Default.agentcolour[ag]);
				}
				else if (d == 3)
				{
					Form1.Default.creator(x.ToString(), y, z, "left", generator.Default.agentcolour[ag]);
				}
				else if (d == 4)
				{
					Form1.Default.creator(x.ToString(), y, z, "right", generator.Default.agentcolour[ag]);
				}
				else if (d == 5)
				{
					Form1.Default.creator(x.ToString(), y, z, "front", generator.Default.agentcolour[ag]);
				}
				else if (d == 6)
				{
					Form1.Default.creator(x.ToString(), y, z, "back", generator.Default.agentcolour[ag]);
				}
			}
			
			
			generator.Default.topgridxy();
			Form1.Default.picshow();
			//Form1.PictureBox1.Image = generator.picxy
			
			
			this.Close();
			
		}
		
		
		public void TextBoxname_Validated(object sender, System.EventArgs e)
		{
			generator.Default.agentname[ComboBoxagent.SelectedIndex + 1] = TextBoxname.Text;
			
			ComboBoxagent.Items.Clear();
			for (var i = 1; i <= Form1.Default.agent; i++)
			{
				ComboBoxagent.Items.Add(generator.Default.agentname[i]);
			}
			
			ComboBoxagent.Text = TextBoxname.Text;
		}
		
		
		public void TextBox1_TextChanged(System.Object sender, System.EventArgs e)
		{
			red = int.Parse(TextBox1.Text);
			colour.BackColor = Color.FromArgb(red, green, blue);
		}
		
		public void TextBox2_TextChanged(System.Object sender, System.EventArgs e)
		{
			green = int.Parse(TextBox2.Text);
			colour.BackColor = Color.FromArgb(red, green, blue);
		}
		
		public void TextBox3_TextChanged(System.Object sender, System.EventArgs e)
		{
			blue = int.Parse(TextBox3.Text);
			colour.BackColor = Color.FromArgb(red, green, blue);
		}
		
		public void TrackBar4_Scroll(System.Object sender, System.EventArgs e)
		{
			red = TrackBar4.Value * 25;
			TextBox1.Text = red.ToString();
			colour.BackColor = Color.FromArgb(red, green, blue);
			generator.Default.agentcolour[ComboBoxagent.SelectedIndex + 1] = colour.BackColor;
		}
		
		public void TrackBar3_Scroll(System.Object sender, System.EventArgs e)
		{
			blue = TrackBar3.Value * 25;
			TextBox3.Text = blue.ToString();
			colour.BackColor = Color.FromArgb(red, green, blue);
			generator.Default.agentcolour[ComboBoxagent.SelectedIndex + 1] = colour.BackColor;
		}
		
		public void TrackBar2_Scroll(System.Object sender, System.EventArgs e)
		{
			green = TrackBar2.Value * 25;
			TextBox2.Text = green.ToString();
			colour.BackColor = Color.FromArgb(red, green, blue);
			generator.Default.agentcolour[ComboBoxagent.SelectedIndex + 1] = colour.BackColor;
		}
		
		public void TextBox4_TextChanged(System.Object sender, System.EventArgs e)
		{
			if (Information.IsNumeric(TextBoxinienergy.Text))
			{
				generator.Default.initialenergy[ComboBoxagent.SelectedIndex + 1] = int.Parse(TextBoxinienergy.Text);
			}
		}
		
		public void TextBox5_TextChanged_1(System.Object sender, System.EventArgs e)
		{
			if (Information.IsNumeric(TextBoxstepenergy.Text))
			{
				generator.Default.stepenergy[ComboBoxagent.SelectedIndex + 1] = int.Parse(TextBoxstepenergy.Text);
			}
		}
		
		public void TextBoxbumpenergy_TextChanged(System.Object sender, System.EventArgs e)
		{
			if (Information.IsNumeric(TextBoxbumpenergy.Text))
			{
				generator.Default.bumpenergy[ComboBoxagent.SelectedIndex + 1] = int.Parse(TextBoxbumpenergy.Text);
			}
		}
		
		public void TextBox7_TextChanged(System.Object sender, System.EventArgs e)
		{
			if (Information.IsNumeric(TextBoxagelimit.Text))
			{
				generator.Default.agelimit[ComboBoxagent.SelectedIndex + 1] = int.Parse(TextBoxagelimit.Text);
			}
		}
		
		public void CheckBox1_CheckedChanged(System.Object sender, System.EventArgs e)
		{
			if (CheckBoxaging.Checked == true)
			{
				generator.Default.aging[ComboBoxagent.SelectedIndex + 1] = true;
			}
			else if (CheckBoxaging.Checked == false)
			{
				generator.Default.aging[ComboBoxagent.SelectedIndex + 1] = false;
			}
		}
		
		public void CheckBox2_CheckedChanged(System.Object sender, System.EventArgs e)
		{
			if (CheckBoxasr.Checked == true)
			{
				generator.Default.asr[ComboBoxagent.SelectedIndex + 1] = true;
			}
			else if (CheckBoxasr.Checked == false)
			{
				generator.Default.asr[ComboBoxagent.SelectedIndex + 1] = false;
			}
		}
		
		public void txtasr_TextChanged(System.Object sender, System.EventArgs e)
		{
			if (Information.IsNumeric(txtasr.Text))
			{
				generator.Default.asrtime[ComboBoxagent.SelectedIndex + 1] = int.Parse(txtasr.Text);
			}
		}
		
		public void txtasrenergy_TextChanged(System.Object sender, System.EventArgs e)
		{
			if (Information.IsNumeric(txtasrenergy.Text))
			{
				generator.Default.asrenergy[ComboBoxagent.SelectedIndex + 1] = int.Parse(txtasrenergy.Text);
			}
		}
	}
}
