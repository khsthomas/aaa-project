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

namespace AAA.ProgramTrade
{
    public partial class DataMonitorForm : Form
    {
        public DataMonitorForm()
        {
            InitializeComponent();
            Init();
            RefreshData();
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

            try
            {
                dataSource = (IDataSource)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.DATA_SOURCE];

                foreach (string strSymbolId in dataSource.GetSymbolList())
                {
                    lstBarData = dataSource.GetBar(strSymbolId);
                    DataGridViewUtil.InsertRow(tblSymbolList, new object[] {strSymbolId, 
                                                                            lstBarData[0].BarDateTime.ToString("yyyy/MM/dd HH:mm:ss"), 
                                                                            lstBarData[lstBarData.Count - 1].BarDateTime.ToString("yyyy/MM/dd HH:mm:ss") });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void tblSymbolList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            IDataSource dataSource;
            List<BarData> lstBarData;
            string strSymbolId;

            try
            {               
                strSymbolId = tblSymbolList.Rows[e.RowIndex].Cells["SymbolId"].Value.ToString();
                dataSource = (IDataSource)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.DATA_SOURCE];
                lstBarData = dataSource.GetBar(strSymbolId);

                foreach (BarData barData in lstBarData)
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }
    }
}
