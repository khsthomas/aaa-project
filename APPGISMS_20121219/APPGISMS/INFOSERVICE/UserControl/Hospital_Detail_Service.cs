using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ATTDAO.UserControl;

namespace INFOSERVICE.UserControl
{
    public class Hospital_Detail_Service
    {
        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/04/23
        // 功能簡述：取得醫院詳細資訊
        // 修改人：Hilda
        // 修改日期：2012/4/30
        // </summary>
        public DataSet getHospitalDetail(string strHospital_Sn, string strUserID, string strD_H_Type)
        {
            Hospital_Detail_DAO hdd = new Hospital_Detail_DAO();
            return hdd.getHospitalDetail(strHospital_Sn, strUserID, strD_H_Type);
        }

        // </summary>
        // 撰寫人：Hilda
        // 撰寫日期：2011/10/11
        // 功能簡述：取得醫師門診時間
        // 修改人：
        // 修改日期：
        // </summary>
        public DataSet getDoctor_Time(string strHospital_Sn, string strDoctor_Sn)
        {
            Hospital_Detail_DAO hdd = new Hospital_Detail_DAO();
            return hdd.getDoctor_Time(strHospital_Sn, strDoctor_Sn);
        }
    }
}
