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
            InputVariableNames = new string[] { "TransferSymbolId", "Len" };
            InputVariableDescs = new string[] { "計算後商品名稱", "長度" };
            DefaultValues = new object[] { "", 3 };
        }

        public override BarRecord ExecCalculate()
        {
            BarRecord barRecord = new BarRecord();
            float fClose;
            try
            {
                // 取得參數 Len 的值
                int iLen = (int)InputVariable("Len");
                float fSum = 0;

                // 計算收盤價的和
                for (int i = 0; i < iLen; i++)
                {
                    // 取得往前i根K棒的收盤價
                    fClose = Close(BaseSymbolId, i);

                    //判斷收盤價是否有值, 在K棒數小於所要取的i時, 會回傳NaN
                    if (float.IsNaN(fClose))
                    {
                        fSum = 0;
                        break;
                    }
                    fSum += fClose;
                }

                // 計算平均值, 並把值放進此根K棒的運算資料中
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
