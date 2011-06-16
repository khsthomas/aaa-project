using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Base.Util.SafeCollection;
using AAA.Meta.Quote.Data;
using System.Threading;

namespace AAA.AGS.DataStore
{
    public sealed class DataTable
    {
        private const int DEFAULT_INTERVAL = 1000;
        private static DataTable _instance;
        private ThreadSafeDictionary<string, TickInfo> _dicSymbolSnapshot;
        private ThreadSafeDictionary<string, ThreadSafeList<TickInfo>> _dicSymbolQueue;
        private ThreadSafeDictionary<string, ThreadSafeList<BarData>> _dicSymbolMinuteQueue;
        private ThreadSafeDictionary<string, ThreadSafeList<PriceVolumeData>> _dicSymbolPriceVolumeQueue;
        private ThreadSafeList<string> _lstAvailableSymbolId;        
        private Thread _threadTickToMinute;
        private bool _isStart;

        private DataTable()
        {
            _dicSymbolSnapshot = new ThreadSafeDictionary<string, TickInfo>();
            _dicSymbolQueue = new ThreadSafeDictionary<string, ThreadSafeList<TickInfo>>();
            _dicSymbolMinuteQueue = new ThreadSafeDictionary<string, ThreadSafeList<BarData>>();
            _dicSymbolPriceVolumeQueue = new ThreadSafeDictionary<string, ThreadSafeList<PriceVolumeData>>();
            _lstAvailableSymbolId = new ThreadSafeList<string>();
            _isStart = true;
            _threadTickToMinute = new Thread(new ThreadStart(TickToMinute));
            _threadTickToMinute.Start();            
        }

        private void TickToMinute()
        {
            DateTime dtNow;
            DateTime dtPrevious = DateTime.MinValue;
            string strSymbolId;
            ThreadSafeList<TickInfo> lstTickQueue;
            ThreadSafeList<BarData> lstMinuteQueue;
            BarData barData;
            PriceVolumeData priceVolumeData;
            float fOpen;
            float fHigh;
            float fLow;
            float fClose;
            float fVolume;
            long lStartTicks;
            long lEndTicks;

            while (_isStart)
            {                
                dtNow = DateTime.Now;
                if(dtNow.Minute == dtPrevious.Minute)
                {
                    Thread.Sleep(DEFAULT_INTERVAL);
                    continue;
                }
                
                lEndTicks = dtNow.Ticks;
                lStartTicks = dtNow.AddSeconds(-60).Ticks;

                for (int i = 0; i < _lstAvailableSymbolId.Count; i++)
                {
                    try
                    {
                        strSymbolId = _lstAvailableSymbolId[i];
                        lstTickQueue = _dicSymbolQueue[strSymbolId];
                        priceVolumeData = new PriceVolumeData();
                        priceVolumeData.SymbolId = strSymbolId;
                        priceVolumeData.PVDateTime = dtNow;
                        if (_dicSymbolPriceVolumeQueue.ContainsKey(strSymbolId) == false)
                        {
                            _dicSymbolPriceVolumeQueue.Add(strSymbolId, new ThreadSafeList<PriceVolumeData>());
                        }
                        
                        _dicSymbolPriceVolumeQueue[strSymbolId].Add(priceVolumeData);
                        
                        fVolume = 0;
                        fOpen = float.NaN;
                        fClose = float.NaN;
                        fHigh = -float.MaxValue;
                        fLow = float.MaxValue;

                        for (int j = lstTickQueue.Count - 1; j >= 0; j--)
                        {
                            if (lstTickQueue[j].Ticks >= lEndTicks)
                                continue;

                            if (lstTickQueue[j].Ticks < lStartTicks)
                            {
                                if (_dicSymbolMinuteQueue.ContainsKey(strSymbolId) == false)
                                {
                                    lstMinuteQueue = new ThreadSafeList<BarData>();
                                    _dicSymbolMinuteQueue.Add(strSymbolId, lstMinuteQueue);
                                }
                                else
                                {
                                    lstMinuteQueue = _dicSymbolMinuteQueue[strSymbolId];
                                }

                                barData = new BarData();
                                barData.SymbolId = strSymbolId;
                                barData.BarCompression = AAA.Meta.Quote.BarCompressionEnum.Min_1;
                                barData.BarDateTime = dtNow;
                                barData.Open = fOpen;
                                barData.High = fHigh;
                                barData.Low = fLow;
                                barData.Close = fClose;
                                barData.Volume = fVolume;
                                lstMinuteQueue.Add(barData);

                                fOpen = float.NaN;
                                fHigh = float.Parse(((QuoteData)lstTickQueue[j].Data).Items[5].ToString());
                                fLow = float.Parse(((QuoteData)lstTickQueue[j].Data).Items[5].ToString());
                                fClose = float.Parse(((QuoteData)lstTickQueue[j].Data).Items[5].ToString());
                                break;
                            }

                            priceVolumeData.AddData(float.Parse(((QuoteData)lstTickQueue[j].Data).Items[5].ToString()),
                                                    float.Parse(((QuoteData)lstTickQueue[j].Data).Items[2].ToString()));

                            fVolume += float.Parse(((QuoteData)lstTickQueue[j].Data).Items[2].ToString());
                            if (float.IsNaN(fOpen))
                                fOpen = float.Parse(((QuoteData)lstTickQueue[j].Data).Items[5].ToString());
            
                            fClose = float.Parse(((QuoteData)lstTickQueue[j].Data).Items[5].ToString());
                            fHigh = Math.Max(fHigh, float.Parse(((QuoteData)lstTickQueue[j].Data).Items[5].ToString()));
                            fLow = Math.Min(fLow, float.Parse(((QuoteData)lstTickQueue[j].Data).Items[5].ToString()));
                        }
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message + "," + ex.StackTrace);
                    }
                }
                dtPrevious = dtNow;
            }
        }

