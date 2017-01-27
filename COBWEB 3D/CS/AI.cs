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
	public partial class AI
	{
		public AI()
		{
			InitializeComponent();
			
			//Added to support default instance behavour in C#
			if (defaultInstance == null)
				defaultInstance = this;
		}
		
		#region Default Instance
		
		private static AI defaultInstance;
		
		/// <summary>
		/// Added by the VB.Net to C# Converter to support default instance behavour in C#
		/// </summary>
		public static AI Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new AI();
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
		
		public void AI_Load(System.Object sender, System.EventArgs e)
		{
			for (var i = 1; i <= Form1.Default.agent; i++)
			{
				ComboBoxagent.Items.Add(generator.Default.agentname[i]);
			}
		}
		
		public void TextBox1_TextChanged(System.Object sender, System.EventArgs e)
		{
			if (Information.IsNumeric(TextBox1.Text))
			{
				generator.Default.agentrange[ComboBoxagent.SelectedIndex + 1, 0, 0] = int.Parse(TextBox1.Text);
			}
		}
		
		public void TextBox2_TextChanged(System.Object sender, System.EventArgs e)
		{
			if (Information.IsNumeric(TextBox2.Text))
			{
				generator.Default.agentrange[ComboBoxagent.SelectedIndex + 1, 0, 1] = int.Parse(TextBox2.Text);
			}
		}
		
		public void TextBox3_TextChanged(System.Object sender, System.EventArgs e)
		{
			if (Information.IsNumeric(TextBox3.Text))
			{
				generator.Default.agentrange[ComboBoxagent.SelectedIndex + 1, 1, 0] = int.Parse(TextBox3.Text);
			}
		}
		
		public void TextBox4_TextChanged(System.Object sender, System.EventArgs e)
		{
			if (Information.IsNumeric(TextBox4.Text))
			{
				generator.Default.agentrange[ComboBoxagent.SelectedIndex + 1, 1, 1] = int.Parse(TextBox4.Text);
			}
		}
		
		public void TextBox5_TextChanged(System.Object sender, System.EventArgs e)
		{
			if (Information.IsNumeric(TextBox5.Text))
			{
				generator.Default.agentrange[ComboBoxagent.SelectedIndex + 1, 2, 0] = int.Parse(TextBox5.Text);
			}
		}
		
		public void TextBox6_TextChanged(System.Object sender, System.EventArgs e)
		{
			if (Information.IsNumeric(TextBox6.Text))
			{
				generator.Default.agentrange[ComboBoxagent.SelectedIndex + 1, 2, 1] = int.Parse(TextBox6.Text);
			}
		}
		
		public void Button1_Click(System.Object sender, System.EventArgs e)
		{
			this.Close();
		}
		
		public void ComboBoxagent_SelectedIndexChanged(System.Object sender, System.EventArgs e)
		{
			TextBox1.Text = System.Convert.ToString(generator.Default.agentrange[ComboBoxagent.SelectedIndex + 1, 0, 0]);
			TextBox2.Text = System.Convert.ToString(generator.Default.agentrange[ComboBoxagent.SelectedIndex + 1, 0, 1]);
			TextBox3.Text = System.Convert.ToString(generator.Default.agentrange[ComboBoxagent.SelectedIndex + 1, 1, 0]);
			TextBox4.Text = System.Convert.ToString(generator.Default.agentrange[ComboBoxagent.SelectedIndex + 1, 1, 1]);
			TextBox5.Text = System.Convert.ToString(generator.Default.agentrange[ComboBoxagent.SelectedIndex + 1, 2, 0]);
			TextBox6.Text = System.Convert.ToString(generator.Default.agentrange[ComboBoxagent.SelectedIndex + 1, 2, 1]);
			CheckBox1.Checked = generator.Default.agentrangeabsolute[ComboBoxagent.SelectedIndex + 1];
			
		}
		
		public void CheckBox1_CheckedChanged(System.Object sender, System.EventArgs e)
		{
			generator.Default.agentrangeabsolute[ComboBoxagent.SelectedIndex + 1] = CheckBox1.Checked;
		}
	}
}
