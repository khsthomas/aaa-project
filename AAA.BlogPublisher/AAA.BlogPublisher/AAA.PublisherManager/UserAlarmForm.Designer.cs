namespace AAA.PublisherManager
{
    partial class UserAlarmForm
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
            this.components = new System.ComponentModel.Container();
            this.tblUserList = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tblUserList)).BeginInit();
            this.SuspendLayout();
            // 
            // tblUserList
            // 
            this.tblUserList.AllowUserToAddRows = false;
            this.tblUserList.AllowUserToDeleteRows = false;
            this.tblUserList.AllowUserToResizeRows = false;
            this.tblUserList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblUserList.Location = new System.Drawing.Point(3, 2);
            this.tblUserList.Name = "tblUserList";
            this.tblUserList.ReadOnly = true;
            this.tblUserList.RowHeadersVisible = false;
            this.tblUserList.RowTemplate.Height = 24;
            this.tblUserList.Size = new System.Drawing.Size(525, 318);
            this.tblUserList.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(432, 326);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "更新列表";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // timerRefresh
            // 
            this.timerRefresh.Interval = 3600000;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // UserAlarmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 355);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.tblUserList);
            this.Name = "UserAlarmForm";
            this.Text = "到期列表";
            ((System.ComponentModel.ISupportInitialize)(this.tblUserList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView tblUserList;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Timer timerRefresh;
    }
}