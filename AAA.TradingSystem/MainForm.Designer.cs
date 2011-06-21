namespace AAA.TradingSystem
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
            this.menuItemMarketProfile = new System.Windows.Forms.ToolStripMenuItem();
            this.dataManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGetter = new System.Windows.Forms.ToolStripMenuItem();
            this.stockCriteria = new System.Windows.Forms.ToolStripMenuItem();
            this.filterStock = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MenuItemJournal = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tradingMonitor,
            this.dataManagement,
            this.stockCriteria});
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
            this.menuItemMarketProfile,
            this.MenuItemJournal});
            this.tradingMonitor.Name = "tradingMonitor";
            this.tradingMonitor.Size = new System.Drawing.Size(41, 20);
            this.tradingMonitor.Text = "行情";
            // 
            // menuItemKBar
            // 
            this.menuItemKBar.Name = "menuItemKBar";
            this.menuItemKBar.Size = new System.Drawing.Size(137, 22);
            this.menuItemKBar.Text = "K線圖";
            this.menuItemKBar.Click += new System.EventHandler(this.menuItemKBar_Click);
            // 
            // menuItemMarketProfile
            // 
            this.menuItemMarketProfile.Name = "menuItemMarketProfile";
            this.menuItemMarketProfile.Size = new System.Drawing.Size(137, 22);
            this.menuItemMarketProfile.Text = "Market Profile";
            this.menuItemMarketProfile.Visible = false;
            this.menuItemMarketProfile.Click += new System.EventHandler(this.menuItemMarketProfile_Click);
            // 
            // dataManagement
            // 
            this.dataManagement.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataGetter});
            this.dataManagement.Name = "dataManagement";
            this.dataManagement.Size = new System.Drawing.Size(41, 20);
            this.dataManagement.Text = "資料";
            this.dataManagement.Visible = false;
            // 
            // dataGetter
            // 
            this.dataGetter.Name = "dataGetter";
            this.dataGetter.Size = new System.Drawing.Size(152, 22);
            this.dataGetter.Text = "資料抓取";
            this.dataGetter.Click += new System.EventHandler(this.dataGetter_Click);
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
            this.filterStock.Size = new System.Drawing.Size(152, 22);
            this.filterStock.Text = "條件選股";
            this.filterStock.Click += new System.EventHandler(this.filterStock_Click);
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
            // MenuItemJournal
            // 
            this.MenuItemJournal.Name = "MenuItemJournal";
            this.MenuItemJournal.Size = new System.Drawing.Size(152, 22);
            this.MenuItemJournal.Text = "Trading Journal";
            this.MenuItemJournal.Click += new System.EventHandler(this.MenuItemJournal_Click);
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
    }
}



