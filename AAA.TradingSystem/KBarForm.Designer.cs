namespace AAA.TradingSystem
{
    partial class KBarForm
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
            this.pnlConfig = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtClose = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLow = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtHigh = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOpen = new System.Windows.Forms.TextBox();
            this.btnConfig = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cboFileType = new System.Windows.Forms.ComboBox();
            this.cboPeriod = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDisplay = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSymbolId = new System.Windows.Forms.TextBox();
            this.cpDatabase = new AAA.TeeChart.TeeChartPanel();
            this.cpText = new AAA.TeeChart.TeeChartPanel();
            this.cpExcel = new AAA.TeeChart.TeeChartPanel();
            this.signalPane = new AAA.TeeChart.SignalLightPane();
            this.txtSymbolName = new System.Windows.Forms.TextBox();
            this.pnlConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlConfig
            // 
            this.pnlConfig.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlConfig.Controls.Add(this.txtSymbolName);
            this.pnlConfig.Controls.Add(this.label7);
            this.pnlConfig.Controls.Add(this.txtClose);
            this.pnlConfig.Controls.Add(this.label6);
            this.pnlConfig.Controls.Add(this.txtLow);
            this.pnlConfig.Controls.Add(this.label5);
            this.pnlConfig.Controls.Add(this.txtHigh);
            this.pnlConfig.Controls.Add(this.label4);
            this.pnlConfig.Controls.Add(this.txtOpen);
            this.pnlConfig.Controls.Add(this.btnConfig);
            this.pnlConfig.Controls.Add(this.label3);
            this.pnlConfig.Controls.Add(this.cboFileType);
            this.pnlConfig.Controls.Add(this.cboPeriod);
            this.pnlConfig.Controls.Add(this.label2);
            this.pnlConfig.Controls.Add(this.btnDisplay);
            this.pnlConfig.Controls.Add(this.label1);
            this.pnlConfig.Controls.Add(this.txtSymbolId);
            this.pnlConfig.Location = new System.Drawing.Point(12, 12);
            this.pnlConfig.Name = "pnlConfig";
            this.pnlConfig.Size = new System.Drawing.Size(992, 42);
            this.pnlConfig.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(489, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 15;
            this.label7.Text = "收盤";
            // 
            // txtClose
            // 
            this.txtClose.Location = new System.Drawing.Point(524, 9);
            this.txtClose.Name = "txtClose";
            this.txtClose.ReadOnly = true;
            this.txtClose.Size = new System.Drawing.Size(44, 22);
            this.txtClose.TabIndex = 14;
            this.txtClose.Text = "1101";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(402, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "最低";
            // 
            // txtLow
            // 
            this.txtLow.Location = new System.Drawing.Point(437, 9);
            this.txtLow.Name = "txtLow";
            this.txtLow.ReadOnly = true;
            this.txtLow.Size = new System.Drawing.Size(44, 22);
            this.txtLow.TabIndex = 12;
            this.txtLow.Text = "1101";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(318, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "最高";
            // 
            // txtHigh
            // 
            this.txtHigh.Location = new System.Drawing.Point(353, 9);
            this.txtHigh.Name = "txtHigh";
            this.txtHigh.ReadOnly = true;
            this.txtHigh.Size = new System.Drawing.Size(44, 22);
            this.txtHigh.TabIndex = 10;
            this.txtHigh.Text = "1101";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(234, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "開盤";
            // 
            // txtOpen
            // 
            this.txtOpen.Location = new System.Drawing.Point(269, 9);
            this.txtOpen.Name = "txtOpen";
            this.txtOpen.ReadOnly = true;
            this.txtOpen.Size = new System.Drawing.Size(44, 22);
            this.txtOpen.TabIndex = 8;
            this.txtOpen.Text = "1101";
            // 
            // btnConfig
            // 
            this.btnConfig.Location = new System.Drawing.Point(820, 9);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(75, 23);
            this.btnConfig.TabIndex = 7;
            this.btnConfig.Text = "指標";
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(682, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "來源";
            this.label3.Visible = false;
            // 
            // cboFileType
            // 
            this.cboFileType.FormattingEnabled = true;
            this.cboFileType.Location = new System.Drawing.Point(717, 11);
            this.cboFileType.Name = "cboFileType";
            this.cboFileType.Size = new System.Drawing.Size(96, 20);
            this.cboFileType.TabIndex = 5;
            this.cboFileType.Visible = false;
            // 
            // cboPeriod
            // 
            this.cboPeriod.FormattingEnabled = true;
            this.cboPeriod.Location = new System.Drawing.Point(552, 11);
            this.cboPeriod.Name = "cboPeriod";
            this.cboPeriod.Size = new System.Drawing.Size(121, 20);
            this.cboPeriod.TabIndex = 4;
            this.cboPeriod.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(517, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "時間";
            this.label2.Visible = false;
            // 
            // btnDisplay
            // 
            this.btnDisplay.Location = new System.Drawing.Point(901, 9);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(75, 23);
            this.btnDisplay.TabIndex = 2;
            this.btnDisplay.Text = "顯示";
            this.btnDisplay.UseVisualStyleBackColor = true;
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "商品代碼";
            // 
            // txtSymbolId
            // 
            this.txtSymbolId.Location = new System.Drawing.Point(62, 9);
            this.txtSymbolId.Name = "txtSymbolId";
            this.txtSymbolId.Size = new System.Drawing.Size(78, 22);
            this.txtSymbolId.TabIndex = 0;
            this.txtSymbolId.Text = "1101";
            // 
            // cpDatabase
            // 
            this.cpDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cpDatabase.DateTimeFormat = null;
            this.cpDatabase.Location = new System.Drawing.Point(12, 60);
            this.cpDatabase.Name = "cpDatabase";
            this.cpDatabase.PointPerPage = 0;
            this.cpDatabase.ShowHorizontalCursor = false;
            this.cpDatabase.ShowVerticalCursor = false;
            this.cpDatabase.Size = new System.Drawing.Size(992, 625);
            this.cpDatabase.TabIndex = 4;
            // 
            // cpText
            // 
            this.cpText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cpText.DateTimeFormat = null;
            this.cpText.Location = new System.Drawing.Point(12, 60);
            this.cpText.Name = "cpText";
            this.cpText.PointPerPage = 0;
            this.cpText.ShowHorizontalCursor = false;
            this.cpText.ShowVerticalCursor = false;
            this.cpText.Size = new System.Drawing.Size(992, 625);
            this.cpText.TabIndex = 3;
            // 
            // cpExcel
            // 
            this.cpExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cpExcel.DateTimeFormat = null;
            this.cpExcel.Location = new System.Drawing.Point(12, 60);
            this.cpExcel.Name = "cpExcel";
            this.cpExcel.PointPerPage = 0;
            this.cpExcel.ShowHorizontalCursor = false;
            this.cpExcel.ShowVerticalCursor = false;
            this.cpExcel.Size = new System.Drawing.Size(992, 625);
            this.cpExcel.TabIndex = 2;
            // 
            // signalPane
            // 
            this.signalPane.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.signalPane.BorderColor = System.Drawing.Color.Black;
            this.signalPane.BottomPad = 3;
            this.signalPane.DisplayKey = null;
            this.signalPane.LeftPad = 3;
            this.signalPane.Location = new System.Drawing.Point(12, 691);
            this.signalPane.Name = "signalPane";
            this.signalPane.Pad = 3;
            this.signalPane.RightPad = 3;
            this.signalPane.Size = new System.Drawing.Size(992, 31);
            this.signalPane.TabIndex = 5;
            this.signalPane.TopPad = 3;
            // 
            // txtSymbolName
            // 
            this.txtSymbolName.Location = new System.Drawing.Point(146, 9);
            this.txtSymbolName.Name = "txtSymbolName";
            this.txtSymbolName.ReadOnly = true;
            this.txtSymbolName.Size = new System.Drawing.Size(82, 22);
            this.txtSymbolName.TabIndex = 16;
            this.txtSymbolName.Text = "1101";
            // 
            // KBarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.Controls.Add(this.signalPane);
            this.Controls.Add(this.cpDatabase);
            this.Controls.Add(this.cpText);
            this.Controls.Add(this.cpExcel);
            this.Controls.Add(this.pnlConfig);
            this.Name = "KBarForm";
            this.Text = "走勢圖";
            this.pnlConfig.ResumeLayout(false);
            this.pnlConfig.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlConfig;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSymbolId;
        private System.Windows.Forms.Button btnDisplay;
        private System.Windows.Forms.ComboBox cboPeriod;
        private System.Windows.Forms.Label label2;
        private AAA.TeeChart.TeeChartPanel cpExcel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboFileType;
        private AAA.TeeChart.TeeChartPanel cpText;
        private AAA.TeeChart.TeeChartPanel cpDatabase;
        private System.Windows.Forms.Button btnConfig;
        private AAA.TeeChart.SignalLightPane signalPane;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOpen;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLow;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtHigh;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtClose;
        private System.Windows.Forms.TextBox txtSymbolName;

    }
}

