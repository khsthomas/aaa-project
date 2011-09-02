using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AAA.TradingSystem.Indicator
{
    public abstract class AbstractIndicator : IIndicator
    {
        private string _strErrorMessage;
        private int _iRawDataCount;
        private int _iIndicatorCount;
        private List<string[]> _lstData;
        private int _iRowIndex;

        public int RowIndex
        {
            get { return _iRowIndex; }
            set { _iRowIndex = value; }
        }

        public List<string[]> Data
        {
            get { return _lstData; }
            set { _lstData = value; }
        }
        #region IIndicator Members

        public void SetIndicatorLight(int iIndicatorIndex, string strLight)
        {
            if (Data == null)
                return;

            Data[RowIndex][RawDataCount + iIndicatorIndex] = strLight;
        }

        public void SetIndicatorRemark(int iIndicatorIndex, int iRemarkIndex, string strRemark)
        {
            if (Data == null)
                return;
            Data[RowIndex][RawDataCount + iIndicatorIndex * (IndicatorCount + 1) + iRemarkIndex] = strRemark;
        }

        public int IndicatorCount
        {
            get { return _iIndicatorCount; }
            set { _iIndicatorCount = value; }
        }

        public int RawDataCount
        {
            get { return _iRawDataCount; }
            set { _iRawDataCount = value; }
        }

        public string ErrorMessage
        {
            get
            {
                return _strErrorMessage;
            }
            set
            {
                _strErrorMessage = value;
            }
        }

        public abstract bool Calculate(int iIndicatorIndex, List<string> lstField, List<string[]> lstData);

        #endregion

    }
}
