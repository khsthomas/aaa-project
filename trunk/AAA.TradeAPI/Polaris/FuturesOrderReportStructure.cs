using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AAA.TradeAPI.Polaris
{
    public class FuturesOrderReportStructure : PolarisStructure
    {
        public FuturesOrderReportStructure()
        {
            ApiId = "20.101.20.11";
            ApiIdHex = "1465140B";
            ClientName = "FuturesOrderReport";
			DisplayName = "期貨、選擇權委託回報";
			
            AddParam(PolarisStructure.INPUT_PARENT, "Count", "int", 4);
			AddParam(PolarisStructure.INPUT_PARENT, "OrderCancelFlag", "string", 1);
			
			AddParam(PolarisStructure.INPUT_CHILDREN, "AccountInfo", "string", 22);

            AddParam(PolarisStructure.OUTPUT_PARENT, "RecordCount", "int", 4);
			
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "AccountInfo", "string", 22);
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "TradeDate", "Date", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "MarketNo", "byte", 1);
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "MarketName", "string", 20);
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "CommodityID1", "string", 7);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "SettlementMonth1", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "StrikePrice1", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "BuySellKind1", "byte", 1);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "CommodityID2", "string", 7);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "SettlementMonth2", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "StrikePrice2", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "BuySellKind2", "byte", 1);			
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "OpenOffsetKind", "byte", 1);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "OrderCondition", "byte", 1);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "OrderPrice", "string", 10);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "OrderQty", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "AferQty", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "OkQty ", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "Status", "int", 4);			
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "AcceptDate", "string", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "AcceptTime", "string", 5);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "ErrorNo", "string", 10);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "ErrorMessage", "string", 78);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "OrderNo", "string", 5);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "ProductType", "byte", 1);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "Seller", "short", 2);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "TotalMatFee", "long", 8);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "TotalMatExchTax", "long", 8);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "TotalMatPremium", "long", 8);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "DayTradeID", "string", 1);
        }
    }
}
