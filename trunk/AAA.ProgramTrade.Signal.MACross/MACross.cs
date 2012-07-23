using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.TradeLanguage;
using AAA.ProgramTrade.Function;
using AAA.Meta.Quote.Data;

namespace AAA.ProgramTrade.Signal.MACross
{
    public class MACross : AbstractSignal
    {
        public MACross()
        {
            DisplayName = "MA Cross";
            VariableNames = new string[] { "TransferSymbolId", "FastMALen", "SlowMALen" };
            VariableDescs = new string[] { "計算後商品名稱", "快線長度", "慢線長度" };
            DefaultValues = new object[] { "", 5, 10 };
        }

        public override void ExecCalculate()
        {
            MA fastMA = new MA();
            MA slowMA = new MA();
            BarRecord barRecord;
            BarRecord previousBar;
            BarCompression barCompression;             
            try
            {
                barRecord = new BarRecord();
                barCompression = BarCompression(BaseSymbolId);
                barRecord.BarCompression = barCompression.DataCompression;
                barRecord.CompressionInterval = barCompression.Interval;
                barRecord.BarDateTime = Time(BaseSymbolId, 0);
                
                fastMA.SetCurrentTime(CurrentTime);
                fastMA.BaseSymbolId = BaseSymbolId;
                fastMA.Variable("Len", Variable("FastMALen"));
                barRecord["FastMA"] = fastMA.Calculate()["MA"];
                
                slowMA.SetCurrentTime(CurrentTime);
                slowMA.BaseSymbolId = BaseSymbolId;
                slowMA.Variable("Len", Variable("SlowMALen"));
                barRecord["SlowMA"] = slowMA.Calculate()["MA"];

                AddBarData(DisplayName, barRecord);

                previousBar = Bar(DisplayName, 1);

                if (previousBar == null)
                    return;
                // Die Cross
                if ((previousBar["FastMA"] > barRecord["FastMA"]) &&
                   (previousBar["SlowMA"] < barRecord["SlowMA"]))
                {
                    ShortEntry("SE_MA", PriceTimeTypeEnum.AtNextBarOpen, OrderTypeEnum.MarketOrder, 0);
                }

                // Golden Cross
                if ((previousBar["FastMA"] < barRecord["FastMA"]) &&
                   (previousBar["SlowMA"] > barRecord["SlowMA"]))
                {
                    LongEntry("LE_MA", PriceTimeTypeEnum.AtNextBarOpen, OrderTypeEnum.MarketOrder, 0);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
