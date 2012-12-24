
namespace CTLLIBRARY.DialogControl
{
    public class Address_Info_Dialog_Library
    {
        // </summary>
        // 撰寫人：Edison
        // 撰寫日期：2012/09/28
        // 功能簡述：SQL
        // 最後更新日期：
        // 修改人：
        // 修改日期：
        // </summary>
        public string sqlAddressInfo(string strType)
        {
            string strSql = "";
            switch (strType)
            {
                case "getlbxCounty":
                    strSql = @"SELECT COUNTY_NO, COUNTY_NAME FROM TB_COUNTY_INFO";
                    break;
                case "getlbxTown":
                    strSql = @"SELECT TOWN_NO, TOWN_NAME FROM TB_TOWN_INFO";
                    break;
                case "getlbxRoad":
                    strSql = @"SELECT ROAD_NO, ROAD_NAME FROM TB_ROAD_INFO";
                    break;
                case "getZipCode":
                    strSql = @"SELECT ZIP_CODE FROM TB_ROAD_INFO";
                    break;
            }

            return strSql;
        }
    }
}
