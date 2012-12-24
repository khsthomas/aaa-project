using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ATTDAO.WebServices;

namespace INFOSERVICE.WebServices
{
    public class GetPositionService_Service
    {
        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/04/23
        // 功能簡述：取得鄉鎮市座標資料
        // 修改人：
        // 修改日期：
        // </summary>
        public string getTownXY(string strCounty_No, string strTown_No)
        {
            GetPositionService_DAO gpsd = new GetPositionService_DAO();
            return gpsd.getTownXY(strCounty_No, strTown_No);
        }
    }
}
