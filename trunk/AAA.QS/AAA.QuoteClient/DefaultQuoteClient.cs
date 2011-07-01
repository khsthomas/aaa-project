using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.MQ;
using AAA.Base.Util.Reader;
using AAA.Meta.Quote.Data;
using AAA.Meta.Quote;
using AAA.Base.Util.SafeCollection;
using System.Threading;

namespace AAA.QuoteClient
{
    public class DefaultQuoteClient : IQuoteClient
    {
        private const int DEFAULT_INTERVAL = 1000;
        private bool _isStart;
        private Dictionary<string, IMQClient> _dicMQClient;
        private Dictionary<string, long> _dicLastTicks;
        private Dictionary<string, long> _dicMinuteLastTicks;
        private Dictionary<string, long> _dicPVLastTicks;
        private List<string> _lstAvailableSymbolId;
        private TickDataHandler OnTickReceive;        

        public DefaultQuoteClient()
        {
            try
            {
                IniReader iniReader = new IniReader(Environment.CurrentDirectory + @"\AAA.QuoteClient.dll", "AAA.QuoteClient.cfg.system.ini");
                IMQClient mqClient;
                string[] strSymbolIds = iniReader.GetParam("SymbolList").Split(',');
                string strMQServer = iniReader.GetParam("MQServer");
                _dicLastTicks = new Dictionary<string, long>();
                _dicMinuteLastTicks = new Dictionary<string, long>();
                _dicPVLastTicks = new Dictionary<string, long>();
                _dicMQClient = new Dictionary<string, IMQClient>();
                _lstAvailableSymbolId = new List<string>();

                foreach (string strSymbolId in strSymbolIds)
                {
                    if (_lstAvailableSymbolId.IndexOf(strSymbolId) > -1)
                        continue;

                    mqClient = new ActiveMQClient(strMQServer);
                    mqClient.QueueName = strSymbolId;
                    mqClient.Connect();
                    _dicMQClient.Add(strSymbolId, mqClient);
                    _dicLastTicks.Add(strSymbolId, 0);
                    _dicMinuteLastTicks.Add(strSymbolId, 0);
                    _dicPVLastTicks.Add(strSymbolId, 0);
                    _lstAvailableSymbolId.Add(strSymbolId);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "," + ex.StackTrace);
            }
        }

        public void DeleteHistoryQueueData()
        {
            foreach(string strSymbolId in _lstAvailableSymbolId)
                _dicMQClient[strSymbolId].Receive("Ticks < " + DateTime.Now.Ticks);
        }

        private void GenerateMinuteData()
        {
            string strPreviousMinute = "1900/01/01 00:00";
            string strMinute = "";

            while (true)
            {
                try
                {
                    // Group Minute Data
                    if (strPreviousMinute != strMinute)
                    {

                    }

                    Thread.Sleep(DEFAULT_INTERVAL);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "," + ex.StackTrace);
                }
            }
        }


        #region IQuoteClient Members

        public bool StartQuote()
        {
            _isStart = true;            
            return true;
        }

        public bool StopQuote()
        {
            _isStart = false;
            return true;
        }

        public List<string> GetAvailableSymbolId()
        {
            return _lstAvailableSymbolId;
        }

        public List<AAA.Meta.Quote.Data.BarData> GetBarData(Dictionary<string, string> queryProperty)
        {
            throw new NotImplementedException();
        }

        public List<AAA.Meta.Quote.Data.PriceVolumeData> GetPriceVolumeData(Dictionary<string, string> queryProperty)
        {
            throw new NotImplementedException();
        }

        public List<AAA.Meta.Quote.Data.TickInfo> GetTodayTick(string strSymbolId)
        {
            List<TickInfo> lstTickData = null;
            try
            {
                lstTickData = new List<TickInfo>(); 
                List<IMessage> lstMessage = _dicMQClient[strSymbolId].Peek("Ticks > " + _dicLastTicks[strSymbolId]);
                


                foreach (IMessage message in lstMessage)
                {
                    _dicLastTicks[strSymbolId] = message.Id;
                    if (((TickInfo)message.Message).Id != strSymbolId)
                        continue;
                    lstTickData.Add((TickInfo)message.Message);
                }

            }
            catch (Exception ex)
            {
            }
            return lstTickData;
        }

        #endregion
    }
}
