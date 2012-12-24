using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;

namespace YEZZ
{
    public class DataMapping
    {
        public static Color HexToColor(string strHex)
        {
            return Color.FromArgb(int.Parse(strHex, System.Globalization.NumberStyles.HexNumber));
        }

        public static string ColorToHex(Color color)
        {
            return color.ToArgb().ToString("X");
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
