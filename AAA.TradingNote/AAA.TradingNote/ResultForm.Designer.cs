namespace AAA.TradingNote
{
    partial class ResultForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
            this.gbCriteria = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // gbCriteria
            // 
            this.gbCriteria.Location = new System.Drawing.Point(12, 12);
            this.gbCriteria.Name = "gbCriteria";
            this.gbCriteria.Size = new System.Drawing.Size(746, 100);
            this.gbCriteria.TabIndex = 0;
            this.gbCriteria.TabStop = false;
            this.gbCriteria.Text = "條件";
            // 
            // ResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 542);
            this.Controls.Add(this.gbCriteria);
            this.Name = "ResultForm";
            this.Text = "行情搜尋";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCriteria;
    }
}

