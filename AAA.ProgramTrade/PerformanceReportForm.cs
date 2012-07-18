using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AAA.Base.Util.Reflection;
using AAA.TradeLanguage;
using AAA.DataSource;

namespace AAA.ProgramTrade
{
    public partial class PerformanceReportForm : Form
    {
        public PerformanceReportForm()
        {
            InitializeComponent();
            LoadSymbolId();
        }

        private void LoadSymbolId()
        {
            IDataSource dataSource;
            List<string> lstSymbolId;
            try
            {
                dataSource = (IDataSource)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.DATA_SOURCE];
                lstSymbolId = dataSource.GetSymbolList();

                while (cboBaseSymbolId.Items.Count > 0)
                    cboBaseSymbolId.Items.RemoveAt(0);

                foreach (string strSymbolId in lstSymbolId)
                {
                    cboBaseSymbolId.Items.Add(strSymbolId);
                }

                if (cboBaseSymbolId.Items.Count > 0)
                    cboBaseSymbolId.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }


        private void btnBrowse_Click(object sender, EventArgs e)
        {
            List<ISignal> lstSignal;
            ISignal loadedSignal;
            try
            {
                if (ofdDllPath.ShowDialog() != DialogResult.OK)
                    return;

                lstSignal = Builder.LoadClassesFromFile<ISignal>(ofdDllPath.FileName);
                txtStrategyPath.Text = ofdDllPath.FileName;

                if (lstSignal.Count == 0)
                    return;

                loadedSignal = lstSignal[0];

                txtStrategyName.Text = loadedSignal.DisplayName;

                for (int i = 0; i < loadedSignal.VariableNames.Length; i++)
                {
                    tblParameter.Rows.Add(new object[] {loadedSignal.VariableNames[i],
                                                        loadedSignal.VariableDescs[i],
                                                        loadedSignal.DefaultValues[i]});

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void btnPerformance_Click(object sender, EventArgs e)
        {
            try
            {
                CurrentTime currentTime = (CurrentTime)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.CURRENT_TIME];
                currentTime.Reset();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }
    }
}
