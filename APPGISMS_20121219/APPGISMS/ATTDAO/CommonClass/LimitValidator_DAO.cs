using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CTLLIBRARY.CommonClass;

namespace ATTDAO.CommonClass
{
    public class LimitValidator_DAO
    {
        // <summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/02/01
        // 功能簡述：各網頁功能認證
        // 修改人：
        // 修改日期：
        // </summary>
        public bool getLimitWebFunChk(string strUser_Id, string strFun_Id)
        {
            LimitValidator_Library ll = new LimitValidator_Library();
            string strSql = string.Format(@"{0} WHERE b.USERID = '{1}' AND a.FUN_ID = '{2}' GROUP BY a.FUN_ID",
                                                           ll.sqlLimitCheck("checkFunLimit"), strUser_Id, strFun_Id);

            try
            {
                using (SqlDataReader rdr = SQLHelper.ExecuteReader(SQLHelper.strConnection, CommandType.Text, strSql, null))
                {
                    int intCount = 0;
                    if (rdr.Read())
                        intCount = int.Parse(rdr[0].ToString());
                    rdr.Close();
                    return intCount == 0 ? false : true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // <summary>
        // 撰寫人：Hilda
        // 撰寫日期：2011/08/23
        // 功能簡述：各網頁功能細項控制認證
        // 修改人：
        // 修改日期：
        // </summary>
        public bool getDtlFunChk(string strUser_Id, string strFun_Id)
        {
            LimitValidator_Library ll = new LimitValidator_Library();
            string strSql = string.Format(@"{0} WHERE a.USERID = '{1}' AND c.FUN_ID = '{2}' ",
                                                           ll.sqlLimitCheck("checkDtlFun"), strUser_Id, strFun_Id);

            try
            {
                using (SqlDataReader rdr = SQLHelper.ExecuteReader(SQLHelper.strConnection, CommandType.Text, strSql, null))
                {
                    int intCount = 0;
                    if (rdr.Read())
                        intCount = int.Parse(rdr[0].ToString());
                    rdr.Close();
                    return intCount == 0 ? false : true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // <summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/02/01
        // 功能簡述：取得各細項功能控制項
        // 修改人：
        // 修改日期：
        // </summary>
        public DataSet getDtlFunctionControl(string strUser_Id, string strFun_Id)
        {
            LimitValidator_Library ll = new LimitValidator_Library();
            string strSql = "{0} WHERE a.USERID = '{1}' AND c.FUN_ID = '{2}'";
            strSql = string.Format(strSql, ll.sqlLimitCheck("getDtlFunControl"), strUser_Id, strFun_Id);

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

        // <summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/02/01
        // 功能簡述：取得使用者之頁面角色
        // 修改人：
        // 修改日期：
        // </summary>
        public DataSet getUserRoleInfo(string strUser_Id, string strFun_Id)
        {
            LimitValidator_Library ll = new LimitValidator_Library();
            string strSql = "{0} WHERE a.USERID = '{1}' AND b.FUN_ID = '{2}' ";
            strSql = string.Format(strSql, ll.sqlLimitCheck("getUserRoleInfo"), strUser_Id, strFun_Id);

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

        // <summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/02/01
        // 功能簡述：取得使用者之員工編號與組織編號
        // 修改人：
        // 修改日期：
        // </summary>
        public string getEmpOrgInfo(string strUser_Id)
        {
            LimitValidator_Library ll = new LimitValidator_Library();

            string strSql = ll.sqlLimitCheck("getEmpOrgInfo");
            strSql += "WHERE a.USERID = '" + strUser_Id + "'";

            try
            {
                using (SqlDataReader rdr = SQLHelper.ExecuteReader(SQLHelper.strConnection, CommandType.Text, strSql, null))
                {
                    string strEmp_Org = "";
                    if (rdr.Read())
                        strEmp_Org = rdr[0].ToString() + "," + rdr[1].ToString() + "," + rdr[2].ToString() + "," + rdr[3].ToString();
                    rdr.Close();
                    return strEmp_Org;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}