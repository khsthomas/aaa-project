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

namespace AAA.TradingSystem
{
    public partial class ProfileChartForm : Form
    {
        private int _iTimePeriod = 30;
        private float _fPriceInterval = 5;
        private string _strLastDate;
        private SymbolBaseInfo _symInfo = new SymbolBaseInfo();
        private ProfileMgr _ProfileMgr;
        private float _fLastPrice;
        private Client _client;
        private Dictionary<string, string> _queryProperties = new Dictionary<string, string>();

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
                _client = new Client(); 
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

        private void tUpdate_Tick(object sender, EventArgs e)
        {
            lblUpdateCnt.Text = DateTime.Now.ToString("yyyy:MM:dd HH:mm:ss");
            _ProfileMgr = new ProfileMgr(_symInfo);
            _ProfileMgr.PriceInterval = _fPriceInterval;
            _ProfileMgr.TimePeriod = _iTimePeriod * 60;
            GetData();
        }

        private void btnStartDB_Click(object sender, EventArgs e)
        {
            _symInfo.Start = "08:45" + ":00";
            _symInfo.End = "13:44" + ":59";
            _symInfo.SymbolId = "TWFE_TFHTX";
            _ProfileMgr = new ProfileMgr(_symInfo);
            _ProfileMgr.PriceInterval = _fPriceInterval;
            _ProfileMgr.TimePeriod = _iTimePeriod * 60;
            QueryHistoryData();
            pChartContainer1.AddProfileMgr(_ProfileMgr);
            tUpdate.Enabled = true;
        }

        private void GetData() {
            QueryHistoryData();
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
                while (dtStartDate < dtQueryEndDate)
                {
                    if (_queryProperties.ContainsKey("SymbolId"))
                    {
                        _queryProperties["StartDateTime"] = dtStartDate.ToString("yyyy/MM/dd");
                        _queryProperties["EndDateTime"] = ((dtEndDate.AddDays(5) < dtQueryEndDate) ? dtEndDate.AddDays(5) : dtQueryEndDate).ToString("yyyy/MM/dd");
                    }
                    else
                    {
                        if (txtSymbolId.Text.Trim() == "")
                        {
                            txtSymbolId.Text = "TWFE_TFHTX";
                        }
                        _queryProperties.Add("SymbolId", txtSymbolId.Text.Trim());
                        _queryProperties.Add("StartDateTime", dtStartDate.ToString("yyyy/MM/dd"));
                        _queryProperties.Add("EndDateTime", ((dtEndDate.AddDays(5) < dtQueryEndDate) ? dtEndDate.AddDays(5) : dtQueryEndDate).ToString("yyyy/MM/dd"));
                    }


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

                    _fLastPrice = _ProfileMgr.GetLastPrice();

                    dtStartDate = dtEndDate.AddDays(6);
                    dtEndDate = dtStartDate.AddDays(5);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void ProfileChartForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            tUpdate.Enabled = false;
            _client.Disconnect();
        }
    }
}
