using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Quote;

namespace AAA.RealtimeQuote.Polaris
{
    public class PolarisQuote : AbstractRealtimeQuote
    {
        private PolarisB2BAPI.PolaisB2BTrader _objB2BApi;
        private PolarisB2BAPI.IPolaisB2BTraderEvents_OnResponseEventHandler _eventHandle = null;

        public PolarisB2BAPI.PolaisB2BTrader B2BApi
        {
            get
            {
                if (_objB2BApi == null)
                {
                    _objB2BApi = new PolarisB2BAPI.PolaisB2BTrader();
                }
                try
                {
                    if (_eventHandle == null)
                    {
                        _eventHandle = new PolarisB2BAPI.IPolaisB2BTraderEvents_OnResponseEventHandler(objB2BApi_OnResponse);
                        _objB2BApi.OnResponse += _eventHandle;
                    }
                }
                catch (Exception ex)
                {

                }

                return _objB2BApi;
            }
            set
            {
                _objB2BApi = value;

                try
                {
                    if (_eventHandle == null)
                    {
                        _eventHandle = new PolarisB2BAPI.IPolaisB2BTraderEvents_OnResponseEventHandler(objB2BApi_OnResponse);
                        _objB2BApi.OnResponse += _eventHandle;
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }


        public override string Request(string strItem)
        {
            return "";
        }

        public override bool StartQuote()
        {
            throw new NotImplementedException();
        }

        public override bool StopQuote()
        {
            throw new NotImplementedException();
        }
    }
}
