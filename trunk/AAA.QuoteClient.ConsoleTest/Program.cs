using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Meta.Quote.Data;

namespace AAA.QuoteClient.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            DefaultQuoteClient quoteClient = new DefaultQuoteClient();


            List<string> lstSymbolId = quoteClient.GetAvailableSymbolId();
            List<TickInfo> lstTodayTick;

            foreach (string strSymbolId in lstSymbolId)
            {
                lstTodayTick = quoteClient.GetTodayTick(strSymbolId);

                foreach (TickInfo tickInfo in lstTodayTick)
                    Console.WriteLine(tickInfo.Id + "," + tickInfo.Ticks);

            }
        }
    }
}
