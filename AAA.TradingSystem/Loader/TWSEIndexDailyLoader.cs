using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.DataLoader;
using System.IO;
using System.Windows.Forms;
using AAA.ResultSet;
using AAA.Database;

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
                resultSet.Load();
                _lstSymbolId = new List<string>();
                while (resultSet.Read())
                {
                    if ((resultSet.Cells(2).ToString() == "上市") &&
                       (resultSet.Cells(3).ToString() == "指數"))
                        _lstSymbolId.Add(resultSet.Cells(0).ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "," + ex.StackTrace);
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
                strFields = strHead.Split(new string[] {"</th>"}, StringSplitOptions.RemoveEmptyEntries);
                _strExDate = ParseDate(strFields[0].Substring(strFields[0].LastIndexOf('>') + 1));

                _lstField = new List<string>();
                for (int i = 2; i < strFields.Length; i++)
                {
                    if (strFields[i].IndexOf("tr") > -1)
                        continue;
                    if (strFields[i].IndexOf("div") > -1)
                    {
                        strFields[i] = strFields[i].Replace("</div>", "");
                        _lstField.Add(strFields[i].Substring(strFields[i].LastIndexOf('>') + 1));
                    }
                    else
                    {
                        _lstField.Add(strFields[i].Replace("<th>", ""));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "," + ex.StackTrace);
            }
        }

        public override bool Load(AAA.ResultSet.IResultSet resultSet)
        {
            string strInsertSQL = "INSERT INTO TWSE_Stock_D_Deal(OpenPrice, HighestPrice, LowestPrice, ClosePrice, Vol, Amt, PreClose, ExDate, SymbolId) VALUES({0}, {1}, {2}, {3}, {4}, {5}, {6}, CDATE('{7}'), '{8}')";
            string strUpdateSQL = "UPDATE TWSE_Stock_D_Deal SET OpenPrice = {0}, HighestPrice = {1}, LowestPrice = {2}, ClosePrice = {3}, Vol = {4}, Amt = {5}, PreClose = {6} WHERE ExDate = CDATE('{7}') AND SymbolId = '{8}'";
            string[] strValues;

            float[] fOpen;
            float[] fHigh;
            float[] fLow;
            float[] fClose;

            try
            {
                ParseHead(resultSet.GetAttribute("Date"));
                strValues = new string[9];
                fOpen = new float[_lstField.Count];
                fHigh = new float[_lstField.Count];
                fLow = new float[_lstField.Count];
                fClose = new float[_lstField.Count];
               
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

                    for (int i = 0; i < resultSet.ColumnCount - 1; i++)
                    {
                        if (float.IsNaN(fOpen[i]))
                        {
                            fOpen[i] = float.Parse(resultSet.Cells(i + 1).ToString());
                            fHigh[i] = float.Parse(resultSet.Cells(i + 1).ToString());
                            fLow[i] = float.Parse(resultSet.Cells(i + 1).ToString());
                        }

                        fClose[i] = float.Parse(resultSet.Cells(i + 1).ToString());
                        fHigh[i] = Math.Max(float.Parse(resultSet.Cells(i + 1).ToString()), fHigh[i]);
                        fLow[i] = Math.Min(float.Parse(resultSet.Cells(i + 1).ToString()), fLow[i]);
                    }                    
                }
                
                for (int i = 0; i < fOpen.Length; i++)
                {
                    strValues[0] = fOpen[i].ToString();
                    strValues[1] = fHigh[i].ToString();
                    strValues[2] = fLow[i].ToString();
                    strValues[3] = fClose[i].ToString();
                    strValues[4] = "0";
                    strValues[5] = "0";
                    strValues[6] = "0";
                    strValues[7] = _strExDate; //DateTime
                    strValues[8] = _lstSymbolId[i].Trim(); //SymbolId
                    if (Database.ExecuteUpdate(strInsertSQL, strValues) != 1)
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
