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
	public partial class Form5
	{
		public Form5()
		{
			InitializeComponent();
			
			//Added to support default instance behavour in C#
			if (defaultInstance == null)
				defaultInstance = this;
		}
		
		#region Default Instance
		
		private static Form5 defaultInstance;
		
		/// <summary>
		/// Added by the VB.Net to C# Converter to support default instance behavour in C#
		/// </summary>
		public static Form5 Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new Form5();
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
		
		public void check()
		{
			if (CheckBoxconsume.Checked == false && CheckBoxproduce.Checked == false && CheckBoxdeminish.Checked == true)
			{
				generator.Default.action[ComboBoxagent.SelectedIndex + 1, ComboBox1.SelectedIndex + 1, 1] = 3;
			}
			else if (CheckBoxconsume.Checked == true && CheckBoxproduce.Checked == false && CheckBoxdeminish.Checked == true)
			{
				generator.Default.action[ComboBoxagent.SelectedIndex + 1, ComboBox1.SelectedIndex + 1, 1] = 5;
			}
			else if (CheckBoxconsume.Checked == false && CheckBoxproduce.Checked == true && CheckBoxdeminish.Checked == true)
			{
				generator.Default.action[ComboBoxagent.SelectedIndex + 1, ComboBox1.SelectedIndex + 1, 1] = 6;
			}
			else if (CheckBoxconsume.Checked == true && CheckBoxproduce.Checked == false && CheckBoxdeminish.Checked == false)
			{
				generator.Default.action[ComboBoxagent.SelectedIndex + 1, ComboBox1.SelectedIndex + 1, 1] = 2;
			}
			else if (CheckBoxconsume.Checked == false && CheckBoxproduce.Checked == true && CheckBoxdeminish.Checked == false)
			{
				generator.Default.action[ComboBoxagent.SelectedIndex + 1, ComboBox1.SelectedIndex + 1, 1] = 1;
			}
			else if (CheckBoxconsume.Checked == true && CheckBoxproduce.Checked == true && CheckBoxdeminish.Checked == false)
			{
				generator.Default.action[ComboBoxagent.SelectedIndex + 1, ComboBox1.SelectedIndex + 1, 1] = 4;
			}
			else if (CheckBoxconsume.Checked == true && CheckBoxproduce.Checked == true && CheckBoxdeminish.Checked == true)
			{
				generator.Default.action[ComboBoxagent.SelectedIndex + 1, ComboBox1.SelectedIndex + 1, 1] = 7;
			}
			else if (CheckBoxconsume.Checked == false && CheckBoxproduce.Checked == false && CheckBoxdeminish.Checked == false)
			{
				generator.Default.action[ComboBoxagent.SelectedIndex + 1, ComboBox1.SelectedIndex + 1, 1] = 0;
			}
		}
		
		
		
		public void Form5_Load(System.Object sender, System.EventArgs e)
		{
			for (var i = 1; i <= Form1.Default.agent; i++)
			{
				ComboBoxagent.Items.Add(generator.Default.agentname[i]);
				ComboBox1.Items.Add(generator.Default.agentname[i]);
				ComboBox2.Items.Add(generator.Default.agentname[i]);
			}
			
		}
		
		public void Button1_Click(System.Object sender, System.EventArgs e)
		{
			this.Close();
		}
		
		
		
		public void CheckBox2_CheckedChanged(System.Object sender, System.EventArgs e)
		{
			
			check();
			
		}
		
		public void CheckBox3_CheckedChanged(System.Object sender, System.EventArgs e)
		{
			check();
			
		}
		
		public void ComboBox2_SelectedIndexChanged(System.Object sender, System.EventArgs e)
		{
			generator.Default.action[ComboBoxagent.SelectedIndex + 1, ComboBox1.SelectedIndex + 1, 2] = ComboBox2.SelectedIndex + 1;
		}
		
		public void CheckBox1_CheckedChanged(System.Object sender, System.EventArgs e)
		{
			check();
		}
		
		public void ComboBoxagent_SelectedIndexChanged(System.Object sender, System.EventArgs e)
		{
			
			for (var a = 1; a <= Form1.Default.agent; a++)
			{
				for (var b = 1; b <= Form1.Default.agent; b++)
				{
					if (ComboBoxagent.SelectedIndex + 1 == a && ComboBox1.SelectedIndex + 1 == b)
					{
						
						if (generator.Default.action[a, b, 1] == 1)
						{
							CheckBoxconsume.Checked = false;
							CheckBoxproduce.Checked = true;
							CheckBoxdeminish.Checked = false;
						}
						else if (generator.Default.action[a, b, 1] == 2)
						{
							CheckBoxconsume.Checked = true;
							CheckBoxproduce.Checked = false;
							CheckBoxdeminish.Checked = false;
						}
						else if (generator.Default.action[a, b, 1] == 3)
						{
							CheckBoxconsume.Checked = false;
							CheckBoxproduce.Checked = false;
							CheckBoxdeminish.Checked = true;
						}
						else if (generator.Default.action[a, b, 1] == 4)
						{
							CheckBoxconsume.Checked = true;
							CheckBoxproduce.Checked = true;
							CheckBoxdeminish.Checked = false;
						}
						else if (generator.Default.action[a, b, 1] == 5)
						{
							CheckBoxconsume.Checked = true;
							CheckBoxproduce.Checked = false;
							CheckBoxdeminish.Checked = true;
						}
						else if (generator.Default.action[a, b, 1] == 6)
						{
							CheckBoxconsume.Checked = false;
							CheckBoxproduce.Checked = true;
							CheckBoxdeminish.Checked = true;
						}
						else if (generator.Default.action[a, b, 1] == 7)
						{
							CheckBoxconsume.Checked = true;
							CheckBoxproduce.Checked = true;
							CheckBoxdeminish.Checked = true;
						}
						else if (generator.Default.action[a, b, 1] == 0)
						{
							CheckBoxconsume.Checked = false;
							CheckBoxproduce.Checked = false;
							CheckBoxdeminish.Checked = false;
						}
						
						
						ComboBox2.SelectedIndex = System.Convert.ToInt32(generator.Default.action[a, b, 2] - 1);
						TextBox1.Text = System.Convert.ToString(generator.Default.action[a, b, 3]);
						TextBox2.Text = System.Convert.ToString(generator.Default.action[a, b, 4]);
						TextBox3.Text = System.Convert.ToString(generator.Default.action[a, b, 5]);
						if (generator.Default.action[a, b, 6] == 1)
						{
							RadioButton1.Checked = true;
						}
						else if (generator.Default.action[a, b, 6] == 2)
						{
							RadioButton2.Checked = true;
						}
						
						
					}
				}
			}
		}
		
		public void ComboBox1_SelectedIndexChanged(System.Object sender, System.EventArgs e)
		{
			for (var a = 1; a <= Form1.Default.agent; a++)
			{
				for (var b = 1; b <= Form1.Default.agent; b++)
				{
					if (ComboBoxagent.SelectedIndex + 1 == a && ComboBox1.SelectedIndex + 1 == b)
					{
						
						if (generator.Default.action[a, b, 1] == 1)
						{
							CheckBoxconsume.Checked = false;
							CheckBoxproduce.Checked = true;
							CheckBoxdeminish.Checked = false;
						}
						else if (generator.Default.action[a, b, 1] == 2)
						{
							CheckBoxconsume.Checked = true;
							CheckBoxproduce.Checked = false;
							CheckBoxdeminish.Checked = false;
						}
						else if (generator.Default.action[a, b, 1] == 3)
						{
							CheckBoxconsume.Checked = false;
							CheckBoxproduce.Checked = false;
							CheckBoxdeminish.Checked = true;
						}
						else if (generator.Default.action[a, b, 1] == 4)
						{
							CheckBoxconsume.Checked = true;
							CheckBoxproduce.Checked = true;
							CheckBoxdeminish.Checked = false;
						}
						else if (generator.Default.action[a, b, 1] == 5)
						{
							CheckBoxconsume.Checked = true;
							CheckBoxproduce.Checked = false;
							CheckBoxdeminish.Checked = true;
						}
						else if (generator.Default.action[a, b, 1] == 6)
						{
							CheckBoxconsume.Checked = false;
							CheckBoxproduce.Checked = true;
							CheckBoxdeminish.Checked = true;
						}
						else if (generator.Default.action[a, b, 1] == 7)
						{
							CheckBoxconsume.Checked = true;
							CheckBoxproduce.Checked = true;
							CheckBoxdeminish.Checked = true;
						}
						else if (generator.Default.action[a, b, 1] == 0)
						{
							CheckBoxconsume.Checked = false;
							CheckBoxproduce.Checked = false;
							CheckBoxdeminish.Checked = false;
						}
						
						
						ComboBox2.SelectedIndex = System.Convert.ToInt32(generator.Default.action[a, b, 2] - 1);
						TextBox1.Text = System.Convert.ToString(generator.Default.action[a, b, 3]);
						TextBox2.Text = System.Convert.ToString(generator.Default.action[a, b, 4]);
						TextBox3.Text = System.Convert.ToString(generator.Default.action[a, b, 5]);
						if (generator.Default.action[a, b, 6] == 1)
						{
							RadioButton1.Checked = true;
						}
						else if (generator.Default.action[a, b, 6] == 2)
						{
							RadioButton2.Checked = true;
						}
						
						
						
						
						
					}
				}
			}
		}
		
		public void TextBox1_TextChanged(System.Object sender, System.EventArgs e)
		{
			if (Information.IsNumeric(TextBox1.Text))
			{
				generator.Default.action[ComboBoxagent.SelectedIndex + 1, ComboBox1.SelectedIndex + 1, 3] = int.Parse(TextBox1.Text);
			}
		}
		
		public void TextBox2_TextChanged(System.Object sender, System.EventArgs e)
		{
			if (Information.IsNumeric(TextBox2.Text))
			{
				generator.Default.action[ComboBoxagent.SelectedIndex + 1, ComboBox1.SelectedIndex + 1, 4] = int.Parse(TextBox2.Text);
			}
		}
		
		public void TextBox3_TextChanged(System.Object sender, System.EventArgs e)
		{
			if (Information.IsNumeric(TextBox3.Text))
			{
				generator.Default.action[ComboBoxagent.SelectedIndex + 1, ComboBox1.SelectedIndex + 1, 5] = int.Parse(TextBox3.Text);
			}
		}
		
		public void RadioButton1_CheckedChanged(System.Object sender, System.EventArgs e)
		{
			generator.Default.action[ComboBoxagent.SelectedIndex + 1, ComboBox1.SelectedIndex + 1, 6] = 1;
		}
		
		public void RadioButton2_CheckedChanged(System.Object sender, System.EventArgs e)
		{
			generator.Default.action[ComboBoxagent.SelectedIndex + 1, ComboBox1.SelectedIndex + 1, 6] = 2;
		}
	}
}
