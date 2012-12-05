namespace AAA.ProgramTrade
{
    partial class DataExportForm
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
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cboBaseSymbolId = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lstField = new System.Windows.Forms.CheckedListBox();
            this.btnAddSymbol = new System.Windows.Forms.Button();
            this.tblMergeSymbolId = new System.Windows.Forms.DataGridView();
            this.btnDeleteSymbol = new System.Windows.Forms.Button();
            this.btnUpdateField = new System.Windows.Forms.Button();
            this.tabFunction = new System.Windows.Forms.TabControl();
            this.pnlMerge = new System.Windows.Forms.TabPage();
            this.pnlExport = new System.Windows.Forms.TabPage();
            this.txtExportDirectory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMergedSymbolId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboMergeBaseSymbolId = new System.Windows.Forms.ComboBox();
            this.btnMerge = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tblMergeSymbolId)).BeginInit();
            this.tabFunction.SuspendLayout();
            this.pnlMerge.SuspendLayout();
            this.pnlExport.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(306, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 12;
            this.btnRefresh.Text = "更新列表";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cboBaseSymbolId
            // 
            this.cboBaseSymbolId.FormattingEnabled = true;
            this.cboBaseSymbolId.Location = new System.Drawing.Point(67, 12);
            this.cboBaseSymbolId.Name = "cboBaseSymbolId";
            this.cboBaseSymbolId.Size = new System.Drawing.Size(233, 20);
            this.cboBaseSymbolId.TabIndex = 11;
            this.cboBaseSymbolId.SelectedIndexChanged += new System.EventHandler(this.cboBaseSymbolId_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "商品名稱";
            // 
            // lstField
            // 
            this.lstField.FormattingEnabled = true;
            this.lstField.Location = new System.Drawing.Point(12, 38);
            this.lstField.Name = "lstField";
            this.lstField.Size = new System.Drawing.Size(378, 89);
            this.lstField.TabIndex = 13;
            // 
            // btnAddSymbol
            // 
            this.btnAddSymbol.Location = new System.Drawing.Point(67, 133);
            this.btnAddSymbol.Name = "btnAddSymbol";
            this.btnAddSymbol.Size = new System.Drawing.Size(75, 23);
            this.btnAddSymbol.TabIndex = 14;
            this.btnAddSymbol.Text = "新增商品";
            this.btnAddSymbol.UseVisualStyleBackColor = true;
            this.btnAddSymbol.Click += new System.EventHandler(this.btnAddSymbol_Click);
            // 
            // tblMergeSymbolId
            // 
            this.tblMergeSymbolId.AllowUserToAddRows = false;
            this.tblMergeSymbolId.AllowUserToDeleteRows = false;
            this.tblMergeSymbolId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tblMergeSymbolId.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblMergeSymbolId.Location = new System.Drawing.Point(10, 162);
            this.tblMergeSymbolId.Name = "tblMergeSymbolId";
            this.tblMergeSymbolId.RowHeadersVisible = false;
            this.tblMergeSymbolId.RowTemplate.Height = 24;
            this.tblMergeSymbolId.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblMergeSymbolId.Size = new System.Drawing.Size(380, 125);
            this.tblMergeSymbolId.TabIndex = 21;
            // 
            // btnDeleteSymbol
            // 
            this.btnDeleteSymbol.Location = new System.Drawing.Point(148, 133);
            this.btnDeleteSymbol.Name = "btnDeleteSymbol";
            this.btnDeleteSymbol.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteSymbol.TabIndex = 25;
            this.btnDeleteSymbol.Text = "刪除商品";
            this.btnDeleteSymbol.UseVisualStyleBackColor = true;
            this.btnDeleteSymbol.Click += new System.EventHandler(this.btnDeleteSymbol_Click);
            // 
            // btnUpdateField
            // 
            this.btnUpdateField.Location = new System.Drawing.Point(229, 133);
            this.btnUpdateField.Name = "btnUpdateField";
            this.btnUpdateField.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateField.TabIndex = 26;
            this.btnUpdateField.Text = "修改欄位";
            this.btnUpdateField.UseVisualStyleBackColor = true;
            this.btnUpdateField.Click += new System.EventHandler(this.btnUpdateField_Click);
            // 
            // tabFunction
            // 
            this.tabFunction.Controls.Add(this.pnlMerge);
            this.tabFunction.Controls.Add(this.pnlExport);
            this.tabFunction.Location = new System.Drawing.Point(10, 293);
            this.tabFunction.Name = "tabFunction";
            this.tabFunction.SelectedIndex = 0;
            this.tabFunction.Size = new System.Drawing.Size(380, 116);
            this.tabFunction.TabIndex = 27;
            // 
            // pnlMerge
            // 
            this.pnlMerge.Controls.Add(this.btnMerge);
            this.pnlMerge.Controls.Add(this.cboMergeBaseSymbolId);
            this.pnlMerge.Controls.Add(this.txtMergedSymbolId);
            this.pnlMerge.Controls.Add(this.label4);
            this.pnlMerge.Controls.Add(this.label3);
            this.pnlMerge.Location = new System.Drawing.Point(4, 21);
            this.pnlMerge.Name = "pnlMerge";
            this.pnlMerge.Padding = new System.Windows.Forms.Padding(3);
            this.pnlMerge.Size = new System.Drawing.Size(372, 91);
            this.pnlMerge.TabIndex = 0;
            this.pnlMerge.Text = "資料合併";
            this.pnlMerge.UseVisualStyleBackColor = true;
            // 
            // pnlExport
            // 
            this.pnlExport.Controls.Add(this.txtExportDirectory);
            this.pnlExport.Controls.Add(this.label1);
            this.pnlExport.Controls.Add(this.btnExport);
            this.pnlExport.Location = new System.Drawing.Point(4, 21);
            this.pnlExport.Name = "pnlExport";
            this.pnlExport.Padding = new System.Windows.Forms.Padding(3);
            this.pnlExport.Size = new System.Drawing.Size(372, 91);
            this.pnlExport.TabIndex = 1;
            this.pnlExport.Text = "資料輸出";
            this.pnlExport.UseVisualStyleBackColor = true;
            // 
            // txtExportDirectory
            // 
            this.txtExportDirectory.Location = new System.Drawing.Point(68, 13);
            this.txtExportDirectory.Name = "txtExportDirectory";
            this.txtExportDirectory.Size = new System.Drawing.Size(298, 22);
            this.txtExportDirectory.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 26;
            this.label1.Text = "輸出路徑";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(145, 51);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 25;
            this.btnExport.Text = "輪出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 28;
            this.label3.Text = "基準商品";
            // 
            // txtMergedSymbolId
            // 
            this.txtMergedSymbolId.Location = new System.Drawing.Point(79, 34);
            this.txtMergedSymbolId.Name = "txtMergedSymbolId";
            this.txtMergedSymbolId.Size = new System.Drawing.Size(287, 22);
            this.txtMergedSymbolId.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 30;
            this.label4.Text = "合併後名稱";
            // 
            // cboMergeBaseSymbolId
            // 
            this.cboMergeBaseSymbolId.FormattingEnabled = true;
            this.cboMergeBaseSymbolId.Location = new System.Drawing.Point(79, 9);
            this.cboMergeBaseSymbolId.Name = "cboMergeBaseSymbolId";
            this.cboMergeBaseSymbolId.Size = new System.Drawing.Size(287, 20);
            this.cboMergeBaseSymbolId.TabIndex = 32;
            // 
            // btnMerge
            // 
            this.btnMerge.Location = new System.Drawing.Point(147, 62);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(75, 23);
            this.btnMerge.TabIndex = 33;
            this.btnMerge.Text = "合併";
            this.btnMerge.UseVisualStyleBackColor = true;
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            // 
            // DataExportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 412);
            this.Controls.Add(this.tabFunction);
            this.Controls.Add(this.btnUpdateField);
            this.Controls.Add(this.btnDeleteSymbol);
            this.Controls.Add(this.tblMergeSymbolId);
            this.Controls.Add(this.btnAddSymbol);
            this.Controls.Add(this.lstField);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.cboBaseSymbolId);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DataExportForm";
            this.Text = "資料輸出";
            ((System.ComponentModel.ISupportInitialize)(this.tblMergeSymbolId)).EndInit();
            this.tabFunction.ResumeLayout(false);
            this.pnlMerge.ResumeLayout(false);
            this.pnlMerge.PerformLayout();
            this.pnlExport.ResumeLayout(false);
            this.pnlExport.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox cboBaseSymbolId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox lstField;
        private System.Windows.Forms.Button btnAddSymbol;
        private System.Windows.Forms.DataGridView tblMergeSymbolId;
        private System.Windows.Forms.Button btnDeleteSymbol;
        private System.Windows.Forms.Button btnUpdateField;
        private System.Windows.Forms.TabControl tabFunction;
        private System.Windows.Forms.TabPage pnlMerge;
        private System.Windows.Forms.TabPage pnlExport;
        private System.Windows.Forms.TextBox txtExportDirectory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TextBox txtMergedSymbolId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboMergeBaseSymbolId;
        private System.Windows.Forms.Button btnMerge;
    }
}