using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Momentum.Strategy;
using Momentum.Strategy.Meta;

namespace Momentum.MA
{
    public class MA : AbstractIndicator
    {
        private const int MA_LEN = 3;

        public MA()
            : base("MA3", "MA3")
        {
        }

        public override ISignalInfo Compute(List<BarData> barData)
        {
            ISignalInfo signalInfo = new DefaultSignalInfo();
            float fSum;

            if (barData.Count < MA_LEN)
            {
                signalInfo.Value = 0;
            }
            else
            {
                fSum = 0;
                for (int i = 0; i < MA_LEN; i++)
                {
                    fSum += barData[barData.Count - i - 1].Close;
                }
                signalInfo.Value = fSum / MA_LEN;
            }

            return signalInfo;
        }
    }
}
