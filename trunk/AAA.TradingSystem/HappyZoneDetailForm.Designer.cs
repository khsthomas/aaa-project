namespace AAA.TradingSystem
{
    partial class HappyZoneDetailForm
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
            this.tblSymbolGrid = new System.Windows.Forms.DataGridView();
            this.tabReport = new System.Windows.Forms.TabControl();
            this.pnlPosition = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tblShortPosition = new System.Windows.Forms.DataGridView();
            this.tblLongPosition = new System.Windows.Forms.DataGridView();
            this.pnlEquality = new System.Windows.Forms.TabPage();
            this.tblEquality = new System.Windows.Forms.DataGridView();
            this.txtSymbolName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tblSymbolGrid)).BeginInit();
            this.tabReport.SuspendLayout();
            this.pnlPosition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblShortPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblLongPosition)).BeginInit();
            this.pnlEquality.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblEquality)).BeginInit();
            this.SuspendLayout();
            // 
            // tblSymbolGrid
            // 
            this.tblSymbolGrid.AllowUserToAddRows = false;
            this.tblSymbolGrid.AllowUserToDeleteRows = false;
            this.tblSymbolGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tblSymbolGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.tblSymbolGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblSymbolGrid.Location = new System.Drawing.Point(153, 3);
            this.tblSymbolGrid.Name = "tblSymbolGrid";
            this.tblSymbolGrid.ReadOnly = true;
            this.tblSymbolGrid.RowHeadersVisible = false;
            this.tblSymbolGrid.RowTemplate.Height = 24;
            this.tblSymbolGrid.Size = new System.Drawing.Size(697, 65);
            this.tblSymbolGrid.TabIndex = 1;
            // 
            // tabReport
            // 
            this.tabReport.Controls.Add(this.pnlPosition);
            this.tabReport.Controls.Add(this.pnlEquality);
            this.tabReport.Location = new System.Drawing.Point(2, 74);
            this.tabReport.Name = "tabReport";
            this.tabReport.SelectedIndex = 0;
            this.tabReport.Size = new System.Drawing.Size(852, 346);
            this.tabReport.TabIndex = 2;
            // 
            // pnlPosition
            // 
            this.pnlPosition.Controls.Add(this.label2);
            this.pnlPosition.Controls.Add(this.label1);
            this.pnlPosition.Controls.Add(this.tblShortPosition);
            this.pnlPosition.Controls.Add(this.tblLongPosition);
            this.pnlPosition.Location = new System.Drawing.Point(4, 21);
            this.pnlPosition.Name = "pnlPosition";
            this.pnlPosition.Padding = new System.Windows.Forms.Padding(3);
            this.pnlPosition.Size = new System.Drawing.Size(844, 321);
            this.pnlPosition.TabIndex = 0;
            this.pnlPosition.Text = "倉位分析";
            this.pnlPosition.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(434, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "空方";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "多方";
            // 
            // tblShortPosition
            // 
            this.tblShortPosition.AllowUserToAddRows = false;
            this.tblShortPosition.AllowUserToDeleteRows = false;
            this.tblShortPosition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.tblShortPosition.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.tblShortPosition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblShortPosition.Location = new System.Drawing.Point(426, 38);
            this.tblShortPosition.Name = "tblShortPosition";
            this.tblShortPosition.ReadOnly = true;
            this.tblShortPosition.RowHeadersVisible = false;
            this.tblShortPosition.RowTemplate.Height = 24;
            this.tblShortPosition.Size = new System.Drawing.Size(412, 277);
            this.tblShortPosition.TabIndex = 5;
            // 
            // tblLongPosition
            // 
            this.tblLongPosition.AllowUserToAddRows = false;
            this.tblLongPosition.AllowUserToDeleteRows = false;
            this.tblLongPosition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.tblLongPosition.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.tblLongPosition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblLongPosition.Location = new System.Drawing.Point(8, 38);
            this.tblLongPosition.Name = "tblLongPosition";
            this.tblLongPosition.ReadOnly = true;
            this.tblLongPosition.RowHeadersVisible = false;
            this.tblLongPosition.RowTemplate.Height = 24;
            this.tblLongPosition.Size = new System.Drawing.Size(412, 277);
            this.tblLongPosition.TabIndex = 4;
            // 
            // pnlEquality
            // 
            this.pnlEquality.Controls.Add(this.tblEquality);
            this.pnlEquality.Location = new System.Drawing.Point(4, 21);
            this.pnlEquality.Name = "pnlEquality";
            this.pnlEquality.Padding = new System.Windows.Forms.Padding(3);
            this.pnlEquality.Size = new System.Drawing.Size(844, 321);
            this.pnlEquality.TabIndex = 1;
            this.pnlEquality.Text = "損益分析";
            this.pnlEquality.UseVisualStyleBackColor = true;
            // 
            // tblEquality
            // 
            this.tblEquality.AllowUserToAddRows = false;
            this.tblEquality.AllowUserToDeleteRows = false;
            this.tblEquality.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.tblEquality.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.tblEquality.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblEquality.Location = new System.Drawing.Point(6, 6);
            this.tblEquality.Name = "tblEquality";
            this.tblEquality.ReadOnly = true;
            this.tblEquality.RowHeadersVisible = false;
            this.tblEquality.RowTemplate.Height = 24;
            this.tblEquality.Size = new System.Drawing.Size(412, 309);
            this.tblEquality.TabIndex = 5;
            // 
            // txtSymbolName
            // 
            this.txtSymbolName.Location = new System.Drawing.Point(6, 46);
            this.txtSymbolName.Name = "txtSymbolName";
            this.txtSymbolName.Size = new System.Drawing.Size(141, 22);
            this.txtSymbolName.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "商品名稱";
            // 
            // HappyZoneDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 423);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSymbolName);
            this.Controls.Add(this.tabReport);
            this.Controls.Add(this.tblSymbolGrid);
            this.Name = "HappyZoneDetailForm";
            this.Text = "HappyZone商品資訊";
            ((System.ComponentModel.ISupportInitialize)(this.tblSymbolGrid)).EndInit();
            this.tabReport.ResumeLayout(false);
            this.pnlPosition.ResumeLayout(false);
            this.pnlPosition.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblShortPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblLongPosition)).EndInit();
            this.pnlEquality.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblEquality)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tblSymbolGrid;
        private System.Windows.Forms.TabControl tabReport;
        private System.Windows.Forms.TabPage pnlPosition;
        private System.Windows.Forms.DataGridView tblShortPosition;
        private System.Windows.Forms.DataGridView tblLongPosition;
        private System.Windows.Forms.TabPage pnlEquality;
        private System.Windows.Forms.DataGridView tblEquality;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSymbolName;
        private System.Windows.Forms.Label label3;
    }
}