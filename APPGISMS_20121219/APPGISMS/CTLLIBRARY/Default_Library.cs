
namespace CTLLIBRARY
{
    public class Default_Library
    {
        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/04/23
        // 功能簡述：SQL
        // 修改人：
        // 修改日期：
        // </summary>
        public string sqlMainPage(string strType)
        {
            string strSql = "";
            switch (strType)
            {
                //取得系統參數
                case "getPageData":
                    strSql = @"SELECT PARAMETER_NAME, PARAMETER_VALUE FROM gis.TB_SYSTEM_PARAMETER ";
                    break;
            }
            return strSql;
        }
    }
}
