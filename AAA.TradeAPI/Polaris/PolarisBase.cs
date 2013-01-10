using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Meta.Trade;
using System.Threading;
using System.Windows.Forms;
using AAA.Meta.Trade.Data;
using System.Runtime.InteropServices;

namespace AAA.TradeAPI.Polaris
{
    public class PolarisBase
    {
        public const string RETURN_MESSAGE = "ReturnMessage";
        public const string SUCCESS_RETURN_MESSAGE = "Success";


        private const int CONNECTED = 1;
        private const int DISCONNECTED = 2;
        private const int NOT_LOGIN = 3;
        private const int NOT_CONNECTED = 5;

        private const int SYSTEM_RESP = 0;
        private const int RQRP_RESP = 1;
        private const int SUBSCRIPE_RESP = 2;

        private const string INTEGRATE_LOGIN = "0";
        private const string SUB_ACCOUNT_LOGIN = "1";
        /*
                private const string INVENTORY = "1467140B";
                private const string EQUITY = "1468140C";
                private const string DEAL = "1465140C";
                private const string SEND = "1E641416";
                private const string SEND_STOCK = "1E640A0A";
                private const string REPORT = "1465140B";
                private const string COVER = "1466140B";

                private const string GET_POSITION_REPORT = "20.103.20.11";
                private const string TODAY_EQUITY = "20.104.20.12";
                private const string DEAL_REPORT = "20.101.20.12";
                private const string SEND_ORDER = "30.100.20.22";
                private const string SEND_STOCK_ORDER = "30.100.10.10";
                private const string ORDER_REPORT = "20.101.20.11";
                private const string COVER_REPORT = "20.102.20.11";

                //登入
                private static string[] LOGIN_OUTPUT_PARENT_TYPE = { "string", "string", "int" };
                private static int[] LOGIN_OUTPUT_PARENT_LEN = { 4, 50, 4 };
                private static string[] LOGIN_OUTPUT_PARENT_NAME = { "MsgCode", "MsgContent", "RecordCount" };

                private static string[] LOGIN_OUTPUT_CHILDREN_TYPE = { "string", "string", "string", "short" };
                private static int[] LOGIN_OUTPUT_CHILDREN_LEN = { 22, 12, 14, 2 };
                private static string[] LOGIN_OUTPUT_CHILDREN_NAME = { "Account", "Name", "InvestorId", "SellerNo" };

                //目前庫存
                private const string INVENTORY_RETUTN_CODE = "";
                private static string[] INVENTORY_OUTPUT_PARENT_TYPE = { "int" };
                private static int[] INVENTORY_OUTPUT_PARENT_LEN = { 4 };
                private static string[] INVENTORY_OUTPUT_PARENT_NAME = { "RecordCount" };

                private static string[] INVENTORY_OUTPUT_CHILDREN_TYPE = { "string", "string", "string", "string", "int", "long", "string", "string", "int", "int", "string", "string", "int", "int", "int", "int", "string", "string", "string", "string", "string", "string", "byte", "string", "byte", "string", "byte", "string", "byte", "string" };
                private static int[] INVENTORY_OUTPUT_CHILDREN_LEN = { 22, 1, 20, 1, 4, 8, 6, 1, 4, 4, 6, 1, 4, 4, 4, 4, 3, 1, 1, 1, 1, 1, 1, 12, 1, 12, 1, 12, 1, 12 };
                private static string[] INVENTORY_OUTPUT_CHILDREN_NAME = { "Account", "Kind", "Trid", "BS", "Qty", "Amount", "CommodityID1", "CallPut1", "SettlementMonth1", "StrikePrice1", "CommodityID2", "CallPut2", "SettlementMonth2", "StrikePrice2", "Fee", "Tax", "CurrencyType", "DayTradeID", "BS1", "BS2", "ProdKind1", "ProdKind2", "MarketNo1", "StockCode1", "MarketNo2", "StockCode2", "BelongMarketNo1", "BelongStockCode1", "BelongMarketNo2", "BelongStockCode2" };

                //目前權益數
                private static string[] EQUITY_OUTPUT_PARENT_TYPE = { "short", "string", "long", "long", "long", "long", "long", "long", "long", "long", "long", "long", "long", "long", "string", "long", "long", "string", "long", "long", "long", "long", "string", "long" };
                private static int[] EQUITY_OUTPUT_PARENT_LEN = { 2, 78, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 9, 8, 8, 9, 8, 8, 8, 8, 1, 8 };
                private static string[] EQUITY_OUTPUT_PARENT_NAME = { "ReplyCode", "Advisory", "CurrencyRate", "AccountBalance", "InOutAmt", "VarIncome", "AccountEquity", "RealizePremium", "UnRealizePremium", "InitialMargin", "MaintainMargin", "CoverIncome", "TodayTOT", "UsableMargin", "MaintainRate", "BuyOptionValue", "SellOptionValue", "FullRate", "CoverAmt", "AddMargin", "CashUsable", "NetEquityAmt", "MarginGetType", "YNetEquitAmt" };

                //成交回報
                private static string[] DEAL_OUTPUT_PARENT_TYPE = { "int" };
                private static int[] DEAL_OUTPUT_PARENT_LEN = { 4 };
                private static string[] DEAL_OUTPUT_PARENT_NAME = { "RecordCount" };

                private static string[] DEAL_OUTPUT_CHILDREN_TYPE = { "string", "string", "string", "string", "int", "string", "int", "long", "long", "Time", "Date", "string", "int", "string", "int", "string", "int", "string", "string", "int", "string", "string", "string", "long" };
                private static int[] DEAL_OUTPUT_CHILDREN_LEN = { 22, 1, 20, 7, 4, 1, 4, 8, 8, 5, 4, 5, 4, 7, 4, 1, 4, 1, 1, 4, 8, 8, 1, 8 };
                private static string[] DEAL_OUTPUT_CHILDREN_NAME = { "Account", "MarketNo", "MarketName", "CommodityID1", "SettlementMonth1", "BuySellKind1", "MatchQty", "MatchPrice1", "MatchPrice2", "MatchTime", "MatchDate", "OrderNo", "StrikePrice1", "CommodityID2", "SettlementMonth2", "BuySellKind2", "StrikePrice2", "RecType", "ProductType", "OrderPrice", "IdName", "IdName2", "DayTradeID", "SprMatchPrice" };

                //委託回報-查詢
                private static string[] REPORT_OUTPUT_PARENT_TYPE = { "int" };
                private static int[] REPORT_OUTPUT_PARENT_LEN = { 4 };
                private static string[] REPORT_OUTPUT_PARENT_NAME = { "RecordCount" };

                private static string[] REPORT_OUTPUT_CHILDREN_TYPE = { "string", "Date", "byte", "string", "string", "int", "int", "string", "string", "int", "int", "string", "string", "string", "string", "int", "int", "int", "int", "Date", "Time", "string", "string", "string", "string", "short", "long", "long", "long", "string" };
                private static int[] REPORT_OUTPUT_CHILDREN_LEN = { 22, 4, 1, 20, 7, 4, 4, 1, 7, 4, 4, 1, 1, 1, 10, 4, 4, 4, 4, 4, 5, 10, 78, 5, 1, 2, 8, 8, 8, 1 };
                private static string[] REPORT_OUTPUT_CHILDREN_NAME = { "Account", "TradeDate", "MarketNo", "MarketName", "CommodityID1", "SettlementMonth1", "StrikePrice1", "BuySellKind1", "CommodityID2", "SettlementMonth2", "StrikePrice2", "BuySellKind2", "OpenOffsetKind", "OrderCondition", "OrderPrice", "OrderQty", "AfterQty", "OkQty", "Status", "AcceptDate", "AcceptTime", "ErrorNo", "ErrorMessage", "OrderNo", "ProductType", "Seller", "TotalMatFee", "TotalMatExchTax", "TotalMatPremium", "DayTradeID" };

                //委託回報-送單
                private static string[] SEND_ORDER_OUTPUT_PARENT_TYPE = { "string", "string", "int" };
                private static int[] SEND_ORDER_OUTPUT_PARENT_LEN = { 4, 50, 4 };
                private static string[] SEND_ORDER_OUTPUT_PARENT_NAME = { "MsgCode", "MsgContent", "RecordCount" };

                private static string[] SEND_ORDER_OUTPUT_CHILDREN_TYPE = { "int", "short", "string", "Date", "string", "string", "string" };
                private static int[] SEND_ORDER_OUTPUT_CHILDREN_LEN = { 4, 2, 5, 4, 1, 3, 74 };
                private static string[] SEND_ORDER_OUTPUT_CHILDREN_NAME = { "Identify", "ReplyCode", "OrderNo", "TradeDate", "ErrKind", "ErrNo", "Advisory" };

                //股票委託回報-送單
                private static string[] STOCK_SEND_ORDER_OUTPUT_PARENT_TYPE = { "string", "string", "int" };
                private static int[] STOCK_SEND_ORDER_OUTPUT_PARENT_LEN = { 4, 50, 4 };
                private static string[] STOCK_SEND_ORDER_OUTPUT_PARENT_NAME = { "MsgCode", "MsgContent", "RecordCount" };

                private static string[] STOCK_SEND_ORDER_OUTPUT_CHILDREN_TYPE = { "int", "short", "string", "Date", "string", "string", "string" };
                private static int[] STOCK_SEND_ORDER_OUTPUT_CHILDREN_LEN = { 4, 2, 5, 4, 1, 3, 78 };
                private static string[] STOCK_SEND_ORDER_OUTPUT_CHILDREN_NAME = { "Identify", "ReplyCode", "OrderNo", "TradeDate", "ErrKind", "ErrNo", "Advisory" };

                //沖銷明細-查詢
                private static string[] COVER_OUTPUT_PARENT_TYPE = { "int" };
                private static int[] COVER_OUTPUT_PARENT_LEN = { 4 };
                private static string[] COVER_OUTPUT_PARENT_NAME = { "RecordCount" };

                private static string[] COVER_OUTPUT_CHILDREN_TYPE = { "string", "Date", "short", "short", "Date", "string", "int", "int", "string", "string", "int", "string", "int", "int", "int", "int", "byte", "string" };
                private static int[] COVER_OUTPUT_CHILDREN_LEN = { 22, 4, 2, 2, 4, 7, 4, 4, 20, 1, 4, 1, 4, 4, 4, 4, 1, 3 };
                private static string[] COVER_OUTPUT_CHILDREN_NAME = { "Account", "CoverDate", "CoverSeqNo", "CoverNum", "OriTradeDate", "FutCode", "FutTradeYM1", "StrikeP", "StkName", "BSCL", "MatchP", "SourceCL", "CoverVol", "ProfitMoney", "Fee", "Tax", "ProductType", "CurrencyType" };
        */
        private event MessageEvent _messageEvent;

