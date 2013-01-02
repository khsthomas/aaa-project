using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AAA.TradeAPI.Polaris
{
    public class StockOrderReportStructure : PolarisStructure
    {
        public StockOrderReportStructure()
        {
            ApiId = "20.101.10.11";
            ApiIdHex = "14650A0B";
            ClientName = "StockOrderReport";
			DisplayName = "股票委託回報";
			
			AddParam(PolarisStructure.INPUT_PARENT, "OrderCancelFlag", "string", 1);
            AddParam(PolarisStructure.INPUT_PARENT, "Count", "int", 4);
						
			AddParam(PolarisStructure.INPUT_CHILDREN, "AccountInfo", "string", 22);

            AddParam(PolarisStructure.OUTPUT_PARENT, "RecordCount", "int", 4);
			
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "AccountInfo", "string", 22);
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "TradeDate", "Date", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "MarketNo", "byte", 1);
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "MarketName", "string", 20);
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "CompanyName", "string", 12);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "StockName", "string", 20);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "OrderType", "short", 2);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "BS", "string", 1);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "Price", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "PriceFlag", "string", 1);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "BeforeQty", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "AfterQty", "int", 4);			
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "OkQty", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "OrderStatus", "short", 2);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "AcceptDate", "Date", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "AcceptTime", "Time", 5);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "OrderNo", "string", 5);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "ErrorNo", "string", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "ErrorMessage", "string", 80);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "Seller", "short", 2);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "Channel", "string", 2);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "APCode", "short", 2);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "Tax", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "Fee", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "DueAmount", "int", 4);			
        }
    }
}
