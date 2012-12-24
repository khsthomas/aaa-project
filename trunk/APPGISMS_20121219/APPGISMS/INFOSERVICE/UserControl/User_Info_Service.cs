using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ATTDAO.UserControl;

namespace INFOSERVICE.UserControl
{
    public class User_Info_Service
    {
        // </summary>
        // 撰寫人：Hilda
        // 撰寫日期：2010/08/08
        // 功能簡述：取得登入者資訊
        // 修改人：
        // 修改日期：
        // </summary>
        public DataSet getUser_Info(string strUser_ID)
        {
            User_Info_DAO uid = new User_Info_DAO();
            return uid.getUser_Info(strUser_ID);
        }
        // </summary>
        // 撰寫人：Hilda
        // 撰寫日期：2010/08/22
        // 功能簡述：取得角色功能權限
        // 修改人：
        // 修改日期：
        // </summary>
        public DataSet getRole_DtlFun_Info(string strUser_ID, string strFun_ID)
        {
            User_Info_DAO uid = new User_Info_DAO();
            return uid.getRole_DtlFun_Info(strUser_ID, strFun_ID);
        }
    }
}
