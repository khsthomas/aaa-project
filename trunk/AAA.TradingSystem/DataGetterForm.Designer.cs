﻿namespace AAA.TradingSystem
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
            this.txtStartDate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDownload = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lstMessage = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnUpdateIndexMapping = new System.Windows.Forms.Button();
            this.btnRecalculateIndex = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtDeleteDate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.chkCalculateIndex = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkCalculateIndex);
            this.groupBox1.Controls.Add(this.txtStartDate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnDownload);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 121);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "股票資料收集";
            // 
            // txtStartDate
            // 
            this.txtStartDate.Location = new System.Drawing.Point(74, 21);
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.Size = new System.Drawing.Size(145, 22);
            this.txtStartDate.TabIndex = 4;
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
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(144, 70);
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtDeleteDate);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.btnDelete);
            this.groupBox3.Location = new System.Drawing.Point(265, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(236, 121);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "股票資料維護";
            // 
            // txtDeleteDate
            // 
            this.txtDeleteDate.Location = new System.Drawing.Point(74, 21);
            this.txtDeleteDate.Name = "txtDeleteDate";
            this.txtDeleteDate.Size = new System.Drawing.Size(145, 22);
            this.txtDeleteDate.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "刪除日期";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(74, 64);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "刪除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // chkCalculateIndex
            // 
            this.chkCalculateIndex.AutoSize = true;
            this.chkCalculateIndex.Location = new System.Drawing.Point(17, 99);
            this.chkCalculateIndex.Name = "chkCalculateIndex";
            this.chkCalculateIndex.Size = new System.Drawing.Size(96, 16);
            this.chkCalculateIndex.TabIndex = 5;
            this.chkCalculateIndex.Text = "計算技術指標";
            this.chkCalculateIndex.UseVisualStyleBackColor = true;
            // 
            // DataGetterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 365);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lstMessage);
            this.Controls.Add(this.groupBox1);
            this.Name = "DataGetterForm";
            this.Text = "交易資料下載";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtDeleteDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.CheckBox chkCalculateIndex;
    }
}