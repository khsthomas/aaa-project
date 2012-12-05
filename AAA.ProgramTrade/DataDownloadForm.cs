using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using AAA.ProgramTrade.Quote;
using AAA.Base.Util.Reader;
using AAA.Meta.Quote.Data;
using AAA.Trade;
using AAA.TradeLanguage;
using AAA.Base.Util;

namespace AAA.ProgramTrade
{
    public partial class DataDownloadForm : Form
    {
        private PolarisHistoryQuote _historyQuote = new PolarisHistoryQuote();
        private string _strExportDirectory;
        private string _strDefaultSymbolList;

        public DataDownloadForm()
        {
            InitializeComponent();

            cboSymbolType.Items.Add("清單");
            cboSymbolType.Items.Add("選擇權");
            cboSymbolType.Items.Add("清單+選擇權");
            cboSymbolType.SelectedIndex = 0;
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            StreamReader sr = null;
            string strLine;
            try
            {
                if (ofdFile.ShowDialog() != DialogResult.OK)
                    return;

                sr = new StreamReader(ofdFile.FileName);

                while ((strLine = sr.ReadLine()) != null)                
                    chkSymbolList.Items.Add(strLine.Trim(), true);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
            finally
            {
                if(sr != null)
                    sr.Close();
            }
        }

        private void InitQuote(PolarisHistoryQuote historyQuote)
        {
            IniReader iniReader = null;
            Dictionary<string, object> dicParam = new Dictionary<string, object>();             

            try
            {
                iniReader = new IniReader(AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.PROGRAM_ROOT_PATH] +
                                          @"\cfg\system.ini");

                dicParam.Add("AccountType", iniReader.GetParam("Account", "AccountType"));
                dicParam.Add("AccountNo", iniReader.GetParam("Account", "AccountNo"));
                dicParam.Add("Password", iniReader.GetParam("Account", "Password"));

                _strExportDirectory = IOHelper.ConvertDirectory(AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.PROGRAM_ROOT_PATH].ToString(),
                                                                iniReader.GetParam("DataDownload", "ExportDirectory", AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.PROGRAM_ROOT_PATH] + @"\Export\"));
                _strDefaultSymbolList = IOHelper.ConvertDirectory(AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.PROGRAM_ROOT_PATH].ToString(),
                                                                  iniReader.GetParam("DataDownload", "DefaultSymbolList", ""));
                
                historyQuote.InitProgram(dicParam);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }            
        }


        private void DownloadData(string strSymbolId, DateTime dtStartTime, DateTime dtEndTime)
        {
            List<BarRecord> lstBarRecord;
            StreamWriter sw = null;
            string strLine;

            if (Directory.Exists(_strExportDirectory) == false)
                Directory.CreateDirectory(_strExportDirectory);


            lstBarRecord = _historyQuote.GetBarData(strSymbolId,
                                        dtStartTime,
                                        dtEndTime);

            try
            {
                sw = new StreamWriter(_strExportDirectory + "\\" + strSymbolId + ".csv", true, Encoding.Default);
                for (int j = 0; j < lstBarRecord.Count; j++)
                {
                    strLine = lstBarRecord[j].BarDateTime.ToString("yyyy/MM/dd HH:mm:ss") + "\t" +
                              lstBarRecord[j]["Open"].ToString() + "\t" +
                              lstBarRecord[j]["High"].ToString() + "\t" +
                              lstBarRecord[j]["Low"].ToString() + "\t" +
                              lstBarRecord[j]["Close"].ToString() + "\t" +
                              lstBarRecord[j]["Volume"].ToString();
                    sw.WriteLine(strLine);
                }
            }
            catch { }
            finally
            {
                if (sw != null)
                    sw.Close();
            }
        }

