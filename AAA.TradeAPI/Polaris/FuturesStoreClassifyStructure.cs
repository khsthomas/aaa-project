using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AAA.TradeAPI.Polaris
{
    public class FuturesStoreClassifyStructure : PolarisStructure
    {
        public FuturesStoreClassifyStructure()
        {
            ApiId = "20.103.20.11";
            ApiIdHex = "1467140B";
            ClientName = "FuturesStoreClassify";
			DisplayName = "期貨庫存總表";
			
            AddParam(PolarisStructure.INPUT_PARENT, "Count", "int", 4);
			
			AddParam(PolarisStructure.INPUT_CHILDREN, "AccountInfo", "string", 22);

            AddParam(PolarisStructure.OUTPUT_PARENT, "RecordCount", "int", 4);
			
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "AccountInfo", "string", 22);            
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "Kind", "string", 1);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "Trid", "string", 20);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "BS", "string", 1);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "Qty", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "Amt", "long", 8);
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "CommodityID1", "string", 6);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "CallPut1", "string", 1);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "SettlementMonth1", "int", 4);			
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "StrikePrice1", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "CommodityID2", "string", 6);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "CallPut2", "string", 1);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "SettlementMonth2", "int", 4);			
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "StrikePrice2", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "Fee", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "Tax", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "CurrencyType", "string", 3);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "DayTradeID", "string", 1);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "BS1", "string", 1);			
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "BS2", "string", 1);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "ProductKind1", "string", 1);			
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "ProductKind2", "string", 1);						
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "MarketNo1", "byte", 1);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "StockkCode1", "string", 12);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "MarketNo2", "byte", 1);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "StockkCode2", "string", 12);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "BelongMarketNo1", "byte", 1);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "BelongStockkCode1", "string", 12);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "BelongMarketNo2", "byte", 1);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "BelongStockkCode2", "string", 12);

        }
    }
}
