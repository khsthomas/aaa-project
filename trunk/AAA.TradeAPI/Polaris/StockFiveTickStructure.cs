using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AAA.TradeAPI.Polaris
{
    public class StockFiveTickStructure : PolarisStructure
    {
        public StockFiveTickStructure()
        {            
            ApiId = "50.0.0.13";
            ApiIdHex = "3200000D";
            ClientName = "StockFiveTick";
			DisplayName = "個股最佳五檔";
			
			AddParam(PolarisStructure.INPUT_PARENT, "Count", "int", 4);
			
			AddParam(PolarisStructure.INPUT_CHILDREN, "MarketNo", "byte", 1);
			AddParam(PolarisStructure.INPUT_CHILDREN, "StockCode", "string", 12);
            
            AddParam(PolarisStructure.OUTPUT_PARENT, "RecordCount", "int", 4);			
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "MarketNo", "byte", 1);            
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "StockCode", "string", 12);            
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "BVol1", "int", 4);            
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "BVol2", "int", 4);                 
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "BVol3", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "BVol4", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "BVol5", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "BPrice1", "int", 4);            
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "BPrice2", "int", 4);                 
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "BPrice3", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "BPrice4", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "BPrice5", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "SVol1", "int", 4);            
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "SVol2", "int", 4);                 
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "SVol3", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "SVol4", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "SVol5", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "SPrice1", "int", 4);            
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "SPrice2", "int", 4);                 
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "SPrice3", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "SPrice4", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "SPrice5", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "Decimal", "short", 2);
    }
}
