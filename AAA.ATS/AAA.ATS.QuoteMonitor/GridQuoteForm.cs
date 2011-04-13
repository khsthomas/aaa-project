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

namespace AAA.ATS.QuoteMonitor
{
    public partial class GridQuoteForm : Form
    {
        private readonly string[] SYMBOL_MONITOR_HEADER = { "Symbol", "Last Update", "D1", "D2", "D3", "D4", "D5", "D6" };
        private List<string> _lstSymbol;
        private Client _client;

        public GridQuoteForm(Client client)
        {
            InitializeComponent();

            _client = client;
            Init();
        }

        private void Init()
        {
            InitTableHeader();

            _client.DataHandler += new DataHandler(OnDataReceive);
        }

        private void InitTableHeader()
        {
            foreach (string strHeader in SYMBOL_MONITOR_HEADER)
                tblSymbolMonitor.Columns.Add(strHeader, strHeader);
        }

        private void OnDataReceive(QuoteData quoteData)
        {
            
            if (tblSymbolMonitor.InvokeRequired)
            {
                tblSymbolMonitor.Invoke((MethodInvoker)delegate()
                {
                    UpdateTable(quoteData);
                });
            }
            else
            {
                UpdateTable(quoteData);
            }
        }

        private void UpdateTable(QuoteData quoteData)
        {
            try
            {
                int iIndex;
                iIndex = _lstSymbol.IndexOf(quoteData.SymbolId);
                if (iIndex < 0)
                    return;

                tblSymbolMonitor.Rows[iIndex].Cells["Last Update"].Value = quoteData.LastUpdateTime;

                for (int i = 0; i < quoteData.Items.Length; i++)
                {
                    tblSymbolMonitor.Rows[iIndex].Cells[i + 2].Value = quoteData.Items[i];
                }
            }
            catch { }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _client.Register();            
            _lstSymbol = _client.AvailableSymbolList();

            foreach(string strSymbolId in _lstSymbol)
            {
                tblSymbolMonitor.Rows.Add(new string[] { strSymbolId, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), "0", "0", "0", "0", "0", "0" });                
            }

            _client.SetWatchingList(_lstSymbol.ToArray());
            _client.StartService();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _client.Unregister();
        }
    }
}
