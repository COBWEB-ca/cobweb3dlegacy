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
	public partial class Genetics
	{
		public Genetics()
		{
			InitializeComponent();
		}
		
		public void ComboBox1_SelectedIndexChanged(System.Object sender, System.EventArgs e)
		{
			if (ComboBox1.Text != "")
			{
				chromosomelabel.Enabled = true;
				chromosometext.Enabled = true;
				ploidylabel.Enabled = true;
				ploidycombo.Enabled = true;
				plasmidlabel.Enabled = true;
				plasmidtext.Enabled = true;
				jumpinggenecheck.Enabled = true;
				mutationcheck.Enabled = true;
				crossovercheck.Enabled = true;
			}
		}
		
		public void Genetics_Load(System.Object sender, System.EventArgs e)
		{
			for (var i = 1; i <= Form1.Default.agent; i++)
			{
				ComboBox1.Items.Add(generator.Default.agentname[i]);
			}
		}
		
		public void chromosometext_TextChanged(System.Object sender, System.EventArgs e)
		{
			if (Information.IsNumeric(chromosometext.Text))
			{
				chromosomelabel2.Enabled = true;
				chromosomecombo.Enabled = true;
				chromosomecombo.Items.Clear();
				int chromosome = int.Parse(chromosometext.Text);
				for (var i = 1; i <= chromosome; i++)
				{
					chromosomecombo.Items.Add("chromosome" + i);
				}
			}
			else if (chromosometext.Text == "")
			{
				chromosomelabel2.Enabled = false;
				chromosomecombo.Enabled = false;
			}
			else
			{
				MessageBox.Show("Please enter numbers only");
				chromosometext.Text = "";
			}
		}
	}
}
