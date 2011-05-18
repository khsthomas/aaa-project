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
            this.pChartContainer1 = new AAA.Chart.Component.PChartContainer();
            this.gbSetting = new System.Windows.Forms.GroupBox();
            this.txtSymbolId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDemo = new System.Windows.Forms.Button();
            this.btnStartDB = new System.Windows.Forms.Button();
            this.txtEndDate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStartDate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tUpdate = new System.Windows.Forms.Timer(this.components);
            this.lblUpdateCnt = new System.Windows.Forms.Label();
            this.gbSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // pChartContainer1
            // 
            this.pChartContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pChartContainer1.Location = new System.Drawing.Point(-2, 53);
            this.pChartContainer1.Name = "pChartContainer1";
            this.pChartContainer1.SetScale = 1F;
            this.pChartContainer1.Size = new System.Drawing.Size(754, 328);
            this.pChartContainer1.TabIndex = 2;
            this.pChartContainer1.XStartIndex = 0;
            this.pChartContainer1.YStartIndex = 0;
            // 
            // gbSetting
            // 
            this.gbSetting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSetting.Controls.Add(this.lblUpdateCnt);
            this.gbSetting.Controls.Add(this.txtSymbolId);
            this.gbSetting.Controls.Add(this.label3);
            this.gbSetting.Controls.Add(this.btnDemo);
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
            // txtSymbolId
            // 
            this.txtSymbolId.Location = new System.Drawing.Point(70, 16);
            this.txtSymbolId.Name = "txtSymbolId";
            this.txtSymbolId.Size = new System.Drawing.Size(113, 22);
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
            // btnDemo
            // 
            this.btnDemo.Location = new System.Drawing.Point(620, 16);
            this.btnDemo.Name = "btnDemo";
            this.btnDemo.Size = new System.Drawing.Size(78, 22);
            this.btnDemo.TabIndex = 5;
            this.btnDemo.Text = "功能展示";
            this.btnDemo.UseVisualStyleBackColor = true;
            this.btnDemo.Click += new System.EventHandler(this.btnDemo_Click);
            // 
            // btnStartDB
            // 
            this.btnStartDB.Location = new System.Drawing.Point(539, 16);
            this.btnStartDB.Name = "btnStartDB";
            this.btnStartDB.Size = new System.Drawing.Size(78, 22);
            this.btnStartDB.TabIndex = 4;
            this.btnStartDB.Text = "執行";
            this.btnStartDB.UseVisualStyleBackColor = true;
            this.btnStartDB.Click += new System.EventHandler(this.btnStartDB_Click);
            // 
            // txtEndDate
            // 
            this.txtEndDate.Location = new System.Drawing.Point(424, 16);
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Size = new System.Drawing.Size(100, 22);
            this.txtEndDate.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(368, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "結束時間";
            // 
            // txtStartDate
            // 
            this.txtStartDate.Location = new System.Drawing.Point(251, 16);
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.Size = new System.Drawing.Size(100, 22);
            this.txtStartDate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(195, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "開始時間";
            // 
            // tUpdate
            // 
            this.tUpdate.Interval = 60000;
            this.tUpdate.Tick += new System.EventHandler(this.tUpdate_Tick);
            // 
            // lblUpdateCnt
            // 
            this.lblUpdateCnt.AutoSize = true;
            this.lblUpdateCnt.Location = new System.Drawing.Point(704, 21);
            this.lblUpdateCnt.Name = "lblUpdateCnt";
            this.lblUpdateCnt.Size = new System.Drawing.Size(11, 12);
            this.lblUpdateCnt.TabIndex = 8;
            this.lblUpdateCnt.Text = "0";
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
        private System.Windows.Forms.Button btnDemo;
        private System.Windows.Forms.Button btnStartDB;
        private System.Windows.Forms.TextBox txtEndDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStartDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSymbolId;
        private System.Windows.Forms.Timer tUpdate;
        private System.Windows.Forms.Label lblUpdateCnt;
    }
}