using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AAA.Web;
using System.IO;
using AAA.Base.Util;
using System.Threading;
using AAA.Database;
using System.Data.Common;

namespace AAA.NHI.Downloader
{
    public partial class MainForm : Form
    {
        private const int MAX_RETRY_COUNT = 10;

        private const int HOMEPAGE = 0;
        private const int QUERY_RESULT = 1;
        private const int QUERY_FINISHED = 2;
        private const int DOWNLOAD_DETAIL = 3;

        private const string LIST_FILE = "HospitalList.txt";
        
        private readonly string[] FUNC_CODE = { "40", "41", "42", "43", "44", "45", "46"};
        private readonly string QUERY_HOME = "http://www.nhi.gov.tw/Query/query3.aspx?menu=20&menu_id=712&WD_ID=828";
        private int _iCurrentFunc;
        // Modify 2013.01.14 
        private readonly string[] ELEMENT_IDS = { "lblHospID", "lblHospName", "lblHospType", "lblTel", "lblAddress", "lblBranch", "lblSpecial", "lblService", "lblFunc", "lblCloseshop", "lblHolidayName"};
        private readonly string[] FIELDS = { "HospId", "HospName", "HospType", "Tel", "Address", "Branch", "Special", "Service", "Func", "CloseShop", "HolidayName"};
        // Add 2013.01.14
        private Dictionary<string, string> _dicCounty;
        private Dictionary<string, Dictionary<string, string>> _dicTown;
        private Dictionary<string, Dictionary<string, Dictionary<string, string>>> _dicRoad;
        private Dictionary<string, string> _dicTownToCounty;

        private List<string> _lstUrl;
        private int _iCurrentStep;

        private int _iTotalRetryCount;

        private string _strRawDataPath = Environment.CurrentDirectory + "\\" + "rawdata";
        private string _strOutputDataPath = Environment.CurrentDirectory + "\\" + "data";

        public MainForm()
        {

            InitializeComponent();

            wbNHI.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(wbNHI_DocumentCompleted);
            wbNHI.Navigated += new WebBrowserNavigatedEventHandler(wbNHI_Navigated);
            wbNHI.ScriptErrorsSuppressed = true;
            _iCurrentStep = HOMEPAGE;
            _iCurrentFunc = 0;
            _iTotalRetryCount = 0;
            IOHelper.CreateDirectory(_strRawDataPath);
            IOHelper.CreateDirectory(_strOutputDataPath);

            wbNHI.Url = new Uri(QUERY_HOME);


            StreamWriter sw = new StreamWriter(Environment.CurrentDirectory + "\\" + LIST_FILE, false, Encoding.Default);
            sw.Close();

//            LoadToDatabase();
        }

        void wbNHI_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            HtmlAction.MaskAlertWindow(wbNHI.Document);
        }

        private void MoveToNextFunc()
        {
            _iCurrentFunc++;
            if (_iCurrentFunc < FUNC_CODE.Length)
            {
                _iCurrentStep = HOMEPAGE;
                wbNHI.Url = new Uri(QUERY_HOME);
            }
            else
            {
                _iCurrentStep = QUERY_FINISHED;
                DownloadDetail(Environment.CurrentDirectory + "\\" + LIST_FILE);
            }

        }

