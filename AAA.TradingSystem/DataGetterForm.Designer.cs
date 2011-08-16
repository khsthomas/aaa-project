namespace AAA.TradingSystem
{
    partial class DataGetterForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDownload = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lstMessage = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnUpdateIndexMapping = new System.Windows.Forms.Button();
            this.btnRecalculateIndex = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStartDate = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtStartDate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnDownload);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(500, 121);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "股票資料收集";
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(384, 92);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(75, 23);
            this.btnDownload.TabIndex = 2;
            this.btnDownload.Text = "下載";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "交易資料下載";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "股票代碼";
            // 
            // lstMessage
            // 
            this.lstMessage.FormattingEnabled = true;
            this.lstMessage.ItemHeight = 12;
            this.lstMessage.Location = new System.Drawing.Point(12, 198);
            this.lstMessage.Name = "lstMessage";
            this.lstMessage.Size = new System.Drawing.Size(500, 148);
            this.lstMessage.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnUpdateIndexMapping);
            this.groupBox2.Controls.Add(this.btnRecalculateIndex);
            this.groupBox2.Location = new System.Drawing.Point(12, 139);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(500, 53);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "參數更新";
            // 
            // btnUpdateIndexMapping
            // 
            this.btnUpdateIndexMapping.Location = new System.Drawing.Point(137, 21);
            this.btnUpdateIndexMapping.Name = "btnUpdateIndexMapping";
            this.btnUpdateIndexMapping.Size = new System.Drawing.Size(114, 23);
            this.btnUpdateIndexMapping.TabIndex = 3;
            this.btnUpdateIndexMapping.Text = "更新指數對照表";
            this.btnUpdateIndexMapping.UseVisualStyleBackColor = true;
            this.btnUpdateIndexMapping.Click += new System.EventHandler(this.btnUpdateIndexMapping_Click);
            // 
            // btnRecalculateIndex
            // 
            this.btnRecalculateIndex.Location = new System.Drawing.Point(17, 21);
            this.btnRecalculateIndex.Name = "btnRecalculateIndex";
            this.btnRecalculateIndex.Size = new System.Drawing.Size(114, 23);
            this.btnRecalculateIndex.TabIndex = 2;
            this.btnRecalculateIndex.Text = "重新計算所有指標";
            this.btnRecalculateIndex.UseVisualStyleBackColor = true;
            this.btnRecalculateIndex.Click += new System.EventHandler(this.btnRecalculateIndex_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "開始日期";
            // 
            // txtStartDate
            // 
            this.txtStartDate.Location = new System.Drawing.Point(74, 21);
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.Size = new System.Drawing.Size(145, 22);
            this.txtStartDate.TabIndex = 4;
            // 
            // DataGetterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 365);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lstMessage);
            this.Controls.Add(this.groupBox1);
            this.Name = "DataGetterForm";
            this.Text = "資料下載";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.ListBox lstMessage;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRecalculateIndex;
        private System.Windows.Forms.Button btnUpdateIndexMapping;
        private System.Windows.Forms.TextBox txtStartDate;
        private System.Windows.Forms.Label label3;
    }
}