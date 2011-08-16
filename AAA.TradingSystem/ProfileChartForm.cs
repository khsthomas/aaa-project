using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AAA.Meta.Chart.Data;
using AAA.Meta.Quote.Data;
using System.IO;
using AAA.AGS.Client;
using AAA.DesignPattern.Observer;
using AAA.Meta.Quote;

namespace AAA.TradingSystem
{
    public partial class ProfileChartForm : Form
    {
        private const int QUERY_DAYS = 1;
        private const int UPDATE_TICKS = 10;
        private int _iTimePeriod = 30;
        private float _fPriceInterval = 5;
        private string _strLastDate;
        private SymbolBaseInfo _symInfo = new SymbolBaseInfo();
        private ProfileMgr _ProfileMgr;
        private float _fLastPrice;
        private MQClient _client;
        private Dictionary<string, string> _queryProperties = new Dictionary<string, string>();
        private bool _isProcess = false;
        private bool _FirstRun = true;
        private DateTime LastHistoryTime = DateTime.Now;
        private int iTickCount = 0;

        public ProfileChartForm()
        {
            InitializeComponent();
            Init();
        }
        
        private void Init()
        {
            try
            {
                txtEndDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
                txtStartDate.Text = DateTime.Now.AddDays(-10).ToString("yyyy/MM/dd");
                _client = new MQClient();
                _client.DataHandler += new DataHandler(OnDataReceive);
                _strLastDate = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void btnDemo_Click(object sender, EventArgs e)
        {
            _symInfo.Start = "08:45" + ":00";
            _symInfo.End = "13:44" + ":59";
            _symInfo.SymbolId = "TWFE_TFHTX";
            _ProfileMgr = new ProfileMgr(_symInfo);
            _ProfileMgr.PriceInterval = _fPriceInterval;
            _ProfileMgr.TimePeriod = _iTimePeriod * 60;
            QueryData_FromFile();
            pChartContainer1.AddProfileMgr(_ProfileMgr);
        }

        private Dictionary<string, AAA.Meta.Chart.Data.PriceVolumeData> GetPriceVolume_FromFile(string filePath)
        {
            Dictionary<string, AAA.Meta.Chart.Data.PriceVolumeData> dicPriceVolume = new Dictionary<string, AAA.Meta.Chart.Data.PriceVolumeData>();
            AAA.Meta.Chart.Data.PriceVolumeData priceVolume = new AAA.Meta.Chart.Data.PriceVolumeData();
            StreamReader file;
            string line;
            string strKey = "";
            if (File.Exists(filePath))
            {
                file = new StreamReader(filePath);
                try
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        string[] words = line.Split(';');
                        if (strKey != words[0])
                        {
                            strKey = words[0];
                            dicPriceVolume.Add(strKey, new AAA.Meta.Chart.Data.PriceVolumeData());
                            priceVolume = dicPriceVolume[strKey];
                        }
                        priceVolume.AddData(float.Parse(words[1]), float.Parse(words[2]), float.Parse(words[3]), DateTime.Parse(strKey));
                    }
                }
                catch (Exception ex)
                {
                }
                finally
                {
                    if (file != null)
                        file.Close();
                }
            }
            return dicPriceVolume;
        }

        private List<BarRecord> GetBarRecord_FromFile(string filePath)
        {
            List<BarRecord> lstBarRecord = new List<BarRecord>();
            StreamReader file;
            string line;
            if (File.Exists(filePath))
            {
                file = new StreamReader(filePath);
                try
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        string[] words = line.Split(';');
                        BarRecord barRecord = new BarRecord();
                        barRecord.BarDateTime = DateTime.Parse(words[0]);
                        barRecord.V0 = float.Parse(words[1]);
                        barRecord.V1 = float.Parse(words[2]);
                        barRecord.V2 = float.Parse(words[3]);
                        barRecord.V3 = float.Parse(words[4]);
                        barRecord.V4 = float.Parse(words[5]);
                        barRecord.V5 = float.Parse(words[6]);
                        lstBarRecord.Add(barRecord);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                finally
                {
                    if (file != null)
                        file.Close();
                }
            }
            return lstBarRecord;
        }

