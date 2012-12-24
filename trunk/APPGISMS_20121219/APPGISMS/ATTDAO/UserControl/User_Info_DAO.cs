using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CTLLIBRARY.UserControl;

namespace ATTDAO.UserControl
{
    public class User_Info_DAO
    {
        // </summary>
        // 撰寫人：Hilda
        // 撰寫日期：2010/08/08
        // 功能簡述：取得登入者資訊
        // 修改人：
        // 修改日期：
        // </summary>
        public DataSet getUser_Info(string strUser_ID)
        {
            User_Info_Library uil = new User_Info_Library();
            string strSql = string.Format(@" {0} WHERE u.USERID = '{1}' ", uil.getUser_Info("getLogin_User_Info"), strUser_ID);
            

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
        // 撰寫人：Hilda
        // 撰寫日期：2010/08/22
        // 功能簡述：取得角色功能權限
        // 修改人：
        // 修改日期：
        // </summary>
        public DataSet getRole_DtlFun_Info(string strUser_ID, string strFun_ID)
        {
            User_Info_Library uil = new User_Info_Library();
            string strSql = string.Format(@" {0} WHERE a.USERID = '{1}' AND d.FUN_ID = '{2}' ", uil.getUser_Info("getRole_DtlFun_Info"), strUser_ID, strFun_ID);


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
