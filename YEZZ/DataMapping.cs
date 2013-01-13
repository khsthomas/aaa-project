using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;

namespace YEZZ
{
    public class DataMapping
    {
        public const int ALL_LEVEL = 0;
        public const int AREA_LEVEL = 1;
		public const int COUNTY_LEVEL = 2;
		public const int TOWN_LEVEL = 3;
        public static Color HexToColor(string strHex)
        {
            return Color.FromArgb(int.Parse(strHex, System.Globalization.NumberStyles.HexNumber));
        }

        public static string ColorToHex(Color color)
        {
            return color.ToArgb().ToString("X");
        }

		public static string DataLevelSql(int iDataLevel)
		{
			return DataLevelSql(iDataLevel, "");
		}
		
		public static string DataLevelSql(int iDataLevel, string strPrefix)
		{
			switch(iDataLevel)
			{
				case COUNTY_LEVEL:
					return string.Format("{0}COUNTY_NO", new string[] {strPrefix + "."});
				case TOWN_LEVEL:
					return string.Format("{0}COUNTY_NO, {0}TOWN_NO", new string[] {strPrefix + "."});
			}
			return "";
		}
		
		public static string DoctorSql(int iDataLevel)
		{
			return DoctorSql(iDataLevel, "TMP_DOCTOR");
		}
		
		public static string DoctorSql(int iDataLevel, string strTableName)
		{
			string strSQL = "";
			
			strSQL += "WITH ";
            strSQL += "{0} AS "; //牙醫師數
            strSQL += "( ";
            strSQL += "	SELECT DATA_YEAR, COUNTY_VARSION, {1}, SUM(CONVERT(int, ISNULL(DATA_CONTENT, 0))) AS DATA_CONTENT ";
            strSQL += "	FROM TB_TOWN_DATA ";
            strSQL += "	WHERE DATA_YEAR = @DATA_YEAR ";
            strSQL += "	  AND COUNTY_VARSION = (SELECT TOP(1) COUNTY_VARSION FROM TB_TOWN_DATA ";
            strSQL += "													WHERE DATA_YEAR = @DATA_YEAR ";
            strSQL += "													GROUP BY COUNTY_VARSION) ";
            strSQL += "	  AND DATA_TYPE in ('HDC', 'CDC') ";
            strSQL += "	GROUP BY DATA_YEAR, COUNTY_VARSION, {1} ";
            strSQL += ") ";
			
			return string.Format(strSQL, new string[] {strTableName, DataLevelSql(iDataLevel)});
		}
		
		public static string PopulationSql(int iDataLevel)
		{
			return PopulationSql(iDataLevel, "TMP_POPULATION");
		}
		
		public static string PopulationSql(int iDataLevel, string strTableName)
		{
			string strSQL = "";
			
			strSQL += "{0} AS "; //人口數
            strSQL += "( ";
            strSQL += "	SELECT DATA_YEAR, COUNTY_VARSION, {1}, SUM(CONVERT(int, ISNULL(DATA_CONTENT, 0))) AS DATA_CONTENT ";
            strSQL += "	FROM TB_TOWN_DATA ";
            strSQL += "	WHERE DATA_YEAR = @DATA_YEAR ";
            strSQL += "	  AND COUNTY_VARSION = (SELECT TOP(1) COUNTY_VARSION FROM TB_TOWN_DATA ";
            strSQL += "													WHERE DATA_YEAR = @DATA_YEAR ";
            strSQL += "													GROUP BY COUNTY_VARSION) ";
            strSQL += "	  AND DATA_TYPE = 'DPC' ";
            strSQL += "	GROUP BY DATA_YEAR, COUNTY_VARSION, {1} ";
            strSQL += ") ";
			
			return string.Format(strSQL, new string[] {strTableName, DataLevelSql(iDataLevel)});
		}
		
		public static string GroundSquareSql(int iDataLevel)
		{
			return GroundSquareSql(iDataLevel, "TMP_GROUND_SQUARE");
		}
		
