using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Command.WCF;
using AAA.ResultSet;

namespace AAA.PublisherService.Command
{
    public class QueryAccountListCommand : DefaultCommand
    {
        protected override int ExecuteCommand(Dictionary<string, string> dicModel)
        {
            string strRecord;
            string strSQL = "SELECT Account, Password, StartDate, ExpiredDate, ActiveFlag FROM Account";
            DatabaseResultSet databaseResult = new DatabaseResultSet(SystemConfig.DATABASE_TYPE, SystemConfig.HOST, SystemConfig.DATABASE, SystemConfig.USERNAME, SystemConfig.PASSWORD);
            databaseResult.SQLStatement = strSQL;
            databaseResult.Load();
            databaseResult.Read();

            dicModel.Add("RowCount", databaseResult.RowCount.ToString());

            for (int i = 0; i < databaseResult.RowCount; i++, databaseResult.Read())
            {
                strRecord = "";

                for (int j = 0; j < databaseResult.ColumnCount; j++)
                    strRecord += "," + databaseResult.Cells(j).ToString();
                dicModel.Add("Row" + i, strRecord.Substring(1));                                
            }
            return OK;

        }
    }
}
