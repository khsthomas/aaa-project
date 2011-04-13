namespace AAA.ATS.QuoteMonitor
{
    partial class TestChartForm
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
            this.ccContainer = new AAA.Chart.Component.ChartContainer();
            this.SuspendLayout();
            // 
            // ccContainer
            // 
            this.ccContainer.EndIndex = -1;
            this.ccContainer.Location = new System.Drawing.Point(5, 7);
            this.ccContainer.Name = "ccContainer";
            this.ccContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.ccContainer.Size = new System.Drawing.Size(464, 340);
            this.ccContainer.StartIndex = -1;
            this.ccContainer.TabIndex = 0;
            this.ccContainer.XScale = 1;
            // 
            // TestChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 353);
            this.Controls.Add(this.ccContainer);
            this.Name = "TestChartForm";
            this.Text = "TestChartForm";
            this.ResumeLayout(false);

        }

        #endregion

        private AAA.Chart.Component.ChartContainer ccContainer;
    }
}