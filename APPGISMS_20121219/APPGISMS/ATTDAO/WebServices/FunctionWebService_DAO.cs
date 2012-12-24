using System;
using System.Data;
using System.Data.SqlClient;
using CTLLIBRARY.WebServices;

namespace ATTDAO.WebServices
{
    public class FunctionWebService_DAO
    {
        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/08/01
        // 功能簡述：
        // 修改人：
        // 修改日期：
        // </summary>
        public DataSet getFunctionInfo(string strUser_Id, string strSystem_Type)
        {
            FunctionWebService_Library fwl = new FunctionWebService_Library();
            string strSql = string.Format(@"{0} ORDER BY MAIN_ORDER, SUB_ORDER", fwl.sqlFunctionInfo("getFunctionInfo", strUser_Id, strSystem_Type));

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
