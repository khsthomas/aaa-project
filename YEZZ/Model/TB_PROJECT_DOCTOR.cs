using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace YEZZ.Model
{
    public class TB_PROJECT_DOCTOR : AbstractDataModel
    {
        public TB_PROJECT_DOCTOR()
        {
            SetDatabaseName(SystemConstants.DATABASE_NAME);
            PrimaryKeys = new string[] { "PROJECT_SN", "HOSPITAL_NO", "DOCTOR_ID" };
            TableName = SystemConstants.DATABASE_CATALOG + ".dbo.TB_PROJECT_DOCTOR";
            Fields = new string[] { "PROJECT_SDATE", "PROJECT_EDATE", "CUSTOM_COLUMN1", "CUSTOM_COLUMN2", "CUSTOM_COLUMN3", "CUSTOM_COLUMN4", "CUSTOM_COLUMN5", "CREATE_DATE", "CREATE_USER" };
            DataTypes = new SqlDbType[] { SqlDbType.DateTime, SqlDbType.DateTime, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.DateTime, SqlDbType.NVarChar };            
        }

        public override IDataModel CreateInstance()
        {
            return new TB_PROJECT_DOCTOR();
        }
    }
}
