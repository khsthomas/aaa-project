using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace AAA.TradeAPI.SPF
{
    public class OrderStatusForeignStructure : SPFStructure
    {
        /*
            查詢國外委託回報
        */
        [DllImport("t4.dll")]
        public static extern string ff_get_response();

        public OrderStatusForeignStructure()
        {

            ClientName = "ff_get_response";
            DisplayName = "國外下(刪)單回報查詢";

            AddParam(BaseStructure.OUTPUT_PARENT, "Type", "string", 2);
            AddParam(BaseStructure.OUTPUT_PARENT, "CancelQty", "string", 5);
            AddParam(BaseStructure.OUTPUT_PARENT, "ContractQty", "string", 5);
            AddParam(BaseStructure.OUTPUT_PARENT, "OrgPrice", "string", 9);
            AddParam(BaseStructure.OUTPUT_PARENT, "Seq", "string", 8);
            AddParam(BaseStructure.OUTPUT_PARENT, "Account", "string", 15);
            AddParam(BaseStructure.OUTPUT_PARENT, "Ord_No", "string", 5);
            AddParam(BaseStructure.OUTPUT_PARENT, "Ord_Seq", "string", 6);
            AddParam(BaseStructure.OUTPUT_PARENT, "Code", "string", 10);
            AddParam(BaseStructure.OUTPUT_PARENT, "TradeType", "string", 3);
            AddParam(BaseStructure.OUTPUT_PARENT, "TradeClass", "string", 2);
            AddParam(BaseStructure.OUTPUT_PARENT, "Price", "string", 9);
            AddParam(BaseStructure.OUTPUT_PARENT, "ContractPrice", "string", 9);
            AddParam(BaseStructure.OUTPUT_PARENT, "OrderKind", "string", 3);
            AddParam(BaseStructure.OUTPUT_PARENT, "Qty", "string", 5);
            AddParam(BaseStructure.OUTPUT_PARENT, "TransTime", "string", 6);
            AddParam(BaseStructure.OUTPUT_PARENT, "StatusMessage", "string", 20);
            AddParam(BaseStructure.OUTPUT_PARENT, "ErrorCode", "string", 4);
            AddParam(BaseStructure.OUTPUT_PARENT, "ErrorMessage", "string", 60);
            AddParam(BaseStructure.OUTPUT_PARENT, "WebId", "string", 3);
            AddParam(BaseStructure.OUTPUT_PARENT, "AccoutS", "string", 15);
            AddParam(BaseStructure.OUTPUT_PARENT, "OCT", "string", 1);
            AddParam(BaseStructure.OUTPUT_PARENT, "OrderTime", "string", 6);
            AddParam(BaseStructure.OUTPUT_PARENT, "AgentId", "string", 6);
            AddParam(BaseStructure.OUTPUT_PARENT, "PriceType", "string", 1);
            AddParam(BaseStructure.OUTPUT_PARENT, "TrfField", "string", 4);
            AddParam(BaseStructure.OUTPUT_PARENT, "MatchSeq", "string", 8);
        }

        public override string Invoke(Dictionary<string, object> dicValue)
        {
            return ff_get_response();
        }
    }
}
