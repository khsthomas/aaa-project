using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AAA.TradeAPI.Polaris
{
    public class Util
    {
        /// <summary>
        /// 將字串結尾補空白字元
        /// </summary>
        /// <param name="strData">欲處理的字串</param>
        /// <param name="intLen">欲達到的Bytes</param>
        /// <returns></returns>
        public static string FillSpace(string strData, int intLen)
        {
            Encoding enc = Encoding.GetEncoding("Big5");//提供big5的編解碼
            int intDataLen = enc.GetByteCount(strData);
            if (intDataLen < intLen)
            {
                StringBuilder strRtnData = new StringBuilder(strData);
                strRtnData.Append(' ', intLen - strData.Length);
                return strRtnData.ToString();
            }
            else
            {
                return strData;
            }
        }

        /// <summary>
        /// 過濾結束字元\0
        /// </summary>
        /// <param name="strFilterData">欲過濾的字串資料</param>
        /// <returns></returns>
        public static string FilterBreakChar(string strFilterData)
        {
            Encoding enc = Encoding.GetEncoding("Big5");//提供Big5的編解碼
            byte[] tmp_bytearyData = enc.GetBytes(strFilterData);
            int intCharLen = tmp_bytearyData.Length;
            int indexCharData = intCharLen;
            for (int i = 0; i < intCharLen; i++)
            {
                if (Convert.ToChar(tmp_bytearyData.GetValue(i)) == 0)
                {
                    indexCharData = i;
                    break;
                }
            }
            return enc.GetString(tmp_bytearyData, 0, indexCharData);
        }

        public static int AccountType(string strAccountType)
        {
            switch (strAccountType)
            {
                case "一般登入":
                    return 0;

                case "分戶登入":
                    return 1;
            }
            return -1;
        }
    }


}
