using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Quote;
using AAA.Base.Util;
using System.Windows.Forms;
using System.Threading;
using AAA.Base.Util.Reader;
using AAA.Meta.Quote.Data;
using PolarisB2BAPI;
using AAA.TradeLanguage;
using AAA.TradeLanguage.Data;

namespace AAA.ProgramTrade.Quote
{
    public class PolarisHistoryQuote : AbstractHistoryQuote
    {
        private const int SYSTEM_RESP = 0;
        private const int RQRP_RESP = 1;
        private const int SUBSCRIPE_RESP = 2;

        private const string INTEGRATE_LOGIN = "0";
        private const string KLINE = "50.0.0.40";
        private const string OPTIONS_THEORETICAL_PRICE = "50.0.20.16";
        
        private const string KLINE_HEX = "32000028";
        private const string OPTIONS_THEORETICAL_PRICE_HEX = "32001410";
        //登入
        private static string[] LOGIN_OUTPUT_PARENT_TYPE = { "string", "string", "int" };
        private static int[] LOGIN_OUTPUT_PARENT_LEN = { 4, 50, 4 };
        private static string[] LOGIN_OUTPUT_PARENT_NAME = { "MsgCode", "MsgContent", "RecordCount" };

        private static string[] LOGIN_OUTPUT_CHILDREN_TYPE = { "string", "string", "string", "short" };
        private static int[] LOGIN_OUTPUT_CHILDREN_LEN = { 22, 12, 14, 2 };
        private static string[] LOGIN_OUTPUT_CHILDREN_NAME = { "Account", "Name", "InvestorId", "SellerNo" };

        //KLine
        private static string[] KLINE_OUTPUT_PARENT_TYPE = { "byte", "int" };
        private static int[] KLINE_OUTPUT_PARENT_LEN = { 1, 4 };
        private static string[] KLINE_OUTPUT_PARENT_NAME = { "KLineKind", "RecordCount" };

        private static string[] KLINE_OUTPUT_CHILDREN_TYPE = { "byte", "string", "string", "short", "short", "short", "int", "int", "int", "int", "short", "short", "short", "short", "byte", "string", "byte", "byte", "DateTime", "int", "DateTime", "int", "int", "int" };
        private static int[] KLINE_OUTPUT_CHILDREN_LEN = { 1, 12, 20, 2, 2, 2, 4, 4, 4, 4, 2, 2, 2, 2, 1, 12, 1, 1, 9, 4, 9, 4, 4, 4 };
        private static string[] KLINE_OUTPUT_CHILDREN_NAME = { "MarketNo", "StockCode", "StockName", "OpenTime", "CloseTime", "Decimal", "YstPrice", "OpenRefPrice", "UpStopPrice", "DownStopPrice", "RestStartTime1", "RestEndTime1", "RestStartTime2", "RestEndTime2", "BelongMarketNo", "BelongStockCode", "StockType1", "StockType2", "DateTime_First", "Seqno_First", "DateTime_Last", "Seqno_Last", "DealVoltmp", "DataCount" };

        private static string[] KLINE_OUTPUT_GRAND_CHILDREN_TYPE = { "DateTime", "int", "int", "int", "int", "int" };
        private static int[] KLINE_OUTPUT_GRAND_CHILDREN_LEN = { 9, 4, 4, 4, 4, 4 };
        private static string[] KLINE_OUTPUT_GRAND_CHILDREN_NAME = { "DateTime", "OpenPrice", "HighPrice", "LowPrice", "ClosePrice", "DealVol" };

        //Options Theoretical Price
        private static string[] OPTIONS_THEORETICAL_PRICE_OUTPUT_PARENT_TYPE = { "int" };
        private static int[] OPTIONS_THEORETICAL_PRICE_OUTPUT_PARENT_LEN = { 4 };
        private static string[] OPTIONS_THEORETICAL_PRICE_OUTPUT_PARENT_NAME = { "RecordCount" };

        private static string[] OPTIONS_THEORETICAL_PRICE_OUTPUT_CHILDREN_TYPE = { "byte", "string", "int", "int", "int", "short", "int", "int", "int", "int", "int", "int", "int" };
        private static int[] OPTIONS_THEORETICAL_PRICE_OUTPUT_CHILDREN_LEN = { 1, 12, 4, 4, 4, 2, 4, 4, 4, 4, 4, 4, 4 };
        private static string[] OPTIONS_THEORETICAL_PRICE_OUTPUT_CHILDREN_NAME = { "MarketNo", "StockCode", "OpenRefPrice", "UpStopPrice", "DownStopPrice", "Decimal", "TheoreticalPrice", "DealPrice", "Volatility", "Delta", "Gamma", "Theta", "Vega" };

