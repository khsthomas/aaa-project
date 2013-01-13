using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using MapControl;
using System.Collections.Generic;
using System.Drawing;

namespace APPGISMS
{
    public class MapControlLibrary
    {
        private DisplayArea _daArea;

        public MapControlLibrary()
            : this(null, null)
        {
        }

        public MapControlLibrary(string strReportImagePath, string strASPImagePath)
        {
            _daArea = new DisplayArea();
            ReportImagePath = strReportImagePath;
            ASPImagePath = strASPImagePath;
        }

        public string ReportImagePath
        {
            
            get { return _daArea.ReportImagePath; }
            set { _daArea.ReportImagePath = value; }
        }

        public string ASPImagePath
        {
            get { return _daArea.ASPImagePath; }
            set { _daArea.ASPImagePath = value; }
        }

        public void Init_mapini(string strDataYear)
        {
            _daArea._strDataYear = strDataYear;
            _daArea.Init(strDataYear);
        }

        // Add by Alex 2012/12/23
        public void SetTownColor(Dictionary<string, Color> dicTownColor)
        {
            _daArea.SetTownColor(dicTownColor);
        }

        public string SaveReportImage(string strCityCode, bool isDisplaySchool, bool isDisplayHospital)
        {
            string strPrefix = DateTime.Now.Ticks.ToString() + "_";
            _daArea.SetSchoolVisible(isDisplaySchool);
            _daArea.SetHospitalVisible(isDisplayHospital);
            _daArea.DisplayCity = strCityCode;
            //_daArea._strDataYear = strDataYear;

            return _daArea.SaveReportImage(strPrefix);
        }

        public string SaveASPImage(string strCityCode, string strDataYear, bool isDisplaySchool, bool isDisplayHospital)
        {
            string strPrefix = DateTime.Now.Ticks.ToString() + "_";
            _daArea.DisplaySchool = isDisplaySchool;
            _daArea.DisplayHOSPITAL = isDisplayHospital;
            _daArea.SetSchoolVisible(isDisplaySchool);
            _daArea.SetHospitalVisible(isDisplayHospital);
            _daArea.DisplayCity = strCityCode;
            //_daArea._strDataYear = strDataYear;

            return _daArea.SaveASPImage(strPrefix);
        }

    }
}
