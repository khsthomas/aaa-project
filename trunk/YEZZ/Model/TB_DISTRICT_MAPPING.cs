using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace YEZZ.Model
{
    public class TB_DISTRICT_MAPPING : AbstractDataModel
    {
        public TB_DISTRICT_MAPPING()
        {
            SetDatabaseName(SystemConstants.DATABASE_NAME);
            PrimaryKeys = new string[] { "MAPPING_ID" };
            TableName = SystemConstants.DATABASE_CATALOG + ".dbo.TB_DISTRICT_MAPPING";
            Fields = new string[] { "PRE_DISTRICT_VAR", "PRE_COUNTY_NO", "PRE_TOWN_NO", "NEXT_DISTRICT_VAR", "NEXT_COUNTY_NO", "NEXT_TOWN_NO", "CREATE_DATE", "CREATE_USER"};
            DataTypes = new SqlDbType[] { SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.DateTime, SqlDbType.NVarChar };

            AddAutoIncreaseField("MAPPING_ID");
        }

        public override IDataModel CreateInstance()
        {
            return new TB_DISTRICT_MAPPING();
        }
    }
}
