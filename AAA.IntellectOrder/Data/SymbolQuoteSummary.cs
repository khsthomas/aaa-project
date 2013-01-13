using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AAA.IntellectOrder.Data
{
    public class SymbolQuoteSummary
    {
        private const int PRICE_COUNT = 5;
        public const int BUY = 0;
        public const int SELL = 1;

        private string _strSymbolName;

        public string SymbolName
        {
            get { return _strSymbolName; }
            set { _strSymbolName = value; }
        }
        private string _strSymbolQuoteCode;

        public string SymbolQuoteCode
        {
            get { return _strSymbolQuoteCode; }
            set { _strSymbolQuoteCode = value; }
        }

        private string _strSymbolOrderCode;

        public string SymbolOrderCode
        {
            get { return _strSymbolOrderCode; }
            set { _strSymbolOrderCode = value; }
        }

        private float[] _fBuyPrices;
        private int[] _iBuyVols;
        private float[] _fSellPrices;
        private int[] _iSellVols;

        private int[] _iAccuBuyVols;
        private int[] _iAccuSellVols;

        public SymbolQuoteSummary()
        {
            _fBuyPrices = new float[PRICE_COUNT];
            _fSellPrices = new float[PRICE_COUNT];
            _iBuyVols = new int[PRICE_COUNT];
            _iSellVols = new int[PRICE_COUNT];
            _iAccuBuyVols = new int[PRICE_COUNT];
            _iAccuSellVols = new int[PRICE_COUNT];
        }

        public void SetPrice(int iType, int iIndex, float fPrice)
        {
            try
            {
                if (iType == BUY)
                    _fBuyPrices[iIndex] = fPrice;                    
                else
                    _fSellPrices[iIndex] = fPrice;
            }
            catch 
            { 
            }
        }

        public void UpdateAccuVolume(int iType, int iIndex)
        {
            int[] iAccuVolumes = (iType == BUY) ? _iAccuBuyVols : _iAccuSellVols;
            int[] iCurrentVolumes = (iType == BUY) ? _iBuyVols : _iSellVols;

            for (int i = iIndex; i < iAccuVolumes.Length; i++)
            {
                if(i == 0)
                {
                    iAccuVolumes[i] = iCurrentVolumes[i];
                    continue;
                }
                iAccuVolumes[i] = iAccuVolumes[i - 1] + iCurrentVolumes[i];
            }
        }

        public void SetVolume(int iType, int iIndex, int iVolume)
        {
            try
            {
                if (iType == BUY)
                {
                    _iBuyVols[iIndex] = iVolume;
                }
                else
                {
                    _iSellVols[iIndex] = iVolume;
                }
            }
            catch
            {
            }
        }

        public int GetAccuVolume(int iType, int iIndex)
        {
            return (iType == BUY) ? _iAccuBuyVols[iIndex] : _iAccuSellVols[iIndex];
        }

        public float BestPrice(int iType, int iVolume)
        {
            int[] iAccuVolumes = (iType == BUY) ? _iAccuBuyVols : _iAccuSellVols;
            float[] fPrices = (iType == BUY) ? _fBuyPrices : _fSellPrices;

            for (int i = 0; i < iAccuVolumes.Length; i++)
            {
                if (iAccuVolumes[i] > iVolume)
                    return fPrices[i];
            }

            return float.NaN;
        }

    }
}
