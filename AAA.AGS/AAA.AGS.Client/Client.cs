using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Base.Util.Reader;
using System.ServiceModel;
using AAA.Base.Util.WCF;
using System.ServiceModel.Channels;
using AAA.AGS.Service;
using AAA.Base.Util.Json;
using System.Threading;
using AAA.Meta.Quote;
using AAA.Meta.Quote.Data;
using AAA.Meta.Chart.Data;

namespace AAA.AGS.Client
{
    public class Client : IQuoteServiceCallBack
    {
        DuplexChannelFactory<IQuoteService> _factory;
        IQuoteService _proxy;        
		
        private SendOrPostCallback _tickCallback ;
        private SynchronizationContext _syncContext = null;

        private DataHandler _dataHandler;

        public DataHandler DataHandler
        {
            get { return _dataHandler; }
            set { _dataHandler = value; }
        }

		public Client()
		{
            //IniReader iniReader = new IniReader(Environment.CurrentDirectory + @"\config\system.ini");

            IniReader iniReader = new IniReader("AAA.AGS.Client.dll", "AAA.AGS.Client.config.system.ini");

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
			//_proxy.Register();
		}

        public CommunicationState Status()
        {
            return _factory.State;
        }

		#region Public Method

        public SynchronizationContext SynchronizationContext
        {
            set { _syncContext = value; }
        }

		public void Register()
		{
			_proxy.Register();
		}

		public void Unregister()
		{
			_proxy.Unregister();
		}

		public List<string> AvailableSymbolList()
		{
			return JsonUtil.Deserialize<List<string>>(_proxy.AvailableSymbolList());
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
            _proxy.StartService();
        }

		public void Disconnect()
		{
			try
			{
				_factory.Abort();
				_factory.Close();

			}
			catch (Exception ex)
			{

			}		
		}
		#endregion

		#region IQuoteServiceCallBack Members

//        public void OnDataReceive(string strData)
        public void OnDataReceive(QuoteData quoteData)
		{
            //QuoteData quoteData = JsonUtil.Deserizalize<QuoteData>(strData);

            if (_dataHandler != null)
                _dataHandler(quoteData);
            else
                _syncContext.Post(_tickCallback, quoteData.Items);

		}
		#endregion

    }


}
