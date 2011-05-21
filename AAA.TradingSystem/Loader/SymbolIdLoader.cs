using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.DataLoader;
using AAA.ResultSet;

namespace AAA.TradingSystem.Loader
{
    public class SymbolIdLoader : AbstractLoader
    {        
        public override bool Load(IResultSet resultSet)
        {
            string strDeleteSQL = "DELETE FROM SymbolProfile";
            string strInsertSQL = "INSERT INTO SymbolProfile(SymbolId, SymbolName, MarketPlace, Industral) VALUES('{0}', '{1}', '{2}', '{3}')";
            try
            {
                
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message + "," + ex.StackTrace;
            }
        }
    }
}
