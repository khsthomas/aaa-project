using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace AAA.TradingTool.Model
{
    public class TW_Trans_D_EquitySummary : TradingDefaultModel
    {
        public TW_Trans_D_EquitySummary()
        {
            PrimaryKeys = new string[] { "ExDate", "AccountNo" };
            TableName = "TW_Trans_D_EquitySummary";
            Fields = new string[] { "ProfitQty", "ClearQty", "Fee", "Tax", "FCon", "FMiss", "OMiss", "InOut", "OSecuAmt", 
                                    "USecuAmt", "RiskStatus", "BidQty", "AskQty", "OGain" };
            DataTypes = new DbType[] {DbType.DateTime, DbType.String,
                                      DbType.Double, DbType.Double, DbType.Double, DbType.Double, DbType.Double, DbType.Double, DbType.Double, DbType.Double, DbType.Double,
                                      DbType.Double, DbType.Double, DbType.Double, DbType.Double, DbType.Double};
        }

        public override AAA.Database.Model.IDataModel CreateInstance()
        {
            return new TW_Trans_D_EquitySummary();
        }
    }
}
