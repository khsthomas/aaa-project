namespace AAA.TradingSystem
{
    partial class DiaryForm
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
            this.txtSymbolId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxOpenType = new System.Windows.Forms.ComboBox();
            this.cbxPossDayType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDayRange = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxDC = new System.Windows.Forms.ComboBox();
            this.cbxDA = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtOpp = new System.Windows.Forms.TextBox();
            this.dgvDiary = new System.Windows.Forms.DataGridView();
            this.txtOthers = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiary)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSymbolId
            // 
            this.txtSymbolId.Location = new System.Drawing.Point(108, 5);
            this.txtSymbolId.Name = "txtSymbolId";
            this.txtSymbolId.Size = new System.Drawing.Size(100, 22);
            this.txtSymbolId.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Symbol";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Open Type";
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
            this.cbxOpenType.Location = new System.Drawing.Point(108, 34);
            this.cbxOpenType.Name = "cbxOpenType";
            this.cbxOpenType.Size = new System.Drawing.Size(121, 20);
            this.cbxOpenType.TabIndex = 3;
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
            this.cbxPossDayType.Location = new System.Drawing.Point(108, 61);
            this.cbxPossDayType.Name = "cbxPossDayType";
            this.cbxPossDayType.Size = new System.Drawing.Size(121, 20);
            this.cbxPossDayType.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Possible Day Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "Day Range";
            // 
            // txtDayRange
            // 
            this.txtDayRange.Location = new System.Drawing.Point(108, 88);
            this.txtDayRange.Name = "txtDayRange";
            this.txtDayRange.Size = new System.Drawing.Size(100, 22);
            this.txtDayRange.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "Market DC";
            // 
            // cbxDC
            // 
            this.cbxDC.FormattingEnabled = true;
            this.cbxDC.Items.AddRange(new object[] {
            "Higher",
            "Lower"});
            this.cbxDC.Location = new System.Drawing.Point(108, 117);
            this.cbxDC.Name = "cbxDC";
            this.cbxDC.Size = new System.Drawing.Size(121, 20);
            this.cbxDC.TabIndex = 9;
            // 
            // cbxDA
            // 
            this.cbxDA.FormattingEnabled = true;
            this.cbxDA.Items.AddRange(new object[] {
            "Good",
            "Bad"});
            this.cbxDA.Location = new System.Drawing.Point(108, 144);
            this.cbxDA.Name = "cbxDA";
            this.cbxDA.Size = new System.Drawing.Size(121, 20);
            this.cbxDA.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "Market DA";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 171);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "Opportunity";
            // 
            // txtOpp
            // 
            this.txtOpp.Location = new System.Drawing.Point(108, 171);
            this.txtOpp.Multiline = true;
            this.txtOpp.Name = "txtOpp";
            this.txtOpp.Size = new System.Drawing.Size(171, 78);
            this.txtOpp.TabIndex = 13;
            // 
            // dgvDiary
            // 
            this.dgvDiary.AllowUserToAddRows = false;
            this.dgvDiary.AllowUserToDeleteRows = false;
            this.dgvDiary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiary.Location = new System.Drawing.Point(289, 10);
            this.dgvDiary.Name = "dgvDiary";
            this.dgvDiary.ReadOnly = true;
            this.dgvDiary.RowTemplate.Height = 24;
            this.dgvDiary.Size = new System.Drawing.Size(407, 360);
            this.dgvDiary.TabIndex = 14;
            // 
            // txtOthers
            // 
            this.txtOthers.Location = new System.Drawing.Point(108, 256);
            this.txtOthers.Multiline = true;
            this.txtOthers.Name = "txtOthers";
            this.txtOthers.Size = new System.Drawing.Size(171, 78);
            this.txtOthers.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 256);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 12);
            this.label8.TabIndex = 15;
            this.label8.Text = "Others";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(204, 344);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // DiaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 371);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtOthers);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dgvDiary);
            this.Controls.Add(this.txtOpp);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbxDA);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbxDC);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDayRange);
            this.Controls.Add(this.cbxPossDayType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxOpenType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSymbolId);
            this.Name = "DiaryForm";
            this.Text = "Trading Journal";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiary)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSymbolId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxOpenType;
        private System.Windows.Forms.ComboBox cbxPossDayType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDayRange;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxDC;
        private System.Windows.Forms.ComboBox cbxDA;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtOpp;
        private System.Windows.Forms.DataGridView dgvDiary;
        private System.Windows.Forms.TextBox txtOthers;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSave;
    }
}