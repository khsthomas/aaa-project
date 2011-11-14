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
            ((System.ComponentModel.ISupportInitialize)(this.tblAccount)).BeginInit();
            this.SuspendLayout();
            // 
            // tblAccount
            // 
            this.tblAccount.AllowUserToAddRows = false;
            this.tblAccount.AllowUserToDeleteRows = false;
            this.tblAccount.AllowUserToOrderColumns = true;
            this.tblAccount.AllowUserToResizeRows = false;
            this.tblAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblAccount.Location = new System.Drawing.Point(12, 12);
            this.tblAccount.Name = "tblAccount";
            this.tblAccount.ReadOnly = true;
            this.tblAccount.RowHeadersVisible = false;
            this.tblAccount.RowTemplate.Height = 24;
            this.tblAccount.Size = new System.Drawing.Size(532, 150);
            this.tblAccount.TabIndex = 0;
            // 
            // btnGetAccountList
            // 
            this.btnGetAccountList.Location = new System.Drawing.Point(12, 267);
            this.btnGetAccountList.Name = "btnGetAccountList";
            this.btnGetAccountList.Size = new System.Drawing.Size(75, 23);
            this.btnGetAccountList.TabIndex = 1;
            this.btnGetAccountList.Text = "帳號列表";
            this.btnGetAccountList.UseVisualStyleBackColor = true;
            this.btnGetAccountList.Click += new System.EventHandler(this.btnGetAccountList_Click);
            // 
            // AccountManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 302);
            this.Controls.Add(this.btnGetAccountList);
            this.Controls.Add(this.tblAccount);
            this.Name = "AccountManagement";
            this.Text = "帳號管理";
            ((System.ComponentModel.ISupportInitialize)(this.tblAccount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView tblAccount;
        private System.Windows.Forms.Button btnGetAccountList;
    }
}

