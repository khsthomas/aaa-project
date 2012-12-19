using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace YEZZ.Model
{
    public class TB_TOWN_DATA : AbstractDataModel
    {
        public TB_TOWN_DATA()
        {
            SetDatabaseName(SystemConstants.DATABASE_NAME);
            PrimaryKeys = new string[] { "DATA_YEAR", "COUNTY_VARSION", "COUNTY_NO", "TOWN_NO", "DATA_TYPE" };
            TableName = SystemConstants.DATABASE_CATALOG + ".dbo.TB_TOWN_DATA";
            Fields = new string[] { "DATA_CONTENT", "CREATE_DATE", "CREATE_USER", "MODIFY_DATE", "MODIFY_USER" };
            DataTypes = new SqlDbType[] { SqlDbType.NVarChar, SqlDbType.DateTime, SqlDbType.NVarChar, SqlDbType.DateTime, SqlDbType.NVarChar };            
        }

        public override IDataModel CreateInstance()
        {
            return new TB_TOWN_DATA();
        }
    }
}
