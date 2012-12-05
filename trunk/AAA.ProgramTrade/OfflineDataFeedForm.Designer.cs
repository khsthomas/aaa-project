namespace AAA.ProgramTrade
{
    partial class OfflineDataFeedForm
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
            this.splContainer = new System.Windows.Forms.SplitContainer();
            this.tblSymbolList = new System.Windows.Forms.DataGridView();
            this.tblDataDetail = new System.Windows.Forms.DataGridView();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCurrentTime = new System.Windows.Forms.TextBox();
            this.btnLoadOfflineData = new System.Windows.Forms.Button();
            this.ofdOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.btnReset = new System.Windows.Forms.Button();
            this.splContainer.Panel1.SuspendLayout();
            this.splContainer.Panel2.SuspendLayout();
            this.splContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblSymbolList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblDataDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // splContainer
            // 
            this.splContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splContainer.Location = new System.Drawing.Point(7, 4);
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
            this.splContainer.TabIndex = 12;
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
            this.tblSymbolList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblSymbolList_CellDoubleClick);
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
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNext.Location = new System.Drawing.Point(256, 405);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(23, 23);
            this.btnNext.TabIndex = 11;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrevious.Location = new System.Drawing.Point(77, 407);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(23, 23);
            this.btnPrevious.TabIndex = 10;
            this.btnPrevious.Text = "<";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 412);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "目前時間";
            // 
            // txtCurrentTime
            // 
            this.txtCurrentTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCurrentTime.Location = new System.Drawing.Point(106, 407);
            this.txtCurrentTime.Name = "txtCurrentTime";
            this.txtCurrentTime.ReadOnly = true;
            this.txtCurrentTime.Size = new System.Drawing.Size(144, 22);
            this.txtCurrentTime.TabIndex = 8;
            // 
            // btnLoadOfflineData
            // 
            this.btnLoadOfflineData.Location = new System.Drawing.Point(793, 405);
            this.btnLoadOfflineData.Name = "btnLoadOfflineData";
            this.btnLoadOfflineData.Size = new System.Drawing.Size(75, 23);
            this.btnLoadOfflineData.TabIndex = 13;
            this.btnLoadOfflineData.Text = "載入資料";
            this.btnLoadOfflineData.UseVisualStyleBackColor = true;
            this.btnLoadOfflineData.Click += new System.EventHandler(this.btnLoadOfflineData_Click);
            // 
            // ofdOpenFile
            // 
            this.ofdOpenFile.FileName = "openFileDialog1";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(712, 405);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 14;
            this.btnReset.Text = "時間重置";
            this.btnReset.UseVisualStyleBackColor = true;
            // 
            // OfflineDataFeedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 435);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnLoadOfflineData);
            this.Controls.Add(this.splContainer);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCurrentTime);
            this.Name = "OfflineDataFeedForm";
            this.Text = "歷史資料重播";
            this.splContainer.Panel1.ResumeLayout(false);
            this.splContainer.Panel2.ResumeLayout(false);
            this.splContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblSymbolList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblDataDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splContainer;
        private System.Windows.Forms.DataGridView tblSymbolList;
        private System.Windows.Forms.DataGridView tblDataDetail;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCurrentTime;
        private System.Windows.Forms.Button btnLoadOfflineData;
        private System.Windows.Forms.OpenFileDialog ofdOpenFile;
        private System.Windows.Forms.Button btnReset;
    }
}