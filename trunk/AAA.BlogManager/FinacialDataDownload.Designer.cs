namespace AAA.BlogManager
{
    partial class FinacialDataDownload
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
            this.lstMessage = new System.Windows.Forms.ListBox();
            this.btnDownload = new System.Windows.Forms.Button();
            this.pnlBrowser = new System.Windows.Forms.Panel();
            this.btnPublish = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtBlogname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnParse = new System.Windows.Forms.Button();
            this.fbdFileRoot = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // lstMessage
            // 
            this.lstMessage.FormattingEnabled = true;
            this.lstMessage.ItemHeight = 12;
            this.lstMessage.Location = new System.Drawing.Point(3, 77);
            this.lstMessage.Name = "lstMessage";
            this.lstMessage.Size = new System.Drawing.Size(261, 256);
            this.lstMessage.TabIndex = 2;
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(108, 48);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(75, 23);
            this.btnDownload.TabIndex = 3;
            this.btnDownload.Text = "下載";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // pnlBrowser
            // 
            this.pnlBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBrowser.Location = new System.Drawing.Point(270, 77);
            this.pnlBrowser.Name = "pnlBrowser";
            this.pnlBrowser.Size = new System.Drawing.Size(594, 383);
            this.pnlBrowser.TabIndex = 5;
            // 
            // btnPublish
            // 
            this.btnPublish.Location = new System.Drawing.Point(789, 48);
            this.btnPublish.Name = "btnPublish";
            this.btnPublish.Size = new System.Drawing.Size(75, 23);
            this.btnPublish.TabIndex = 6;
            this.btnPublish.Text = "發佈";
            this.btnPublish.UseVisualStyleBackColor = true;
            this.btnPublish.Click += new System.EventHandler(this.btnPublish_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(283, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "帳號";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(543, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "密碼";
            // 
            // txtAccount
            // 
            this.txtAccount.Location = new System.Drawing.Point(318, 10);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(200, 22);
            this.txtAccount.TabIndex = 9;
            this.txtAccount.Text = "softengineer_tw";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(578, 10);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(200, 22);
            this.txtPassword.TabIndex = 10;
            this.txtPassword.Text = "clotheskmc6475";
            // 
            // txtBlogname
            // 
            this.txtBlogname.Location = new System.Drawing.Point(318, 38);
            this.txtBlogname.Name = "txtBlogname";
            this.txtBlogname.Size = new System.Drawing.Size(200, 22);
            this.txtBlogname.TabIndex = 12;
            this.txtBlogname.Text = "ecity2005";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(283, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "名稱";
            // 
            // btnParse
            // 
            this.btnParse.Location = new System.Drawing.Point(189, 48);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(75, 23);
            this.btnParse.TabIndex = 13;
            this.btnParse.Text = "解檔";
            this.btnParse.UseVisualStyleBackColor = true;
            this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // FinacialDataDownload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 472);
            this.Controls.Add(this.btnParse);
            this.Controls.Add(this.txtBlogname);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtAccount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPublish);
            this.Controls.Add(this.pnlBrowser);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.lstMessage);
            this.Name = "FinacialDataDownload";
            this.Text = "金融資訊下載";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstMessage;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Panel pnlBrowser;
        private System.Windows.Forms.Button btnPublish;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtBlogname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnParse;
        private System.Windows.Forms.FolderBrowserDialog fbdFileRoot;
    }
}