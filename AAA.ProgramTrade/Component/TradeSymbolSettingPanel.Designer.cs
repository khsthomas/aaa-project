namespace AAA.ProgramTrade.Component
{
    partial class TradeSymbolSettingPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbStrategy = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSymbolSeq = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.chkExitSignal = new System.Windows.Forms.CheckBox();
            this.pnlOptions = new System.Windows.Forms.Panel();
            this.cboPriceZone = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboOptionsMonth = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOptionsSlippage = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboExecutePrice = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboOptionsSide = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.txtOrderVolume = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.pnlFutures = new System.Windows.Forms.Panel();
            this.cboFuturesMonth = new System.Windows.Forms.ComboBox();
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
            this.gbStrategy.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlOptions.SuspendLayout();
            this.pnlFutures.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblStrategy)).BeginInit();
            this.SuspendLayout();
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
            this.gbStrategy.Location = new System.Drawing.Point(8, 7);
            this.gbStrategy.Name = "gbStrategy";
            this.gbStrategy.Size = new System.Drawing.Size(485, 460);
            this.gbStrategy.TabIndex = 3;
            this.gbStrategy.TabStop = false;
            this.gbStrategy.Text = "交易商品設定";
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
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(139, 190);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(75, 23);
            this.btnModify.TabIndex = 7;
            this.btnModify.Text = "修改";
            this.btnModify.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(240, 190);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "刪除";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(42, 190);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "新增";
            this.btnAdd.UseVisualStyleBackColor = true;
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
            this.panel1.Size = new System.Drawing.Size(473, 163);
            this.panel1.TabIndex = 4;
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
            this.tblStrategy.Size = new System.Drawing.Size(473, 236);
            this.tblStrategy.TabIndex = 3;
            // 
            // TradeSymbolSettingPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbStrategy);
            this.Name = "TradeSymbolSettingPanel";
            this.Size = new System.Drawing.Size(500, 470);
            this.gbStrategy.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlOptions.ResumeLayout(false);
            this.pnlOptions.PerformLayout();
            this.pnlFutures.ResumeLayout(false);
            this.pnlFutures.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblStrategy)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbStrategy;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtSymbolSeq;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkExitSignal;
        private System.Windows.Forms.Panel pnlOptions;
        private System.Windows.Forms.ComboBox cboPriceZone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboOptionsMonth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOptionsSlippage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboExecutePrice;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboOptionsSide;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.TextBox txtOrderVolume;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel pnlFutures;
        private System.Windows.Forms.ComboBox cboFuturesMonth;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox chkDayTrade;
        private System.Windows.Forms.TextBox txtSlippage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboPriceType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboSymbolType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtStrategyName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView tblStrategy;
    }
}
