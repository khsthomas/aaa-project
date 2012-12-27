using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AAA.TradeAPI.Polaris
{
    public class FuturesTradeReportStructure : PolarisStructure
    {
        public FuturesTradeReportStructure()
        {
            ApiId = "20.101.20.12";
            ApiIdHex = "1465140C";
            ClientName = "FuturesTradeReport";
			DisplayName = "期貨、選擇權成交回報";
			
            AddParam(PolarisStructure.INPUT_PARENT, "Count", "int", 4);
			
			AddParam(PolarisStructure.INPUT_CHILDREN, "AccountInfo", "string", 22);

            AddParam(PolarisStructure.OUTPUT_PARENT, "RecordCount", "int", 4);
			
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "AccountInfo", "string", 22);            
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "MarketNo", "byte", 1);
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "MarketName", "string", 20);
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "CommodityID1", "string", 7);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "SettlementMonth1", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "BuySellKind1", "string", 1);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "MatchQty", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "MatchPrice1", "long", 8);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "MatchPrice2", "long", 8);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "MatchTime", "string", 5);			
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "MatchDate", "string", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "OrderNo", "string", 5);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "StrikePrice1", "int", 4);			
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "CommodityID2", "string", 7);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "SettlementMonth2", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "BuySellKind2", "string", 1);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "StrikePrice2", "int", 4);			
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "RecType", "string", 1);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "ProductType", "string", 1);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "OrderPrice ", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "IdName", "string", 8);			
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "IdName2", "string", 8);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "DayTradeID", "string", 1);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "SprMatchPrice", "long", 8);
        }
    }
}
