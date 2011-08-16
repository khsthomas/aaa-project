using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Base.Util.Reader;
using AAA.QuoteClient;
using System.Threading;
using AAA.Meta.Quote;
using AAA.Meta.Quote.Data;
using AAA.Meta.Chart.Data;
using System.ServiceModel.Channels;
using System.ServiceModel;
using AAA.Base.Util.WCF;
using AAA.AGS.Service;

namespace AAA.AGS.Client
{
    public class MQClient : IQuoteServiceCallBack
    {
        private const int SLEEP_INTERVAL = 1000;
        private bool _isStart;
        private SynchronizationContext _syncContext = null;
        private DuplexChannelFactory<IQuoteService> _factory;
        private SendOrPostCallback _tickCallback;
        private IQuoteService _proxy;        
        private DataHandler _dataHandler;
        private Thread _tQuote;

        private IQuoteClient _qcDataClient;

        public DataHandler DataHandler
        {
            get { return _dataHandler; }
            set { _dataHandler = value; }
        }

		public MQClient()
		{
            //IniReader iniReader = new IniReader(Environment.CurrentDirectory + @"\config\system.ini");

            IniReader iniReader = new IniReader("AAA.AGS.Client.dll", "AAA.AGS.Client.config.system.ini");

            _qcDataClient = new DefaultQuoteClient();
//            _qcDataClient.StartQuote();

            string strUrl = iniReader.GetParam("Host");
            Uri address = new Uri(strUrl);
            Binding binding = WCFUtil.CreateBinding(strUrl.Split(':')[0]);
            _factory = new DuplexChannelFactory<IQuoteService>(
                 new InstanceContext(this),
                 binding,
                 new EndpointAddress(address)
            );
            _tickCallback = delegate(object state) { _dataHandler((QuoteData)state); };
            _proxy = _factory.CreateChannel();            
		}

        public void SetStartDateTime(DateTime dtStartTime)
        {
            List<string> lstSymbolId;
            try
            {
                lstSymbolId = AvailableSymbolList();

                foreach (string strSymbolId in lstSymbolId)
                    _qcDataClient.SetStartDateTime(strSymbolId, dtStartTime);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "," + ex.StackTrace);
            }
        }

		#region Public Method        

        public SynchronizationContext SynchronizationContext
        {
            set { _syncContext = value; }
        }

		public void Register()
		{
			
		}

		public void Unregister()
		{
			
		}

		public List<string> AvailableSymbolList()
		{
            return _qcDataClient.GetAvailableSymbolId();
            //return _proxy.AvailableSymbolList();
		}

        public void SetWatchingList(string[] strSymbols)
        {
            _proxy.SetWatchingSymbolList(strSymbols);        
        }

        public List<BarRecord> GetData(Dictionary<string, string> queryProperties)
        {
            return _proxy.GetData(queryProperties);
        }

        public Dictionary<string, AAA.Meta.Chart.Data.PriceVolumeData> GetPriceVolume(Dictionary<string, string> queryProperties)
        {
            return _proxy.GetPriceVolume(queryProperties);
        }

        public List<DateInfo> GetTransactionDay()
        {
            return _proxy.GetTransactionDay();            
        }

        public void StartService()
        {
            _qcDataClient.StartQuote();
            _isStart = true;
            _tQuote = new Thread(MQQuote);
            _tQuote.Start();
        }

		public void Disconnect()
		{
			try
			{
				_qcDataClient.StopQuote();
                _isStart = false;
                try
                {
                    _tQuote.Abort();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "," + ex.StackTrace);
                }
			}
			catch (Exception ex)
			{
                Console.WriteLine(ex.Message + "," + ex.StackTrace);
			}		
		}
		#endregion

        private void MQQuote()
        {
            List<TickInfo> lstTickInfo;
            List<string> lstSymbolId;
            QuoteData quoteData;

            lstSymbolId = AvailableSymbolList();
            while (_isStart)
            {
                try
                {
                    
                    foreach (string strSymbolId in lstSymbolId)
                    {
                        lstTickInfo = _qcDataClient.GetTodayTick(strSymbolId);
                        foreach (TickInfo tickInfo in lstTickInfo)
                        {
                            quoteData = ((QuoteData)tickInfo.Data);
                            OnDataReceive(quoteData);
                        }



                    }
                    Thread.Sleep(SLEEP_INTERVAL);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "," + ex.StackTrace);
                }
            }
        }

		#region IQuoteServiceCallBack Members

//        public void OnDataReceive(string strData)
        public void OnDataReceive(QuoteData quoteData)
		{
            //QuoteData quoteData = JsonUtil.Deserizalize<QuoteData>(strData);

            if (_dataHandler != null)
                _dataHandler(quoteData);
//            else
//                _syncContext.Post(_tickCallback, quoteData.Items);

		}
		#endregion

    }
}