        private void QueryData_FromFile()
        {
            Dictionary<string, AAA.Meta.Chart.Data.PriceVolumeData> dicPriceVolume;
            AAA.Meta.Chart.Data.PriceVolumeData priceVolume;
            List<BarRecord> lstBarRecord;

            try
            {
                //AAA.Meta.Chart.Data.ProfileData profile = null;
                dicPriceVolume = GetPriceVolume_FromFile(Environment.CurrentDirectory + "\\data\\db_dumper_pv_20110515.txt");

                // Group PriceVolume into Profile
                foreach (string strTime in dicPriceVolume.Keys)
                {
                    priceVolume = dicPriceVolume[strTime];
                    for (int i = 0; i < priceVolume.Price.Count; i++)
                    {
                        _ProfileMgr.AddHistoryData(DateTime.Parse(strTime),
                                        priceVolume.Price[i],
                                        (int)priceVolume.Volume[i],
                                        (int)priceVolume.TickVolume[i]);
                    }

                }

                lstBarRecord = GetBarRecord_FromFile(Environment.CurrentDirectory + "\\data\\db_dumper_br_20110515.txt");

                _ProfileMgr.UpdateOpenClosePrice(lstBarRecord);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void OnDataReceive(QuoteData quoteData)
        {
            try
            {
               // Console.WriteLine("OnDataReceive:" + quoteData.LastUpdateTime.ToString() + "_" + quoteData.SymbolId.ToString());
                if (lblUpdateCnt.InvokeRequired)
                {
                    lblUpdateCnt.Invoke((MethodInvoker)delegate()
                    {
                        UpdateTickData(quoteData);
                    });
                }
                else
                {
                    UpdateTickData(quoteData);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "," + ex.StackTrace);
            }
        }

        private void UpdateTickData(QuoteData quoteData)
        {
            if (quoteData.SymbolId == txtSymbolId.Text) {
                if (DateTime.Parse(quoteData.LastUpdateTime) > LastHistoryTime)
                {
                    _ProfileMgr.AddData(DateTime.Parse(quoteData.LastUpdateTime),
                                                               float.Parse(quoteData.Items[5]),
                                                               int.Parse(quoteData.Items[2]));
                    iTickCount++;
                    if (iTickCount == UPDATE_TICKS)
                    {
                        pChartContainer1.AddProfileMgr(_ProfileMgr);
                        pChartContainer1.SetLastPos();
                        pChartContainer1.SetLastDayProfileVT();
                        iTickCount = 0;
                    }
                    //lblUpdateCnt.Text = quoteData.LastUpdateTime.ToString();
                }
                lblUpdateCnt.Text = quoteData.LastUpdateTime.ToString() + "(" + quoteData.Items[2] + ")";
            }
        }

        private void btnStartDB_Click(object sender, EventArgs e)
        {
            if (_isProcess)
                return;
            btnStartDB.Enabled = false;
            btnStopUpdate.Enabled = true;
            timer1.Enabled = false;
            _isProcess = true;
            _symInfo.Start = "08:45" + ":01";
            _symInfo.End = "13:45" + ":00";
            _symInfo.SymbolId = "TWFE_TFHTX";
            _ProfileMgr = new ProfileMgr(_symInfo);
            _ProfileMgr.PriceInterval = _fPriceInterval;
            _ProfileMgr.TimePeriod = _iTimePeriod * 60;
            QueryHistoryData();
            pChartContainer1.AddProfileMgr(_ProfileMgr);
            if ((_FirstRun) || (pChartContainer1.GetVTChartMode() == 0))
            {
                pChartContainer1.SetLastDayProfileVT();
                _FirstRun = false;
            }
            pChartContainer1.SetLastPos();
//            //btnStartDB.Enabled = true;
            lblUpdateCnt.Text = LastHistoryTime.ToString();
            _client.SetStartDateTime(LastHistoryTime);
            _client.StartService();
            _isProcess = false;
        }

        private void QueryHistoryData()
        {
            Dictionary<string, AAA.Meta.Chart.Data.PriceVolumeData> dicPriceVolume;
            AAA.Meta.Chart.Data.PriceVolumeData priceVolume;
            List<BarRecord> lstBarRecord;
            DateTime dtEndDate;
            DateTime dtStartDate;
            DateTime dtQueryEndDate;

            try
            {
                dtStartDate = DateTime.Parse(txtStartDate.Text);
                dtEndDate = DateTime.Parse(txtStartDate.Text);
                dtQueryEndDate = DateTime.Parse(txtEndDate.Text);
                while (dtStartDate <= dtQueryEndDate)
                {
                    if (_queryProperties.ContainsKey("SymbolId"))
                    {
                        _queryProperties["StartDateTime"] = dtStartDate.ToString("yyyy/MM/dd");
                        _queryProperties["EndDateTime"] = ((dtEndDate.AddDays(QUERY_DAYS) < dtQueryEndDate) ? dtEndDate.AddDays(QUERY_DAYS) : dtQueryEndDate).ToString("yyyy/MM/dd");
                    }
                    else
                    {
                        if (txtSymbolId.Text.Trim() == "")
                        {
                            txtSymbolId.Text = "TWFE_TFHTX";
                        }
                        _queryProperties.Add("SymbolId", txtSymbolId.Text.Trim());
                        _queryProperties.Add("StartDateTime", dtStartDate.ToString("yyyy/MM/dd"));
                        _queryProperties.Add("EndDateTime", ((dtEndDate.AddDays(QUERY_DAYS) < dtQueryEndDate) ? dtEndDate.AddDays(QUERY_DAYS) : dtQueryEndDate).ToString("yyyy/MM/dd"));
                    }
                    //if (_queryProperties["EndDateTime"] == DateTime.Now.ToString("yyyy/MM/dd")) {
                    //    _queryProperties["EndDateTime"] = DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd");
                    //}

                    dicPriceVolume = _client.GetPriceVolume(_queryProperties);
                    // Group PriceVolume into Profile
                    foreach (string strTime in dicPriceVolume.Keys)
                    {
                        priceVolume = dicPriceVolume[strTime];
                        for (int i = 0; i < priceVolume.Price.Count; i++)
                        {
                            _ProfileMgr.AddHistoryData(DateTime.Parse(strTime),
                                            priceVolume.Price[i],
                                            (int)priceVolume.Volume[i],
                                            (int)priceVolume.TickVolume[i]);
                        }

                    }

                    lstBarRecord = _client.GetData(_queryProperties);
                    _ProfileMgr.UpdateOpenClosePrice(lstBarRecord);
                    if (lstBarRecord.Count > 0) {
                        LastHistoryTime = lstBarRecord[lstBarRecord.Count - 1].BarDateTime;
                    }
                    _fLastPrice = _ProfileMgr.GetLastPrice();

                    dtStartDate = dtEndDate.AddDays(QUERY_DAYS + 1);
                    dtEndDate = dtStartDate.AddDays(QUERY_DAYS);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void ProfileChartForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _client.Unregister();
            _client.Disconnect();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btnStartDB_Click(sender, e);
            lblUpdateCnt.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss").ToString();
        }

        private void btnStopUpdate_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            btnStartDB.Enabled = true;
            btnStopUpdate.Enabled = false;
            lblUpdateCnt.Text = "Stop";
            _client.Disconnect();
        }
    }
}
