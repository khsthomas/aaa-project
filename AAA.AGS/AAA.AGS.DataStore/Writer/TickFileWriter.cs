using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using AAA.AGS.DataSource;
using AAA.AGS.DataStore.Provider;
using System.Threading;
using AAA.Meta.Quote.Data;

namespace AAA.AGS.DataStore.Writer
{
    public class TickFileWriter
    {
        private const int DEFAULT_INTERVAL = 5000;
        private StreamWriter _swOutput;
        private IDataProvider _dataProvider;
        private Thread _threadWriteData;
        private bool _isStart;
        private string _strSymbolId;

        public TickFileWriter(string strSymbolId, string strFile, bool isAppend)
        {
            _swOutput = new StreamWriter(strFile, isAppend);
            _dataProvider = new DefaultDataProvider();
            _isStart = true;
            _strSymbolId = strSymbolId;
        }

        private void WriteData()
        {
            List<TickInfo> lstTick;

            while (_isStart)
            {
                if (_swOutput == null)
                    break;

                lstTick = _dataProvider.GetLastTicks();

                foreach (TickInfo tickInfo in lstTick)
                {                  
                    if (((QuoteData)tickInfo.Data).SymbolId != _strSymbolId)
                        continue;

                    _swOutput.WriteLine(((QuoteData)tickInfo.Data).LastUpdateTime + "," +
                                        ((QuoteData)tickInfo.Data).Items[0] + "," +
                                        ((QuoteData)tickInfo.Data).Items[1] + "," +
                                        ((QuoteData)tickInfo.Data).Items[2] + "," +
                                        ((QuoteData)tickInfo.Data).Items[3] + "," +
                                        ((QuoteData)tickInfo.Data).Items[4] + "," +
                                        ((QuoteData)tickInfo.Data).Items[5]);
                    _swOutput.Flush();
                }

                Thread.Sleep(DEFAULT_INTERVAL);
            }
        }

        public void Start()
        {
            _threadWriteData = new Thread(new ThreadStart(WriteData));
            _threadWriteData.Start();
        }

        public void Stop()
        {
            _threadWriteData.Abort();
        }

        public void Close()
        {
            try
            {
                if (_swOutput != null)
                    _swOutput.Close();
            }
            catch { }

        }
    }
}
