using System.Data;
using ATTDAO.ManageTool;

namespace INFOSERVICE.ManageTool
{
    public class Hospital_Repeat_Service
    {
        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2011/02/26
        // 功能簡述：縣市資料取得
        // 修改人：
        // 修改日期：
        // </summary>
        public DataSet getCountyInfo()
        {
            Hospital_Repeat_DAO hrd = new Hospital_Repeat_DAO();
            return hrd.getCountyInfo();
        }

        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2011/02/26
        // 功能簡述：鄉鎮市區資料取得
        // 修改人：
        // 修改日期：
        // </summary>
        public DataSet getTownInfo(string strCounty_No)
        {
            Hospital_Repeat_DAO hrd = new Hospital_Repeat_DAO();
            return hrd.getTownInfo(strCounty_No);
        }

        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2011/02/26
        // 功能簡述：院所資料取得
        // 修改人：
        // 修改日期：
        // </summary>
        public DataSet getHospitalInfo(string strCounty_No, string strTown_No, string strHospital_Name)
        {
            Hospital_Repeat_DAO hrd = new Hospital_Repeat_DAO();
            return hrd.getHospitalInfo(strCounty_No, strTown_No, strHospital_Name);
        }

        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2011/02/26
        // 功能簡述：院所資料修正
        // 修改人：
        // 修改日期：
        // </summary>
        public int setHospitalInfo(DataTable dt)
        {
            Hospital_Repeat_DAO hrd = new Hospital_Repeat_DAO();
            return hrd.setHospitalInfo(dt);
        }
    }
}
