using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ATTDAO.Report;

namespace INFOSERVICE.Report
{
    public class Distribute_Map_Service
    {
        // </summary>
        // 撰寫人：Jacky
        // 撰寫日期：2011/02/26
        // 功能簡述：(下拉式選單)年度資料擷取
        // 最後更新日期：
        // 修改人：
        // 修改日期：
        // </summary>
        public DataSet getddlYearly()
        {
            Distribute_Map_DAO DMD = new Distribute_Map_DAO();
            return DMD.getddlYearly();
        }

        // </summary>
        // 撰寫人：Jacky
        // 撰寫日期：2011/02/26
        // 功能簡述：(下拉式選單)分區資料
        // 最後更新日期：
        // 修改人：
        // 修改日期：
        // </summary>
        public DataSet getddlArea()
        {
            Distribute_Map_DAO DMD = new Distribute_Map_DAO();
            return DMD.getddlArea();
        }

        // </summary>
        // 撰寫人：Jacky
        // 撰寫日期：2011/02/26
        // 功能簡述：(下拉式選單)分區資料
        // 最後更新日期：
        // 修改人：
        // 修改日期：
        // </summary>
        public DataSet getddlCounty(string strDataYear, string strArea)
        {
            Distribute_Map_DAO DMD = new Distribute_Map_DAO();
            return DMD.getddlCounty(strDataYear, strArea);
        }

        // </summary>
        // 撰寫人：Jacky
        // 撰寫日期：2011/02/26
        // 功能簡述：gridview資料
        // 最後更新日期：
        // 修改人：
        // 修改日期：
        // </summary>
        public DataSet getgrvDistribute(string strDataYear, string strArea, string strCounty)
        {
            Distribute_Map_DAO DMD = new Distribute_Map_DAO();
            return DMD.getgrvDistribute(strDataYear, strArea, strCounty);
        }
    }
}
