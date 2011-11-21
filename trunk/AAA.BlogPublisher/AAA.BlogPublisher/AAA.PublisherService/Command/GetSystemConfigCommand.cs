using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Command.WCF;
using AAA.ResultSet;

namespace AAA.PublisherService.Command
{
    public class GetSystemConfigCommand : DatabaseCommand
    {
        protected override int ExecuteCommand(Dictionary<string, string> dicModel)
        {
            string strRecord;
            string strSQL = "SELECT ParamName, ParamValue FROM SystemConfig WHERE Category = '{0}'";
            //DatabaseResultSet databaseResult = new DatabaseResultSet(SystemConfig.DATABASE_TYPE, SystemConfig.HOST, SystemConfig.DATABASE, SystemConfig.USERNAME, SystemConfig.PASSWORD);
            DatabaseResultSet databaseResult = CreateResultSet();
            databaseResult.SQLStatement = string.Format(strSQL, new string[] {dicModel["Category"]});
            databaseResult.Load();
            databaseResult.Read();

            for (int i = 0; i < databaseResult.RowCount; i++, databaseResult.Read())
            {
                dicModel.Add(databaseResult.Cells("ParamName").ToString(),
                             databaseResult.Cells("ParamValue").ToString());
            }
            return OK;

        }
    }
}
