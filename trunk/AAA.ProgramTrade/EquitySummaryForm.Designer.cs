namespace AAA.ProgramTrade
{
    partial class EquitySummaryForm
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
            this.tabEquity = new System.Windows.Forms.TabControl();
            this.pnlOpenInterest = new System.Windows.Forms.TabPage();
            this.pnlDealReport = new System.Windows.Forms.TabPage();
            this.tblOpenInterest = new System.Windows.Forms.DataGridView();
            this.tblDealReport = new System.Windows.Forms.DataGridView();
            this.tabEquity.SuspendLayout();
            this.pnlOpenInterest.SuspendLayout();
            this.pnlDealReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblOpenInterest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblDealReport)).BeginInit();
            this.SuspendLayout();
            // 
            // tabEquity
            // 
            this.tabEquity.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabEquity.Controls.Add(this.pnlOpenInterest);
            this.tabEquity.Controls.Add(this.pnlDealReport);
            this.tabEquity.Location = new System.Drawing.Point(3, 2);
            this.tabEquity.Name = "tabEquity";
            this.tabEquity.SelectedIndex = 0;
            this.tabEquity.Size = new System.Drawing.Size(615, 383);
            this.tabEquity.TabIndex = 0;
            // 
            // pnlOpenInterest
            // 
            this.pnlOpenInterest.Controls.Add(this.tblOpenInterest);
            this.pnlOpenInterest.Location = new System.Drawing.Point(4, 21);
            this.pnlOpenInterest.Name = "pnlOpenInterest";
            this.pnlOpenInterest.Padding = new System.Windows.Forms.Padding(3);
            this.pnlOpenInterest.Size = new System.Drawing.Size(607, 358);
            this.pnlOpenInterest.TabIndex = 0;
            this.pnlOpenInterest.Text = "未平倉損益";
            this.pnlOpenInterest.UseVisualStyleBackColor = true;
            // 
            // pnlDealReport
            // 
            this.pnlDealReport.Controls.Add(this.tblDealReport);
            this.pnlDealReport.Location = new System.Drawing.Point(4, 21);
            this.pnlDealReport.Name = "pnlDealReport";
            this.pnlDealReport.Padding = new System.Windows.Forms.Padding(3);
            this.pnlDealReport.Size = new System.Drawing.Size(607, 358);
            this.pnlDealReport.TabIndex = 1;
            this.pnlDealReport.Text = "成交回報列表";
            this.pnlDealReport.UseVisualStyleBackColor = true;
            // 
            // tblOpenInterest
            // 
            this.tblOpenInterest.AllowUserToAddRows = false;
            this.tblOpenInterest.AllowUserToDeleteRows = false;
            this.tblOpenInterest.AllowUserToResizeRows = false;
            this.tblOpenInterest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblOpenInterest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblOpenInterest.Location = new System.Drawing.Point(3, 3);
            this.tblOpenInterest.MultiSelect = false;
            this.tblOpenInterest.Name = "tblOpenInterest";
            this.tblOpenInterest.ReadOnly = true;
            this.tblOpenInterest.RowHeadersVisible = false;
            this.tblOpenInterest.RowTemplate.Height = 24;
            this.tblOpenInterest.Size = new System.Drawing.Size(601, 352);
            this.tblOpenInterest.TabIndex = 4;
            // 
            // tblDealReport
            // 
            this.tblDealReport.AllowUserToAddRows = false;
            this.tblDealReport.AllowUserToDeleteRows = false;
            this.tblDealReport.AllowUserToResizeRows = false;
            this.tblDealReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblDealReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblDealReport.Location = new System.Drawing.Point(3, 3);
            this.tblDealReport.MultiSelect = false;
            this.tblDealReport.Name = "tblDealReport";
            this.tblDealReport.ReadOnly = true;
            this.tblDealReport.RowHeadersVisible = false;
            this.tblDealReport.RowTemplate.Height = 24;
            this.tblDealReport.Size = new System.Drawing.Size(601, 352);
            this.tblDealReport.TabIndex = 4;
            // 
            // EquitySummaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 388);
            this.Controls.Add(this.tabEquity);
            this.Name = "EquitySummaryForm";
            this.Text = "帳務列表";
            this.tabEquity.ResumeLayout(false);
            this.pnlOpenInterest.ResumeLayout(false);
            this.pnlDealReport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblOpenInterest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblDealReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabEquity;
        private System.Windows.Forms.TabPage pnlOpenInterest;
        private System.Windows.Forms.TabPage pnlDealReport;
        private System.Windows.Forms.DataGridView tblOpenInterest;
        private System.Windows.Forms.DataGridView tblDealReport;
    }
}