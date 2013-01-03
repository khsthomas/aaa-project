using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AAA.TradeAPI.Polaris
{
    public class StockOrderStructure : PolarisStructure
    {
        public StockOrderStructure()
        {
            ApiId = "30.100.10.10";
            ApiIdHex = "1E640A0A";
            ClientName = "StockOrder";
			DisplayName = "現貨下單";
			
            AddParam(PolarisStructure.INPUT_PARENT, "Count", "int", 4);
			
            AddParam(PolarisStructure.INPUT_CHILDREN, "Identify", "int", 4);
			AddParam(PolarisStructure.INPUT_CHILDREN, "AccountInfo", "string", 22);
			AddParam(PolarisStructure.INPUT_CHILDREN, "APCode", "short", 2);
			AddParam(PolarisStructure.INPUT_CHILDREN, "TradeKing", "short", 2);
			AddParam(PolarisStructure.INPUT_CHILDREN, "OrderType", "string", 1);
			AddParam(PolarisStructure.INPUT_CHILDREN, "StockCode", "string", 12);
			AddParam(PolarisStructure.INPUT_CHILDREN, "PriceFlag", "string", 1);
			AddParam(PolarisStructure.INPUT_CHILDREN, "Price", "int", 4);
			AddParam(PolarisStructure.INPUT_CHILDREN, "OrderQty", "int", 4);
			AddParam(PolarisStructure.INPUT_CHILDREN, "BuySell", "string", 1);
			AddParam(PolarisStructure.INPUT_CHILDREN, "SellerNo", "short", 2);
			AddParam(PolarisStructure.INPUT_CHILDREN, "OrderNo", "string", 5);
			AddParam(PolarisStructure.INPUT_CHILDREN, "TradeDate", "Date", 4);
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
