using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AAA.Base.Util.Reader;
using AAA.Quote;
using AAA.Meta.Quote;
using AAA.Meta.Quote.Data;
using AAA.Trade;
using AAA.DesignPattern.Observer;
using AAA.Meta.Trade.Data;

namespace AAA.ProgramTrade
{
    public partial class SpeedOrderForm : Form, IObserver
    {
        private const int CLEAR_ROW_COUNT = 20;
        private float _fDiffRatio;
        private int _iPriceBuffer;
        private int _iMinPriceBuffer;
        private int _iMaxPrice;
        private int _iMinPrice;
        private int _iPreviousPrice;
        private bool _isStartQuote;
        private Dictionary<string, string> _dicDDEParameter;
        private IRealtimeQuote _realtimeQuote;
        private TrustData _previousTrustData;
        private Dictionary<int, OrderInfo> _dicOrderInfo;        

        public SpeedOrderForm()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            Init();
            InitSymbol();
        }

        private void InitSymbol()
        {
            cboSymbolType.Items.Clear();
            cboSymbolType.Items.Add("台指");
            cboSymbolType.Items.Add("小台");
            cboSymbolType.Items.Add("選擇權");
            cboSymbolType.SelectedIndex = 0;

            cboMonth.Items.Clear();
            cboMonth.Items.Add("近月");
            cboMonth.Items.Add("遠月");
            cboMonth.Items.Add("季月1");
            cboMonth.Items.Add("季月2");
            cboMonth.Items.Add("季月3");
            cboMonth.SelectedIndex = 0;

            cboPutOrCall.Items.Clear();
            cboPutOrCall.Items.Add("-");
            cboPutOrCall.Items.Add("Put");
            cboPutOrCall.Items.Add("Call");
            cboPutOrCall.SelectedIndex = 0;
        }

