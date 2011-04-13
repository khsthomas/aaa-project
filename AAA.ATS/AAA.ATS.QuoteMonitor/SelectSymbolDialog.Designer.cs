namespace AAA.ATS.QuoteMonitor
{
    partial class SelectSymbolDialog
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.pnlSymbol = new System.Windows.Forms.TabPage();
            this.gbVolume = new System.Windows.Forms.GroupBox();
            this.rbTradeVolume = new System.Windows.Forms.RadioButton();
            this.rbTickCount = new System.Windows.Forms.RadioButton();
            this.gbCompression = new System.Windows.Forms.GroupBox();
            this.lblVolumeBar = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.txtIntraday = new System.Windows.Forms.TextBox();
            this.txtVolumeBar = new System.Windows.Forms.TextBox();
            this.rbMonthly = new System.Windows.Forms.RadioButton();
            this.rbWeekly = new System.Windows.Forms.RadioButton();
            this.rbDaily = new System.Windows.Forms.RadioButton();
            this.rbIntraday = new System.Windows.Forms.RadioButton();
            this.rbVolumeBar = new System.Windows.Forms.RadioButton();
            this.gbDateRange = new System.Windows.Forms.GroupBox();
            this.gbBetween = new System.Windows.Forms.GroupBox();
            this.gbDaysBack = new System.Windows.Forms.GroupBox();
            this.txtLastDate = new System.Windows.Forms.TextBox();
            this.lblLastDate = new System.Windows.Forms.Label();
            this.txtDaysBack = new System.Windows.Forms.TextBox();
            this.lblDaysBack = new System.Windows.Forms.Label();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.lblTo = new System.Windows.Forms.Label();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.gbDayRangeType = new System.Windows.Forms.GroupBox();
            this.rbDaysBack = new System.Windows.Forms.RadioButton();
            this.rbBetween = new System.Windows.Forms.RadioButton();
            this.gbSymbolSelection = new System.Windows.Forms.GroupBox();
            this.tblSymbolList = new System.Windows.Forms.DataGridView();
            this.txtSymbol = new System.Windows.Forms.TextBox();
            this.lblSymbol = new System.Windows.Forms.Label();
            this.pnlStyleScaling = new System.Windows.Forms.TabPage();
            this.gbStyle = new System.Windows.Forms.GroupBox();
            this.cboComponentWeight = new System.Windows.Forms.ComboBox();
            this.lblComponentWeight = new System.Windows.Forms.Label();
            this.cboComponentColor = new System.Windows.Forms.ComboBox();
            this.lblComponentColor = new System.Windows.Forms.Label();
            this.lstBarCompnoents = new System.Windows.Forms.ListBox();
            this.lblBarComponents = new System.Windows.Forms.Label();
            this.lstBarType = new System.Windows.Forms.ListBox();
            this.lblBarType = new System.Windows.Forms.Label();
            this.gbScaling = new System.Windows.Forms.GroupBox();
            this.gbScaleType = new System.Windows.Forms.GroupBox();
            this.rbScreen = new System.Windows.Forms.RadioButton();
            this.rbEntireDataSeries = new System.Windows.Forms.RadioButton();
            this.rbUserDefined = new System.Windows.Forms.RadioButton();
            this.lblMaximum = new System.Windows.Forms.Label();
            this.lblMinimum = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.gbAxisType = new System.Windows.Forms.GroupBox();
            this.rbLinear = new System.Windows.Forms.RadioButton();
            this.rbSemiLog = new System.Windows.Forms.RadioButton();
            this.gbProperties = new System.Windows.Forms.GroupBox();
            this.cboSubgraph = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.chkUseAsSymbolDefault = new System.Windows.Forms.CheckBox();
            this.chkUseStyleAsSymbolDefault = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.pnlSymbol.SuspendLayout();
            this.gbVolume.SuspendLayout();
            this.gbCompression.SuspendLayout();
            this.gbDateRange.SuspendLayout();
            this.gbBetween.SuspendLayout();
            this.gbDaysBack.SuspendLayout();
            this.gbDayRangeType.SuspendLayout();
            this.gbSymbolSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblSymbolList)).BeginInit();
            this.pnlStyleScaling.SuspendLayout();
            this.gbStyle.SuspendLayout();
            this.gbScaling.SuspendLayout();
            this.gbScaleType.SuspendLayout();
            this.gbAxisType.SuspendLayout();
            this.gbProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.pnlSymbol);
            this.tabControl1.Controls.Add(this.pnlStyleScaling);
            this.tabControl1.Location = new System.Drawing.Point(6, 7);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(603, 383);
            this.tabControl1.TabIndex = 0;
            // 
            // pnlSymbol
            // 
            this.pnlSymbol.Controls.Add(this.chkUseAsSymbolDefault);
            this.pnlSymbol.Controls.Add(this.gbProperties);
            this.pnlSymbol.Controls.Add(this.gbVolume);
            this.pnlSymbol.Controls.Add(this.gbCompression);
            this.pnlSymbol.Controls.Add(this.gbDateRange);
            this.pnlSymbol.Controls.Add(this.gbSymbolSelection);
            this.pnlSymbol.Location = new System.Drawing.Point(4, 21);
            this.pnlSymbol.Name = "pnlSymbol";
            this.pnlSymbol.Padding = new System.Windows.Forms.Padding(3);
            this.pnlSymbol.Size = new System.Drawing.Size(595, 358);
            this.pnlSymbol.TabIndex = 0;
            this.pnlSymbol.Text = "Symbol";
            this.pnlSymbol.UseVisualStyleBackColor = true;
            // 
            // gbVolume
            // 
            this.gbVolume.Controls.Add(this.rbTradeVolume);
            this.gbVolume.Controls.Add(this.rbTickCount);
            this.gbVolume.Location = new System.Drawing.Point(283, 6);
            this.gbVolume.Name = "gbVolume";
            this.gbVolume.Size = new System.Drawing.Size(306, 43);
            this.gbVolume.TabIndex = 5;
            this.gbVolume.TabStop = false;
            this.gbVolume.Text = "Volume";
            // 
            // rbTradeVolume
            // 
            this.rbTradeVolume.AutoSize = true;
            this.rbTradeVolume.Checked = true;
            this.rbTradeVolume.Location = new System.Drawing.Point(6, 20);
            this.rbTradeVolume.Name = "rbTradeVolume";
            this.rbTradeVolume.Size = new System.Drawing.Size(88, 16);
            this.rbTradeVolume.TabIndex = 1;
            this.rbTradeVolume.TabStop = true;
            this.rbTradeVolume.Text = "Trade volume";
            this.rbTradeVolume.UseVisualStyleBackColor = true;
            this.rbTradeVolume.Click += new System.EventHandler(this.rbVolumeType_Click);
            // 
            // rbTickCount
            // 
            this.rbTickCount.AutoSize = true;
            this.rbTickCount.Location = new System.Drawing.Point(100, 20);
            this.rbTickCount.Name = "rbTickCount";
            this.rbTickCount.Size = new System.Drawing.Size(73, 16);
            this.rbTickCount.TabIndex = 0;
            this.rbTickCount.Text = "Tick count";
            this.rbTickCount.UseVisualStyleBackColor = true;
            this.rbTickCount.Click += new System.EventHandler(this.rbVolumeType_Click);
            // 
            // gbCompression
            // 
            this.gbCompression.Controls.Add(this.lblVolumeBar);
            this.gbCompression.Controls.Add(this.lblMin);
            this.gbCompression.Controls.Add(this.txtIntraday);
            this.gbCompression.Controls.Add(this.txtVolumeBar);
            this.gbCompression.Controls.Add(this.rbMonthly);
            this.gbCompression.Controls.Add(this.rbWeekly);
            this.gbCompression.Controls.Add(this.rbDaily);
            this.gbCompression.Controls.Add(this.rbIntraday);
            this.gbCompression.Controls.Add(this.rbVolumeBar);
            this.gbCompression.Location = new System.Drawing.Point(283, 55);
            this.gbCompression.Name = "gbCompression";
            this.gbCompression.Size = new System.Drawing.Size(306, 157);
            this.gbCompression.TabIndex = 4;
            this.gbCompression.TabStop = false;
            this.gbCompression.Text = "Compression";
            // 
            // lblVolumeBar
            // 
            this.lblVolumeBar.AutoSize = true;
            this.lblVolumeBar.Location = new System.Drawing.Point(199, 19);
            this.lblVolumeBar.Name = "lblVolumeBar";
            this.lblVolumeBar.Size = new System.Drawing.Size(47, 12);
            this.lblVolumeBar.TabIndex = 12;
            this.lblVolumeBar.Text = "(in 100s)";
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.Location = new System.Drawing.Point(199, 44);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(24, 12);
            this.lblMin.TabIndex = 11;
            this.lblMin.Text = "Min";
            // 
            // txtIntraday
            // 
            this.txtIntraday.Location = new System.Drawing.Point(92, 40);
            this.txtIntraday.Name = "txtIntraday";
            this.txtIntraday.Size = new System.Drawing.Size(100, 22);
            this.txtIntraday.TabIndex = 7;
            this.txtIntraday.Text = "1";
            // 
            // txtVolumeBar
            // 
            this.txtVolumeBar.Location = new System.Drawing.Point(92, 16);
            this.txtVolumeBar.Name = "txtVolumeBar";
            this.txtVolumeBar.Size = new System.Drawing.Size(100, 22);
            this.txtVolumeBar.TabIndex = 6;
            this.txtVolumeBar.Text = "1";
            // 
            // rbMonthly
            // 
            this.rbMonthly.AutoSize = true;
            this.rbMonthly.Location = new System.Drawing.Point(6, 119);
            this.rbMonthly.Name = "rbMonthly";
            this.rbMonthly.Size = new System.Drawing.Size(63, 16);
            this.rbMonthly.TabIndex = 5;
            this.rbMonthly.Text = "Monthly";
            this.rbMonthly.UseVisualStyleBackColor = true;
            // 
            // rbWeekly
            // 
            this.rbWeekly.AutoSize = true;
            this.rbWeekly.Location = new System.Drawing.Point(6, 93);
            this.rbWeekly.Name = "rbWeekly";
            this.rbWeekly.Size = new System.Drawing.Size(59, 16);
            this.rbWeekly.TabIndex = 4;
            this.rbWeekly.Text = "Weekly";
            this.rbWeekly.UseVisualStyleBackColor = true;
            // 
            // rbDaily
            // 
            this.rbDaily.AutoSize = true;
            this.rbDaily.Checked = true;
            this.rbDaily.Location = new System.Drawing.Point(6, 67);
            this.rbDaily.Name = "rbDaily";
            this.rbDaily.Size = new System.Drawing.Size(48, 16);
            this.rbDaily.TabIndex = 3;
            this.rbDaily.TabStop = true;
            this.rbDaily.Text = "Daily";
            this.rbDaily.UseVisualStyleBackColor = true;
            // 
            // rbIntraday
            // 
            this.rbIntraday.AutoSize = true;
            this.rbIntraday.Location = new System.Drawing.Point(6, 41);
            this.rbIntraday.Name = "rbIntraday";
            this.rbIntraday.Size = new System.Drawing.Size(66, 16);
            this.rbIntraday.TabIndex = 2;
            this.rbIntraday.Text = "Intra-day";
            this.rbIntraday.UseVisualStyleBackColor = true;
            // 
            // rbVolumeBar
            // 
            this.rbVolumeBar.AutoSize = true;
            this.rbVolumeBar.Location = new System.Drawing.Point(6, 17);
            this.rbVolumeBar.Name = "rbVolumeBar";
            this.rbVolumeBar.Size = new System.Drawing.Size(80, 16);
            this.rbVolumeBar.TabIndex = 0;
            this.rbVolumeBar.Text = "Volume Bar";
            this.rbVolumeBar.UseVisualStyleBackColor = true;
            // 
            // gbDateRange
            // 
            this.gbDateRange.Controls.Add(this.gbBetween);
            this.gbDateRange.Controls.Add(this.gbDayRangeType);
            this.gbDateRange.Location = new System.Drawing.Point(6, 220);
            this.gbDateRange.Name = "gbDateRange";
            this.gbDateRange.Size = new System.Drawing.Size(271, 132);
            this.gbDateRange.TabIndex = 3;
            this.gbDateRange.TabStop = false;
            this.gbDateRange.Text = "Date range";
            // 
            // gbBetween
            // 
            this.gbBetween.Controls.Add(this.gbDaysBack);
            this.gbBetween.Controls.Add(this.txtTo);
            this.gbBetween.Controls.Add(this.lblTo);
            this.gbBetween.Controls.Add(this.txtFrom);
            this.gbBetween.Controls.Add(this.lblFrom);
            this.gbBetween.Location = new System.Drawing.Point(6, 60);
            this.gbBetween.Name = "gbBetween";
            this.gbBetween.Size = new System.Drawing.Size(256, 66);
            this.gbBetween.TabIndex = 1;
            this.gbBetween.TabStop = false;
            this.gbBetween.Text = "Between";
            // 
            // gbDaysBack
            // 
            this.gbDaysBack.Controls.Add(this.txtLastDate);
            this.gbDaysBack.Controls.Add(this.lblLastDate);
            this.gbDaysBack.Controls.Add(this.txtDaysBack);
            this.gbDaysBack.Controls.Add(this.lblDaysBack);
            this.gbDaysBack.Location = new System.Drawing.Point(0, 0);
            this.gbDaysBack.Name = "gbDaysBack";
            this.gbDaysBack.Size = new System.Drawing.Size(256, 66);
            this.gbDaysBack.TabIndex = 2;
            this.gbDaysBack.TabStop = false;
            this.gbDaysBack.Text = "Days Back";
            this.gbDaysBack.Visible = false;
            // 
            // txtLastDate
            // 
            this.txtLastDate.Location = new System.Drawing.Point(64, 39);
            this.txtLastDate.Name = "txtLastDate";
            this.txtLastDate.Size = new System.Drawing.Size(129, 22);
            this.txtLastDate.TabIndex = 3;
            // 
            // lblLastDate
            // 
            this.lblLastDate.AutoSize = true;
            this.lblLastDate.Location = new System.Drawing.Point(7, 44);
            this.lblLastDate.Name = "lblLastDate";
            this.lblLastDate.Size = new System.Drawing.Size(48, 12);
            this.lblLastDate.TabIndex = 2;
            this.lblLastDate.Text = "Last Date";
            // 
            // txtDaysBack
            // 
            this.txtDaysBack.Location = new System.Drawing.Point(64, 14);
            this.txtDaysBack.Name = "txtDaysBack";
            this.txtDaysBack.Size = new System.Drawing.Size(129, 22);
            this.txtDaysBack.TabIndex = 1;
            // 
            // lblDaysBack
            // 
            this.lblDaysBack.AutoSize = true;
            this.lblDaysBack.Location = new System.Drawing.Point(7, 19);
            this.lblDaysBack.Name = "lblDaysBack";
            this.lblDaysBack.Size = new System.Drawing.Size(53, 12);
            this.lblDaysBack.TabIndex = 0;
            this.lblDaysBack.Text = "Days back";
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(51, 39);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(143, 22);
            this.txtTo.TabIndex = 3;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(7, 44);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(18, 12);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "To";
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(51, 14);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(143, 22);
            this.txtFrom.TabIndex = 1;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(7, 19);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(30, 12);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "From";
            // 
            // gbDayRangeType
            // 
            this.gbDayRangeType.Controls.Add(this.rbDaysBack);
            this.gbDayRangeType.Controls.Add(this.rbBetween);
            this.gbDayRangeType.Location = new System.Drawing.Point(6, 16);
            this.gbDayRangeType.Name = "gbDayRangeType";
            this.gbDayRangeType.Size = new System.Drawing.Size(256, 41);
            this.gbDayRangeType.TabIndex = 0;
            this.gbDayRangeType.TabStop = false;
            this.gbDayRangeType.Text = "Type";
            // 
            // rbDaysBack
            // 
            this.rbDaysBack.AutoSize = true;
            this.rbDaysBack.Location = new System.Drawing.Point(107, 19);
            this.rbDaysBack.Name = "rbDaysBack";
            this.rbDaysBack.Size = new System.Drawing.Size(73, 16);
            this.rbDaysBack.TabIndex = 1;
            this.rbDaysBack.Text = "Days Back";
            this.rbDaysBack.UseVisualStyleBackColor = true;
            this.rbDaysBack.Click += new System.EventHandler(this.rbDaysRange_Click);
            // 
            // rbBetween
            // 
            this.rbBetween.AutoSize = true;
            this.rbBetween.Checked = true;
            this.rbBetween.Location = new System.Drawing.Point(7, 19);
            this.rbBetween.Name = "rbBetween";
            this.rbBetween.Size = new System.Drawing.Size(63, 16);
            this.rbBetween.TabIndex = 0;
            this.rbBetween.TabStop = true;
            this.rbBetween.Text = "Between";
            this.rbBetween.UseVisualStyleBackColor = true;
            this.rbBetween.Click += new System.EventHandler(this.rbDaysRange_Click);
            // 
            // gbSymbolSelection
            // 
            this.gbSymbolSelection.Controls.Add(this.tblSymbolList);
            this.gbSymbolSelection.Controls.Add(this.txtSymbol);
            this.gbSymbolSelection.Controls.Add(this.lblSymbol);
            this.gbSymbolSelection.Location = new System.Drawing.Point(6, 6);
            this.gbSymbolSelection.Name = "gbSymbolSelection";
            this.gbSymbolSelection.Size = new System.Drawing.Size(271, 206);
            this.gbSymbolSelection.TabIndex = 2;
            this.gbSymbolSelection.TabStop = false;
            this.gbSymbolSelection.Text = "Symbol Selection";
            // 
            // tblSymbolList
            // 
            this.tblSymbolList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblSymbolList.Location = new System.Drawing.Point(9, 49);
            this.tblSymbolList.Name = "tblSymbolList";
            this.tblSymbolList.RowTemplate.Height = 24;
            this.tblSymbolList.Size = new System.Drawing.Size(253, 150);
            this.tblSymbolList.TabIndex = 4;
            // 
            // txtSymbol
            // 
            this.txtSymbol.Location = new System.Drawing.Point(57, 21);
            this.txtSymbol.Name = "txtSymbol";
            this.txtSymbol.Size = new System.Drawing.Size(163, 22);
            this.txtSymbol.TabIndex = 3;
            // 
            // lblSymbol
            // 
            this.lblSymbol.AutoSize = true;
            this.lblSymbol.Location = new System.Drawing.Point(10, 24);
            this.lblSymbol.Name = "lblSymbol";
            this.lblSymbol.Size = new System.Drawing.Size(41, 12);
            this.lblSymbol.TabIndex = 2;
            this.lblSymbol.Text = "Symbol";
            // 
            // pnlStyleScaling
            // 
            this.pnlStyleScaling.Controls.Add(this.chkUseStyleAsSymbolDefault);
            this.pnlStyleScaling.Controls.Add(this.gbScaling);
            this.pnlStyleScaling.Controls.Add(this.gbStyle);
            this.pnlStyleScaling.Location = new System.Drawing.Point(4, 21);
            this.pnlStyleScaling.Name = "pnlStyleScaling";
            this.pnlStyleScaling.Padding = new System.Windows.Forms.Padding(3);
            this.pnlStyleScaling.Size = new System.Drawing.Size(595, 358);
            this.pnlStyleScaling.TabIndex = 1;
            this.pnlStyleScaling.Text = "Style/Scaling";
            this.pnlStyleScaling.UseVisualStyleBackColor = true;
            // 
            // gbStyle
            // 
            this.gbStyle.Controls.Add(this.cboComponentWeight);
            this.gbStyle.Controls.Add(this.lblComponentWeight);
            this.gbStyle.Controls.Add(this.cboComponentColor);
            this.gbStyle.Controls.Add(this.lblComponentColor);
            this.gbStyle.Controls.Add(this.lstBarCompnoents);
            this.gbStyle.Controls.Add(this.lblBarComponents);
            this.gbStyle.Controls.Add(this.lstBarType);
            this.gbStyle.Controls.Add(this.lblBarType);
            this.gbStyle.Location = new System.Drawing.Point(8, 9);
            this.gbStyle.Name = "gbStyle";
            this.gbStyle.Size = new System.Drawing.Size(148, 335);
            this.gbStyle.TabIndex = 8;
            this.gbStyle.TabStop = false;
            this.gbStyle.Text = "Style";
            // 
            // cboComponentWeight
            // 
            this.cboComponentWeight.FormattingEnabled = true;
            this.cboComponentWeight.Location = new System.Drawing.Point(10, 303);
            this.cboComponentWeight.Name = "cboComponentWeight";
            this.cboComponentWeight.Size = new System.Drawing.Size(121, 20);
            this.cboComponentWeight.TabIndex = 15;
            // 
            // lblComponentWeight
            // 
            this.lblComponentWeight.AutoSize = true;
            this.lblComponentWeight.Location = new System.Drawing.Point(8, 288);
            this.lblComponentWeight.Name = "lblComponentWeight";
            this.lblComponentWeight.Size = new System.Drawing.Size(100, 12);
            this.lblComponentWeight.TabIndex = 14;
            this.lblComponentWeight.Text = "Component weight :";
            // 
            // cboComponentColor
            // 
            this.cboComponentColor.FormattingEnabled = true;
            this.cboComponentColor.Location = new System.Drawing.Point(10, 261);
            this.cboComponentColor.Name = "cboComponentColor";
            this.cboComponentColor.Size = new System.Drawing.Size(121, 20);
            this.cboComponentColor.TabIndex = 13;
            // 
            // lblComponentColor
            // 
            this.lblComponentColor.AutoSize = true;
            this.lblComponentColor.Location = new System.Drawing.Point(8, 246);
            this.lblComponentColor.Name = "lblComponentColor";
            this.lblComponentColor.Size = new System.Drawing.Size(93, 12);
            this.lblComponentColor.TabIndex = 12;
            this.lblComponentColor.Text = "Component color :";
            // 
            // lstBarCompnoents
            // 
            this.lstBarCompnoents.FormattingEnabled = true;
            this.lstBarCompnoents.ItemHeight = 12;
            this.lstBarCompnoents.Location = new System.Drawing.Point(10, 179);
            this.lstBarCompnoents.Name = "lstBarCompnoents";
            this.lstBarCompnoents.Size = new System.Drawing.Size(120, 64);
            this.lstBarCompnoents.TabIndex = 11;
            // 
            // lblBarComponents
            // 
            this.lblBarComponents.AutoSize = true;
            this.lblBarComponents.Location = new System.Drawing.Point(8, 164);
            this.lblBarComponents.Name = "lblBarComponents";
            this.lblBarComponents.Size = new System.Drawing.Size(87, 12);
            this.lblBarComponents.TabIndex = 10;
            this.lblBarComponents.Text = "Bar components :";
            // 
            // lstBarType
            // 
            this.lstBarType.FormattingEnabled = true;
            this.lstBarType.ItemHeight = 12;
            this.lstBarType.Location = new System.Drawing.Point(10, 35);
            this.lstBarType.Name = "lstBarType";
            this.lstBarType.Size = new System.Drawing.Size(120, 124);
            this.lstBarType.TabIndex = 9;
            // 
            // lblBarType
            // 
            this.lblBarType.AutoSize = true;
            this.lblBarType.Location = new System.Drawing.Point(8, 20);
            this.lblBarType.Name = "lblBarType";
            this.lblBarType.Size = new System.Drawing.Size(51, 12);
            this.lblBarType.TabIndex = 8;
            this.lblBarType.Text = "Bar type :";
            // 
            // gbScaling
            // 
            this.gbScaling.Controls.Add(this.gbAxisType);
            this.gbScaling.Controls.Add(this.gbScaleType);
            this.gbScaling.Location = new System.Drawing.Point(171, 9);
            this.gbScaling.Name = "gbScaling";
            this.gbScaling.Size = new System.Drawing.Size(216, 258);
            this.gbScaling.TabIndex = 9;
            this.gbScaling.TabStop = false;
            this.gbScaling.Text = "Scaling";
            // 
            // gbScaleType
            // 
            this.gbScaleType.Controls.Add(this.textBox2);
            this.gbScaleType.Controls.Add(this.textBox1);
            this.gbScaleType.Controls.Add(this.lblMinimum);
            this.gbScaleType.Controls.Add(this.lblMaximum);
            this.gbScaleType.Controls.Add(this.rbUserDefined);
            this.gbScaleType.Controls.Add(this.rbEntireDataSeries);
            this.gbScaleType.Controls.Add(this.rbScreen);
            this.gbScaleType.Location = new System.Drawing.Point(6, 20);
            this.gbScaleType.Name = "gbScaleType";
            this.gbScaleType.Size = new System.Drawing.Size(200, 139);
            this.gbScaleType.TabIndex = 0;
            this.gbScaleType.TabStop = false;
            this.gbScaleType.Text = "Scale type";
            // 
            // rbScreen
            // 
            this.rbScreen.AutoSize = true;
            this.rbScreen.Checked = true;
            this.rbScreen.Location = new System.Drawing.Point(6, 21);
            this.rbScreen.Name = "rbScreen";
            this.rbScreen.Size = new System.Drawing.Size(54, 16);
            this.rbScreen.TabIndex = 0;
            this.rbScreen.TabStop = true;
            this.rbScreen.Text = "Screen";
            this.rbScreen.UseVisualStyleBackColor = true;
            // 
            // rbEntireDataSeries
            // 
            this.rbEntireDataSeries.AutoSize = true;
            this.rbEntireDataSeries.Location = new System.Drawing.Point(6, 43);
            this.rbEntireDataSeries.Name = "rbEntireDataSeries";
            this.rbEntireDataSeries.Size = new System.Drawing.Size(101, 16);
            this.rbEntireDataSeries.TabIndex = 1;
            this.rbEntireDataSeries.Text = "Entire data series";
            this.rbEntireDataSeries.UseVisualStyleBackColor = true;
            // 
            // rbUserDefined
            // 
            this.rbUserDefined.AutoSize = true;
            this.rbUserDefined.Location = new System.Drawing.Point(6, 65);
            this.rbUserDefined.Name = "rbUserDefined";
            this.rbUserDefined.Size = new System.Drawing.Size(82, 16);
            this.rbUserDefined.TabIndex = 2;
            this.rbUserDefined.Text = "User defined";
            this.rbUserDefined.UseVisualStyleBackColor = true;
            // 
            // lblMaximum
            // 
            this.lblMaximum.AutoSize = true;
            this.lblMaximum.Location = new System.Drawing.Point(25, 93);
            this.lblMaximum.Name = "lblMaximum";
            this.lblMaximum.Size = new System.Drawing.Size(53, 12);
            this.lblMaximum.TabIndex = 3;
            this.lblMaximum.Text = "Maximum";
            // 
            // lblMinimum
            // 
            this.lblMinimum.AutoSize = true;
            this.lblMinimum.Location = new System.Drawing.Point(25, 116);
            this.lblMinimum.Name = "lblMinimum";
            this.lblMinimum.Size = new System.Drawing.Size(51, 12);
            this.lblMinimum.TabIndex = 4;
            this.lblMinimum.Text = "Minimum";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(84, 90);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(84, 113);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 6;
            // 
            // gbAxisType
            // 
            this.gbAxisType.Controls.Add(this.rbSemiLog);
            this.gbAxisType.Controls.Add(this.rbLinear);
            this.gbAxisType.Location = new System.Drawing.Point(6, 165);
            this.gbAxisType.Name = "gbAxisType";
            this.gbAxisType.Size = new System.Drawing.Size(200, 68);
            this.gbAxisType.TabIndex = 1;
            this.gbAxisType.TabStop = false;
            this.gbAxisType.Text = "Axis type";
            // 
            // rbLinear
            // 
            this.rbLinear.AutoSize = true;
            this.rbLinear.Checked = true;
            this.rbLinear.Location = new System.Drawing.Point(7, 22);
            this.rbLinear.Name = "rbLinear";
            this.rbLinear.Size = new System.Drawing.Size(53, 16);
            this.rbLinear.TabIndex = 0;
            this.rbLinear.TabStop = true;
            this.rbLinear.Text = "Linear";
            this.rbLinear.UseVisualStyleBackColor = true;
            // 
            // rbSemiLog
            // 
            this.rbSemiLog.AutoSize = true;
            this.rbSemiLog.Location = new System.Drawing.Point(7, 44);
            this.rbSemiLog.Name = "rbSemiLog";
            this.rbSemiLog.Size = new System.Drawing.Size(69, 16);
            this.rbSemiLog.TabIndex = 1;
            this.rbSemiLog.Text = "Semi-Log";
            this.rbSemiLog.UseVisualStyleBackColor = true;
            // 
            // gbProperties
            // 
            this.gbProperties.Controls.Add(this.label1);
            this.gbProperties.Controls.Add(this.cboSubgraph);
            this.gbProperties.Location = new System.Drawing.Point(283, 220);
            this.gbProperties.Name = "gbProperties";
            this.gbProperties.Size = new System.Drawing.Size(306, 51);
            this.gbProperties.TabIndex = 6;
            this.gbProperties.TabStop = false;
            this.gbProperties.Text = "Properties";
            // 
            // cboSubgraph
            // 
            this.cboSubgraph.FormattingEnabled = true;
            this.cboSubgraph.Location = new System.Drawing.Point(71, 19);
            this.cboSubgraph.Name = "cboSubgraph";
            this.cboSubgraph.Size = new System.Drawing.Size(121, 20);
            this.cboSubgraph.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Subgraph";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(524, 396);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(441, 396);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // chkUseAsSymbolDefault
            // 
            this.chkUseAsSymbolDefault.AutoSize = true;
            this.chkUseAsSymbolDefault.Location = new System.Drawing.Point(283, 280);
            this.chkUseAsSymbolDefault.Name = "chkUseAsSymbolDefault";
            this.chkUseAsSymbolDefault.Size = new System.Drawing.Size(125, 16);
            this.chkUseAsSymbolDefault.TabIndex = 7;
            this.chkUseAsSymbolDefault.Text = "Use as symbol default";
            this.chkUseAsSymbolDefault.UseVisualStyleBackColor = true;
            // 
            // chkUseStyleAsSymbolDefault
            // 
            this.chkUseStyleAsSymbolDefault.AutoSize = true;
            this.chkUseStyleAsSymbolDefault.Location = new System.Drawing.Point(171, 274);
            this.chkUseStyleAsSymbolDefault.Name = "chkUseStyleAsSymbolDefault";
            this.chkUseStyleAsSymbolDefault.Size = new System.Drawing.Size(184, 16);
            this.chkUseStyleAsSymbolDefault.TabIndex = 10;
            this.chkUseStyleAsSymbolDefault.Text = "Use style/scaling as symbol default";
            this.chkUseStyleAsSymbolDefault.UseVisualStyleBackColor = true;
            // 
            // SelectSymbolDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 430);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tabControl1);
            this.Name = "SelectSymbolDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Symbol Configuration";
            this.TopMost = true;
            this.tabControl1.ResumeLayout(false);
            this.pnlSymbol.ResumeLayout(false);
            this.pnlSymbol.PerformLayout();
            this.gbVolume.ResumeLayout(false);
            this.gbVolume.PerformLayout();
            this.gbCompression.ResumeLayout(false);
            this.gbCompression.PerformLayout();
            this.gbDateRange.ResumeLayout(false);
            this.gbBetween.ResumeLayout(false);
            this.gbBetween.PerformLayout();
            this.gbDaysBack.ResumeLayout(false);
            this.gbDaysBack.PerformLayout();
            this.gbDayRangeType.ResumeLayout(false);
            this.gbDayRangeType.PerformLayout();
            this.gbSymbolSelection.ResumeLayout(false);
            this.gbSymbolSelection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblSymbolList)).EndInit();
            this.pnlStyleScaling.ResumeLayout(false);
            this.pnlStyleScaling.PerformLayout();
            this.gbStyle.ResumeLayout(false);
            this.gbStyle.PerformLayout();
            this.gbScaling.ResumeLayout(false);
            this.gbScaleType.ResumeLayout(false);
            this.gbScaleType.PerformLayout();
            this.gbAxisType.ResumeLayout(false);
            this.gbAxisType.PerformLayout();
            this.gbProperties.ResumeLayout(false);
            this.gbProperties.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage pnlSymbol;
        private System.Windows.Forms.TabPage pnlStyleScaling;
        private System.Windows.Forms.GroupBox gbSymbolSelection;
        private System.Windows.Forms.DataGridView tblSymbolList;
        private System.Windows.Forms.TextBox txtSymbol;
        private System.Windows.Forms.Label lblSymbol;
        private System.Windows.Forms.GroupBox gbDateRange;
        private System.Windows.Forms.GroupBox gbDayRangeType;
        private System.Windows.Forms.RadioButton rbDaysBack;
        private System.Windows.Forms.RadioButton rbBetween;
        private System.Windows.Forms.GroupBox gbBetween;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.GroupBox gbDaysBack;
        private System.Windows.Forms.TextBox txtLastDate;
        private System.Windows.Forms.Label lblLastDate;
        private System.Windows.Forms.TextBox txtDaysBack;
        private System.Windows.Forms.Label lblDaysBack;
        private System.Windows.Forms.GroupBox gbCompression;
        private System.Windows.Forms.RadioButton rbMonthly;
        private System.Windows.Forms.RadioButton rbWeekly;
        private System.Windows.Forms.RadioButton rbDaily;
        private System.Windows.Forms.RadioButton rbIntraday;
        private System.Windows.Forms.RadioButton rbVolumeBar;
        private System.Windows.Forms.GroupBox gbVolume;
        private System.Windows.Forms.RadioButton rbTradeVolume;
        private System.Windows.Forms.RadioButton rbTickCount;
        private System.Windows.Forms.TextBox txtIntraday;
        private System.Windows.Forms.TextBox txtVolumeBar;
        private System.Windows.Forms.Label lblVolumeBar;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.GroupBox gbStyle;
        private System.Windows.Forms.ComboBox cboComponentWeight;
        private System.Windows.Forms.Label lblComponentWeight;
        private System.Windows.Forms.ComboBox cboComponentColor;
        private System.Windows.Forms.Label lblComponentColor;
        private System.Windows.Forms.ListBox lstBarCompnoents;
        private System.Windows.Forms.Label lblBarComponents;
        private System.Windows.Forms.ListBox lstBarType;
        private System.Windows.Forms.Label lblBarType;
        private System.Windows.Forms.GroupBox gbScaling;
        private System.Windows.Forms.GroupBox gbScaleType;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblMinimum;
        private System.Windows.Forms.Label lblMaximum;
        private System.Windows.Forms.RadioButton rbUserDefined;
        private System.Windows.Forms.RadioButton rbEntireDataSeries;
        private System.Windows.Forms.RadioButton rbScreen;
        private System.Windows.Forms.GroupBox gbProperties;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboSubgraph;
        private System.Windows.Forms.GroupBox gbAxisType;
        private System.Windows.Forms.RadioButton rbSemiLog;
        private System.Windows.Forms.RadioButton rbLinear;
        private System.Windows.Forms.CheckBox chkUseAsSymbolDefault;
        private System.Windows.Forms.CheckBox chkUseStyleAsSymbolDefault;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}