using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ATTDAO.UserControl;

namespace INFOSERVICE.UserControl
{
    public class Announcement_Service
    {
        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/04/23
        // 功能簡述：取得公告資訊
        // 修改人：
        // 修改日期：
        // </summary>
        public DataSet getAnnouncement()
        {
            Announcement_DAO ad = new Announcement_DAO();
            return ad.getAnnouncement();
        }

        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/04/23
        // 功能簡述：取得公告內容
        // 修改人：
        // 修改日期：
        // </summary>
        public DataSet getAnnounceContent(string strAnn_Id)
        {
            Announcement_DAO ad = new Announcement_DAO();
            return ad.getAnnounceContent(strAnn_Id);
        }
    }
}
