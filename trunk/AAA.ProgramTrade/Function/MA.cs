using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.TradeLanguage;
using AAA.Meta.Quote.Data;

namespace AAA.ProgramTrade.Function
{
    public class MA : AbstractFunction
    {
        public override BarRecord ExecCalculate()
        {
            BarRecord barRecord = null;
            try
            {
                barRecord.V0 = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return barRecord;
        }
    }
}
