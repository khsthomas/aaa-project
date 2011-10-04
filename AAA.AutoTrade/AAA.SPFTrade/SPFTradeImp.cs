using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Trade;
using System.Runtime.InteropServices;
using AAA.Meta.Trade;
using AAA.Meta.Trade.Data;
using AAA.Base.Util;

namespace AAA.SPFTrade
{
    public class SPFTradeImp : ITrade, IDisposable
    {
        private static readonly int MINI_REC_LEN = 210;
        private static readonly int TRUST_REC_LEN = 213;
        private static readonly int TRUST_REC_OFFSET = 5;
        private static readonly int TRUST_REC_CNT_START = 0;
        private static readonly int TRUST_REC_CNT_START_LEN = 5;
        private static readonly int[] TRUST_SPLIT_LENGTH = { 2, 5, 5, 8, 15, 5, 6, 10, 3, 2, 9, 9, 3, 5, 6, 20, 4, 60, 3, 15, 1, 6, 6, 1, 4 };

        private static readonly int POSITION_REC_LEN = 192;
        private static readonly int POSITION_REC_OFFSET = 208;
        private static readonly int POSITION_REC_CNT_START = 192;
        private static readonly int POSITION_REC_CNT_START_LEN = 16;
        private static readonly string POSITION_FLAG_IN = "0000";
        private static readonly string POSITION_LENG_IN = "0004";
        private static readonly string POSITION_NEXT_IN = "0000";
        private static readonly string POSITION_PREV_IN = "0000";
        private static readonly int[] POSITION_SPLIT_LENGTH = { 15, 8, 10, 6, 1, 2, 3, 3, 16, 16, 16, 16, 16, 16, 16, 16, 15 };


        [DllImport("t4.dll")]
        public static extern int log_out();
        /*
         初始化
         login_id = 登入id
         login_pass = 登入密碼
         dll_path = Dll所在的目錄
        */
        [DllImport("t4.dll")]
        public static extern string init_t4(string strAccount, string strPassword, string strDllPath);

        /*
         國內期貨下單
         buy_or_sell : "B" = 買, "S" = 賣
         branch : 分公司代號
         account : 帳號
         code : 商品代號
         price :  價格 6位數
         amount : 口數 3位數
         price type : "MKT"市價, "LMT"限價
         ordtype: ROD / FOK / IOC
         octtype: 倉別 "0" = 新倉  "1" = 平倉 " "= 自動  "6"= 當沖
        */
        [DllImport("t4.dll")]
        public static extern string future_order(string strBuyOrSell, string strBranch,
                                                 string strAccount, string strCode,
                                                 string strPrice, string strAmount,
                                                 string strPriceType, string strOrderType,
                                                 string strOCType);

        /*
         future_cancel 國內期貨刪單
         branch : 分公司代號
         account : 帳號
         code : 商品代號
         ord_seq   :  網路單號
         ord_num   :  委託單號
         octtype : "0" 新倉, "1" 平倉, " " 自動
         pre_order : "N" - 非預約單, " " - 預約單
        */
        [DllImport("t4.dll")]
        public static extern string future_cancel(string strBranch, string strAccount,
                                                   string strCode, string strOrderSeq,
                                                   string strOrderNum, string strOCtype,
                                                   string strPreOrder);
        /*
        option_order 國內選擇權下單
        buy_or_sell : "B" = 買, "S" = 賣
        branch : 分公司代號
        account : 帳號
        code : 商品代號
        price :  價格 6位數
        amount : 口數 3位數
        price type : "MKT"市價, "LMT"限價        
        ordertype : "IOC" or "ROD" or "FOK"
        octype : "0" 新倉, "1" 平倉, " " 自動
        IsComp : "S" 單式 , "C" 複式
        bs2 : 第二商品 買 / 賣
        commodity2 : 第二商品代號
        */
        [DllImport("t4.dll")]
        public static extern string option_order(string strBuyOrSell, string strBranch, string strAccount,
                                                 string strCode, string strPrice, string strAmount,
                                                 string strPriceType, string strOrderType, string strOCType,
                                                 string strIsComp, string strBS2, string strCommodity2);

        /*
         國內期權未平倉部位查詢
         gubn : 0:單一帳號 1:群組
         group name : 群組 name
         branch : 分公司代號
         account : 帳號
         type_1 : 0:all ;1:Future ;2:Option ;3:USD
         type_2 : 0:明細 1.匯整
        */
        [DllImport("t4.dll")]
        public static extern string fo_unsettled_qry(string strFlag, string strLeng, string strNekst,
                                                     string strPrev, string strGubn, string strGroupName,
                                                     string strBranch, string strAccount, string strType_1,
                                                     string strType_2, string strTimeOut);

        /*
         查詢下單帳號
        */
        [DllImport("t4.dll")]
        public static extern string show_list();

        /*
         查詢委託回報
         */
        [DllImport("t4.dll")]
        public static extern string get_response();

