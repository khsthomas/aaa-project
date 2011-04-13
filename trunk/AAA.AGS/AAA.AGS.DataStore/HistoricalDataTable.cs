using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.AGS.DataSource;
using AAA.Meta.Quote.Data;
using AAA.Meta.Chart.Data;

namespace AAA.AGS.DataStore
{
    public sealed class HistoricalDataTable
    {
        private static HistoricalDataTable _instance;
        private Dictionary<string, IHisDataSource> _dicSymbol;
        private Dictionary<string, IPriceVolumeDataSource> _dicPriceVolume;
        private Dictionary<string, DateInfo> _dicTransactionDay;
        private List<string> _lstDate;

        private HistoricalDataTable()
        {
            _dicSymbol = new Dictionary<string, IHisDataSource>();
            _dicPriceVolume = new Dictionary<string, IPriceVolumeDataSource>();
            _dicTransactionDay = new Dictionary<string, DateInfo>();
            _lstDate = new List<string>();
        }

        public static HistoricalDataTable Instance()
        {
            if (_instance == null)
                _instance = new HistoricalDataTable();

            return _instance;
        }

        public void SetDataSource(string strSymbolId, IHisDataSource dataSource)
        {
            if (_dicSymbol.ContainsKey(strSymbolId))
                _dicSymbol[strSymbolId] = dataSource;
            else
                _dicSymbol.Add(strSymbolId, dataSource);
        }

        public void SetPriceVolume(string strSymbolId, IPriceVolumeDataSource dataSource)
        {
            if (_dicPriceVolume.ContainsKey(strSymbolId))
                _dicPriceVolume[strSymbolId] = dataSource;
            else
                _dicPriceVolume.Add(strSymbolId, dataSource);
        }

        public List<BarRecord> GetData(Dictionary<string, string> queryProperties)
        {
            return _dicSymbol[queryProperties["SymbolId"]].GetData(queryProperties);
        }

        public Dictionary<string, AAA.Meta.Chart.Data.PriceVolumeData> GetPriceVolume(Dictionary<string, string> queryProperties)
        {
            return _dicPriceVolume[queryProperties["SymbolId"]].GetPriceVolume(queryProperties);
        }

        public void AddTransactionDay(DateInfo dateInfo)
        {
            if (_lstDate.IndexOf(dateInfo.Date) < 0)
            {
                _lstDate.Add(dateInfo.Date);
                _dicTransactionDay.Add(dateInfo.Date, dateInfo);
                _lstDate.Sort();
            }
        }

        public List<DateInfo> GetTransactionDay()
        {
            List<DateInfo> lstTransactionDay = new List<DateInfo>();

            foreach (string strDate in _lstDate)
                lstTransactionDay.Add(_dicTransactionDay[strDate]);

            return lstTransactionDay;
        }
        
    }
}
