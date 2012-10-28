using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AAA.DataSource;
using AAA.Meta.Quote.Data;
using AAA.Forms.Components.Util;
using AAA.TradeLanguage;
using AAA.DesignPattern.Observer;
using AAA.Base.Util.Reader;
using AAA.Base.Util;
using System.IO;

namespace AAA.ProgramTrade
{
    public partial class DataMonitorForm : Form, IObserver
    {
        private const int PREVIOUS = -1;
        private const int NEXT = 1;

        public DataMonitorForm()
        {            
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Init();
            RefreshData();
            ((IDataSource)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.DATA_SOURCE]).Attach(this);
        }

        private void Init()
        {
            try
            {
                tblSymbolList.Columns.Add("SymbolId", "商品代碼");
                tblSymbolList.Columns.Add("StartTime", "資料開始時間");
                tblSymbolList.Columns.Add("EndTime", "資料結束時間");
                tblSymbolList.Columns.Add("CurrentTime", "目前時間");
                tblSymbolList.Columns.Add("OpenPrice", "開盤價");
                tblSymbolList.Columns.Add("HighPrice", "最高價");
                tblSymbolList.Columns.Add("LowPrice", "最低價");
                tblSymbolList.Columns.Add("ClosePrice", "收盤價");
                tblSymbolList.Columns.Add("Volume", "成交量");
                tblSymbolList.Columns.Add("Amount", "成交額");                

                tblDataDetail.Columns.Add("BarDataTime", "時間");
                tblDataDetail.Columns.Add("OpenPrice", "開盤價");
                tblDataDetail.Columns.Add("HighPrice", "最高價");
                tblDataDetail.Columns.Add("LowPrice", "最低價");
                tblDataDetail.Columns.Add("ClosePrice", "收盤價");
                tblDataDetail.Columns.Add("Volume", "成交量");
                tblDataDetail.Columns.Add("Amount", "成交額");                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void RefreshData()
        {
            IDataSource dataSource;
            List<BarData> lstBarData;
            CurrentTime currentTime;
            int iCurrentIndex;
            int iRowIndex = -1;
            IDataAccess dataAccess = new DefaultDataAccess();

            try
            {
                dataSource = (IDataSource)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.DATA_SOURCE];
                currentTime = (CurrentTime)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.CURRENT_TIME];
                if (currentTime == null)
                    return;
                dataAccess.CurrentTime = currentTime;
                dataAccess.DataSource = dataSource;

                foreach (string strSymbolId in dataSource.GetSymbolList())
                {
                    

                    iRowIndex = DataGridViewUtil.FindRowIndex(tblSymbolList, new string[] { "SymbolId" }, new object[] {strSymbolId });
                    if (iRowIndex < 0)
                    {
                        if (float.IsNaN(dataAccess.Open(strSymbolId, 0)))
                        {
                            DataGridViewUtil.InsertRow(tblSymbolList, new object[] {strSymbolId, 
                                                                                dataSource.DataStartTime(strSymbolId).ToString("yyyy/MM/dd HH:mm:ss"), 
                                                                                dataSource.DataEndTime(strSymbolId).ToString("yyyy/MM/dd HH:mm:ss"),
                                                                                dataAccess.Time(strSymbolId, 0).ToString("yyyy/MM/dd HH:mm:ss"),
                                                                                dataAccess.Bar(strSymbolId, 0)[0].ToString(),
                                                                                dataAccess.Bar(strSymbolId, 0)[1].ToString(),
                                                                                dataAccess.Bar(strSymbolId, 0)[2].ToString(),
                                                                                dataAccess.Bar(strSymbolId, 0)[3].ToString(),
                                                                                dataAccess.Bar(strSymbolId, 0)[4].ToString(),
                                                                                dataAccess.Bar(strSymbolId, 0)[5].ToString()});
                        }
                        else
                        {
                            DataGridViewUtil.InsertRow(tblSymbolList, new object[] {strSymbolId, 
                                                                                dataSource.DataStartTime(strSymbolId).ToString("yyyy/MM/dd HH:mm:ss"), 
                                                                                dataSource.DataEndTime(strSymbolId).ToString("yyyy/MM/dd HH:mm:ss"),
                                                                                dataAccess.Time(strSymbolId, 0).ToString("yyyy/MM/dd HH:mm:ss"),
                                                                                dataAccess.Open(strSymbolId, 0).ToString(),
                                                                                dataAccess.High(strSymbolId, 0).ToString(),
                                                                                dataAccess.Low(strSymbolId, 0).ToString(),
                                                                                dataAccess.Close(strSymbolId, 0).ToString(),
                                                                                dataAccess.Volume(strSymbolId, 0).ToString(),
                                                                                dataAccess.Amount(strSymbolId, 0).ToString()});
                        }
                    }
                    else
                    {
                        if (float.IsNaN(dataAccess.Open(strSymbolId, 0)))
                        {
                            DataGridViewUtil.UpdateRow(tblSymbolList, new string[] { "SymbolId" },
                                                                      new object[] {strSymbolId, 
                                                                                dataSource.DataStartTime(strSymbolId).ToString("yyyy/MM/dd HH:mm:ss"), 
                                                                                dataSource.DataEndTime(strSymbolId).ToString("yyyy/MM/dd HH:mm:ss"),
                                                                                dataAccess.Time(strSymbolId, 0).ToString("yyyy/MM/dd HH:mm:ss"),
                                                                                dataAccess.Bar(strSymbolId, 0)[0].ToString(),
                                                                                dataAccess.Bar(strSymbolId, 0)[1].ToString(),
                                                                                dataAccess.Bar(strSymbolId, 0)[2].ToString(),
                                                                                dataAccess.Bar(strSymbolId, 0)[3].ToString(),
                                                                                dataAccess.Bar(strSymbolId, 0)[4].ToString(),
                                                                                dataAccess.Bar(strSymbolId, 0)[5].ToString()});
                        }
                        else
                        {
                            DataGridViewUtil.UpdateRow(tblSymbolList, new string[] { "SymbolId" },
                                                                      new object[] {strSymbolId, 
                                                                                dataSource.DataStartTime(strSymbolId).ToString("yyyy/MM/dd HH:mm:ss"), 
                                                                                dataSource.DataEndTime(strSymbolId).ToString("yyyy/MM/dd HH:mm:ss"),
                                                                                dataAccess.Time(strSymbolId, 0).ToString("yyyy/MM/dd HH:mm:ss"),
                                                                                dataAccess.Open(strSymbolId, 0).ToString(),
                                                                                dataAccess.High(strSymbolId, 0).ToString(),
                                                                                dataAccess.Low(strSymbolId, 0).ToString(),
                                                                                dataAccess.Close(strSymbolId, 0).ToString(),
                                                                                dataAccess.Volume(strSymbolId, 0).ToString(),
                                                                                dataAccess.Amount(strSymbolId, 0).ToString()});
                        }
                    }

/*
                    lstBarData = dataSource.GetBar(strSymbolId);

                    iCurrentIndex = currentTime.GetDataIndex(strSymbolId);
                    if (iCurrentIndex == int.MinValue)
                        continue;

                    iRowIndex = DataGridViewUtil.FindRowIndex(tblSymbolList, new string[] { "SymbolId" }, new object[] {strSymbolId });
                    if(iRowIndex < 0)
                        DataGridViewUtil.InsertRow(tblSymbolList, new object[] {strSymbolId, 
                                                                                lstBarData[0].BarDateTime.ToString("yyyy/MM/dd HH:mm:ss"), 
                                                                                lstBarData[lstBarData.Count - 1].BarDateTime.ToString("yyyy/MM/dd HH:mm:ss"),
                                                                                lstBarData[iCurrentIndex].BarDateTime.ToString("yyyy/MM/dd HH:mm:ss"),
                                                                                lstBarData[iCurrentIndex].Open.ToString(),
                                                                                lstBarData[iCurrentIndex].High.ToString(),
                                                                                lstBarData[iCurrentIndex].Low.ToString(),
                                                                                lstBarData[iCurrentIndex].Close.ToString(),
                                                                                lstBarData[iCurrentIndex].Volume.ToString(),
                                                                                lstBarData[iCurrentIndex].Amount.ToString()});
                    else
                        DataGridViewUtil.UpdateRow(tblSymbolList, new string[] {"SymbolId"},
                                                                  new object[] {strSymbolId, 
                                                                                lstBarData[0].BarDateTime.ToString("yyyy/MM/dd HH:mm:ss"), 
                                                                                lstBarData[lstBarData.Count - 1].BarDateTime.ToString("yyyy/MM/dd HH:mm:ss"),
                                                                                lstBarData[iCurrentIndex].BarDateTime.ToString("yyyy/MM/dd HH:mm:ss"),
                                                                                lstBarData[iCurrentIndex].Open.ToString(),
                                                                                lstBarData[iCurrentIndex].High.ToString(),
                                                                                lstBarData[iCurrentIndex].Low.ToString(),
                                                                                lstBarData[iCurrentIndex].Close.ToString(),
                                                                                lstBarData[iCurrentIndex].Volume.ToString(),
                                                                                lstBarData[iCurrentIndex].Amount.ToString()});
 */ 
                    
                }
                txtCurrentTime.Text = ((CurrentTime)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.CURRENT_TIME]).CurrentDateTime.ToString("yyyy/MM/dd HH:mm:ss");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void tblSymbolList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            IDataSource dataSource;
            List<BarRecord> lstBarData;
            string strSymbolId;
            BarData barData;
            
            try
            {               
                strSymbolId = tblSymbolList.Rows[e.RowIndex].Cells["SymbolId"].Value.ToString();
                dataSource = (IDataSource)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.DATA_SOURCE];
                lstBarData = dataSource.GetBar(strSymbolId);

                foreach (BarRecord barRecord in lstBarData)
                {
                    barData = new BarData(barRecord);
                    if (float.IsNaN(barData.Open))
                    {
                        DataGridViewUtil.InsertRow(tblDataDetail, new object[] { barRecord.BarDateTime.ToString("yyyy/MM/dd HH:mm:ss"),
                                                                                 barRecord[0].ToString(),
                                                                                 barRecord[1].ToString(),
                                                                                 barRecord[2].ToString(),
                                                                                 barRecord[3].ToString(),
                                                                                 barRecord[4].ToString(),
                                                                                 barRecord[5].ToString()});
                    }
                    else
                    {
                        DataGridViewUtil.InsertRow(tblDataDetail, new object[] { barData.BarDateTime.ToString("yyyy/MM/dd HH:mm:ss"),
                                                                             barData.Open.ToString(),
                                                                             barData.High.ToString(),
                                                                             barData.Low.ToString(),
                                                                             barData.Close.ToString(),
                                                                             barData.Volume.ToString(),
                                                                             barData.Amount.ToString()});
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void Move(int iDirection)
        {
            CurrentTime currentTime = (CurrentTime)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.CURRENT_TIME];
            switch (iDirection)
            {
                case PREVIOUS:
                    currentTime.MovePrevious();
                    break;
                case NEXT:
                    currentTime.MoveNext();
                    break;
            }
            txtCurrentTime.Text = currentTime.CurrentDateTime.ToString("yyyy/MM/dd HH:mm:ss");
            RefreshData();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                Move(NEXT);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                Move(PREVIOUS);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void tblSymbolList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string strSymbolId = tblSymbolList.Rows[e.RowIndex].Cells["SymbolId"].Value.ToString();

                List<BarRecord> lstBarDetail = ((IDataSource)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.DATA_SOURCE]).GetBar(strSymbolId);
                BarData barData;
                
                DataGridViewUtil.Clear(tblDataDetail);

                foreach (BarRecord barRecord in lstBarDetail)
                {
                    barData = new BarData(barRecord);
                    if (float.IsNaN(barData.Open))
                    {
                        DataGridViewUtil.InsertRow(tblDataDetail, new object[] {barData.BarDateTime.ToString("yyyy/MM/dd HH:mm:ss"),
                                                                                barRecord[0],
                                                                                barRecord[1],
                                                                                barRecord[2],
                                                                                barRecord[3],
                                                                                barRecord[4],
                                                                                barRecord[5]});
                    }
                    else
                    {
                        DataGridViewUtil.InsertRow(tblDataDetail, new object[] {barData.BarDateTime.ToString("yyyy/MM/dd HH:mm:ss"),
                                                                             barData.Open,
                                                                             barData.High,
                                                                             barData.Low,
                                                                             barData.Close,
                                                                             barData.Volume,
                                                                             barData.Amount});
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        #region IObserver Members

        public void Update(object oSource, IMessageInfo miMessage)
        {
            switch (miMessage.MessageSubject)
            {
                case DataSourceConstants.BAR_RECEIVE:
                    RefreshData();                    
                    break;
            }
        }

        #endregion

        private void btnLoadAllData_Click(object sender, EventArgs e)
        {
            IniReader iniReader = new IniReader(AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.PROGRAM_ROOT_PATH] +
                                                @"\cfg\system.ini");
            string strExportDirectory;
            string[] strFiles;
            try
            {
                strExportDirectory = IOHelper.ConvertDirectory(AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.PROGRAM_ROOT_PATH].ToString(),
                                                               iniReader.GetParam("DataDownload", "ExportDirectory", AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.PROGRAM_ROOT_PATH] + @"\Export\"));


                strFiles = Directory.GetFiles(strExportDirectory);

                foreach (string strFilename in strFiles)
                    ProgramUtil.LoadOfflineData(strFilename, false);

                RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);                     
            }
        }

        private void btnDataExport_Click(object sender, EventArgs e)
        {
            Form dataExportForm = new DataExportForm();
            try
            {
                dataExportForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);                     
            }
        }
    }
}
