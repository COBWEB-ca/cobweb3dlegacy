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
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public partial class generator : System.Windows.Forms.Form
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
			this.SuspendLayout();
			//
			//generator
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
			base.Load += new System.EventHandler(generator_Load);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(49, 19);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "generator";
			this.Opacity = 0.0D;
			this.Text = "generator";
			this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
			this.ResumeLayout(false);
			
		}
	}
	
}
