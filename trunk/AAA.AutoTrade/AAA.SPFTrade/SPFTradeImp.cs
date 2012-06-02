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
    public class SPFTradeImp : AbstractTrade, IDisposable
    {
        private static readonly string MONTH = "ABCDEFGHIJKLMNOPQRSTUVWX";

        private static readonly int MINI_REC_LEN = 230;
        private static readonly int TRUST_REC_LEN = 230;
        private static readonly int TRUST_REC_OFFSET = 5;
        private static readonly int TRUST_REC_CNT_START = 0;
        private static readonly int TRUST_REC_CNT_START_LEN = 5;
        private static readonly string[] TRUST_SPLIT_TITLE = { "商品類別", "刪單量", "成交量", "原委託價", "序號", "帳號", "書號", "網路單號", "商品代碼", "指令別", "交易別", "委託價", "成交價", "委託別", "數量", "異動時間", "訊息類別", "錯誤代碼", "錯誤訊息", "下單系統", "未啟用", "倉別", "時間", "未啟用", "未啟用", "未啟用", "成交序號" };
        private static readonly string[] TRUST_SPLIT_FIELD = { "type", "cancelqty", "contractqty", "orgprice", "seq", "account", "ord_no", "ord_seq", "code", "trade_type", "trade_class", "price", "contractprice", "ordknd", "qty", "trans_time", "statusmsg", "errorcode", "errormsg", "web_id", "account_s", "oct", "ord_time", "agent_id", "price_type", "trf_fld", "match_seq" };
        private static readonly int[] TRUST_SPLIT_LENGTH = { 2, 5, 5, 9, 8, 15, 5, 6, 10, 3, 2, 9, 9, 3, 5, 6, 20, 4, 60, 3, 15, 1, 6, 6, 1, 4, 8 };

        private static readonly int POSITION_REC_LEN = 192;
        private static readonly int POSITION_REC_OFFSET = 208;
        private static readonly int POSITION_REC_CNT_START = 192;
        private static readonly int POSITION_REC_CNT_START_LEN = 16;
        private static readonly string POSITION_FLAG_IN = "0000";
        private static readonly string POSITION_LENG_IN = "0004";
        private static readonly string POSITION_NEXT_IN = "0000";
        private static readonly string POSITION_PREV_IN = "0000";
        private static readonly string[] POSITION_SPLIT_TITLE = { "帳號", "交易日", "商品代碼", "委託書號", "買賣別", "未啟用", "幣別", "未啟用", "口數", "成交均價", "結算價", "即時價", "浮動損益", "結算原始保證金", "結算維持保證金", "原始保證金", "維持保證金"};
        private static readonly string[] POSITION_SPLIT_FIELD = { "account", "tdate", "code", "ord_no", "ord_bs", "ord_type", "currency", "fill", "vol", "avg_price", "set_price", "price", "loss", "secu", "keep", "otamt", "mtamt"};
        private static readonly int[] POSITION_SPLIT_LENGTH = { 15, 8, 10, 6, 1, 2, 3, 3, 16, 16, 16, 16, 16, 16, 16, 16, 15 };

        private static readonly int EQUITY_MINI_REC_LEN = 18;
        private static readonly int EQUITY_REC_LEN = 560;
        private static readonly int EQUITY_REC_OFFSET = 18;
        private static readonly int EQUITY_REC_DATE_START = 0;
        private static readonly int EQUITY_REC_DATE_LEN = 8;
        private static readonly int EQUITY_REC_TIME_START = 8;
        private static readonly int EQUITY_REC_TIME_LEN = 6;
        private static readonly int EQUITY_REC_CNT_START = 14;
        private static readonly int EQUITY_REC_CNT_START_LEN = 4;
        private static readonly string[] EQUITY_SPLIT_TITLE = { "下單可用保證金", "帳戶權益數", "期貨平倉損益", "未平倉損益(期貨)", "未平倉損益(選擇權)", "今日選擇權收支", "選擇權市值", "今日存提款", "手續費", "交易稅", "委託保證金", "原始保證金", "維持保證金", "風險係數", "清算風險係數", "未啟用", "未啟用", "未啟用", "未啟用", "前日帳戶餘額", "抵繳金額", "清算權益數", "平倉損益(選擇權)", "轉換匯率", "未啟用", "追繳金額", "昨日清算權益數", "未平倉損益(當日)" };
        private static readonly string[] EQUITY_SPLIT_FIELD = { "Avlamt", "ACTbal", "Tgain", "Bgain", "OBGAIN", "PMamt", "APamt", "TMamt", "FEE", "FTAX", "OTamt", "COGTamt", "CMGTamt", "WARNN", "WARNV", "BidVolume", "AskVolume", "BidMatch", "AskMatch", "BEQUITY", "GdAmt", "EQuity", "OGAIN", "exrate", "xgdamt", "agtamt", "yequity", "munet"};
        private static readonly string[] EQUITY_TYPE = { "台幣", "約當台幣", "美元", "約當美元"};
        private static readonly int[] EQUITY_SPLIT_LENGTH = { 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20};

        private static readonly int FUTURE_OPTION_RETURN_LEN = 181;
        private static readonly string[] FUTURE_OPTION_RETURN_SPLIT_TITLE = { "交易別", "交易帳號", "期/權", "商品代碼", "C/P", "買賣別", "下單價格", "價格別", "交易量", "委託書號", "網路單號", "下單別", "", "", "", "", "", "", "", "", "", "送單日期", "預約交易日期", "送單時間", "預約單", "錯誤代碼", "回應訊息" };
        private static readonly string[] FUTURE_OPTION_RETURN_SPLIT_FIELD = { "trade_type", "account", "f_futopt", "stock_id", "f_callput", "ord_bs", "ord_price", "price_type", "ord_qty", "ord_no", "ord_seq", "ord_type", "f_octype", "f_mttype", "f_composit", "c_futopt", "c_code", "c_callput", "c_buysell", "c_price", "c_quantity", "ord_date", "preord_date", "ord_time", "type", "err_code", "msg" };
        private static readonly int[] FUTURE_OPTION_RETURN_SPLIT_LENGTH = { 2, 15, 1, 10, 1, 1, 12, 3, 4, 6, 6, 3, 1, 1, 2, 1, 10, 1, 1, 12, 4, 8, 8, 6, 1, 4, 60 };


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
         CA測試
         branch = 分行
         account = 帳戶
        */
        [DllImport("t4.dll")]
        public static extern string verify_ca_pass(string strBranch, string strAccountNo);

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
        option_cancel 國內選擇權下單        
        branch : 分公司代號
        account : 帳號
        code : 商品代號
        ord_seq : 網路單號
        ord_num : 委託單號
        octype : "0" 新倉, "1" 平倉, " " 自動
        pre_order : 是否為預約單 "N" 非預約單, " " 預約單
        */
        [DllImport("t4.dll")]
        public static extern string option_cancel(string strBranch, string strAccount, string strCode,
                                                  string strOrderSeq, string strOrderNo, 
                                                  string strOCType, string strPreOrder);

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
         查詢成交回報
         */
        [DllImport("t4.dll")]
        public static extern string get_response_log();

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

        /*
         查看API資訊
         */
        [DllImport("t4.dll")]
        public static extern string show_version();

        /*
         * 查詢當日權益數
         */
        [DllImport("t4.dll")]
        public static extern string fo_get_day_info(string strBranch, string strAccount);

        #region ITrade Members
        public event MessageEvent _messageEvent;
        //private AccountInfo _accountInfo;

        private bool _isInitial = false;
        private bool _isLogin = false;
        private bool _isCheckCA = false;

        public override void OnMessage(MessageEvent messageEvent)
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

        public override object InitProgram(AccountInfo accountInfo)
        {
            _accountInfo = accountInfo;
            _isInitial = true;
            return "Success";
        }

        public override object Login()
        {
            if (_isInitial == false)
            {
                return "請先初始化帳號";
            }
            string strRC = init_t4(_accountInfo.IdNo, _accountInfo.Password, Environment.CurrentDirectory);
            string[] strAccount;
            string strAccountInfo;
            string strServerInfo;            

            if ((strRC.IndexOf("已初始化") > -1) || (strRC.IndexOf("成功") > -1))
            {
                if ((_accountInfo.Branch == "") || (_accountInfo.Branch == null))
                    {
                        strAccountInfo = show_list();
                        strAccount = strAccountInfo.Split('-');
                        _accountInfo.Branch = strAccount[0];
                        _accountInfo.AccountNo = strAccount[1];
                    }
                
                _isLogin = true;
                strServerInfo = show_ip();
                
                strRC += "\n" + show_ip() + "\n" + show_version();
            }

            return strRC;
        }

        public override object CA()
        {
            if (_isLogin == false)
            {
                return "請先登入系統";
            }

            string strRC;
            string strVerifyCA;

            strRC = add_acc_ca(_accountInfo.Branch, _accountInfo.AccountNo, _accountInfo.IdNo,
                               _accountInfo.CAPath, _accountInfo.CAPassword);
            strRC = strRC.IndexOf("成功") > -1 ? "Success" : strRC;

            strVerifyCA = verify_ca_pass(_accountInfo.Branch, _accountInfo.AccountNo);

            _isCheckCA = true;

            return strRC + "\n" + strVerifyCA;
        }

        public override object Logout()
        {
            log_out();            
            return "Success";
        }

        public override string QuerySymbolCode(string strSymbolType, string strStrikePrice, string strPubOrCall, string strYear, string strMonth)
        {
            string strSymbolCode = "";
            string strMonthYear = "";

            int iMonth = NumericHelper.ToInt(strMonth);

            switch (strPubOrCall)
            {
                case "P":
                    strMonthYear = MONTH.Substring(NumericHelper.ToInt(strMonth) - 1 + 12, 1) + strYear.Substring(strYear.Length - 1, 1);
                    break;
                default:
                    strMonthYear = MONTH.Substring(NumericHelper.ToInt(strMonth) - 1, 1) + strYear.Substring(strYear.Length - 1, 1);
                    break;
            }

            switch (strSymbolType)
            {
                case "台指":
                    strSymbolCode = "TXF" + strMonthYear;
                    break;
                case "小台":
                    strSymbolCode = "MXF" + strMonthYear;
                    break;
                case "選擇權":
                    strSymbolCode = "TXO" + StringHelper.FillChar(strStrikePrice, '0', 5, StringFillTypeEnum.Left) + strMonthYear;
                    break;
            }

            return strSymbolCode;
        }

        private void WriteLog(string[] strParams)
        {
            string strLog = "";
            foreach (string strParam in strParams)
                strLog += "," + strParam;
            if (strLog.Length > 0)
                strLog = strLog.Substring(1);

            foreach (AAA.Logger.Logger logger in Loggers)
            {
                logger.Write(this, strLog);
            }

        }

        public override object SendOrder(OrderInfo orderInfo)
        {
            string strMessage = "";
            string[] strParams;
            string[] strReturns;
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
                {
                    strParams = new string[] {(orderInfo.OrderType == "LE" ||
                                               orderInfo.OrderType == "SX") ? "B" : "S",
                                               _accountInfo.Branch,
                                               _accountInfo.AccountNo,
                                               orderInfo.SymbolCode,
                                               (orderInfo.FilledPrice == "M" ? "0" : orderInfo.FilledPrice),
                                               orderInfo.FilledVolume.ToString(),
                                               (orderInfo.FilledPrice == "0" || orderInfo.FilledPrice == "M") ? "MKT" : "LMT",
                                               (orderInfo.FilledPrice == "0" || orderInfo.FilledPrice == "M") ? "IOC" : "ROD",
                                               orderInfo.IsDistinctExitOrder 
                                                    ?   orderInfo.OrderType.EndsWith("E") 
                                                            ? orderInfo.IntraDay 
                                                                ?   "6"
                                                                :   "0" 
                                                            : "1"
                                                    :   " ",
                                               "S",
                                               "0",
                                               "9"};

                    if(TradeMode == TradeModeEnum.Real)                    
                        strMessage = option_order(strParams[0],
                                                  strParams[1],
                                                  strParams[2],
                                                  strParams[3],
                                                  strParams[4],
                                                  strParams[5],
                                                  strParams[6],
                                                  strParams[7],
                                                  strParams[8],
                                                  strParams[9],
                                                  strParams[10],
                                                  strParams[11]);                    
                }
                else
                {
                    strParams = new string[] {(orderInfo.OrderType == "LE" ||
                                               orderInfo.OrderType == "SX") ? "B" : "S",
                                               _accountInfo.Branch,
                                               _accountInfo.AccountNo,
                                               orderInfo.SymbolCode,
                                               (orderInfo.FilledPrice == "M" ? "0" : orderInfo.FilledPrice),
                                               orderInfo.FilledVolume.ToString(),
                                               (orderInfo.FilledPrice == "0" || orderInfo.FilledPrice == "M") ? "MKT" : "LMT",
                                               (orderInfo.FilledPrice == "0" || orderInfo.FilledPrice == "M") ? "IOC" : "ROD",
                                               orderInfo.IsDistinctExitOrder 
                                                    ?   orderInfo.OrderType.EndsWith("E") 
                                                            ? orderInfo.IntraDay 
                                                                ?   "6"
                                                                :   "0" 
                                                            : "1"
                                                    :   " " };
                    if (TradeMode == TradeModeEnum.Real)                    
                        strMessage = future_order(strParams[0],
                                                  strParams[1],
                                                  strParams[2],
                                                  strParams[3],
                                                  strParams[4],
                                                  strParams[5],
                                                  strParams[6],
                                                  strParams[7],
                                                  strParams[8]);                    
                }

                WriteLog(strParams);

                strReturns = StringHelper.Split(strMessage, FUTURE_OPTION_RETURN_SPLIT_LENGTH);
                WriteLog(strReturns);
                
                //orderInfo.OrderType.EndsWith("E") ? "0" : "1");                                          
            }
            catch (Exception ex)
            {
                strMessage = ex.Message + "," + ex.StackTrace;
            }
            //            AlertException(strMessage);
            return strMessage;
        }

        public override object CancelOrder(OrderInfo orderInfo)
        {
            string strMessage = "";
            string[] strParams;            
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

            /*
            option_cancel 國內選擇權下單        
            branch : 分公司代號
            account : 帳號
            code : 商品代號
            ord_seq : 網路單號
            ord_num : 委託單號
            octype : "0" 新倉, "1" 平倉, " " 自動
            pre_order : 是否為預約單 "N" 非預約單, " " 預約單
            */

            strParams = new string[] { _accountInfo.Branch, 
                                       _accountInfo.AccountNo, 
                                       orderInfo.SymbolCode, 
                                       orderInfo.OrderID, 
                                       orderInfo.OrderNo, 
                                       orderInfo.OrderType.EndsWith("E")
                                        ?   "0"
                                        :   orderInfo.OrderType.EndsWith("X")
                                            ?   "1"
                                            :   " ", 
                                       orderInfo.IsAppointment ? " " : "N"};


            if (orderInfo.SymbolCode.StartsWith("TXO"))
            {
                if (TradeMode == TradeModeEnum.Real)
                    strMessage = option_cancel(strParams[0], 
                                               strParams[1], 
                                               strParams[2], 
                                               strParams[3], 
                                               strParams[4], 
                                               strParams[5], 
                                               strParams[6]);
            }
            else
            {
                if (TradeMode == TradeModeEnum.Real)
                    strMessage = future_cancel(strParams[0],
                                               strParams[1],
                                               strParams[2],
                                               strParams[3],
                                               strParams[4],
                                               strParams[5],
                                               strParams[6]);
            }
            WriteLog(strParams);
            return strMessage;
        }

        public override object GetOrderStatus(OrderInfo orderInfo)
        {
            return "";
        }

        public override object GetDealReport(string strStartDate, string strEndDate)
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
            strMessage = get_response_log();
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

                for (int j = 0; j < TRUST_SPLIT_FIELD.Length; j++)
                    dicRecord.Add(TRUST_SPLIT_FIELD[j], strRecords[j]);




                /* 
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
               */


                dicReturn.Add("record" + i, dicRecord);
            }


            if (_messageEvent != null)
                _messageEvent(dicReturn);
            return "";

        }

        public override object GetOrderReport(string strStartDate, string strEndDate)
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

                for (int j = 0; j < TRUST_SPLIT_FIELD.Length; j++)
                {
                    if (TRUST_SPLIT_TITLE[j].EndsWith("價") && (strRecords[j].Trim() != ""))
                    {
                        dicRecord.Add(TRUST_SPLIT_FIELD[j], (NumericHelper.ToDouble(strRecords[j]) / 1000.0).ToString("0.00"));
                    }
                    else if (TRUST_SPLIT_TITLE[j].EndsWith("量") && (strRecords[j].Trim() != ""))
                    {
                        dicRecord.Add(TRUST_SPLIT_FIELD[j], NumericHelper.ToDouble(strRecords[j]).ToString("0.00"));
                    }
                    else
                    {

                        dicRecord.Add(TRUST_SPLIT_FIELD[j], strRecords[j]);
                    }
                }

                //簡明內容轉換 Start

                //商品類別
                dicRecord["type"] = dicRecord["type"].Trim() == "93"
                                        ?   "股票"
                                        :   dicRecord["type"].Trim() == "91"
                                            ? "期權"
                                            : "未知";
                //成交時間
                dicRecord["ord_time"] = dicRecord["ord_time"].Substring(0, 2) + ":" +
                                        dicRecord["ord_time"].Substring(2, 2) + ":" +
                                        dicRecord["ord_time"].Substring(4, 2);

                //指令別
                switch(dicRecord["trade_type"].Trim())
                {
                    case "01":
                    case "1":
                        dicRecord["trade_type"] = "買";
                        break;

                    case "02":
                    case "2":
                        dicRecord["trade_type"] = "賣";
                        break;

                    case "03":
                    case "UPD":
                        dicRecord["trade_type"] = "改量";
                        break;

                    case "04":
                    case "CXL":
                        dicRecord["trade_type"] = "刪單";
                        break;

                    default :
                        dicRecord["trade_type"] = "未知";
                        break;
                }
