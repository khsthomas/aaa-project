using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Schedule;
using AAA.Meta.Quote.Data;
using AAA.ProgramTrade.Quote;
using AAA.DataSource;
using AAA.DesignPattern.Observer;

namespace AAA.ProgramTrade.Task
{
    public class LoadTradeData : AbstractQuoteTask
    {
        public override IExecuteResult Execute(Dictionary<string, object> dicData)
        {
            IExecuteResult executeResult = null;

            List<BarRecord> lstBarRecord;
            DateTime dtEndDate = DateTime.Now;
            DateTime dtStartDate = DateTime.Now;
            MessageInfo messageInfo;
            HistoryQuote.InitProgram(Param);
            BarInfo barInfo;

            for (int i = 0; i < APISymbols.Length; i++)
            {
                lstBarRecord = HistoryQuote.GetBarData(APISymbols[i], dtStartDate, dtEndDate);

                if (lstBarRecord == null)
                    continue;

                if (lstBarRecord.Count == 0)
                    continue;

                barInfo = new BarInfo();
                barInfo.SymbolId = Symbols[i];
                barInfo.BarRecord = lstBarRecord;

                foreach (BarRecord barRecord in lstBarRecord)
                    barRecord.SymbolId = barInfo.SymbolId;

                messageInfo = new MessageInfo();
                messageInfo.MessageTicks = DateTime.Now.Ticks;
                messageInfo.MessageSubject = DataSource.DataSourceConstants.BAR_RECEIVE;
                messageInfo.Message = barInfo;
                
                ((IDataSource)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.DATA_SOURCE]).Update(this, messageInfo);
            }


            SystemHelper.WriteLog(AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.PROGRAM_ROOT_PATH].ToString() + @"\log",
                                  "[Info]-LoadTradeData-" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "-" + NextExecuteTime.ToString("yyyy/MM/dd HH:mm:ss"));


            SystemHelper.WriteLog(AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.PROGRAM_ROOT_PATH].ToString() + @"\log",
                                  "[Info]-LoadTradeData-" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "-" + NextExecuteTime.ToString("yyyy/MM/dd HH:mm:ss"));
/*
            List<BarRecord> lstBarData;
            Dictionary<string, List<BarRecord>> dicResult = new Dictionary<string, List<BarRecord>>();
            PolarisHistoryQuote quote = new PolarisHistoryQuote();
            try
            {
                foreach (string strSymbolId in SYMBOLS)
                {
                    lstBarData = quote.GetBarData(strSymbolId, CompletedTime, DateTime.Now);
                    dicResult.Add(strSymbolId, lstBarData);
                }

                executeResult = new DefaultExecuteResult();
                executeResult.ReturnCode = 0;
                executeResult.ReturnValue = dicResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
 */ 
            return executeResult;
        }
    }
}
