using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.TradeLanguage;
using AAA.Meta.Quote.Data;

namespace AAA.ProgramTrade.Function
{
    public class Functions : AbstractFunction
    {
        public Functions(BarCompression barCompression) : base(barCompression)
        {
            DisplayName = "MA";
            VariableNames = new string[] { "SymbolId", "Len" };
            VariableDescs = new string[] { "商品名稱", "長度"};
            DefaultValues = new object[] { "", 3 };
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
