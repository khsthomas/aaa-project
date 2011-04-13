using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AAA.AGS.DataSource
{
    public interface IRTDataSource : IDataSourceInfo
    {
        void OnDataReceive(object oData);
        void OnDataStore(object oData);
        void StartReteive();
        void StopReteive();
        void Quote();

        DataReceiveEvent DataReceiveEvent { get; set; }
        DataStoreEvent DataStoreEvent { get; set; }
    }
}
