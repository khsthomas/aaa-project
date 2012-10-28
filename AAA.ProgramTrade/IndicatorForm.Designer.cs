namespace AAA.ProgramTrade
{
    partial class IndicatorForm
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
            this.tabFunction = new System.Windows.Forms.TabControl();
            this.pnlDataCompress = new System.Windows.Forms.TabPage();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.txtTransferSymbolId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.nudTimeInterval = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.cboTimeUnit = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlIndicator = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tblIndicators = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tblParameter = new System.Windows.Forms.DataGridView();
            this.btnLoad = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboIndicator = new System.Windows.Forms.ComboBox();
            this.cboBaseSymbolId = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.tabFunction.SuspendLayout();
            this.pnlDataCompress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeInterval)).BeginInit();
            this.pnlIndicator.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblIndicators)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblParameter)).BeginInit();
            this.SuspendLayout();
            // 
            // tabFunction
            // 
            this.tabFunction.Controls.Add(this.pnlDataCompress);
            this.tabFunction.Controls.Add(this.pnlIndicator);
            this.tabFunction.Location = new System.Drawing.Point(3, 30);
            this.tabFunction.Name = "tabFunction";
            this.tabFunction.SelectedIndex = 0;
            this.tabFunction.Size = new System.Drawing.Size(627, 385);
            this.tabFunction.TabIndex = 0;
            // 
            // pnlDataCompress
            // 
            this.pnlDataCompress.Controls.Add(this.btnTransfer);
            this.pnlDataCompress.Controls.Add(this.txtTransferSymbolId);
            this.pnlDataCompress.Controls.Add(this.label5);
            this.pnlDataCompress.Controls.Add(this.nudTimeInterval);
            this.pnlDataCompress.Controls.Add(this.label4);
            this.pnlDataCompress.Controls.Add(this.cboTimeUnit);
            this.pnlDataCompress.Controls.Add(this.label3);
            this.pnlDataCompress.Location = new System.Drawing.Point(4, 21);
            this.pnlDataCompress.Name = "pnlDataCompress";
            this.pnlDataCompress.Padding = new System.Windows.Forms.Padding(3);
            this.pnlDataCompress.Size = new System.Drawing.Size(619, 360);
            this.pnlDataCompress.TabIndex = 0;
            this.pnlDataCompress.Text = "資料轉換";
            this.pnlDataCompress.UseVisualStyleBackColor = true;
            // 
            // btnTransfer
            // 
            this.btnTransfer.Location = new System.Drawing.Point(272, 9);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(75, 23);
            this.btnTransfer.TabIndex = 15;
            this.btnTransfer.Text = "轉換";
            this.btnTransfer.UseVisualStyleBackColor = true;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // txtTransferSymbolId
            // 
            this.txtTransferSymbolId.Location = new System.Drawing.Point(84, 67);
            this.txtTransferSymbolId.Name = "txtTransferSymbolId";
            this.txtTransferSymbolId.Size = new System.Drawing.Size(152, 22);
            this.txtTransferSymbolId.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "轉換後名稱";
            // 
            // nudTimeInterval
            // 
            this.nudTimeInterval.Location = new System.Drawing.Point(72, 32);
            this.nudTimeInterval.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudTimeInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTimeInterval.Name = "nudTimeInterval";
            this.nudTimeInterval.Size = new System.Drawing.Size(164, 22);
            this.nudTimeInterval.TabIndex = 12;
            this.nudTimeInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudTimeInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "時間長度";
            // 
            // cboTimeUnit
            // 
            this.cboTimeUnit.FormattingEnabled = true;
            this.cboTimeUnit.Location = new System.Drawing.Point(72, 6);
            this.cboTimeUnit.Name = "cboTimeUnit";
            this.cboTimeUnit.Size = new System.Drawing.Size(164, 20);
            this.cboTimeUnit.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "時間單位";
            // 
            // pnlIndicator
            // 
            this.pnlIndicator.Controls.Add(this.groupBox1);
            this.pnlIndicator.Location = new System.Drawing.Point(4, 21);
            this.pnlIndicator.Name = "pnlIndicator";
            this.pnlIndicator.Padding = new System.Windows.Forms.Padding(3);
            this.pnlIndicator.Size = new System.Drawing.Size(619, 360);
            this.pnlIndicator.TabIndex = 1;
            this.pnlIndicator.Text = "指標運算";
            this.pnlIndicator.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tblIndicators);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.tblParameter);
            this.groupBox1.Controls.Add(this.btnLoad);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboIndicator);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(607, 347);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "指標列表";
            // 
            // tblIndicators
            // 
            this.tblIndicators.AllowUserToAddRows = false;
            this.tblIndicators.AllowUserToDeleteRows = false;
            this.tblIndicators.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tblIndicators.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblIndicators.Location = new System.Drawing.Point(6, 177);
            this.tblIndicators.Name = "tblIndicators";
            this.tblIndicators.RowHeadersVisible = false;
            this.tblIndicators.RowTemplate.Height = 24;
            this.tblIndicators.Size = new System.Drawing.Size(592, 164);
            this.tblIndicators.TabIndex = 8;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(467, 26);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "加入列表";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // tblParameter
            // 
            this.tblParameter.AllowUserToAddRows = false;
            this.tblParameter.AllowUserToDeleteRows = false;
            this.tblParameter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tblParameter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblParameter.Location = new System.Drawing.Point(6, 55);
            this.tblParameter.Name = "tblParameter";
            this.tblParameter.RowHeadersVisible = false;
            this.tblParameter.RowTemplate.Height = 24;
            this.tblParameter.Size = new System.Drawing.Size(592, 116);
            this.tblParameter.TabIndex = 4;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(386, 25);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "指標載入";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "指標";
            // 
            // cboIndicator
            // 
            this.cboIndicator.FormattingEnabled = true;
            this.cboIndicator.Location = new System.Drawing.Point(42, 28);
            this.cboIndicator.Name = "cboIndicator";
            this.cboIndicator.Size = new System.Drawing.Size(257, 20);
            this.cboIndicator.TabIndex = 0;
            this.cboIndicator.SelectedIndexChanged += new System.EventHandler(this.cboIndicator_SelectedIndexChanged);
            // 
            // cboBaseSymbolId
            // 
            this.cboBaseSymbolId.FormattingEnabled = true;
            this.cboBaseSymbolId.Location = new System.Drawing.Point(69, 4);
            this.cboBaseSymbolId.Name = "cboBaseSymbolId";
            this.cboBaseSymbolId.Size = new System.Drawing.Size(233, 20);
            this.cboBaseSymbolId.TabIndex = 8;
            this.cboBaseSymbolId.SelectedIndexChanged += new System.EventHandler(this.cboIndicator_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "基礎商品";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(308, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Text = "更新列表";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // IndicatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 427);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.cboBaseSymbolId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tabFunction);
            this.Name = "IndicatorForm";
            this.Text = "資料運算";
            this.tabFunction.ResumeLayout(false);
            this.pnlDataCompress.ResumeLayout(false);
            this.pnlDataCompress.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeInterval)).EndInit();
            this.pnlIndicator.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblIndicators)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblParameter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabFunction;
        private System.Windows.Forms.TabPage pnlDataCompress;
        private System.Windows.Forms.TabPage pnlIndicator;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView tblIndicators;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView tblParameter;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboIndicator;
        private System.Windows.Forms.NumericUpDown nudTimeInterval;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboTimeUnit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboBaseSymbolId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.TextBox txtTransferSymbolId;
        private System.Windows.Forms.Label label5;

    }
}