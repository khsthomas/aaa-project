using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AAA.DataSource;
using AAA.ResultSet;
using AAA.Meta.Quote.Data;
using AAA.Meta.Chart;
using AAA.TeeChart;

namespace AAA.ProgramTrade
{
    public partial class ChartForm : Form
    {
        private static string[] KBAR_NAME = {"ExDate", "Open", "High", "Low", "Close" };
        private static string[] VOLUME_NAME = { "ExDate", "Volume" };
        public ChartForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            IDataSource dataSource;
            List<string> lstFieldName;
            try
            {
                dataSource = (IDataSource)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.DATA_SOURCE];

                chartPane.PointPerPage = int.Parse(txtKBarCount.Text);
                chartPane.ShowVerticalCursor = true;
                chartPane.IsShowScale = true;
                chartPane.IsShowInfoTable = true;
                chartPane.AddChart("KBar");
                chartPane.AddChart("Volume");


                chartPane.AdddSeries("KBar", "KBar", ScaleTypeEnum.Screen, DataFieldTypeEnum.BarData, ChartStyleEnum.CandleStick);                
                lstFieldName = new List<string>();
                lstFieldName.Add("ExDate");
                lstFieldName.Add("Open");
                lstFieldName.Add("High");
                lstFieldName.Add("Low");
                lstFieldName.Add("Close");
                chartPane.AddSeriesField("KBar", lstFieldName);

                chartPane.AdddSeries("Volume", "Volume", ScaleTypeEnum.Screen, DataFieldTypeEnum.Volume, ChartStyleEnum.Volume);
                lstFieldName = new List<string>();
                lstFieldName.Add("ExDate");
                lstFieldName.Add("Volume");
                chartPane.AddSeriesField("Volume", lstFieldName);

                chartPane.AddActiveSeries("KBar", "KBar");
                chartPane.AddActiveSeries("Volume", "Volume");

                chartPane.SetChartSize("KBar", 3);
                chartPane.SetChartSize("Volume", 1);

                foreach (string strSymbolId in dataSource.GetSymbolList())
                    cboSymbolId.Items.Add(strSymbolId);

                if (cboSymbolId.Items.Count > 0)
                    cboSymbolId.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }

        }

        private void cboSymbolId_SelectedIndexChanged(object sender, EventArgs e)
        {
            IDataSource dataSource;
            IResultSet resultSet;
            List<BarRecord> lstBarData;
            try
            {
                dataSource = (IDataSource)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.DATA_SOURCE];
                lstBarData = dataSource.GetBar(cboSymbolId.Text);
                resultSet = new DataSourceResultSet(lstBarData);
                if (!resultSet.Load())
                {
                    MessageBox.Show(resultSet.ErrorMessage);
                    return;
                }

                chartPane.ProcessResultSet("KBar", "KBar", resultSet);
                chartPane.ProcessResultSet("Volume", "Volume", resultSet);
                chartPane.PointPerPage = int.Parse(txtKBarCount.Text);
                chartPane.Draw();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                chartPane.PrintInOnSheet();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void txtKBarCount_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Return)
                return;

            try
            {
                chartPane.PointPerPage = int.Parse(txtKBarCount.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

    }
}
