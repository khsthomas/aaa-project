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
        public MA()
        {
            DisplayName = "MA";
            VariableNames = new string[] { "TransferSymbolId", "Len" };
            VariableDescs = new string[] { "計算後商品名稱", "長度"};
            DefaultValues = new object[] { "", 3 };
        }

        public override BarRecord ExecCalculate()
        {
            BarRecord barRecord = new BarRecord();
            float fClose;
            try
            {
                int iLen = (int)Variable("Len");
                float fSum = 0;

                for (int i = 0; i < iLen; i++)
                {
                    fClose = Close(BaseSymbolId, i);
                    if (float.IsNaN(fClose))
                    {
                        fSum = 0;
                        break;
                    }
                    fSum += fClose;
                }

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
