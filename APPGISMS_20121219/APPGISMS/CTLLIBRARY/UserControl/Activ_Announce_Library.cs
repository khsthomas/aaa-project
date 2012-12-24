using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTLLIBRARY.UserControl
{
    public class Activ_Announce_Library
    {
        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/04/23
        // 功能簡述：取得公告資訊
        // 修改人：
        // 修改日期：
        // </summary>
        public string getActiv_Announce()
        {
            string strSql = @"SELECT ANNOUNCEMENT_ID, ANNOUNCEMENT_OBJECT,ACTIVITY_NAME,
                                CASE WHEN a.ACTIVITY_SN = '' THEN '系統公告 - '+ANNOUNCEMENT_OBJECT 
                                     ELSE '活動公告 - '+ANNOUNCEMENT_OBJECT   END T_ANNOUNCEMENT_OBJECT,
                                ANNOUNCEMENT_CONTENT, ISNULL(a.MODIFY_DATE, a.CREATE_DATE) AS CREATE_DATE 
                                FROM TB_ACTIVITY_ANNOUNCEMENT_INFO a LEFT JOIN 
                                TB_ACTIVITY_FORM b ON(a.ACTIVITY_SN=b.ACTIVITY_SN)  ";
            return strSql; 
        }
    }
}
