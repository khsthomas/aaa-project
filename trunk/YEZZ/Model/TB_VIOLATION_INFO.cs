using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace YEZZ.Model
{
    public class TB_VIOLATION_INFO : AbstractDataModel
    {
        public TB_VIOLATION_INFO()
        {
            SetDatabaseName(SystemConstants.DATABASE_NAME);
            PrimaryKeys = new string[] { "RECEIPT_SN" };
            TableName = SystemConstants.DATABASE_CATALOG + ".dbo.TB_VIOLATION_INFO";
            Fields = new string[] { "SEND_DATE", "COUNTY_AREA", "HOSPITAL_NO", "DOCTOR_ID_RES", "DOCTOR_ID_VIOLATION", "VIOLATION_REASON", "REAPPLICATION_RESULT", "REAPPLICATION_NO", "REMARK", "CREATE_DATE", "CREATE_USER" };
            DataTypes = new SqlDbType[] { SqlDbType.DateTime, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.DateTime, SqlDbType.NVarChar };            
        }

        public override IDataModel CreateInstance()
        {
            return new TB_VIOLATION_INFO();
        }
    }
}
