﻿namespace AAA.TradingSystem
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.tradingMonitor = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemKBar = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemHappyZone = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemMarketProfile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemJournal = new System.Windows.Forms.ToolStripMenuItem();
            this.dataManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGetter = new System.Windows.Forms.ToolStripMenuItem();
            this.basicDataGetter = new System.Windows.Forms.ToolStripMenuItem();
            this.dataTransfer = new System.Windows.Forms.ToolStripMenuItem();
            this.dataQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.dataReport = new System.Windows.Forms.ToolStripMenuItem();
            this.dataExport = new System.Windows.Forms.ToolStripMenuItem();
            this.stockCriteria = new System.Windows.Forms.ToolStripMenuItem();
            this.filterStock = new System.Windows.Forms.ToolStripMenuItem();
            this.userDefine = new System.Windows.Forms.ToolStripMenuItem();
            this.userDefineSymbol = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tradingMonitor,
            this.dataManagement,
            this.stockCriteria,
            this.userDefine});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(632, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // tradingMonitor
            // 
            this.tradingMonitor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemKBar,
            this.menuItemHappyZone,
            this.menuItemMarketProfile,
            this.MenuItemJournal});
            this.tradingMonitor.Name = "tradingMonitor";
            this.tradingMonitor.Size = new System.Drawing.Size(41, 20);
            this.tradingMonitor.Text = "行情";
            // 
            // menuItemKBar
            // 
            this.menuItemKBar.Name = "menuItemKBar";
            this.menuItemKBar.Size = new System.Drawing.Size(152, 22);
            this.menuItemKBar.Text = "K線圖";
            this.menuItemKBar.Visible = false;
            this.menuItemKBar.Click += new System.EventHandler(this.menuItemKBar_Click);
            // 
            // menuItemHappyZone
            // 
            this.menuItemHappyZone.Name = "menuItemHappyZone";
            this.menuItemHappyZone.Size = new System.Drawing.Size(152, 22);
            this.menuItemHappyZone.Text = "HappyZone 監控";
            this.menuItemHappyZone.Click += new System.EventHandler(this.menuItemHappyZone_Click);
            // 
            // menuItemMarketProfile
            // 
            this.menuItemMarketProfile.Name = "menuItemMarketProfile";
            this.menuItemMarketProfile.Size = new System.Drawing.Size(152, 22);
            this.menuItemMarketProfile.Text = "Market Profile";
            this.menuItemMarketProfile.Visible = false;
            this.menuItemMarketProfile.Click += new System.EventHandler(this.menuItemMarketProfile_Click);
            // 
            // MenuItemJournal
            // 
            this.MenuItemJournal.Name = "MenuItemJournal";
            this.MenuItemJournal.Size = new System.Drawing.Size(152, 22);
            this.MenuItemJournal.Text = "Trading Journal";
            this.MenuItemJournal.Visible = false;
            // 
            // dataManagement
            // 
            this.dataManagement.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataGetter,
            this.basicDataGetter,
            this.dataTransfer,
            this.dataQuery,
            this.dataReport,
            this.dataExport});
            this.dataManagement.Name = "dataManagement";
            this.dataManagement.Size = new System.Drawing.Size(41, 20);
            this.dataManagement.Text = "資料";
            // 
            // dataGetter
            // 
            this.dataGetter.Name = "dataGetter";
            this.dataGetter.Size = new System.Drawing.Size(142, 22);
            this.dataGetter.Text = "資料抓取";
            this.dataGetter.Click += new System.EventHandler(this.dataGetter_Click);
            // 
            // basicDataGetter
            // 
            this.basicDataGetter.Name = "basicDataGetter";
            this.basicDataGetter.Size = new System.Drawing.Size(142, 22);
            this.basicDataGetter.Text = "基本資料匯入";
            this.basicDataGetter.Visible = false;
            this.basicDataGetter.Click += new System.EventHandler(this.basicDataGetter_Click);
            // 
            // dataTransfer
            // 
            this.dataTransfer.Name = "dataTransfer";
            this.dataTransfer.Size = new System.Drawing.Size(142, 22);
            this.dataTransfer.Text = "資料轉換";
            this.dataTransfer.Visible = false;
            this.dataTransfer.Click += new System.EventHandler(this.dataTransfer_Click);
            // 
            // dataQuery
            // 
            this.dataQuery.Name = "dataQuery";
            this.dataQuery.Size = new System.Drawing.Size(142, 22);
            this.dataQuery.Text = "資料查詢";
            this.dataQuery.Visible = false;
            this.dataQuery.Click += new System.EventHandler(this.dataQuery_Click);
            // 
            // dataReport
            // 
            this.dataReport.Name = "dataReport";
            this.dataReport.Size = new System.Drawing.Size(142, 22);
            this.dataReport.Text = "整合報表";
            this.dataReport.Click += new System.EventHandler(this.dataReport_Click);
            // 
            // dataExport
            // 
            this.dataExport.Name = "dataExport";
            this.dataExport.Size = new System.Drawing.Size(142, 22);
            this.dataExport.Text = "匯出Excel";
            this.dataExport.Click += new System.EventHandler(this.dataExport_Click);
            // 
            // stockCriteria
            // 
            this.stockCriteria.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filterStock});
            this.stockCriteria.Name = "stockCriteria";
            this.stockCriteria.Size = new System.Drawing.Size(41, 20);
            this.stockCriteria.Text = "選股";
            this.stockCriteria.Visible = false;
            // 
            // filterStock
            // 
            this.filterStock.Name = "filterStock";
            this.filterStock.Size = new System.Drawing.Size(118, 22);
            this.filterStock.Text = "條件選股";
            this.filterStock.Click += new System.EventHandler(this.filterStock_Click);
            // 
            // userDefine
            // 
            this.userDefine.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userDefineSymbol});
            this.userDefine.Name = "userDefine";
            this.userDefine.Size = new System.Drawing.Size(41, 20);
            this.userDefine.Text = "設定";
            // 
            // userDefineSymbol
            // 
            this.userDefineSymbol.Name = "userDefineSymbol";
            this.userDefineSymbol.Size = new System.Drawing.Size(130, 22);
            this.userDefineSymbol.Text = "自選股設定";
            this.userDefineSymbol.Click += new System.EventHandler(this.userDefineSymbol_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
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
            this.Text = "金融投資決策系統";
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
        private System.Windows.Forms.ToolStripMenuItem tradingMonitor;
        private System.Windows.Forms.ToolStripMenuItem menuItemKBar;
        private System.Windows.Forms.ToolStripMenuItem menuItemMarketProfile;
        private System.Windows.Forms.ToolStripMenuItem dataManagement;
        private System.Windows.Forms.ToolStripMenuItem dataGetter;
        private System.Windows.Forms.ToolStripMenuItem stockCriteria;
        private System.Windows.Forms.ToolStripMenuItem filterStock;
        private System.Windows.Forms.ToolStripMenuItem MenuItemJournal;
        private System.Windows.Forms.ToolStripMenuItem userDefine;
        private System.Windows.Forms.ToolStripMenuItem userDefineSymbol;
        private System.Windows.Forms.ToolStripMenuItem dataTransfer;
        private System.Windows.Forms.ToolStripMenuItem dataQuery;
        private System.Windows.Forms.ToolStripMenuItem basicDataGetter;
        private System.Windows.Forms.ToolStripMenuItem dataReport;
        private System.Windows.Forms.ToolStripMenuItem dataExport;
        private System.Windows.Forms.ToolStripMenuItem menuItemHappyZone;
    }
}



