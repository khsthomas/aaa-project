using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CTLLIBRARY.DialogControl;

namespace ATTDAO.DialogControl
{
    public class Activity_Info_Dialog_DAO
    {
        public DataSet getgrvActInfo(string strAct_Info)
        {
            Activity_Info_Dialog_Library aidl = new Activity_Info_Dialog_Library();

            string strSql = aidl.sqlActivity_Info_Dialog("getgrvActInfo");

            if (strAct_Info != "")
            {
                strSql += "WHERE ACTIVITY_NAME like '%" + strAct_Info + "%' ";

            }
            



            try
            {
                using (SqlDataReader rdr = SQLHelper.ExecuteReader(SQLHelper.strConnection, CommandType.Text, strSql, null))
                {
                    DataSet ds = new DataSet();
                    ds.Tables.Add();

                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        ds.Tables[0].Columns.Add(rdr.GetName(i), rdr.GetFieldType(i));
                    }

                    while (rdr.Read())
                    {
                        object[] values = new object[rdr.FieldCount];
                        rdr.GetValues(values);
                        ds.Tables[0].Rows.Add(values);
                    }

                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

