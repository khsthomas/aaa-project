using System;
using System.Data;
using System.Data.SqlClient;
using CTLLIBRARY;

namespace ATTDAO
{
    public class Default_DAO
    {
        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/04/23
        // 功能簡述：取得人數
        // 修改人：
        // 修改日期：
        // </summary>
        public uint getApplicationCount()
        {
            Default_Library dl = new Default_Library();
            string strSql = string.Format(@"{0} WHERE PARAMETER_NAME = 'ApplicationCount'", dl.sqlMainPage("getPageData"));

            try
            {
                using (SqlDataReader rdr = SQLHelper.ExecuteReader(SQLHelper.strConnection, CommandType.Text, strSql, null))
                {
                    uint uintCount = 0;
                    if (rdr.Read())
                        uintCount = Convert.ToUInt32(rdr["PARAMETER_VALUE"]);
                    return uintCount;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/04/23
        // 功能簡述：更新人數
        // 修改人：
        // 修改日期：
        // </summary>
        public int setApplicationCount(string strCount)
        {
            SqlConnection conn = new SqlConnection(SQLHelper.strConnection);
            SqlTransaction trans;

            conn.Open();
            trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

            string strSql = string.Format(@"UPDATE TB_SYSTEM_PARAMETER SET PARAMETER_VALUE = '{0}'
                                                            WHERE PARAMETER_NAME = 'ApplicationCount'", strCount);

            try
            {
                int i = SQLHelper.ExecuteNonQuery(trans, CommandType.Text, strSql);
                trans.Commit();
                return i;
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
