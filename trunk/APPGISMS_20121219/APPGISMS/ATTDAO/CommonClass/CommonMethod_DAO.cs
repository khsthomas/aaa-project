using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ATTDAO.CommonClass
{
    public class CommonMethod_DAO
    {
        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/06/06
        // 功能簡述：取得流水編號
        // 修改人：
        // 修改日期：
        // </summary>
        public string getSerialNumber(string strTable_Name, string strColumne_Name)
        {
            SqlConnection conn = new SqlConnection(SQLHelper.strConnection);

            conn.Open();
            SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

            try
            {
                SqlParameter[] arr_parms = SQLHelper.GetCachedParameters("SPC_SERIALNO_CTL");
                if (arr_parms == null)
                {
                    arr_parms = new SqlParameter[3];
                    arr_parms[0] = new SqlParameter("@TB_NAME", SqlDbType.NVarChar, 20);
                    arr_parms[1] = new SqlParameter("@CL_NAME", SqlDbType.NVarChar, 20);
                    arr_parms[2] = new SqlParameter("@KEY_VALUE", SqlDbType.NVarChar, 60);
                    SQLHelper.CacheParameters("SPC_SERIALNO_CTL", arr_parms);
                }

                arr_parms[0].Value = strTable_Name;
                arr_parms[1].Value = strColumne_Name;
                arr_parms[0].Direction = ParameterDirection.Input;
                arr_parms[1].Direction = ParameterDirection.Input;
                arr_parms[2].Direction = ParameterDirection.InputOutput;

                SQLHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "SPC_SERIALNO_CTL", arr_parms);
                trans.Commit();
                return arr_parms[2].Value.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                trans.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }
    }
}
