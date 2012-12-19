using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace YEZZ.Model
{
    public class TB_LAYER_COLOR : AbstractDataModel
    {
        public TB_LAYER_COLOR()
        {
            SetDatabaseName(SystemConstants.DATABASE_NAME);
            PrimaryKeys = new string[] { "PROJECT_SN", "FORMULA_ID", "LAYER_TYPE" };
            TableName = SystemConstants.DATABASE_CATALOG + ".dbo.TB_LAYER_COLOR";
            Fields = new string[] { "STS_INFO", "LAYER_COLOR", "LAYER_START", "LAYER_END", "LAYER_DEFINITION", "LAYER_REMARK", "CREATE_DATE", "CREATE_USER", "MODIFY_DATE", "MODIFY_USER" };
            DataTypes = new SqlDbType[] { SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.DateTime, SqlDbType.NVarChar, SqlDbType.DateTime, SqlDbType.NVarChar };            
        }

        public override IDataModel CreateInstance()
        {
            return new TB_LAYER_COLOR();
        }
    }
}
