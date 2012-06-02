using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AAA.ProgramTrade.data
{
    public class OrderInfo
    {
        private int _iSide;

        public int Side
        {
            get { return _iSide; }
            set { _iSide = value; }
        }
        private int _iType;

        public int Type
        {
            get { return _iType; }
            set { _iType = value; }
        }
        private float _fPrice;

        public float Price
        {
            get { return _fPrice; }
            set { _fPrice = value; }
        }
        
    }
}
