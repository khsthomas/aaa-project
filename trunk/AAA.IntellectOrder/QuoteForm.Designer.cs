namespace AAA.IntellectOrder
{
    partial class QuoteForm
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
            this.gbAccountInfo = new System.Windows.Forms.GroupBox();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtAccountType = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtSymbol = new System.Windows.Forms.TextBox();
            this.tblQuote = new System.Windows.Forms.DataGridView();
            this.btnStop = new System.Windows.Forms.Button();
            this.gbAccountInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblQuote)).BeginInit();
            this.SuspendLayout();
            // 
            // gbAccountInfo
            // 
            this.gbAccountInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbAccountInfo.Controls.Add(this.btnStop);
            this.gbAccountInfo.Controls.Add(this.txtSymbol);
            this.gbAccountInfo.Controls.Add(this.btnStart);
            this.gbAccountInfo.Controls.Add(this.txtAccountType);
            this.gbAccountInfo.Controls.Add(this.txtPassword);
            this.gbAccountInfo.Controls.Add(this.txtAccount);
            this.gbAccountInfo.Location = new System.Drawing.Point(2, 3);
            this.gbAccountInfo.Name = "gbAccountInfo";
            this.gbAccountInfo.Size = new System.Drawing.Size(730, 55);
            this.gbAccountInfo.TabIndex = 0;
            this.gbAccountInfo.TabStop = false;
            this.gbAccountInfo.Text = "帳號資訊";
            // 
            // txtAccount
            // 
            this.txtAccount.Location = new System.Drawing.Point(149, 21);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(100, 22);
            this.txtAccount.TabIndex = 0;
            this.txtAccount.Text = "F0210000002525917";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(307, 21);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(100, 22);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.Text = "12345678";
            // 
            // txtAccountType
            // 
            this.txtAccountType.Location = new System.Drawing.Point(41, 21);
            this.txtAccountType.Name = "txtAccountType";
            this.txtAccountType.Size = new System.Drawing.Size(35, 22);
            this.txtAccountType.TabIndex = 2;
            this.txtAccountType.Text = "F";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(565, 21);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "啟動";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtSymbol
            // 
            this.txtSymbol.Location = new System.Drawing.Point(441, 21);
            this.txtSymbol.Name = "txtSymbol";
            this.txtSymbol.Size = new System.Drawing.Size(100, 22);
            this.txtSymbol.TabIndex = 4;
            this.txtSymbol.Text = "3,7779";
            // 
            // tblQuote
            // 
            this.tblQuote.AllowUserToAddRows = false;
            this.tblQuote.AllowUserToDeleteRows = false;
            this.tblQuote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tblQuote.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblQuote.Location = new System.Drawing.Point(2, 64);
            this.tblQuote.Name = "tblQuote";
            this.tblQuote.ReadOnly = true;
            this.tblQuote.RowHeadersVisible = false;
            this.tblQuote.RowTemplate.Height = 24;
            this.tblQuote.Size = new System.Drawing.Size(730, 150);
            this.tblQuote.TabIndex = 1;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(646, 21);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 5;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // QuoteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 408);
            this.Controls.Add(this.tblQuote);
            this.Controls.Add(this.gbAccountInfo);
            this.Name = "QuoteForm";
            this.Text = "Form1";
            this.gbAccountInfo.ResumeLayout(false);
            this.gbAccountInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblQuote)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbAccountInfo;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtAccountType;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.TextBox txtSymbol;
        private System.Windows.Forms.DataGridView tblQuote;
        private System.Windows.Forms.Button btnStop;
    }
}