/*
                dicRecord["trade_type"] = dicRecord["type"].Trim() == "93"
                                            ? dicRecord["trade_type"].Trim() == "01"
                                                ? "買"
                                                : dicRecord["trade_type"].Trim() == "02"
                                                    ? "賣"
                                                    : dicRecord["trade_type"].Trim() == "03"
                                                        ? "改量"
                                                        : dicRecord["trade_type"].Trim() == "04"
                                                            ? "刪單"
                                                            : "未知"

                                            : dicRecord["trade_type"].Trim() == "1"
                                                ? "買"
                                                : dicRecord["trade_type"].Trim() == "2"
                                                    ? "賣"
                                                    : dicRecord["trade_type"].Trim() == "CXL"
                                                        ? "刪單"
                                                        : dicRecord["trade_type"].Trim() == "UPD"
                                                            ? "改量"
                                                            : "未知";
 */

                //交易別
                switch (dicRecord["trade_class"].Trim())
                {
                    case "01":
                        dicRecord["trade_class"] = "現賣";
                        break;

                    case "02":
                        dicRecord["trade_class"] = "現買";
                        break;

                    case "03":
                        dicRecord["trade_class"] = "資賣";
                        break;

                    case "04":
                        dicRecord["trade_class"] = "資買";
                        break;

                    case "05":
                        dicRecord["trade_class"] = "券賣";
                        break;

                    case "06":
                        dicRecord["trade_class"] = "券買";
                        break;

                    case "B":
                        dicRecord["trade_class"] = "買";
                        break;

                    case "S":
                        dicRecord["trade_class"] = "賣";
                        break;

                    case "EB":
                        dicRecord["trade_class"] = "零買";
                        break;

                    case "ES":
                        dicRecord["trade_class"] = "零賣";
                        break;

                    default:
                        dicRecord["trade_class"] = "未知";
                        break;
                }

                //委託別
                switch (dicRecord["ordknd"].Trim())
                {
                    case "0":
                        dicRecord["ordknd"] = "現股/定盤";
                        break;

                    case "2":
                        dicRecord["ordknd"] = "零股";
                        break;

                    case "FOK":
                    case "ROD":
                    case "IOC":
                        break;

                    default:
                        dicRecord["ordknd"] = "未知";
                        break;
                }

                //倉別
                switch (dicRecord["oct"].Trim())
                {
                    case "0":
                        dicRecord["oct"] = "新倉";
                        break;

                    case "1":
                        dicRecord["oct"] = "平倉";
                        break;

                    case "2":
                        dicRecord["oct"] = "自動";
                        break;

                    default:
                        dicRecord["oct"] = "未知";
                        break;
                }



                //簡明內容轉換 End
                 /* 
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
                */


                dicReturn.Add("record" + i, dicRecord);
            }


            if (_messageEvent != null)
                _messageEvent(dicReturn);
            return "";
        }

        public override object GetPositionReport()
        {
            string strMessage = fo_unsettled_qry(POSITION_FLAG_IN, POSITION_LENG_IN, POSITION_NEXT_IN, POSITION_PREV_IN,
                                                 "0", "", _accountInfo.Branch, _accountInfo.AccountNo, "0", "0", "15");

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
            dicReturn.Add("fields", POSITION_SPLIT_FIELD);
            dicReturn.Add("titles", POSITION_SPLIT_TITLE);

            for (int i = 0; i < iRecCount; i++)
            {
                strRecord = StringHelper.Substring(strMessage, i * POSITION_REC_LEN + POSITION_REC_OFFSET, POSITION_REC_LEN);
                strRecords = StringHelper.Split(strRecord, POSITION_SPLIT_LENGTH);
                dicRecord = new Dictionary<string, string>();
                for (int j = 0; j < POSITION_SPLIT_FIELD.Length; j++)
                    dicRecord.Add(POSITION_SPLIT_FIELD[j], strRecords[j]);

/*
                dicRecord.Add("product", strRecords[2]);
                dicRecord.Add("symbolcategory", strRecords[2]);
                dicRecord.Add("bsaction", strRecords[4].Trim() == "B" ? "買進" : "賣出");
                dicRecord.Add("volume", Double.Parse(strRecords[8]).ToString("0"));
                dicRecord.Add("cost", Double.Parse(strRecords[9]).ToString("0.000"));
                dicRecord.Add("price", Double.Parse(strRecords[11]).ToString("0.00"));
                dicRecord.Add("intraday", "Unknown");
                dicRecord.Add("currentpl", (Double.Parse(strRecords[12])).ToString("0"));
*/
                dicReturn.Add("record" + i, dicRecord);
            }


            if (_messageEvent != null)
                _messageEvent(dicReturn);
            return "";

        }

        public override object GetTodayEquity()
        {
            string strMessage = fo_get_day_info(_accountInfo.Branch, _accountInfo.AccountNo);

            int iRecCount;
            string strRecord;
            string[] strRecords;

            Dictionary<string, object> dicReturn = new Dictionary<string, object>();
            Dictionary<string, string> dicRecord;
            if (strMessage.Length < EQUITY_REC_LEN)
                return "";

            iRecCount = Int32.Parse(strMessage.Substring(EQUITY_REC_CNT_START, EQUITY_REC_CNT_START_LEN));
            dicReturn.Add("name", "QueryTodayEquity");
            dicReturn.Add("recordcount", iRecCount.ToString());
            dicReturn.Add("outputstate", "Success");
            dicReturn.Add("fields", EQUITY_SPLIT_FIELD);
            dicReturn.Add("titles", EQUITY_SPLIT_TITLE);
            dicReturn.Add("equitytypes", EQUITY_TYPE);

            for (int i = 0; i < iRecCount; i++)
            {
                strRecord = StringHelper.Substring(strMessage, i * EQUITY_REC_LEN + EQUITY_REC_OFFSET, EQUITY_REC_LEN);
                strRecords = StringHelper.Split(strRecord, EQUITY_SPLIT_LENGTH);
                dicRecord = new Dictionary<string, string>();
                for(int j = 0; j < EQUITY_SPLIT_FIELD.Length; j++)
                    dicRecord.Add(EQUITY_SPLIT_FIELD[j], strRecords[j]);

                dicReturn.Add("record" + i, dicRecord);
            }


            if (_messageEvent != null)
                _messageEvent(dicReturn);
            return "";

        }


        public override bool IsConnected()
        {
            return true;
        }

        public override Dictionary<string, string> SplitMessage(string strMessage, string strMessageType)
        {
            Dictionary<string, string> dicReturn = new Dictionary<string, string>();
            int[] iSplitLens = null;
            string[] strSplitTitles = null;
            string[] strSplitFields = null;
            string[] strSplits = null;

            try
            {
                switch (strMessageType)
                {
                    case "FutureOptionReturn":
                        iSplitLens = FUTURE_OPTION_RETURN_SPLIT_LENGTH;
                        strSplitFields = FUTURE_OPTION_RETURN_SPLIT_FIELD;
                        strSplitTitles = FUTURE_OPTION_RETURN_SPLIT_TITLE;
                        break;
                }

                strSplits = StringHelper.Split(strMessage, iSplitLens);
                for (int i = 0; i < strSplitFields.Length; i++)
                    dicReturn.Add(strSplitFields[i], strSplits[i]);
            }
            catch (Exception ex)
            {
                dicReturn.Add("ErrorMessage", ex.Message + "," + ex.StackTrace);
            }
            return dicReturn;
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
