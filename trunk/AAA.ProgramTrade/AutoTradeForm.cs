using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AAA.Trade;
using AAA.SPFTrade;
using AAA.Meta.Trade.Data;
using AAA.Forms.Components.Util;
using AAA.Base.Util.Reader;
using AAA.DesignPattern.Observer;
using System.IO;

namespace AAA.ProgramTrade
{
    public partial class AutoTradeForm : Form, IObserver
    {
        private ITrade _autoTrade;
//        private AccountInfo _accountInfo;
        private bool _isStarted;
        private Dictionary<string, object> _dicEquity;
        private Dictionary<string, StrategyInfo> _dicStrategy;
        public AutoTradeForm()
        {
            InitializeComponent();
            try
            {
                _dicStrategy = new Dictionary<string, StrategyInfo>();
                _autoTrade = (ITrade)AAA.DesignPattern.Singleton.SystemParameter.Parameter["AutoTrade"];

                txtAccount.Text = _autoTrade.AccountInfo.IdNo;
                btnConnect.Text = _autoTrade.IsConnected()
                                    ? "中斷"
                                    : "連線";

/*
                // Init Logger
                if (Directory.Exists(Environment.CurrentDirectory + @"\trade_logs") == false)
                    Directory.CreateDirectory(Environment.CurrentDirectory + @"\trade_logs");

                if (AAA.DesignPattern.Singleton.SystemParameter.Parameter["InitTrade"] == null)
                {
                    _autoTrade.OnMessage(new AAA.Meta.Trade.MessageEvent(OnMessageReceive));
                    _autoTrade.AddTradeLogger(new TradeLogger(Environment.CurrentDirectory + @"\trade_logs\autotrade-" + DateTime.Now.ToString("yyyyMMdd") + ".log"));
                    AAA.DesignPattern.Singleton.SystemParameter.Parameter["InitTrade"] = "Y";
                }
*/

                tblTodayEquity.Columns.Add("ItemName", "項目");
                tblTodayEquity.Columns.Add("ItemValue", "值");

                gbStrategy.Left = 210;
                gbStrategy.Top = 5;
                gbOrderStatus.Left = 210;
                gbOrderStatus.Top = 5;

                //商品類別選項
                cboSymbolType.Items.Add("台指");
                cboSymbolType.Items.Add("小台");
                cboSymbolType.Items.Add("選擇權");
                cboSymbolType.Items.Add("選擇權(雙邊)");
                cboSymbolType.Items.Add("選擇權價差");
                cboSymbolType.SelectedIndex = 0;

                cboPriceType.Items.Add("市價單");
                cboPriceType.Items.Add("限價單");
                cboPriceType.SelectedIndex = 0;

                //期貨設定
                cboFutureMonth.Items.Add("當月");
                cboFutureMonth.Items.Add("次月");
                cboFutureMonth.Items.Add("季月1");
                cboFutureMonth.Items.Add("季月2");
                cboFutureMonth.Items.Add("季月3");
                cboFutureMonth.SelectedIndex = 0;

                //選擇權設定
                cboOptionSide.Items.Add("買方");
                cboOptionSide.Items.Add("賣方");
                cboOptionSide.SelectedIndex = 0;

                cboStrikePrice.Items.Add("價平");
                cboStrikePrice.Items.Add("價外一檔");
                cboStrikePrice.Items.Add("價外二檔");
                cboStrikePrice.Items.Add("價外三檔");
                cboStrikePrice.Items.Add("價外四檔");
                cboStrikePrice.Items.Add("價外五檔");
                cboStrikePrice.Items.Add("價外六檔");
                cboStrikePrice.SelectedIndex = 0;

                //選擇權(雙邊)設定
                cboSpreadTwoSideOptionSide.Items.Add("買方");
                cboSpreadTwoSideOptionSide.Items.Add("賣方");
                cboSpreadTwoSideOptionSide.SelectedIndex = 0;

                cboSpreadTwoSideStrikePrice.Items.Add("價平");
                cboSpreadTwoSideStrikePrice.Items.Add("價外一檔");
                cboSpreadTwoSideStrikePrice.Items.Add("價外二檔");
                cboSpreadTwoSideStrikePrice.Items.Add("價外三檔");
                cboSpreadTwoSideStrikePrice.Items.Add("價外四檔");
                cboSpreadTwoSideStrikePrice.Items.Add("價外五檔");
                cboSpreadTwoSideStrikePrice.Items.Add("價外六檔");
                cboSpreadTwoSideStrikePrice.SelectedIndex = 0;

                //價差設定
                cboSpreadSide.Items.Add("買近賣遠");
                cboSpreadSide.Items.Add("買遠賣近");
                cboSpreadSide.SelectedIndex = 0;

                cboSpreadBuyStrikePrice.Items.Add("價平");
                cboSpreadBuyStrikePrice.Items.Add("價外一檔");
                cboSpreadBuyStrikePrice.Items.Add("價外二檔");
                cboSpreadBuyStrikePrice.Items.Add("價外三檔");
                cboSpreadBuyStrikePrice.Items.Add("價外四檔");
                cboSpreadBuyStrikePrice.Items.Add("價外五檔");
                cboSpreadBuyStrikePrice.Items.Add("價外六檔");
                cboSpreadBuyStrikePrice.SelectedIndex = 0;

                cboSpreadSellStrikePrice.Items.Add("價平");
                cboSpreadSellStrikePrice.Items.Add("價外一檔");
                cboSpreadSellStrikePrice.Items.Add("價外二檔");
                cboSpreadSellStrikePrice.Items.Add("價外三檔");
                cboSpreadSellStrikePrice.Items.Add("價外四檔");
                cboSpreadSellStrikePrice.Items.Add("價外五檔");
                cboSpreadSellStrikePrice.Items.Add("價外六檔");
                cboSpreadSellStrikePrice.SelectedIndex = 0;

                //策略列表
                //tblStrategy.Columns.Add("IsActive", "啟動");
                DataGridViewCheckBoxColumn checkBox = new DataGridViewCheckBoxColumn();
                checkBox.Name = "啟動";
                tblStrategy.Columns.Add(checkBox);
                tblStrategy.Columns.Add("Strategy", "策略名稱");
                tblStrategy.Columns.Add("SymbolType", "商品別");
                tblStrategy.Columns.Add("PriceType", "價格別");
                tblStrategy.Columns.Add("DayTrade", "當沖");
                tblStrategy.Columns.Add("Multiple", "下單倍數");
                tblStrategy.Columns.Add("SymbolContent", "商品內容");

                //目前部位
                tblOpenPosition.Columns.Add("code", "商品代碼");
                tblOpenPosition.Columns.Add("ord_no", "委託書號");
                tblOpenPosition.Columns.Add("ord_bs", "買賣別");
                tblOpenPosition.Columns.Add("currency", "幣別");
                tblOpenPosition.Columns.Add("vol", "口數");
                tblOpenPosition.Columns.Add("avg_price", "成交均價");

                //委託回報
                tblTrust.Columns.Add("ord_time", "時間");
                tblTrust.Columns.Add("type", "商品類別");
                tblTrust.Columns.Add("code", "商品代碼");
                tblTrust.Columns.Add("trade_type", "指令別");
                tblTrust.Columns.Add("trade_class", "交易別");
                tblTrust.Columns.Add("price", "委託價");
                tblTrust.Columns.Add("qty", "委託量");
                tblTrust.Columns.Add("contractprice", "成交價");
                tblTrust.Columns.Add("contractqty", "成交量");
                tblTrust.Columns.Add("cancelqty", "刪單量");
                tblTrust.Columns.Add("errorcode", "訊息代碼");
                tblTrust.Columns.Add("errormsg", "錯誤訊息");
                tblTrust.Columns.Add("oct", "倉別");
                tblTrust.Columns.Add("ord_no", "委託書號");
                tblTrust.Columns.Add("ord_seq", "網路單號");

                //手動下單匣
                cboManualSymbolType.Items.Add("台指");
                cboManualSymbolType.Items.Add("小台");
                cboManualSymbolType.Items.Add("選擇權");
                cboManualSymbolType.SelectedIndex = 0;

                cboManualMonth.Items.Add("1");
                cboManualMonth.Items.Add("2");
                cboManualMonth.Items.Add("3");
                cboManualMonth.Items.Add("4");
                cboManualMonth.Items.Add("5");
                cboManualMonth.Items.Add("6");
                cboManualMonth.Items.Add("7");
                cboManualMonth.Items.Add("8");
                cboManualMonth.Items.Add("9");
                cboManualMonth.Items.Add("10");
                cboManualMonth.Items.Add("11");
                cboManualMonth.Items.Add("12");
                cboManualMonth.SelectedIndex = 0;

                cboManualPutOrCall.Items.Add("買權");
                cboManualPutOrCall.Items.Add("賣權");
                cboManualPutOrCall.SelectedIndex = 0;

                cboManualOCType.Items.Add("自動");
                cboManualOCType.Items.Add("新倉");
                cboManualOCType.Items.Add("平倉");
                cboManualOCType.SelectedIndex = 0;

                MessageSubject.Instance().Subject.Attach(this);

                InitReport();
                InitStrategy();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void InitStrategy()
        {
            StreamReader sr = null;
            string strLine;
            string[] strValues;
            try
            {
                if (File.Exists(Environment.CurrentDirectory + @"\cfg\strategy.cfg") == false)
                    return;

                sr = new StreamReader(Environment.CurrentDirectory + @"\cfg\strategy.cfg", Encoding.Default);

                sr.ReadLine();

                while ((strLine = sr.ReadLine()) != null)
                {
                    strValues = strLine.Split('\t');

                    StrategyInfo strategyInfo = new StrategyInfo();                    
                    tblStrategy.Rows.Add(strValues);
                    RestoreStrategy(tblStrategy.Rows.Count - 1);
                    object[] oStragegyInfo = BuildStragegy(strategyInfo);
                    _dicStrategy.Add(strategyInfo.StrategyName, strategyInfo);                    
                }
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
            finally
            {
                if (sr != null)
                    sr.Close();
            }
        }

        private void InitReport()
        {
            try
            {
                if (_autoTrade.IsConnected() == false)
                {
                    MessageBox.Show("請先連線, 謝謝!!");
                    return;
                }
                _autoTrade.GetTodayEquity();
                _autoTrade.GetPositionReport();
                _autoTrade.GetOrderReport(DateTime.Now.ToString("yyyy/MM/dd"), DateTime.Now.ToString("yyyy/MM/dd"));
                _autoTrade.GetDealReport(DateTime.Now.ToString("yyyy/MM/dd"), DateTime.Now.ToString("yyyy/MM/dd"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

/*
        private void OnMessageReceive(Dictionary<string, object> dicReturn)
        {
            string[] strEquityTypes;
            string[] strFields;
            string[] strValues;

            int iRecordCount;
            Dictionary<string, string> dicRecord;
            try
            {
                switch (dicReturn["name"].ToString())
                {
                    case "QueryTodayEquity":

                        _dicEquity = dicReturn;
                        strEquityTypes = (string[])dicReturn["equitytypes"];

                        while (cboEquityType.Items.Count > 0)
                            cboEquityType.Items.RemoveAt(0);

                        for (int i = 0; i < strEquityTypes.Length; i++)
                        {
                            cboEquityType.Items.Add(strEquityTypes[i]);
                        }

                        if (cboEquityType.Items.Count > 0)
                            cboEquityType.SelectedIndex = 0;

                        break;

                    case "QueryTodayPosition":
                        DataGridViewUtil.Clear(tblOpenPosition);

                        iRecordCount = int.Parse(dicReturn["recordcount"].ToString());

                        for (int i = 0; i < iRecordCount; i++)
                        {
                            dicRecord = (Dictionary<string, string>)dicReturn["record" + i];
                            strValues = new string[tblOpenPosition.ColumnCount];
                            for (int j = 0; j < strValues.Length; j++)
                            {
                                strValues[j] = dicRecord[tblOpenPosition.Columns[j].Name].ToString();
                            }
                            DataGridViewUtil.InsertRow(tblOpenPosition, strValues);                            
                        }
                        break;

                    case "QueryOrderListByDiff":
                        DataGridViewUtil.Clear(tblTrust);

                        iRecordCount = int.Parse(dicReturn["recordcount"].ToString());

                        for (int i = 0; i < iRecordCount; i++)
                        {
                            dicRecord = (Dictionary<string, string>)dicReturn["record" + i];
                            strValues = new string[tblTrust.ColumnCount];
                            for (int j = 0; j < strValues.Length; j++)
                            {
                                strValues[j] = dicRecord[tblTrust.Columns[j].Name].ToString();
                            }
                            DataGridViewUtil.InsertRow(tblTrust, strValues);
                        }

                        break;

                }

                MessageInfo messageInfo = new MessageInfo();
                messageInfo.MessageSubject = "OnTradeMessageReceive";
                messageInfo.Message = dicReturn;
                messageInfo.MessageTicks = DateTime.Now.Ticks;
                MessageSubject.Instance().Subject.Notify(messageInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }
*/
/*
        private void btnConnect_Click(object sender, EventArgs e)
        {
            string strRC;
            
            try
            {
                if (btnConnect.Text == "連線")
                {
                    _accountInfo.IdNo = txtUsername.Text;
                    _accountInfo.Password = txtPassword.Text;
                    _accountInfo.CAPassword = txtCAPassword.Text;
                    _accountInfo.CAPath = txtCAPath.Text;                    
                    
                    strRC = (string)_autoTrade.InitProgram(_accountInfo);
                    _autoTrade.Login();
                    _autoTrade.CA();
                    
                    if (_autoTrade.IsConnected())
                        btnConnect.Text = "中斷";
                    btnOpenPosition.Enabled = true;
                    btnTrust.Enabled = true;
                    btnDeal.Enabled = true;
                    btnQueryTodayEquity.Enabled = true;
                    MessageBox.Show(strRC);
                }
                else
                {
                    btnOpenPosition.Enabled = false;
                    btnTrust.Enabled = false;
                    btnDeal.Enabled = false;
                    btnQueryTodayEquity.Enabled = false;
                    _autoTrade.Logout();
                    btnConnect.Text = "連線";
                }
                
                _autoTrade.GetTodayEquity();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }
*/
        private void cboEquityType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] strFields;
            string[] strTitles;
            Dictionary<string, string> dicRecord;
            
            try
            {
                strFields = (string[])_dicEquity["fields"];
                strTitles = (string[])_dicEquity["titles"];

                dicRecord = (Dictionary<string, string>)_dicEquity["record" + cboEquityType.SelectedIndex];
                DataGridViewUtil.Clear(tblTodayEquity);    
                for (int i = 0; i < strFields.Length; i++)
                {
                    if (strTitles[i] == "未啟用")
                        continue;

                    DataGridViewUtil.InsertRow(tblTodayEquity, new string[] { strTitles[i], double.Parse(dicRecord[strFields[i]]).ToString("0.00") });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void cboPriceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
//                pnlFutures.Visible = (cboPriceType.Text == "限價單") && (cboSymbolType.Text == "台指" || cboSymbolType.Text == "小台");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void cboSymbolType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeDisplay(cboSymbolType.Text);
/*
            switch (cboSymbolType.Text)
            {
                case "選擇權":
                    pnlOption.Visible = true;
                    pnlSpread.Visible = false;
                    pnlFutures.Visible = false;
                    pnlSpreadTwoSide.Visible = false;
                    pnlOption.Top = 5;
                    pnlOption.Left = 173;
                    pnlSpread.Top = 5;
                    pnlSpread.Left = 173;
                    pnlSpreadTwoSide.Top = 5;
                    pnlSpreadTwoSide.Left = 173;
                    pnlFutures.Top = 5;
                    pnlFutures.Left = 173;
                    cboPriceType.SelectedIndex = cboPriceType.Items.IndexOf("限價單");
                    break;

                case "選擇權(雙邊)":
                    pnlOption.Visible = false;
                    pnlSpread.Visible = false;
                    pnlFutures.Visible = false;
                    pnlSpreadTwoSide.Visible = true;
                    pnlOption.Top = 5;
                    pnlOption.Left = 173;
                    pnlSpread.Top = 5;
                    pnlSpread.Left = 173;
                    pnlSpreadTwoSide.Top = 5;
                    pnlSpreadTwoSide.Left = 173;
                    pnlFutures.Top = 5;
                    pnlFutures.Left = 173;
                    cboPriceType.SelectedIndex = cboPriceType.Items.IndexOf("限價單");
                    break;

                case "選擇權價差":
                    pnlOption.Visible = false;
                    pnlSpread.Visible = true;
                    pnlFutures.Visible = false;
                    pnlSpreadTwoSide.Visible = false;
                    pnlOption.Top = 5;
                    pnlOption.Left = 173;
                    pnlSpread.Top = 5;
                    pnlSpread.Left = 173;
                    pnlSpreadTwoSide.Top = 5;
                    pnlSpreadTwoSide.Left = 173;
                    pnlFutures.Top = 5;
                    pnlFutures.Left = 173;
                    cboPriceType.SelectedIndex = cboPriceType.Items.IndexOf("限價單");
                    break;

                default:
                    pnlOption.Visible = false;
                    pnlSpread.Visible = false;
                    pnlFutures.Visible = true;
                    pnlSpreadTwoSide.Visible = false;
                    pnlOption.Top = 5;
                    pnlOption.Left = 173;
                    pnlSpread.Top = 5;
                    pnlSpread.Left = 173;
                    pnlSpreadTwoSide.Top = 5;
                    pnlSpreadTwoSide.Left = 173;
                    pnlFutures.Top = 5;
                    pnlFutures.Left = 173;
                    cboPriceType.SelectedIndex = cboPriceType.Items.IndexOf("市價單");
                    break;
            }
 */ 
        }

        private void btnQueryTodayEquity_Click(object sender, EventArgs e)
        {
            try
            {
                _autoTrade.GetTodayEquity();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.TargetSite);
            }
        }

        private void btnOpenPosition_Click(object sender, EventArgs e)
        {
            try
            {
                if (_autoTrade.IsConnected() == false)
                {
                    MessageBox.Show("請先連線, 謝謝!!");
                    return;
                }
                _autoTrade.GetPositionReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void chkStrategySetup_CheckedChanged(object sender, EventArgs e)
        {
            gbStrategy.Left = 210;
            gbStrategy.Top = 5;
            gbOrderStatus.Left = 210;
            gbOrderStatus.Top = 5;
//            gbStrategy.Visible = chkStrategySetup.Checked;
//            gbOrderStatus.Visible = !chkStrategySetup.Checked;
        }

        private void btnTrust_Click(object sender, EventArgs e)
        {
            try
            {
                if (_autoTrade.IsConnected() == false)
                {
                    MessageBox.Show("請先連線, 謝謝!!");
                    return;
                }
                _autoTrade.GetOrderReport(DateTime.Now.ToString("yyyy/MM/dd"), DateTime.Now.ToString("yyyy/MM/dd"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void btnDeal_Click(object sender, EventArgs e)
        {
            try
            {
                if (_autoTrade.IsConnected() == false)
                {
                    MessageBox.Show("請先連線, 謝謝!!");
                    return;
                }
                _autoTrade.GetDealReport(DateTime.Now.ToString("yyyy/MM/dd"), DateTime.Now.ToString("yyyy/MM/dd"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void BuildOrder(OrderInfo orderInfo, SignalInfo signalInfo, StrategyInfo strategyInfo, int iPriceType)
        {
            try
            {                
                orderInfo.OrderType = signalInfo.OrderType;
                orderInfo.FilledPrice = signalInfo.FillPrice;
                orderInfo.Slippage = strategyInfo.Slippage.ToString();
                orderInfo.Symbol = signalInfo.Symbol;
                orderInfo.SymbolCode = _autoTrade.QuerySymbolCode(strategyInfo.SymbolType,
                                                                  "",
                                                                  "",
                                                                  "",
                                                                  strategyInfo.ExpiredMonth);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        #region IObserver Members

        public void Update(object oSource, IMessageInfo miMessage)
        {
            Dictionary<string, string> dicParam;
            try
            {
                switch (miMessage.MessageSubject)
                {
                    case "FilledOrder":
                        SignalInfo signalInfo = (SignalInfo)miMessage.Message;
                        StrategyInfo strategyInfo = null;
                        OrderInfo orderInfo = new OrderInfo();

                        if (_dicStrategy.ContainsKey(signalInfo.Strategy) == false)
                            return;
                        strategyInfo = _dicStrategy[signalInfo.Strategy];

                        switch (strategyInfo.SymbolType)
                        {
                            case "台指":
                                BuildOrder(orderInfo, signalInfo, strategyInfo, 0);
                                _autoTrade.SendOrder(orderInfo);
                                break;

                            case "小台":
                                break;

                        }

                        break;

                    case "OnTradeMessageReceive":
                        string[] strEquityTypes;                        
                        string[] strValues;

                        int iRecordCount;
                        Dictionary<string, string> dicRecord;
                        Dictionary<string, object> dicReturn;

                        dicReturn = (Dictionary<string, object>)miMessage.Message;

                        switch (dicReturn["name"].ToString())
                        {
                            case "QueryTodayEquity":

                                _dicEquity = dicReturn;
                                strEquityTypes = (string[])dicReturn["equitytypes"];

                                while (cboEquityType.Items.Count > 0)
                                    cboEquityType.Items.RemoveAt(0);

                                for (int i = 0; i < strEquityTypes.Length; i++)
                                {
                                    cboEquityType.Items.Add(strEquityTypes[i]);
                                }

                                if (cboEquityType.Items.Count > 0)
                                    cboEquityType.SelectedIndex = 0;

                                break;

                            case "QueryTodayPosition":
                                DataGridViewUtil.Clear(tblOpenPosition);

                                iRecordCount = int.Parse(dicReturn["recordcount"].ToString());

                                for (int i = 0; i < iRecordCount; i++)
                                {
                                    dicRecord = (Dictionary<string, string>)dicReturn["record" + i];
                                    strValues = new string[tblOpenPosition.ColumnCount];
                                    for (int j = 0; j < strValues.Length; j++)
                                    {
                                        strValues[j] = dicRecord[tblOpenPosition.Columns[j].Name].ToString();
                                    }
                                    DataGridViewUtil.InsertRow(tblOpenPosition, strValues);
                                }
                                break;

                            case "QueryOrderListByDiff":
                                DataGridViewUtil.Clear(tblTrust);

                                iRecordCount = int.Parse(dicReturn["recordcount"].ToString());

                                for (int i = 0; i < iRecordCount; i++)
                                {
                                    dicRecord = (Dictionary<string, string>)dicReturn["record" + i];
                                    strValues = new string[tblTrust.ColumnCount];
                                    for (int j = 0; j < strValues.Length; j++)
                                    {
                                        strValues[j] = dicRecord[tblTrust.Columns[j].Name].ToString();
                                    }
                                    DataGridViewUtil.InsertRow(tblTrust, strValues);
                                }

                                break;

                        }

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        #endregion

        private void chkMarketPrice_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                txtManualPrice.Enabled = !chkMarketPrice.Checked;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void SendOrder(string strBuyOrSell)
        {
            if (_autoTrade.IsConnected() == false)
            {
                MessageBox.Show("請先連線, 謝謝!!");
                return;
            }

            OrderInfo orderInfo = new OrderInfo();
            orderInfo.OrderType = (strBuyOrSell == "Buy")
                                    ? (cboManualOCType.Text == "自動" || cboManualOCType.Text == "新倉")
                                        ? "LE" 
                                        : "SX"
                                    : (cboManualOCType.Text == "自動" || cboManualOCType.Text == "新倉")
                                        ? "SE" 
                                        : "LX";

            orderInfo.Year = DateTime.Now.ToString("yyyy");
            orderInfo.Month = cboManualMonth.Text;
            orderInfo.SymbolCode = _autoTrade.QuerySymbolCode(cboManualSymbolType.Text, txtManualStrikePrice.Text, cboManualPutOrCall.Text == "買權" ? "C" : "P", orderInfo.Year, orderInfo.Month);
            orderInfo.IntraDay = chkIntraday.Checked;
            orderInfo.FilledPrice = (chkIntraday.Checked) ? "M" : txtManualPrice.Text;
            orderInfo.FilledVolume = int.Parse(txtManualVol.Text);
            _autoTrade.SendOrder(orderInfo);
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            try
            {
                SendOrder("Buy");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            try
            {
                SendOrder("Sell");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void CancelOrder(string strOrderNo, string strOrderSeq, string strSymbolCode, string strOctType)
        {
            try
            {
                OrderInfo orderInfo = new OrderInfo();
                orderInfo.SymbolCode = strSymbolCode;
                orderInfo.OrderNo = strOrderNo;
                orderInfo.OrderID = strOrderSeq;
                switch (strOctType)
                {
                    case "新倉":
                        orderInfo.OrderType = "E";
                        break;
                    case "平倉":
                        orderInfo.OrderType = "X";
                        break;
                    case "自動":
                        orderInfo.OrderType = " ";
                        break;

                }
                
                _autoTrade.CancelOrder(orderInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            string strOrderNo;
            string strOrderSeq;
            string strSymbolCode;
            string strOctType;

            try
            {
                for (int i = 0; i < tblTrust.Rows.Count; i++)
                {
                    if ((tblTrust.Rows[i].Cells["ord_seq"].Value == null) ||
                       (tblTrust.Rows[i].Cells["ord_no"].Value == null))
                        continue;

                    strOrderNo = tblTrust.Rows[i].Cells["ord_no"].Value.ToString();
                    strOrderSeq = tblTrust.Rows[i].Cells["ord_seq"].Value.ToString();
                    strSymbolCode = tblTrust.Rows[i].Cells["code"].Value.ToString();
                    strOctType = tblTrust.Rows[i].Cells["oct"].Value.ToString();

                    CancelOrder(strOrderNo, strOrderSeq, strSymbolCode, strOctType);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                string strRC;

                if (btnConnect.Text == "連線")
                {
                    strRC = (string)_autoTrade.Login();
                    strRC += "\n" + (string)_autoTrade.CA();
                    MessageBox.Show(strRC);
                    if (_autoTrade.IsConnected())
                        btnConnect.Text = "中斷";

                    IMessageInfo messageInfo = new MessageInfo();
                    messageInfo.MessageSubject = "Login";

                    MessageSubject.Instance().Subject.Notify(messageInfo);
//                    btnOpenPosition.Enabled = true;
//                    btnTrust.Enabled = true;
//                    btnDeal.Enabled = true;
//                    btnQueryTodayEquity.Enabled = true;                    
                }
                else
                {
//                    btnOpenPosition.Enabled = false;
//                    btnTrust.Enabled = false;
//                    btnDeal.Enabled = false;
//                    btnQueryTodayEquity.Enabled = false;
                    _autoTrade.Logout();
                    MessageBox.Show("中斷連線");
                    btnConnect.Text = "連線";

                    IMessageInfo messageInfo = new MessageInfo();
                    messageInfo.MessageSubject = "Logout";

                    MessageSubject.Instance().Subject.Notify(messageInfo);
                }

//                _autoTrade.GetTodayEquity();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }

        }

        private void btnDisplayStrategySetup_Click(object sender, EventArgs e)
        {            
            if (btnDisplayStrategySetup.Text == "顯示策略")
            {
                gbStrategy.Visible = true;
                gbOrderStatus.Visible = false;
                btnDisplayStrategySetup.Text = "隱藏策略";
            }
            else
            {
                gbStrategy.Visible = false;
                gbOrderStatus.Visible = true;
                btnDisplayStrategySetup.Text = "顯示策略";
            }
            gbStrategy.Left = 210;
            gbStrategy.Top = 5;
            gbOrderStatus.Left = 210;
            gbOrderStatus.Top = 5;
        }

        private object[] BuildStragegy(StrategyInfo strategyInfo)
        {
            string strStrategyName;
            string strSymbolType;
            string strPriceType;
            string strDayTrade;
            string strMultiple;
            string strSymbolContent;
            object[] oStrategyInfo = null;
            try
            {
                strStrategyName = txtStrategyName.Text;
                strSymbolType = cboSymbolType.Text;
                strMultiple = txtOrderMultipler.Text;
                strPriceType = cboPriceType.Text;

                strategyInfo.StrategyName = strStrategyName;
                strategyInfo.SymbolType = strSymbolType;
                strategyInfo.PriceType = strPriceType;
                strategyInfo.Multipler = int.Parse(strMultiple);

                switch (strSymbolType)
                {
                    case "台指":
                    case "小台":
                        strategyInfo.IsDayTrade = chkDayTrade.Checked;
                        strategyInfo.Slippage = float.Parse(txtSlippage.Text);
                        strategyInfo.ExpiredMonth = cboFutureMonth.Text;
                        strategyInfo.IsDistinctExitSignal = chkExitSignal.Checked;

                        strSymbolContent = "滑價 : " + txtSlippage.Text + ", 月份 : " + cboFutureMonth.Text + ", 送出平倉訊號 : " + (chkExitSignal.Checked ? "Y" : "N");
                        strDayTrade = chkDayTrade.Checked ? "Y" : "N";
                        oStrategyInfo = new object[] {  chkIsActive.Checked, 
                                                        strStrategyName,
                                                        strSymbolType,
                                                        strPriceType,
                                                        strDayTrade,
                                                        strMultiple,
                                                        strSymbolContent};
                        break;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
            return oStrategyInfo;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                StrategyInfo strategyInfo = new StrategyInfo();
                object[] oStragegyInfo = BuildStragegy(strategyInfo);

                if (_dicStrategy.ContainsKey(strategyInfo.StrategyName))
                {
                    MessageBox.Show(strategyInfo.StrategyName + " 已存在, 請修改策略名稱");
                    return;
                }
                                
                _dicStrategy.Add(strategyInfo.StrategyName, strategyInfo);
                DataGridViewUtil.InsertRow(tblStrategy, oStragegyInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                object[] oStragegyInfo;
                if (_dicStrategy.ContainsKey(txtStrategyName.Text) == false)
                {
                    MessageBox.Show(txtStrategyName.Text + " 不存在, 請重新輸入策略名稱");
                    return;
                }

                oStragegyInfo = BuildStragegy(_dicStrategy[txtStrategyName.Text]);
                DataGridViewUtil.UpdateRow(tblStrategy, new string[] { "Strategy" }, oStragegyInfo);
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
                object[] oStragegyInfo;
                if (_dicStrategy.ContainsKey(txtStrategyName.Text) == false)
                {
                    MessageBox.Show(txtStrategyName.Text + " 不存在, 請重新輸入策略名稱");
                    return;
                }

                oStragegyInfo = BuildStragegy(_dicStrategy[txtStrategyName.Text]);
                _dicStrategy.Remove(txtStrategyName.Text);                
                DataGridViewUtil.DeleteRow(tblStrategy, new string[] { "Strategy" }, oStragegyInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnStart.Text == "啟動")
                {
                    _isStarted = true;
                    btnStart.Text = "停止";
                }
                else
                {
                    _isStarted = false;
                    btnStart.Text = "啟動";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            StreamWriter sw = null;
            try
            {
                string strLine;

                sw = new StreamWriter(Environment.CurrentDirectory + @"\cfg\strategy.cfg", false, Encoding.Default);

                strLine = "";
                for (int i = 0; i < tblStrategy.Columns.Count; i++)
                {
                    strLine += "\t" + tblStrategy.Columns[i].Name;
                }
                sw.WriteLine(strLine.Substring(1));

                for(int i = 0; i < tblStrategy.Rows.Count; i++)
                {
                    strLine = "";
                    for(int j = 0; j < tblStrategy.Columns.Count; j++)
                    {
                        strLine += "\t" + tblStrategy.Rows[i].Cells[j].Value.ToString();
                    }
                    sw.WriteLine(strLine.Substring(1));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
            finally
            {
                if (sw != null)
                    sw.Close();
            }
        }

        private Dictionary<string, string> GenerateParam(string strContent)
        {
            string[] strValues;
            Dictionary<string, string> dicParam = new Dictionary<string, string>();
            strValues = strContent.Split(',');

            for (int i = 0; i < strValues.Length; i++)
            {
                dicParam.Add(strValues[i].Split(':')[0].Trim(),
                             strValues[i].Split(':')[1].Trim());
            }

            return dicParam;
        }

        private void RestoreStrategy(int iRowIndex)
        {
            string strSymbolContent;
            Dictionary<string, string> dicParam;
            try
            {
                strSymbolContent = tblStrategy.Rows[iRowIndex].Cells["SymbolContent"].Value.ToString();
                dicParam = GenerateParam(strSymbolContent);

                switch(tblStrategy.Rows[iRowIndex].Cells["SymbolType"].Value.ToString())
                {
                    default:                        
                        txtStrategyName.Text = tblStrategy.Rows[iRowIndex].Cells["Strategy"].Value.ToString();
                        cboPriceType.SelectedIndex = cboPriceType.Items.IndexOf(tblStrategy.Rows[iRowIndex].Cells["PriceType"].Value.ToString());
                        chkDayTrade.Checked = tblStrategy.Rows[iRowIndex].Cells["DayTrade"].Value.ToString() == "Y";
                        txtOrderMultipler.Text = tblStrategy.Rows[iRowIndex].Cells["Multiple"].Value.ToString();
                        txtSlippage.Text = dicParam["滑價"];
                        chkExitSignal.Checked = dicParam["送出平倉訊號"] == "Y";
                        cboFutureMonth.SelectedIndex = cboFutureMonth.Items.IndexOf(dicParam["月份"]);
                        chkIsActive.Checked = tblStrategy.Rows[iRowIndex].Cells[0].Value.ToString() == "True";
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void ChangeDisplay(string strSymbolType)
        {
            try
            {
                pnlOption.Top = 5;
                pnlOption.Left = 173;
                pnlSpread.Top = 5;
                pnlSpread.Left = 173;
                pnlSpreadTwoSide.Top = 5;
                pnlSpreadTwoSide.Left = 173;
                pnlFutures.Top = 5;
                pnlFutures.Left = 173;

                switch (strSymbolType)
                {
                    case "選擇權":
                        pnlOption.Visible = true;
                        pnlSpread.Visible = false;
                        pnlFutures.Visible = false;
                        pnlSpreadTwoSide.Visible = false;
                        cboPriceType.SelectedIndex = cboPriceType.Items.IndexOf("限價單");
                        break;

                    case "選擇權(雙邊)":
                        pnlOption.Visible = false;
                        pnlSpread.Visible = false;
                        pnlFutures.Visible = false;
                        pnlSpreadTwoSide.Visible = true;
                        cboPriceType.SelectedIndex = cboPriceType.Items.IndexOf("限價單");
                        break;

                    case "選擇權價差":
                        pnlOption.Visible = false;
                        pnlSpread.Visible = true;
                        pnlFutures.Visible = false;
                        pnlSpreadTwoSide.Visible = false;
                        cboPriceType.SelectedIndex = cboPriceType.Items.IndexOf("限價單");
                        break;

                    default:
                        pnlOption.Visible = false;
                        pnlSpread.Visible = false;
                        pnlFutures.Visible = true;
                        pnlSpreadTwoSide.Visible = false;
                        break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void tblStrategy_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int iRowIndex = e.RowIndex;                
               
                if (e.ColumnIndex == 0)                
                    tblStrategy.Rows[iRowIndex].Cells[0].Value = (tblStrategy.Rows[iRowIndex].Cells[0].Value.ToString() == "False");                    
                              

                /*
                                tblStrategy.Columns.Add("IsActive", "啟動");
                                tblStrategy.Columns.Add("Strategy", "策略名稱");
                                tblStrategy.Columns.Add("SymbolType", "商品別");
                                tblStrategy.Columns.Add("PriceType", "價格別");
                                tblStrategy.Columns.Add("DayTrade", "當沖");
                                tblStrategy.Columns.Add("Multiple", "下單倍數");
                                tblStrategy.Columns.Add("SymbolContent", "商品內容");
                */
                ChangeDisplay(tblStrategy.Rows[iRowIndex].Cells["SymbolType"].Value.ToString());
                RestoreStrategy(iRowIndex);
            }
            catch (Exception ex)            
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }
    }
}
