﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Base.Util.Reader;
using AAA.QuoteClient;
using System.Threading;
using AAA.Meta.Quote;
using AAA.Meta.Quote.Data;
using AAA.Meta.Chart.Data;

namespace AAA.AGS.Client
{
    public class MQClient
    {	
        private SynchronizationContext _syncContext = null;

        private DataHandler _dataHandler;

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
            _qcDataClient.StartQuote();
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
		}

        public void SetWatchingList(string[] strSymbols)
        {
            //_proxy.SetWatchingSymbolList(strSymbols);        
        }

        public List<BarRecord> GetData(Dictionary<string, string> queryProperties)
        {
            //return _qcDataClient.GetBarData(queryProperties);            
            return null;
        }

        public Dictionary<string, AAA.Meta.Chart.Data.PriceVolumeData> GetPriceVolume(Dictionary<string, string> queryProperties)
        {
            //return _qcDataClient.GetPriceVolumeData(queryProperties);
            return null;
        }

        public List<DateInfo> GetTransactionDay()
        {
            //return _proxy.GetTransactionDay();
            return null;
        }

        public void StartService()
        {
            _qcDataClient.StartQuote();
        }

		public void Disconnect()
		{
			try
			{
				_qcDataClient.StopQuote();

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
//            else
//                _syncContext.Post(_tickCallback, quoteData.Items);

		}
		#endregion

    }
}
