using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuoteClient
{
    public interface IQuoteClient
    {
        bool StartQuote();
        bool StopQuote();
        List<BarData>
    }
}
