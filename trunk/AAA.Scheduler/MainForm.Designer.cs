namespace AAA.Scheduler
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
            this.tblSetting = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.tblSetting)).BeginInit();
            this.SuspendLayout();
            // 
            // tblSetting
            // 
            this.tblSetting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblSetting.Location = new System.Drawing.Point(12, 12);
            this.tblSetting.Name = "tblSetting";
            this.tblSetting.RowTemplate.Height = 24;
            this.tblSetting.Size = new System.Drawing.Size(282, 253);
            this.tblSetting.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 279);
            this.Controls.Add(this.tblSetting);
            this.Name = "Form1";
            this.Text = "Scheduler";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblSetting)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView tblSetting;
    }
}

