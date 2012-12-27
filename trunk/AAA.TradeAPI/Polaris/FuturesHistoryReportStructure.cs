using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AAA.TradeAPI.Polaris
{
    public class FuturesHistoryReportStructure : PolarisStructure
    {
        public FuturesHistoryReportStructure()
        {
            ApiId = "20.102.20.10";
            ApiIdHex = "1466140A";
            ClientName = "FuturesHistoryReport";
			DisplayName = "期貨對帳單查詢";
			
			AddParam(PolarisStructure.INPUT_PARENT, "StartDate", "Date", 4);
            AddParam(PolarisStructure.INPUT_PARENT, "EndDate", "Date", 4);
			AddParam(PolarisStructure.INPUT_PARENT, "FutKindCL", "string", 1);
			AddParam(PolarisStructure.INPUT_PARENT, "ProductTypeCL", "string", 5);
			AddParam(PolarisStructure.INPUT_PARENT, "Count", "int", 4);
			
			AddParam(PolarisStructure.INPUT_CHILDREN, "AccountInfo", "string", 22);

            AddParam(PolarisStructure.OUTPUT_PARENT, "RecordCount", "int", 4);
			
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "AccountInfo", "string", 22);            
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "TradeDate", "Date", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "FuturesCode", "string", 7);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "FuturesTradeYM1", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "StrikePrice", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "StockName", "string", 20);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "OpenOffCL", "string", 1);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "BSCL", "string", 1);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "MatchVol", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "MatchPrice", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "OptPremium", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "Fee", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "Tax", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "DayTradeId", "string", 1);
			
        }
    }
}
