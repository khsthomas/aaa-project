using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AAA.TradeAPI.Polaris
{
    public class RealReportMergeStructure : PolarisStructure
    {
        public RealReportMergeStructure()
        {            
            ApiId = "200.10.10.11";
            ApiIdHex = "C80A0A0B";
            ClientName = "RealReportMerge";
			DisplayName = "彙整的即時回報資料";
						
			AddParam(PolarisStructure.INPUT_PARENT, "Count", "int", 4);

            AddParam(PolarisStructure.INPUT_CHILDREN, "AccountInfo", "string", 22);
		
            AddParam(PolarisStructure.OUTPUT_PARENT, "AccountInfo", "string", 22);			
            AddParam(PolarisStructure.OUTPUT_PARENT, "ReportType", "byte", 1);            
            AddParam(PolarisStructure.OUTPUT_PARENT, "OrderNo", "string", 20);            
            AddParam(PolarisStructure.OUTPUT_PARENT, "MarketNo", "byte", 1);            
            AddParam(PolarisStructure.OUTPUT_PARENT, "CompanyNo", "string", 20);                 
			AddParam(PolarisStructure.OUTPUT_PARENT, "OrderDate", "Date", 4);
			AddParam(PolarisStructure.OUTPUT_PARENT, "OrderTime", "Time", 5);
			AddParam(PolarisStructure.OUTPUT_PARENT, "OrderType", "string", 3);
			AddParam(PolarisStructure.OUTPUT_PARENT, "BS", "string", 1);
			AddParam(PolarisStructure.OUTPUT_PARENT, "OrderPrice", "string", 14);
			AddParam(PolarisStructure.OUTPUT_PARENT, "TouchPrice", "string", 14);
			AddParam(PolarisStructure.OUTPUT_PARENT, "LastDealPrice", "string", 14);
			AddParam(PolarisStructure.OUTPUT_PARENT, "AvgDealPrice", "string", 14);			
			AddParam(PolarisStructure.OUTPUT_PARENT, "BeforeQty", "int", 4);
			AddParam(PolarisStructure.OUTPUT_PARENT, "OrderQty", "int", 4);
			AddParam(PolarisStructure.OUTPUT_PARENT, "OkQty", "int", 4);
			AddParam(PolarisStructure.OUTPUT_PARENT, "OpenOffsetKind", "string", 1);
			AddParam(PolarisStructure.OUTPUT_PARENT, "DayTrade", "string", 1);
			AddParam(PolarisStructure.OUTPUT_PARENT, "OrderCond", "string", 1);
			AddParam(PolarisStructure.OUTPUT_PARENT, "OrderErrorNo", "string", 4);
			AddParam(PolarisStructure.OUTPUT_PARENT, "APCode", "byte", 1);
			AddParam(PolarisStructure.OUTPUT_PARENT, "OrderStatus", "byte", 2);
			AddParam(PolarisStructure.OUTPUT_PARENT, "LastOrderStatus", "byte", 1);
			AddParam(PolarisStructure.OUTPUT_PARENT, "CompanyName", "string", 20);
			AddParam(PolarisStructure.OUTPUT_PARENT, "TradeCode", "string", 20);
			AddParam(PolarisStructure.OUTPUT_PARENT, "StrikePrice", "int", 4);
			AddParam(PolarisStructure.OUTPUT_PARENT, "BasketNo", "string", 10);
			
        }
    }
}