        public ThreadSafeList<string> GetAvailableSymbolId()
        {
            return _lstAvailableSymbolId;
        }

        public List<TickInfo> GetTicks(int iStartIndex, string strSymbolId)
        {
            List<TickInfo> lstTicks = new List<TickInfo>();
            ThreadSafeList<TickInfo> lstTickQueue;

            if(_dicSymbolQueue.ContainsKey(strSymbolId) == false)
                return lstTicks;

            lstTickQueue = _dicSymbolQueue[strSymbolId];
            for (int i = iStartIndex; i < lstTickQueue.Count; i++)
                lstTicks.Add(lstTickQueue[i]);

            return lstTicks;
        }

        public List<BarData> GetMinutes(int iStartIndex, string strSymbolId)
        {
            List<BarData> lstMinutes = new List<BarData>();
            ThreadSafeList<BarData> lstMinuteQueue;

            if (_dicSymbolMinuteQueue.ContainsKey(strSymbolId) == false)
                return lstMinutes;

            lstMinuteQueue = _dicSymbolMinuteQueue[strSymbolId];
            for (int i = iStartIndex; i < lstMinuteQueue.Count; i++)
                lstMinutes.Add(lstMinuteQueue[i]);

            return lstMinutes;
        }


        public List<PriceVolumeData> GetPriceVolumes(int iStartIndex, string strSymbolId)
        {
            List<PriceVolumeData> lstMinutes = new List<PriceVolumeData>();
            ThreadSafeList<PriceVolumeData> lstMinuteQueue;

            if (_dicSymbolPriceVolumeQueue.ContainsKey(strSymbolId) == false)
                return lstMinutes;

            lstMinuteQueue = _dicSymbolPriceVolumeQueue[strSymbolId];
            for (int i = iStartIndex; i < lstMinuteQueue.Count; i++)
                lstMinutes.Add(lstMinuteQueue[i]);

            return lstMinutes;
        }

        public void SetSymbolSnapshot(string strSymbolId, TickInfo tickInfo)
        {
            ThreadSafeList<TickInfo> lstTickInfo;

            if (_dicSymbolSnapshot.ContainsKey(strSymbolId))
                _dicSymbolSnapshot[strSymbolId] = tickInfo;
            else
            {
                _dicSymbolSnapshot.Add(strSymbolId, tickInfo);
                _lstAvailableSymbolId.Add(strSymbolId);
            }

            if (_dicSymbolQueue.ContainsKey(strSymbolId))
                _dicSymbolQueue[strSymbolId].Add(tickInfo);
            else
            {
                lstTickInfo = new ThreadSafeList<TickInfo>();
                lstTickInfo.Add(tickInfo);
                _dicSymbolQueue.Add(strSymbolId, lstTickInfo);
            }
        }

        public TickInfo GetSymbolSnapshot(string strSymbolId)
        {
            return _dicSymbolSnapshot.ContainsKey(strSymbolId)
                    ? _dicSymbolSnapshot[strSymbolId]
                    : null;
        }

        public static DataTable Instance()
        {
            if (_instance == null)
                _instance = new DataTable();
            return _instance;
        }
    }
}
