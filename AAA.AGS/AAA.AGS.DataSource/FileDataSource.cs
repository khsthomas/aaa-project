using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Meta.Quote.Data;
using System.IO;
using AAA.Meta.Quote;
using AAA.Meta.Chart.Data;

namespace AAA.AGS.DataSource
{
    public class FileDataSource : AbstractHisDataSource
    {
        private List<BarRecord> _lstBarRecord;
        private int _iDateIndex = 0;
        private int _iTimeIndex = 1;
        private int _iDataStart = 2;

        public FileDataSource(string strFile, string strSymbolId, string strBarCompression)
        {
            StreamReader sr = null;
            string strLine;
            string[] strValues;
            BarRecord barRecord = null;

            try
            {
                sr = new StreamReader(strFile);
                _lstBarRecord = new List<BarRecord>();

                while ((strLine = sr.ReadLine()) != null)
                {
                    strValues = strLine.Split(',');
                    barRecord = new BarRecord();
                    barRecord.BarDateTime = DateTime.Parse(strValues[_iDateIndex] + " " + strValues[_iTimeIndex]);
                    barRecord.BarCompression = (BarCompressionEnum)Enum.Parse(typeof(BarCompressionEnum), strBarCompression);
                    if(strValues.Length > _iDataStart)
                        barRecord.V0 = float.Parse(strValues[_iDataStart]);
                    if (strValues.Length > _iDataStart + 1)
                        barRecord.V1 = float.Parse(strValues[_iDataStart + 1]);
                    if (strValues.Length > _iDataStart + 2)
                        barRecord.V2 = float.Parse(strValues[_iDataStart + 2]);
                    if (strValues.Length > _iDataStart + 3)
                        barRecord.V3 = float.Parse(strValues[_iDataStart + 3]);
                    if (strValues.Length > _iDataStart + 4)
                        barRecord.V4 = float.Parse(strValues[_iDataStart + 4]);
                    if (strValues.Length > _iDataStart + 5)
                        barRecord.V5 = float.Parse(strValues[_iDataStart + 5]);
                    _lstBarRecord.Add(barRecord);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "," + ex.StackTrace);
            }
            finally
            {
                if (sr != null)
                    sr.Close();
            }
        }

        public override List<BarRecord> GetData(Dictionary<string, string> queryProperties)
        {
            List<BarRecord> lstReturn = new List<BarRecord>();
            string strStartDateTime = queryProperties.ContainsKey("StartDateTime") ? queryProperties["StartDateTime"] : "1900/01/01 00:00:00";
            string strEndDateTime = queryProperties.ContainsKey("EndDateTime") ? queryProperties["EndDateTime"] : DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            DateTime dStart = DateTime.Parse(strStartDateTime);
            DateTime dEnd = DateTime.Parse(strEndDateTime);

            foreach (BarRecord barRecord in _lstBarRecord)
            {
                if (barRecord.BarDateTime < dStart || barRecord.BarDateTime > dEnd)
                    continue;

                lstReturn.Add(barRecord);
            }

            return lstReturn;
        }

        public override List<T> GetData<T>(Dictionary<string, string> queryProperties)
        {
            throw new NotImplementedException();
        }
    }
}
