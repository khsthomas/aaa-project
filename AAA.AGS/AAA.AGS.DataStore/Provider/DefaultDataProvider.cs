using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Meta.Quote.Data;
using AAA.Base.Util.SafeCollection;

namespace AAA.AGS.DataStore.Provider
{
    public class DefaultDataProvider : IDataProvider
    {
        #region IDataProvider Members

        private Dictionary<string, int> _dicLastTickIndex;
        private Dictionary<string, int> _dicLastMinuteIndex;
        private Dictionary<string, int> _dicLastPriceVolumeIndex;

        public DefaultDataProvider()
        {
            _dicLastTickIndex = new Dictionary<string, int>();
            _dicLastMinuteIndex = new Dictionary<string, int>();
            _dicLastPriceVolumeIndex = new Dictionary<string, int>();
        }

        public List<TickInfo> GetLastTicks()
        {
            List<TickInfo> lstReturnTickInfo = new List<TickInfo>();
            List<TickInfo> lstTickInfo;

            for(int i = 0; i < DataTable.Instance().GetAvailableSymbolId().Count; i++)
            {
                lstTickInfo = GetLastTicks(DataTable.Instance().GetAvailableSymbolId()[i]);
                for (int j = 0; j < lstTickInfo.Count; j++)
                    lstReturnTickInfo.Add(lstTickInfo[j]);

            }
            return lstReturnTickInfo;
        }

        public List<TickInfo> GetLastTicks(string strSymbolId)
        {
            List<TickInfo> lstTicks;

            if (_dicLastTickIndex.ContainsKey(strSymbolId) == false)
                _dicLastTickIndex.Add(strSymbolId, 0);

            lstTicks = DataTable.Instance().GetTicks(_dicLastTickIndex[strSymbolId], strSymbolId);

            _dicLastTickIndex[strSymbolId] += lstTicks.Count;
            return lstTicks;
        }

        public List<BarData> GetLastMinuteData()
        {
            List<BarData> lstReturnMinuteInfo = new List<BarData>();
            List<BarData> lstMinuteInfo;

            for (int i = 0; i < DataTable.Instance().GetAvailableSymbolId().Count; i++)
            {
                lstMinuteInfo = GetLastMinuteData(DataTable.Instance().GetAvailableSymbolId()[i]);
                for (int j = 0; j < lstMinuteInfo.Count; j++)
                    lstReturnMinuteInfo.Add(lstMinuteInfo[j]);

            }
            return lstReturnMinuteInfo;
        }

        public List<BarData> GetLastMinuteData(string strSymbolId)
        {
            List<BarData> lstMinutes;

            if (_dicLastMinuteIndex.ContainsKey(strSymbolId) == false)
                _dicLastMinuteIndex.Add(strSymbolId, 0);

            lstMinutes = DataTable.Instance().GetMinutes(_dicLastMinuteIndex[strSymbolId], strSymbolId);

            _dicLastMinuteIndex[strSymbolId] += lstMinutes.Count;
            return lstMinutes;
        }

        public List<PriceVolumeData> GetLastPriceVolumeData()
        {
            List<PriceVolumeData> lstReturnMinuteInfo = new List<PriceVolumeData>();
            List<PriceVolumeData> lstMinuteInfo;

            for (int i = 0; i < DataTable.Instance().GetAvailableSymbolId().Count; i++)
            {
                lstMinuteInfo = GetLastPriceVolumeData(DataTable.Instance().GetAvailableSymbolId()[i]);
                for (int j = 0; j < lstMinuteInfo.Count; j++)
                    lstReturnMinuteInfo.Add(lstMinuteInfo[j]);

            }
            return lstReturnMinuteInfo;
        }

        public List<PriceVolumeData> GetLastPriceVolumeData(string strSymbolId)
        {
            List<PriceVolumeData> lstMinutes;

            if (_dicLastPriceVolumeIndex.ContainsKey(strSymbolId) == false)
                _dicLastPriceVolumeIndex.Add(strSymbolId, 0);

            lstMinutes = DataTable.Instance().GetPriceVolumes(_dicLastPriceVolumeIndex[strSymbolId], strSymbolId);

            _dicLastPriceVolumeIndex[strSymbolId] += lstMinutes.Count;
            return lstMinutes;
        }


        #endregion
    }
}
