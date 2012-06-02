using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Momentum.Strategy.Meta
{
    public class DefaultSignalInfo : ISignalInfo
    {
        private Color _cColor;
        private float _fValue;
        #region ISignalInfo Members

        public Color LightColor
        {
            get
            {
                return _cColor;
            }
            set
            {
                _cColor = value;
            }
        }

        public float Value
        {
            get
            {
                return _fValue;
            }
            set
            {
                _fValue = value;
            }
        }

        #endregion
    }
}
