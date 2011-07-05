namespace AAA.DataCorrect
{
    partial class MainForm
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
            this.btnStart = new System.Windows.Forms.Button();
            this.lstMessage = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(189, 112);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(91, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "開始更正資料";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lstMessage
            // 
            this.lstMessage.FormattingEnabled = true;
            this.lstMessage.ItemHeight = 12;
            this.lstMessage.Location = new System.Drawing.Point(12, 12);
            this.lstMessage.Name = "lstMessage";
            this.lstMessage.Size = new System.Drawing.Size(171, 124);
            this.lstMessage.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 147);
            this.Controls.Add(this.lstMessage);
            this.Controls.Add(this.btnStart);
            this.Name = "MainForm";
            this.Text = "資料庫更正";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ListBox lstMessage;
    }
}

