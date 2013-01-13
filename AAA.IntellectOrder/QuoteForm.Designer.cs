namespace AAA.IntellectOrder
{
    partial class QuoteForm
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
            this.gbAccountInfo = new System.Windows.Forms.GroupBox();
            this.txtStrikePrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboMonth = new System.Windows.Forms.ComboBox();
            this.cboSymbolType = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtAccountType = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.tblQuote = new System.Windows.Forms.DataGridView();
            this.tQuote = new System.Windows.Forms.Timer(this.components);
            this.lstPrice = new System.Windows.Forms.ListBox();
            this.tblQuoteList = new System.Windows.Forms.DataGridView();
            this.lstMatchItem = new System.Windows.Forms.ListBox();
            this.gbOrder = new System.Windows.Forms.GroupBox();
            this.txtCanOrderQty2 = new System.Windows.Forms.TextBox();
            this.txtCanOrderQty1 = new System.Windows.Forms.TextBox();
            this.btnOrder = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtOrderQty2 = new System.Windows.Forms.TextBox();
            this.cboOrderType2 = new System.Windows.Forms.ComboBox();
            this.cboTradeSymbol2 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtOrderQty1 = new System.Windows.Forms.TextBox();
            this.cboOrderType1 = new System.Windows.Forms.ComboBox();
            this.cboTradeSymbol1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.gbAccountInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblQuote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblQuoteList)).BeginInit();
            this.gbOrder.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbAccountInfo
            // 
            this.gbAccountInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbAccountInfo.Controls.Add(this.txtStrikePrice);
            this.gbAccountInfo.Controls.Add(this.label5);
            this.gbAccountInfo.Controls.Add(this.cboMonth);
            this.gbAccountInfo.Controls.Add(this.cboSymbolType);
            this.gbAccountInfo.Controls.Add(this.btnAdd);
            this.gbAccountInfo.Controls.Add(this.label4);
            this.gbAccountInfo.Controls.Add(this.label3);
            this.gbAccountInfo.Controls.Add(this.label2);
            this.gbAccountInfo.Controls.Add(this.label1);
            this.gbAccountInfo.Controls.Add(this.btnStop);
            this.gbAccountInfo.Controls.Add(this.btnStart);
            this.gbAccountInfo.Controls.Add(this.txtAccountType);
            this.gbAccountInfo.Controls.Add(this.txtPassword);
            this.gbAccountInfo.Controls.Add(this.txtAccount);
            this.gbAccountInfo.Location = new System.Drawing.Point(2, 3);
            this.gbAccountInfo.Name = "gbAccountInfo";
            this.gbAccountInfo.Size = new System.Drawing.Size(904, 80);
            this.gbAccountInfo.TabIndex = 0;
            this.gbAccountInfo.TabStop = false;
            this.gbAccountInfo.Text = "帳號資訊";
            // 
            // txtStrikePrice
            // 
            this.txtStrikePrice.Location = new System.Drawing.Point(280, 49);
            this.txtStrikePrice.Name = "txtStrikePrice";
            this.txtStrikePrice.Size = new System.Drawing.Size(59, 22);
            this.txtStrikePrice.TabIndex = 15;
            this.txtStrikePrice.Text = "7800";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(233, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "履約價";
            // 
            // cboMonth
            // 
            this.cboMonth.FormattingEnabled = true;
            this.cboMonth.Location = new System.Drawing.Point(132, 51);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(88, 20);
            this.cboMonth.TabIndex = 12;
            // 
            // cboSymbolType
            // 
            this.cboSymbolType.FormattingEnabled = true;
            this.cboSymbolType.Location = new System.Drawing.Point(64, 51);
            this.cboSymbolType.Name = "cboSymbolType";
            this.cboSymbolType.Size = new System.Drawing.Size(62, 20);
            this.cboSymbolType.TabIndex = 11;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(572, 17);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "新增";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "商品";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(317, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "密碼";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(114, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "帳號";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "帳戶類別";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(734, 17);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 5;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(653, 17);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "啟動";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtAccountType
            // 
            this.txtAccountType.Location = new System.Drawing.Point(64, 19);
            this.txtAccountType.Name = "txtAccountType";
            this.txtAccountType.Size = new System.Drawing.Size(35, 22);
            this.txtAccountType.TabIndex = 2;
            this.txtAccountType.Text = "F";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(352, 19);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(100, 22);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.Text = "12345678";
            // 
            // txtAccount
            // 
            this.txtAccount.Location = new System.Drawing.Point(149, 19);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(162, 22);
            this.txtAccount.TabIndex = 0;
            this.txtAccount.Text = "F0210000002525917";
            // 
            // tblQuote
            // 
            this.tblQuote.AllowUserToAddRows = false;
            this.tblQuote.AllowUserToDeleteRows = false;
            this.tblQuote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tblQuote.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblQuote.Location = new System.Drawing.Point(2, 208);
            this.tblQuote.Name = "tblQuote";
            this.tblQuote.ReadOnly = true;
            this.tblQuote.RowHeadersVisible = false;
            this.tblQuote.RowTemplate.Height = 24;
            this.tblQuote.Size = new System.Drawing.Size(904, 107);
            this.tblQuote.TabIndex = 1;
            // 
            // tQuote
            // 
            this.tQuote.Tick += new System.EventHandler(this.tQuote_Tick);
            // 
            // lstPrice
            // 
            this.lstPrice.FormattingEnabled = true;
            this.lstPrice.ItemHeight = 12;
            this.lstPrice.Location = new System.Drawing.Point(2, 321);
            this.lstPrice.Name = "lstPrice";
            this.lstPrice.Size = new System.Drawing.Size(184, 136);
            this.lstPrice.TabIndex = 2;
            // 
            // tblQuoteList
            // 
            this.tblQuoteList.AllowUserToAddRows = false;
            this.tblQuoteList.AllowUserToDeleteRows = false;
            this.tblQuoteList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblQuoteList.Location = new System.Drawing.Point(2, 89);
            this.tblQuoteList.Name = "tblQuoteList";
            this.tblQuoteList.ReadOnly = true;
            this.tblQuoteList.RowHeadersVisible = false;
            this.tblQuoteList.RowTemplate.Height = 24;
            this.tblQuoteList.Size = new System.Drawing.Size(339, 113);
            this.tblQuoteList.TabIndex = 3;
            // 
            // lstMatchItem
            // 
            this.lstMatchItem.FormattingEnabled = true;
            this.lstMatchItem.ItemHeight = 12;
            this.lstMatchItem.Location = new System.Drawing.Point(192, 321);
            this.lstMatchItem.Name = "lstMatchItem";
            this.lstMatchItem.Size = new System.Drawing.Size(184, 136);
            this.lstMatchItem.TabIndex = 4;
            // 
            // gbOrder
            // 
            this.gbOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbOrder.Controls.Add(this.txtCanOrderQty2);
            this.gbOrder.Controls.Add(this.txtCanOrderQty1);
            this.gbOrder.Controls.Add(this.btnOrder);
            this.gbOrder.Controls.Add(this.label8);
            this.gbOrder.Controls.Add(this.txtOrderQty2);
            this.gbOrder.Controls.Add(this.cboOrderType2);
            this.gbOrder.Controls.Add(this.cboTradeSymbol2);
            this.gbOrder.Controls.Add(this.label9);
            this.gbOrder.Controls.Add(this.label7);
            this.gbOrder.Controls.Add(this.txtOrderQty1);
            this.gbOrder.Controls.Add(this.cboOrderType1);
            this.gbOrder.Controls.Add(this.cboTradeSymbol1);
            this.gbOrder.Controls.Add(this.label6);
            this.gbOrder.Location = new System.Drawing.Point(385, 89);
            this.gbOrder.Name = "gbOrder";
            this.gbOrder.Size = new System.Drawing.Size(521, 113);
            this.gbOrder.TabIndex = 5;
            this.gbOrder.TabStop = false;
            this.gbOrder.Text = "下單";
            // 
            // txtCanOrderQty2
            // 
            this.txtCanOrderQty2.Location = new System.Drawing.Point(360, 45);
            this.txtCanOrderQty2.Name = "txtCanOrderQty2";
            this.txtCanOrderQty2.ReadOnly = true;
            this.txtCanOrderQty2.Size = new System.Drawing.Size(59, 22);
            this.txtCanOrderQty2.TabIndex = 25;
            this.txtCanOrderQty2.Text = "1";
            this.txtCanOrderQty2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCanOrderQty1
            // 
            this.txtCanOrderQty1.Location = new System.Drawing.Point(360, 17);
            this.txtCanOrderQty1.Name = "txtCanOrderQty1";
            this.txtCanOrderQty1.ReadOnly = true;
            this.txtCanOrderQty1.Size = new System.Drawing.Size(59, 22);
            this.txtCanOrderQty1.TabIndex = 24;
            this.txtCanOrderQty1.Text = "1";
            this.txtCanOrderQty1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnOrder
            // 
            this.btnOrder.Location = new System.Drawing.Point(48, 84);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(75, 23);
            this.btnOrder.TabIndex = 23;
            this.btnOrder.Text = "下單";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(254, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 22;
            this.label8.Text = "數量";
            // 
            // txtOrderQty2
            // 
            this.txtOrderQty2.Location = new System.Drawing.Point(295, 45);
            this.txtOrderQty2.Name = "txtOrderQty2";
            this.txtOrderQty2.Size = new System.Drawing.Size(59, 22);
            this.txtOrderQty2.TabIndex = 21;
            this.txtOrderQty2.Text = "1";
            this.txtOrderQty2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cboOrderType2
            // 
            this.cboOrderType2.FormattingEnabled = true;
            this.cboOrderType2.Location = new System.Drawing.Point(196, 47);
            this.cboOrderType2.Name = "cboOrderType2";
            this.cboOrderType2.Size = new System.Drawing.Size(52, 20);
            this.cboOrderType2.TabIndex = 20;
            // 
            // cboTradeSymbol2
            // 
            this.cboTradeSymbol2.FormattingEnabled = true;
            this.cboTradeSymbol2.Location = new System.Drawing.Point(48, 47);
            this.cboTradeSymbol2.Name = "cboTradeSymbol2";
            this.cboTradeSymbol2.Size = new System.Drawing.Size(142, 20);
            this.cboTradeSymbol2.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 12);
            this.label9.TabIndex = 18;
            this.label9.Text = "商品2";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(254, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 17;
            this.label7.Text = "數量";
            // 
            // txtOrderQty1
            // 
            this.txtOrderQty1.Location = new System.Drawing.Point(295, 17);
            this.txtOrderQty1.Name = "txtOrderQty1";
            this.txtOrderQty1.Size = new System.Drawing.Size(59, 22);
            this.txtOrderQty1.TabIndex = 16;
            this.txtOrderQty1.Text = "1";
            this.txtOrderQty1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cboOrderType1
            // 
            this.cboOrderType1.FormattingEnabled = true;
            this.cboOrderType1.Location = new System.Drawing.Point(196, 19);
            this.cboOrderType1.Name = "cboOrderType1";
            this.cboOrderType1.Size = new System.Drawing.Size(52, 20);
            this.cboOrderType1.TabIndex = 2;
            // 
            // cboTradeSymbol1
            // 
            this.cboTradeSymbol1.FormattingEnabled = true;
            this.cboTradeSymbol1.Location = new System.Drawing.Point(48, 19);
            this.cboTradeSymbol1.Name = "cboTradeSymbol1";
            this.cboTradeSymbol1.Size = new System.Drawing.Size(142, 20);
            this.cboTradeSymbol1.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "商品1";
            // 
            // QuoteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 458);
            this.Controls.Add(this.gbOrder);
            this.Controls.Add(this.lstMatchItem);
            this.Controls.Add(this.tblQuoteList);
            this.Controls.Add(this.lstPrice);
            this.Controls.Add(this.tblQuote);
            this.Controls.Add(this.gbAccountInfo);
            this.Name = "QuoteForm";
            this.Text = "期權下單系統 - 測試版";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QuoteForm_FormClosing);
            this.gbAccountInfo.ResumeLayout(false);
            this.gbAccountInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblQuote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblQuoteList)).EndInit();
            this.gbOrder.ResumeLayout(false);
            this.gbOrder.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbAccountInfo;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtAccountType;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.DataGridView tblQuote;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Timer tQuote;
        private System.Windows.Forms.ListBox lstPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cboSymbolType;
        private System.Windows.Forms.ComboBox cboMonth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtStrikePrice;
        private System.Windows.Forms.DataGridView tblQuoteList;
        private System.Windows.Forms.ListBox lstMatchItem;
        private System.Windows.Forms.GroupBox gbOrder;
        private System.Windows.Forms.ComboBox cboOrderType1;
        private System.Windows.Forms.ComboBox cboTradeSymbol1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtOrderQty2;
        private System.Windows.Forms.ComboBox cboOrderType2;
        private System.Windows.Forms.ComboBox cboTradeSymbol2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtOrderQty1;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.TextBox txtCanOrderQty2;
        private System.Windows.Forms.TextBox txtCanOrderQty1;
    }
}

