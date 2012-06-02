using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Momentum.Strategy.Meta;
using AAA.DesignPattern.Observer;

namespace Momentum.Strategy
{
    public abstract class AbstractIndicator : IIndicator
    {
        private string _strId;
        private string _strDisplayName;
        private List<IObserver> _lstObserver;

        public AbstractIndicator(string strId, string strDisplayName)
        {
            _strId = strId;
            _strDisplayName = strDisplayName;
            _lstObserver = new List<IObserver>();
        }

        #region IIndicator Members

        public abstract ISignalInfo Compute(List<BarData> barData);

        public string Id
        {
            get { return _strId; }
        }

        public string DisplayName
        {
            get { return _strDisplayName; }
        }

        #endregion

        #region IObserver Members

        public void Update(object oSource, IMessageInfo miMessage)
        {
            List<BarData> lstBarData;
            ISignalInfo signalInfo;
            IMessageInfo miReturn;
            try
            {
                lstBarData = (List<BarData>)miMessage.Message;
                signalInfo = Compute(lstBarData);
                miReturn = new MessageInfo();
                miReturn.MessageTicks = DateTime.Now.Ticks;
                miReturn.Message = signalInfo;
                miReturn.MessageSubject = "IndicatorResult";
                Notify(miReturn);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region ISubject Members

        public void Attach(IObserver observer)
        {
            if(_lstObserver.Contains(observer) == false)
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
