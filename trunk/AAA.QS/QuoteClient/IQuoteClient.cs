using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Meta.Quote.Data;
using AAA.Meta.Quote;

namespace QuoteClient
{    
    public interface IQuoteClient
    {
        bool StartQuote();
        bool StopQuote();
        List<BarData> GetBarData(Dictionary<string, string> queryProperty);
        List<PriceVolumeData> GetPriceVolumeData(Dictionary<string, string> queryProperty);
        List<TickData> GetTodayTick(string strSymbolId);        
    }
}
