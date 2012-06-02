using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AAA.Trade.MonitorSystem
{
    public partial class IndexSimulationForm : Form
    {
        public IndexSimulationForm()
        {
            InitializeComponent();
            wbTWSE.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(wbTWSE_DocumentCompleted);   
        }

        void wbTWSE_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                if (wbTWSE.ReadyState == WebBrowserReadyState.Complete)
                {
                    string strText = wbTWSE.DocumentText;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                wbTWSE.Url = new Uri("http://mis.twse.com.tw/stock_best5.html?stockId=1101");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }
    }
}
