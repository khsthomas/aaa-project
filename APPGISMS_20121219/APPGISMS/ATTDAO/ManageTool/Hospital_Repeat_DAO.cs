using System;
using System.Data;
using System.Data.SqlClient;
using CTLLIBRARY.ManageTool;

namespace ATTDAO.ManageTool
{
    public class Hospital_Repeat_DAO
    {
        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2011/02/26
        // 功能簡述：縣市資料取得
        // 修改人：
        // 修改日期：
        // </summary>
        public DataSet getCountyInfo()
        {
            Hospital_Repeat_Library hrl = new Hospital_Repeat_Library();
            string strSql = hrl.sqlHospitalInfo("getCountyInfo");

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

        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2011/02/26
        // 功能簡述：鄉鎮市區資料取得
        // 修改人：
        // 修改日期：
        // </summary>
        public DataSet getTownInfo(string strCounty_No)
        {
            Hospital_Repeat_Library hrl = new Hospital_Repeat_Library();
            string strSql = string.Format(@"{0} AND COUNTY_NO = '{1}'", hrl.sqlHospitalInfo("getTownInfo"), strCounty_No);

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

        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2011/02/26
        // 功能簡述：院所資料取得
        // 修改人：
        // 修改日期：
        // </summary>
        public DataSet getHospitalInfo(string strCounty_No, string strTown_No, string strHospital_Name)
        {
            Hospital_Repeat_Library hrl = new Hospital_Repeat_Library();
            SqlConnection conn = new SqlConnection(SQLHelper.strConnection);
            SqlTransaction trans;
            SqlDataReader rdr;
            DataSet ds = new DataSet();
            DataTable dt;
            string[] arr_strSql = new string[2];

            conn.Open();
            trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

            try
            {
                //牙醫院所資料
                arr_strSql[0] = string.Format(@"{0} WHERE HOSPITAL_COUNTY = '{1}' AND HOSPITAL_TOWN = '{2}' AND
                                                                HOSPITAL_NAME LIKE '%{3}%' ORDER BY HOSPITAL_SN", hrl.sqlHospitalInfo("getHospitalInfo"), 
                                                                strCounty_No, strTown_No, strHospital_Name);
                //牙醫師所屬院所資料
                arr_strSql[1] = string.Format(@"{0} WHERE a.HOSPITAL_SN IN (SELECT HOSPITAL_SN FROM TB_HOSPITAL_INFO WHERE 
                                                               HOSPITAL_COUNTY = '{1}' AND HOSPITAL_TOWN = '{2}' AND HOSPITAL_NAME LIKE '%{3}%')
                                                               ORDER BY c.DOCTOR_SN", hrl.sqlHospitalInfo("getHospitalDoctor"), strCounty_No, strTown_No, strHospital_Name);

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
        // 撰寫人：Oliver
        // 撰寫日期：2011/02/26
        // 功能簡述：院所資料修正
        // 修改人：
        // 修改日期：
        // </summary>
        public int setHospitalInfo(DataTable dt)
        {
            Hospital_Repeat_Library hrl = new Hospital_Repeat_Library();
            SqlConnection conn = new SqlConnection(SQLHelper.strConnection);
            SqlTransaction trans;
            string strSql = "";
            int i = 0;

            conn.Open();
            trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

            try
            {
                strSql = hrl.sqlTempTable("createHospitalTemp");
                SQLHelper.ExecuteNonQuery(trans, CommandType.Text, strSql, null);

                foreach (DataRow dr in dt.Rows)
                {
                    strSql = string.Format(@"INSERT INTO #TB_HOSPITAL_TMP (MAIN_CHOOSE, HOSPITAL_SN) VALUES ('{0}', '{1}')",
                                                            dr["MAIN_CHOOSE"].ToString(), dr["HOSPITAL_SN"].ToString());
                    SQLHelper.ExecuteNonQuery(trans, CommandType.Text, strSql, null);
                }

                strSql = hrl.sqlTempTable("createHospitalDoctorTemp");
                SQLHelper.ExecuteNonQuery(trans, CommandType.Text, strSql, null);

                strSql = @"INSERT INTO #TB_HOSPITAL_DOCTOR_TMP
                                 SELECT HOSPITAL_SN, DOCTOR_SN, DOCTOR_CAPACITY, DOCTOR_POSITION, EXTENSION_NUMBER
                                 FROM TB_HOSPITAL_DOCTOR
                                 WHERE HOSPITAL_SN IN (SELECT HOSPITAL_SN FROM #TB_HOSPITAL_TMP)";
                SQLHelper.ExecuteNonQuery(trans, CommandType.Text, strSql, null);

                //醫師院所資料
                strSql = @"DELETE TB_HOSPITAL_DOCTOR WHERE HOSPITAL_SN IN (SELECT HOSPITAL_SN FROM #TB_HOSPITAL_TMP)";
                i += SQLHelper.ExecuteNonQuery(trans, CommandType.Text, strSql, null);

                strSql = @"INSERT INTO TB_HOSPITAL_DOCTOR (HOSPITAL_SN, DOCTOR_SN, DOCTOR_CAPACITY, DOCTOR_POSITION, EXTENSION_NUMBER, CREATE_USER)
                                 SELECT (SELECT HOSPITAL_SN FROM #TB_HOSPITAL_TMP WHERE MAIN_CHOOSE = '1') AS HOSPITAL_SN,
                                        DOCTOR_SN, DOCTOR_CAPACITY, DOCTOR_POSITION, EXTENSION_NUMBER, 'SYS'
                                 FROM #TB_HOSPITAL_DOCTOR_TMP
                                 GROUP BY DOCTOR_SN, DOCTOR_CAPACITY, DOCTOR_POSITION, EXTENSION_NUMBER";
                i += SQLHelper.ExecuteNonQuery(trans, CommandType.Text, strSql, null);

                //院所資料
                strSql = @"DELETE TB_HOSPITAL_INFO WHERE HOSPITAL_SN IN (SELECT HOSPITAL_SN FROM #TB_HOSPITAL_TMP WHERE MAIN_CHOOSE = '0')";
                i += SQLHelper.ExecuteNonQuery(trans, CommandType.Text, strSql, null);

                //院所明細資料
                strSql = @"DELETE TB_HOSPITAL_DTL WHERE HOSPITAL_SN IN (SELECT HOSPITAL_SN FROM #TB_HOSPITAL_TMP WHERE MAIN_CHOOSE = '0')";
                i += SQLHelper.ExecuteNonQuery(trans, CommandType.Text, strSql, null);

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
