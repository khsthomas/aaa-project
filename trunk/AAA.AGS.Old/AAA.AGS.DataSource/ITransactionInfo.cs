using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Meta.Chart.Data;

namespace AAA.AGS.DataSource
{
    public interface ITransactionInfo : IDataSourceInfo
    {
        List<DateInfo> GetTransactionDay();
    }
}
