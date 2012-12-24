using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTLLIBRARY.UserControl
{
    public class User_Info_Library
    {
        string strSql = "";

        // </summary>
        // 撰寫人：Hilda
        // 撰寫日期：2010/08/08
        // 功能簡述：取得登入者DB資料
        // 修改人：
        // 修改日期：
        // </summary>
        public string getUser_Info(string strType)
        {
            switch(strType)
            {
                //取得登入者資訊
                case "getLogin_User_Info":
//                    strSql = @"SELECT USERID, USER_TYPE 
//                                   , CASE WHEN u.ASS_ID = '1000' THEN '全聯會' 
//                                     WHEN u.ASS_ID != '1000' THEN d.ASS_NAME 
//                                     WHEN u.ASS_ID IS NULL THEN c.ASS_NAME 
//                                     END ASS_NAME, 
//                                     b.CHI_LAST_NAME, b.CHI_FIRST_NAME, u.ASS_ID
//                                    ,u.DOCTOR_SN 
//                                    , CASE WHEN u.ASS_ID = '1000' THEN 'http://www.cda.org.tw/' 
//                                     WHEN u.ASS_ID != '1000' THEN c.ASS_URL 
//                                     WHEN u.ASS_ID IS NULL THEN c.ASS_URL 
//                                     END ASS_URL 
//
//                                  FROM TB_USER_INFO u 
//                                  LEFT JOIN TB_DOCTOR_DTL a ON (u.DOCTOR_SN = a.DOCTOR_SN) 
//                                  LEFT JOIN TB_DOCTOR_INFO b ON (a.DOCTOR_SN = b.DOCTOR_SN) 
//                                  LEFT JOIN TB_ASSOCIATION_INFO c ON (c.ASS_ID = a.ASSOCIATION_ID) 
//                                  LEFT JOIN TB_ASSOCIATION_INFO d ON (d.ASS_ID = u.ASS_ID) ";
                    strSql = @"SELECT u.USERID, USER_TYPE, u.SYS_TYPE, e.ROLE_ID, ROLE_NAME 
                                   , CASE WHEN u.ASS_ID = '1000' THEN '全聯會' 
                                     WHEN u.ASS_ID != '1000' AND USER_TYPE = 'M' THEN d.ASS_NAME 
                                     WHEN USER_TYPE = 'D' THEN c.ASS_NAME 
                                     END ASS_NAME
                                   , CASE WHEN USER_TYPE = 'D' THEN b.CHI_LAST_NAME 
                                          WHEN USER_TYPE = 'E' THEN g.CHI_LAST_NAME
                                     END CHI_LAST_NAME
                                   , CASE WHEN USER_TYPE = 'D' THEN b.CHI_FIRST_NAME
                                          WHEN USER_TYPE = 'E' THEN g.CHI_FIRST_NAME
                                     END CHI_FIRST_NAME
                                   , u.ASS_ID
                                   ,u.DOCTOR_SN 
                                    , CASE WHEN u.ASS_ID = '1000' THEN 'http://www.cda.org.tw/' 
                                     WHEN u.ASS_ID != '1000' AND USER_TYPE = 'M' THEN d.ASS_URL 
                                     WHEN USER_TYPE = 'D' THEN c.ASS_URL 
                                     END ASS_URL 

                                  FROM TB_USER_INFO u 
                                  LEFT JOIN TB_DOCTOR_DTL a ON (u.DOCTOR_SN = a.DOCTOR_SN) 
                                  LEFT JOIN TB_DOCTOR_INFO b ON (a.DOCTOR_SN = b.DOCTOR_SN) 
                                  LEFT JOIN TB_ASSOCIATION_INFO c ON (c.ASS_ID = a.ASSOCIATION_ID) 
                                  LEFT JOIN TB_ASSOCIATION_INFO d ON (d.ASS_ID = u.ASS_ID) 
                                  LEFT JOIN TB_USER_ROLE e ON (e.USERID = u.USERID)
                                  LEFT JOIN TB_ROLE_INFO f ON (f.ROLE_ID = e.ROLE_ID)
                                  LEFT JOIN TB_MEMBER_INFO g ON (g.USERID = u.USERID)";
              break;

                //取得角色功能權限
                case "getRole_DtlFun_Info":
              strSql = @" SELECT a.USERID, d.FUN_ID, b.ROLE_ID
                          FROM TB_USER_INFO a
                          INNER JOIN TB_USER_ROLE b ON (a.USERID = b.USERID)
                          INNER JOIN TB_ROLE_FUN c ON (c.ROLE_ID = b.ROLE_ID)
                          INNER JOIN TB_FUN_INFO d ON (d.FUN_ID = c.FUN_ID) ";

              break;
            }
            return strSql;
        }
    }
}
