namespace AAA.TradingSystem
{
    partial class HappyZoneMasterForm
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
            this.tblSymbolGrid = new System.Windows.Forms.DataGridView();
            this.gbSetup = new System.Windows.Forms.GroupBox();
            this.txtChannelLen = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtSymbolName = new System.Windows.Forms.TextBox();
            this.txtSymbolId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStopMultipler = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAddMultiple = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtATRLen = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tblSymbolGrid)).BeginInit();
            this.gbSetup.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblSymbolGrid
            // 
            this.tblSymbolGrid.AllowUserToAddRows = false;
            this.tblSymbolGrid.AllowUserToDeleteRows = false;
            this.tblSymbolGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tblSymbolGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.tblSymbolGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblSymbolGrid.Location = new System.Drawing.Point(3, 141);
            this.tblSymbolGrid.Name = "tblSymbolGrid";
            this.tblSymbolGrid.ReadOnly = true;
            this.tblSymbolGrid.RowHeadersVisible = false;
            this.tblSymbolGrid.RowTemplate.Height = 24;
            this.tblSymbolGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblSymbolGrid.Size = new System.Drawing.Size(449, 258);
            this.tblSymbolGrid.TabIndex = 0;
            this.tblSymbolGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblSymbolGrid_CellDoubleClick);
            this.tblSymbolGrid.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblSymbolGrid_CellContentDoubleClick);
            // 
            // gbSetup
            // 
            this.gbSetup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSetup.Controls.Add(this.txtChannelLen);
            this.gbSetup.Controls.Add(this.label5);
            this.gbSetup.Controls.Add(this.btnSave);
            this.gbSetup.Controls.Add(this.btnModify);
            this.gbSetup.Controls.Add(this.btnDelete);
            this.gbSetup.Controls.Add(this.btnAdd);
            this.gbSetup.Controls.Add(this.txtSymbolName);
            this.gbSetup.Controls.Add(this.txtSymbolId);
            this.gbSetup.Controls.Add(this.label4);
            this.gbSetup.Controls.Add(this.txtStopMultipler);
            this.gbSetup.Controls.Add(this.label3);
            this.gbSetup.Controls.Add(this.txtAddMultiple);
            this.gbSetup.Controls.Add(this.label2);
            this.gbSetup.Controls.Add(this.txtATRLen);
            this.gbSetup.Controls.Add(this.label1);
            this.gbSetup.Location = new System.Drawing.Point(3, 3);
            this.gbSetup.Name = "gbSetup";
            this.gbSetup.Size = new System.Drawing.Size(448, 132);
            this.gbSetup.TabIndex = 1;
            this.gbSetup.TabStop = false;
            this.gbSetup.Text = "設定";
            // 
            // txtChannelLen
            // 
            this.txtChannelLen.Location = new System.Drawing.Point(202, 13);
            this.txtChannelLen.Name = "txtChannelLen";
            this.txtChannelLen.Size = new System.Drawing.Size(65, 22);
            this.txtChannelLen.TabIndex = 14;
            this.txtChannelLen.Text = "6";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(146, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "通道天數";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(273, 97);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "儲存";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(192, 97);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(75, 23);
            this.btnModify.TabIndex = 11;
            this.btnModify.Text = "修改";
            this.btnModify.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(111, 98);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "刪除";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(30, 98);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "新增";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // txtSymbolName
            // 
            this.txtSymbolName.Location = new System.Drawing.Point(10, 41);
            this.txtSymbolName.Name = "txtSymbolName";
            this.txtSymbolName.ReadOnly = true;
            this.txtSymbolName.Size = new System.Drawing.Size(119, 22);
            this.txtSymbolName.TabIndex = 8;
            this.txtSymbolName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSymbolId
            // 
            this.txtSymbolId.Location = new System.Drawing.Point(64, 13);
            this.txtSymbolId.Name = "txtSymbolId";
            this.txtSymbolId.Size = new System.Drawing.Size(65, 22);
            this.txtSymbolId.TabIndex = 7;
            this.txtSymbolId.Text = "2454";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "商品代碼";
            // 
            // txtStopMultipler
            // 
            this.txtStopMultipler.Location = new System.Drawing.Point(342, 71);
            this.txtStopMultipler.Name = "txtStopMultipler";
            this.txtStopMultipler.Size = new System.Drawing.Size(65, 22);
            this.txtStopMultipler.TabIndex = 5;
            this.txtStopMultipler.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(286, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "停損乖數";
            // 
            // txtAddMultiple
            // 
            this.txtAddMultiple.Location = new System.Drawing.Point(342, 43);
            this.txtAddMultiple.Name = "txtAddMultiple";
            this.txtAddMultiple.Size = new System.Drawing.Size(65, 22);
            this.txtAddMultiple.TabIndex = 3;
            this.txtAddMultiple.Text = "1.6";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(286, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "加碼乖數";
            // 
            // txtATRLen
            // 
            this.txtATRLen.Location = new System.Drawing.Point(342, 13);
            this.txtATRLen.Name = "txtATRLen";
            this.txtATRLen.Size = new System.Drawing.Size(65, 22);
            this.txtATRLen.TabIndex = 1;
            this.txtATRLen.Text = "14";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(286, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "ATR天數";
            // 
            // HappyZoneMasterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 411);
            this.Controls.Add(this.gbSetup);
            this.Controls.Add(this.tblSymbolGrid);
            this.Name = "HappyZoneMasterForm";
            this.Text = "Happy Zone監控";
            ((System.ComponentModel.ISupportInitialize)(this.tblSymbolGrid)).EndInit();
            this.gbSetup.ResumeLayout(false);
            this.gbSetup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView tblSymbolGrid;
        private System.Windows.Forms.GroupBox gbSetup;
        private System.Windows.Forms.TextBox txtAddMultiple;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtATRLen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStopMultipler;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSymbolId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSymbolName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtChannelLen;
        private System.Windows.Forms.Label label5;
    }
}