namespace AAA.BlogPublisher
{
    partial class ArticleEditor
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
            this.txtArticle = new System.Windows.Forms.RichTextBox();
            this.btnLoadArticle = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPictureDesc = new System.Windows.Forms.TextBox();
            this.wbPictureSite = new System.Windows.Forms.WebBrowser();
            this.btnReload = new System.Windows.Forms.Button();
            this.tblPicture = new System.Windows.Forms.DataGridView();
            this.btnInsert = new System.Windows.Forms.Button();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.btnSaveArticle = new System.Windows.Forms.Button();
            this.lblFilename = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tblPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // txtArticle
            // 
            this.txtArticle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.txtArticle.Location = new System.Drawing.Point(3, 38);
            this.txtArticle.Name = "txtArticle";
            this.txtArticle.Size = new System.Drawing.Size(460, 640);
            this.txtArticle.TabIndex = 0;
            this.txtArticle.Text = "";
            // 
            // btnLoadArticle
            // 
            this.btnLoadArticle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoadArticle.Location = new System.Drawing.Point(12, 699);
            this.btnLoadArticle.Name = "btnLoadArticle";
            this.btnLoadArticle.Size = new System.Drawing.Size(75, 23);
            this.btnLoadArticle.TabIndex = 1;
            this.btnLoadArticle.Text = "載入文章";
            this.btnLoadArticle.UseVisualStyleBackColor = true;
            this.btnLoadArticle.Click += new System.EventHandler(this.btnLoadArticle_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(470, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "圖片說明";
            // 
            // txtPictureDesc
            // 
            this.txtPictureDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPictureDesc.Location = new System.Drawing.Point(540, 10);
            this.txtPictureDesc.Name = "txtPictureDesc";
            this.txtPictureDesc.Size = new System.Drawing.Size(338, 22);
            this.txtPictureDesc.TabIndex = 3;
            // 
            // wbPictureSite
            // 
            this.wbPictureSite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.wbPictureSite.Location = new System.Drawing.Point(472, 38);
            this.wbPictureSite.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbPictureSite.Name = "wbPictureSite";
            this.wbPictureSite.Size = new System.Drawing.Size(532, 329);
            this.wbPictureSite.TabIndex = 4;
            // 
            // btnReload
            // 
            this.btnReload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReload.Location = new System.Drawing.Point(884, 8);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(120, 23);
            this.btnReload.TabIndex = 5;
            this.btnReload.Text = "顯示上傳網頁";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // tblPicture
            // 
            this.tblPicture.AllowUserToAddRows = false;
            this.tblPicture.AllowUserToDeleteRows = false;
            this.tblPicture.AllowUserToResizeRows = false;
            this.tblPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tblPicture.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.tblPicture.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblPicture.Location = new System.Drawing.Point(472, 373);
            this.tblPicture.Name = "tblPicture";
            this.tblPicture.ReadOnly = true;
            this.tblPicture.RowHeadersVisible = false;
            this.tblPicture.RowTemplate.Height = 24;
            this.tblPicture.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblPicture.Size = new System.Drawing.Size(532, 305);
            this.tblPicture.TabIndex = 6;
            // 
            // btnInsert
            // 
            this.btnInsert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInsert.Location = new System.Drawing.Point(472, 699);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 23);
            this.btnInsert.TabIndex = 7;
            this.btnInsert.Text = "插入圖片";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // openFile
            // 
            this.openFile.FileName = "openFileDialog1";
            // 
            // btnSaveArticle
            // 
            this.btnSaveArticle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveArticle.Location = new System.Drawing.Point(93, 699);
            this.btnSaveArticle.Name = "btnSaveArticle";
            this.btnSaveArticle.Size = new System.Drawing.Size(75, 23);
            this.btnSaveArticle.TabIndex = 8;
            this.btnSaveArticle.Text = "儲存文章";
            this.btnSaveArticle.UseVisualStyleBackColor = true;
            this.btnSaveArticle.Click += new System.EventHandler(this.btnSaveArticle_Click);
            // 
            // lblFilename
            // 
            this.lblFilename.AutoSize = true;
            this.lblFilename.Location = new System.Drawing.Point(3, 13);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Size = new System.Drawing.Size(0, 12);
            this.lblFilename.TabIndex = 9;
            this.lblFilename.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ArticleEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.Controls.Add(this.lblFilename);
            this.Controls.Add(this.btnSaveArticle);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.tblPicture);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.wbPictureSite);
            this.Controls.Add(this.txtPictureDesc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLoadArticle);
            this.Controls.Add(this.txtArticle);
            this.Name = "ArticleEditor";
            this.Text = "圖文整合系統";
            this.Load += new System.EventHandler(this.ArticleEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtArticle;
        private System.Windows.Forms.Button btnLoadArticle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPictureDesc;
        private System.Windows.Forms.WebBrowser wbPictureSite;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.DataGridView tblPicture;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.Button btnSaveArticle;
        private System.Windows.Forms.Label lblFilename;
    }
}