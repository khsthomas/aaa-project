using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AAA.AGS.Client;
using AAA.Meta.Quote;
using AAA.Meta.Quote.Data;

namespace AAA.AGS.ClientTest
{
    public partial class Form1 : Form
    {
        private MQClient _mqClient;
        public Form1()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            _mqClient = new MQClient();
            _mqClient.DataHandler += new DataHandler(OnDataReceive);            
        }

        private void OnDataReceive(QuoteData quoteData)
        {
            try
            {
                if(quoteData.SymbolId == "TWFE_TFHTX")
                    Console.WriteLine("OnDataReceive : " + quoteData.SymbolId + "," + quoteData.LastUpdateTime);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "," + ex.StackTrace);
            }
        }

        private void btnQuote_Click(object sender, EventArgs e)
        {
            try
            {
                //_mqClient.SetStartDateTime(DateTime.Parse("2011/08/15 10:44:00"));
                _mqClient.StartService();
            }
            catch (Exception ex)
            {

            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                _mqClient.Disconnect();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
