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
    }
}
