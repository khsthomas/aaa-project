namespace AAA.TradingSystem
{
    partial class DataQueryForm
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
            this.gbCriteria = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSymbolId = new System.Windows.Forms.TextBox();
            this.txtStartDate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEndDate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnQuery = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.pnlDailyData = new System.Windows.Forms.TabPage();
            this.pnlIndicator = new System.Windows.Forms.TabPage();
            this.pnlJoin = new System.Windows.Forms.TabPage();
            this.tblDailyData = new System.Windows.Forms.DataGridView();
            this.tblIndicator = new System.Windows.Forms.DataGridView();
            this.tblJoin = new System.Windows.Forms.DataGridView();
            this.gbCriteria.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.pnlDailyData.SuspendLayout();
            this.pnlIndicator.SuspendLayout();
            this.pnlJoin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblDailyData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblIndicator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblJoin)).BeginInit();
            this.SuspendLayout();
            // 
            // gbCriteria
            // 
            this.gbCriteria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCriteria.Controls.Add(this.btnQuery);
            this.gbCriteria.Controls.Add(this.txtEndDate);
            this.gbCriteria.Controls.Add(this.label3);
            this.gbCriteria.Controls.Add(this.txtStartDate);
            this.gbCriteria.Controls.Add(this.label2);
            this.gbCriteria.Controls.Add(this.txtSymbolId);
            this.gbCriteria.Controls.Add(this.label1);
            this.gbCriteria.Location = new System.Drawing.Point(12, 12);
            this.gbCriteria.Name = "gbCriteria";
            this.gbCriteria.Size = new System.Drawing.Size(564, 78);
            this.gbCriteria.TabIndex = 0;
            this.gbCriteria.TabStop = false;
            this.gbCriteria.Text = "查詢條件";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "股票代碼";
            // 
            // txtSymbolId
            // 
            this.txtSymbolId.Location = new System.Drawing.Point(65, 15);
            this.txtSymbolId.Name = "txtSymbolId";
            this.txtSymbolId.Size = new System.Drawing.Size(94, 22);
            this.txtSymbolId.TabIndex = 1;
            this.txtSymbolId.Text = "2881";
            // 
            // txtStartDate
            // 
            this.txtStartDate.Location = new System.Drawing.Point(224, 15);
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.Size = new System.Drawing.Size(94, 22);
            this.txtStartDate.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "起始日期";
            // 
            // txtEndDate
            // 
            this.txtEndDate.Location = new System.Drawing.Point(383, 15);
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Size = new System.Drawing.Size(94, 22);
            this.txtEndDate.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(324, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "結束日期";
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(84, 49);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 6;
            this.btnQuery.Text = "查詢";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.pnlDailyData);
            this.tabControl1.Controls.Add(this.pnlIndicator);
            this.tabControl1.Controls.Add(this.pnlJoin);
            this.tabControl1.Location = new System.Drawing.Point(12, 105);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(564, 286);
            this.tabControl1.TabIndex = 1;
            // 
            // pnlDailyData
            // 
            this.pnlDailyData.Controls.Add(this.tblDailyData);
            this.pnlDailyData.Location = new System.Drawing.Point(4, 21);
            this.pnlDailyData.Name = "pnlDailyData";
            this.pnlDailyData.Padding = new System.Windows.Forms.Padding(3);
            this.pnlDailyData.Size = new System.Drawing.Size(556, 261);
            this.pnlDailyData.TabIndex = 0;
            this.pnlDailyData.Text = "日資料";
            this.pnlDailyData.UseVisualStyleBackColor = true;
            // 
            // pnlIndicator
            // 
            this.pnlIndicator.Controls.Add(this.tblIndicator);
            this.pnlIndicator.Location = new System.Drawing.Point(4, 21);
            this.pnlIndicator.Name = "pnlIndicator";
            this.pnlIndicator.Padding = new System.Windows.Forms.Padding(3);
            this.pnlIndicator.Size = new System.Drawing.Size(556, 261);
            this.pnlIndicator.TabIndex = 1;
            this.pnlIndicator.Text = "技術指標";
            this.pnlIndicator.UseVisualStyleBackColor = true;
            // 
            // pnlJoin
            // 
            this.pnlJoin.Controls.Add(this.tblJoin);
            this.pnlJoin.Location = new System.Drawing.Point(4, 21);
            this.pnlJoin.Name = "pnlJoin";
            this.pnlJoin.Padding = new System.Windows.Forms.Padding(3);
            this.pnlJoin.Size = new System.Drawing.Size(556, 261);
            this.pnlJoin.TabIndex = 2;
            this.pnlJoin.Text = "綜合查詢";
            this.pnlJoin.UseVisualStyleBackColor = true;
            // 
            // tblDailyData
            // 
            this.tblDailyData.AllowUserToAddRows = false;
            this.tblDailyData.AllowUserToDeleteRows = false;
            this.tblDailyData.AllowUserToResizeRows = false;
            this.tblDailyData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblDailyData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblDailyData.Location = new System.Drawing.Point(3, 3);
            this.tblDailyData.MultiSelect = false;
            this.tblDailyData.Name = "tblDailyData";
            this.tblDailyData.ReadOnly = true;
            this.tblDailyData.RowHeadersVisible = false;
            this.tblDailyData.RowTemplate.Height = 24;
            this.tblDailyData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblDailyData.Size = new System.Drawing.Size(550, 255);
            this.tblDailyData.TabIndex = 0;
            // 
            // tblIndicator
            // 
            this.tblIndicator.AllowUserToAddRows = false;
            this.tblIndicator.AllowUserToDeleteRows = false;
            this.tblIndicator.AllowUserToResizeRows = false;
            this.tblIndicator.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblIndicator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblIndicator.Location = new System.Drawing.Point(3, 3);
            this.tblIndicator.MultiSelect = false;
            this.tblIndicator.Name = "tblIndicator";
            this.tblIndicator.ReadOnly = true;
            this.tblIndicator.RowHeadersVisible = false;
            this.tblIndicator.RowTemplate.Height = 24;
            this.tblIndicator.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblIndicator.Size = new System.Drawing.Size(550, 255);
            this.tblIndicator.TabIndex = 1;
            // 
            // tblJoin
            // 
            this.tblJoin.AllowUserToAddRows = false;
            this.tblJoin.AllowUserToDeleteRows = false;
            this.tblJoin.AllowUserToResizeRows = false;
            this.tblJoin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblJoin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblJoin.Location = new System.Drawing.Point(3, 3);
            this.tblJoin.MultiSelect = false;
            this.tblJoin.Name = "tblJoin";
            this.tblJoin.ReadOnly = true;
            this.tblJoin.RowHeadersVisible = false;
            this.tblJoin.RowTemplate.Height = 24;
            this.tblJoin.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblJoin.Size = new System.Drawing.Size(550, 255);
            this.tblJoin.TabIndex = 1;
            // 
            // DataQueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 403);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.gbCriteria);
            this.Name = "DataQueryForm";
            this.Text = "資料查詢";
            this.gbCriteria.ResumeLayout(false);
            this.gbCriteria.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.pnlDailyData.ResumeLayout(false);
            this.pnlIndicator.ResumeLayout(false);
            this.pnlJoin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblDailyData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblIndicator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblJoin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCriteria;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.TextBox txtEndDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStartDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSymbolId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage pnlDailyData;
        private System.Windows.Forms.TabPage pnlIndicator;
        private System.Windows.Forms.DataGridView tblDailyData;
        private System.Windows.Forms.TabPage pnlJoin;
        private System.Windows.Forms.DataGridView tblIndicator;
        private System.Windows.Forms.DataGridView tblJoin;
    }
}