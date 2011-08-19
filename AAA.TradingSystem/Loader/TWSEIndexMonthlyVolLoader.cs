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
    public class TWSEIndexMonthlyVolLoader : AbstractLoader
    {
        private List<string> _lstField;
        private string _strExDate;
        private List<string> _lstSymbolId;
        private Dictionary<string, string> _dicSymbolIdMapping;

        public TWSEIndexMonthlyVolLoader()
        {                        
            IResultSet resultSet = new TextResultSet(Environment.CurrentDirectory + @"\cfg\index_mapping.ini", false);
            try
            {
                resultSet.Load();
                _lstSymbolId = new List<string>();
                _dicSymbolIdMapping = new Dictionary<string, string>();
                while (resultSet.Read())
                {
                    if ((resultSet.Cells(2).ToString() == "上市") &&
                       (resultSet.Cells(3).ToString() == "指數"))
                    {
                        _lstSymbolId.Add(resultSet.Cells(0).ToString());
                        _dicSymbolIdMapping.Add(resultSet.Cells(1).ToString(),
                                                resultSet.Cells(0).ToString());
                    }
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
            string[] strDates = strSource.Split('/');
            string strDate = "";
            try
            {
                strDate = (1911 + int.Parse(strDates[0])).ToString();
                strDate += "/" + strDates[1];
                strDate += "/" + strDates[2];
                strDate += " 00:00:00";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "," + ex.StackTrace);
            }
            return strDate;
        }

        public override bool Load(AAA.ResultSet.IResultSet resultSet)
        {            
            string strUpdateSQL = "UPDATE TWSE_Stock_D_Deal SET Vol = {0}, Amt = {1}, PreClose = ClosePrice - {2} WHERE ExDate = CDATE('{3}') AND SymbolId = '{4}'";
            string[] strValues;
            string strSymbolName;            

            try
            {
                strValues = new string[5];               
                resultSet.Reset();

                resultSet.Read();
                strSymbolName = resultSet.Cells(4).ToString();

                while(resultSet.Read())
                {
                    Application.DoEvents();
                    if (_dicSymbolIdMapping.ContainsKey(strSymbolName) == false)
                        continue;

                    strValues[0] = resultSet.Cells(1).ToString();
                    strValues[1] = resultSet.Cells(2).ToString();
                    strValues[2] = resultSet.Cells(5).ToString();
                    strValues[3] = ParseDate(resultSet.Cells(0).ToString());
                    strValues[4] = _dicSymbolIdMapping[strSymbolName];

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
