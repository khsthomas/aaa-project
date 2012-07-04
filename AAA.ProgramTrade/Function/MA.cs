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
        public MA(BarCompression barCompression) : base(barCompression)
        {
        }

        public override BarRecord ExecCalculate()
        {
            BarRecord barRecord = null;
            try
            {
                int iLen = (int)Variable("Len");
                string strSymbolId = (string)Variable("SymbolId");
                float fSum = 0;

                for (int i = 0; i < iLen; i++)
                    fSum += Close(strSymbolId, i);

                barRecord.V0 = fSum / iLen;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return barRecord;
        }
    }
}
