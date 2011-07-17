using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.DataLoader;
using System.IO;
using System.Windows.Forms;

namespace AAA.TradingSystem.Loader
{
    public class TWSEIndexDailyLoader : AbstractLoader
    {
        public override bool Load(AAA.ResultSet.IResultSet resultSet)
        {
            string strInsertSQL = "INSERT INTO TWSE_Stock_D_Deal(OpenPrice, HighestPrice, LowestPrice, ClosePrice, Vol, Amt, PreClose, ExDate, SymbolId) VALUES({0}, {1}, {2}, {3}, {4}, {5}, {6}, '{7}', '{8}')";
            string strUpdateSQL = "UPDATE TWSE_Stock_D_Deal SET OpenPrice = {0}, HighestPrice = {1}, LowestPrice = {2}, ClosePrice = {3}, Vol = {4}, Amt = {5}, PreClose = {6} WHERE ExDate = '{7}' AND SymbolId = '{8}'";

            string[] strValues;
            
            try
            {
                strValues = new string[9];

                while(resultSet.Read())
                {
                    Application.DoEvents();
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
