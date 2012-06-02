using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AAA.ProgramTrade.data
{    
    public class ContractInfo
    {
        private int _iYear;

        public int Year
        {
            get { return _iYear; }
            set { _iYear = value; }
        }
        private int _iMonth;

        public int Month
        {
            get { return _iMonth; }
            set { _iMonth = value; }
        }
    }
}
