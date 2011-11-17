using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Command.WCF;
using AAA.ResultSet;
using AAA.Database;

namespace AAA.PublisherService.Command
{
    public class UpdateArticleCategoryCommand : DefaultCommand
    {
        protected override int ExecuteCommand(Dictionary<string, string> dicModel)
        {
            IDatabase database = null;
            string strDeleteSQL = "DELETE FROM ArticleCategory";
            string strInsertSQL = "INSERT INTO ArticleCategory(ArticleCategoryId, ArticleCategoryName) VALUES('{0}', '{1}')";

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

            if (database == null)
                return NG;
            database.ExecuteUpdate(strDeleteSQL);
            database.Commit();

            foreach (string strId in dicModel.Keys)
            {
                database.ExecuteUpdate(strInsertSQL, new string[] {strId, dicModel[strId] });
            }
            database.Commit();

            return OK;
        }
    }
}
