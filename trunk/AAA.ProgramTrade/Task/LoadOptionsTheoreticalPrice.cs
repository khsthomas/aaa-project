using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Schedule;
using AAA.ProgramTrade.Quote;
using AAA.Meta.Quote.Data;
using AAA.Base.Util.Reader;
using AAA.TradeLanguage;
using AAA.DataSource;

namespace AAA.ProgramTrade.Task
{
    public class LoadOptionsTheoreticalPrice : AbstractQuoteTask
    {
        public LoadOptionsTheoreticalPrice()
        {
            InitQuote();
        }

        public override IExecuteResult Execute(Dictionary<string, object> dicData)
        {
            IExecuteResult executeResult = null;
            Dictionary<string, List<BarRecord>> dicBarRecord;
            DateTime dtEndDate = DateTime.Now;
            DateTime dtStartDate = SystemHelper.ShiftTradingDay(dtEndDate, -5);

            HistoryQuote.InitProgram(Param);

            dicBarRecord = HistoryQuote.GetBarRecord("OptionsTheroreticalPrice", "f2", dtStartDate, dtEndDate);

            foreach (string strSymbolCode in dicBarRecord.Keys)
            {
                ((IDataSource)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.DATA_SOURCE]).AddSymbol(strSymbolCode, dicBarRecord[strSymbolCode]);
            }
            

            SystemHelper.WriteLog(AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.PROGRAM_ROOT_PATH].ToString() + @"\log",
                                  "[Info]-LoadOptionsTheoreticalPrice-" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "-" + NextExecuteTime.ToString("yyyy/MM/dd HH:mm:ss"));
            return executeResult;
        }
    }
}
