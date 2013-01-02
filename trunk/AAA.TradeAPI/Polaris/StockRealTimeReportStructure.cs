using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AAA.TradeAPI.Polaris
{
    public class StockRealTimeReportStructure : PolarisStructure
    {
        public StockRealTimeReportStructure()
        {            
            ApiId = "200.10.10.10";
            ApiIdHex = "C80A0A0A";
            ClientName = "StockRealTimeReport";
			DisplayName = "即時回報資料";
						
			AddParam(PolarisStructure.INPUT_PARENT, "Count", "int", 4);

            AddParam(PolarisStructure.INPUT_CHILDREN, "AccountInfo", "string", 22);
				
            AddParam(PolarisStructure.OUTPUT_PARENT, "AccountInfo", "string", 22);			
            AddParam(PolarisStructure.OUTPUT_PARENT, "ReportType", "byte", 1);            
            AddParam(PolarisStructure.OUTPUT_PARENT, "OrderNo", "string", 20);            
            AddParam(PolarisStructure.OUTPUT_PARENT, "MarketNo", "byte", 1);            
            AddParam(PolarisStructure.OUTPUT_PARENT, "CompanyNo", "string", 20);                 
			AddParam(PolarisStructure.OUTPUT_PARENT, "StockCName", "string", 20);
			AddParam(PolarisStructure.OUTPUT_PARENT, "OrderDate", "Date", 4);
			AddParam(PolarisStructure.OUTPUT_PARENT, "OrderTime", "Time", 5);
			AddParam(PolarisStructure.OUTPUT_PARENT, "OrderType", "string", 3);
			AddParam(PolarisStructure.OUTPUT_PARENT, "BS", "string", 1);
			AddParam(PolarisStructure.OUTPUT_PARENT, "Price", "string", 14);
			AddParam(PolarisStructure.OUTPUT_PARENT, "TouchPrice", "string", 14);
			AddParam(PolarisStructure.OUTPUT_PARENT, "BeforeQty", "int", 4);
			AddParam(PolarisStructure.OUTPUT_PARENT, "OrderQty", "int", 4);
			AddParam(PolarisStructure.OUTPUT_PARENT, "OpenOffsetKind", "string", 1);
			AddParam(PolarisStructure.OUTPUT_PARENT, "DayTrade", "string", 1);
			AddParam(PolarisStructure.OUTPUT_PARENT, "OrderCond", "string", 1);
			AddParam(PolarisStructure.OUTPUT_PARENT, "OrderErrorNo", "string", 4);
			AddParam(PolarisStructure.OUTPUT_PARENT, "TradeKind", "byte", 1);
			AddParam(PolarisStructure.OUTPUT_PARENT, "APCode", "byte", 1);
			AddParam(PolarisStructure.OUTPUT_PARENT, "BasketNo", "string", 10);
			AddParam(PolarisStructure.OUTPUT_PARENT, "OrderStatus", "byte", 1);
        }
    }
}
