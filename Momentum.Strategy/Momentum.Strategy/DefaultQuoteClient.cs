using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.DesignPattern.Observer;
using Momentum.Strategy.Meta;
using System.Threading;

namespace Momentum.Strategy
{
    public class DefaultQuoteClient : IQuoteClient
    {
        private bool _isStarted;
        private List<IObserver> _lstObserver;

        public DefaultQuoteClient()
        {
            _lstObserver = new List<IObserver>();
        }

        #region IQuoteClient Members

        public bool StartQuote()
        {

            List<BarData> lstBarData = new List<BarData>();
            BarData barData;
            MessageInfo messageInfo;

            for (int i = 0; i < 10; i++)
            {
                barData = new BarData();
                barData.Open = 10;
                barData.High = 10 + i;
                barData.Low = 10 - i;
                barData.Close = 10 + i;
                lstBarData.Add(barData);
                messageInfo = new MessageInfo();
                messageInfo.MessageTicks = DateTime.Now.Ticks;
                messageInfo.Message = lstBarData;
                messageInfo.MessageSubject = "DataReceived";
                Notify(messageInfo);
                Thread.Sleep(1000);
                //Application.DoEvents();
            }

            _isStarted = true;
            return true;
        }

        public bool StopQuote()
        {
            _isStarted = false;
            return true;
        }

        public bool IsStarted
        {
            get { return _isStarted; }
        }

        #endregion

        #region ISubject Members

        public void Attach(IObserver observer)
        {
            if (_lstObserver.Contains(observer) == false)
                _lstObserver.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            if (_lstObserver.Contains(observer))
                _lstObserver.Remove(observer);
        }

        public void Notify(IMessageInfo miMessage)
        {
            foreach (IObserver observer in _lstObserver)
                observer.Update(this, miMessage);
        }

        #endregion
    }
}
