using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Trade;
using System.Collections;

namespace AAA.KGTrade
{
    public class KGTradeImp : ITrade, IDisposable
    {
        private AxICEGLOBALTRADEAPILib.AxICEGLOBALTRADEAPI _axIceGlobalTrade;

        //'編碼方式
        public const int NONE = 0;
        public const int MD5 = 1;
        public const int MINECODE = 2;

        //'委成回用到的欄位, 欄位說明請參照文件
        public const int KEY1 = 350;
        public const int KEY2 = 351;
        public const int FORM_TYPE = 352;
        public const int HEADER = 353;
        public const int FTR_NAME2 = 354;
        public const int MEMO = 355;
        public const int OKSEQNO = 356;
        public const int OD_PRICE2 = 357;
        public const int OD_QTY2 = 358;
        public const int BFR_QTY = 359;
        public const int AFT_QTY = 360;
        public const int FUNCTIONCODE = 361;
        public const int SRC_CODE = 362;
        public const int ORG_QTY2 = 363;
        public const int DEAL_QTY = 364;
        public const int DEAL_QTY2 = 365;
        public const int DEAL_AVGPRICE = 366;
        public const int TRANS_DATE = 159;
        public const int MATCH_TIME = 310;
        //'public const int  BRANCH_ID = 1;
        public const int ORDNO = 147;
        public const int S_OD_SEQ = 143;
        public const int F_OD_SEQ = 208;
        //'public const int  CUST_ID = 39;
        public const int STK_ID = 85;
        public const int FTR_ID = 114;
        public const int FTR_MTH = 115;
        public const int CALLPUT = 116;
        public const int STRIKE_PRICE = 117;
        public const int BUYSELL = 148;
        public const int FTR_ID2 = 130;
        public const int FTR_MTH2 = 131;
        public const int CALLPUT2 = 132;
        public const int STRIKE_PRICE2 = 133;
        public const int BUYSELL2 = 134;
        public const int PRICE_FLAG = 150;
        public const int OPENCLOSE = 163;
        public const int OD_TYPE = 149;
        //'public const int  AGENT_ID = 5;
        public const int ERR_CODE = 68;
        public const int ERR_MSG = 69;
        public const int OD_PRICE = 151;
        public const int OBOD_PRICE = 257;
        public const int OD_QTY = 156;
        public const int OD_KEY = 201;
        public const int F_ORG_SEQ = 204;
        public const int S_ORG_SEQ = 144;
        public const int MARKET_TYPE = 101;
        public const int TRADE_TYPE = 153;


        //艾揚下單使用                 '  證券                    期貨         選擇權             複式
        public const int ORDER_ARGS_ROCID = 0;            //'X 身份證字號(登入帳號)           *             *               *
        public const int ORDER_ARGS_PASSWORD = 1;    //     'X 登入密碼                       *             *               *
        public const int ORDER_ARGS_BRANCHID = 2;        // 'X 分公司代號                     *             *               *
        public const int ORDER_ARGS_CUSTID = 3;           //X 帳號                           *             *               *
        public const int ORDER_ARGS_AGENTID = 4;          //X 營業員代碼                     *             *               *
        public const int ORDER_ARGS_SOURCE = 5;        //   'X 來源別                         *             *               *
        public const int ORDER_ARGS_ID = 6;               //'X 商品代碼                       *             *           (第一腳)代碼
        public const int ORDER_ARGS_BS = 7;               //'X 買賣別                         *             *           (第一腳)買賣別
        public const int ORDER_ARGS_ODTYPE = 8;        //   'X 現股(0)/融資(1)/融券(2)        ""      IOC(I)/ROD(R)/FOK(F)    *
        public const int ORDER_ARGS_TRADE_TYPE = 9;  //     'X 普通(N)/盤後(F)/零股(O)        ""            *               *
        public const int ORDER_ARGS_PRICE_FLAG = 10;   //   'X 市價(1), 限價(0)               *             *               *
        public const int ORDER_ARGS_ODPRICE = 11;         //'9 價格                           *             *               *
        public const int ORDER_ARGS_ODQTY = 12;           //'9 數量                           *             *               *
        public const int ORDER_ARGS_ODKEY = 13;           //'X Order Key                      *             *               *
        public const int ORDER_ARGS_OPENCLOSE = 14;    //   'X -                          新倉(O)/平倉(C)   *               *
        public const int ORDER_ARGS_MTH = 15;             //'X -                              -       (第一腳)履約年月      *
        public const int ORDER_ARGS_CP = 16;              //'X -                              -       (第一腳)Call(C)/Put(P)  *
        public const int ORDER_ARGS_STRIKE = 17;        //  '9 -                              -       (第一腳)履約價          *
        public const int ORDER_ARGS_ID2 = 18;             //'X -                              -             -           (第二腳)代碼
        public const int ORDER_ARGS_BS2 = 19;             //'X -                              -             -           (第二腳)買賣別
        public const int ORDER_ARGS_MTH2 = 20;           // 'X -                              -             -           (第二腳)履約年月
        public const int ORDER_ARGS_CP2 = 21;             //'X -                              -             -           (第二腳)CallPut
        public const int ORDER_ARGS_STRIKE2 = 22;        // '9 -                              -             -           (第二腳)履約價
        public const int ORDER_ARGS_MARKETTYPE = 23;  //    '上市(T)/上櫃(O)                  -             -               -
        // '-表示不使用 *表示同左用法
        public const int ORDER_ARGS_EXCHANGE = 24;
        public const int ORDER_ARGS_STOPPRICE = 25;
        public const int ORDER_ARGS_DAYTRADE = 26;

