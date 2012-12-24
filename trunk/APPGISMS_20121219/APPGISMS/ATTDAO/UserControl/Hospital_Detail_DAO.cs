using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CTLLIBRARY.UserControl;

namespace ATTDAO.UserControl
{
    public class Hospital_Detail_DAO
    {
        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/04/23
        // 功能簡述：取得醫院詳細資訊
        // 修改人：Hilda
        // 修改日期：2012/4/30
        // </summary>
        public DataSet getHospitalDetail(string strHospital_Sn, string strUserID, string strD_H_Type)
        {
            Hospital_Detail_Library hdl = new Hospital_Detail_Library();
            SqlConnection conn = new SqlConnection(SQLHelper.strConnection);
            SqlTransaction trans;
            SqlDataReader rdr;
            DataSet ds = new DataSet();
            DataTable dt;
            string[] arr_strSql = new string[4];

            conn.Open();
            trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

            try
            {
                //院所詳細資料
                arr_strSql[0] = hdl.sqlHospitalInfo("getDetail_Info", strHospital_Sn, strUserID, strD_H_Type);
                //院所門診資料
                arr_strSql[1] = hdl.sqlHospitalInfo("getTime_lnfo", strHospital_Sn, strUserID, strD_H_Type);
                //院所醫生資料
                arr_strSql[2] = hdl.sqlHospitalInfo("getDoctor_Info", strHospital_Sn, strUserID, strD_H_Type);

                //專案計畫資料
                arr_strSql[3] = hdl.sqlHospitalInfo("getProject_Info", strHospital_Sn, strUserID, strD_H_Type);

                for (int i = 0; i <= arr_strSql.Length - 1; i++)
                {
                    rdr = SQLHelper.ExecuteReaderNoClose(trans, CommandType.Text, arr_strSql[i], null);
                    dt = ds.Tables.Add();

                    for (int j = 0; j < rdr.FieldCount; j++)
                    {
                        dt.Columns.Add(rdr.GetName(j), rdr.GetFieldType(j));
                    }

                    while (rdr.Read())
                    {
                        object[] values = new object[rdr.FieldCount];
                        rdr.GetValues(values);
                        dt.Rows.Add(values);
                    }
                    rdr.Close();
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // </summary>
        // 撰寫人：Hilda
        // 撰寫日期：2011/10/11
        // 功能簡述：取得醫師門診時間
        // 修改人：
        // 修改日期：
        // </summary>
        public DataSet getDoctor_Time(string strHospital_Sn, string strDoctor_Sn)
        {
            Hospital_Detail_Library hdl = new Hospital_Detail_Library();
            SqlConnection conn = new SqlConnection(SQLHelper.strConnection);
            SqlTransaction trans;
            SqlDataReader rdr;
            DataSet ds = new DataSet();
            DataTable dt;
            string[] arr_strSql = new string[2];

            //建立Transaction
            conn.Open();
            trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

            try
            {
                
                
                //語言_Query
                arr_strSql[0] = hdl.getDoctor_Time("getLanguageInfo_Doctor", strHospital_Sn, strDoctor_Sn);
                //門診時間_Query
                arr_strSql[1] = hdl.getDoctor_Time("getTimeInfo_Doctor", strHospital_Sn, strDoctor_Sn);

                for (int i = 0; i <= arr_strSql.Length - 1; i++)
                {
                    rdr = SQLHelper.ExecuteReaderNoClose(trans, CommandType.Text, arr_strSql[i], null);
                    dt = ds.Tables.Add();

                    for (int j = 0; j < rdr.FieldCount; j++)
                    {
                        dt.Columns.Add(rdr.GetName(j), rdr.GetFieldType(j));
                    }

                    while (rdr.Read())
                    {
                        object[] values = new object[rdr.FieldCount];
                        rdr.GetValues(values);
                        dt.Rows.Add(values);
                    }
                    rdr.Close();
                }
                return ds;
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
