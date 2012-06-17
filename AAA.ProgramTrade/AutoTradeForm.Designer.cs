namespace AAA.ProgramTrade
{
    partial class AutoTradeForm
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
            this.tabAPI = new System.Windows.Forms.TabControl();
            this.tabAutoTrade = new System.Windows.Forms.TabPage();
            this.gbOrderStatus = new System.Windows.Forms.GroupBox();
            this.gbDeal = new System.Windows.Forms.GroupBox();
            this.tblDeal = new System.Windows.Forms.DataGridView();
            this.gbTrust = new System.Windows.Forms.GroupBox();
            this.tblTrust = new System.Windows.Forms.DataGridView();
            this.gbOpenPosition = new System.Windows.Forms.GroupBox();
            this.tblOpenPosition = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisplayStrategySetup = new System.Windows.Forms.Button();
            this.btnAllExit = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.gbManual = new System.Windows.Forms.GroupBox();
            this.txtManualVol = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.btnSell = new System.Windows.Forms.Button();
            this.btnBuy = new System.Windows.Forms.Button();
            this.cboManualOCType = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.chkIntraday = new System.Windows.Forms.CheckBox();
            this.chkMarketPrice = new System.Windows.Forms.CheckBox();
            this.txtManualPrice = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.cboManualPutOrCall = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtManualStrikePrice = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cboManualMonth = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.cboManualSymbolType = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.gbStrategy = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkExitSignal = new System.Windows.Forms.CheckBox();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.txtOrderVolume = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.pnlFutures = new System.Windows.Forms.Panel();
            this.cboFuturesMonth = new System.Windows.Forms.ComboBox();
            this.pnlOptions = new System.Windows.Forms.Panel();
            this.cboOptionsMonth = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOptionsSlippage = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboExecutePrice = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboOptionsSide = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.chkDayTrade = new System.Windows.Forms.CheckBox();
            this.txtSlippage = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboPriceType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboSymbolType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStrategyName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tblStrategy = new System.Windows.Forms.DataGridView();
            this.tabEquity = new System.Windows.Forms.TabPage();
            this.btnQueryTodayEquity = new System.Windows.Forms.Button();
            this.cboEquityType = new System.Windows.Forms.ComboBox();
            this.tblTodayEquity = new System.Windows.Forms.DataGridView();
            this.cboPriceZone = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSymbolSeq = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tabAPI.SuspendLayout();
            this.tabAutoTrade.SuspendLayout();
            this.gbOrderStatus.SuspendLayout();
            this.gbDeal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblDeal)).BeginInit();
            this.gbTrust.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblTrust)).BeginInit();
            this.gbOpenPosition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblOpenPosition)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.gbManual.SuspendLayout();
            this.gbStrategy.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlFutures.SuspendLayout();
            this.pnlOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblStrategy)).BeginInit();
            this.tabEquity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblTodayEquity)).BeginInit();
            this.SuspendLayout();
            // 
            // tabAPI
            // 
            this.tabAPI.Controls.Add(this.tabAutoTrade);
            this.tabAPI.Controls.Add(this.tabEquity);
            this.tabAPI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabAPI.Location = new System.Drawing.Point(0, 0);
            this.tabAPI.Name = "tabAPI";
            this.tabAPI.SelectedIndex = 0;
            this.tabAPI.Size = new System.Drawing.Size(726, 515);
            this.tabAPI.TabIndex = 0;
            // 
            // tabAutoTrade
            // 
            this.tabAutoTrade.Controls.Add(this.gbOrderStatus);
            this.tabAutoTrade.Controls.Add(this.groupBox2);
            this.tabAutoTrade.Controls.Add(this.gbManual);
            this.tabAutoTrade.Controls.Add(this.gbStrategy);
            this.tabAutoTrade.Location = new System.Drawing.Point(4, 21);
            this.tabAutoTrade.Name = "tabAutoTrade";
            this.tabAutoTrade.Padding = new System.Windows.Forms.Padding(3);
            this.tabAutoTrade.Size = new System.Drawing.Size(718, 490);
            this.tabAutoTrade.TabIndex = 0;
            this.tabAutoTrade.Text = "程式下單";
            this.tabAutoTrade.UseVisualStyleBackColor = true;
            // 
            // gbOrderStatus
            // 
            this.gbOrderStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbOrderStatus.Controls.Add(this.gbDeal);
            this.gbOrderStatus.Controls.Add(this.gbTrust);
            this.gbOrderStatus.Controls.Add(this.gbOpenPosition);
            this.gbOrderStatus.Location = new System.Drawing.Point(217, 9);
            this.gbOrderStatus.Name = "gbOrderStatus";
            this.gbOrderStatus.Size = new System.Drawing.Size(498, 475);
            this.gbOrderStatus.TabIndex = 3;
            this.gbOrderStatus.TabStop = false;
            this.gbOrderStatus.Text = "下單總覽";
            // 
            // gbDeal
            // 
            this.gbDeal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDeal.Controls.Add(this.tblDeal);
            this.gbDeal.Location = new System.Drawing.Point(9, 337);
            this.gbDeal.Name = "gbDeal";
            this.gbDeal.Size = new System.Drawing.Size(478, 132);
            this.gbDeal.TabIndex = 2;
            this.gbDeal.TabStop = false;
            this.gbDeal.Text = "成交回報";
            // 
            // tblDeal
            // 
            this.tblDeal.AllowUserToAddRows = false;
            this.tblDeal.AllowUserToDeleteRows = false;
            this.tblDeal.AllowUserToResizeRows = false;
            this.tblDeal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblDeal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblDeal.Location = new System.Drawing.Point(3, 18);
            this.tblDeal.MultiSelect = false;
            this.tblDeal.Name = "tblDeal";
            this.tblDeal.ReadOnly = true;
            this.tblDeal.RowHeadersVisible = false;
            this.tblDeal.RowTemplate.Height = 24;
            this.tblDeal.Size = new System.Drawing.Size(472, 111);
            this.tblDeal.TabIndex = 3;
            // 
            // gbTrust
            // 
            this.gbTrust.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbTrust.Controls.Add(this.tblTrust);
            this.gbTrust.Location = new System.Drawing.Point(9, 165);
            this.gbTrust.Name = "gbTrust";
            this.gbTrust.Size = new System.Drawing.Size(478, 166);
            this.gbTrust.TabIndex = 1;
            this.gbTrust.TabStop = false;
            this.gbTrust.Text = "委託回報";
            // 
            // tblTrust
            // 
            this.tblTrust.AllowUserToAddRows = false;
            this.tblTrust.AllowUserToDeleteRows = false;
            this.tblTrust.AllowUserToResizeRows = false;
            this.tblTrust.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblTrust.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblTrust.Location = new System.Drawing.Point(3, 18);
            this.tblTrust.MultiSelect = false;
            this.tblTrust.Name = "tblTrust";
            this.tblTrust.ReadOnly = true;
            this.tblTrust.RowHeadersVisible = false;
            this.tblTrust.RowTemplate.Height = 24;
            this.tblTrust.Size = new System.Drawing.Size(472, 145);
            this.tblTrust.TabIndex = 3;
            // 
            // gbOpenPosition
            // 
            this.gbOpenPosition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbOpenPosition.Controls.Add(this.tblOpenPosition);
            this.gbOpenPosition.Location = new System.Drawing.Point(9, 17);
            this.gbOpenPosition.Name = "gbOpenPosition";
            this.gbOpenPosition.Size = new System.Drawing.Size(478, 142);
            this.gbOpenPosition.TabIndex = 0;
            this.gbOpenPosition.TabStop = false;
            this.gbOpenPosition.Text = "目前部位";
            // 
            // tblOpenPosition
            // 
            this.tblOpenPosition.AllowUserToAddRows = false;
            this.tblOpenPosition.AllowUserToDeleteRows = false;
            this.tblOpenPosition.AllowUserToResizeRows = false;
            this.tblOpenPosition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblOpenPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblOpenPosition.Location = new System.Drawing.Point(3, 18);
            this.tblOpenPosition.MultiSelect = false;
            this.tblOpenPosition.Name = "tblOpenPosition";
            this.tblOpenPosition.ReadOnly = true;
            this.tblOpenPosition.RowHeadersVisible = false;
            this.tblOpenPosition.RowTemplate.Height = 24;
            this.tblOpenPosition.Size = new System.Drawing.Size(472, 121);
            this.tblOpenPosition.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnConnect);
            this.groupBox2.Controls.Add(this.btnDisplayStrategySetup);
            this.groupBox2.Controls.Add(this.btnAllExit);
            this.groupBox2.Controls.Add(this.btnStart);
            this.groupBox2.Controls.Add(this.txtAccount);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Location = new System.Drawing.Point(7, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 122);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(25, 55);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 16;
            this.btnConnect.Text = "連線";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisplayStrategySetup
            // 
            this.btnDisplayStrategySetup.Location = new System.Drawing.Point(25, 89);
            this.btnDisplayStrategySetup.Name = "btnDisplayStrategySetup";
            this.btnDisplayStrategySetup.Size = new System.Drawing.Size(75, 23);
            this.btnDisplayStrategySetup.TabIndex = 15;
            this.btnDisplayStrategySetup.Text = "顯示策略";
            this.btnDisplayStrategySetup.UseVisualStyleBackColor = true;
            this.btnDisplayStrategySetup.Click += new System.EventHandler(this.btnDisplayStrategySetup_Click);
            // 
            // btnAllExit
            // 
            this.btnAllExit.Location = new System.Drawing.Point(115, 89);
            this.btnAllExit.Name = "btnAllExit";
            this.btnAllExit.Size = new System.Drawing.Size(75, 23);
            this.btnAllExit.TabIndex = 14;
            this.btnAllExit.Text = "全部平倉";
            this.btnAllExit.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(115, 55);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 13;
            this.btnStart.Text = "啟動";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtAccount
            // 
            this.txtAccount.Enabled = false;
            this.txtAccount.Location = new System.Drawing.Point(56, 17);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(131, 22);
            this.txtAccount.TabIndex = 4;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(7, 20);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(29, 12);
            this.label25.TabIndex = 3;
            this.label25.Text = "帳號";
            // 
            // gbManual
            // 
            this.gbManual.Controls.Add(this.txtManualVol);
            this.gbManual.Controls.Add(this.label23);
            this.gbManual.Controls.Add(this.btnSell);
            this.gbManual.Controls.Add(this.btnBuy);
            this.gbManual.Controls.Add(this.cboManualOCType);
            this.gbManual.Controls.Add(this.label22);
            this.gbManual.Controls.Add(this.chkIntraday);
            this.gbManual.Controls.Add(this.chkMarketPrice);
            this.gbManual.Controls.Add(this.txtManualPrice);
            this.gbManual.Controls.Add(this.label21);
            this.gbManual.Controls.Add(this.cboManualPutOrCall);
            this.gbManual.Controls.Add(this.label20);
            this.gbManual.Controls.Add(this.txtManualStrikePrice);
            this.gbManual.Controls.Add(this.label19);
            this.gbManual.Controls.Add(this.cboManualMonth);
            this.gbManual.Controls.Add(this.label18);
            this.gbManual.Controls.Add(this.cboManualSymbolType);
            this.gbManual.Controls.Add(this.label17);
            this.gbManual.Location = new System.Drawing.Point(7, 241);
            this.gbManual.Name = "gbManual";
            this.gbManual.Size = new System.Drawing.Size(200, 237);
            this.gbManual.TabIndex = 4;
            this.gbManual.TabStop = false;
            this.gbManual.Text = "下單匣";
            // 
            // txtManualVol
            // 
            this.txtManualVol.Location = new System.Drawing.Point(66, 176);
            this.txtManualVol.Name = "txtManualVol";
            this.txtManualVol.Size = new System.Drawing.Size(62, 22);
            this.txtManualVol.TabIndex = 19;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(9, 182);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(29, 12);
            this.label23.TabIndex = 18;
            this.label23.Text = "口數";
            // 
            // btnSell
            // 
            this.btnSell.Location = new System.Drawing.Point(111, 209);
            this.btnSell.Name = "btnSell";
            this.btnSell.Size = new System.Drawing.Size(75, 23);
            this.btnSell.TabIndex = 17;
            this.btnSell.Text = "賣出";
            this.btnSell.UseVisualStyleBackColor = true;
            this.btnSell.Click += new System.EventHandler(this.btnSell_Click);
            // 
            // btnBuy
            // 
            this.btnBuy.Location = new System.Drawing.Point(13, 209);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(75, 23);
            this.btnBuy.TabIndex = 16;
            this.btnBuy.Text = "買進";
            this.btnBuy.UseVisualStyleBackColor = true;
            this.btnBuy.Click += new System.EventHandler(this.btnBuy_Click);
            // 
            // cboManualOCType
            // 
            this.cboManualOCType.FormattingEnabled = true;
            this.cboManualOCType.Location = new System.Drawing.Point(67, 150);
            this.cboManualOCType.Name = "cboManualOCType";
            this.cboManualOCType.Size = new System.Drawing.Size(65, 20);
            this.cboManualOCType.TabIndex = 15;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(10, 156);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(29, 12);
            this.label22.TabIndex = 14;
            this.label22.Text = "倉別";
            // 
            // chkIntraday
            // 
            this.chkIntraday.AutoSize = true;
            this.chkIntraday.Location = new System.Drawing.Point(138, 152);
            this.chkIntraday.Name = "chkIntraday";
            this.chkIntraday.Size = new System.Drawing.Size(48, 16);
            this.chkIntraday.TabIndex = 13;
            this.chkIntraday.Text = "當沖";
            this.chkIntraday.UseVisualStyleBackColor = true;
            // 
            // chkMarketPrice
            // 
            this.chkMarketPrice.AutoSize = true;
            this.chkMarketPrice.Location = new System.Drawing.Point(138, 124);
            this.chkMarketPrice.Name = "chkMarketPrice";
            this.chkMarketPrice.Size = new System.Drawing.Size(48, 16);
            this.chkMarketPrice.TabIndex = 12;
            this.chkMarketPrice.Text = "市價";
            this.chkMarketPrice.UseVisualStyleBackColor = true;
            this.chkMarketPrice.CheckedChanged += new System.EventHandler(this.chkMarketPrice_CheckedChanged);
            // 
            // txtManualPrice
            // 
            this.txtManualPrice.Location = new System.Drawing.Point(67, 122);
            this.txtManualPrice.Name = "txtManualPrice";
            this.txtManualPrice.Size = new System.Drawing.Size(62, 22);
            this.txtManualPrice.TabIndex = 9;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(10, 128);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(41, 12);
            this.label21.TabIndex = 8;
            this.label21.Text = "委託價";
            // 
            // cboManualPutOrCall
            // 
            this.cboManualPutOrCall.FormattingEnabled = true;
            this.cboManualPutOrCall.Location = new System.Drawing.Point(66, 96);
            this.cboManualPutOrCall.Name = "cboManualPutOrCall";
            this.cboManualPutOrCall.Size = new System.Drawing.Size(121, 20);
            this.cboManualPutOrCall.TabIndex = 7;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(9, 102);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(44, 12);
            this.label20.TabIndex = 6;
            this.label20.Text = "買/賣權";
            // 
            // txtManualStrikePrice
            // 
            this.txtManualStrikePrice.Location = new System.Drawing.Point(66, 68);
            this.txtManualStrikePrice.Name = "txtManualStrikePrice";
            this.txtManualStrikePrice.Size = new System.Drawing.Size(120, 22);
            this.txtManualStrikePrice.TabIndex = 5;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(9, 74);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(41, 12);
            this.label19.TabIndex = 4;
            this.label19.Text = "履約價";
            // 
            // cboManualMonth
            // 
            this.cboManualMonth.FormattingEnabled = true;
            this.cboManualMonth.Location = new System.Drawing.Point(66, 42);
            this.cboManualMonth.Name = "cboManualMonth";
            this.cboManualMonth.Size = new System.Drawing.Size(121, 20);
            this.cboManualMonth.TabIndex = 3;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(9, 48);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(29, 12);
            this.label18.TabIndex = 2;
            this.label18.Text = "月份";
            // 
            // cboManualSymbolType
            // 
            this.cboManualSymbolType.FormattingEnabled = true;
            this.cboManualSymbolType.Location = new System.Drawing.Point(66, 15);
            this.cboManualSymbolType.Name = "cboManualSymbolType";
            this.cboManualSymbolType.Size = new System.Drawing.Size(121, 20);
            this.cboManualSymbolType.TabIndex = 1;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(7, 18);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 12);
            this.label17.TabIndex = 0;
            this.label17.Text = "商品類別";
            // 
            // gbStrategy
            // 
            this.gbStrategy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbStrategy.Controls.Add(this.btnSave);
            this.gbStrategy.Controls.Add(this.btnModify);
            this.gbStrategy.Controls.Add(this.btnDelete);
            this.gbStrategy.Controls.Add(this.btnAdd);
            this.gbStrategy.Controls.Add(this.panel1);
            this.gbStrategy.Controls.Add(this.tblStrategy);
            this.gbStrategy.Location = new System.Drawing.Point(217, 14);
            this.gbStrategy.Name = "gbStrategy";
            this.gbStrategy.Size = new System.Drawing.Size(498, 476);
            this.gbStrategy.TabIndex = 2;
            this.gbStrategy.TabStop = false;
            this.gbStrategy.Text = "策略設定";
            this.gbStrategy.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(345, 190);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "儲存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(139, 190);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(75, 23);
            this.btnModify.TabIndex = 7;
            this.btnModify.Text = "修改";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(240, 190);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "刪除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(42, 190);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "新增";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.txtSymbolSeq);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.chkExitSignal);
            this.panel1.Controls.Add(this.pnlOptions);
            this.panel1.Controls.Add(this.chkIsActive);
            this.panel1.Controls.Add(this.txtOrderVolume);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.pnlFutures);
            this.panel1.Controls.Add(this.cboPriceType);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cboSymbolType);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtStrategyName);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(6, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(486, 163);
            this.panel1.TabIndex = 4;
            // 
            // chkExitSignal
            // 
            this.chkExitSignal.AutoSize = true;
            this.chkExitSignal.Location = new System.Drawing.Point(76, 134);
            this.chkExitSignal.Name = "chkExitSignal";
            this.chkExitSignal.Size = new System.Drawing.Size(96, 16);
            this.chkExitSignal.TabIndex = 16;
            this.chkExitSignal.Text = "送出平倉訊號";
            this.chkExitSignal.UseVisualStyleBackColor = true;
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Location = new System.Drawing.Point(7, 134);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(72, 16);
            this.chkIsActive.TabIndex = 11;
            this.chkIsActive.Text = "啟動策略";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // txtOrderVolume
            // 
            this.txtOrderVolume.Location = new System.Drawing.Point(62, 78);
            this.txtOrderVolume.Name = "txtOrderVolume";
            this.txtOrderVolume.Size = new System.Drawing.Size(100, 22);
            this.txtOrderVolume.TabIndex = 10;
            this.txtOrderVolume.Text = "1";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 81);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 9;
            this.label13.Text = "下單倍數";
            // 
            // pnlFutures
            // 
            this.pnlFutures.Controls.Add(this.cboFuturesMonth);
            this.pnlFutures.Controls.Add(this.label14);
            this.pnlFutures.Controls.Add(this.chkDayTrade);
            this.pnlFutures.Controls.Add(this.txtSlippage);
            this.pnlFutures.Controls.Add(this.label7);
            this.pnlFutures.Location = new System.Drawing.Point(173, 8);
            this.pnlFutures.Name = "pnlFutures";
            this.pnlFutures.Size = new System.Drawing.Size(291, 91);
            this.pnlFutures.TabIndex = 6;
            // 
            // cboFuturesMonth
            // 
            this.cboFuturesMonth.FormattingEnabled = true;
            this.cboFuturesMonth.Location = new System.Drawing.Point(41, 33);
            this.cboFuturesMonth.Name = "cboFuturesMonth";
            this.cboFuturesMonth.Size = new System.Drawing.Size(100, 20);
            this.cboFuturesMonth.TabIndex = 7;
            // 
            // pnlOptions
            // 
            this.pnlOptions.Controls.Add(this.cboPriceZone);
            this.pnlOptions.Controls.Add(this.label3);
            this.pnlOptions.Controls.Add(this.cboOptionsMonth);
            this.pnlOptions.Controls.Add(this.label1);
            this.pnlOptions.Controls.Add(this.txtOptionsSlippage);
            this.pnlOptions.Controls.Add(this.label2);
            this.pnlOptions.Controls.Add(this.cboExecutePrice);
            this.pnlOptions.Controls.Add(this.label9);
            this.pnlOptions.Controls.Add(this.cboOptionsSide);
            this.pnlOptions.Controls.Add(this.label8);
            this.pnlOptions.Location = new System.Drawing.Point(173, 8);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Size = new System.Drawing.Size(291, 110);
            this.pnlOptions.TabIndex = 15;
            // 
            // cboOptionsMonth
            // 
            this.cboOptionsMonth.FormattingEnabled = true;
            this.cboOptionsMonth.Location = new System.Drawing.Point(53, 82);
            this.cboOptionsMonth.Name = "cboOptionsMonth";
            this.cboOptionsMonth.Size = new System.Drawing.Size(100, 20);
            this.cboOptionsMonth.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "月份";
            // 
            // txtOptionsSlippage
            // 
            this.txtOptionsSlippage.Location = new System.Drawing.Point(53, 56);
            this.txtOptionsSlippage.Name = "txtOptionsSlippage";
            this.txtOptionsSlippage.Size = new System.Drawing.Size(72, 22);
            this.txtOptionsSlippage.TabIndex = 9;
            this.txtOptionsSlippage.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "滑價";
            // 
            // cboExecutePrice
            // 
            this.cboExecutePrice.FormattingEnabled = true;
            this.cboExecutePrice.Location = new System.Drawing.Point(53, 33);
            this.cboExecutePrice.Name = "cboExecutePrice";
            this.cboExecutePrice.Size = new System.Drawing.Size(75, 20);
            this.cboExecutePrice.TabIndex = 6;
            this.cboExecutePrice.SelectedIndexChanged += new System.EventHandler(this.cboExecutePrice_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 5;
            this.label9.Text = "履約價";
            // 
            // cboOptionsSide
            // 
            this.cboOptionsSide.FormattingEnabled = true;
            this.cboOptionsSide.Location = new System.Drawing.Point(53, 7);
            this.cboOptionsSide.Name = "cboOptionsSide";
            this.cboOptionsSide.Size = new System.Drawing.Size(100, 20);
            this.cboOptionsSide.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "買賣別";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 36);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 12);
            this.label14.TabIndex = 6;
            this.label14.Text = "月份";
            // 
            // chkDayTrade
            // 
            this.chkDayTrade.AutoSize = true;
            this.chkDayTrade.Location = new System.Drawing.Point(8, 65);
            this.chkDayTrade.Name = "chkDayTrade";
            this.chkDayTrade.Size = new System.Drawing.Size(48, 16);
            this.chkDayTrade.TabIndex = 4;
            this.chkDayTrade.Text = "當沖";
            this.chkDayTrade.UseVisualStyleBackColor = true;
            // 
            // txtSlippage
            // 
            this.txtSlippage.Location = new System.Drawing.Point(41, 7);
            this.txtSlippage.Name = "txtSlippage";
            this.txtSlippage.Size = new System.Drawing.Size(72, 22);
            this.txtSlippage.TabIndex = 3;
            this.txtSlippage.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "滑價";
            // 
            // cboPriceType
            // 
            this.cboPriceType.FormattingEnabled = true;
            this.cboPriceType.Location = new System.Drawing.Point(62, 54);
            this.cboPriceType.Name = "cboPriceType";
            this.cboPriceType.Size = new System.Drawing.Size(100, 20);
            this.cboPriceType.TabIndex = 5;
            this.cboPriceType.SelectedIndexChanged += new System.EventHandler(this.cboPriceType_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "價格別";
            // 
            // cboSymbolType
            // 
            this.cboSymbolType.FormattingEnabled = true;
            this.cboSymbolType.Location = new System.Drawing.Point(62, 30);
            this.cboSymbolType.Name = "cboSymbolType";
            this.cboSymbolType.Size = new System.Drawing.Size(100, 20);
            this.cboSymbolType.TabIndex = 3;
            this.cboSymbolType.SelectedIndexChanged += new System.EventHandler(this.cboSymbolType_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "商品別";
            // 
            // txtStrategyName
            // 
            this.txtStrategyName.Location = new System.Drawing.Point(62, 5);
            this.txtStrategyName.Name = "txtStrategyName";
            this.txtStrategyName.Size = new System.Drawing.Size(100, 22);
            this.txtStrategyName.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "策略名稱";
            // 
            // tblStrategy
            // 
            this.tblStrategy.AllowUserToAddRows = false;
            this.tblStrategy.AllowUserToDeleteRows = false;
            this.tblStrategy.AllowUserToResizeRows = false;
            this.tblStrategy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tblStrategy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblStrategy.Location = new System.Drawing.Point(6, 218);
            this.tblStrategy.MultiSelect = false;
            this.tblStrategy.Name = "tblStrategy";
            this.tblStrategy.ReadOnly = true;
            this.tblStrategy.RowHeadersVisible = false;
            this.tblStrategy.RowTemplate.Height = 24;
            this.tblStrategy.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblStrategy.Size = new System.Drawing.Size(486, 252);
            this.tblStrategy.TabIndex = 3;
            this.tblStrategy.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblStrategy_CellClick);
            this.tblStrategy.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblStrategy_CellContentClick);
            // 
            // tabEquity
            // 
            this.tabEquity.Controls.Add(this.btnQueryTodayEquity);
            this.tabEquity.Controls.Add(this.cboEquityType);
            this.tabEquity.Controls.Add(this.tblTodayEquity);
            this.tabEquity.Location = new System.Drawing.Point(4, 21);
            this.tabEquity.Name = "tabEquity";
            this.tabEquity.Padding = new System.Windows.Forms.Padding(3);
            this.tabEquity.Size = new System.Drawing.Size(718, 490);
            this.tabEquity.TabIndex = 1;
            this.tabEquity.Text = "當日權益數";
            this.tabEquity.UseVisualStyleBackColor = true;
            // 
            // btnQueryTodayEquity
            // 
            this.btnQueryTodayEquity.Enabled = false;
            this.btnQueryTodayEquity.Location = new System.Drawing.Point(133, 5);
            this.btnQueryTodayEquity.Name = "btnQueryTodayEquity";
            this.btnQueryTodayEquity.Size = new System.Drawing.Size(75, 23);
            this.btnQueryTodayEquity.TabIndex = 4;
            this.btnQueryTodayEquity.Text = "查詢";
            this.btnQueryTodayEquity.UseVisualStyleBackColor = true;
            this.btnQueryTodayEquity.Click += new System.EventHandler(this.btnQueryTodayEquity_Click);
            // 
            // cboEquityType
            // 
            this.cboEquityType.FormattingEnabled = true;
            this.cboEquityType.Location = new System.Drawing.Point(6, 8);
            this.cboEquityType.Name = "cboEquityType";
            this.cboEquityType.Size = new System.Drawing.Size(121, 20);
            this.cboEquityType.TabIndex = 3;
            this.cboEquityType.SelectedIndexChanged += new System.EventHandler(this.cboEquityType_SelectedIndexChanged);
            // 
            // tblTodayEquity
            // 
            this.tblTodayEquity.AllowUserToAddRows = false;
            this.tblTodayEquity.AllowUserToDeleteRows = false;
            this.tblTodayEquity.AllowUserToResizeRows = false;
            this.tblTodayEquity.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tblTodayEquity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblTodayEquity.Location = new System.Drawing.Point(3, 34);
            this.tblTodayEquity.MultiSelect = false;
            this.tblTodayEquity.Name = "tblTodayEquity";
            this.tblTodayEquity.ReadOnly = true;
            this.tblTodayEquity.RowHeadersVisible = false;
            this.tblTodayEquity.RowTemplate.Height = 24;
            this.tblTodayEquity.Size = new System.Drawing.Size(707, 435);
            this.tblTodayEquity.TabIndex = 2;
            // 
            // cboPriceZone
            // 
            this.cboPriceZone.FormattingEnabled = true;
            this.cboPriceZone.Location = new System.Drawing.Point(175, 30);
            this.cboPriceZone.Name = "cboPriceZone";
            this.cboPriceZone.Size = new System.Drawing.Size(75, 20);
            this.cboPriceZone.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(140, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "檔次";
            // 
            // txtSymbolSeq
            // 
            this.txtSymbolSeq.Location = new System.Drawing.Point(62, 103);
            this.txtSymbolSeq.Name = "txtSymbolSeq";
            this.txtSymbolSeq.Size = new System.Drawing.Size(100, 22);
            this.txtSymbolSeq.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 106);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 17;
            this.label10.Text = "商品序";
            // 
            // AutoTradeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 515);
            this.Controls.Add(this.tabAPI);
            this.Name = "AutoTradeForm";
            this.Text = "API下單";
            this.tabAPI.ResumeLayout(false);
            this.tabAutoTrade.ResumeLayout(false);
            this.gbOrderStatus.ResumeLayout(false);
            this.gbDeal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblDeal)).EndInit();
            this.gbTrust.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblTrust)).EndInit();
            this.gbOpenPosition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblOpenPosition)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbManual.ResumeLayout(false);
            this.gbManual.PerformLayout();
            this.gbStrategy.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlFutures.ResumeLayout(false);
            this.pnlFutures.PerformLayout();
            this.pnlOptions.ResumeLayout(false);
            this.pnlOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblStrategy)).EndInit();
            this.tabEquity.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblTodayEquity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabAPI;
        private System.Windows.Forms.TabPage tabAutoTrade;
        private System.Windows.Forms.TabPage tabEquity;
        private System.Windows.Forms.DataGridView tblTodayEquity;
        private System.Windows.Forms.ComboBox cboEquityType;
        private System.Windows.Forms.GroupBox gbStrategy;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView tblStrategy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboSymbolType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtStrategyName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboPriceType;
        private System.Windows.Forms.Panel pnlFutures;
        private System.Windows.Forms.TextBox txtSlippage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtOrderVolume;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox chkDayTrade;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cboFuturesMonth;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnQueryTodayEquity;
        private System.Windows.Forms.GroupBox gbOrderStatus;
        private System.Windows.Forms.GroupBox gbDeal;
        private System.Windows.Forms.DataGridView tblDeal;
        private System.Windows.Forms.GroupBox gbTrust;
        private System.Windows.Forms.DataGridView tblTrust;
        private System.Windows.Forms.GroupBox gbOpenPosition;
        private System.Windows.Forms.DataGridView tblOpenPosition;
        private System.Windows.Forms.GroupBox gbManual;
        private System.Windows.Forms.ComboBox cboManualSymbolType;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cboManualMonth;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cboManualPutOrCall;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtManualStrikePrice;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.CheckBox chkMarketPrice;
        private System.Windows.Forms.TextBox txtManualPrice;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cboManualOCType;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.CheckBox chkIntraday;
        private System.Windows.Forms.Button btnSell;
        private System.Windows.Forms.Button btnBuy;
        private System.Windows.Forms.TextBox txtManualVol;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDisplayStrategySetup;
        private System.Windows.Forms.Button btnAllExit;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel pnlOptions;
        private System.Windows.Forms.ComboBox cboOptionsMonth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOptionsSlippage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboExecutePrice;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboOptionsSide;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkExitSignal;
        private System.Windows.Forms.ComboBox cboPriceZone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSymbolSeq;
        private System.Windows.Forms.Label label10;

    }
}