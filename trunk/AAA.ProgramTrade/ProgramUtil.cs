using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.TradeLanguage;
using System.IO;
using AAA.Meta.Quote.Data;
using AAA.Meta.Quote;
using AAA.DataSource;

namespace AAA.ProgramTrade
{
    public class ProgramUtil
    {
        public static void RunFunction(IFunction function, string strBaseSymbolId, Dictionary<string, object> dicParam)
        {
            CurrentTime currentTime = (CurrentTime)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.CURRENT_TIME];
            IDataSource dataSource = (IDataSource)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.DATA_SOURCE];
            int iOriginalInterval;
            DateTime dtOriginalCurrentTime = currentTime.CurrentDateTime;
            try
            {
                currentTime.CurrentDateTime = dataSource.DataStartTime(strBaseSymbolId);
                function.SetCurrentTime(currentTime);
                function.BaseSymbolId = strBaseSymbolId;

                foreach (string strKey in dicParam.Keys)
                {
                    function.InputVariable(strKey, dicParam[strKey]);
                }

                iOriginalInterval = currentTime.TimeInterval;

                currentTime.RemoveSymbol(function.InputVariable("TransferSymbolId").ToString());
                currentTime.Reset();
                currentTime.TimeInterval = 60 * function.DataCompression.Interval;
                while (currentTime.CurrentDateTime.CompareTo(currentTime.DataEndTime) < 0)
                {
                    function.Calculate(function.InputVariable("TransferSymbolId").ToString().Trim() == "" ? null : function.InputVariable("TransferSymbolId").ToString().Trim());
                    currentTime.MoveNext();
                }
                currentTime.TimeInterval = iOriginalInterval;
                currentTime.CurrentDateTime = dtOriginalCurrentTime;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void LoadOfflineData(string strFilename, bool isParseHeader)
        {
            StreamReader sr = null;
            string strSymbolId;
            string strDataCompression;
            string strLine;
            string[] strValues;
            List<BarRecord> lstBarData;
            BarData barData;
            BarCompressionEnum eBarCompression;
            int iInterval = 1;

            try
            {
                sr = new StreamReader(strFilename);

                if (isParseHeader)
                {
                    strSymbolId = sr.ReadLine().Trim();
                    strDataCompression = sr.ReadLine().Trim();
                    eBarCompression = (BarCompressionEnum)Enum.Parse(typeof(BarCompressionEnum), strDataCompression.Split(',')[0]);
                    iInterval = int.Parse(strDataCompression.Split(',')[1]);                    
                }
                else
                {
                    strValues = strFilename.Substring(strFilename.LastIndexOf("\\") + 1).Split('_');

                    strSymbolId = strValues[0] + "-" + strValues[1] + "-" + strValues[2] + "-" + strValues[3];                    
                    eBarCompression = (BarCompressionEnum)Enum.Parse(typeof(BarCompressionEnum), strValues[2]);
                    iInterval = int.Parse(strValues[3].Substring(0, strValues[3].LastIndexOf(".")));
                }

                lstBarData = new List<BarRecord>();

                while ((strLine = sr.ReadLine()) != null)
                {
                    strValues = strLine.Split('\t');
                    barData = new BarData();
                    barData.SymbolId = strSymbolId;
                    barData.BarCompression = eBarCompression;
                    barData.CompressionInterval = iInterval;
                    barData.BarDateTime = DateTime.Parse(strValues[0]);
                    barData.Open = float.Parse(strValues[1]);
                    barData.High = float.Parse(strValues[2]);
                    barData.Low = float.Parse(strValues[3]);
                    barData.Close = float.Parse(strValues[4]);
                    barData.Volume = float.Parse(strValues[5]);
                    if(strValues.Length > 6)
                        barData.Amount = float.Parse(strValues[6]);

                    lstBarData.Add(barData.ToBarRecord());
                }

                sr.Close();

                if(lstBarData.Count > 0)
                    ((IDataSource)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.DATA_SOURCE]).AddSymbol(strSymbolId, lstBarData);

            }
            catch (Exception ex)
            {
                throw new Exception(strFilename, ex);
            }
            finally
            {
                if (sr != null)
                    sr.Close();

            }
        }
    }
}
