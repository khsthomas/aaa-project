using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace AAA.TradeAPI.SPF
{
    public class OrderStatusTaiwanStructure : SPFStructure
    {
        /*
             查詢委託回報
        */
        [DllImport("t4.dll")]
        public static extern string get_response();

        public OrderStatusTaiwanStructure()
        {
            ClientName = "get_response";
            DisplayName = "國內下(刪)單回報查詢";

            AddParam(BaseStructure.OUTPUT_PARENT, "Count", "string", 5);

            AddParam(BaseStructure.OUTPUT_CHILDREN, "Type", "string", 2);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "CancelQty", "string", 5);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "ContractQty", "string", 5);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "OrgPrice", "string", 9);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "Seq", "string", 8);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "Account", "string", 15);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "OrderNo", "string", 5);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "OrderSeq", "string", 6);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "Code", "string", 10);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "TradeType", "string", 3);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "TradeClass", "string", 2);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "Price", "string", 9);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "ContractPrice", "string", 9);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "OrderKind", "string", 3);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "Qty", "string", 5);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "TransTime", "string", 6);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "StatusMessage", "string", 20);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "ErrorCode", "string", 4);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "ErrorMessage", "string", 60);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "WebId", "string", 3);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "AccountS", "string", 15);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "OCT", "string", 1);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "OrderTime", "string", 6);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "AgentId", "string", 6);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "PriceType", "string", 1);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "TrfField", "string", 4);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "MatchSeq", "string", 8);
        }

        public override string Invoke(Dictionary<string, object> dicValue)
        {
            return get_response();
        }
    }
}
