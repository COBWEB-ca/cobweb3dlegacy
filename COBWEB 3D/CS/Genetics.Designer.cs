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
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public partial class Genetics : System.Windows.Forms.Form
		{
		
		//Form overrides dispose to clean up the component list.
		[System.Diagnostics.DebuggerNonUserCode()]protected override void Dispose(bool disposing)
			{
			try
			{
				if (disposing && (components != null))
				{
					components.Dispose();
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}
		
		//Required by the Windows Form Designer
		private System.ComponentModel.Container components = null;
		
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
			{
			this.TextBox14 = new System.Windows.Forms.TextBox();
			base.Load += new System.EventHandler(Genetics_Load);
			this.Button6 = new System.Windows.Forms.Button();
			this.Button5 = new System.Windows.Forms.Button();
			this.Button4 = new System.Windows.Forms.Button();
			this.jumpinggenecheck = new System.Windows.Forms.CheckBox();
			this.crossovercheck = new System.Windows.Forms.CheckBox();
			this.mutationcheck = new System.Windows.Forms.CheckBox();
			this.Label29 = new System.Windows.Forms.Label();
			this.TrackBar1 = new System.Windows.Forms.TrackBar();
			this.plasmidtext = new System.Windows.Forms.TextBox();
			this.plasmidlabel = new System.Windows.Forms.Label();
			this.ploidycombo = new System.Windows.Forms.ComboBox();
			this.ploidylabel = new System.Windows.Forms.Label();
			this.TextBox13 = new System.Windows.Forms.TextBox();
			this.Label25 = new System.Windows.Forms.Label();
			this.TextBox12 = new System.Windows.Forms.TextBox();
			this.Label24 = new System.Windows.Forms.Label();
			this.ComboBox6 = new System.Windows.Forms.ComboBox();
			this.Label23 = new System.Windows.Forms.Label();
			this.ComboBox5 = new System.Windows.Forms.ComboBox();
			this.Label22 = new System.Windows.Forms.Label();
			this.ComboBox4 = new System.Windows.Forms.ComboBox();
			this.Label21 = new System.Windows.Forms.Label();
			this.TextBox11 = new System.Windows.Forms.TextBox();
			this.Label20 = new System.Windows.Forms.Label();
			this.TextBox10 = new System.Windows.Forms.TextBox();
			this.Label19 = new System.Windows.Forms.Label();
			this.TextBox9 = new System.Windows.Forms.TextBox();
			this.Label18 = new System.Windows.Forms.Label();
			this.TextBox8 = new System.Windows.Forms.TextBox();
			this.Label17 = new System.Windows.Forms.Label();
			this.TextBox7 = new System.Windows.Forms.TextBox();
			this.Label16 = new System.Windows.Forms.Label();
			this.ComboBox3 = new System.Windows.Forms.ComboBox();
			this.Label15 = new System.Windows.Forms.Label();
			this.TextBox6 = new System.Windows.Forms.TextBox();
			this.Label14 = new System.Windows.Forms.Label();
			this.chromosomelabel2 = new System.Windows.Forms.Label();
			this.chromosometext = new System.Windows.Forms.TextBox();
			this.chromosometext.TextChanged += new System.EventHandler(this.chromosometext_TextChanged);
			this.chromosomelabel = new System.Windows.Forms.Label();
			this.chromosomecombo = new System.Windows.Forms.ComboBox();
			this.Label11 = new System.Windows.Forms.Label();
			this.ComboBox1 = new System.Windows.Forms.ComboBox();
			this.ComboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
			((System.ComponentModel.ISupportInitialize) this.TrackBar1).BeginInit();
			this.SuspendLayout();
			//
			//TextBox14
			//
			this.TextBox14.Enabled = false;
			this.TextBox14.Location = new System.Drawing.Point(9, 408);
			this.TextBox14.Multiline = true;
			this.TextBox14.Name = "TextBox14";
			this.TextBox14.Size = new System.Drawing.Size(1220, 114);
			this.TextBox14.TabIndex = 94;
			//
			//Button6
			//
			this.Button6.Enabled = false;
			this.Button6.Location = new System.Drawing.Point(944, 122);
			this.Button6.Name = "Button6";
			this.Button6.Size = new System.Drawing.Size(254, 23);
			this.Button6.TabIndex = 93;
			this.Button6.Text = "Show chromosome/plasmid map:";
			this.Button6.UseVisualStyleBackColor = true;
			//
			//Button5
			//
			this.Button5.Enabled = false;
			this.Button5.Location = new System.Drawing.Point(736, 122);
			this.Button5.Name = "Button5";
			this.Button5.Size = new System.Drawing.Size(202, 23);
			this.Button5.TabIndex = 92;
			this.Button5.Text = "Delete this chromosome/plasmid ";
			this.Button5.UseVisualStyleBackColor = true;
			//
			//Button4
			//
			this.Button4.Enabled = false;
			this.Button4.Location = new System.Drawing.Point(1098, 329);
			this.Button4.Name = "Button4";
			this.Button4.Size = new System.Drawing.Size(135, 73);
			this.Button4.TabIndex = 91;
			this.Button4.Text = "Enter DNA sequence";
			this.Button4.UseVisualStyleBackColor = true;
			//
			//jumpinggenecheck
			//
			this.jumpinggenecheck.AutoSize = true;
			this.jumpinggenecheck.Enabled = false;
			this.jumpinggenecheck.Location = new System.Drawing.Point(826, 41);
			this.jumpinggenecheck.Name = "jumpinggenecheck";
			this.jumpinggenecheck.Size = new System.Drawing.Size(125, 17);
			this.jumpinggenecheck.TabIndex = 90;
			this.jumpinggenecheck.Text = "Enable jumping gene";
			this.jumpinggenecheck.UseVisualStyleBackColor = true;
			//
			//crossovercheck
			//
			this.crossovercheck.AutoSize = true;
			this.crossovercheck.Enabled = false;
			this.crossovercheck.Location = new System.Drawing.Point(1065, 43);
			this.crossovercheck.Name = "crossovercheck";
			this.crossovercheck.Size = new System.Drawing.Size(111, 17);
			this.crossovercheck.TabIndex = 89;
			this.crossovercheck.Text = "Enable cross over";
			this.crossovercheck.UseVisualStyleBackColor = true;
			//
			//mutationcheck
			//
			this.mutationcheck.AutoSize = true;
			this.mutationcheck.Enabled = false;
			this.mutationcheck.Location = new System.Drawing.Point(957, 43);
			this.mutationcheck.Name = "mutationcheck";
			this.mutationcheck.Size = new System.Drawing.Size(102, 17);
			this.mutationcheck.TabIndex = 88;
			this.mutationcheck.Text = "Enable mutation";
			this.mutationcheck.UseVisualStyleBackColor = true;
			//
			//Label29
			//
			this.Label29.AutoSize = true;
			this.Label29.Enabled = false;
			this.Label29.Location = new System.Drawing.Point(9, 276);
			this.Label29.Name = "Label29";
			this.Label29.Size = new System.Drawing.Size(65, 13);
			this.Label29.TabIndex = 87;
			this.Label29.Text = "Penetrance:";
			//
			//TrackBar1
			//
			this.TrackBar1.Enabled = false;
			this.TrackBar1.Location = new System.Drawing.Point(80, 267);
			this.TrackBar1.Name = "TrackBar1";
			this.TrackBar1.Size = new System.Drawing.Size(1149, 45);
			this.TrackBar1.TabIndex = 86;
			//
			//plasmidtext
			//
			this.plasmidtext.Enabled = false;
			this.plasmidtext.Location = new System.Drawing.Point(644, 38);
			this.plasmidtext.Name = "plasmidtext";
			this.plasmidtext.Size = new System.Drawing.Size(151, 20);
			this.plasmidtext.TabIndex = 85;
			//
			//plasmidlabel
			//
			this.plasmidlabel.AutoSize = true;
			this.plasmidlabel.Enabled = false;
			this.plasmidlabel.Location = new System.Drawing.Point(535, 41);
			this.plasmidlabel.Name = "plasmidlabel";
			this.plasmidlabel.Size = new System.Drawing.Size(103, 13);
			this.plasmidlabel.TabIndex = 84;
			this.plasmidlabel.Text = "Number of Plasmids:";
			//
			//ploidycombo
			//
			this.ploidycombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ploidycombo.Enabled = false;
			this.ploidycombo.FormattingEnabled = true;
			this.ploidycombo.Items.AddRange(new object[] {"Haploid", "Diploid", "Triploid"});
			this.ploidycombo.Location = new System.Drawing.Point(369, 38);
			this.ploidycombo.Name = "ploidycombo";
			this.ploidycombo.Size = new System.Drawing.Size(151, 21);
			this.ploidycombo.TabIndex = 83;
			//
			//ploidylabel
			//
			this.ploidylabel.AutoSize = true;
			this.ploidylabel.Enabled = false;
			this.ploidylabel.Location = new System.Drawing.Point(325, 41);
			this.ploidylabel.Name = "ploidylabel";
			this.ploidylabel.Size = new System.Drawing.Size(38, 13);
			this.ploidylabel.TabIndex = 82;
			this.ploidylabel.Text = "Ploidy:";
			//
			//TextBox13
			//
			this.TextBox13.Enabled = false;
			this.TextBox13.Location = new System.Drawing.Point(144, 382);
			this.TextBox13.Name = "TextBox13";
			this.TextBox13.Size = new System.Drawing.Size(948, 20);
			this.TextBox13.TabIndex = 81;
			//
			//Label25
			//
			this.Label25.AutoSize = true;
			this.Label25.Enabled = false;
			this.Label25.Location = new System.Drawing.Point(7, 385);
			this.Label25.Name = "Label25";
			this.Label25.Size = new System.Drawing.Size(131, 13);
			this.Label25.TabIndex = 80;
			this.Label25.Text = "Value of _ with this morph:";
			//
			//TextBox12
			//
			this.TextBox12.Enabled = false;
			this.TextBox12.Location = new System.Drawing.Point(144, 356);
			this.TextBox12.Name = "TextBox12";
			this.TextBox12.Size = new System.Drawing.Size(948, 20);
			this.TextBox12.TabIndex = 79;
			//
			//Label24
			//
			this.Label24.AutoSize = true;
			this.Label24.Enabled = false;
			this.Label24.Location = new System.Drawing.Point(7, 359);
			this.Label24.Name = "Label24";
			this.Label24.Size = new System.Drawing.Size(131, 13);
			this.Label24.TabIndex = 78;
			this.Label24.Text = "Value of _ with this morph:";
			//
			//ComboBox6
			//
			this.ComboBox6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ComboBox6.Enabled = false;
			this.ComboBox6.FormattingEnabled = true;
			this.ComboBox6.Location = new System.Drawing.Point(687, 240);
			this.ComboBox6.Name = "ComboBox6";
			this.ComboBox6.Size = new System.Drawing.Size(542, 21);
			this.ComboBox6.TabIndex = 77;
			//
			//Label23
			//
			this.Label23.AutoSize = true;
			this.Label23.Enabled = false;
			this.Label23.Location = new System.Drawing.Point(656, 243);
			this.Label23.Name = "Label23";
			this.Label23.Size = new System.Drawing.Size(25, 13);
			this.Label23.TabIndex = 76;
			this.Label23.Text = "and";
			//
			//ComboBox5
			//
			this.ComboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ComboBox5.Enabled = false;
			this.ComboBox5.FormattingEnabled = true;
			this.ComboBox5.Location = new System.Drawing.Point(96, 240);
			this.ComboBox5.Name = "ComboBox5";
			this.ComboBox5.Size = new System.Drawing.Size(554, 21);
			this.ComboBox5.TabIndex = 75;
			//
			//Label22
			//
			this.Label22.AutoSize = true;
			this.Label22.Enabled = false;
			this.Label22.Location = new System.Drawing.Point(9, 243);
			this.Label22.Name = "Label22";
			this.Label22.Size = new System.Drawing.Size(81, 13);
			this.Label22.TabIndex = 74;
			this.Label22.Text = "Gene bound to:";
			//
			//ComboBox4
			//
			this.ComboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ComboBox4.Enabled = false;
			this.ComboBox4.FormattingEnabled = true;
			this.ComboBox4.Location = new System.Drawing.Point(82, 329);
			this.ComboBox4.Name = "ComboBox4";
			this.ComboBox4.Size = new System.Drawing.Size(1010, 21);
			this.ComboBox4.TabIndex = 73;
			//
			//Label21
			//
			this.Label21.AutoSize = true;
			this.Label21.Enabled = false;
			this.Label21.Location = new System.Drawing.Point(7, 332);
			this.Label21.Name = "Label21";
			this.Label21.Size = new System.Drawing.Size(69, 13);
			this.Label21.TabIndex = 72;
			this.Label21.Text = "Gene Morph:";
			//
			//TextBox11
			//
			this.TextBox11.Enabled = false;
			this.TextBox11.Location = new System.Drawing.Point(969, 214);
			this.TextBox11.Name = "TextBox11";
			this.TextBox11.Size = new System.Drawing.Size(62, 20);
			this.TextBox11.TabIndex = 71;
			//
			//Label20
			//
			this.Label20.AutoSize = true;
			this.Label20.Enabled = false;
			this.Label20.Location = new System.Drawing.Point(880, 217);
			this.Label20.Name = "Label20";
			this.Label20.Size = new System.Drawing.Size(83, 13);
			this.Label20.TabIndex = 70;
			this.Label20.Text = "Gene end point:";
			//
			//TextBox10
			//
			this.TextBox10.Enabled = false;
			this.TextBox10.Location = new System.Drawing.Point(815, 214);
			this.TextBox10.Name = "TextBox10";
			this.TextBox10.Size = new System.Drawing.Size(59, 20);
			this.TextBox10.TabIndex = 69;
			//
			//Label19
			//
			this.Label19.AutoSize = true;
			this.Label19.Enabled = false;
			this.Label19.Location = new System.Drawing.Point(710, 217);
			this.Label19.Name = "Label19";
			this.Label19.Size = new System.Drawing.Size(99, 13);
			this.Label19.TabIndex = 68;
			this.Label19.Text = "Gene Starting Point";
			//
			//TextBox9
			//
			this.TextBox9.Enabled = false;
			this.TextBox9.Location = new System.Drawing.Point(82, 214);
			this.TextBox9.Name = "TextBox9";
			this.TextBox9.Size = new System.Drawing.Size(622, 20);
			this.TextBox9.TabIndex = 67;
			//
			//Label18
			//
			this.Label18.AutoSize = true;
			this.Label18.Enabled = false;
			this.Label18.Location = new System.Drawing.Point(9, 217);
			this.Label18.Name = "Label18";
			this.Label18.Size = new System.Drawing.Size(67, 13);
			this.Label18.TabIndex = 66;
			this.Label18.Text = "Gene Name:";
			//
			//TextBox8
			//
			this.TextBox8.Enabled = false;
			this.TextBox8.Location = new System.Drawing.Point(1171, 214);
			this.TextBox8.Name = "TextBox8";
			this.TextBox8.Size = new System.Drawing.Size(58, 20);
			this.TextBox8.TabIndex = 65;
			//
			//Label17
			//
			this.Label17.AutoSize = true;
			this.Label17.Enabled = false;
			this.Label17.Location = new System.Drawing.Point(1037, 217);
			this.Label17.Name = "Label17";
			this.Label17.Size = new System.Drawing.Size(129, 13);
			this.Label17.TabIndex = 64;
			this.Label17.Text = "Number of Polymorphism: ";
			//
			//TextBox7
			//
			this.TextBox7.Enabled = false;
			this.TextBox7.Location = new System.Drawing.Point(175, 125);
			this.TextBox7.Name = "TextBox7";
			this.TextBox7.Size = new System.Drawing.Size(57, 20);
			this.TextBox7.TabIndex = 63;
			//
			//Label16
			//
			this.Label16.AutoSize = true;
			this.Label16.Enabled = false;
			this.Label16.Location = new System.Drawing.Point(6, 128);
			this.Label16.Name = "Label16";
			this.Label16.Size = new System.Drawing.Size(163, 13);
			this.Label16.TabIndex = 62;
			this.Label16.Text = "Size of the chromosome/plasmid:";
			//
			//ComboBox3
			//
			this.ComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ComboBox3.Enabled = false;
			this.ComboBox3.FormattingEnabled = true;
			this.ComboBox3.Location = new System.Drawing.Point(51, 187);
			this.ComboBox3.Name = "ComboBox3";
			this.ComboBox3.Size = new System.Drawing.Size(1178, 21);
			this.ComboBox3.TabIndex = 61;
			//
			//Label15
			//
			this.Label15.AutoSize = true;
			this.Label15.Enabled = false;
			this.Label15.Location = new System.Drawing.Point(9, 178);
			this.Label15.Name = "Label15";
			this.Label15.Size = new System.Drawing.Size(36, 13);
			this.Label15.TabIndex = 60;
			this.Label15.Text = "Gene:";
			//
			//TextBox6
			//
			this.TextBox6.Enabled = false;
			this.TextBox6.Location = new System.Drawing.Point(472, 125);
			this.TextBox6.Name = "TextBox6";
			this.TextBox6.Size = new System.Drawing.Size(57, 20);
			this.TextBox6.TabIndex = 59;
			//
			//Label14
			//
			this.Label14.AutoSize = true;
			this.Label14.Enabled = false;
			this.Label14.Location = new System.Drawing.Point(239, 128);
			this.Label14.Name = "Label14";
			this.Label14.Size = new System.Drawing.Size(227, 13);
			this.Label14.TabIndex = 58;
			this.Label14.Text = "Number of genes on the chromosome/plasmid:";
			//
			//chromosomelabel2
			//
			this.chromosomelabel2.AutoSize = true;
			this.chromosomelabel2.Enabled = false;
			this.chromosomelabel2.Location = new System.Drawing.Point(6, 101);
			this.chromosomelabel2.Name = "chromosomelabel2";
			this.chromosomelabel2.Size = new System.Drawing.Size(118, 13);
			this.chromosomelabel2.TabIndex = 57;
			this.chromosomelabel2.Text = "Chromosome/Plasmid : ";
			//
			//chromosometext
			//
			this.chromosometext.Enabled = false;
			this.chromosometext.Location = new System.Drawing.Point(163, 38);
			this.chromosometext.Name = "chromosometext";
			this.chromosometext.Size = new System.Drawing.Size(151, 20);
			this.chromosometext.TabIndex = 56;
			//
			//chromosomelabel
			//
			this.chromosomelabel.AutoSize = true;
			this.chromosomelabel.Enabled = false;
			this.chromosomelabel.Location = new System.Drawing.Point(7, 41);
			this.chromosomelabel.Name = "chromosomelabel";
			this.chromosomelabel.Size = new System.Drawing.Size(150, 13);
			this.chromosomelabel.TabIndex = 55;
			this.chromosomelabel.Text = "Number of Chromosomes sets:";
			//
			//chromosomecombo
			//
			this.chromosomecombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.chromosomecombo.Enabled = false;
			this.chromosomecombo.FormattingEnabled = true;
			this.chromosomecombo.Location = new System.Drawing.Point(130, 98);
			this.chromosomecombo.Name = "chromosomecombo";
			this.chromosomecombo.Size = new System.Drawing.Size(1099, 21);
			this.chromosomecombo.TabIndex = 54;
			//
			//Label11
			//
			this.Label11.AutoSize = true;
			this.Label11.Location = new System.Drawing.Point(7, 15);
			this.Label11.Name = "Label11";
			this.Label11.Size = new System.Drawing.Size(38, 13);
			this.Label11.TabIndex = 53;
			this.Label11.Text = "Agent:";
			//
			//ComboBox1
			//
			this.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ComboBox1.FormattingEnabled = true;
			this.ComboBox1.Location = new System.Drawing.Point(51, 12);
			this.ComboBox1.Name = "ComboBox1";
			this.ComboBox1.Size = new System.Drawing.Size(1178, 21);
			this.ComboBox1.TabIndex = 52;
			//
			//Genetics
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1240, 541);
			this.Controls.Add(this.TextBox14);
			this.Controls.Add(this.Button6);
			this.Controls.Add(this.Button5);
			this.Controls.Add(this.Button4);
			this.Controls.Add(this.jumpinggenecheck);
			this.Controls.Add(this.crossovercheck);
			this.Controls.Add(this.mutationcheck);
			this.Controls.Add(this.Label29);
			this.Controls.Add(this.TrackBar1);
			this.Controls.Add(this.plasmidtext);
			this.Controls.Add(this.plasmidlabel);
			this.Controls.Add(this.ploidycombo);
			this.Controls.Add(this.ploidylabel);
			this.Controls.Add(this.TextBox13);
			this.Controls.Add(this.Label25);
			this.Controls.Add(this.TextBox12);
			this.Controls.Add(this.Label24);
			this.Controls.Add(this.ComboBox6);
			this.Controls.Add(this.Label23);
			this.Controls.Add(this.ComboBox5);
			this.Controls.Add(this.Label22);
			this.Controls.Add(this.ComboBox4);
			this.Controls.Add(this.Label21);
			this.Controls.Add(this.TextBox11);
			this.Controls.Add(this.Label20);
			this.Controls.Add(this.TextBox10);
			this.Controls.Add(this.Label19);
			this.Controls.Add(this.TextBox9);
			this.Controls.Add(this.Label18);
			this.Controls.Add(this.TextBox8);
			this.Controls.Add(this.Label17);
			this.Controls.Add(this.TextBox7);
			this.Controls.Add(this.Label16);
			this.Controls.Add(this.ComboBox3);
			this.Controls.Add(this.Label15);
			this.Controls.Add(this.TextBox6);
			this.Controls.Add(this.Label14);
			this.Controls.Add(this.chromosomelabel2);
			this.Controls.Add(this.chromosometext);
			this.Controls.Add(this.chromosomelabel);
			this.Controls.Add(this.chromosomecombo);
			this.Controls.Add(this.Label11);
			this.Controls.Add(this.ComboBox1);
			this.Name = "Genetics";
			this.Text = "Genetics";
			((System.ComponentModel.ISupportInitialize) this.TrackBar1).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
			
		}
		internal System.Windows.Forms.TextBox TextBox14;
		internal System.Windows.Forms.Button Button6;
		internal System.Windows.Forms.Button Button5;
		internal System.Windows.Forms.Button Button4;
		internal System.Windows.Forms.CheckBox jumpinggenecheck;
		internal System.Windows.Forms.CheckBox crossovercheck;
		internal System.Windows.Forms.CheckBox mutationcheck;
		internal System.Windows.Forms.Label Label29;
		internal System.Windows.Forms.TrackBar TrackBar1;
		internal System.Windows.Forms.TextBox plasmidtext;
		internal System.Windows.Forms.Label plasmidlabel;
		internal System.Windows.Forms.ComboBox ploidycombo;
		internal System.Windows.Forms.Label ploidylabel;
		internal System.Windows.Forms.TextBox TextBox13;
		internal System.Windows.Forms.Label Label25;
		internal System.Windows.Forms.TextBox TextBox12;
		internal System.Windows.Forms.Label Label24;
		internal System.Windows.Forms.ComboBox ComboBox6;
		internal System.Windows.Forms.Label Label23;
		internal System.Windows.Forms.ComboBox ComboBox5;
		internal System.Windows.Forms.Label Label22;
		internal System.Windows.Forms.ComboBox ComboBox4;
		internal System.Windows.Forms.Label Label21;
		internal System.Windows.Forms.TextBox TextBox11;
		internal System.Windows.Forms.Label Label20;
		internal System.Windows.Forms.TextBox TextBox10;
		internal System.Windows.Forms.Label Label19;
		internal System.Windows.Forms.TextBox TextBox9;
		internal System.Windows.Forms.Label Label18;
		internal System.Windows.Forms.TextBox TextBox8;
		internal System.Windows.Forms.Label Label17;
		internal System.Windows.Forms.TextBox TextBox7;
		internal System.Windows.Forms.Label Label16;
		internal System.Windows.Forms.ComboBox ComboBox3;
		internal System.Windows.Forms.Label Label15;
		internal System.Windows.Forms.TextBox TextBox6;
		internal System.Windows.Forms.Label Label14;
		internal System.Windows.Forms.Label chromosomelabel2;
		internal System.Windows.Forms.TextBox chromosometext;
		internal System.Windows.Forms.Label chromosomelabel;
		internal System.Windows.Forms.ComboBox chromosomecombo;
		internal System.Windows.Forms.Label Label11;
		internal System.Windows.Forms.ComboBox ComboBox1;
	}
	
}
