using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CTLLIBRARY.Report;

namespace ATTDAO.Report
{
    public class Distribute_Map_DAO
    {
        string strSql = "";
        // </summary>
        // 撰寫人：Jacky
        // 撰寫日期：2011/02/26
        // 功能簡述：(下拉式選單)年度資料擷取
        // 最後更新日期：
        // 修改人：
        // 修改日期：
        // </summary>
        public DataSet getddlYearly()
        {
            Distribute_Map_Library DML = new Distribute_Map_Library();
            strSql = DML.getSqlDataYear();

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
        // 撰寫日期：2011/02/26
        // 功能簡述：(下拉式選單)分區資料
        // 最後更新日期：
        // 修改人：
        // 修改日期：
        // </summary>
        public DataSet getddlArea()
        {
            Distribute_Map_Library DML = new Distribute_Map_Library();
            strSql = DML.getSqlArea();

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
        // 撰寫日期：2011/02/26
        // 功能簡述：(下拉式選單)分區資料
        // 最後更新日期：
        // 修改人：
        // 修改日期：
        // </summary>
        public DataSet getddlCounty(string strDataYear, string strArea)
        {
            Distribute_Map_Library DML = new Distribute_Map_Library();
            strSql = DML.getSqlCounty(strDataYear, strArea);

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
        // 撰寫日期：2011/02/26
        // 功能簡述：gridview資料
        // 最後更新日期：
        // 修改人：
        // 修改日期：
        // </summary>
        public DataSet getgrvDistribute(string strDataYear, string strArea, string strCounty)
        {
            Distribute_Map_Library DML = new Distribute_Map_Library();
            strSql = DML.getgrvDistribute(strDataYear, strArea, strCounty);

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
