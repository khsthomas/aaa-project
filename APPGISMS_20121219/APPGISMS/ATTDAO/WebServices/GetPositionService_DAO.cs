using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CTLLIBRARY.WebServices;

namespace ATTDAO.WebServices
{
    public class GetPositionService_DAO
    {
        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/04/23
        // 功能簡述：取得鄉鎮市座標資料
        // 修改人：
        // 修改日期：
        // </summary>
        public string getTownXY(string strCounty_No, string strTown_No)
        {
            GetPositionService_Library gpsl = new GetPositionService_Library();
            string strSql;

            if (strTown_No == "NoChoose")
                strSql = string.Format(@"{0} AND COUNTY_NO = '{1}' AND COUNTY_X IS NOT NULL", gpsl.sqlPosition("getCountyXY"), strCounty_No);
            else
                strSql = string.Format(@"{0} AND COUNTY_NO = '{1}' AND TOWN_NO = '{2}' AND TOWN_X IS NOT NULL", gpsl.sqlPosition("getTownXY"), strCounty_No, strTown_No);

            try
            {
                string strTownXY = "";

                using (SqlDataReader rdr = SQLHelper.ExecuteReader(SQLHelper.strConnection, CommandType.Text, strSql, null))
                {
                    if (rdr.Read())
                        strTownXY = rdr["MAP_X"].ToString() + "," + rdr["MAP_Y"].ToString() + "," + rdr["MAP_SCALE"].ToString();
                }

                return strTownXY;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
