
namespace CTLLIBRARY.WebServices
{
    public class GetPositionService_Library
    {
        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/04/23
        // 功能簡述：取得鄉鎮市座標資料
        // 修改人：
        // 修改日期：
        // </summary>
        public string sqlPosition(string strType)
        {
            string strSql = "";
            switch (strType)
            {
                case "getCountyXY":
                    strSql = @"SELECT COUNTY_X AS MAP_X, COUNTY_Y AS MAP_Y, COUNTY_SCALE AS MAP_SCALE FROM TB_COUNTY_INFO 
                                     WHERE COUNTY_VARSION = (SELECT MAX(COUNTY_VARSION) FROM TB_COUNTY_INFO)";
                    break;
                case "getTownXY":
                    strSql = @"SELECT TOWN_X AS MAP_X, TOWN_Y AS MAP_Y, TOWN_SCALE AS MAP_SCALE FROM TB_TOWN_INFO 
                                     WHERE COUNTY_VARSION = (SELECT MAX(COUNTY_VARSION) FROM TB_COUNTY_INFO)";
                    break;
            }
            return strSql;
        }
    }
}
