using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Database;
using System.Data.Common;
using AAA.Finacial.Indicator;
using System.Windows.Forms;

namespace AAA.TradingSystem.Indicator
{
    public class CalculateIndicator
    {
        private IDatabase _databaseQuery;
        private IDatabase _databaseUpdate;
        private string _strStartDate;

        public CalculateIndicator(string strHost, string strDatabase, string strUsername, string strPassword)
        {
            _databaseQuery = new AccessDatabase();
            _databaseQuery.Open(strDatabase, strUsername, strPassword);

            _databaseUpdate = new AccessDatabase();
            _databaseUpdate.Open(strDatabase, strUsername, strPassword);
        }

        private string ParseDate(string strSource)
        {
            string strDate = "1900/01/01 00:00:00";
            string[] strValues;

            try
            {
                strValues = strSource.Substring(0, strSource.IndexOf(' ')).Split('/');
                strDate = strValues[0] + "/" +
                    (strValues[1].Length == 1 ? "0" + strValues[1] : strValues[1]) + "/" +
                    (strValues[2].Length == 1 ? "0" + strValues[2] : strValues[2]);

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message + "," + ex.StackTrace);
            }

            return strDate;
        }

        public void SetStartDate(string strStartDate)
        {
            _strStartDate = strStartDate;
        }

