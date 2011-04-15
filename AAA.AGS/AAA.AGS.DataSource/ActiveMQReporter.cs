using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.MQ;
using AAA.Meta.Quote.Data;

namespace AAA.AGS.DataSource
{
    public class ActiveMQReporter : IDataReporter
    {
        private IMQClient _mqClient;
        private string _strQueueName;

        public ActiveMQReporter(string strBroker)
        {
            IMQClient _mqClient = new ActiveMQClient(strBroker);
            _mqClient.Connect();

            
        }

        #region IDataReporter Members

        public bool Report(AAA.Meta.Quote.Data.TickInfo tickInfo)
        {
            try
            {
                IMessage message = new DefaultMessage();
                message.IdFieldName = "Ticks";
                message.Id = DateTime.Parse(((QuoteData)tickInfo.Data).LastUpdateTime).Ticks;
                message.Message = tickInfo;
                _mqClient.QueueName = tickInfo.Id;
                _mqClient.Send(message);
                return true;
            }
            catch (Exception ex)
            {
            }
            return false;
        }

        #endregion
    }
}
