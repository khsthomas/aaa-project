using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Command.WCF;
using AAA.ResultSet;
using AAA.Database;

namespace AAA.PublisherService.Command
{
    public class UpdateAccountFunctionMappingCommand : DatabaseCommand
    {
        protected override int ExecuteCommand(Dictionary<string, string> dicModel)
        {
            IDatabase database = CreateDatabase();
            string strAccount = null;
            string strDeleteSQL = "DELETE FROM AccountFunctionMapping WHERE Account = '{0}'";
            string strInsertSQL = "INSERT INTO AccountFunctionMapping(Account, FunctionId) VALUES('{0}', '{1}')";
/*
            switch (SystemConfig.DATABASE_TYPE)
            {
                case DatabaseTypeEnum.Access:
                    database = new AccessDatabase();
                    break;

                case DatabaseTypeEnum.MSSql:
                    database = new MSSqlDatabase();
                    database.Open(SystemConfig.HOST, SystemConfig.DATABASE, SystemConfig.USERNAME, SystemConfig.PASSWORD);
                    break;
            }
*/
            if (database == null)
                return NG;

            foreach (string strKey in dicModel.Keys)
            {
                strAccount = dicModel[strKey];
                break;
            }

            if (strAccount == null)
                return NG;

            database.ExecuteUpdate(strDeleteSQL, new string[] {strAccount});
            database.Commit();

            foreach (string strId in dicModel.Keys)
            {
                database.ExecuteUpdate(strInsertSQL, new string[] {strAccount, strId});
            }
            database.Commit();

            return OK;
        }
    }
}
