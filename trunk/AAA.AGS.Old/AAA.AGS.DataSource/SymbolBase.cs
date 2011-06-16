using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Meta.Chart.Data;

namespace AAA.AGS.DataSource
{
    public class SymbolBase
    {
        private int _iDateRangeType;
        private int _iDaysBack;
        private string _strFromDate;
        private string _strToDate;
        private List<BarData> _lstBarData;

        public int DateRangeType
        {
            get { return _iDateRangeType; }
            set { _iDateRangeType = value; }
        }

        public int DaysBack
        {
            get { return _iDaysBack; }
            set { _iDaysBack = value; }
        }

        public string FromDate
        {
            get { return _strFromDate; }
            set { _strFromDate = value; }
        }

        public string ToDate
        {
            get { return _strToDate; }
            set { _strToDate = value; }
        }        


    }
}
