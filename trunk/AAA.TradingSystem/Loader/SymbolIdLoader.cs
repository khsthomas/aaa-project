using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.DataLoader;
using AAA.ResultSet;
using System.Windows.Forms;

namespace AAA.TradingSystem.Loader
{
    public class SymbolIdLoader : AbstractLoader
    {        
        public override bool Load(IResultSet resultSet)
        {
            string strDeleteSQL = "DELETE FROM SymbolProfile";
            //string strInsertSQL = "INSERT INTO SymbolProfile(SymbolId, SymbolName, MarketPlace, Industral) VALUES('{0}', '{1}', '{2}', '{3}')";
            string strInsertSQL = "INSERT INTO SymbolProfile(SymbolId, SymbolName, MarketPlace, Industral) VALUES(@SymbolId, @SymbolName, @MarketPlace, @Industral)";

            string[] strValues;
            string[] strFields = { "SymbolId", "SymbolName", "MarketPlace", "Industral" };
            string[] strSymbols;
            try
            {
//                Database.ExecuteUpdate(strDeleteSQL);
                strValues = new string[4];

                while(resultSet.Read())
                {
                    Application.DoEvents();
                    if((strValues[3] = resultSet.Cells(4).ToString().Trim()) == "")
                        continue; 
                    
                    strSymbols = resultSet.Cells(0).ToString().Split(' ');                                       

                    strValues[0] = strSymbols[0].Trim();
                    for(int i = 1; i < strSymbols.Length; i++)
                        if(strSymbols[i].Trim() != "")
                            strValues[1] = strSymbols[i].Trim();
                    strValues[2] = resultSet.Cells(3).ToString().Trim();
                    Database.ExecuteUpdate(strInsertSQL, strFields, strValues);
                }

            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message + "," + ex.StackTrace;
            }
            return false;
        }
    }
}
