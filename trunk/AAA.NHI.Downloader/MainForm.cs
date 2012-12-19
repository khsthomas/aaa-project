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

namespace AAA.NHI.Downloader
{
    public partial class MainForm : Form
    {        
        private const int HOMEPAGE = 0;
        private const int QUERY_RESULT = 1;
        private const int QUERY_FINISHED = 2;
        private const int DOWNLOAD_DETAIL = 3;

        private const string LIST_FILE = "HospitalList.txt";
        
        private readonly string[] FUNC_CODE = { "40", "41", "42", "43", "44", "45", "46"};
        private readonly string QUERY_HOME = "http://www.nhi.gov.tw/Query/query3.aspx?menu=20&menu_id=712&WD_ID=828";
        private int _iCurrentFunc;

        private readonly string[] ELEMENT_IDS = { "lblHospID", "lblHospName", "lblHospType", "lblTel", "lblAddress", "lblBranch", "lblSpecial", "lblService", "lblFunc", "lblCloseshop", "lblOffPeriod"};
        private readonly string[] FIELDS = { "HospId", "HospName", "HospType", "Tel", "Address", "Branch", "Special", "Service", "Func", "CloseShop", "OffPeriod"};
        
        private List<string> _lstUrl;
        private int _iCurrentStep;

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

            IOHelper.CreateDirectory(_strRawDataPath);
            IOHelper.CreateDirectory(_strOutputDataPath);

            wbNHI.Url = new Uri(QUERY_HOME);
            
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

        private void LoadToDatabase()
        {
            IDatabase database = new MSSqlDatabase();
            StreamReader sr = null;
            try
            {

                string[] strFiles = Directory.GetFiles(_strOutputDataPath, "*.txt");
                string[] strHospitalFields = { "HOSPITAL_SN", "HOSPITAL_NO", "HOSPITAL_NAME", "HOSPITAL_TYPE", "HOSPITAL_PHONE",
                                               "HOSPITAL_ADDR", "HOSPITAL_BUSINESS", "HOSPITAL_CATEGORY", "HOSPITAL_SERVICES",
                                               "HOSPITAL_SUBJECT", "HOSPITAL_OUT_DATE", "HOSPITAL_VACATION", "CREATE_DATE", "CREATE_USER"};
                string[] strTimeFields = { "HOSPITAL_NO", "TYPE_WEEK", "TYPE_TIME", "CREATE_DATE", "CREATE_USER"};

                string strInsertHospitalSQL = "INSERT INTO TB_HOSPITAL_INFO(HOSPITAL_SN, HOSPITAL_NO, HOSPITAL_NAME, HOSPITAL_TYPE, HOSPITAL_PHONE, " +
                                              "                             HOSPITAL_ADDR, HOSPITAL_BUSINESS, HOSPITAL_CATEGORY, HOSPITAL_SERVICES, " +
                                              "                             HOSPITAL_SUBJECT, HOSPITAL_OUT_DATE, HOSPITAL_VACATION, CREATE_DATE, CREATE_USER)" +
                                              "                   VALUES(@HOSPITAL_SN, @HOSPITAL_NO, @HOSPITAL_NAME, @HOSPITAL_TYPE, @HOSPITAL_PHONE, " +
                                              "                          @HOSPITAL_ADDR, @HOSPITAL_BUSINESS, @HOSPITAL_CATEGORY, @HOSPITAL_SERVICES, " +
                                              "                          @HOSPITAL_SUBJECT, @HOSPITAL_OUT_DATE, @HOSPITAL_VACATION, @CREATE_DATE, @CREATE_USER)";

                string strInsertTimeSQL = "INSERT INTO TB_TIME_INFO(HOSPITAL_NO, TYPE_WEEK, TYPE_TIME, CREATE_DATE, CREATE_USER)" +
                                          "                  VALUES(@HOSPITAL_NO, @TYPE_WEEK, @TYPE_TIME, @CREATE_DATE, @CREATE_USER)";

                database.Open(System.Configuration.ConfigurationManager.ConnectionStrings["map-dev"].ToString());

                database.ExecuteUpdate("DELETE FROM TB_HOSPITAL_INFO");
                database.ExecuteUpdate("DELETE FROM TB_TIME_INFO");

                string[] strHospitalValues = new string[strHospitalFields.Length];
                string[] strTimeValues = new string[strTimeFields.Length];

                string[] strTypeTimes = { "M", "A", "N" };
                string[] strTypeWeeks = { "SUN", "MON", "TUE", "WED", "THU", "FRI", "SAT" };
                string strLine;

                for (int i = 0; i < strFiles.Length; i++)
                {
                    sr = new StreamReader(strFiles[i]);
                    strHospitalValues[0] = i.ToString();
                    strHospitalValues[strHospitalValues.Length - 1] = "Program";
                    strHospitalValues[strHospitalValues.Length - 2] = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

                    for (int j = 1; j < strHospitalFields.Length - 2; j++)
                    {
                        strLine = sr.ReadLine();                       
                        strHospitalValues[j] = strLine == null ? "" : strLine.Trim();
                    }

                    if (strHospitalValues[1].Trim() == "")
                        continue;

                    if(database.ExecuteUpdate(strInsertHospitalSQL, strHospitalFields, strHospitalValues) < 0)
                        MessageBox.Show(database.ErrorMessage);

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
                                MessageBox.Show(database.ErrorMessage);
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
                            foreach (HtmlElement formElement in document.Forms)
                                formElement.SetAttribute("target", "_self");

                            _iCurrentStep = QUERY_RESULT;
                            HtmlElement submitButton = HtmlAction.FindHtmlElementById(document, "SUBMIT", "ctl00_ContentPlaceHolder1_btnSubmit", "");
                            submitButton.SetAttribute("target", "_self");
                            HtmlAction.SetOptionValue(document, "ctl00_ContentPlaceHolder1_ddlFuncCode", FUNC_CODE[_iCurrentFunc]);
                            HtmlAction.Submit(document, "aspnetForm", "ctl00_ContentPlaceHolder1_btnSubmit");
                            break;
                        case QUERY_RESULT:
                            try
                            {
                                lstHref = HtmlAction.GetAllHref(document, "Query3_Detail.aspx?HospID");
                                if (lstHref.Count == 0)
                                {
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
