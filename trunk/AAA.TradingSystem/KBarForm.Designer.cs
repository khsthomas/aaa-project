namespace AAA.TradingSystem
{
    partial class KBarForm
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
            this.pnlConfig = new System.Windows.Forms.Panel();
            this.btnConfig = new System.Windows.Forms.Button();
            this.txtSymbolName = new System.Windows.Forms.TextBox();
            this.btnDisplay = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSymbolId = new System.Windows.Forms.TextBox();
            this.pnlDataSource = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cboFileType = new System.Windows.Forms.ComboBox();
            this.cboPeriod = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.txtDateTime = new System.Windows.Forms.TextBox();
            this.txtDiffRatio = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDiff = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtVolume = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtClose = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLow = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtHigh = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOpen = new System.Windows.Forms.TextBox();
            this.cpDatabase = new AAA.TeeChart.TeeChartPanel();
            this.cpText = new AAA.TeeChart.TeeChartPanel();
            this.cpExcel = new AAA.TeeChart.TeeChartPanel();
            this.pnlConfig.SuspendLayout();
            this.pnlDataSource.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlConfig
            // 
            this.pnlConfig.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlConfig.Controls.Add(this.pnlInfo);
            this.pnlConfig.Controls.Add(this.pnlDataSource);
            this.pnlConfig.Controls.Add(this.btnConfig);
            this.pnlConfig.Controls.Add(this.txtSymbolName);
            this.pnlConfig.Controls.Add(this.btnDisplay);
            this.pnlConfig.Controls.Add(this.label1);
            this.pnlConfig.Controls.Add(this.txtSymbolId);
            this.pnlConfig.Location = new System.Drawing.Point(12, 12);
            this.pnlConfig.Name = "pnlConfig";
            this.pnlConfig.Size = new System.Drawing.Size(992, 42);
            this.pnlConfig.TabIndex = 1;
            // 
            // btnConfig
            // 
            this.btnConfig.Location = new System.Drawing.Point(820, 9);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(75, 23);
            this.btnConfig.TabIndex = 7;
            this.btnConfig.Text = "指標";
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Visible = false;
            // 
            // txtSymbolName
            // 
            this.txtSymbolName.Location = new System.Drawing.Point(146, 9);
            this.txtSymbolName.Name = "txtSymbolName";
            this.txtSymbolName.ReadOnly = true;
            this.txtSymbolName.Size = new System.Drawing.Size(82, 22);
            this.txtSymbolName.TabIndex = 16;
            // 
            // btnDisplay
            // 
            this.btnDisplay.Location = new System.Drawing.Point(901, 9);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(75, 23);
            this.btnDisplay.TabIndex = 2;
            this.btnDisplay.Text = "顯示";
            this.btnDisplay.UseVisualStyleBackColor = true;
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "商品代碼";
            // 
            // txtSymbolId
            // 
            this.txtSymbolId.Location = new System.Drawing.Point(62, 9);
            this.txtSymbolId.Name = "txtSymbolId";
            this.txtSymbolId.Size = new System.Drawing.Size(78, 22);
            this.txtSymbolId.TabIndex = 0;
            this.txtSymbolId.Text = "1101";
            // 
            // pnlDataSource
            // 
            this.pnlDataSource.Controls.Add(this.label3);
            this.pnlDataSource.Controls.Add(this.cboFileType);
            this.pnlDataSource.Controls.Add(this.cboPeriod);
            this.pnlDataSource.Controls.Add(this.label2);
            this.pnlDataSource.Location = new System.Drawing.Point(236, 6);
            this.pnlDataSource.Name = "pnlDataSource";
            this.pnlDataSource.Size = new System.Drawing.Size(314, 30);
            this.pnlDataSource.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(171, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "來源";
            // 
            // cboFileType
            // 
            this.cboFileType.FormattingEnabled = true;
            this.cboFileType.Location = new System.Drawing.Point(206, 5);
            this.cboFileType.Name = "cboFileType";
            this.cboFileType.Size = new System.Drawing.Size(96, 20);
            this.cboFileType.TabIndex = 9;
            // 
            // cboPeriod
            // 
            this.cboPeriod.FormattingEnabled = true;
            this.cboPeriod.Location = new System.Drawing.Point(41, 5);
            this.cboPeriod.Name = "cboPeriod";
            this.cboPeriod.Size = new System.Drawing.Size(121, 20);
            this.cboPeriod.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "時間";
            // 
            // pnlInfo
            // 
            this.pnlInfo.Controls.Add(this.txtDateTime);
            this.pnlInfo.Controls.Add(this.txtDiffRatio);
            this.pnlInfo.Controls.Add(this.label9);
            this.pnlInfo.Controls.Add(this.txtDiff);
            this.pnlInfo.Controls.Add(this.label8);
            this.pnlInfo.Controls.Add(this.txtVolume);
            this.pnlInfo.Controls.Add(this.label7);
            this.pnlInfo.Controls.Add(this.txtClose);
            this.pnlInfo.Controls.Add(this.label6);
            this.pnlInfo.Controls.Add(this.txtLow);
            this.pnlInfo.Controls.Add(this.label5);
            this.pnlInfo.Controls.Add(this.txtHigh);
            this.pnlInfo.Controls.Add(this.label4);
            this.pnlInfo.Controls.Add(this.txtOpen);
            this.pnlInfo.Location = new System.Drawing.Point(234, 6);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(580, 29);
            this.pnlInfo.TabIndex = 24;
            // 
            // txtDateTime
            // 
            this.txtDateTime.Location = new System.Drawing.Point(3, 3);
            this.txtDateTime.Name = "txtDateTime";
            this.txtDateTime.ReadOnly = true;
            this.txtDateTime.Size = new System.Drawing.Size(69, 22);
            this.txtDateTime.TabIndex = 29;
            // 
            // txtDiffRatio
            // 
            this.txtDiffRatio.Location = new System.Drawing.Point(531, 2);
            this.txtDiffRatio.Name = "txtDiffRatio";
            this.txtDiffRatio.ReadOnly = true;
            this.txtDiffRatio.Size = new System.Drawing.Size(44, 22);
            this.txtDiffRatio.TabIndex = 28;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(446, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 27;
            this.label9.Text = "漲跌";
            // 
            // txtDiff
            // 
            this.txtDiff.Location = new System.Drawing.Point(481, 3);
            this.txtDiff.Name = "txtDiff";
            this.txtDiff.ReadOnly = true;
            this.txtDiff.Size = new System.Drawing.Size(44, 22);
            this.txtDiff.TabIndex = 26;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(385, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 25;
            this.label8.Text = "量";
            // 
            // txtVolume
            // 
            this.txtVolume.Location = new System.Drawing.Point(404, 3);
            this.txtVolume.Name = "txtVolume";
            this.txtVolume.ReadOnly = true;
            this.txtVolume.Size = new System.Drawing.Size(35, 22);
            this.txtVolume.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(310, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 23;
            this.label7.Text = "收盤";
            // 
            // txtClose
            // 
            this.txtClose.Location = new System.Drawing.Point(341, 3);
            this.txtClose.Name = "txtClose";
            this.txtClose.ReadOnly = true;
            this.txtClose.Size = new System.Drawing.Size(35, 22);
            this.txtClose.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(230, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 21;
            this.label6.Text = "最低";
            // 
            // txtLow
            // 
            this.txtLow.Location = new System.Drawing.Point(261, 3);
            this.txtLow.Name = "txtLow";
            this.txtLow.ReadOnly = true;
            this.txtLow.Size = new System.Drawing.Size(35, 22);
            this.txtLow.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(154, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 19;
            this.label5.Text = "最高";
            // 
            // txtHigh
            // 
            this.txtHigh.Location = new System.Drawing.Point(185, 3);
            this.txtHigh.Name = "txtHigh";
            this.txtHigh.ReadOnly = true;
            this.txtHigh.Size = new System.Drawing.Size(35, 22);
            this.txtHigh.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(80, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "開盤";
            // 
            // txtOpen
            // 
            this.txtOpen.Location = new System.Drawing.Point(110, 3);
            this.txtOpen.Name = "txtOpen";
            this.txtOpen.ReadOnly = true;
            this.txtOpen.Size = new System.Drawing.Size(35, 22);
            this.txtOpen.TabIndex = 16;
            // 
            // cpDatabase
            // 
            this.cpDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cpDatabase.DateTimeFormat = null;
            this.cpDatabase.IsShowInfoTable = false;
            this.cpDatabase.IsShowScale = false;
            this.cpDatabase.Location = new System.Drawing.Point(12, 60);
            this.cpDatabase.Name = "cpDatabase";
            this.cpDatabase.PointPerPage = 0;
            this.cpDatabase.ShowHorizontalCursor = false;
            this.cpDatabase.ShowVerticalCursor = false;
            this.cpDatabase.Size = new System.Drawing.Size(992, 298);
            this.cpDatabase.TabIndex = 4;
            // 
            // cpText
            // 
            this.cpText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cpText.DateTimeFormat = null;
            this.cpText.IsShowInfoTable = false;
            this.cpText.IsShowScale = false;
            this.cpText.Location = new System.Drawing.Point(12, 60);
            this.cpText.Name = "cpText";
            this.cpText.PointPerPage = 0;
            this.cpText.ShowHorizontalCursor = false;
            this.cpText.ShowVerticalCursor = false;
            this.cpText.Size = new System.Drawing.Size(992, 254);
            this.cpText.TabIndex = 3;
            // 
            // cpExcel
            // 
            this.cpExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cpExcel.DateTimeFormat = null;
            this.cpExcel.IsShowInfoTable = false;
            this.cpExcel.IsShowScale = false;
            this.cpExcel.Location = new System.Drawing.Point(12, 60);
            this.cpExcel.Name = "cpExcel";
            this.cpExcel.PointPerPage = 0;
            this.cpExcel.ShowHorizontalCursor = false;
            this.cpExcel.ShowVerticalCursor = false;
            this.cpExcel.Size = new System.Drawing.Size(992, 254);
            this.cpExcel.TabIndex = 2;
            // 
            // KBarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 363);
            this.Controls.Add(this.cpDatabase);
            this.Controls.Add(this.cpText);
            this.Controls.Add(this.cpExcel);
            this.Controls.Add(this.pnlConfig);
            this.Name = "KBarForm";
            this.Text = "走勢圖";
            this.pnlConfig.ResumeLayout(false);
            this.pnlConfig.PerformLayout();
            this.pnlDataSource.ResumeLayout(false);
            this.pnlDataSource.PerformLayout();
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlConfig;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSymbolId;
        private System.Windows.Forms.Button btnDisplay;
        private AAA.TeeChart.TeeChartPanel cpExcel;
        private AAA.TeeChart.TeeChartPanel cpText;
        private AAA.TeeChart.TeeChartPanel cpDatabase;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.TextBox txtSymbolName;
        private System.Windows.Forms.Panel pnlDataSource;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboFileType;
        private System.Windows.Forms.ComboBox cboPeriod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.TextBox txtDateTime;
        private System.Windows.Forms.TextBox txtDiffRatio;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDiff;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtVolume;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtClose;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLow;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtHigh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOpen;

    }
}

