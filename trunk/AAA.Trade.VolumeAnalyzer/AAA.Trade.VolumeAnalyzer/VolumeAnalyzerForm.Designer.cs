namespace AAA.Trade.VolumeAnalyzer
{
    partial class VolumeAnalyzerForm
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtVolume = new System.Windows.Forms.TextBox();
            this.txtDBV = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDSV = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtDealDiff = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.txtPriceDiff = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tblVolume = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tblVolume1 = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tblAbnormalVolume = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tblAbnormalVolume1 = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBigAlarmDiffVolume = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSmallAlarmDiffVolume = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnRemark = new System.Windows.Forms.Button();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEstVol = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPeriodAlarmVolume = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtPeriodAlarmInterval = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtPeriodVolume = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.alarmTimer = new System.Windows.Forms.Timer(this.components);
            this.txtSymbolId = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblVolume)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblVolume1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblAbnormalVolume)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblAbnormalVolume1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "成交價";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "成交量";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(59, 6);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.ReadOnly = true;
            this.txtPrice.Size = new System.Drawing.Size(63, 22);
            this.txtPrice.TabIndex = 3;
            // 
            // txtVolume
            // 
            this.txtVolume.Location = new System.Drawing.Point(59, 31);
            this.txtVolume.Name = "txtVolume";
            this.txtVolume.ReadOnly = true;
            this.txtVolume.Size = new System.Drawing.Size(63, 22);
            this.txtVolume.TabIndex = 4;
            // 
            // txtDBV
            // 
            this.txtDBV.Location = new System.Drawing.Point(187, 6);
            this.txtDBV.Name = "txtDBV";
            this.txtDBV.ReadOnly = true;
            this.txtDBV.Size = new System.Drawing.Size(63, 22);
            this.txtDBV.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(128, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "成交買張";
            // 
            // txtDSV
            // 
            this.txtDSV.Location = new System.Drawing.Point(187, 31);
            this.txtDSV.Name = "txtDSV";
            this.txtDSV.ReadOnly = true;
            this.txtDSV.Size = new System.Drawing.Size(63, 22);
            this.txtDSV.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(128, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "成交賣張";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(384, 6);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 9;
            this.btnStart.Text = "啟動";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtDealDiff
            // 
            this.txtDealDiff.Location = new System.Drawing.Point(315, 6);
            this.txtDealDiff.Name = "txtDealDiff";
            this.txtDealDiff.ReadOnly = true;
            this.txtDealDiff.Size = new System.Drawing.Size(63, 22);
            this.txtDealDiff.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(256, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "買賣差距";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(384, 31);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 12;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // txtPriceDiff
            // 
            this.txtPriceDiff.Location = new System.Drawing.Point(315, 31);
            this.txtPriceDiff.Name = "txtPriceDiff";
            this.txtPriceDiff.ReadOnly = true;
            this.txtPriceDiff.Size = new System.Drawing.Size(63, 22);
            this.txtPriceDiff.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(256, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "點數差距";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(3, 84);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(914, 351);
            this.tabControl1.TabIndex = 15;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tblVolume);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(906, 326);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "成交量(1)";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tblVolume
            // 
            this.tblVolume.AllowUserToAddRows = false;
            this.tblVolume.AllowUserToDeleteRows = false;
            this.tblVolume.AllowUserToResizeRows = false;
            this.tblVolume.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tblVolume.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblVolume.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblVolume.Location = new System.Drawing.Point(3, 3);
            this.tblVolume.MultiSelect = false;
            this.tblVolume.Name = "tblVolume";
            this.tblVolume.ReadOnly = true;
            this.tblVolume.RowHeadersVisible = false;
            this.tblVolume.RowTemplate.Height = 24;
            this.tblVolume.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblVolume.Size = new System.Drawing.Size(900, 320);
            this.tblVolume.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tblVolume1);
            this.tabPage3.Location = new System.Drawing.Point(4, 21);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(906, 326);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "成交量(2)";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tblVolume1
            // 
            this.tblVolume1.AllowUserToAddRows = false;
            this.tblVolume1.AllowUserToDeleteRows = false;
            this.tblVolume1.AllowUserToResizeRows = false;
            this.tblVolume1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tblVolume1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblVolume1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblVolume1.Location = new System.Drawing.Point(3, 3);
            this.tblVolume1.MultiSelect = false;
            this.tblVolume1.Name = "tblVolume1";
            this.tblVolume1.ReadOnly = true;
            this.tblVolume1.RowHeadersVisible = false;
            this.tblVolume1.RowTemplate.Height = 24;
            this.tblVolume1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblVolume1.Size = new System.Drawing.Size(900, 320);
            this.tblVolume1.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tblAbnormalVolume);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(906, 326);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "異常成交量(1)";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tblAbnormalVolume
            // 
            this.tblAbnormalVolume.AllowUserToAddRows = false;
            this.tblAbnormalVolume.AllowUserToDeleteRows = false;
            this.tblAbnormalVolume.AllowUserToResizeRows = false;
            this.tblAbnormalVolume.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tblAbnormalVolume.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblAbnormalVolume.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblAbnormalVolume.Location = new System.Drawing.Point(3, 3);
            this.tblAbnormalVolume.MultiSelect = false;
            this.tblAbnormalVolume.Name = "tblAbnormalVolume";
            this.tblAbnormalVolume.ReadOnly = true;
            this.tblAbnormalVolume.RowHeadersVisible = false;
            this.tblAbnormalVolume.RowTemplate.Height = 24;
            this.tblAbnormalVolume.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblAbnormalVolume.Size = new System.Drawing.Size(900, 320);
            this.tblAbnormalVolume.TabIndex = 1;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.tblAbnormalVolume1);
            this.tabPage4.Location = new System.Drawing.Point(4, 21);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(906, 326);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "異常成交量(2)";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tblAbnormalVolume1
            // 
            this.tblAbnormalVolume1.AllowUserToAddRows = false;
            this.tblAbnormalVolume1.AllowUserToDeleteRows = false;
            this.tblAbnormalVolume1.AllowUserToResizeRows = false;
            this.tblAbnormalVolume1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tblAbnormalVolume1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblAbnormalVolume1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblAbnormalVolume1.Location = new System.Drawing.Point(3, 3);
            this.tblAbnormalVolume1.MultiSelect = false;
            this.tblAbnormalVolume1.Name = "tblAbnormalVolume1";
            this.tblAbnormalVolume1.ReadOnly = true;
            this.tblAbnormalVolume1.RowHeadersVisible = false;
            this.tblAbnormalVolume1.RowTemplate.Height = 24;
            this.tblAbnormalVolume1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblAbnormalVolume1.Size = new System.Drawing.Size(900, 320);
            this.tblAbnormalVolume1.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(467, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "儲存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(467, 32);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 17;
            this.btnLoad.Text = "載入";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // txtDate
            // 
            this.txtDate.BackColor = System.Drawing.SystemColors.Control;
            this.txtDate.Location = new System.Drawing.Point(187, 57);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(63, 22);
            this.txtDate.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(152, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 18;
            this.label7.Text = "日期";
            // 
            // txtBigAlarmDiffVolume
            // 
            this.txtBigAlarmDiffVolume.BackColor = System.Drawing.SystemColors.Control;
            this.txtBigAlarmDiffVolume.Location = new System.Drawing.Point(607, 7);
            this.txtBigAlarmDiffVolume.Name = "txtBigAlarmDiffVolume";
            this.txtBigAlarmDiffVolume.Size = new System.Drawing.Size(63, 22);
            this.txtBigAlarmDiffVolume.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(548, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 20;
            this.label8.Text = "進場口數";
            // 
            // txtSmallAlarmDiffVolume
            // 
            this.txtSmallAlarmDiffVolume.BackColor = System.Drawing.SystemColors.Control;
            this.txtSmallAlarmDiffVolume.Location = new System.Drawing.Point(607, 35);
            this.txtSmallAlarmDiffVolume.Name = "txtSmallAlarmDiffVolume";
            this.txtSmallAlarmDiffVolume.Size = new System.Drawing.Size(63, 22);
            this.txtSmallAlarmDiffVolume.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(548, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 22;
            this.label9.Text = "出場口數";
            // 
            // btnRemark
            // 
            this.btnRemark.Location = new System.Drawing.Point(677, 5);
            this.btnRemark.Name = "btnRemark";
            this.btnRemark.Size = new System.Drawing.Size(75, 23);
            this.btnRemark.TabIndex = 24;
            this.btnRemark.Text = "重新標示";
            this.btnRemark.UseVisualStyleBackColor = true;
            this.btnRemark.Click += new System.EventHandler(this.btnRemark_Click);
            // 
            // txtTime
            // 
            this.txtTime.BackColor = System.Drawing.SystemColors.Control;
            this.txtTime.Location = new System.Drawing.Point(315, 56);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(63, 22);
            this.txtTime.TabIndex = 26;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(280, 59);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 25;
            this.label10.Text = "時間";
            // 
            // txtEstVol
            // 
            this.txtEstVol.Location = new System.Drawing.Point(59, 56);
            this.txtEstVol.Name = "txtEstVol";
            this.txtEstVol.ReadOnly = true;
            this.txtEstVol.Size = new System.Drawing.Size(63, 22);
            this.txtEstVol.TabIndex = 28;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 60);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 27;
            this.label11.Text = "預估量";
            // 
            // txtPeriodAlarmVolume
            // 
            this.txtPeriodAlarmVolume.Location = new System.Drawing.Point(821, 31);
            this.txtPeriodAlarmVolume.Name = "txtPeriodAlarmVolume";
            this.txtPeriodAlarmVolume.ReadOnly = true;
            this.txtPeriodAlarmVolume.Size = new System.Drawing.Size(63, 22);
            this.txtPeriodAlarmVolume.TabIndex = 32;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(762, 37);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 31;
            this.label12.Text = "警示口數";
            // 
            // txtPeriodAlarmInterval
            // 
            this.txtPeriodAlarmInterval.Location = new System.Drawing.Point(821, 6);
            this.txtPeriodAlarmInterval.Name = "txtPeriodAlarmInterval";
            this.txtPeriodAlarmInterval.ReadOnly = true;
            this.txtPeriodAlarmInterval.Size = new System.Drawing.Size(63, 22);
            this.txtPeriodAlarmInterval.TabIndex = 30;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(762, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 29;
            this.label13.Text = "警示秒數";
            // 
            // txtPeriodVolume
            // 
            this.txtPeriodVolume.Location = new System.Drawing.Point(821, 56);
            this.txtPeriodVolume.Name = "txtPeriodVolume";
            this.txtPeriodVolume.ReadOnly = true;
            this.txtPeriodVolume.Size = new System.Drawing.Size(63, 22);
            this.txtPeriodVolume.TabIndex = 34;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(762, 62);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 33;
            this.label14.Text = "累積口數";
            // 
            // alarmTimer
            // 
            this.alarmTimer.Interval = 200;
            this.alarmTimer.Tick += new System.EventHandler(this.alarmTimer_Tick);
            // 
            // txtSymbolId
            // 
            this.txtSymbolId.Location = new System.Drawing.Point(449, 60);
            this.txtSymbolId.Name = "txtSymbolId";
            this.txtSymbolId.Size = new System.Drawing.Size(93, 22);
            this.txtSymbolId.TabIndex = 36;
            this.txtSymbolId.Text = "TW.TXFI2";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(389, 64);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 35;
            this.label15.Text = "商品名稱";
            // 
            // VolumeAnalyzerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 439);
            this.Controls.Add(this.txtSymbolId);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtPeriodVolume);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtPeriodAlarmVolume);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtPeriodAlarmInterval);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtEstVol);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnRemark);
            this.Controls.Add(this.txtSmallAlarmDiffVolume);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtBigAlarmDiffVolume);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txtPriceDiff);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.txtDealDiff);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtDSV);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDBV);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtVolume);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "VolumeAnalyzerForm";
            this.Text = "籌碼分析";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VolumeAnalyzerForm_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblVolume)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblVolume1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblAbnormalVolume)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblAbnormalVolume1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtVolume;
        private System.Windows.Forms.TextBox txtDBV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDSV;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtDealDiff;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TextBox txtPriceDiff;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView tblVolume;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView tblAbnormalVolume;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView tblVolume1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView tblAbnormalVolume1;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBigAlarmDiffVolume;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSmallAlarmDiffVolume;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnRemark;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtEstVol;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtPeriodAlarmVolume;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtPeriodAlarmInterval;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtPeriodVolume;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Timer alarmTimer;
        private System.Windows.Forms.TextBox txtSymbolId;
        private System.Windows.Forms.Label label15;
    }
}

