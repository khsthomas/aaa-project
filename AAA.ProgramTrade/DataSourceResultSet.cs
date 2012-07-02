using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.ResultSet;
using AAA.Meta.Quote.Data;

namespace AAA.ProgramTrade
{
    public class DataSourceResultSet : AbstractResultSet
    {
        private List<BarRecord> _lstBarData;
        private static string[] COLUMN_NAMES = {"ExDate", "Open", "High", "Low", "Close", "Volume", "Amount" };

        public DataSourceResultSet(List<BarRecord> lstBarData)
        {
            _lstBarData = lstBarData;
        }

        public override bool Load()
        {
            BarData barData;
            try
            {
                foreach (string strColumnName in COLUMN_NAMES)
                    AddColumn(strColumnName);

                foreach (BarRecord barRecord in _lstBarData)
                {
                    barData = new BarData(barRecord);
                    AddRow(new object[] { barData.BarDateTime.ToString("yyyy/MM/dd HH:mm:ss"),
                                          barData.Open.ToString(),
                                          barData.High.ToString(),
                                          barData.Low.ToString(),
                                          barData.Close.ToString(),
                                          barData.Volume.ToString(),
                                          barData.Amount.ToString()});
                }
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message + "," + ex.StackTrace;
                throw ex;
            }

            return false;
        }

    }
}
