using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AAA.TradeAPI.Polaris
{
    public class EstimateVolTickStructure : PolarisStructure
    {
        public EstimateVolTickStructure()
        {
            ApiId = "210.10.40.12";
            ApiIdHex = "D20A280C";
            ClientName = "EstimateVolTick";
			DisplayName = "大盤預估量分時明細行情資料";
			
            AddParam(PolarisStructure.INPUT_PARENT, "Count", "int", 4);
			
			AddParam(PolarisStructure.INPUT_CHILDREN, "Key", "string", 22);

            AddParam(PolarisStructure.OUTPUT_PARENT, "Key", "string", 22);			
            AddParam(PolarisStructure.OUTPUT_PARENT, "MarketNo", "byte", 1);            
            AddParam(PolarisStructure.OUTPUT_PARENT, "StockCode", "string", 12);            
            AddParam(PolarisStructure.OUTPUT_PARENT, "SerialNo", "string", 2);            
            AddParam(PolarisStructure.OUTPUT_PARENT, "Time", "Time", 5);                 
            AddParam(PolarisStructure.OUTPUT_PARENT, "EstimateVol", "int", 4);            
                     			 
        }
    }
}