        /*
         增加驗證群組的CA
         */
        [DllImport("t4.dll")]
        public static extern string add_acc_ca(string strBranch, string strAccount, string strIdNo,
                                               string strCAPath, string strCAPassword);

        [DllImport("t4.dll")]
        public static extern string fo_order_qry(string strBranch, string strAccount, string strCode,
                                                 string strMatchFlag, string strOrderType, string strOCTType,
                                                 string strIsDaily, string strStartDate, string strEndDate,
                                                 string strPreOrder);

        /*
         查看server資訊
         */
        [DllImport("t4.dll")]
        public static extern string show_ip();

        #region ITrade Members
        public event MessageEvent _messageEvent;
        private AccountInfo _accountInfo;

        public void OnMessage(MessageEvent messageEvent)
        {
            _messageEvent += messageEvent;
        }

        private void AlertException(string strError)
        {
            Dictionary<string, object> dicReturn = new Dictionary<string, object>();
            dicReturn.Add("name", "Exception");
            dicReturn.Add("rc", strError);

            if (_messageEvent != null)
                _messageEvent(dicReturn);
        }

        public object InitProgram(AccountInfo accountInfo)
        {
            _accountInfo = accountInfo;
            string strRC = init_t4(accountInfo.IdNo, accountInfo.Password, Environment.CurrentDirectory);
            string[] strAccount;
            string strServerInfo;

            if (strRC.IndexOf("成功") > -1)
            {
                strRC = "Success";
                if (_accountInfo.Branch == "")
                {
                    strAccount = show_list().Split('-');
                    _accountInfo.Branch = strAccount[0];
                    _accountInfo.AccountNo = strAccount[1];
                }
                strRC = add_acc_ca(_accountInfo.Branch, _accountInfo.AccountNo, _accountInfo.IdNo,
                                   _accountInfo.CAPath, _accountInfo.CAPassword);
                strRC = strRC.IndexOf("成功") > -1 ? "Success" : strRC;

                strServerInfo = show_ip();

                strRC += "(Server : " + strServerInfo + ")";
            }

            return strRC;
        }

        public object CA()
        {
            return "Success";
        }

        public object Login()
        {
            return "Success";
        }

        public object Logout()
        {
            log_out();
            return "Success";
        }

        public object SendOrder(OrderInfo orderInfo)
        {
            string strMessage = "";
            try
            {
                /*
                         buy_or_sell : "B" = 買, "S" = 賣
                         branch : 分公司代號
                         account : 帳號
                         code : 商品代號
                         price :  價格 6位數
                         amount : 口數 3位數
                         price type : "MKT"市價, "LMT"限價
                         ordtype: ROD / FOK / IOC
                         octtype: 倉別 "0" = 新倉  "1" = 平倉 " "= 自動  "6"= 當沖
                */

                if (orderInfo.SymbolCode.StartsWith("TXO"))
                    strMessage = option_order((orderInfo.OrderType == "LE" ||
                                               orderInfo.OrderType == "SX") ? "B" : "S",
                                               _accountInfo.Branch,
                                               _accountInfo.AccountNo,
                                               orderInfo.SymbolCode,
                                               (orderInfo.FilledPrice == "M" ? "0" : orderInfo.FilledPrice),
                                               orderInfo.FilledVolume.ToString(),
                                               (orderInfo.FilledPrice == "0" || orderInfo.FilledPrice == "M") ? "MKT" : "LMT",
                                               (orderInfo.FilledPrice == "0" || orderInfo.FilledPrice == "M") ? "IOC" : "ROD",
                        //orderInfo.OrderType.EndsWith("E") ? "0" : "1",
                                               " ",
                                               "S",
                                               "0",
                                               "9");
                else
                    strMessage = future_order((orderInfo.OrderType == "LE" ||
                                               orderInfo.OrderType == "SX") ? "B" : "S",
                                               _accountInfo.Branch,
                                               _accountInfo.AccountNo,
                                               orderInfo.SymbolCode,
                                               (orderInfo.FilledPrice == "M" ? "0" : orderInfo.FilledPrice),
                                               orderInfo.FilledVolume.ToString(),
                                               (orderInfo.FilledPrice == "0" || orderInfo.FilledPrice == "M") ? "MKT" : "LMT",
                                               (orderInfo.FilledPrice == "0" || orderInfo.FilledPrice == "M") ? "IOC" : "ROD",
                                               " ");
                //orderInfo.OrderType.EndsWith("E") ? "0" : "1");                                          
            }
            catch (Exception ex)
            {
                strMessage = ex.Message + "," + ex.StackTrace;
            }
            //            AlertException(strMessage);
            return strMessage;
        }

        public object CancelOrder(OrderInfo orderInfo)
        {
            return "";
        }

        public object GetOrderStatus(OrderInfo orderInfo)
        {
            return "";
        }

        public object GetDealReport(string strStartDate, string strEndDate)
        {
            return "";
        }

