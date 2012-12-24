using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace YEZZ.Model
{
    public class TB_PROJECT_FORMULA : AbstractDataModel
    {
        public TB_PROJECT_FORMULA()
        {
            SetDatabaseName(SystemConstants.DATABASE_NAME);
            PrimaryKeys = new string[] { "PROJECT_SN", "FORMULA_ID" };
            TableName = SystemConstants.DATABASE_CATALOG + ".dbo.TB_PROJECT_FORMULA";
            Fields = new string[] { "FORMULA_NAME", "FORMULA_DATA", "FORMULA_VALUE", "CREATE_DATE", "CREATE_USER", "MODIFY_DATE", "MODIFY_USER" };
            DataTypes = new SqlDbType[] { SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.DateTime, SqlDbType.NVarChar, SqlDbType.DateTime, SqlDbType.NVarChar };            
        }

        public override IDataModel CreateInstance()
        {
            return new TB_PROJECT_FORMULA();
        }
    }
}
