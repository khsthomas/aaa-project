using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Quote;

namespace AAA.ProgramTrade.Quote
{
    public class PolarisHistoryQuote : AbstractHistoryQuote
    {

        public override List<AAA.Meta.Quote.Data.BarData> GetBarData(string strSymbolId)
        {
            throw new NotImplementedException();
        }

        public override List<AAA.Meta.Quote.Data.BarData> GetBarData(string strSymbolId, DateTime dtStartTime, DateTime dtEndTime)
        {
            throw new NotImplementedException();
        }
    }
}
