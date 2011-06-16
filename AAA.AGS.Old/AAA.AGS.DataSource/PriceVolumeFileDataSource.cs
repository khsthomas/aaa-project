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
    public class PriceVolumeFileDataSource : AbstractPriceVolumeDataSource
    {
        private Dictionary<string, AAA.Meta.Chart.Data.PriceVolumeData> _dicPriceVolume;
        private int _iDateIndex = 0;
        private int _iTimeIndex = 1;
        private int _iDataStart = 2;

        public PriceVolumeFileDataSource(string strFile, string strSymbolId)
        {
            StreamReader sr = null;
            string strLine;
            string[] strValues;
            AAA.Meta.Chart.Data.PriceVolumeData priceVolumeData = null;

            try
            {
                sr = new StreamReader(strFile);
                _dicPriceVolume = new Dictionary<string, AAA.Meta.Chart.Data.PriceVolumeData>();

                while ((strLine = sr.ReadLine()) != null)
                {
                    strValues = strLine.Split(',');

                    if (_dicPriceVolume.ContainsKey(strValues[0]) == false)
                    {
                        priceVolumeData = new AAA.Meta.Chart.Data.PriceVolumeData();
                        priceVolumeData.AddData(float.Parse(strValues[2]), float.Parse(strValues[3]));
                        _dicPriceVolume.Add(strValues[0], priceVolumeData);
                    }
                    else
                    {
                        _dicPriceVolume[strValues[0]].AddData(float.Parse(strValues[2]), float.Parse(strValues[3]));
                    }
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

        public override Dictionary<string, AAA.Meta.Chart.Data.PriceVolumeData> GetPriceVolume(Dictionary<string, string> queryProperties)
        {
            AAA.Meta.Chart.Data.PriceVolumeData priceVolumeData;
            Dictionary<string, AAA.Meta.Chart.Data.PriceVolumeData> dicPriceVolume;
            string strStartDateTime = queryProperties.ContainsKey("StartDateTime") ? "1900/01/01 00:00:00" : queryProperties["StartDateTime"];
            string strEndDateTime = queryProperties.ContainsKey("EndDateTime") ? DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") : queryProperties["EndDateTime"];
            List<float> lstPrice;
            List<float> lstVolume;
            string strDate;
            DateTime dStart = DateTime.Parse(strStartDateTime);
            DateTime dEnd = DateTime.Parse(strEndDateTime);
            
            dicPriceVolume = new Dictionary<string, AAA.Meta.Chart.Data.PriceVolumeData>();

            foreach (string strDateTime in _dicPriceVolume.Keys)
            {
                if (DateTime.Parse(strDateTime) < dStart || DateTime.Parse(strDateTime) > dEnd)
                    continue;

                strDate = strDateTime.Substring(0, 10);

                if (dicPriceVolume.ContainsKey(strDate) == false)
                {
                    priceVolumeData = new AAA.Meta.Chart.Data.PriceVolumeData();
                    dicPriceVolume.Add(strDate, priceVolumeData);
                }
                else
                {
                    priceVolumeData = dicPriceVolume[strDate];
                }

                lstPrice = _dicPriceVolume[strDateTime].Price;
                lstVolume = _dicPriceVolume[strDateTime].Volume;

                for (int i = 0; i < lstPrice.Count; i++)
                    priceVolumeData.AddData(lstPrice[i], lstVolume[i]);
            }

            return dicPriceVolume;
        }
    }
}

