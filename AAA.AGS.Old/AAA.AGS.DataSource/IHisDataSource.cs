using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Meta.Quote.Data;
using AAA.Meta.Chart.Data;

namespace AAA.AGS.DataSource
{
    public interface IHisDataSource : IDataSourceInfo
    {
        List<BarRecord> GetData(Dictionary<string, string> queryProperties);
        List<T> GetData<T>(Dictionary<string, string> queryProperties);
    }
}
