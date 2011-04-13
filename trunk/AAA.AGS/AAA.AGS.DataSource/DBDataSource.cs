using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Meta.Quote.Data;
using System.IO;
using AAA.Meta.Quote;
using AAA.Meta.Chart.Data;
using AAA.Base.Util.Reader;
using System.Xml;
using AAA.Database;
using System.Reflection;
using System.Data.Common;

namespace AAA.AGS.DataSource
{
    public class DBDataSource : AbstractHisDataSource
    {
        private IDatabase _database;
        private string _strHost;
        private string _strDatabase;
        private string _strUsername;
        private string _strPassword;
        private string _strSQL;
        private string _strSymbolId;
        private string _strBarCompression;

        public DBDataSource(string strConfigFile, string strSymbolId, string strBarCompression)
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
                _strBarCompression = strBarCompression;

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

        public override List<BarRecord> GetData(Dictionary<string, string> queryProperties)
        {
            List<BarRecord> lstReturn = new List<BarRecord>();

            string strStartDateTime = queryProperties.ContainsKey("StartDateTime") ? queryProperties["StartDateTime"] + " 00:00:00" : "1900/01/01 00:00:00";
            string strEndDateTime = queryProperties.ContainsKey("EndDateTime") ? queryProperties["EndDateTime"] + " 23:59:59" : DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            DbDataReader dbReader;
            BarRecord barRecord;

            try
            {
                

                _database.Open(_strHost, _strDatabase, _strUsername, _strPassword);
                dbReader = _database.ExecuteQuery(_strSQL, new object[] { _strSymbolId, strStartDateTime, strEndDateTime });

                while (dbReader.Read())
                {
                    barRecord = new BarRecord();
                    barRecord.BarDateTime = DateTime.Parse(dbReader["ExTime"].ToString());
                    barRecord.BarCompression = (BarCompressionEnum)Enum.Parse(typeof(BarCompressionEnum), _strBarCompression);
                    barRecord.V0 = float.Parse(dbReader["OpenPrice"].ToString());
                    barRecord.V1 = float.Parse(dbReader["HighPrice"].ToString());
                    barRecord.V2 = float.Parse(dbReader["LowPrice"].ToString());
                    barRecord.V3 = float.Parse(dbReader["ClosePrice"].ToString());
                    barRecord.V4 = float.Parse(dbReader["DealVol"].ToString());
                    barRecord.V5 = float.Parse(dbReader["DealAmt"].ToString());

                    lstReturn.Add(barRecord);
                }
            }
            catch (Exception ex)
            {
            }            
           
            return lstReturn;
        }

        public override List<T> GetData<T>(Dictionary<string, string> queryProperties)
        {
            throw new NotImplementedException();
        }
    }
}
