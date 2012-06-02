using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.ProgramTrade.data;

namespace AAA.ProgramTrade
{
    public class SymbolUtil
    {
        public static ContractInfo HotContract(DateTime dtCurrent)
        {
            ContractInfo contractInfo = new ContractInfo();
            DateTime dtMonthStart = new DateTime(dtCurrent.Year, dtCurrent.Month, 1);            
            int iCount = 0;

            while (iCount < 2)
            {
                if (dtMonthStart.DayOfWeek == DayOfWeek.Wednesday)
                    iCount++;
                dtMonthStart.AddDays(1);
            }

            if (dtCurrent <= dtMonthStart)
            {
                contractInfo.Year = dtCurrent.Year;
                contractInfo.Month = dtCurrent.Month;
            }
            else
            {
                contractInfo.Year = dtCurrent.Year;
                contractInfo.Month = dtCurrent.Month + 1;
                if (contractInfo.Month > 12)
                {
                    contractInfo.Year += 1;
                    contractInfo.Month = 1;
                }
            }

            return contractInfo;
        }
    }
}
