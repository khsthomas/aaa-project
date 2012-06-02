namespace AAA.TradingSystem
{
    partial class BasicDataGetterForm
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
            this.tabDownload = new System.Windows.Forms.TabPage();
            this.wbDownload = new System.Windows.Forms.WebBrowser();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.tabGenerate = new System.Windows.Forms.TabPage();
            this.tblDividendData = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtStartYear = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtForwardDays = new System.Windows.Forms.TextBox();
            this.rbBackDays = new System.Windows.Forms.RadioButton();
            this.rbStartDate = new System.Windows.Forms.RadioButton();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBackDays = new System.Windows.Forms.TextBox();
            this.dtpExportStartDate = new System.Windows.Forms.DateTimePicker();
            this.tabFunction.SuspendLayout();
            this.tabDownload.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabGenerate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblDividendData)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabFunction
            // 
            this.tabFunction.Controls.Add(this.tabDownload);
            this.tabFunction.Controls.Add(this.tabGenerate);
            this.tabFunction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabFunction.Location = new System.Drawing.Point(0, 0);
            this.tabFunction.Name = "tabFunction";
            this.tabFunction.SelectedIndex = 0;
            this.tabFunction.Size = new System.Drawing.Size(728, 345);
            this.tabFunction.TabIndex = 0;
            // 
            // tabDownload
            // 
            this.tabDownload.Controls.Add(this.wbDownload);
            this.tabDownload.Controls.Add(this.groupBox1);
            this.tabDownload.Location = new System.Drawing.Point(4, 21);
            this.tabDownload.Name = "tabDownload";
            this.tabDownload.Padding = new System.Windows.Forms.Padding(3);
            this.tabDownload.Size = new System.Drawing.Size(720, 320);
            this.tabDownload.TabIndex = 0;
            this.tabDownload.Text = "資料下載";
            this.tabDownload.UseVisualStyleBackColor = true;
            // 
            // wbDownload
            // 
            this.wbDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.wbDownload.Location = new System.Drawing.Point(8, 85);
            this.wbDownload.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbDownload.Name = "wbDownload";
            this.wbDownload.Size = new System.Drawing.Size(704, 236);
            this.wbDownload.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dtpEndDate);
            this.groupBox1.Controls.Add(this.dtpStartDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnImport);
            this.groupBox1.Location = new System.Drawing.Point(8, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(704, 79);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "日期設定";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(75, 45);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(122, 22);
            this.dtpEndDate.TabIndex = 4;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(75, 17);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(122, 22);
            this.dtpStartDate.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "結束日期";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "開始日期";
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(203, 44);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 0;
            this.btnImport.Text = "匯入資料";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // tabGenerate
            // 
            this.tabGenerate.Controls.Add(this.tblDividendData);
            this.tabGenerate.Controls.Add(this.groupBox2);
            this.tabGenerate.Location = new System.Drawing.Point(4, 21);
            this.tabGenerate.Name = "tabGenerate";
            this.tabGenerate.Padding = new System.Windows.Forms.Padding(3);
            this.tabGenerate.Size = new System.Drawing.Size(720, 320);
            this.tabGenerate.TabIndex = 1;
            this.tabGenerate.Text = "資料匯出";
            this.tabGenerate.UseVisualStyleBackColor = true;
            // 
            // tblDividendData
            // 
            this.tblDividendData.AllowUserToAddRows = false;
            this.tblDividendData.AllowUserToDeleteRows = false;
            this.tblDividendData.AllowUserToResizeRows = false;
            this.tblDividendData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tblDividendData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblDividendData.Location = new System.Drawing.Point(8, 140);
            this.tblDividendData.Name = "tblDividendData";
            this.tblDividendData.ReadOnly = true;
            this.tblDividendData.RowHeadersVisible = false;
            this.tblDividendData.RowTemplate.Height = 24;
            this.tblDividendData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblDividendData.Size = new System.Drawing.Size(704, 172);
            this.tblDividendData.TabIndex = 1;
            this.tblDividendData.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblDividendData_CellContentDoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtStartYear);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtForwardDays);
            this.groupBox2.Controls.Add(this.rbBackDays);
            this.groupBox2.Controls.Add(this.rbStartDate);
            this.groupBox2.Controls.Add(this.btnCalculate);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtBackDays);
            this.groupBox2.Controls.Add(this.dtpExportStartDate);
            this.groupBox2.Location = new System.Drawing.Point(8, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(704, 128);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "匯出設定";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "開始年度";
            // 
            // txtStartYear
            // 
            this.txtStartYear.Location = new System.Drawing.Point(105, 14);
            this.txtStartYear.Name = "txtStartYear";
            this.txtStartYear.Size = new System.Drawing.Size(79, 22);
            this.txtStartYear.TabIndex = 11;
            this.txtStartYear.Text = "2011";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "除權後天數";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(190, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "交易日";
            // 
            // txtForwardDays
            // 
            this.txtForwardDays.Location = new System.Drawing.Point(105, 99);
            this.txtForwardDays.Name = "txtForwardDays";
            this.txtForwardDays.Size = new System.Drawing.Size(79, 22);
            this.txtForwardDays.TabIndex = 8;
            this.txtForwardDays.Text = "30";
            // 
            // rbBackDays
            // 
            this.rbBackDays.AutoSize = true;
            this.rbBackDays.Location = new System.Drawing.Point(6, 72);
            this.rbBackDays.Name = "rbBackDays";
            this.rbBackDays.Size = new System.Drawing.Size(71, 16);
            this.rbBackDays.TabIndex = 7;
            this.rbBackDays.Text = "前推天數";
            this.rbBackDays.UseVisualStyleBackColor = true;
            this.rbBackDays.CheckedChanged += new System.EventHandler(this.rbBackDays_CheckedChanged);
            // 
            // rbStartDate
            // 
            this.rbStartDate.AutoSize = true;
            this.rbStartDate.Checked = true;
            this.rbStartDate.Location = new System.Drawing.Point(7, 45);
            this.rbStartDate.Name = "rbStartDate";
            this.rbStartDate.Size = new System.Drawing.Size(71, 16);
            this.rbStartDate.TabIndex = 6;
            this.rbStartDate.TabStop = true;
            this.rbStartDate.Text = "開始日期";
            this.rbStartDate.UseVisualStyleBackColor = true;
            this.rbStartDate.CheckedChanged += new System.EventHandler(this.rbStartDate_CheckedChanged);
            // 
            // btnCalculate
            // 
            this.btnCalculate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCalculate.Location = new System.Drawing.Point(283, 99);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(75, 23);
            this.btnCalculate.TabIndex = 5;
            this.btnCalculate.Text = "計算";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(190, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "交易日";
            // 
            // txtBackDays
            // 
            this.txtBackDays.Enabled = false;
            this.txtBackDays.Location = new System.Drawing.Point(105, 71);
            this.txtBackDays.Name = "txtBackDays";
            this.txtBackDays.Size = new System.Drawing.Size(79, 22);
            this.txtBackDays.TabIndex = 3;
            this.txtBackDays.Text = "120";
            // 
            // dtpExportStartDate
            // 
            this.dtpExportStartDate.CustomFormat = "MM/dd";
            this.dtpExportStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpExportStartDate.Location = new System.Drawing.Point(105, 42);
            this.dtpExportStartDate.Name = "dtpExportStartDate";
            this.dtpExportStartDate.Size = new System.Drawing.Size(126, 22);
            this.dtpExportStartDate.TabIndex = 0;
            this.dtpExportStartDate.Value = new System.DateTime(2001, 4, 1, 0, 0, 0, 0);
            // 
            // BasicDataGetterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 345);
            this.Controls.Add(this.tabFunction);
            this.Name = "BasicDataGetterForm";
            this.Text = "基本資料下載";
            this.tabFunction.ResumeLayout(false);
            this.tabDownload.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabGenerate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblDividendData)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabFunction;
        private System.Windows.Forms.TabPage tabDownload;
        private System.Windows.Forms.WebBrowser wbDownload;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.TabPage tabGenerate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtBackDays;
        private System.Windows.Forms.DateTimePicker dtpExportStartDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.RadioButton rbBackDays;
        private System.Windows.Forms.RadioButton rbStartDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtForwardDays;
        private System.Windows.Forms.DataGridView tblDividendData;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtStartYear;

    }
}