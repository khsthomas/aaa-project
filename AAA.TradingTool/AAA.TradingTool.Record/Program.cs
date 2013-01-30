using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.TradeAPI.SPF;
using AAA.Meta.Trade.Data;
using AAA.Database.Model;
using AAA.TradingTool.Model;
using AAA.Base.Util;
using System.IO;

namespace AAA.TradingTool.Record
{
    class RecordProcess
    {
        private SPFStructure _orderStatusTaiwanStructure;
        private SPFStructure _todayEquityStructure;
        private SPFStructure _historyEquityStructure;
        private AccountInfo _accountInfo;
        private SPFBase _spfBase;

        public RecordProcess()
        {
            _spfBase = new SPFBase();
            _spfBase.OnMessage(new AAA.Meta.Trade.MessageEvent(OnMessageReceive));
        }

        private void OnMessageReceive(Dictionary<string, object> dicReturn)
        {
            if (!dicReturn.ContainsKey("name"))
                return;

            string strName = dicReturn["name"].ToString();
            int iRecordCount;
            Dictionary<string, object> dicChildren;
            IDataModel dataModel;

            if (dicReturn.ContainsKey("ReturnText"))
            {
                try
                {
                    if (!Directory.Exists(Environment.CurrentDirectory + @"\record_log\"))
                        Directory.CreateDirectory(Environment.CurrentDirectory + @"\record_log\");
                    StreamWriter sw = new StreamWriter(Environment.CurrentDirectory + @"\record_log\trade" + DateTime.Now.ToString("yyyyMMdd") + ".log", true, Encoding.Default);
                    sw.WriteLine(dicReturn["name"].ToString());
                    sw.WriteLine(dicReturn["ReturnText"].ToString());
                    sw.Close();
                }
                catch { }
            }

            if (strName == _historyEquityStructure.ClientName)
            {
                iRecordCount = int.Parse(dicReturn["Count"].ToString());

                for (int i = 0; i < iRecordCount; i++)
                {                    
                    dicChildren = (Dictionary<string, object>)dicReturn["Children" + i];

                    dataModel = new TW_Trans_D_EquitySummary();
                    dataModel.Value("ExDate", DateTimeHelper.Parse(dicChildren["TDate"].ToString()).ToString("yyyy/MM/dd"));
                    dataModel.Value("AccountNo", dicChildren["Account"].ToString());
                    dataModel.Value("ProfitQty", NumericHelper.ToFloat(dicChildren["ProfitQty"].ToString()));
                    dataModel.Value("ClearQty", NumericHelper.ToFloat(dicChildren["ClearQty"].ToString()));
                    dataModel.Value("Fee", NumericHelper.ToFloat(dicChildren["Fee"].ToString()));
                    dataModel.Value("Tax", NumericHelper.ToFloat(dicChildren["Tax"].ToString()));
                    dataModel.Value("FCon", NumericHelper.ToFloat(dicChildren["FCon"].ToString()));
                    dataModel.Value("FMiss", NumericHelper.ToFloat(dicChildren["FMiss"].ToString()));
                    dataModel.Value("OMiss", NumericHelper.ToFloat(dicChildren["OMiss"].ToString()));
                    dataModel.Value("InOut", NumericHelper.ToFloat(dicChildren["InOut"].ToString()));
                    dataModel.Value("OSecuAmt", NumericHelper.ToFloat(dicChildren["OSecuAmt"].ToString()));
                    dataModel.Value("USecuAmt", NumericHelper.ToFloat(dicChildren["USecuAmt"].ToString()));
                    dataModel.Value("RiskStatus", NumericHelper.ToFloat(dicChildren["Status"].ToString()));
                    dataModel.Value("BidQty", NumericHelper.ToFloat(dicChildren["BidQty"].ToString()));
                    dataModel.Value("AskQty", NumericHelper.ToFloat(dicChildren["AskQty"].ToString()));
                    dataModel.Value("OGain", NumericHelper.ToFloat(dicChildren["OGain"].ToString()));

                    if(dataModel.Update() == false)
                        Console.WriteLine(dataModel.ErrorMessage);
                }
            }

            if (strName == _todayEquityStructure.ClientName)
            {
                dicChildren = (Dictionary<string, object>)dicReturn["Children0"];

                dataModel = new TW_Trans_D_EquityDetail();
                dataModel.Value("ExDate", DateTimeHelper.Parse(dicReturn["Date"].ToString()).ToString("yyyy/MM/dd"));
                dataModel.Value("AccountNo", _accountInfo.AccountNo);
                dataModel.Value("CurrencyType", "0");
                dataModel.Value("AvlAmt", NumericHelper.ToFloat(dicChildren["Avlamt"].ToString()));
                dataModel.Value("ActBalance", NumericHelper.ToFloat(dicChildren["ACTbal"].ToString()));
                dataModel.Value("TGain", NumericHelper.ToFloat(dicChildren["Tgain"].ToString()));
                dataModel.Value("BGain", NumericHelper.ToFloat(dicChildren["Bgain"].ToString()));
                dataModel.Value("OBGain", NumericHelper.ToFloat(dicChildren["OBGAIN"].ToString()));
                dataModel.Value("PmAmt", NumericHelper.ToFloat(dicChildren["PMamt"].ToString()));
                dataModel.Value("ApAmt", NumericHelper.ToFloat(dicChildren["APamt"].ToString()));
                dataModel.Value("TmAmt", NumericHelper.ToFloat(dicChildren["TMamt"].ToString()));
                dataModel.Value("Fee", NumericHelper.ToFloat(dicChildren["Fee"].ToString()));
                dataModel.Value("Tax", NumericHelper.ToFloat(dicChildren["FTax"].ToString()));
                dataModel.Value("OtAmt", NumericHelper.ToFloat(dicChildren["OTamt"].ToString()));
                dataModel.Value("CogtAmt", NumericHelper.ToFloat(dicChildren["COGTamt"].ToString()));
                dataModel.Value("CmgtAmt", NumericHelper.ToFloat(dicChildren["CMGTamt"].ToString()));
                dataModel.Value("WarnN", NumericHelper.ToFloat(dicChildren["WARNN"].ToString()));
                dataModel.Value("WarnV", NumericHelper.ToFloat(dicChildren["WARNV"].ToString()));
                dataModel.Value("BidVolume", NumericHelper.ToFloat(dicChildren["BidVolume"].ToString()));
                dataModel.Value("AskVolume", NumericHelper.ToFloat(dicChildren["AskVolume"].ToString()));
                dataModel.Value("BidMatch", NumericHelper.ToFloat(dicChildren["BidMatch"].ToString()));
                dataModel.Value("AskMatch", NumericHelper.ToFloat(dicChildren["AskMatch"].ToString()));
                dataModel.Value("BEquity", NumericHelper.ToFloat(dicChildren["BEQUITY"].ToString()));
                dataModel.Value("GdAmt", NumericHelper.ToFloat(dicChildren["GdAmt"].ToString()));
                dataModel.Value("Equity", NumericHelper.ToFloat(dicChildren["EQuity"].ToString()));
                dataModel.Value("OGain", NumericHelper.ToFloat(dicChildren["OGAIN"].ToString()));
                dataModel.Value("ExRate", NumericHelper.ToFloat(dicChildren["exrate"].ToString()));
                dataModel.Value("XdgAmt", NumericHelper.ToFloat(dicChildren["xgdamt"].ToString()));
                dataModel.Value("AgtAmt", NumericHelper.ToFloat(dicChildren["agtamt"].ToString()));
                dataModel.Value("YEquity", NumericHelper.ToFloat(dicChildren["yequity"].ToString()));
                dataModel.Value("MuNet", NumericHelper.ToFloat(dicChildren["munet"].ToString()));

                if (dataModel.Update() == false)
                    Console.WriteLine(dataModel.ErrorMessage);

                dicChildren = (Dictionary<string, object>)dicReturn["Children2"];

                dataModel = new TW_Trans_D_EquityDetail();
                dataModel.Value("ExDate", DateTimeHelper.Parse(dicReturn["Date"].ToString()).ToString("yyyy/MM/dd"));
                dataModel.Value("AccountNo", _accountInfo.AccountNo);
                dataModel.Value("CurrencyType", "2");
                dataModel.Value("AvlAmt", NumericHelper.ToFloat(dicChildren["Avlamt"].ToString()));
                dataModel.Value("ActBalance", NumericHelper.ToFloat(dicChildren["ACTbal"].ToString()));
                dataModel.Value("TGain", NumericHelper.ToFloat(dicChildren["Tgain"].ToString()));
                dataModel.Value("BGain", NumericHelper.ToFloat(dicChildren["Bgain"].ToString()));
                dataModel.Value("OBGain", NumericHelper.ToFloat(dicChildren["OBGAIN"].ToString()));
                dataModel.Value("PmAmt", NumericHelper.ToFloat(dicChildren["PMamt"].ToString()));
                dataModel.Value("ApAmt", NumericHelper.ToFloat(dicChildren["APamt"].ToString()));
                dataModel.Value("TmAmt", NumericHelper.ToFloat(dicChildren["TMamt"].ToString()));
                dataModel.Value("Fee", NumericHelper.ToFloat(dicChildren["Fee"].ToString()));
                dataModel.Value("Tax", NumericHelper.ToFloat(dicChildren["FTax"].ToString()));
                dataModel.Value("OtAmt", NumericHelper.ToFloat(dicChildren["OTamt"].ToString()));
                dataModel.Value("CogtAmt", NumericHelper.ToFloat(dicChildren["COGTamt"].ToString()));
                dataModel.Value("CmgtAmt", NumericHelper.ToFloat(dicChildren["CMGTamt"].ToString()));
                dataModel.Value("WarnN", NumericHelper.ToFloat(dicChildren["WARNN"].ToString()));
                dataModel.Value("WarnV", NumericHelper.ToFloat(dicChildren["WARNV"].ToString()));
                dataModel.Value("BidVolume", NumericHelper.ToFloat(dicChildren["BidVolume"].ToString()));
                dataModel.Value("AskVolume", NumericHelper.ToFloat(dicChildren["AskVolume"].ToString()));
                dataModel.Value("BidMatch", NumericHelper.ToFloat(dicChildren["BidMatch"].ToString()));
                dataModel.Value("AskMatch", NumericHelper.ToFloat(dicChildren["AskMatch"].ToString()));
                dataModel.Value("BEquity", NumericHelper.ToFloat(dicChildren["BEQUITY"].ToString()));
                dataModel.Value("GdAmt", NumericHelper.ToFloat(dicChildren["GdAmt"].ToString()));
                dataModel.Value("Equity", NumericHelper.ToFloat(dicChildren["EQuity"].ToString()));
                dataModel.Value("OGain", NumericHelper.ToFloat(dicChildren["OGAIN"].ToString()));
                dataModel.Value("ExRate", NumericHelper.ToFloat(dicChildren["exrate"].ToString()));
                dataModel.Value("XdgAmt", NumericHelper.ToFloat(dicChildren["xgdamt"].ToString()));
                dataModel.Value("AgtAmt", NumericHelper.ToFloat(dicChildren["agtamt"].ToString()));
                dataModel.Value("YEquity", NumericHelper.ToFloat(dicChildren["yequity"].ToString()));
                dataModel.Value("MuNet", NumericHelper.ToFloat(dicChildren["munet"].ToString()));

                if (dataModel.Update() == false)
                    Console.WriteLine(dataModel.ErrorMessage);
            }


            if (strName == _orderStatusTaiwanStructure.ClientName)
            {
                iRecordCount = int.Parse(dicReturn["Count"].ToString());

                for (int i = 0; i < iRecordCount; i++)
                {
                    dicChildren = (Dictionary<string, object>)dicReturn["Children" + i];

                    dataModel = new TW_Trans_D_OrderHistory();
                    dataModel.Value("ExDateTime", DateTimeHelper.Parse(DateTime.Now.ToString("yyyyMMdd") + " " + dicChildren["TransTime"].ToString()).ToString("yyyy/MM/dd HH:mm:ss"));
                    dataModel.Value("SymbolType", dicChildren["Type"].ToString());
                    dataModel.Value("CancelQty", NumericHelper.ToFloat(dicChildren["CancelQty"].ToString()));
                    dataModel.Value("ContractQty", NumericHelper.ToFloat(dicChildren["ContractQty"].ToString()));
                    dataModel.Value("OrgPrice", NumericHelper.ToFloat(dicChildren["OrgPrice"].ToString().Trim() == "" ? "0" : dicChildren["OrgPrice"].ToString()));
                    dataModel.Value("Seq", dicChildren["Seq"].ToString());
                    dataModel.Value("AccountNo", dicChildren["Account"].ToString());
                    dataModel.Value("OrderNo", dicChildren["OrderNo"].ToString());
                    dataModel.Value("OrderSeq", dicChildren["OrderSeq"].ToString());
                    dataModel.Value("SymbolId", dicChildren["Code"].ToString());
                    dataModel.Value("TradeType", dicChildren["TradeType"].ToString());
                    dataModel.Value("TradeClass", dicChildren["TradeClass"].ToString());
                    dataModel.Value("TrustPrice", NumericHelper.ToFloat(dicChildren["Price"].ToString()));
                    dataModel.Value("DealPrice", NumericHelper.ToFloat(dicChildren["ContractPrice"].ToString()));
                    dataModel.Value("OrderKind", dicChildren["OrderKind"].ToString());
                    dataModel.Value("Qty", NumericHelper.ToFloat(dicChildren["Qty"].ToString()));
                    dataModel.Value("TransTime", DateTimeHelper.Parse(DateTime.Now.ToString("yyyyMMdd") + " " + dicChildren["TransTime"].ToString()).ToString("yyyy/MM/dd HH:mm:ss"));
                    dataModel.Value("StatusMessage", dicChildren["StatusMessage"].ToString());
                    dataModel.Value("ErrorCode", dicChildren["ErrorCode"].ToString());
                    dataModel.Value("ErrorMessage", dicChildren["ErrorMessage"].ToString());
                    dataModel.Value("WebId", dicChildren["WebId"].ToString());
                    dataModel.Value("AccountS", dicChildren["AccountS"].ToString());
                    dataModel.Value("OCT", dicChildren["OCT"].ToString());
                    dataModel.Value("OrderTime", DateTimeHelper.Parse(DateTime.Now.ToString("yyyyMMdd") + " " + dicChildren["OrderTime"].ToString()).ToString("yyyy/MM/dd HH:mm:ss"));
                    dataModel.Value("AgentId", dicChildren["AgentId"].ToString());
                    dataModel.Value("PriceType", dicChildren["PriceType"].ToString());
                    dataModel.Value("TrfField", dicChildren["TrfField"].ToString());
                    dataModel.Value("MatchSeq", dicChildren["MatchSeq"].ToString());

                    if (dataModel.Update() == false)
                        Console.WriteLine(dataModel.ErrorMessage);

                }
            }
        }

        public void Execute(AccountInfo accountInfo)
        {
            object oReturn;
            Dictionary<string, object> dicValue;            
            
            _orderStatusTaiwanStructure = new OrderStatusTaiwanStructure();
            _todayEquityStructure = new TodayEquityStructure();
            _historyEquityStructure = new HistoryEquityStructure();

            _spfBase.AddMessageStructure(_orderStatusTaiwanStructure);
            _spfBase.AddMessageStructure(_todayEquityStructure);
            _spfBase.AddMessageStructure(_historyEquityStructure);

            try
            {
                _spfBase.InitProgram(accountInfo);
                oReturn = _spfBase.Login();

                _spfBase.MessageSend(_orderStatusTaiwanStructure.ClientName, new Dictionary<string, object>());

                for (int i = 0; i < _spfBase.AccountList.Count; i++)
                {
                    if ((DateTime.Now.ToString("HH:mm:ss").CompareTo("15:00:00") < 0) &&
                        (DateTime.Now.ToString("HH:mm:ss").CompareTo("08:45:00") > 0))
                    {
                        _accountInfo = _spfBase.AccountList[i];
                        dicValue = new Dictionary<string, object>();
                        dicValue.Add(TodayEquityStructure.BRANCH, _spfBase.AccountList[i].Branch);
                        dicValue.Add(TodayEquityStructure.ACCOUNT_NO, _spfBase.AccountList[i].AccountNo);
                        _spfBase.MessageSend(_todayEquityStructure.ClientName, dicValue);
                    }
                    dicValue = new Dictionary<string, object>();
                    dicValue.Add(HistoryEquityStructure.BRANCH, _spfBase.AccountList[i].Branch);
                    dicValue.Add(HistoryEquityStructure.ACCOUNT_NO, _spfBase.AccountList[i].AccountNo);
                    dicValue.Add(HistoryEquityStructure.START_DATE, DateTime.Now.AddDays(-59).ToString("yyyyMMdd"));
                    dicValue.Add(HistoryEquityStructure.END_DATE, DateTime.Now.ToString("yyyyMMdd"));
                    _spfBase.MessageSend(_historyEquityStructure.ClientName, dicValue);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
            }
            finally
            {
                _spfBase.Logout();
            }
        }

    }

    class Program
    {         
        public static void Main(string[] args)
        {
            AccountInfo accountInfo;
            RecordProcess process;

            string[] strIdNo = new string[0];
            string[] strPassword = new string[0];

            for (int i = 0; i < strIdNo.Length; i++)
            {
                process = new RecordProcess();
                accountInfo = new AccountInfo();
                accountInfo.IdNo = strIdNo[i];
                accountInfo.Password = strPassword[i];

                process.Execute(accountInfo);
            }
        }
    }
}
