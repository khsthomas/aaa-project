using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTLLIBRARY.UserControl
{
    public class Announcement_Library
    {
        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/04/23
        // 功能簡述：取得公告資訊
        // 修改人：
        // 修改日期：
        // </summary>
        public string getAnnouncement(string strType)
        {
            string strSql = "";
            switch (strType)
            {
                case "getAnnouncement":
                //使用狀態
             strSql = "SELECT ANNOUNCE_ID, ANNOUNCE_SUBJECT, ANNOUNCE_CONTENT, ISNULL(MODIFY_DATE, CREATE_DATE) AS CREATE_DATE FROM TB_ANNOUNCE_INFO ";
                 break;

                //
                case"getNewAnnoun":
                 strSql = "SELECT MAX(ANNOUNCE_ID) FROM TB_ANNOUNCE_INFO ";
                 break;
        
            }


            return strSql;
        }
    }
}
