using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Base.Util.Reader;
using System.Reflection;
using AAA.Database;
using System.Xml;
using AAA.Meta.Quote.Data;
using System.Data.Common;
using AAA.Meta.Chart.Data;

namespace AAA.AGS.DataSource
{
    public class DBTransactionInfoDataSource : AbstractTransactionInfo
    {
        private IDatabase _database;
        private string _strHost;
        private string _strDatabase;
        private string _strUsername;
        private string _strPassword;
        private string _strSQL;
        private string _strSymbolId;

        public DBTransactionInfoDataSource(string strConfigFile, string strSymbolId)
        {
            XmlParser xmlParser;
            Assembly asmb;

            try
            {
                xmlParser = new XmlParser(strConfigFile);

                _strHost = xmlParser.GetSingleNode("/config/host").InnerText;
                _strDatabase = xmlParser.GetSingleNode("/config/database").InnerText;
                _strUsername = xmlParser.GetSingleNode("/config/username").InnerText;
                _strPassword = xmlParser.GetSingleNode("/config/password").InnerText;
                _strSymbolId = strSymbolId;

                asmb = Assembly.LoadFrom(xmlParser.GetSingleNode("/config/dll").InnerText);
                _database = (IDatabase)asmb.CreateInstance(xmlParser.GetSingleNode("/config/class-name").InnerText);

                foreach (XmlNode xmlNode in xmlParser.GetNodes("/config/symbol"))
                {
                    if (xmlParser.GetSingleNode(xmlNode, "symbol-id").InnerText == strSymbolId)
                    {
                        _strSQL = xmlParser.GetSingleNode(xmlNode, "sql").InnerText;
                        break;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "," + ex.StackTrace);
            }
        }

        public override List<DateInfo> GetTransactionDay()
        {
            return null;
        }
    }
}
