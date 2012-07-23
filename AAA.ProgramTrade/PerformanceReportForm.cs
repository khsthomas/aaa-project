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
using AAA.Meta.Quote.Data;
using AAA.TradeLanguage.Data;

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

                tblSignalHistory.Columns.Add("SignalName", "訊號名稱");                
                tblSignalHistory.Columns.Add("BarDateTime", "K棒時間");
                tblSignalHistory.Columns.Add("Direction", "方向");
                tblSignalHistory.Columns.Add("Price", "價位");
                tblSignalHistory.Columns.Add("Profit", "損益");
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

                int iTimeInterval = 60;
                BarCompression barCompression = _loadedSignal.BarCompression(_loadedSignal.BaseSymbolId);

                switch (barCompression.DataCompression)
                {
                    case AAA.Meta.Quote.BarCompressionEnum.Min:
                        iTimeInterval = 60 * barCompression.Interval;
                        break;
                    case AAA.Meta.Quote.BarCompressionEnum.Hour:
                        iTimeInterval = 60 * 60 * barCompression.Interval;
                        break;
                    case AAA.Meta.Quote.BarCompressionEnum.Daily:
                        iTimeInterval = 60 * 60 * 24 * barCompression.Interval;
                        break;
                }

                strategyManager.PerformanceVarify(iTimeInterval, 
                                                  dtStartTime.Value, 
                                                  dtEndTime.Value);

                while (tblSignalHistory.Rows.Count > 0)
                    tblSignalHistory.Rows.RemoveAt(0);

                List<SignalRecord> lstSignalRecord;
                SignalRecord signalRecord;
                string strOrderDirection;
                float fProfit = 0;

                lstSignalRecord = strategyManager.TradeRecord(_loadedSignal.DisplayName);

                if (lstSignalRecord == null)
                {
                    MessageBox.Show("沒有任何交易資訊可顯示");
                    return;
                }

                for (int i = 0; i < lstSignalRecord.Count; i++)
                {
                    signalRecord = lstSignalRecord[i];

                    switch (signalRecord.EntryOrderDirection)
                    {
                        case OrderDirectionEnum.LongEntry:
                            fProfit = signalRecord.ExitPrice - signalRecord.EntryPrice;
                            break;
                        case OrderDirectionEnum.ShortEntry:
                            fProfit = -1 * (signalRecord.ExitPrice - signalRecord.EntryPrice);
                            break;
                    }

                    tblSignalHistory.Rows.Add(new object[] {signalRecord.EntrySignalName,
                                                            signalRecord.EntryDateTime,
                                                            signalRecord.EntryOrderDirection,
                                                            signalRecord.EntryPrice,
                                                            fProfit});

                    tblSignalHistory.Rows.Add(new object[] {"",
                                                            signalRecord.ExitDateTime,
                                                            signalRecord.ExitOrderDirection,
                                                            signalRecord.ExitPrice,
                                                            ""});
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }
    }
}
