namespace AAA.ProgramTrade
{
    partial class APIFuturesForm
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
            this.btnSend = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tblOutputGrandChildren = new System.Windows.Forms.DataGridView();
            this.tblOutputChildren = new System.Windows.Forms.DataGridView();
            this.tblOutputParent = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tblInputChildren = new System.Windows.Forms.DataGridView();
            this.tblInputParent = new System.Windows.Forms.DataGridView();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.tabFunction = new System.Windows.Forms.TabControl();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.txtAccountType = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblOutputGrandChildren)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblOutputChildren)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblOutputParent)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblInputChildren)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblInputParent)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(759, 469);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 11;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tblOutputGrandChildren);
            this.groupBox2.Controls.Add(this.tblOutputChildren);
            this.groupBox2.Controls.Add(this.tblOutputParent);
            this.groupBox2.Location = new System.Drawing.Point(513, 65);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(488, 401);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Output";
            // 
            // tblOutputGrandChildren
            // 
            this.tblOutputGrandChildren.AllowUserToAddRows = false;
            this.tblOutputGrandChildren.AllowUserToDeleteRows = false;
            this.tblOutputGrandChildren.AllowUserToResizeRows = false;
            this.tblOutputGrandChildren.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblOutputGrandChildren.Location = new System.Drawing.Point(6, 308);
            this.tblOutputGrandChildren.Name = "tblOutputGrandChildren";
            this.tblOutputGrandChildren.RowHeadersVisible = false;
            this.tblOutputGrandChildren.RowTemplate.Height = 24;
            this.tblOutputGrandChildren.Size = new System.Drawing.Size(476, 86);
            this.tblOutputGrandChildren.TabIndex = 3;
            // 
            // tblOutputChildren
            // 
            this.tblOutputChildren.AllowUserToAddRows = false;
            this.tblOutputChildren.AllowUserToDeleteRows = false;
            this.tblOutputChildren.AllowUserToResizeRows = false;
            this.tblOutputChildren.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblOutputChildren.Location = new System.Drawing.Point(6, 165);
            this.tblOutputChildren.Name = "tblOutputChildren";
            this.tblOutputChildren.RowHeadersVisible = false;
            this.tblOutputChildren.RowTemplate.Height = 24;
            this.tblOutputChildren.Size = new System.Drawing.Size(476, 137);
            this.tblOutputChildren.TabIndex = 2;
            // 
            // tblOutputParent
            // 
            this.tblOutputParent.AllowUserToAddRows = false;
            this.tblOutputParent.AllowUserToDeleteRows = false;
            this.tblOutputParent.AllowUserToResizeRows = false;
            this.tblOutputParent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblOutputParent.Location = new System.Drawing.Point(6, 21);
            this.tblOutputParent.Name = "tblOutputParent";
            this.tblOutputParent.RowHeadersVisible = false;
            this.tblOutputParent.RowTemplate.Height = 24;
            this.tblOutputParent.Size = new System.Drawing.Size(476, 138);
            this.tblOutputParent.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tblInputChildren);
            this.groupBox1.Controls.Add(this.tblInputParent);
            this.groupBox1.Location = new System.Drawing.Point(4, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(488, 401);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input";
            // 
            // tblInputChildren
            // 
            this.tblInputChildren.AllowUserToAddRows = false;
            this.tblInputChildren.AllowUserToDeleteRows = false;
            this.tblInputChildren.AllowUserToResizeRows = false;
            this.tblInputChildren.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblInputChildren.Location = new System.Drawing.Point(6, 228);
            this.tblInputChildren.MultiSelect = false;
            this.tblInputChildren.Name = "tblInputChildren";
            this.tblInputChildren.RowHeadersVisible = false;
            this.tblInputChildren.RowTemplate.Height = 24;
            this.tblInputChildren.Size = new System.Drawing.Size(476, 166);
            this.tblInputChildren.TabIndex = 1;
            // 
            // tblInputParent
            // 
            this.tblInputParent.AllowUserToAddRows = false;
            this.tblInputParent.AllowUserToDeleteRows = false;
            this.tblInputParent.AllowUserToResizeRows = false;
            this.tblInputParent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblInputParent.Location = new System.Drawing.Point(6, 21);
            this.tblInputParent.MultiSelect = false;
            this.tblInputParent.Name = "tblInputParent";
            this.tblInputParent.RowHeadersVisible = false;
            this.tblInputParent.RowTemplate.Height = 24;
            this.tblInputParent.Size = new System.Drawing.Size(476, 201);
            this.tblInputParent.TabIndex = 0;
            this.tblInputParent.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tblInputParent_KeyUp);
            // 
            // lstLog
            // 
            this.lstLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstLog.FormattingEnabled = true;
            this.lstLog.ItemHeight = 12;
            this.lstLog.Location = new System.Drawing.Point(12, 503);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(983, 88);
            this.lstLog.TabIndex = 8;
            // 
            // tabFunction
            // 
            this.tabFunction.Location = new System.Drawing.Point(12, 30);
            this.tabFunction.Name = "tabFunction";
            this.tabFunction.SelectedIndex = 0;
            this.tabFunction.Size = new System.Drawing.Size(989, 29);
            this.tabFunction.TabIndex = 13;
            this.tabFunction.SelectedIndexChanged += new System.EventHandler(this.tabFunction_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "帳號";
            // 
            // txtAccount
            // 
            this.txtAccount.Location = new System.Drawing.Point(47, 6);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(164, 22);
            this.txtAccount.TabIndex = 15;
            // 
            // txtAccountType
            // 
            this.txtAccountType.Location = new System.Drawing.Point(259, 6);
            this.txtAccountType.Name = "txtAccountType";
            this.txtAccountType.Size = new System.Drawing.Size(40, 22);
            this.txtAccountType.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(224, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = "類別";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(340, 6);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(164, 22);
            this.txtPassword.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(305, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 18;
            this.label3.Text = "密碼";
            // 
            // APIFuturesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 599);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAccountType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAccount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabFunction);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lstLog);
            this.Name = "APIFuturesForm";
            this.Text = "期貨API測試";
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblOutputGrandChildren)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblOutputChildren)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblOutputParent)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblInputChildren)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblInputParent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView tblOutputChildren;
        private System.Windows.Forms.DataGridView tblOutputParent;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView tblInputParent;
        private System.Windows.Forms.ListBox lstLog;
        private System.Windows.Forms.TabControl tabFunction;
        private System.Windows.Forms.DataGridView tblOutputGrandChildren;
        private System.Windows.Forms.DataGridView tblInputChildren;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.TextBox txtAccountType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label3;
    }
}