using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AAA.TradeAPI.Polaris
{
    public class RealReport3Structure : PolarisStructure
    {
        public RealReport3Structure()
        {
            ApiId = "10.0.0.13";
            ApiIdHex = "0A00000D";
            ClientName = "RealReport3";
			DisplayName = "即時回報III資料回補";
			
            AddParam(PolarisStructure.INPUT_PARENT, "Count", "int", 4);
			
            AddParam(PolarisStructure.INPUT_CHILDREN, "AccountInfo", "string", 22);
            			
			AddParam(PolarisStructure.OUTPUT_PARENT, "RecordCount", "int", 4);            
			
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "AccountInfo", "string", 22);   			
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "ReportType", "byte", 1);            
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "OrderNo", "string", 20);            
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "MarketNo", "byte", 1);            
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "CompanyNo", "string", 20);            
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "StockCName", "string", 20);            
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "OrderDate", "Date", 4);            
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "OrderTime", "Time", 5);            
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "OrderType", "string", 3);            
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "BS", "string", 1);            
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "Price", "string", 14);            
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "DayTrade", "string", 1);            
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "OrderCond", "string", 1);            
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "OrderErrorNo", "string", 4);            
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "TradeKind", "byte", 1);            
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "APCode", "byte", 1);            
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "BasketNo", "string", 10);            
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "OrderStatus", "byte", 1);            

        }
    }
}
