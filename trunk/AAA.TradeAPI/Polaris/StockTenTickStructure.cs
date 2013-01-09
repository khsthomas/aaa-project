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
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "0", "BuyVol1", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "1", "BuyVol2", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "2", "BuyVol3", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "3", "BuyVol4", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "4", "BuyVol5", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "10", "SellVol1", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "11", "SellVol2", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "12", "SellVol3", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "13", "SellVol4", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "14", "SellVol5", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "22", "BuyVol6", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "23", "BuyVol7", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "24", "BuyVol8", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "25", "BuyVol9", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "26", "BuyVol10", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "32", "SellVol6", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "33", "SellVol7", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "34", "SellVol8", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "35", "SellVol9", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "36", "SellVol10", "int", 4);

            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "5", "BuyPrice1", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "6", "BuyPrice2", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "7", "BuyPrice3", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "8", "BuyPrice4", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "9", "BuyPrice5", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "15", "SellPrice1", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "16", "SellPrice2", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "17", "SellPrice3", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "18", "SellPrice4", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "19", "SellPrice5", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "27", "BuyPrice6", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "28", "BuyPrice7", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "29", "BuyPrice8", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "30", "BuyPrice9", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "31", "BuyPrice10", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "37", "SellPrice6", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "38", "SellPrice7", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "39", "SellPrice8", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "40", "SellPrice9", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "41", "SellPrice10", "int", 4);

            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "20", "BuyPrice1", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "20", "BuyPrice2", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "20", "BuyPrice3", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "20", "BuyPrice4", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "20", "BuyPrice5", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "20", "BuyVol1", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "20", "BuyVol2", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "20", "BuyVol3", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "20", "BuyVol4", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "20", "BuyVol5", "int", 4);

            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "21", "SellPrice1", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "21", "SellPrice2", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "21", "SellPrice3", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "21", "SellPrice4", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "21", "SellPrice5", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "21", "SellVol1", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "21", "SellVol2", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "21", "SellVol3", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "21", "SellVol4", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "21", "SellVol5", "int", 4);

            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "42", "BuyPrice6", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "42", "BuyPrice7", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "42", "BuyPrice8", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "42", "BuyPrice9", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "42", "BuyPrice10", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "42", "BuyVol6", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "42", "BuyVol7", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "42", "BuyVol8", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "42", "BuyVol9", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "42", "BuyVol10", "int", 4);

            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "43", "BuyPrice6", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "43", "BuyPrice7", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "43", "BuyPrice8", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "43", "BuyPrice9", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "43", "BuyPrice10", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "43", "BuyVol6", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "43", "BuyVol7", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "43", "BuyVol8", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "43", "BuyVol9", "int", 4);
            AddSwitchParam(PolarisStructure.OUTPUT_CHILDREN, "IndexFlag", "43", "BuyVol10", "int", 4);

        }
    }
}
