﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AAA.TradeAPI.Polaris
{
    public class WatchListStructure : PolarisStructure
    {
        public WatchListStructure()
        {
            ApiId = "210.10.70.11";
            ApiIdHex = "D20A460B";
            ClientName = "SBWatchList";
			DisplayName = "WatchList行情資料";
			
            AddParam(PolarisStructure.INPUT_PARENT, "Count", "int", 4);
            AddParam(PolarisStructure.INPUT_CHILDREN, "Key", "string", 22);

            AddParam(PolarisStructure.OUTPUT_PARENT, "Key", "string", 22);
            AddParam(PolarisStructure.OUTPUT_PARENT, "MarketNo", "byte", 1);
            AddParam(PolarisStructure.OUTPUT_PARENT, "StkCode", "string", 12);
            AddParam(PolarisStructure.OUTPUT_PARENT, "IndexFlag", "byte", 1);
            AddParam(PolarisStructure.OUTPUT_PARENT, "Value", "int", 4);
        }
    }
}