using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AAA.TradeAPI.Polaris
{
    public class IndexClassHistoryStructure : PolarisStructure
    {
        public IndexClassHistoryStructure()
        {
            ApiId = "50.0.10.33";
            ApiIdHex = "32000A21";
            ClientName = "IndexClassHistoryData";
			DisplayName = "指數類別歷史資料查詢";
			
            AddParam(PolarisStructure.INPUT_PARENT, "ClassFlag", "byte", 1);

            AddParam(PolarisStructure.OUTPUT_PARENT, "RecordCount", "int", 4);
			
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "MarketNo", "byte", 1);            
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "StockCode", "string", 12);            
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "StockName", "string", 20);            
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "Decimal", "short", 2);                 
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "OpenRefPrice", "int", 4);            
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "DataCount", "int", 4);            
			
			AddParam(PolarisStructure.OUTPUT_GRAND_CHILDREN, "Date", "Date", 4);            
			AddParam(PolarisStructure.OUTPUT_GRAND_CHILDREN, "OpenRefPrice", "int", 4);            
			AddParam(PolarisStructure.OUTPUT_GRAND_CHILDREN, "DealPrice", "int", 4);            
			AddParam(PolarisStructure.OUTPUT_GRAND_CHILDREN, "TotalVol", "int", 4);            

        }
    }
}
