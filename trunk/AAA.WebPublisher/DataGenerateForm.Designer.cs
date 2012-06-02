namespace AAA.WebPublisher
{
    partial class DataGenerateForm
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
            this.btnFuturesEstimateVol = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFuturesEstimateVol
            // 
            this.btnFuturesEstimateVol.Location = new System.Drawing.Point(12, 12);
            this.btnFuturesEstimateVol.Name = "btnFuturesEstimateVol";
            this.btnFuturesEstimateVol.Size = new System.Drawing.Size(134, 23);
            this.btnFuturesEstimateVol.TabIndex = 0;
            this.btnFuturesEstimateVol.Text = "Futures Estimate Vol.";
            this.btnFuturesEstimateVol.UseVisualStyleBackColor = true;
            this.btnFuturesEstimateVol.Click += new System.EventHandler(this.btnFuturesEstimateVol_Click);
            // 
            // DataGenerateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 313);
            this.Controls.Add(this.btnFuturesEstimateVol);
            this.Name = "DataGenerateForm";
            this.Text = "Data Generate Form";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFuturesEstimateVol;
    }
}

