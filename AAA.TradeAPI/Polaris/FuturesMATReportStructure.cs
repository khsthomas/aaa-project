using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AAA.TradeAPI.Polaris
{
    public class FuturesMATReportStructure : PolarisStructure
    {
        public FuturesMATReportStructure()
        {
            ApiId = "20.103.20.10";
            ApiIdHex = "1467140A";
            ClientName = "FuturesMATReport";
			DisplayName = "期貨庫存明細";
			
            AddParam(PolarisStructure.INPUT_PARENT, "Count", "int", 4);
			
			AddParam(PolarisStructure.INPUT_CHILDREN, "AccountInfo", "string", 22);

            AddParam(PolarisStructure.OUTPUT_PARENT, "RecordCount", "int", 4);
			
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "AccountInfo", "string", 22);            
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "CommodityID", "string", 7);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "SettlementMonth", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "ProductCName", "string", 10);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "BuySellKind", "string", 1);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "StrikePrice", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "MatchPrice", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "Qty", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "Date", "string", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "DayTradeID", "string", 1);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "Fee", "int", 4);			
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "Tax", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "OpenOffsetKind", "string", 1);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "SeqNo", "short", 2);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "ProductKind", "string", 1);			
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "MarketNo", "byte", 1);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "StockkCode", "string", 12);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "OrgTickMultiplier ", "int", 4);

        }
    }
}
