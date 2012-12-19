using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace YEZZ.Model
{
    public class TB_COLUMN_STATE : AbstractDataModel
    {
        public TB_COLUMN_STATE()
        {
            SetDatabaseName(SystemConstants.DATABASE_NAME);            
            PrimaryKeys = new string[] { "PROJECT_SN", "COLUMN_ID" };
            TableName = SystemConstants.DATABASE_CATALOG + ".dbo.TB_COLUMN_STATE";
            Fields = new string[] { "COLUMN_NAME", "DB_COLUMN_NAME", "CUS_COLUMN_ORDER", "STS_INFO", "CREATE_DATE", "CREATE_USER", "MODIFY_DATE", "MODIFY_USER"};
            DataTypes = new SqlDbType[] { SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.DateTime, SqlDbType.NVarChar, SqlDbType.DateTime, SqlDbType.NVarChar };

            AddAutoIncreaseField("COLUMN_ID");
        }

        public override IDataModel CreateInstance()
        {
            return new TB_COLUMN_STATE();
        }
    }
}
