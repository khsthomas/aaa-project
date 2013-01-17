using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AAA.TradeAPI.Polaris
{
    public class FuturesOrderStructure : PolarisStructure
    {
        public FuturesOrderStructure()
        {
            ApiId = "30.100.20.22";
            ApiIdHex = "1E641416";
            ClientName = "FuturesOrder";
			DisplayName = "期貨下單";
			
            AddParam(PolarisStructure.INPUT_PARENT, "Count", "int", 4);
			
            AddParam(PolarisStructure.INPUT_CHILDREN, "Identify", "int", 4);
			AddParam(PolarisStructure.INPUT_CHILDREN, "AccountInfo", "string", 22);
			AddParam(PolarisStructure.INPUT_CHILDREN, "FunctionCode", "short", 2);
			AddParam(PolarisStructure.INPUT_CHILDREN, "CommodityID1", "string", 6);
			AddParam(PolarisStructure.INPUT_CHILDREN, "CallPut1", "string", 1);
			AddParam(PolarisStructure.INPUT_CHILDREN, "SettlementMonth1", "int", 4);
			AddParam(PolarisStructure.INPUT_CHILDREN, "StrikePrice1", "int", 4);
			AddParam(PolarisStructure.INPUT_CHILDREN, "OrderPrice1", "int", 4);
			AddParam(PolarisStructure.INPUT_CHILDREN, "OrderQty1", "short", 2);
			AddParam(PolarisStructure.INPUT_CHILDREN, "BuySell1", "string", 1);
			AddParam(PolarisStructure.INPUT_CHILDREN, "CommodityID2", "string", 6);
			AddParam(PolarisStructure.INPUT_CHILDREN, "CallPut2", "string", 1);
			AddParam(PolarisStructure.INPUT_CHILDREN, "SettlementMonth2", "int", 4);
			AddParam(PolarisStructure.INPUT_CHILDREN, "StrikePrice2", "int", 4);			
			AddParam(PolarisStructure.INPUT_CHILDREN, "OrderQty2", "short", 2);
			AddParam(PolarisStructure.INPUT_CHILDREN, "BuySell2", "string", 1);
			AddParam(PolarisStructure.INPUT_CHILDREN, "OpenOffsetKind", "string", 1);
			AddParam(PolarisStructure.INPUT_CHILDREN, "DayTradeID", "string", 1);
			AddParam(PolarisStructure.INPUT_CHILDREN, "OrderType", "string", 1);
			AddParam(PolarisStructure.INPUT_CHILDREN, "OrderCond", "string", 1);
			AddParam(PolarisStructure.INPUT_CHILDREN, "SellerNo", "string", 2);
			AddParam(PolarisStructure.INPUT_CHILDREN, "OrderNo", "string", 5);
			AddParam(PolarisStructure.INPUT_CHILDREN, "TradeDate", "string", 4);
			AddParam(PolarisStructure.INPUT_CHILDREN, "BasketNo", "string", 10);
			AddParam(PolarisStructure.INPUT_CHILDREN, "Channel", "string", 2);

			AddParam(PolarisStructure.OUTPUT_PARENT, "MsgCode", "string", 4);
			AddParam(PolarisStructure.OUTPUT_PARENT, "MsgContent", "string", 50);
            AddParam(PolarisStructure.OUTPUT_PARENT, "RecordCount", "int", 4);
			
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "Identify", "int", 4);
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "ReplyCode", "short", 2);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "OrderNo", "string", 5);
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "TradeDate", "string", 4);
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "ErrorKind", "string", 1);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "ErrorNo", "string", 3);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "Advisory", "string", 74);

        }
    }
}
