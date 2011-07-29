using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AAA.QuoteClient;
using AAA.Meta.Quote.Data;

namespace AAA.QuoteClien.QuoteTest
{
    public partial class MainForm : Form
    {
        private DefaultQuoteClient _defaultQuoteClient;
        public MainForm()
        {
            InitializeComponent();
            _defaultQuoteClient = new DefaultQuoteClient();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Dictionary<string, string> dicProperty = new Dictionary<string, string>();
                dicProperty.Add("SymbolId", "TWFE_TFHTX");
                dicProperty.Add("StartDateTime", "2011/07/20");
                dicProperty.Add("EndDateTime", "2011/07/20");

//                List<TickInfo> lstTicks = _defaultQuoteClient.GetTodayTick("TWFE_TFHTX");

                List<BarData> lstBarData = _defaultQuoteClient.GetBarData(dicProperty);

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                _defaultQuoteClient.DeleteHistoryQueueData();
            }
            catch (Exception ex)
            {
            }
        }
    }
}
