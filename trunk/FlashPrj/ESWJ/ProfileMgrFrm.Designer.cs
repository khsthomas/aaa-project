namespace ESWJ
{
    partial class ProfileMgrFrm
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
            this.dgProfile = new System.Windows.Forms.DataGridView();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Url1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Url2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // dgProfile
            // 
            this.dgProfile.AllowUserToAddRows = false;
            this.dgProfile.AllowUserToDeleteRows = false;
            this.dgProfile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProfile.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserName,
            this.Pass,
            this.ServerName,
            this.Url1,
            this.Url2});
            this.dgProfile.Location = new System.Drawing.Point(1, 2);
            this.dgProfile.Name = "dgProfile";
            this.dgProfile.ReadOnly = true;
            this.dgProfile.RowHeadersVisible = false;
            this.dgProfile.RowTemplate.Height = 24;
            this.dgProfile.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgProfile.Size = new System.Drawing.Size(544, 337);
            this.dgProfile.TabIndex = 0;
            this.dgProfile.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProfile_CellDoubleClick);
            // 
            // UserName
            // 
            this.UserName.HeaderText = "UserName";
            this.UserName.Name = "UserName";
            // 
            // Pass
            // 
            this.Pass.HeaderText = "Pass";
            this.Pass.Name = "Pass";
            // 
            // ServerName
            // 
            this.ServerName.HeaderText = "ServerName";
            this.ServerName.Name = "ServerName";
            // 
            // Url1
            // 
            this.Url1.HeaderText = "Url1";
            this.Url1.Name = "Url1";
            // 
            // Url2
            // 
            this.Url2.HeaderText = "Url2";
            this.Url2.Name = "Url2";
            // 
            // ProfileMgrFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 343);
            this.ControlBox = false;
            this.Controls.Add(this.dgProfile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProfileMgrFrm";
            this.Text = "ProfileMgr";
            ((System.ComponentModel.ISupportInitialize)(this.dgProfile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgProfile;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pass;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Url1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Url2;
    }
}