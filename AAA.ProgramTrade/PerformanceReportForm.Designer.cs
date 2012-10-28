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
            this.pnlStrategy = new System.Windows.Forms.TabPage();
            this.btnDrawChart = new System.Windows.Forms.Button();
            this.dtEndTime = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtStartTime = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
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
            this.pnlTrackingCenter = new System.Windows.Forms.TabPage();
            this.tabTrackingCenter = new System.Windows.Forms.TabControl();
            this.pnlOpen = new System.Windows.Forms.TabPage();
            this.tblOpenPosition = new System.Windows.Forms.DataGridView();
            this.pnlActive = new System.Windows.Forms.TabPage();
            this.tblActiveOrder = new System.Windows.Forms.DataGridView();
            this.pnlFilled = new System.Windows.Forms.TabPage();
            this.tblFilled = new System.Windows.Forms.DataGridView();
            this.pnlCanceled = new System.Windows.Forms.TabPage();
            this.tblCanceled = new System.Windows.Forms.DataGridView();
            this.pnlChart = new System.Windows.Forms.TabPage();
            this.cpChart = new AAA.Chart.Component.ChartPane();
            this.ofdDllPath = new System.Windows.Forms.OpenFileDialog();
            this.txtPointMultiple = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTaxRate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCommission = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlReport = new System.Windows.Forms.TabPage();
            this.tblReport = new System.Windows.Forms.DataGridView();
            this.tabReport.SuspendLayout();
            this.pnlStrategy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblSignalHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblParameter)).BeginInit();
            this.pnlTrackingCenter.SuspendLayout();
            this.tabTrackingCenter.SuspendLayout();
            this.pnlOpen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblOpenPosition)).BeginInit();
            this.pnlActive.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblActiveOrder)).BeginInit();
            this.pnlFilled.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblFilled)).BeginInit();
            this.pnlCanceled.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblCanceled)).BeginInit();
            this.pnlChart.SuspendLayout();
            this.pnlReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblReport)).BeginInit();
            this.SuspendLayout();
            // 
            // tabReport
            // 
            this.tabReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabReport.Controls.Add(this.pnlStrategy);
            this.tabReport.Controls.Add(this.pnlTrackingCenter);
            this.tabReport.Controls.Add(this.pnlReport);
            this.tabReport.Controls.Add(this.pnlChart);
            this.tabReport.Location = new System.Drawing.Point(3, 8);
            this.tabReport.Name = "tabReport";
            this.tabReport.SelectedIndex = 0;
            this.tabReport.Size = new System.Drawing.Size(641, 409);
            this.tabReport.TabIndex = 0;
            // 
            // pnlStrategy
            // 
            this.pnlStrategy.Controls.Add(this.txtCommission);
            this.pnlStrategy.Controls.Add(this.label7);
            this.pnlStrategy.Controls.Add(this.txtTaxRate);
            this.pnlStrategy.Controls.Add(this.label6);
            this.pnlStrategy.Controls.Add(this.txtPointMultiple);
            this.pnlStrategy.Controls.Add(this.label8);
            this.pnlStrategy.Controls.Add(this.btnDrawChart);
            this.pnlStrategy.Controls.Add(this.dtEndTime);
            this.pnlStrategy.Controls.Add(this.label5);
            this.pnlStrategy.Controls.Add(this.dtStartTime);
            this.pnlStrategy.Controls.Add(this.label4);
            this.pnlStrategy.Controls.Add(this.btnPerformance);
            this.pnlStrategy.Controls.Add(this.tblSignalHistory);
            this.pnlStrategy.Controls.Add(this.cboBaseSymbolId);
            this.pnlStrategy.Controls.Add(this.label3);
            this.pnlStrategy.Controls.Add(this.tblParameter);
            this.pnlStrategy.Controls.Add(this.txtStrategyName);
            this.pnlStrategy.Controls.Add(this.label2);
            this.pnlStrategy.Controls.Add(this.btnBrowse);
            this.pnlStrategy.Controls.Add(this.txtStrategyPath);
            this.pnlStrategy.Controls.Add(this.label1);
            this.pnlStrategy.Location = new System.Drawing.Point(4, 21);
            this.pnlStrategy.Name = "pnlStrategy";
            this.pnlStrategy.Padding = new System.Windows.Forms.Padding(3);
            this.pnlStrategy.Size = new System.Drawing.Size(633, 384);
            this.pnlStrategy.TabIndex = 0;
            this.pnlStrategy.Text = "策略載入";
            this.pnlStrategy.UseVisualStyleBackColor = true;
            this.pnlStrategy.Click += new System.EventHandler(this.pnlStrategy_Click);
            // 
            // btnDrawChart
            // 
            this.btnDrawChart.Location = new System.Drawing.Point(555, 9);
            this.btnDrawChart.Name = "btnDrawChart";
            this.btnDrawChart.Size = new System.Drawing.Size(75, 23);
            this.btnDrawChart.TabIndex = 16;
            this.btnDrawChart.Text = "畫圖";
            this.btnDrawChart.UseVisualStyleBackColor = true;
            this.btnDrawChart.Click += new System.EventHandler(this.btnDrawChart_Click);
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
            // dtStartTime
            // 
            this.dtStartTime.Location = new System.Drawing.Point(74, 99);
            this.dtStartTime.Name = "dtStartTime";
            this.dtStartTime.Size = new System.Drawing.Size(117, 22);
            this.dtStartTime.TabIndex = 12;
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
            // btnPerformance
            // 
            this.btnPerformance.Location = new System.Drawing.Point(474, 9);
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
            this.tblParameter.Location = new System.Drawing.Point(17, 129);
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
            // pnlTrackingCenter
            // 
            this.pnlTrackingCenter.Controls.Add(this.tabTrackingCenter);
            this.pnlTrackingCenter.Location = new System.Drawing.Point(4, 21);
            this.pnlTrackingCenter.Name = "pnlTrackingCenter";
            this.pnlTrackingCenter.Padding = new System.Windows.Forms.Padding(3);
            this.pnlTrackingCenter.Size = new System.Drawing.Size(633, 384);
            this.pnlTrackingCenter.TabIndex = 1;
            this.pnlTrackingCenter.Text = "追蹤中心";
            this.pnlTrackingCenter.UseVisualStyleBackColor = true;
            // 
            // tabTrackingCenter
            // 
            this.tabTrackingCenter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabTrackingCenter.Controls.Add(this.pnlOpen);
            this.tabTrackingCenter.Controls.Add(this.pnlActive);
            this.tabTrackingCenter.Controls.Add(this.pnlFilled);
            this.tabTrackingCenter.Controls.Add(this.pnlCanceled);
            this.tabTrackingCenter.Location = new System.Drawing.Point(7, 7);
            this.tabTrackingCenter.Name = "tabTrackingCenter";
            this.tabTrackingCenter.SelectedIndex = 0;
            this.tabTrackingCenter.Size = new System.Drawing.Size(623, 374);
            this.tabTrackingCenter.TabIndex = 0;
            // 
            // pnlOpen
            // 
            this.pnlOpen.Controls.Add(this.tblOpenPosition);
            this.pnlOpen.Location = new System.Drawing.Point(4, 21);
            this.pnlOpen.Name = "pnlOpen";
            this.pnlOpen.Padding = new System.Windows.Forms.Padding(3);
            this.pnlOpen.Size = new System.Drawing.Size(615, 349);
            this.pnlOpen.TabIndex = 0;
            this.pnlOpen.Text = "未平倉";
            this.pnlOpen.UseVisualStyleBackColor = true;
            // 
            // tblOpenPosition
            // 
            this.tblOpenPosition.AllowUserToAddRows = false;
            this.tblOpenPosition.AllowUserToDeleteRows = false;
            this.tblOpenPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tblOpenPosition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblOpenPosition.Location = new System.Drawing.Point(0, 0);
            this.tblOpenPosition.Name = "tblOpenPosition";
            this.tblOpenPosition.ReadOnly = true;
            this.tblOpenPosition.RowHeadersVisible = false;
            this.tblOpenPosition.RowTemplate.Height = 24;
            this.tblOpenPosition.Size = new System.Drawing.Size(612, 343);
            this.tblOpenPosition.TabIndex = 0;
            // 
            // pnlActive
            // 
            this.pnlActive.Controls.Add(this.tblActiveOrder);
            this.pnlActive.Location = new System.Drawing.Point(4, 21);
            this.pnlActive.Name = "pnlActive";
            this.pnlActive.Padding = new System.Windows.Forms.Padding(3);
            this.pnlActive.Size = new System.Drawing.Size(615, 349);
            this.pnlActive.TabIndex = 1;
            this.pnlActive.Text = "未觸發訊號";
            this.pnlActive.UseVisualStyleBackColor = true;
            // 
            // tblActiveOrder
            // 
            this.tblActiveOrder.AllowUserToAddRows = false;
            this.tblActiveOrder.AllowUserToDeleteRows = false;
            this.tblActiveOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tblActiveOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblActiveOrder.Location = new System.Drawing.Point(1, 3);
            this.tblActiveOrder.Name = "tblActiveOrder";
            this.tblActiveOrder.ReadOnly = true;
            this.tblActiveOrder.RowHeadersVisible = false;
            this.tblActiveOrder.RowTemplate.Height = 24;
            this.tblActiveOrder.Size = new System.Drawing.Size(612, 343);
            this.tblActiveOrder.TabIndex = 1;
            // 
            // pnlFilled
            // 
            this.pnlFilled.Controls.Add(this.tblFilled);
            this.pnlFilled.Location = new System.Drawing.Point(4, 21);
            this.pnlFilled.Name = "pnlFilled";
            this.pnlFilled.Size = new System.Drawing.Size(615, 349);
            this.pnlFilled.TabIndex = 2;
            this.pnlFilled.Text = "已觸發訊號";
            this.pnlFilled.UseVisualStyleBackColor = true;
            // 
            // tblFilled
            // 
            this.tblFilled.AllowUserToAddRows = false;
            this.tblFilled.AllowUserToDeleteRows = false;
            this.tblFilled.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tblFilled.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblFilled.Location = new System.Drawing.Point(1, 3);
            this.tblFilled.Name = "tblFilled";
            this.tblFilled.ReadOnly = true;
            this.tblFilled.RowHeadersVisible = false;
            this.tblFilled.RowTemplate.Height = 24;
            this.tblFilled.Size = new System.Drawing.Size(612, 343);
            this.tblFilled.TabIndex = 1;
            // 
            // pnlCanceled
            // 
            this.pnlCanceled.Controls.Add(this.tblCanceled);
            this.pnlCanceled.Location = new System.Drawing.Point(4, 21);
            this.pnlCanceled.Name = "pnlCanceled";
            this.pnlCanceled.Size = new System.Drawing.Size(615, 349);
            this.pnlCanceled.TabIndex = 3;
            this.pnlCanceled.Text = "已取消訊號";
            this.pnlCanceled.UseVisualStyleBackColor = true;
            // 
            // tblCanceled
            // 
            this.tblCanceled.AllowUserToAddRows = false;
            this.tblCanceled.AllowUserToDeleteRows = false;
            this.tblCanceled.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tblCanceled.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblCanceled.Location = new System.Drawing.Point(1, 3);
            this.tblCanceled.Name = "tblCanceled";
            this.tblCanceled.ReadOnly = true;
            this.tblCanceled.RowHeadersVisible = false;
            this.tblCanceled.RowTemplate.Height = 24;
            this.tblCanceled.Size = new System.Drawing.Size(612, 343);
            this.tblCanceled.TabIndex = 1;
            // 
            // pnlChart
            // 
            this.pnlChart.Controls.Add(this.cpChart);
            this.pnlChart.Location = new System.Drawing.Point(4, 21);
            this.pnlChart.Name = "pnlChart";
            this.pnlChart.Size = new System.Drawing.Size(633, 384);
            this.pnlChart.TabIndex = 2;
            this.pnlChart.Text = "走勢圖";
            this.pnlChart.UseVisualStyleBackColor = true;
            // 
            // cpChart
            // 
            this.cpChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cpChart.Location = new System.Drawing.Point(5, 3);
            this.cpChart.Name = "cpChart";
            this.cpChart.Size = new System.Drawing.Size(622, 378);
            this.cpChart.TabIndex = 0;
            // 
            // ofdDllPath
            // 
            this.ofdDllPath.FileName = "openFileDialog1";
            // 
            // txtPointMultiple
            // 
            this.txtPointMultiple.Location = new System.Drawing.Point(459, 40);
            this.txtPointMultiple.Name = "txtPointMultiple";
            this.txtPointMultiple.Size = new System.Drawing.Size(55, 22);
            this.txtPointMultiple.TabIndex = 22;
            this.txtPointMultiple.Text = "200";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(404, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 21;
            this.label8.Text = "契約乖數";
            // 
            // txtTaxRate
            // 
            this.txtTaxRate.Location = new System.Drawing.Point(459, 67);
            this.txtTaxRate.Name = "txtTaxRate";
            this.txtTaxRate.Size = new System.Drawing.Size(55, 22);
            this.txtTaxRate.TabIndex = 24;
            this.txtTaxRate.Text = "0.00004";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(404, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 23;
            this.label6.Text = "交易稅率";
            // 
            // txtCommission
            // 
            this.txtCommission.Location = new System.Drawing.Point(459, 94);
            this.txtCommission.Name = "txtCommission";
            this.txtCommission.Size = new System.Drawing.Size(55, 22);
            this.txtCommission.TabIndex = 26;
            this.txtCommission.Text = "45";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(404, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 25;
            this.label7.Text = "手績費";
            // 
            // pnlReport
            // 
            this.pnlReport.Controls.Add(this.tblReport);
            this.pnlReport.Location = new System.Drawing.Point(4, 21);
            this.pnlReport.Name = "pnlReport";
            this.pnlReport.Size = new System.Drawing.Size(633, 384);
            this.pnlReport.TabIndex = 3;
            this.pnlReport.Text = "報表";
            this.pnlReport.UseVisualStyleBackColor = true;
            // 
            // tblReport
            // 
            this.tblReport.AllowUserToAddRows = false;
            this.tblReport.AllowUserToDeleteRows = false;
            this.tblReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tblReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblReport.Location = new System.Drawing.Point(5, 3);
            this.tblReport.Name = "tblReport";
            this.tblReport.RowHeadersVisible = false;
            this.tblReport.RowTemplate.Height = 24;
            this.tblReport.Size = new System.Drawing.Size(622, 378);
            this.tblReport.TabIndex = 6;
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
            this.pnlStrategy.ResumeLayout(false);
            this.pnlStrategy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblSignalHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblParameter)).EndInit();
            this.pnlTrackingCenter.ResumeLayout(false);
            this.tabTrackingCenter.ResumeLayout(false);
            this.pnlOpen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblOpenPosition)).EndInit();
            this.pnlActive.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblActiveOrder)).EndInit();
            this.pnlFilled.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblFilled)).EndInit();
            this.pnlCanceled.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblCanceled)).EndInit();
            this.pnlChart.ResumeLayout(false);
            this.pnlReport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabReport;
        private System.Windows.Forms.TabPage pnlStrategy;
        private System.Windows.Forms.TabPage pnlTrackingCenter;
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
        private System.Windows.Forms.TabControl tabTrackingCenter;
        private System.Windows.Forms.TabPage pnlOpen;
        private System.Windows.Forms.TabPage pnlActive;
        private System.Windows.Forms.DataGridView tblOpenPosition;
        private System.Windows.Forms.DataGridView tblActiveOrder;
        private System.Windows.Forms.TabPage pnlFilled;
        private System.Windows.Forms.DataGridView tblFilled;
        private System.Windows.Forms.TabPage pnlCanceled;
        private System.Windows.Forms.DataGridView tblCanceled;
        private System.Windows.Forms.Button btnDrawChart;
        private System.Windows.Forms.TabPage pnlChart;
        private AAA.Chart.Component.ChartPane cpChart;
        private System.Windows.Forms.TextBox txtPointMultiple;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCommission;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTaxRate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage pnlReport;
        private System.Windows.Forms.DataGridView tblReport;
    }
}