        private DateTime GetStartTime(string strSymbolId)
        {
            DateTime dtStartTime = dtpStartTime.Value;
            StreamReader sr = null;
            string strLine;

            try
            {
                if (File.Exists(_strExportDirectory + "\\" + strSymbolId + ".csv") == false)
                    return dtStartTime;


                sr = new StreamReader(_strExportDirectory + "\\" + strSymbolId + ".csv");


                while ((strLine = sr.ReadLine()) != null)
                    dtStartTime = DateTime.Parse(strLine.Split('\t')[0]);                                
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

            return dtStartTime;
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            string strSymbolId;
            string[] strSymbolType = cboSymbolType.Text.Split('+');                        
            InitQuote(_historyQuote);
            DateTime dtOptionTime;
            DateTime dtOptionEndDate;
            DateTime dtDownloadStartTime;
            List<string> lstOptionsMonth;
            
            btnDownload.Enabled = false;
            dtDownloadStartTime = dtpStartTime.Value;
            try
            {
                for (int iSymbolType = 0; iSymbolType < strSymbolType.Length; iSymbolType++)
                {
                    switch (strSymbolType[iSymbolType])
                    {
                        case "清單":
                            for (int i = 0; i < chkSymbolList.CheckedIndices.Count; i++)
                            {
                                strSymbolId = chkSymbolList.Items[chkSymbolList.CheckedIndices[i]].ToString();                                
                                
                                if(chkRedownload.Checked == false)
                                    dtDownloadStartTime = GetStartTime(strSymbolId);

                                DownloadData(strSymbolId, dtDownloadStartTime, dtpEndTime.Value);

                                lstMessage.Items.Add(strSymbolId + " - 下載完成");
                                Application.DoEvents();
                            }
                            break;
                        case "選擇權":
                            dtOptionTime = dtpEndTime.Value;
                            lstOptionsMonth = new List<string>();
                            
                            lstOptionsMonth.Add(dtpStartTime.Value.ToString("yyyyMM"));

                            if (dtpStartTime.Value.ToString("yyyyMM").CompareTo(dtpEndTime.Value.ToString("yyyyMM")) != 0)
                                lstOptionsMonth.Add(dtpEndTime.Value.ToString("yyyyMM"));

                            while (dtOptionTime.ToString("yyyyMM").CompareTo(lstOptionsMonth[0]) > 0)
                            {
                                dtOptionTime = dtOptionTime.AddMonths(-1);
                                if(lstOptionsMonth.IndexOf(dtOptionTime.ToString("yyyyMM")) < 0)
                                    lstOptionsMonth.Insert(1, dtOptionTime.ToString("yyyyMM"));
                            }

                            for (int i = 0; i < lstOptionsMonth.Count; i++)
                            {
                                dtOptionEndDate = SymbolUtil.SettleDate(int.Parse(lstOptionsMonth[i].Substring(0, 4)),
                                                                        int.Parse(lstOptionsMonth[i].Substring(4)));
                                for (int j = int.Parse(txtStrikePriceStart.Text); j <= int.Parse(txtStrikePriceEnd.Text); j = j + 100)
                                {
                                    strSymbolId = SymbolCodeHelper.QuerySymbolCode("選擇權", j.ToString(), "C", lstOptionsMonth[i].Substring(0, 4), lstOptionsMonth[i].Substring(4)) +
                                                  "_TAIFEX_Min_1";
                                    if (chkRedownload.Checked == false)
                                        dtDownloadStartTime = GetStartTime(strSymbolId);
                                    DownloadData(strSymbolId, dtDownloadStartTime, dtOptionEndDate.CompareTo(dtpEndTime.Value) < 0 ? dtOptionEndDate : dtpEndTime.Value);
                                    lstMessage.Items.Add(strSymbolId + " - 下載完成");
                                    strSymbolId = SymbolCodeHelper.QuerySymbolCode("選擇權", j.ToString(), "P", lstOptionsMonth[i].Substring(0, 4), lstOptionsMonth[i].Substring(4)) +
                                                  "_TAIFEX_Min_1";
                                    if (chkRedownload.Checked == false)
                                        dtDownloadStartTime = GetStartTime(strSymbolId);
                                    DownloadData(strSymbolId, dtDownloadStartTime, dtOptionEndDate.CompareTo(dtpEndTime.Value) < 0 ? dtOptionEndDate : dtpEndTime.Value);
                                    lstMessage.Items.Add(strSymbolId + " - 下載完成");
                                    Application.DoEvents();
                                }
                            }

                            break;
                    }
                }
                lstMessage.Items.Add("資料下載完成");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
            btnDownload.Enabled = true;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            InitQuote(_historyQuote);
        }

        private void DataDownloadForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                _historyQuote.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }
    }
}
