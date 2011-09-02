using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AAA.Base.Util.Reader;
using NDde.Client;
using System.Threading;
using System.IO;

namespace AAA.Trade.VolumeAnalyzer
{
    public partial class VolumeAnalyzerForm : Form
    {
        private const string CONFIG_FILE = "dde_ft.ini";
        private IniReader _iniReader;
        private DateTime _dtStartTime;
        private int _iDealBarLen;
        private DdeClient _ddeClient;
        private bool _isStartMonitor;
        private bool _isUpdateTime;
        private int _iPreviousVolume;
        private int _iDealBuyVolume;
        private int _iDealSellVolume;
        private int _iDealBuyVolume1;
        private int _iDealSellVolume1;
        private int _iAlarmVolume;
        private int _iMarkVolume1;
        private int _iMarkVolume2;
        private int _iSmallAlarmDiffVolume;
        private int _iBigAlarmDiffVolume;
        private int _iDetectInterval;
        private Thread _tMonitor;
        private SynchronizationContext _context;
        private bool _isSaved;
        private string _strAlarmType;

        public VolumeAnalyzerForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            try
            {
                _iniReader = new IniReader(Environment.CurrentDirectory + @"\" + CONFIG_FILE);

                _strAlarmType = _iniReader.GetParam("AlarmType");

                _dtStartTime = DateTime.Parse(DateTime.Now.ToString("yyyy/MM/dd ") + _iniReader.GetParam("StartTime"));
                _iDealBarLen = int.Parse(_iniReader.GetParam("DealInterval"));
                _iDetectInterval = int.Parse(_iniReader.GetParam("DetectInterval"));
                _iSmallAlarmDiffVolume = int.Parse(_iniReader.GetParam("SmallAlarmDiffVolume"));
                _iBigAlarmDiffVolume = int.Parse(_iniReader.GetParam("BigAlarmDiffVolume"));

                _ddeClient = new DdeClient(_iniReader.GetParam("Application"), _iniReader.GetParam("Topic"));
                _iPreviousVolume = 0;
                _iDealBuyVolume = 0;
                _iDealSellVolume = 0;
                _iDealBuyVolume1 = 0;
                _iDealSellVolume1 = 0;
                _isStartMonitor = false;
                _isUpdateTime = true;
                _isSaved = false;
                _iAlarmVolume = int.Parse(_iniReader.GetParam("AlarmVolume"));
                _iMarkVolume1 = int.Parse(_iniReader.GetParam("MarkVolume1"));
                _iMarkVolume2 = int.Parse(_iniReader.GetParam("MarkVolume2"));

                tblVolume.Columns.Add("DealTime", "成交時間");
                tblVolume.Columns.Add("OpenPrice", "開盤價");
                tblVolume.Columns.Add("HighPrice", "最高價"); 
                tblVolume.Columns.Add("LowPrice", "最低價");
                tblVolume.Columns.Add("ClosePrice", "收盤價");
                tblVolume.Columns.Add("DealBuyVolume", "成交買張");
                tblVolume.Columns.Add("DealSellVolume", "成交賣張");
                tblVolume.Columns.Add("DealVolume", "成交量");
                tblVolume.Columns.Add("DealDiff", "成交差異");
                tblVolume.Columns.Add("PriceDiff", "K棒實體");

                tblVolume1.Columns.Add("DealTime", "成交時間");
                tblVolume1.Columns.Add("OpenPrice", "開盤價");
                tblVolume1.Columns.Add("HighPrice", "最高價");
                tblVolume1.Columns.Add("LowPrice", "最低價");
                tblVolume1.Columns.Add("ClosePrice", "收盤價");
                tblVolume1.Columns.Add("DealBuyVolume", "成交買張");
                tblVolume1.Columns.Add("DealSellVolume", "成交賣張");
                tblVolume1.Columns.Add("DealVolume", "成交量");
                tblVolume1.Columns.Add("DealDiff", "成交差異");
                tblVolume1.Columns.Add("PriceDiff", "K棒實體");


                tblAbnormalVolume.Columns.Add("BuyPriceDiff", "K棒實體");
                tblAbnormalVolume.Columns.Add("DealBuyDiff", "成交差異");
                tblAbnormalVolume.Columns.Add("DealBuyPrice", "成交價");
                tblAbnormalVolume.Columns.Add("DealBuyVolume", "成交量");                
                tblAbnormalVolume.Columns.Add("DealTime", "成交時間");
                tblAbnormalVolume.Columns.Add("DealSellVolume", "成交量");                
                tblAbnormalVolume.Columns.Add("DealSellPrice", "成交價");                
                tblAbnormalVolume.Columns.Add("DealSelDiff", "成交差異");
                tblAbnormalVolume.Columns.Add("SellPriceDiff", "K棒實體");

                tblAbnormalVolume1.Columns.Add("BuyPriceDiff", "K棒實體");
                tblAbnormalVolume1.Columns.Add("DealBuyDiff", "成交差異");                
                tblAbnormalVolume1.Columns.Add("DealBuyPrice", "成交價");
                tblAbnormalVolume1.Columns.Add("DealBuyVolume", "成交量");
                tblAbnormalVolume1.Columns.Add("DealTime", "成交時間");                
                tblAbnormalVolume1.Columns.Add("DealSellVolume", "成交量");
                tblAbnormalVolume1.Columns.Add("DealSellPrice", "成交價");
                tblAbnormalVolume1.Columns.Add("DealSellDiff", "成交差異");
                tblAbnormalVolume1.Columns.Add("SellPriceDiff", "K棒實體");

                _context = SynchronizationContext.Current;

                if (_context == null)
                    _context = new SynchronizationContext();

                txtBigAlarmDiffVolume.Text = _iBigAlarmDiffVolume.ToString();
                txtSmallAlarmDiffVolume.Text = _iSmallAlarmDiffVolume.ToString();

                txtDate.Text = DateTime.Now.ToString("yyyyMMdd");
                LoadRecord(DateTime.Now.ToString("yyyyMMdd"));

                (new Thread(new ThreadStart(UpdateTime))).Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void MarkTable(DataGridView tblSource)
        {
            for (int i = 0; i < tblSource.Rows.Count; i++)
            {
                if (_strAlarmType == "Resp")
                {
                    if (int.Parse(tblSource.Rows[i].Cells["DealDiff"].Value.ToString()) >= _iBigAlarmDiffVolume)
                        tblSource.Rows[i].Cells["DealDiff"].Style.BackColor = Color.Red;
                    else if (int.Parse(tblSource.Rows[i].Cells["DealDiff"].Value.ToString()) <= -1 * _iBigAlarmDiffVolume)
                        tblSource.Rows[i].Cells["DealDiff"].Style.BackColor = Color.Green;
                    else if (int.Parse(tblSource.Rows[i].Cells["DealDiff"].Value.ToString()) >= _iSmallAlarmDiffVolume)
                        tblSource.Rows[i].Cells["DealDiff"].Style.BackColor = Color.LightPink;
                    else if (int.Parse(tblSource.Rows[i].Cells["DealDiff"].Value.ToString()) <= -1 * _iSmallAlarmDiffVolume)
                        tblSource.Rows[i].Cells["DealDiff"].Style.BackColor = Color.LightGreen;
                    else
                        tblSource.Rows[i].Cells["DealDiff"].Style.BackColor = Color.White;
                }
                else
                {
                    if (int.Parse(tblSource.Rows[i].Cells["DealDiff"].Value.ToString()) >= _iBigAlarmDiffVolume)
                        tblSource.Rows[i].Cells["DealDiff"].Style.BackColor = Color.Green;
                    else if (int.Parse(tblSource.Rows[i].Cells["DealDiff"].Value.ToString()) <= -1 * _iBigAlarmDiffVolume)
                        tblSource.Rows[i].Cells["DealDiff"].Style.BackColor = Color.Red;
                    else if (int.Parse(tblSource.Rows[i].Cells["DealDiff"].Value.ToString()) >= _iSmallAlarmDiffVolume)
                        tblSource.Rows[i].Cells["DealDiff"].Style.BackColor = Color.LightGreen;
                    else if (int.Parse(tblSource.Rows[i].Cells["DealDiff"].Value.ToString()) <= -1 * _iSmallAlarmDiffVolume)
                        tblSource.Rows[i].Cells["DealDiff"].Style.BackColor = Color.LightPink;
                    else
                        tblSource.Rows[i].Cells["DealDiff"].Style.BackColor = Color.White;
                }
            }
        }

        private void MarkAbnormalTable(DataGridView tblSource)
        {
            for (int i = 0; i < tblSource.Rows.Count; i++)
            {
                if (tblSource.Rows[i].Cells["BuyPriceDiff"].Value.ToString() != "")
                {
                    if (int.Parse(tblSource.Rows[i].Cells["DealBuyVolume"].Value.ToString()) >= _iMarkVolume2)
                        tblSource.Rows[i].Cells["DealBuyVolume"].Style.BackColor = Color.Red;
                    else if (int.Parse(tblSource.Rows[i].Cells["DealBuyVolume"].Value.ToString()) >= _iMarkVolume1)
                        tblSource.Rows[i].Cells["DealBuyVolume"].Style.BackColor = Color.Pink;
                    else
                        tblSource.Rows[i].Cells["DealBuyVolume"].Style.BackColor = Color.White;
                }
                else
                {
                    if (int.Parse(tblSource.Rows[i].Cells["DealSellVolume"].Value.ToString()) >= _iMarkVolume2)
                        tblSource.Rows[i].Cells["DealSellVolume"].Style.BackColor = Color.Green;
                    else if (int.Parse(tblSource.Rows[i].Cells["DealSellVolume"].Value.ToString()) >= _iMarkVolume1)
                        tblSource.Rows[i].Cells["DealSellVolume"].Style.BackColor = Color.LightGreen;
                    else
                        tblSource.Rows[i].Cells["DealSellVolume"].Style.BackColor = Color.White;
                }
            }
        }

        private void UpdateTable(object[] oArgs)
        {
            if (tblVolume.Rows.Count == 0)
                tblVolume.Rows.Add(oArgs);
            else
                tblVolume.Rows.Insert(0, oArgs);
            MarkTable(tblVolume);
/*
            for (int i = 0; i < tblVolume.Rows.Count; i++)
            {
                if (int.Parse(tblVolume.Rows[i].Cells["DealDiff"].Value.ToString()) >= _iBigAlarmDiffVolume)
                    tblVolume.Rows[i].Cells["DealDiff"].Style.BackColor = Color.Red;
                else if (int.Parse(tblVolume.Rows[i].Cells["DealDiff"].Value.ToString()) <= -1 * _iBigAlarmDiffVolume)
                    tblVolume.Rows[i].Cells["DealDiff"].Style.BackColor = Color.Green;
                else if (int.Parse(tblVolume.Rows[i].Cells["DealDiff"].Value.ToString()) >= _iSmallAlarmDiffVolume)
                    tblVolume.Rows[i].Cells["DealDiff"].Style.BackColor = Color.LightPink;
                else if (int.Parse(tblVolume.Rows[i].Cells["DealDiff"].Value.ToString()) <= -1 * _iSmallAlarmDiffVolume)
                    tblVolume.Rows[i].Cells["DealDiff"].Style.BackColor = Color.LightGreen;
                else
                    tblVolume.Rows[i].Cells["DealDiff"].Style.BackColor = Color.White;
            }
 */ 
        }

        private void UpdateTable1(object[] oArgs)
        {
            if (tblVolume1.Rows.Count == 0)
                tblVolume1.Rows.Add(oArgs);
            else
                tblVolume1.Rows.Insert(0, oArgs);
            MarkTable(tblVolume1);
/*
            for (int i = 0; i < tblVolume1.Rows.Count; i++)
            {
                if (int.Parse(tblVolume1.Rows[i].Cells["DealDiff"].Value.ToString()) >= _iBigAlarmDiffVolume)
                    tblVolume1.Rows[i].Cells["DealDiff"].Style.BackColor = Color.Red;
                else if (int.Parse(tblVolume1.Rows[i].Cells["DealDiff"].Value.ToString()) <= -1 * _iBigAlarmDiffVolume)
                    tblVolume1.Rows[i].Cells["DealDiff"].Style.BackColor = Color.Green;
                else if (int.Parse(tblVolume1.Rows[i].Cells["DealDiff"].Value.ToString()) >= _iSmallAlarmDiffVolume)
                    tblVolume1.Rows[i].Cells["DealDiff"].Style.BackColor = Color.LightPink;
                else if (int.Parse(tblVolume1.Rows[i].Cells["DealDiff"].Value.ToString()) <= -1 * _iSmallAlarmDiffVolume)
                    tblVolume1.Rows[i].Cells["DealDiff"].Style.BackColor = Color.LightGreen;
                else
                    tblVolume1.Rows[i].Cells["DealDiff"].Style.BackColor = Color.White;
            }
 */ 
        }

        private void UpdateAbnormalTable(object[] oArgs)
        {
            if (tblAbnormalVolume.Rows.Count == 0)
                tblAbnormalVolume.Rows.Add(oArgs);
            else
                tblAbnormalVolume.Rows.Insert(0, oArgs);

            MarkAbnormalTable(tblAbnormalVolume);
        }

        private void UpdateAbnormalTable1(object[] oArgs)
        {
            if (tblAbnormalVolume1.Rows.Count == 0)
                tblAbnormalVolume1.Rows.Add(oArgs);
            else
                tblAbnormalVolume1.Rows.Insert(0, oArgs);
            MarkAbnormalTable(tblAbnormalVolume1);
        }

        private void LoadRecord(string strDate)
        {
            StreamReader sr = null;
            string strLine;
            string[] strValues;

            try
            {

                if ((new FileInfo(Environment.CurrentDirectory + @"\Volume\Volume_" + strDate + ".csv")).Exists)
                {
                    sr = new StreamReader(Environment.CurrentDirectory + @"\Volume\Volume_" + strDate + ".csv");
                    sr.ReadLine();

                    while (tblVolume.Rows.Count > 0)
                        tblVolume.Rows.RemoveAt(0);
                    while ((strLine = sr.ReadLine()) != null)
                    {
                        strValues = strLine.Split(',');
                        tblVolume.Rows.Add(strValues);
                    }
                    sr.Close();
                    MarkTable(tblVolume);
                }

                if ((new FileInfo(Environment.CurrentDirectory + @"\Volume1\Volume1_" + strDate + ".csv")).Exists)
                {
                    sr = new StreamReader(Environment.CurrentDirectory + @"\Volume1\Volume1_" + strDate + ".csv");
                    sr.ReadLine();

                    while (tblVolume1.Rows.Count > 0)
                        tblVolume1.Rows.RemoveAt(0);

                    while ((strLine = sr.ReadLine()) != null)
                    {
                        strValues = strLine.Split(',');
                        tblVolume1.Rows.Add(strValues);
                    }
                    sr.Close();
                    MarkTable(tblVolume1);
                }

                if ((new FileInfo(Environment.CurrentDirectory + @"\AbnormalVolume\AbnormalVolume_" + strDate + ".csv")).Exists)
                {
                    sr = new StreamReader(Environment.CurrentDirectory + @"\AbnormalVolume\AbnormalVolume_" + strDate + ".csv");
                    sr.ReadLine();

                    while (tblAbnormalVolume.Rows.Count > 0)
                        tblAbnormalVolume.Rows.RemoveAt(0);

                    while ((strLine = sr.ReadLine()) != null)
                    {
                        strValues = strLine.Split(',');
                        tblAbnormalVolume.Rows.Add(strValues);
                    }
                    sr.Close();
                    MarkAbnormalTable(tblAbnormalVolume);
                }

                if ((new FileInfo(Environment.CurrentDirectory + @"\AbnormalVolume1\AbnormalVolume1_" + strDate + ".csv")).Exists)
                {
                    sr = new StreamReader(Environment.CurrentDirectory + @"\AbnormalVolume1\AbnormalVolume1_" + strDate + ".csv");
                    sr.ReadLine();

                    while (tblAbnormalVolume1.Rows.Count > 0)
                        tblAbnormalVolume1.Rows.RemoveAt(0);

                    while ((strLine = sr.ReadLine()) != null)
                    {
                        strValues = strLine.Split(',');
                        tblAbnormalVolume1.Rows.Add(strValues);
                    }
                    sr.Close();
                    MarkAbnormalTable(tblAbnormalVolume1);
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
        }

        private void SaveRecord(string strDate)
        {
            StreamWriter sw = null;
            
            try
            {
                if ((new DirectoryInfo(Environment.CurrentDirectory + @"\Volume")).Exists == false)
                    (new DirectoryInfo(Environment.CurrentDirectory + @"\Volume")).Create();

                if ((new DirectoryInfo(Environment.CurrentDirectory + @"\AbnormalVolume")).Exists == false)
                    (new DirectoryInfo(Environment.CurrentDirectory + @"\AbnormalVolume")).Create();

                if ((new DirectoryInfo(Environment.CurrentDirectory + @"\Volume1")).Exists == false)
                    (new DirectoryInfo(Environment.CurrentDirectory + @"\Volume1")).Create();

                if ((new DirectoryInfo(Environment.CurrentDirectory + @"\AbnormalVolume1")).Exists == false)
                    (new DirectoryInfo(Environment.CurrentDirectory + @"\AbnormalVolume1")).Create();

                sw = new StreamWriter(Environment.CurrentDirectory + @"\Volume\Volume_" + strDate + ".csv");

                for (int i = 0; i < tblVolume.Columns.Count; i++)
                    sw.Write(tblVolume.Columns[i].HeaderText + ",");
                sw.Write(Environment.NewLine);

                for (int i = 0; i < tblVolume.Rows.Count; i++)
                {
                    for (int j = 0; j < tblVolume.Columns.Count; j++)
                        sw.Write(tblVolume.Rows[i].Cells[j].Value.ToString() + ",");
                    sw.Write(Environment.NewLine);
                }
                sw.Close();


                sw = new StreamWriter(Environment.CurrentDirectory + @"\Volume1\Volume1_" + strDate + ".csv");

                for (int i = 0; i < tblVolume1.Columns.Count; i++)
                    sw.Write(tblVolume1.Columns[i].HeaderText + ",");
                sw.Write(Environment.NewLine);

                for (int i = 0; i < tblVolume1.Rows.Count; i++)
                {
                    for (int j = 0; j < tblVolume1.Columns.Count; j++)
                        sw.Write(tblVolume1.Rows[i].Cells[j].Value.ToString() + ",");
                    sw.Write(Environment.NewLine);
                }
                sw.Close();


                sw = new StreamWriter(Environment.CurrentDirectory + @"\AbnormalVolume\AbnormalVolume_" + strDate + ".csv");

                for (int i = 0; i < tblAbnormalVolume.Columns.Count; i++)
                    sw.Write(tblAbnormalVolume.Columns[i].HeaderText + ",");
                sw.Write(Environment.NewLine);

                for (int i = 0; i < tblAbnormalVolume.Rows.Count; i++)
                {
                    for (int j = 0; j < tblAbnormalVolume.Columns.Count; j++)
                        sw.Write(tblAbnormalVolume.Rows[i].Cells[j].Value.ToString() + ",");
                    sw.Write(Environment.NewLine);
                }
                sw.Close();

                sw = new StreamWriter(Environment.CurrentDirectory + @"\AbnormalVolume1\AbnormalVolume1_" + strDate + ".csv");

                for (int i = 0; i < tblAbnormalVolume1.Columns.Count; i++)
                    sw.Write(tblAbnormalVolume1.Columns[i].HeaderText + ",");
                sw.Write(Environment.NewLine);

                for (int i = 0; i < tblAbnormalVolume1.Rows.Count; i++)
                {
                    for (int j = 0; j < tblAbnormalVolume1.Columns.Count; j++)
                        sw.Write(tblAbnormalVolume1.Rows[i].Cells[j].Value.ToString() + ",");
                    sw.Write(Environment.NewLine);
                }
                sw.Close();


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

        private void UpdateValue(string[] strValues)
        {
            try
            {
                int iDiff;

                iDiff = int.Parse(strValues[2]) - int.Parse(strValues[3]);
                txtPrice.Text = strValues[0];
                txtVolume.Text = strValues[1];
                txtDBV.Text = strValues[2];
                txtDSV.Text = strValues[3];
                txtDealDiff.Text = iDiff.ToString();
                txtPriceDiff.Text = strValues[4];

                if (iDiff >= _iBigAlarmDiffVolume)
                    txtDealDiff.BackColor = Color.Red;
                else if (iDiff <= -1 * _iBigAlarmDiffVolume)
                    txtDealDiff.BackColor = Color.Green;
                else if (iDiff >= _iSmallAlarmDiffVolume)
                    txtDealDiff.BackColor = Color.LightPink;
                else if (iDiff <= -1 * _iSmallAlarmDiffVolume)
                    txtDealDiff.BackColor = Color.LightGreen;
                else
                    txtDealDiff.BackColor = txtPrice.BackColor;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void SetTime()
        {
            txtTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void UpdateTime()
        {
            try
            {
                while (_isUpdateTime)
                {
                    if (txtTime.InvokeRequired)
                    {
                        txtTime.Invoke((MethodInvoker)delegate()
                        {
                            SetTime();
                        });                   
                    }
                    else
                    {
                        SetTime();
                    }
                    Thread.Sleep(1000);
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void StartMonitor()
        {
            int iVolume;
            int iTickVolume;
            int iTotalVolume = 0;
            float fPrice;
            float fPreviousPrice = 0;
            float fOpen = float.NaN;
            float fHigh = -float.MaxValue;
            float fLow = float.MaxValue;
            float fBuyPrice1;
            float fSellPrice1;
            float fPreviousBuyPrice1 = float.NaN;
            float fPreviousSellPrice1 = float.NaN;
            TimeSpan timeSpan;
            TimeSpan timeSpanNow;
            object[] oItems;
            DateTime dtPreviousMinute = DateTime.Now;
            DateTime dtNow;

            while (_isStartMonitor)
            {
                try
                {
                    if (DateTime.Now <= _dtStartTime)
                    {
                        _iPreviousVolume = 0;
                        Thread.Sleep(1000);
                        continue;
                    }

                    if (DateTime.Now.ToString("HH:mm") == _iniReader.GetParam("SaveTime") && (_isSaved == false))
                    {
                        SaveRecord(DateTime.Now.ToString("yyyyMMdd"));
                        _isSaved = true;
                        _isStartMonitor = false;
                    }

                    iVolume = int.Parse(_ddeClient.Request(_iniReader.GetParam("Volume"), 6000));
                    if (iVolume <= _iPreviousVolume)
                    {
                        Thread.Sleep(_iDetectInterval);
                        continue;
                    }

                    iTickVolume = iVolume - _iPreviousVolume;
                    fPrice = float.Parse(_ddeClient.Request(_iniReader.GetParam("Price"), 6000));
                    fBuyPrice1 = float.Parse(_ddeClient.Request(_iniReader.GetParam("BuyPrice1"), 6000));
                    fSellPrice1 = float.Parse(_ddeClient.Request(_iniReader.GetParam("SellPrice1"), 6000));
                    iTotalVolume += iTickVolume;
                    dtNow = DateTime.Now;

                    if (float.IsNaN(fPreviousBuyPrice1))
                        fPreviousBuyPrice1 = fBuyPrice1;

                    if (float.IsNaN(fPreviousSellPrice1))
                        fPreviousSellPrice1 = fSellPrice1;

                    fOpen = float.IsNaN(fOpen) ? fPrice : fOpen;
                    fLow = Math.Min(fLow, fPrice);
                    fHigh = Math.Max(fHigh, fPrice);                    

                    if (fPrice >= fPreviousSellPrice1)
                        _iDealSellVolume += iTickVolume;

                    if (fPrice <= fPreviousBuyPrice1)
                        _iDealBuyVolume += iTickVolume;

                    if (fPrice >= fPreviousPrice)
                        _iDealBuyVolume1 += iTickVolume;

                    if (fPrice <= fPreviousPrice)
                        _iDealSellVolume1 += iTickVolume;

                    timeSpan = new TimeSpan(dtNow.Ticks - _dtStartTime.Ticks);
                    timeSpanNow = new TimeSpan(dtNow.Ticks - dtPreviousMinute.Ticks);

                    if (((((int)timeSpan.TotalSeconds) % _iDealBarLen == 0) || (((int)timeSpanNow.TotalSeconds > _iDealBarLen) && 
                        dtNow > _dtStartTime)) &&
                        dtNow.ToString("HH:mm") != dtPreviousMinute.ToString("HH:mm"))
                    {
                        oItems = new object[] { dtNow.ToString("HH:mm:ss"), 
                                                fOpen.ToString(), 
                                                fHigh.ToString(), 
                                                fLow.ToString(), 
                                                fPrice.ToString(), 
                                                _iDealBuyVolume.ToString(), 
                                                _iDealSellVolume.ToString(), 
                                                iTotalVolume.ToString(), 
                                                (_iDealBuyVolume - _iDealSellVolume).ToString(),
                                                (fPrice - fOpen).ToString()};
                        if (tblVolume.InvokeRequired)
                        {
                            tblVolume.Invoke((MethodInvoker)delegate()
                            {
                                UpdateTable(oItems);
                            });                   
                        }
                        else
                        {
                            UpdateTable(oItems);
                        }

                        oItems = new object[] { dtNow.ToString("HH:mm:ss"), 
                                                fOpen.ToString(), 
                                                fHigh.ToString(), 
                                                fLow.ToString(), 
                                                fPrice.ToString(), 
                                                _iDealBuyVolume1.ToString(), 
                                                _iDealSellVolume1.ToString(), 
                                                iTotalVolume.ToString(), 
                                                (_iDealBuyVolume1 - _iDealSellVolume1).ToString(),
                                                (fPrice - fOpen).ToString()};

                        if (tblVolume.InvokeRequired)
                        {
                            tblVolume.Invoke((MethodInvoker)delegate()
                            {
                                UpdateTable1(oItems);
                            });
                        }
                        else
                        {
                            UpdateTable1(oItems);
                        }

                        if (iTotalVolume >= _iAlarmVolume)
                        {
                            if (fPrice > fOpen)
                                oItems = new object[] {(fPrice - fOpen).ToString(),
                                                       (_iDealBuyVolume - _iDealSellVolume).ToString(),
                                                       fPrice.ToString(),
                                                       iTotalVolume.ToString(),
                                                       dtNow.ToString("HH:mm:ss"),
                                                       "",
                                                       "",
                                                       "",
                                                       ""};
                            else
                                oItems = new object[] {"",
                                                       "",
                                                       "",
                                                       "",
                                                       dtNow.ToString("HH:mm:ss"),
                                                       iTotalVolume.ToString(),
                                                       fPrice.ToString(),
                                                       (_iDealBuyVolume - _iDealSellVolume).ToString(),
                                                       (fPrice - fOpen).ToString()};

                            if (tblAbnormalVolume.InvokeRequired)
                            {
                                tblAbnormalVolume.Invoke((MethodInvoker)delegate()
                                {
                                    UpdateAbnormalTable(oItems);
                                });
                            }
                            else
                            {
                                UpdateAbnormalTable(oItems);
                            }


                            if (fPrice > fOpen)
                                oItems = new object[] {(fPrice - fOpen).ToString(),
                                                       (_iDealBuyVolume1 - _iDealSellVolume1).ToString(),
                                                        fPrice.ToString(),
                                                       iTotalVolume.ToString(),
                                                       dtNow.ToString("HH:mm:ss"),
                                                       "",
                                                       "",
                                                       "",
                                                       ""};
                            else
                                oItems = new object[] {"",
                                                       "",
                                                       "",
                                                       "",
                                                       dtNow.ToString("HH:mm:ss"),
                                                       iTotalVolume.ToString(),
                                                       fPrice.ToString(),
                                                       (_iDealBuyVolume1 - _iDealSellVolume1).ToString(),
                                                       (fPrice - fOpen).ToString()};

                            if (tblAbnormalVolume1.InvokeRequired)
                            {
                                tblAbnormalVolume1.Invoke((MethodInvoker)delegate()
                                {
                                    UpdateAbnormalTable1(oItems);
                                });
                            }
                            else
                            {
                                UpdateAbnormalTable1(oItems);
                            }

                        }
                        _iDealSellVolume = 0;
                        _iDealBuyVolume = 0;
                        _iDealBuyVolume1 = 0;
                        _iDealSellVolume1 = 0;
                        fOpen = fPrice;
                        fHigh = fPrice;
                        fLow = fPrice;
                        iTotalVolume = 0;
                        dtPreviousMinute = dtNow;                        
                    }                    

                    _iPreviousVolume = iVolume;
                    fPreviousPrice = fPrice;
                    fPreviousBuyPrice1 = fBuyPrice1;
                    fPreviousSellPrice1 = fSellPrice1;

                    _context.Post(new SendOrPostCallback(delegate {UpdateValue(new string[] {fPrice.ToString(),
                                                                                             _iPreviousVolume.ToString(),
                                                                                             _iDealBuyVolume.ToString(),
                                                                                             _iDealSellVolume.ToString(),
                                                                                             (fPrice - fOpen).ToString()
                                                                                            });
                                                                  }),
                                  null);

                }
                catch (Exception ex)
                {
//                    MessageBox.Show(ex.Message + "," + ex.StackTrace);
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                _ddeClient.Connect();                
                txtPrice.Text = _ddeClient.Request(_iniReader.GetParam("Price"), 6000);
                txtVolume.Text = _ddeClient.Request(_iniReader.GetParam("Volume"), 6000);
                _isStartMonitor = true;
                _isSaved = false;
                _tMonitor = new Thread(new ThreadStart(StartMonitor));
                _tMonitor.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void VolumeAnalyzerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                _isStartMonitor = false;
                _isUpdateTime = false;
                if(_ddeClient.IsConnected)
                    _ddeClient.Disconnect();

                if (MessageBox.Show("是否儲存資料", "Save Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    SaveRecord(txtDate.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                _isStartMonitor = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveRecord(txtDate.Text);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadRecord(txtDate.Text);
        }

        private void btnRemark_Click(object sender, EventArgs e)
        {
            _iSmallAlarmDiffVolume = int.Parse(txtSmallAlarmDiffVolume.Text);
            _iBigAlarmDiffVolume = int.Parse(txtBigAlarmDiffVolume.Text);

            MarkTable(tblVolume);
            MarkTable(tblVolume1);
            MarkAbnormalTable(tblAbnormalVolume);
            MarkAbnormalTable(tblAbnormalVolume1);
        }
    }
}
