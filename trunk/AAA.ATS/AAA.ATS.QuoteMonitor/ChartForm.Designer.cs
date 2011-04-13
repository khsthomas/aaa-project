namespace AAA.ATS.QuoteMonitor
{
    partial class ChartForm
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
            this.ccChartContainer = new AAA.Chart.Component.ChartContainer();
            this.SuspendLayout();
            // 
            // ccChartContainer
            // 
            this.ccChartContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ccChartContainer.EndIndex = -1;
            this.ccChartContainer.Location = new System.Drawing.Point(7, 7);
            this.ccChartContainer.Name = "ccChartContainer";
            this.ccChartContainer.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.ccChartContainer.Size = new System.Drawing.Size(552, 333);
            this.ccChartContainer.StartIndex = 0;
            this.ccChartContainer.TabIndex = 0;
            this.ccChartContainer.XScale = 5;
            // 
            // ChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 348);
            this.Controls.Add(this.ccChartContainer);
            this.Name = "ChartForm";
            this.Text = "ChartForm";
            this.ResumeLayout(false);

        }

        #endregion

        private AAA.Chart.Component.ChartContainer ccChartContainer;

    }
}