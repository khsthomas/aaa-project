namespace AAA.BlogPublisher
{
    partial class RegisterForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtConfigFile = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.gbAuto = new System.Windows.Forms.GroupBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.lstAuto = new System.Windows.Forms.CheckedListBox();
            this.tblAccountInfo = new System.Windows.Forms.DataGridView();
            this.pnlBrowser = new System.Windows.Forms.Panel();
            this.gbAuto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblAccountInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "設定檔路徑";
            // 
            // txtConfigFile
            // 
            this.txtConfigFile.Location = new System.Drawing.Point(83, 6);
            this.txtConfigFile.Name = "txtConfigFile";
            this.txtConfigFile.Size = new System.Drawing.Size(265, 22);
            this.txtConfigFile.TabIndex = 1;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(354, 4);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "載入";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // gbAuto
            // 
            this.gbAuto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.gbAuto.Controls.Add(this.btnRegister);
            this.gbAuto.Controls.Add(this.lstAuto);
            this.gbAuto.Location = new System.Drawing.Point(225, 34);
            this.gbAuto.Name = "gbAuto";
            this.gbAuto.Size = new System.Drawing.Size(200, 390);
            this.gbAuto.TabIndex = 3;
            this.gbAuto.TabStop = false;
            this.gbAuto.Text = "網站";
            // 
            // btnRegister
            // 
            this.btnRegister.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegister.Location = new System.Drawing.Point(61, 347);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(75, 23);
            this.btnRegister.TabIndex = 3;
            this.btnRegister.Text = "註冊";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // lstAuto
            // 
            this.lstAuto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstAuto.FormattingEnabled = true;
            this.lstAuto.Location = new System.Drawing.Point(6, 21);
            this.lstAuto.Name = "lstAuto";
            this.lstAuto.Size = new System.Drawing.Size(188, 310);
            this.lstAuto.TabIndex = 1;
            // 
            // tblAccountInfo
            // 
            this.tblAccountInfo.AllowUserToAddRows = false;
            this.tblAccountInfo.AllowUserToDeleteRows = false;
            this.tblAccountInfo.AllowUserToOrderColumns = true;
            this.tblAccountInfo.AllowUserToResizeRows = false;
            this.tblAccountInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.tblAccountInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblAccountInfo.Location = new System.Drawing.Point(12, 43);
            this.tblAccountInfo.MultiSelect = false;
            this.tblAccountInfo.Name = "tblAccountInfo";
            this.tblAccountInfo.ReadOnly = true;
            this.tblAccountInfo.RowHeadersVisible = false;
            this.tblAccountInfo.RowTemplate.Height = 24;
            this.tblAccountInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblAccountInfo.Size = new System.Drawing.Size(207, 381);
            this.tblAccountInfo.TabIndex = 4;
            // 
            // pnlBrowser
            // 
            this.pnlBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBrowser.Location = new System.Drawing.Point(435, 6);
            this.pnlBrowser.Name = "pnlBrowser";
            this.pnlBrowser.Size = new System.Drawing.Size(325, 418);
            this.pnlBrowser.TabIndex = 5;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 436);
            this.Controls.Add(this.pnlBrowser);
            this.Controls.Add(this.tblAccountInfo);
            this.Controls.Add(this.gbAuto);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.txtConfigFile);
            this.Controls.Add(this.label1);
            this.Name = "RegisterForm";
            this.Text = "自動開站系統";
            this.gbAuto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblAccountInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtConfigFile;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.GroupBox gbAuto;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.CheckedListBox lstAuto;
        private System.Windows.Forms.DataGridView tblAccountInfo;
        private System.Windows.Forms.Panel pnlBrowser;
    }
}