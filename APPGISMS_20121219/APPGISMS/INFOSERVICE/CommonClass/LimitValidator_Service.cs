using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ATTDAO.CommonClass;

namespace INFOSERVICE.CommonClass
{
    public class LimitValidator_Service
    {
        // <summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/02/01
        // 功能簡述：各網頁功能認證
        // 修改人：
        // 修改日期：
        // </summary>
        public bool getLimitWebFunChk(string strUser_Id, string strFun_Id)
        {
            LimitValidator_DAO ld = new LimitValidator_DAO();
            return ld.getLimitWebFunChk(strUser_Id, strFun_Id);
        }
        // <summary>
        // 撰寫人：Hilda
        // 撰寫日期：2011/08/23
        // 功能簡述：各網頁功能細項控制認證
        // 修改人：
        // 修改日期：
        // </summary>
        public bool getDtlFunChk(string strUser_Id, string strFun_Id)
        {
            LimitValidator_DAO ld = new LimitValidator_DAO();
            return ld.getDtlFunChk(strUser_Id, strFun_Id);
        }
        // <summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/02/01
        // 功能簡述：取得各細項功能控制項
        // 修改人：
        // 修改日期：
        // </summary>
        public DataSet getDtlFunctionControl(string strUser_Id, string strFun_Id)
        {
            LimitValidator_DAO ld = new LimitValidator_DAO();
            return ld.getDtlFunctionControl(strUser_Id, strFun_Id);
        }

        // <summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/02/01
        // 功能簡述：取得使用者之頁面角色
        // 修改人：
        // 修改日期：
        // </summary>
        public DataSet getUserRoleInfo(string strUser_Id, string strFun_Id)
        {
            LimitValidator_DAO ld = new LimitValidator_DAO();
            return ld.getUserRoleInfo(strUser_Id, strFun_Id);
        }

        // <summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/02/01
        // 功能簡述：取得使用者之員工編號與組織編號
        // 修改人：
        // 修改日期：
        // </summary>
        public string getEmpOrgInfo(string strUser_Id)
        {
            LimitValidator_DAO ld = new LimitValidator_DAO();
            return ld.getEmpOrgInfo(strUser_Id);
        }
    }
}
