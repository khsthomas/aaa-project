using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.DataLoader;
using System.IO;
using System.Windows.Forms;
using AAA.ResultSet;

namespace AAA.TradingSystem.Loader
{
    public class TWSEIndexDailyLoader : AbstractLoader
    {
        private List<string> _lstField;
        private string _strExDate;
        private List<string> _lstSymbolId;

        public TWSEIndexDailyLoader()
        {
            IResultSet resultSet = new TextResultSet(Environment.CurrentDirectory + @"\cfg\index_mapping.ini", false);
            try
            {
                _lstSymbolId = new List<string>();
                while (resultSet.Read())
                {
                    if ((resultSet.Cells(2) == "上市") &&
                       (resultSet.Cells(2) == "指數"))
                    {

                    }

                }
            }
            catch (Exception ex)
            {

            }
        }

        private string ParseDate(string strSource)
        {
            //100年08月10日每15秒指數統計
            string strDate = "";

            try
            {
                strDate = (1911 + int.Parse(strSource.Substring(0, strSource.IndexOf("年")))).ToString();
                strDate += "/" + strSource.Substring(strSource.IndexOf("年") + 1, strSource.IndexOf("月") - (strSource.IndexOf("年") + 1));
                strDate += "/" + strSource.Substring(strSource.IndexOf("月") + 1, strSource.IndexOf("日") - (strSource.IndexOf("月") + 1));
                strDate += " 00:00:00";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "," + ex.StackTrace);
            }
            return strDate;
        }


        private void ParseHead(string strHead)
        {
            string[] strFields;
            
            try
            {
                strFields = strHead.Split(new string[] {"<th>"}, StringSplitOptions.RemoveEmptyEntries);

                strFields[0] = strFields[0].Substring(strFields[0].IndexOf('>', strFields[0].IndexOf("<th") + 1) + 1);
                strFields[0] = strFields[0].Substring(0, strFields[0].IndexOf('<'));
                _strExDate = ParseDate(strFields[0]);

                _lstField = new List<string>();
                for(int i = 1; i < strFields.Length; i++)
                    _lstField.Add(strFields[i].Replace("</th>", ""));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "," + ex.StackTrace);
            }
        }

        public override bool Load(AAA.ResultSet.IResultSet resultSet)
        {
            string strInsertSQL = "INSERT INTO TWSE_Stock_D_Deal(OpenPrice, HighestPrice, LowestPrice, ClosePrice, Vol, Amt, PreClose, ExDate, SymbolId) VALUES({0}, {1}, {2}, {3}, {4}, {5}, {6}, '{7}', '{8}')";
            string strUpdateSQL = "UPDATE TWSE_Stock_D_Deal SET OpenPrice = {0}, HighestPrice = {1}, LowestPrice = {2}, ClosePrice = {3}, Vol = {4}, Amt = {5}, PreClose = {6} WHERE ExDate = '{7}' AND SymbolId = '{8}'";
            string[] strValues;

            float[] fOpen;
            float[] fHigh;
            float[] fLow;
            float[] fClose;

            try
            {
                strValues = new string[9];
                fOpen = new float[_lstField.Count - 1];
                fHigh = new float[_lstField.Count - 1];
                fLow = new float[_lstField.Count - 1];
                fClose = new float[_lstField.Count - 1];

                ParseHead(resultSet.GetAttribute("Date"));

                resultSet.Reset();

                for (int i = 0; i < fOpen.Length; i++)
                {
                    fOpen[i] = float.NaN;
                    fHigh[i] = float.NaN;
                    fLow[i] = float.NaN;
                    fClose[i] = float.NaN;
                }

                while(resultSet.Read())
                {
                    Application.DoEvents();

                    for (int i = 1; i < resultSet.ColumnCount; i++)
                    {
                        if (float.IsNaN(fOpen[i]))
                        {
                            fOpen[i] = float.Parse(resultSet.Cells(i).ToString());
                            fHigh[i] = float.Parse(resultSet.Cells(i).ToString());
                            fLow[i] = float.Parse(resultSet.Cells(i).ToString());
                        }

                        fClose[i] = float.Parse(resultSet.Cells(i).ToString());
                        fHigh[i] = Math.Max(float.Parse(resultSet.Cells(i).ToString()), fHigh[i]);
                        fLow[i] = Math.Min(float.Parse(resultSet.Cells(i).ToString()), fLow[i]);
                    }
                }

                while(true)
                {
                    try
                    {
                        strValues[0] = resultSet.Cells(5).ToString().Trim(); //Open
                    }
                    catch 
                    {
                        strValues[0] = "0";
                    }
                    try
                    {
                        strValues[1] = resultSet.Cells(6).ToString().Trim(); //High
                    }
                    catch
                    {
                        strValues[1] = "0";
                    }
                    try
                    {
                        strValues[2] = resultSet.Cells(7).ToString().Trim(); //Low
                    }
                    catch
                    {
                        strValues[2] = "0";
                    }
                    try
                    {
                        strValues[3] = resultSet.Cells(8).ToString().Trim(); //Close
                    }
                    catch
                    {
                        strValues[3] = "0";
                    }
                    try
                    {
                        strValues[4] = resultSet.Cells(2).ToString().Trim(); //Vol
                    }
                    catch
                    {
                        strValues[4] = "0";
                    }
                    try
                    {
                        strValues[5] = resultSet.Cells(4).ToString().Trim(); //Amt
                    }
                    catch
                    {
                        strValues[5] = "0";
                    }
                    try
                    {
                        if (resultSet.Cells(9).ToString().Trim() == "")
                            strValues[6] = strValues[3];
                        else
                            strValues[6] = (float.Parse(resultSet.Cells(8).ToString().Trim()) - (resultSet.Cells(9).ToString().Trim() == "－" ? -1.0 : 1.0) * float.Parse(resultSet.Cells(10).ToString().Trim())).ToString(); //PreClose
                    }
                    catch
                    {
                        continue;
                    }

                    strValues[7] = GetLoaderParam("ExDate"); //DateTime
                    strValues[8] = resultSet.Cells(0).ToString().Trim(); //SymbolId

                    if(Database.ExecuteUpdate(strInsertSQL, strValues) != 1)
                        if (Database.ExecuteUpdate(strUpdateSQL, strValues) != 1)
                        {
                            ErrorMessage = Database.ErrorMessage;
                            IsSuccess = false;
                        }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message + "," + ex.StackTrace;
                IsSuccess = false;
            }
            return IsSuccess;
        }
    }
}