        public object GetOrderReport(string strStartDate, string strEndDate)
        {
            string strMessage;
            int iRecCount;
            string strRecord;
            string[] strRecords;

            Dictionary<string, object> dicReturn = new Dictionary<string, object>();
            Dictionary<string, string> dicRecord;
            /*
                        strMessage = fo_order_qry(_accountInfo.Branch, _accountInfo.AccountNo, "         ", "0", "0", "0", "0",
                                                  strStartDate, strEndDate, "N");
            */
            strMessage = get_response();
            if (strMessage.Length < MINI_REC_LEN)
                return "";

            iRecCount = Int32.Parse(strMessage.Substring(TRUST_REC_CNT_START, TRUST_REC_CNT_START_LEN));
            dicReturn.Add("name", "QueryOrderListByDiff");
            dicReturn.Add("recordcount", iRecCount.ToString());
            dicReturn.Add("outputstate", "Success");

            for (int i = 0; i < iRecCount; i++)
            {
                strRecord = StringHelper.Substring(strMessage, i * TRUST_REC_LEN + TRUST_REC_OFFSET, TRUST_REC_LEN);
                strRecords = StringHelper.Split(strRecord, TRUST_SPLIT_LENGTH);
                dicRecord = new Dictionary<string, string>();

                strRecords[6] = strRecords[21].StartsWith(" ") ? "0" + strRecords[21].Substring(1) : strRecords[21];
                dicRecord.Add("time", strRecords[21].Substring(0, 2) + ":" +
                                      strRecords[21].Substring(2, 2) + ":" +
                                      strRecords[21].Substring(4, 2));
                dicRecord.Add("orderno", strRecords[5]);
                dicRecord.Add("product", strRecords[7]);
                dicRecord.Add("bsaction", strRecords[9].Trim() == "B" ? "買進" : "賣出");
                dicRecord.Add("rc", strRecords[15]);
                dicRecord.Add("method", "Unknown");
                dicRecord.Add("intraday", strRecords[17] == "6" ? "當沖" : "一般");
                dicRecord.Add("octype", strRecords[20] == "0"
                                          ? "新倉"
                                          : strRecords[20] == "1"
                                              ? "平倉"
                                              : strRecords[20] == "6"
                                                ? "當沖"
                                                : "自動");
                dicRecord.Add("volume", Int32.Parse(strRecords[13]).ToString());
                dicRecord.Add("price", (Int32.Parse(strRecords[10]) / 1000).ToString());
                dicRecord.Add("ordercondition", "Unknown");
                dicRecord.Add("comment", strRecords[17]);

                dicReturn.Add("record" + i, dicRecord);
            }


            if (_messageEvent != null)
                _messageEvent(dicReturn);
            return "";
        }

        public object GetPositionReport()
        {
            string strMessage = fo_unsettled_qry(POSITION_FLAG_IN, POSITION_LENG_IN, POSITION_NEXT_IN, POSITION_PREV_IN,
                                                 "0", "", _accountInfo.Branch, _accountInfo.AccountNo, "0", "1", "15");

            int iRecCount;
            string strRecord;
            string[] strRecords;

            Dictionary<string, object> dicReturn = new Dictionary<string, object>();
            Dictionary<string, string> dicRecord;
            if (strMessage.Length < MINI_REC_LEN)
                return "";

            iRecCount = Int32.Parse(strMessage.Substring(POSITION_REC_CNT_START, POSITION_REC_CNT_START_LEN));
            dicReturn.Add("name", "QueryTodayPosition");
            dicReturn.Add("recordcount", iRecCount.ToString());
            dicReturn.Add("outputstate", "Success");

            for (int i = 0; i < iRecCount; i++)
            {
                strRecord = StringHelper.Substring(strMessage, i * POSITION_REC_LEN + POSITION_REC_OFFSET, POSITION_REC_LEN);
                strRecords = StringHelper.Split(strRecord, POSITION_SPLIT_LENGTH);
                dicRecord = new Dictionary<string, string>();

                dicRecord.Add("product", strRecords[2]);
                dicRecord.Add("symbolcategory", strRecords[2]);
                dicRecord.Add("bsaction", strRecords[4].Trim() == "B" ? "買進" : "賣出");
                dicRecord.Add("volume", Double.Parse(strRecords[8]).ToString("0"));
                dicRecord.Add("cost", Double.Parse(strRecords[9]).ToString("0.000"));
                dicRecord.Add("price", Double.Parse(strRecords[11]).ToString("0.00"));
                dicRecord.Add("intraday", "Unknown");
                dicRecord.Add("currentpl", (Double.Parse(strRecords[12])).ToString("0"));

                dicReturn.Add("record" + i, dicRecord);
            }


            if (_messageEvent != null)
                _messageEvent(dicReturn);
            return "";

        }

        public bool IsConnected()
        {
            return true;
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            log_out();
        }

        #endregion
    }
}
