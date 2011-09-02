using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AAA.TradingSystem.Indicator
{
    public class MAArrange : AbstractIndicator
    {
        public override bool Calculate(int iIndicatorIndex, List<string> lstField, List<string[]> lstData)
        {
            int iShortMAIndex = -1;
            int iLongMAIndex = -1;
            try
            {

                iShortMAIndex = lstField.IndexOf("MA5");
                iLongMAIndex = lstField.IndexOf("MA10");

                Data = lstData;

                for (int i = 0; i < lstData.Count; i++)
                {
                    if ((lstData[i][iShortMAIndex] == "") ||
                       (lstData[i][iLongMAIndex] == ""))
                        continue;

                    RowIndex = i;
                    //多頭排列
                    if ((float.Parse(lstData[i][iShortMAIndex]) > float.Parse(lstData[i][iLongMAIndex])))
                    {
                        //Indicator Light
                        SetIndicatorLight(iIndicatorIndex, "red");
                        //Remark 
                        SetIndicatorRemark(iIndicatorIndex, 0, "MA Bullish");
                    }

                    //空頭排列
                    if ((float.Parse(lstData[i][iShortMAIndex]) < float.Parse(lstData[i][iLongMAIndex])))
                    {
                        //Indicator Light
                        SetIndicatorLight(iIndicatorIndex, "green");
                        //Remark 
                        SetIndicatorRemark(iIndicatorIndex, 0, "MA Bearish");
                    }

                }
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message + "," + ex.StackTrace;
                return false;
            }
            return false;
        }
    }
}
