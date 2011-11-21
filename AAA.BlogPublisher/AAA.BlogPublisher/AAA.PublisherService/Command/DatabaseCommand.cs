using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Command.WCF;
using AAA.Database;
using AAA.ResultSet;

namespace AAA.PublisherService.Command
{
    public abstract class DatabaseCommand : DefaultCommand
    {
        protected DatabaseResultSet CreateResultSet()
        {
            try
            {
                switch (SystemConfig.DATABASE_TYPE)
                {
                    case AAA.ResultSet.DatabaseTypeEnum.Access:
                        return new DatabaseResultSet(SystemConfig.DATABASE_TYPE,
                                                     "",
                                                     Environment.CurrentDirectory + @"\Account.mdb",
                                                     SystemConfig.USERNAME,
                                                     SystemConfig.PASSWORD);
                    case AAA.ResultSet.DatabaseTypeEnum.MSSql:
                        return new DatabaseResultSet(SystemConfig.DATABASE_TYPE,
                                                     SystemConfig.HOST,
                                                     SystemConfig.DATABASE,
                                                     SystemConfig.USERNAME,
                                                     SystemConfig.PASSWORD);
                        break;
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        protected IDatabase CreateDatabase()
        {
            IDatabase database;
            try
            {
                switch (SystemConfig.DATABASE_TYPE)
                {
                    case AAA.ResultSet.DatabaseTypeEnum.Access:
                        database = new AccessDatabase();
                        database.Open(Environment.CurrentDirectory + @"\" + SystemConfig.DATABASE,
                                      SystemConfig.USERNAME,
                                      SystemConfig.PASSWORD);
                        break;
                    case AAA.ResultSet.DatabaseTypeEnum.MSSql:
                        database = new MSSqlDatabase();
                        database.Open(SystemConfig.HOST,
                                      SystemConfig.DATABASE,
                                      SystemConfig.USERNAME,
                                      SystemConfig.PASSWORD);
                        break;
                }

                return database;
            }
            catch (Exception ex)
            {
                
            }
            return null;
        }
    }
}
