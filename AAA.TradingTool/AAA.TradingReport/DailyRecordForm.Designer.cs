namespace AAA.TradingReport
{
    partial class DailyRecordForm
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
            this.btnDisplay = new System.Windows.Forms.Button();
            this.tabFunction = new System.Windows.Forms.TabControl();
            this.pnlOrderRecord = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProfit = new System.Windows.Forms.TextBox();
            this.tblReport = new System.Windows.Forms.DataGridView();
            this.tblOrderRecord = new System.Windows.Forms.DataGridView();
            this.tabFunction.SuspendLayout();
            this.pnlOrderRecord.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblOrderRecord)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDisplay
            // 
            this.btnDisplay.Location = new System.Drawing.Point(522, 11);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(75, 23);
            this.btnDisplay.TabIndex = 0;
            this.btnDisplay.Text = "顯示";
            this.btnDisplay.UseVisualStyleBackColor = true;
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // tabFunction
            // 
            this.tabFunction.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabFunction.Controls.Add(this.pnlOrderRecord);
            this.tabFunction.Controls.Add(this.tabPage2);
            this.tabFunction.Location = new System.Drawing.Point(12, 41);
            this.tabFunction.Name = "tabFunction";
            this.tabFunction.SelectedIndex = 0;
            this.tabFunction.Size = new System.Drawing.Size(657, 406);
            this.tabFunction.TabIndex = 1;
            // 
            // pnlOrderRecord
            // 
            this.pnlOrderRecord.Controls.Add(this.tblOrderRecord);
            this.pnlOrderRecord.Location = new System.Drawing.Point(4, 21);
            this.pnlOrderRecord.Name = "pnlOrderRecord";
            this.pnlOrderRecord.Padding = new System.Windows.Forms.Padding(3);
            this.pnlOrderRecord.Size = new System.Drawing.Size(649, 381);
            this.pnlOrderRecord.TabIndex = 0;
            this.pnlOrderRecord.Text = "當日成交明細";
            this.pnlOrderRecord.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.txtProfit);
            this.tabPage2.Controls.Add(this.tblReport);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(649, 381);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "歷史權益數";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "yyyyMMdd";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(405, 13);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(106, 22);
            this.dtpEndDate.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(346, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "結束日期";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "yyyyMMdd";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(231, 12);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(106, 22);
            this.dtpStartDate.TabIndex = 7;
            // 
            // txtAccount
            // 
            this.txtAccount.Location = new System.Drawing.Point(10, 12);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.ReadOnly = true;
            this.txtAccount.Size = new System.Drawing.Size(156, 22);
            this.txtAccount.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(172, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "開始日期";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(430, 360);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "淨損益";
            // 
            // txtProfit
            // 
            this.txtProfit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProfit.Location = new System.Drawing.Point(487, 350);
            this.txtProfit.Name = "txtProfit";
            this.txtProfit.ReadOnly = true;
            this.txtProfit.Size = new System.Drawing.Size(156, 22);
            this.txtProfit.TabIndex = 13;
            // 
            // tblReport
            // 
            this.tblReport.AllowUserToAddRows = false;
            this.tblReport.AllowUserToDeleteRows = false;
            this.tblReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tblReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblReport.Location = new System.Drawing.Point(6, 9);
            this.tblReport.Name = "tblReport";
            this.tblReport.ReadOnly = true;
            this.tblReport.RowHeadersVisible = false;
            this.tblReport.RowTemplate.Height = 24;
            this.tblReport.Size = new System.Drawing.Size(637, 335);
            this.tblReport.TabIndex = 12;
            // 
            // tblOrderRecord
            // 
            this.tblOrderRecord.AllowUserToAddRows = false;
            this.tblOrderRecord.AllowUserToDeleteRows = false;
            this.tblOrderRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tblOrderRecord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblOrderRecord.Location = new System.Drawing.Point(6, 6);
            this.tblOrderRecord.Name = "tblOrderRecord";
            this.tblOrderRecord.ReadOnly = true;
            this.tblOrderRecord.RowHeadersVisible = false;
            this.tblOrderRecord.RowTemplate.Height = 24;
            this.tblOrderRecord.Size = new System.Drawing.Size(637, 335);
            this.tblOrderRecord.TabIndex = 13;
            // 
            // DailyRecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 448);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.txtAccount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabFunction);
            this.Controls.Add(this.btnDisplay);
            this.Name = "DailyRecordForm";
            this.Text = "每日匯整";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DailyRecordForm_FormClosing);
            this.tabFunction.ResumeLayout(false);
            this.pnlOrderRecord.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblOrderRecord)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDisplay;
        private System.Windows.Forms.TabControl tabFunction;
        private System.Windows.Forms.TabPage pnlOrderRecord;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView tblOrderRecord;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtProfit;
        private System.Windows.Forms.DataGridView tblReport;
    }
}