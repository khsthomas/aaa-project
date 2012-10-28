namespace AAA.ProgramTrade
{
    partial class AccountManagement
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtAccountType = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCAPassword = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txtCAPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnChangeMode = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cboMode = new System.Windows.Forms.ComboBox();
            this.btnStartSchedule = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtAccountType);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtCAPassword);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.txtCAPath);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.txtUsername);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 177);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "帳號設定";
            // 
            // txtAccountType
            // 
            this.txtAccountType.Location = new System.Drawing.Point(56, 118);
            this.txtAccountType.Name = "txtAccountType";
            this.txtAccountType.Size = new System.Drawing.Size(131, 22);
            this.txtAccountType.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "帳號別";
            // 
            // txtCAPassword
            // 
            this.txtCAPassword.Location = new System.Drawing.Point(56, 92);
            this.txtCAPassword.Name = "txtCAPassword";
            this.txtCAPassword.PasswordChar = '*';
            this.txtCAPassword.Size = new System.Drawing.Size(131, 22);
            this.txtCAPassword.TabIndex = 14;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(7, 95);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(45, 12);
            this.label24.TabIndex = 13;
            this.label24.Text = "CA密碼";
            // 
            // txtCAPath
            // 
            this.txtCAPath.Location = new System.Drawing.Point(56, 67);
            this.txtCAPath.Name = "txtCAPath";
            this.txtCAPath.Size = new System.Drawing.Size(131, 22);
            this.txtCAPath.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "CA路徑";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(65, 146);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "連線";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(56, 41);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(131, 22);
            this.txtPassword.TabIndex = 3;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(56, 15);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(131, 22);
            this.txtUsername.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "密碼";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "帳號";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnChangeMode);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cboMode);
            this.groupBox2.Location = new System.Drawing.Point(13, 195);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 81);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "交易模式";
            // 
            // btnChangeMode
            // 
            this.btnChangeMode.Location = new System.Drawing.Point(64, 52);
            this.btnChangeMode.Name = "btnChangeMode";
            this.btnChangeMode.Size = new System.Drawing.Size(75, 23);
            this.btnChangeMode.TabIndex = 5;
            this.btnChangeMode.Text = "模式切換";
            this.btnChangeMode.UseVisualStyleBackColor = true;
            this.btnChangeMode.Click += new System.EventHandler(this.btnChangeMode_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "模式";
            // 
            // cboMode
            // 
            this.cboMode.FormattingEnabled = true;
            this.cboMode.Location = new System.Drawing.Point(55, 21);
            this.cboMode.Name = "cboMode";
            this.cboMode.Size = new System.Drawing.Size(121, 20);
            this.cboMode.TabIndex = 0;
            // 
            // btnStartSchedule
            // 
            this.btnStartSchedule.Location = new System.Drawing.Point(77, 285);
            this.btnStartSchedule.Name = "btnStartSchedule";
            this.btnStartSchedule.Size = new System.Drawing.Size(75, 23);
            this.btnStartSchedule.TabIndex = 6;
            this.btnStartSchedule.Text = "啟動排程";
            this.btnStartSchedule.UseVisualStyleBackColor = true;
            this.btnStartSchedule.Click += new System.EventHandler(this.btnStartSchedule_Click);
            // 
            // AccountManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 320);
            this.Controls.Add(this.btnStartSchedule);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "AccountManagement";
            this.Text = "帳號管理";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCAPassword;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtCAPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnChangeMode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboMode;
        private System.Windows.Forms.TextBox txtAccountType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnStartSchedule;
    }
}