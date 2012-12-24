using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTLLIBRARY.Report
{
    public class Distribute_Map_Library
    {
        string strSql = "";
        public string getSqlDataYear()
        {
            strSql = "Select DATA_YEAR From TB_TOWN_DATA Group By DATA_YEAR ORDER BY CONVERT(INT, DATA_YEAR) DESC";
            return strSql;
        }

        public string getSqlArea()
        {
            strSql = "SELECT CL_INF, CL_DESC ";
            strSql += "FROM TB_TABLE_CONFIG ";
            strSql += "WHERE TB_NAME = 'TB_COUNTY_INFO' AND CL_NAME = 'COUNTY_AREA' AND CL_STS = 'S' ";
            strSql += "ORDER BY CL_ORDER ";
            return strSql;
        }

        public string getSqlCounty(string strDataYear, string strArea)
        {
            strSql = "Select x.COUNTY_NO, b.COUNTY_NAME ";
            strSql += "From (Select a.COUNTY_NO ";
            strSql += "		From TB_TOWN_DATA a ";
            strSql += "		Where a.DATA_YEAR = '" + strDataYear + "' ";
            strSql += "		Group by a.COUNTY_NO) x ";
            strSql += "INNER JOIN TB_COUNTY_INFO b on (x.COUNTY_NO = b.COUNTY_NO and b.COUNTY_AREA = '" + strArea + "' ";
            strSql += "							and b.COUNTY_VARSION = (Select TOP(1) COUNTY_VARSION From TB_TOWN_DATA ";
            strSql += "													Where DATA_YEAR = '" + strDataYear + "' ";
            strSql += "													Group By COUNTY_VARSION)) ";
            strSql += "Order By x.COUNTY_NO ";
            return strSql;
        }

        public string getgrvDistribute(string strDataYear, string strArea, string strCounty)
        {
            strSql = "WITH ";
            strSql += "TMP1 AS "; //牙醫師數
            strSql += "( ";
            strSql += "	Select DATA_YEAR, COUNTY_VARSION, COUNTY_NO, TOWN_NO, SUM(convert(int, isnull(DATA_CONTENT, 0))) AS DATA_CONTENT ";
            strSql += "	From TB_TOWN_DATA ";
            strSql += "	Where DATA_YEAR = '" + strDataYear + "' ";
            strSql += "	  and COUNTY_VARSION = (Select TOP(1) COUNTY_VARSION From TB_TOWN_DATA ";
            strSql += "													Where DATA_YEAR = '" + strDataYear + "' ";
            strSql += "													Group By COUNTY_VARSION) ";
            strSql += "	  and DATA_TYPE in ('HDC', 'CDC') ";
            strSql += "	Group By DATA_YEAR, COUNTY_VARSION, COUNTY_NO, TOWN_NO ";
            strSql += "), ";
            strSql += "TMP2 AS "; //人口數
            strSql += "( ";
            strSql += "	Select DATA_YEAR, COUNTY_VARSION, COUNTY_NO, TOWN_NO, convert(int, isnull(DATA_CONTENT, 0)) AS DATA_CONTENT ";
            strSql += "	From TB_TOWN_DATA ";
            strSql += "	Where DATA_YEAR = '" + strDataYear + "' ";
            strSql += "	  and COUNTY_VARSION = (Select TOP(1) COUNTY_VARSION From TB_TOWN_DATA ";
            strSql += "													Where DATA_YEAR = '" + strDataYear + "' ";
            strSql += "													Group By COUNTY_VARSION) ";
            strSql += "	  and DATA_TYPE = 'DPC' ";
            strSql += "), ";
            strSql += "TMP3 AS "; //土地面積
            strSql += "( ";
            strSql += "	Select DATA_YEAR, COUNTY_VARSION, COUNTY_NO, TOWN_NO, convert(float, isnull(DATA_CONTENT, 0)) AS DATA_CONTENT ";
            strSql += "	From TB_TOWN_DATA ";
            strSql += "	Where DATA_YEAR = '" + strDataYear + "' ";
            strSql += "	  and COUNTY_VARSION = (Select TOP(1) COUNTY_VARSION From TB_TOWN_DATA ";
            strSql += "													Where DATA_YEAR = '" + strDataYear + "' ";
            strSql += "													Group By COUNTY_VARSION) ";
            strSql += "	  and DATA_TYPE = 'DLG' ";
            strSql += "), ";
            strSql += "TMP4 AS "; //顏色
            strSql += "( ";
            strSql += "	Select x.DATA_YEAR, x.COUNTY_VARSION, x.COUNTY_NO, x.TOWN_NO, x.DATA_CONTENT, y.LAYER_COLOR, z.CL_DESC ";
            strSql += "	From (Select DATA_YEAR, COUNTY_VARSION, COUNTY_NO, TOWN_NO, DATA_TYPE, DATA_CONTENT ";
            strSql += "		  From TB_TOWN_DATA ";
            strSql += "	      Where DATA_YEAR = '" + strDataYear + "' ";
            strSql += "	        and COUNTY_VARSION = (Select TOP(1) COUNTY_VARSION From TB_TOWN_DATA ";
            strSql += "													Where DATA_YEAR = '" + strDataYear + "' ";
            strSql += "													Group By COUNTY_VARSION) ";
            strSql += "			and DATA_TYPE = 'LCL') x ";
            strSql += "	INNER JOIN TB_LAYER_COLOR y on (x.DATA_CONTENT = y.LAYER_TYPE) ";
            strSql += "	INNER JOIN TB_TABLE_CONFIG z on (z.TB_NAME = 'TB_LAYER_COLOR' and z.CL_NAME = 'LAYER_TYPE' and z.CL_STS = 'S' and z.CL_INF = x.DATA_CONTENT) ";
            strSql += ") ";
            strSql += "Select a.DATA_YEAR, a.COUNTY_VARSION, a.COUNTY_NO, b.COUNTY_NAME, a.TOWN_NO, c.TOWN_NAME, ";
            strSql += "case a.DATA_CONTENT when 0 then 0 else ROUND((d.DATA_CONTENT / a.DATA_CONTENT), 2) end AS Doctor_Rate, ";
            strSql += "d.DATA_CONTENT AS Person_Count, ";
            strSql += "case e.DATA_CONTENT when 0 then 0 else ROUND((d.DATA_CONTENT / e.DATA_CONTENT), 2) end AS Person_Density, ";
            strSql += "f.DATA_CONTENT AS LCL, f.LAYER_COLOR, f.CL_DESC AS Evaluate ";
            strSql += "From TMP1 a ";
            strSql += "INNER JOIN TB_COUNTY_INFO b on (a.COUNTY_NO = b.COUNTY_NO and a.COUNTY_VARSION = b.COUNTY_VARSION) ";
            strSql += "INNER JOIN TB_TOWN_INFO c on (a.TOWN_NO = c.TOWN_NO and a.COUNTY_NO = c.COUNTY_NO and a.COUNTY_VARSION = c.COUNTY_VARSION) ";
            strSql += "INNER JOIN TMP2 d on (a.DATA_YEAR = d.DATA_YEAR and a.COUNTY_VARSION = d.COUNTY_VARSION and a.COUNTY_NO = d.COUNTY_NO and a.TOWN_NO = d.TOWN_NO) ";
            strSql += "INNER JOIN TMP3 e on (a.DATA_YEAR = e.DATA_YEAR and a.COUNTY_VARSION = e.COUNTY_VARSION and a.COUNTY_NO = e.COUNTY_NO and a.TOWN_NO = e.TOWN_NO) ";
            strSql += "LEFT JOIN TMP4 f on (a.DATA_YEAR = f.DATA_YEAR and a.COUNTY_VARSION = f.COUNTY_VARSION and a.COUNTY_NO = f.COUNTY_NO and a.TOWN_NO = f.TOWN_NO) ";
            strSql += "Where a.COUNTY_NO = '" + strCounty + "' ";
            strSql += "  and b.COUNTY_AREA = '" + strArea + "' ";

            return strSql;
        }
    }
}
