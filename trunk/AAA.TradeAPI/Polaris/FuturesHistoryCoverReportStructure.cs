using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AAA.TradeAPI.Polaris
{
    public class FuturesHistoryCoverReportStructure : PolarisStructure
    {
        public FuturesHistoryCoverReportStructure()
        {
            ApiId = "20.102.20.11";
            ApiIdHex = "1466140B";
            ClientName = "FuturesHistoryCoverReport";
			DisplayName = "期貨沖銷明細查詢";
			
			AddParam(PolarisStructure.INPUT_PARENT, "StartDate", "Date", 4);
            AddParam(PolarisStructure.INPUT_PARENT, "EndDate", "Date", 4);
			AddParam(PolarisStructure.INPUT_PARENT, "FutKindCL", "string", 1);
			AddParam(PolarisStructure.INPUT_PARENT, "ProductTypeCL", "string", 5);
			AddParam(PolarisStructure.INPUT_PARENT, "Count", "int", 4);
			
			AddParam(PolarisStructure.INPUT_CHILDREN, "AccountInfo", "string", 22);

            AddParam(PolarisStructure.OUTPUT_PARENT, "RecordCount", "int", 4);
			
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "AccountInfo", "string", 22);            
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "CoverDate", "Date", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "CoverSeqNo", "short", 2);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "CoverNum", "short", 2);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "OriTradeDate", "Date", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "FuturesCode", "string", 7);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "FutTradeYM1", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "StrikePrice", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "StockName", "string", 20);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "BSCL", "string", 1);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "MatchPrice", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "SourceCL", "string", 1);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "CoverVol", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "ProfitMoney", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "Fee", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "Tax", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "ProductType", "string", 1);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "CurrencyType", "string", 3);
        }
    }
}
