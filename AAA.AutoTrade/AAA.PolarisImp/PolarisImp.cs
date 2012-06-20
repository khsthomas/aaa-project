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

        private static string[] INVENTORY_OUTPUT_PARENT_TYPE = { "int" };
        private static int[] INVENTORY_OUTPUT_PARENT_LEN = { 4 };
        private static string[] INVENTORY_OUTPUT_PARENT_NAME = { "RecordCount" };

        private static string[] INVENTORY_OUTPUT_CHILDREN_TYPE = { "string", "string", "string", "string", "int", "long", "string", "string", "int", "int", "string", "string", "int", "int", "int", "int", "string", "string", "string", "string", "string", "string", "byte", "string", "byte", "string", "byte", "string", "byte", "string" };
        private static int[] INVENTORY_OUTPUT_CHILDREN_LEN = { 22, 1, 20, 1, 4, 8, 6, 1, 4, 4, 6, 1, 4, 4, 4, 4, 3, 1, 1, 1, 1, 1, 1, 12, 1, 12, 1, 12, 1, 12 };
        private static string[] INVENTORY_OUTPUT_CHILDREN_NAME = { "Account", "Kind", "Trid", "BS", "Qty", "Amount", "CommodityID1", "CallPut1", "SettlementMonth1", "StrikePrice1", "CommodityID2", "CallPut2", "SettlementMonth2", "StrikePrice2", "Fee", "Tax", "CurrencyType", "DayTradeID", "BS1", "BS2", "ProdKind1", "ProdKind2", "MarketNo1", "StockCode1", "MarketNo2", "StockCode2", "BelongMarketNo1", "BelongStockCode1", "BelongMarketNo2", "BelongStockCode2" };


        private static string[] EQUITY_OUTPUT_PARENT_TYPE = { "short", "string", "long", "long", "long", "long", "long", "long", "long", "long", "long", "long", "long", "long", "string", "long", "long", "string", "long", "long", "long", "long", "string", "long" };
        private static int[] EQUITY_OUTPUT_PARENT_LEN = { 2, 78, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 9, 8, 8, 9, 8, 8, 8, 8, 1, 8 };
        private static string[] EQUITY_OUTPUT_PARENT_NAME = { "ReplyCode", "Advisory", "CurrencyRate", "AccountBalance", "InOutAmt", "VarIncome", "AccountEquity", "RealizePremium", "UnRealizePremium", "InitialMargin", "MaintainMargin", "CoverIncome", "TodayTOT", "UsableMargin", "MaintainRate", "BuyOptionValue", "SellOptionValue", "FullRate", "CoverAmt", "AddMargin", "CashUsable", "NetEquityAmt", "MarginGetType", "YNetEquitAmt" };


        private PolarisB2BAPI.PolaisB2BTrader B2BApi;

        private PolarisB2BAPI.IPolaisB2BTraderEvents_OnResponseEventHandler _eventHandle = null;

        private bool _isConnected;

        public PolarisB2BAPI.PolaisB2BTrader APIInstance
        {
            get { return B2BApi; }
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
            throw new NotImplementedException();
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
