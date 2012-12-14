namespace AAA.ProgramTrade
{
    partial class DailyReportForm
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
            this.tabFunction = new System.Windows.Forms.TabControl();
            this.pnlPosition = new System.Windows.Forms.TabPage();
            this.tblOpenPosition = new System.Windows.Forms.DataGridView();
            this.pnlEquity = new System.Windows.Forms.TabPage();
            this.tblEquity = new System.Windows.Forms.DataGridView();
            this.pnlTheory = new System.Windows.Forms.TabPage();
            this.tblTheory = new System.Windows.Forms.DataGridView();
            this.pnlDealReport = new System.Windows.Forms.TabPage();
            this.tblDeal = new System.Windows.Forms.DataGridView();
            this.pnlEven = new System.Windows.Forms.TabPage();
            this.tblEven = new System.Windows.Forms.DataGridView();
            this.pnlIndex = new System.Windows.Forms.TabPage();
            this.tblIndex = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dpEndDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudBackDays = new System.Windows.Forms.NumericUpDown();
            this.btnQuery = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.tabFunction.SuspendLayout();
            this.pnlPosition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblOpenPosition)).BeginInit();
            this.pnlEquity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblEquity)).BeginInit();
            this.pnlTheory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblTheory)).BeginInit();
            this.pnlDealReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblDeal)).BeginInit();
            this.pnlEven.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblEven)).BeginInit();
            this.pnlIndex.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBackDays)).BeginInit();
            this.SuspendLayout();
            // 
            // tabFunction
            // 
            this.tabFunction.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabFunction.Controls.Add(this.pnlPosition);
            this.tabFunction.Controls.Add(this.pnlEquity);
            this.tabFunction.Controls.Add(this.pnlTheory);
            this.tabFunction.Controls.Add(this.pnlDealReport);
            this.tabFunction.Controls.Add(this.pnlEven);
            this.tabFunction.Controls.Add(this.pnlIndex);
            this.tabFunction.Location = new System.Drawing.Point(2, 63);
            this.tabFunction.Name = "tabFunction";
            this.tabFunction.SelectedIndex = 0;
            this.tabFunction.Size = new System.Drawing.Size(640, 372);
            this.tabFunction.TabIndex = 0;
            // 
            // pnlPosition
            // 
            this.pnlPosition.Controls.Add(this.tblOpenPosition);
            this.pnlPosition.Location = new System.Drawing.Point(4, 21);
            this.pnlPosition.Name = "pnlPosition";
            this.pnlPosition.Size = new System.Drawing.Size(632, 347);
            this.pnlPosition.TabIndex = 5;
            this.pnlPosition.Text = "未平倉明細";
            this.pnlPosition.UseVisualStyleBackColor = true;
            // 
            // tblOpenPosition
            // 
            this.tblOpenPosition.AllowUserToAddRows = false;
            this.tblOpenPosition.AllowUserToDeleteRows = false;
            this.tblOpenPosition.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.tblOpenPosition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblOpenPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblOpenPosition.Location = new System.Drawing.Point(0, 0);
            this.tblOpenPosition.Name = "tblOpenPosition";
            this.tblOpenPosition.RowHeadersVisible = false;
            this.tblOpenPosition.RowTemplate.Height = 24;
            this.tblOpenPosition.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblOpenPosition.Size = new System.Drawing.Size(632, 347);
            this.tblOpenPosition.TabIndex = 0;
            // 
            // pnlEquity
            // 
            this.pnlEquity.Controls.Add(this.tblEquity);
            this.pnlEquity.Location = new System.Drawing.Point(4, 21);
            this.pnlEquity.Name = "pnlEquity";
            this.pnlEquity.Padding = new System.Windows.Forms.Padding(3);
            this.pnlEquity.Size = new System.Drawing.Size(632, 347);
            this.pnlEquity.TabIndex = 0;
            this.pnlEquity.Text = "今日權益數";
            this.pnlEquity.UseVisualStyleBackColor = true;
            // 
            // tblEquity
            // 
            this.tblEquity.AllowUserToAddRows = false;
            this.tblEquity.AllowUserToDeleteRows = false;
            this.tblEquity.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.tblEquity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblEquity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblEquity.Location = new System.Drawing.Point(3, 3);
            this.tblEquity.Name = "tblEquity";
            this.tblEquity.RowHeadersVisible = false;
            this.tblEquity.RowTemplate.Height = 24;
            this.tblEquity.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblEquity.Size = new System.Drawing.Size(626, 341);
            this.tblEquity.TabIndex = 1;
            // 
            // pnlTheory
            // 
            this.pnlTheory.Controls.Add(this.tblTheory);
            this.pnlTheory.Location = new System.Drawing.Point(4, 21);
            this.pnlTheory.Name = "pnlTheory";
            this.pnlTheory.Padding = new System.Windows.Forms.Padding(3);
            this.pnlTheory.Size = new System.Drawing.Size(632, 347);
            this.pnlTheory.TabIndex = 1;
            this.pnlTheory.Text = "選擇權理論價";
            this.pnlTheory.UseVisualStyleBackColor = true;
            // 
            // tblTheory
            // 
            this.tblTheory.AllowUserToAddRows = false;
            this.tblTheory.AllowUserToDeleteRows = false;
            this.tblTheory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.tblTheory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblTheory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblTheory.Location = new System.Drawing.Point(3, 3);
            this.tblTheory.Name = "tblTheory";
            this.tblTheory.RowHeadersVisible = false;
            this.tblTheory.RowTemplate.Height = 24;
            this.tblTheory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblTheory.Size = new System.Drawing.Size(626, 341);
            this.tblTheory.TabIndex = 1;
            // 
            // pnlDealReport
            // 
            this.pnlDealReport.Controls.Add(this.tblDeal);
            this.pnlDealReport.Location = new System.Drawing.Point(4, 21);
            this.pnlDealReport.Name = "pnlDealReport";
            this.pnlDealReport.Size = new System.Drawing.Size(632, 347);
            this.pnlDealReport.TabIndex = 2;
            this.pnlDealReport.Text = "成交明細";
            this.pnlDealReport.UseVisualStyleBackColor = true;
            // 
            // tblDeal
            // 
            this.tblDeal.AllowUserToAddRows = false;
            this.tblDeal.AllowUserToDeleteRows = false;
            this.tblDeal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.tblDeal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblDeal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblDeal.Location = new System.Drawing.Point(0, 0);
            this.tblDeal.Name = "tblDeal";
            this.tblDeal.RowHeadersVisible = false;
            this.tblDeal.RowTemplate.Height = 24;
            this.tblDeal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblDeal.Size = new System.Drawing.Size(632, 347);
            this.tblDeal.TabIndex = 1;
            // 
            // pnlEven
            // 
            this.pnlEven.Controls.Add(this.tblEven);
            this.pnlEven.Location = new System.Drawing.Point(4, 21);
            this.pnlEven.Name = "pnlEven";
            this.pnlEven.Size = new System.Drawing.Size(632, 347);
            this.pnlEven.TabIndex = 3;
            this.pnlEven.Text = "沖銷明細";
            this.pnlEven.UseVisualStyleBackColor = true;
            // 
            // tblEven
            // 
            this.tblEven.AllowUserToAddRows = false;
            this.tblEven.AllowUserToDeleteRows = false;
            this.tblEven.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.tblEven.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblEven.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblEven.Location = new System.Drawing.Point(0, 0);
            this.tblEven.Name = "tblEven";
            this.tblEven.RowHeadersVisible = false;
            this.tblEven.RowTemplate.Height = 24;
            this.tblEven.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblEven.Size = new System.Drawing.Size(632, 347);
            this.tblEven.TabIndex = 1;
            // 
            // pnlIndex
            // 
            this.pnlIndex.Controls.Add(this.tblIndex);
            this.pnlIndex.Location = new System.Drawing.Point(4, 21);
            this.pnlIndex.Name = "pnlIndex";
            this.pnlIndex.Size = new System.Drawing.Size(632, 347);
            this.pnlIndex.TabIndex = 4;
            this.pnlIndex.Text = "大盤資訊";
            this.pnlIndex.UseVisualStyleBackColor = true;
            // 
            // tblIndex
            // 
            this.tblIndex.AllowUserToAddRows = false;
            this.tblIndex.AllowUserToDeleteRows = false;
            this.tblIndex.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.tblIndex.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblIndex.Location = new System.Drawing.Point(0, 0);
            this.tblIndex.Name = "tblIndex";
            this.tblIndex.RowHeadersVisible = false;
            this.tblIndex.RowTemplate.Height = 24;
            this.tblIndex.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblIndex.Size = new System.Drawing.Size(632, 347);
            this.tblIndex.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "開始日期";
            // 
            // dpStartDate
            // 
            this.dpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpStartDate.Location = new System.Drawing.Point(63, 3);
            this.dpStartDate.Name = "dpStartDate";
            this.dpStartDate.Size = new System.Drawing.Size(112, 22);
            this.dpStartDate.TabIndex = 2;
            // 
            // dpEndDate
            // 
            this.dpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpEndDate.Location = new System.Drawing.Point(242, 3);
            this.dpEndDate.Name = "dpEndDate";
            this.dpEndDate.Size = new System.Drawing.Size(112, 22);
            this.dpEndDate.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(183, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "結束日期";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "指數回推天數";
            // 
            // nudBackDays
            // 
            this.nudBackDays.Location = new System.Drawing.Point(87, 35);
            this.nudBackDays.Name = "nudBackDays";
            this.nudBackDays.Size = new System.Drawing.Size(88, 22);
            this.nudBackDays.TabIndex = 6;
            this.nudBackDays.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(369, 2);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 7;
            this.btnQuery.Text = "查詢";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(450, 3);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 8;
            this.btnExport.Text = "匯出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // DailyReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 437);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.nudBackDays);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dpEndDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dpStartDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabFunction);
            this.Name = "DailyReportForm";
            this.Text = "庫存日報表";
            this.tabFunction.ResumeLayout(false);
            this.pnlPosition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblOpenPosition)).EndInit();
            this.pnlEquity.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblEquity)).EndInit();
            this.pnlTheory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblTheory)).EndInit();
            this.pnlDealReport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblDeal)).EndInit();
            this.pnlEven.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblEven)).EndInit();
            this.pnlIndex.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBackDays)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabFunction;
        private System.Windows.Forms.TabPage pnlEquity;
        private System.Windows.Forms.TabPage pnlTheory;
        private System.Windows.Forms.TabPage pnlDealReport;
        private System.Windows.Forms.TabPage pnlEven;
        private System.Windows.Forms.TabPage pnlIndex;
        private System.Windows.Forms.TabPage pnlPosition;
        private System.Windows.Forms.DataGridView tblOpenPosition;
        private System.Windows.Forms.DataGridView tblEquity;
        private System.Windows.Forms.DataGridView tblTheory;
        private System.Windows.Forms.DataGridView tblDeal;
        private System.Windows.Forms.DataGridView tblEven;
        private System.Windows.Forms.DataGridView tblIndex;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dpStartDate;
        private System.Windows.Forms.DateTimePicker dpEndDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudBackDays;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Button btnExport;
    }
}