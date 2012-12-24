using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTLLIBRARY.DialogControl
{
    public class Activity_Info_Dialog_Library
    {
        public string sqlActivity_Info_Dialog(string strType)
        {
            string strSql = "";
            switch (strType)
            {
                case "getgrvActInfo":
                    strSql = @" SELECT ACTIVITY_SN, a.ACTIVITY_NAME, b.ORGANIZER_NAME, a.ORGANIZER_ID, c.CL_DESC AS ACTIVITY_STATE, a.ACTIVITY_SDATE, a.ACTIVITY_EDATE
                                FROM TB_ACTIVITY_FORM a
                                INNER JOIN TB_ORGANIZER_INFO b ON (a.ORGANIZER_ID = b.ORGANIZER_ID)
                                INNER JOIN TB_TABLE_CONFIG c ON (c.TB_NAME = 'TB_ACTIVITY_FORM' AND c.CL_NAME = 'ACTIVITY_STATE' AND c.CL_STS = 'S' AND c.CL_INF = a.ACTIVITY_STATE) ";
                    break;


            }
            return strSql;
        }
    }
}
