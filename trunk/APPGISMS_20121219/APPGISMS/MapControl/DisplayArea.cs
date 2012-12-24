using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Data.Common;
using System.Runtime.InteropServices;
using Microsoft.Win32;
//using MapControl.Database;
using MapControl.Reader;
using ATTDAO.MapControl;


namespace MapControl
{          
    [ComVisible(true)]
    public partial class DisplayArea : UserControl, IObjectSafety
    {
        private const int MARK_SIZE = 3;
        private const int PRIMARY_SCHOOL = 0;
        private const string PRIMARY_SCHOOL_TYPE = "E";
        private readonly Color PRIMARY_SCHOOL_COLOR = Color.Yellow;
        private const int JUNIOR_HIGH_SCHOOL = 1;
        private const string JUNIOR_HIGH_SCHOOL_TYPE = "J";
        private readonly Color JUNIOR_HIGH_SCHOOL_COLOR = Color.Green;
        private const int HOSPITAL = 2;
        private const string HOSPITAL_TYPE = "02";
        private readonly Color HOSPITAL_COLOR = Color.Gold;       

        private static readonly int EMPTY_RGB = Color.White.ToArgb();

        private static readonly int LINE_RGB = Color.Black.ToArgb();
        //private string _strDatabaseType;
        //private string _strHost;
        //private string _strDatabase;        
        //private string _strUsername;
        //private string _strPassword;
        private string _strDisplayCity;
        private Dictionary<string, City> _dicCity;
        private List<string> _lstCityName;
        private string _strReportImagePath;
        private string _strASPImagePath;
        private List<string> _lstDisplayBuildingType;
        public bool DisplaySchool;
        public bool DisplayHOSPITAL;
        // Add by Alex 2012/12/23
        private Dictionary<string, Color> _dicTownColor;
        public string _strDataYear;
        private Dictionary<string, Dictionary<string, List<Building>>> _dicBuilding;

        public string ReportImagePath
        {
            get { return _strReportImagePath; }
            set { _strReportImagePath = value; }
        }
        
        public string ASPImagePath
        {
            get { return _strASPImagePath; }
            set { _strASPImagePath = value; }
        }

        public string DisplayCity
        {
            get { return _strDisplayCity; }
            set 
            {

                _strDisplayCity = value;
                if (value == null)
                    return;
                try
                {
                    Assembly myAssembly = Assembly.GetExecutingAssembly();  
                    picMap.Image = Image.FromStream(myAssembly.GetManifestResourceStream("MapControl.images." + _dicCity[value].CityName + ".PNG"));
                    picMap.Top = Height < picMap.Height ? 0 : (int)((Height - picMap.Height) / 2.0);
                    picMap.Left = Width < picMap.Width ? 0 : (int)((Width - picMap.Width) / 2.0);

                    InitBuilding();
                    DisplayBuilding((Bitmap)picMap.Image);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message + "," + ex.StackTrace);
                    throw ex;
                }
            }
        }



        public DisplayArea()
        {
            InitializeComponent();

            picMap.SizeMode = PictureBoxSizeMode.AutoSize;
            _dicBuilding = new Dictionary<string, Dictionary<string, List<Building>>>();
            _dicCity = new Dictionary<string, City>();
            _lstCityName = new List<string>();
            BorderStyle = BorderStyle.Fixed3D;
            _lstDisplayBuildingType = new List<string>();

            //Init();
            //if (int.Parse(_strDataYear) < 100)
            //{
            //    Init("map_old.ini");
            //}
            //else
            //{
            //    Init("map.ini");
            //}
        }

        // Add by Alex 2012/12/23
        public void SetTownColor(Dictionary<string, Color> dicTownColor)
        {
            _dicTownColor = dicTownColor;
        }

        public void AddDisplayBuildingType(string strType)
        {
            if (_lstDisplayBuildingType.IndexOf(strType) < 0)
                _lstDisplayBuildingType.Add(strType);
        }

