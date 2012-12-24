using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTLLIBRARY.CommonClass
{
    public class LimitValidator_Library
    {
        // <summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/02/01
        // 功能簡述：SQL
        // 修改人：
        // 修改日期：
        // </summary>
        public string sqlLimitCheck(string strType)
        {
            string strSql = "";
            switch (strType)
            {
                //檢查使用者是否有權限使用特定功能
                case "checkFunLimit":
                    strSql = @"SELECT COUNT(1)
                                     FROM TB_ROLE_FUN a INNER JOIN 
                                               TB_USER_ROLE b ON (a.ROLE_ID = b.ROLE_ID) ";
                    break;

                //檢查使用者是否有權限使用細部控制項功能
                case "checkDtlFun":
                    strSql = @"SELECT COUNT(1)
                               FROM TB_USER_ROLE a 
                               INNER JOIN TB_ROLE_DTL_FUN b ON (b.ROLE_ID = a.ROLE_ID)
                               INNER JOIN TB_DTL_FUN c ON (b.DTL_FUN_ID = c.DTL_FUN_ID)
                               INNER JOIN TB_DTL_CONTROL d ON (c.DTL_FUN_ID = d.DTL_FUN_ID) ";
                    break;
                //取得需關閉之控制項元件
                case "getDtlFunControl":
                    strSql = "SELECT d.CONTROL_ID, d.CONTROL_TYPE, d.CONTAINER_ID, d.IS_CONTROL ";
                    strSql += "FROM TB_USER_ROLE a INNER JOIN ";
                    strSql += "TB_ROLE_DTL_FUN b ON (a.ROLE_ID = b.ROLE_ID) INNER JOIN ";
                    strSql += "TB_DTL_FUN c ON (b.DTL_FUN_ID = c.DTL_FUN_ID) INNER JOIN ";
                    strSql += "TB_DTL_CONTROL d ON (c.DTL_FUN_ID = d.DTL_FUN_ID) ";
                    break;
                //取得使用者之頁面角色
                case "getUserRoleInfo":
                    strSql = "SELECT a.ROLE_ID ";
                    strSql += "FROM TB_USER_ROLE a INNER JOIN ";
                    strSql += "TB_ROLE_FUN b ON (a.ROLE_ID = b.ROLE_ID) ";
                    break;
                //取得使用者之員工編號與組織編號
                case "getEmpOrgInfo":
                    strSql = "SELECT a.EMP_ID, b.ORG_ID, c.ORG_NAME, d.CHI_NAME ";
                    strSql += "FROM TB_USER_INFO a INNER JOIN ";
                    strSql += "TB_EMP_ORG_INFO b ON (a.EMP_ID = b.EMP_ID) INNER JOIN ";
                    strSql += "TB_ORGDTL_INFO c ON (b.ORG_ID = c.ORG_ID) INNER JOIN ";
                    strSql += "TB_EMP_INFO d ON (a.EMP_ID = d.EMP_ID) ";
                    break;
            }
            return strSql;
        }
    }
}
