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
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public partial class Form5 : System.Windows.Forms.Form
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
			this.Button1 = new System.Windows.Forms.Button();
			base.Load += new System.EventHandler(Form5_Load);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Label1 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.ComboBoxagent = new System.Windows.Forms.ComboBox();
			this.ComboBoxagent.SelectedIndexChanged += new System.EventHandler(this.ComboBoxagent_SelectedIndexChanged);
			this.ComboBox1 = new System.Windows.Forms.ComboBox();
			this.ComboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
			this.CheckBoxproduce = new System.Windows.Forms.CheckBox();
			this.CheckBoxproduce.CheckedChanged += new System.EventHandler(this.CheckBox2_CheckedChanged);
			this.ComboBox2 = new System.Windows.Forms.ComboBox();
			this.ComboBox2.SelectedIndexChanged += new System.EventHandler(this.ComboBox2_SelectedIndexChanged);
			this.CheckBoxconsume = new System.Windows.Forms.CheckBox();
			this.CheckBoxconsume.CheckedChanged += new System.EventHandler(this.CheckBox3_CheckedChanged);
			this.Label3 = new System.Windows.Forms.Label();
			this.TextBox1 = new System.Windows.Forms.TextBox();
			this.TextBox1.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
			this.GroupBox1 = new System.Windows.Forms.GroupBox();
			this.CheckBoxdeminish = new System.Windows.Forms.CheckBox();
			this.CheckBoxdeminish.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
			this.RadioButton1 = new System.Windows.Forms.RadioButton();
			this.RadioButton1.CheckedChanged += new System.EventHandler(this.RadioButton1_CheckedChanged);
			this.RadioButton2 = new System.Windows.Forms.RadioButton();
			this.RadioButton2.CheckedChanged += new System.EventHandler(this.RadioButton2_CheckedChanged);
			this.Label4 = new System.Windows.Forms.Label();
			this.TextBox2 = new System.Windows.Forms.TextBox();
			this.TextBox2.TextChanged += new System.EventHandler(this.TextBox2_TextChanged);
			this.Label5 = new System.Windows.Forms.Label();
			this.TextBox3 = new System.Windows.Forms.TextBox();
			this.TextBox3.TextChanged += new System.EventHandler(this.TextBox3_TextChanged);
			this.Panel1 = new System.Windows.Forms.Panel();
			this.GroupBox1.SuspendLayout();
			this.Panel1.SuspendLayout();
			this.SuspendLayout();
			//
			//Button1
			//
			this.Button1.Location = new System.Drawing.Point(12, 244);
			this.Button1.Name = "Button1";
			this.Button1.Size = new System.Drawing.Size(596, 28);
			this.Button1.TabIndex = 0;
			this.Button1.Text = "Apply";
			this.Button1.UseVisualStyleBackColor = true;
			//
			//Label1
			//
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(9, 9);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(38, 13);
			this.Label1.TabIndex = 1;
			this.Label1.Text = "Agent:";
			//
			//Label2
			//
			this.Label2.AutoSize = true;
			this.Label2.Location = new System.Drawing.Point(9, 38);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(149, 13);
			this.Label2.TabIndex = 2;
			this.Label2.Text = "When come into contact with:";
			//
			//ComboBoxagent
			//
			this.ComboBoxagent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ComboBoxagent.FormattingEnabled = true;
			this.ComboBoxagent.Location = new System.Drawing.Point(53, 6);
			this.ComboBoxagent.Name = "ComboBoxagent";
			this.ComboBoxagent.Size = new System.Drawing.Size(555, 21);
			this.ComboBoxagent.TabIndex = 3;
			//
			//ComboBox1
			//
			this.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ComboBox1.FormattingEnabled = true;
			this.ComboBox1.Location = new System.Drawing.Point(164, 33);
			this.ComboBox1.Name = "ComboBox1";
			this.ComboBox1.Size = new System.Drawing.Size(444, 21);
			this.ComboBox1.TabIndex = 4;
			//
			//CheckBoxproduce
			//
			this.CheckBoxproduce.AutoSize = true;
			this.CheckBoxproduce.Location = new System.Drawing.Point(161, 16);
			this.CheckBoxproduce.Name = "CheckBoxproduce";
			this.CheckBoxproduce.Size = new System.Drawing.Size(82, 17);
			this.CheckBoxproduce.TabIndex = 6;
			this.CheckBoxproduce.Text = "Reproduce:";
			this.CheckBoxproduce.UseVisualStyleBackColor = true;
			//
			//ComboBox2
			//
			this.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ComboBox2.FormattingEnabled = true;
			this.ComboBox2.Location = new System.Drawing.Point(249, 14);
			this.ComboBox2.Name = "ComboBox2";
			this.ComboBox2.Size = new System.Drawing.Size(341, 21);
			this.ComboBox2.TabIndex = 7;
			//
			//CheckBoxconsume
			//
			this.CheckBoxconsume.AutoSize = true;
			this.CheckBoxconsume.Location = new System.Drawing.Point(6, 16);
			this.CheckBoxconsume.Name = "CheckBoxconsume";
			this.CheckBoxconsume.Size = new System.Drawing.Size(75, 17);
			this.CheckBoxconsume.TabIndex = 8;
			this.CheckBoxconsume.Text = "Consumes";
			this.CheckBoxconsume.UseVisualStyleBackColor = true;
			//
			//Label3
			//
			this.Label3.AutoSize = true;
			this.Label3.Location = new System.Drawing.Point(26, 19);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(186, 13);
			this.Label3.TabIndex = 9;
			this.Label3.Text = "% energy transferred when consumes:";
			//
			//TextBox1
			//
			this.TextBox1.Location = new System.Drawing.Point(218, 16);
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.Size = new System.Drawing.Size(372, 20);
			this.TextBox1.TabIndex = 10;
			//
			//GroupBox1
			//
			this.GroupBox1.Controls.Add(this.CheckBoxdeminish);
			this.GroupBox1.Controls.Add(this.CheckBoxconsume);
			this.GroupBox1.Controls.Add(this.ComboBox2);
			this.GroupBox1.Controls.Add(this.CheckBoxproduce);
			this.GroupBox1.Location = new System.Drawing.Point(12, 71);
			this.GroupBox1.Name = "GroupBox1";
			this.GroupBox1.Size = new System.Drawing.Size(596, 49);
			this.GroupBox1.TabIndex = 11;
			this.GroupBox1.TabStop = false;
			this.GroupBox1.Text = "Actions:";
			//
			//CheckBoxdeminish
			//
			this.CheckBoxdeminish.AutoSize = true;
			this.CheckBoxdeminish.Location = new System.Drawing.Point(87, 16);
			this.CheckBoxdeminish.Name = "CheckBoxdeminish";
			this.CheckBoxdeminish.Size = new System.Drawing.Size(68, 17);
			this.CheckBoxdeminish.TabIndex = 11;
			this.CheckBoxdeminish.Text = "Diminish ";
			this.CheckBoxdeminish.UseVisualStyleBackColor = true;
			//
			//RadioButton1
			//
			this.RadioButton1.AutoSize = true;
			this.RadioButton1.Location = new System.Drawing.Point(6, 19);
			this.RadioButton1.Name = "RadioButton1";
			this.RadioButton1.Size = new System.Drawing.Size(14, 13);
			this.RadioButton1.TabIndex = 12;
			this.RadioButton1.TabStop = true;
			this.RadioButton1.UseVisualStyleBackColor = true;
			//
			//RadioButton2
			//
			this.RadioButton2.AutoSize = true;
			this.RadioButton2.Location = new System.Drawing.Point(6, 45);
			this.RadioButton2.Name = "RadioButton2";
			this.RadioButton2.Size = new System.Drawing.Size(14, 13);
			this.RadioButton2.TabIndex = 15;
			this.RadioButton2.TabStop = true;
			this.RadioButton2.UseVisualStyleBackColor = true;
			//
			//Label4
			//
			this.Label4.AutoSize = true;
			this.Label4.Location = new System.Drawing.Point(26, 45);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(253, 13);
			this.Label4.TabIndex = 13;
			this.Label4.Text = "Fixed amound of energy transferred when consumes";
			//
			//TextBox2
			//
			this.TextBox2.Location = new System.Drawing.Point(285, 42);
			this.TextBox2.Name = "TextBox2";
			this.TextBox2.Size = new System.Drawing.Size(305, 20);
			this.TextBox2.TabIndex = 14;
			//
			//Label5
			//
			this.Label5.AutoSize = true;
			this.Label5.Location = new System.Drawing.Point(9, 209);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(139, 13);
			this.Label5.TabIndex = 16;
			this.Label5.Text = "Energy cost in reproduction:";
			//
			//TextBox3
			//
			this.TextBox3.Location = new System.Drawing.Point(154, 206);
			this.TextBox3.Name = "TextBox3";
			this.TextBox3.Size = new System.Drawing.Size(454, 20);
			this.TextBox3.TabIndex = 17;
			//
			//Panel1
			//
			this.Panel1.Controls.Add(this.RadioButton2);
			this.Panel1.Controls.Add(this.Label4);
			this.Panel1.Controls.Add(this.TextBox2);
			this.Panel1.Controls.Add(this.RadioButton1);
			this.Panel1.Controls.Add(this.Label3);
			this.Panel1.Controls.Add(this.TextBox1);
			this.Panel1.Location = new System.Drawing.Point(12, 126);
			this.Panel1.Name = "Panel1";
			this.Panel1.Size = new System.Drawing.Size(596, 74);
			this.Panel1.TabIndex = 18;
			//
			//Form5
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(615, 278);
			this.Controls.Add(this.Panel1);
			this.Controls.Add(this.Label5);
			this.Controls.Add(this.TextBox3);
			this.Controls.Add(this.GroupBox1);
			this.Controls.Add(this.ComboBox1);
			this.Controls.Add(this.ComboBoxagent);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.Button1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "Form5";
			this.Text = "Interactions";
			this.GroupBox1.ResumeLayout(false);
			this.GroupBox1.PerformLayout();
			this.Panel1.ResumeLayout(false);
			this.Panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
			
		}
		internal System.Windows.Forms.Button Button1;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.ComboBox ComboBoxagent;
		internal System.Windows.Forms.ComboBox ComboBox1;
		internal System.Windows.Forms.CheckBox CheckBoxproduce;
		internal System.Windows.Forms.ComboBox ComboBox2;
		internal System.Windows.Forms.CheckBox CheckBoxconsume;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.TextBox TextBox1;
		internal System.Windows.Forms.GroupBox GroupBox1;
		internal System.Windows.Forms.CheckBox CheckBoxdeminish;
		internal System.Windows.Forms.RadioButton RadioButton1;
		internal System.Windows.Forms.RadioButton RadioButton2;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.TextBox TextBox2;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.TextBox TextBox3;
		internal System.Windows.Forms.Panel Panel1;
	}
	
}