        private System.Timers.Timer _timer;

        private PolarisB2BAPI.PolaisB2BTrader _objB2BApi;
        private PolarisB2BAPI.IPolaisB2BTraderEvents_OnResponseEventHandler _eventHandle = null;

        private Dictionary<string, object> _dicReturn;        
        private bool _isConnected;
        private List<string> _lstParam;
        private string _strSellerNo = "0";

        private Dictionary<string, PolarisStructure> _dicStructure;
        private Dictionary<string, string> _dicHexMapping;
        
        private int _iMaxWaitCount = 20;
        private bool _isAutoLogin;

        public bool IsAutoLogin
        {
            get { return _isAutoLogin; }
            set { _isAutoLogin = value; }
        }
        protected AccountInfo _accountInfo;                

        public PolarisBase()
        {
            _dicHexMapping = new Dictionary<string, string>();
            _dicStructure = new Dictionary<string, PolarisStructure>();
            _timer = new System.Timers.Timer();
            _timer.Elapsed += new System.Timers.ElapsedEventHandler(_timer_Elapsed);

            AddMessageStructure(new LoginStructure());
        }

        public void AddMessageStructure(PolarisStructure messageStructure)
        {
            if(_dicStructure.ContainsKey(messageStructure.ApiId))
            {
                _dicStructure[messageStructure.ApiId] = messageStructure;
                _dicHexMapping[messageStructure.ApiIdHex] = messageStructure.ApiId;
            }
            else
            {
                _dicStructure.Add(messageStructure.ApiId, messageStructure);
                _dicHexMapping.Add(messageStructure.ApiIdHex, messageStructure.ApiId);
            }
        }

