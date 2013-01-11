using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AAA.TradeAPI.Polaris;
using AAA.Meta.Trade.Data;
using AAA.Forms.Components.Util;

namespace AAA.IntellectOrder
{
    public partial class QuoteForm : Form
    {
        private PolarisBase _polarisBase;
        private AccountInfo _accountInfo;
        private StockFiveTickStructure _tickStructure;
        private WatchListStructure _watchListStructure;
        public QuoteForm()
        {
            InitializeComponent();
            _tickStructure = new StockFiveTickStructure();
            _watchListStructure = new WatchListStructure();
            _polarisBase = new PolarisBase();
            _polarisBase.IsAutoLogin = true;
            _polarisBase.OnMessage(new AAA.Meta.Trade.MessageEvent(OnMessageReceive));
            _polarisBase.AddMessageStructure(new OpenStructure());
            _polarisBase.AddMessageStructure(new LoginStructure());
            _polarisBase.AddMessageStructure(new LogoutStructure());
            _polarisBase.AddMessageStructure(_watchListStructure);
            _polarisBase.AddMessageStructure(_tickStructure);
            Text = "";
            InitTable();
        }

        private void InitTable()
        {
            tblQuote.Columns.Add("SymbolId", "代碼");
            tblQuote.Columns.Add("BuyPrice1", "BP1");
            tblQuote.Columns.Add("BuyPrice2", "BP2");
            tblQuote.Columns.Add("BuyPrice3", "BP3");
            tblQuote.Columns.Add("BuyPrice4", "BP4");
            tblQuote.Columns.Add("BuyPrice5", "BP5");
            tblQuote.Columns.Add("SellPrice1", "SP1");
            tblQuote.Columns.Add("SellPrice2", "SP2");
            tblQuote.Columns.Add("SellPrice3", "SP3");
            tblQuote.Columns.Add("SellPrice4", "SP4");
            tblQuote.Columns.Add("SellPrice5", "SP5");
            tblQuote.Columns.Add("BuyVol1", "BV1");
            tblQuote.Columns.Add("BuyVol2", "BV2");
            tblQuote.Columns.Add("BuyVol3", "BV3");
            tblQuote.Columns.Add("BuyVol4", "BV4");
            tblQuote.Columns.Add("BuyVol5", "BV5");
            tblQuote.Columns.Add("SellVol1", "SV1");
            tblQuote.Columns.Add("SellVol2", "SV2");
            tblQuote.Columns.Add("SellVol3", "SV3");
            tblQuote.Columns.Add("SellVol4", "SV4");
            tblQuote.Columns.Add("SellVol5", "SV5");
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                _accountInfo = new AccountInfo();
                _accountInfo.AccountNo = txtAccount.Text;
                _accountInfo.AccountType = txtAccountType.Text;
                _accountInfo.Password = txtPassword.Text;
                _polarisBase.InitProgram(_accountInfo);                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void OnMessageReceive(Dictionary<string, object> dicReturn)
        {
            Dictionary<string, object> dicParam;
            Dictionary<string, string> dicSymbol;
            string[] strValues = txtSymbol.Text.Split(',');

            try
            {
                if (dicReturn.ContainsKey("name") == false)
                    return;

                if (dicReturn["name"].ToString() == "Login")
                {
                    Text = "Login-" + ((Dictionary<string, object>)dicReturn["Children0"])["Name"].ToString();
                    tQuote.Interval = 1000;
                    tQuote.Enabled = true;
//                    Quote();
                    dicParam = new Dictionary<string, object>();
                    dicParam.Add("Count", "1");

                    dicSymbol = new Dictionary<string, string>();
                    dicSymbol.Add("Index", "7");
                    dicSymbol.Add("MarketNo", strValues[0]);
                    dicSymbol.Add("StockCode", strValues[1]);

                    dicParam.Add("Children0", dicSymbol);

                    _polarisBase.MessageSend(_watchListStructure.ApiId,
                                             dicParam);
                    return;
                }

                if (dicReturn["name"].ToString() == _watchListStructure.ClientName)
                {
                    lstPrice.Items.Add(dicReturn["StockCode"].ToString() + "," +
                                       dicReturn["IndexFlag"].ToString() + "," +
                                       dicReturn["Value"].ToString());
                    lstPrice.Invalidate();
                }

                if (dicReturn["name"].ToString() != _tickStructure.ClientName)
                    return;

                if (int.Parse(dicReturn["RecordCount"].ToString()) == 0)
                    return;

                Dictionary<string, object> dicChildren;
                object[] oRowValues;
                float fDecimal;
                for (int i = 0; i < int.Parse(dicReturn["RecordCount"].ToString()); i++)
                {
                    dicChildren = (Dictionary<string, object>)dicReturn["Children" + i];
                    fDecimal = (float)Math.Pow(10, int.Parse(dicChildren["Decimal"].ToString()));
                    oRowValues = new object[] { dicChildren["StockCode"],
                                                (float.Parse(dicChildren["BPrice1"].ToString()) / fDecimal).ToString("0.00"),
                                                (float.Parse(dicChildren["BPrice2"].ToString()) / fDecimal).ToString("0.00"),
                                                (float.Parse(dicChildren["BPrice3"].ToString()) / fDecimal).ToString("0.00"),
                                                (float.Parse(dicChildren["BPrice4"].ToString()) / fDecimal).ToString("0.00"),
                                                (float.Parse(dicChildren["BPrice5"].ToString()) / fDecimal).ToString("0.00"),
                                                (float.Parse(dicChildren["SPrice1"].ToString()) / fDecimal).ToString("0.00"),
                                                (float.Parse(dicChildren["SPrice2"].ToString()) / fDecimal).ToString("0.00"),
                                                (float.Parse(dicChildren["SPrice3"].ToString()) / fDecimal).ToString("0.00"),
                                                (float.Parse(dicChildren["SPrice4"].ToString()) / fDecimal).ToString("0.00"),
                                                (float.Parse(dicChildren["SPrice5"].ToString()) / fDecimal).ToString("0.00"),
                                                dicChildren["BVol1"],
                                                dicChildren["BVol2"],
                                                dicChildren["BVol3"],
                                                dicChildren["BVol4"],
                                                dicChildren["BVol5"],
                                                dicChildren["SVol1"],
                                                dicChildren["SVol2"],
                                                dicChildren["SVol3"],
                                                dicChildren["SVol4"],
                                                dicChildren["SVol5"],
                                              };

                    if (DataGridViewUtil.FindRowIndex(tblQuote, new string[] {"SymbolId"}, new object[] {dicChildren["StockCode"]}) < 0)
                    {
                        DataGridViewUtil.InsertRow(tblQuote, oRowValues);
                    }
                    else
                    {
                        DataGridViewUtil.UpdateRow(tblQuote, new string[] {"SymbolId"}, oRowValues);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void Quote()
        {
            Dictionary<string, object> dicValue = new Dictionary<string, object>();
            Dictionary<string, string> dicSymbol;
            string[] strValues = txtSymbol.Text.Split(',');

            dicValue.Add("Count", "1");
            dicSymbol = new Dictionary<string, string>();
            dicSymbol.Add("MarketNo", strValues[0]);
            dicSymbol.Add("StockCode", strValues[1]);

            dicValue.Add("Children0", dicSymbol);

            _polarisBase.MessageSend(_tickStructure.ApiId, dicValue);

        }

        private void tQuote_Tick(object sender, EventArgs e)
        {
            Quote();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            tQuote.Enabled = false;
            _polarisBase.Logout();
        }

        private void QuoteForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tQuote.Enabled)
                tQuote.Enabled = false;

            if (_polarisBase != null)
                if(_polarisBase.IsConnected)
                    _polarisBase.Logout();
        }
    }
}
