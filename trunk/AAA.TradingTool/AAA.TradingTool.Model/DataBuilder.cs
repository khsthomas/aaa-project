using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Database;

namespace AAA.TradingTool.Model
{
    public class DataBuilder
    {
        private const string HOST = "localhost";
        private const string DATABASE = "AAATrading";
        private const string USERNAME = "AAAUser";
        private const string PASSWORD = "apc888";

        public static IDatabase CreateDatabase(string strDatabaseName)
        {
            MSSqlDatabase db = new MSSqlDatabase();
            //string strConnectionString = ConfigurationManager.ConnectionStrings[strDatabaseName].ConnectionString;
            //db.Open(strConnectionString);
            db.Open(HOST, DATABASE, USERNAME, PASSWORD);
            return db;
        }
    }
}
