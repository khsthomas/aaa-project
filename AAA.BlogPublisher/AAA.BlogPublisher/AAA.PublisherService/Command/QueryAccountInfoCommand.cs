using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Command.WCF;
using AAA.ResultSet;

namespace AAA.PublisherService.Command
{
    public class QueryAccountInfoCommand : DatabaseCommand
    {
        protected override int ExecuteCommand(Dictionary<string, string> dicModel)
        {            
            string strSQL = "SELECT AccountId AS Account, UserPassword, StartDate, ExpiredDate, ActiveFlag FROM Account WHERE AccountId = '{0}'";
            DatabaseResultSet databaseResult = CreateResultSet();
            databaseResult.SQLStatement = strSQL;
            databaseResult.Load();
            databaseResult.Read();

            for (int i = 0; i < databaseResult.RowCount; i++, databaseResult.Read())
                for (int j = 0; j < databaseResult.ColumnCount; j++)
                    if(dicModel.ContainsKey(databaseResult.ColumnNames()[j]))
                        dicModel[databaseResult.ColumnNames()[j]] =  databaseResult.Cells(j).ToString();
                    else
                        dicModel.Add(databaseResult.ColumnNames()[j], databaseResult.Cells(j).ToString());

            return OK;

        }
    }
}
