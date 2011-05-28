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
            this.label3 = new System.Windows.Forms.Label();
            this.cboFileType = new System.Windows.Forms.ComboBox();
            this.cboPeriod = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDisplay = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSymbolId = new System.Windows.Forms.TextBox();
            this.cpExcel = new AAA.TeeChart.TeeChartPanel();
            this.cpText = new AAA.TeeChart.TeeChartPanel();
            this.cpDatabase = new AAA.TeeChart.TeeChartPanel();
            this.pnlConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlConfig
            // 
            this.pnlConfig.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlConfig.Controls.Add(this.label3);
            this.pnlConfig.Controls.Add(this.cboFileType);
            this.pnlConfig.Controls.Add(this.cboPeriod);
            this.pnlConfig.Controls.Add(this.label2);
            this.pnlConfig.Controls.Add(this.btnDisplay);
            this.pnlConfig.Controls.Add(this.label1);
            this.pnlConfig.Controls.Add(this.txtSymbolId);
            this.pnlConfig.Location = new System.Drawing.Point(12, 12);
            this.pnlConfig.Name = "pnlConfig";
            this.pnlConfig.Size = new System.Drawing.Size(694, 42);
            this.pnlConfig.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(333, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "來源";
            this.label3.Visible = false;
            // 
            // cboFileType
            // 
            this.cboFileType.FormattingEnabled = true;
            this.cboFileType.Location = new System.Drawing.Point(368, 11);
            this.cboFileType.Name = "cboFileType";
            this.cboFileType.Size = new System.Drawing.Size(96, 20);
            this.cboFileType.TabIndex = 5;
            this.cboFileType.Visible = false;
            // 
            // cboPeriod
            // 
            this.cboPeriod.FormattingEnabled = true;
            this.cboPeriod.Location = new System.Drawing.Point(203, 11);
            this.cboPeriod.Name = "cboPeriod";
            this.cboPeriod.Size = new System.Drawing.Size(121, 20);
            this.cboPeriod.TabIndex = 4;
            this.cboPeriod.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(168, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "時間";
            this.label2.Visible = false;
            // 
            // btnDisplay
            // 
            this.btnDisplay.Location = new System.Drawing.Point(591, 7);
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
            this.txtSymbolId.Size = new System.Drawing.Size(100, 22);
            this.txtSymbolId.TabIndex = 0;
            this.txtSymbolId.Text = "1101";
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
            this.cpExcel.Size = new System.Drawing.Size(694, 451);
            this.cpExcel.TabIndex = 2;
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
            this.cpText.Size = new System.Drawing.Size(694, 451);
            this.cpText.TabIndex = 3;
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
            this.cpDatabase.Size = new System.Drawing.Size(694, 451);
            this.cpDatabase.TabIndex = 4;
            // 
            // KBarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 523);
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

    }
}

