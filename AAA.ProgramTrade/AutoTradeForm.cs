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
using AAA.TradeLanguage;
using AAA.TradeLanguage.Data;

namespace AAA.ProgramTrade
{
    public partial class AutoTradeForm : Form, IObserver
    {
        private ITrade _autoTrade;
//        private AccountInfo _accountInfo;
        private bool _isStarted;
        private Dictionary<string, object> _dicEquity;
        private Dictionary<string, StrategyInfo> _dicStrategy;
        private ITradingRule _tradingRule;
        public AutoTradeForm()
        {
            InitializeComponent();
            try
            {
                _dicStrategy = new Dictionary<string, StrategyInfo>();
                _autoTrade = (ITrade)AAA.DesignPattern.Singleton.SystemParameter.Parameter["AutoTrade"];
                _tradingRule = (ITradingRule)AAA.DesignPattern.Singleton.SystemParameter.Parameter["TradingRule"];
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
                cboSymbolType.Items.Add("選擇權買權");
                cboSymbolType.Items.Add("選擇權賣權");
                cboSymbolType.SelectedIndex = 0;

                cboPriceType.Items.Add("市價單");
                cboPriceType.Items.Add("限價單");
                cboPriceType.SelectedIndex = 0;

                //期貨設定
                cboFuturesMonth.Items.Add("近月");
                cboFuturesMonth.Items.Add("遠月");
                cboFuturesMonth.Items.Add("季月1");
                cboFuturesMonth.Items.Add("季月2");
                cboFuturesMonth.Items.Add("季月3");
                cboFuturesMonth.SelectedIndex = 0;

                //選擇權設定
                cboOptionsSide.Items.Add("買方");
                cboOptionsSide.Items.Add("賣方");
                cboOptionsSide.SelectedIndex = 0;

                cboExecutePrice.Items.Add("價平");
                cboExecutePrice.Items.Add("價內");                
                cboExecutePrice.Items.Add("價外");
                cboExecutePrice.SelectedIndex = 0;

                cboPriceZone.Items.Add("0");
                cboPriceZone.Items.Add("1");
                cboPriceZone.Items.Add("2");
                cboPriceZone.Items.Add("3");
                cboPriceZone.Items.Add("4");
                cboPriceZone.Items.Add("5");
                cboPriceZone.Items.Add("6");
                cboPriceZone.Items.Add("7");
                cboPriceZone.Items.Add("8");
                cboPriceZone.SelectedIndex = 0;

                cboOptionsMonth.Items.Add("近月");
                cboOptionsMonth.Items.Add("遠月");
                cboOptionsMonth.Items.Add("季月1");
                cboOptionsMonth.Items.Add("季月2");
                cboOptionsMonth.Items.Add("季月3");
                cboOptionsMonth.SelectedIndex = 0;

                //策略列表
                //tblStrategy.Columns.Add("IsActive", "啟動");
                DataGridViewCheckBoxColumn checkBox = new DataGridViewCheckBoxColumn();
                checkBox.Name = "啟動";
                tblStrategy.Columns.Add(checkBox);
                tblStrategy.Columns.Add("Strategy", "策略名稱");
                tblStrategy.Columns.Add("SymbolType", "商品別");
                tblStrategy.Columns.Add("SymbolSeq", "商品序號");
                tblStrategy.Columns.Add("PriceType", "價格別");
                tblStrategy.Columns.Add("DayTrade", "當沖");
                tblStrategy.Columns.Add("Volume", "下單口數");
                tblStrategy.Columns.Add("ExitSignal", "送出平倉訊號");
                tblStrategy.Columns.Add("ContractType", "合約別");
                tblStrategy.Columns.Add("Slippage", "滑價");
                tblStrategy.Columns.Add("OrderDirection", "買賣別");
                tblStrategy.Columns.Add("ExecutePrice", "履約價別");
                tblStrategy.Columns.Add("PriceZone", "檔次");

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

                cboManualMonth.Items.Add("近月");
                cboManualMonth.Items.Add("遠月");
                cboManualMonth.Items.Add("季月1");
                cboManualMonth.Items.Add("季月2");
                cboManualMonth.Items.Add("季月3");
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
            TradeSymbol tradeSymbol;
            try
            {
                if (File.Exists((string)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.PROGRAM_ROOT_PATH] + @"\cfg\strategy.cfg") == false)
                    return;

                sr = new StreamReader((string)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.PROGRAM_ROOT_PATH] + @"\cfg\strategy.cfg", Encoding.Default);

                sr.ReadLine();

                while ((strLine = sr.ReadLine()) != null)
                {
                    strValues = strLine.Split('\t');
                    DataGridViewUtil.InsertRow(tblStrategy, strValues);
                    RestoreStrategy(tblStrategy.Rows.Count - 1);
                    tradeSymbol = new TradeSymbol();
                    BuildStrategy(tradeSymbol);
                    _tradingRule.AddSignalSymbolMapping(txtStrategyName.Text, tradeSymbol);
/*
                    StrategyInfo strategyInfo = new StrategyInfo();                    
                    tblStrategy.Rows.Add(strValues);
                    RestoreStrategy(tblStrategy.Rows.Count - 1);
                    //object[] oStragegyInfo = BuildStragegy(strategyInfo);
                    object[] oStrategyInfo = null;
                    _dicStrategy.Add(strategyInfo.StrategyName, strategyInfo);                    
 */ 
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

        private void BuildOrder(AAA.Meta.Trade.Data.OrderInfo orderInfo, AAA.Meta.Trade.Data.SignalInfo signalInfo, StrategyInfo strategyInfo, int iPriceType)
        {
            try
            {                
/*
                orderInfo.OrderType = signalInfo.OrderType;
                orderInfo.FilledPrice = signalInfo.FillPrice;
                orderInfo.Slippage = strategyInfo.Slippage.ToString();
                orderInfo.Symbol = signalInfo.Symbol;
                orderInfo.SymbolCode = _autoTrade.QuerySymbolCode(strategyInfo.SymbolType,
                                                                  "",
                                                                  "",
                                                                  "",
                                                                  strategyInfo.ExpiredMonth);
*/
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
                        AAA.Meta.Trade.Data.SignalInfo signalInfo = (AAA.Meta.Trade.Data.SignalInfo)miMessage.Message;
                        TradeInfo[] tradeInfo = _tradingRule.CreateOrder(signalInfo.Strategy);
                        OrderInfo orderInfo = null;
                        string strSymbolType = "";
                        string strSymbolName="";
                        for (int i = 0; i < tradeInfo.Length; i++)
                        {
                            orderInfo = new OrderInfo();
                            orderInfo.OrderType = signalInfo.OrderType;

                            switch (tradeInfo[i].SymbolType)
                            {
                                case SymbolTypeEnum.Futures:
                                    strSymbolType = "台指";
                                    strSymbolName = "台指";
                                    break;
                                case SymbolTypeEnum.MiniFutures:
                                    strSymbolType = "小台";
                                    strSymbolName = "小台";
                                    break;
                                case SymbolTypeEnum.Call:
                                    strSymbolType = "C";
                                    strSymbolName = "選擇權";
                                    break;
                                case SymbolTypeEnum.Put:
                                    strSymbolType = "P";
                                    strSymbolName = "選擇權";
                                    break;
                            }
                            
                            orderInfo.Year = tradeInfo[i].Year.ToString();
                            orderInfo.Month = tradeInfo[i].Month.ToString();

                            if (strSymbolName == "選擇權")
                            {                                
                                switch (signalInfo.OrderType)
                                {
                                    case "LE":
                                        orderInfo.ExercisePrice = tradeInfo[i].ExecutePrice.ToString();
                                        break;
                                    case "SE":
                                        orderInfo.ExercisePrice = tradeInfo[i].ExecutePrice.ToString();
                                        break;
                                    case "LX":
                                        break;
                                    case "SX":
                                        break;
                                }

                            }
                            else
                            {
                                orderInfo.SymbolCode = _autoTrade.QuerySymbolCode(strSymbolType, orderInfo.ExercisePrice, strSymbolType, orderInfo.Year, orderInfo.Month);
                            }
                            orderInfo.IntraDay = tradeInfo[i].IsDayTrade;
                            orderInfo.FilledPrice = (tradeInfo[i].Price < 0) ? "M" : tradeInfo[i].Price.ToString();
                            orderInfo.FilledVolume = tradeInfo[i].Volume;                           

                            _autoTrade.SendOrder(orderInfo);
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

            AAA.Meta.Trade.Data.OrderInfo orderInfo = new AAA.Meta.Trade.Data.OrderInfo();
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
                AAA.Meta.Trade.Data.OrderInfo orderInfo = new AAA.Meta.Trade.Data.OrderInfo();
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

/*
        private object[] BuildStragegy(StrategyInfo strategyInfo)
        {
            string strStrategyName;
            string strSymbolType;
            string strPriceType;
            string strDayTrade;
            string strVolume;
            string strSymbolContent;
            object[] oStrategyInfo = null;
            try
            {
                strStrategyName = txtStrategyName.Text;
                strSymbolType = cboSymbolType.Text;
                strVolume = txtOrderVolume.Text;
                strPriceType = cboPriceType.Text;

                strategyInfo.StrategyName = strStrategyName;
                strategyInfo.SymbolType = strSymbolType;
                strategyInfo.PriceType = strPriceType;
                

                switch (strSymbolType)
                {
                    case "台指":
                    case "小台":
                        strategyInfo.IsDayTrade = chkDayTrade.Checked;
                        strategyInfo.Slippage = float.Parse(txtSlippage.Text);
                        strategyInfo.ExpiredMonth = cboFuturesMonth.Text;
                        strategyInfo.IsDistinctExitSignal = chkExitSignal.Checked;

                        strSymbolContent = "滑價 : " + txtSlippage.Text + ", 月份 : " + cboFuturesMonth.Text + ", 送出平倉訊號 : " + (chkExitSignal.Checked ? "Y" : "N");
                        strDayTrade = chkDayTrade.Checked ? "Y" : "N";
                        oStrategyInfo = new object[] {  chkIsActive.Checked, 
                                                        strStrategyName,
                                                        strSymbolType,
                                                        strPriceType,
                                                        strDayTrade,
                                                        strVolume,
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
*/
        private object[] BuildStrategy(TradeSymbol tradeSymbol)
        {
            bool isActive;
            string strStrategyName = "";
            string strSymbolType = "";
            string strSymbolSeq = "0";
            string strPriceType = "";
            string strDayTrade = "";
            string strVolume = "";
            string strExitSignal = "";
            string strContractType = "";
            string strSlippage = "";
            string strOrderDirection = "";
            string strExecutePrice = "";
            string strPriceZone = "0";
            object[] oStrategyInfo = null;
            /*
                        tblStrategy.Columns.Add(checkBox);
                        tblStrategy.Columns.Add("Strategy", "策略名稱");
                        tblStrategy.Columns.Add("SymbolType", "商品別");
                        tblStrategy.Columns.Add("SymbolSeq", "商品序號");
                        tblStrategy.Columns.Add("PriceType", "價格別");
                        tblStrategy.Columns.Add("DayTrade", "當沖");
                        tblStrategy.Columns.Add("Volume", "下單口數");
                        tblStrategy.Columns.Add("ExitSignal", "送出平倉訊號");
                        tblStrategy.Columns.Add("ContractType", "合約別");
                        tblStrategy.Columns.Add("Slippage", "滑價");
                        tblStrategy.Columns.Add("OrderDirection", "買賣別");
                        tblStrategy.Columns.Add("ExecutePrice", "履約價別");
                        tblStrategy.Columns.Add("PriceZone", "檔次");
            */

            try
            {
                isActive = chkIsActive.Checked;
                strStrategyName = txtStrategyName.Text;
                strSymbolType = cboSymbolType.Text;
                strVolume = txtOrderVolume.Text;
                strPriceType = cboPriceType.Text;
                strDayTrade = chkDayTrade.Checked ? "Y" : "N";
                strExitSignal = chkExitSignal.Checked ? "Y" : "N";
                strSlippage = (cboPriceType.Text == "市價單" ? "-1" : txtSlippage.Text);
                
                tradeSymbol.IsDayTrade = chkDayTrade.Checked;
                tradeSymbol.Slippage = float.Parse(strSlippage);
                tradeSymbol.Volume = int.Parse(strVolume);
                
                switch (strSymbolType)
                {
                    case "台指":
                        tradeSymbol.SymbolType = SymbolTypeEnum.Futures;
                        strContractType = cboFuturesMonth.Text;
                        strSlippage = (cboPriceType.Text == "市價單" ? "-1" : txtSlippage.Text);
                        break;
                    case "小台":
                        tradeSymbol.SymbolType = SymbolTypeEnum.MiniFutures;
                        strContractType = cboFuturesMonth.Text;
                        strSlippage = (cboPriceType.Text == "市價單" ? "-1" : txtSlippage.Text);
                        break;
                    case "選擇權買權":
                        tradeSymbol.SymbolType = SymbolTypeEnum.Call;
                        strContractType = cboOptionsMonth.Text;
                        strSlippage = (cboPriceType.Text == "市價單" ? "-1" : txtOptionsSlippage.Text);
                        break;
                    case "選擇權賣權":
                        tradeSymbol.SymbolType = SymbolTypeEnum.Put;
                        strContractType = cboOptionsMonth.Text;
                        strSlippage = (cboPriceType.Text == "市價單" ? "-1" : txtOptionsSlippage.Text);
                        break;
                }

                if (strSymbolType.StartsWith("選擇權"))
                {
                    switch (cboExecutePrice.Text)
                    {
                        case "價平":
                            tradeSymbol.ExecutePriceType = ExecutePriceTypeEnum.AtTheMoney;                            
                            break;
                        case "價內":
                            tradeSymbol.ExecutePriceType = ExecutePriceTypeEnum.InTheMoney;
                            break;
                        case "價外":
                            tradeSymbol.ExecutePriceType = ExecutePriceTypeEnum.OutOfTheMoney;
                            break;
                    }
                    switch (cboOptionsSide.Text)
                    {
                        case "買方":
                            tradeSymbol.OrderDirection = OrderDirectionEnum.Buy;
                            break;
                        case "賣方":
                            tradeSymbol.OrderDirection = OrderDirectionEnum.Sell;
                            break;
                    }

                    strExecutePrice = cboExecutePrice.Text;
                    strPriceZone = cboPriceZone.Text;
                    strOrderDirection = cboOptionsSide.Text;
                    tradeSymbol.ExecutePriceZone = int.Parse(cboPriceZone.Text);
                }

                switch (strContractType)
                {
                    case "近月":
                        tradeSymbol.ContractType = ContractTypeEnum.Hot;
                        break;
                    case "遠月":
                        tradeSymbol.ContractType = ContractTypeEnum.Next;
                        break;
                    case "季月1":
                        tradeSymbol.ContractType = ContractTypeEnum.FirstQ;
                        break;
                    case "季月2":
                        tradeSymbol.ContractType = ContractTypeEnum.SecondQ;
                        break;
                    case "季月3":
                        tradeSymbol.ContractType = ContractTypeEnum.ThirdQ;
                        break;
                }

                if(txtSymbolSeq.Text.Trim() != "")
                    strSymbolSeq = txtSymbolSeq.Text;
                oStrategyInfo = new object[] { isActive,
                                               strStrategyName,
                                               strSymbolType,
                                               strSymbolSeq,
                                               strPriceType,
                                               strDayTrade,
                                               strVolume,
                                               strExitSignal,
                                               strContractType,
                                               strSlippage,
                                               strOrderDirection,
                                               strExecutePrice,
                                               strPriceZone
                                                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oStrategyInfo;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string strStrategyName = txtStrategyName.Text;
                TradeSymbol tradeSymbol = new TradeSymbol();
                object[] oStrategyInfo = BuildStrategy(tradeSymbol);
                
                List<TradeSymbol> lstTradeSymbol = _tradingRule.GetTradeSymbol(strStrategyName);
                oStrategyInfo[3] = (lstTradeSymbol.Count + 1).ToString();
                txtSymbolSeq.Text = oStrategyInfo[3].ToString();
                _tradingRule.AddSignalSymbolMapping(strStrategyName, tradeSymbol);
                DataGridViewUtil.InsertRow(tblStrategy, oStrategyInfo);

/*
                StrategyInfo strategyInfo = new StrategyInfo();
                object[] oStragegyInfo = BuildStragegy(strategyInfo);

                if (_dicStrategy.ContainsKey(strategyInfo.StrategyName))
                {
                    MessageBox.Show(strategyInfo.StrategyName + " 已存在, 請修改策略名稱");
                    return;
                }
                                
                _dicStrategy.Add(strategyInfo.StrategyName, strategyInfo);
                DataGridViewUtil.InsertRow(tblStrategy, oStragegyInfo);
 */ 
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
                string strStrategyName = txtStrategyName.Text;
                List<TradeSymbol> lstTradeSymbol = _tradingRule.GetTradeSymbol(strStrategyName);

                if (lstTradeSymbol.Count < int.Parse(txtSymbolSeq.Text))
                {
                    MessageBox.Show("商品序錯誤, 請確認");
                    return;
                }

                if (tblStrategy.SelectedRows.Count > 0)
                {
                    if (tblStrategy.Rows[tblStrategy.SelectedRows[0].Index].Cells["SymbolSeq"].Value.ToString() != txtSymbolSeq.Text)
                    {
                        MessageBox.Show("商品序錯誤, 請確認");
                        txtSymbolSeq.Text = tblStrategy.Rows[tblStrategy.SelectedRows[0].Index].Cells["SymbolSeq"].Value.ToString();
                        return;
                    }
                }

                TradeSymbol tradeSymbol = lstTradeSymbol[int.Parse(txtSymbolSeq.Text) - 1];
                object[] oStrategyInfo = BuildStrategy(tradeSymbol);
                               
                DataGridViewUtil.UpdateRow(tblStrategy, new string[] {"Strategy", "SymbolSeq"}, oStrategyInfo);
/*
                object[] oStrategyInfo = null;
                if (_dicStrategy.ContainsKey(txtStrategyName.Text) == false)
                {
                    MessageBox.Show(txtStrategyName.Text + " 不存在, 請重新輸入策略名稱");
                    return;
                }

                oStrategyInfo = BuildStragegy(_dicStrategy[txtStrategyName.Text]);
                DataGridViewUtil.UpdateRow(tblStrategy, new string[] { "Strategy" }, oStrategyInfo);
 */ 
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
                string strStrategyName = txtStrategyName.Text;
                string strSymbolSeq = txtSymbolSeq.Text;

                List<TradeSymbol> lstTradeSymbol = _tradingRule.GetTradeSymbol(strStrategyName);

                if (lstTradeSymbol.Count < int.Parse(txtSymbolSeq.Text))
                {
                    MessageBox.Show("商品序錯誤, 請確認");
                    return;
                }

                TradeSymbol tradeSymbol = lstTradeSymbol[int.Parse(strSymbolSeq) - 1];
                object[] oStrategyInfo = BuildStrategy(tradeSymbol);
                object[] oOldStrategyInfo = null;
                object[] oNewStrategyInfo = null;
                DataGridViewUtil.DeleteRow(tblStrategy, new string[] { "Strategy", "SymbolSeq" }, oStrategyInfo);
                lstTradeSymbol.RemoveAt(int.Parse(strSymbolSeq) - 1);
                int iRowIndex;

                for (int i = int.Parse(strSymbolSeq) - 1; i < lstTradeSymbol.Count; i++)
                {
                    oStrategyInfo[3] = (i + 2).ToString();
                    iRowIndex = DataGridViewUtil.FindRowIndex(tblStrategy, new string[] { "Strategy", "SymbolSeq" }, oStrategyInfo);
                    RestoreStrategy(iRowIndex);

                    tradeSymbol = lstTradeSymbol[i];                    
                    oOldStrategyInfo = BuildStrategy(tradeSymbol);                    
                    oNewStrategyInfo = BuildStrategy(tradeSymbol);
                    oNewStrategyInfo[3] = (i + 1).ToString();
                    DataGridViewUtil.UpdateRow(tblStrategy, new string[] { "Strategy", "SymbolSeq" }, oOldStrategyInfo, oNewStrategyInfo);
                }

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
            try
            {
                if (tblStrategy.Rows[iRowIndex].Cells["SymbolType"].Value.ToString().StartsWith("選擇權"))
                {
                    pnlFutures.Visible = false;
                    pnlOptions.Visible = true;
                    txtOptionsSlippage.Text = tblStrategy.Rows[iRowIndex].Cells["Slippage"].Value.ToString();
                    cboOptionsMonth.SelectedIndex = cboOptionsMonth.Items.IndexOf(tblStrategy.Rows[iRowIndex].Cells["ContractType"].Value.ToString());
                }
                else
                {
                    pnlFutures.Visible = true;
                    pnlOptions.Visible = false;
                    txtSlippage.Text = tblStrategy.Rows[iRowIndex].Cells["Slippage"].Value.ToString();
                    cboFuturesMonth.SelectedIndex = cboFuturesMonth.Items.IndexOf(tblStrategy.Rows[iRowIndex].Cells["ContractType"].Value.ToString());
                }
                txtSymbolSeq.Text = tblStrategy.Rows[iRowIndex].Cells["SymbolSeq"].Value.ToString();
                cboSymbolType.SelectedIndex = cboSymbolType.Items.IndexOf(tblStrategy.Rows[iRowIndex].Cells["SymbolType"].Value.ToString());
                txtStrategyName.Text = tblStrategy.Rows[iRowIndex].Cells["Strategy"].Value.ToString();
                cboPriceType.SelectedIndex = cboPriceType.Items.IndexOf(tblStrategy.Rows[iRowIndex].Cells["PriceType"].Value.ToString());
                chkDayTrade.Checked = tblStrategy.Rows[iRowIndex].Cells["DayTrade"].Value.ToString() == "Y";
                txtOrderVolume.Text = tblStrategy.Rows[iRowIndex].Cells["Volume"].Value.ToString();                
                chkExitSignal.Checked = tblStrategy.Rows[iRowIndex].Cells["ExitSignal"].Value.ToString() == "Y";                
                chkIsActive.Checked = tblStrategy.Rows[iRowIndex].Cells[0].Value.ToString() == "True";
                cboOptionsSide.SelectedIndex = cboOptionsSide.Items.IndexOf(tblStrategy.Rows[iRowIndex].Cells["OrderDirection"].Value.ToString());
                cboExecutePrice.SelectedIndex = cboExecutePrice.Items.IndexOf(tblStrategy.Rows[iRowIndex].Cells["ExecutePrice"].Value.ToString());
                cboPriceZone.SelectedIndex = cboPriceZone.Items.IndexOf(tblStrategy.Rows[iRowIndex].Cells["PriceZone"].Value.ToString());

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
                pnlOptions.Top = 5;
                pnlOptions.Left = 173;
                pnlFutures.Top = 5;
                pnlFutures.Left = 173;

                switch (strSymbolType)
                {
                    case "選擇權買權":
                    case "選擇權賣權":
                        pnlOptions.Visible = true;
                        pnlFutures.Visible = false;
                        cboPriceType.SelectedIndex = cboPriceType.Items.IndexOf("限價單");
                        break;

                    default:
                        pnlOptions.Visible = false;
                        pnlFutures.Visible = true;
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
                              

                ChangeDisplay(tblStrategy.Rows[iRowIndex].Cells["SymbolType"].Value.ToString());
                RestoreStrategy(iRowIndex);
            }
            catch (Exception ex)            
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void cboExecutePrice_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (cboExecutePrice.Text)
                {
                    case "價平":
                        if(cboPriceZone.Items.Count > 0)
                            cboPriceZone.SelectedIndex = 0;
                        cboPriceZone.Enabled = false;
                        break;
                    default:
                        cboPriceZone.Enabled = true;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void tblStrategy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRowIndex = e.RowIndex;

            _tradingRule.ToString();
            ChangeDisplay(tblStrategy.Rows[iRowIndex].Cells["SymbolType"].Value.ToString());
            RestoreStrategy(iRowIndex);
        }
    }
}
