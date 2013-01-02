using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AAA.TradeAPI.Polaris
{
    public class OptionsTheoreticalPriceStructure : PolarisStructure
    {
        public OptionsTheoreticalPriceStructure()
        {            
            ApiId = "50.0.20.16";
            ApiIdHex = "32001410";
            ClientName = "OptionsTheoreticalPrice";
			DisplayName = "選擇權理論價";
			
			AddParam(PolarisStructure.INPUT_PARENT, "IndexCode", "string", 2);
			AddParam(PolarisStructure.INPUT_PARENT, "TradeDate", "int", 4);
            AddParam(PolarisStructure.INPUT_PARENT, "RefFlag", "byte", 1);
			AddParam(PolarisStructure.INPUT_PARENT, "VolatilityFlag", "byte", 1);
			AddParam(PolarisStructure.INPUT_PARENT, "RemainDay", "int", 4);
		
            AddParam(PolarisStructure.OUTPUT_PARENT, "RecordCount", "int", 4);
			
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "MarketNo", "byte", 1);            
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "StockCode", "string", 12);            
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "OpenRefPrice", "int", 4);            
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "UpStopPrice", "int", 4);                 
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "DownStopPrice", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "Decimal", "short", 2);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "TheoreticalPrice", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "DealPrice", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "Volatility", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "Delta", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "Gamma", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "Theta", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "Vega", "int", 4);
        }
    }
}
