using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Base.Util;

namespace AAA.ProgramTrade.Parser
{
    public class PolarisMessageParser
    {
        public static Dictionary<string, object> ParseEquity(Dictionary<string, object> dicParam)
        {
            Dictionary<string, object> dicReturn = new Dictionary<string, object>();
            Dictionary<string, string> dicEquity = new Dictionary<string, string>();
            string[] strFields = new string[] { "CurrencyRate", "AccountBalance", "InOutAmt", "VarIncome", "AccountEquity", "RealizePremium", "UnRealizePremium", "InitialMargin", "MaintainMargin", "CoverIncome", "TodayTOT", "UsableMargin", "MaintainRate", "BuyOptionValue", "SellOptionValue", "FullRate", "CoverAmt", "AddMargin", "CashUsable", "NetEquityAmt", "MarginGetType", "YNetEquitAmt" };            
            string[] strTitles = new string[] { "轉換匯率", "帳戶餘額", "本日提存", "浮動損益", "帳務權益", "權利金", "預扣費用", "原始保證金", "維持保證金", "平倉損益", "已實現費用", "可用餘額", "風險係數", "買方市值", "賣方市值", "足額維持率", "實際抵繳金額", "剩餘可抵繳金額", "出金可提領金額", "清算值", "保證金計收方式", "前一日清算值" };

            string[] strErrorFields = new string[] { "ReplyCode", "Advisory" };
            string[] strErrorTitles = new string[] { "錯誤代碼", "錯誤說明"};
            try
            {
                dicReturn.Add("equitytypes", new string[] {"台幣"});

                switch (dicParam["ReplyCode"].ToString().Trim())
                {
                    case "0":
                        dicReturn.Add("record0", dicEquity);
                        dicReturn.Add("fields", strFields);
                        dicReturn.Add("titles", strTitles);


                        dicEquity.Add("CurrencyRate", (long.Parse((string)dicParam["CurrencyRate"]) / 1000000).ToString("0.00"));
                        dicEquity.Add("AccountBalance", (long.Parse((string)dicParam["AccountBalance"]) / 100).ToString("0.00"));
                        dicEquity.Add("InOutAmt", (long.Parse((string)dicParam["InOutAmt"]) / 100).ToString("0.00"));
                        dicEquity.Add("VarIncome", (long.Parse((string)dicParam["VarIncome"]) / 100).ToString("0.00"));
                        dicEquity.Add("AccountEquity", (long.Parse((string)dicParam["AccountEquity"]) / 100).ToString("0.00"));
                        dicEquity.Add("RealizePremium", (long.Parse((string)dicParam["RealizePremium"]) / 100).ToString("0.00"));
                        dicEquity.Add("UnRealizePremium", (long.Parse((string)dicParam["UnRealizePremium"]) / 100).ToString("0.00"));
                        dicEquity.Add("InitialMargin", (long.Parse((string)dicParam["InitialMargin"]) / 100).ToString("0.00"));
                        dicEquity.Add("MaintainMargin", (long.Parse((string)dicParam["MaintainMargin"]) / 100).ToString("0.00"));
                        dicEquity.Add("CoverIncome", (long.Parse((string)dicParam["CoverIncome"]) / 100).ToString("0.00"));
                        dicEquity.Add("TodayTOT", (long.Parse((string)dicParam["TodayTOT"]) / 100).ToString("0.00"));
                        dicEquity.Add("UsableMargin", (long.Parse((string)dicParam["UsableMargin"]) / 100).ToString("0.00"));
                        dicEquity.Add("MaintainRate", (string)dicParam["MaintainRate"]);
                        dicEquity.Add("BuyOptionValue", (long.Parse((string)dicParam["BuyOptionValue"]) / 100).ToString("0.00"));
                        dicEquity.Add("SellOptionValue", (long.Parse((string)dicParam["SellOptionValue"]) / 100).ToString("0.00"));
                        dicEquity.Add("FullRate", (string)dicParam["FullRate"]);
                        dicEquity.Add("CoverAmt", (long.Parse((string)dicParam["CoverAmt"]) / 100).ToString("0.00"));
                        dicEquity.Add("AddMargin", (long.Parse((string)dicParam["AddMargin"]) / 100).ToString("0.00"));
                        dicEquity.Add("CashUsable", (long.Parse((string)dicParam["CashUsable"]) / 100).ToString("0.00"));
                        dicEquity.Add("NetEquityAmt", (long.Parse((string)dicParam["NetEquityAmt"]) / 100).ToString("0.00"));
                        dicEquity.Add("MarginGetType", ((string)dicParam["MarginGetType"]) == " "
                                                        ? "傳統"
                                                        : ((string)dicParam["MarginGetType"]) == "S"
                                                            ? "整戶風險"
                                                            : "保證金最佳化");
                        dicEquity.Add("YNetEquitAmt", (long.Parse((string)dicParam["YNetEquitAmt"]) / 100).ToString("0.00"));
                        break;
                    default:
                        dicReturn.Add("record0", dicEquity);
                        dicReturn.Add("fields", strErrorFields);
                        dicReturn.Add("titles", strErrorTitles);

                        dicEquity.Add("ReplyCode", (string)dicParam["ReplyCode"]);
                        dicEquity.Add("Advisory", StringHelper.FilterBreakChar((string)dicParam["Advisory"]));
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dicReturn;
        }

        public static Dictionary<string, object> ParseTodayPosition(Dictionary<string, object> dicParam)
        {
            Dictionary<string, object> dicReturn = new Dictionary<string, object>();
            Dictionary<string, object> dicChildren = new Dictionary<string, object>();
            Dictionary<string, string> dicRecord;

            int iRecordCount;
            
            try
            {
                dicReturn.Add("recordcount", dicParam["RecordCount"].ToString());
                iRecordCount = int.Parse(dicParam["RecordCount"].ToString());

                for (int i = 0; i < iRecordCount; i++)
                {
                    dicRecord = new Dictionary<string, string>();
                    dicChildren = (Dictionary<string, object>)dicParam["Children" + i];

                    dicRecord.Add("code", dicChildren["Trid"].ToString());
                    dicRecord.Add("ord_no", "");
                    dicRecord.Add("ord_bs", dicChildren["BS"].ToString());
                    dicRecord.Add("currency", dicChildren["CurrencyType"].ToString());
                    dicRecord.Add("vol", dicChildren["Qty"].ToString());
                    dicRecord.Add("avg_price", (double.Parse(dicChildren["Amount"].ToString()) / 1000.0).ToString("0.00"));

                    dicReturn.Add("record" + i, dicRecord);
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dicReturn;
        }

        public static Dictionary<string, object> ParseDealReport(Dictionary<string, object> dicParam)
        {
            Dictionary<string, object> dicReturn = new Dictionary<string, object>();
            Dictionary<string, object> dicChildren = new Dictionary<string, object>();
            Dictionary<string, string> dicRecord;

            int iRecordCount;

            try
            {
                dicReturn.Add("recordcount", dicParam["RecordCount"].ToString());
                iRecordCount = int.Parse(dicParam["RecordCount"].ToString());

                for (int i = 0; i < iRecordCount; i++)
                {
                    dicRecord = new Dictionary<string, string>();
                    dicChildren = (Dictionary<string, object>)dicParam["Children" + i];

                    dicRecord.Add("ord_time", dicChildren["MatchTime"].ToString());
                    dicRecord.Add("type", dicChildren["ProductType"].ToString());
                    dicRecord.Add("code", dicChildren["CommodityID1"].ToString());
                    dicRecord.Add("trade_type", dicChildren["BuySellKind1"].ToString());
                    dicRecord.Add("trade_class", dicChildren["RecType"].ToString());
                    dicRecord.Add("price", "-");
                    dicRecord.Add("qty", "-");
                    dicRecord.Add("contractprice", (long.Parse(dicChildren["MatchPrice1"].ToString()) / 1000.0).ToString("0.00"));
                    dicRecord.Add("contractqty", dicChildren["MatchQty"].ToString());
                    dicRecord.Add("cancelqty", "0");
                    dicRecord.Add("errorcode", "-");
                    dicRecord.Add("errormsg", "-");
                    dicRecord.Add("oct", "-");
                    dicRecord.Add("ord_no", dicChildren["OrderNo"].ToString());
                    dicRecord.Add("ord_seq", "0");                    

                    dicReturn.Add("record" + i, dicRecord);
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dicReturn;
        }

        public static Dictionary<string, object> ParseTrustReport(Dictionary<string, object> dicParam)
        {
            Dictionary<string, object> dicReturn = new Dictionary<string, object>();
            Dictionary<string, object> dicChildren = new Dictionary<string, object>();
            Dictionary<string, string> dicRecord;

            int iRecordCount;

            try
            {
                dicReturn.Add("recordcount", dicParam["RecordCount"].ToString());
                iRecordCount = int.Parse(dicParam["RecordCount"].ToString());

                for (int i = 0; i < iRecordCount; i++)
                {
                    dicRecord = new Dictionary<string, string>();
                    dicChildren = (Dictionary<string, object>)dicParam["Children" + i];

                    dicRecord.Add("ord_time", dicChildren["AcceptDate"].ToString() + " " + dicChildren["AcceptTime"].ToString());
                    dicRecord.Add("type", dicChildren["ProductType"].ToString());
                    dicRecord.Add("code", dicChildren["CommodityID1"].ToString() + "," + dicChildren["SettlementMonth1"].ToString() + "," + (int.Parse(dicChildren["StrikePrice1"].ToString()) / 1000).ToString());
                    dicRecord.Add("trade_type", dicChildren["BuySellKind1"].ToString());
                    dicRecord.Add("trade_class", "-");
                    dicRecord.Add("price", (double.Parse(dicChildren["OrderPrice"].ToString())).ToString("0.00"));
                    dicRecord.Add("qty", dicChildren["OrderQty"].ToString());
                    dicRecord.Add("contractprice", "-");
                    dicRecord.Add("contractqty", dicChildren["OkQty"].ToString());
                    dicRecord.Add("cancelqty", (double.Parse(dicChildren["OrderQty"].ToString()) - double.Parse(dicChildren["AfterQty"].ToString())).ToString());
                    dicRecord.Add("errorcode", dicChildren["ErrorNo"].ToString());
                    dicRecord.Add("errormsg", dicChildren["ErrorMessage"].ToString());
                    dicRecord.Add("oct", (dicChildren["OpenOffsetKind"].ToString().Trim() == "0" 
                                            ? "新倉"
                                            : dicChildren["OpenOffsetKind"].ToString().Trim() == "1"
                                                ? "平倉"
                                                : "自動"));
                    dicRecord.Add("ord_no", dicChildren["OrderNo"].ToString());
                    dicRecord.Add("ord_seq", dicChildren["OrderNo"].ToString());                    

                    dicReturn.Add("record" + i, dicRecord);
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dicReturn;
        }
    }
}