        private PolaisB2BTrader _objB2BApi;
        private IPolaisB2BTraderEvents_OnResponseEventHandler _eventHandle = null;

        private Dictionary<string, object> _dicReturn;
        private string _strAccountNo;

        private bool _isConnected;
        private bool _isLogin;

        private Dictionary<string, string> _dicMarketNoMapping;
        private Dictionary<string, int> _dicMarketMultiple;

        public PolarisHistoryQuote()
        {
            InitPolarisParam();
            B2BApi.Open();
            WaitTillCompleted();
        }

        private void InitPolarisParam()
        {
            IniReader iniReader = null;
            try
            {
                iniReader = new IniReader(AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.PROGRAM_ROOT_PATH].ToString() + @"\cfg\polaris.ini");
                _dicMarketNoMapping = new Dictionary<string, string>();
                _dicMarketMultiple = new Dictionary<string, int>();

                foreach (string strKey in iniReader.GetKey("MarketNo"))
                    _dicMarketNoMapping.Add(strKey, iniReader.GetParam("MarketNo", strKey));

                foreach (string strKey in iniReader.GetKey("Multiple"))
                    _dicMarketMultiple.Add(strKey, int.Parse(iniReader.GetParam("Multiple", strKey)));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void InitProgram(Dictionary<string, object> dicParam)
        {           
            if (_isConnected && (_isLogin == false))
            {
                _strAccountNo = StringHelper.FillSpace((dicParam["AccountType"].ToString() + dicParam["AccountNo"].ToString()).Trim(), 22);
                B2BApi.Login((int)0, _strAccountNo, dicParam["Password"].ToString());
                WaitTillCompleted();
            }            
        }

        public override void Close()
        {
            try
            {
                B2BApi.Logout(_strAccountNo);
                B2BApi.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
                    throw ex;
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
                    throw ex;
                }
            }
        }

        private Dictionary<string, object> ConvertMessage(int iMark, uint dwIndex, string strIndex, object oValue,
                                                         string[] strOutputParentType, int[] iOutputParentLen, string[] strOutputParentName,
                                                         string[] strOutputChildrenType, int[] iOutputChildrenLen, string[] strOutputChildrenName,
                                                         string[] strOutputGrandChildrenType, int[] iOutputGrandChildrenLen, string[] strOutputGrandChildrenName)
        {
            Dictionary<string, object> dicReturn = new Dictionary<string, object>();
            Dictionary<string, object> dicChildren;
            Dictionary<string, object> dicGrandChildren;
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
                    //依元件規格文件依序解出內容值, ParentStruct
                    for (int i = 0; i < strOutputParentType.Length; i++)
                    {
                        strValue = ProcessOutput(strOutputParentType[i], iOutputParentLen[i]);
                        AddValue(dicReturn, strOutputParentName[i], strValue);
                    }

                    dicReturn.Add("Header", GenerateHeader(strOutputParentName));

                    //依元件規格文件依序解出內容值, ChildStruct
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

                            //依元件規格文件依序解出內容值, GrandChildStruct
                            if (strOutputGrandChildrenName != null)
                            {                                
                                for (int j = 0; j < int.Parse(dicChildren["DataCount"].ToString()); j++)
                                {
                                    dicGrandChildren = new Dictionary<string, object>();
                                    for (int k = 0; k < strOutputGrandChildrenType.Length; k++)
                                    {
                                        strValue = ProcessOutput(strOutputGrandChildrenType[k], iOutputGrandChildrenLen[k]);
                                        AddValue(dicGrandChildren, strOutputGrandChildrenName[k], strValue);
                                    }
                                    dicChildren.Add("GrandChildren" + j, dicGrandChildren);
                                }
                                if(dicReturn.ContainsKey("GrandChildrenHeader") == false)
                                    dicReturn.Add("GrandChildrenHeader", GenerateHeader(strOutputGrandChildrenName));
                            }
                        }
                        dicReturn.Add("ChildrenHeader", GenerateHeader(strOutputChildrenName));
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
                        _isConnected = strResult.IndexOf("Connected") > -1;

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
                                _isLogin = true;
                                break;

