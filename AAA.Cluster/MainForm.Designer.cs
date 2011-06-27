namespace AAA.Cluster
{
    partial class MainForm
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
            this.tabFunction = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.gbField = new System.Windows.Forms.GroupBox();
            this.chkDataField = new System.Windows.Forms.CheckedListBox();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.tabFunction.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gbField.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabFunction
            // 
            this.tabFunction.Controls.Add(this.tabPage1);
            this.tabFunction.Controls.Add(this.tabPage2);
            this.tabFunction.Location = new System.Drawing.Point(12, 12);
            this.tabFunction.Name = "tabFunction";
            this.tabFunction.SelectedIndex = 0;
            this.tabFunction.Size = new System.Drawing.Size(844, 563);
            this.tabFunction.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gbField);
            this.tabPage1.Controls.Add(this.btnLoadData);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(836, 538);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Cluster";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(836, 538);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Investment";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnLoadData
            // 
            this.btnLoadData.Location = new System.Drawing.Point(15, 6);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(75, 23);
            this.btnLoadData.TabIndex = 0;
            this.btnLoadData.Text = "1. Load Data";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // gbField
            // 
            this.gbField.Controls.Add(this.chkDataField);
            this.gbField.Location = new System.Drawing.Point(15, 35);
            this.gbField.Name = "gbField";
            this.gbField.Size = new System.Drawing.Size(201, 180);
            this.gbField.TabIndex = 1;
            this.gbField.TabStop = false;
            this.gbField.Text = "2. 資料欄位";
            // 
            // chkDataField
            // 
            this.chkDataField.FormattingEnabled = true;
            this.chkDataField.Location = new System.Drawing.Point(6, 21);
            this.chkDataField.Name = "chkDataField";
            this.chkDataField.Size = new System.Drawing.Size(189, 157);
            this.chkDataField.TabIndex = 0;
            // 
            // openFile
            // 
            this.openFile.FileName = "*.csv";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 587);
            this.Controls.Add(this.tabFunction);
            this.Name = "MainForm";
            this.Text = "Hiratical Similarity Future Cluster";
            this.tabFunction.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.gbField.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabFunction;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.GroupBox gbField;
        private System.Windows.Forms.CheckedListBox chkDataField;
        private System.Windows.Forms.OpenFileDialog openFile;
    }
}

