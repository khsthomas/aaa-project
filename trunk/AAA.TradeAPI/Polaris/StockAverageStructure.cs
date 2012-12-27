using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AAA.TradeAPI.Polaris
{
    public class StockAverageStructure : PolarisStructure
    {
        public StockAverageStructure()
        {
            ApiId = "50.0.0.23";
            ApiIdHex = "32000017";
            ClientName = "StockAverage";
			DisplayName = "江波走勢圖";
			
            AddParam(PolarisStructure.INPUT_PARENT, "MarketNo", "byte", 1);
            AddParam(PolarisStructure.INPUT_CHILDREN, "IndextNo", "string", 12);

            AddParam(PolarisStructure.OUTPUT_PARENT, "MarketNo", "byte", 1);
            AddParam(PolarisStructure.OUTPUT_PARENT, "IndextNo", "string", 12);
            AddParam(PolarisStructure.OUTPUT_PARENT, "StkCode", "string", 12);
            AddParam(PolarisStructure.OUTPUT_PARENT, "IndexFlag", "byte", 1);
            AddParam(PolarisStructure.OUTPUT_PARENT, "Value", "int", 4);
        }
    }
}
