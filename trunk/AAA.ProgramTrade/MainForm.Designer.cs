namespace AAA.ProgramTrade
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.loginItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.catcherItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoTradeItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speedOrderItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chartItem = new System.Windows.Forms.ToolStripMenuItem();
            this.realtimeStrategyItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataItem = new System.Windows.Forms.ToolStripMenuItem();
            this.offlineDataItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calculateItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataMonitorItem = new System.Windows.Forms.ToolStripMenuItem();
            this.offlineDataFeedItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataDownloadItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportItem = new System.Windows.Forms.ToolStripMenuItem();
            this.performanceReportItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.newWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arrangeIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.loginStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ofdOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginItem,
            this.systemMenu,
            this.dataItem,
            this.reportItem,
            this.viewMenu,
            this.windowsMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.MdiWindowListItem = this.windowsMenu;
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(632, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // loginItem
            // 
            this.loginItem.Name = "loginItem";
            this.loginItem.Size = new System.Drawing.Size(77, 20);
            this.loginItem.Text = "登入(&Login)";
            this.loginItem.Click += new System.EventHandler(this.loginItem_Click);
            // 
            // systemMenu
            // 
            this.systemMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.catcherItem,
            this.scheduleItem,
            this.autoTradeItem,
            this.speedOrderItem,
            this.chartItem,
            this.realtimeStrategyItem,
            this.toolStripSeparator1,
            this.exitItem});
            this.systemMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.systemMenu.Name = "systemMenu";
            this.systemMenu.Size = new System.Drawing.Size(82, 20);
            this.systemMenu.Text = "系統(&System)";
            // 
            // catcherItem
            // 
            this.catcherItem.Name = "catcherItem";
            this.catcherItem.Size = new System.Drawing.Size(142, 22);
            this.catcherItem.Text = "訊號讀取器";
            this.catcherItem.Click += new System.EventHandler(this.catcherItem_Click);
            // 
            // scheduleItem
            // 
            this.scheduleItem.Name = "scheduleItem";
            this.scheduleItem.Size = new System.Drawing.Size(142, 22);
            this.scheduleItem.Text = "工作排程";
            this.scheduleItem.Click += new System.EventHandler(this.scheduleItem_Click);
            // 
            // autoTradeItem
            // 
            this.autoTradeItem.Name = "autoTradeItem";
            this.autoTradeItem.Size = new System.Drawing.Size(142, 22);
            this.autoTradeItem.Text = "API下單";
            this.autoTradeItem.Click += new System.EventHandler(this.autoTradeItem_Click);
            // 
            // speedOrderItem
            // 
            this.speedOrderItem.Name = "speedOrderItem";
            this.speedOrderItem.Size = new System.Drawing.Size(142, 22);
            this.speedOrderItem.Text = "智慧閃電下單";
            this.speedOrderItem.Click += new System.EventHandler(this.speedOrderItem_Click);
            // 
            // chartItem
            // 
            this.chartItem.Name = "chartItem";
            this.chartItem.Size = new System.Drawing.Size(142, 22);
            this.chartItem.Text = "走勢圖";
            this.chartItem.Click += new System.EventHandler(this.chartItem_Click);
            // 
            // realtimeStrategyItem
            // 
            this.realtimeStrategyItem.Name = "realtimeStrategyItem";
            this.realtimeStrategyItem.Size = new System.Drawing.Size(142, 22);
            this.realtimeStrategyItem.Text = "即時策略";
            this.realtimeStrategyItem.Click += new System.EventHandler(this.realtimeStrategyItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(139, 6);
            // 
            // exitItem
            // 
            this.exitItem.Name = "exitItem";
            this.exitItem.Size = new System.Drawing.Size(142, 22);
            this.exitItem.Text = "E&xit";
            this.exitItem.Click += new System.EventHandler(this.ExitToolsStripMenuItem_Click);
            // 
            // dataItem
            // 
            this.dataItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.offlineDataItem,
            this.calculateItem,
            this.dataMonitorItem,
            this.offlineDataFeedItem,
            this.dataDownloadItem});
            this.dataItem.Name = "dataItem";
            this.dataItem.Size = new System.Drawing.Size(70, 20);
            this.dataItem.Text = "資料(&Data)";
            // 
            // offlineDataItem
            // 
            this.offlineDataItem.Name = "offlineDataItem";
            this.offlineDataItem.Size = new System.Drawing.Size(142, 22);
            this.offlineDataItem.Text = "讀入離線資料";
            this.offlineDataItem.Click += new System.EventHandler(this.offlineDataItem_Click);
            // 
            // calculateItem
            // 
            this.calculateItem.Name = "calculateItem";
            this.calculateItem.Size = new System.Drawing.Size(142, 22);
            this.calculateItem.Text = "資料運算";
            this.calculateItem.Click += new System.EventHandler(this.calculateItem_Click);
            // 
            // dataMonitorItem
            // 
            this.dataMonitorItem.Name = "dataMonitorItem";
            this.dataMonitorItem.Size = new System.Drawing.Size(142, 22);
            this.dataMonitorItem.Text = "資料監控";
            this.dataMonitorItem.Click += new System.EventHandler(this.dataMonitorItem_Click);
            // 
            // offlineDataFeedItem
            // 
            this.offlineDataFeedItem.Name = "offlineDataFeedItem";
            this.offlineDataFeedItem.Size = new System.Drawing.Size(142, 22);
            this.offlineDataFeedItem.Text = "歷史資料重播";
            this.offlineDataFeedItem.Click += new System.EventHandler(this.offlineDataFeedItem_Click);
            // 
            // dataDownloadItem
            // 
            this.dataDownloadItem.Name = "dataDownloadItem";
            this.dataDownloadItem.Size = new System.Drawing.Size(142, 22);
            this.dataDownloadItem.Text = "歷史資料下載";
            this.dataDownloadItem.Click += new System.EventHandler(this.dataDownloadItem_Click);
            // 
            // reportItem
            // 
            this.reportItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.performanceReportItem});
            this.reportItem.Name = "reportItem";
            this.reportItem.Size = new System.Drawing.Size(81, 20);
            this.reportItem.Text = "報表(&Report)";
            // 
            // performanceReportItem
            // 
            this.performanceReportItem.Name = "performanceReportItem";
            this.performanceReportItem.Size = new System.Drawing.Size(118, 22);
            this.performanceReportItem.Text = "績效報表";
            this.performanceReportItem.Click += new System.EventHandler(this.performanceReportItem_Click);
            // 
            // viewMenu
            // 
            this.viewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBarToolStripMenuItem});
            this.viewMenu.Name = "viewMenu";
            this.viewMenu.Size = new System.Drawing.Size(73, 20);
            this.viewMenu.Text = "檢視(&View)";
            // 
            // statusBarToolStripMenuItem
            // 
            this.statusBarToolStripMenuItem.Checked = true;
            this.statusBarToolStripMenuItem.CheckOnClick = true;
            this.statusBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.statusBarToolStripMenuItem.Name = "statusBarToolStripMenuItem";
            this.statusBarToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.statusBarToolStripMenuItem.Text = "&Status Bar";
            // 
            // windowsMenu
            // 
            this.windowsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newWindowToolStripMenuItem,
            this.cascadeToolStripMenuItem,
            this.tileVerticalToolStripMenuItem,
            this.tileHorizontalToolStripMenuItem,
            this.closeAllToolStripMenuItem,
            this.arrangeIconsToolStripMenuItem});
            this.windowsMenu.Name = "windowsMenu";
            this.windowsMenu.Size = new System.Drawing.Size(93, 20);
            this.windowsMenu.Text = "視窗(&Windows)";
            // 
            // newWindowToolStripMenuItem
            // 
            this.newWindowToolStripMenuItem.Name = "newWindowToolStripMenuItem";
            this.newWindowToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.newWindowToolStripMenuItem.Text = "&New Window";
            this.newWindowToolStripMenuItem.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // cascadeToolStripMenuItem
            // 
            this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            this.cascadeToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.cascadeToolStripMenuItem.Text = "&Cascade";
            this.cascadeToolStripMenuItem.Click += new System.EventHandler(this.CascadeToolStripMenuItem_Click);
            // 
            // tileVerticalToolStripMenuItem
            // 
            this.tileVerticalToolStripMenuItem.Name = "tileVerticalToolStripMenuItem";
            this.tileVerticalToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.tileVerticalToolStripMenuItem.Text = "Tile &Vertical";
            this.tileVerticalToolStripMenuItem.Click += new System.EventHandler(this.TileVerticalToolStripMenuItem_Click);
            // 
            // tileHorizontalToolStripMenuItem
            // 
            this.tileHorizontalToolStripMenuItem.Name = "tileHorizontalToolStripMenuItem";
            this.tileHorizontalToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.tileHorizontalToolStripMenuItem.Text = "Tile &Horizontal";
            this.tileHorizontalToolStripMenuItem.Click += new System.EventHandler(this.TileHorizontalToolStripMenuItem_Click);
            // 
            // closeAllToolStripMenuItem
            // 
            this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.closeAllToolStripMenuItem.Text = "C&lose All";
            this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.CloseAllToolStripMenuItem_Click);
            // 
            // arrangeIconsToolStripMenuItem
            // 
            this.arrangeIconsToolStripMenuItem.Name = "arrangeIconsToolStripMenuItem";
            this.arrangeIconsToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.arrangeIconsToolStripMenuItem.Text = "&Arrange Icons";
            this.arrangeIconsToolStripMenuItem.Click += new System.EventHandler(this.ArrangeIconsToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.loginStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 396);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(632, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(32, 17);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // loginStatus
            // 
            this.loginStatus.Name = "loginStatus";
            this.loginStatus.Size = new System.Drawing.Size(41, 17);
            this.loginStatus.Text = "未連線";
            // 
            // ofdOpenFile
            // 
            this.ofdOpenFile.FileName = "openFileDialog1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 418);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem tileHorizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem systemMenu;
        private System.Windows.Forms.ToolStripMenuItem exitItem;
        private System.Windows.Forms.ToolStripMenuItem viewMenu;
        private System.Windows.Forms.ToolStripMenuItem statusBarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowsMenu;
        private System.Windows.Forms.ToolStripMenuItem newWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cascadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileVerticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arrangeIconsToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem catcherItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem autoTradeItem;
        private System.Windows.Forms.ToolStripStatusLabel loginStatus;
        private System.Windows.Forms.ToolStripMenuItem loginItem;
        private System.Windows.Forms.ToolStripMenuItem speedOrderItem;
        private System.Windows.Forms.ToolStripMenuItem dataItem;
        private System.Windows.Forms.ToolStripMenuItem offlineDataItem;
        private System.Windows.Forms.OpenFileDialog ofdOpenFile;
        private System.Windows.Forms.ToolStripMenuItem dataMonitorItem;
        private System.Windows.Forms.ToolStripMenuItem chartItem;
        private System.Windows.Forms.ToolStripMenuItem calculateItem;
        private System.Windows.Forms.ToolStripMenuItem reportItem;
        private System.Windows.Forms.ToolStripMenuItem performanceReportItem;
        private System.Windows.Forms.ToolStripMenuItem offlineDataFeedItem;
        private System.Windows.Forms.ToolStripMenuItem dataDownloadItem;
        private System.Windows.Forms.ToolStripMenuItem realtimeStrategyItem;
    }
}



