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
using AAA.TradeLanguage;
using AAA.TradeLanguage.Data;
using AAA.Trade;
using AAA.IntellectOrder.Data;

namespace AAA.IntellectOrder
{
    public partial class QuoteForm : Form
    {
        private const string BUY = "買進";
        private const string SELL = "賣出";

        private PolarisBase _polarisBase;
        private AccountInfo _accountInfo;
        private StockFiveTickStructure _tickStructure;
        private WatchListStructure _watchListStructure;
        private Dictionary<string, SymbolQuoteSummary> _dicSymbolQuoteSummary;
        private readonly string[] QUOTE_INDEX_FLAGS = new string[] { "7", "10"};
        private const string FORM_TEXT = "期權下單系統 - 測試版";
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
            Text = FORM_TEXT;

            _dicSymbolQuoteSummary = new Dictionary<string, SymbolQuoteSummary>();
            InitParam();
            InitTable();
        }

        private string GetQuoteSymbolCode()
        {
            string strSymbolId = "";
            
            ContractInfo contractInfo = null;
            
            
            switch(cboSymbolType.Text)
            {
                case SymbolCodeHelper.FUTURES_BIG:
                    strSymbolId =  (cboMonth.Text == "近月")
                                ?   "3,7799"
                                :   "3,77" + SymbolUtil.NextMonthContract(DateTime.Now).Month.ToString("00");
                    break;
                case SymbolCodeHelper.FUTURES_SMALL:
                    strSymbolId = (cboMonth.Text == "近月")
                                ? "3,7796"
                                : "3,77" + SymbolUtil.NextMonthContract(DateTime.Now).Month.ToString("00");
                    break;
                case SymbolCodeHelper.OPTIONS_CALL:
                case SymbolCodeHelper.OPTIONS_PUT:
                    contractInfo = (cboMonth.Text == "近月")
                                    ?   SymbolUtil.HotContract(DateTime.Now)
                                    :   SymbolUtil.NextMonthContract(DateTime.Now);


                    strSymbolId = "3," + SymbolCodeHelper.QuerySymbolCode(SymbolCodeHelper.OPTIONS,
                                                                           txtStrikePrice.Text,
                                                                           cboSymbolType.Text.IndexOf(SymbolCodeHelper.OPTIONS_CALL) > -1
                                                                            ? SymbolCodeHelper.OPTIONS_CALL
                                                                            : SymbolCodeHelper.OPTIONS_PUT,
                                                                            contractInfo.Year.ToString(),
                                                                            contractInfo.Month.ToString());
                    break;                
            }

            return strSymbolId;
        }

        private string GetOrderSymbolCode()
        {
            string strSymbolId = "";

            ContractInfo contractInfo = (cboMonth.Text == "近月")
                                            ? SymbolUtil.HotContract(DateTime.Now)
                                            : SymbolUtil.NextMonthContract(DateTime.Now);

            strSymbolId = SymbolCodeHelper.QuerySymbolCode(cboSymbolType.Text,
                                                           txtStrikePrice.Text,
                                                           cboSymbolType.Text,
                                                           contractInfo.Year.ToString(),
                                                           contractInfo.Month.ToString());
            return strSymbolId;
        }


