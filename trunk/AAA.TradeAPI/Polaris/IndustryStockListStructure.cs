using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AAA.TradeAPI.Polaris
{
    public class IndustryStockListStructure : PolarisStructure
    {
        public IndustryStockListStructure()
        {          
            ApiId = "50.0.0.21";
            ApiIdHex = "32000015";
            ClientName = "IndustryStockList";
			DisplayName = "產業類股所屬股票";
			
			AddParam(PolarisStructure.INPUT_PARENT, "MaxLimited", "int", 4);
			AddParam(PolarisStructure.INPUT_PARENT, "PageNo", "int", 4);
            AddParam(PolarisStructure.INPUT_PARENT, "Count", "int", 4);

			AddParam(PolarisStructure.INPUT_CHILDREN, "MarketNo", "byte", 2);
			AddParam(PolarisStructure.INPUT_CHILDREN, "IndustryCode", "string", 2);
			
			AddParam(PolarisStructure.OUTPUT_PARENT, "SearchCount", "int", 4);
            AddParam(PolarisStructure.OUTPUT_PARENT, "RecordCount", "int", 4);
			
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "MarketNo", "byte", 1);            
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "StockCode", "string", 12);            
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "StockName", "string", 20);            
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "IndustryCode", "string", 2);                 

        }
    }
}
