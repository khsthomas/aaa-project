using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Intelligence;
using Package;
using System.IO;

namespace AAA.KGITrade
{
    delegate void SetAddInfoCallBack(string text);
    delegate void SetTextBoxCallBack(TextBox txtSource, string text);

    public partial class QuoteForm : Form
    {
        private const string HOST = "211.22.59.11";
        private const ushort PORT = (ushort)8000;
        private const string ID = "53165402";
        private const string PASSWORD = "lucky777";
        private const string TOKEN = "b6eb";
        private const string SOURCE_ID = "API";
        private const char AREA = ' ';

        private Intelligence.QuoteCom _quoteCom;
        private UTF8Encoding _encoding = new System.Text.UTF8Encoding();

        private StreamWriter _sw = null;

        public QuoteForm()
        {
            InitializeComponent();
            InitTable();

            _quoteCom = new QuoteCom(HOST, PORT, SOURCE_ID, TOKEN);
            _quoteCom.OnRcvMessage += OnQuoteRcvMessage;
            _quoteCom.OnGetStatus += OnQuoteGetStatus;

        }

        private void InitTable()
        {
            tblQuote.Columns.Add("DateTime", "時間");
            tblQuote.Columns.Add("OpenPrice", "開盤價");
            tblQuote.Columns.Add("HighPrice", "最高價");
            tblQuote.Columns.Add("LowPrice", "最低價");
            tblQuote.Columns.Add("ClosePrice", "收盤價");
            tblQuote.Columns.Add("Volume", "成交量");
        }

        private void btnQuote_Click(object sender, EventArgs e)
        {
            try
            {
                string strQuotedList = txtSymbolId.Text;
                _quoteCom.SourceId = SOURCE_ID;
                _quoteCom.Connect2Quote(HOST, PORT, ID, PASSWORD, AREA, strQuotedList);
                _sw = new StreamWriter(Environment.CurrentDirectory + @"\KGIQuote.txt", true, Encoding.Default);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);                     
            }
        }

        private void AddInfo(TextBox txtSource, string strMsg)
        {
            if (txtSource.InvokeRequired)
            {
                SetTextBoxCallBack d = new SetTextBoxCallBack(AddInfo);
                this.Invoke(d, new object[] { txtSource, strMsg });
            }
            else
            {                
                try
                {
                    txtSource.Text = strMsg;
                }
                catch { };
            }
        }

        private void AddInfo(string msg)
        {
            if (lstMessage.InvokeRequired)
            {
                SetAddInfoCallBack d = new SetAddInfoCallBack(AddInfo);
                this.Invoke(d, new object[] { msg });
            }
            else
            {
                string fMsg = String.Format("[{0}] {1} {2}", DateTime.Now.ToString("hh:mm:ss:ffff"), msg, Environment.NewLine);
                try
                {
                    lstMessage.Items.Add(fMsg);
                }
                catch { };
            }
        }

