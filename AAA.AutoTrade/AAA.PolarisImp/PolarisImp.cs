﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Trade;
using System.Threading;
using System.Windows.Forms;
using AAA.Base.Util;
using AAA.Meta.Trade;

namespace AAA.Polaris
{
    public delegate void MessageReceiveEventHandler(int iMark, uint dwIndex, string strIndex, object oValue);   
    
    public class PolarisImp : AbstractTrade, IDisposable
    {
        private static readonly string MONTH = "ABCDEFGHIJKLMNOPQRSTUVWX";

        private const int SYSTEM_RESP = 0;
        private const int RQRP_RESP = 1;
        private const int SUBSCRIPE_RESP = 2;

        private const string INTEGRATE_LOGIN = "0";
        private const string SUB_ACCOUNT_LOGIN = "1";
        private const string INVENTORY = "1467140B";
        private const string EQUITY = "1468140C";
        private const string DEAL = "1465140C";
        private const string SEND = "1E641416";
        private const string REPORT = "1465140B";

        private const string GET_POSITION_REPORT = "20.103.20.11";
        private const string TODAY_EQUITY = "20.104.20.12";
        private const string DEAL_REPORT = "20.101.20.12";
        private const string SEND_ORDER = "30.100.20.22";
        private const string ORDER_REPORT = "20.101.20.11";

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

        private static string[] REPORT_OUTPUT_CHILDREN_TYPE = { "string",  "Date", "byte", "string", "string", "int", "int", "string", "string", "int", "int", "string", "string", "string", "string", "int", "int", "int", "int", "Date", "Time", "string", "string", "string", "string", "short", "long", "long", "long", "string"};
        private static int[] REPORT_OUTPUT_CHILDREN_LEN = { 22, 4, 1, 20, 7, 4, 4, 1, 7, 4, 4, 1, 1, 1, 10, 4, 4, 4, 4, 4, 5, 10, 78, 5, 1, 2, 8, 8, 8, 1 };
        private static string[] REPORT_OUTPUT_CHILDREN_NAME = { "Account", "TradeDate", "MarketNo", "MarketName", "CommodityID1", "SettlementMonth1", "StrikePrice1", "BuySellKind1", "CommodityID2", "SettlementMonth2", "StrikePrice2", "BuySellKind2", "OpenOffsetKind", "OrderCondition", "OrderPrice", "OrderQty", "AfterQty", "OkQty", "Status", "AcceptDate", "AcceptTime", "ErrorNo", "ErrorMessage", "OrderNo", "ProductType", "Seller", "TotalMatFee", "TotalMatExchTax", "TotalMatPremium", "DayTradeID" };

        //委託回報-送單
        private static string[] SEND_ORDER_OUTPUT_PARENT_TYPE = { "string", "string", "int" };
        private static int[] SEND_ORDER_OUTPUT_PARENT_LEN = { 4, 50, 4 };
        private static string[] SEND_ORDER_OUTPUT_PARENT_NAME = { "MsgCode", "MsgContent", "RecordCount" };

        private static string[] SEND_ORDER_OUTPUT_CHILDREN_TYPE = { "int", "short", "string", "Date", "string", "string", "string" };
        private static int[] SEND_ORDER_OUTPUT_CHILDREN_LEN = { 4, 2, 5, 4, 1, 3, 74 };
        private static string[] SEND_ORDER_OUTPUT_CHILDREN_NAME = { "Identify", "ReplyCode", "OrderNo", "TradeDate", "ErrKind", "ErrNo", "Advisory" };

        public event MessageEvent _messageEvent;

        private PolarisB2BAPI.PolaisB2BTrader _objB2BApi;
        private PolarisB2BAPI.IPolaisB2BTraderEvents_OnResponseEventHandler _eventHandle = null;

        private Dictionary<string, object> _dicReturn;

        private bool _isConnected;

        private string _strSellerNo = "0";

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

        string ProcessInput(Dictionary<string, string> dicInput, string[] strTypes, int[] iLengthes, string[] strNames)
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

