namespace AAA.NHI.Downloader
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
            this.wbNHI = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // wbNHI
            // 
            this.wbNHI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbNHI.Location = new System.Drawing.Point(0, 0);
            this.wbNHI.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbNHI.Name = "wbNHI";
            this.wbNHI.Size = new System.Drawing.Size(1016, 734);
            this.wbNHI.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.Controls.Add(this.wbNHI);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser wbNHI;
    }
}

