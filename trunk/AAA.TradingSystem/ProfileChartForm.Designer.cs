namespace AAA.TradingSystem
{
    partial class ProfileChartForm
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
            this.gbSetting = new System.Windows.Forms.GroupBox();
            this.btnStopUpdate = new System.Windows.Forms.Button();
            this.lblUpdateCnt = new System.Windows.Forms.Label();
            this.txtSymbolId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnStartDB = new System.Windows.Forms.Button();
            this.txtEndDate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStartDate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pChartContainer1 = new AAA.Chart.Component.PChartContainer();
            this.cbxUpdateTicks = new System.Windows.Forms.ComboBox();
            this.cbxUpdateSeconds = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gbSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSetting
            // 
            this.gbSetting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSetting.Controls.Add(this.label5);
            this.gbSetting.Controls.Add(this.label4);
            this.gbSetting.Controls.Add(this.cbxUpdateSeconds);
            this.gbSetting.Controls.Add(this.cbxUpdateTicks);
            this.gbSetting.Controls.Add(this.btnStopUpdate);
            this.gbSetting.Controls.Add(this.lblUpdateCnt);
            this.gbSetting.Controls.Add(this.txtSymbolId);
            this.gbSetting.Controls.Add(this.label3);
            this.gbSetting.Controls.Add(this.btnStartDB);
            this.gbSetting.Controls.Add(this.txtEndDate);
            this.gbSetting.Controls.Add(this.label2);
            this.gbSetting.Controls.Add(this.txtStartDate);
            this.gbSetting.Controls.Add(this.label1);
            this.gbSetting.Location = new System.Drawing.Point(2, 1);
            this.gbSetting.Name = "gbSetting";
            this.gbSetting.Size = new System.Drawing.Size(750, 46);
            this.gbSetting.TabIndex = 4;
            this.gbSetting.TabStop = false;
            this.gbSetting.Text = "設定";
            // 
            // btnStopUpdate
            // 
            this.btnStopUpdate.Enabled = false;
            this.btnStopUpdate.Location = new System.Drawing.Point(659, 16);
            this.btnStopUpdate.Name = "btnStopUpdate";
            this.btnStopUpdate.Size = new System.Drawing.Size(64, 22);
            this.btnStopUpdate.TabIndex = 9;
            this.btnStopUpdate.Text = "停止更新";
            this.btnStopUpdate.UseVisualStyleBackColor = true;
            this.btnStopUpdate.Click += new System.EventHandler(this.btnStopUpdate_Click);
            // 
            // lblUpdateCnt
            // 
            this.lblUpdateCnt.AutoSize = true;
            this.lblUpdateCnt.Location = new System.Drawing.Point(730, 21);
            this.lblUpdateCnt.Name = "lblUpdateCnt";
            this.lblUpdateCnt.Size = new System.Drawing.Size(11, 12);
            this.lblUpdateCnt.TabIndex = 8;
            this.lblUpdateCnt.Text = "0";
            // 
            // txtSymbolId
            // 
            this.txtSymbolId.Location = new System.Drawing.Point(70, 16);
            this.txtSymbolId.Name = "txtSymbolId";
            this.txtSymbolId.Size = new System.Drawing.Size(90, 22);
            this.txtSymbolId.TabIndex = 7;
            this.txtSymbolId.Text = "TWFE_TFHTX";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "商品名稱";
            // 
            // btnStartDB
            // 
            this.btnStartDB.Location = new System.Drawing.Point(593, 16);
            this.btnStartDB.Name = "btnStartDB";
            this.btnStartDB.Size = new System.Drawing.Size(64, 22);
            this.btnStartDB.TabIndex = 4;
            this.btnStartDB.Text = "執行";
            this.btnStartDB.UseVisualStyleBackColor = true;
            this.btnStartDB.Click += new System.EventHandler(this.btnStartDB_Click);
            // 
            // txtEndDate
            // 
            this.txtEndDate.Location = new System.Drawing.Point(371, 16);
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Size = new System.Drawing.Size(83, 22);
            this.txtEndDate.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(312, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "結束時間";
            // 
            // txtStartDate
            // 
            this.txtStartDate.Location = new System.Drawing.Point(220, 16);
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.Size = new System.Drawing.Size(84, 22);
            this.txtStartDate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(164, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "開始時間";
            // 
            // timer1
            // 
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pChartContainer1
            // 
            this.pChartContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pChartContainer1.Location = new System.Drawing.Point(-2, 53);
            this.pChartContainer1.Name = "pChartContainer1";
            this.pChartContainer1.SelectMode = 0;
            this.pChartContainer1.SetScale = 1F;
            this.pChartContainer1.Size = new System.Drawing.Size(754, 328);
            this.pChartContainer1.TabIndex = 2;
            this.pChartContainer1.XStartIndex = 0;
            this.pChartContainer1.YStartIndex = 0;
            // 
            // cbxUpdateTicks
            // 
            this.cbxUpdateTicks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUpdateTicks.FormattingEnabled = true;
            this.cbxUpdateTicks.Items.AddRange(new object[] {
            "30",
            "50",
            "100",
            "200"});
            this.cbxUpdateTicks.Location = new System.Drawing.Point(475, 16);
            this.cbxUpdateTicks.Name = "cbxUpdateTicks";
            this.cbxUpdateTicks.Size = new System.Drawing.Size(44, 20);
            this.cbxUpdateTicks.TabIndex = 10;
            this.cbxUpdateTicks.SelectedIndexChanged += new System.EventHandler(this.cbxUpdateTicks_SelectedIndexChanged);
            // 
            // cbxUpdateSeconds
            // 
            this.cbxUpdateSeconds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUpdateSeconds.FormattingEnabled = true;
            this.cbxUpdateSeconds.Items.AddRange(new object[] {
            "1",
            "3",
            "5",
            "10"});
            this.cbxUpdateSeconds.Location = new System.Drawing.Point(546, 16);
            this.cbxUpdateSeconds.Name = "cbxUpdateSeconds";
            this.cbxUpdateSeconds.Size = new System.Drawing.Size(44, 20);
            this.cbxUpdateSeconds.TabIndex = 11;
            this.cbxUpdateSeconds.SelectedIndexChanged += new System.EventHandler(this.cbxUpdateSeconds_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(460, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "T";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(528, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "S";
            // 
            // ProfileChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 380);
            this.Controls.Add(this.gbSetting);
            this.Controls.Add(this.pChartContainer1);
            this.Name = "ProfileChartForm";
            this.Text = "Market Profile Chart";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProfileChartForm_FormClosing);
            this.gbSetting.ResumeLayout(false);
            this.gbSetting.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private AAA.Chart.Component.PChartContainer pChartContainer1;
        private System.Windows.Forms.GroupBox gbSetting;
        private System.Windows.Forms.Button btnStartDB;
        private System.Windows.Forms.TextBox txtEndDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStartDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSymbolId;
        private System.Windows.Forms.Label lblUpdateCnt;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnStopUpdate;
        private System.Windows.Forms.ComboBox cbxUpdateTicks;
        private System.Windows.Forms.ComboBox cbxUpdateSeconds;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}