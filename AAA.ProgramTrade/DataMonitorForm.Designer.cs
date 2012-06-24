namespace AAA.ProgramTrade
{
    partial class DataMonitorForm
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
            this.tblSymbolList = new System.Windows.Forms.DataGridView();
            this.tblDataDetail = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tblSymbolList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblDataDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // tblSymbolList
            // 
            this.tblSymbolList.AllowUserToAddRows = false;
            this.tblSymbolList.AllowUserToDeleteRows = false;
            this.tblSymbolList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblSymbolList.Location = new System.Drawing.Point(2, 2);
            this.tblSymbolList.Name = "tblSymbolList";
            this.tblSymbolList.ReadOnly = true;
            this.tblSymbolList.RowHeadersVisible = false;
            this.tblSymbolList.RowTemplate.Height = 24;
            this.tblSymbolList.Size = new System.Drawing.Size(311, 392);
            this.tblSymbolList.TabIndex = 0;
            // 
            // tblDataDetail
            // 
            this.tblDataDetail.AllowUserToAddRows = false;
            this.tblDataDetail.AllowUserToDeleteRows = false;
            this.tblDataDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblDataDetail.Location = new System.Drawing.Point(319, 2);
            this.tblDataDetail.Name = "tblDataDetail";
            this.tblDataDetail.ReadOnly = true;
            this.tblDataDetail.RowHeadersVisible = false;
            this.tblDataDetail.RowTemplate.Height = 24;
            this.tblDataDetail.Size = new System.Drawing.Size(544, 392);
            this.tblDataDetail.TabIndex = 1;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(788, 400);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "更新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // DataMonitorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 435);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.tblDataDetail);
            this.Controls.Add(this.tblSymbolList);
            this.Name = "DataMonitorForm";
            this.Text = "資料監控";
            ((System.ComponentModel.ISupportInitialize)(this.tblSymbolList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblDataDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView tblSymbolList;
        private System.Windows.Forms.DataGridView tblDataDetail;
        private System.Windows.Forms.Button btnRefresh;
    }
}