        //'以下為刪單改量用到的欄位
        public const int ORDER_ARGS_ORGSEQ = 27;     // '原始網路單號
        public const int ORDER_ARGS_ORGSOURCE = 28;   //'原始來源別
        public const int ORDER_ARGS_ORDNO = 29;       //委託書號
        public const int ORDER_ARGS_CANCELQTY = 30;   //'取消股數/口數

        public const int ORDER_ARGS_AFTERQTY = 31;
        public const int ORDER_ARGS_TRANSDATE = 32;    //'交易日
        public const int ORDER_ARGS_MATCHQTY = 33; //'成交口數

        //現貨-----------------------------------------------------------------------
        //'取得分公司號
        public static string _strStkBranch = "";
        //'取得帳號
        public static string _strStkAccount = "";
        //取得帳號名稱
        public static string _strStkName = "";
        //取得營業員
        public static string _strStkAgentId = "";
        //期貨---------------------------------------------------------------------
        //    '取得分公司號
        public static string _strBranch = "";
        //    '取得帳號
        public static string _strAccount = "";
        //    '取得帳號名稱
        public static string _strName = "";
        //    '取得營業員
        public static string _strAgentId = "";

        public class TRptData
        {
            public int nType;
            public int nIndex;
            public int nGridNum;
            public String nOrderNo;
        }

        private ArrayList _alOrderReport = new ArrayList();
        private ArrayList _alOBOrderReport = new ArrayList();
        private ArrayList _alDealReport = new ArrayList();
        private ArrayList _alOBDealReport = new ArrayList();


        private int _iOrderRow;
        private int _iDealRow;
        private int _iOBOrderRow;
        private int _iOBDealRow;


        public const int ROC_ID = 34;
        public const int CUST_PWD = 35;
        public const int BRANCH_ID = 1;
        public const int CUST_ID = 39;
        public const int CUST_NAME = 40;
        public const int AGENT_ID = 5;
        public const int ACCOUNT_TYPE = 59;


        public const int ITS_REPORT_LOGIN_OK = 1;
        public const int ITS_REPORT_LOGIN_ERROR = 2;

        public KGTradeImp()
        {
            _axIceGlobalTrade = new AxICEGLOBALTRADEAPILib.AxICEGLOBALTRADEAPI();
        }

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
            _axIceGlobalTrade = new AxICEGLOBALTRADEAPILib.AxICEGLOBALTRADEAPI();
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
            int iRC;

            iRC = _axIceGlobalTrade.Login(1, 
                                             _accountInfo.LoginHost, 
                                             _accountInfo.Host, 
                                             _accountInfo.Port, 
                                             "", 
                                             0, 
                                             "ICE", 
                                             "iRealII", 
                                             _accountInfo.IdNo, 
                                             "", 
                                             "", 
                                             _accountInfo.Password, 
                                             MD5);

            return "Success";
        }

        public object Logout()
        {
            _axIceGlobalTrade.Logout();
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
                strRecord = StringUtil.Substring(strMessage, i * TRUST_REC_LEN + TRUST_REC_OFFSET, TRUST_REC_LEN);
                strRecords = StringUtil.Split(strRecord, TRUST_SPLIT_LENGTH);
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
                strRecord = StringUtil.Substring(strMessage, i * POSITION_REC_LEN + POSITION_REC_OFFSET, POSITION_REC_LEN);
                strRecords = StringUtil.Split(strRecord, POSITION_SPLIT_LENGTH);
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
    }}
