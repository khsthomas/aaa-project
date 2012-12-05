namespace AAA.ProgramTrade
{
    partial class DataDownloadForm
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
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.chkSymbolList = new System.Windows.Forms.CheckedListBox();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnConfig = new System.Windows.Forms.Button();
            this.ofdFile = new System.Windows.Forms.OpenFileDialog();
            this.lstMessage = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboSymbolType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStrikePriceStart = new System.Windows.Forms.TextBox();
            this.txtStrikePriceEnd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkRedownload = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "開始時間";
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.CustomFormat = "yyyy/MM/dd";
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(71, 4);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Size = new System.Drawing.Size(119, 22);
            this.dtpStartTime.TabIndex = 1;
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.CustomFormat = "yyyy/MM/dd";
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(71, 32);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(119, 22);
            this.dtpEndTime.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "結束時間";
            // 
            // chkSymbolList
            // 
            this.chkSymbolList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.chkSymbolList.FormattingEnabled = true;
            this.chkSymbolList.Location = new System.Drawing.Point(14, 111);
            this.chkSymbolList.Name = "chkSymbolList";
            this.chkSymbolList.Size = new System.Drawing.Size(186, 259);
            this.chkSymbolList.TabIndex = 4;
            // 
            // btnDownload
            // 
            this.btnDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDownload.Location = new System.Drawing.Point(115, 376);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(75, 23);
            this.btnDownload.TabIndex = 5;
            this.btnDownload.Text = "下載";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnConfig
            // 
            this.btnConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnConfig.Location = new System.Drawing.Point(14, 376);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(75, 23);
            this.btnConfig.TabIndex = 6;
            this.btnConfig.Text = "載入清單";
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // ofdFile
            // 
            this.ofdFile.FileName = "openFileDialog1";
            // 
            // lstMessage
            // 
            this.lstMessage.FormattingEnabled = true;
            this.lstMessage.ItemHeight = 12;
            this.lstMessage.Location = new System.Drawing.Point(206, 112);
            this.lstMessage.Name = "lstMessage";
            this.lstMessage.Size = new System.Drawing.Size(438, 256);
            this.lstMessage.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "商品類別";
            // 
            // cboSymbolType
            // 
            this.cboSymbolType.FormattingEnabled = true;
            this.cboSymbolType.Location = new System.Drawing.Point(71, 68);
            this.cboSymbolType.Name = "cboSymbolType";
            this.cboSymbolType.Size = new System.Drawing.Size(121, 20);
            this.cboSymbolType.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(240, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "選擇權履約價區間";
            // 
            // txtStrikePriceStart
            // 
            this.txtStrikePriceStart.Location = new System.Drawing.Point(347, 6);
            this.txtStrikePriceStart.Name = "txtStrikePriceStart";
            this.txtStrikePriceStart.Size = new System.Drawing.Size(51, 22);
            this.txtStrikePriceStart.TabIndex = 11;
            this.txtStrikePriceStart.Text = "5000";
            this.txtStrikePriceStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtStrikePriceEnd
            // 
            this.txtStrikePriceEnd.Location = new System.Drawing.Point(419, 6);
            this.txtStrikePriceEnd.Name = "txtStrikePriceEnd";
            this.txtStrikePriceEnd.Size = new System.Drawing.Size(51, 22);
            this.txtStrikePriceEnd.TabIndex = 12;
            this.txtStrikePriceEnd.Text = "9000";
            this.txtStrikePriceEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(402, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "~";
            // 
            // chkRedownload
            // 
            this.chkRedownload.AutoSize = true;
            this.chkRedownload.Location = new System.Drawing.Point(242, 38);
            this.chkRedownload.Name = "chkRedownload";
            this.chkRedownload.Size = new System.Drawing.Size(72, 16);
            this.chkRedownload.TabIndex = 14;
            this.chkRedownload.Text = "重新下載";
            this.chkRedownload.UseVisualStyleBackColor = true;
            // 
            // DataDownloadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 413);
            this.Controls.Add(this.chkRedownload);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtStrikePriceEnd);
            this.Controls.Add(this.txtStrikePriceStart);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkSymbolList);
            this.Controls.Add(this.cboSymbolType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstMessage);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.dtpEndTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpStartTime);
            this.Controls.Add(this.label1);
            this.Name = "DataDownloadForm";
            this.Text = "資料下載";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DataDownloadForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox chkSymbolList;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.OpenFileDialog ofdFile;
        private System.Windows.Forms.ListBox lstMessage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboSymbolType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtStrikePriceStart;
        private System.Windows.Forms.TextBox txtStrikePriceEnd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkRedownload;
    }
}