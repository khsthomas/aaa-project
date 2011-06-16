using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.AGS.DataStore.Provider;
using AAA.Meta.Quote.Data;
using System.Threading;
using AAA.Database;
using AAA.Base.Util.Reader;
using System.Xml;
using System.Reflection;

namespace AAA.AGS.DataStore.Writer
{
    public class PriceVolumeDBWriter : IWriter
    {
        private const int DEFAULT_INTERVAL = 5000;
        private IDataProvider _dataProvider;
        private Thread _threadWriteData;
        private bool _isStart;
        private string _strConfigFile;
        private Dictionary<string, IDatabase> _dicDatabase;
        private Dictionary<string, string> _dicSQL;

        public PriceVolumeDBWriter(string strConfigFile)
        {
            _dataProvider = new DefaultDataProvider();
            _isStart = true;

            _strConfigFile = strConfigFile;
            _dicDatabase = new Dictionary<string, IDatabase>();
            _dicSQL = new Dictionary<string, string>();
        }

        private void WriteData()
        {
            List<PriceVolumeData> lstMinute;
            List<float> lstPrice;
            List<float> lstVolume;
            List<float> lstTickVolume;

            while (_isStart)
            {
                lstMinute = _dataProvider.GetLastPriceVolumeData();

                foreach (PriceVolumeData priceVolumeData in lstMinute)
                {
                    if (_dicDatabase.ContainsKey(priceVolumeData.SymbolId) == false)
                        continue;

                    lstPrice = priceVolumeData.Price;
                    lstVolume = priceVolumeData.Volume;
                    lstTickVolume = priceVolumeData.TickVolume;

                    for (int i = 0; i < lstPrice.Count; i++)
                    {
                        _dicDatabase[priceVolumeData.SymbolId].ExecuteUpdate(_dicSQL[priceVolumeData.SymbolId], new object[] { priceVolumeData.PVDateTime.ToString("yyyy/MM/dd HH:mm:ss"),
                                                                                                                               priceVolumeData.SymbolId,
                                                                                                                               lstPrice[i],
                                                                                                                               lstVolume[i],
                                                                                                                               lstTickVolume[i]});
                    }
                }
                Thread.Sleep(DEFAULT_INTERVAL);
            }
        }


        #region IWriter Members

        public void Init()
        {
            XmlParser xmlParser = new XmlParser(_strConfigFile);
            Assembly asmb;
            IDatabase database;
            string strSymbolId;
            string strHost;
            string strDatabase;
            string strUsername;
            string strPassword;
            string strSQL;

            foreach (XmlNode xmlNode in xmlParser.GetNodes("/config/pv-data/symbol"))
            {
                strSymbolId = xmlParser.GetSingleNode(xmlNode, "symbol-id").InnerText;
                asmb = Assembly.LoadFrom(xmlParser.GetSingleNode(xmlNode, "dll").InnerText);
                database = (IDatabase)asmb.CreateInstance(xmlParser.GetSingleNode(xmlNode, "class-name").InnerText);
                strHost = xmlParser.GetSingleNode(xmlNode, "host").InnerText;
                strDatabase = xmlParser.GetSingleNode(xmlNode, "database").InnerText;
                strUsername = xmlParser.GetSingleNode(xmlNode, "username").InnerText;
                strPassword = xmlParser.GetSingleNode(xmlNode, "password").InnerText;
                strSQL = xmlParser.GetSingleNode(xmlNode, "sql").InnerText;
                database.Open(strHost, strDatabase, strUsername, strPassword);
                database.AutoCommit = true;
                _dicDatabase.Add(strSymbolId, database);
                _dicSQL.Add(strSymbolId, strSQL);
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
            foreach (IDatabase database in _dicDatabase.Values)
                database.Close();
            
        }

        #endregion
    }
}
