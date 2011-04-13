using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Meta.Quote.Data;
using System.IO;
using AAA.Meta.Quote;
using AAA.Meta.Chart.Data;
using System.Reflection;
using AAA.Database;
using System.Xml;
using System.Data.Common;
using AAA.Base.Util.Reader;

namespace AAA.AGS.DataSource
{
    public class DBPriceVolumeDataSource : AbstractPriceVolumeDataSource
    {
        private IDatabase _database;
        private string _strHost;
        private string _strDatabase;
        private string _strUsername;
        private string _strPassword;
        private string _strSQL;
        private string _strSymbolId;

        public DBPriceVolumeDataSource(string strConfigFile, string strSymbolId)
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

        public override Dictionary<string, AAA.Meta.Chart.Data.PriceVolumeData> GetPriceVolume(Dictionary<string, string> queryProperties)
        {
            string strStartDateTime = queryProperties.ContainsKey("StartDateTime") ? queryProperties["StartDateTime"] + " 00:00:00" : "1900/01/01 00:00:00";
            string strEndDateTime = queryProperties.ContainsKey("EndDateTime") ? queryProperties["EndDateTime"] + " 23:59:59" : DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            DbDataReader dbReader;
            AAA.Meta.Chart.Data.PriceVolumeData priceVolumeData;
            Dictionary<string, AAA.Meta.Chart.Data.PriceVolumeData> dicPriceVolume;
            string strDate;

            dicPriceVolume = new Dictionary<string, AAA.Meta.Chart.Data.PriceVolumeData>();
            try
            {
                _database.Open(_strHost, _strDatabase, _strUsername, _strPassword);
                dbReader = _database.ExecuteQuery(_strSQL, new object[] { _strSymbolId, strStartDateTime, strEndDateTime });                

                while (dbReader.Read())
                {
                    //strDate = DateTime.Parse(dbReader["ExTime"].ToString()).ToString("yyyy/MM/dd HH:mm");
                    strDate = DateTime.Parse(dbReader["ExTime"].ToString()).ToString("yyyy/MM/dd HH:mm");

                    if (dicPriceVolume.ContainsKey(strDate) == false)
                    {
                        priceVolumeData = new AAA.Meta.Chart.Data.PriceVolumeData();
                        dicPriceVolume.Add(strDate, priceVolumeData);
                    }
                    else
                    {
                        priceVolumeData = dicPriceVolume[strDate];
                    }

                    priceVolumeData.AddData(float.Parse(dbReader["Price"].ToString()), 
                                            float.Parse(dbReader["DealVol"].ToString()),
                                            float.Parse(dbReader["DealTick"].ToString()));
                }
            }
            catch (Exception ex)
            {
            }

            return dicPriceVolume;
        }
    }
}

