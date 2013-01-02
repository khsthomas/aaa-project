using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AAA.TradeAPI.Polaris
{
    public class StockStoreSummaryStructure : PolarisStructure
    {
        public StockStoreSummaryStructure()
        {
            ApiId = "20.103.10.15";
            ApiIdHex = "14670A0F";
            ClientName = "StockStoreSummary";
			DisplayName = "股票庫存總表";
						
            AddParam(PolarisStructure.INPUT_PARENT, "Count", "int", 4);
			
			AddParam(PolarisStructure.INPUT_CHILDREN, "AccountInfo", "string", 22);

            AddParam(PolarisStructure.OUTPUT_PARENT, "RecordCount", "int", 4);
			
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "AccountInfo", "string", 22);            
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "TradeKind", "short", 2);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "MarketNo", "byte", 1);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "MarketName", "string", 20);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "StockCode", "string", 12);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "StockCName", "string", 20);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "StockQty", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "Price", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "Cost", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "Interest", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "BuyNotInQty", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "SellNotInQty", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "CanOrderQty", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "Loan", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "TaxRate", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "LotSize", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "MarketPrice", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "Decimal", "short", 2);

        }
    }
}