        public void RemoveDisplayBuildingType(string strType)
        {
            int iIndex;
            if ((iIndex = _lstDisplayBuildingType.IndexOf(strType)) < 0)
                return;
            _lstDisplayBuildingType.RemoveAt(iIndex);
        }

        public void SetSchoolVisible(bool isVisible)
        {
            if (isVisible)
            {
                AddDisplayBuildingType(PRIMARY_SCHOOL_TYPE);
                AddDisplayBuildingType(JUNIOR_HIGH_SCHOOL_TYPE);
            }
            else
            {
                RemoveDisplayBuildingType(PRIMARY_SCHOOL_TYPE);
                RemoveDisplayBuildingType(JUNIOR_HIGH_SCHOOL_TYPE);
            }
        }

        public void SetHospitalVisible(bool isVisible)
        {
            if (isVisible)
            {
                AddDisplayBuildingType(HOSPITAL_TYPE);             
            }
            else
            {
                RemoveDisplayBuildingType(HOSPITAL_TYPE);
            }
        }

        public City GetCity(string strCity)
        {
            return _dicCity.ContainsKey(strCity) ? _dicCity[strCity] : null;
        }

        private void AddBuilding(string strCity, string strType, string strName, double dX, double dY)
        {
            try
            {
                Building building = new Building();
                Dictionary<string, List<Building>> dicBuilding;
                List<Building> lstBuilding;

                building.Name = strName;
                building.Position = new double[] {dX, dY};

                if (_dicBuilding.ContainsKey(strCity) == false)
                    _dicBuilding.Add(strCity, new Dictionary<string, List<Building>>());
                dicBuilding = _dicBuilding[strCity];

                if (dicBuilding.ContainsKey(strType) == false)
                    dicBuilding.Add(strType, new List<Building>());
                lstBuilding = dicBuilding[strType];

                lstBuilding.Add(building);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message + "," + ex.StackTrace);
                throw ex;
            }
        }

        private void InitBuilding()
        {
            MapControl_DAO MCD = new MapControl_DAO();
            try
            {
                // Modify by Alex 2012/12/23
                if (_dicTownColor == null)
                {
                    DataTable dtTown = new DataTable();
                    dtTown = MCD.getTownColor(_strDataYear, DisplayCity).Tables[0];

                    foreach (DataRow dr in dtTown.Rows)
                    {
                        FillRegionColor(dr["town_no"].ToString(),
                                        Color.FromArgb(int.Parse(dr["data_content"].ToString(), System.Globalization.NumberStyles.HexNumber)));
                    }
                }
                else
                {
                    foreach(string strTownNo in _dicTownColor.Keys)
                        FillRegionColor(strTownNo,
                                        _dicTownColor[strTownNo]);
                }


                if (DisplaySchool == true)
                {
                    DataTable dtSchool = new DataTable();
                    dtSchool = MCD.getSchoolArea(_strDataYear, DisplayCity).Tables[0];

                    foreach (DataRow dr in dtSchool.Rows)
                    {
                        if ((dr["school_x"].ToString().Trim() == "") ||
                            (dr["school_y"].ToString().Trim() == ""))
                            continue;
                        AddBuilding(DisplayCity,
                                    dr["school_type"].ToString(),
                                    dr["school_name"].ToString(),
                                    double.Parse(dr["school_x"].ToString()),
                                    double.Parse(dr["school_y"].ToString()));
                    }
                }


                if (DisplayHOSPITAL == true)
                {
                    DataTable dtHOSPITAL = new DataTable();
                    dtHOSPITAL = MCD.getHOSPITALArea(_strDataYear, DisplayCity).Tables[0];

                    foreach (DataRow dr in dtHOSPITAL.Rows)
                    {
                        if ((dr["hospital_x"].ToString().Trim() == "") ||
                            (dr["hospital_y"].ToString().Trim() == ""))
                            continue;
                        AddBuilding(DisplayCity,
                                    "02",
                                    dr["hospital_name"].ToString(),
                                    double.Parse(dr["hospital_x"].ToString()),
                                    double.Parse(dr["hospital_y"].ToString()));
                    }
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message + "," + ex.StackTrace);
                throw ex;
            }
        }

        private void DrawMark(Bitmap bitmap, string strType, int iX, int iY)
        {
            switch (strType)
            {
                case PRIMARY_SCHOOL_TYPE:
                    try
                    {
                        for (int i = -MARK_SIZE; i <= MARK_SIZE; i++)
                        {
                            if (((iX + i) >= 0) && ((iX + i) < bitmap.Width) &&
                                ((iY + i) >= 0) && ((iY + i) < bitmap.Height))
                                bitmap.SetPixel(iX + i, iY + i, PRIMARY_SCHOOL_COLOR);

                            if (((iX + i) >= 0) && ((iX + i) < bitmap.Width) &&
                                ((iY - i) >= 0) && ((iY - i) < bitmap.Height))
                                bitmap.SetPixel(iX + i, iY - i, PRIMARY_SCHOOL_COLOR);
                        }
                    }
                    catch { }
                    break;
                case JUNIOR_HIGH_SCHOOL_TYPE:
                    try
                    {
                        for (int i = -MARK_SIZE; i <= MARK_SIZE; i++)
                            for (int j = -MARK_SIZE; j <= MARK_SIZE; j++)
                            {
                                if (((iX + i) < 0) || ((iX + i) >= bitmap.Width) ||
                                    ((iY + j) < 0) || ((iY + j) >= bitmap.Height))
                                    continue;
                                bitmap.SetPixel(iX + i, iY + j, JUNIOR_HIGH_SCHOOL_COLOR);
                            }
                    }
                    catch { }

                    break;
                case HOSPITAL_TYPE:

                    try
                    {
                        for (int i = -MARK_SIZE; i <= MARK_SIZE; i++)
                        {
                            if (((iX + i) < 0) || ((iX + i) >= bitmap.Width) ||
                                ((iY) < 0) || ((iY) >= bitmap.Height))
                                continue;
                            bitmap.SetPixel(iX + i, iY, HOSPITAL_COLOR);
                        }
                        for (int i = -MARK_SIZE; i <= MARK_SIZE; i++)
                        {
                            if (((iX) < 0) || ((iX) >= bitmap.Width) ||
                                ((iY + i) < 0) || ((iY + i) >= bitmap.Height))
                                continue;
                            bitmap.SetPixel(iX, iY + i, HOSPITAL_COLOR);
                        }
                    }
                    catch { }
                    break;
            }
        }

        private void DisplayBuilding(Bitmap bitmap)
        {
            try
            {
                if (bitmap == null)
                    return;

                Dictionary<string, List<Building>> dicBuilding;
                List<Building> lstBuilding;
                int iX;
                int iY;
                City city = _dicCity[DisplayCity];
                double dWidth = (city.CityEast - city.CityWest);
                double dHeight = (city.CityNorth - city.CitySouth);

                if (_dicBuilding.ContainsKey(DisplayCity) == false)
                    return;

                dicBuilding = _dicBuilding[DisplayCity];

                foreach (string strType in dicBuilding.Keys)
                {
                    if (strType == "")
                        continue;

                    if (_lstDisplayBuildingType.IndexOf(strType) < 0)
                        continue;

                    lstBuilding = dicBuilding[strType];

                    foreach (Building building in lstBuilding)
                    {

                        iX = (int)((building.Position[0] - city.CityWest) / dWidth * bitmap.Width);
                        iY = (int)((city.CityNorth - building.Position[1]) / dHeight * bitmap.Height);

                        if ((iX >= bitmap.Width) || (iX < 0) || (iY >= bitmap.Height) || (iY < 0))
                            continue;
                        
                        DrawMark(bitmap, strType, iX, iY);
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message + "," + ex.StackTrace);
                throw ex;
            }
        }

        private void FillColor(Bitmap bitmap, List<Point> lstPoint, Color cFill)
        {
            //foreach (Point point in lstPoint)
            //{
            //    if (point.X < 0 || point.Y < 0 || point.X >= bitmap.Width || point.Y >= bitmap.Height)
            //        continue;

            //    bitmap.SetPixel(point.X, point.Y, cFill);
            //}
            foreach (Point point in lstPoint)
            {
                if (point.X < 0 || point.Y < 0 || point.X >= bitmap.Width || point.Y >= bitmap.Height)
                    continue;

                if (bitmap.GetPixel(point.X, point.Y).ToArgb() == EMPTY_RGB)
                    bitmap.SetPixel(point.X, point.Y, cFill);
            }
        }

        private void FillColor(int iX, int iY, Color cFill)
        {
            List<Point> lstSourcePoint = new List<Point>();
            List<Point> lstProcessedPoint = new List<Point>();
            Bitmap bitmap = (Bitmap)picMap.Image;
            Point pCurrent;
            Point pDetect;
            //string strValue;
            int iFillColor = cFill.ToArgb();

            if (cFill.ToArgb() == EMPTY_RGB)
                return;

            lstSourcePoint.Add(new Point(iX, iY));            

            while (lstSourcePoint.Count > 0)
            {
                pCurrent = lstSourcePoint[0];
                lstSourcePoint.RemoveAt(0);
                lstProcessedPoint.Add(pCurrent);

                //if ((pCurrent.X >= 0) && (pCurrent.Y >= 0) && (pCurrent.X < bitmap.Width) && (pCurrent.Y < bitmap.Height))
                //    bitmap.SetPixel(pCurrent.X, pCurrent.Y, cFill);

                //pDetect = new Point(pCurrent.X - 1, pCurrent.Y);
                //if((pDetect.X >= 0) && (pDetect.Y >=0) && (pDetect.X < bitmap.Width) && (pDetect.Y < bitmap.Height))
                //    if ((bitmap.GetPixel(pDetect.X, pDetect.Y).ToArgb() == EMPTY_RGB) &&
                //        (lstSourcePoint.Contains(pDetect) == false) && 
                //        (lstProcessedPoint.Contains(pDetect) == false))
                //        lstSourcePoint.Add(pDetect);

                //pDetect = new Point(pCurrent.X + 1, pCurrent.Y);
                //if ((pDetect.X >= 0) && (pDetect.Y >= 0) && (pDetect.X < bitmap.Width) && (pDetect.Y < bitmap.Height))
                //    if ((bitmap.GetPixel(pDetect.X, pDetect.Y).ToArgb() == EMPTY_RGB) &&
                //        (lstSourcePoint.Contains(pDetect) == false) &&
                //        (lstProcessedPoint.Contains(pDetect) == false))
                //        lstSourcePoint.Add(pDetect);

                //pDetect = new Point(pCurrent.X, pCurrent.Y - 1);
                //if ((pDetect.X >= 0) && (pDetect.Y >= 0) && (pDetect.X < bitmap.Width) && (pDetect.Y < bitmap.Height))
                //    if ((bitmap.GetPixel(pDetect.X, pDetect.Y).ToArgb() == EMPTY_RGB) &&
                //        (lstSourcePoint.Contains(pDetect) == false) &&
                //        (lstProcessedPoint.Contains(pDetect) == false))
                //        lstSourcePoint.Add(pDetect);

                //pDetect = new Point(pCurrent.X, pCurrent.Y + 1);
                //if ((pDetect.X >= 0) && (pDetect.Y >= 0) && (pDetect.X < bitmap.Width) && (pDetect.Y < bitmap.Height))
                //    if ((bitmap.GetPixel(pDetect.X, pDetect.Y).ToArgb() == EMPTY_RGB) &&
                //        (lstSourcePoint.Contains(pDetect) == false) &&
                //        (lstProcessedPoint.Contains(pDetect) == false))
                //        lstSourcePoint.Add(pDetect);
                //2011.04.01 修改
                if ((pCurrent.X >= 0) && (pCurrent.Y >= 0) && (pCurrent.X < bitmap.Width) && (pCurrent.Y < bitmap.Height) && bitmap.GetPixel(pCurrent.X, pCurrent.Y).ToArgb() == EMPTY_RGB)

                    bitmap.SetPixel(pCurrent.X, pCurrent.Y, cFill);

                pDetect = new Point(pCurrent.X - 1, pCurrent.Y);
                //2011.05.01 修改
                if ((pDetect.X >= 0) && (pDetect.Y >= 0) && (pDetect.X < bitmap.Width) && (pDetect.Y < bitmap.Height))
                    if ((bitmap.GetPixel(pDetect.X, pDetect.Y).ToArgb() == EMPTY_RGB) &&
                        (lstSourcePoint.Contains(pDetect) == false) &&
                        (lstProcessedPoint.Contains(pDetect) == false))
                        lstSourcePoint.Add(pDetect);

                pDetect = new Point(pCurrent.X + 1, pCurrent.Y);
                //2011.05.01 修改
                if ((pDetect.X >= 0) && (pDetect.Y >= 0) && (pDetect.X < bitmap.Width) && (pDetect.Y < bitmap.Height))
                    if ((bitmap.GetPixel(pDetect.X, pDetect.Y).ToArgb() == EMPTY_RGB) &&
                        (lstSourcePoint.Contains(pDetect) == false) &&
                        (lstProcessedPoint.Contains(pDetect) == false))
                        lstSourcePoint.Add(pDetect);

                pDetect = new Point(pCurrent.X, pCurrent.Y - 1);
                //2011.05.01 修改
                if ((pDetect.X >= 0) && (pDetect.Y >= 0) && (pDetect.X < bitmap.Width) && (pDetect.Y < bitmap.Height))
                    if ((bitmap.GetPixel(pDetect.X, pDetect.Y).ToArgb() == EMPTY_RGB) &&
                        (lstSourcePoint.Contains(pDetect) == false) &&
                        (lstProcessedPoint.Contains(pDetect) == false))
                        lstSourcePoint.Add(pDetect);

                pDetect = new Point(pCurrent.X, pCurrent.Y + 1);
                //2011.05.01 修改
                if ((pDetect.X >= 0) && (pDetect.Y >= 0) && (pDetect.X < bitmap.Width) && (pDetect.Y < bitmap.Height))
                    if ((bitmap.GetPixel(pDetect.X, pDetect.Y).ToArgb() == EMPTY_RGB) &&
                        (lstSourcePoint.Contains(pDetect) == false) &&
                        (lstProcessedPoint.Contains(pDetect) == false))
                        lstSourcePoint.Add(pDetect);
            }

            picMap.Image = bitmap;
        }

        public void FillRegionColor(string strRegion, Color cFill)
        {
            try
            {
                if (DisplayCity == null)
                    return;
                
                if (_dicCity.ContainsKey(DisplayCity) == false)
                    return;

                if (_dicCity[DisplayCity].GetRegion().ContainsKey(strRegion) == false)
                    return;

                List<Point> lstReferencePoint = _dicCity[DisplayCity].GetRegion()[strRegion].GetReferencePoints();

                foreach(Point referencePoint in lstReferencePoint)
                {
                    FillColor(referencePoint.X, referencePoint.Y, cFill);
                }                
            }
            catch (Exception ex)
            {
                throw ex;
                //MessageBox.Show(ex.Message + "," + ex.StackTrace);
                 
                //ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "", "<script language=\"javascript\" type=\"text/javascript\">alert(\"資料匯入成功\");</script>", false);
                //string scriptA = String.Format("alert('{0}');", ex.Message + "," + ex.StackTrace);
                //string strAlert = "";
                //strAlert = "<script language=\"javascript\" type=\"text/javascript\">alert(\"" +  ex.Message + "," + ex.StackTrace + "\");</script>";

                //Page.ClientScript.RegisterStartupScript(typeof(Page), "", strAlert, false);
                                                        //(Me, Me.GetType(), "alert", scriptA, True)
                //ClientScript.RegisterStartupScript(typeof(Page), "", "<script language=\"javascript\" type=\"text/javascript\">alert(\"資料匯入失敗\");</script>", false);
            }
        }

        //private void Init()
        public void Init(string strDataYear)
        {
            try
            {                
                //IniReader iniReader = new IniReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("MapControl.cfg.map.ini"));
                //IniReader iniReader = new IniReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("MapControl.cfg." + strIni));  
                IniReader iniReader;
                if (int.Parse(strDataYear) < 100)
                {
                    iniReader = new IniReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("MapControl.cfg.map_old.ini"));
                }
                else
                {
                    iniReader = new IniReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("MapControl.cfg.map.ini"));
                }

                string[] strCities;
                string[] strCityNos;
                List<string> lstRegion;
                //Dictionary<string, Point[]> dicPoint;
                string[] strPoints;
                string[] strRegionPoints;
                string[] strCoordinate;
                string[] strCorner;
                City city;
                Region region;

                //_strDatabaseType = iniReader.GetParam("database", "DatabaseType");
                //_strHost = iniReader.GetParam("database", "Host");
                //_strDatabase = iniReader.GetParam("database", "Database");
                //_strUsername = iniReader.GetParam("database", "Username");
                //_strPassword = iniReader.GetParam("database", "Password");

                strCities = iniReader.GetParam("map", "city").Split(',');
                strCityNos = iniReader.GetParam("map", "area").Split(',');

                for(int i = 0; i < strCities.Length; i++)
                {
                    city = new City();
                    city.CityName = strCities[i];
                    city.CityNo = iniReader.GetParam(strCityNos[i], "cityno");

                    strCorner = iniReader.GetParam(strCityNos[i], "corner").Split(',');
                    city.CityEast = double.Parse(strCorner[0]);
                    city.CitySouth = double.Parse(strCorner[1]);
                    city.CityWest = double.Parse(strCorner[2]);
                    city.CityNorth = double.Parse(strCorner[3]);

                    lstRegion = new List<string>(iniReader.GetParam(strCityNos[i], "area").Split(','));
                    strPoints = iniReader.GetParam(strCityNos[i], "point").Split(';');

                    for (int j = 0; j < lstRegion.Count; j++)
                    {
                        region = new Region();
                        region.RegionName = lstRegion[j];

                        strRegionPoints = strPoints[j].Replace("(", "").Replace(")", "").Split('~');

                        for (int k = 0; k < strRegionPoints.Length; k++)
                        {
                            strCoordinate = strRegionPoints[k].Split(',');
                            region.AddReferencePoint(new Point(int.Parse(strCoordinate[0]), int.Parse(strCoordinate[1])));
                        }
                        city.AddRegion(region);
                    }                    

                    _dicCity.Add(city.CityNo, city);      
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message + "," + ex.StackTrace);
                throw ex;
            }
        }

        public string SaveASPImage()
        {
            return SaveImage("");
        }

        public string SaveASPImage(string strPrefix)
        {
            return SaveImage(ASPImagePath + @"\" + strPrefix + DisplayCity + ".PNG");
        }

        public string SaveReportImage()
        {
            return SaveReportImage("");
        }

        public string SaveReportImage(string strPrefix)
        {
            return SaveImage(ReportImagePath + @"\" + strPrefix + DisplayCity + ".PNG");
        }

        public string SaveImage(string strFilename)
        {
            try
            {
                picMap.Image.Save(strFilename);                
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message + "," + ex.StackTrace);
                throw ex;
            }
            return strFilename.Substring(strFilename.LastIndexOf("\\") + 1);
        }

        public void GetInterfacceSafyOptions(Int32 riid, out Int32 pdwSupportedOptions, out Int32 pdwEnabledOptions)
        {
            pdwSupportedOptions = 1;
            pdwEnabledOptions = 2;
        }
        public void SetInterfaceSafetyOptions(Int32 riid, Int32 dwOptionsSetMask, Int32 dwEnabledOptions)
        {

        }

    }
}
