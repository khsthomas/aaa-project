namespace AAA.PublisherManager
{
    partial class AccountManagement
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
            this.tblAccount = new System.Windows.Forms.DataGridView();
            this.btnGetAccountList = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstWebSite = new System.Windows.Forms.CheckedListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstArticle = new System.Windows.Forms.CheckedListBox();
            this.btnSaveMapping = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtExpiredDate = new System.Windows.Forms.DateTimePicker();
            this.chkActive = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.tblAccount)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblAccount
            // 
            this.tblAccount.AllowUserToAddRows = false;
            this.tblAccount.AllowUserToDeleteRows = false;
            this.tblAccount.AllowUserToOrderColumns = true;
            this.tblAccount.AllowUserToResizeRows = false;
            this.tblAccount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tblAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblAccount.Location = new System.Drawing.Point(12, 12);
            this.tblAccount.MultiSelect = false;
            this.tblAccount.Name = "tblAccount";
            this.tblAccount.ReadOnly = true;
            this.tblAccount.RowHeadersVisible = false;
            this.tblAccount.RowTemplate.Height = 24;
            this.tblAccount.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblAccount.Size = new System.Drawing.Size(609, 166);
            this.tblAccount.TabIndex = 0;
            this.tblAccount.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.tblAccount_CellMouseDoubleClick);
            // 
            // btnGetAccountList
            // 
            this.btnGetAccountList.Location = new System.Drawing.Point(12, 339);
            this.btnGetAccountList.Name = "btnGetAccountList";
            this.btnGetAccountList.Size = new System.Drawing.Size(75, 23);
            this.btnGetAccountList.TabIndex = 1;
            this.btnGetAccountList.Text = "帳號列表";
            this.btnGetAccountList.UseVisualStyleBackColor = true;
            this.btnGetAccountList.Click += new System.EventHandler(this.btnGetAccountList_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstWebSite);
            this.groupBox1.Location = new System.Drawing.Point(12, 216);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(302, 117);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "網站權限";
            // 
            // lstWebSite
            // 
            this.lstWebSite.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstWebSite.FormattingEnabled = true;
            this.lstWebSite.Location = new System.Drawing.Point(6, 21);
            this.lstWebSite.Name = "lstWebSite";
            this.lstWebSite.Size = new System.Drawing.Size(290, 89);
            this.lstWebSite.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstArticle);
            this.groupBox2.Location = new System.Drawing.Point(320, 216);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(302, 117);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "文章權限";
            // 
            // lstArticle
            // 
            this.lstArticle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstArticle.FormattingEnabled = true;
            this.lstArticle.Location = new System.Drawing.Point(6, 20);
            this.lstArticle.Name = "lstArticle";
            this.lstArticle.Size = new System.Drawing.Size(290, 89);
            this.lstArticle.TabIndex = 1;
            // 
            // btnSaveMapping
            // 
            this.btnSaveMapping.Location = new System.Drawing.Point(93, 339);
            this.btnSaveMapping.Name = "btnSaveMapping";
            this.btnSaveMapping.Size = new System.Drawing.Size(75, 23);
            this.btnSaveMapping.TabIndex = 4;
            this.btnSaveMapping.Text = "儲存權限";
            this.btnSaveMapping.UseVisualStyleBackColor = true;
            this.btnSaveMapping.Click += new System.EventHandler(this.btnSaveMapping_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "到期日";
            // 
            // dtExpiredDate
            // 
            this.dtExpiredDate.Location = new System.Drawing.Point(59, 188);
            this.dtExpiredDate.Name = "dtExpiredDate";
            this.dtExpiredDate.Size = new System.Drawing.Size(127, 22);
            this.dtExpiredDate.TabIndex = 6;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Location = new System.Drawing.Point(202, 192);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(72, 16);
            this.chkActive.TabIndex = 7;
            this.chkActive.Text = "有效帳號";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // AccountManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 365);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.dtExpiredDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSaveMapping);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnGetAccountList);
            this.Controls.Add(this.tblAccount);
            this.Name = "AccountManagement";
            this.Text = "帳號管理";
            ((System.ComponentModel.ISupportInitialize)(this.tblAccount)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tblAccount;
        private System.Windows.Forms.Button btnGetAccountList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox lstWebSite;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox lstArticle;
        private System.Windows.Forms.Button btnSaveMapping;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtExpiredDate;
        private System.Windows.Forms.CheckBox chkActive;
    }
}

