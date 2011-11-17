namespace AAA.BlogPublisher
{
    partial class PublishForm
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
            this.gbAuto = new System.Windows.Forms.GroupBox();
            this.btnPublishAuto = new System.Windows.Forms.Button();
            this.lstAuto = new System.Windows.Forms.CheckedListBox();
            this.gbCheck = new System.Windows.Forms.GroupBox();
            this.btnPublishCheck = new System.Windows.Forms.Button();
            this.lstCheck = new System.Windows.Forms.CheckedListBox();
            this.gbAccount = new System.Windows.Forms.GroupBox();
            this.lstAccount = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstNewArticle = new System.Windows.Forms.CheckedListBox();
            this.gbAuto.SuspendLayout();
            this.gbCheck.SuspendLayout();
            this.gbAccount.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbAuto
            // 
            this.gbAuto.Controls.Add(this.btnPublishAuto);
            this.gbAuto.Controls.Add(this.lstAuto);
            this.gbAuto.Location = new System.Drawing.Point(12, 202);
            this.gbAuto.Name = "gbAuto";
            this.gbAuto.Size = new System.Drawing.Size(212, 220);
            this.gbAuto.TabIndex = 0;
            this.gbAuto.TabStop = false;
            this.gbAuto.Text = "不需認證網站";
            // 
            // btnPublishAuto
            // 
            this.btnPublishAuto.Location = new System.Drawing.Point(62, 184);
            this.btnPublishAuto.Name = "btnPublishAuto";
            this.btnPublishAuto.Size = new System.Drawing.Size(75, 23);
            this.btnPublishAuto.TabIndex = 3;
            this.btnPublishAuto.Text = "發佈";
            this.btnPublishAuto.UseVisualStyleBackColor = true;
            this.btnPublishAuto.Click += new System.EventHandler(this.btnPublishAuto_Click);
            // 
            // lstAuto
            // 
            this.lstAuto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstAuto.FormattingEnabled = true;
            this.lstAuto.Location = new System.Drawing.Point(6, 21);
            this.lstAuto.Name = "lstAuto";
            this.lstAuto.Size = new System.Drawing.Size(200, 157);
            this.lstAuto.TabIndex = 1;
            // 
            // gbCheck
            // 
            this.gbCheck.Controls.Add(this.btnPublishCheck);
            this.gbCheck.Controls.Add(this.lstCheck);
            this.gbCheck.Location = new System.Drawing.Point(250, 202);
            this.gbCheck.Name = "gbCheck";
            this.gbCheck.Size = new System.Drawing.Size(212, 220);
            this.gbCheck.TabIndex = 1;
            this.gbCheck.TabStop = false;
            this.gbCheck.Text = "需認證網站";
            // 
            // btnPublishCheck
            // 
            this.btnPublishCheck.Location = new System.Drawing.Point(73, 184);
            this.btnPublishCheck.Name = "btnPublishCheck";
            this.btnPublishCheck.Size = new System.Drawing.Size(75, 23);
            this.btnPublishCheck.TabIndex = 4;
            this.btnPublishCheck.Text = "發佈";
            this.btnPublishCheck.UseVisualStyleBackColor = true;
            // 
            // lstCheck
            // 
            this.lstCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstCheck.FormattingEnabled = true;
            this.lstCheck.Location = new System.Drawing.Point(6, 21);
            this.lstCheck.Name = "lstCheck";
            this.lstCheck.Size = new System.Drawing.Size(200, 157);
            this.lstCheck.TabIndex = 2;
            // 
            // gbAccount
            // 
            this.gbAccount.Controls.Add(this.lstAccount);
            this.gbAccount.Location = new System.Drawing.Point(12, 12);
            this.gbAccount.Name = "gbAccount";
            this.gbAccount.Size = new System.Drawing.Size(212, 103);
            this.gbAccount.TabIndex = 2;
            this.gbAccount.TabStop = false;
            this.gbAccount.Text = "帳號列表";
            // 
            // lstAccount
            // 
            this.lstAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstAccount.FormattingEnabled = true;
            this.lstAccount.Location = new System.Drawing.Point(10, 20);
            this.lstAccount.Name = "lstAccount";
            this.lstAccount.Size = new System.Drawing.Size(194, 72);
            this.lstAccount.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstNewArticle);
            this.groupBox1.Location = new System.Drawing.Point(244, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(212, 184);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "目前新進文章";
            // 
            // lstNewArticle
            // 
            this.lstNewArticle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstNewArticle.FormattingEnabled = true;
            this.lstNewArticle.Location = new System.Drawing.Point(10, 20);
            this.lstNewArticle.Name = "lstNewArticle";
            this.lstNewArticle.Size = new System.Drawing.Size(194, 157);
            this.lstNewArticle.TabIndex = 2;
            // 
            // PublishForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 436);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbAccount);
            this.Controls.Add(this.gbCheck);
            this.Controls.Add(this.gbAuto);
            this.Name = "PublishForm";
            this.Text = "自動文章發佈系統";
            this.Load += new System.EventHandler(this.PublishForm_Load);
            this.gbAuto.ResumeLayout(false);
            this.gbCheck.ResumeLayout(false);
            this.gbAccount.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbAuto;
        private System.Windows.Forms.GroupBox gbCheck;
        private System.Windows.Forms.CheckedListBox lstAuto;
        private System.Windows.Forms.CheckedListBox lstCheck;
        private System.Windows.Forms.Button btnPublishAuto;
        private System.Windows.Forms.Button btnPublishCheck;
        private System.Windows.Forms.GroupBox gbAccount;
        private System.Windows.Forms.CheckedListBox lstAccount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox lstNewArticle;
    }
}

