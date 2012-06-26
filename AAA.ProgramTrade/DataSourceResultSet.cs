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
        private List<BarData> _lstBarData;
        private static string[] COLUMN_NAMES = {"ExDate", "Open", "High", "Low", "Close", "Volume", "Amount" };

        public DataSourceResultSet(List<BarData> lstBarData)
        {
            _lstBarData = lstBarData;
        }

        public override bool Load()
        {
            try
            {
                foreach (string strColumnName in COLUMN_NAMES)
                    AddColumn(strColumnName);

                foreach (BarData barData in _lstBarData)
                    AddRow(new object[] { barData.BarDateTime.ToString("yyyy/MM/dd HH:mm:ss"),
                                          barData.Open,
                                          barData.High,
                                          barData.Low,
                                          barData.Close,
                                          barData.Volume,
                                          barData.Amount});
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
