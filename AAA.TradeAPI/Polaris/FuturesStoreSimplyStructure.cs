using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AAA.TradeAPI.Polaris
{
    public class FuturesStoreSimplyStructure : PolarisStructure
    {
        public FuturesStoreSimplyStructure()
        {
            ApiId = "20.103.20.15";
            ApiIdHex = "1467140F";
            ClientName = "FuturesStoreSimply";
			DisplayName = "期貨庫存簡表";
			
			AddParam(PolarisStructure.INPUT_PARENT, "Trid", "string", 20);
            AddParam(PolarisStructure.INPUT_PARENT, "Count", "int", 4);
			
			AddParam(PolarisStructure.INPUT_CHILDREN, "AccountInfo", "string", 22);

            AddParam(PolarisStructure.OUTPUT_PARENT, "RecordCount", "int", 4);
			
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "AccountInfo", "string", 22);            
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "Kind", "string", 1);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "Trid", "string", 20);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "BS", "string", 1);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "Qty", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "Amt", "long", 8);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "DayTradeID", "string", 1);

        }
    }
}
