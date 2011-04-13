using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

namespace AAA.AGS.DataSource
{
    public class TickFileDataSource : AbstractRTDataSource
    {
        private volatile bool _isStart;
        private Thread _tQuote;
        private string _strSymbol;
        private string _strFilename;
        private StreamReader _srTickReader;
        private string[] _strItemNames;

        public TickFileDataSource(string strSymbol, string strFilename, string[] strItemNames)
        {
            _strFilename = strFilename;
            _strSymbol = strSymbol;
            _strItemNames = strItemNames;
            Init();
        }

        private void Init()
        {
            try
            {
                _srTickReader = new StreamReader(_strFilename);
                Status = "Disconnected";
            }
            catch(Exception ex)
            {
                Status = ex.Message + "," + ex.StackTrace;
            }
        }

        #region IDataSource Members
        public override void StartReteive()
        {
            try
            {
                _isStart = true;
                _tQuote = new Thread(new ThreadStart(Quote));
                _tQuote.Start();

                Status = "Connected";
            }
            catch (Exception ex)
            {
                Status = "Disconnected";
            }
        }


        public override void StopReteive()
        {
            _isStart = false;
            Status = "Disconnected";
        }

        #endregion

        public override void Quote()
        {
            string[] strValues;
            string[] strItems;
            string[] strReturnItems;

            string strPreviousTime = "";
            double dOpen = -1;
            double dHigh = -double.MaxValue;
            double dLow = double.MaxValue;
            double dClose = -1;
            double dVolume = 0;

            string strLine;

            while (_isStart)
            {
                try
                {
                    strLine = _srTickReader.ReadLine();
                    if (strLine == null)
                    {
                        _isStart = false;
                        continue;
                    }

                    strValues = strLine.Split('\t');
                    dClose = double.Parse(strValues[4]);

                    if (strPreviousTime != strValues[1].Substring(0, 16))
                    {
                        dOpen = dClose;
                        dHigh = dClose;
                        dLow = dClose;                        
                        dVolume = 0;
                    }

                    dHigh = Math.Max(dHigh, dClose);
                    dLow = Math.Min(dLow, dClose);

                    strReturnItems = new string[_strItemNames.Length + 2];
                    strReturnItems[0] = _strSymbol;
                    strReturnItems[1] = DateTime.Parse(strValues[1]).ToString("yyyy/MM/dd HH:mm:ss");
                    strReturnItems[2] = dOpen.ToString("0");
                    strReturnItems[3] = dHigh.ToString("0");
                    strReturnItems[4] = dLow.ToString("0");
                    strReturnItems[5] = dClose.ToString("0");
                    strReturnItems[6] = (dVolume + double.Parse(strValues[5])).ToString("0");

                    OnDataReceive(strReturnItems);
                    OnDataStore(strReturnItems);
                    strPreviousTime = strValues[1].Substring(0, 16);
                    Thread.Sleep(100);
                }
                catch (Exception ex)
                {
                    Status = ex.Message + "," + ex.StackTrace;
                }
            }
        }

    }
}
