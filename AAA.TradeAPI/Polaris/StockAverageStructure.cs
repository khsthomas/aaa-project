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
            AddParam(PolarisStructure.OUTPUT_PARENT, "OpenTime", "short", 2);
            AddParam(PolarisStructure.OUTPUT_PARENT, "CloseTime", "short", 2);
            AddParam(PolarisStructure.OUTPUT_PARENT, "IndexOpenRefPrice", "int", 4);
			AddParam(PolarisStructure.OUTPUT_PARENT, "IndexDecimal", "short", 2);
			AddParam(PolarisStructure.OUTPUT_PARENT, "RecordCount", "int", 4);
			
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "SerialNo", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "Time", "string", 5);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "Index", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "DealAmt", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "BuyVol", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "BuyCount", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "SellVol", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "SellCount", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "DealVol", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "DealCount", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "Up", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "Down", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "Equal", "int", 4);
        }
    }
}
