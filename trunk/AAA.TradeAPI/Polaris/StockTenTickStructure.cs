using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AAA.TradeAPI.Polaris
{
    public class StockTenTickStructure : PolarisStructure
    {
        public StockTenTickStructure()
        {
            ApiId = "210.10.60.10";
            ApiIdHex = "D20A3C0A";
            ClientName = "StockTenTick";
            DisplayName = "個股最佳十檔";

            AddParam(PolarisStructure.INPUT_PARENT, "Count", "int", 4);

            AddParam(PolarisStructure.INPUT_CHILDREN, "Ket", "string", 22);

            AddParam(PolarisStructure.OUTPUT_PARENT, "Key", "string", 22);
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "MarketNo", "byte", 1);
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "StockCode", "string", 12);
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "byte", 1);
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "Value", "int", 4);
        }
    }
}
