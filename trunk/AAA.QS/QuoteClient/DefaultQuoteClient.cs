using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.MQ;
using AAA.Base.Util.Reader;
using AAA.Meta.Quote.Data;
using AAA.Meta.Quote;

namespace QuoteClient
{
    public class DefaultQuoteClient : IQuoteClient
    {
        private bool _isStart;
        private Dictionary<string, IMQClient> _dicMQClient;
        private Dictionary<string, long> _dicLastTicks;
        private List<string> _lstSymbolList;
        private TickDataHandler OnTickReceive;        

        public DefaultQuoteClient()
        {
            try
            {
                IniReader iniReader = new IniReader(Environment.CurrentDirectory + @"\QuoteClient.dll", "QuoteClient.cfg.system.ini");
                IMQClient mqClient;
                string[] strSymbolIds = iniReader.GetParam("SymbolList").Split(',');
                string strMQServer = iniReader.GetParam("MQServer");
                _dicLastTicks = new Dictionary<string, long>();
                _dicMQClient = new Dictionary<string, IMQClient>();
                _lstSymbolList = new List<string>();

                foreach (string strSymbolId in strSymbolIds)
                {
                    if (_lstSymbolList.IndexOf(strSymbolId) > -1)
                        continue;

                    mqClient = new ActiveMQClient(strMQServer);
                    mqClient.Connect();
                    _dicMQClient.Add(strSymbolId, mqClient);
                    _dicLastTicks.Add(strSymbolId, 0);
                }
            }
            catch (Exception ex)
            {

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

        public List<AAA.Meta.Quote.Data.BarData> GetBarData(Dictionary<string, string> queryProperty)
        {
            throw new NotImplementedException();
        }

        public List<AAA.Meta.Quote.Data.PriceVolumeData> GetPriceVolumeData(Dictionary<string, string> queryProperty)
        {
            throw new NotImplementedException();
        }

        public List<AAA.Meta.Quote.Data.TickData> GetTodayTick(string strSymbolId)
        {
            try
            {
                List<IMessage> lstMessage = _dicMQClient[strSymbolId].Peek("Ticks > " + _dicLastTicks[strSymbolId]);
                List<TickData> lstTickData = new List<TickData>();


                foreach (IMessage message in lstMessage)
                {
                    _dicLastTicks[strSymbolId] = message.Id;
                    lstTickData.Add((TickData)message.Message);
                }

                return lstTickData;
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        #endregion
    }
}
