using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ATTDAO.WebServices;

namespace INFOSERVICE.WebServices
{
    public class FunctionWebService_Service
    {
        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/08/01
        // 功能簡述：
        // 修改人：
        // 修改日期：
        // </summary>
        public DataSet getFunctionInfo(string strUser_Id, string strSystem_Type)
        {
            FunctionWebService_DAO fwd = new FunctionWebService_DAO();
            return fwd.getFunctionInfo(strUser_Id, strSystem_Type);
        }
    }
}
