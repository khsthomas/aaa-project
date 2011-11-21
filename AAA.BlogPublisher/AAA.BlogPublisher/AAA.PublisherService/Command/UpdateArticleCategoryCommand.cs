﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Command.WCF;
using AAA.ResultSet;
using AAA.Database;

namespace AAA.PublisherService.Command
{
    public class UpdateArticleCategoryCommand : DatabaseCommand
    {
        protected override int ExecuteCommand(Dictionary<string, string> dicModel)
        {
            IDatabase database = CreateDatabase();
            string strDeleteSQL = "DELETE FROM ArticleCategory";
            string strInsertSQL = "INSERT INTO ArticleCategory(ArticleCategoryId, ArticleCategoryName) VALUES('{0}', '{1}')";

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
