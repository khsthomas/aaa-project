using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Command.WCF;
using AAA.ResultSet;
using AAA.Database;

namespace AAA.PublisherService.Command
{
    public class UpdateAccountPrivilegeCommand : DatabaseCommand
    {
        protected override int ExecuteCommand(Dictionary<string, string> dicModel)
        {
            IDatabase database = CreateDatabase();
            string strAccount = null;
            string strUpdateSQL = "UPDATE Account SET ExpiredDate = CDate('{0}'), ActiveFlag = '{1}' WHERE AccountId = '{2}'";
            if (database == null)
                return NG;

            foreach (string strKey in dicModel.Keys)
            {
                strAccount = dicModel[strKey];
                break;
            }

            if (strAccount == null)
                return NG;

            database.ExecuteUpdate(strUpdateSQL, new string[] { dicModel["ExpiredDate"], dicModel["ActiveFlag"], dicModel["Account"] });
            database.Commit();

            return OK;
        }
    }
}
