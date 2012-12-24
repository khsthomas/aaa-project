using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CTLLIBRARY.UserControl;

namespace ATTDAO.UserControl
{
    public class Activity_List_DAO
    {
        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/04/23
        // 功能簡述：取得公告資訊
        // 修改人：
        // 修改日期：
        // </summary>
        public DataSet getActivity_List()
        {
            Activity_List_Library al = new Activity_List_Library();
            string strSql = al.getActivity_List("List_Info", null);
            strSql += "GROUP BY a.ACTIVITY_SN, a.ACTIVITY_NAME, (a.ACTIVITY_SDATE+' 至 '+a.ACTIVITY_EDATE), a.ORGANIZER_NAME, ACTIVITY_STATE , ALTERNATE_NUM,QUALIFY_NUM,ACTIVITY_TYPE_INFO ,REGISTRATION_NUMBER ,a.ACTIVITY_SDATE,a.ACTIVITY_EDATE,REGISTRATION_NUMBER, a.APPLY_EDATE, b.CL_DESC,c.COLUMN_ID,a.APPLY_SDATE,a.APPLY_STIME_H,a.APPLY_STIME_M,a.APPLY_ETIME_H,a.APPLY_ETIME_M,a.REGISTRATION_MODE,a.ACTIVITY_TEL,a.ACTIVITY_MAIL,a.REGISTRATION_NUMBER,a.ACTIVITY_STATE,a.APPLY_EDATE, a.ACTIVITY_STIME_H,a.ACTIVITY_STIME_M, ACTIVITY_ETIME_H, ACTIVITY_ETIME_M  ORDER BY a.APPLY_EDATE DESC ";

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
        // 撰寫日期：2010/04/23
        // 功能簡述：取得公告內容
        // 修改人：
        // 修改日期：
        // </summary>
        public DataSet getActivity_ListContent(string strAnn_Id)
        {
            Activity_List_Library al = new Activity_List_Library();
            string strSql = al.getActivity_List("ListContent", strAnn_Id);

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

