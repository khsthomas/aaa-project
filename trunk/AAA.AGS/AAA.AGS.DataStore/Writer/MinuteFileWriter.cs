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
    public class MinuteFileWriter : IWriter
    {
        private const int DEFAULT_INTERVAL = 5000;
        private StreamWriter _swOutput;
        private IDataProvider _dataProvider;
        private Thread _threadWriteData;
        private bool _isStart;
        private string _strSymbolId;

        public MinuteFileWriter(string strSymbolId, string strFile, bool isAppend)
        {
            _swOutput = new StreamWriter(strFile, isAppend);
            _dataProvider = new DefaultDataProvider();
            _isStart = true;
            _strSymbolId = strSymbolId;            
        }

        private void WriteData()
        {
            List<BarData> lstMinute;

            while (_isStart)
            {
                if (_swOutput == null)
                    break;

                lstMinute = _dataProvider.GetLastMinuteData();

                foreach (BarData barData in lstMinute)
                {
                    if (barData.SymbolId != _strSymbolId)
                        continue;

                    _swOutput.WriteLine(barData.BarDateTime.ToString("yyyy/MM/dd,HH:mm") + "," +
                                        barData.Open.ToString() + "," +
                                        barData.High.ToString() + "," +
                                        barData.Low.ToString() + "," +
                                        barData.Close.ToString() + "," +
                                        barData.Volume.ToString());
                    _swOutput.Flush();
                }

                Thread.Sleep(DEFAULT_INTERVAL);
            }
        }

        #region IWriter Members

        public void Init()
        {
            throw new NotImplementedException();
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


        #endregion
    }
}
