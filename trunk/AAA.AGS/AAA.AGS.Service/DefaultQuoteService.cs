using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Base.Util.Json;
using System.Threading;
using AAA.Meta.Quote.Data;
using System.Data;
using AAA.Base.Util.Reader;
using System.Reflection;
using AAA.Meta.Chart.Data;
using System.Xml;

namespace AAA.AGS.Service
{
    public class DefaultQuoteService : IQuoteService
    {
        private List<string> _lstSymbolList;
        private Dictionary<string, long> _dicSymbolTicks;

        private IQuoteServiceCallBack _callback;
        private volatile bool _isStartService;
        private string[] _strSymbols;

        public DefaultQuoteService()
        {            
        }

        private void InitSymbol()
        {
            XmlParser xmlParser = new XmlParser(Environment.CurrentDirectory + @"\config\symbol_list.xml");
            string strSymbolId;

            _lstSymbolList = new List<string>();
            _dicSymbolTicks = new Dictionary<string, long>();

            foreach (XmlNode xmlNode in xmlParser.GetNodes("/symbol-list/symbol"))
            {
                strSymbolId = xmlParser.GetSingleNode(xmlNode, "symbol-id").InnerText;
                _lstSymbolList.Add(strSymbolId);
                _dicSymbolTicks.Add(strSymbolId, 0);
            }

/*
            IniReader iniReader = new IniReader(Environment.CurrentDirectory + @"\config\symbol_list.ini");

            _lstSymbolList = iniReader.Section;
            _dicSymbolTicks = new Dictionary<string, long>();

            foreach(string strSymbolId in iniReader.Section)
            {
                _dicSymbolTicks.Add(strSymbolId, 0);
            }
 */ 
        }

        #region IQuoteService Members

        public string AvailableSymbolList()
        {
            return JsonUtil.Serialize(_lstSymbolList);
        }

        public void Register()
        {
            _callback = System.ServiceModel.OperationContext.Current.GetCallbackChannel<IQuoteServiceCallBack>();            
            InitSymbol();
        }

        public void Unregister()
        {
            _callback = null;
            _isStartService = false;
        }

        public void StartService()
        {
            Thread quoteThread = new Thread(new ThreadStart(StartQuote));
            _isStartService = true;
            quoteThread.Start();
        }

        public void SetWatchingSymbolList(string[] strSymbols)
        {
            _strSymbols = strSymbols;
        }

        public List<BarRecord> GetData(Dictionary<string, string> queryProperties)
        {
            return AAA.AGS.DataStore.HistoricalDataTable.Instance().GetData(queryProperties);
        }

        public Dictionary<string, AAA.Meta.Chart.Data.PriceVolumeData> GetPriceVolume(Dictionary<string, string> queryProperties)
        {
            return AAA.AGS.DataStore.HistoricalDataTable.Instance().GetPriceVolume(queryProperties);
        }

        public List<DateInfo> GetTransactionDay()
        {
            return AAA.AGS.DataStore.HistoricalDataTable.Instance().GetTransactionDay();
        }
        #endregion

        private void StartQuote()
        {
            TickInfo tickInfo;
            long lTicks;

            while (_isStartService)
            {
                foreach (string strSymbolId in _strSymbols)
                {
                    try
                    {
                        lTicks = _dicSymbolTicks[strSymbolId];                        
                        tickInfo = AAA.AGS.DataStore.DataTable.Instance().GetSymbolSnapshot(strSymbolId);

                        if (tickInfo.Ticks > lTicks)
                        {
                            //OnDataReceive(JsonUtil.Serialize(tickInfo.Data));
                            OnDataReceive(tickInfo.Data);

                            _dicSymbolTicks[strSymbolId] = tickInfo.Ticks;
                        }
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message + "," + ex.StackTrace);
                    }
                }
            }
            Thread.Sleep(100);
        }

        public void OnDataReceive(object oData)
        {
            try
            {       
                if (_callback != null)
                    //_callback.OnDataReceive(JsonUtil.Serialize(oData));
                    _callback.OnDataReceive((QuoteData)oData);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "," + ex.StackTrace);
            }
        }
    }
}