        public int MaxWaitCount
        {
            private get { return _iMaxWaitCount; }
            set { _iMaxWaitCount = value; }
        }

        public bool IsConnected
        {
            get { return _isConnected; }
            private set { _isConnected = value; }
        }

        public PolarisStructure GetMessageStructure(string strApiId)
        {
            return _dicStructure.ContainsKey(strApiId)
                    ?   _dicStructure[strApiId]
                    :   null;
        }

        public AccountInfo AccountInfo
        {
            get { return _accountInfo; }
        }

        public PolarisB2BAPI.PolaisB2BTrader B2BApi
        {
            get
            {
                if (_objB2BApi == null)
                {
                    _objB2BApi = new PolarisB2BAPI.PolaisB2BTrader();
                }
                try
                {
                    if (_eventHandle == null)
                    {
                        _eventHandle = new PolarisB2BAPI.IPolaisB2BTraderEvents_OnResponseEventHandler(objB2BApi_OnResponse);
                        _objB2BApi.OnResponse += _eventHandle;
                    }
                }
                catch (Exception ex)
                {

                }

                return _objB2BApi;
            }
            set
            {
                _objB2BApi = value;

                try
                {
                    if (_eventHandle == null)
                    {
                        _eventHandle = new PolarisB2BAPI.IPolaisB2BTraderEvents_OnResponseEventHandler(objB2BApi_OnResponse);
                        _objB2BApi.OnResponse += _eventHandle;
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

        void AddValue(Dictionary<string, object> dicData, string strKey, object strValue)
        {
            if (dicData.ContainsKey(strKey))
                dicData[strKey] += "," + strValue;
            else
                dicData.Add(strKey, strValue);
        }

        void AddValue(Dictionary<string, object> dicData, string strKey, long lValue)
        {
            if (dicData.ContainsKey(strKey))
                dicData[strKey] += "," + lValue.ToString();
            else
                dicData.Add(strKey, lValue.ToString());
        }

        void AddValue(Dictionary<string, object> dicData, string strKey, int iValue)
        {
            if (dicData.ContainsKey(strKey))
                dicData[strKey] += "," + iValue.ToString();
            else
                dicData.Add(strKey, iValue.ToString());
        }

        void AddValue(Dictionary<string, object> dicData, string strKey, short sValue)
        {
            if (dicData.ContainsKey(strKey))
                dicData[strKey] += "," + sValue.ToString();
            else
                dicData.Add(strKey, sValue.ToString());
        }

        void AddValue(Dictionary<string, object> dicData, string strKey, byte bValue)
        {
            if (dicData.ContainsKey(strKey))
                dicData[strKey] += "," + bValue.ToString();
            else
                dicData.Add(strKey, bValue.ToString());
        }

        string GenerateHeader(string[] strFields, string[] strSwichFields)
        {
            string strHeader = "";
            try
            {
                for (int i = 0; i < strFields.Length; i++)
                    strHeader += "," + strFields[i];

                for (int i = 0; i < strSwichFields.Length; i++)
                    strHeader += "," + strSwichFields[i];
            }
            catch (Exception ex)
            {
                return ex.Message + "," + ex.StackTrace;
            }
            return (strHeader.Length > 0) ? strHeader.Substring(1) : "";
        }

        public string ProcessInput(Dictionary<string, string> dicInput, string[] strTypes, int[] iLengthes, string[] strNames)
        {
            try
            {
                for (int i = 0; i < strTypes.Length; i++)
                {
                    ProcessInput(strTypes[i], iLengthes[i], dicInput[strNames[i]]);
                }
            }
            catch (Exception ex)
            {
                return ex.Message + "," + ex.StackTrace;
            }
            return "";
        }

        public string ProcessInput(string strType, int iLength, string strValue)
        {
            try
            {
                string[] strTimes;
                string[] strSeconds;
                string[] strValues;

                if (_lstParam != null)
                    _lstParam.Add(strType + "-" + iLength + "-" + strValue);

                switch (strType)
                {
                    case "short":
                        B2BApi.inMsgAddsmi(Convert.ToInt16(strValue));
                        break;
                    case "byte":
                        B2BApi.inMsgAddByte(Convert.ToByte(strValue));
                        break;
                    case "int":
                        B2BApi.inMsgAddLong(Convert.ToInt32(strValue));
                        break;
                    case "long":
                        B2BApi.inMsgAddLongLong(Convert.ToInt64(strValue));
                        break;
                    case "Date":
                        B2BApi.inMsgAddDate(Convert.ToUInt16(strValue.Split('/')[0]), Convert.ToByte(strValue.Split('/')[1]), Convert.ToByte(strValue.Split('/')[2]));
                        break;
                    case "Time":
                        strTimes = strValue.Split(':');
                        strSeconds = strTimes[2].Split('.');
                        B2BApi.inMsgAddTime(Convert.ToByte(strTimes[0]), Convert.ToByte(strTimes[1]), Convert.ToByte(strSeconds[0]), Convert.ToUInt16(strSeconds[1]));
                        break;
                    case "DateTime":
                        strValues = strValue.Split(' ');
                        strTimes = strValues[1].Split(':');
                        strSeconds = strTimes[2].Split('.');
                        B2BApi.inMsgAddDateTime(Convert.ToUInt16(strValues[0].Split('/')[0]), Convert.ToByte(strValues[0].Split('/')[1]), Convert.ToByte(strValues[0].Split('/')[2]),
                                                Convert.ToByte(strTimes[0]), Convert.ToByte(strTimes[1]), Convert.ToByte(strSeconds[0]), Convert.ToUInt16(strSeconds[1]));
                        break;
                    case "string":
                        B2BApi.inMsgAddStr(strValue, iLength);
                        break;
                }
            }
            catch (Exception ex)
            {
                return ex.Message + "," + ex.StackTrace;
            }
            return "";
        }

        public string ProcessOutput(Dictionary<string, string> dicOutput, string[] strTypes, int[] iLengthes, string[] strNames)
        {
            string strReturnValue;
            try
            {
                for (int i = 0; i < strTypes.Length; i++)
                {
                    strReturnValue = ProcessOutput(strTypes[i], iLengthes[i]);
                    dicOutput.Add(strNames[i], strReturnValue);
                }
            }
            catch (Exception ex)
            {
                return ex.Message + "," + ex.StackTrace;
            }
            return "";
        }

        public string ProcessOutput(string strType, int iLength)
        {
            byte bValue = new byte();
            short sValue = (short)0;
            int iValue = 0;
            long lValue = 0;
            string strValue = "";
            string strReturnValue = "";

            try
            {
                switch (strType)
                {
                    case "short":
                        B2BApi.outMsgGetsmi(ref sValue);
                        strReturnValue = sValue.ToString();
                        break;

                    case "byte":
                        B2BApi.outMsgGetByte(ref bValue);
                        strReturnValue = bValue.ToString();
                        break;

                    case "int":
                        B2BApi.outMsgGetLong(ref iValue);
                        strReturnValue = iValue.ToString();
                        break;

                    case "long":
                        B2BApi.outMsgGetLongLong(ref lValue);
                        strReturnValue = lValue.ToString();
                        break;

                    case "Date":
                        B2BApi.outMsgGetDate(ref strValue);
                        strReturnValue = strValue;
                        break;

                    case "Time":
                        B2BApi.outMsgGetTime(ref strValue);
                        strReturnValue = strValue;
                        break;

                    case "DateTime":
                        B2BApi.outMsgGetDateTime(ref strValue);
                        strReturnValue = strValue;
                        break;

                    case "string":
                        B2BApi.outMsgGetStr(ref strValue, iLength);
                        strReturnValue = Util.FilterBreakChar(strValue);
                        break;
                }

                if (_lstParam != null)
                    _lstParam.Add(strType + "-" + iLength + "-" + strReturnValue);
            }
            catch (Exception ex)
            {
                return ex.Message + "," + ex.StackTrace;
            }
            return strReturnValue;
        }

        private Dictionary<string, object> ConvertMessage(int iMark, uint dwIndex, string strIndex, object oValue,
                                                         string[] strOutputParentType, int[] iOutputParentLen, string[] strOutputParentName,
                                                         string[] strOutputChildrenType, int[] iOutputChildrenLen, string[] strOutputChildrenName,
                                                         string[] strOutputGrandChildrenType, int[] iOutputGrandChildrenLen, string[] strOutputGrandChildrenName,
                                                         PolarisStructure structure)
        {
            Dictionary<string, object> dicReturn = new Dictionary<string, object>();
            Dictionary<string, object> dicChildren;
            Dictionary<string, object> dicGrandChiildren = null;

            byte[] bValues = null;
            string strValue;
            string[] strSwitchNames = null;
            string[] strSwitchTypes = null;
            int[] iSwitchLens = null;

            try
            {

                if ((iMark == 0) || (oValue.GetType() == typeof(string)))
                {
                    dicReturn.Add("ReturnText", (string)oValue);
                    B2BApi.outMsgClear();
                    return dicReturn;
                }
                else
                {
                    bValues = (byte[])oValue;
                }

                int intCheck = B2BApi.outMsgLoad(bValues); //將資料載入元件
                if (intCheck == 1) //0:失敗 1:成功
                {
//                    ClearParam();
                    //依元件規格文件依序解出內容值
                    strSwitchNames = null;
                    strSwitchTypes = null;
                    iSwitchLens = null;

                    for (int i = 0; i < strOutputParentType.Length; i++)
                    {
                        
                        
                        strValue = ProcessOutput(strOutputParentType[i], iOutputParentLen[i]);
                        AddValue(dicReturn, strOutputParentName[i], strValue);
                        if (!structure.IsSwitchField(PolarisStructure.OUTPUT_PARENT, strOutputParentName[i]))
                            continue;

                        strSwitchNames = structure.GetSwitchName(PolarisStructure.OUTPUT_PARENT, strOutputParentName[i], strValue);
                        strSwitchTypes = structure.GetSwitchType(PolarisStructure.OUTPUT_PARENT, strOutputParentName[i], strValue);
                        iSwitchLens = structure.GetSwitchLen(PolarisStructure.OUTPUT_PARENT, strOutputParentName[i], strValue);

                        for (int j = 0; j < strSwitchNames.Length; j++)
                        {
                            strValue = ProcessOutput(strSwitchTypes[j], iSwitchLens[j]);
                            AddValue(dicReturn, strSwitchNames[j], strValue);
                        }
                    }

                    dicReturn.Add("Header", GenerateHeader(strOutputParentName, strSwitchNames == null ? new string[0] : strSwitchNames));

                    if (strOutputChildrenName != null)
                    {
                        strSwitchNames = null;
                        strSwitchTypes = null;
                        iSwitchLens = null;

                        for (int i = 0; i < int.Parse(dicReturn["RecordCount"].ToString()); i++)
                        {
                            dicChildren = new Dictionary<string, object>();
                            for (int j = 0; j < strOutputChildrenType.Length; j++)
                            {
                                strValue = ProcessOutput(strOutputChildrenType[j], iOutputChildrenLen[j]);
                                AddValue(dicChildren, strOutputChildrenName[j], strValue);

                                if (!structure.IsSwitchField(PolarisStructure.OUTPUT_CHILDREN, strOutputChildrenName[j]))
                                    continue;

                                strSwitchNames = structure.GetSwitchName(PolarisStructure.OUTPUT_CHILDREN, strOutputChildrenName[j], strValue);
                                strSwitchTypes = structure.GetSwitchType(PolarisStructure.OUTPUT_CHILDREN, strOutputChildrenName[j], strValue);
                                iSwitchLens = structure.GetSwitchLen(PolarisStructure.OUTPUT_CHILDREN, strOutputChildrenName[j], strValue);

                                for (int k = 0; k < strSwitchNames.Length; k++)
                                {
                                    strValue = ProcessOutput(strSwitchTypes[k], iSwitchLens[k]);
                                    AddValue(dicChildren, strSwitchNames[k], strValue);
                                }
                            }
                            dicReturn.Add("Children" + i, dicChildren);
                            dicReturn.Add("ChildrenHeader" + i, GenerateHeader(strOutputChildrenName, strSwitchNames == null ? new string[0] : strSwitchNames));

                            if (strOutputGrandChildrenName != null)
                            {
                                strSwitchNames = null;
                                strSwitchTypes = null;
                                iSwitchLens = null;
                                for (int k = 0; k < int.Parse(dicChildren["DataCount"].ToString()); k++)
                                {
                                    dicGrandChiildren = new Dictionary<string, object>();
                                    for (int l = 0; l < strOutputGrandChildrenType.Length; l++)
                                    {
                                        strValue = ProcessOutput(strOutputGrandChildrenType[l], iOutputGrandChildrenLen[l]);
                                        AddValue(dicGrandChiildren, strOutputGrandChildrenName[l], strValue);

                                        if (!structure.IsSwitchField(PolarisStructure.OUTPUT_GRAND_CHILDREN, strOutputGrandChildrenName[l]))
                                            continue;

                                        strSwitchNames = structure.GetSwitchName(PolarisStructure.OUTPUT_GRAND_CHILDREN, strOutputGrandChildrenName[l], strValue);
                                        strSwitchTypes = structure.GetSwitchType(PolarisStructure.OUTPUT_GRAND_CHILDREN, strOutputGrandChildrenName[l], strValue);
                                        iSwitchLens = structure.GetSwitchLen(PolarisStructure.OUTPUT_GRAND_CHILDREN, strOutputGrandChildrenName[l], strValue);

                                        for (int m = 0; m < strSwitchNames.Length; m++)
                                        {
                                            strValue = ProcessOutput(strSwitchTypes[m], iSwitchLens[m]);
                                            AddValue(dicChildren, strSwitchNames[m], strValue);
                                        }
                                    }
                                    dicChildren.Add("GrandChildren" + k, dicGrandChiildren);
                                    dicChildren.Add("GrandChildrenHeader" + k, GenerateHeader(strOutputGrandChildrenName, strSwitchNames == null ? new string[0] : strSwitchNames));
                                }
                            }
                        }
                    }
//                    WriteLog(_lstParam);
                }
                B2BApi.outMsgClear();
            }
            catch (Exception ex)
            {
                dicReturn.Add("Exception", ex.Message + "," + ex.StackTrace);
            }
            return dicReturn;
        }

        void objB2BApi_OnResponse(int iMark, uint dwIndex, string strIndex, object Handle, object aryValue)
        {
            string strResult = "";
            string strValue = "";
            string[] strAdvisory = null;
            Dictionary<string, object> dicChild;
            PolarisStructure polarisStructure;
            string strMessageHexId;

            try
            {
                switch (iMark)
                {
                    case SYSTEM_RESP: //系統回應
                        strResult = Convert.ToString(aryValue);
                        switch (dwIndex)
                        {
                            case CONNECTED:
                                _timer.Interval = 1000;
                                _timer.Enabled = true;
                                _timer.Start();
                                IsConnected = true;
                                //strResult = SUCCESS_RETURN_MESSAGE;
                                break;
                            case DISCONNECTED:
                                IsConnected = false;
                                break;
                            case NOT_CONNECTED:                                
                                IsConnected = false;
                                break;
                            default:
                                IsConnected = false;
                                break;
                        }
                        
                        _dicReturn = new Dictionary<string, object>();
                        _dicReturn.Add(RETURN_MESSAGE, strResult);
                        break;

                    case RQRP_RESP: //代表為RQ/RP 所回應的
                    case SUBSCRIPE_RESP: //訂閱所回應
                        if (dwIndex == NOT_LOGIN)
                        {
                            _dicReturn = new Dictionary<string, object>();
                            _dicReturn.Add(RETURN_MESSAGE, Convert.ToString(aryValue));
                            break;
                        }

                        strIndex = strIndex == null ? dwIndex.ToString() : strIndex;

                        if (_dicStructure.ContainsKey(strIndex) == false)
                        {
                            _dicReturn = new Dictionary<string, object>();
                            _dicReturn.Add(RETURN_MESSAGE, "該ID(" + strIndex + ")的訊息結構不存在, " + Convert.ToString(aryValue));
                            break;
                        }

                        polarisStructure = _dicStructure[strIndex];
                        _dicReturn = ConvertMessage(iMark, dwIndex, strIndex, aryValue,
                                                    polarisStructure.GetTypes(PolarisStructure.OUTPUT_PARENT), 
                                                    polarisStructure.GetLens(PolarisStructure.OUTPUT_PARENT), 
                                                    polarisStructure.GetNames(PolarisStructure.OUTPUT_PARENT),
                                                    polarisStructure.GetTypes(PolarisStructure.OUTPUT_CHILDREN), 
                                                    polarisStructure.GetLens(PolarisStructure.OUTPUT_CHILDREN), 
                                                    polarisStructure.GetNames(PolarisStructure.OUTPUT_CHILDREN),
                                                    polarisStructure.GetTypes(PolarisStructure.OUTPUT_GRAND_CHILDREN),
                                                    polarisStructure.GetLens(PolarisStructure.OUTPUT_GRAND_CHILDREN),
                                                    polarisStructure.GetNames(PolarisStructure.OUTPUT_GRAND_CHILDREN),
                                                    polarisStructure);
                        if (polarisStructure.ClientName != null)
                        {
                            if (_dicReturn.ContainsKey(polarisStructure.ClientName))
                                _dicReturn["name"] = polarisStructure.ClientName;
                            else
                                _dicReturn.Add("name", polarisStructure.ClientName);
                        }
                        _dicReturn.Add(RETURN_MESSAGE, SUCCESS_RETURN_MESSAGE);
                        break;

                    default:
                        strResult = Convert.ToString(aryValue);
                        _dicReturn = new Dictionary<string, object>();
                        _dicReturn.Add(RETURN_MESSAGE, strResult);
                        break;
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                try
                {
                    _objB2BApi.OnResponse -= _eventHandle;
                }
                catch { }
                finally
                {
                    _eventHandle = null;
                }
            }
            if (_messageEvent != null)
                _messageEvent(_dicReturn);
        }

        void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            ((System.Timers.Timer)sender).Stop();
            ((System.Timers.Timer)sender).Enabled = false;
            if (IsAutoLogin)
                Login();
        }

        public void MessageSend(string strFunctionCode, Dictionary<string, object> dicValue)
        {
            try
            {
                PolarisStructure polarisStructure;
                if ((polarisStructure = GetMessageStructure(strFunctionCode)) == null)
                    return;
                
                string[] strNames;
                string[] strTypes;
                int[] iLens;
                int iRowCount = 0;
                Dictionary<string, string> dicChildren;

                if ((strNames = polarisStructure.GetNames(PolarisStructure.INPUT_PARENT)) != null)
                {
                    strTypes = polarisStructure.GetTypes(PolarisStructure.INPUT_PARENT);
                    iLens = polarisStructure.GetLens(PolarisStructure.INPUT_PARENT);

                    for (int i = 0; i < strNames.Length; i++)
                    {
                        ProcessInput(strTypes[i], iLens[i], (string)dicValue[strNames[i]]);
                        if(strNames[i] == "Count")
                            iRowCount = int.Parse((string)dicValue[strNames[i]]);
                    }
                }

                if ((strNames = polarisStructure.GetNames(PolarisStructure.INPUT_CHILDREN)) != null)
                {
                    strTypes = polarisStructure.GetTypes(PolarisStructure.INPUT_CHILDREN);
                    iLens = polarisStructure.GetLens(PolarisStructure.INPUT_CHILDREN);

                    for (int i = 0; i < iRowCount; i++)
                    {
                        dicChildren = (Dictionary<string, string>)dicValue["Children" + i];
                        for (int j = 0; j < strNames.Length; j++)
                            ProcessInput(strTypes[j], iLens[j], (string)dicChildren[strNames[j]]);
                    }
                }

                B2BApi.inMsgSend(strFunctionCode, (uint)0, (_accountInfo.AccountType + _accountInfo.AccountNo).Trim(), true);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public object InitProgram(AAA.Meta.Trade.Data.AccountInfo accountInfo)
        {
            _accountInfo = accountInfo;
            B2BApi.Open();
            WaitTillCompleted();
            //_isConnected = (_dicReturn.ContainsKey("ReturnMessage") ? _dicReturn["ReturnMessage"].ToString() == "Is Connected!!" : false);
            return _isConnected ? "Success" : "Fail";
        }

        private void WaitTillCompleted()
        {
            try
            {
                int iWaitCount = 0;
                while ((_eventHandle != null) && (iWaitCount < MaxWaitCount))
                {
                    Application.DoEvents();
                    Thread.Sleep(50);
                    iWaitCount++;
                }
                if (iWaitCount > MaxWaitCount)
                {
                    _dicReturn = new Dictionary<string, object>();
                    _dicReturn.Add(RETURN_MESSAGE, "Exceed max wait count!!");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void OnMessage(MessageEvent messageEvent)
        {
            _messageEvent += messageEvent;
        }

        public object Logout()
        {
            try
            {
                B2BApi.Logout((_accountInfo.AccountType + _accountInfo.AccountNo).Trim());
                WaitTillCompleted();
                B2BApi.Close();
                WaitTillCompleted();
                _isConnected = false;
                return "Success";
            }
            catch (Exception ex)
            {
                Marshal.ReleaseComObject(_objB2BApi);
            }
            finally
            {
                Marshal.ReleaseComObject(_objB2BApi);
            }
            return "Fail";
        }

        public object Login()
        {
            int iLoginCheck = 0;
            try
            {
                string strLoginAccount = Util.FillSpace(_accountInfo.AccountType + _accountInfo.AccountNo, 22);
                iLoginCheck = B2BApi.Login((int)0, strLoginAccount, _accountInfo.Password);
                WaitTillCompleted();
            }
            catch (Exception ex)
            {
                throw;
            }

            return ((iLoginCheck == 1) && _dicReturn.ContainsKey("MsgCode"))
                        ?   _dicReturn["MsgCode"] != "0001"
                                ?   "Fail\n" + _dicReturn["MsgCode"] + "," + _dicReturn["MsgContent"]
                                :   "Success\n" + _dicReturn["MsgCode"] + "," + _dicReturn["MsgContent"] + "\n" +
                                    ((Dictionary<string, object>)_dicReturn["Children0"])["Account"] + "," +
                                    ((Dictionary<string, object>)_dicReturn["Children0"])["Name"] + "," +
                                    ((Dictionary<string, object>)_dicReturn["Children0"])["InvestorId"]
                        : "Fail" + "\n" + _dicReturn["ReturnMessage"];
        }



    }
}
