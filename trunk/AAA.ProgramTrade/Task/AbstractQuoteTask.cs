using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Schedule;
using AAA.Base.Util.Reader;
using AAA.ProgramTrade.Quote;

namespace AAA.ProgramTrade.Task
{
    public abstract class AbstractQuoteTask : AbstractTask
    {
        private static string[] _strAPISymbols;

        public static string[] APISymbols
        {
            get { return _strAPISymbols; }
            set { _strAPISymbols = value; }
        }
        private static string[] _strSymbols;

        public static string[] Symbols
        {
            get { return _strSymbols; }
            set { _strSymbols = value; }
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


        public AbstractQuoteTask()
        {
            InitQuote();
        }

        protected void InitQuote()
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

        //public abstract IExecuteResult Execute(Dictionary<string, object> dicData);

    }
}
