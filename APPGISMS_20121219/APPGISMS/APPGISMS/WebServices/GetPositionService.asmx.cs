using System.ComponentModel;
using System.Web.Services;
using INFOSERVICE.WebServices;

namespace APPGISMS.WebServices
{
    /// <summary>
    /// GetPositionService 的摘要描述
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下一行。
    [System.Web.Script.Services.ScriptService]
    public class GetPositionService : System.Web.Services.WebService
    {
        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/04/23
        // 功能簡述：取得鄉鎮市座標資料
        // 修改人：
        // 修改日期：
        // </summary>
        [WebMethod]
        public string getTownXY(string strCounty_No, string strTown_No)
        {
            GetPositionService_Service gpss = new GetPositionService_Service();
            return gpss.getTownXY(strCounty_No, strTown_No);
        }
    }
}
