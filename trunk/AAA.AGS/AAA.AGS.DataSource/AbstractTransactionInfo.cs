using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Meta.Chart.Data;

namespace AAA.AGS.DataSource
{
    public abstract class AbstractTransactionInfo : ITransactionInfo
    {
        private string _strStatus;
        private string _strName;

        #region IDataSourceInfo Members

        public string Status
        {
            get { return _strStatus; }
            set { _strStatus = value; }
        }

        public string Name
        {
            get { return _strName; }
            set { _strName = value; }
        }

        #endregion

        #region ITransactionInfo Members

        public abstract List<DateInfo> GetTransactionDay();
        #endregion


    }
}
