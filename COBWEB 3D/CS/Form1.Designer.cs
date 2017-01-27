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
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public partial class Form1 : System.Windows.Forms.Form
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
			this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.NewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.NewToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
			this.OpenProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.OpenProjectToolStripMenuItem.Click += new System.EventHandler(this.OpenProjectToolStripMenuItem_Click);
			this.SaveProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.SaveProjectToolStripMenuItem.Click += new System.EventHandler(this.SaveProjectToolStripMenuItem_Click);
			this.LogDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.LogDataToolStripMenuItem.Click += new System.EventHandler(this.LogDataToolStripMenuItem_Click);
			this.CreditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.CreditToolStripMenuItem.Click += new System.EventHandler(this.CreditToolStripMenuItem_Click);
			this.QuitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.QuitToolStripMenuItem.Click += new System.EventHandler(this.QuitToolStripMenuItem_Click);
			this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.TickToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.TickToolStripMenuItem.Click += new System.EventHandler(this.TickToolStripMenuItem_Click);
			this.ViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.SizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.SizeToolStripMenuItem.Click += new System.EventHandler(this.SizeToolStripMenuItem_Click);
			this.AIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.AIToolStripMenuItem.Click += new System.EventHandler(this.AIToolStripMenuItem_Click);
			this.collisionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.collisionToolStripMenuItem.Click += new System.EventHandler(this.FoodWebToolStripMenuItem_Click);
			this.ProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.TopViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.TopViewToolStripMenuItem.Click += new System.EventHandler(this.TopViewToolStripMenuItem_Click);
			this.SideViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.SideViewToolStripMenuItem.Click += new System.EventHandler(this.SideViewToolStripMenuItem_Click);
			this.SideViewToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.SideViewToolStripMenuItem1.Click += new System.EventHandler(this.SideViewToolStripMenuzItem1_Click);
			this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.AdjustFocalPointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.AdjustFocalPointToolStripMenuItem.Click += new System.EventHandler(this.AdjustFocalPointToolStripMenuItem_Click);
			this.FullScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.FullScreenToolStripMenuItem.Click += new System.EventHandler(this.FullScreenToolStripMenuItem_Click);
			this.GraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.DataSheetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.DataSheetToolStripMenuItem.Click += new System.EventHandler(this.DataSheetToolStripMenuItem_Click);
			this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.HelpToolStripMenuItem.Click += new System.EventHandler(this.HelpToolStripMenuItem_Click);
			this.StopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.StopToolStripMenuItem.Click += new System.EventHandler(this.StopToolStripMenuItem_Click);
			this.Timerxy = new System.Windows.Forms.Timer(this.components);
			this.Timerxy.Tick += new System.EventHandler(this.Timerxy_Tick);
			this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
			this.ToolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.timelabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.ToolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
			this.ToolStripStatusLabel2.Click += new System.EventHandler(this.ToolStripStatusLabel2_Click);
			this.stoplabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.ToolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
			this.ToolStripStatusLabel4.Click += new System.EventHandler(this.ToolStripStatusLabel4_Click);
			this.speedbar = new System.Windows.Forms.ToolStripProgressBar();
			this.spacebar = new System.Windows.Forms.ToolStripStatusLabel();
			this.viewlabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			this.SaveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.SaveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.SaveFileDialog1_FileOk);
			this.SaveFilepro = new System.Windows.Forms.SaveFileDialog();
			this.SaveFilepro.FileOk += new System.ComponentModel.CancelEventHandler(this.SaveFilepro_FileOk);
			this.OpenFilepro = new System.Windows.Forms.OpenFileDialog();
			this.OpenFilepro.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFilepro_FileOk);
			this.MenuStrip1.SuspendLayout();
			this.StatusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) this.PictureBox1).BeginInit();
			this.SuspendLayout();
			//
			//MenuStrip1
			//
			this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.FileToolStripMenuItem, this.EditToolStripMenuItem, this.ViewToolStripMenuItem, this.ProjectToolStripMenuItem, this.GraphToolStripMenuItem, this.HelpToolStripMenuItem, this.StopToolStripMenuItem});
			this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
			this.MenuStrip1.Name = "MenuStrip1";
			this.MenuStrip1.Size = new System.Drawing.Size(1215, 24);
			this.MenuStrip1.TabIndex = 0;
			this.MenuStrip1.Text = "MenuStrip1";
			//
			//FileToolStripMenuItem
			//
			this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.NewToolStripMenuItem, this.OpenProjectToolStripMenuItem, this.SaveProjectToolStripMenuItem, this.LogDataToolStripMenuItem, this.CreditToolStripMenuItem, this.QuitToolStripMenuItem});
			this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
			this.FileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.FileToolStripMenuItem.Text = "File";
			//
			//NewToolStripMenuItem
			//
			this.NewToolStripMenuItem.Name = "NewToolStripMenuItem";
			this.NewToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
			this.NewToolStripMenuItem.Text = "New Project";
			//
			//OpenProjectToolStripMenuItem
			//
			this.OpenProjectToolStripMenuItem.Name = "OpenProjectToolStripMenuItem";
			this.OpenProjectToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
			this.OpenProjectToolStripMenuItem.Text = "Open Project";
			//
			//SaveProjectToolStripMenuItem
			//
			this.SaveProjectToolStripMenuItem.Enabled = false;
			this.SaveProjectToolStripMenuItem.Name = "SaveProjectToolStripMenuItem";
			this.SaveProjectToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
			this.SaveProjectToolStripMenuItem.Text = "Save Project";
			//
			//LogDataToolStripMenuItem
			//
			this.LogDataToolStripMenuItem.Enabled = false;
			this.LogDataToolStripMenuItem.Name = "LogDataToolStripMenuItem";
			this.LogDataToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
			this.LogDataToolStripMenuItem.Text = "Log Data";
			//
			//CreditToolStripMenuItem
			//
			this.CreditToolStripMenuItem.Name = "CreditToolStripMenuItem";
			this.CreditToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
			this.CreditToolStripMenuItem.Text = "Credit";
			//
			//QuitToolStripMenuItem
			//
			this.QuitToolStripMenuItem.Name = "QuitToolStripMenuItem";
			this.QuitToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
			this.QuitToolStripMenuItem.Text = "Quit";
			//
			//EditToolStripMenuItem
			//
			this.EditToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.TickToolStripMenuItem});
			this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
			this.EditToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
			this.EditToolStripMenuItem.Text = "Edit";
			//
			//TickToolStripMenuItem
			//
			this.TickToolStripMenuItem.Name = "TickToolStripMenuItem";
			this.TickToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
			this.TickToolStripMenuItem.Text = "Tick";
			//
			//ViewToolStripMenuItem
			//
			this.ViewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.SizeToolStripMenuItem, this.AIToolStripMenuItem, this.collisionToolStripMenuItem});
			this.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem";
			this.ViewToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
			this.ViewToolStripMenuItem.Text = "Project";
			//
			//SizeToolStripMenuItem
			//
			this.SizeToolStripMenuItem.Enabled = false;
			this.SizeToolStripMenuItem.Name = "SizeToolStripMenuItem";
			this.SizeToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
			this.SizeToolStripMenuItem.Text = "Properties";
			//
			//AIToolStripMenuItem
			//
			this.AIToolStripMenuItem.Enabled = false;
			this.AIToolStripMenuItem.Name = "AIToolStripMenuItem";
			this.AIToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
			this.AIToolStripMenuItem.Text = "AI";
			//
			//collisionToolStripMenuItem
			//
			this.collisionToolStripMenuItem.Enabled = false;
			this.collisionToolStripMenuItem.Name = "collisionToolStripMenuItem";
			this.collisionToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
			this.collisionToolStripMenuItem.Text = "Interactions";
			//
			//ProjectToolStripMenuItem
			//
			this.ProjectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.TopViewToolStripMenuItem, this.SideViewToolStripMenuItem, this.SideViewToolStripMenuItem1, this.ToolStripSeparator1, this.AdjustFocalPointToolStripMenuItem, this.FullScreenToolStripMenuItem});
			this.ProjectToolStripMenuItem.Name = "ProjectToolStripMenuItem";
			this.ProjectToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.ProjectToolStripMenuItem.Text = "View";
			//
			//TopViewToolStripMenuItem
			//
			this.TopViewToolStripMenuItem.Enabled = false;
			this.TopViewToolStripMenuItem.Name = "TopViewToolStripMenuItem";
			this.TopViewToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
			this.TopViewToolStripMenuItem.Text = "Top View (x,z)";
			//
			//SideViewToolStripMenuItem
			//
			this.SideViewToolStripMenuItem.Enabled = false;
			this.SideViewToolStripMenuItem.Name = "SideViewToolStripMenuItem";
			this.SideViewToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
			this.SideViewToolStripMenuItem.Text = "Side View (x,y)";
			//
			//SideViewToolStripMenuItem1
			//
			this.SideViewToolStripMenuItem1.Enabled = false;
			this.SideViewToolStripMenuItem1.Name = "SideViewToolStripMenuItem1";
			this.SideViewToolStripMenuItem1.Size = new System.Drawing.Size(185, 22);
			this.SideViewToolStripMenuItem1.Text = "Side View (z,y)";
			//
			//ToolStripSeparator1
			//
			this.ToolStripSeparator1.Name = "ToolStripSeparator1";
			this.ToolStripSeparator1.Size = new System.Drawing.Size(182, 6);
			//
			//AdjustFocalPointToolStripMenuItem
			//
			this.AdjustFocalPointToolStripMenuItem.Name = "AdjustFocalPointToolStripMenuItem";
			this.AdjustFocalPointToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
			this.AdjustFocalPointToolStripMenuItem.Text = "Adjust Depth of Field";
			//
			//FullScreenToolStripMenuItem
			//
			this.FullScreenToolStripMenuItem.Name = "FullScreenToolStripMenuItem";
			this.FullScreenToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
			this.FullScreenToolStripMenuItem.Text = "Full Screen";
			//
			//GraphToolStripMenuItem
			//
			this.GraphToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.DataSheetToolStripMenuItem});
			this.GraphToolStripMenuItem.Name = "GraphToolStripMenuItem";
			this.GraphToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
			this.GraphToolStripMenuItem.Text = "Data";
			//
			//DataSheetToolStripMenuItem
			//
			this.DataSheetToolStripMenuItem.Name = "DataSheetToolStripMenuItem";
			this.DataSheetToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
			this.DataSheetToolStripMenuItem.Text = "Data Sheet";
			//
			//HelpToolStripMenuItem
			//
			this.HelpToolStripMenuItem.BackColor = System.Drawing.Color.GreenYellow;
			this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
			this.HelpToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
			this.HelpToolStripMenuItem.Text = "Start";
			//
			//StopToolStripMenuItem
			//
			this.StopToolStripMenuItem.BackColor = System.Drawing.Color.Pink;
			this.StopToolStripMenuItem.Name = "StopToolStripMenuItem";
			this.StopToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
			this.StopToolStripMenuItem.Text = "Stop";
			//
			//Timerxy
			//
			this.Timerxy.Interval = 200;
			//
			//StatusStrip1
			//
			this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.ToolStripStatusLabel1, this.timelabel, this.ToolStripStatusLabel2, this.stoplabel, this.ToolStripStatusLabel4, this.speedbar, this.spacebar, this.viewlabel});
			this.StatusStrip1.Location = new System.Drawing.Point(0, 534);
			this.StatusStrip1.Name = "StatusStrip1";
			this.StatusStrip1.Size = new System.Drawing.Size(1215, 22);
			this.StatusStrip1.TabIndex = 11;
			this.StatusStrip1.Text = "StatusStrip1";
			//
			//ToolStripStatusLabel1
			//
			this.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
			this.ToolStripStatusLabel1.Size = new System.Drawing.Size(75, 17);
			this.ToolStripStatusLabel1.Text = "Current Tick:";
			//
			//timelabel
			//
			this.timelabel.Name = "timelabel";
			this.timelabel.Size = new System.Drawing.Size(13, 17);
			this.timelabel.Text = "0";
			//
			//ToolStripStatusLabel2
			//
			this.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2";
			this.ToolStripStatusLabel2.Size = new System.Drawing.Size(62, 17);
			this.ToolStripStatusLabel2.Text = "     Stop at:";
			//
			//stoplabel
			//
			this.stoplabel.Name = "stoplabel";
			this.stoplabel.Size = new System.Drawing.Size(31, 17);
			this.stoplabel.Text = "1000";
			//
			//ToolStripStatusLabel4
			//
			this.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4";
			this.ToolStripStatusLabel4.Size = new System.Drawing.Size(57, 17);
			this.ToolStripStatusLabel4.Text = "     Speed:";
			//
			//speedbar
			//
			this.speedbar.Name = "speedbar";
			this.speedbar.Size = new System.Drawing.Size(100, 16);
			//
			//spacebar
			//
			this.spacebar.Name = "spacebar";
			this.spacebar.Size = new System.Drawing.Size(860, 17);
			this.spacebar.Spring = true;
			//
			//viewlabel
			//
			this.viewlabel.Name = "viewlabel";
			this.viewlabel.Size = new System.Drawing.Size(0, 17);
			//
			//PictureBox1
			//
			this.PictureBox1.Anchor = (System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
			this.PictureBox1.Image = global::My.Resources.Resources.Cobweb_3D_2;
			this.PictureBox1.Location = new System.Drawing.Point(12, 27);
			this.PictureBox1.Name = "PictureBox1";
			this.PictureBox1.Size = new System.Drawing.Size(1191, 504);
			this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.PictureBox1.TabIndex = 1;
			this.PictureBox1.TabStop = false;
			//
			//SaveFileDialog1
			//
			this.SaveFileDialog1.Filter = "Excel Files(*.xlsx)|*.xls|All Files|*.*";
			//
			//SaveFilepro
			//
			this.SaveFilepro.Filter = "COBWEB 3D Files(*.C3d)|*.C3d|All Files|*.*";
			//
			//OpenFilepro
			//
			this.OpenFilepro.Filter = "COBWEB 3D Files(*.C3d)|*.C3d|All Files|*.*";
			//
			//Form1
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1215, 556);
			this.Controls.Add(this.PictureBox1);
			this.Controls.Add(this.StatusStrip1);
			this.Controls.Add(this.MenuStrip1);
			this.Icon = (System.Drawing.Icon) (resources.GetObject("$this.Icon"));
			this.MainMenuStrip = this.MenuStrip1;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "COBWEB 3D";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.MenuStrip1.ResumeLayout(false);
			this.MenuStrip1.PerformLayout();
			this.StatusStrip1.ResumeLayout(false);
			this.StatusStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize) this.PictureBox1).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
			
		}
		internal System.Windows.Forms.MenuStrip MenuStrip1;
		internal System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem EditToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem ViewToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem ProjectToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem TopViewToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem SideViewToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem SideViewToolStripMenuItem1;
		internal System.Windows.Forms.ToolStripMenuItem NewToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem OpenProjectToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem SaveProjectToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem LogDataToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem QuitToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem GraphToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
		internal System.Windows.Forms.PictureBox PictureBox1;
		internal System.Windows.Forms.ToolStripMenuItem AIToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem collisionToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem SizeToolStripMenuItem;
		internal System.Windows.Forms.Timer Timerxy;
		internal System.Windows.Forms.StatusStrip StatusStrip1;
		internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel1;
		internal System.Windows.Forms.ToolStripStatusLabel timelabel;
		internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel2;
		internal System.Windows.Forms.ToolStripStatusLabel stoplabel;
		internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel4;
		internal System.Windows.Forms.ToolStripProgressBar speedbar;
		internal System.Windows.Forms.ToolStripMenuItem StopToolStripMenuItem;
		internal System.Windows.Forms.ToolStripStatusLabel spacebar;
		internal System.Windows.Forms.ToolStripStatusLabel viewlabel;
		internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
		internal System.Windows.Forms.ToolStripMenuItem AdjustFocalPointToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem FullScreenToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem DataSheetToolStripMenuItem;
		internal System.Windows.Forms.SaveFileDialog SaveFileDialog1;
		internal System.Windows.Forms.SaveFileDialog SaveFilepro;
		internal System.Windows.Forms.ToolStripMenuItem TickToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem CreditToolStripMenuItem;
		internal System.Windows.Forms.OpenFileDialog OpenFilepro;
		
	}
	
}
