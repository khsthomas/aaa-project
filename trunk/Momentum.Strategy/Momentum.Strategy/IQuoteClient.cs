using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.DesignPattern.Observer;

namespace Momentum.Strategy
{
    public interface IQuoteClient : ISubject
    {
        bool StartQuote();
        bool StopQuote();
        bool IsStarted { get; }
    }
}
