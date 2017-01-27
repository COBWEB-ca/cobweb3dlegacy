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
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public partial class Form4 : System.Windows.Forms.Form
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
			this.components = new System.ComponentModel.Container();
			base.Load += new System.EventHandler(Form4_Load);
			this.labelagentnumber = new System.Windows.Forms.Label();
			this.Timer1 = new System.Windows.Forms.Timer(this.components);
			this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
			this.labelX = new System.Windows.Forms.Label();
			this.labelY = new System.Windows.Forms.Label();
			this.labelZ = new System.Windows.Forms.Label();
			this.labelAGENTTYPE = new System.Windows.Forms.Label();
			this.labelENERGY = new System.Windows.Forms.Label();
			this.labelAGE = new System.Windows.Forms.Label();
			this.Panel1 = new System.Windows.Forms.Panel();
			this.VScrollBar1 = new System.Windows.Forms.VScrollBar();
			this.Panel1.SuspendLayout();
			this.SuspendLayout();
			//
			//labelagentnumber
			//
			this.labelagentnumber.AutoSize = true;
			this.labelagentnumber.Location = new System.Drawing.Point(5, 10);
			this.labelagentnumber.Name = "labelagentnumber";
			this.labelagentnumber.Size = new System.Drawing.Size(79, 13);
			this.labelagentnumber.TabIndex = 0;
			this.labelagentnumber.Text = "Agent number: ";
			//
			//Timer1
			//
			//
			//labelX
			//
			this.labelX.AutoSize = true;
			this.labelX.Location = new System.Drawing.Point(133, 10);
			this.labelX.Name = "labelX";
			this.labelX.Size = new System.Drawing.Size(50, 13);
			this.labelX.TabIndex = 6;
			this.labelX.Text = "X-Value: ";
			//
			//labelY
			//
			this.labelY.AutoSize = true;
			this.labelY.Location = new System.Drawing.Point(261, 10);
			this.labelY.Name = "labelY";
			this.labelY.Size = new System.Drawing.Size(50, 13);
			this.labelY.TabIndex = 7;
			this.labelY.Text = "Y-Value: ";
			//
			//labelZ
			//
			this.labelZ.AutoSize = true;
			this.labelZ.Location = new System.Drawing.Point(392, 10);
			this.labelZ.Name = "labelZ";
			this.labelZ.Size = new System.Drawing.Size(50, 13);
			this.labelZ.TabIndex = 8;
			this.labelZ.Text = "Z-Value: ";
			//
			//labelAGENTTYPE
			//
			this.labelAGENTTYPE.AutoSize = true;
			this.labelAGENTTYPE.Location = new System.Drawing.Point(520, 10);
			this.labelAGENTTYPE.Name = "labelAGENTTYPE";
			this.labelAGENTTYPE.Size = new System.Drawing.Size(68, 13);
			this.labelAGENTTYPE.TabIndex = 9;
			this.labelAGENTTYPE.Text = "Agent Type: ";
			//
			//labelENERGY
			//
			this.labelENERGY.AutoSize = true;
			this.labelENERGY.Location = new System.Drawing.Point(657, 10);
			this.labelENERGY.Name = "labelENERGY";
			this.labelENERGY.Size = new System.Drawing.Size(77, 13);
			this.labelENERGY.TabIndex = 10;
			this.labelENERGY.Text = "Agent Energy: ";
			//
			//labelAGE
			//
			this.labelAGE.AutoSize = true;
			this.labelAGE.Location = new System.Drawing.Point(790, 10);
			this.labelAGE.Name = "labelAGE";
			this.labelAGE.Size = new System.Drawing.Size(63, 13);
			this.labelAGE.TabIndex = 11;
			this.labelAGE.Text = "Agent Age: ";
			//
			//Panel1
			//
			this.Panel1.Anchor = (System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
			this.Panel1.Controls.Add(this.labelAGE);
			this.Panel1.Controls.Add(this.labelENERGY);
			this.Panel1.Controls.Add(this.labelAGENTTYPE);
			this.Panel1.Controls.Add(this.labelZ);
			this.Panel1.Controls.Add(this.labelY);
			this.Panel1.Controls.Add(this.labelX);
			this.Panel1.Controls.Add(this.labelagentnumber);
			this.Panel1.Location = new System.Drawing.Point(7, 12);
			this.Panel1.Name = "Panel1";
			this.Panel1.Size = new System.Drawing.Size(870, 464);
			this.Panel1.TabIndex = 12;
			//
			//VScrollBar1
			//
			this.VScrollBar1.Anchor = (System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Right);
			this.VScrollBar1.LargeChange = 1;
			this.VScrollBar1.Location = new System.Drawing.Point(880, 12);
			this.VScrollBar1.Maximum = 0;
			this.VScrollBar1.Name = "VScrollBar1";
			this.VScrollBar1.Size = new System.Drawing.Size(20, 461);
			this.VScrollBar1.TabIndex = 12;
			//
			//Form4
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(903, 488);
			this.Controls.Add(this.VScrollBar1);
			this.Controls.Add(this.Panel1);
			this.Name = "Form4";
			this.Text = "Data";
			this.Panel1.ResumeLayout(false);
			this.Panel1.PerformLayout();
			this.ResumeLayout(false);
			
		}
		internal System.Windows.Forms.Label labelagentnumber;
		internal System.Windows.Forms.Timer Timer1;
		internal System.Windows.Forms.Label labelX;
		internal System.Windows.Forms.Label labelY;
		internal System.Windows.Forms.Label labelZ;
		internal System.Windows.Forms.Label labelAGENTTYPE;
		internal System.Windows.Forms.Label labelENERGY;
		internal System.Windows.Forms.Label labelAGE;
		internal System.Windows.Forms.Panel Panel1;
		internal System.Windows.Forms.VScrollBar VScrollBar1;
	}
	
}