        #region QuoteCom API 事件
        private void OnQuoteGetStatus(object sender, COM_STATUS staus, byte[] msg)
        {
            QuoteCom com = (QuoteCom)sender;
            string smsg = null;
            switch (staus)
            {
                case COM_STATUS.LOGIN_READY:
                    AddInfo(String.Format("LOGIN_READY:[{0}]", _encoding.GetString(msg)));
                    break;
                case COM_STATUS.LOGIN_FAIL:
                    AddInfo(String.Format("LOGIN FAIL:[{0}]", _encoding.GetString(msg)));
                    break;
                case COM_STATUS.LOGIN_UNKNOW:
                    AddInfo(String.Format("LOGIN UNKNOW:[{0}]", _encoding.GetString(msg)));
                    break;
                case COM_STATUS.CONNECT_READY:                    
                    smsg = "QuoteCom: [" + _encoding.GetString(msg) + "] MyIP=" + _quoteCom.MyIP;
                    AddInfo(smsg);
                    break;
                case COM_STATUS.CONNECT_FAIL:
                    smsg = _encoding.GetString(msg);
                    AddInfo("CONNECT_FAIL:" + smsg);
                    break;
                case COM_STATUS.DISCONNECTED:
                    smsg = _encoding.GetString(msg);
                    AddInfo("DISCONNECTED:" + smsg);
                    break;

/*
                case COM_STATUS.LOGIN_READY:
                    AddInfo(String.Format("LOGIN_READY:[{0}]", encoding.GetString(msg)));
                    break;
                case COM_STATUS.LOGIN_FAIL:
                    AddInfo(String.Format("LOGIN FAIL:[{0}]", encoding.GetString(msg)));
                    break;
                case COM_STATUS.LOGIN_UNKNOW:
                    AddInfo(String.Format("LOGIN UNKNOW:[{0}]", encoding.GetString(msg)));
                    break;
                case COM_STATUS.CONNECT_READY:
                    _quoteCom.Login(tfcom.Main_ID, tfcom.Main_PWD, tfcom.Main_CENTER);
                    smsg = "QuoteCom: [" + encoding.GetString(msg) + "] MyIP=" + _quoteCom.MyIP;
                    AddInfo(smsg);
                    break;
                case COM_STATUS.CONNECT_FAIL:
                    smsg = encoding.GetString(msg);
                    AddInfo("CONNECT_FAIL:" + smsg);
                    break;
                case COM_STATUS.DISCONNECTED:
                    smsg = encoding.GetString(msg);
                    AddInfo("DISCONNECTED:" + smsg);
                    break;
                case COM_STATUS.SUBSCRIBE:
                    smsg = encoding.GetString(msg, 0, msg.Length - 1);
                    AddInfo(String.Format("SUBSCRIBE:[{0}]", smsg));
                    txtQuoteList.AppendText(String.Format("SUBSCRIBE:[{0}]", smsg));  //2012.02.16 LYNN TEMPORARY ; 
                    break;
                case COM_STATUS.UNSUBSCRIBE:
                    smsg = encoding.GetString(msg, 0, msg.Length - 1);
                    AddInfo(String.Format("UNSUBSCRIBE:[{0}]", smsg));
                    break;
                case COM_STATUS.ACK_REQUESTID:
                    long RequestId = BitConverter.ToInt64(msg, 0);
                    byte status = msg[8];
                    AddInfo("Request Id BACK: " + RequestId + " Status=" + status);
                    break;
                case COM_STATUS.RECOVER_DATA:
                    smsg = encoding.GetString(msg, 1, msg.Length - 1);
                    if (!RecoverMap.ContainsKey(smsg))
                        RecoverMap.Add(smsg, 0);

                    if (msg[0] == 0)
                    {
                        RecoverMap[smsg] = 0;
                        AddInfo(String.Format("開始回補 Topic:[{0}]", smsg));
                    }

                    if (msg[0] == 1)
                    {
                        AddInfo(String.Format("結束回補 Topic:[{0} 筆數:{1}]", smsg, RecoverMap[smsg]));
                    }
                    break;
 */ 
            }
            com.Processed();
        }

