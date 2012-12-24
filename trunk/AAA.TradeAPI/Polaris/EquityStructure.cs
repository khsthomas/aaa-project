using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AAA.TradeAPI.Polaris
{
    public class EquityStructure : PolarisStructure
    {
        public EquityStructure()
        {
            _strApiId = "20.104.20.12";
            _strApiIdHex = "1468140C";
            _strClientName = "QueryTodayEquity";

            AddParam(PolarisStructure.INPUT_PARENT, "AccountInfo", "string", 22);
            AddParam(PolarisStructure.INPUT_PARENT, "CurrencyType", "string", 1);

            AddParam(PolarisStructure.OUTPUT_PARENT, "ReplyCode", "string", 2);
            AddParam(PolarisStructure.OUTPUT_PARENT, "Advisory", "string", 78);
            AddParam(PolarisStructure.OUTPUT_PARENT, "CurrencyRate", "long", 8);            
            AddParam(PolarisStructure.OUTPUT_PARENT, "AccountBalance", "long", 8);            
            AddParam(PolarisStructure.OUTPUT_PARENT, "InOutAmt", "long", 8);            
            AddParam(PolarisStructure.OUTPUT_PARENT, "VarIncome", "long", 8);            
            AddParam(PolarisStructure.OUTPUT_PARENT, "AccountEquity", "long", 8);            
            AddParam(PolarisStructure.OUTPUT_PARENT, "RealizePremium", "long", 8);            
            AddParam(PolarisStructure.OUTPUT_PARENT, "UnRealizePremium", "long", 8);            
            AddParam(PolarisStructure.OUTPUT_PARENT, "InitialMargin", "long", 8);            
            AddParam(PolarisStructure.OUTPUT_PARENT, "MaintainMargin", "long", 8);            
            AddParam(PolarisStructure.OUTPUT_PARENT, "CoverIncome", "long", 8);            
            AddParam(PolarisStructure.OUTPUT_PARENT, "TodayTOT", "long", 8);            
            AddParam(PolarisStructure.OUTPUT_PARENT, "UsableMargin", "long", 8);            
            AddParam(PolarisStructure.OUTPUT_PARENT, "MaintainRate", "string", 9);            
            AddParam(PolarisStructure.OUTPUT_PARENT, "BuyOptionValue", "long", 8);            
            AddParam(PolarisStructure.OUTPUT_PARENT, "SellOptionValue", "long", 8);            
            AddParam(PolarisStructure.OUTPUT_PARENT, "FullRate", "string", 9);            
            AddParam(PolarisStructure.OUTPUT_PARENT, "CoverAmt", "long", 8);            
            AddParam(PolarisStructure.OUTPUT_PARENT, "AddMargin", "long", 8);            
            AddParam(PolarisStructure.OUTPUT_PARENT, "CashUsable", "long", 8);            
            AddParam(PolarisStructure.OUTPUT_PARENT, "NetEquityAmt", "long", 8);            
            AddParam(PolarisStructure.OUTPUT_PARENT, "MarginGetType", "string", 1);            
            AddParam(PolarisStructure.OUTPUT_PARENT, "YNetEquitAmt", "long", 8);            
        }
    }
}
