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
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public partial class Ratio : System.Windows.Forms.Form
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
			this.TrackBar1 = new System.Windows.Forms.TrackBar();
			this.TrackBar1.Scroll += new System.EventHandler(this.TrackBar1_Scroll);
			base.Load += new System.EventHandler(Ratio_Load);
			this.Button1 = new System.Windows.Forms.Button();
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			((System.ComponentModel.ISupportInitialize) this.TrackBar1).BeginInit();
			this.SuspendLayout();
			//
			//TrackBar1
			//
			this.TrackBar1.Location = new System.Drawing.Point(12, 12);
			this.TrackBar1.Maximum = 20;
			this.TrackBar1.Name = "TrackBar1";
			this.TrackBar1.Size = new System.Drawing.Size(604, 45);
			this.TrackBar1.TabIndex = 0;
			this.TrackBar1.TickStyle = System.Windows.Forms.TickStyle.Both;
			//
			//Button1
			//
			this.Button1.Location = new System.Drawing.Point(12, 63);
			this.Button1.Name = "Button1";
			this.Button1.Size = new System.Drawing.Size(604, 34);
			this.Button1.TabIndex = 1;
			this.Button1.Text = "Done";
			this.Button1.UseVisualStyleBackColor = true;
			//
			//Ratio
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(628, 107);
			this.Controls.Add(this.Button1);
			this.Controls.Add(this.TrackBar1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "Ratio";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Ratio";
			((System.ComponentModel.ISupportInitialize) this.TrackBar1).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
			
		}
		internal System.Windows.Forms.TrackBar TrackBar1;
		internal System.Windows.Forms.Button Button1;
	}
	
}
