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
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public partial class Form2 : System.Windows.Forms.Form
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
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Button2 = new System.Windows.Forms.Button();
			this.GroupBox2 = new System.Windows.Forms.GroupBox();
			this.Label10 = new System.Windows.Forms.Label();
			this.TextBox4 = new System.Windows.Forms.TextBox();
			this.TextBox4.TextChanged += new System.EventHandler(this.TextBox4_TextChanged);
			this.GroupBox1 = new System.Windows.Forms.GroupBox();
			this.Label9 = new System.Windows.Forms.Label();
			this.Label8 = new System.Windows.Forms.Label();
			this.Label7 = new System.Windows.Forms.Label();
			this.Label4 = new System.Windows.Forms.Label();
			this.TextBox3 = new System.Windows.Forms.TextBox();
			this.Label5 = new System.Windows.Forms.Label();
			this.Label6 = new System.Windows.Forms.Label();
			this.TextBox1 = new System.Windows.Forms.TextBox();
			this.TextBox2 = new System.Windows.Forms.TextBox();
			this.GroupBox2.SuspendLayout();
			this.GroupBox1.SuspendLayout();
			this.SuspendLayout();
			//
			//Button1
			//
			this.Button1.Location = new System.Drawing.Point(12, 190);
			this.Button1.Name = "Button1";
			this.Button1.Size = new System.Drawing.Size(348, 27);
			this.Button1.TabIndex = 5;
			this.Button1.Text = "Apply";
			this.Button1.UseVisualStyleBackColor = true;
			//
			//Button2
			//
			this.Button2.Location = new System.Drawing.Point(12, 223);
			this.Button2.Name = "Button2";
			this.Button2.Size = new System.Drawing.Size(348, 26);
			this.Button2.TabIndex = 18;
			this.Button2.Text = "Cancel";
			this.Button2.UseVisualStyleBackColor = true;
			//
			//GroupBox2
			//
			this.GroupBox2.Controls.Add(this.Label10);
			this.GroupBox2.Controls.Add(this.TextBox4);
			this.GroupBox2.Location = new System.Drawing.Point(12, 124);
			this.GroupBox2.Name = "GroupBox2";
			this.GroupBox2.Size = new System.Drawing.Size(348, 52);
			this.GroupBox2.TabIndex = 17;
			this.GroupBox2.TabStop = false;
			this.GroupBox2.Text = "Agents";
			//
			//Label10
			//
			this.Label10.AutoSize = true;
			this.Label10.Location = new System.Drawing.Point(6, 25);
			this.Label10.Name = "Label10";
			this.Label10.Size = new System.Drawing.Size(67, 13);
			this.Label10.TabIndex = 13;
			this.Label10.Text = "Agent Types";
			//
			//TextBox4
			//
			this.TextBox4.Location = new System.Drawing.Point(79, 22);
			this.TextBox4.Name = "TextBox4";
			this.TextBox4.Size = new System.Drawing.Size(263, 20);
			this.TextBox4.TabIndex = 16;
			this.TextBox4.Text = "1";
			//
			//GroupBox1
			//
			this.GroupBox1.Controls.Add(this.Label9);
			this.GroupBox1.Controls.Add(this.Label8);
			this.GroupBox1.Controls.Add(this.Label7);
			this.GroupBox1.Controls.Add(this.Label4);
			this.GroupBox1.Controls.Add(this.TextBox3);
			this.GroupBox1.Controls.Add(this.Label5);
			this.GroupBox1.Controls.Add(this.Label6);
			this.GroupBox1.Controls.Add(this.TextBox1);
			this.GroupBox1.Controls.Add(this.TextBox2);
			this.GroupBox1.Location = new System.Drawing.Point(12, 12);
			this.GroupBox1.Name = "GroupBox1";
			this.GroupBox1.Size = new System.Drawing.Size(348, 99);
			this.GroupBox1.TabIndex = 12;
			this.GroupBox1.TabStop = false;
			this.GroupBox1.Text = "Size";
			//
			//Label9
			//
			this.Label9.AutoSize = true;
			this.Label9.Location = new System.Drawing.Point(311, 74);
			this.Label9.Name = "Label9";
			this.Label9.Size = new System.Drawing.Size(31, 13);
			this.Label9.TabIndex = 14;
			this.Label9.Text = "Units";
			//
			//Label8
			//
			this.Label8.AutoSize = true;
			this.Label8.Location = new System.Drawing.Point(311, 48);
			this.Label8.Name = "Label8";
			this.Label8.Size = new System.Drawing.Size(31, 13);
			this.Label8.TabIndex = 13;
			this.Label8.Text = "Units";
			//
			//Label7
			//
			this.Label7.AutoSize = true;
			this.Label7.Location = new System.Drawing.Point(311, 22);
			this.Label7.Name = "Label7";
			this.Label7.Size = new System.Drawing.Size(31, 13);
			this.Label7.TabIndex = 12;
			this.Label7.Text = "Units";
			//
			//Label4
			//
			this.Label4.AutoSize = true;
			this.Label4.Location = new System.Drawing.Point(7, 22);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(36, 13);
			this.Label4.TabIndex = 6;
			this.Label4.Text = "X-Axis";
			//
			//TextBox3
			//
			this.TextBox3.Location = new System.Drawing.Point(49, 71);
			this.TextBox3.Name = "TextBox3";
			this.TextBox3.Size = new System.Drawing.Size(260, 20);
			this.TextBox3.TabIndex = 11;
			this.TextBox3.Text = "5";
			//
			//Label5
			//
			this.Label5.AutoSize = true;
			this.Label5.Location = new System.Drawing.Point(7, 48);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(36, 13);
			this.Label5.TabIndex = 7;
			this.Label5.Text = "Y-Axis";
			//
			//Label6
			//
			this.Label6.AutoSize = true;
			this.Label6.Location = new System.Drawing.Point(7, 74);
			this.Label6.Name = "Label6";
			this.Label6.Size = new System.Drawing.Size(36, 13);
			this.Label6.TabIndex = 10;
			this.Label6.Text = "Z-Axis";
			//
			//TextBox1
			//
			this.TextBox1.Location = new System.Drawing.Point(49, 19);
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.Size = new System.Drawing.Size(260, 20);
			this.TextBox1.TabIndex = 8;
			this.TextBox1.Text = "10";
			//
			//TextBox2
			//
			this.TextBox2.Location = new System.Drawing.Point(49, 45);
			this.TextBox2.Name = "TextBox2";
			this.TextBox2.Size = new System.Drawing.Size(260, 20);
			this.TextBox2.TabIndex = 9;
			this.TextBox2.Text = "10";
			//
			//Form2
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(376, 259);
			this.Controls.Add(this.GroupBox2);
			this.Controls.Add(this.Button2);
			this.Controls.Add(this.GroupBox1);
			this.Controls.Add(this.Button1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "Form2";
			this.Text = "New Project";
			this.GroupBox2.ResumeLayout(false);
			this.GroupBox2.PerformLayout();
			this.GroupBox1.ResumeLayout(false);
			this.GroupBox1.PerformLayout();
			this.ResumeLayout(false);
			
		}
		internal System.Windows.Forms.Button Button1;
		internal System.Windows.Forms.Button Button2;
		internal System.Windows.Forms.GroupBox GroupBox2;
		internal System.Windows.Forms.Label Label10;
		internal System.Windows.Forms.TextBox TextBox4;
		internal System.Windows.Forms.GroupBox GroupBox1;
		internal System.Windows.Forms.Label Label9;
		internal System.Windows.Forms.Label Label8;
		internal System.Windows.Forms.Label Label7;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.TextBox TextBox3;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.Label Label6;
		internal System.Windows.Forms.TextBox TextBox1;
		internal System.Windows.Forms.TextBox TextBox2;
	}
	
}
