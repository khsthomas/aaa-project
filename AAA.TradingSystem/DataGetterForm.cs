using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AAA.Base.Util.Reader;
using AAA.Web;
using AAA.ResultSet;
using AAA.DataLoader;
using AAA.Database;
using System.Data.Common;
using AAA.TradingSystem.Indicator;

namespace AAA.TradingSystem
{
    public partial class DataGetterForm : Form
    {
        public DataGetterForm()
        {
            InitializeComponent();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {            
            IniReader iniReader = new IniReader(Environment.CurrentDirectory + @"\cfg\download.ini");
            IResultSet resultSet;
            HtmlPageDownloader pageDownloader = new HtmlPageDownloader();
            HtmlFileParser fileParser = new HtmlFileParser();
            string[] strUrls;
            string[] strFilenames;
            string[] strWebs;
            string[] strWebDescs;
            string strHost;
            string strDatabase;
            string strUsername;
            string strPassword;
            string strLoader;
            string strUrl;
            IDatabase database = null;
            IDatabase databaseUpdate = null;
            IDatabase calendarDatabase = null;
            ILoader loader;
            int iColumnCount;
            int iSkipRow;
            string strXPath;
            bool isParseTable = false;
            bool isGenerateResultSet = false;
            bool isHistricalData = false;
            DbDataReader dataReader;
            DateTime dtStartTime = DateTime.Now;
            DateTime dtNow;
            string strStartTime = "";
            string strParsedUrl = "";
            List<DateTime> lstDate;
            List<DateTime> lstParameter;
            string[] strFields;
            List<string> lstField;

            try
            {
                btnDownload.Enabled = false;
                lstMessage.Items.Clear();
                calendarDatabase = new AccessDatabase();
                strHost = iniReader.GetParam("Calendar", "Host");
                strDatabase = iniReader.GetParam("Calendar", "Database");
                strUsername = iniReader.GetParam("Calendar", "Username");
                strPassword = iniReader.GetParam("Calendar", "Password");
                calendarDatabase.Open(strDatabase.StartsWith(".") ? Environment.CurrentDirectory + strDatabase.Substring(1) : strDatabase,
                                      strUsername,
                                      strPassword);

                dataReader = calendarDatabase.ExecuteQuery(iniReader.GetParam("Calendar", "SQLStatement"));
                
                while(dataReader.Read())
                    strStartTime = dataReader[0].ToString();

                dtNow = DateTime.Now;
                dtStartTime = (strStartTime == "" ? dtNow.AddYears(-2) : DateTime.Parse(strStartTime));
                lstDate = new List<DateTime>();
                while(dtStartTime <= dtNow)
                {
                    lstDate.Add(new DateTime(dtStartTime.Ticks));
                    dtStartTime = dtStartTime.AddDays(1);
                }

                if (lstDate.Count == 0)
                    lstDate.Add(dtStartTime.AddDays(-2));

                strWebs = iniReader.GetParam("Web", "WebList").Split(',');
                strWebDescs = iniReader.GetParam("Web", "WebListDesc").Split(',');                

                pageDownloader.Path = Environment.CurrentDirectory;
                pageDownloader.FileType = FileTypeEnum.asc;

                for (int i = 0; i < strWebs.Length; i++)
                {
                    Application.DoEvents();
                    lstMessage.Items.Add("開始下載:" + strWebDescs[i]);
                    strUrls = iniReader.GetParam(strWebs[i], "URLList").Split(',');
                    strFilenames = iniReader.GetParam(strWebs[i], "Filename").Split(',');

                    iColumnCount = iniReader.GetParam(strWebs[i], "ColumnCount") == null ? -1 : int.Parse(iniReader.GetParam(strWebs[i], "ColumnCount"));
                    iSkipRow = iniReader.GetParam(strWebs[i], "SkipRow") == null ? 0 : int.Parse(iniReader.GetParam(strWebs[i], "SkipRow"));
                    strXPath = iniReader.GetParam(strWebs[i], "XPath");

                    strLoader = iniReader.GetParam(strWebs[i], "Loader");

                    strHost = iniReader.GetParam(strWebs[i], "Host");
                    strDatabase = iniReader.GetParam(strWebs[i], "Database");
                    strUsername = iniReader.GetParam(strWebs[i], "Username");
                    strPassword = iniReader.GetParam(strWebs[i], "Password");
                    
                    isParseTable = (iniReader.GetParam(strWebs[i], "ParseTable") == "true");
                    isGenerateResultSet = (iniReader.GetParam(strWebs[i], "GenerateResultSet") == "true");
                    isHistricalData = (iniReader.GetParam(strWebs[i], "HistoricalData") == "true");

                    if (iniReader.GetParam(strWebs[i], "FieldList") != null)
                    {
                        strFields = iniReader.GetParam(strWebs[i], "FieldList").Split(',');
                        for(int iField = 0; iField < strFields.Length; iField++)
                            fileParser.AddParseField(strFields[iField], iniReader.GetParam(strWebs[i], strFields[iField] + "XPath"));
                    }

                    lstParameter = new List<DateTime>();
                    if(isHistricalData)
                    {
                        foreach(DateTime dateTime in lstDate)
                            lstParameter.Add(dateTime);
                    }
                    else
                    {
                        lstParameter.Add(DateTime.Now);
                    }

                    database = new AccessDatabase();
                    database.Open(strDatabase.StartsWith(".") ? Environment.CurrentDirectory + strDatabase.Substring(1) : strDatabase,
                                  strUsername,
                                  strPassword);
                    databaseUpdate = new AccessDatabase();
                    databaseUpdate.Open(strDatabase.StartsWith(".") ? Environment.CurrentDirectory + strDatabase.Substring(1) : strDatabase,
                                        strUsername,
                                        strPassword);

                    loader = (ILoader)Activator.CreateInstance(Type.GetType(strLoader));
                    loader.Database = database;
                    for (int j = 0; j < strUrls.Length; j++)
                    {
                        strUrl = iniReader.GetParam(strWebs[i], strUrls[j]);

                        foreach(DateTime dateTime in lstParameter)
                        {
                            lstMessage.Items.Add("開始抓取" + dateTime.ToString("yyyy/MM/dd") + "資料");
                            lstMessage.Update();
                            strParsedUrl = strUrl;
                            while (strParsedUrl.IndexOf('{') > -1)
                                strParsedUrl = pageDownloader.ParseParameter(strParsedUrl, dateTime);
                            pageDownloader.DownloadPage(strParsedUrl, strFilenames[j]);
                            
                            if (isParseTable)
                            {
                                fileParser.ParseTable(Environment.CurrentDirectory + @"\" + strFilenames[j],
                                                      Environment.CurrentDirectory + @"\" + strFilenames[j].Replace("html", "csv"),
                                                      strXPath,
                                                      ",", iSkipRow, iColumnCount);
                            }
                            if (isGenerateResultSet)
                            {

                                resultSet = new TextResultSet(Environment.CurrentDirectory + @"\" + strFilenames[j].Replace("html", "csv"), false);
                                resultSet.IsDoEvents = true;
                                resultSet.Load();

                                lstField = fileParser.GetFieldList();
                                foreach(string strFieldName in lstField)
                                    resultSet.SetAttribute(strFieldName, fileParser.GetFieldValue(strFieldName));

                                if (isHistricalData)
                                    loader.AddLoaderParam("ExDate", dateTime.ToString("yyyy/MM/dd") + " 00:00:00");
                                loader.Load(resultSet);
                            }
                            else
                            {
                                loader.AddLoaderParam("File", Environment.CurrentDirectory + @"\" + strFilenames[j]);
                                loader.Load(null);
                            }
                            lstMessage.Items.Add(dateTime.ToString("yyyy/MM/dd") + "資料抓取完畢");
                            lstMessage.Update();
                        }
                    }                                       
                    database.Close();
                }


                strHost = iniReader.GetParam("Calculate", "Host");
                strDatabase = iniReader.GetParam("Calculate", "Database");
                strUsername = iniReader.GetParam("Calculate", "Username");
                strPassword = iniReader.GetParam("Calculate", "Password");

                strDatabase = strDatabase.StartsWith(".") ? Environment.CurrentDirectory + strDatabase.Substring(1) : strDatabase;
                lstMessage.Items.Add("開始更新技術指標");
                lstMessage.Update();
                CalculateIndicator calculateIndicator = new CalculateIndicator(strHost, strDatabase, strUsername, strPassword);
                calculateIndicator.Calculate();
                MessageBox.Show("資料下載成功!");
                btnDownload.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void btnRecalculateIndex_Click(object sender, EventArgs e)
        {
            string strHost;
            string strDatabase;
            string strUsername;
            string strPassword;
            IniReader iniReader = new IniReader(Environment.CurrentDirectory + @"\cfg\download.ini");
            IDatabase database = new AccessDatabase();
            string strSQL;
            try
            {
                btnRecalculateIndex.Enabled = false;
                strHost = iniReader.GetParam("Calculate", "Host");
                strDatabase = iniReader.GetParam("Calculate", "Database");
                strUsername = iniReader.GetParam("Calculate", "Username");
                strPassword = iniReader.GetParam("Calculate", "Password");

                strDatabase = strDatabase.StartsWith(".") ? Environment.CurrentDirectory + strDatabase.Substring(1) : strDatabase;

                database.Open(strDatabase, strUsername, strPassword);
                strSQL = "DELETE FROM TWSE_Stock_D_Index";
                database.ExecuteUpdate(strSQL);
                database.Commit();
                database.Close();

                lstMessage.Items.Add("開始重新計算技術指標");
                lstMessage.Update();
                CalculateIndicator calculateIndicator = new CalculateIndicator(strHost, strDatabase, strUsername, strPassword);
                calculateIndicator.Calculate();
                lstMessage.Items.Add("計算技術指標計算完畢");
                lstMessage.Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
            finally
            {                
                btnRecalculateIndex.Enabled = true;
            }
        }
    }
}
