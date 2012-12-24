using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Collections.Specialized;
using INFOSERVICE.CommonClass;

namespace CommonClass
{
    public class LimitValidator
    {
        public static string strErrorPageUrl = "http://127.0.0.1/WebSystem/PWP/ErrorPage.htm";

        // <summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/02/01
        // 功能簡述：檢查使用者權限
        // 修改人：
        // 修改日期：
        // </summary>
        public static bool checkUserIsLogin(Page pg, string strUser_Id, string strFun_Id)
        {
            if (!checkWebPageLimit(strUser_Id, strFun_Id))
                return false;
            
            else
            {
                
                //檢查使用者權限
                bool boolCheck = checkWebPageLimit(strUser_Id, strFun_Id);

                if (boolCheck)
                    setPageState(pg, strUser_Id, strFun_Id);

                return boolCheck;
            }
        }

        // <summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/02/01
        // 功能簡述：檢查使用者是否有權限使用特定功能
        // 修改人：
        // 修改日期：
        // </summary>
        private static bool checkWebPageLimit(string strUser_Id, string strFun_Id)
        {
            LimitValidator_Service ls = new LimitValidator_Service();
            return ls.getLimitWebFunChk(strUser_Id, strFun_Id);
        }

        // <summary>
        // 撰寫人：Hilda
        // 撰寫日期：2011/08/23
        // 功能簡述：檢查使用者是否有權限使用細部控制項功能
        // 修改人：
        // 修改日期：
        // </summary>
        public static bool getDtlFunChk(string strUser_Id, string strFun_Id)
        {
            LimitValidator_Service ls = new LimitValidator_Service();
            return ls.getDtlFunChk(strUser_Id, strFun_Id);
        }

        // <summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/02/01
        // 功能簡述：取得各細項功能控制項
        // 修改人：
        // 修改日期：
        // </summary>
        
        //public DataSet getDtlFunctionControl(string strUser_Id, string strFun_Id)
        //{
        //    LimitValidator_Service ls = new LimitValidator_Service();
        //    return ls.getDtlFunctionControl(strUser_Id, strFun_Id);
        //}

        // <summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/02/01
        // 功能簡述：取得使用者之頁面角色
        // 修改人：
        // 修改日期：
        // </summary>

        //public static DataSet getUserRoleInfo(string strUser_Id, string strFun_Id)
        //{
        //    LimitValidator_Service ls = new LimitValidator_Service();
        //    return ls.getUserRoleInfo(strUser_Id, strFun_Id);
        //}

        // <summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/02/01
        // 功能簡述：取得使用者之員工編號與組織編號
        // 修改人：
        // 修改日期：
        // </summary>

        //public string getEmpOrgInfo(string strUser_Id)
        //{
        //    LimitValidator_Service ls = new LimitValidator_Service();
        //    return ls.getEmpOrgInfo(strUser_Id);
        //}

        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/02/01
        // 功能簡述：隱藏控制項
        // 修改人：
        // 修改日期：
        // </summary>
        public static void setPageState(Page pg, string strUser_Id, string strFun_Id)
        {
            LimitValidator_Service ls = new LimitValidator_Service();
            DataSet ds = ls.getDtlFunctionControl(strUser_Id, strFun_Id);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Control page_control = null;
                if (dr["CONTAINER_ID"].ToString() == "Page")
                    page_control = pg.FindControl(dr["CONTROL_ID"].ToString());
                else
                    page_control = getContainer(pg, ds.Tables[0], dr["CONTAINER_ID"].ToString()).FindControl(dr["CONTROL_ID"].ToString());
                page_control.Visible = false;
            }
        }

        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/02/01
        // 功能簡述：取得元件之上層容器
        // 修改人：
        // 修改日期：
        // </summary>
        public static Control getContainer(Page pg, DataTable dt, string strContainer_Id)
        {
            DataRow[] arrdrContainer = dt.Select("CONTROL_ID = '" + strContainer_Id + "'");
            DataRow drContainer = arrdrContainer[0];

            if (drContainer["CONTAINER_ID"].ToString() == "Page")
                return pg.FindControl(drContainer["CONTROL_ID"].ToString());
            else
                return getContainer(pg, dt, drContainer["CONTAINER_ID"].ToString()).FindControl(drContainer["CONTROL_ID"].ToString());
        }
    }
}
