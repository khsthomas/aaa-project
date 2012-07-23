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
        private ISignal _loadedSignal;
        public PerformanceReportForm()
        {
            InitializeComponent();
            Init();
            LoadSymbolId();
        }

        private void Init()
        {
            try
            {
                tblParameter.Columns.Add("ItemName", "項目");
                tblParameter.Columns.Add("ItemDesc", "項目描述");
                tblParameter.Columns.Add("ItemValue", "參數值");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
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
            //ISignal loadedSignal;
            try
            {
                if (ofdDllPath.ShowDialog() != DialogResult.OK)
                    return;

                lstSignal = Builder.LoadClassesFromFile<ISignal>(ofdDllPath.FileName);
                txtStrategyPath.Text = ofdDllPath.FileName;

                if (lstSignal.Count == 0)
                    return;

                _loadedSignal = lstSignal[0];

                txtStrategyName.Text = _loadedSignal.DisplayName;

                for (int i = 0; i < _loadedSignal.VariableNames.Length; i++)
                {
                    tblParameter.Rows.Add(new object[] {_loadedSignal.VariableNames[i],
                                                        _loadedSignal.VariableDescs[i],
                                                        _loadedSignal.DefaultValues[i]});

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
                StrategyManager strategyManager = new StrategyManager();

                for (int i = 0; i < tblParameter.Rows.Count; i++)
                {
                    _loadedSignal.DefaultValues[i] = tblParameter.Rows[i].Cells["ItemValue"].Value;
                    _loadedSignal.BaseSymbolId = cboBaseSymbolId.Text;
                    _loadedSignal.Variable(tblParameter.Rows[i].Cells["ItemName"].Value.ToString(),
                                           tblParameter.Rows[i].Cells["ItemValue"].Value);
                }

                strategyManager.AddSignal(_loadedSignal);
                strategyManager.CurrentTime = (CurrentTime)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.CURRENT_TIME];
                //strategyManager.DataSource = (IDataSource)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.DATA_SOURCE];
                strategyManager.PositionManager = (PositionManager)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.POSITION_MANAGER];
                strategyManager.PerformanceVarify(60 * 30, 
                                                  strategyManager.CurrentTime.DataSource.DataStartTime(cboBaseSymbolId.Text), 
                                                  strategyManager.CurrentTime.DataSource.DataEndTime(cboBaseSymbolId.Text));


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }
    }
}
