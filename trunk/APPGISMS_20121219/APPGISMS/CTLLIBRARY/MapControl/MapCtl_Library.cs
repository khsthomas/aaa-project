using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTLLIBRARY.MapControl
{
    public class MapCtl_Library
    {
        string strSql = "";
        public string getTownColor(string strDATA_YEAR, string strCounty_no)
        {
            strSql = "SELECT a.county_no, a.town_no, b.LAYER_COLOR AS data_content ";
            strSql += "FROM tb_town_data a ";
            strSql += "INNER JOIN TB_LAYER_COLOR b on (a.data_content = b.LAYER_TYPE) ";
            strSql += "WHERE a.county_no = '" + strCounty_no + "' ";
            strSql += "AND a.data_type='LCL' ";
            strSql += "AND a.DATA_YEAR = '" + strDATA_YEAR + "' ";
            
            return strSql;
        }

        public string getSchoolArea(string strDATA_YEAR, string strCounty_no)
        {
            if (int.Parse(strDATA_YEAR) <= 99)
            {
                strSql = "SELECT school_name, school_type, school_y AS school_x, school_x AS school_y ";
                strSql += "FROM tb_school_info ";
                strSql += "WHERE county_no = (select NEXT_COUNTY_NO from TB_DISTRICT_MAPPING ";
                strSql += "                     Where PRE_DISTRICT_VAR = '01' and PRE_COUNTY_NO = '" + strCounty_no + "' Group By NEXT_COUNTY_NO) ";
                strSql += "  and town_no in (select NEXT_TOWN_NO from TB_DISTRICT_MAPPING ";
                strSql += "                     Where PRE_DISTRICT_VAR = '01' and PRE_COUNTY_NO = '" + strCounty_no + "' and NEXT_TOWN_NO is not null) ";
                strSql += "  and SCHOOL_TYPE in ('E', 'J') ";
            }
            else
            {
                strSql = "SELECT school_name, school_type, school_y AS school_x, school_x AS school_y ";
                strSql += "FROM tb_school_info ";
                strSql += "WHERE county_no = (Select county_no From TB_COUNTY_INFO Where COUNTY_VARSION = '02' and county_no = '" + strCounty_no + "') ";
                strSql += "  and SCHOOL_TYPE in ('E', 'J') ";
            }
            
            return strSql;
        }

        public string getHOSPITALArea(string strDATA_YEAR, string strCounty_no)
        {
            if (int.Parse(strDATA_YEAR) <= 99)
            {
                strSql = "SELECT hospital_name, hospital_y AS hospital_x, hospital_x AS hospital_y ";
                strSql += "FROM tb_hospital_info ";
                //strSql += "WHERE hospital_county = (Select county_no From TB_COUNTY_INFO Where COUNTY_VARSION = '02' and county_no = '" + strCounty_no + "') ";
                strSql += "WHERE hospital_county = (select NEXT_COUNTY_NO from TB_DISTRICT_MAPPING ";
                strSql += "                     Where PRE_DISTRICT_VAR = '01' and PRE_COUNTY_NO = '" + strCounty_no + "' Group By NEXT_COUNTY_NO) ";
                strSql += "  and HOSPITAL_TOWN in (select NEXT_TOWN_NO from TB_DISTRICT_MAPPING ";
                strSql += "                     Where PRE_DISTRICT_VAR = '01' and PRE_COUNTY_NO = '" + strCounty_no + "' and NEXT_TOWN_NO is not null) ";
            }
            else
            {
                strSql = "SELECT hospital_name, hospital_y AS hospital_x, hospital_x AS hospital_y ";
                strSql += "FROM tb_hospital_info ";
                strSql += "WHERE hospital_county = (Select county_no From TB_COUNTY_INFO Where COUNTY_VARSION = '02' and county_no = '" + strCounty_no + "') ";
            }
            return strSql;
        }
    }
}
