namespace AAA.BlogPublisher
{
    partial class PublishForm
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
            this.gbAuto = new System.Windows.Forms.GroupBox();
            this.gbCheck = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // gbAuto
            // 
            this.gbAuto.Location = new System.Drawing.Point(12, 12);
            this.gbAuto.Name = "gbAuto";
            this.gbAuto.Size = new System.Drawing.Size(212, 222);
            this.gbAuto.TabIndex = 0;
            this.gbAuto.TabStop = false;
            this.gbAuto.Text = "不需認證網站";
            // 
            // gbCheck
            // 
            this.gbCheck.Location = new System.Drawing.Point(250, 12);
            this.gbCheck.Name = "gbCheck";
            this.gbCheck.Size = new System.Drawing.Size(212, 222);
            this.gbCheck.TabIndex = 1;
            this.gbCheck.TabStop = false;
            this.gbCheck.Text = "需認證網站";
            // 
            // PublishForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 365);
            this.Controls.Add(this.gbCheck);
            this.Controls.Add(this.gbAuto);
            this.Name = "PublishForm";
            this.Text = "自動文章發佈系統";
            this.Load += new System.EventHandler(this.PublishForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbAuto;
        private System.Windows.Forms.GroupBox gbCheck;
    }
}

