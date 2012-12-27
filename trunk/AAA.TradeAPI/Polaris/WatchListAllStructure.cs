using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AAA.TradeAPI.Polaris
{
    public class WatchListAllStructure : PolarisStructure
    {
        public WatchListAllStructure()
        {
            ApiId = "50.0.0.16";
            ApiIdHex = "32000010";
            ClientName = "SBWatchListAll";
			DisplayName = "WatchList 完整版";
			
            AddParam(PolarisStructure.INPUT_PARENT, "Count", "int", 4);
			
            AddParam(PolarisStructure.INPUT_CHILDREN, "MarketNo", "byte", 1);
			AddParam(PolarisStructure.INPUT_CHILDREN, "StockCode", "string", 12);

            AddParam(PolarisStructure.OUTPUT_PARENT, "RecordCount", "int", 4);
			
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "MarketNo", "byte", 1);
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "StockCode", "string", 12);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "YstPrice", "int", 4);
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "OpenRefPrice", "int", 4);
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "UpStopPrice", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "DownStopPrice", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "YstVol", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "ExtName", "string", 20);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "Decimal", "short", 2);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "CreditPercent", "byte", 1);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "LenBondPercent", "byte", 1);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "OpenPrice", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "HighPrice", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "LowPrice", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "BuyPrice", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "TotalOutVol", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "SellPrice", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "TotalInVol", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "DealPrice", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "TotalDealAmt", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "VolFlag", "byte", 1);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "Vol", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "TotalVol", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "FixedPriceVol", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "ReserveVol", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "SettlementPrice", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "HiContractPrice", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "LoContractPrice", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "OrderBuyCount", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "OrderBuyQty", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "OrderSellCount", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "OrderSellQty", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "DealBuyCount", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "DealSellCount", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "PolaTime", "Time", 5);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "TimeDiff", "byte", 1);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "StockType2", "byte", 1);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "ReserveVolDiff", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "BelongCode", "string", 2);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "IndustryName", "string", 20);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "ReserveVolDiff", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "PrincipalPercent", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "UpDownDay", "short", 2);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "BidQty", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "AskQty", "int", 4);
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "PriceTrends", "byte", 1);
        }
    }
}
