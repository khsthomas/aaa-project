using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Command.WCF;
using AAA.Database;
using AAA.ResultSet;

namespace AAA.PublisherService.Command
{
    public class LoginCommand : DefaultCommand
    {
        protected override int ExecuteCommand(Dictionary<string, string> dicModel)
        {
            try
            {
                string strSQL = "SELECT Account, Password FROM Account WHERE Account = '{0}' AND ActiveFlag = 'Y'";
                DatabaseResultSet databaseResult = new DatabaseResultSet(SystemConfig.DATABASE_TYPE, SystemConfig.HOST, SystemConfig.DATABASE, SystemConfig.USERNAME, SystemConfig.PASSWORD);
                databaseResult.SQLStatement = string.Format(strSQL, new string[] { dicModel["Account"] });
                databaseResult.Load();
                databaseResult.Read();
                switch (databaseResult.RowCount)
                {
                    case 0:
                        dicModel.Add("ReturnMessage", "無此帳號");
                        break;
                    case 1:
                        if (databaseResult.Cells("Password").ToString() == dicModel["Password"])
                            dicModel.Add("ReturnMessage", "登入成功");
                        else
                            dicModel.Add("ReturnMessage", "密碼錯誤");
                        break;
                }

                return OK;
            }
            catch (Exception ex)
            {
                dicModel.Add("ReturnMessage", ex.Message + "," + ex.StackTrace);                
            }
            return OK;
        }

    }
}