        private void InitParam()
        {
            cboSymbolType.Items.Add(SymbolCodeHelper.OPTIONS_CALL);
            cboSymbolType.Items.Add(SymbolCodeHelper.OPTIONS_PUT);
            cboSymbolType.Items.Add(SymbolCodeHelper.FUTURES_BIG);
            cboSymbolType.SelectedIndex = 0;

            cboMonth.Items.Add("近月");
            cboMonth.Items.Add("遠月");
            cboMonth.SelectedIndex = 0;

            cboOrderType1.Items.Add(BUY);
            cboOrderType1.Items.Add(SELL);
            cboOrderType1.SelectedIndex = 0;

            cboOrderType2.Items.Add(BUY);
            cboOrderType2.Items.Add(SELL);
            cboOrderType2.SelectedIndex = 0;
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

            tblQuoteList.Columns.Add("SymbolName", "商品");
            tblQuoteList.Columns.Add("QuoteSymbolCode", "報價商品");
            tblQuoteList.Columns.Add("OrderSymbolCode", "下單商品商品");
            

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            SymbolQuoteSummary quoteSummary;
            try
            {
                _accountInfo = new AccountInfo();
                _accountInfo.AccountNo = txtAccount.Text;
                _accountInfo.AccountType = txtAccountType.Text;
                _accountInfo.Password = txtPassword.Text;
                
                _polarisBase.InitProgram(_accountInfo);

                while (cboTradeSymbol1.Items.Count > 0)
                    cboTradeSymbol1.Items.RemoveAt(0);

                while (cboTradeSymbol2.Items.Count > 0)
                    cboTradeSymbol2.Items.RemoveAt(0);

                _dicSymbolQuoteSummary = new Dictionary<string, SymbolQuoteSummary>();
                for (int i = 0; i < tblQuoteList.Rows.Count; i++)
                {
                    quoteSummary = new SymbolQuoteSummary();
                   
                    quoteSummary.SymbolName = tblQuoteList.Rows[i].Cells["SymbolName"].Value.ToString();
                    quoteSummary.SymbolQuoteCode = tblQuoteList.Rows[i].Cells["QuoteSymbolCode"].Value.ToString();
                    quoteSummary.SymbolOrderCode = tblQuoteList.Rows[i].Cells["OrderSymbolCode"].Value.ToString();

                    cboTradeSymbol1.Items.Add(quoteSummary.SymbolName);
                    cboTradeSymbol2.Items.Add(quoteSummary.SymbolName);

                    try
                    {
                        _dicSymbolQuoteSummary.Add(quoteSummary.SymbolQuoteCode, quoteSummary);
                    }
                    catch { }
                }

                if (cboTradeSymbol1.Items.Count > 0)
                    cboTradeSymbol1.SelectedIndex = 0;

                if (cboTradeSymbol2.Items.Count > 0)
                    cboTradeSymbol2.SelectedIndex = 0;

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
            string[] strValues;

            try
            {
                if (dicReturn.ContainsKey("name") == false)
                    return;

                if (dicReturn["name"].ToString() == "Login")
                {
                    Text += "    Login-" + ((Dictionary<string, object>)dicReturn["Children0"])["Name"].ToString();
                    tQuote.Interval = 1000;
                    tQuote.Enabled = true;

                    dicParam = new Dictionary<string, object>();
                    dicParam.Add("Count", tblQuoteList.Rows.Count * QUOTE_INDEX_FLAGS.Length);

                    for (int i = 0; i < tblQuoteList.Rows.Count; i++)
                    {
                        strValues = tblQuoteList.Rows[i].Cells["QuoteSymbolCode"].Value.ToString().Split(',');
                        for (int j = 0; j < QUOTE_INDEX_FLAGS.Length; j++)
                        {
                            dicSymbol = new Dictionary<string, string>();
                            dicSymbol.Add("Index", QUOTE_INDEX_FLAGS[j]);
                            dicSymbol.Add("MarketNo", strValues[0]);
                            dicSymbol.Add("StockCode", strValues[1]);
                            dicParam.Add("Children" + (i * QUOTE_INDEX_FLAGS.Length + j).ToString(), dicSymbol);
                        }
                    }
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
                SymbolQuoteSummary quoteSummary;
                for (int i = 0; i < int.Parse(dicReturn["RecordCount"].ToString()); i++)
                {
                    dicChildren = (Dictionary<string, object>)dicReturn["Children" + i];
                    fDecimal = (float)Math.Pow(10, int.Parse(dicChildren["Decimal"].ToString()));
                    oRowValues = new object[] { dicChildren["StockCode"].ToString(),
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
                                                dicChildren["BVol1"].ToString(),
                                                dicChildren["BVol2"].ToString(),
                                                dicChildren["BVol3"].ToString(),
                                                dicChildren["BVol4"].ToString(),
                                                dicChildren["BVol5"].ToString(),
                                                dicChildren["SVol1"].ToString(),
                                                dicChildren["SVol2"].ToString(),
                                                dicChildren["SVol3"].ToString(),
                                                dicChildren["SVol4"].ToString(),
                                                dicChildren["SVol5"].ToString(),
                                              };

                    if (_dicSymbolQuoteSummary.ContainsKey((string)oRowValues[0]))
                    {
                        quoteSummary = _dicSymbolQuoteSummary[(string)oRowValues[0]];
                        for (int j = 0; j < 5; j++)
                        {
                            quoteSummary.SetPrice(SymbolQuoteSummary.BUY, j, float.Parse(oRowValues[1 + j].ToString()));
                            quoteSummary.SetPrice(SymbolQuoteSummary.SELL, j, float.Parse(oRowValues[6 + j].ToString()));
                            quoteSummary.SetVolume(SymbolQuoteSummary.BUY, j, int.Parse(oRowValues[11 + j].ToString()));
                            quoteSummary.SetVolume(SymbolQuoteSummary.SELL, j, int.Parse(oRowValues[16 + j].ToString()));
                        }
                        quoteSummary.UpdateAccuVolume(SymbolQuoteSummary.BUY, 0);
                        quoteSummary.UpdateAccuVolume(SymbolQuoteSummary.SELL, 0);
                    }
                        

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
            string[] strValues;
        
            dicValue.Add("Count", tblQuoteList.Rows.Count.ToString());

            for (int i = 0; i < tblQuoteList.Rows.Count; i++)
            {
                strValues = tblQuoteList.Rows[i].Cells["QuoteSymbolCode"].Value.ToString().Split(',');
                dicSymbol = new Dictionary<string, string>();
                dicSymbol.Add("MarketNo", strValues[0]);
                dicSymbol.Add("StockCode", strValues[1]);

                dicValue.Add("Children" + i, dicSymbol);
            }
            _polarisBase.MessageSend(_tickStructure.ApiId, dicValue);

        }

        private void tQuote_Tick(object sender, EventArgs e)
        {
            Quote();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> dicValue = new Dictionary<string, object>();
            _dicSymbolQuoteSummary = null;
            //Dictionary<string, string> dicSymbol;
        

            DataGridViewUtil.Clear(tblQuote);
            DataGridViewUtil.Clear(tblQuoteList);

            dicValue.Add("Count", "0");
            _polarisBase.MessageSend(_tickStructure.ApiId, dicValue);

            tQuote.Enabled = false;
            _polarisBase.Logout();

            Text = FORM_TEXT;
        }

        private void QuoteForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tQuote.Enabled)
                tQuote.Enabled = false;

            if (_polarisBase != null)
                if(_polarisBase.IsConnected)
                    _polarisBase.Logout();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string strSymbolName = cboSymbolType.Text + 
                                   cboMonth.Text + 
                                   ((cboSymbolType.Text == SymbolCodeHelper.FUTURES_BIG) 
                                        ?   ""
                                        :   txtStrikePrice.Text);

            string strQuoteSymbolId = GetQuoteSymbolCode();
            string strOrderSymbolId = GetOrderSymbolCode();

            if (DataGridViewUtil.FindRowIndex(tblQuoteList,
                                             new string[] { "SymbolName" },
                                             new object[] { strSymbolName }) < 0)
                DataGridViewUtil.InsertRow(tblQuoteList, new object[] { strSymbolName, strQuoteSymbolId, strOrderSymbolId });
            else
                DataGridViewUtil.UpdateRow(tblQuoteList, new string[] { "SymbolName" }, new object[] { strSymbolName, strQuoteSymbolId, strOrderSymbolId });
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            SymbolQuoteSummary quoteSummary1 = null;
            SymbolQuoteSummary quoteSummary2 = null;
            float fBestPrice;

            try
            {
                foreach (SymbolQuoteSummary quoteSummary in _dicSymbolQuoteSummary.Values)
                {
                    if (quoteSummary.SymbolName == cboTradeSymbol1.Text)
                    {
                        quoteSummary1 = quoteSummary;
                        fBestPrice = quoteSummary.BestPrice(cboOrderType1.Text == BUY
                                                           ?   SymbolQuoteSummary.BUY : SymbolQuoteSummary.SELL,
                                                         int.Parse(txtCanOrderQty1.Text));
                        if(float.IsNaN(fBestPrice))
                        {
                            txtCanOrderQty1.BackColor = Color.Red;
                            txtCanOrderQty1.Text = "";
                        }
                        else
                        {
                            txtCanOrderQty1.BackColor = Color.Green;
                            txtCanOrderQty1.Text = fBestPrice.ToString();
                        }
                    }

                    if (quoteSummary.SymbolName == cboTradeSymbol2.Text)
                    {
                        quoteSummary2 = quoteSummary;
                        fBestPrice = quoteSummary.BestPrice(cboOrderType1.Text == BUY
                                                           ?   SymbolQuoteSummary.BUY : SymbolQuoteSummary.SELL,
                                                         int.Parse(txtCanOrderQty1.Text));
                        if(float.IsNaN(fBestPrice))
                        {
                            txtCanOrderQty2.BackColor = Color.Red;
                            txtCanOrderQty2.Text = "";
                        }
                        else
                        {
                            txtCanOrderQty2.BackColor = Color.Green;
                            txtCanOrderQty2.Text = fBestPrice.ToString();
                        }

                    }

                    if((quoteSummary1 != null) && (quoteSummary2 != null))
                        break;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }

    }
}
