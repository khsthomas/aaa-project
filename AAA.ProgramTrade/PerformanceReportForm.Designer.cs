namespace AAA.ProgramTrade
{
    partial class PerformanceReportForm
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
            this.tabReport = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnPerformance = new System.Windows.Forms.Button();
            this.tblSignalHistory = new System.Windows.Forms.DataGridView();
            this.cboBaseSymbolId = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tblParameter = new System.Windows.Forms.DataGridView();
            this.txtStrategyName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtStrategyPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ofdDllPath = new System.Windows.Forms.OpenFileDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.dtStartTime = new System.Windows.Forms.DateTimePicker();
            this.dtEndTime = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.tabReport.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblSignalHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblParameter)).BeginInit();
            this.SuspendLayout();
            // 
            // tabReport
            // 
            this.tabReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabReport.Controls.Add(this.tabPage1);
            this.tabReport.Controls.Add(this.tabPage2);
            this.tabReport.Location = new System.Drawing.Point(3, 8);
            this.tabReport.Name = "tabReport";
            this.tabReport.SelectedIndex = 0;
            this.tabReport.Size = new System.Drawing.Size(641, 409);
            this.tabReport.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dtEndTime);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.dtStartTime);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.btnPerformance);
            this.tabPage1.Controls.Add(this.tblSignalHistory);
            this.tabPage1.Controls.Add(this.cboBaseSymbolId);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.tblParameter);
            this.tabPage1.Controls.Add(this.txtStrategyName);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.btnBrowse);
            this.tabPage1.Controls.Add(this.txtStrategyPath);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(633, 384);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "策略載入";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnPerformance
            // 
            this.btnPerformance.Location = new System.Drawing.Point(478, 9);
            this.btnPerformance.Name = "btnPerformance";
            this.btnPerformance.Size = new System.Drawing.Size(75, 23);
            this.btnPerformance.TabIndex = 10;
            this.btnPerformance.Text = "驗證";
            this.btnPerformance.UseVisualStyleBackColor = true;
            this.btnPerformance.Click += new System.EventHandler(this.btnPerformance_Click);
            // 
            // tblSignalHistory
            // 
            this.tblSignalHistory.AllowUserToAddRows = false;
            this.tblSignalHistory.AllowUserToDeleteRows = false;
            this.tblSignalHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tblSignalHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblSignalHistory.Location = new System.Drawing.Point(17, 233);
            this.tblSignalHistory.Name = "tblSignalHistory";
            this.tblSignalHistory.RowHeadersVisible = false;
            this.tblSignalHistory.RowTemplate.Height = 24;
            this.tblSignalHistory.Size = new System.Drawing.Size(600, 145);
            this.tblSignalHistory.TabIndex = 9;
            // 
            // cboBaseSymbolId
            // 
            this.cboBaseSymbolId.FormattingEnabled = true;
            this.cboBaseSymbolId.Location = new System.Drawing.Point(74, 69);
            this.cboBaseSymbolId.Name = "cboBaseSymbolId";
            this.cboBaseSymbolId.Size = new System.Drawing.Size(317, 20);
            this.cboBaseSymbolId.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "基礎商品";
            // 
            // tblParameter
            // 
            this.tblParameter.AllowUserToAddRows = false;
            this.tblParameter.AllowUserToDeleteRows = false;
            this.tblParameter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tblParameter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblParameter.Location = new System.Drawing.Point(17, 127);
            this.tblParameter.Name = "tblParameter";
            this.tblParameter.RowHeadersVisible = false;
            this.tblParameter.RowTemplate.Height = 24;
            this.tblParameter.Size = new System.Drawing.Size(600, 100);
            this.tblParameter.TabIndex = 5;
            // 
            // txtStrategyName
            // 
            this.txtStrategyName.Location = new System.Drawing.Point(74, 37);
            this.txtStrategyName.Name = "txtStrategyName";
            this.txtStrategyName.ReadOnly = true;
            this.txtStrategyName.Size = new System.Drawing.Size(317, 22);
            this.txtStrategyName.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "策略名稱";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(397, 9);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "瀏覽";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtStrategyPath
            // 
            this.txtStrategyPath.Location = new System.Drawing.Point(74, 9);
            this.txtStrategyPath.Name = "txtStrategyPath";
            this.txtStrategyPath.Size = new System.Drawing.Size(317, 22);
            this.txtStrategyPath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "策略路徑";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(633, 384);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ofdDllPath
            // 
            this.ofdDllPath.FileName = "openFileDialog1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "開始時間";
            // 
            // dtStartTime
            // 
            this.dtStartTime.Location = new System.Drawing.Point(74, 99);
            this.dtStartTime.Name = "dtStartTime";
            this.dtStartTime.Size = new System.Drawing.Size(117, 22);
            this.dtStartTime.TabIndex = 12;
            // 
            // dtEndTime
            // 
            this.dtEndTime.Location = new System.Drawing.Point(258, 99);
            this.dtEndTime.Name = "dtEndTime";
            this.dtEndTime.Size = new System.Drawing.Size(117, 22);
            this.dtEndTime.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(203, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "結束時間";
            // 
            // PerformanceReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 422);
            this.Controls.Add(this.tabReport);
            this.Name = "PerformanceReportForm";
            this.Text = "績效報表";
            this.tabReport.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblSignalHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblParameter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabReport;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtStrategyPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStrategyName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView tblParameter;
        private System.Windows.Forms.DataGridView tblSignalHistory;
        private System.Windows.Forms.ComboBox cboBaseSymbolId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog ofdDllPath;
        private System.Windows.Forms.Button btnPerformance;
        private System.Windows.Forms.DateTimePicker dtEndTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtStartTime;
        private System.Windows.Forms.Label label4;
    }
}