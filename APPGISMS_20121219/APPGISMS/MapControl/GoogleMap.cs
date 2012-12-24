using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Threading;

namespace MapControl
{
    public class GoogleMap
    {
        private const int RETRY_COUNT = 20;

        public string GetFormatMapLngAndLat(string strAddress)
        {
            string[] strRc = GetMapLngAndLat(strAddress);
            return strRc.Length == 0
                    ?   "0"
                    :   String.Format("經度：{0},緯度：{1}", strRc);
        }

        public string[] GetMapLngAndLat(string strAddress)
        {

            //返回型態，也可以是json或xml等等 
            string output = "csv";
            
            //key值 
            string key = "ABQIAAAAAK87f44qwZO18nBEIqgUThT2yXp_ZAY8_ufC3CFXhHIE1NvwkxSxKQEDQF0tHasyJFQM8GMj__E4yg";

            string url = string.Format("http://maps.google.com/maps/geo?q={0}&output={1}&key={2}", strAddress, output, key);

            int iRetryCount = 0;

            while (iRetryCount++ < RETRY_COUNT)
            {
                // 送出要求 
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                // 取得回應 
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    // 讀取結果 
                    using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                    {
                        //取回結果 
                        //[0] 是回應狀態 
                        //[1]是accuracy(精度) 
                        //[2]是緯度 
                        //[3]是經度 

                        string[] tmpArray = sr.ReadToEnd().Split(',');

                        if (tmpArray[0] == "200")
                        {
                            string latitude = tmpArray[2];

                            string longitude = tmpArray[3];

                            return new string[] { longitude, latitude };
                        }
                        else
                        {
                            Thread.Sleep(2000);
                        }
                    }
                }
            }
            return new string[0];
        }
    }
}
