using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AAA.Base.Util.Reader;
using AAA.ResultSet;
using AAA.Web;
using System.IO;
using AAA.Base.Util;
using AAA.WebPublisher;
using AAA.Base.Util.Reflection;
using System.Threading;
using AAA.BlogManager.Util;
using AAA.Meta.Quote.Data;
using AAA.Trade;
using AAA.Quote;

namespace AAA.BlogManager
{
    public partial class FinacialDataDownload : Form
    {
        private Dictionary<string, IResultSet> _dicResultSet;
        
        public FinacialDataDownload()
        {
            InitializeComponent();            
        }

        public void Download()
        {
            IniReader iniReader = new IniReader(Environment.CurrentDirectory + @"\cfg\download.ini");
            IResultSet resultSet;
            HtmlPageDownloader pageDownloader = new HtmlPageDownloader();
            HtmlFileParser fileParser = new HtmlFileParser();
            string[] strUrls;
            string[] strFilenames;
            string[] strWebs;
            string[] strWebDescs;
            string strLoader;
            string strUrl;            
            int iSkipRow;
            string strXPath;
            bool isParseTable = false;
            bool isGenerateResultSet = false;
            bool isHistricalData = false;
            DateTime dtStartTime = DateTime.Now;
            string strParsedUrl = "";
            List<DateTime> lstParameter;
            string[] strFields;
            List<string> lstField;
            string[] strColCounts;
            int[] iColCounts;
            int iDayOffset;

            string strTemplate;
            string strLine;
            StreamReader sr = null;
            StreamWriter sw = null;
            int iRowIndex;
            Encoding encoding;

            Dictionary<string, string> dicParam = new Dictionary<string, string>();

            try
            {
                strWebs = iniReader.GetParam("Web", "WebList").Split(',');
                strWebDescs = iniReader.GetParam("Web", "WebListDesc").Split(',');

                pageDownloader.Path = Environment.CurrentDirectory;
                pageDownloader.FileType = FileTypeEnum.asc;

                _dicResultSet = new Dictionary<string, IResultSet>();

                for (int i = 0; i < strWebs.Length; i++)
                {
                    Application.DoEvents();
                    lstMessage.Items.Add("開始下載:" + strWebDescs[i]);
                    strUrls = iniReader.GetParam(strWebs[i], "URLList").Split(',');
                    strFilenames = iniReader.GetParam(strWebs[i], "Filename").Split(',');

                    //iColumnCount = iniReader.GetParam(strWebs[i], "ColumnCount") == null ? -1 : int.Parse(iniReader.GetParam(strWebs[i], "ColumnCount"));
                    strColCounts = iniReader.GetParam(strWebs[i], "ColumnCount") == null ? new string[] { "-1" } : iniReader.GetParam(strWebs[i], "ColumnCount").Split(',');
                    iSkipRow = iniReader.GetParam(strWebs[i], "SkipRow") == null ? 0 : int.Parse(iniReader.GetParam(strWebs[i], "SkipRow"));
                    iDayOffset = iniReader.GetParam(strWebs[i], "DayOffset") == null ? 0 : int.Parse(iniReader.GetParam(strWebs[i], "DayOffset"));
                    strXPath = iniReader.GetParam(strWebs[i], "XPath");
                    encoding = iniReader.GetParam(strWebs[i], "Encoding") == null ? Encoding.Default : StringHelper.GetEncoding(iniReader.GetParam(strWebs[i], "Encoding"));
                    strLoader = iniReader.GetParam(strWebs[i], "Loader");

                    isParseTable = (iniReader.GetParam(strWebs[i], "ParseTable") == "true");
                    isGenerateResultSet = (iniReader.GetParam(strWebs[i], "GenerateResultSet") == "true");
                    isHistricalData = (iniReader.GetParam(strWebs[i], "HistoricalData") == "true");

                    if (iniReader.GetParam(strWebs[i], "FieldList") != null)
                    {
                        strFields = iniReader.GetParam(strWebs[i], "FieldList").Split(',');
                        for (int iField = 0; iField < strFields.Length; iField++)
                            fileParser.AddParseField(strFields[iField], iniReader.GetParam(strWebs[i], strFields[iField] + "XPath"));
                    }

                    lstParameter = new List<DateTime>();
                    lstParameter.Add(DateTime.Now.AddDays(iDayOffset));

                    iColCounts = new int[strColCounts.Length];
                    for (int j = 0; j < iColCounts.Length; j++)
                        iColCounts[j] = int.Parse(strColCounts[j]);

                    for (int j = 0; j < strUrls.Length; j++)
                    {
                        strUrl = iniReader.GetParam(strWebs[i], strUrls[j]);

                        foreach (DateTime dateTime in lstParameter)
                        {
                            lstMessage.Items.Add("開始抓取" + dateTime.ToString("yyyy/MM/dd") + "資料");
                            lstMessage.Update();
                            strParsedUrl = strUrl;
                            while (strParsedUrl.IndexOf('{') > -1)
                                strParsedUrl = pageDownloader.ParseParameter(strParsedUrl, dateTime);
                            pageDownloader.DownloadPage(strParsedUrl, strFilenames[j], encoding);

                            if (isParseTable)
                            {
                                fileParser.Encoding = encoding;
                                fileParser.ParseTable(Environment.CurrentDirectory + @"\" + strFilenames[j],
                                                      Environment.CurrentDirectory + @"\" + strFilenames[j].Replace("html", "csv"),
                                                      strXPath,
                                                      ",",
                                                      iSkipRow,
                                                      iColCounts,
                                                      HtmlFileParser.APPEND_COL_LEFT);
                            }
                            if (isGenerateResultSet)
                            {

                                resultSet = new TextResultSet(Environment.CurrentDirectory + @"\" + strFilenames[j].Replace("html", "csv"), false);
                                resultSet.IsDoEvents = true;
                                resultSet.Load();

                                lstField = fileParser.GetFieldList();
                                foreach (string strFieldName in lstField)
                                    resultSet.SetAttribute(strFieldName, fileParser.GetFieldValue(strFieldName));
                                _dicResultSet.Add(strWebs[i], resultSet);
                            }
                            lstMessage.Items.Add(dateTime.ToString("yyyy/MM/dd") + "資料抓取完畢");
                            lstMessage.Update();
                        }
                    }
                }

                dicParam.Add("Date", DateTime.Now.ToString("yyyy/MM/dd"));

                sr = new StreamReader(Environment.CurrentDirectory + @"\cfg\capital_template.txt", Encoding.Default);
                sw = new StreamWriter(Environment.CurrentDirectory + @"\capital" + DateTime.Now.ToString("yyyyMMdd") + ".txt", false, Encoding.Default);

                strTemplate = sr.ReadLine() + Environment.NewLine;
                while ((strLine = sr.ReadLine()) != null)
                {
                    strTemplate += strLine;// + Environment.NewLine;
                }

                foreach (string strDataName in _dicResultSet.Keys)
                {
                    resultSet = _dicResultSet[strDataName];
                    resultSet.Reset();
                    iRowIndex = 0;

                    while(resultSet.Read())
                    {
                        for (int iColIndex = 0; iColIndex < resultSet.ColumnCount; iColIndex++)
                        {
                            strTemplate = strTemplate.Replace("{" + strDataName + ":" + iRowIndex + ":" + iColIndex + "}", 
                                                              (NumericHelper.IsNumeric(resultSet.Cells(iColIndex).ToString().Trim()) == false  
                                                                ?   "-"
                                                                :   String.Format("{0:0,0}",double.Parse(resultSet.Cells(iColIndex).ToString().Trim()))));
                        }
                        iRowIndex++;
                    }
                }

                foreach (string strDataName in dicParam.Keys)
                {
                    strTemplate = strTemplate.Replace("{" + strDataName + "}",
                                                      dicParam[strDataName].ToString());
                }

                sw.WriteLine(strTemplate);

                lstMessage.Items.Add("資料整理完畢");
                lstMessage.Update();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (sr != null)
                    sr.Close();

                if (sw != null)
                    sw.Close();
            }
        }

        public void Publish()
        {
            IPublisher publisher;
            try
            {
                while (pnlBrowser.Controls.Count > 0)
                    pnlBrowser.Controls.RemoveAt(0);

                publisher = (IPublisher)Builder.CreateInstance<IPublisher>(Environment.CurrentDirectory + @"\publisher\AAA.WretchPublisher.dll", "AAA.WretchPublisher.WretchPublisher");

                pnlBrowser.Controls.Add(publisher.WebBrowser);

                publisher.WebBrowser.Visible = true;
                publisher.WebBrowser.Dock = DockStyle.Fill;
                publisher.WebBrowser.ScrollBarsEnabled = true;
                publisher.WebBrowser.ScriptErrorsSuppressed = false;

                publisher.Blogname = txtBlogname.Text;
                publisher.Username = txtAccount.Text;
                publisher.Password = txtPassword.Text;

                if(publisher.Login() == false)
                    MessageBox.Show(publisher.ErrorMessage);

                if (publisher.PostArticle(Environment.CurrentDirectory + @"\capital" + DateTime.Now.ToString("yyyyMMdd") + ".txt") == false)
                    MessageBox.Show(publisher.ErrorMessage);

                Thread.Sleep(3000);
                //publisher.Logout();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                Download();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void btnPublish_Click(object sender, EventArgs e)
        {
            try
            {
                Publish();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private DateTime ParseDateTime(string strDate, string strTime)
        {
            int iYear = int.Parse(strDate.Substring(0, 4));
            int iMonth = int.Parse(strDate.Substring(4, 2)); ;
            int iDay = int.Parse(strDate.Substring(6, 2)); ;
            int iHour = int.Parse(strTime.Substring(0, 2)); ;
            int iMinute = int.Parse(strTime.Substring(2, 2)); ;
            int iSecond = int.Parse(strTime.Substring(4, 2)); ;
            return new DateTime(iYear, iMonth, iDay, iHour, iMinute, iSecond);
        }

        private void WriteMinuteData(Dictionary<string, List<BarRecord>> dicMinute)
        {
            StreamWriter sw = null;
            try
            {
                if (Directory.Exists(Environment.CurrentDirectory + @"\Export\") == false)
                    Directory.CreateDirectory(Environment.CurrentDirectory + @"\Export\");

                
                foreach (string strSymbolId in dicMinute.Keys)
                {
                    sw = new StreamWriter(Environment.CurrentDirectory + @"\Export\" + strSymbolId + "_TAIFEX_Min_1.csv", true, Encoding.Default);

                    foreach (BarRecord barRecord in dicMinute[strSymbolId])
                    {
                        if (float.IsNaN(barRecord["Open"]))
                            continue;

                        sw.WriteLine(barRecord.BarDateTime.ToString("yyyy/MM/dd") + "\t" +
                                     barRecord.BarDateTime.ToString("HH:mm:ss") + "\t" +
                                     barRecord["Open"].ToString("0.00") + "\t" +
                                     barRecord["High"].ToString("0.00") + "\t" +
                                     barRecord["Low"].ToString("0.00") + "\t" +
                                     barRecord["Close"].ToString("0.00") + "\t" +
                                     barRecord["Volume"].ToString("0.00"));
                    }

                    sw.Close();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
            finally
            {
                if (sw != null)
                    sw.Close();
            }
        }

        private string ParseOptions(string strFilename)
        {
            try
            {
                OptionsUtil optionsUtil = new OptionsUtil();
                IResultSet resultSet;
                Dictionary<string, List<TickData>> dicTick;
                Dictionary<string, List<BarRecord>> dicMinute;
                TickData tickData;
                DateTime dtDealTime;

                resultSet = optionsUtil.ParseOptionsZip(strFilename);

                if (resultSet == null)
                {
                    return "無法解碼檔案";
                }
                if (resultSet.ErrorMessage != null)
                {
                    return resultSet.ErrorMessage;
                }

                dicTick = new Dictionary<string, List<TickData>>();
                resultSet.Reset();
                while (resultSet.Read())
                {
                    tickData = new TickData();
                    dtDealTime = ParseDateTime(resultSet.Cells("交易日期").ToString().Trim(),
                                               resultSet.Cells("成交時間").ToString().Trim());

                    tickData.SymbolId = resultSet.Cells("商品代號").ToString().Trim() +
                                        StringHelper.FillChar(resultSet.Cells("履約價格").ToString().Trim(), '0', 5, StringFillTypeEnum.Left) +
                                        SymbolCodeHelper.YearMonthToTradeCode(resultSet.Cells("買賣權別").ToString().Trim(),
                                                                              resultSet.Cells("交割年月").ToString().Trim().Substring(0, 4),
                                                                              resultSet.Cells("交割年月").ToString().Trim().Substring(4, 2));
                    tickData.Price = NumericHelper.ToFloat(resultSet.Cells("成交價格").ToString().Trim());
                    tickData.Volume = resultSet.Cells("成交數量(B or S)") == null
                                        ?   NumericHelper.ToFloat(resultSet.Cells("成交數量(B+S)").ToString().Trim())
                                        :   NumericHelper.ToFloat(resultSet.Cells("成交數量(B or S)").ToString().Trim());
                    tickData.Ticks = dtDealTime.Ticks;
                    tickData.Date = dtDealTime.ToString("yyyy/MM/dd");
                    tickData.Time = dtDealTime.ToString("HH:mm:ss");

                    if (dicTick.ContainsKey(tickData.SymbolId) == false)
                        dicTick.Add(tickData.SymbolId, new List<TickData>());
                    dicTick[tickData.SymbolId].Add(tickData);
                }
                resultSet.Close();

                DataSummary dataSummary = new DataSummary();
                dataSummary.SessionStartTime = "08:45:00";
                dataSummary.SessionEndTime = "13:45:00";

                dicMinute = new Dictionary<string, List<BarRecord>>();
                foreach (string strSymbolId in dicTick.Keys)
                {
                    dataSummary.SetTickData(dicTick[strSymbolId]);
                    dicMinute.Add(strSymbolId, dataSummary.ToMinuteData());
                }

                WriteMinuteData(dicMinute);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
            return "";
        }

        private void btnParse_Click(object sender, EventArgs e)
        {
            if (fbdFileRoot.ShowDialog() != DialogResult.OK)
                return;

            string[] strFiles = Directory.GetFiles(fbdFileRoot.SelectedPath);

            foreach (string strFile in strFiles)
                ParseOptions(strFile);
                //ParseOptions(@"D:\OptionsDaily_2012_09_18.zip");            
        }
    }
}
