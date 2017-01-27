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
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public partial class Form3 : System.Windows.Forms.Form
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
			this.Label12 = new System.Windows.Forms.Label();
			base.Load += new System.EventHandler(Form3_Load);
			this.TextBoxcount = new System.Windows.Forms.TextBox();
			this.TextBoxcount.TextChanged += new System.EventHandler(this.TextBox5_TextChanged);
			this.Label28 = new System.Windows.Forms.Label();
			this.ComboBoxagent = new System.Windows.Forms.ComboBox();
			this.ComboBoxagent.SelectedIndexChanged += new System.EventHandler(this.ComboBoxagent_SelectedIndexChanged);
			this.Button1 = new System.Windows.Forms.Button();
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.GroupBox1 = new System.Windows.Forms.GroupBox();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label5 = new System.Windows.Forms.Label();
			this.Label6 = new System.Windows.Forms.Label();
			this.colour = new System.Windows.Forms.Button();
			this.TrackBar3 = new System.Windows.Forms.TrackBar();
			this.TrackBar3.Scroll += new System.EventHandler(this.TrackBar3_Scroll);
			this.TrackBar2 = new System.Windows.Forms.TrackBar();
			this.TrackBar2.Scroll += new System.EventHandler(this.TrackBar2_Scroll);
			this.TextBox2 = new System.Windows.Forms.TextBox();
			this.TextBox2.TextChanged += new System.EventHandler(this.TextBox2_TextChanged);
			this.TextBox1 = new System.Windows.Forms.TextBox();
			this.TextBox1.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
			this.TextBox3 = new System.Windows.Forms.TextBox();
			this.TextBox3.TextChanged += new System.EventHandler(this.TextBox3_TextChanged);
			this.TrackBar4 = new System.Windows.Forms.TrackBar();
			this.TrackBar4.Scroll += new System.EventHandler(this.TrackBar4_Scroll);
			this.Label7 = new System.Windows.Forms.Label();
			this.TextBoxname = new System.Windows.Forms.TextBox();
			this.TextBoxname.Validated += new System.EventHandler(this.TextBoxname_Validated);
			this.TextBoxinienergy = new System.Windows.Forms.TextBox();
			this.TextBoxinienergy.TextChanged += new System.EventHandler(this.TextBox4_TextChanged);
			this.Label1 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.TextBoxstepenergy = new System.Windows.Forms.TextBox();
			this.TextBoxstepenergy.TextChanged += new System.EventHandler(this.TextBox5_TextChanged_1);
			this.Label3 = new System.Windows.Forms.Label();
			this.txtasr = new System.Windows.Forms.TextBox();
			this.txtasr.TextChanged += new System.EventHandler(this.txtasr_TextChanged);
			this.Label8 = new System.Windows.Forms.Label();
			this.TextBoxagelimit = new System.Windows.Forms.TextBox();
			this.TextBoxagelimit.TextChanged += new System.EventHandler(this.TextBox7_TextChanged);
			this.TextBoxbumpenergy = new System.Windows.Forms.TextBox();
			this.TextBoxbumpenergy.TextChanged += new System.EventHandler(this.TextBoxbumpenergy_TextChanged);
			this.Label9 = new System.Windows.Forms.Label();
			this.CheckBoxaging = new System.Windows.Forms.CheckBox();
			this.CheckBoxaging.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
			this.CheckBoxasr = new System.Windows.Forms.CheckBox();
			this.CheckBoxasr.CheckedChanged += new System.EventHandler(this.CheckBox2_CheckedChanged);
			this.GroupBoxaging = new System.Windows.Forms.GroupBox();
			this.GroupBox3 = new System.Windows.Forms.GroupBox();
			this.Label10 = new System.Windows.Forms.Label();
			this.txtasrenergy = new System.Windows.Forms.TextBox();
			this.txtasrenergy.TextChanged += new System.EventHandler(this.txtasrenergy_TextChanged);
			this.GroupBox4 = new System.Windows.Forms.GroupBox();
			this.GroupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) this.TrackBar3).BeginInit();
			((System.ComponentModel.ISupportInitialize) this.TrackBar2).BeginInit();
			((System.ComponentModel.ISupportInitialize) this.TrackBar4).BeginInit();
			this.GroupBoxaging.SuspendLayout();
			this.GroupBox3.SuspendLayout();
			this.GroupBox4.SuspendLayout();
			this.SuspendLayout();
			//
			//Label12
			//
			this.Label12.AutoSize = true;
			this.Label12.Location = new System.Drawing.Point(7, 238);
			this.Label12.Name = "Label12";
			this.Label12.Size = new System.Drawing.Size(65, 13);
			this.Label12.TabIndex = 20;
			this.Label12.Text = "Initial Count:";
			//
			//TextBoxcount
			//
			this.TextBoxcount.Enabled = false;
			this.TextBoxcount.Location = new System.Drawing.Point(77, 238);
			this.TextBoxcount.Name = "TextBoxcount";
			this.TextBoxcount.Size = new System.Drawing.Size(914, 20);
			this.TextBoxcount.TabIndex = 19;
			//
			//Label28
			//
			this.Label28.AutoSize = true;
			this.Label28.Location = new System.Drawing.Point(7, 9);
			this.Label28.Name = "Label28";
			this.Label28.Size = new System.Drawing.Size(38, 13);
			this.Label28.TabIndex = 3;
			this.Label28.Text = "Agent:";
			//
			//ComboBoxagent
			//
			this.ComboBoxagent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ComboBoxagent.FormattingEnabled = true;
			this.ComboBoxagent.Location = new System.Drawing.Point(51, 6);
			this.ComboBoxagent.Name = "ComboBoxagent";
			this.ComboBoxagent.Size = new System.Drawing.Size(940, 21);
			this.ComboBoxagent.TabIndex = 2;
			//
			//Button1
			//
			this.Button1.Location = new System.Drawing.Point(10, 476);
			this.Button1.Name = "Button1";
			this.Button1.Size = new System.Drawing.Size(981, 31);
			this.Button1.TabIndex = 21;
			this.Button1.Text = "Apply";
			this.Button1.UseVisualStyleBackColor = true;
			//
			//GroupBox1
			//
			this.GroupBox1.Controls.Add(this.Label4);
			this.GroupBox1.Controls.Add(this.Label5);
			this.GroupBox1.Controls.Add(this.Label6);
			this.GroupBox1.Controls.Add(this.colour);
			this.GroupBox1.Controls.Add(this.TrackBar3);
			this.GroupBox1.Controls.Add(this.TrackBar2);
			this.GroupBox1.Controls.Add(this.TextBox2);
			this.GroupBox1.Controls.Add(this.TextBox1);
			this.GroupBox1.Controls.Add(this.TextBox3);
			this.GroupBox1.Controls.Add(this.TrackBar4);
			this.GroupBox1.Enabled = false;
			this.GroupBox1.Location = new System.Drawing.Point(10, 77);
			this.GroupBox1.Name = "GroupBox1";
			this.GroupBox1.Size = new System.Drawing.Size(981, 143);
			this.GroupBox1.TabIndex = 22;
			this.GroupBox1.TabStop = false;
			this.GroupBox1.Text = "Colour";
			//
			//Label4
			//
			this.Label4.AutoSize = true;
			this.Label4.Location = new System.Drawing.Point(17, 97);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(28, 13);
			this.Label4.TabIndex = 15;
			this.Label4.Text = "Blue";
			//
			//Label5
			//
			this.Label5.AutoSize = true;
			this.Label5.Location = new System.Drawing.Point(17, 60);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(36, 13);
			this.Label5.TabIndex = 14;
			this.Label5.Text = "Green";
			//
			//Label6
			//
			this.Label6.AutoSize = true;
			this.Label6.Location = new System.Drawing.Point(17, 24);
			this.Label6.Name = "Label6";
			this.Label6.Size = new System.Drawing.Size(27, 13);
			this.Label6.TabIndex = 13;
			this.Label6.Text = "Red";
			//
			//colour
			//
			this.colour.Location = new System.Drawing.Point(839, 13);
			this.colour.Name = "colour";
			this.colour.Size = new System.Drawing.Size(136, 124);
			this.colour.TabIndex = 8;
			this.colour.UseVisualStyleBackColor = true;
			//
			//TrackBar3
			//
			this.TrackBar3.Location = new System.Drawing.Point(170, 93);
			this.TrackBar3.Name = "TrackBar3";
			this.TrackBar3.Size = new System.Drawing.Size(663, 45);
			this.TrackBar3.TabIndex = 12;
			//
			//TrackBar2
			//
			this.TrackBar2.Location = new System.Drawing.Point(170, 56);
			this.TrackBar2.Name = "TrackBar2";
			this.TrackBar2.Size = new System.Drawing.Size(663, 45);
			this.TrackBar2.TabIndex = 11;
			//
			//TextBox2
			//
			this.TextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.TextBox2.Location = new System.Drawing.Point(71, 56);
			this.TextBox2.Name = "TextBox2";
			this.TextBox2.Size = new System.Drawing.Size(93, 22);
			this.TextBox2.TabIndex = 6;
			this.TextBox2.Text = "0";
			//
			//TextBox1
			//
			this.TextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.TextBox1.Location = new System.Drawing.Point(71, 19);
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.Size = new System.Drawing.Size(93, 22);
			this.TextBox1.TabIndex = 5;
			this.TextBox1.Text = "0";
			//
			//TextBox3
			//
			this.TextBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.TextBox3.Location = new System.Drawing.Point(71, 93);
			this.TextBox3.Name = "TextBox3";
			this.TextBox3.Size = new System.Drawing.Size(93, 22);
			this.TextBox3.TabIndex = 7;
			this.TextBox3.Text = "0";
			//
			//TrackBar4
			//
			this.TrackBar4.Location = new System.Drawing.Point(170, 19);
			this.TrackBar4.Name = "TrackBar4";
			this.TrackBar4.Size = new System.Drawing.Size(663, 45);
			this.TrackBar4.TabIndex = 10;
			//
			//Label7
			//
			this.Label7.AutoSize = true;
			this.Label7.Location = new System.Drawing.Point(7, 45);
			this.Label7.Name = "Label7";
			this.Label7.Size = new System.Drawing.Size(67, 13);
			this.Label7.TabIndex = 24;
			this.Label7.Text = "Agent name:";
			//
			//TextBoxname
			//
			this.TextBoxname.Enabled = false;
			this.TextBoxname.Location = new System.Drawing.Point(77, 42);
			this.TextBoxname.Name = "TextBoxname";
			this.TextBoxname.Size = new System.Drawing.Size(914, 20);
			this.TextBoxname.TabIndex = 23;
			//
			//TextBoxinienergy
			//
			this.TextBoxinienergy.Enabled = false;
			this.TextBoxinienergy.Location = new System.Drawing.Point(84, 18);
			this.TextBoxinienergy.Name = "TextBoxinienergy";
			this.TextBoxinienergy.Size = new System.Drawing.Size(226, 20);
			this.TextBoxinienergy.TabIndex = 25;
			//
			//Label1
			//
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(8, 21);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(70, 13);
			this.Label1.TabIndex = 26;
			this.Label1.Text = "Initial Energy:";
			//
			//Label2
			//
			this.Label2.AutoSize = true;
			this.Label2.Location = new System.Drawing.Point(349, 21);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(68, 13);
			this.Label2.TabIndex = 28;
			this.Label2.Text = "Step Energy:";
			//
			//TextBoxstepenergy
			//
			this.TextBoxstepenergy.Enabled = false;
			this.TextBoxstepenergy.Location = new System.Drawing.Point(423, 18);
			this.TextBoxstepenergy.Name = "TextBoxstepenergy";
			this.TextBoxstepenergy.Size = new System.Drawing.Size(226, 20);
			this.TextBoxstepenergy.TabIndex = 27;
			//
			//Label3
			//
			this.Label3.AutoSize = true;
			this.Label3.Location = new System.Drawing.Point(184, 22);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(208, 13);
			this.Label3.TabIndex = 33;
			this.Label3.Text = "Time elapsed for each round of replication:";
			//
			//txtasr
			//
			this.txtasr.Enabled = false;
			this.txtasr.Location = new System.Drawing.Point(398, 19);
			this.txtasr.Name = "txtasr";
			this.txtasr.Size = new System.Drawing.Size(226, 20);
			this.txtasr.TabIndex = 32;
			//
			//Label8
			//
			this.Label8.AutoSize = true;
			this.Label8.Location = new System.Drawing.Point(81, 22);
			this.Label8.Name = "Label8";
			this.Label8.Size = new System.Drawing.Size(53, 13);
			this.Label8.TabIndex = 31;
			this.Label8.Text = "Age Limit:";
			//
			//TextBoxagelimit
			//
			this.TextBoxagelimit.Location = new System.Drawing.Point(140, 19);
			this.TextBoxagelimit.Name = "TextBoxagelimit";
			this.TextBoxagelimit.Size = new System.Drawing.Size(832, 20);
			this.TextBoxagelimit.TabIndex = 30;
			//
			//TextBoxbumpenergy
			//
			this.TextBoxbumpenergy.Enabled = false;
			this.TextBoxbumpenergy.Location = new System.Drawing.Point(786, 18);
			this.TextBoxbumpenergy.Name = "TextBoxbumpenergy";
			this.TextBoxbumpenergy.Size = new System.Drawing.Size(186, 20);
			this.TextBoxbumpenergy.TabIndex = 29;
			//
			//Label9
			//
			this.Label9.AutoSize = true;
			this.Label9.Location = new System.Drawing.Point(676, 21);
			this.Label9.Name = "Label9";
			this.Label9.Size = new System.Drawing.Size(104, 13);
			this.Label9.TabIndex = 34;
			this.Label9.Text = "Agent Bump Energy:";
			//
			//CheckBoxaging
			//
			this.CheckBoxaging.AutoSize = true;
			this.CheckBoxaging.Location = new System.Drawing.Point(14, 21);
			this.CheckBoxaging.Name = "CheckBoxaging";
			this.CheckBoxaging.Size = new System.Drawing.Size(53, 17);
			this.CheckBoxaging.TabIndex = 35;
			this.CheckBoxaging.Text = "Aging";
			this.CheckBoxaging.UseVisualStyleBackColor = true;
			//
			//CheckBoxasr
			//
			this.CheckBoxasr.AutoSize = true;
			this.CheckBoxasr.Location = new System.Drawing.Point(17, 21);
			this.CheckBoxasr.Name = "CheckBoxasr";
			this.CheckBoxasr.Size = new System.Drawing.Size(130, 17);
			this.CheckBoxasr.TabIndex = 36;
			this.CheckBoxasr.Text = "Asexual Reproduction";
			this.CheckBoxasr.UseVisualStyleBackColor = true;
			//
			//GroupBoxaging
			//
			this.GroupBoxaging.Controls.Add(this.CheckBoxaging);
			this.GroupBoxaging.Controls.Add(this.Label8);
			this.GroupBoxaging.Controls.Add(this.TextBoxagelimit);
			this.GroupBoxaging.Enabled = false;
			this.GroupBoxaging.Location = new System.Drawing.Point(10, 342);
			this.GroupBoxaging.Name = "GroupBoxaging";
			this.GroupBoxaging.Size = new System.Drawing.Size(981, 54);
			this.GroupBoxaging.TabIndex = 37;
			this.GroupBoxaging.TabStop = false;
			this.GroupBoxaging.Text = "Aging";
			//
			//GroupBox3
			//
			this.GroupBox3.Controls.Add(this.Label10);
			this.GroupBox3.Controls.Add(this.txtasrenergy);
			this.GroupBox3.Controls.Add(this.CheckBoxasr);
			this.GroupBox3.Controls.Add(this.Label3);
			this.GroupBox3.Controls.Add(this.txtasr);
			this.GroupBox3.Enabled = false;
			this.GroupBox3.Location = new System.Drawing.Point(10, 415);
			this.GroupBox3.Name = "GroupBox3";
			this.GroupBox3.Size = new System.Drawing.Size(981, 54);
			this.GroupBox3.TabIndex = 38;
			this.GroupBox3.TabStop = false;
			this.GroupBox3.Text = "Asexual Reproduction";
			//
			//Label10
			//
			this.Label10.AutoSize = true;
			this.Label10.Location = new System.Drawing.Point(651, 22);
			this.Label10.Name = "Label10";
			this.Label10.Size = new System.Drawing.Size(89, 13);
			this.Label10.TabIndex = 38;
			this.Label10.Text = "Energy Required:";
			//
			//txtasrenergy
			//
			this.txtasrenergy.Enabled = false;
			this.txtasrenergy.Location = new System.Drawing.Point(746, 19);
			this.txtasrenergy.Name = "txtasrenergy";
			this.txtasrenergy.Size = new System.Drawing.Size(226, 20);
			this.txtasrenergy.TabIndex = 37;
			//
			//GroupBox4
			//
			this.GroupBox4.Controls.Add(this.Label9);
			this.GroupBox4.Controls.Add(this.TextBoxbumpenergy);
			this.GroupBox4.Controls.Add(this.Label2);
			this.GroupBox4.Controls.Add(this.TextBoxstepenergy);
			this.GroupBox4.Controls.Add(this.Label1);
			this.GroupBox4.Controls.Add(this.TextBoxinienergy);
			this.GroupBox4.Enabled = false;
			this.GroupBox4.Location = new System.Drawing.Point(10, 274);
			this.GroupBox4.Name = "GroupBox4";
			this.GroupBox4.Size = new System.Drawing.Size(981, 49);
			this.GroupBox4.TabIndex = 39;
			this.GroupBox4.TabStop = false;
			this.GroupBox4.Text = "Energy";
			//
			//Form3
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1003, 523);
			this.Controls.Add(this.GroupBox4);
			this.Controls.Add(this.GroupBox3);
			this.Controls.Add(this.GroupBoxaging);
			this.Controls.Add(this.GroupBox1);
			this.Controls.Add(this.Label7);
			this.Controls.Add(this.TextBoxname);
			this.Controls.Add(this.Button1);
			this.Controls.Add(this.Label12);
			this.Controls.Add(this.TextBoxcount);
			this.Controls.Add(this.Label28);
			this.Controls.Add(this.ComboBoxagent);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "Form3";
			this.Text = "Form3";
			this.GroupBox1.ResumeLayout(false);
			this.GroupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize) this.TrackBar3).EndInit();
			((System.ComponentModel.ISupportInitialize) this.TrackBar2).EndInit();
			((System.ComponentModel.ISupportInitialize) this.TrackBar4).EndInit();
			this.GroupBoxaging.ResumeLayout(false);
			this.GroupBoxaging.PerformLayout();
			this.GroupBox3.ResumeLayout(false);
			this.GroupBox3.PerformLayout();
			this.GroupBox4.ResumeLayout(false);
			this.GroupBox4.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
			
		}
		internal System.Windows.Forms.Label Label12;
		internal System.Windows.Forms.TextBox TextBoxcount;
		internal System.Windows.Forms.Label Label28;
		internal System.Windows.Forms.ComboBox ComboBoxagent;
		internal System.Windows.Forms.Button Button1;
		internal System.Windows.Forms.GroupBox GroupBox1;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.Label Label6;
		internal System.Windows.Forms.Button colour;
		internal System.Windows.Forms.TrackBar TrackBar3;
		internal System.Windows.Forms.TrackBar TrackBar2;
		internal System.Windows.Forms.TextBox TextBox2;
		internal System.Windows.Forms.TextBox TextBox1;
		internal System.Windows.Forms.TextBox TextBox3;
		internal System.Windows.Forms.TrackBar TrackBar4;
		internal System.Windows.Forms.Label Label7;
		internal System.Windows.Forms.TextBox TextBoxname;
		internal System.Windows.Forms.TextBox TextBoxinienergy;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.TextBox TextBoxstepenergy;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.TextBox txtasr;
		internal System.Windows.Forms.Label Label8;
		internal System.Windows.Forms.TextBox TextBoxagelimit;
		internal System.Windows.Forms.TextBox TextBoxbumpenergy;
		internal System.Windows.Forms.Label Label9;
		internal System.Windows.Forms.CheckBox CheckBoxaging;
		internal System.Windows.Forms.CheckBox CheckBoxasr;
		internal System.Windows.Forms.GroupBox GroupBoxaging;
		internal System.Windows.Forms.GroupBox GroupBox3;
		internal System.Windows.Forms.Label Label10;
		internal System.Windows.Forms.TextBox txtasrenergy;
		internal System.Windows.Forms.GroupBox GroupBox4;
	}
	
}
