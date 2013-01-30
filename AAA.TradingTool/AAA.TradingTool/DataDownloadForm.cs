using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AAA.TradeAPI.Polaris;
using AAA.Meta.Trade.Data;
using System.IO;
using AAA.Meta.Quote.Data;
using AAA.Base.Util;

namespace AAA.TradingTool
{    
    public partial class DataDownloadForm : Form
    {
        private PolarisBase _polarisBase;
        private KLineStructure _kLineStructure;
        private LoginStructure _loginStructure;
        private List<BarRecord> _lstBarRecord;

        public DataDownloadForm()
        {
            InitializeComponent();
            dtpStartTime.Value = DateTime.Now.AddDays(-3);
            InitPolarisBase();
        }

        private void InitPolarisBase()
        {
            AccountInfo accountInfo;

            _polarisBase = new PolarisBase();
            _polarisBase.IsAutoLogin = false;
            _loginStructure = new LoginStructure();
            _kLineStructure = new KLineStructure();
            _polarisBase.AddMessageStructure(_kLineStructure);
            _polarisBase.AddMessageStructure(_loginStructure);
            _polarisBase.OnMessage(new AAA.Meta.Trade.MessageEvent(OnMessageReceive));

            accountInfo = new AccountInfo();
            

            _polarisBase.InitProgram(accountInfo);
        }

        private void OnMessageReceive(Dictionary<string, object> dicReturn)
        {
            Dictionary<string, object> dicChildren;
            Dictionary<string, object> dicGrandChildren;
            int iBarCount;
            string strStartTime;
            string strEndTime;
            StreamWriter sw = null;
            string strLastTime = null;
            BarRecord barRecord;

            try
            {                

                if (!dicReturn.ContainsKey("name"))
                    return;

                if (dicReturn["name"].ToString() == _loginStructure.ClientName)
                {
                    btnDownload.Enabled = true;
                    return;
                }
                if (dicReturn["name"].ToString() == _kLineStructure.ClientName)
                {
                    if (dicReturn.ContainsKey("Children0") == false)
                        return;

                    dicChildren = (Dictionary<string, object>)dicReturn["Children0"];
                    iBarCount = int.Parse((string)dicChildren["DataCount"]);
                    strStartTime = (string)dicChildren["DateTime_First"];
                    strEndTime = (string)dicChildren["DateTime_Last"];

                    for (int i = 0; i < iBarCount; i++)
                    {
                        dicGrandChildren = (Dictionary<string, object>)dicChildren["GrandChildren" + i];
                        barRecord = new BarRecord();
                        barRecord.BarCompression = AAA.Meta.Quote.BarCompressionEnum.Min;
                        barRecord.CompressionInterval = 1;
                        barRecord.BarDateTime = DateTime.Parse(dicGrandChildren["DateTime"].ToString().Substring(0, dicGrandChildren["DateTime"].ToString().Length - 4));
                        barRecord["Open"] = (float)(long.Parse(dicGrandChildren["OpenPrice"].ToString()) / (float)1000.0);
                        barRecord["High"] = (float)(long.Parse(dicGrandChildren["HighPrice"].ToString()) / (float)1000.0);
                        barRecord["Low"] = (float)(long.Parse(dicGrandChildren["LowPrice"].ToString()) / (float)1000.0);
                        barRecord["Close"] = (float)(long.Parse(dicGrandChildren["ClosePrice"].ToString()) / (float)1000.0);
                        barRecord["Volume"] = (float)(long.Parse(dicGrandChildren["DealVol"].ToString()));
                        
                        _lstBarRecord.Insert(i, barRecord);                                           
                    }

                    if (_lstBarRecord.Count > 0)
                    {
                        if (_lstBarRecord[0].BarDateTime.CompareTo(dtpStartTime.Value) > 0)
                        {
                            QueryKLine(dtpStartTime.Value.ToString("yyyy/MM/dd") + " 00:00:00.000",
                                       _lstBarRecord[0].BarDateTime.ToString("yyyy/MM/dd HH:mm:ss") + ".000");
                        }
                        else
                        {
                            sw = new StreamWriter(txtFilename.Text, false, Encoding.Default);

                            for (int i = 0; i < _lstBarRecord.Count; i++)
                            {
                                sw.WriteLine(_lstBarRecord[i].BarDateTime.ToString("yyyy/MM/dd HH:mm:ss").Replace(" ", "\t") + "\t" +
                                             _lstBarRecord[i]["Open"].ToString("0") + "\t" +
                                             _lstBarRecord[i]["High"].ToString("0") + "\t" +
                                             _lstBarRecord[i]["Low"].ToString("0") + "\t" +
                                             _lstBarRecord[i]["Close"].ToString("0") + "\t" +
                                             _lstBarRecord[i]["Volume"].ToString("0"));
                            }

                            sw.Close();

                            IOHelper.ExecuteCommand(@"C:\Program Files\HyperTools\hstools.exe",
                                                    @"C:\Program Files\HyperTools", 
                                                    "TFHTX-TP");

                            MessageBox.Show("資料下載完成!!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
            finally
            {
                if (sw != null)
                    sw.Close();
            }
        }

        private void QueryKLine(string strStartTime, string strEndTime)
        {
            Dictionary<string, object> dicParent = new Dictionary<string, object>();
            Dictionary<string, string> dicChildren;

            dicParent.Add("KLineKind", "3");
            dicParent.Add("CustomValue", "1");
            dicParent.Add("SpecialFlag", "Y");
            dicParent.Add("Condition", "2");
            dicParent.Add("DataCount", "500");
            dicParent.Add("StartDateTime", strStartTime);
            dicParent.Add("EndDateTime", strEndTime);
            dicParent.Add("SeqNo", "0");
            dicParent.Add("Count", "1");

            dicChildren = new Dictionary<string, string>();
            dicChildren.Add("MarketNo", txtSymbolId.Text.Split(',')[0]);
            dicChildren.Add("StockCode", txtSymbolId.Text.Split(',')[1]);

            dicParent.Add("Children0", dicChildren);

            _polarisBase.MessageSend(_kLineStructure.ApiId, dicParent);
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {

            try
            {                
                _lstBarRecord = new List<BarRecord>();

                QueryKLine(dtpStartTime.Value.ToString("yyyy/MM/dd") + " 00:00:00.000",
                           dtpEndTime.Value.ToString("yyyy/MM/dd HH:mm:ss") + ".000");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                _polarisBase.Login();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }

        private void DataDownloadForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _polarisBase.Logout();
        }
    }
}