		public static string GroundSquareSql(int iDataLevel, string strTableName)
		{
			string strSQL = "";
			
            strSQL += "{0} AS "; //土地面積
            strSQL += "( ";
            strSQL += "	SELECT DATA_YEAR, COUNTY_VARSION, {1}, CONVERT(float, ISNULL(DATA_CONTENT, 0)) AS DATA_CONTENT ";
            strSQL += "	FROM TB_TOWN_DATA ";
            strSQL += "	WHERE DATA_YEAR = @DATA_YEAR ";
            strSQL += "	  AND COUNTY_VARSION = (SELECT TOP(1) COUNTY_VARSION FROM TB_TOWN_DATA ";
            strSQL += "													WHERE DATA_YEAR = @DATA_YEAR ";
            strSQL += "													GROUP BY COUNTY_VARSION) ";
            strSQL += "	  AND DATA_TYPE = 'DLG' ";
            strSQL += "	GROUP BY DATA_YEAR, COUNTY_VARSION, {1} ";
            strSQL += ") ";

            return string.Format(strSQL, new string[] { strTableName, DataLevelSql(iDataLevel) });
		}
		
		
		public static string ProjectBRSql(int iFormulaLevel, int iDataLevel)
		{
			string strSQL = "";

            strSQL += DoctorSql(iDataLevel) + "," +
                      PopulationSql(iDataLevel) + "," +
                      GroundSquareSql(iDataLevel);
					  
					  
					  
            strSQL += "SELECT a.DATA_YEAR, a.COUNTY_VARSION, a.COUNTY_NO, b.COUNTY_NAME, a.TOWN_NO, c.TOWN_NAME, ";
            strSQL += "CASE a.DATA_CONTENT WHEN 0 THEN 0 ELSE ROUND((d.DATA_CONTENT / a.DATA_CONTENT), 2) END AS DOCTOR_RATE, ";
            strSQL += "d.DATA_CONTENT AS PERSON_COUNT, ";
            strSQL += "CASE e.DATA_CONTENT WHEN 0 THEN 0 ELSE ROUND((d.DATA_CONTENT / e.DATA_CONTENT), 2) END AS PERSON_DENSITY, ";
            strSQL += "FROM TMP_DOCTOR a ";
            strSQL += "INNER JOIN TB_COUNTY_INFO b ON (a.COUNTY_NO = b.COUNTY_NO AND a.COUNTY_VARSION = b.COUNTY_VARSION) ";
            strSQL += "INNER JOIN TB_TOWN_INFO c ON (a.TOWN_NO = c.TOWN_NO AND a.COUNTY_NO = c.COUNTY_NO AND a.COUNTY_VARSION = c.COUNTY_VARSION) ";
            strSQL += "INNER JOIN TMP_POPULATION d ON (a.DATA_YEAR = d.DATA_YEAR AND a.COUNTY_VARSION = d.COUNTY_VARSION AND a.COUNTY_NO = d.COUNTY_NO AND a.TOWN_NO = d.TOWN_NO) ";
            strSQL += "INNER JOIN TMP_GROUND_SQUARE e ON (a.DATA_YEAR = e.DATA_YEAR AND a.COUNTY_VARSION = e.COUNTY_VARSION AND a.COUNTY_NO = e.COUNTY_NO AND a.TOWN_NO = e.TOWN_NO) ";

            switch (iFormulaLevel)
            {
                case AREA_LEVEL:
                    strSQL += "WHERE b.COUNTY_AREA = @COUNTY_AREA";
                    break;
                case COUNTY_LEVEL:
                    strSQL += "WHERE a.COUNTY_NO = @COUNTY_NO ";
                    strSQL += "  AND b.COUNTY_AREA = @COUNTY_AREA ";
                    break;
            }

//            strSQL += "WHERE a.COUNTY_NO = @COUNTY_NO ";
//            strSQL += "  AND b.COUNTY_AREA = @COUNTY_AREA ";					  
			return strSQL;
		}
		
        public static string FormulaToSql(string strFormulaValue)
        {
            // 0: GroupBy, 1:Join Project or All
            string strSQL = "(SELECT COUNT(*) AS FIELD_COUNT, {0} AS GROUP_ID " +
                            "   FROM TB_HOSPITAL_INFO " +
                            "  {1} " +
                            "  GROUP BY {0})";


            string[] strValues = strFormulaValue.Replace("[", "").Replace("]", "").Split(',');
            string strJoinSQL = "WHERE HOSPITAL_NO IN (SELECT DISTINCT HOSPITAL_NO " +
                                "                        FROM TB_PROJECT_DOCTOR " +
                                "                       WHERE PROJECT_SN = @PROJECT_SN)";

            string strGroupBy = "";
            switch(strValues[0])
            {
                case "None":
                    strGroupBy = "HOSPITAL_COUNTY";
                    break;
                case "HOSPITAL_AREA":
                    strGroupBy = "HOSPITAL_COUNTY";
                    break;
                case "HOSPITAL_COUNTY":
                    strGroupBy = "HOSPITAL_TOWN";
                    break;
            }

            switch (strValues[1])
            {
                case "ALL":
                    strJoinSQL = "";
                    break;
            }
            
            return string.Format(strSQL, new string[] {strGroupBy, strJoinSQL});
        }
    }
}
