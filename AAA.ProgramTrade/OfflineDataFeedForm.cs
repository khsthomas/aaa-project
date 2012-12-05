using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AAA.Meta.Quote.Data;
using AAA.Meta.Quote;
using System.IO;
using AAA.DataSource;
using AAA.TradeLanguage;
using AAA.Forms.Components.Util;

namespace AAA.ProgramTrade
{
    public partial class OfflineDataFeedForm : Form
    {
        private const int PREVIOUS = -1;
        private const int NEXT = 1;

        private IDataSource _dataSource;
        private CurrentTime _currentTime;

        public OfflineDataFeedForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            try
            {
                _dataSource = new DefaultDataSource();
                _currentTime = new CurrentTime();
                _currentTime.DataSource = _dataSource;
                _dataSource.Attach(_currentTime);
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

        private void btnLoadOfflineData_Click(object sender, EventArgs e)
        {
            StreamReader sr = null;
            string strSymbolId;
            string strDataCompression;
            string strLine;
            string[] strValues;
            List<BarRecord> lstBarData;
            BarData barData;
            BarCompressionEnum eBarCompression;
            int iInterval = 1;
            try
            {
                if (ofdOpenFile.ShowDialog() != DialogResult.OK)
                    return;

                foreach (string strFilename in ofdOpenFile.FileNames)
                {
                    sr = new StreamReader(strFilename);

                    strSymbolId = sr.ReadLine().Trim();
                    strDataCompression = sr.ReadLine().Trim();
                    iInterval = int.Parse(strDataCompression.Split(',')[1]);
                    lstBarData = new List<BarRecord>();
                    eBarCompression = (BarCompressionEnum)Enum.Parse(typeof(BarCompressionEnum), strDataCompression.Split(',')[0]);

                    while ((strLine = sr.ReadLine()) != null)
                    {
                        strValues = strLine.Split('\t');
                        barData = new BarData();
                        barData.SymbolId = strSymbolId;
                        barData.BarCompression = eBarCompression;
                        barData.CompressionInterval = iInterval;
                        barData.BarDateTime = DateTime.Parse(strValues[0]);
                        barData.Open = float.Parse(strValues[1]);
                        barData.High = float.Parse(strValues[2]);
                        barData.Low = float.Parse(strValues[3]);
                        barData.Close = float.Parse(strValues[4]);
                        barData.Volume = float.Parse(strValues[5]);
                        barData.Amount = float.Parse(strValues[6]);

                        lstBarData.Add(barData.ToBarRecord());
                    }

                    sr.Close();

                    _dataSource.AddSymbol(strSymbolId, lstBarData);
                }
                RefreshData();
                _currentTime.Reset();
                txtCurrentTime.Text = _currentTime.DataStartTime.ToString("yyyy/MM/dd HH:mm:ss");
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

        private void RefreshData()
        {
            int iRowIndex = -1;
            IDataAccess dataAccess = new DefaultDataAccess();

            try
            {
                if (_currentTime == null)
                    return;

                dataAccess.CurrentTime = _currentTime;
                dataAccess.DataSource = _dataSource;

                foreach (string strSymbolId in _dataSource.GetSymbolList())
                {


                    iRowIndex = DataGridViewUtil.FindRowIndex(tblSymbolList, new string[] { "SymbolId" }, new object[] { strSymbolId });
                    if (iRowIndex < 0)
                        DataGridViewUtil.InsertRow(tblSymbolList, new object[] {strSymbolId, 
                                                                                _dataSource.DataStartTime(strSymbolId).ToString("yyyy/MM/dd HH:mm:ss"), 
                                                                                _dataSource.DataEndTime(strSymbolId).ToString("yyyy/MM/dd HH:mm:ss"),
                                                                                dataAccess.Time(strSymbolId, 0).ToString("yyyy/MM/dd HH:mm:ss"),
                                                                                dataAccess.Open(strSymbolId, 0).ToString(),
                                                                                dataAccess.High(strSymbolId, 0).ToString(),
                                                                                dataAccess.Low(strSymbolId, 0).ToString(),
                                                                                dataAccess.Close(strSymbolId, 0).ToString(),
                                                                                dataAccess.Volume(strSymbolId, 0).ToString(),
                                                                                dataAccess.Amount(strSymbolId, 0).ToString()});
                    else
                        DataGridViewUtil.UpdateRow(tblSymbolList, new string[] { "SymbolId" },
                                                                  new object[] {strSymbolId, 
                                                                                _dataSource.DataStartTime(strSymbolId).ToString("yyyy/MM/dd HH:mm:ss"), 
                                                                                _dataSource.DataEndTime(strSymbolId).ToString("yyyy/MM/dd HH:mm:ss"),
                                                                                dataAccess.Time(strSymbolId, 0).ToString("yyyy/MM/dd HH:mm:ss"),
                                                                                dataAccess.Open(strSymbolId, 0).ToString(),
                                                                                dataAccess.High(strSymbolId, 0).ToString(),
                                                                                dataAccess.Low(strSymbolId, 0).ToString(),
                                                                                dataAccess.Close(strSymbolId, 0).ToString(),
                                                                                dataAccess.Volume(strSymbolId, 0).ToString(),
                                                                                dataAccess.Amount(strSymbolId, 0).ToString()});
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

        private void tblSymbolList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {            
            List<BarRecord> lstBarData;
            string strSymbolId;
            BarData barData;

            try
            {
                strSymbolId = tblSymbolList.Rows[e.RowIndex].Cells["SymbolId"].Value.ToString();
                lstBarData = _dataSource.GetBar(strSymbolId);

                foreach (BarRecord barRecord in lstBarData)
                {
                    barData = new BarData(barRecord);
                    DataGridViewUtil.InsertRow(tblDataDetail, new object[] { barData.BarDateTime.ToString("yyyy/MM/dd HH:mm:ss"),
                                                                             barData.Open.ToString(),
                                                                             barData.High.ToString(),
                                                                             barData.Low.ToString(),
                                                                             barData.Close.ToString(),
                                                                             barData.Volume.ToString(),
                                                                             barData.Amount.ToString()});
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
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
    }
}
