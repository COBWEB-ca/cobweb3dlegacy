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
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public partial class AI : System.Windows.Forms.Form
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
			this.Label28 = new System.Windows.Forms.Label();
			base.Load += new System.EventHandler(AI_Load);
			this.ComboBoxagent = new System.Windows.Forms.ComboBox();
			this.ComboBoxagent.SelectedIndexChanged += new System.EventHandler(this.ComboBoxagent_SelectedIndexChanged);
			this.TextBox2 = new System.Windows.Forms.TextBox();
			this.TextBox2.TextChanged += new System.EventHandler(this.TextBox2_TextChanged);
			this.TextBox1 = new System.Windows.Forms.TextBox();
			this.TextBox1.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
			this.Label1 = new System.Windows.Forms.Label();
			this.GroupBox1 = new System.Windows.Forms.GroupBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.GroupBox2 = new System.Windows.Forms.GroupBox();
			this.Label3 = new System.Windows.Forms.Label();
			this.TextBox4 = new System.Windows.Forms.TextBox();
			this.TextBox4.TextChanged += new System.EventHandler(this.TextBox4_TextChanged);
			this.TextBox3 = new System.Windows.Forms.TextBox();
			this.TextBox3.TextChanged += new System.EventHandler(this.TextBox3_TextChanged);
			this.Label4 = new System.Windows.Forms.Label();
			this.GroupBox3 = new System.Windows.Forms.GroupBox();
			this.Label5 = new System.Windows.Forms.Label();
			this.TextBox6 = new System.Windows.Forms.TextBox();
			this.TextBox6.TextChanged += new System.EventHandler(this.TextBox6_TextChanged);
			this.TextBox5 = new System.Windows.Forms.TextBox();
			this.TextBox5.TextChanged += new System.EventHandler(this.TextBox5_TextChanged);
			this.Label6 = new System.Windows.Forms.Label();
			this.Button1 = new System.Windows.Forms.Button();
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.CheckBox1 = new System.Windows.Forms.CheckBox();
			this.CheckBox1.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
			this.GroupBox1.SuspendLayout();
			this.GroupBox2.SuspendLayout();
			this.GroupBox3.SuspendLayout();
			this.SuspendLayout();
			//
			//Label28
			//
			this.Label28.AutoSize = true;
			this.Label28.Location = new System.Drawing.Point(9, 15);
			this.Label28.Name = "Label28";
			this.Label28.Size = new System.Drawing.Size(38, 13);
			this.Label28.TabIndex = 5;
			this.Label28.Text = "Agent:";
			//
			//ComboBoxagent
			//
			this.ComboBoxagent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ComboBoxagent.FormattingEnabled = true;
			this.ComboBoxagent.Location = new System.Drawing.Point(53, 12);
			this.ComboBoxagent.Name = "ComboBoxagent";
			this.ComboBoxagent.Size = new System.Drawing.Size(545, 21);
			this.ComboBoxagent.TabIndex = 4;
			//
			//TextBox2
			//
			this.TextBox2.Location = new System.Drawing.Point(335, 19);
			this.TextBox2.Name = "TextBox2";
			this.TextBox2.Size = new System.Drawing.Size(233, 20);
			this.TextBox2.TabIndex = 6;
			//
			//TextBox1
			//
			this.TextBox1.Location = new System.Drawing.Point(55, 19);
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.Size = new System.Drawing.Size(233, 20);
			this.TextBox1.TabIndex = 7;
			//
			//Label1
			//
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(10, 22);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(33, 13);
			this.Label1.TabIndex = 8;
			this.Label1.Text = "From:";
			//
			//GroupBox1
			//
			this.GroupBox1.Controls.Add(this.Label2);
			this.GroupBox1.Controls.Add(this.TextBox2);
			this.GroupBox1.Controls.Add(this.TextBox1);
			this.GroupBox1.Controls.Add(this.Label1);
			this.GroupBox1.Location = new System.Drawing.Point(12, 49);
			this.GroupBox1.Name = "GroupBox1";
			this.GroupBox1.Size = new System.Drawing.Size(586, 56);
			this.GroupBox1.TabIndex = 9;
			this.GroupBox1.TabStop = false;
			this.GroupBox1.Text = "Target Range (x-direction)";
			//
			//Label2
			//
			this.Label2.AutoSize = true;
			this.Label2.Location = new System.Drawing.Point(306, 22);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(23, 13);
			this.Label2.TabIndex = 9;
			this.Label2.Text = "To:";
			//
			//GroupBox2
			//
			this.GroupBox2.Controls.Add(this.Label3);
			this.GroupBox2.Controls.Add(this.TextBox4);
			this.GroupBox2.Controls.Add(this.TextBox3);
			this.GroupBox2.Controls.Add(this.Label4);
			this.GroupBox2.Location = new System.Drawing.Point(12, 111);
			this.GroupBox2.Name = "GroupBox2";
			this.GroupBox2.Size = new System.Drawing.Size(586, 56);
			this.GroupBox2.TabIndex = 10;
			this.GroupBox2.TabStop = false;
			this.GroupBox2.Text = "Target Range (y-direction)";
			//
			//Label3
			//
			this.Label3.AutoSize = true;
			this.Label3.Location = new System.Drawing.Point(306, 22);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(23, 13);
			this.Label3.TabIndex = 9;
			this.Label3.Text = "To:";
			//
			//TextBox4
			//
			this.TextBox4.Location = new System.Drawing.Point(335, 19);
			this.TextBox4.Name = "TextBox4";
			this.TextBox4.Size = new System.Drawing.Size(233, 20);
			this.TextBox4.TabIndex = 6;
			//
			//TextBox3
			//
			this.TextBox3.Location = new System.Drawing.Point(55, 19);
			this.TextBox3.Name = "TextBox3";
			this.TextBox3.Size = new System.Drawing.Size(233, 20);
			this.TextBox3.TabIndex = 7;
			//
			//Label4
			//
			this.Label4.AutoSize = true;
			this.Label4.Location = new System.Drawing.Point(10, 22);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(33, 13);
			this.Label4.TabIndex = 8;
			this.Label4.Text = "From:";
			//
			//GroupBox3
			//
			this.GroupBox3.Controls.Add(this.Label5);
			this.GroupBox3.Controls.Add(this.TextBox6);
			this.GroupBox3.Controls.Add(this.TextBox5);
			this.GroupBox3.Controls.Add(this.Label6);
			this.GroupBox3.Location = new System.Drawing.Point(12, 173);
			this.GroupBox3.Name = "GroupBox3";
			this.GroupBox3.Size = new System.Drawing.Size(586, 56);
			this.GroupBox3.TabIndex = 11;
			this.GroupBox3.TabStop = false;
			this.GroupBox3.Text = "Target Range (z-direction)";
			//
			//Label5
			//
			this.Label5.AutoSize = true;
			this.Label5.Location = new System.Drawing.Point(306, 22);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(23, 13);
			this.Label5.TabIndex = 9;
			this.Label5.Text = "To:";
			//
			//TextBox6
			//
			this.TextBox6.Location = new System.Drawing.Point(335, 19);
			this.TextBox6.Name = "TextBox6";
			this.TextBox6.Size = new System.Drawing.Size(233, 20);
			this.TextBox6.TabIndex = 6;
			//
			//TextBox5
			//
			this.TextBox5.Location = new System.Drawing.Point(55, 19);
			this.TextBox5.Name = "TextBox5";
			this.TextBox5.Size = new System.Drawing.Size(233, 20);
			this.TextBox5.TabIndex = 7;
			//
			//Label6
			//
			this.Label6.AutoSize = true;
			this.Label6.Location = new System.Drawing.Point(10, 22);
			this.Label6.Name = "Label6";
			this.Label6.Size = new System.Drawing.Size(33, 13);
			this.Label6.TabIndex = 8;
			this.Label6.Text = "From:";
			//
			//Button1
			//
			this.Button1.Location = new System.Drawing.Point(12, 260);
			this.Button1.Name = "Button1";
			this.Button1.Size = new System.Drawing.Size(586, 29);
			this.Button1.TabIndex = 12;
			this.Button1.Text = "Apply";
			this.Button1.UseVisualStyleBackColor = true;
			//
			//CheckBox1
			//
			this.CheckBox1.AutoSize = true;
			this.CheckBox1.Location = new System.Drawing.Point(12, 237);
			this.CheckBox1.Name = "CheckBox1";
			this.CheckBox1.Size = new System.Drawing.Size(540, 17);
			this.CheckBox1.TabIndex = 13;
			this.CheckBox1.Text = "Absolute Range   (If the this box is checked the respected agent will only be pre" + "sent at the defined boundary)";
			this.CheckBox1.UseVisualStyleBackColor = true;
			//
			//AI
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(614, 301);
			this.Controls.Add(this.CheckBox1);
			this.Controls.Add(this.Button1);
			this.Controls.Add(this.GroupBox3);
			this.Controls.Add(this.GroupBox2);
			this.Controls.Add(this.GroupBox1);
			this.Controls.Add(this.Label28);
			this.Controls.Add(this.ComboBoxagent);
			this.Name = "AI";
			this.Text = "Artifical Intelligence";
			this.GroupBox1.ResumeLayout(false);
			this.GroupBox1.PerformLayout();
			this.GroupBox2.ResumeLayout(false);
			this.GroupBox2.PerformLayout();
			this.GroupBox3.ResumeLayout(false);
			this.GroupBox3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
			
		}
		internal System.Windows.Forms.Label Label28;
		internal System.Windows.Forms.ComboBox ComboBoxagent;
		internal System.Windows.Forms.TextBox TextBox2;
		internal System.Windows.Forms.TextBox TextBox1;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.GroupBox GroupBox1;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.GroupBox GroupBox2;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.TextBox TextBox4;
		internal System.Windows.Forms.TextBox TextBox3;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.GroupBox GroupBox3;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.TextBox TextBox6;
		internal System.Windows.Forms.TextBox TextBox5;
		internal System.Windows.Forms.Label Label6;
		internal System.Windows.Forms.Button Button1;
		internal System.Windows.Forms.CheckBox CheckBox1;
	}
	
}
