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
            this.pnlDataSource = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cboFileType = new System.Windows.Forms.ComboBox();
            this.cboPeriod = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConfig = new System.Windows.Forms.Button();
            this.txtSymbolName = new System.Windows.Forms.TextBox();
            this.btnDisplay = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSymbolId = new System.Windows.Forms.TextBox();
            this.gbIndicatorSetup = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cboChart = new System.Windows.Forms.ComboBox();
            this.lstChartIndicator = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lstSourceIndicator = new System.Windows.Forms.ListBox();
            this.cpDatabase = new AAA.TeeChart.TeeChartPanel();
            this.cpText = new AAA.TeeChart.TeeChartPanel();
            this.cpExcel = new AAA.TeeChart.TeeChartPanel();
            this.pnlConfig.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.pnlDataSource.SuspendLayout();
            this.gbIndicatorSetup.SuspendLayout();
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
            this.pnlConfig.Location = new System.Drawing.Point(12, 4);
            this.pnlConfig.Name = "pnlConfig";
            this.pnlConfig.Size = new System.Drawing.Size(1010, 50);
            this.pnlConfig.TabIndex = 1;
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
            this.pnlInfo.Location = new System.Drawing.Point(213, 6);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(598, 29);
            this.pnlInfo.TabIndex = 24;
            // 
            // txtDateTime
            // 
            this.txtDateTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDateTime.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtDateTime.Location = new System.Drawing.Point(3, 3);
            this.txtDateTime.Name = "txtDateTime";
            this.txtDateTime.ReadOnly = true;
            this.txtDateTime.Size = new System.Drawing.Size(79, 20);
            this.txtDateTime.TabIndex = 29;
            this.txtDateTime.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDateTime_KeyUp);
            // 
            // txtDiffRatio
            // 
            this.txtDiffRatio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDiffRatio.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtDiffRatio.Location = new System.Drawing.Point(701, 3);
            this.txtDiffRatio.Name = "txtDiffRatio";
            this.txtDiffRatio.ReadOnly = true;
            this.txtDiffRatio.Size = new System.Drawing.Size(47, 20);
            this.txtDiffRatio.TabIndex = 28;
            this.txtDiffRatio.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.Location = new System.Drawing.Point(593, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 16);
            this.label9.TabIndex = 27;
            this.label9.Text = "漲跌";
            this.label9.Visible = false;
            // 
            // txtDiff
            // 
            this.txtDiff.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDiff.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtDiff.Location = new System.Drawing.Point(636, 4);
            this.txtDiff.Name = "txtDiff";
            this.txtDiff.ReadOnly = true;
            this.txtDiff.Size = new System.Drawing.Size(49, 20);
            this.txtDiff.TabIndex = 26;
            this.txtDiff.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(510, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 16);
            this.label8.TabIndex = 25;
            this.label8.Text = "量";
            // 
            // txtVolume
            // 
            this.txtVolume.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtVolume.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtVolume.Location = new System.Drawing.Point(537, 4);
            this.txtVolume.Name = "txtVolume";
            this.txtVolume.ReadOnly = true;
            this.txtVolume.Size = new System.Drawing.Size(45, 20);
            this.txtVolume.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(403, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 16);
            this.label7.TabIndex = 23;
            this.label7.Text = "收盤";
            // 
            // txtClose
            // 
            this.txtClose.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtClose.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtClose.Location = new System.Drawing.Point(448, 4);
            this.txtClose.Name = "txtClose";
            this.txtClose.ReadOnly = true;
            this.txtClose.Size = new System.Drawing.Size(50, 20);
            this.txtClose.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(297, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 16);
            this.label6.TabIndex = 21;
            this.label6.Text = "最低";
            // 
            // txtLow
            // 
            this.txtLow.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLow.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtLow.Location = new System.Drawing.Point(339, 4);
            this.txtLow.Name = "txtLow";
            this.txtLow.ReadOnly = true;
            this.txtLow.Size = new System.Drawing.Size(50, 20);
            this.txtLow.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(194, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 16);
            this.label5.TabIndex = 19;
            this.label5.Text = "最高";
            // 
            // txtHigh
            // 
            this.txtHigh.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtHigh.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtHigh.Location = new System.Drawing.Point(237, 4);
            this.txtHigh.Name = "txtHigh";
            this.txtHigh.ReadOnly = true;
            this.txtHigh.Size = new System.Drawing.Size(50, 20);
            this.txtHigh.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(91, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 17;
            this.label4.Text = "開盤";
            // 
            // txtOpen
            // 
            this.txtOpen.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOpen.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtOpen.Location = new System.Drawing.Point(133, 4);
            this.txtOpen.Name = "txtOpen";
            this.txtOpen.ReadOnly = true;
            this.txtOpen.Size = new System.Drawing.Size(50, 20);
            this.txtOpen.TabIndex = 16;
            // 
            // pnlDataSource
            // 
            this.pnlDataSource.Controls.Add(this.label3);
            this.pnlDataSource.Controls.Add(this.cboFileType);
            this.pnlDataSource.Controls.Add(this.cboPeriod);
            this.pnlDataSource.Controls.Add(this.label2);
            this.pnlDataSource.Location = new System.Drawing.Point(273, 6);
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
            // btnConfig
            // 
            this.btnConfig.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnConfig.Location = new System.Drawing.Point(923, 8);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(83, 23);
            this.btnConfig.TabIndex = 7;
            this.btnConfig.Text = "指標";
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // txtSymbolName
            // 
            this.txtSymbolName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSymbolName.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtSymbolName.Location = new System.Drawing.Point(137, 8);
            this.txtSymbolName.Name = "txtSymbolName";
            this.txtSymbolName.ReadOnly = true;
            this.txtSymbolName.Size = new System.Drawing.Size(69, 20);
            this.txtSymbolName.TabIndex = 16;
            // 
            // btnDisplay
            // 
            this.btnDisplay.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnDisplay.Location = new System.Drawing.Point(833, 8);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(85, 23);
            this.btnDisplay.TabIndex = 2;
            this.btnDisplay.Text = "顯示";
            this.btnDisplay.UseVisualStyleBackColor = true;
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "商品代碼";
            // 
            // txtSymbolId
            // 
            this.txtSymbolId.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtSymbolId.Location = new System.Drawing.Point(81, 6);
            this.txtSymbolId.Name = "txtSymbolId";
            this.txtSymbolId.Size = new System.Drawing.Size(52, 27);
            this.txtSymbolId.TabIndex = 0;
            this.txtSymbolId.Text = "1101";
            this.txtSymbolId.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSymbolId_KeyUp);
            // 
            // gbIndicatorSetup
            // 
            this.gbIndicatorSetup.Controls.Add(this.btnCancel);
            this.gbIndicatorSetup.Controls.Add(this.btnOK);
            this.gbIndicatorSetup.Controls.Add(this.btnRemove);
            this.gbIndicatorSetup.Controls.Add(this.btnAdd);
            this.gbIndicatorSetup.Controls.Add(this.label12);
            this.gbIndicatorSetup.Controls.Add(this.label11);
            this.gbIndicatorSetup.Controls.Add(this.cboChart);
            this.gbIndicatorSetup.Controls.Add(this.lstChartIndicator);
            this.gbIndicatorSetup.Controls.Add(this.label10);
            this.gbIndicatorSetup.Controls.Add(this.lstSourceIndicator);
            this.gbIndicatorSetup.Location = new System.Drawing.Point(558, 83);
            this.gbIndicatorSetup.Name = "gbIndicatorSetup";
            this.gbIndicatorSetup.Size = new System.Drawing.Size(388, 255);
            this.gbIndicatorSetup.TabIndex = 5;
            this.gbIndicatorSetup.TabStop = false;
            this.gbIndicatorSetup.Text = "指標設定";
            this.gbIndicatorSetup.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(199, 217);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(59, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(128, 217);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(59, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "確定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(178, 146);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(35, 23);
            this.btnRemove.TabIndex = 7;
            this.btnRemove.Text = "<<";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(178, 117);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(35, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = ">>";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(229, 29);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 5;
            this.label12.Text = "副圖";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(229, 82);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 4;
            this.label11.Text = "選取指標";
            // 
            // cboChart
            // 
            this.cboChart.FormattingEnabled = true;
            this.cboChart.Location = new System.Drawing.Point(231, 53);
            this.cboChart.Name = "cboChart";
            this.cboChart.Size = new System.Drawing.Size(141, 20);
            this.cboChart.TabIndex = 3;
            this.cboChart.SelectedIndexChanged += new System.EventHandler(this.cboChart_SelectedIndexChanged);
            // 
            // lstChartIndicator
            // 
            this.lstChartIndicator.FormattingEnabled = true;
            this.lstChartIndicator.ItemHeight = 12;
            this.lstChartIndicator.Location = new System.Drawing.Point(231, 101);
            this.lstChartIndicator.Name = "lstChartIndicator";
            this.lstChartIndicator.Size = new System.Drawing.Size(141, 100);
            this.lstChartIndicator.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 29);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 1;
            this.label10.Text = "可用指標";
            // 
            // lstSourceIndicator
            // 
            this.lstSourceIndicator.FormattingEnabled = true;
            this.lstSourceIndicator.ItemHeight = 12;
            this.lstSourceIndicator.Location = new System.Drawing.Point(18, 53);
            this.lstSourceIndicator.Name = "lstSourceIndicator";
            this.lstSourceIndicator.Size = new System.Drawing.Size(141, 148);
            this.lstSourceIndicator.TabIndex = 0;
            // 
            // cpDatabase
            // 
            this.cpDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cpDatabase.BaseSeriesName = "";
            this.cpDatabase.DateTimeFormat = null;
            this.cpDatabase.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cpDatabase.IsShowInfoTable = false;
            this.cpDatabase.IsShowLightPane = false;
            this.cpDatabase.IsShowScale = false;
            this.cpDatabase.Location = new System.Drawing.Point(12, 60);
            this.cpDatabase.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cpDatabase.Name = "cpDatabase";
            this.cpDatabase.PointPerPage = 0;
            this.cpDatabase.ShowHorizontalCursor = false;
            this.cpDatabase.ShowVerticalCursor = false;
            this.cpDatabase.Size = new System.Drawing.Size(1001, 355);
            this.cpDatabase.TabIndex = 4;
            // 
            // cpText
            // 
            this.cpText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cpText.BaseSeriesName = "";
            this.cpText.DateTimeFormat = null;
            this.cpText.IsShowInfoTable = false;
            this.cpText.IsShowLightPane = false;
            this.cpText.IsShowScale = false;
            this.cpText.Location = new System.Drawing.Point(12, 60);
            this.cpText.Name = "cpText";
            this.cpText.PointPerPage = 0;
            this.cpText.ShowHorizontalCursor = false;
            this.cpText.ShowVerticalCursor = false;
            this.cpText.Size = new System.Drawing.Size(1001, 261);
            this.cpText.TabIndex = 3;
            // 
            // cpExcel
            // 
            this.cpExcel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cpExcel.BaseSeriesName = "";
            this.cpExcel.DateTimeFormat = null;
            this.cpExcel.IsShowInfoTable = false;
            this.cpExcel.IsShowLightPane = false;
            this.cpExcel.IsShowScale = false;
            this.cpExcel.Location = new System.Drawing.Point(12, 60);
            this.cpExcel.Name = "cpExcel";
            this.cpExcel.PointPerPage = 0;
            this.cpExcel.ShowHorizontalCursor = false;
            this.cpExcel.ShowVerticalCursor = false;
            this.cpExcel.Size = new System.Drawing.Size(1001, 261);
            this.cpExcel.TabIndex = 2;
            // 
            // KBarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 427);
            this.Controls.Add(this.gbIndicatorSetup);
            this.Controls.Add(this.cpDatabase);
            this.Controls.Add(this.cpText);
            this.Controls.Add(this.cpExcel);
            this.Controls.Add(this.pnlConfig);
            this.Name = "KBarForm";
            this.Text = "走勢圖";
            this.pnlConfig.ResumeLayout(false);
            this.pnlConfig.PerformLayout();
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.pnlDataSource.ResumeLayout(false);
            this.pnlDataSource.PerformLayout();
            this.gbIndicatorSetup.ResumeLayout(false);
            this.gbIndicatorSetup.PerformLayout();
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
        private System.Windows.Forms.GroupBox gbIndicatorSetup;
        private System.Windows.Forms.ComboBox cboChart;
        private System.Windows.Forms.ListBox lstChartIndicator;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListBox lstSourceIndicator;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;

    }
}

