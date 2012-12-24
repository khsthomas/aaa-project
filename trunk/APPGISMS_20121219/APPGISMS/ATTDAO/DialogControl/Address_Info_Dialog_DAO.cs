using System;
using System.Data;
using System.Data.SqlClient;
using CTLLIBRARY.DialogControl;

namespace ATTDAO.DialogControl
{
    public class Address_Info_Dialog_DAO
    {
        // </summary>
        // 撰寫人：Edison
        // 撰寫日期：2012/09/28
        // 功能簡述：擷取縣市下拉式選單
        // 最後更新日期：
        // 修改人：
        // 修改日期：
        // </summary>
        public DataSet getlbxCounty()
        {
            Address_Info_Dialog_Library aidl = new Address_Info_Dialog_Library();

            string strSql = string.Format(@"{0} WHERE COUNTY_VARSION = (SELECT MAX(COUNTY_VARSION) FROM TB_COUNTY_INFO) 
                                                ORDER BY COUNTY_ORDER", aidl.sqlAddressInfo("getlbxCounty"));

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
        // 撰寫人：Edison
        // 撰寫日期：2012/09/28
        // 功能簡述：擷取鄉鎮下拉式選單
        // 最後更新日期：
        // 修改人：
        // 修改日期：
        // </summary>
        public DataSet getlbxTown(string strCounty_No)
        {
            Address_Info_Dialog_Library aidl = new Address_Info_Dialog_Library();

            string strSql = string.Format(@"{0} WHERE COUNTY_VARSION = (SELECT MAX(COUNTY_VARSION) FROM TB_COUNTY_INFO) AND 
                                                    COUNTY_NO = '{1}'
                                                ORDER BY TOWN_ORDER", aidl.sqlAddressInfo("getlbxTown"), strCounty_No);

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
        // 撰寫人：Edison
        // 撰寫日期：2012/09/28
        // 功能簡述：擷取道路下拉式選單
        // 最後更新日期：
        // 修改人：
        // 修改日期：
        // </summary>
        public DataSet getlbxRoad(string strCounty_No, string strTown_No)
        {
            Address_Info_Dialog_Library aidl = new Address_Info_Dialog_Library();

            string strSql = string.Format(@"{0} WHERE COUNTY_NO = '{1}' AND TOWN_NO = '{2}'", aidl.sqlAddressInfo("getlbxRoad"), strCounty_No, strTown_No);

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
        // 撰寫人：Edison
        // 撰寫日期：2012/10/31
        // 功能簡述：取得完整下拉式選單
        // 修改人：
        // 修改日期：
        // </summary>
        public DataSet getlbxAddress(string strCounty_No, string strTown_No)
        {
            SqlConnection conn = new SqlConnection(SQLHelper.strConnection);
            SqlTransaction trans;
            SqlDataReader rdr;
            conn.Open();
            trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);

            Address_Info_Dialog_Library aidl = new Address_Info_Dialog_Library();

            DataSet ds = new DataSet();
            DataTable dt;
            string[] arr_strSql = new string[3];

            try
            {
                //縣市
                arr_strSql[0] = string.Format(@"{0} WHERE COUNTY_VARSION = (SELECT MAX(COUNTY_VARSION) FROM TB_COUNTY_INFO) 
                                                ORDER BY COUNTY_ORDER", aidl.sqlAddressInfo("getlbxCounty"));

                //鄉鎮
                arr_strSql[1] = string.Format(@"{0} WHERE COUNTY_VARSION = (SELECT MAX(COUNTY_VARSION) FROM TB_COUNTY_INFO) AND 
                                                    COUNTY_NO = '{1}'
                                                ORDER BY TOWN_ORDER", aidl.sqlAddressInfo("getlbxTown"), strCounty_No);
                //道路
                arr_strSql[2] = string.Format(@"{0} WHERE COUNTY_NO = '{1}' AND TOWN_NO = '{2}'", aidl.sqlAddressInfo("getlbxRoad"), strCounty_No, strTown_No);

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

        // </summary>
        // 撰寫人：Edison
        // 撰寫日期：2012/09/28
        // 功能簡述：取得郵遞區號
        // 最後更新日期：
        // 修改人：
        // 修改日期：
        // </summary>
        public string getZipCode(string strCounty_No, string strTown_No, string strRoad_No)
        {
            Address_Info_Dialog_Library aidl = new Address_Info_Dialog_Library();

            string strSql = string.Format(@"{0} WHERE COUNTY_NO = '{1}' AND TOWN_NO = '{2}' AND ROAD_NO = '{3}'", 
                aidl.sqlAddressInfo("getZipCode"), strCounty_No, strTown_No, strRoad_No);

            try
            {
                using (SqlDataReader rdr = SQLHelper.ExecuteReader(SQLHelper.strConnection, CommandType.Text, strSql, null))
                {
                    string strZip_Code = "";
                    if (rdr.Read())
                        strZip_Code = rdr[0].ToString();
                    rdr.Close();

                    return strZip_Code;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
