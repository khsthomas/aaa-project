using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Database;
using System.Data.Common;
using AAA.Finacial.Indicator;
using System.Windows.Forms;
using System.IO;

namespace AAA.TradingSystem.Indicator
{
    public class CalculateIndicator
    {
        private IDatabase _databaseQuery;
        private IDatabase _databaseUpdate;
        private string _strStartDate;
        private string _strDatabase;
        private string _strUsername;
        private string _strPassword;

        public CalculateIndicator(string strHost, string strDatabase, string strUsername, string strPassword)
        {
            _databaseQuery = new AccessDatabase();
            _databaseQuery.Open(strDatabase, strUsername, strPassword);

            _databaseUpdate = new AccessDatabase();
            _databaseUpdate.Open(strDatabase, strUsername, strPassword);

            _strDatabase = strDatabase;
            _strUsername = strUsername;
            _strPassword = strPassword;
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
            int iNullErrorCount = 0;
            bool needReopen = false;
            object[] oValues = null;
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

            float fHighest20;
            float fLowest20;
            float fDiff10;
            float fVolMA5;
            float fVolMA20;
            float fMA20;
            float fBias20;

            string strInsertSQL = "INSERT INTO TWSE_Stock_D_Index(Index1, Index2, Index3, Index4, Index5, Index6, Index7, Index8, Index9, Index10, Index11, Index12, Index13, Index14, Index15, Index16, Index17, Index18, Index19, Index20, Index21, Index22, Index23, Index24, Index25, Index26, Index27, Index28, Index29, Index30, Index31, ExDate, SymbolId) VALUES({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12},  {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}, {26}, {27}, {28}, {29}, {30}, CDATE('{31}'), '{32}')";
            string strUpdateSQL = "UPDATE TWSE_Stock_D_Index SET Index1 = {0}, Index2 = {1}, Index3 = {2}, Index4 = {3}, Index5 = {4}, Index6 = {5}, Index7 = {6}, Index8 = {7}, Index9 = {8}, Index10 = {9}, Index11 = {10}, Index12 = {11}, Index13 = {12}, Index14 = {13}, Index15 = {14}, Index16 = {15}, Index17 = {16}, Index18 = {17}, Index19 = {18}, Index20 = {19}, Index21 = {20}, Index22 = {21}, Index23 = {22}, Index24 = {23}, Index25 = {24}, Index26 = {25}, Index27 = {26}, Index28 = {27}, Index29 = {28}, Index30 = {29}, Index31 = {30} WHERE ExDate = CDATE('{31}') AND SymbolId = '{32}'";
            string strScalarSQL = "SELECT COUNT(*) FROM TWSE_Stock_D_Index WHERE ExDate = CDATE('{0}') AND SymbolId = '{1}'";

            try
            {
                dataReader = _databaseQuery.ExecuteQuery("SELECT DISTINCT SymbolId FROM TWSE_Stock_D_Deal");
                lstSymbolId = new List<string>();

                while (dataReader.Read())
                    lstSymbolId.Add(dataReader["SymbolId"].ToString()); ;

                dataReader.Close();

                for (int i = 0; i < lstSymbolId.Count; i++)
                {
                    if (needReopen)
                    {
                        _databaseQuery = new AccessDatabase();
                        _databaseQuery.Open(_strDatabase, _strUsername, _strPassword);

                        _databaseUpdate = new AccessDatabase();
                        _databaseUpdate.Open(_strDatabase, _strUsername, _strPassword);
                        needReopen = false;
                    }

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

                    if (dataReader == null)
                    {
                        iNullErrorCount++;
                        if (iNullErrorCount > 5)
                        {
                            iNullErrorCount = 0;
                            i++;
                        }
                        continue;
                    }

                    while (dataReader.Read())
                    {
                        try
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



                            fHighest20 = TechnicalIndex.Highest(lstClose, 20);
                            fLowest20 = TechnicalIndex.Lowest(lstClose, 20);
                            fDiff10 = (lstClose.Count >= 10) ? (lstClose[lstClose.Count - 10] == 0 ? float.NaN : (lstClose[lstClose.Count - 1] - lstClose[lstClose.Count - 10]) / lstClose[lstClose.Count - 10]) : float.NaN;
                            fVolMA5 = TechnicalIndex.MA(lstVolume, 5);
                            fVolMA20 = TechnicalIndex.MA(lstVolume, 20);
                            fMA20 = TechnicalIndex.MA(lstClose, 20);
                            fBias20 = (float.IsNaN(fMA20) ? (float)-999999 : lstClose[lstClose.Count - 1] - fMA20);

                            fC = (lstClose.Count > 3) ? 2 * lstClose[lstClose.Count - 1] - lstClose[lstClose.Count - 4] : float.NaN;
                            lstC.Add(fC);

                            fB = (lstC.Count > 1) ? lstC[lstC.Count - 2] : float.NaN;
                            lstB.Add(fB);

                            fA = (lstB.Count > 1) ? lstB[lstB.Count - 2] : float.NaN;
                            lstA.Add(fA);

                            fRed = (lstClose.Count == 1)
                                        ? 0
                                        : (lstClose[lstClose.Count - 1] > lstClose[lstClose.Count - 2])
                                            ? lstClose[lstClose.Count - 1] - lstLow[lstLow.Count - 1]
                                            : 0;

                            fBlack = (lstClose.Count == 1)
                                        ? 0
                                        : (lstClose[lstClose.Count - 1] < lstClose[lstClose.Count - 2])
                                            ? lstClose[lstClose.Count - 1] - lstHigh[lstHigh.Count - 1]
                                            : 0;

                            lstRedBlack.Add(fRed + fBlack);

                            fPreVol1 = (lstVolume.Count > 1) ? lstVolume[lstVolume.Count - 2] : float.NaN;

                            if (lstVolume.Count > 2)
                            {
                                fPreVol2 = Math.Max(lstVolume[lstVolume.Count - 2], lstVolume[lstVolume.Count - 3]);
                            }
                            else
                            {
                                fPreVol2 = float.NaN;
                            }

                            if (lstVolume.Count > 3)
                            {
                                fPreVol3 = lstVolume[lstVolume.Count - 2];

                                for (int j = 1; j < 3; j++)
                                {
                                    fPreVol3 = Math.Max(fPreVol3, lstVolume[lstVolume.Count - 2 - j]);
                                }
                            }
                            else
                            {
                                fPreVol3 = float.NaN;
                            }

                            if (lstVolume.Count > 5)
                            {
                                fPreVol5 = lstVolume[lstVolume.Count - 2];

                                for (int j = 1; j < 5; j++)
                                {
                                    fPreVol5 = Math.Max(fPreVol5, lstVolume[lstVolume.Count - 2 - j]);
                                }
                            }
                            else
                            {
                                fPreVol5 = float.NaN;
                            }

                            fRedBlack3 = float.NaN;

                            if (lstRedBlack.Count >= 3)
                            {
                                fRedBlack3 = 0;

                                for (int j = 0; j < 3; j++)
                                {
                                    fRedBlack3 += lstRedBlack[lstRedBlack.Count - j - 1];
                                }
                            }

                            oValues = new object[] {fMA3,       //1
                                                fMA6,       //2
                                                fMA18,      //3
                                                fMA72,      //4
                                                fVolMA3,    //5
                                                fVolMA6,    //6
                                                fVolMA18,   //7
                                                fBias,      //8
                                                fA,         //9
                                                fB,         //10
                                                fC,         //11
                                                fRed,       //12
                                                fBlack,     //13
                                                fPreVol1,   //14
                                                fPreVol2,   //15
                                                fPreVol3,   //16
                                                fPreVol5,   //17
                                                fRedBlack3, //18
                                                fHighest20, //19
                                                fLowest20,  //20
                                                fDiff10,    //21
                                                fVolMA5,    //22
                                                fVolMA20,   //23
                                                fMA20,      //24
                                                fBias20,    //25
                                                (float)((lstClose[lstClose.Count - 1] == fHighest20) ? 1 : 0),   //26 Highest20
                                                (float)((lstClose[lstClose.Count - 1] == fLowest20) ? 1 : 0),    //27 Lowest20
                                                (float)((fDiff10 > 0.1 && fVolMA5 > fVolMA20) ? 1 : 0),          //28 Demand20
                                                (float)((fBias20 > 0) ? 1 : 0),                                  //29 PosBias20
                                                (float)((fDiff10 < -0.1 && fVolMA5 < fVolMA20) ? 1 : 0),         //30 AntiDemand20
                                                (float)((fBias20 < 0) ? 1 : 0),                                  //31 NegBias20
                                                ParseDate(dataReader["ExDate"].ToString()),
                                                lstSymbolId[i]};

                            hasNull = false;
                            for (int j = 0; j < oValues.Length - 2; j++)
                                if (float.IsNaN((float)oValues[j]))
                                {
                                    oValues[j] = "null";
                                    hasNull = true;
                                }
                            
                            if (_databaseUpdate.ExecuteUpdate(strUpdateSQL, oValues) != 1)
                                if (_databaseUpdate.ExecuteUpdate(strInsertSQL, oValues) != 1)
                                    MessageBox.Show(_databaseUpdate.ErrorMessage);
                        }
                        catch (Exception ex)
                        {
                            StreamWriter sw = new StreamWriter(Environment.CurrentDirectory + @"\download.log");
                            sw.WriteLine("-Calculate-E-" + ex.Message + "-" + string.Format(strInsertSQL, oValues) + "\n" + ex.StackTrace);
                            sw.Close();
                        }
                    }
                    dataReader.Close();
                    iNullErrorCount = 0;

                    needReopen = (DatabaseUtil.CompressAccess(_strDatabase, "stock") == null);
                }
            }
            catch (Exception ex)
            {
                StreamWriter sw = new StreamWriter(Environment.CurrentDirectory + @"\download.log");
                sw.WriteLine("-Calculate-E-" + ex.Message + "\n" + ex.StackTrace);
                sw.Close();
            }
        }

    }
}
