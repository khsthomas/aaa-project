namespace Momentum.Test
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
            this.chkIndicator = new System.Windows.Forms.CheckedListBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.lstMessage = new System.Windows.Forms.ListBox();
            this.btnAttach = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chkIndicator
            // 
            this.chkIndicator.FormattingEnabled = true;
            this.chkIndicator.Location = new System.Drawing.Point(12, 12);
            this.chkIndicator.Name = "chkIndicator";
            this.chkIndicator.Size = new System.Drawing.Size(196, 123);
            this.chkIndicator.TabIndex = 1;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(214, 277);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lstMessage
            // 
            this.lstMessage.FormattingEnabled = true;
            this.lstMessage.ItemHeight = 12;
            this.lstMessage.Location = new System.Drawing.Point(12, 152);
            this.lstMessage.Name = "lstMessage";
            this.lstMessage.Size = new System.Drawing.Size(196, 148);
            this.lstMessage.TabIndex = 3;
            // 
            // btnAttach
            // 
            this.btnAttach.Location = new System.Drawing.Point(214, 248);
            this.btnAttach.Name = "btnAttach";
            this.btnAttach.Size = new System.Drawing.Size(75, 23);
            this.btnAttach.TabIndex = 4;
            this.btnAttach.Text = "Attach";
            this.btnAttach.UseVisualStyleBackColor = true;
            this.btnAttach.Click += new System.EventHandler(this.btnAttach_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 314);
            this.Controls.Add(this.btnAttach);
            this.Controls.Add(this.lstMessage);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.chkIndicator);
            this.Name = "MainForm";
            this.Text = "Testing Form";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox chkIndicator;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ListBox lstMessage;
        private System.Windows.Forms.Button btnAttach;
    }
}