                            case KLINE_HEX: //K線查詢
                                //strResult = funAPILogin_Out((byte[])aryValue);
                                _dicReturn = ConvertMessage(iMark, dwIndex, strIndex, aryValue,
                                                             KLINE_OUTPUT_PARENT_TYPE, KLINE_OUTPUT_PARENT_LEN, KLINE_OUTPUT_PARENT_NAME,
                                                             KLINE_OUTPUT_CHILDREN_TYPE, KLINE_OUTPUT_CHILDREN_LEN, KLINE_OUTPUT_CHILDREN_NAME,
                                                             KLINE_OUTPUT_GRAND_CHILDREN_TYPE, KLINE_OUTPUT_GRAND_CHILDREN_LEN, KLINE_OUTPUT_GRAND_CHILDREN_NAME);
                                break;
                            case OPTIONS_THEORETICAL_PRICE_HEX: //K線查詢
                                //strResult = funAPILogin_Out((byte[])aryValue);
                                _dicReturn = ConvertMessage(iMark, dwIndex, strIndex, aryValue,
                                                             OPTIONS_THEORETICAL_PRICE_OUTPUT_PARENT_TYPE, OPTIONS_THEORETICAL_PRICE_OUTPUT_PARENT_LEN, OPTIONS_THEORETICAL_PRICE_OUTPUT_PARENT_NAME,
                                                             OPTIONS_THEORETICAL_PRICE_OUTPUT_CHILDREN_TYPE, OPTIONS_THEORETICAL_PRICE_OUTPUT_CHILDREN_LEN, OPTIONS_THEORETICAL_PRICE_OUTPUT_CHILDREN_NAME,
                                                             null, null, null);                                
                                break;
                            default:  //不在表列中的直接呈現訊息
                                strResult = strIndex + " " + Convert.ToString(aryValue);
                                break;
                        }
                        break;
                    case SUBSCRIPE_RESP: //訂閱所回應
                        switch (Convert.ToString(dwIndex, 16).ToUpper())
                        {

                            default:
                                strResult = Convert.ToString(aryValue);
                                break;
                        }

                        break;
                    default:
                        strResult = Convert.ToString(aryValue);
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

