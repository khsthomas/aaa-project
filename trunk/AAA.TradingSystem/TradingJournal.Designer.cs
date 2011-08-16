namespace AAA.TradingSystem
{
    partial class TradingJournal
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtOthers = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtOpp = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbxDA = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxDC = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDayRange = new System.Windows.Forms.TextBox();
            this.cbxPossDayType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxOpenType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSymbolId = new System.Windows.Forms.TextBox();
            this.dgvDiary = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiary)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.txtOthers);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtOpp);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.cbxDA);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cbxDC);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtDayRange);
            this.panel1.Controls.Add(this.cbxPossDayType);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cbxOpenType);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtSymbolId);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(284, 426);
            this.panel1.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(105, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(110, 20);
            this.comboBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "Writer";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(201, 368);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 34;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // txtOthers
            // 
            this.txtOthers.Location = new System.Drawing.Point(105, 280);
            this.txtOthers.Multiline = true;
            this.txtOthers.Name = "txtOthers";
            this.txtOthers.Size = new System.Drawing.Size(171, 78);
            this.txtOthers.TabIndex = 33;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 280);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 12);
            this.label8.TabIndex = 32;
            this.label8.Text = "Others";
            // 
            // txtOpp
            // 
            this.txtOpp.Location = new System.Drawing.Point(105, 195);
            this.txtOpp.Multiline = true;
            this.txtOpp.Name = "txtOpp";
            this.txtOpp.Size = new System.Drawing.Size(171, 78);
            this.txtOpp.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 195);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 12);
            this.label7.TabIndex = 30;
            this.label7.Text = "Opportunity";
            // 
            // cbxDA
            // 
            this.cbxDA.FormattingEnabled = true;
            this.cbxDA.Items.AddRange(new object[] {
            "Good",
            "Bad"});
            this.cbxDA.Location = new System.Drawing.Point(105, 168);
            this.cbxDA.Name = "cbxDA";
            this.cbxDA.Size = new System.Drawing.Size(121, 20);
            this.cbxDA.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 12);
            this.label6.TabIndex = 28;
            this.label6.Text = "Market DA";
            // 
            // cbxDC
            // 
            this.cbxDC.FormattingEnabled = true;
            this.cbxDC.Items.AddRange(new object[] {
            "Higher",
            "Lower"});
            this.cbxDC.Location = new System.Drawing.Point(105, 141);
            this.cbxDC.Name = "cbxDC";
            this.cbxDC.Size = new System.Drawing.Size(121, 20);
            this.cbxDC.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 12);
            this.label5.TabIndex = 26;
            this.label5.Text = "Market DC";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 12);
            this.label4.TabIndex = 25;
            this.label4.Text = "Day Range";
            // 
            // txtDayRange
            // 
            this.txtDayRange.Location = new System.Drawing.Point(105, 112);
            this.txtDayRange.Name = "txtDayRange";
            this.txtDayRange.Size = new System.Drawing.Size(100, 22);
            this.txtDayRange.TabIndex = 24;
            // 
            // cbxPossDayType
            // 
            this.cbxPossDayType.FormattingEnabled = true;
            this.cbxPossDayType.Items.AddRange(new object[] {
            "Nontrend",
            "Normal",
            "Neutral-Center",
            "Normal Var.",
            "Netural-Extreme",
            "DD Trend",
            "Trend"});
            this.cbxPossDayType.Location = new System.Drawing.Point(105, 85);
            this.cbxPossDayType.Name = "cbxPossDayType";
            this.cbxPossDayType.Size = new System.Drawing.Size(121, 20);
            this.cbxPossDayType.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 12);
            this.label3.TabIndex = 22;
            this.label3.Text = "Possible Day Type";
            // 
            // cbxOpenType
            // 
            this.cbxOpenType.DisplayMember = "Open-Drive";
            this.cbxOpenType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxOpenType.FormattingEnabled = true;
            this.cbxOpenType.Items.AddRange(new object[] {
            "Open-Drive",
            "Open-Test-Drive",
            "Open-Reject-Reverse",
            "Open-Auction"});
            this.cbxOpenType.Location = new System.Drawing.Point(105, 58);
            this.cbxOpenType.Name = "cbxOpenType";
            this.cbxOpenType.Size = new System.Drawing.Size(121, 20);
            this.cbxOpenType.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 12);
            this.label2.TabIndex = 20;
            this.label2.Text = "Open Type";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 19;
            this.label9.Text = "Symbol";
            // 
            // txtSymbolId
            // 
            this.txtSymbolId.Location = new System.Drawing.Point(105, 29);
            this.txtSymbolId.Name = "txtSymbolId";
            this.txtSymbolId.Size = new System.Drawing.Size(100, 22);
            this.txtSymbolId.TabIndex = 18;
            // 
            // dgvDiary
            // 
            this.dgvDiary.AllowUserToAddRows = false;
            this.dgvDiary.AllowUserToDeleteRows = false;
            this.dgvDiary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDiary.Location = new System.Drawing.Point(284, 0);
            this.dgvDiary.Name = "dgvDiary";
            this.dgvDiary.ReadOnly = true;
            this.dgvDiary.RowTemplate.Height = 24;
            this.dgvDiary.Size = new System.Drawing.Size(693, 426);
            this.dgvDiary.TabIndex = 15;
            // 
            // TradingJournal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 426);
            this.Controls.Add(this.dgvDiary);
            this.Controls.Add(this.panel1);
            this.Name = "TradingJournal";
            this.Text = "交易日誌";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiary)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtOthers;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtOpp;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbxDA;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxDC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDayRange;
        private System.Windows.Forms.ComboBox cbxPossDayType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxOpenType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSymbolId;
        private System.Windows.Forms.DataGridView dgvDiary;
    }
}