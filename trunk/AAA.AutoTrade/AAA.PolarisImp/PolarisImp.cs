using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Trade;

namespace AAA.Polaris
{
    public delegate void MessageReceiveEventHandler(int iMark, uint dwIndex, string strIndex, object oValue);   
    
    public class PolarisImp : AbstractTrade, IDisposable
    {
        private const string GET_POSITION_REPORT = "20.103.20.11";
        private const string TODAY_EQUITY = "20.104.20.12";

        private const string INVENTORY_RETUTN_CODE = 
        private static string[] INVENTORY_OUTPUT_PARENT_TYPE = { "int" };
        private static int[] INVENTORY_OUTPUT_PARENT_LEN = { 4 };
        private static string[] INVENTORY_OUTPUT_PARENT_NAME = { "RecordCount" };

        private static string[] INVENTORY_OUTPUT_CHILDREN_TYPE = { "string", "string", "string", "string", "int", "long", "string", "string", "int", "int", "string", "string", "int", "int", "int", "int", "string", "string", "string", "string", "string", "string", "byte", "string", "byte", "string", "byte", "string", "byte", "string" };
        private static int[] INVENTORY_OUTPUT_CHILDREN_LEN = { 22, 1, 20, 1, 4, 8, 6, 1, 4, 4, 6, 1, 4, 4, 4, 4, 3, 1, 1, 1, 1, 1, 1, 12, 1, 12, 1, 12, 1, 12 };
        private static string[] INVENTORY_OUTPUT_CHILDREN_NAME = { "Account", "Kind", "Trid", "BS", "Qty", "Amount", "CommodityID1", "CallPut1", "SettlementMonth1", "StrikePrice1", "CommodityID2", "CallPut2", "SettlementMonth2", "StrikePrice2", "Fee", "Tax", "CurrencyType", "DayTradeID", "BS1", "BS2", "ProdKind1", "ProdKind2", "MarketNo1", "StockCode1", "MarketNo2", "StockCode2", "BelongMarketNo1", "BelongStockCode1", "BelongMarketNo2", "BelongStockCode2" };


        private static string[] EQUITY_OUTPUT_PARENT_TYPE = { "short", "string", "long", "long", "long", "long", "long", "long", "long", "long", "long", "long", "long", "long", "string", "long", "long", "string", "long", "long", "long", "long", "string", "long" };
        private static int[] EQUITY_OUTPUT_PARENT_LEN = { 2, 78, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 9, 8, 8, 9, 8, 8, 8, 8, 1, 8 };
        private static string[] EQUITY_OUTPUT_PARENT_NAME = { "ReplyCode", "Advisory", "CurrencyRate", "AccountBalance", "InOutAmt", "VarIncome", "AccountEquity", "RealizePremium", "UnRealizePremium", "InitialMargin", "MaintainMargin", "CoverIncome", "TodayTOT", "UsableMargin", "MaintainRate", "BuyOptionValue", "SellOptionValue", "FullRate", "CoverAmt", "AddMargin", "CashUsable", "NetEquityAmt", "MarginGetType", "YNetEquitAmt" };

       
        private PolarisB2BAPI.PolaisB2BTrader _objB2BApi;
        private PolarisB2BAPI.IPolaisB2BTraderEvents_OnResponseEventHandler _eventHandle = null;
        

        private bool _isConnected;

