using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Meta.Quote.Data;

namespace AAA.AGS.DataSource
{
    public class DataTableReporter : IDataReporter
    {
        #region IDataReporter Members

        public bool Report(TickInfo tickInfo)
        {
            AAA.AGS.DataStore.DataTable.Instance().SetSymbolSnapshot(tickInfo.Id, tickInfo);
            return true;
        }

        #endregion
    }
}
