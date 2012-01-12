using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Command.WCF;
using AAA.ResultSet;
using AAA.Database;

namespace AAA.PublisherService.Command
{
    public class LoadAccountCommand : DatabaseCommand
    {
        protected override int ExecuteCommand(Dictionary<string, string> dicModel)
        {
            IDatabase database = CreateDatabase();
            string strDeleteSQL = "DELETE FROM Account";            
            string strInsertSQL = "INSERT INTO Account(AccountId, UserPassword, StartDate, ExpiredDate, ActiveFlag) VALUES('{0}', '{1}', CDate('2011/01/01 00:00:00'), CDate('2020/12/31 23:59:59'), 'Y')";
            //string strInsertSQL = "INSERT INTO Account(AccountId, UserPassword) VALUES('{0}', '{1}')";

            if (database == null)
                return NG;
//            database.ExecuteUpdate(strDeleteSQL);
//            database.Commit();

            foreach (string strAccount in dicModel.Keys)
            {
                database.ExecuteUpdate(strInsertSQL, new string[] {strAccount.Replace("'", ""), dicModel[strAccount].Replace("'", "") });
                //database.ExecuteUpdate(strInsertSQL, new string[] { strAccount.Replace("'", "") });
            }
            database.Commit();

            return OK;
        }
    }
}
