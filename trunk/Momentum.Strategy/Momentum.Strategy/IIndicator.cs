using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Momentum.Strategy.Meta;
using AAA.DesignPattern.Observer;

namespace Momentum.Strategy
{
    public interface IIndicator : IObserver, ISubject
    {        
        ISignalInfo Compute(List<BarData> barData);
        string Id { get; }
        string DisplayName { get; }

    }
}