        public PolarisB2BAPI.PolaisB2BTrader B2BApi
        {
            get { return _objB2BApi; }
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


        void AddValue(Dictionary<string, string> dicData, string strKey, string strValue)
        {
            if (dicData.ContainsKey(strKey))
                dicData[strKey] += "," + strValue;
            else
                dicData.Add(strKey, strValue);
        }

        void AddValue(Dictionary<string, string> dicData, string strKey, long lValue)
        {
            if (dicData.ContainsKey(strKey))
                dicData[strKey] += "," + lValue.ToString();
            else
                dicData.Add(strKey, lValue.ToString());
        }

        void AddValue(Dictionary<string, string> dicData, string strKey, int iValue)
        {
            if (dicData.ContainsKey(strKey))
                dicData[strKey] += "," + iValue.ToString();
            else
                dicData.Add(strKey, iValue.ToString());
        }

        void AddValue(Dictionary<string, string> dicData, string strKey, short sValue)
        {
            if (dicData.ContainsKey(strKey))
                dicData[strKey] += "," + sValue.ToString();
            else
                dicData.Add(strKey, sValue.ToString());
        }

        void AddValue(Dictionary<string, string> dicData, string strKey, byte bValue)
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

        void objB2BApi_OnResponse(int iMark, uint dwIndex, string strIndex, object Handle, object aryValue)
        {
            try
            {

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
        }

        public override object CA()
        {
            throw new NotImplementedException();
        }

        public override object CancelOrder(AAA.Meta.Trade.Data.OrderInfo orderInfo)
        {
            throw new NotImplementedException();
        }

        public override object GetDealReport(string strStartDate, string strEndDate)
        {
            throw new NotImplementedException();
        }

        public override object GetOrderReport(string strStartDate, string strEndDate)
        {
            throw new NotImplementedException();
        }

        public override object GetOrderStatus(AAA.Meta.Trade.Data.OrderInfo orderInfo)
        {
            throw new NotImplementedException();
        }

        public override object GetPositionReport()
        {
            try
            {
                B2BApi.inMsgAddLong(1);                           //填入筆數
                B2BApi.inMsgAddStr(((string)AAA.DesignPattern.Singleton.SystemParameter.Parameter["LoginAccounts"]).Trim(), 22); //填入查詢帳號

                B2BApi.inMsgSend(GET_POSITION_REPORT, (uint)0, ((string)AAA.DesignPattern.Singleton.SystemParameter.Parameter["LoginAccounts"]).Trim(), true); //將即時回報ID為 10.0.0.13的功能送出
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
                B2BApi.inMsgAddStr(((string)AAA.DesignPattern.Singleton.SystemParameter.Parameter["LoginAccounts"]).Trim(), 22); //填入查詢帳號
                B2BApi.inMsgAddStr("2", 1);  //填入幣別 1:基幣 2:台幣 3:美金

                B2BApi.inMsgSend(TODAY_EQUITY, (uint)0, ((string)AAA.DesignPattern.Singleton.SystemParameter.Parameter["LoginAccounts"]).Trim(), true); //將即時回報ID為 10.0.0.13的功能送出

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
            return "Success";
        }

        public override bool IsConnected()
        {
            return _isConnected;   
        }

        public override object Login()
        {
            try
            {
                string strLoginAccount = Util.FillSpace(_accountInfo.AccountType + _accountInfo.AccountNo, 22);
                B2BApi.Login((int)0, strLoginAccount, _accountInfo.Password);
                AAA.DesignPattern.Singleton.SystemParameter.Parameter["LoginAccounts"] = strLoginAccount;
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
            return null;
        }

        public override object Logout()
        {
            try
            {
                B2BApi.Logout(AAA.DesignPattern.Singleton.SystemParameter.Parameter["LoginAccounts"].ToString().Trim());
                B2BApi.Close();

                return "Success";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return "Fail";
        }

        public override void OnMessage(AAA.Meta.Trade.MessageEvent messageEvent)
        {
            
        }

        public override string QuerySymbolCode(string strSymbolType, string strStrikePrice, string strPubOrCall, string strYear, string strMonth)
        {
            throw new NotImplementedException();
        }

        public override object SendOrder(AAA.Meta.Trade.Data.OrderInfo orderInfo)
        {
            throw new NotImplementedException();
        }

        public override Dictionary<string, string> SplitMessage(string strMessage, string strMessageType)
        {
            throw new NotImplementedException();
        }

        #region IDisposable Members

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
