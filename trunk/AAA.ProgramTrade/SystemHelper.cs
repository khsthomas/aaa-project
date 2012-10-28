using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Trade;
using AAA.SPFTrade;
using System.IO;
using AAA.TradeLanguage.Data;
using AAA.TradeLanguage;
using AAA.Polaris;

namespace AAA.ProgramTrade
{
    public class SystemHelper
    {
        public static void WriteLog(string strLogPath, string strMessage)
        {
            StreamWriter sw = new StreamWriter(strLogPath + @"\Log_" + DateTime.Now.ToString("yyyyMMdd") + ".log", true, Encoding.Default);

            try
            {
                sw.WriteLine(strMessage);
                sw.Flush();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if(sw != null)
                    sw.Close();
            }
        }

        public static ITrade CreateTrade()
        {
            //return new SPFTradeImp();
            return new PolarisImp();    
        }

        public static TradeSymbol CreateTradeSymbol(object[] oValues)
        {
            TradeSymbol tradeSymbol;
            string strStrategyName;
            string strPriceType;
            string strContractType;
            string strSymbolType;
            string strSlippage;
            string strOrderDirection;
            string strExecutePrice;
            string strPriceZone;
            /*
                        0:tblStrategy.Columns.Add(checkBox);
                        1:tblStrategy.Columns.Add("Strategy", "策略名稱");
                        2:tblStrategy.Columns.Add("SymbolType", "商品別");
                        3:tblStrategy.Columns.Add("SymbolSeq", "商品序號");
                        4:tblStrategy.Columns.Add("PriceType", "價格別");
                        5:tblStrategy.Columns.Add("DayTrade", "當沖");
                        6:tblStrategy.Columns.Add("Volume", "下單口數");
                        7:tblStrategy.Columns.Add("ExitSignal", "送出平倉訊號");
                        8:tblStrategy.Columns.Add("ContractType", "合約別");
                        9:tblStrategy.Columns.Add("Slippage", "滑價");
                        10:tblStrategy.Columns.Add("OrderDirection", "買賣別");
                        11:tblStrategy.Columns.Add("ExecutePrice", "履約價別");
                        12:tblStrategy.Columns.Add("PriceZone", "檔次");
            */
            try
            {
                tradeSymbol = new TradeSymbol();

                strStrategyName = oValues[1].ToString();
                tradeSymbol.IsDayTrade = (oValues[5].ToString() == "Y");
                tradeSymbol.Volume = int.Parse(oValues[6].ToString());
                strPriceType = oValues[4].ToString();
                strContractType = oValues[8].ToString();
                strSlippage = (oValues[9].ToString() == "市價單" ? "-1" : oValues[9].ToString());
                strOrderDirection = oValues[10].ToString();
                strExecutePrice = oValues[11].ToString();
                strPriceZone = oValues[12].ToString();
                //Symbol Type
                strSymbolType = oValues[2].ToString();
                switch (strSymbolType)
                {
                    case "台指":
                        tradeSymbol.SymbolType = SymbolTypeEnum.Futures;
                        break;
                    case "小台":
                        tradeSymbol.SymbolType = SymbolTypeEnum.MiniFutures;
                        break;
                    case "選擇權買權":
                        tradeSymbol.SymbolType = SymbolTypeEnum.Call;
                        break;
                    case "選擇權賣權":
                        tradeSymbol.SymbolType = SymbolTypeEnum.Put;
                        break;
                }

                switch (strExecutePrice)
                {
                    case "價平":
                        tradeSymbol.ExecutePriceType = ExecutePriceTypeEnum.AtTheMoney;
                        break;
                    case "價內":
                        tradeSymbol.ExecutePriceType = ExecutePriceTypeEnum.InTheMoney;
                        break;
                    case "價外":
                        tradeSymbol.ExecutePriceType = ExecutePriceTypeEnum.OutOfTheMoney;
                        break;
                }

                switch (strOrderDirection)
                {
                    case "買方":
                        tradeSymbol.OrderDirection = OrderDirectionEnum.Buy;
                        break;
                    case "賣方":
                        tradeSymbol.OrderDirection = OrderDirectionEnum.Sell;
                        break;
                    default:
                        tradeSymbol.OrderDirection = OrderDirectionEnum.Auto;
                        break;
                }

                switch (strContractType)
                {
                    case "近月":
                        tradeSymbol.ContractType = ContractTypeEnum.Hot;
                        break;
                    case "遠月":
                        tradeSymbol.ContractType = ContractTypeEnum.Next;
                        break;
                    case "季月1":
                        tradeSymbol.ContractType = ContractTypeEnum.FirstQ;
                        break;
                    case "季月2":
                        tradeSymbol.ContractType = ContractTypeEnum.SecondQ;
                        break;
                    case "季月3":
                        tradeSymbol.ContractType = ContractTypeEnum.ThirdQ;
                        break;
                }

                tradeSymbol.Slippage = int.Parse(strSlippage);
                tradeSymbol.ExecutePriceZone = int.Parse(strPriceZone);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return tradeSymbol;
        }

        public static void InitStrategy(ITradingRule tradingRule, string strStrategyFile)
        {
            StreamReader sr = null;
            string strLine;
            string[] strValues;
            TradeSymbol tradeSymbol;

            try
            {

                if (File.Exists(strStrategyFile) == false)
                    return;

                sr = new StreamReader(strStrategyFile, Encoding.Default);

                sr.ReadLine();

                while ((strLine = sr.ReadLine()) != null)
                {
                    strValues = strLine.Split('\t');
                    tradeSymbol = CreateTradeSymbol(strValues);
                    tradingRule.AddSignalSymbolMapping(strValues[1], tradeSymbol);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sr != null)
                    sr.Close();
            }

        }

        public static DateTime ShiftTradingDay(DateTime dtCurrentDate, int iDayCount)
        {
            DateTime dtReturn = new DateTime(dtCurrentDate.Ticks);

            switch (dtReturn.DayOfWeek)
            {
                case DayOfWeek.Tuesday:
                case DayOfWeek.Monday:
                    dtReturn = dtReturn.AddDays(iDayCount - 2);
                    break;
                case DayOfWeek.Sunday:
                    dtReturn = dtReturn.AddDays(iDayCount - 1);
                    break;
                default:
                    dtReturn = dtReturn.AddDays(iDayCount);
                    break;
            }
            return dtReturn;
        }
    }
}
