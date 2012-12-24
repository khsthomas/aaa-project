using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTLLIBRARY.UserControl
{
    public class Hospital_Detail_Library
    {
        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/04/23
        // 功能簡述：SQL語法
        // 修改人：
        // 修改日期：
        // </summary>
        public string sqlHospitalInfo(string strType, string strHospital_Sn, string strUserID, string strD_H_Type)
        {
            string strSql = "";
            switch (strType)
            {
                //院所詳細資料
                case "getDetail_Info":
                    strSql = string.Format(@"SELECT * FROM FUN_HOSPITAL_DETAIL('{0}', '{1}', '{2}', '')", strHospital_Sn, strUserID, strD_H_Type);
                    break;
                //院所門診資料
                case "getTime_lnfo":
                    strSql = string.Format(@"SELECT * FROM FUN_HOSPITAL_TIME('{0}', '{1}', '{2}', '')", strHospital_Sn, strUserID, strD_H_Type);
                    break;
                //醫生資料
                case "getDoctor_Info":
                    strSql = string.Format(@"	SELECT HOSPITAL_NO, a.DOCTOR_SN, STUFF(b.CHI_LAST_NAME+b.CHI_FIRST_NAME,2,1,'○') AS DOCTOR_NAME, d.CL_DESC AS DOCTOR_SEX, b.DOCTOR_DISPLAY
	                                                        FROM TB_HOSPITAL_DOCTOR a INNER JOIN
		                                                             TB_DOCTOR_INFO b ON (a.DOCTOR_SN = b.DOCTOR_SN) INNER JOIN
		                                                             TB_TABLE_CONFIG c ON (a.DOCTOR_CAPACITY = c.CL_INF AND c.TB_NAME = 'TB_DOCTOR_HOSPITAL' AND c.CL_NAME = 'DOCTOR_CAPACITY' AND c.CL_STS = 'S') INNER JOIN
		                                                             TB_TABLE_CONFIG d ON (b.DOCTOR_SEX = d.CL_INF AND d.TB_NAME = 'TB_DOCTOR_INFO' AND d.CL_NAME = 'DOCTOR_SEX' AND d.CL_STS = 'S')
	                                                        WHERE HOSPITAL_NO = '{0}'
	                                                        ORDER BY c.CL_ORDER", strHospital_Sn);
                    break;
                //專案計劃資料
                case "getProject_Info":
//                    strSql = string.Format(@" SELECT a.HOSPITAL_SN, REPLACE(b.CL_DESC, '院所', '') AS PROJECT_TYPE, a.PROJECT_REMARK 
//                                              FROM TB_PROJECT_INFO a 
//                                              INNER JOIN TB_TABLE_CONFIG b ON (b.TB_NAME = 'TB_PROJECT_INFO' AND b.CL_NAME = 'PROJECT_TYPE' AND b.CL_STS = 'S' AND b.CL_INF = a.PROJECT_TYPE) 
//                                              WHERE HOSPITAL_SN = '{0}'", strHospital_Sn);
                    strSql = string.Format(@"SELECT * FROM FUN_PROJECT_INFO('{0}')", strHospital_Sn);

                    break;
            }
            return strSql;
        }

        // </summary>
        // 撰寫人：Hilda
        // 撰寫日期：2011/10/11
        // 功能簡述：取得醫師門診時間
        // 修改人：
        // 修改日期：
        // </summary>
        public string getDoctor_Time(string strType, string strHospital_Sn, string strDoctor_Sn)
        {
            string strSql = "";
            switch (strType)
            {

                //醫師門診時間
                case "getLanguageInfo_Doctor":
                    strSql = string.Format(@"SELECT * FROM FUN_HOSPITAL_TIME('{0}', '', 'D', '{1}')", strHospital_Sn, strDoctor_Sn);
                    break;
                //醫師語言
                case "getTimeInfo_Doctor":
                    strSql = string.Format(@"SELECT * FROM FUN_HOSPITAL_DETAIL('{0}', '', 'D', '{1}')", strHospital_Sn, strDoctor_Sn);
                    break;
            }
            return strSql;
        }
    }
}
