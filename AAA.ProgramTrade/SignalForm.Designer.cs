namespace AAA.ProgramTrade
{
    partial class SignalForm
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
            this.tabSignals = new System.Windows.Forms.TabControl();
            this.tabSignalCatcher = new System.Windows.Forms.TabPage();
            this.tblSignalCatcher = new System.Windows.Forms.DataGridView();
            this.tabCurrentPosition = new System.Windows.Forms.TabPage();
            this.tblOpenPosition = new System.Windows.Forms.DataGridView();
            this.tabSignal = new System.Windows.Forms.TabPage();
            this.tblSignalList = new System.Windows.Forms.DataGridView();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.tabSignals.SuspendLayout();
            this.tabSignalCatcher.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblSignalCatcher)).BeginInit();
            this.tabCurrentPosition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblOpenPosition)).BeginInit();
            this.tabSignal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblSignalList)).BeginInit();
            this.SuspendLayout();
            // 
            // tabSignals
            // 
            this.tabSignals.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabSignals.Controls.Add(this.tabSignalCatcher);
            this.tabSignals.Controls.Add(this.tabCurrentPosition);
            this.tabSignals.Controls.Add(this.tabSignal);
            this.tabSignals.Location = new System.Drawing.Point(3, 3);
            this.tabSignals.Name = "tabSignals";
            this.tabSignals.SelectedIndex = 0;
            this.tabSignals.Size = new System.Drawing.Size(523, 259);
            this.tabSignals.TabIndex = 0;
            // 
            // tabSignalCatcher
            // 
            this.tabSignalCatcher.Controls.Add(this.tblSignalCatcher);
            this.tabSignalCatcher.Location = new System.Drawing.Point(4, 21);
            this.tabSignalCatcher.Name = "tabSignalCatcher";
            this.tabSignalCatcher.Size = new System.Drawing.Size(515, 234);
            this.tabSignalCatcher.TabIndex = 2;
            this.tabSignalCatcher.Text = "訊號讀取器";
            this.tabSignalCatcher.UseVisualStyleBackColor = true;
            // 
            // tblSignalCatcher
            // 
            this.tblSignalCatcher.AllowUserToAddRows = false;
            this.tblSignalCatcher.AllowUserToDeleteRows = false;
            this.tblSignalCatcher.AllowUserToResizeRows = false;
            this.tblSignalCatcher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblSignalCatcher.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblSignalCatcher.Location = new System.Drawing.Point(0, 0);
            this.tblSignalCatcher.MultiSelect = false;
            this.tblSignalCatcher.Name = "tblSignalCatcher";
            this.tblSignalCatcher.RowHeadersVisible = false;
            this.tblSignalCatcher.RowTemplate.Height = 24;
            this.tblSignalCatcher.Size = new System.Drawing.Size(515, 234);
            this.tblSignalCatcher.TabIndex = 2;
            // 
            // tabCurrentPosition
            // 
            this.tabCurrentPosition.Controls.Add(this.tblOpenPosition);
            this.tabCurrentPosition.Location = new System.Drawing.Point(4, 21);
            this.tabCurrentPosition.Name = "tabCurrentPosition";
            this.tabCurrentPosition.Padding = new System.Windows.Forms.Padding(3);
            this.tabCurrentPosition.Size = new System.Drawing.Size(515, 234);
            this.tabCurrentPosition.TabIndex = 0;
            this.tabCurrentPosition.Text = "目前部位";
            this.tabCurrentPosition.UseVisualStyleBackColor = true;
            // 
            // tblOpenPosition
            // 
            this.tblOpenPosition.AllowUserToAddRows = false;
            this.tblOpenPosition.AllowUserToDeleteRows = false;
            this.tblOpenPosition.AllowUserToResizeRows = false;
            this.tblOpenPosition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblOpenPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblOpenPosition.Location = new System.Drawing.Point(3, 3);
            this.tblOpenPosition.Name = "tblOpenPosition";
            this.tblOpenPosition.RowTemplate.Height = 24;
            this.tblOpenPosition.Size = new System.Drawing.Size(509, 228);
            this.tblOpenPosition.TabIndex = 1;
            // 
            // tabSignal
            // 
            this.tabSignal.Controls.Add(this.tblSignalList);
            this.tabSignal.Location = new System.Drawing.Point(4, 21);
            this.tabSignal.Name = "tabSignal";
            this.tabSignal.Padding = new System.Windows.Forms.Padding(3);
            this.tabSignal.Size = new System.Drawing.Size(515, 234);
            this.tabSignal.TabIndex = 1;
            this.tabSignal.Text = "交易訊號";
            this.tabSignal.UseVisualStyleBackColor = true;
            // 
            // tblSignalList
            // 
            this.tblSignalList.AllowUserToAddRows = false;
            this.tblSignalList.AllowUserToDeleteRows = false;
            this.tblSignalList.AllowUserToResizeRows = false;
            this.tblSignalList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblSignalList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblSignalList.Location = new System.Drawing.Point(3, 3);
            this.tblSignalList.MultiSelect = false;
            this.tblSignalList.Name = "tblSignalList";
            this.tblSignalList.ReadOnly = true;
            this.tblSignalList.RowHeadersVisible = false;
            this.tblSignalList.RowTemplate.Height = 24;
            this.tblSignalList.Size = new System.Drawing.Size(509, 228);
            this.tblSignalList.TabIndex = 1;
            // 
            // lstLog
            // 
            this.lstLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstLog.FormattingEnabled = true;
            this.lstLog.ItemHeight = 12;
            this.lstLog.Location = new System.Drawing.Point(7, 264);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(515, 88);
            this.lstLog.TabIndex = 1;
            // 
            // SignalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 363);
            this.Controls.Add(this.lstLog);
            this.Controls.Add(this.tabSignals);
            this.Name = "SignalForm";
            this.Text = "交易訊號";
            this.tabSignals.ResumeLayout(false);
            this.tabSignalCatcher.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblSignalCatcher)).EndInit();
            this.tabCurrentPosition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblOpenPosition)).EndInit();
            this.tabSignal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblSignalList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabSignals;
        private System.Windows.Forms.TabPage tabCurrentPosition;
        private System.Windows.Forms.TabPage tabSignal;
        private System.Windows.Forms.DataGridView tblOpenPosition;
        private System.Windows.Forms.DataGridView tblSignalList;
        private System.Windows.Forms.TabPage tabSignalCatcher;
        private System.Windows.Forms.DataGridView tblSignalCatcher;
        private System.Windows.Forms.ListBox lstLog;
    }
}