using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AAA.AGS.DataSource
{
    public interface IDataSource : IDataSourceInfo, IRTDataSource, IHisDataSource, ITransactionInfo
    {
        IRTDataSource RealtimeDataSource { get; set; }
        IHisDataSource HistoricalDataSource { get; set; }
        IPriceVolumeDataSource PriceVolumeDataSource { get; set; }
        ITransactionInfo TransactionInfo { get; set; }
    }
}
