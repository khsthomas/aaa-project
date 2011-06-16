namespace AAA.AGS.Server
{
    partial class AdvancedGlobalServerForm
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
            this.tabModule = new System.Windows.Forms.TabControl();
            this.pnlSymbolPortfolio = new System.Windows.Forms.TabPage();
            this.pnlSymbolMonitor = new System.Windows.Forms.TabPage();
            this.tblSymbolMonitor = new System.Windows.Forms.DataGridView();
            this.tabModule.SuspendLayout();
            this.pnlSymbolMonitor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblSymbolMonitor)).BeginInit();
            this.SuspendLayout();
            // 
            // tabModule
            // 
            this.tabModule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabModule.Controls.Add(this.pnlSymbolPortfolio);
            this.tabModule.Controls.Add(this.pnlSymbolMonitor);
            this.tabModule.Location = new System.Drawing.Point(9, 6);
            this.tabModule.Name = "tabModule";
            this.tabModule.SelectedIndex = 0;
            this.tabModule.Size = new System.Drawing.Size(850, 358);
            this.tabModule.TabIndex = 0;
            // 
            // pnlSymbolPortfolio
            // 
            this.pnlSymbolPortfolio.Location = new System.Drawing.Point(4, 21);
            this.pnlSymbolPortfolio.Name = "pnlSymbolPortfolio";
            this.pnlSymbolPortfolio.Padding = new System.Windows.Forms.Padding(3);
            this.pnlSymbolPortfolio.Size = new System.Drawing.Size(842, 333);
            this.pnlSymbolPortfolio.TabIndex = 0;
            this.pnlSymbolPortfolio.Text = "Symbol Portfolio";
            this.pnlSymbolPortfolio.UseVisualStyleBackColor = true;
            // 
            // pnlSymbolMonitor
            // 
            this.pnlSymbolMonitor.Controls.Add(this.tblSymbolMonitor);
            this.pnlSymbolMonitor.Location = new System.Drawing.Point(4, 21);
            this.pnlSymbolMonitor.Name = "pnlSymbolMonitor";
            this.pnlSymbolMonitor.Padding = new System.Windows.Forms.Padding(3);
            this.pnlSymbolMonitor.Size = new System.Drawing.Size(842, 333);
            this.pnlSymbolMonitor.TabIndex = 1;
            this.pnlSymbolMonitor.Text = "Symbol Monitor";
            this.pnlSymbolMonitor.UseVisualStyleBackColor = true;
            // 
            // tblSymbolMonitor
            // 
            this.tblSymbolMonitor.AllowUserToAddRows = false;
            this.tblSymbolMonitor.AllowUserToDeleteRows = false;
            this.tblSymbolMonitor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tblSymbolMonitor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblSymbolMonitor.Location = new System.Drawing.Point(0, 0);
            this.tblSymbolMonitor.Name = "tblSymbolMonitor";
            this.tblSymbolMonitor.ReadOnly = true;
            this.tblSymbolMonitor.RowTemplate.Height = 24;
            this.tblSymbolMonitor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblSymbolMonitor.Size = new System.Drawing.Size(842, 333);
            this.tblSymbolMonitor.TabIndex = 0;
            this.tblSymbolMonitor.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblSymbolMonitor_CellContentDoubleClick);
            // 
            // AdvancedGlobalServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 366);
            this.Controls.Add(this.tabModule);
            this.Name = "AdvancedGlobalServerForm";
            this.Text = "Advanced Global Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdvancedGlobalServerForm_FormClosing);
            this.tabModule.ResumeLayout(false);
            this.pnlSymbolMonitor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblSymbolMonitor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabModule;
        private System.Windows.Forms.TabPage pnlSymbolPortfolio;
        private System.Windows.Forms.TabPage pnlSymbolMonitor;
        private System.Windows.Forms.DataGridView tblSymbolMonitor;
    }
}

