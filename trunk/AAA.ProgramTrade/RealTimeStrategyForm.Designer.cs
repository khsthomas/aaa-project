namespace AAA.ProgramTrade
{
    partial class RealTimeStrategyForm
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
            this.tblStrategy = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.tblStrategy)).BeginInit();
            this.SuspendLayout();
            // 
            // tblStrategy
            // 
            this.tblStrategy.AllowUserToAddRows = false;
            this.tblStrategy.AllowUserToDeleteRows = false;
            this.tblStrategy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tblStrategy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblStrategy.Location = new System.Drawing.Point(2, 34);
            this.tblStrategy.Name = "tblStrategy";
            this.tblStrategy.ReadOnly = true;
            this.tblStrategy.RowHeadersVisible = false;
            this.tblStrategy.RowTemplate.Height = 24;
            this.tblStrategy.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblStrategy.Size = new System.Drawing.Size(716, 294);
            this.tblStrategy.TabIndex = 0;
            // 
            // RealTimeStrategyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 332);
            this.Controls.Add(this.tblStrategy);
            this.Name = "RealTimeStrategyForm";
            this.Text = "即時策略";
            ((System.ComponentModel.ISupportInitialize)(this.tblStrategy)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView tblStrategy;
    }
}