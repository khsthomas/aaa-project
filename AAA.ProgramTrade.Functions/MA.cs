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
                // 取得參數 Len 的值
                int iLen = (int)Variable("Len");
                float fSum = 0;

                // 計算收盤價的和
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

                // 計算平均值
                barRecord["MA"] = fSum / iLen;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return barRecord;
        }
    }
}