        private void DownloadDetail(string strFilename)
        {
            StreamReader sr = null;
            HtmlPageDownloader downloader = new HtmlPageDownloader();            
            string strLine;
            _lstUrl = new List<string>();
            downloader.Path = _strRawDataPath;
            downloader.FileType = FileTypeEnum.asc;

            try
            {
                sr = new StreamReader(strFilename, Encoding.Default);

                while ((strLine = sr.ReadLine()) != null)
                {
                    _lstUrl.Add(strLine);
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
            finally
            {
                if (sr != null)
                    sr.Close();
            }

            string strUrl;
            if (_lstUrl.Count > 0)
            {
                strUrl = _lstUrl[0];
                _lstUrl.RemoveAt(0);
                _iCurrentStep = DOWNLOAD_DETAIL;
                wbNHI.Url = new Uri(strUrl);                
            }
        }

        private void ParseDetail(string strPath)
        {
            string[] strFiles = Directory.GetFiles(strPath, "*.html");
            HtmlFileParser fileParser = new HtmlFileParser();
            fileParser.Encoding = Encoding.ASCII;
            fileParser.ConvertEncoding = Encoding.GetEncoding("big5");

            for (int i = 0; i < strFiles.Length; i++)
            {
                fileParser.RootDocument = null;
                fileParser.SourceFile = strFiles[i];
                for (int j = 0; j < FIELDS.Length; j++)
                {
                    fileParser.AddParseFieldId(ELEMENT_IDS[j], FIELDS[j]);
                    fileParser.ParseElementById(ELEMENT_IDS[j]);
                }
            }
        }

        // Add 2013.01.14
        private int FindMax(int[] iSources)
        {
            int iMax = -int.MaxValue;

            for (int i = 0; i < iSources.Length; i++)
                iMax = iSources[i] > iMax ? iSources[i] : iMax;

            return iMax;
        }

        private string[] ParseAddr(string strAddr)
        {
            string[] strReturns = new string[4];
            string strCounty = null;
            string strTown = null;
            int iTownEndIndex;
            string strRoad = null;
            int iSearchStartIndex;
            int iRoadStartIndex;
            int iRoadEndIndex;

            // Process County
            strCounty = strAddr.Substring(0, 3).Replace("巿", "市");
            {
                if (_dicCounty.ContainsKey(strCounty) == false)
                {
                    if(!_dicTownToCounty.ContainsKey(strCounty))
                        return strReturns;
                    strReturns[0] = _dicTownToCounty[strCounty];
                    strTown = strCounty;
                    iSearchStartIndex = 0;
                }
                else
                {
                    strReturns[0] = _dicCounty[strCounty];
                    iSearchStartIndex = 3;
                }
            }

            if (strTown == null)
            {
                iTownEndIndex = FindMax(new int[] { strAddr.IndexOf("市", 3) + 1,
                                                strAddr.IndexOf("區", 3) + 1,
                                                strAddr.IndexOf("鄉", 3) + 1,
                                                strAddr.IndexOf("鎮", 3) + 1});
                strTown = strAddr.Substring(3, iTownEndIndex - 3);
            }
            if (!_dicTown.ContainsKey(strReturns[0]))
                return strReturns;

            if (!_dicTown[strReturns[0]].ContainsKey(strTown))
                return strReturns;

            strReturns[1] = _dicTown[strReturns[0]][strTown];

            iRoadStartIndex = FindMax(new int[] { strAddr.IndexOf("市", iSearchStartIndex) + 1,
                                                  strAddr.IndexOf("區", iSearchStartIndex) + 1,
                                                  strAddr.IndexOf("鄉", iSearchStartIndex) + 1,
                                                  strAddr.IndexOf("鎮", iSearchStartIndex) + 1,
                                                  strAddr.IndexOf("村", iSearchStartIndex) + 1,
                                                  strAddr.IndexOf("里", iSearchStartIndex) + 1});
            iRoadEndIndex = FindMax(new int[] { strAddr.IndexOf("段", iRoadStartIndex) + 1,
                                                strAddr.IndexOf("路", iRoadStartIndex) + 1,
                                                strAddr.IndexOf("街", iRoadStartIndex) + 1,
                                                strAddr.IndexOf("道", iRoadStartIndex) + 1});
            if (iRoadStartIndex < 0 || (iRoadEndIndex - iRoadStartIndex) <= 0)
            {
                strReturns[2] = "0";
            }
            else
            {

                strRoad = strAddr.Substring(iRoadStartIndex, (iRoadEndIndex - iRoadStartIndex));

                if (!_dicRoad.ContainsKey(strReturns[0]))
                    return strReturns;

                if (!_dicRoad[strReturns[0]].ContainsKey(strReturns[1]))
                    return strReturns;

                if (!_dicRoad[strReturns[0]][strReturns[1]].ContainsKey(strRoad))
                    return strReturns;

                strReturns[2] = _dicRoad[strReturns[0]][strReturns[1]][strRoad];
            }
            strReturns[3] = strAddr.Substring(Math.Max(iRoadStartIndex, iRoadEndIndex));
            return strReturns;

        }

        private void InitCounty(IDatabase database)
        {
            string strQueryCountySQL = "SELECT COUNTY_NO, COUNTY_NAME FROM TB_COUNTY_INFO WHERE COUNTY_VARSION = (SELECT MAX(COUNTY_VARSION) FROM TB_COUNTY_INFO)";
            _dicCounty = new Dictionary<string, string>();
            DbDataReader reader = null;

            try
            {
                reader = database.ExecuteQuery(strQueryCountySQL);

                while (reader.Read())
                {
                    if(_dicCounty.ContainsKey(reader["COUNTY_NAME"].ToString()))
                        _dicCounty[reader["COUNTY_NAME"].ToString()] = reader["COUNTY_NO"].ToString();
                    else
                        _dicCounty.Add(reader["COUNTY_NAME"].ToString(), reader["COUNTY_NO"].ToString());
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }

        private void InitTown(IDatabase database)
        {
            string strQueryTownSQL = "SELECT COUNTY_NO, TOWN_NO, TOWN_NAME FROM TB_TOWN_INFO " +
                                     " WHERE COUNTY_VARSION = (SELECT MAX(COUNTY_VARSION) FROM TB_TOWN_INFO) " +
                                     " ORDER BY COUNTY_NO";

            _dicTown = new Dictionary<string, Dictionary<string, string>>();
            _dicTownToCounty = new Dictionary<string, string>();
            DbDataReader reader = null;            

            try
            {
                reader = database.ExecuteQuery(strQueryTownSQL);

                while (reader.Read())
                {
                    if (!_dicTown.ContainsKey(reader["COUNTY_NO"].ToString()))
                        _dicTown.Add(reader["COUNTY_NO"].ToString(), new Dictionary<string, string>());

                    if (_dicTown[reader["COUNTY_NO"].ToString()].ContainsKey(reader["TOWN_NAME"].ToString()))
                        _dicTown[reader["COUNTY_NO"].ToString()][reader["TOWN_NAME"].ToString()] = reader["TOWN_NO"].ToString();
                    else
                        _dicTown[reader["COUNTY_NO"].ToString()].Add(reader["TOWN_NAME"].ToString(), reader["TOWN_NO"].ToString());

                    if (reader["TOWN_NAME"].ToString().IndexOf("市") > -1)
                    {
                        if(_dicTownToCounty.ContainsKey(reader["TOWN_NAME"].ToString()))
                            _dicTownToCounty[reader["TOWN_NAME"].ToString()] = reader["COUNTY_NO"].ToString();
                        else
                            _dicTownToCounty.Add(reader["TOWN_NAME"].ToString(), reader["COUNTY_NO"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }

        private void InitRoad(IDatabase database)
        {
            string strQueryRoadSQL = "SELECT COUNTY_NO, TOWN_NO, ROAD_NO, ROAD_NAME FROM TB_ROAD_INFO ORDER BY COUNTY_NO, TOWN_NO";

            _dicRoad = new Dictionary<string, Dictionary<string, Dictionary<string, string>>>();
            DbDataReader reader = null;

            try
            {
                reader = database.ExecuteQuery(strQueryRoadSQL);

                while (reader.Read())
                {
                    if (!_dicRoad.ContainsKey(reader["COUNTY_NO"].ToString()))
                        _dicRoad.Add(reader["COUNTY_NO"].ToString(), new Dictionary<string, Dictionary<string, string>>());

                    if (!_dicRoad[reader["COUNTY_NO"].ToString()].ContainsKey(reader["TOWN_NO"].ToString()))
                        _dicRoad[reader["COUNTY_NO"].ToString()].Add(reader["TOWN_NO"].ToString(), new Dictionary<string, string>());

                    if (_dicRoad[reader["COUNTY_NO"].ToString()][reader["TOWN_NO"].ToString()].ContainsKey(reader["ROAD_NAME"].ToString()))
                        _dicRoad[reader["COUNTY_NO"].ToString()][reader["TOWN_NO"].ToString()][reader["ROAD_NAME"].ToString()] = reader["ROAD_NO"].ToString();
                    else
                        _dicRoad[reader["COUNTY_NO"].ToString()][reader["TOWN_NO"].ToString()].Add(reader["ROAD_NAME"].ToString(), reader["ROAD_NO"].ToString());
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }

        private void LoadToDatabase()
        {
            IDatabase database = new MSSqlDatabase();
            StreamReader sr = null;
            Dictionary<string, string> dicArea = new Dictionary<string, string>();
            StreamWriter sw = null;
            try
            {
                dicArea.Add("台北業務組", "T");
                dicArea.Add("中區業務組", "C");
                dicArea.Add("東區業務組", "E");
                dicArea.Add("高屏業務組", "K");
                dicArea.Add("北區業務組", "N");
                dicArea.Add("南區業務組", "S");

                string[] strFiles = Directory.GetFiles(_strOutputDataPath, "*.txt");

                string[] strHospitalFields = { "HOSPITAL_SN", "HOSPITAL_NO", "HOSPITAL_NAME", "HOSPITAL_TYPE", "HOSPITAL_PHONE",                                                     
                                               "HOSPITAL_ADDR", "HOSPITAL_AREA", "HOSPITAL_CATEGORY", "HOSPITAL_SERVICES",
                                               "HOSPITAL_SUBJECT", "HOSPITAL_OUT_DATE", "HOSPITAL_VACATION", 
                                               "HOSPITAL_COUNTY", "HOSPITAL_TOWN", "HOSPITAL_ROAD", "CREATE_DATE", "CREATE_USER"};
                string[] strTimeFields = { "HOSPITAL_NO", "TYPE_WEEK", "TYPE_TIME", "CREATE_DATE", "CREATE_USER"};

                string strInsertHospitalSQL = "INSERT INTO TB_HOSPITAL_INFO(HOSPITAL_SN, HOSPITAL_NO, HOSPITAL_NAME, HOSPITAL_TYPE, HOSPITAL_PHONE, " +
                                              "                             HOSPITAL_COUNTY, HOSPITAL_TOWN, HOSPITAL_ROAD, " +
                                              "                             HOSPITAL_ADDR, HOSPITAL_AREA, HOSPITAL_CATEGORY, HOSPITAL_SERVICES, " +
                                              "                             HOSPITAL_SUBJECT, HOSPITAL_OUT_DATE, HOSPITAL_VACATION, CREATE_DATE, CREATE_USER)" +
                                              "                   VALUES(@HOSPITAL_SN, @HOSPITAL_NO, @HOSPITAL_NAME, @HOSPITAL_TYPE, @HOSPITAL_PHONE, " +
                                              "                          @HOSPITAL_COUNTY, @HOSPITAL_TOWN, @HOSPITAL_ROAD, " +
                                              "                          @HOSPITAL_ADDR, @HOSPITAL_AREA, @HOSPITAL_CATEGORY, @HOSPITAL_SERVICES, " +
                                              "                          @HOSPITAL_SUBJECT, @HOSPITAL_OUT_DATE, @HOSPITAL_VACATION, @CREATE_DATE, @CREATE_USER)";

                string strInsertTimeSQL = "INSERT INTO TB_TIME_INFO(HOSPITAL_NO, TYPE_WEEK, TYPE_TIME, CREATE_DATE, CREATE_USER)" +
                                          "                  VALUES(@HOSPITAL_NO, @TYPE_WEEK, @TYPE_TIME, @CREATE_DATE, @CREATE_USER)";                                              

                database.Open(System.Configuration.ConfigurationManager.ConnectionStrings["map-dev"].ToString());

                database.ExecuteUpdate("DELETE FROM TB_HOSPITAL_INFO");
                database.ExecuteUpdate("DELETE FROM TB_TIME_INFO");

                InitCounty(database);
                InitTown(database);
                InitRoad(database);

                string[] strHospitalValues = new string[strHospitalFields.Length];
                string[] strTimeValues = new string[strTimeFields.Length];

                string[] strTypeTimes = { "M", "A", "N" };
                string[] strTypeWeeks = { "SUN", "MON", "TUE", "WED", "THU", "FRI", "SAT" };
                string strLine;
                string strAddr = "";
                string[] strAddrCodes;
                int iAddrIndex = 0;

                sw = new StreamWriter(Environment.CurrentDirectory + @"\load_database_" + DateTime.Now.ToString("yyyyMMdd") + ".log", true, Encoding.Default);

                for (int i = 0; i < strFiles.Length; i++)
                {
                    sr = new StreamReader(strFiles[i]);
                    strHospitalValues[0] = i.ToString();
                    strHospitalValues[strHospitalValues.Length - 1] = "Program";
                    strHospitalValues[strHospitalValues.Length - 2] = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

                    for (int j = 1; j < strHospitalFields.Length - 5; j++)
                    {
                        strLine = sr.ReadLine();                       
                        strHospitalValues[j] = strLine == null ? "" : strLine.Trim();
                        if (strHospitalFields[j] == "HOSPITAL_AREA")
                            strHospitalValues[j] = dicArea.ContainsKey(strHospitalValues[j])
                                                    ? dicArea[strHospitalValues[j]]
                                                    : "A";
                        if (strHospitalFields[j] == "HOSPITAL_ADDR")
                        {
                            strAddr = strHospitalValues[j];
                            iAddrIndex = j;
                        }
                    }

                    if (strHospitalValues[1].Trim() == "")
                        continue;

                    strAddrCodes = ParseAddr(strAddr);

                    for (int j = 0; j < strAddrCodes.Length - 1; j++)
                    {
                        strHospitalValues[strHospitalValues.Length - 5 + j] = strAddrCodes[j] == null ? "" : strAddrCodes[j];
                    }
                    strHospitalValues[iAddrIndex] = strAddrCodes[strAddrCodes.Length - 1];

                    if (database.ExecuteUpdate(strInsertHospitalSQL, strHospitalFields, strHospitalValues) < 0)
                    {
                        sw.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "\t" + database.ErrorMessage + "\t" + strFiles[i]);
                    }

                    strTimeValues[0] = strHospitalValues[1];
                    strTimeValues[strTimeValues.Length - 1] = "Program";
                    strTimeValues[strTimeValues.Length - 2] = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

                    for (int j = 0; j < strTypeTimes.Length; j++)
                    {
                        strTimeValues[2] = strTypeTimes[j];

                        for (int k = 0; k < strTypeWeeks.Length; k++)
                        {
                            strTimeValues[1] = strTypeWeeks[k];
                            strLine = sr.ReadLine();

                            strLine = strLine == null ? "休診" : strLine.Trim();

                            if (strLine == "休診")
                                continue;

                            if (database.ExecuteUpdate(strInsertTimeSQL, strTimeFields, strTimeValues) < 0)
                            {
                                sw.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "\t" + database.ErrorMessage + "\t" + strFiles[i]);
                            }
                        }
                    }

                    sr.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
            finally
            {
                database.Close();
                if (sr != null)
                    sr.Close();
                if (sw != null)
                    sw.Close();
            }
            Application.Exit();
        }

        void wbNHI_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            StreamWriter sw = null;
            StreamWriter swDetail = null;
            try
            {
                HtmlDocument document = wbNHI.Document;
                List<string> lstHref;                

                if (wbNHI.ReadyState == WebBrowserReadyState.Complete)
                {
                    switch (_iCurrentStep)
                    {
                        case HOMEPAGE:
                            _iTotalRetryCount = 0;
                            foreach (HtmlElement formElement in document.Forms)
                                formElement.SetAttribute("target", "_self");
                            
                            HtmlElement submitButton = HtmlAction.FindHtmlElementById(document, "SUBMIT", "ctl00_ContentPlaceHolder1_btnSubmit", "");
                            if (submitButton == null)
                            {
                                wbNHI.Url = new Uri(QUERY_HOME);
                                break;
                            }
                            submitButton.SetAttribute("target", "_self");
                            HtmlAction.SetOptionValue(document, "ctl00_ContentPlaceHolder1_ddlFuncCode", FUNC_CODE[_iCurrentFunc]);
                            HtmlAction.FillTextFieldData(document, "ctl00_ContentPlaceHolder1_tbxPageNum", "99");
                            HtmlAction.Submit(document, "aspnetForm", "ctl00_ContentPlaceHolder1_btnSubmit");
                            _iCurrentStep = QUERY_RESULT;
                            break;
                        case QUERY_RESULT:
                            try
                            {
                                lstHref = HtmlAction.GetAllHref(document, "Query3_Detail.aspx?HospID");
                                if (lstHref.Count == 0)
                                {
                                    if ((_iTotalRetryCount++ < MAX_RETRY_COUNT) && (e.Url.ToString() == QUERY_HOME))
                                        _iCurrentFunc--;
                                    MoveToNextFunc();
                                    return;
                                }

                                sw = new StreamWriter(Environment.CurrentDirectory + "\\" + LIST_FILE, true, Encoding.Default);
                                foreach (string strHref in lstHref)
                                    sw.WriteLine(strHref);
                                sw.Close();

                                lstHref = HtmlAction.GetAllHref(document, "javascript:__doPostBack('lbtnNextPage','')");
                                if (lstHref.Count == 0)
                                {
                                    if ((_iTotalRetryCount++ < MAX_RETRY_COUNT) && (e.Url.ToString() == QUERY_HOME))
                                        _iCurrentFunc--;
                                    MoveToNextFunc();
                                    return;
                                }
                                else
                                    HtmlAction.HrefClick(document, "javascript:__doPostBack('lbtnNextPage','')");
                            }
                            catch (Exception ex)
                            {
                            }
                            finally
                            {
                                if (sw != null)
                                    sw.Close();
                            }
                            break;
                        case QUERY_FINISHED:
                            break;

                        case DOWNLOAD_DETAIL:
                            Dictionary<string, string> dicParam = new Dictionary<string, string>();
                            swDetail = null;
                            try
                            {
                                for (int i = 0; i < FIELDS.Length; i++)
                                    dicParam.Add(FIELDS[i], document.GetElementById(ELEMENT_IDS[i]).InnerText);
                                

                                swDetail = new StreamWriter(_strOutputDataPath + "\\" + dicParam["HospId"] + ".txt");

                                for (int i = 0; i < FIELDS.Length; i++)
                                    swDetail.WriteLine(dicParam[FIELDS[i]]);


                                HtmlElement tableElement = HtmlAction.FindElement(HtmlAction.FindTableCell(HtmlAction.FindTableRow(HtmlAction.FindElement(document.Body, "tbody"), 7), 1), "tbody");
                                HtmlElement rowElement;
                                HtmlElement cellElement;
                                for (int i = 1; i < 4; i++)
                                {
                                    rowElement = HtmlAction.FindTableRow(tableElement, i);

                                    for (int j = 1; j < 8; j++)
                                    {
                                        cellElement = HtmlAction.FindTableCell(rowElement, j);
                                        swDetail.WriteLine(cellElement.InnerText);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
                            }
                            finally
                            {
                                if (swDetail != null)
                                    swDetail.Close();
                            }
                            string strUrl;
                            if (_lstUrl.Count > 0)
                            {
                                strUrl = _lstUrl[0];
                                _lstUrl.RemoveAt(0);
                                wbNHI.Url = new Uri(strUrl);
                            }
                            else
                            {
                                LoadToDatabase();
                            }

                            break;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }
    }
}
