using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Command.WCF;
using AAA.ResultSet;
using AAA.Database;

namespace AAA.PublisherService.Command
{
    public class UpdateAccountActiveCommand : DatabaseCommand
    {
        protected override int ExecuteCommand(Dictionary<string, string> dicModel)
        {
            IDatabase database = CreateDatabase();
            string strUpdateSQL = "UPDATE Account SET ActiveFlag = 'N' WHERE ExpiredDate < CDate('{0}')";

            if (database == null)
                return NG;

            database.ExecuteUpdate(strUpdateSQL, new string[] { DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")});
            database.Commit();

            return OK;
        }
    }
}
