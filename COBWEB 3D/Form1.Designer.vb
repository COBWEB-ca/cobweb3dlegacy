<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenProjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveProjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QuitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TickToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddAgentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InRangeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InSpecificPositionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SizeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AIToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.collisionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CatalysisToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AbioticFactorsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AbioticFactorsEnergyChangeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AbioticFactorsNonrandomMovementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EconomicZonesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GeneticsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AutomaticRunsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.XZTopViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.XYSideViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ZYSideViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.AdjustFocalPointToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FullScreenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GraphToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataSheetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InteractionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PopulationGraphToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataOnExchangesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TickButtonToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StopToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timerxy = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tslblCurrentTickLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslblCurrentTick = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslblStopLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslblStopTicks = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslblSpeedLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsprgSpeed = New System.Windows.Forms.ToolStripProgressBar()
        Me.spacebar = New System.Windows.Forms.ToolStripStatusLabel()
        Me.viewlabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsprgStatus = New System.Windows.Forms.ToolStripProgressBar()
        Me.SaveFileDialogLogData = New System.Windows.Forms.SaveFileDialog()
        Me.SaveFilepro = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFilepro = New System.Windows.Forms.OpenFileDialog()
        Me.picRenderFrame = New System.Windows.Forms.PictureBox()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.picRenderFrame, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ViewToolStripMenuItem, Me.ProjectToolStripMenuItem, Me.GraphToolStripMenuItem, Me.TickButtonToolStripMenuItem, Me.StartToolStripMenuItem, Me.StopToolStripMenuItem, Me.ResetToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1215, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.OpenProjectToolStripMenuItem, Me.SaveProjectToolStripMenuItem, Me.LogDataToolStripMenuItem, Me.CreditToolStripMenuItem, Me.AboutToolStripMenuItem, Me.QuitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.NewToolStripMenuItem.Text = "New Project"
        '
        'OpenProjectToolStripMenuItem
        '
        Me.OpenProjectToolStripMenuItem.Name = "OpenProjectToolStripMenuItem"
        Me.OpenProjectToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.OpenProjectToolStripMenuItem.Text = "Open Project"
        '
        'SaveProjectToolStripMenuItem
        '
        Me.SaveProjectToolStripMenuItem.Enabled = False
        Me.SaveProjectToolStripMenuItem.Name = "SaveProjectToolStripMenuItem"
        Me.SaveProjectToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.SaveProjectToolStripMenuItem.Text = "Save Project"
        '
        'LogDataToolStripMenuItem
        '
        Me.LogDataToolStripMenuItem.Enabled = False
        Me.LogDataToolStripMenuItem.Name = "LogDataToolStripMenuItem"
        Me.LogDataToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.LogDataToolStripMenuItem.Text = "Log Data"
        '
        'CreditToolStripMenuItem
        '
        Me.CreditToolStripMenuItem.Name = "CreditToolStripMenuItem"
        Me.CreditToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.CreditToolStripMenuItem.Text = "Credit"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'QuitToolStripMenuItem
        '
        Me.QuitToolStripMenuItem.Name = "QuitToolStripMenuItem"
        Me.QuitToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.QuitToolStripMenuItem.Text = "Quit"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TickToolStripMenuItem, Me.AddAgentsToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'TickToolStripMenuItem
        '
        Me.TickToolStripMenuItem.Name = "TickToolStripMenuItem"
        Me.TickToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.TickToolStripMenuItem.Text = "Tick"
        '
        'AddAgentsToolStripMenuItem
        '
        Me.AddAgentsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InRangeToolStripMenuItem, Me.InSpecificPositionsToolStripMenuItem})
        Me.AddAgentsToolStripMenuItem.Enabled = False
        Me.AddAgentsToolStripMenuItem.Name = "AddAgentsToolStripMenuItem"
        Me.AddAgentsToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.AddAgentsToolStripMenuItem.Text = "Add Agents"
        '
        'InRangeToolStripMenuItem
        '
        Me.InRangeToolStripMenuItem.Name = "InRangeToolStripMenuItem"
        Me.InRangeToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.InRangeToolStripMenuItem.Text = "In a Range"
        '
        'InSpecificPositionsToolStripMenuItem
        '
        Me.InSpecificPositionsToolStripMenuItem.Name = "InSpecificPositionsToolStripMenuItem"
        Me.InSpecificPositionsToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.InSpecificPositionsToolStripMenuItem.Text = "In Specific Positions"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SizeToolStripMenuItem, Me.AIToolStripMenuItem, Me.collisionToolStripMenuItem, Me.CatalysisToolStripMenuItem, Me.AbioticFactorsToolStripMenuItem, Me.GeneticsToolStripMenuItem, Me.AutomaticRunsToolStripMenuItem})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(56, 20)
        Me.ViewToolStripMenuItem.Text = "Project"
        '
        'SizeToolStripMenuItem
        '
        Me.SizeToolStripMenuItem.Enabled = False
        Me.SizeToolStripMenuItem.Name = "SizeToolStripMenuItem"
        Me.SizeToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.SizeToolStripMenuItem.Text = "Initial Properties"
        '
        'AIToolStripMenuItem
        '
        Me.AIToolStripMenuItem.Enabled = False
        Me.AIToolStripMenuItem.Name = "AIToolStripMenuItem"
        Me.AIToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.AIToolStripMenuItem.Text = "AI"
        '
        'collisionToolStripMenuItem
        '
        Me.collisionToolStripMenuItem.Enabled = False
        Me.collisionToolStripMenuItem.Name = "collisionToolStripMenuItem"
        Me.collisionToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.collisionToolStripMenuItem.Text = "Interactions"
        '
        'CatalysisToolStripMenuItem
        '
        Me.CatalysisToolStripMenuItem.Enabled = False
        Me.CatalysisToolStripMenuItem.Name = "CatalysisToolStripMenuItem"
        Me.CatalysisToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.CatalysisToolStripMenuItem.Text = "Catalysis"
        '
        'AbioticFactorsToolStripMenuItem
        '
        Me.AbioticFactorsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AbioticFactorsEnergyChangeToolStripMenuItem, Me.AbioticFactorsNonrandomMovementToolStripMenuItem, Me.EconomicZonesToolStripMenuItem})
        Me.AbioticFactorsToolStripMenuItem.Enabled = False
        Me.AbioticFactorsToolStripMenuItem.Name = "AbioticFactorsToolStripMenuItem"
        Me.AbioticFactorsToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.AbioticFactorsToolStripMenuItem.Text = "Abiotic Factors"
        '
        'AbioticFactorsEnergyChangeToolStripMenuItem
        '
        Me.AbioticFactorsEnergyChangeToolStripMenuItem.Name = "AbioticFactorsEnergyChangeToolStripMenuItem"
        Me.AbioticFactorsEnergyChangeToolStripMenuItem.Size = New System.Drawing.Size(287, 22)
        Me.AbioticFactorsEnergyChangeToolStripMenuItem.Text = "Abiotic Factors Energy Change"
        '
        'AbioticFactorsNonrandomMovementToolStripMenuItem
        '
        Me.AbioticFactorsNonrandomMovementToolStripMenuItem.Name = "AbioticFactorsNonrandomMovementToolStripMenuItem"
        Me.AbioticFactorsNonrandomMovementToolStripMenuItem.Size = New System.Drawing.Size(287, 22)
        Me.AbioticFactorsNonrandomMovementToolStripMenuItem.Text = "Abiotic Factors Non-random Movement"
        '
        'EconomicZonesToolStripMenuItem
        '
        Me.EconomicZonesToolStripMenuItem.Name = "EconomicZonesToolStripMenuItem"
        Me.EconomicZonesToolStripMenuItem.Size = New System.Drawing.Size(287, 22)
        Me.EconomicZonesToolStripMenuItem.Text = "Economic Zones"
        '
        'GeneticsToolStripMenuItem
        '
        Me.GeneticsToolStripMenuItem.Enabled = False
        Me.GeneticsToolStripMenuItem.Name = "GeneticsToolStripMenuItem"
        Me.GeneticsToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.GeneticsToolStripMenuItem.Text = "Genetics"
        '
        'AutomaticRunsToolStripMenuItem
        '
        Me.AutomaticRunsToolStripMenuItem.Name = "AutomaticRunsToolStripMenuItem"
        Me.AutomaticRunsToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.AutomaticRunsToolStripMenuItem.Text = "Automation"
        '
        'ProjectToolStripMenuItem
        '
        Me.ProjectToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.XZTopViewToolStripMenuItem, Me.XYSideViewToolStripMenuItem, Me.ZYSideViewToolStripMenuItem, Me.ToolStripSeparator1, Me.AdjustFocalPointToolStripMenuItem, Me.FullScreenToolStripMenuItem})
        Me.ProjectToolStripMenuItem.Name = "ProjectToolStripMenuItem"
        Me.ProjectToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.ProjectToolStripMenuItem.Text = "View"
        '
        'XZTopViewToolStripMenuItem
        '
        Me.XZTopViewToolStripMenuItem.Enabled = False
        Me.XZTopViewToolStripMenuItem.Name = "XZTopViewToolStripMenuItem"
        Me.XZTopViewToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.XZTopViewToolStripMenuItem.Text = "Top View (x,z)"
        '
        'XYSideViewToolStripMenuItem
        '
        Me.XYSideViewToolStripMenuItem.Enabled = False
        Me.XYSideViewToolStripMenuItem.Name = "XYSideViewToolStripMenuItem"
        Me.XYSideViewToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.XYSideViewToolStripMenuItem.Text = "Side View (x,y)"
        '
        'ZYSideViewToolStripMenuItem
        '
        Me.ZYSideViewToolStripMenuItem.Enabled = False
        Me.ZYSideViewToolStripMenuItem.Name = "ZYSideViewToolStripMenuItem"
        Me.ZYSideViewToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.ZYSideViewToolStripMenuItem.Text = "Side View (z,y)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(182, 6)
        '
        'AdjustFocalPointToolStripMenuItem
        '
        Me.AdjustFocalPointToolStripMenuItem.Name = "AdjustFocalPointToolStripMenuItem"
        Me.AdjustFocalPointToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.AdjustFocalPointToolStripMenuItem.Text = "Adjust Depth of Field"
        '
        'FullScreenToolStripMenuItem
        '
        Me.FullScreenToolStripMenuItem.Name = "FullScreenToolStripMenuItem"
        Me.FullScreenToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.FullScreenToolStripMenuItem.Text = "Full Screen"
        '
        'GraphToolStripMenuItem
        '
        Me.GraphToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DataSheetToolStripMenuItem, Me.InteractionsToolStripMenuItem, Me.PopulationGraphToolStripMenuItem, Me.DataOnExchangesToolStripMenuItem})
        Me.GraphToolStripMenuItem.Name = "GraphToolStripMenuItem"
        Me.GraphToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.GraphToolStripMenuItem.Text = "Data"
        '
        'DataSheetToolStripMenuItem
        '
        Me.DataSheetToolStripMenuItem.Name = "DataSheetToolStripMenuItem"
        Me.DataSheetToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.DataSheetToolStripMenuItem.Text = "Data Sheet"
        '
        'InteractionsToolStripMenuItem
        '
        Me.InteractionsToolStripMenuItem.Name = "InteractionsToolStripMenuItem"
        Me.InteractionsToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.InteractionsToolStripMenuItem.Text = "Interactions"
        '
        'PopulationGraphToolStripMenuItem
        '
        Me.PopulationGraphToolStripMenuItem.Name = "PopulationGraphToolStripMenuItem"
        Me.PopulationGraphToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.PopulationGraphToolStripMenuItem.Text = "Population Graph"
        '
        'DataOnExchangesToolStripMenuItem
        '
        Me.DataOnExchangesToolStripMenuItem.Name = "DataOnExchangesToolStripMenuItem"
        Me.DataOnExchangesToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.DataOnExchangesToolStripMenuItem.Text = "Data on Exchanges"
        '
        'TickButtonToolStripMenuItem
        '
        Me.TickButtonToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TickButtonToolStripMenuItem.Name = "TickButtonToolStripMenuItem"
        Me.TickButtonToolStripMenuItem.Size = New System.Drawing.Size(41, 20)
        Me.TickButtonToolStripMenuItem.Text = "Tick"
        '
        'StartToolStripMenuItem
        '
        Me.StartToolStripMenuItem.BackColor = System.Drawing.Color.GreenYellow
        Me.StartToolStripMenuItem.Name = "StartToolStripMenuItem"
        Me.StartToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.StartToolStripMenuItem.Text = "Start"
        '
        'StopToolStripMenuItem
        '
        Me.StopToolStripMenuItem.BackColor = System.Drawing.Color.Pink
        Me.StopToolStripMenuItem.Name = "StopToolStripMenuItem"
        Me.StopToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.StopToolStripMenuItem.Text = "Stop"
        '
        'ResetToolStripMenuItem
        '
        Me.ResetToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ResetToolStripMenuItem.Name = "ResetToolStripMenuItem"
        Me.ResetToolStripMenuItem.Size = New System.Drawing.Size(47, 20)
        Me.ResetToolStripMenuItem.Text = "Reset"
        '
        'Timerxy
        '
        Me.Timerxy.Interval = 200
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslblCurrentTickLabel, Me.tslblCurrentTick, Me.tslblStopLabel, Me.tslblStopTicks, Me.tslblSpeedLabel, Me.tsprgSpeed, Me.spacebar, Me.viewlabel, Me.tslblStatus, Me.tsprgStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 534)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1215, 22)
        Me.StatusStrip1.TabIndex = 11
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tslblCurrentTickLabel
        '
        Me.tslblCurrentTickLabel.Name = "tslblCurrentTickLabel"
        Me.tslblCurrentTickLabel.Size = New System.Drawing.Size(75, 17)
        Me.tslblCurrentTickLabel.Text = "Current Tick:"
        '
        'tslblCurrentTick
        '
        Me.tslblCurrentTick.Name = "tslblCurrentTick"
        Me.tslblCurrentTick.Size = New System.Drawing.Size(13, 17)
        Me.tslblCurrentTick.Text = "0"
        '
        'tslblStopLabel
        '
        Me.tslblStopLabel.Name = "tslblStopLabel"
        Me.tslblStopLabel.Size = New System.Drawing.Size(62, 17)
        Me.tslblStopLabel.Text = "     Stop at:"
        '
        'tslblStopTicks
        '
        Me.tslblStopTicks.Name = "tslblStopTicks"
        Me.tslblStopTicks.Size = New System.Drawing.Size(31, 17)
        Me.tslblStopTicks.Text = "1000"
        '
        'tslblSpeedLabel
        '
        Me.tslblSpeedLabel.Name = "tslblSpeedLabel"
        Me.tslblSpeedLabel.Size = New System.Drawing.Size(57, 17)
        Me.tslblSpeedLabel.Text = "     Speed:"
        '
        'tsprgSpeed
        '
        Me.tsprgSpeed.Name = "tsprgSpeed"
        Me.tsprgSpeed.Size = New System.Drawing.Size(100, 16)
        '
        'spacebar
        '
        Me.spacebar.Name = "spacebar"
        Me.spacebar.Size = New System.Drawing.Size(668, 17)
        Me.spacebar.Spring = True
        '
        'viewlabel
        '
        Me.viewlabel.Name = "viewlabel"
        Me.viewlabel.Size = New System.Drawing.Size(0, 17)
        '
        'tslblStatus
        '
        Me.tslblStatus.Name = "tslblStatus"
        Me.tslblStatus.Size = New System.Drawing.Size(59, 17)
        Me.tslblStatus.Text = "Loading..."
        Me.tslblStatus.Visible = False
        '
        'tsprgStatus
        '
        Me.tsprgStatus.Name = "tsprgStatus"
        Me.tsprgStatus.Size = New System.Drawing.Size(100, 16)
        Me.tsprgStatus.Visible = False
        '
        'SaveFileDialogLogData
        '
        Me.SaveFileDialogLogData.Filter = "Excel Files(*.xlsx)|*.xls|All Files|*.*"
        '
        'SaveFilepro
        '
        Me.SaveFilepro.Filter = "COBWEB 3D Files(*.C3d)|*.C3d|All Files|*.*"
        '
        'OpenFilepro
        '
        Me.OpenFilepro.Filter = "COBWEB 3D Files(*.C3d)|*.C3d|All Files|*.*"
        '
        'picRenderFrame
        '
        Me.picRenderFrame.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picRenderFrame.Image = Global.COBWEB_3D.My.Resources.Resources.Cobweb_3D_2
        Me.picRenderFrame.Location = New System.Drawing.Point(12, 27)
        Me.picRenderFrame.Name = "picRenderFrame"
        Me.picRenderFrame.Size = New System.Drawing.Size(1191, 504)
        Me.picRenderFrame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picRenderFrame.TabIndex = 1
        Me.picRenderFrame.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1215, 556)
        Me.Controls.Add(Me.picRenderFrame)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "COBWEB 3D"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.picRenderFrame, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProjectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents XZTopViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents XYSideViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ZYSideViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenProjectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveProjectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LogDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents QuitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GraphToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StartToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents picRenderFrame As System.Windows.Forms.PictureBox
    Friend WithEvents AIToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents collisionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SizeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timerxy As System.Windows.Forms.Timer
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents tslblCurrentTickLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tslblCurrentTick As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tslblStopLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tslblStopTicks As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tslblSpeedLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsprgSpeed As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents StopToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents spacebar As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents viewlabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AdjustFocalPointToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FullScreenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataSheetToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveFileDialogLogData As System.Windows.Forms.SaveFileDialog
    Friend WithEvents SaveFilepro As System.Windows.Forms.SaveFileDialog
    Friend WithEvents TickToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CreditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFilepro As System.Windows.Forms.OpenFileDialog
    Friend WithEvents InteractionsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PopulationGraphToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddAgentsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CatalysisToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AbioticFactorsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents tslblStatus As ToolStripStatusLabel
    Friend WithEvents tsprgStatus As ToolStripProgressBar
    Friend WithEvents InRangeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InSpecificPositionsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DataOnExchangesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AbioticFactorsEnergyChangeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AbioticFactorsNonrandomMovementToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EconomicZonesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GeneticsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AutomaticRunsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ResetToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TickButtonToolStripMenuItem As ToolStripMenuItem
End Class
