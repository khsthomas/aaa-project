using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AAA.TradeAPI.Polaris
{
    public class StockHistoryReportStructure : PolarisStructure
    {
        public StockHistoryReportStructure()
        {
            ApiId = "20.102.10.10";
            ApiIdHex = "14660A0A";
            ClientName = "StockHistoryReport";
			DisplayName = "股票對帳單明細";
			
			AddParam(PolarisStructure.INPUT_PARENT, "StartDate", "Date", 4);
            AddParam(PolarisStructure.INPUT_PARENT, "EndDate", "Date", 4);
			AddParam(PolarisStructure.INPUT_PARENT, "DateType", "string", 1);
			AddParam(PolarisStructure.INPUT_PARENT, "StockCode", "string", 12);
			AddParam(PolarisStructure.INPUT_PARENT, "TradeKindCL", "string", 1);			
			AddParam(PolarisStructure.INPUT_PARENT, "Count", "int", 4);
			
			AddParam(PolarisStructure.INPUT_CHILDREN, "AccountInfo", "string", 22);

            AddParam(PolarisStructure.OUTPUT_PARENT, "RecordCount", "int", 4);
			
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "AccountInfo", "string", 22);            
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "TradeDate", "Date", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "SeqNo", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "StockCode", "string", 12);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "StockName", "string", 20);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "TradeKindCL", "short", 2);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "TradeKindName", "string", 10);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "MatchVol", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "MatchPrice", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "Fee", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "Tax", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "Interest", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "BFee", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "PolarisAmount", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "LoanAmount", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "Mortgage", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "PayDate", "Date", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "ProfitLoss", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "ProfitLossPercent", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "RefAsset", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "TotalAmount", "int", 4);
			
        }
    }
}
