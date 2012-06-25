namespace AAA.ProgramTrade
{
    partial class ChartForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.cboSymbolId = new System.Windows.Forms.ComboBox();
            this.teeChartPanel1 = new AAA.TeeChart.TeeChartPanel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "商品名稱";
            // 
            // cboSymbolId
            // 
            this.cboSymbolId.FormattingEnabled = true;
            this.cboSymbolId.Location = new System.Drawing.Point(71, 6);
            this.cboSymbolId.Name = "cboSymbolId";
            this.cboSymbolId.Size = new System.Drawing.Size(121, 20);
            this.cboSymbolId.TabIndex = 1;
            // 
            // teeChartPanel1
            // 
            this.teeChartPanel1.BaseSeriesName = "";
            this.teeChartPanel1.DateTimeFormat = null;
            this.teeChartPanel1.IsShowInfoTable = false;
            this.teeChartPanel1.IsShowLightPane = false;
            this.teeChartPanel1.IsShowScale = false;
            this.teeChartPanel1.Location = new System.Drawing.Point(3, 32);
            this.teeChartPanel1.Name = "teeChartPanel1";
            this.teeChartPanel1.PointPerPage = 0;
            this.teeChartPanel1.ShowHorizontalCursor = false;
            this.teeChartPanel1.ShowVerticalCursor = false;
            this.teeChartPanel1.Size = new System.Drawing.Size(881, 571);
            this.teeChartPanel1.TabIndex = 2;
            // 
            // ChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 587);
            this.Controls.Add(this.teeChartPanel1);
            this.Controls.Add(this.cboSymbolId);
            this.Controls.Add(this.label1);
            this.Name = "ChartForm";
            this.Text = "走勢圖";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboSymbolId;
        private AAA.TeeChart.TeeChartPanel teeChartPanel1;
    }
}