using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Command.WCF;
using AAA.ResultSet;

namespace AAA.PublisherService.Command
{
    public class GetArticleCategoryListCommand : DefaultCommand
    {
        protected override int ExecuteCommand(Dictionary<string, string> dicModel)
        {            
            string strSQL = "SELECT a.ArticleCategoryId CategoryId, b.ArticleCategoryName CategoryName FROM AccountArticleMapping a, ArticleCategory b WHERE a.ArticleCategoryId = b.ArticleCategoryId AND a.Account = '{0}'";
            DatabaseResultSet databaseResult = new DatabaseResultSet(SystemConfig.DATABASE_TYPE, SystemConfig.HOST, SystemConfig.DATABASE, SystemConfig.USERNAME, SystemConfig.PASSWORD);
            string strCategoryIdList;
            databaseResult.SQLStatement = string.Format(strSQL, new string[] {dicModel["Account"]});
            databaseResult.Load();
            databaseResult.Read();

            strCategoryIdList = "";
            for (int i = 0; i < databaseResult.RowCount; i++, databaseResult.Read())
            {
                dicModel.Add(databaseResult.Cells("CategoryId").ToString(),
                             databaseResult.Cells("CategoryName").ToString());
                strCategoryIdList += "," + databaseResult.Cells("CategoryId").ToString() + "." + databaseResult.Cells("CategoryName").ToString();
            }
            if (strCategoryIdList.Length > 0)
                dicModel.Add("CategoryList", strCategoryIdList.Substring(1));

            return OK;

        }
    }
}
