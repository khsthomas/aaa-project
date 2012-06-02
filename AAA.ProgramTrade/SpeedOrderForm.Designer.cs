namespace AAA.ProgramTrade
{
    partial class SpeedOrderForm
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
            this.tblPrice = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVolume = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtTickVolume = new System.Windows.Forms.TextBox();
            this.chkAutoScroll = new System.Windows.Forms.CheckBox();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.txtCurrentPosition = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gbBracketSetting = new System.Windows.Forms.GroupBox();
            this.chkSellStopPrice = new System.Windows.Forms.CheckBox();
            this.chkBuyStopPrice = new System.Windows.Forms.CheckBox();
            this.txtSellStopPrice = new System.Windows.Forms.TextBox();
            this.txtBuyStopPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.udOrderLots = new System.Windows.Forms.NumericUpDown();
            this.tblCurrentPosition = new System.Windows.Forms.DataGridView();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboSymbolType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.cboMonth = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboPutOrCall = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboStrikePrice = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.chkDayTrade = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.tblPrice)).BeginInit();
            this.gbBracketSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udOrderLots)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblCurrentPosition)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblPrice
            // 
            this.tblPrice.AllowUserToAddRows = false;
            this.tblPrice.AllowUserToDeleteRows = false;
            this.tblPrice.AllowUserToResizeColumns = false;
            this.tblPrice.AllowUserToResizeRows = false;
            this.tblPrice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblPrice.Location = new System.Drawing.Point(3, 118);
            this.tblPrice.MultiSelect = false;
            this.tblPrice.Name = "tblPrice";
            this.tblPrice.ReadOnly = true;
            this.tblPrice.RowHeadersVisible = false;
            this.tblPrice.RowTemplate.Height = 24;
            this.tblPrice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.tblPrice.Size = new System.Drawing.Size(731, 350);
            this.tblPrice.TabIndex = 0;
            this.tblPrice.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblPrice_CellDoubleClick);
            this.tblPrice.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblPrice_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(152, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "成交價";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "成交量";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(298, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "單量";
            // 
            // txtVolume
            // 
            this.txtVolume.Location = new System.Drawing.Point(60, 34);
            this.txtVolume.Name = "txtVolume";
            this.txtVolume.ReadOnly = true;
            this.txtVolume.Size = new System.Drawing.Size(75, 22);
            this.txtVolume.TabIndex = 4;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(199, 34);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.ReadOnly = true;
            this.txtPrice.Size = new System.Drawing.Size(75, 22);
            this.txtPrice.TabIndex = 5;
            // 
            // txtTickVolume
            // 
            this.txtTickVolume.Location = new System.Drawing.Point(333, 34);
            this.txtTickVolume.Name = "txtTickVolume";
            this.txtTickVolume.ReadOnly = true;
            this.txtTickVolume.Size = new System.Drawing.Size(75, 22);
            this.txtTickVolume.TabIndex = 6;
            // 
            // chkAutoScroll
            // 
            this.chkAutoScroll.AutoSize = true;
            this.chkAutoScroll.Location = new System.Drawing.Point(3, 96);
            this.chkAutoScroll.Name = "chkAutoScroll";
            this.chkAutoScroll.Size = new System.Drawing.Size(96, 16);
            this.chkAutoScroll.TabIndex = 7;
            this.chkAutoScroll.Text = "報價自動置中";
            this.chkAutoScroll.UseVisualStyleBackColor = true;
            // 
            // lstLog
            // 
            this.lstLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lstLog.FormattingEnabled = true;
            this.lstLog.ItemHeight = 12;
            this.lstLog.Location = new System.Drawing.Point(740, 344);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(399, 256);
            this.lstLog.TabIndex = 8;
            // 
            // txtCurrentPosition
            // 
            this.txtCurrentPosition.Location = new System.Drawing.Point(60, 60);
            this.txtCurrentPosition.Name = "txtCurrentPosition";
            this.txtCurrentPosition.ReadOnly = true;
            this.txtCurrentPosition.Size = new System.Drawing.Size(75, 22);
            this.txtCurrentPosition.TabIndex = 10;
            this.txtCurrentPosition.Text = "0";
            this.txtCurrentPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "目前部位";
            // 
            // gbBracketSetting
            // 
            this.gbBracketSetting.Controls.Add(this.chkSellStopPrice);
            this.gbBracketSetting.Controls.Add(this.chkBuyStopPrice);
            this.gbBracketSetting.Controls.Add(this.txtSellStopPrice);
            this.gbBracketSetting.Controls.Add(this.txtBuyStopPrice);
            this.gbBracketSetting.Location = new System.Drawing.Point(740, 118);
            this.gbBracketSetting.Name = "gbBracketSetting";
            this.gbBracketSetting.Size = new System.Drawing.Size(399, 217);
            this.gbBracketSetting.TabIndex = 11;
            this.gbBracketSetting.TabStop = false;
            this.gbBracketSetting.Text = "預設絕對平倉點位";
            // 
            // chkSellStopPrice
            // 
            this.chkSellStopPrice.AutoSize = true;
            this.chkSellStopPrice.Location = new System.Drawing.Point(9, 22);
            this.chkSellStopPrice.Name = "chkSellStopPrice";
            this.chkSellStopPrice.Size = new System.Drawing.Size(120, 16);
            this.chkSellStopPrice.TabIndex = 5;
            this.chkSellStopPrice.Text = "空方絕對停損價位";
            this.chkSellStopPrice.UseVisualStyleBackColor = true;
            // 
            // chkBuyStopPrice
            // 
            this.chkBuyStopPrice.AutoSize = true;
            this.chkBuyStopPrice.Location = new System.Drawing.Point(9, 49);
            this.chkBuyStopPrice.Name = "chkBuyStopPrice";
            this.chkBuyStopPrice.Size = new System.Drawing.Size(120, 16);
            this.chkBuyStopPrice.TabIndex = 4;
            this.chkBuyStopPrice.Text = "多方絕對停損價位";
            this.chkBuyStopPrice.UseVisualStyleBackColor = true;
            // 
            // txtSellStopPrice
            // 
            this.txtSellStopPrice.Location = new System.Drawing.Point(130, 20);
            this.txtSellStopPrice.Name = "txtSellStopPrice";
            this.txtSellStopPrice.Size = new System.Drawing.Size(100, 22);
            this.txtSellStopPrice.TabIndex = 3;
            this.txtSellStopPrice.Text = "0";
            this.txtSellStopPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtBuyStopPrice
            // 
            this.txtBuyStopPrice.Location = new System.Drawing.Point(130, 47);
            this.txtBuyStopPrice.Name = "txtBuyStopPrice";
            this.txtBuyStopPrice.Size = new System.Drawing.Size(100, 22);
            this.txtBuyStopPrice.TabIndex = 2;
            this.txtBuyStopPrice.Text = "0";
            this.txtBuyStopPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(151, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "數量";
            // 
            // udOrderLots
            // 
            this.udOrderLots.Location = new System.Drawing.Point(199, 90);
            this.udOrderLots.Name = "udOrderLots";
            this.udOrderLots.Size = new System.Drawing.Size(75, 22);
            this.udOrderLots.TabIndex = 13;
            this.udOrderLots.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.udOrderLots.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tblCurrentPosition
            // 
            this.tblCurrentPosition.AllowUserToAddRows = false;
            this.tblCurrentPosition.AllowUserToDeleteRows = false;
            this.tblCurrentPosition.AllowUserToResizeColumns = false;
            this.tblCurrentPosition.AllowUserToResizeRows = false;
            this.tblCurrentPosition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblCurrentPosition.Location = new System.Drawing.Point(3, 474);
            this.tblCurrentPosition.MultiSelect = false;
            this.tblCurrentPosition.Name = "tblCurrentPosition";
            this.tblCurrentPosition.ReadOnly = true;
            this.tblCurrentPosition.RowHeadersVisible = false;
            this.tblCurrentPosition.RowTemplate.Height = 24;
            this.tblCurrentPosition.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.tblCurrentPosition.Size = new System.Drawing.Size(731, 118);
            this.tblCurrentPosition.TabIndex = 14;
            // 
            // txtAccount
            // 
            this.txtAccount.Location = new System.Drawing.Point(60, 6);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.ReadOnly = true;
            this.txtAccount.Size = new System.Drawing.Size(75, 22);
            this.txtAccount.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "帳號";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboStrikePrice);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.cboPutOrCall);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cboMonth);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cboYear);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cboSymbolType);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(430, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 100);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "下單商品設定";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "商品別";
            // 
            // cboSymbolType
            // 
            this.cboSymbolType.FormattingEnabled = true;
            this.cboSymbolType.Location = new System.Drawing.Point(54, 18);
            this.cboSymbolType.Name = "cboSymbolType";
            this.cboSymbolType.Size = new System.Drawing.Size(121, 20);
            this.cboSymbolType.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 18;
            this.label8.Text = "年度";
            // 
            // cboYear
            // 
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Location = new System.Drawing.Point(54, 44);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(121, 20);
            this.cboYear.TabIndex = 19;
            // 
            // cboMonth
            // 
            this.cboMonth.FormattingEnabled = true;
            this.cboMonth.Location = new System.Drawing.Point(54, 70);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(121, 20);
            this.cboMonth.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 20;
            this.label9.Text = "月份";
            // 
            // cboPutOrCall
            // 
            this.cboPutOrCall.FormattingEnabled = true;
            this.cboPutOrCall.Location = new System.Drawing.Point(230, 18);
            this.cboPutOrCall.Name = "cboPutOrCall";
            this.cboPutOrCall.Size = new System.Drawing.Size(121, 20);
            this.cboPutOrCall.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(182, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(22, 12);
            this.label10.TabIndex = 22;
            this.label10.Text = "P/C";
            // 
            // cboStrikePrice
            // 
            this.cboStrikePrice.FormattingEnabled = true;
            this.cboStrikePrice.Location = new System.Drawing.Point(230, 44);
            this.cboStrikePrice.Name = "cboStrikePrice";
            this.cboStrikePrice.Size = new System.Drawing.Size(121, 20);
            this.cboStrikePrice.TabIndex = 25;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(182, 49);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 24;
            this.label11.Text = "履約價";
            // 
            // chkDayTrade
            // 
            this.chkDayTrade.AutoSize = true;
            this.chkDayTrade.Location = new System.Drawing.Point(300, 91);
            this.chkDayTrade.Name = "chkDayTrade";
            this.chkDayTrade.Size = new System.Drawing.Size(48, 16);
            this.chkDayTrade.TabIndex = 18;
            this.chkDayTrade.Text = "當沖";
            this.chkDayTrade.UseVisualStyleBackColor = true;
            // 
            // SpeedOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 604);
            this.Controls.Add(this.chkDayTrade);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtAccount);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tblCurrentPosition);
            this.Controls.Add(this.udOrderLots);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.gbBracketSetting);
            this.Controls.Add(this.txtCurrentPosition);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lstLog);
            this.Controls.Add(this.chkAutoScroll);
            this.Controls.Add(this.txtTickVolume);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtVolume);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tblPrice);
            this.Name = "SpeedOrderForm";
            this.Text = "智慧閃電下單";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SpeedOrderForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.tblPrice)).EndInit();
            this.gbBracketSetting.ResumeLayout(false);
            this.gbBracketSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udOrderLots)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblCurrentPosition)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tblPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtVolume;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtTickVolume;
        private System.Windows.Forms.CheckBox chkAutoScroll;
        private System.Windows.Forms.ListBox lstLog;
        private System.Windows.Forms.TextBox txtCurrentPosition;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gbBracketSetting;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown udOrderLots;
        private System.Windows.Forms.TextBox txtSellStopPrice;
        private System.Windows.Forms.TextBox txtBuyStopPrice;
        private System.Windows.Forms.CheckBox chkSellStopPrice;
        private System.Windows.Forms.CheckBox chkBuyStopPrice;
        private System.Windows.Forms.DataGridView tblCurrentPosition;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboSymbolType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboYear;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboMonth;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboStrikePrice;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboPutOrCall;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkDayTrade;
    }
}