        private void MessageSend(string strFunctionCode)
        {
            try
            {
                B2BApi.inMsgSend(strFunctionCode, (uint)0, (_strAccountNo).Trim(), true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void AddValue(Dictionary<string, object> dicData, string strKey, object oValue)
        {
            if (dicData.ContainsKey(strKey))
                dicData[strKey] += "," + oValue;
            else
                dicData.Add(strKey, oValue);
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
                        return StringHelper.FilterBreakChar(strValue);
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

        private void ProcessBarRecord(List<AAA.Meta.Quote.Data.BarRecord> lstBarRecord, int iMultiple)
        {
            Dictionary<string, object> dicChildren;
            Dictionary<string, object> dicGrandChildren;
            BarRecord barRecord;
            int iBarCount;
            string strStartTime;
            string strEndTime;

            try
            {
                if (_dicReturn.ContainsKey("Children0") == false)
                    return;

                dicChildren = (Dictionary<string, object>)_dicReturn["Children0"];
                iBarCount = int.Parse((string)dicChildren["DataCount"]);
                strStartTime = (string)dicChildren["DateTime_First"];
                strEndTime = (string)dicChildren["DateTime_Last"];

                for (int i = 0; i < iBarCount; i++)
                {
                    dicGrandChildren = (Dictionary<string, object>)dicChildren["GrandChildren" + i];

                    barRecord = new BarRecord();
                    barRecord.BarCompression = AAA.Meta.Quote.BarCompressionEnum.Min;
                    barRecord.CompressionInterval = 1;
                    barRecord.BarDateTime = DateTime.Parse(dicGrandChildren["DateTime"].ToString().Substring(0, dicGrandChildren["DateTime"].ToString().Length - 4));
                    barRecord["Open"] = (float)(long.Parse(dicGrandChildren["OpenPrice"].ToString()) / (float)iMultiple);
                    barRecord["High"] = (float)(long.Parse(dicGrandChildren["HighPrice"].ToString()) / (float)iMultiple);
                    barRecord["Low"] = (float)(long.Parse(dicGrandChildren["LowPrice"].ToString()) / (float)iMultiple);
                    barRecord["Close"] = (float)(long.Parse(dicGrandChildren["ClosePrice"].ToString()) / (float)iMultiple);
                    barRecord["Volume"] = (float)(long.Parse(dicGrandChildren["DealVol"].ToString()));
                    //lstBarRecord.Add(barRecord);
                    lstBarRecord.Insert(i, barRecord);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ProcessTheoreticalPrice(Dictionary<string, List<BarRecord>> dicDataSource, DateTime dtCurrent)
        {
            Dictionary<string, object> dicChildren;
            BarRecord barRecord;
            int iBarCount;
            string strSymbolId;
            float fMultiple = 10000;
            try
            {
                if ((iBarCount = int.Parse(_dicReturn["RecordCount"].ToString())) == 0)
                    return;


                for (int i = 0; i < iBarCount; i++)
                {
                    dicChildren = (Dictionary<string, object>)_dicReturn["Children" + i];
                    strSymbolId = (string)dicChildren["StockCode"];

                    if (dicDataSource.ContainsKey(strSymbolId) == false)
                        dicDataSource.Add(strSymbolId, new List<BarRecord>());
                   
                    barRecord = new BarRecord();
                    barRecord.BarCompression = AAA.Meta.Quote.BarCompressionEnum.Daily;
                    barRecord.CompressionInterval = 1;
                    barRecord.BarDateTime = dtCurrent;
                    barRecord["TheoreticalPrice"] = float.Parse(dicChildren["TheoreticalPrice"].ToString()) / 1000;
                    barRecord["Volatility"] = float.Parse(dicChildren["Volatility"].ToString()) / 100;
                    barRecord["Delta"] = float.Parse(dicChildren["Delta"].ToString()) / fMultiple;
                    barRecord["Gamma"] = float.Parse(dicChildren["Gamma"].ToString()) / fMultiple;
                    barRecord["Theta"] = float.Parse(dicChildren["Theta"].ToString()) / fMultiple;
                    barRecord["Vega"] = float.Parse(dicChildren["Vega"].ToString()) / fMultiple;
                    barRecord["DealPrice"] = float.Parse(dicChildren["DealPrice"].ToString()) / 1000;
                    barRecord["OpenRefPrice"] = float.Parse(dicChildren["OpenRefPrice"].ToString()) / 1000;
                    barRecord["UpStopPrice"] = float.Parse(dicChildren["UpStopPrice"].ToString()) / 1000;
                    barRecord["DownStopPrice"] = float.Parse(dicChildren["DownStopPrice"].ToString()) / 1000;
                    dicDataSource[strSymbolId].Insert(0, barRecord);                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        private string MarketNo(string strMarket)
        {
            return _dicMarketNoMapping.ContainsKey(strMarket)
                    ? _dicMarketNoMapping[strMarket]
                    : strMarket;
        }

        private int MarketMultiple(string strMarket)
        {
            return _dicMarketMultiple.ContainsKey(strMarket)
                    ? _dicMarketMultiple[strMarket]
                    : 1000;
        }

        public override Dictionary<string, List<AAA.Meta.Quote.Data.BarRecord>> GetBarRecord(string strRecordType, string strSymbolId)
        {
            return GetBarRecord(strRecordType, strSymbolId, DateTime.Now.AddDays(-2), DateTime.Now);
        }

        public override Dictionary<string, List<AAA.Meta.Quote.Data.BarRecord>> GetBarRecord(string strRecordType, string strSymbolId, DateTime dtStartTime, DateTime dtEndTime)
        {
            Dictionary<string, List<AAA.Meta.Quote.Data.BarRecord>> dicReturn = new Dictionary<string, List<AAA.Meta.Quote.Data.BarRecord>>();
            dtStartTime = DateTime.Parse(dtStartTime.ToString("yyyy/MM/dd") + " 00:00:00.000");
            DateTime dtCurrentEndTime = DateTime.Parse(dtEndTime.ToString("yyyy/MM/dd") + " 23:59:59.000");
            DateTime dtSettleDate = SymbolUtil.SettleDate(dtCurrentEndTime.Year, dtCurrentEndTime.Month);
            string strQueryType = strRecordType.Split('_')[0];
            string strContract = strRecordType.IndexOf('_') > 0 ? strRecordType.Split('_')[1] : "";
            try
            {
                switch (strQueryType)
                {
                    case "OptionsTheroreticalPrice":
                        while (dtCurrentEndTime.CompareTo(dtStartTime) >= 0)
                        {
                            int iDayCount = SymbolUtil.TradeDayCountToSettleDay(dtCurrentEndTime);
                            ContractInfo queryContract = strContract.ToLower() == "next" ? SymbolUtil.NextMonthContract(dtCurrentEndTime) : SymbolUtil.HotContract(dtCurrentEndTime);
                            B2BApi.inMsgClear();
                            ProcessInput("string", 2, strSymbolId);  //類股代碼
                            ProcessInput("int", 4, (queryContract.Year * 100 + queryContract.Month).ToString());    //交易月份
                            ProcessInput("byte", 1, "2");   //參考標的種類 1:大盤 2:期指
                            ProcessInput("byte", 1, "1");   //波動率種類 1.歷史 2.隱含 3.自設
                            ProcessInput("int", 4, SymbolUtil.TradeDayCountToSettleDay(dtCurrentEndTime).ToString()); //剩餘日 - 只計交易日
                            MessageSend(OPTIONS_THEORETICAL_PRICE);
                            WaitTillCompleted();
                            ProcessTheoreticalPrice(dicReturn, dtCurrentEndTime);
                            dtCurrentEndTime = dtCurrentEndTime.AddDays(-1);
                        }
                        break;

                }                  
            }
            catch (Exception ex)
            {
                throw new Exception(this.GetType().ToString(), ex);
            }
            return dicReturn;
        }

        public override List<AAA.Meta.Quote.Data.BarRecord> GetBarData(string strSymbolId)
        {
            return GetBarData(strSymbolId, DateTime.Now.AddDays(-2), DateTime.Now);
        }

        public override List<AAA.Meta.Quote.Data.BarRecord> GetBarData(string strSymbolId, DateTime dtStartTime, DateTime dtEndTime)
        {
            List<AAA.Meta.Quote.Data.BarRecord> lstReturn = new List<AAA.Meta.Quote.Data.BarRecord>();

            //SymbolCode, MarketName, KLineKind, Interval
            string[] strSymbolParam = strSymbolId.Split('_');
            string strCondition = "1";

            dtStartTime = DateTime.Parse(dtStartTime.ToString("yyyy/MM/dd") + " 00:00:00.000");
            DateTime dtCurrentEndTime = DateTime.Parse(dtEndTime.ToString("yyyy/MM/dd") + " 23:59:59.000");

            try
            {

                while (dtCurrentEndTime.CompareTo(dtStartTime) > 0)
                {
                    B2BApi.inMsgClear();

                    switch (strSymbolParam[2].ToLower())
                    {
                        case "min":
                            ProcessInput("byte", 1, "3"); //查詢分鐘線
                            strCondition = "2";
                            break;
                        case "day":
                            ProcessInput("byte", 1, "11"); //查詢日線
                            strCondition = "3";
                            break;
                        case "week":
                            ProcessInput("byte", 1, "12"); //查詢週線
                            strCondition = "3";
                            break;
                        case "month":
                            ProcessInput("byte", 1, "13"); //查詢月線
                            strCondition = "3";
                            break;
                        case "adj_day":
                            ProcessInput("byte", 1, "21"); //查詢還原日線
                            strCondition = "3";
                            break;
                    }


                    ProcessInput("short", 2, strSymbolParam[3]); //時間長度
                    ProcessInput("string", 1, "Y"); //5分K足分計算
                    ProcessInput("byte", 1, strCondition); //查詢條件 1:最近K棒數, 2:指定時間前的K棒數, 3:區間查詢                
                    ProcessInput("int", 4, "500"); //預設K棒數
                    ProcessInput("DateTime", 9, dtStartTime.ToString("yyyy/MM/dd") + " 00:00:00.000");
                    ProcessInput("DateTime", 9, dtCurrentEndTime.ToString("yyyy/MM/dd HH:mm:ss") + ".000");
                    ProcessInput("int", 4, "0"); //序號<忽略>
                    ProcessInput("int", 4, "1"); //查詢筆數 -- 股票代碼數, 目前均為1, 代表一次查一個股票

                    ProcessInput("byte", 1, MarketNo(strSymbolParam[1])); //市場代碼
                    ProcessInput("string", 12, strSymbolParam[0]); //股票代碼

                    MessageSend(KLINE); //送出查詢指令

                    WaitTillCompleted(); //等待查詢回傳內容

                    ProcessBarRecord(lstReturn, MarketMultiple(strSymbolParam[1]));

                    if (lstReturn.Count == 0)
                        break;

                    if (dtCurrentEndTime.CompareTo(lstReturn[0].BarDateTime) == 0)
                        break;

                    dtCurrentEndTime = lstReturn[0].BarDateTime;                        
                }
                
                if(lstReturn.Count > 0)
                {
                    while (lstReturn[0].BarDateTime.CompareTo(dtStartTime) < 0)
                    {
                        lstReturn.RemoveAt(0);
                        if (lstReturn.Count == 0)
                            break;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return lstReturn;
        }
    }
}
