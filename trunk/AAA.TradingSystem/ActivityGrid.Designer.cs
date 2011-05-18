namespace AAA.TradingSystem
{
    partial class ActivityGrid
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
            this.tblData = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.tblData)).BeginInit();
            this.SuspendLayout();
            // 
            // tblData
            // 
            this.tblData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblData.Location = new System.Drawing.Point(2, 2);
            this.tblData.Name = "tblData";
            this.tblData.RowTemplate.Height = 24;
            this.tblData.Size = new System.Drawing.Size(599, 364);
            this.tblData.TabIndex = 0;
            // 
            // ActivityGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 370);
            this.Controls.Add(this.tblData);
            this.Name = "ActivityGrid";
            this.Text = "多空戰力圖";
            ((System.ComponentModel.ISupportInitialize)(this.tblData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView tblData;
    }
}