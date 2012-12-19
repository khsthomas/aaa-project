namespace AAA.TradingSystem
{
    partial class DaySummaryForm
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
            this.btnGenerate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtStartDate = new System.Windows.Forms.TextBox();
            this.txtEndDate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabReports = new System.Windows.Forms.TabControl();
            this.pnlTechSummary = new System.Windows.Forms.TabPage();
            this.tblTechSummary = new System.Windows.Forms.DataGridView();
            this.btnExcel = new System.Windows.Forms.Button();
            this.tabReports.SuspendLayout();
            this.pnlTechSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblTechSummary)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(373, 9);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 0;
            this.btnGenerate.Text = "報表";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "開始日期";
            // 
            // txtStartDate
            // 
            this.txtStartDate.Location = new System.Drawing.Point(71, 9);
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.Size = new System.Drawing.Size(115, 22);
            this.txtStartDate.TabIndex = 2;
            // 
            // txtEndDate
            // 
            this.txtEndDate.Location = new System.Drawing.Point(252, 9);
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Size = new System.Drawing.Size(115, 22);
            this.txtEndDate.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(193, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "結束日期";
            // 
            // tabReports
            // 
            this.tabReports.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabReports.Controls.Add(this.pnlTechSummary);
            this.tabReports.Location = new System.Drawing.Point(12, 37);
            this.tabReports.Name = "tabReports";
            this.tabReports.SelectedIndex = 0;
            this.tabReports.Size = new System.Drawing.Size(708, 332);
            this.tabReports.TabIndex = 5;
            // 
            // pnlTechSummary
            // 
            this.pnlTechSummary.Controls.Add(this.tblTechSummary);
            this.pnlTechSummary.Location = new System.Drawing.Point(4, 21);
            this.pnlTechSummary.Name = "pnlTechSummary";
            this.pnlTechSummary.Padding = new System.Windows.Forms.Padding(3);
            this.pnlTechSummary.Size = new System.Drawing.Size(700, 307);
            this.pnlTechSummary.TabIndex = 0;
            this.pnlTechSummary.Text = "技術指標";
            this.pnlTechSummary.UseVisualStyleBackColor = true;
            // 
            // tblTechSummary
            // 
            this.tblTechSummary.AllowUserToAddRows = false;
            this.tblTechSummary.AllowUserToDeleteRows = false;
            this.tblTechSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tblTechSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblTechSummary.Location = new System.Drawing.Point(3, 6);
            this.tblTechSummary.Name = "tblTechSummary";
            this.tblTechSummary.ReadOnly = true;
            this.tblTechSummary.RowHeadersVisible = false;
            this.tblTechSummary.RowTemplate.Height = 24;
            this.tblTechSummary.Size = new System.Drawing.Size(691, 295);
            this.tblTechSummary.TabIndex = 0;
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(454, 9);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(75, 23);
            this.btnExcel.TabIndex = 6;
            this.btnExcel.Text = "Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // DaySummaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 374);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.tabReports);
            this.Controls.Add(this.txtEndDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtStartDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGenerate);
            this.Name = "DaySummaryForm";
            this.Text = "日報表";
            this.tabReports.ResumeLayout(false);
            this.pnlTechSummary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblTechSummary)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStartDate;
        private System.Windows.Forms.TextBox txtEndDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabReports;
        private System.Windows.Forms.TabPage pnlTechSummary;
        private System.Windows.Forms.DataGridView tblTechSummary;
        private System.Windows.Forms.Button btnExcel;
    }
}