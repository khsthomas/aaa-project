using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Command.WCF;
using AAA.ResultSet;

namespace AAA.PublisherService.Command
{
    public class QueryAccountListCommand : DatabaseCommand
    {
        protected override int ExecuteCommand(Dictionary<string, string> dicModel)
        {
            string strRecord;
            string strFieldName;
            string strSQL = "SELECT AccountId AS Account, UserPassword, StartDate, ExpiredDate, ActiveFlag FROM Account";
            //DatabaseResultSet databaseResult = new DatabaseResultSet(SystemConfig.DATABASE_TYPE, SystemConfig.HOST, SystemConfig.DATABASE, SystemConfig.USERNAME, SystemConfig.PASSWORD);
            DatabaseResultSet databaseResult = CreateResultSet();
            databaseResult.SQLStatement = strSQL;
            databaseResult.Load();
            databaseResult.Read();

            dicModel.Add("RowCount", databaseResult.RowCount.ToString());
            strFieldName = "";
            for (int i = 0; i < databaseResult.ColumnCount; i++)
                strFieldName += "," + databaseResult.ColumnNames()[i];

            if (strFieldName.Length > 0)
                dicModel.Add("FieldName", strFieldName.Substring(1));

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
