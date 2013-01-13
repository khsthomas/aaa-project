using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.ResultSet;
using AAA.Trade;

namespace AAA.ProgramTrade
{
    public class QuoteUtil
    {
        private const int OPEN_PRICE = 2;
        private const int HIGH_PRICE = 3;
        private const int LOW_PRICE = 4;
        private const int CLOSE_PRICE = 5;
        private const int VOLUME = 6;

        private string _strDataDirectory;

        public string DataDirectory
        {
            get { return _strDataDirectory; }
            set { _strDataDirectory = value; }
        }

        private string ParseFilename(string strSymbolName)
        {
            //買權_yyyy_m_strikeprice

            string strFilename = null;
            string[] strValues = strSymbolName.Split('_');

            switch (strValues[0])
            {
                case "買權":
                case "賣權":
                    strFilename = SymbolCodeHelper.QuerySymbolCode(SymbolCodeHelper.OPTIONS, strValues[3], strValues[0] == "買權" ? "C" : "P", strValues[1], strValues[2]);
                    break;

                case "台指":
                    strFilename = SymbolCodeHelper.QuerySymbolCode(SymbolCodeHelper.FUTURES_BIG, "0", "", strValues[1], strValues[2]);
                    break;

                case "小台":
                    strFilename = SymbolCodeHelper.QuerySymbolCode(SymbolCodeHelper.FUTURES_SMALL, "0", "", strValues[1], strValues[2]);
                    break;
            }

            return strFilename;
        }

        private float GetValue(int iValueType, string strSymbolName, string strDateTime)
        {
            string strFilename;
            float fValue = float.NaN;

            if ((strFilename = ParseFilename(strSymbolName)) == null)
                return fValue;

            IResultSet resultSet = new TextResultSet(DataDirectory + @"\" + strFilename + "_TAIFEX_Min_1.csv", '\t', false);
            
            if (resultSet.Load() == false)
                return fValue;

            while (resultSet.Read())
            {
                fValue = float.Parse(resultSet.Cells(iValueType).ToString());
                if (strDateTime.CompareTo(resultSet.Cells(0) + " " + resultSet.Cells(1)) <= 0)
                    break;

            }
            resultSet.Close();
            return fValue;
        }

        public float GetClosePrice(string strSymbolName, string strDateTime)
        {
            return GetValue(CLOSE_PRICE, strSymbolName, strDateTime);
        }
    }
}
