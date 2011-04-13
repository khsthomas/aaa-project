using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AAA.AGS.DataSource
{
    public abstract class AbstractRTDataSource : IRTDataSource
    {
        private string _strStatus;
        private string _strName;
        private DataReceiveEvent _dataReceiveEvent;
        private DataStoreEvent _dataStoreEvent;

        #region IDataSourceInfo Members

        public string Status
        {
            get { return _strStatus; }
            set { _strStatus = value;}
        }

        public string Name
        {
            get { return _strName; }
            set { _strName = value; }
        }

        #endregion

        #region IRTDataSource Members
        public DataReceiveEvent DataReceiveEvent
        {
            get { return _dataReceiveEvent; }
            set { _dataReceiveEvent = value; }
        }

        public DataStoreEvent DataStoreEvent
        {
            get { return _dataStoreEvent; }
            set { _dataStoreEvent = value; }
        }
        public void OnDataReceive(object oData)
        {
            if (DataReceiveEvent != null)
                DataReceiveEvent(oData);
        }

        public void OnDataStore(object oData)
        {
            if (DataStoreEvent != null)
                DataStoreEvent(oData);
        }

        public abstract void StartReteive();
        public abstract void StopReteive();
        public abstract void Quote();

        #endregion
    }
}
