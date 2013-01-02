using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AAA.TradeAPI.Polaris
{
    public class OptionsRiskTickStructure : PolarisStructure
    {
        public OptionsRiskTickStructure()
        {            
            ApiId = "210.10.40.11";
            ApiIdHex = "D20A280B";
            ClientName = "OptionsRiskTick";
			DisplayName = "選擇權風險係數分時明細資料";
			
			AddParam(PolarisStructure.INPUT_PARENT, "Count", "int", 4);
			
			AddParam(PolarisStructure.INPUT_CHILDREN, "Key", "string", 22);
            
            AddParam(PolarisStructure.OUTPUT_PARENT, "Key", "string", 22);			
            AddParam(PolarisStructure.OUTPUT_PARENT, "MarketNo", "byte", 1);            
            AddParam(PolarisStructure.OUTPUT_PARENT, "StockCode", "string", 12);            
            AddParam(PolarisStructure.OUTPUT_PARENT, "SerialNo", "string", 4);            
            AddParam(PolarisStructure.OUTPUT_PARENT, "Time", "Time", 5);                 
			AddParam(PolarisStructure.OUTPUT_PARENT, "TheoreticalPrice", "int", 4);
			AddParam(PolarisStructure.OUTPUT_PARENT, "Volatility", "int", 4);
			AddParam(PolarisStructure.OUTPUT_PARENT, "Delta", "int", 4);
			AddParam(PolarisStructure.OUTPUT_PARENT, "Gamma", "int", 4);
			AddParam(PolarisStructure.OUTPUT_PARENT, "Theta", "int", 4);
			AddParam(PolarisStructure.OUTPUT_PARENT, "Vega", "int", 4);
			AddParam(PolarisStructure.OUTPUT_PARENT, "Rho", "int", 4);
    }
}
