using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CTLLIBRARY.MapControl;
using System.Data.SqlClient;

namespace ATTDAO.MapControl
{
    public class MapControl_DAO
    {
        string strSql = "";
        // </summary>
        // 撰寫人：Jacky
        // 撰寫日期：2011/02/27
        // 功能簡述：抓取鄉鎮市顏色
        // 最後更新日期：
        // 修改人：
        // 修改日期：
        // </summary>
        public DataSet getTownColor(string strDATA_YEAR, string strCounty_no)
        {
            MapCtl_Library MCL = new MapCtl_Library();
            strSql = MCL.getTownColor(strDATA_YEAR, strCounty_no);

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
        // 撰寫人：Jacky
        // 撰寫日期：2011/02/27
        // 功能簡述：抓取學校座標
        // 最後更新日期：
        // 修改人：
        // 修改日期：
        // </summary>
        public DataSet getSchoolArea(string strDATA_YEAR, string strCounty_no)
        {
            MapCtl_Library MCL = new MapCtl_Library();
            strSql = MCL.getSchoolArea(strDATA_YEAR, strCounty_no);

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
        // 撰寫人：Jacky
        // 撰寫日期：2011/02/27
        // 功能簡述：抓取醫院座標
        // 最後更新日期：
        // 修改人：
        // 修改日期：
        // </summary>
        public DataSet getHOSPITALArea(string strDATA_YEAR, string strCounty_no)
        {
            MapCtl_Library MCL = new MapCtl_Library();
            strSql = MCL.getHOSPITALArea(strDATA_YEAR, strCounty_no);

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
