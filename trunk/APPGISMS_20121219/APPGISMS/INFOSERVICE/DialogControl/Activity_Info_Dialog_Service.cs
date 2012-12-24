using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ATTDAO.DialogControl;

namespace INFOSERVICE.DialogControl
{
    public class Activity_Info_Dialog_Service
    {
        public DataSet getgrvActInfo(string strAct_Info)
        {
            Activity_Info_Dialog_DAO aidd = new Activity_Info_Dialog_DAO();

            return aidd.getgrvActInfo(strAct_Info);
        }
    }
}
