using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Meta.Quote.Data;
using AAA.Meta.Chart.Data;

namespace AAA.AGS.DataSource
{
    public class DefaultDataSource : IDataSource
    {
        private IRTDataSource _realtimeDataSource;
        private IHisDataSource _historicalDataSource;
        private IPriceVolumeDataSource _priceVolumeDataSource;
        private ITransactionInfo _transactionInfo;

        private string _strStatus;
        private string _strName;

        #region Attributes
        public DataReceiveEvent DataReceiveEvent
        {
            get { return _realtimeDataSource.DataReceiveEvent; }
            set { _realtimeDataSource.DataReceiveEvent = value; }
        }

        public DataStoreEvent DataStoreEvent
        {
            get { return _realtimeDataSource.DataStoreEvent; }
            set { _realtimeDataSource.DataStoreEvent = value; }
        }

        public IRTDataSource RealtimeDataSource
        {
            get { return _realtimeDataSource; }
            set { _realtimeDataSource = value; }
        }

        public IHisDataSource HistoricalDataSource
        {
            get { return _historicalDataSource; }
            set { _historicalDataSource = value; }
        }

        public IPriceVolumeDataSource PriceVolumeDataSource
        {
            get { return _priceVolumeDataSource; }
            set { _priceVolumeDataSource = value; }
        }

        public ITransactionInfo TransactionInfo
        {
            get { return _transactionInfo; }
            set { _transactionInfo = value; }
        }

        public string Status
        {
            get { return _strStatus; }
            set { _strStatus = value; }
        }

        public string Name
        {
            get { return _strName; }
            set { _strName = value; }
        }
        #endregion

        #region IDataSource Members
        public List<BarRecord> GetData(Dictionary<string, string> queryProperties)
        {
            return _historicalDataSource.GetData(queryProperties);
        }

        public List<T> GetData<T>(Dictionary<string, string> queryProperties)
        {
            return _historicalDataSource.GetData<T>(queryProperties);
        }

        public List<DateInfo> GetTransactionDay()
        {
            return _transactionInfo.GetTransactionDay();
        }

        public void OnDataReceive(object oData)
        {
            _realtimeDataSource.OnDataReceive(oData);
        }
        public void OnDataStore(object oData)
        {
            _realtimeDataSource.OnDataStore(oData);
        }

        public void StartReteive()
        {
            _realtimeDataSource.StartReteive();
        }

        public void StopReteive()
        {
            _realtimeDataSource.StopReteive();
        }

        public void Quote()
        {
            _realtimeDataSource.Quote();
        }
        #endregion
    }
}
