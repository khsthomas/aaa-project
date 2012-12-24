using System;
using INFOSERVICE.StatisticsInfo;

namespace APPGISMS.StatisticsInfo
{
    // </summary>
    // 撰寫人：Oliver
    // 撰寫日期：2010/04/23
    // 功能簡述：牙醫院所分布狀況
    // 修改人：
    // 修改日期：
    // </summary>
    public partial class Hospital_Doctor_Count : System.Web.UI.Page
    {
        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/04/23
        // 功能簡述：頁面讀取
        // 修改人：
        // 修改日期：
        // </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Statistics_Service ss = new Statistics_Service();
                grvStatistics_Info.DataSource = ss.getStatisticsCount();
                grvStatistics_Info.DataBind();
            }
        }
    }
}