        string ProcessInput(string strType, int iLength, string strValue)
        {
            try
            {
                string[] strTimes;
                string[] strSeconds;
                string[] strValues;

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

        string ProcessOutput(Dictionary<string, string> dicOutput, string[] strTypes, int[] iLengthes, string[] strNames)
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

        string ProcessOutput(string strType, int iLength)
        {
            byte bValue = new byte();
            short sValue = (short)0;
            int iValue = 0;
            long lValue = 0;
            string strValue = "";

            try
            {
                switch (strType)
                {
                    case "short":
                        B2BApi.outMsgGetsmi(ref sValue);
                        return sValue.ToString();

                    case "byte":
                        B2BApi.outMsgGetByte(ref bValue);
                        return bValue.ToString();

                    case "int":
                        B2BApi.outMsgGetLong(ref iValue);
                        return iValue.ToString();

                    case "long":
                        B2BApi.outMsgGetLongLong(ref lValue);
                        return lValue.ToString();

                    case "Date":
                        B2BApi.outMsgGetDate(ref strValue);
                        return strValue;

                    case "Time":
                        B2BApi.outMsgGetTime(ref strValue);
                        return strValue;

                    case "DateTime":
                        B2BApi.outMsgGetDateTime(ref strValue);
                        return strValue;

                    case "string":
                        B2BApi.outMsgGetStr(ref strValue, iLength);
                        return Util.FilterBreakChar(strValue);
                }
            }
            catch (Exception ex)
            {
                return ex.Message + "," + ex.StackTrace;
            }
            return "";
        }

        string GenerateHeader(string[] strFields)
        {
            string strHeader = "";
            try
            {
                for (int i = 0; i < strFields.Length; i++)
                    strHeader += "," + strFields[i];
            }
            catch (Exception ex)
            {
                return ex.Message + "," + ex.StackTrace;
            }
            return (strHeader.Length > 0) ? strHeader.Substring(1) : "";
        }

        private Dictionary<string, object> ConvertMessage(int iMark, uint dwIndex, string strIndex, object oValue,
                                                         string[] strOutputParentType, int[] iOutputParentLen, string[] strOutputParentName,
                                                         string[] strOutputChildrenType, int[] iOutputChildrenLen, string[] strOutputChildrenName,
                                                         string[] strOutputGrandChildrenType, int[] iOutputGrandChildrenLen, string[] strOutputGrandChildrenName)
        {
            Dictionary<string, object> dicReturn = new Dictionary<string, object>();
            Dictionary<string, object> dicChildren;
            byte[] bValues = null;
            string strValue;

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
                    //依元件規格文件依序解出內容值
                    for (int i = 0; i < strOutputParentType.Length; i++)
                    {
                        strValue = ProcessOutput(strOutputParentType[i], iOutputParentLen[i]);
                        AddValue(dicReturn, strOutputParentName[i], strValue);
                    }

                    dicReturn.Add("Header", GenerateHeader(strOutputParentName));

                    if (strOutputChildrenName != null)
                    {
                        for (int i = 0; i < int.Parse(dicReturn["RecordCount"].ToString()); i++)
                        {
                            dicChildren = new Dictionary<string, object>();
                            for (int j = 0; j < strOutputChildrenType.Length; j++)
                            {
                                strValue = ProcessOutput(strOutputChildrenType[j], iOutputChildrenLen[j]);
                                AddValue(dicChildren, strOutputChildrenName[j], strValue);
                            }
                            dicReturn.Add("Children" + i, dicChildren);
                        }
                    }
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
            
            try
            {
                switch (iMark)
                {
                    case SYSTEM_RESP: //系統回應
                        strResult = Convert.ToString(aryValue);
                        _dicReturn = new Dictionary<string, object>();
                        _dicReturn.Add("ReturnMessage", strResult);
                        break;
                    case RQRP_RESP: //代表為RQ/RP 所回應的
                        switch (Convert.ToString(dwIndex, 16).ToUpper())
                        {
                            case INTEGRATE_LOGIN: //總帳登入
                                //strResult = funAPILogin_Out((byte[])aryValue);
                                _dicReturn = ConvertMessage(iMark, dwIndex, strIndex, aryValue,
                                                             LOGIN_OUTPUT_PARENT_TYPE, LOGIN_OUTPUT_PARENT_LEN, LOGIN_OUTPUT_PARENT_NAME,
                                                             LOGIN_OUTPUT_CHILDREN_TYPE, LOGIN_OUTPUT_CHILDREN_LEN, LOGIN_OUTPUT_CHILDREN_NAME,
                                                             null, null, null);
                                _strSellerNo = (string)_dicReturn["SellerNo"];
                                break;
                            case INVENTORY: //期貨庫存明細
                                _dicReturn = ConvertMessage(iMark, dwIndex, strIndex, aryValue,
                                                             INVENTORY_OUTPUT_PARENT_TYPE, INVENTORY_OUTPUT_PARENT_LEN, INVENTORY_OUTPUT_PARENT_NAME,
                                                             INVENTORY_OUTPUT_CHILDREN_TYPE, INVENTORY_OUTPUT_CHILDREN_LEN, INVENTORY_OUTPUT_CHILDREN_NAME,
                                                             null, null, null);
                                _dicReturn.Add("name", "QueryTodayPosition");
                                break;
                            case EQUITY: //今日權益數
                                _dicReturn = ConvertMessage(iMark, dwIndex, strIndex, aryValue,
                                                             EQUITY_OUTPUT_PARENT_TYPE, EQUITY_OUTPUT_PARENT_LEN, EQUITY_OUTPUT_PARENT_NAME,
                                                             null, null, null,
                                                             null, null, null);
                                _dicReturn.Add("name", "QueryTodayEquity");
                                break;

                            case DEAL: //成交回報
                                _dicReturn = ConvertMessage(iMark, dwIndex, strIndex, aryValue,
                                                             DEAL_OUTPUT_PARENT_TYPE, DEAL_OUTPUT_PARENT_LEN, DEAL_OUTPUT_PARENT_NAME,
                                                             DEAL_OUTPUT_CHILDREN_TYPE, DEAL_OUTPUT_CHILDREN_LEN, DEAL_OUTPUT_CHILDREN_NAME,
                                                             null, null, null);
                                _dicReturn.Add("name", "QueryDealReport");
                                break;

                            case REPORT: //委託回報-查詢
                                _dicReturn = ConvertMessage(iMark, dwIndex, strIndex, aryValue,
                                                             REPORT_OUTPUT_PARENT_TYPE, REPORT_OUTPUT_PARENT_LEN, REPORT_OUTPUT_PARENT_NAME,
                                                             REPORT_OUTPUT_CHILDREN_TYPE, REPORT_OUTPUT_CHILDREN_LEN, REPORT_OUTPUT_CHILDREN_NAME,
                                                             null, null, null);
                                _dicReturn.Add("name", "QueryOrderListByDiff");
                                break;

                            case SEND: //委託回報-即時
                                _dicReturn = ConvertMessage(iMark, dwIndex, strIndex, aryValue,
                                                             SEND_ORDER_OUTPUT_PARENT_TYPE, SEND_ORDER_OUTPUT_PARENT_LEN, SEND_ORDER_OUTPUT_PARENT_NAME,
                                                             SEND_ORDER_OUTPUT_CHILDREN_TYPE, SEND_ORDER_OUTPUT_CHILDREN_LEN, SEND_ORDER_OUTPUT_CHILDREN_NAME,
                                                             null, null, null);
                                _dicReturn.Add("name", "SendOrder");
                                break;
/*
                            case "1"://分戶登入
                                strResult = funAPISubLogin_Out((byte[])aryValue);
                                break;
                            case "A00000D"://即時回報
                                strResult = funGetRealReport_Out((byte[])aryValue);
                                break;
                            case "A00000E"://即時回報彙總
                                strResult = funGetRealReportMerge_Out((byte[])aryValue);
                                break;
                            case "147C0A0B"://現貨/期貨分戶設定
                            case "147C140D":
                                strResult = funSubAccountSet_Out((byte[])aryValue);
                                break;
                            case "1E640A0A": //現貨下單
                                strResult = funStkOrder_Out((byte[])aryValue);
                                break;
                            case "1E641416": //期貨下單
                            case "1E64140A": //期貨下單
                                strResult = funFutOrder_Out((byte[])aryValue);
                                break;
                            case "32000010"://WatchListAll
                                strResult = funWatchListAll_Out((byte[])aryValue);
                                break;
 */ 
                            default:  //不在表列中的直接呈現訊息
                                strResult = strIndex + " " + Convert.ToString(aryValue);
                                break;
                        }
                        break;
                    case SUBSCRIPE_RESP: //訂閱所回應
                        switch (Convert.ToString(dwIndex, 16).ToUpper())
                        {
/*
                            case "C80A0A0A": //即時回報
                                strResult = funRealReport_Out((byte[])aryValue);
                                break;
                            case "C80A0A0B"://即時回報彙總
                                strResult = funRealReportMerge_Out((byte[])aryValue);
                                break;
                            case "D20A460B"://WatchList
                                strResult = funRealPrice_Out((byte[])aryValue);
                                break;
 */ 
                            default:
                                strResult = Convert.ToString(aryValue);
                                break;
                        }

                        break;
                    default:
                        strResult = Convert.ToString(aryValue);
                        _dicReturn = new Dictionary<string, object>();
                        _dicReturn.Add("ReturnMessage", strResult);
                        break;
                }

            }
            catch (Exception ex)
            {
                throw ex;
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

        public override object CA()
        {
            return "Success";
        }

        public override object CancelOrder(AAA.Meta.Trade.Data.OrderInfo orderInfo)
        {
            string strMessage = "";
            string[] strParams;
            string[] strReturns;
            string strSymbolType = "";
            string strCallPut = "";
            int iMultipler = 1000;
            try
            {
                // ParentStruct_In
                ProcessInput("int", 4, "1");    // 下單筆數

                // ChildStruct_In
                ProcessInput("int", 4, "001");  // 識別碼
                ProcessInput("string", 22, (_accountInfo.AccountType + _accountInfo.AccountNo).Trim()); // 期貨帳號
                ProcessInput("short", 2, "04"); // 功能 00:委託單 04:取消 05:改量
                ProcessInput("string", 6, strSymbolType);   // 商品名稱1
                ProcessInput("string", 1, strCallPut);  // 買賣權1
                ProcessInput("int", 4, "0");  // 商品年月1
                ProcessInput("int", 4, "0");   // 履約價1
                ProcessInput("int", 4, "0"); // 委託價1
                ProcessInput("short", 2, "0");   // 委託口數1
                ProcessInput("string", 1, "");  // 買賣別1

                ProcessInput("string", 6, "");   // 商品名稱2
                ProcessInput("string", 1, "");  // 買賣權2
                ProcessInput("int", 4, "0");  // 商品年月2
                ProcessInput("int", 4, "0");   // 履約價2                
                ProcessInput("short", 2, "0");   // 委託口數2
                ProcessInput("string", 1, "");  // 買賣別2

                ProcessInput("string", 1, " "); // 新/平倉碼
                ProcessInput("string", 1, " ");  // 當沖註記
                ProcessInput("string", 1, "1");  // 委託方式
                ProcessInput("string", 1, " ");  // 委託條件
                ProcessInput("short", 2, _strSellerNo); // 營業員代碼
                ProcessInput("string", 5, orderInfo.OrderNo);  // 委託書編號
                ProcessInput("Date", 4, orderInfo.TSSignalTime.Split(' ')[0]); // 交易日期
                ProcessInput("string", 10, ""); // BasketNo
                ProcessInput("string", 2, "0");

                MessageSend(SEND_ORDER);

                WaitTillCompleted();
                return "Success";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return "Fail";
        }

        private void MessageSend(string strFunctionCode)
        {
            try
            {
                B2BApi.inMsgSend(strFunctionCode, (uint)0, (_accountInfo.AccountType + _accountInfo.AccountNo).Trim(), true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override object GetDealReport(string strStartDate, string strEndDate)
        {
            try
            {
                B2BApi.inMsgAddLong(1);                           //填入筆數
                B2BApi.inMsgAddStr((_accountInfo.AccountType + _accountInfo.AccountNo).Trim(), 22); //填入查詢帳號                

                MessageSend(DEAL_REPORT);
                WaitTillCompleted();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return "Success";

        }

        public override object GetOrderReport(string strStartDate, string strEndDate)
        {
            try
            {
                B2BApi.inMsgAddLong(1);                                                             //填入筆數
                B2BApi.inMsgAddStr("Y", 1);                                                         //是否列出取消單
                B2BApi.inMsgAddStr((_accountInfo.AccountType + _accountInfo.AccountNo).Trim(), 22); //填入查詢帳號                

                MessageSend(ORDER_REPORT);
                WaitTillCompleted();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return "Success";
        }

        public override object GetOrderStatus(AAA.Meta.Trade.Data.OrderInfo orderInfo)
        {
            return "";
        }

        public override object GetPositionReport()
        {
            try
            {
                B2BApi.inMsgAddLong(1);                           //填入筆數
                B2BApi.inMsgAddStr((_accountInfo.AccountType + _accountInfo.AccountNo).Trim(), 22); //填入查詢帳號
                MessageSend(GET_POSITION_REPORT);
                WaitTillCompleted();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return "Success";
        }

        public override object GetTodayEquity()
        {
            try
            {
                B2BApi.inMsgAddStr((_accountInfo.AccountType + _accountInfo.AccountNo).Trim(), 22); //填入查詢帳號
                B2BApi.inMsgAddStr("2", 1);  //填入幣別 1:基幣 2:台幣 3:美金

                MessageSend(TODAY_EQUITY);
                WaitTillCompleted();               
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return "Success";
        }

        public override object InitProgram(AAA.Meta.Trade.Data.AccountInfo accountInfo)
        {
            _accountInfo = accountInfo;
            B2BApi.Open();
            _isConnected = true;
            return "Success";
        }

        public override bool IsConnected()
        {
            return _isConnected;   
        }

        private void WaitTillCompleted()
        {
            try
            {
                while (_eventHandle != null)
                {
                    Application.DoEvents();
                    Thread.Sleep(10);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override object Login()
        {
            try
            {               
                string strLoginAccount = Util.FillSpace(_accountInfo.AccountType + _accountInfo.AccountNo, 22);
                int iLoginCheckt = B2BApi.Login((int)0, strLoginAccount, _accountInfo.Password);
                WaitTillCompleted();
//                AAA.DesignPattern.Singleton.SystemParameter.Parameter["LoginAccounts"] = strLoginAccount;
/*
                string strLoginAccount = Util.FillSpace(dicInput["AccountType"] + dicInput["Account"], 22);

                if (SystemVariables.Instance().GetVariable("LoginAccounts") == null)
                {
                    SystemVariables.Instance().SetVariable("LoginAccounts", new List<string>());
                }

                if (((List<string>)SystemVariables.Instance().GetVariable("LoginAccounts")).IndexOf(strLoginAccount) < 0)
                    ((List<string>)SystemVariables.Instance().GetVariable("LoginAccounts")).Add(strLoginAccount);
*/
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return _dicReturn["MsgCode"] + "," + _dicReturn["MsgContent"] + "\n" +
                   ((Dictionary<string, object>)_dicReturn["Children0"])["Account"] + "," + 
                   ((Dictionary<string, object>)_dicReturn["Children0"])["Name"] + "," + 
                   ((Dictionary<string, object>)_dicReturn["Children0"])["InvestorId"];
        }

        public override object Logout()
        {
            try
            {
                B2BApi.Logout((_accountInfo.AccountType + _accountInfo.AccountNo).Trim());
                B2BApi.Close();
                WaitTillCompleted();
                _isConnected = false;
                return "Success";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return "Fail";
        }

        public override void OnMessage(MessageEvent messageEvent)
        {
            _messageEvent += messageEvent;
        }

        public override string QuerySymbolCode(string strSymbolType, string strStrikePrice, string strPubOrCall, string strYear, string strMonth)
        {
            return SymbolCodeHelper.QuerySymbolCode(strSymbolType, strStrikePrice, strPubOrCall, strYear, strMonth);
/*
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
 */ 
        }

        public override object SendOrder(AAA.Meta.Trade.Data.OrderInfo orderInfo)
        {
            string strMessage = "";
            string[] strParams;
            string[] strReturns;
            string strSymbolType = "";
            string strCallPut = "";
            int iMultipler = 1000;
            try
            {
                if (orderInfo.SymbolCode.StartsWith("TXO"))
                {
                    strSymbolType = "TXO";
                    strCallPut = orderInfo.PutOrCall.Substring(0, 1);
                }

                if (orderInfo.SymbolCode.StartsWith("MXF"))
                {
                    strSymbolType = "FIMTX";
                    strCallPut = "";
                }

                if (orderInfo.SymbolCode.StartsWith("TXF"))
                {
                    strSymbolType = "FITX";
                    strCallPut = "";
                }

                // ParentStruct_In
                ProcessInput("int", 4, "1");    // 下單筆數

                // ChildStruct_In
                ProcessInput("int", 4, "001");  // 識別碼
                ProcessInput("string", 22, (_accountInfo.AccountType + _accountInfo.AccountNo).Trim()); // 期貨帳號
                ProcessInput("short", 2, "00"); // 功能 00:委託單 04:取消 05:改量
                ProcessInput("string", 6, strSymbolType);   // 商品名稱1
                ProcessInput("string", 1, strCallPut);  // 買賣權1
                ProcessInput("int", 4, orderInfo.Year.ToString() + ((orderInfo.Month.Length == 1) ? "0" + orderInfo.Month : orderInfo.Month));  // 商品年月1
                ProcessInput("int", 4, strSymbolType == "TXO" ? (Convert.ToInt32(orderInfo.ExercisePrice) * 1000).ToString() : "0");   // 履約價1
                ProcessInput("int", 4, (Convert.ToInt32(orderInfo.FilledPrice) * iMultipler).ToString()); // 委託價1
                ProcessInput("short", 2, orderInfo.FilledVolume.ToString());   // 委託口數1
                ProcessInput("string", 1, (orderInfo.OrderType == "LE" ||
                                           orderInfo.OrderType == "SX") ? "B" : "S");  // 買賣別1

                ProcessInput("string", 6, "");   // 商品名稱2
                ProcessInput("string", 1, "");  // 買賣權2
                ProcessInput("int", 4, "0");  // 商品年月2
                ProcessInput("int", 4, "0");   // 履約價2                
                ProcessInput("short", 2, "0");   // 委託口數2
                ProcessInput("string", 1, "");  // 買賣別2

                ProcessInput("string", 1, strSymbolType == "TXO"
                                            ? orderInfo.OrderType.EndsWith("E")
                                                ?   "0"
                                                :   "1"
                                            : " "); // 新/平倉碼
                ProcessInput("string", 1, orderInfo.IntraDay ? "Y" : " ");  // 當沖註記
                ProcessInput("string", 1, orderInfo.FilledPrice == "M" ? "1" : "2");  // 委託方式
                ProcessInput("string", 1, ((orderInfo.FilledPrice == "M") || (orderInfo.FilledPrice == "0")) ? "2" : " ");  // 委託條件
                ProcessInput("short", 2, _strSellerNo); // 營業員代碼
                ProcessInput("string", 5, "");  // 委託書編號
                ProcessInput("Date", 4, orderInfo.TSSignalTime.Split(' ')[0]); // 交易日期
                ProcessInput("string", 10, ""); // BasketNo
                ProcessInput("string", 2, "0");

                MessageSend(SEND_ORDER);

                WaitTillCompleted();
                return "Success";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return "Fail";
        }

        public override object ChangeQuantity(AAA.Meta.Trade.Data.OrderInfo orderInfo)
        {
            string strMessage = "";
            string[] strParams;
            string[] strReturns;
            string strSymbolType = "";
            string strCallPut = "";
            int iMultipler = 1000;
            try
            {
                if (orderInfo.SymbolCode.StartsWith("TXO"))
                {
                    strSymbolType = "TXO";
                    strCallPut = orderInfo.PutOrCall.Substring(0, 1);
                }

                if (orderInfo.SymbolCode.StartsWith("MXF"))
                {
                    strSymbolType = "FIMTX";
                    strCallPut = "";
                }

                if (orderInfo.SymbolCode.StartsWith("TXF"))
                {
                    strSymbolType = "FITX";
                    strCallPut = "";
                }

                // ParentStruct_In
                ProcessInput("int", 4, "1");    // 下單筆數

                // ChildStruct_In
                ProcessInput("int", 4, "001");  // 識別碼
                ProcessInput("string", 22, (_accountInfo.AccountType + _accountInfo.AccountNo).Trim()); // 期貨帳號
                ProcessInput("short", 2, "05"); // 功能 00:委託單 04:取消 05:改量
                ProcessInput("string", 6, strSymbolType);   // 商品名稱1
                ProcessInput("string", 1, strCallPut);  // 買賣權1
                ProcessInput("int", 4, orderInfo.Year.ToString() + ((orderInfo.Month.Length == 1) ? "0" + orderInfo.Month : orderInfo.Month));  // 商品年月1
                ProcessInput("int", 4, strSymbolType == "TXO" ? (Convert.ToInt32(orderInfo.ExercisePrice) * 1000).ToString() : "0");   // 履約價1
                ProcessInput("int", 4, (Convert.ToInt32(orderInfo.FilledPrice) * iMultipler).ToString()); // 委託價1
                ProcessInput("short", 2, orderInfo.FilledVolume.ToString());   // 委託口數1
                ProcessInput("string", 1, (orderInfo.OrderType == "LE" ||
                                           orderInfo.OrderType == "SX") ? "B" : "S");  // 買賣別1

                ProcessInput("string", 6, "");   // 商品名稱2
                ProcessInput("string", 1, "");  // 買賣權2
                ProcessInput("int", 4, "0");  // 商品年月2
                ProcessInput("int", 4, "0");   // 履約價2                
                ProcessInput("short", 2, "0");   // 委託口數2
                ProcessInput("string", 1, "");  // 買賣別2

                ProcessInput("string", 1, strSymbolType == "TXO"
                                            ? orderInfo.OrderType.EndsWith("E")
                                                ? "0"
                                                : "1"
                                            : " "); // 新/平倉碼
                ProcessInput("string", 1, orderInfo.IntraDay ? "Y" : " ");  // 當沖註記
                ProcessInput("string", 1, orderInfo.FilledPrice == "M" ? "1" : "2");  // 委託方式
                ProcessInput("string", 1, ((orderInfo.FilledPrice == "M") || (orderInfo.FilledPrice == "0")) ? "2" : " ");  // 委託條件
                ProcessInput("short", 2, _strSellerNo); // 營業員代碼
                ProcessInput("string", 5, orderInfo.OrderNo);  // 委託書編號
                ProcessInput("Date", 4, orderInfo.TSSignalTime.Split(' ')[0]); // 交易日期
                ProcessInput("string", 10, ""); // BasketNo
                ProcessInput("string", 2, "0");

                MessageSend(SEND_ORDER);

                WaitTillCompleted();
                return "Success";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return "Fail";
        }

        public override object ChangePrice(AAA.Meta.Trade.Data.OrderInfo orderInfo)
        {
            string strMessage = "";
            string[] strParams;
            string[] strReturns;
            string strSymbolType = "";
            string strCallPut = "";
            int iMultipler = 1000;
            try
            {
                if (orderInfo.SymbolCode.StartsWith("TXO"))
                {
                    strSymbolType = "TXO";
                    strCallPut = orderInfo.PutOrCall.Substring(0, 1);
                }

                if (orderInfo.SymbolCode.StartsWith("MXF"))
                {
                    strSymbolType = "FIMTX";
                    strCallPut = "";
                }

                if (orderInfo.SymbolCode.StartsWith("TXF"))
                {
                    strSymbolType = "FITX";
                    strCallPut = "";
                }

                // ParentStruct_In
                ProcessInput("int", 4, "1");    // 下單筆數

                // ChildStruct_In
                ProcessInput("int", 4, "001");  // 識別碼
                ProcessInput("string", 22, (_accountInfo.AccountType + _accountInfo.AccountNo).Trim()); // 期貨帳號
                ProcessInput("short", 2, "07"); // 功能 00:委託單 04:取消 05:改量 07:改價
                ProcessInput("string", 6, strSymbolType);   // 商品名稱1
                ProcessInput("string", 1, strCallPut);  // 買賣權1
                ProcessInput("int", 4, orderInfo.Year.ToString() + ((orderInfo.Month.Length == 1) ? "0" + orderInfo.Month : orderInfo.Month));  // 商品年月1
                ProcessInput("int", 4, strSymbolType == "TXO" ? (Convert.ToInt32(orderInfo.ExercisePrice) * 1000).ToString() : "0");   // 履約價1
                ProcessInput("int", 4, (Convert.ToInt32(orderInfo.FilledPrice) * iMultipler).ToString()); // 委託價1
                ProcessInput("short", 2, orderInfo.FilledVolume.ToString());   // 委託口數1
                ProcessInput("string", 1, (orderInfo.OrderType == "LE" ||
                                           orderInfo.OrderType == "SX") ? "B" : "S");  // 買賣別1

                ProcessInput("string", 6, "");   // 商品名稱2
                ProcessInput("string", 1, "");  // 買賣權2
                ProcessInput("int", 4, "0");  // 商品年月2
                ProcessInput("int", 4, "0");   // 履約價2                
                ProcessInput("short", 2, "0");   // 委託口數2
                ProcessInput("string", 1, "");  // 買賣別2

                ProcessInput("string", 1, strSymbolType == "TXO"
                                            ? orderInfo.OrderType.EndsWith("E")
                                                ? "0"
                                                : "1"
                                            : " "); // 新/平倉碼
                ProcessInput("string", 1, orderInfo.IntraDay ? "Y" : " ");  // 當沖註記
                ProcessInput("string", 1, orderInfo.FilledPrice == "M" ? "1" : "2");  // 委託方式
                ProcessInput("string", 1, ((orderInfo.FilledPrice == "M") || (orderInfo.FilledPrice == "0")) ? "2" : " ");  // 委託條件
                ProcessInput("short", 2, _strSellerNo); // 營業員代碼
                ProcessInput("string", 5, orderInfo.OrderNo);  // 委託書編號
                ProcessInput("Date", 4, orderInfo.TSSignalTime.Split(' ')[0]); // 交易日期
                ProcessInput("string", 10, ""); // BasketNo
                ProcessInput("string", 2, "0");

                MessageSend(SEND_ORDER);

                WaitTillCompleted();
                return "Success";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return "Fail";
        }

        public override Dictionary<string, string> SplitMessage(string strMessage, string strMessageType)
        {
            throw new NotImplementedException();
        }

        #region IDisposable Members

        public void Dispose()
        {
            
        }

        #endregion
    }
}
