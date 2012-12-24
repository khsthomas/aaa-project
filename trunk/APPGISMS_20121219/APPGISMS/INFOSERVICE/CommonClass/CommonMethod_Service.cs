using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ATTDAO.CommonClass;

namespace INFOSERVICE.CommonClass
{
    public class CommonMethod_Service
    {
        // </summary>
        // 撰寫人：Luffy
        // 撰寫日期：2010/08/11
        // 功能簡述：取得流水編號
        // 修改人：
        // 修改日期：
        // </summary>
        public string getSerialNumber(string strTable_Name, string strColumne_Name)
        {
            CommonMethod_DAO cmd = new CommonMethod_DAO();
            return cmd.getSerialNumber(strTable_Name, strColumne_Name);
        }
    }
}
