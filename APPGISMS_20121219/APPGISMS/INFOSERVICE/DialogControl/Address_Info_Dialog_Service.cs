using System;
using System.Data;
using System.Data.SqlClient;
using ATTDAO.DialogControl;

namespace INFOSERVICE.DialogControl
{
    public class Address_Info_Dialog_Service
    {
        // </summary>
        // 撰寫人：Edison
        // 撰寫日期：2012/09/28
        // 功能簡述：擷取縣市下拉式選單
        // 最後更新日期：
        // 修改人：
        // 修改日期：
        // </summary>
        public DataSet getlbxCounty()
        {
            Address_Info_Dialog_DAO aidd = new Address_Info_Dialog_DAO();
            return aidd.getlbxCounty();
        }

        // </summary>
        // 撰寫人：Edison
        // 撰寫日期：2012/09/28
        // 功能簡述：擷取鄉鎮下拉式選單
        // 最後更新日期：
        // 修改人：
        // 修改日期：
        // </summary>
        public DataSet getlbxTown(string strCounty_No)
        {
            Address_Info_Dialog_DAO aidd = new Address_Info_Dialog_DAO();
            return aidd.getlbxTown(strCounty_No);
        }

        // </summary>
        // 撰寫人：Edison
        // 撰寫日期：2012/09/28
        // 功能簡述：擷取道路下拉式選單
        // 最後更新日期：
        // 修改人：
        // 修改日期：
        // </summary>
        public DataSet getlbxRoad(string strCounty_No, string strTown_No)
        {
            Address_Info_Dialog_DAO aidd = new Address_Info_Dialog_DAO();
            return aidd.getlbxRoad(strCounty_No, strTown_No);
        }

        // </summary>
        // 撰寫人：Edison
        // 撰寫日期：2012/09/28
        // 功能簡述：取得完整下拉式選單
        // 最後更新日期：
        // 修改人：
        // 修改日期：
        // </summary>
        public DataSet getlbxAddress(string strCounty_No, string strTown_No)
        {
            Address_Info_Dialog_DAO aidd = new Address_Info_Dialog_DAO();
            return aidd.getlbxAddress(strCounty_No, strTown_No);
        }

        // </summary>
        // 撰寫人：Edison
        // 撰寫日期：2012/09/28
        // 功能簡述：取得郵遞區號
        // 最後更新日期：
        // 修改人：
        // 修改日期：
        // </summary>
        public string getZipCode(string strCounty_No, string strTown_No, string strRoad_No)
        {
            Address_Info_Dialog_DAO aidd = new Address_Info_Dialog_DAO();
            return aidd.getZipCode(strCounty_No, strTown_No, strRoad_No);
        }
    }
}
