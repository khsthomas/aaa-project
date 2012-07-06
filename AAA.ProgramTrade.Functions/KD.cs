using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.TradeLanguage;
using AAA.Meta.Quote.Data;

namespace AAA.ProgramTrade.Functions
{
    public class KD : AbstractFunction
    {
        public KD()
        {
            DisplayName = "KD";
            VariableNames = new string[] { "Transfer Symbol Id", "Len"};
            VariableDescs = new string[] { "計算後商品名稱", "長度"};
            DefaultValues = new object[] { "", 9};
        }

        public override AAA.Meta.Quote.Data.BarRecord ExecCalculate()
        {
            BarRecord barRecord = null;
            BarRecord previousBar = null;
            try
            {                
                int iLen = (int)Variable("Len");
                float fRSV;
                float fHigh;
                float fLow;
                

                fHigh = float.MinValue;
                fLow = float.MaxValue;

                for (int i = 0; i < iLen; i++)
                {
                    fHigh = (High(i) > fHigh) ? High(i) : fHigh;
                    fLow = (Low(i) < fLow) ? Low(i) : fLow;
                }

                fRSV = (Close(0) - fLow) / (fHigh - fLow);

                if((previousBar = Bar(1)) == null)
                {
                    previousBar = new BarRecord();
                    previousBar.V0 = 50;
                    previousBar.V1 = 50;
                }

                barRecord.V0 = (float)(previousBar.V0 * (1.0 / 3 * fRSV));
                barRecord.V1 = (float)(previousBar.V1 * (1.0 / 3 * barRecord.V0));                                   
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return barRecord;
        }
    }
}
