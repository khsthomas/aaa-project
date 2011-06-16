using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Meta.Quote.Data;

namespace AAA.AGS.DataSource
{
    public interface IDataReporter
    {
        bool Report(TickInfo tickInfo);
    }
}
