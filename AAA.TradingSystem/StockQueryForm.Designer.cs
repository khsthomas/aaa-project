namespace AAA.TradingSystem
{
    partial class StockQueryForm
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
            this.gbCriteria = new System.Windows.Forms.GroupBox();
            this.chkBCValue = new System.Windows.Forms.CheckBox();
            this.chkRatioDirection = new System.Windows.Forms.CheckBox();
            this.chkVolume = new System.Windows.Forms.CheckBox();
            this.chkDirection = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.cboBCValue = new System.Windows.Forms.ComboBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRatio = new System.Windows.Forms.MaskedTextBox();
            this.cboRatioDirection = new System.Windows.Forms.ComboBox();
            this.cboVolume = new System.Windows.Forms.ComboBox();
            this.cboDirection = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tblStock = new System.Windows.Forms.DataGridView();
            this.gbCriteria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblStock)).BeginInit();
            this.SuspendLayout();
            // 
            // gbCriteria
            // 
            this.gbCriteria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCriteria.Controls.Add(this.chkBCValue);
            this.gbCriteria.Controls.Add(this.chkRatioDirection);
            this.gbCriteria.Controls.Add(this.chkVolume);
            this.gbCriteria.Controls.Add(this.chkDirection);
            this.gbCriteria.Controls.Add(this.label7);
            this.gbCriteria.Controls.Add(this.txtDate);
            this.gbCriteria.Controls.Add(this.cboBCValue);
            this.gbCriteria.Controls.Add(this.btnQuery);
            this.gbCriteria.Controls.Add(this.label5);
            this.gbCriteria.Controls.Add(this.txtRatio);
            this.gbCriteria.Controls.Add(this.cboRatioDirection);
            this.gbCriteria.Controls.Add(this.cboVolume);
            this.gbCriteria.Controls.Add(this.cboDirection);
            this.gbCriteria.Controls.Add(this.label1);
            this.gbCriteria.Location = new System.Drawing.Point(7, 3);
            this.gbCriteria.Name = "gbCriteria";
            this.gbCriteria.Size = new System.Drawing.Size(413, 164);
            this.gbCriteria.TabIndex = 0;
            this.gbCriteria.TabStop = false;
            this.gbCriteria.Text = "條件";
            // 
            // chkBCValue
            // 
            this.chkBCValue.AutoSize = true;
            this.chkBCValue.Checked = true;
            this.chkBCValue.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBCValue.Location = new System.Drawing.Point(17, 139);
            this.chkBCValue.Name = "chkBCValue";
            this.chkBCValue.Size = new System.Drawing.Size(52, 16);
            this.chkBCValue.TabIndex = 18;
            this.chkBCValue.Text = "BC值";
            this.chkBCValue.UseVisualStyleBackColor = true;
            // 
            // chkRatioDirection
            // 
            this.chkRatioDirection.AutoSize = true;
            this.chkRatioDirection.Checked = true;
            this.chkRatioDirection.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRatioDirection.Location = new System.Drawing.Point(17, 112);
            this.chkRatioDirection.Name = "chkRatioDirection";
            this.chkRatioDirection.Size = new System.Drawing.Size(60, 16);
            this.chkRatioDirection.TabIndex = 17;
            this.chkRatioDirection.Text = "漲跌幅";
            this.chkRatioDirection.UseVisualStyleBackColor = true;
            // 
            // chkVolume
            // 
            this.chkVolume.AutoSize = true;
            this.chkVolume.Checked = true;
            this.chkVolume.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVolume.Location = new System.Drawing.Point(17, 82);
            this.chkVolume.Name = "chkVolume";
            this.chkVolume.Size = new System.Drawing.Size(60, 16);
            this.chkVolume.TabIndex = 16;
            this.chkVolume.Text = "成交量";
            this.chkVolume.UseVisualStyleBackColor = true;
            // 
            // chkDirection
            // 
            this.chkDirection.AutoSize = true;
            this.chkDirection.Checked = true;
            this.chkDirection.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDirection.Location = new System.Drawing.Point(17, 49);
            this.chkDirection.Name = "chkDirection";
            this.chkDirection.Size = new System.Drawing.Size(48, 16);
            this.chkDirection.TabIndex = 15;
            this.chkDirection.Text = "漲跌";
            this.chkDirection.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(133, 114);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = ">";
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(83, 15);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(119, 22);
            this.txtDate.TabIndex = 13;
            // 
            // cboBCValue
            // 
            this.cboBCValue.FormattingEnabled = true;
            this.cboBCValue.Items.AddRange(new object[] {
            "BC值高",
            "BC值低"});
            this.cboBCValue.Location = new System.Drawing.Point(83, 137);
            this.cboBCValue.Name = "cboBCValue";
            this.cboBCValue.Size = new System.Drawing.Size(121, 20);
            this.cboBCValue.TabIndex = 12;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(243, 135);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 10;
            this.btnQuery.Text = "選股";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(190, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "%";
            // 
            // txtRatio
            // 
            this.txtRatio.Location = new System.Drawing.Point(147, 110);
            this.txtRatio.Mask = "0.00";
            this.txtRatio.Name = "txtRatio";
            this.txtRatio.Size = new System.Drawing.Size(41, 22);
            this.txtRatio.TabIndex = 8;
            this.txtRatio.Text = "000";
            // 
            // cboRatioDirection
            // 
            this.cboRatioDirection.FormattingEnabled = true;
            this.cboRatioDirection.Items.AddRange(new object[] {
            "漲幅",
            "跌幅"});
            this.cboRatioDirection.Location = new System.Drawing.Point(83, 111);
            this.cboRatioDirection.Name = "cboRatioDirection";
            this.cboRatioDirection.Size = new System.Drawing.Size(44, 20);
            this.cboRatioDirection.TabIndex = 7;
            // 
            // cboVolume
            // 
            this.cboVolume.FormattingEnabled = true;
            this.cboVolume.Items.AddRange(new object[] {
            "量大於前一天",
            "量大於前三天",
            "量大於前五天",
            "量縮"});
            this.cboVolume.Location = new System.Drawing.Point(82, 78);
            this.cboVolume.Name = "cboVolume";
            this.cboVolume.Size = new System.Drawing.Size(121, 20);
            this.cboVolume.TabIndex = 5;
            // 
            // cboDirection
            // 
            this.cboDirection.FormattingEnabled = true;
            this.cboDirection.Items.AddRange(new object[] {
            "上漲",
            "下跌"});
            this.cboDirection.Location = new System.Drawing.Point(82, 45);
            this.cboDirection.Name = "cboDirection";
            this.cboDirection.Size = new System.Drawing.Size(121, 20);
            this.cboDirection.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "日期";
            // 
            // tblStock
            // 
            this.tblStock.AllowUserToAddRows = false;
            this.tblStock.AllowUserToDeleteRows = false;
            this.tblStock.AllowUserToResizeColumns = false;
            this.tblStock.AllowUserToResizeRows = false;
            this.tblStock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tblStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblStock.Location = new System.Drawing.Point(7, 173);
            this.tblStock.Name = "tblStock";
            this.tblStock.ReadOnly = true;
            this.tblStock.RowHeadersVisible = false;
            this.tblStock.RowTemplate.Height = 24;
            this.tblStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblStock.Size = new System.Drawing.Size(413, 307);
            this.tblStock.TabIndex = 1;
            this.tblStock.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblStock_CellDoubleClick);
            // 
            // StockQueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 492);
            this.Controls.Add(this.tblStock);
            this.Controls.Add(this.gbCriteria);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "StockQueryForm";
            this.Text = "條件選股";
            this.Load += new System.EventHandler(this.StockQueryForm_Load);
            this.gbCriteria.ResumeLayout(false);
            this.gbCriteria.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblStock)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCriteria;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboDirection;
        private System.Windows.Forms.ComboBox cboVolume;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox txtRatio;
        private System.Windows.Forms.ComboBox cboRatioDirection;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.ComboBox cboBCValue;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView tblStock;
        private System.Windows.Forms.CheckBox chkRatioDirection;
        private System.Windows.Forms.CheckBox chkVolume;
        private System.Windows.Forms.CheckBox chkDirection;
        private System.Windows.Forms.CheckBox chkBCValue;
    }
}