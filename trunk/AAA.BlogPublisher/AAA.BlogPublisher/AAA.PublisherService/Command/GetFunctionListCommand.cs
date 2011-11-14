using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Command.WCF;
using AAA.ResultSet;

namespace AAA.PublisherService.Command
{
    public class GetFunctionListCommand : DefaultCommand
    {
        protected override int ExecuteCommand(Dictionary<string, string> dicModel)
        {            
            string strSQL = "SELECT a.FunctionId FunctionId, b.DllName DllName FROM AccountFunctionMapping a, FunctionInfo b WHERE a.Account = '{0}'";
            DatabaseResultSet databaseResult = new DatabaseResultSet(SystemConfig.DATABASE_TYPE, SystemConfig.HOST, SystemConfig.DATABASE, SystemConfig.USERNAME, SystemConfig.PASSWORD);
            string strDllList;
            databaseResult.SQLStatement = string.Format(strSQL, new string[] {dicModel["Account"]});
            databaseResult.Load();
            databaseResult.Read();

            strDllList = "";
            for (int i = 0; i < databaseResult.RowCount; i++, databaseResult.Read())
            {
                dicModel.Add(databaseResult.Cells("FunctionId").ToString(),
                             databaseResult.Cells("DllName").ToString());
                strDllList += "," + databaseResult.Cells("DllName").ToString();
            }
            if (strDllList.Length > 0)
                dicModel.Add("DllList", strDllList.Substring(1));

            return OK;

        }
    }
}
