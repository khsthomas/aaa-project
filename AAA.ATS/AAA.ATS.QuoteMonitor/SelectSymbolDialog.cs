using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AAA.ATS.QuoteMonitor
{
    public partial class SelectSymbolDialog : Form
    {
        public SelectSymbolDialog()
        {
            InitializeComponent();
        }

        private void rbDaysRange_Click(object sender, EventArgs e)
        {
            gbBetween.Visible = rbBetween.Checked;
            gbDaysBack.Visible = rbDaysBack.Checked;
        }

        private void rbVolumeType_Click(object sender, EventArgs e)
        {
            if(rbTradeVolume.Checked)
            {
                rbVolumeBar.Text = "Volume Bar";
                lblVolumeBar.Text = "(in 100s)";
            }

            if (rbTickCount.Checked)
            {
                rbVolumeBar.Text = "Tick Bar";
                lblVolumeBar.Text = "Ticks";
            }
        }
    }
}
