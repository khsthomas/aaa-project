namespace AAA.ImageMatching
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
            this.picGoldenImage = new System.Windows.Forms.PictureBox();
            this.picCompare = new System.Windows.Forms.PictureBox();
            this.picResult = new System.Windows.Forms.PictureBox();
            this.txtGoldenImage = new System.Windows.Forms.TextBox();
            this.txtCompareImage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCompare = new System.Windows.Forms.Button();
            this.txtTollence = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picGoldenImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCompare)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).BeginInit();
            this.SuspendLayout();
            // 
            // picGoldenImage
            // 
            this.picGoldenImage.Location = new System.Drawing.Point(12, 12);
            this.picGoldenImage.Name = "picGoldenImage";
            this.picGoldenImage.Size = new System.Drawing.Size(337, 320);
            this.picGoldenImage.TabIndex = 0;
            this.picGoldenImage.TabStop = false;
            // 
            // picCompare
            // 
            this.picCompare.Location = new System.Drawing.Point(367, 12);
            this.picCompare.Name = "picCompare";
            this.picCompare.Size = new System.Drawing.Size(337, 320);
            this.picCompare.TabIndex = 1;
            this.picCompare.TabStop = false;
            // 
            // picResult
            // 
            this.picResult.Location = new System.Drawing.Point(722, 12);
            this.picResult.Name = "picResult";
            this.picResult.Size = new System.Drawing.Size(337, 320);
            this.picResult.TabIndex = 2;
            this.picResult.TabStop = false;
            // 
            // txtGoldenImage
            // 
            this.txtGoldenImage.Location = new System.Drawing.Point(96, 356);
            this.txtGoldenImage.Name = "txtGoldenImage";
            this.txtGoldenImage.Size = new System.Drawing.Size(277, 22);
            this.txtGoldenImage.TabIndex = 3;
            this.txtGoldenImage.Text = "01.JPG";
            // 
            // txtCompareImage
            // 
            this.txtCompareImage.Location = new System.Drawing.Point(96, 384);
            this.txtCompareImage.Name = "txtCompareImage";
            this.txtCompareImage.Size = new System.Drawing.Size(277, 22);
            this.txtCompareImage.TabIndex = 4;
            this.txtCompareImage.Text = "01-1.JPG";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 359);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "Golden Image";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 387);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "Compare Image";
            // 
            // btnCompare
            // 
            this.btnCompare.Location = new System.Drawing.Point(422, 387);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(75, 23);
            this.btnCompare.TabIndex = 7;
            this.btnCompare.Text = "Compare";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // txtTollence
            // 
            this.txtTollence.Location = new System.Drawing.Point(396, 356);
            this.txtTollence.Name = "txtTollence";
            this.txtTollence.Size = new System.Drawing.Size(100, 22);
            this.txtTollence.TabIndex = 8;
            this.txtTollence.Text = "50";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(503, 388);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 423);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtTollence);
            this.Controls.Add(this.btnCompare);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCompareImage);
            this.Controls.Add(this.txtGoldenImage);
            this.Controls.Add(this.picResult);
            this.Controls.Add(this.picCompare);
            this.Controls.Add(this.picGoldenImage);
            this.Name = "MainForm";
            this.Text = "Defect Matching";
            ((System.ComponentModel.ISupportInitialize)(this.picGoldenImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCompare)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picGoldenImage;
        private System.Windows.Forms.PictureBox picCompare;
        private System.Windows.Forms.PictureBox picResult;
        private System.Windows.Forms.TextBox txtGoldenImage;
        private System.Windows.Forms.TextBox txtCompareImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.TextBox txtTollence;
        private System.Windows.Forms.Button button1;
    }
}

