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
            InputVariableNames = new string[] { "TransferSymbolId", "Len"};
            InputVariableDescs = new string[] { "計算後商品名稱", "長度" };
            DefaultValues = new object[] { "", 9};
        }

        public override AAA.Meta.Quote.Data.BarRecord ExecCalculate()
        {
            BarRecord barRecord = new BarRecord();
            BarRecord previousBar = null;
            try
            {           
                // 取得參數 Len 的值
                int iLen = (int)InputVariable("Len");
                float fRSV;
                float fHigh;
                float fLow;
                

                fHigh = float.MinValue;
                fLow = float.MaxValue;

                // 計算時間內的最高, 最低價
                for (int i = 0; i < iLen; i++)
                {
                    fHigh = (High(i) > fHigh) ? High(i) : fHigh;
                    fLow = (Low(i) < fLow) ? Low(i) : fLow;
                }

                // 計算RSV
                fRSV = (Close(0) - fLow) / (fHigh - fLow);

                // 取得前一個K, D值, 若當根Bar為第一根, 則K, D值均給50
                if((previousBar = Bar(1)) == null)
                {
                    previousBar = new BarRecord();
                    previousBar["K"] = 50;
                    previousBar["D"] = 50;
                }

                // 計筫K, D值
                barRecord["K"] = (float)(previousBar["K"] * (1.0 / 3 * fRSV));
                barRecord["D"] = (float)(previousBar["D"] * (1.0 / 3 * barRecord["K"]));                                   
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return barRecord;
        }
    }
}
