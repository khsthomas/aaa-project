using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Database.Model;

namespace AAA.TradingTool.Model
{
    public class TradingDefaultModel : DefaultDataModel
    {
        public TradingDefaultModel()
        {
            ParamPrefix = "";
        }
        protected override AAA.Database.IDatabase CreateDatabase(string strDatabaseName)
        {
            return DataBuilder.CreateDatabase(strDatabaseName);
        }
    }
}
