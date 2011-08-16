using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.DataLoader;
using System.IO;

namespace AAA.TradingSystem.Loader
{ 
    public class OTCStockDailyLoader : AbstractLoader
    {
        //代碼 名稱 收盤 漲跌 開盤 最高 最低 均價 成交股數 成交金額 成交筆數 最後買價 最後賣價 發行股數 次日參考價 次日漲停價 次日跌停價
        private string ParseDate(string strSource)
        {
            //100年06月24日大盤統計資訊            
            string strDate = "";
            int iStart;
            int iEnd;
            try
            {
                iStart = 0;
                iEnd = strSource.LastIndexOf('&');
                strSource = strSource.Substring(iStart, iEnd - iStart);
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

        public override bool Load(AAA.ResultSet.IResultSet resultSet)
        {
            string strInsertSQL = "INSERT INTO TWSE_Stock_D_Deal(OpenPrice, HighestPrice, LowestPrice, ClosePrice, Vol, Amt, PreClose, ExDate, SymbolId) VALUES({0}, {1}, {2}, {3}, {4}, {5}, {6}, CDATE('{7}'), '{8}')";
            string strUpdateSQL = "UPDATE TWSE_Stock_D_Deal SET OpenPrice = {0}, HighestPrice = {1}, LowestPrice = {2}, ClosePrice = {3}, Vol = {4}, Amt = {5}, PreClose = {6} WHERE ExDate = CDATE('{7}') AND SymbolId = '{8}'";

            string[] strValues;
            string strDiff;

            try
            {
                strValues = new string[9];

                while (resultSet.Read())
                {
                    try
                    {
                        strValues[0] = resultSet.Cells(4).ToString().Trim().Replace("⊕", "").Replace("⊙", ""); //Open
                    }
                    catch
                    {
                        strValues[0] = "0";
                    }
                    try
                    {
                        strValues[1] = resultSet.Cells(5).ToString().Trim().Replace("⊕", "").Replace("⊙", ""); //High
                    }
                    catch
                    {
                        strValues[1] = "0";
                    }
                    try
                    {
                        strValues[2] = resultSet.Cells(6).ToString().Trim().Replace("⊕", "").Replace("⊙", ""); //Low
                    }
                    catch
                    {
                        strValues[2] = "0";
                    }
                    try
                    {
                        strValues[3] = resultSet.Cells(2).ToString().Trim().Replace("⊕", "").Replace("⊙", ""); //Close
                    }
                    catch
                    {
                        strValues[3] = "0";
                    }
                    try
                    {
                        strValues[4] = resultSet.Cells(8).ToString().Trim(); //Vol
                    }
                    catch
                    {
                        strValues[4] = "0";
                    }
                    try
                    {
                        strValues[5] = resultSet.Cells(9).ToString().Trim(); //Amt
                    }
                    catch
                    {
                        strValues[5] = "0";
                    }
                    try
                    {
                        strDiff = resultSet.Cells(3).ToString().Trim();

                        if (resultSet.Cells(9).ToString().Trim().Replace("⊕", "").Replace("⊙", "") == "")
                            strValues[6] = strValues[3];
                        else
                            strValues[6] = (float.Parse(strValues[3]) - (strDiff.IndexOf("-") > -1 ? -1.0 : 1.0) * float.Parse(strDiff.Replace("+", "").Replace("-", ""))).ToString(); //PreClose
                    }
                    catch
                    {
                        continue;
                    }

                    if (resultSet.GetAttribute("Date") == null)
                        strValues[7] = GetLoaderParam("ExDate"); //DateTime
                    else
                        strValues[7] = ParseDate(resultSet.GetAttribute("Date"));

                    if (strValues[7] != GetLoaderParam("ExDate"))
                        break;

                    strValues[8] = resultSet.Cells(0).ToString().Trim(); //SymbolId

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
