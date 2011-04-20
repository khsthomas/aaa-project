using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Meta.Quote.Data;
using AAA.Meta.Quote;
using AAA.Base.Util.SafeCollection;

namespace AAA.QuoteClient
{    
    public interface IQuoteClient
    {
        bool StartQuote();
        bool StopQuote();
        List<string> GetAvailableSymbolId();
        List<BarData> GetBarData(Dictionary<string, string> queryProperty);
        List<PriceVolumeData> GetPriceVolumeData(Dictionary<string, string> queryProperty);
        List<TickInfo> GetTodayTick(string strSymbolId);        
    }
}
