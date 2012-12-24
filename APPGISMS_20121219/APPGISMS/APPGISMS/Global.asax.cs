using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Xml.Linq;
using INFOSERVICE;

namespace APPGISMS
{
    public class Global : System.Web.HttpApplication
    {


        protected void Application_Start(object sender, EventArgs e)
        {
            //總人數
            Default_Service ds = new Default_Service();
            uint uintCount = ds.getApplicationCount();
            object obj = uintCount;
            Application["counter"] = obj;

            //線上人數
            Application["online"] = 0;
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Application.Lock();

            //取得目前總人數
            uint uintCount = Application["counter"] != null ? Convert.ToUInt32(Application["counter"]) : 0;
            //總人數加一
            object obj = uintCount + 1;
            //記錄總人數
            Application["counter"] = obj;

            //線上人數
            Application["online"] = Convert.ToUInt32(Application["online"]) + 1;

            Application.UnLock();
        }

        protected void Session_End(object sender, EventArgs e)
        {
            //線上人數
            Application.Lock();
            Application["online"] = (int)Application["online"] - 1;
            Application.UnLock();
        }

        protected void Application_End(object sender, EventArgs e)
        {
            Default_Service ds = new Default_Service();
            //取得目前總人數
            uint uintCount = Application["counter"] != null ? Convert.ToUInt32(Application["counter"]) : 0;
            ds.setApplicationCount(uintCount.ToString());
        }
    }
}