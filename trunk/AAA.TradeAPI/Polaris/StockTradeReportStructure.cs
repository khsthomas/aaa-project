using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AAA.TradeAPI.Polaris
{
    public class StockTradeReportStructure : PolarisStructure
    {
        public StockTradeReportStructure()
        {
            ApiId = "20.101.10.12";
            ApiIdHex = "14650A0C";
            ClientName = "StockTradeReport";
			DisplayName = "股票成交回報";
			
            AddParam(PolarisStructure.INPUT_PARENT, "Count", "int", 4);
			
			AddParam(PolarisStructure.INPUT_CHILDREN, "AccountInfo", "string", 22);

            AddParam(PolarisStructure.OUTPUT_PARENT, "RecordCount", "int", 4);
			
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "AccountInfo", "string", 22);            
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "MarketNo", "byte", 1);
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "MarketName", "string", 20);
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "CompanyNo", "string", 12);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "StockName", "string", 20);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "OrderType", "short", 2);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "BS", "string", 1);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "DealQty", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "OrderPrice", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "MatchPrice", "int", 4);			
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "MatchDateTime", "DateTime", 9);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "OrderNo", "string", 5);

        }
    }
}
