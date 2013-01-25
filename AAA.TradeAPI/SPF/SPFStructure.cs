using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AAA.TradeAPI.SPF
{
    public abstract class SPFStructure : BaseStructure
    {
        public abstract string Invoke(Dictionary<string, object> dicValue);
    }


}
