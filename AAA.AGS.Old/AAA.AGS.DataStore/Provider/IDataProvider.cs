using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Meta.Quote.Data;

namespace AAA.AGS.DataStore.Provider
{
    public interface IDataProvider
    {
        List<TickInfo> GetLastTicks();
        List<BarData> GetLastMinuteData();
        List<PriceVolumeData> GetLastPriceVolumeData();
    }
}