        private void Init()
        {
            IniReader iniReader;
            string strDDESection;
            string strApplication;
            string strTopic;
            int iYsdClosePrice;

            try
            {
                tblPrice.Columns.Add("DelBuyOrder", "刪單");
                tblPrice.Columns["DelBuyOrder"].Width = 70;
                tblPrice.Columns.Add("StopBuyOrder", "觸價");
                tblPrice.Columns["StopBuyOrder"].Width = 70;
                tblPrice.Columns.Add("BuyOrder", "買進");
                tblPrice.Columns["BuyOrder"].Width = 70;
                tblPrice.Columns.Add("TrustBuy", "委買量");
                tblPrice.Columns["TrustBuy"].Width = 100;
                tblPrice.Columns.Add("Price", "價格");
                tblPrice.Columns["Price"].Width = 100;
                tblPrice.Columns.Add("TrustSell", "委賣量");
                tblPrice.Columns["TrustSell"].Width = 100;
                tblPrice.Columns.Add("SellOrder", "賣出");
                tblPrice.Columns["SellOrder"].Width = 70;
                tblPrice.Columns.Add("StopSellOrder", "觸價");
                tblPrice.Columns["StopSellOrder"].Width = 70;
                tblPrice.Columns.Add("DelSellOrder", "刪單");
                tblPrice.Columns["DelSellOrder"].Width = 70;

                iniReader = new IniReader((string)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.PROGRAM_ROOT_PATH] + @"\cfg\realtime.ini");

                
                _fDiffRatio = float.Parse(iniReader.GetParam("View", "DiffRatio"));
                _iPriceBuffer = int.Parse(iniReader.GetParam("View", "PriceBuffer"));
                _iMinPriceBuffer = int.Parse(iniReader.GetParam("View", "MinPriceBuffer"));

                
                strDDESection = iniReader.GetParam("System", "DDE_Setting");                

                strApplication = iniReader.GetParam(strDDESection, "Application");
                strTopic = iniReader.GetParam(strDDESection, "Topic");

                _dicDDEParameter = new Dictionary<string, string>();
                _dicDDEParameter.Add("Price", iniReader.GetParam(strDDESection, "Price"));
                _dicDDEParameter.Add("Volume", iniReader.GetParam(strDDESection, "Volume"));
                _dicDDEParameter.Add("AskPrice", iniReader.GetParam(strDDESection, "SellPrice1"));
                _dicDDEParameter.Add("AskVolume", iniReader.GetParam(strDDESection, "SellVolume1"));
                _dicDDEParameter.Add("BidPrice", iniReader.GetParam(strDDESection, "BuyPrice1"));
                _dicDDEParameter.Add("BidVolume", iniReader.GetParam(strDDESection, "BuyVolume1"));
                _dicDDEParameter.Add("AskPrice2", iniReader.GetParam(strDDESection, "SellPrice2"));
                _dicDDEParameter.Add("AskVolume2", iniReader.GetParam(strDDESection, "SellVolume2"));
                _dicDDEParameter.Add("BidPrice2", iniReader.GetParam(strDDESection, "BuyPrice2"));
                _dicDDEParameter.Add("BidVolume2", iniReader.GetParam(strDDESection, "BuyVolume2"));
                _dicDDEParameter.Add("AskPrice3", iniReader.GetParam(strDDESection, "SellPrice3"));
                _dicDDEParameter.Add("AskVolume3", iniReader.GetParam(strDDESection, "SellVolume3"));
                _dicDDEParameter.Add("BidPrice3", iniReader.GetParam(strDDESection, "BuyPrice3"));
                _dicDDEParameter.Add("BidVolume3", iniReader.GetParam(strDDESection, "BuyVolume3"));
                _dicDDEParameter.Add("AskPrice4", iniReader.GetParam(strDDESection, "SellPrice4"));
                _dicDDEParameter.Add("AskVolume4", iniReader.GetParam(strDDESection, "SellVolume4"));
                _dicDDEParameter.Add("BidPrice4", iniReader.GetParam(strDDESection, "BuyPrice4"));
                _dicDDEParameter.Add("BidVolume4", iniReader.GetParam(strDDESection, "BuyVolume4"));
                _dicDDEParameter.Add("AskPrice5", iniReader.GetParam(strDDESection, "SellPrice5"));
                _dicDDEParameter.Add("AskVolume5", iniReader.GetParam(strDDESection, "SellVolume5"));
                _dicDDEParameter.Add("BidPrice5", iniReader.GetParam(strDDESection, "BuyPrice5"));
                _dicDDEParameter.Add("BidVolume5", iniReader.GetParam(strDDESection, "BuyVolume5"));

                _isStartQuote = false;
                _realtimeQuote = new DDERealtimeQuote(strApplication, strTopic, _dicDDEParameter);
                _realtimeQuote.TickDataReceiveEvent += new TickDataHandler(OnTickReceive);
                _realtimeQuote.TrustDataReceiveEvent += new TrustDataHandler(OnTrustReceive);
                _realtimeQuote.QuotePeriod = 250;
                _realtimeQuote.StartQuote();

                iYsdClosePrice = (int)double.Parse(_realtimeQuote.Request(iniReader.GetParam(strDDESection, "YesterdayClosePrice")));
                _iMaxPrice = (int)(Math.Ceiling(iYsdClosePrice * (1 + _fDiffRatio)));
                _iMinPrice = (int)(Math.Floor(iYsdClosePrice * (1 - _fDiffRatio))); ;
                _isStartQuote = true;

                if (AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.AUTO_TRADE_PROGRAM] != null)
                {
                    txtAccount.Text = ((ITrade)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.AUTO_TRADE_PROGRAM]).AccountInfo.IdNo;
                }
                else
                {
                    txtAccount.Text = "未登入";
                }

                MessageSubject.Instance().Subject.Attach(this);

                _dicOrderInfo = new Dictionary<int, OrderInfo>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        public void OnTickReceive(TickData tickData)
        {
            try
            {
                Application.DoEvents();
                if ((tblPrice.Rows.Count != 0) || (_isStartQuote == false))
                    return;

                if ((_iMaxPrice != 0) && (_iMinPrice != 0))
                {
                    _iPriceBuffer = (_iMaxPrice - _iMinPrice);
                }
                else
                {
                    _iMinPrice = (int)tickData.Price - _iPriceBuffer;
                    _iMaxPrice = (int)tickData.Price + _iPriceBuffer;
                }

                for (int i = _iMaxPrice; i >= _iMinPrice; i--)
                {
                    
                    tblPrice.Rows.Add(new string[] {"刪",
                                                    "",
                                                    "",
                                                    "",
                                                    i.ToString("0"),
                                                    "",
                                                    "",
                                                    "",
                                                    "刪"});
                }

                tblPrice.FirstDisplayedScrollingRowIndex = _iMaxPrice - (int)tickData.Price - 6;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void UpdatePositionColor()
        {
            txtCurrentPosition.BackColor = int.Parse(txtCurrentPosition.Text) == 0
                                            ? Color.Gray
                                            : int.Parse(txtCurrentPosition.Text) > 0
                                                ? Color.Red
                                                : Color.Green;
        }


        public void OnTrustReceive(TrustData trustData)
        {
            int iPriceRowIndex;
            int iPrice;
            int iBuyStopPrice;
            int iSellStopPrice;
            try
            {
                Application.DoEvents();
                if ((trustData.TickVolume == 0) || (_isStartQuote == false))
                    return;

                txtPrice.Text = trustData.Price.ToString("0");
                txtVolume.Text = trustData.Volume.ToString("0");
                txtTickVolume.Text = trustData.TickVolume.ToString("0");

                iPrice = (int)trustData.Price;
                iPriceRowIndex = _iMaxPrice - (int)trustData.Price;
                tblPrice.Rows[iPriceRowIndex].Cells["Price"].Style.BackColor = Color.Yellow;

                iBuyStopPrice = int.Parse(txtBuyStopPrice.Text);
                iSellStopPrice = int.Parse(txtSellStopPrice.Text);


                if ((iBuyStopPrice != 0) && (iPrice <= iBuyStopPrice) && (int.Parse(txtCurrentPosition.Text) > 0) && chkBuyStopPrice.Checked)
                {
                    lstLog.Items.Add(DateTime.Now.ToString("HH:mm:ss") + " - 多單絕對停損 - " + (int)trustData.Price + " - " + int.Parse(txtCurrentPosition.Text));
                    txtCurrentPosition.Text = "0";
                    chkBuyStopPrice.Checked = false;
                    for (int i = 0; i < tblPrice.Rows.Count; i++)
                        tblPrice.Rows[i].Cells["StopBuyOrder"].Value = "";
                }

                if ((iSellStopPrice != 0) && (iPrice <= iSellStopPrice) && (int.Parse(txtCurrentPosition.Text) < 0) && chkSellStopPrice.Checked)
                {
                    lstLog.Items.Add(DateTime.Now.ToString("HH:mm:ss") + " - 空單絕對停損 - " + (int)trustData.Price + " - " + -1 * int.Parse(txtCurrentPosition.Text));
                    txtCurrentPosition.Text = "0";
                    chkSellStopPrice.Checked = false;
                    for (int i = 0; i < tblPrice.Rows.Count; i++)
                        tblPrice.Rows[i].Cells["StopSellOrder"].Value = "";
                }

                if (tblPrice.Rows[iPriceRowIndex].Cells["StopBuyOrder"].Value.ToString() != "")
                {                    
                    lstLog.Items.Add(DateTime.Now.ToString("HH:mm:ss") + " - 觸價買進 - " + (int)trustData.Price + " - " + tblPrice.Rows[iPriceRowIndex].Cells["StopBuyOrder"].Value.ToString());                    
                    txtCurrentPosition.Text = (int.Parse(txtCurrentPosition.Text) + int.Parse(tblPrice.Rows[iPriceRowIndex].Cells["StopBuyOrder"].Value.ToString())).ToString();
                    tblPrice.Rows[iPriceRowIndex].Cells["StopBuyOrder"].Value = "";
                    UpdatePositionColor();
                }

                if (tblPrice.Rows[iPriceRowIndex].Cells["BuyOrder"].Value.ToString() != "")
                {
                    lstLog.Items.Add(DateTime.Now.ToString("HH:mm:ss") + " - 委託買進 - " + (int)trustData.Price + " - 1");
                    tblPrice.Rows[iPriceRowIndex].Cells["BuyOrder"].Value = int.Parse(tblPrice.Rows[iPriceRowIndex].Cells["BuyOrder"].Value.ToString()) - 1 == 0 ? "" : (int.Parse(tblPrice.Rows[iPriceRowIndex].Cells["BuyOrder"].Value.ToString()) - 1).ToString(); 
                    txtCurrentPosition.Text = (int.Parse(txtCurrentPosition.Text) + 1).ToString();
                    UpdatePositionColor();
                }

                if (tblPrice.Rows[iPriceRowIndex].Cells["StopSellOrder"].Value.ToString() != "")
                {
                    lstLog.Items.Add(DateTime.Now.ToString("HH:mm:ss") + " - 觸價賣出 - " + (int)trustData.Price + " - " + tblPrice.Rows[iPriceRowIndex].Cells["StopSellOrder"].Value.ToString());                    
                    txtCurrentPosition.Text = (int.Parse(txtCurrentPosition.Text) - int.Parse(tblPrice.Rows[iPriceRowIndex].Cells["StopSellOrder"].Value.ToString())).ToString();
                    tblPrice.Rows[iPriceRowIndex].Cells["StopSellOrder"].Value = "";
                    UpdatePositionColor();
                }

                if (tblPrice.Rows[iPriceRowIndex].Cells["SellOrder"].Value.ToString() != "")
                {
                    lstLog.Items.Add(DateTime.Now.ToString("HH:mm:ss") + " - 委託賣出 - " + (int)trustData.Price + " - 1");
                    tblPrice.Rows[iPriceRowIndex].Cells["SellOrder"].Value = int.Parse(tblPrice.Rows[iPriceRowIndex].Cells["SellOrder"].Value.ToString()) - 1 == 0 ? "" : (int.Parse(tblPrice.Rows[iPriceRowIndex].Cells["SellOrder"].Value.ToString()) - 1).ToString(); 
                    txtCurrentPosition.Text = (int.Parse(txtCurrentPosition.Text) - 1).ToString();
                    UpdatePositionColor();
                }

                

                if(chkAutoScroll.Checked)
                    tblPrice.FirstDisplayedScrollingRowIndex =  iPriceRowIndex - 6;

                if (_iPreviousPrice != 0)                
                    tblPrice.Rows[_iMaxPrice - _iPreviousPrice].Cells["Price"].Style.BackColor = Color.White;

                for (int i = -1 * CLEAR_ROW_COUNT; i < CLEAR_ROW_COUNT; i++)
                {
                    tblPrice.Rows[iPriceRowIndex + i].Cells["TrustBuy"].Value = "";
                    tblPrice.Rows[iPriceRowIndex + i].Cells["TrustSell"].Value = "";
                }

                if (_previousTrustData != null)
                {
                    if (_previousTrustData.BuyPrice1 != 0)
                        tblPrice.Rows[_iMaxPrice - (int)_previousTrustData.BuyPrice1].Cells["TrustBuy"].Value = "";
                    if (_previousTrustData.BuyPrice2 != 0)
                        tblPrice.Rows[_iMaxPrice - (int)_previousTrustData.BuyPrice2].Cells["TrustBuy"].Value = "";
                    if (_previousTrustData.BuyPrice3 != 0)
                        tblPrice.Rows[_iMaxPrice - (int)_previousTrustData.BuyPrice3].Cells["TrustBuy"].Value = "";
                    if (_previousTrustData.BuyPrice4 != 0)
                        tblPrice.Rows[_iMaxPrice - (int)_previousTrustData.BuyPrice4].Cells["TrustBuy"].Value = "";
                    if (_previousTrustData.BuyPrice5 != 0)
                        tblPrice.Rows[_iMaxPrice - (int)_previousTrustData.BuyPrice5].Cells["TrustBuy"].Value = "";

                    if (_previousTrustData.SellPrice1 != 0)
                        tblPrice.Rows[_iMaxPrice - (int)_previousTrustData.SellPrice1].Cells["TrustSell"].Value = "";
                    if (_previousTrustData.SellPrice2 != 0)
                        tblPrice.Rows[_iMaxPrice - (int)_previousTrustData.SellPrice2].Cells["TrustSell"].Value = "";
                    if (_previousTrustData.SellPrice3 != 0)
                        tblPrice.Rows[_iMaxPrice - (int)_previousTrustData.SellPrice3].Cells["TrustSell"].Value = "";
                    if (_previousTrustData.SellPrice4 != 0)
                        tblPrice.Rows[_iMaxPrice - (int)_previousTrustData.SellPrice4].Cells["TrustSell"].Value = "";
                    if (_previousTrustData.SellPrice5 != 0)
                        tblPrice.Rows[_iMaxPrice - (int)_previousTrustData.SellPrice5].Cells["TrustSell"].Value = "";
                }

                _iPreviousPrice = (int)trustData.Price;
                
                if(trustData.BuyPrice1 != 0)
                    tblPrice.Rows[_iMaxPrice - (int)trustData.BuyPrice1].Cells["TrustBuy"].Value = trustData.BuyVol1;
                if (trustData.BuyPrice2 != 0)
                    tblPrice.Rows[_iMaxPrice - (int)trustData.BuyPrice2].Cells["TrustBuy"].Value = trustData.BuyVol2;
                if (trustData.BuyPrice3 != 0)
                    tblPrice.Rows[_iMaxPrice - (int)trustData.BuyPrice3].Cells["TrustBuy"].Value = trustData.BuyVol3;
                if (trustData.BuyPrice4 != 0)
                    tblPrice.Rows[_iMaxPrice - (int)trustData.BuyPrice4].Cells["TrustBuy"].Value = trustData.BuyVol4;
                if (trustData.BuyPrice5 != 0)
                    tblPrice.Rows[_iMaxPrice - (int)trustData.BuyPrice5].Cells["TrustBuy"].Value = trustData.BuyVol5;

                if (trustData.SellPrice1 != 0)
                    tblPrice.Rows[_iMaxPrice - (int)trustData.SellPrice1].Cells["TrustSell"].Value = trustData.SellVol1;
                if (trustData.SellPrice2 != 0)
                    tblPrice.Rows[_iMaxPrice - (int)trustData.SellPrice2].Cells["TrustSell"].Value = trustData.SellVol2;
                if (trustData.SellPrice3 != 0)
                    tblPrice.Rows[_iMaxPrice - (int)trustData.SellPrice3].Cells["TrustSell"].Value = trustData.SellVol3;
                if (trustData.SellPrice4 != 0)
                    tblPrice.Rows[_iMaxPrice - (int)trustData.SellPrice4].Cells["TrustSell"].Value = trustData.SellVol4;
                if (trustData.SellPrice5 != 0)
                    tblPrice.Rows[_iMaxPrice - (int)trustData.SellPrice5].Cells["TrustSell"].Value = trustData.SellVol5;

                _previousTrustData = trustData;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void SpeedOrderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _realtimeQuote.StopQuote();
        }

        private void tblPrice_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
                switch (tblPrice.Columns[e.ColumnIndex].Name)
                {
                    case "StopBuyOrder":                        
                    case "BuyOrder":                        
                    case "StopSellOrder":                        
                    case "SellOrder":
                        break;

                    case "DelBuyOrder":
                        break;

                    case "DelSellOrder":
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void SendOrder(AAA.Meta.Trade.Data.OrderInfo orderInfo)
        {
            string strMessage;
            if (AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.AUTO_TRADE_PROGRAM] == null)
            {
                MessageBox.Show("請先登入, 謝謝!!");
                return;
            }

            strMessage = (string)((ITrade)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.AUTO_TRADE_PROGRAM]).SendOrder(orderInfo);

            ((ITrade)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.AUTO_TRADE_PROGRAM]).GetOrderReport(DateTime.Now.ToString("yyyy/MM/dd") + " 00:00:00", 
                                                                                                                                     DateTime.Now.ToString("yyyy/MM/dd") + " 23:59:59");
        }

        private void CancelOrder(AAA.Meta.Trade.Data.OrderInfo orderInfo)
        {
            if (AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.AUTO_TRADE_PROGRAM] == null)
            {
                MessageBox.Show("請先登入, 謝謝!!");
                return;
            }

            ((ITrade)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.AUTO_TRADE_PROGRAM]).CancelOrder(orderInfo);
        }

        private void FormatCommonProperty(AAA.Meta.Trade.Data.OrderInfo orderInfo)
        {
            orderInfo.SymbolCode = ((ITrade)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.AUTO_TRADE_PROGRAM]).QuerySymbolCode(cboSymbolType.Text,
                                                                                                                                                             cboStrikePrice.Text,
                                                                                                                                                             cboPutOrCall.Text,
                                                                                                                                                             cboYear.Text,
                                                                                                                                                             cboMonth.Text);
            orderInfo.IntraDay = chkDayTrade.Checked;
        }

        private void tblPrice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AAA.Meta.Trade.Data.OrderInfo orderInfo;

            try
            {
                if (AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.AUTO_TRADE_PROGRAM] == null)
                {
                    MessageBox.Show("請先登入, 謝謝!!");
                    return;
                }

                switch (tblPrice.Columns[e.ColumnIndex].Name)
                {
                    case "StopBuyOrder":
                        tblPrice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = tblPrice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == ""
                                                                                                                            ? udOrderLots.Value.ToString()
                                                                                                                            : (int.Parse(tblPrice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()) + udOrderLots.Value).ToString();
                        break;
                    case "StopSellOrder":                                            
                        tblPrice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = tblPrice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == ""
                                                                                                    ? udOrderLots.Value.ToString()
                                                                                                    : (int.Parse(tblPrice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()) + udOrderLots.Value).ToString();
                        break;

                    case "BuyOrder":
                        orderInfo = new AAA.Meta.Trade.Data.OrderInfo();
                        orderInfo.FilledPrice = tblPrice.Rows[e.RowIndex].Cells["Price"].Value.ToString();
                        orderInfo.FilledVolume = (int)udOrderLots.Value;
                        orderInfo.OrderType = "LE";
                        FormatCommonProperty(orderInfo);
                        SendOrder(orderInfo);
                        break;

                    case "SellOrder":
                        break;

                    case "DelBuyOrder":
                        if (tblPrice.Rows[e.RowIndex].Cells["StopBuyOrder"].Value.ToString() != "")
                            tblPrice.Rows[e.RowIndex].Cells["StopBuyOrder"].Value = int.Parse(tblPrice.Rows[e.RowIndex].Cells["StopBuyOrder"].Value.ToString()) > udOrderLots.Value
                                                                                                        ? (int.Parse(tblPrice.Rows[e.RowIndex].Cells["StopBuyOrder"].Value.ToString()) - udOrderLots.Value).ToString()
                                                                                                        : "";
                        if (tblPrice.Rows[e.RowIndex].Cells["BuyOrder"].Value.ToString() != "")
                            tblPrice.Rows[e.RowIndex].Cells["BuyOrder"].Value = int.Parse(tblPrice.Rows[e.RowIndex].Cells["BuyOrder"].Value.ToString()) > udOrderLots.Value
                                                                                                        ? (int.Parse(tblPrice.Rows[e.RowIndex].Cells["BuyOrder"].Value.ToString()) - udOrderLots.Value).ToString()
                                                                                                        : "";
                        break;
                    case "DelSellOrder":
                        if (tblPrice.Rows[e.RowIndex].Cells["StopSellOrder"].Value.ToString() != "")
                            tblPrice.Rows[e.RowIndex].Cells["StopSellOrder"].Value = int.Parse(tblPrice.Rows[e.RowIndex].Cells["StopSellOrder"].Value.ToString()) > udOrderLots.Value
                                                                                                        ? (int.Parse(tblPrice.Rows[e.RowIndex].Cells["StopSellOrder"].Value.ToString()) - udOrderLots.Value).ToString()
                                                                                                        : "";
                        if(tblPrice.Rows[e.RowIndex].Cells["SellOrder"].Value.ToString() != "")
                            tblPrice.Rows[e.RowIndex].Cells["SellOrder"].Value = int.Parse(tblPrice.Rows[e.RowIndex].Cells["SellOrder"].Value.ToString()) > udOrderLots.Value
                                                                                                        ? (int.Parse(tblPrice.Rows[e.RowIndex].Cells["SellOrder"].Value.ToString()) - udOrderLots.Value).ToString()
                                                                                                        : "";

                        break;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        #region IObserver Members

        public void Update(object oSource, IMessageInfo miMessage)
        {
            Dictionary<string, object> dicReturn;
            Dictionary<string, string> dicRecord;
            int iRecordCount;
            string[] strValues;

            switch (miMessage.MessageSubject)
            {
                case "Login":
                    if (AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.AUTO_TRADE_PROGRAM] != null)
                    {
                        txtAccount.Text = ((ITrade)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.AUTO_TRADE_PROGRAM]).AccountInfo.IdNo;
                    }
                    break;

                case "OnTradeMessageReceive":
                    dicReturn = (Dictionary<string, object>)miMessage.Message;

                    switch (dicReturn["name"].ToString())
                    {
                        case "QueryOrderListByDiff":
                            iRecordCount = int.Parse(dicReturn["recordcount"].ToString());

                            for (int i = 0; i < iRecordCount; i++)
                            {
                                dicRecord = (Dictionary<string, string>)dicReturn["record" + i];
                                
                            }

                            break;

                    }

                    break;

            }
        }

        #endregion
    }
}
