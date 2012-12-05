namespace AAA.ProgramTrade
{
    partial class ChartXForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDisplay = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cboSymbolId = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabChart = new System.Windows.Forms.TabControl();
            this.pnlChart = new System.Windows.Forms.TabPage();
            this.pnlData = new System.Windows.Forms.TabPage();
            this.cpChart = new AAA.Chart.Component.ChartPane();
            this.panel1.SuspendLayout();
            this.tabChart.SuspendLayout();
            this.pnlChart.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnDisplay);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.cboSymbolId);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(665, 47);
            this.panel1.TabIndex = 0;
            // 
            // btnDisplay
            // 
            this.btnDisplay.Location = new System.Drawing.Point(280, 10);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(75, 23);
            this.btnDisplay.TabIndex = 3;
            this.btnDisplay.Text = "顯示";
            this.btnDisplay.UseVisualStyleBackColor = true;
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(199, 10);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "更新商品";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cboSymbolId
            // 
            this.cboSymbolId.FormattingEnabled = true;
            this.cboSymbolId.Location = new System.Drawing.Point(72, 13);
            this.cboSymbolId.Name = "cboSymbolId";
            this.cboSymbolId.Size = new System.Drawing.Size(121, 20);
            this.cboSymbolId.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "商品名稱";
            // 
            // tabChart
            // 
            this.tabChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabChart.Controls.Add(this.pnlChart);
            this.tabChart.Controls.Add(this.pnlData);
            this.tabChart.Location = new System.Drawing.Point(12, 65);
            this.tabChart.Name = "tabChart";
            this.tabChart.SelectedIndex = 0;
            this.tabChart.Size = new System.Drawing.Size(665, 382);
            this.tabChart.TabIndex = 1;
            // 
            // pnlChart
            // 
            this.pnlChart.Controls.Add(this.cpChart);
            this.pnlChart.Location = new System.Drawing.Point(4, 21);
            this.pnlChart.Name = "pnlChart";
            this.pnlChart.Padding = new System.Windows.Forms.Padding(3);
            this.pnlChart.Size = new System.Drawing.Size(657, 357);
            this.pnlChart.TabIndex = 2;
            this.pnlChart.Text = "走勢圖";
            this.pnlChart.UseVisualStyleBackColor = true;
            // 
            // pnlData
            // 
            this.pnlData.Location = new System.Drawing.Point(4, 21);
            this.pnlData.Name = "pnlData";
            this.pnlData.Padding = new System.Windows.Forms.Padding(3);
            this.pnlData.Size = new System.Drawing.Size(657, 357);
            this.pnlData.TabIndex = 1;
            this.pnlData.Text = "資料";
            this.pnlData.UseVisualStyleBackColor = true;
            // 
            // cpChart
            // 
            this.cpChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cpChart.Location = new System.Drawing.Point(6, 6);
            this.cpChart.Name = "cpChart";
            this.cpChart.Size = new System.Drawing.Size(645, 345);
            this.cpChart.TabIndex = 0;
            // 
            // ChartXForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 450);
            this.Controls.Add(this.tabChart);
            this.Controls.Add(this.panel1);
            this.Name = "ChartXForm";
            this.Text = "走勢圖";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabChart.ResumeLayout(false);
            this.pnlChart.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabChart;
        private System.Windows.Forms.TabPage pnlData;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox cboSymbolId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage pnlChart;
        private System.Windows.Forms.Button btnDisplay;
        private AAA.Chart.Component.ChartPane cpChart;
    }
}