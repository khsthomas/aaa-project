using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AAA.TradeAPI.Polaris
{
    public class KLineStructure : PolarisStructure
    {
        public KLineStructure()
        {
            ApiId = "50.0.0.40";
            ApiIdHex = "32000028";
            ClientName = "QueryKLine";

            AddParam(PolarisStructure.INPUT_PARENT, "KLineKind", "byte", 1);
            AddParam(PolarisStructure.INPUT_PARENT, "CustomValue", "short", 2);
			AddParam(PolarisStructure.INPUT_PARENT, "SpecialFlag", "string", 1);
			AddParam(PolarisStructure.INPUT_PARENT, "Condition", "byte", 1);
			AddParam(PolarisStructure.INPUT_PARENT, "DataCount", "int", 1);
			AddParam(PolarisStructure.INPUT_PARENT, "StartDateTime", "DateTime", 9);
			AddParam(PolarisStructure.INPUT_PARENT, "EndDateTime", "DateTime", 9);
			AddParam(PolarisStructure.INPUT_PARENT, "SeqNo", "int", 4);
			AddParam(PolarisStructure.INPUT_PARENT, "Count", "int", 4);
			
			AddParam(PolarisStructure.INPUT_CHILDREN, "MarketNo", "byte", 1);
			AddParam(PolarisStructure.INPUT_CHILDREN, "StockCode", "string", 12);
			
            AddParam(PolarisStructure.OUTPUT_PARENT, "KLineKind", "byte", 1);
            AddParam(PolarisStructure.OUTPUT_PARENT, "RecordCount", "int", 4);
			
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "MarketNo", "byte", 1);            
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "StockCode", "string", 12);            
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "StockName", "string", 20);            
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "OpenTime", "short", 2);            
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "CloseTime", "short", 2);            
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "Decimal", "short", 2);            
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "YstPrice", "int", 4);            
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "OpenRefPrice", "int", 4);            
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "UpStopPrice", "int", 4);            
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "DownStopPrice", "int", 4);            
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "RestStartTime1", "short", 2);            
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "RestEndTime1", "short", 2);            
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "RestStartTime2", "short", 2);            
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "RestEndTime2", "short", 2);            
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "BelongMarketNo", "byte", 1);            
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "BelongStockCode", "string", 12);            
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "StockType1", "byte", 1);            
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "StockType2", "byte", 1);            
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "DateTime_First", "DateTime", 9);            
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "SeqNo_First", "int", 4);  
			AddParam(PolarisStructure.OUTPUT_CHILDREN, "DateTime_Last", "DateTime", 9);            
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "SeqNo_Last", "int", 4);            			
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "DealVoltmp", "int", 4);            
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "DataCount", "int", 4);            
			
			AddParam(PolarisStructure.OUTPUT_GRAND_CHILDREN, "DateTime", "DateTime", 9);            
			AddParam(PolarisStructure.OUTPUT_GRAND_CHILDREN, "OpenPrice", "int", 4);            
			AddParam(PolarisStructure.OUTPUT_GRAND_CHILDREN, "HighPrice", "int", 4);            
			AddParam(PolarisStructure.OUTPUT_GRAND_CHILDREN, "LowPrice", "int", 4);            
			AddParam(PolarisStructure.OUTPUT_GRAND_CHILDREN, "ClosePrice", "int", 4);            
			AddParam(PolarisStructure.OUTPUT_GRAND_CHILDREN, "DealVol", "int", 4);            
        }
    }
}
