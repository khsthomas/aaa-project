using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AAA.TradingTool.Model
{
    public class TW_Trans_D_OrderHistory : TradingDefaultModel
    {
        public TW_Trans_D_OrderHistory()
        {
            PrimaryKeys = new string[] { "ExDateTime", "SymbolType", "Seq" };
            TableName = "TW_Trans_D_OrderHistory";
            Fields = new string[] { "CancelQty", "ContractQty", "OrgPrice", "AccountNo", "OrderNo", "OrderSeq", "SymbolId", "TradeType", 
                                    "TradeClass", "TrustPrice", "DealPrice", "OrderKind", "Qty", "TransTime", "StatusMessage", "ErrorCode", 
                                    "ErrorMessage", "WebId", "AccountS", "OCT", "OrderTime", "AgentId", "PriceType", "TrfField", "MatchSeq" };
        }

        public override AAA.Database.Model.IDataModel CreateInstance()
        {
            return new TW_Trans_D_OrderHistory();
        }
    }
}