        public void Calculate()
        {
            DbDataReader dataReader;
            List<string> lstSymbolId;
            string strStartTime = "";
            List<float> lstOpen;
            List<float> lstHigh;
            List<float> lstLow;
            List<float> lstClose;
            List<float> lstVolume;
            List<float> lstA;
            List<float> lstB;
            List<float> lstC;
            List<float> lstRedBlack;

            object[] oValues;
            bool hasNull;

            float fMA3;
            float fMA6;
            float fMA18;
            float fMA72;
            float fA;
            float fB;
            float fC;
            float fVolMA3;
            float fVolMA6;
            float fVolMA18;
            float fBias;
            float fRed;
            float fBlack;
            float fPreVol1;
            float fPreVol2;
            float fPreVol3;
            float fPreVol5;
            float fRedBlack3;
            string strInsertSQL = "INSERT INTO TWSE_Stock_D_Index(Index1, Index2, Index3, Index4, Index5, Index6, Index7, Index8, Index9, Index10, Index11, Index12, Index13, Index14, Index15, Index16, Index17, Index18, ExDate, SymbolId) VALUES({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12},  {13}, {14}, {15}, {16}, {17}, CDATE('{18}'), '{19}')";
            string strUpdateSQL = "UPDATE TWSE_Stock_D_Index SET Index1 = {0}, Index2 = {1}, Index3 = {2}, Index4 = {3}, Index5 = {4}, Index6 = {5}, Index7 = {6}, Index8 = {7}, Index9 = {8}, Index10 = {9}, Index11 = {10}, Index12 = {11}, Index13 = {12}, Index14 = {13}, Index15 = {14}, Index16 = {15}, Index17 = {16}, Index18 = {17} WHERE ExDate = CDATE('{18}') AND SymbolId = '{19}'";

            try
            {
                dataReader = _databaseQuery.ExecuteQuery("SELECT DISTINCT SymbolId FROM TWSE_Stock_D_Deal");
                lstSymbolId = new List<string>();

                while (dataReader.Read())
                    lstSymbolId.Add(dataReader["SymbolId"].ToString()); ;

                dataReader.Close();

                for (int i = 0; i < lstSymbolId.Count; i++)
                {
                    if (_strStartDate == null)
                    {
                        dataReader = _databaseQuery.ExecuteQuery("SELECT MAX(ExDate) FROM TWSE_Stock_D_Index WHERE SymbolId = '{0}'", new object[] { lstSymbolId[i] });

                        while (dataReader.Read())
                            strStartTime = dataReader[0].ToString() == "" ? "1900/01/01 00:00:00" : DateTime.Parse(dataReader[0].ToString()).AddDays(-120).ToString("yyyy/MM/dd") + " 00:00:00";
                        dataReader.Close();

                    }
                    else
                    {
                        strStartTime = _strStartDate + " 00:00:00";
                    }

                    

                    dataReader = _databaseQuery.ExecuteQuery("SELECT ExDate, OpenPrice, HighestPrice, LowestPrice, ClosePrice, Vol FROM TWSE_Stock_D_Deal WHERE ExDate >= CDATE('{0}') AND SymbolId = '{1}' ORDER BY ExDate", new object[] { strStartTime, lstSymbolId[i] });
                    lstOpen = new List<float>();
                    lstHigh = new List<float>();
                    lstLow = new List<float>();
                    lstClose = new List<float>();
                    lstVolume = new List<float>();                    
                    lstA = new List<float>();
                    lstB = new List<float>();
                    lstC = new List<float>();
                    lstRedBlack = new List<float>();

                    while (dataReader.Read())
                    {
                        Application.DoEvents();
                        lstOpen.Add(float.Parse(dataReader["OpenPrice"].ToString()));
                        lstHigh.Add(float.Parse(dataReader["HighestPrice"].ToString()));
                        lstLow.Add(float.Parse(dataReader["LowestPrice"].ToString()));
                        lstClose.Add(float.Parse(dataReader["ClosePrice"].ToString()));
                        lstVolume.Add(float.Parse(dataReader["Vol"].ToString()));

                        fMA3 = TechnicalIndex.MA(lstClose, 3);
                        fMA6 = TechnicalIndex.MA(lstClose, 6);
                        fMA18 = TechnicalIndex.MA(lstClose, 18);
                        fMA72 = TechnicalIndex.MA(lstClose, 72);
                        fVolMA3 = TechnicalIndex.MA(lstVolume, 3);
                        fVolMA6 = TechnicalIndex.MA(lstVolume, 6);
                        fVolMA18 = TechnicalIndex.MA(lstVolume, 18);
                        fBias = (float.IsNaN(fMA3) || float.IsNaN(fMA6)) ? float.NaN : fMA3 - fMA6;

                        fC = (lstClose.Count > 3) ? 2 * lstClose[lstClose.Count - 1] - lstClose[lstClose.Count - 4]: float.NaN;
                        lstC.Add(fC);

                        fB = (lstC.Count > 1) ? lstC[lstC.Count - 2] : float.NaN;
                        lstB.Add(fB);

                        fA = (lstB.Count > 1) ? lstB[lstB.Count - 2] : float.NaN;
                        lstA.Add(fA);

                        fRed = (lstClose.Count == 1) 
                                    ?  0
                                    :  (lstClose[lstClose.Count - 1] > lstClose[lstClose.Count - 2])
                                        ? lstClose[lstClose.Count - 1] - lstLow[lstLow.Count - 1]
                                        : 0;

                        fBlack = (lstClose.Count == 1)
                                    ? 0
                                    : (lstClose[lstClose.Count - 1] < lstClose[lstClose.Count - 2])
                                        ? lstClose[lstClose.Count - 1] - lstHigh[lstHigh.Count - 1]
                                        : 0;

                        lstRedBlack.Add(fRed + fBlack);

                        fPreVol1 = (lstVolume.Count > 1) ? lstVolume[lstVolume.Count - 2] : float.NaN;
                        fPreVol2 = (lstVolume.Count > 2) ? lstVolume[lstVolume.Count - 3] : float.NaN;
                        fPreVol3 = (lstVolume.Count > 3) ? lstVolume[lstVolume.Count - 4] : float.NaN;
                        fPreVol5 = (lstVolume.Count > 5) ? lstVolume[lstVolume.Count - 6] : float.NaN;

                        fRedBlack3 = float.NaN;

                        if (lstRedBlack.Count >= 3)
                        {
                            fRedBlack3 = 0;

                            for (int j = 0; j < 3; j++)
                            {
                                fRedBlack3 += lstRedBlack[lstRedBlack.Count - j - 1];
                            }
                        }

                        oValues = new object[] {fMA3,
                                                fMA6,
                                                fMA18,
                                                fMA72,
                                                fVolMA3,
                                                fVolMA6,
                                                fVolMA18,
                                                fBias,
                                                fA,
                                                fB,
                                                fC,
                                                fRed,
                                                fBlack,
                                                fPreVol1,
                                                fPreVol2,
                                                fPreVol3,
                                                fPreVol5,
                                                fRedBlack3,
                                                ParseDate(dataReader["ExDate"].ToString()),
                                                lstSymbolId[i]};

                        hasNull = false;
                        for(int j = 0; j < oValues.Length - 2; j++)
                            if (float.IsNaN((float)oValues[j]))
                            {
//                                  oValues[j] = "0";
                                oValues[j] = "null";
                                hasNull = true;
                            }

//                        if (hasNull)
//                            continue;

                        if (_databaseUpdate.ExecuteUpdate(strInsertSQL, oValues) != 1)
                            if (_databaseUpdate.ExecuteUpdate(strUpdateSQL, oValues) != 1)
                                MessageBox.Show(_databaseUpdate.ErrorMessage);

                    }
                    dataReader.Close();

                }


            }
            catch (Exception ex)
            {

            }
        }

    }
}
