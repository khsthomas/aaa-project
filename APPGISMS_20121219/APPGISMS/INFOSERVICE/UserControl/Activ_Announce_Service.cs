using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ATTDAO.UserControl;

namespace INFOSERVICE.UserControl
{
    public class Activ_Announce_Service
    {
        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/04/23
        // 功能簡述：取得公告資訊
        // 修改人：
        // 修改日期：
        // </summary>
        public DataSet getActiv_Announce()
        {
            Activ_Announce_DAO ad = new Activ_Announce_DAO();
            return ad.getActiv_Announce();
        }

        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/04/23
        // 功能簡述：取得公告內容
        // 修改人：
        // 修改日期：
        // </summary>
        public DataSet getActiv_AnnounceContent(string strAnn_Id)
        {
            Activ_Announce_DAO ad = new Activ_Announce_DAO();
            return ad.getActiv_AnnounceContent(strAnn_Id);
        }
    }
}
