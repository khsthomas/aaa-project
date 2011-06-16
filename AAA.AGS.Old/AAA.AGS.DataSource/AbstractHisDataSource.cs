﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Meta.Quote.Data;
using AAA.Meta.Chart.Data;

namespace AAA.AGS.DataSource
{
    public abstract class AbstractHisDataSource : IHisDataSource
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


        #region IHisDataSource Members
        public abstract List<BarRecord> GetData(Dictionary<string, string> queryProperties);
        public abstract List<T> GetData<T>(Dictionary<string, string> queryProperties);

        #endregion

    }
}
