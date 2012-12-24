
namespace CTLLIBRARY.ManageTool
{
    public class Hospital_Repeat_Library
    {
        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2011/02/26
        // 功能簡述：SQL
        // 修改人：
        // 修改日期：
        // </summary>
        public string sqlHospitalInfo(string strType)
        {
            string strSql = "";
            switch (strType)
            {
                //縣市資料
                case "getCountyInfo":
                    strSql = @"SELECT COUNTY_NO, COUNTY_NAME FROM TB_COUNTY_INFO
                                     WHERE COUNTY_VARSION = (SELECT MAX(COUNTY_VARSION) FROM TB_COUNTY_INFO) ORDER BY COUNTY_ORDER";
                    break;
                //鄉鎮市區資料
                case "getTownInfo":
                    strSql = @"SELECT TOWN_NO, TOWN_NAME FROM TB_TOWN_INFO
                                     WHERE COUNTY_VARSION = (SELECT MAX(COUNTY_VARSION) FROM TB_COUNTY_INFO)";
                    break;
                //牙醫院所資料
                case "getHospitalInfo":
                    strSql = @"SELECT 0 AS MAIN_CHOOSE, HOSPITAL_SN, HOSPITAL_NAME FROM TB_HOSPITAL_INFO";
                    break;
                //牙醫師所屬院所資料
                case "getHospitalDoctor":
                    strSql = @"SELECT a.HOSPITAL_SN, b.DOCTOR_SN, c.CHI_LAST_NAME+c.CHI_FIRST_NAME AS DOCTOR_NAME
                                     FROM TB_HOSPITAL_INFO a INNER JOIN
                                               TB_HOSPITAL_DOCTOR b ON (a.HOSPITAL_SN = b.HOSPITAL_SN) INNER JOIN
                                               TB_DOCTOR_INFO c ON (b.DOCTOR_SN = c.DOCTOR_SN)";
                    break;
            }
            return strSql;
        }

        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2011/02/26
        // 功能簡述：建立TempTable SQL
        // 修改人：
        // 修改日期：
        // </summary>
        public string sqlTempTable(string strType)
        {
            string strSql = "";
            switch (strType)
            {
                //院所資料
                case "createHospitalTemp":
                    strSql = @"CREATE TABLE #TB_HOSPITAL_TMP ( 
                                     MAIN_CHOOSE NVARCHAR(1),
                                     HOSPITAL_SN NVARCHAR(10))";
                    break;
                //牙醫院所資料
                case "createHospitalDoctorTemp":
                    strSql = @"CREATE TABLE #TB_HOSPITAL_DOCTOR_TMP ( 
	                                    HOSPITAL_SN	NVARCHAR(10),
	                                    DOCTOR_SN NVARCHAR(10),
	                                    DOCTOR_CAPACITY NVARCHAR(1),
	                                    DOCTOR_POSITION	NVARCHAR(50),
	                                    EXTENSION_NUMBER NVARCHAR(10))";
                    break;
            }
            return strSql;
        }
    }
}