        private void OnQuoteRcvMessage(object sender, PackageBase package)
        {
/*
            if (package.TOPIC != null)
                if (RecoverMap.ContainsKey(package.TOPIC))
                    RecoverMap[package.TOPIC]++;
*/

            StringBuilder sb;
            switch (package.DT)
            {
                case (ushort)DT.QUOTE_I020:
                    PI20020 i20020 = (PI20020)package;

/*
                    sb = new StringBuilder(Environment.NewLine);

                    sb.Append("資料時間:").Append(String.Format("{0:00:00:00\\.00}", i20020.MatchTime));
                    sb.Append("    Tick序號:").Append(i20020.InfoSeq).Append(Environment.NewLine);
                    sb.Append("最後封包:").Append(i20020.LastItem).Append(Environment.NewLine);
                    sb.Append("期貨/選擇權:").Append(i20020.Market).Append("  [").Append(i20020.Symbol).Append("]").Append(Environment.NewLine);
                    //sb.Append("價格正負號:").Append(i20020.MATCH_SIGN).Append(Environment.NewLine);
                    sb.Append("成交 [價:").Append(i20020.Price).Append("   量:").Append(i20020.MatchQuantity).Append("]").Append(Environment.NewLine);
                    sb.Append("累計成交  [量:").Append(i20020.MatchTotalQty).Append("  買筆數:")
                        .Append(i20020.MatchBuyCnt).Append("  賣筆數:")
                        .Append(i20020.MatchSellCnt).Append("]").Append(Environment.NewLine);
                    sb.Append("==========================================");
 */
                    string strQuoteInfo = i20020.MatchTime + "," + i20020.Market + "," + i20020.Price + "," + i20020.MatchQuantity + "," + i20020.MatchBuyCnt + "," + i20020.MatchSellCnt;
                    _sw.WriteLine(strQuoteInfo);
                    AddInfo(strQuoteInfo);
                    AddInfo(txtPrice, i20020.Price.ToString());
                    AddInfo(txtVolume, i20020.MatchQuantity.ToString());


                    break;

/*
                case (ushort)DT.LOGIN:
                    P001503 _p001503 = (P001503)package;
                    if (_p001503.Code == 0)
                        AddInfo("可註冊檔數：" + _p001503.Qnum);
                    break;
                case (ushort)DT.QUOTE_I020:
                    PI20020 i20020 = (PI20020)package;
                    sb = new StringBuilder(Environment.NewLine);

                    sb.Append("資料時間:").Append(String.Format("{0:00:00:00\\.00}", i20020.MatchTime));
                    sb.Append("    Tick序號:").Append(i20020.InfoSeq).Append(Environment.NewLine);
                    sb.Append("最後封包:").Append(i20020.LastItem).Append(Environment.NewLine);
                    sb.Append("期貨/選擇權:").Append(i20020.Market).Append("  [").Append(i20020.Symbol).Append("]").Append(Environment.NewLine);
                    //sb.Append("價格正負號:").Append(i20020.MATCH_SIGN).Append(Environment.NewLine);
                    sb.Append("成交 [價:").Append(i20020.Price).Append("   量:").Append(i20020.MatchQuantity).Append("]").Append(Environment.NewLine);
                    sb.Append("累計成交  [量:").Append(i20020.MatchTotalQty).Append("  買筆數:")
                        .Append(i20020.MatchBuyCnt).Append("  賣筆數:")
                        .Append(i20020.MatchSellCnt).Append("]").Append(Environment.NewLine);
                    sb.Append("==========================================");
                    AddInfo(sb.ToString());
                    //AddInfoT("[I20]");
                    break;
                case (ushort)DT.QUOTE_I021:
                    PI20021 i20021 = (PI20021)package;
                    sb = new StringBuilder(Environment.NewLine);
                    sb.Append("******************DataType:").Append(i20021.DT).Append("*****************************");
                    sb.Append("資料時間:").Append(String.Format("{0:00:00:00\\.00}", i20021.MatchTime));
                    sb.Append("當日最高成交價格:").Append(i20021.DayHighPrice).Append("當日最低成交價格:").Append(i20021.DayLowPrice).Append(Environment.NewLine);
                    AddInfo(sb.ToString());
                    //AddInfoT(i20021.ToLog());
                    break;
                case (ushort)DT.QUOTE_I023:
                    PI20023 i20023 = (PI20023)package;
                    sb = new StringBuilder(Environment.NewLine);
                    sb.Append("******************DataType:").Append(i20023.DT).Append("*****************************");
                    AddInfo(sb.ToString());
                    //AddInfoT(i20023.ToLog());
                    break;
                case (ushort)DT.QUOTE_I030:
                    PI20030 i20030 = (PI20030)package;
                    AddInfo(i20030.ToLog());

                    break;
                case (ushort)DT.QUOTE_BASE_P08:
                    //PI20008 pi20008 = (PI20008)package;
                    //sb = new StringBuilder();
                    //sb.Append("商品:").Append(pi20008.Symbol).Append(" 價格小數位:").Append(pi20008.PriceDecimal).Append(" 履約價格小數位:").Append(pi20008.StrikePriceDecimal);
                    //AddInfo(sb.ToString());

                    //sb = new StringBuilder(Environment.NewLine);
                    //sb.Append("期貨/選擇權:").Append(pi20008.Market).Append(Environment.NewLine);
                    //sb.Append("商品代號:").Append(pi20008.Symbol).Append(Environment.NewLine);
                    //sb.Append("商品IDX:").Append(pi20008.SymbolIdx).Append(Environment.NewLine);
                    //sb.Append("第一漲停價:").Append(pi20008._RISE_LIMIT_PRICE1).Append(Environment.NewLine);
                    //sb.Append("參考價:").Append(pi20008._REFERENCE_PRICE).Append(Environment.NewLine);
                    //sb.Append("第一漲停價:").Append(pi20008._RISE_LIMIT_PRICE1).Append(Environment.NewLine);
                    //sb.Append("第二漲停價:").Append(pi20008._RISE_LIMIT_PRICE2).Append(Environment.NewLine);
                    //sb.Append("第二跌停價:").Append(pi20008._FALL_LIMIT_PRICE2).Append(Environment.NewLine);
                    //sb.Append("第三漲停價:").Append(pi20008._RISE_LIMIT_PRICE3).Append(Environment.NewLine);
                    //sb.Append("第三跌停價:").Append(pi20008._FALL_LIMIT_PRICE3).Append(Environment.NewLine);
                    //sb.Append("契約種類:").Append(pi20008._PROD_KIND).Append(Environment.NewLine);
                    //sb.Append("價格欄位小數位數:").Append(pi20008.PriceDecimal).Append(Environment.NewLine);
                    //sb.Append("商品名稱:").Append(pi20008._PROD_NAME).Append(Environment.NewLine);
                    //sb.Append("=================================");
                    //AddInfo(sb.ToString());

                    break;
                case (ushort)DT.QUOTE_CLOSE_I070:
                    PI20070 pb = (PI20070)package;
                    sb = new StringBuilder();
                    sb.Append("期貨/選擇權:").Append(pb.MESSAGE_KIND).Append(Environment.NewLine);
                    sb.Append("商品代號:").Append(pb.PROD_ID).Append(Environment.NewLine);
                    sb.Append("該期最高價:").Append(pb.TERM_HIGH_PRICE).Append(Environment.NewLine);
                    sb.Append("該期最低價:").Append(pb.TERM_LOW_PRICE).Append(Environment.NewLine);
                    sb.Append("該日最高價:").Append(pb.DAY_HIGH_PRICE).Append(Environment.NewLine);
                    sb.Append("該日最低價:").Append(pb.DAY_LOW_PRICE).Append(Environment.NewLine);
                    sb.Append("開盤價:").Append(pb.OPEN_PRICE).Append(Environment.NewLine);
                    sb.Append("最後買價:").Append(pb.BUY_PRICE).Append(Environment.NewLine);
                    sb.Append("最後賣價:").Append(pb.SELL_PRICE).Append(Environment.NewLine);
                    sb.Append("收盤價:").Append(pb.CLOSE_PRICE).Append(Environment.NewLine);
                    sb.Append("委託買進總筆數:").Append(pb.BO_COUNT_TAL).Append(Environment.NewLine);
                    sb.Append("委託買進總口數:").Append(pb.BO_QNTY_TAL).Append(Environment.NewLine);
                    sb.Append("委託賣出總筆數:").Append(pb.SO_COUNT_TAL).Append(Environment.NewLine);
                    sb.Append("委託賣出總口數:").Append(pb.SO_QNTY_TAL).Append(Environment.NewLine);
                    sb.Append("總成交筆數:").Append(pb.TOTAL_COUNT).Append(Environment.NewLine);
                    sb.Append("總成交量:").Append(pb.TOTAL_QNTY).Append(Environment.NewLine);
                    sb.Append("合併委託買進總筆數:").Append(pb.COMBINE_BO_COUNT_TAL).Append(Environment.NewLine);
                    sb.Append("合併委託買進總口數:").Append(pb.COMBINE_BO_QNTY_TAL).Append(Environment.NewLine);
                    sb.Append("合併委託賣出總筆數:").Append(pb.COMBINE_SO_COUNT_TAL).Append(Environment.NewLine);
                    sb.Append("合併委託賣出總口數:").Append(pb.COMBINE_SO_QNTY_TAL).Append(Environment.NewLine);
                    sb.Append("合併總成交量:").Append(pb.COMBINE_TOTAL_QNTY).Append(Environment.NewLine);
                    sb.Append("價格欄位小數點:").Append(pb.DECIMAL_LOCATOR).Append(Environment.NewLine);
                    sb.Append("=========================================");
                    AddInfo(sb.ToString());
                    break;
                case (ushort)DT.QUOTE_I080:
                    PI20080 i20080 = (PI20080)package;
                    sb = new StringBuilder(Environment.NewLine);
                    sb.Append("商品代號:").Append(i20080.Symbol).Append(Environment.NewLine);
                    for (int i = 0; i < 5; i++)
                        sb.Append(String.Format("五檔[{0}] 買[價:{1:N} 量:{2:N}]    賣[價:{3:N} 量:{4:N}]", i + 1, i20080.BUY_DEPTH[i].PRICE, i20080.BUY_DEPTH[i].QUANTITY, i20080.SELL_DEPTH[i].PRICE, i20080.SELL_DEPTH[i].QUANTITY)).Append(Environment.NewLine);
                    sb.AppendLine("衍生委託第一檔買進價格:" + i20080.FIRST_DERIVED_BUY_PRICE);
                    sb.AppendLine("衍生委託第一檔買進數量:" + i20080.FIRST_DERIVED_BUY_QTY);
                    sb.AppendLine("衍生委託第一檔賣出價格:" + i20080.FIRST_DERIVED_SELL_PRICE);
                    sb.AppendLine("衍生委託第一檔賣出數量" + i20080.FIRST_DERIVED_SELL_QTY);
                    sb.Append("==============================================");
                    AddInfo(sb.ToString());
                    //AddInfoT("[I80]");
                    break;
                case (ushort)DT.QUOTE_LAST_PRICE:
                    PI20026 pi20026 = (PI20026)package;
                    sb = new StringBuilder(Environment.NewLine);
                    sb.Append("商品代號:").Append(pi20026.Symbol).Append(" 最後價格:").Append(pi20026.MatchPrice).Append(Environment.NewLine);
                    sb.Append("當日最高成交價格:").Append(pi20026.DayHighPrice).Append(" 當日最低成交價格:").Append(pi20026.DayLowPrice);
                    sb.Append("開盤價:").Append(pi20026.FirstMatchPrice).Append(" 開盤量:").Append(pi20026.FirstMatchQty).Append(Environment.NewLine);
                    sb.Append("參考價:").Append(pi20026.ReferencePrice).Append(Environment.NewLine);
                    sb.Append("==============================================");
                    AddInfo(sb.ToString());
                    //AddInfoT(pi20026.ToLog());
                    break;
 */ 
            }
        }


        #endregion

        private void btnLogout_Click(object sender, EventArgs e)
        {
            try
            {
                _quoteCom.Logout();
                if (_sw != null)
                    _sw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void QuoteForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                _quoteCom.Dispose();
                if (_sw != null)
                    _sw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void btnStopQuote_Click(object sender, EventArgs e)
        {
            try
            {
                _quoteCom.UnsubQuote(txtSymbolId.Text);
                if (_sw != null)
                    _sw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

    }
}
