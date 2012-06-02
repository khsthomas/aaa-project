using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Momentum.Strategy.Meta
{
    public class BarData
    {
        private float _fOpen;

        public float Open
        {
            get { return _fOpen; }
            set { _fOpen = value; }
        }
        private float _fHigh;

        public float High
        {
            get { return _fHigh; }
            set { _fHigh = value; }
        }
        private float _fLow;

        public float Low
        {
            get { return _fLow; }
            set { _fLow = value; }
        }
        private float _fClose;

        public float Close
        {
            get { return _fClose; }
            set { _fClose = value; }
        }
        private float _fVolume;

        public float Volume
        {
            get { return _fVolume; }
            set { _fVolume = value; }
        }
        private float _fAmount;

        public float Amount
        {
            get { return _fAmount; }
            set { _fAmount = value; }
        }
        private int _iTickVolume;

        public int TickVolume
        {
            get { return _iTickVolume; }
            set { _iTickVolume = value; }
        }

    }
}
