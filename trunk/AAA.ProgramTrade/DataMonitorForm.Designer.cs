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
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtCurrentTime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.splContainer = new System.Windows.Forms.SplitContainer();
            this.tblSymbolList = new System.Windows.Forms.DataGridView();
            this.tblDataDetail = new System.Windows.Forms.DataGridView();
            this.splContainer.Panel1.SuspendLayout();
            this.splContainer.Panel2.SuspendLayout();
            this.splContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblSymbolList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblDataDetail)).BeginInit();
            this.SuspendLayout();
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
            // txtCurrentTime
            // 
            this.txtCurrentTime.Location = new System.Drawing.Point(101, 405);
            this.txtCurrentTime.Name = "txtCurrentTime";
            this.txtCurrentTime.ReadOnly = true;
            this.txtCurrentTime.Size = new System.Drawing.Size(144, 22);
            this.txtCurrentTime.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 410);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "目前時間";
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(72, 405);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(23, 23);
            this.btnPrevious.TabIndex = 5;
            this.btnPrevious.Text = "<";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(251, 403);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(23, 23);
            this.btnNext.TabIndex = 6;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // splContainer
            // 
            this.splContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splContainer.Location = new System.Drawing.Point(2, 2);
            this.splContainer.Name = "splContainer";
            // 
            // splContainer.Panel1
            // 
            this.splContainer.Panel1.Controls.Add(this.tblSymbolList);
            // 
            // splContainer.Panel2
            // 
            this.splContainer.Panel2.Controls.Add(this.tblDataDetail);
            this.splContainer.Size = new System.Drawing.Size(861, 392);
            this.splContainer.SplitterDistance = 561;
            this.splContainer.TabIndex = 7;
            // 
            // tblSymbolList
            // 
            this.tblSymbolList.AllowUserToAddRows = false;
            this.tblSymbolList.AllowUserToDeleteRows = false;
            this.tblSymbolList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblSymbolList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblSymbolList.Location = new System.Drawing.Point(0, 0);
            this.tblSymbolList.Name = "tblSymbolList";
            this.tblSymbolList.ReadOnly = true;
            this.tblSymbolList.RowHeadersVisible = false;
            this.tblSymbolList.RowTemplate.Height = 24;
            this.tblSymbolList.Size = new System.Drawing.Size(561, 392);
            this.tblSymbolList.TabIndex = 1;
            // 
            // tblDataDetail
            // 
            this.tblDataDetail.AllowUserToAddRows = false;
            this.tblDataDetail.AllowUserToDeleteRows = false;
            this.tblDataDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblDataDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblDataDetail.Location = new System.Drawing.Point(0, 0);
            this.tblDataDetail.Name = "tblDataDetail";
            this.tblDataDetail.ReadOnly = true;
            this.tblDataDetail.RowHeadersVisible = false;
            this.tblDataDetail.RowTemplate.Height = 24;
            this.tblDataDetail.Size = new System.Drawing.Size(296, 392);
            this.tblDataDetail.TabIndex = 2;
            // 
            // DataMonitorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 435);
            this.Controls.Add(this.splContainer);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCurrentTime);
            this.Controls.Add(this.btnRefresh);
            this.Name = "DataMonitorForm";
            this.Text = "資料監控";
            this.splContainer.Panel1.ResumeLayout(false);
            this.splContainer.Panel2.ResumeLayout(false);
            this.splContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblSymbolList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblDataDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtCurrentTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.SplitContainer splContainer;
        private System.Windows.Forms.DataGridView tblSymbolList;
        private System.Windows.Forms.DataGridView tblDataDetail;
    }
}