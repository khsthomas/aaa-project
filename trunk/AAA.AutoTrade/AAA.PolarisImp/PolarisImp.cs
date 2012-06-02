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

        private PolarisB2BAPI.PolaisB2BTrader B2BApi;

        private PolarisB2BAPI.IPolaisB2BTraderEvents_OnResponseEventHandler _eventHandle = null;

        private bool _isConnected;

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
            throw new NotImplementedException();
        }

        public override object GetTodayEquity()
        {
            throw new NotImplementedException();
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
                B2BApi.Login((int)0, Util.FillSpace(_accountInfo.AccountNo, 22), _accountInfo.Password);

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
            throw new NotImplementedException();
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
