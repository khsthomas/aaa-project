namespace AAA.ProgramTrade
{
    partial class ScheduleForm
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
            this.tblTask = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.tblTask)).BeginInit();
            this.SuspendLayout();
            // 
            // tblTask
            // 
            this.tblTask.AllowUserToAddRows = false;
            this.tblTask.AllowUserToDeleteRows = false;
            this.tblTask.AllowUserToResizeRows = false;
            this.tblTask.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tblTask.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblTask.Location = new System.Drawing.Point(2, 2);
            this.tblTask.Name = "tblTask";
            this.tblTask.RowTemplate.Height = 24;
            this.tblTask.Size = new System.Drawing.Size(580, 358);
            this.tblTask.TabIndex = 0;
            // 
            // ScheduleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 364);
            this.Controls.Add(this.tblTask);
            this.Name = "ScheduleForm";
            this.Text = "工作排程";
            ((System.ComponentModel.ISupportInitialize)(this.tblTask)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView tblTask;
    }
}

