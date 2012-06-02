using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Trade;
using AAA.SPFTrade;

namespace AAA.ProgramTrade
{
    public class SystemHelper
    {
        public static ITrade CreateTrade()
        {
            return new SPFTradeImp();
        }
    }
}
