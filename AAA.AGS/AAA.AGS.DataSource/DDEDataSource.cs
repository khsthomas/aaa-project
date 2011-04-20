using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Base.Util.Reader;
using NDde.Client;
using System.Threading;

namespace AAA.AGS.DataSource
{
    public class DDEDataSource : AbstractRTDataSource
    {
        private const int DDE_TIMEOUT = 600;
        private volatile bool _isStart;
        private DdeClient _ddeClient;
        private Thread _tQuote;
        private float _fPreviousfIdentifyValue;
        private string _strApplication;
        private string _strTopic;
        private string _strIdentifyField;
        private string _strStartTime;
        private string _strEndTime;
        private int _iRequestInterval;
        private string[] _strItemNames;
        private string[] _strItemsCalculate;
        private string[] _strPreviousItems;
        private string _strSymbol;

        public DDEDataSource(string strSymbol, int iRequestInterval,
                             string strStartTime, string strEndTime,                        
                             string strApplication, string strTopic, string[] strItems, 
                             string[] strItemsCalculate, string strIdentifyField)
        {
            _iRequestInterval = iRequestInterval;
            _strStartTime = strStartTime;
            _strEndTime = strEndTime;
            _strApplication = strApplication;
            _strTopic = strTopic;
            _strItemNames = strItems;
            _strItemsCalculate = strItemsCalculate;
            _strIdentifyField = strIdentifyField;
            _strPreviousItems = null;
            _strSymbol = strSymbol;
            Init();
        }

        private void Init()
        {
            try
            {
                _fPreviousfIdentifyValue = 0;
                _ddeClient = new DdeClient(_strApplication, _strTopic);
                Status = "Disconnected";
            }
            catch(Exception ex)
            {
                Status = ex.Message + "," + ex.StackTrace;
            }
        }

        private bool Connect()
        {
            try
            {
                _ddeClient.Connect();
                return true;
            }
            catch (Exception ex)
            {
                Status = ex.Message + "," + ex.StackTrace;
            }
            return false;
        }

        #region IDataSource Members
        public override void StartReteive()
        {
            try
            {
                if (_ddeClient.IsConnected == false)
                    if(Connect() == false)
                        return;

                _fPreviousfIdentifyValue = 0;
                _isStart = true;
//                _tQuote = new Thread(new ThreadStart(Quote));
//                _tQuote.Start();

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
/*
            try
            {
                _tQuote.Abort();
                _ddeClient.Disconnect();
            }
            catch (Exception ex)
            {
                Status = ex.Message;
            }
 */ 
        }

        public override void Quote()
        {
            float fIdentifyValue;
            float fTickVolume;
            string[] strItems;
            string[] strReturnItems;            
            string strVolume;

//            while (_isStart)
//            {
                try
                {

                    if (_ddeClient.IsConnected == false)
                        if (Connect() == false)
                            return;

                    if ((DateTime.Now.ToString("HH:mm").CompareTo(_strStartTime)  < 0) || (DateTime.Now.ToString("HH:mm").CompareTo(_strEndTime) > 0))
                    {
//                        Thread.Sleep(_iRequestInterval);
//                        continue;
                        return;
                    }

                    fIdentifyValue = float.Parse(_ddeClient.Request(_strIdentifyField, DDE_TIMEOUT));

                    if (fIdentifyValue == _fPreviousfIdentifyValue)
                        //continue;                    
                        return;

                    strItems = new string[_strItemNames.Length + 2];
                    strReturnItems = new string[_strItemNames.Length + 2];
                    strReturnItems[0] = _strSymbol;
                    strReturnItems[1] = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");                    

                    for (int i = 0; i < _strItemNames.Length; i++)
                        if (_strItemNames[i].Trim() != "")
                        {
                            strItems[i + 2] = _ddeClient.Request(_strItemNames[i], DDE_TIMEOUT).Replace('\r', ' ').Replace('\n', ' ').Replace('\0', ' ').Trim();
                            if (_strItemsCalculate[i] == "-")
                            {
                                if (_strPreviousItems != null)
                                    strReturnItems[i + 2] = (float.Parse(strItems[i + 2]) - float.Parse(_strPreviousItems[i + 2])).ToString();
                                else
                                    strReturnItems[i + 2] = strItems[i + 2];
                            }
                            else
                            {
                                strReturnItems[i + 2] = strItems[i + 2];
                            }
                        }
                    _strPreviousItems = strItems;
                    OnDataReceive(strReturnItems);
                    OnDataStore(strReturnItems);
//                    Thread.Sleep(_iRequestInterval);
                    _fPreviousfIdentifyValue = fIdentifyValue;
                }
                catch (Exception ex)
                {
                    Status = ex.Message + "," + ex.StackTrace;
                }
//            }
        }
        #endregion
    }
}
