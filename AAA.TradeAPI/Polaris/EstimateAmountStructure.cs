using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AAA.TradeAPI.Polaris
{
    public class EstimateAmountStructure : PolarisStructure
    {
        public EstimateAmountStructure()
        {
            ApiId = "50.0.10.31";
            ApiIdHex = "32000A1F";
            ClientName = "EstimateAmount";
			DisplayName = "大盤預估量走勢圖";
			
            AddParam(PolarisStructure.INPUT_PARENT, "Count", "int", 4);
			
			AddParam(PolarisStructure.INPUT_CHILDREN, "MarketNo", "byte", 1);

            AddParam(PolarisStructure.OUTPUT_PARENT, "RecordCount", "int", 4);
			
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "MarketNo", "byte", 1);            
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "YstDealAmount", "int", 4);            
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "AvgFiveDealAmount", "int", 4);            
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "OpenTime", "short", 2);                 
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "CloseTime", "short", 2);            
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "DataCount", "int", 4);            
			
			AddParam(PolarisStructure.OUTPUT_GRAND_CHILDREN, "DateTime", "DateTime", 9);            
			AddParam(PolarisStructure.OUTPUT_GRAND_CHILDREN, "EstimateAmount", "int", 4);            

        }
    }
}
