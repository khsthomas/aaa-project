using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using AAA.Database;
using AAA.AGS.DataSource;
using AAA.AGS.DataStore.Provider;
using System.Threading;
using AAA.Meta.Quote.Data;
using System.Xml;
using System.Reflection;
using AAA.Base.Util.Reader;

namespace AAA.AGS.DataStore.Writer
{
    public class TickDBWriter : IWriter
    {
        private const int DEFAULT_INTERVAL = 5000;
        private IDataProvider _dataProvider;
        private Thread _threadWriteData;
        private bool _isStart;
        private string _strConfigFile;
        private Dictionary<string, IDatabase> _dicDatabase;
        private Dictionary<string, string> _dicSQL;
        private string _strSymbolId;

        public TickDBWriter(string strConfigFile, string strSymbolId)
        {
            _dataProvider = new ActiveMQDataProvider();
            _isStart = true;
            _strSymbolId = strSymbolId;
            _strConfigFile = strConfigFile;
            _dicDatabase = new Dictionary<string, IDatabase>();
            _dicSQL = new Dictionary<string, string>();
        }

        private void WriteData()
        {
            List<TickInfo> lstTick;

            while (_isStart)
            {
                lstTick = _dataProvider.GetLastTicks();

                foreach (TickInfo tickInfo in lstTick)
                {
                    QuoteData tickInfo_qd = (QuoteData)tickInfo.Data;
                    if (tickInfo_qd.SymbolId != _strSymbolId)
                        continue;

                    _dicDatabase[tickInfo_qd.SymbolId].ExecuteUpdate(_dicSQL[tickInfo_qd.SymbolId], new object[] {  tickInfo_qd.LastUpdateTime,
                                                                                                                    tickInfo_qd.SymbolId,
                                                                                                                    tickInfo_qd.Items[0],
                                                                                                                    tickInfo_qd.Items[1],
                                                                                                                    tickInfo_qd.Items[2],
                                                                                                                    tickInfo_qd.Items[3],
                                                                                                                    tickInfo_qd.Items[4],
                                                                                                                    tickInfo_qd.Items[5]});


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

            foreach (XmlNode xmlNode in xmlParser.GetNodes("/config/tick-data/symbol"))
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
