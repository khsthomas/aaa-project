using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTLLIBRARY.UserControl
{
    public class Activity_List_Library
    {       
        // </summary>
        // 撰寫人：Hilda
        // 撰寫日期：2012/11/20
        // 功能簡述：取得公告資訊
        // 修改人：
        // 修改日期：
        // </summary>
        public string getActivity_List(string Type, string Activity_Sn)
        {
            string strSql = "";
            switch (Type)
            {
                case"List_Info":
                    strSql = @"SELECT  a.ACTIVITY_SN,a.ACTIVITY_NAME, ( a.ACTIVITY_SDATE+' 至 '+a.ACTIVITY_EDATE) AS ACTIVITY_DATE, a.ORGANIZER_NAME,	
	                            CASE WHEN  CONVERT(varchar(100), GETDATE(), 20) > CONVERT(varchar, a.APPLY_EDATE) THEN '截止' 
	                            WHEN count(f.CHECK_STS) >= a.REGISTRATION_NUMBER AND a.REGISTRATION_NUMBER!='-1' THEN '額滿'
	                            WHEN ( CONVERT(varchar(100), GETDATE(), 20) BETWEEN CONVERT(varchar,a.APPLY_SDATE)+' '+a.APPLY_STIME_H+':'+a.APPLY_STIME_M AND CONVERT(varchar, a.APPLY_EDATE)+' '+a.APPLY_ETIME_H+':'+a.APPLY_ETIME_M  )THEN '受理報名中'
	                            WHEN( CONVERT(varchar(100), GETDATE(), 20) BETWEEN CONVERT(varchar,a.ACTIVITY_SDATE)+' '+a.ACTIVITY_STIME_H+':'+a.ACTIVITY_STIME_M AND CONVERT(varchar, a.ACTIVITY_EDATE)+' '+a.ACTIVITY_ETIME_H+':'+a.ACTIVITY_ETIME_M  )THEN '活動進行中'
	                            WHEN CONVERT(varchar(100), GETDATE(), 20) > CONVERT(varchar, a.ACTIVITY_EDATE) THEN '活動結束'
	                            ELSE CL_DESC END ACTIVITY_STATE,ACTIVITY_TYPE_INFO,
                                CASE WHEN count(f.CHECK_STS) >= a.REGISTRATION_NUMBER AND a.REGISTRATION_NUMBER!='-1' THEN 'N' 
	                            WHEN c.COLUMN_ID IS NOT NULL AND ( CONVERT(varchar(100), GETDATE(), 20)BETWEEN CONVERT(varchar,a.APPLY_SDATE)+' '+a.APPLY_STIME_H+':'+a.APPLY_STIME_M AND CONVERT(varchar, a.APPLY_EDATE)+' '+a.APPLY_ETIME_H+':'+a.APPLY_ETIME_M  ) THEN 'Y' ELSE 'N' END REGISTRATION_STATE , 
	                            CASE WHEN REGISTRATION_NUMBER='-1' THEN '不限制報名人數' ELSE '限 正取:'+QUALIFY_NUM+'人 及 備取:'+ALTERNATE_NUM+'人'  END REGISTRATION_NUMBER,'欲知活動詳細內容，請點選活動詳細查詢。' AS ACTIVITY_CONTENT,
                                (APPLY_SDATE+' '+APPLY_STIME_H+':'+APPLY_STIME_M+' 至 '+APPLY_EDATE+' '+APPLY_ETIME_H+':'+APPLY_ETIME_M) AS APPLY_TIME,REGISTRATION_MODE,ACTIVITY_TEL,ACTIVITY_MAIL
                            FROM TB_ACTIVITY_FORM a INNER JOIN
                            TB_TABLE_CONFIG b ON (b.TB_NAME='TB_ACTIVITY_FORM' AND b.CL_NAME='ACTIVITY_STATE' AND a.ACTIVITY_STATE=b.CL_INF) left JOIN
                            TB_REGISTRATION_STATE c ON(a.ACTIVITY_SN=c.ACTIVITY_SN AND c.COLUMN_ID=(select TOP 1 COLUMN_ID from  TB_REGISTRATION_STATE s where  s.ACTIVITY_SN=c.ACTIVITY_SN)) left JOIN
                            TB_REGISTRATION_FORM f ON (a.ACTIVITY_SN=f.ACTIVITY_SN AND f.CHECK_STS = '2' )                               
                              ";
                    break;
                case "ListContent":
                    strSql = string.Format(@"WITH
                                            ATTACH_FILE
                                            AS
                                            (
                                              SELECT TOP 1 ATTACH_NAME, a.ORI_ATTACH_NAME, b.ACTIVITY_SN
                                              FROM TB_FILE_ATTACH a INNER JOIN
                                                   TB_ACTIVITY_FORM b ON (a.TB_PRIMARY_KEY = b.ACTIVITY_SN AND b.ACTIVITY_SN = '{0}')
                                            )
                                            SELECT a.ACTIVITY_SN,a.ACTIVITY_NAME, ( a.ACTIVITY_SDATE+' '+a.ACTIVITY_STIME_H+':'+a.ACTIVITY_STIME_M+' 至 '+a.ACTIVITY_EDATE+' '+a.ACTIVITY_ETIME_H+':'+a.ACTIVITY_ETIME_M) AS ACTIVITY_DATE, a.ORGANIZER_NAME,b.CL_DESC AS ACTIVITY_STATE , ACTIVITY_TYPE_INFO,
                                        --CASE WHEN COLUMN_ID IS NULL OR b.CL_DESC !='活動中'  OR  (GETDATE()-1 < a.APPLY_SDATE OR GETDATE()-1 > a.APPLY_EDATE)  THEN 'N' ELSE 'Y' END REGISTRATION_STATE,
                                       -- CASE WHEN COLUMN_ID IS NOT NULL AND ( GETDATE()  BETWEEN a.APPLY_SDATE AND a.APPLY_EDATE)  THEN 'Y' ELSE 'N' END REGISTRATION_STATE,
                                        CASE WHEN COLUMN_ID IS NOT NULL AND 
                                        ( CONVERT(varchar(100), GETDATE(), 20)
                                            BETWEEN 
                                                CONVERT(varchar,a.APPLY_SDATE)+' '+a.APPLY_STIME_H+':'+a.APPLY_STIME_M   
                                                 AND 
                                                CONVERT(varchar, a.APPLY_EDATE)+' '+a.APPLY_ETIME_H+':'+a.APPLY_ETIME_M  
                                        ) THEN 'Y' ELSE 'N' END REGISTRATION_STATE, CASE WHEN REGISTRATION_NUMBER='-1' THEN '不限制報名人數' ELSE '限 正取:'+QUALIFY_NUM+'人 及 備取:'+ALTERNATE_NUM+'人'  END REGISTRATION_NUMBER,'欲知活動詳細，請點選活動詳細查詢。' AS ACTIVITY_CONTENT,
                                                (APPLY_SDATE+' '+APPLY_STIME_H+':'+APPLY_STIME_M+' 至 '+APPLY_EDATE+' '+APPLY_ETIME_H+':'+APPLY_ETIME_M) AS APPLY_TIME,REGISTRATION_MODE,ACTIVITY_TEL,ACTIVITY_MAIL
                                 
                                  
                                          , d.ATTACH_NAME, d.ORI_ATTACH_NAME AS FILE_ATTACH
                                          FROM TB_ACTIVITY_FORM a INNER JOIN
                                          TB_TABLE_CONFIG b ON (b.TB_NAME='TB_ACTIVITY_FORM' AND b.CL_NAME='ACTIVITY_STATE' AND a.ACTIVITY_STATE=b.CL_INF) left JOIN
                                          TB_REGISTRATION_STATE c ON(a.ACTIVITY_SN=c.ACTIVITY_SN AND c.COLUMN_ID=(select TOP 1 COLUMN_ID from  TB_REGISTRATION_STATE s where  s.ACTIVITY_SN=c.ACTIVITY_SN))                                  
                                          LEFT JOIN ATTACH_FILE d ON (d.ACTIVITY_SN = a.ACTIVITY_SN)
                                          WHERE a.ACTIVITY_SN = '{0}'", Activity_Sn);
                    break;
            }
            return strSql;
        }
    }
}
