namespace AAA.KGITrade
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
            this.btnQuote = new System.Windows.Forms.Button();
            this.tblQuote = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSymbolId = new System.Windows.Forms.TextBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lstMessage = new System.Windows.Forms.ListBox();
            this.btnStopQuote = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtVolume = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tblQuote)).BeginInit();
            this.SuspendLayout();
            // 
            // btnQuote
            // 
            this.btnQuote.Location = new System.Drawing.Point(455, 12);
            this.btnQuote.Name = "btnQuote";
            this.btnQuote.Size = new System.Drawing.Size(75, 23);
            this.btnQuote.TabIndex = 0;
            this.btnQuote.Text = "啟動報價";
            this.btnQuote.UseVisualStyleBackColor = true;
            this.btnQuote.Click += new System.EventHandler(this.btnQuote_Click);
            // 
            // tblQuote
            // 
            this.tblQuote.AllowUserToAddRows = false;
            this.tblQuote.AllowUserToDeleteRows = false;
            this.tblQuote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tblQuote.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblQuote.Location = new System.Drawing.Point(7, 69);
            this.tblQuote.Name = "tblQuote";
            this.tblQuote.RowTemplate.Height = 24;
            this.tblQuote.Size = new System.Drawing.Size(529, 238);
            this.tblQuote.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Symbol Id";
            // 
            // txtSymbolId
            // 
            this.txtSymbolId.Location = new System.Drawing.Point(72, 13);
            this.txtSymbolId.Name = "txtSymbolId";
            this.txtSymbolId.Size = new System.Drawing.Size(163, 22);
            this.txtSymbolId.TabIndex = 3;
            this.txtSymbolId.Text = "TW.TXFI2";
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(293, 11);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "離線";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lstMessage
            // 
            this.lstMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstMessage.FormattingEnabled = true;
            this.lstMessage.ItemHeight = 12;
            this.lstMessage.Location = new System.Drawing.Point(7, 315);
            this.lstMessage.Name = "lstMessage";
            this.lstMessage.Size = new System.Drawing.Size(529, 52);
            this.lstMessage.TabIndex = 5;
            // 
            // btnStopQuote
            // 
            this.btnStopQuote.Location = new System.Drawing.Point(374, 11);
            this.btnStopQuote.Name = "btnStopQuote";
            this.btnStopQuote.Size = new System.Drawing.Size(75, 23);
            this.btnStopQuote.TabIndex = 6;
            this.btnStopQuote.Text = "停止報價";
            this.btnStopQuote.UseVisualStyleBackColor = true;
            this.btnStopQuote.Click += new System.EventHandler(this.btnStopQuote_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "Price";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(72, 41);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.ReadOnly = true;
            this.txtPrice.Size = new System.Drawing.Size(62, 22);
            this.txtPrice.TabIndex = 8;
            this.txtPrice.Text = "TW.TXFI2";
            // 
            // txtVolume
            // 
            this.txtVolume.Location = new System.Drawing.Point(173, 42);
            this.txtVolume.Name = "txtVolume";
            this.txtVolume.ReadOnly = true;
            this.txtVolume.Size = new System.Drawing.Size(62, 22);
            this.txtVolume.TabIndex = 10;
            this.txtVolume.Text = "TW.TXFI2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(145, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "Vol";
            // 
            // QuoteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 369);
            this.Controls.Add(this.txtVolume);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnStopQuote);
            this.Controls.Add(this.lstMessage);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.txtSymbolId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tblQuote);
            this.Controls.Add(this.btnQuote);
            this.Name = "QuoteForm";
            this.Text = "即時報價";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QuoteForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.tblQuote)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnQuote;
        private System.Windows.Forms.DataGridView tblQuote;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSymbolId;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.ListBox lstMessage;
        private System.Windows.Forms.Button btnStopQuote;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtVolume;
        private System.Windows.Forms.Label label3;
    }
}

