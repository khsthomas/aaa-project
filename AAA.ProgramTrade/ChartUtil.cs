using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Chart.Component;
using AAA.Meta.Quote.Data;

namespace AAA.ProgramTrade
{
    public class ChartUtil
    {
        public static void FillRecord(string strSymbolId, ChartPane cpChart, List<BarRecord> lstBarRecord)
        {
            FillRecord(strSymbolId, cpChart, lstBarRecord, DateTime.MinValue, DateTime.MaxValue);
        }

        public static void FillRecord(string strSymbolId, ChartPane cpChart, List<BarRecord> lstBarRecord, DateTime dtStartTime, DateTime dtEndTime)
        {            
            AAA.Meta.Chart.Data.BarData barData = new AAA.Meta.Chart.Data.BarData();

            for (int i = 0; i < lstBarRecord.Count; i++)
            {
                if ((lstBarRecord[i].BarDateTime < dtStartTime) ||
                   (lstBarRecord[i].BarDateTime > dtEndTime))
                    continue;

                barData.AddData(lstBarRecord[i].BarDateTime,
                                lstBarRecord[i]["Open"],
                                lstBarRecord[i]["High"],
                                lstBarRecord[i]["Low"],
                                lstBarRecord[i]["Close"],
                                lstBarRecord[i]["Volume"]);
            }

            cpChart.ChartContainer.AddSymbol(strSymbolId, barData);

        }
    }
}
