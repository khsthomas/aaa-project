namespace AAA.TradingSystem
{
    partial class ExcelExportForm
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
            this.txtEndDate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStartDate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTemplateFile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOutputPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSaveConfig = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cboGroupId = new System.Windows.Forms.ComboBox();
            this.txtSymbolId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtWorksheetName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtHeaderRowCount = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtEndDate
            // 
            this.txtEndDate.Location = new System.Drawing.Point(255, 3);
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Size = new System.Drawing.Size(115, 22);
            this.txtEndDate.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(196, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "結束日期";
            // 
            // txtStartDate
            // 
            this.txtStartDate.Location = new System.Drawing.Point(74, 3);
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.Size = new System.Drawing.Size(115, 22);
            this.txtStartDate.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "開始日期";
            // 
            // txtTemplateFile
            // 
            this.txtTemplateFile.Location = new System.Drawing.Point(74, 86);
            this.txtTemplateFile.Name = "txtTemplateFile";
            this.txtTemplateFile.Size = new System.Drawing.Size(408, 22);
            this.txtTemplateFile.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "範本檔";
            // 
            // txtOutputPath
            // 
            this.txtOutputPath.Location = new System.Drawing.Point(74, 114);
            this.txtOutputPath.Name = "txtOutputPath";
            this.txtOutputPath.Size = new System.Drawing.Size(408, 22);
            this.txtOutputPath.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "輸出目錄";
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.Location = new System.Drawing.Point(153, 140);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(75, 23);
            this.btnSaveConfig.TabIndex = 13;
            this.btnSaveConfig.Text = "儲存設定";
            this.btnSaveConfig.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(277, 140);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 14;
            this.btnExport.Text = "匯出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "群組名稱";
            // 
            // cboGroupId
            // 
            this.cboGroupId.FormattingEnabled = true;
            this.cboGroupId.Location = new System.Drawing.Point(75, 32);
            this.cboGroupId.Name = "cboGroupId";
            this.cboGroupId.Size = new System.Drawing.Size(174, 20);
            this.cboGroupId.TabIndex = 16;
            // 
            // txtSymbolId
            // 
            this.txtSymbolId.Location = new System.Drawing.Point(314, 32);
            this.txtSymbolId.Name = "txtSymbolId";
            this.txtSymbolId.Size = new System.Drawing.Size(115, 22);
            this.txtSymbolId.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(255, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 18;
            this.label6.Text = "股票代碼";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 20;
            this.label7.Text = "頁面名稱";
            // 
            // txtWorksheetName
            // 
            this.txtWorksheetName.Location = new System.Drawing.Point(74, 58);
            this.txtWorksheetName.Name = "txtWorksheetName";
            this.txtWorksheetName.Size = new System.Drawing.Size(115, 22);
            this.txtWorksheetName.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(196, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 21;
            this.label8.Text = "標題列數";
            // 
            // txtHeaderRowCount
            // 
            this.txtHeaderRowCount.Location = new System.Drawing.Point(255, 58);
            this.txtHeaderRowCount.Name = "txtHeaderRowCount";
            this.txtHeaderRowCount.Size = new System.Drawing.Size(115, 22);
            this.txtHeaderRowCount.TabIndex = 22;
            this.txtHeaderRowCount.Text = "1";
            // 
            // ExcelExportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 168);
            this.Controls.Add(this.txtHeaderRowCount);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtWorksheetName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSymbolId);
            this.Controls.Add(this.cboGroupId);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnSaveConfig);
            this.Controls.Add(this.txtOutputPath);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTemplateFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEndDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtStartDate);
            this.Controls.Add(this.label1);
            this.Name = "ExcelExportForm";
            this.Text = "匯出工具";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEndDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStartDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTemplateFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOutputPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSaveConfig;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboGroupId;
        private System.Windows.Forms.TextBox txtSymbolId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtWorksheetName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtHeaderRowCount;
    }
}