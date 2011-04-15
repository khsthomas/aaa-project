using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Meta.Quote.Data;
using AAA.Base.Util.SafeCollection;
using AAA.QuoteClient;

namespace AAA.AGS.DataStore.Provider
{
    public class ActiveMQDataProvider : IDataProvider
    {
        #region IDataProvider Members

        private Dictionary<string, string> _dicLastTickIndex;
        private Dictionary<string, string> _dicLastMinuteIndex;
        private Dictionary<string, string> _dicLastPriceVolumeIndex;
        private IQuoteClient _qcDataClient;

        public ActiveMQDataProvider()
        {
            _dicLastTickIndex = new Dictionary<string, string>();
            _dicLastMinuteIndex = new Dictionary<string, string>();
            _dicLastPriceVolumeIndex = new Dictionary<string, string>();
            _qcDataClient = new DefaultQuoteClient();
            _qcDataClient.StartQuote();
        }

        public List<TickInfo> GetLastTicks()
        {
            List<TickInfo> lstReturnTickInfo = new List<TickInfo>();
            List<TickInfo> lstTickInfo;

            for(int i = 0; i < _qcDataClient.GetAvailableSymbolId().Count; i++)
            {
                lstTickInfo = GetLastTicks(_qcDataClient.GetAvailableSymbolId()[i]);
                for (int j = 0; j < lstTickInfo.Count; j++)
                    lstReturnTickInfo.Add(lstTickInfo[j]);

            }
            return lstReturnTickInfo;
        }

        public List<TickInfo> GetLastTicks(string strSymbolId)
        {
            List<TickInfo> lstTicks;

            lstTicks = _qcDataClient.GetTodayTick(strSymbolId);

            return lstTicks;
        }

        public List<BarData> GetLastMinuteData()
        {
            List<BarData> lstReturnMinuteInfo = new List<BarData>();
            /*
             List<BarData> lstMinuteInfo;

            for (int i = 0; i < _qcDataClient.GetAvailableSymbolId().Count; i++)
            {
                lstMinuteInfo = GetLastMinuteData(_qcDataClient.GetAvailableSymbolId()[i]);
                for (int j = 0; j < lstMinuteInfo.Count; j++)
                    lstReturnMinuteInfo.Add(lstMinuteInfo[j]);

            }
             */
            return lstReturnMinuteInfo;
        }

        public List<BarData> GetLastMinuteData(string strSymbolId)
        {
            List<BarData> lstMinutes = new List<BarData>();
            /*
            if (_dicLastMinuteIndex.ContainsKey(strSymbolId) == false)
                _dicLastMinuteIndex.Add(strSymbolId, 0);

            lstMinutes = _qcDataClient. DataTable.Instance().GetMinutes(_dicLastMinuteIndex[strSymbolId], strSymbolId);

            _dicLastMinuteIndex[strSymbolId] += lstMinutes.Count;
            */ 
            return lstMinutes;
        }

        public List<PriceVolumeData> GetLastPriceVolumeData()
        {
            List<PriceVolumeData> lstReturnMinuteInfo = new List<PriceVolumeData>();
            /*List<PriceVolumeData> lstMinuteInfo;
            
            for (int i = 0; i < _qcDataClient.GetAvailableSymbolId().Count; i++)
            {
                lstMinuteInfo = GetLastPriceVolumeData(_qcDataClient.GetAvailableSymbolId()[i]);
                for (int j = 0; j < lstMinuteInfo.Count; j++)
                    lstReturnMinuteInfo.Add(lstMinuteInfo[j]);

            }
             */
            return lstReturnMinuteInfo;
        }

        public List<PriceVolumeData> GetLastPriceVolumeData(string strSymbolId)
        {
            List<PriceVolumeData> lstMinutes = new List<PriceVolumeData>();

         /*   if (_dicLastPriceVolumeIndex.ContainsKey(strSymbolId) == false)
                _dicLastPriceVolumeIndex.Add(strSymbolId, 0);

            lstMinutes = _qcDataClient.GetPriceVolumeData(_dicLastPriceVolumeIndex);

            _dicLastPriceVolumeIndex[strSymbolId] += lstMinutes.Count;
         */
           return lstMinutes;
        }
        
        public void Dispose() {
            _qcDataClient.StopQuote();
        }

        #endregion
    }
}
