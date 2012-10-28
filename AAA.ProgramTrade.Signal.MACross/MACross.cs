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
            InputVariableNames = new string[] { "FastMALen", "SlowMALen", "StartTime", "EndTime" };
            InputVariableDescs = new string[] { "快線長度", "慢線長度", "策略開始時間", "策略結束時間" };
            DefaultValues = new object[] { 5, 10 , "09:00", "13:00"};
        }

        public override void ExecCalculate()
        {
            MA fastMA = (MA)InitFunction(new MA());
            MA slowMA = (MA)InitFunction(new MA());
            DateTime dtCurrent;
            try
            {
/*
                if ((CurrentTime.CurrentDateTime.ToString("HH:mm:ss").CompareTo(InputVariable("StartTime").ToString()) < 0) ||
                   (CurrentTime.CurrentDateTime.ToString("HH:mm:ss").CompareTo(InputVariable("EndTime").ToString()) > 0))
                    return;
*/
                // 取得快線的計算長度
                fastMA.InputVariable("Len", InputVariable("FastMALen"));
                // 計算快線的均值, 並將值存至FastMA這佪變數中
                Variable("FastMA", fastMA.Calculate()["MA"]);

                // 取得慢線的計算長度
                slowMA.InputVariable("Len", InputVariable("SlowMALen"));
                // 計算慢線的均值, 並將值存至SlowMA這佪變數中
                Variable("SlowMA", slowMA.Calculate()["MA"]);

                // 若當根K為第一根則離開計算函式
                if (VariableBarNumber() == 0)
                    return;

                dtCurrent = Time();

                // 當前一根的快線值大於當根的快線值且前一根的慢線值小於當根的慢線值, 表示MA做死亡交叉, 則進行放空
                if((Variable("FastMA", 1) > Variable("SlowMA", 1)) &&
                   (Variable("FastMA") < Variable("SlowMA")))
                    ShortEntry("SE_MA", PriceTimeTypeEnum.AtNextBarOpen, OrderTypeEnum.MarketOrder, 0);

                // 當前一根的快線值小於當根的快線值且前一根的慢線值大於當根的慢線值, 表示MA做黃金交叉, 則進行買進
                if ((Variable("FastMA", 1) < Variable("SlowMA", 1)) &&
                    (Variable("FastMA") > Variable("SlowMA")))
                    LongEntry("LE_MA", PriceTimeTypeEnum.AtNextBarOpen, OrderTypeEnum.MarketOrder, 0);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
