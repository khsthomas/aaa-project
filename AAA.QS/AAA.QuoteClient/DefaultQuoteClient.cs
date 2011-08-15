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
        private const int TICKS_SCALE = 10000;
        private const int SECOND_PER_ROUND = 30;
        private bool _isStart;
        private Dictionary<string, IMQClient> _dicMQClient;
        private Dictionary<string, long> _dicLastTicks;
        private Dictionary<string, long> _dicMinuteLastTicks;
        private Dictionary<string, long> _dicPVLastTicks;
        private List<string> _lstAvailableSymbolId;
        private Dictionary<string, List<BarData>> _dicMinuteData;
        private Dictionary<string, Dictionary<string, PriceVolumeData>> _dicPVData;
        private TickDataHandler OnTickReceive;
        private Thread _threadPVQuote;
        private Thread _threadMinuteQuote;        

        public DefaultQuoteClient()
        {
            try
            {
                IniReader iniReader = new IniReader(Environment.CurrentDirectory + @"\AAA.QuoteClient.dll", "AAA.QuoteClient.cfg.system.ini");
                IMQClient mqClient;
                string[] strSymbolIds = iniReader.GetParam("SymbolList").Split(',');
                string strMQServer = iniReader.GetParam("MQServer");
                long lDayStartTicks = DateTime.Parse(DateTime.Now.ToString("yyyy/MM/dd") + " 08:47:00").Ticks;
                _dicLastTicks = new Dictionary<string, long>();
                _dicMinuteLastTicks = new Dictionary<string, long>();
                _dicPVLastTicks = new Dictionary<string, long>();
                _dicMQClient = new Dictionary<string, IMQClient>();
                _lstAvailableSymbolId = new List<string>();
                _dicMinuteData = new Dictionary<string, List<BarData>>();
                _dicPVData = new Dictionary<string, Dictionary<string, PriceVolumeData>>();

                foreach (string strSymbolId in strSymbolIds)
                {
                    if (_lstAvailableSymbolId.IndexOf(strSymbolId) > -1)
                        continue;

                    mqClient = new ActiveMQClient(strMQServer, strSymbolId);
                    mqClient.Connect();
                    _dicMQClient.Add(strSymbolId, mqClient);
                    _dicLastTicks.Add(strSymbolId, DateTime.Parse(DateTime.Now.ToString("yyyy/MM/dd") + " 08:45:00").Ticks);
                    //_dicLastTicks.Add(strSymbolId, DateTime.Parse("2011/08/10 08:45:00").Ticks);
                    _dicMinuteLastTicks.Add(strSymbolId, lDayStartTicks);
                    _dicPVLastTicks.Add(strSymbolId, lDayStartTicks);
                    _lstAvailableSymbolId.Add(strSymbolId);
                    _dicMinuteData.Add(strSymbolId, new List<BarData>());
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

        private void GeneratePriceVolumeData()
        {
            string strPreviousMinute = "1900/01/01 00:00";
            string strMinute = "";
            List<TickInfo> lstTickData;
            List<IMessage> lstMessage;
            Dictionary<string, PriceVolumeData> dicPVData;
            PriceVolumeData pvData = null;
            TickInfo tickInfo;
            QuoteData quoteData;
            long lLastTick;

            while (_isStart)
            {
                try
                {
                    foreach (string strSymbolId in _lstAvailableSymbolId)
                    {
                        lstTickData = new List<TickInfo>();
                        lstMessage = _dicMQClient[strSymbolId].Peek("Ticks > " + (_dicPVLastTicks[strSymbolId] - TimeSpan.TicksPerMinute * 2));
                        

                        if (_dicPVData.ContainsKey(strSymbolId) == false)
                            _dicPVData.Add(strSymbolId, new Dictionary<string, PriceVolumeData>());

                        foreach (IMessage message in lstMessage)
                        {
                            tickInfo = (TickInfo)message.Message;
                            quoteData = (QuoteData)tickInfo.Data;
                            
                            _dicPVLastTicks[strSymbolId] = message.Id;

                            if (((TickInfo)message.Message).Id != strSymbolId)
                                continue;
                            strMinute = (new DateTime(tickInfo.Ticks)).ToString("yyyy/MM/dd HH:mm");
                            dicPVData = _dicPVData[strSymbolId];

                            if(dicPVData.ContainsKey(strMinute))
                            {
                                pvData = dicPVData[strMinute];
                                //dicPVData[strMinute].AddData(float.Parse(quoteData.Items[5]), float.Parse(quoteData.Items[2]));
                            }
                            else
                            {
                                pvData = new PriceVolumeData();
                                dicPVData.Add(strMinute, pvData);
                                
                            }
                            pvData.AddData(float.Parse(quoteData.Items[5]), float.Parse(quoteData.Items[2]));
                        }
                    }
                    Thread.Sleep(DEFAULT_INTERVAL);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "," + ex.StackTrace);
                }
            }
        }

        private void GenerateMinuteData()
        {
            string strPreviousMinute = "1900/01/01 00:00";
            string strMinute = "";
            List<TickInfo> lstTickData;
            List<IMessage> lstMessage;
            List<BarData> lstBarData;
            List<BarData> lstQueueBarData;
            BarData barData = null;
            TickInfo tickInfo;
            QuoteData quoteData;
            int iOffset = 0;
            int iStartIndex = 0;

            while (_isStart)
            {
                try
                {
                    foreach (string strSymbolId in _lstAvailableSymbolId)
                    {
                        lstTickData = new List<TickInfo>();
                        lstMessage = _dicMQClient[strSymbolId].Peek("Ticks > " + (_dicMinuteLastTicks[strSymbolId] - TimeSpan.TicksPerMinute * 2));

                        if (lstMessage.Count == 0)
                        {
                            Thread.Sleep(DEFAULT_INTERVAL);
                            continue;
                        }

                        lstBarData = _dicMinuteData[strSymbolId];                        
                        strPreviousMinute = (new DateTime(((TickInfo)lstMessage[0].Message).Ticks)).ToString("yyyy/MM/dd HH:mm");

                        for ( int i = lstBarData.Count - 1; i >= 0; i--)
                        {
                            barData = lstBarData[lstBarData.Count - i];
                            if (barData.BarDateTime.ToString("yyyy/MM/dd HH:mm") == strPreviousMinute)
                            {
                                iOffset = i;
                                iStartIndex = i;
                                break;
                            }
                        }


                        lstQueueBarData = new List<BarData>();
                        barData = new BarData();

                        foreach (IMessage message in lstMessage)
                        {
                            tickInfo = (TickInfo)message.Message;
                            quoteData = (QuoteData)tickInfo.Data;

                            _dicMinuteLastTicks[strSymbolId] = message.Id;
                            if (((TickInfo)message.Message).Id != strSymbolId)
                                continue;
                            strMinute = (new DateTime(tickInfo.Ticks)).ToString("yyyy/MM/dd HH:mm");
                            barData.BarDateTime = DateTime.Parse(strMinute);
                            // Group Minute Data
                            if (strPreviousMinute != strMinute)
                            {
                                barData = new BarData();
                                barData.Open = float.Parse(quoteData.Items[5]);
                                barData.High = -float.MaxValue;
                                barData.Low = float.MaxValue;
                                barData.Close = float.Parse(quoteData.Items[5]);
                                barData.Volume = 0;
                                lstQueueBarData.Add(barData);                                
                            }
                            
                            barData.High = Math.Max(barData.High, float.Parse(quoteData.Items[5]));
                            barData.Low = Math.Min(barData.Low, float.Parse(quoteData.Items[5]));
                            barData.Close = float.Parse(quoteData.Items[5]);
                            barData.Volume += float.Parse(quoteData.Items[2]);
                            strPreviousMinute = strMinute;
                        }

                        if (barData != null)
                            lstQueueBarData.Add(barData);

                        if (iOffset != 0)
                        {
                            lstBarData[iOffset].High = Math.Max(lstBarData[iOffset].High, lstQueueBarData[0].High);
                            lstBarData[iOffset].Low = Math.Min(lstBarData[iOffset].Low, lstQueueBarData[0].Low);
                            lstBarData[iOffset].Close = lstQueueBarData[0].Close;
                            lstBarData[iOffset].Volume += lstQueueBarData[0].Volume;
                        }
                        for (int j = 1; j < lstQueueBarData.Count; j++)
                            lstBarData.Add(lstQueueBarData[j]);
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
            try
            {
/*
                _isStart = true;
                _threadPVQuote = new Thread(GeneratePriceVolumeData);
                _threadPVQuote.Start();
                _threadMinuteQuote = new Thread(GenerateMinuteData);
                _threadMinuteQuote.Start();
 */ 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "," + ex.StackTrace);
            }
            return true;
        }

        public bool StopQuote()
        {
            try
            {
                _isStart = false;
                _threadPVQuote.Abort();
                _threadMinuteQuote.Abort();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "," + ex.StackTrace);
            }
            return true;
        }

        public List<string> GetAvailableSymbolId()
        {
            return _lstAvailableSymbolId;
        }

        public List<AAA.Meta.Quote.Data.BarData> GetBarData(Dictionary<string, string> queryProperties)
        {
            List<AAA.Meta.Quote.Data.BarData> lstReturnBarData = new List<BarData>();
            List<BarData> lstBarData;
            DateTime dtStartDateTime = DateTime.Parse(queryProperties.ContainsKey("StartDateTime") ? queryProperties["StartDateTime"] + " 00:00:00" : "1900/01/01 00:00:00");
            DateTime dtEndDateTime = DateTime.Parse(queryProperties.ContainsKey("EndDateTime") ? queryProperties["EndDateTime"] + " 23:59:59" : DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));

            try
            {
                lstBarData = _dicMinuteData[queryProperties["SymbolId"]];

                foreach (BarData barData in lstBarData)
                {
                    if ((barData.BarDateTime < dtStartDateTime) || (barData.BarDateTime > dtEndDateTime))
                        continue;

                    lstReturnBarData.Add(barData);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "," + ex.StackTrace);
            }
            return lstReturnBarData;
        }

        public List<AAA.Meta.Quote.Data.PriceVolumeData> GetPriceVolumeData(Dictionary<string, string> queryProperty)
        {
            throw new NotImplementedException();
        }

        public List<AAA.Meta.Quote.Data.TickInfo> GetTodayTick(string strSymbolId)
        {
            List<TickInfo> lstTickData = null;
            long lStartTick;

            try
            {
                Console.WriteLine(strSymbolId + ":" + (new DateTime(_dicLastTicks[strSymbolId])).ToString("yyyy/MM/dd HH:mm:ss"));

                lstTickData = new List<TickInfo>();
                List<IMessage> lstMessage = _dicMQClient[strSymbolId].Peek("Ticks >= " + _dicLastTicks[strSymbolId] + " and Ticks < " + (_dicLastTicks[strSymbolId] + TimeSpan.TicksPerSecond * SECOND_PER_ROUND));
                //lStartTick = _dicLastTicks[strSymbolId];

                if (lstMessage == null)
                    return lstTickData;

                foreach (IMessage message in lstMessage)
                {
                    //_dicLastTicks[strSymbolId] = message.Id;
                    if (((TickInfo)message.Message).Id != strSymbolId)
                        continue;
                    lstTickData.Add((TickInfo)message.Message);
                }
                _dicLastTicks[strSymbolId] = Math.Min((_dicLastTicks[strSymbolId] + TimeSpan.TicksPerSecond * SECOND_PER_ROUND), DateTime.Now.Ticks);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "," + ex.StackTrace);
            }
            return lstTickData;
        }

        public void SetStartDateTime(string strSymbolId, DateTime dtStartTime)
        {
            try
            {
                if (_dicLastTicks.ContainsKey(strSymbolId))
                    _dicLastTicks[strSymbolId] = dtStartTime.Ticks;
                else
                    _dicLastTicks.Add(strSymbolId, dtStartTime.Ticks);

                if (_dicMinuteLastTicks.ContainsKey(strSymbolId))
                    _dicMinuteLastTicks[strSymbolId] = dtStartTime.Ticks;
                else
                    _dicMinuteLastTicks.Add(strSymbolId, dtStartTime.Ticks);

                if (_dicPVLastTicks.ContainsKey(strSymbolId))
                    _dicPVLastTicks[strSymbolId] = dtStartTime.Ticks;
                else
                    _dicPVLastTicks.Add(strSymbolId, dtStartTime.Ticks);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "," + ex.StackTrace);
            }
        }

        #endregion
    }
}
