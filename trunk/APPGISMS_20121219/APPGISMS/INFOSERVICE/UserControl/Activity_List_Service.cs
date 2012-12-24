using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ATTDAO.UserControl;

namespace INFOSERVICE.UserControl
{
    public class Activity_List_Service
    {
        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/04/23
        // 功能簡述：取得公告資訊
        // 修改人：
        // 修改日期：
        // </summary>
        public DataSet getActivity_List()
        {
            Activity_List_DAO ad = new Activity_List_DAO();
            return ad.getActivity_List();
        }

        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/04/23
        // 功能簡述：取得公告內容
        // 修改人：
        // 修改日期：
        // </summary>
        public DataSet getActivity_ListContent(string strAnn_Id)
        {
            Activity_List_DAO ad = new Activity_List_DAO();
            return ad.getActivity_ListContent(strAnn_Id);
        }
    }
}
