namespace AAA.TradingSystem
{
    partial class UserDefineSymbolForm
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
            this.cboGroupId = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.tblSource = new System.Windows.Forms.DataGridView();
            this.tblTarget = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSymbolId = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.tblSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblTarget)).BeginInit();
            this.SuspendLayout();
            // 
            // cboGroupId
            // 
            this.cboGroupId.FormattingEnabled = true;
            this.cboGroupId.Location = new System.Drawing.Point(12, 26);
            this.cboGroupId.Name = "cboGroupId";
            this.cboGroupId.Size = new System.Drawing.Size(121, 20);
            this.cboGroupId.TabIndex = 0;
            this.cboGroupId.SelectedIndexChanged += new System.EventHandler(this.cboGroupId_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "群組名稱";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(139, 23);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "儲存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(220, 23);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "刪除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // tblSource
            // 
            this.tblSource.AllowUserToAddRows = false;
            this.tblSource.AllowUserToDeleteRows = false;
            this.tblSource.AllowUserToResizeColumns = false;
            this.tblSource.AllowUserToResizeRows = false;
            this.tblSource.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.tblSource.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblSource.Location = new System.Drawing.Point(12, 69);
            this.tblSource.Name = "tblSource";
            this.tblSource.ReadOnly = true;
            this.tblSource.RowHeadersVisible = false;
            this.tblSource.RowTemplate.Height = 24;
            this.tblSource.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblSource.Size = new System.Drawing.Size(181, 185);
            this.tblSource.TabIndex = 4;
            this.tblSource.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblSource_CellDoubleClick);
            // 
            // tblTarget
            // 
            this.tblTarget.AllowUserToAddRows = false;
            this.tblTarget.AllowUserToDeleteRows = false;
            this.tblTarget.AllowUserToResizeColumns = false;
            this.tblTarget.AllowUserToResizeRows = false;
            this.tblTarget.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.tblTarget.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblTarget.Location = new System.Drawing.Point(238, 95);
            this.tblTarget.Name = "tblTarget";
            this.tblTarget.ReadOnly = true;
            this.tblTarget.RowHeadersVisible = false;
            this.tblTarget.RowTemplate.Height = 24;
            this.tblTarget.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblTarget.Size = new System.Drawing.Size(181, 159);
            this.tblTarget.TabIndex = 5;
            this.tblTarget.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblTarget_CellDoubleClick);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(199, 125);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(33, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = ">";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(199, 154);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(33, 23);
            this.btnRemove.TabIndex = 7;
            this.btnRemove.Text = "<";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(238, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "商品代碼";
            // 
            // txtSymbolId
            // 
            this.txtSymbolId.Location = new System.Drawing.Point(297, 66);
            this.txtSymbolId.Name = "txtSymbolId";
            this.txtSymbolId.Size = new System.Drawing.Size(122, 22);
            this.txtSymbolId.TabIndex = 9;
            this.txtSymbolId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSymbolId_KeyDown);
            // 
            // UserDefineSymbolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 266);
            this.Controls.Add(this.txtSymbolId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.tblTarget);
            this.Controls.Add(this.tblSource);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboGroupId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "UserDefineSymbolForm";
            this.Text = "自選股設定";
            this.Load += new System.EventHandler(this.UserDefineSymbolForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblTarget)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboGroupId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView tblSource;
        private System.Windows.Forms.DataGridView tblTarget;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSymbolId;
    }
}