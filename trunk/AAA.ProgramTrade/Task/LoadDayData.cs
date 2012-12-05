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
    public class LoadDayData : AbstractQuoteTask
    {
/*
        private static string[] _strAPISymbols;

        public static string[] APISymbols
        {
            get { return LoadDayData._strAPISymbols; }
            set { LoadDayData._strAPISymbols = value; }
        }
        private static string[] _strSymbols;

        public static string[] Symbols
        {
            get { return LoadDayData._strSymbols; }
            set { LoadDayData._strSymbols = value; }
        }

        private PolarisHistoryQuote _historyQuote;

        public PolarisHistoryQuote HistoryQuote
        {
            get { return _historyQuote; }
            set { _historyQuote = value; }
        }
        private Dictionary<string, object> _dicParam;

        public Dictionary<string, object> Param
        {
            get { return _dicParam; }
            set { _dicParam = value; }
        }
*/
        public LoadDayData()
        {
            InitQuote();            
        }
/*
        private void InitQuote()
        {
            IniReader iniReader = null;
            _dicParam = new Dictionary<string, object>();
            
            try
            {
                iniReader = new IniReader(AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.PROGRAM_ROOT_PATH] +
                                          @"\cfg\system.ini");

                _strAPISymbols = iniReader.GetParam("Quote", "APISymbol").Split(',');
                _strSymbols = iniReader.GetParam("Quote", "Symbol").Split(',');

                _dicParam.Add("AccountType", iniReader.GetParam("Account", "AccountType"));
                _dicParam.Add("AccountNo", iniReader.GetParam("Account", "AccountNo"));
                _dicParam.Add("Password", iniReader.GetParam("Account", "Password"));                

                _historyQuote = new PolarisHistoryQuote();                

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
*/
        public override IExecuteResult Execute(Dictionary<string, object> dicData)
        {
            IExecuteResult executeResult = null;
            List<BarRecord> lstBarRecord;
            DateTime dtEndDate = DateTime.Now;
            DateTime dtStartDate = SystemHelper.ShiftTradingDay(dtEndDate, -5);

            HistoryQuote.InitProgram(Param);

            for (int i = 0; i < APISymbols.Length; i++)
            {
                lstBarRecord = HistoryQuote.GetBarData(APISymbols[i], dtStartDate, dtEndDate);
                foreach (BarRecord barRecord in lstBarRecord)
                    barRecord.SymbolId = Symbols[i];

                ((IDataSource)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.DATA_SOURCE]).AddSymbol(Symbols[i], lstBarRecord);
            }            

            SystemHelper.WriteLog(AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.PROGRAM_ROOT_PATH].ToString() + @"\log",
                                  "[Info]-LoadDayData-" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "-" + NextExecuteTime.ToString("yyyy/MM/dd HH:mm:ss"));
/*
            List<BarRecord> lstBarData;
            Dictionary<string, List<BarRecord>> dicResult = new Dictionary<string, List<BarRecord>>();
            PolarisHistoryQuote quote = new PolarisHistoryQuote();
            try
            {
                foreach (string strSymbolId in SYMBOLS)
                {
                    lstBarData = quote.GetBarData(strSymbolId, _dtStartTime, DateTime.Now);
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
