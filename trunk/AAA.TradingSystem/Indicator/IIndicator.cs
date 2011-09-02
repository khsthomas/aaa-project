using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AAA.TradingSystem.Indicator
{
    public interface IIndicator
    {
        void SetIndicatorLight(int iIndicatorIndex, string strLight);
        void SetIndicatorRemark(int iIndicatorIndex, int iRemarkIndex, string strRemark);
        string ErrorMessage { get; set; }
        int RowIndex { get; set; }
        bool Calculate(int iIndicatorIndex, List<string> lstField, List<string[]> lstData);
    }
}
