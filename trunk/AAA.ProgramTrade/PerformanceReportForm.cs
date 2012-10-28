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
using AAA.Forms.Components.Util;
using AAA.DesignPattern.Observer;
using AAA.Chart.Component;
using AAA.Chart.Indicator;

namespace AAA.ProgramTrade
{
    public partial class PerformanceReportForm : Form, IObserver
    {
        private ISignal _loadedSignal;
        private CurrentTime _currentTime;
        private PositionManager _positionManager;
        private TrackingCenter _trackingCenter;
        private ITradingRule _tradingRule;
        private Dictionary<string, List<TradeInfo>> _dicTradeInfo;

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
                tblSignalHistory.Columns.Add("Profit", "平倉損益");
                tblSignalHistory.Columns.Add("Commission", "手續費");
                tblSignalHistory.Columns.Add("Tax", "交易稅");
                tblSignalHistory.Columns.Add("NetProfit", "淨損益");

                tblActiveOrder.Columns.Add("SignalName", "訊號名稱");
                tblActiveOrder.Columns.Add("SignalDirection", "訊號方向");
                tblActiveOrder.Columns.Add("SignalOrderType", "訊號類別");
                tblActiveOrder.Columns.Add("SignalTimePlaced", "時間");
                tblActiveOrder.Columns.Add("SignalPrice", "價位");
                tblActiveOrder.Columns.Add("SignalBaseSymbolId", "商品");

                tblFilled.Columns.Add("SignalName", "訊號名稱");
                tblFilled.Columns.Add("SignalDirection", "訊號方向");
                tblFilled.Columns.Add("SignalOrderType", "訊號類別");
                tblFilled.Columns.Add("SignalTimePlaced", "時間");
                tblFilled.Columns.Add("SignalPrice", "價位");
                tblFilled.Columns.Add("SignalBaseSymbolId", "訊號商品");
                tblFilled.Columns.Add("TradeSymbolId", "交易商品");
                tblFilled.Columns.Add("ContractType", "合約類別");
                tblFilled.Columns.Add("OrderDirection", "買賣別");
                tblFilled.Columns.Add("Volume", "口數");
                tblFilled.Columns.Add("DealPrice", "成交價格");
                tblFilled.Columns.Add("ExecutePriceType", "履約價別");
                tblFilled.Columns.Add("PositionId", "部位序號");

                tblReport.Columns.Add("Item", "項目");
                tblReport.Columns.Add("Total", "所有交易");
                tblReport.Columns.Add("Long", "多方交易");
                tblReport.Columns.Add("Short", "空方交易");

                _currentTime = new CurrentTime();
                _currentTime.SessionStartTime = new DateTime(1900, 01, 01, 8, 45, 00);
                _currentTime.SessionEndTime = new DateTime(1900, 01, 01, 13, 45, 00);
                _currentTime.DataSource = (IDataSource)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.DATA_SOURCE];
                _positionManager = new PositionManager();
                _trackingCenter = new TrackingCenter();
                //_tradingRule = (ITradingRule)AAA.DesignPattern.Singleton.SystemParameter.Parameter["TradingRule"];
                _tradingRule = new DefaultTradingRule();
                _dicTradeInfo = new Dictionary<string, List<TradeInfo>>();
                SystemHelper.InitStrategy(_tradingRule,
                                          (string)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.PROGRAM_ROOT_PATH] + @"\cfg\strategy.cfg");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void InitChart()
        {
            try
            {
                ChartX chart;
                IIndicator indicator;

                cpChart.ChartContainer.XScale = 10;
                //Add Trend Chart
                chart = new ChartX();
                cpChart.ChartContainer.AddChart(chart);                
                indicator = new CandleStick("Trend");
                indicator.BaseStudy = cboBaseSymbolId.Text;
                chart.AddIndicator(indicator);


                //Add Volume Chart
                chart = new ChartX();
                chart.IsShowXAxis = true;
                cpChart.ChartContainer.AddChart(chart);
                indicator = new Volume();
                indicator.BaseStudy = cboBaseSymbolId.Text;
                chart.AddIndicator(indicator);

                cpChart.ChartContainer.RedrawChart();
                cpChart.InitChartEvent();
                
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

                for (int i = 0; i < _loadedSignal.InputVariableNames.Length; i++)
                {
                    tblParameter.Rows.Add(new object[] {_loadedSignal.InputVariableNames[i],
                                                        _loadedSignal.InputVariableDescs[i],
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
                DataGridViewUtil.Clear(tblSignalHistory);
                DataGridViewUtil.Clear(tblReport);
                DataGridViewUtil.Clear(tblOpenPosition);
                DataGridViewUtil.Clear(tblCanceled);
                DataGridViewUtil.Clear(tblActiveOrder);
                DataGridViewUtil.Clear(tblFilled);

                StrategyManager strategyManager = new StrategyManager();

                for (int i = 0; i < tblParameter.Rows.Count; i++)
                {
                    _loadedSignal.DefaultValues[i] = tblParameter.Rows[i].Cells["ItemValue"].Value;
                    _loadedSignal.BaseSymbolId = cboBaseSymbolId.Text;
                    _loadedSignal.InputVariable(tblParameter.Rows[i].Cells["ItemName"].Value.ToString(),
                                                tblParameter.Rows[i].Cells["ItemValue"].Value);                    
                }

//                _loadedSignal.Attach((TrackingCenter)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.TRACKING_CENTER]);

                _loadedSignal.Attach(this);
                _loadedSignal.SignalGroupName = txtStrategyName.Text;
                strategyManager.AddSignal(_loadedSignal);
                strategyManager.CurrentTime = _currentTime;
                strategyManager.PositionManager = _positionManager;

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

                DateTime dtVerifyStartTime = new DateTime(dtStartTime.Value.Year, dtStartTime.Value.Month, dtStartTime.Value.Day,
                                                          _currentTime.SessionStartTime.Hour, _currentTime.SessionStartTime.Minute, 0);
                DateTime dtVerifyEndTime = new DateTime(dtEndTime.Value.Year, dtEndTime.Value.Month, dtEndTime.Value.Day,
                                                          _currentTime.SessionEndTime.Hour, _currentTime.SessionEndTime.Minute, 59);

                strategyManager.PerformanceVarify(iTimeInterval, 
                                                  dtVerifyStartTime, 
                                                  dtVerifyEndTime);

                DataGridViewUtil.Clear(tblSignalHistory);

                List<SignalRecord> lstSignalRecord;
                SignalRecord signalRecord;

                double dNetProfit = 0;
                int iCorrectCount = 0;
                
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
                    signalRecord.PointMultiple = float.Parse(txtPointMultiple.Text);
                    signalRecord.TaxRate = float.Parse(txtTaxRate.Text);
                    signalRecord.Commission = float.Parse(txtCommission.Text);
                    signalRecord.Contract = 1;

/*
                    switch (signalRecord.EntryOrderDirection)
                    {
                        case OrderDirectionEnum.LongEntry:
                            fProfit = signalRecord.ExitPrice - signalRecord.EntryPrice;
                            break;
                        case OrderDirectionEnum.ShortEntry:
                            fProfit = -1 * (signalRecord.ExitPrice - signalRecord.EntryPrice);
                            break;
                    }
*/
                    DataGridViewUtil.InsertRow(tblSignalHistory, new object[] {signalRecord.EntrySignalName,
                                                                                signalRecord.EntryDateTime.ToString("yyyy/MM/dd HH:mm:ss"),
                                                                                signalRecord.EntryOrderDirection,
                                                                                signalRecord.EntryPrice,                                                                                
                                                                                signalRecord.TradeProfit,
                                                                                signalRecord.TradeCommission,
                                                                                signalRecord.Tax,
                                                                                signalRecord.Profit});

                    DataGridViewUtil.InsertRow(tblSignalHistory, new object[] {"",
                                                            signalRecord.ExitDateTime.ToString("yyyy/MM/dd HH:mm:ss"),
                                                            signalRecord.ExitOrderDirection,
                                                            signalRecord.ExitPrice,
                                                            "",
                                                            "",
                                                            "",
                                                            ""});

                }

                PerformanceAnalyzer performanceAnalyzer = new PerformanceAnalyzer();
                performanceAnalyzer.TaxRate = float.Parse(txtTaxRate.Text);
                performanceAnalyzer.PointMultiple = float.Parse(txtPointMultiple.Text);
                performanceAnalyzer.Commission = float.Parse(txtCommission.Text);

                performanceAnalyzer.ParseRecord(lstSignalRecord);

                DataGridViewUtil.InsertRow(tblReport, 
                                           new object[] { "淨利",
                                                          performanceAnalyzer.AllTrade.TotalNetProfit,
                                                          performanceAnalyzer.LongTrade.TotalNetProfit,
                                                          performanceAnalyzer.ShortTrade.TotalNetProfit
                                                        });
                DataGridViewUtil.InsertRow(tblReport,
                                           new object[] { "獲利",
                                                          performanceAnalyzer.AllTrade.GrossProfit,
                                                          performanceAnalyzer.LongTrade.GrossProfit,
                                                          performanceAnalyzer.ShortTrade.GrossProfit
                                                        });
                DataGridViewUtil.InsertRow(tblReport,
                                           new object[] { "損失",
                                                          performanceAnalyzer.AllTrade.GrossLoss,
                                                          performanceAnalyzer.LongTrade.GrossLoss,
                                                          performanceAnalyzer.ShortTrade.GrossLoss
                                                        });
                DataGridViewUtil.InsertRow(tblReport,
                                           new object[] { "總交易次數",
                                                          performanceAnalyzer.AllTrade.TotalTradeCount,
                                                          performanceAnalyzer.LongTrade.TotalTradeCount,
                                                          performanceAnalyzer.ShortTrade.TotalTradeCount
                                                        });
                DataGridViewUtil.InsertRow(tblReport,
                                           new object[] { "勝率",
                                                          performanceAnalyzer.AllTrade.PercentProfitable,
                                                          performanceAnalyzer.LongTrade.PercentProfitable,
                                                          performanceAnalyzer.ShortTrade.PercentProfitable
                                                        });
                DataGridViewUtil.InsertRow(tblReport,
                                           new object[] { "最大單次獲利",
                                                          performanceAnalyzer.AllTrade.LargestWinningTrade,
                                                          performanceAnalyzer.LongTrade.LargestWinningTrade,
                                                          performanceAnalyzer.ShortTrade.LargestWinningTrade
                                                        });
                DataGridViewUtil.InsertRow(tblReport,
                                           new object[] { "最大單次損失",
                                                          performanceAnalyzer.AllTrade.LargestLosingTrade,
                                                          performanceAnalyzer.LongTrade.LargestLosingTrade,
                                                          performanceAnalyzer.ShortTrade.LargestLosingTrade
                                                        });
                DataGridViewUtil.InsertRow(tblReport,
                                           new object[] { "平均獲利",
                                                          performanceAnalyzer.AllTrade.AverageWinningTrade,
                                                          performanceAnalyzer.LongTrade.AverageWinningTrade,
                                                          performanceAnalyzer.ShortTrade.AverageWinningTrade
                                                        });
                DataGridViewUtil.InsertRow(tblReport,
                                           new object[] { "平均損失",
                                                          performanceAnalyzer.AllTrade.AverageLosingTrade,
                                                          performanceAnalyzer.LongTrade.AverageLosingTrade,
                                                          performanceAnalyzer.ShortTrade.AverageLosingTrade
                                                        });
                DataGridViewUtil.InsertRow(tblReport,
                                           new object[] { "平均獲利/平均損失",
                                                          performanceAnalyzer.AllTrade.AverageWinLossRatio,
                                                          performanceAnalyzer.LongTrade.AverageWinLossRatio,
                                                          performanceAnalyzer.ShortTrade.AverageWinLossRatio
                                                        });
                DataGridViewUtil.InsertRow(tblReport,
                                           new object[] { "平均單次損益",
                                                          performanceAnalyzer.AllTrade.AverageTrade,
                                                          performanceAnalyzer.LongTrade.AverageTrade,
                                                          performanceAnalyzer.ShortTrade.AverageTrade
                                                        });
                DataGridViewUtil.InsertRow(tblReport,
                                           new object[] { "最大連對次數",
                                                          performanceAnalyzer.AllTrade.MaxConsecWinner,
                                                          performanceAnalyzer.LongTrade.MaxConsecWinner,
                                                          performanceAnalyzer.ShortTrade.MaxConsecWinner
                                                        });
                DataGridViewUtil.InsertRow(tblReport,
                                           new object[] { "最大連錯次數",
                                                          performanceAnalyzer.AllTrade.MaxConsecLoser,
                                                          performanceAnalyzer.LongTrade.MaxConsecLoser,
                                                          performanceAnalyzer.ShortTrade.MaxConsecLoser
                                                        });





            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        #region IObserver Members

        public void Update(object oSource, IMessageInfo miMessage)
        {
            SignalInfo signalInfo;
            
            try
            {
                switch (miMessage.MessageSubject)
                {
                    case "Active":
                        signalInfo = (SignalInfo)miMessage.Message;
                        DataGridViewUtil.InsertRow(tblActiveOrder,
                                                   new object[] {signalInfo.SignalName,
                                                                 signalInfo.OrderDirection,
                                                                 signalInfo.OrderType,
                                                                 signalInfo.TimePlaced.ToString("yyyy/MM/dd HH:mm:ss"),
                                                                 signalInfo.Price,
                                                                 signalInfo.BaseSymbolId});
                        break;
                    case "Filled":
                        signalInfo = (SignalInfo)miMessage.Message;
                        
                        if(_dicTradeInfo.ContainsKey(signalInfo.PositionId))
                        {
                            foreach(TradeInfo tradeInfo in _dicTradeInfo[signalInfo.PositionId])
                            {
                                DataGridViewUtil.InsertRow(tblFilled,
                                                           new object[] {signalInfo.SignalName,
                                                                     signalInfo.OrderDirection,
                                                                     signalInfo.OrderType,
                                                                     signalInfo.TimePlaced.ToString("yyyy/MM/dd HH:mm:ss"),
                                                                     signalInfo.Price,
                                                                     signalInfo.BaseSymbolId,
                                                                     tradeInfo.SymbolType.ToString(),
                                                                     tradeInfo.SymbolName + "_" + tradeInfo.Year + "_" + tradeInfo.Month + "_" + tradeInfo.ExecutePrice,
                                                                     tradeInfo.OrderDirection.ToString(),
                                                                     tradeInfo.Volume.ToString(),
                                                                     tradeInfo.Price.ToString(),
                                                                     tradeInfo.ExecutePrice.ToString(),
                                                                     signalInfo.PositionId});

                            }
                            _dicTradeInfo.Remove(signalInfo.PositionId);
                        }
                        else
                        {
                            _tradingRule.CreateBasicContractInfo(signalInfo.TimePlaced, signalInfo.Price);
                            List<TradeSymbol> lstTradeSymbol = _tradingRule.GetTradeSymbol(signalInfo.SignalGroupName);
                            TradeInfo[] tradeInfos = _tradingRule.CreateOrder(signalInfo.SignalGroupName);
                            _dicTradeInfo.Add(signalInfo.PositionId, new List<TradeInfo>());
                            foreach (TradeInfo tradeInfo in tradeInfos)
                            {                                                        
                                DataGridViewUtil.InsertRow(tblFilled,
                                                           new object[] {signalInfo.SignalName,
                                                                     signalInfo.OrderDirection,
                                                                     signalInfo.OrderType,
                                                                     signalInfo.TimePlaced.ToString("yyyy/MM/dd HH:mm:ss"),
                                                                     signalInfo.Price,
                                                                     signalInfo.BaseSymbolId,
                                                                     tradeInfo.SymbolType.ToString(),
                                                                     tradeInfo.SymbolName + "_" + tradeInfo.Year + "_" + tradeInfo.Month + "_" + tradeInfo.ExecutePrice,
                                                                     tradeInfo.OrderDirection.ToString(),
                                                                     tradeInfo.Volume.ToString(),
                                                                     tradeInfo.Price.ToString(),
                                                                     tradeInfo.ExecutePrice.ToString(),
                                                                     signalInfo.PositionId});
                                _dicTradeInfo[signalInfo.PositionId].Add(tradeInfo);
                            }
                        }
 /*
                        _tradingRule.CreateBasicContractInfo(signalInfo.TimePlaced, signalInfo.Price);
                        List<TradeSymbol> lstTradeSymbol = _tradingRule.GetTradeSymbol(signalInfo.SignalGroupName);
                        TradeInfo[] tradeInfos = _tradingRule.CreateOrder(signalInfo.SignalGroupName);
                        
                        foreach (TradeInfo tradeInfo in tradeInfos)
                        {
                            DataGridViewUtil.InsertRow(tblFilled,
                                                       new object[] {signalInfo.SignalName,
                                                                     signalInfo.OrderDirection,
                                                                     signalInfo.OrderType,
                                                                     signalInfo.TimePlaced,
                                                                     signalInfo.Price,
                                                                     signalInfo.BaseSymbolId,
                                                                     tradeInfo.SymbolType.ToString(),
                                                                     tradeInfo.SymbolName + "_" + tradeInfo.Year + "_" + tradeInfo.Month + "_" + tradeInfo.ExecutePrice,
                                                                     tradeInfo.OrderDirection.ToString(),
                                                                     tradeInfo.Volume.ToString(),
                                                                     tradeInfo.Price.ToString(),
                                                                     tradeInfo.ExecutePrice.ToString(),
                                                                     signalInfo.PositionId});
                            
                        }
*/
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        #endregion

        private void btnDrawChart_Click(object sender, EventArgs e)
        {
            List<BarRecord> lstBarRecord;
            try
            {
                lstBarRecord = ((IDataSource)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.DATA_SOURCE]).GetBar(cboBaseSymbolId.Text);
                if(lstBarRecord == null)
                {
                    MessageBox.Show("查無此商品資料");
                    return;
                }

                ChartUtil.FillRecord(cboBaseSymbolId.Text, cpChart, lstBarRecord, dtStartTime.Value, dtEndTime.Value);

                cpChart.ChartContainer.RemoveAllChart();

                InitChart();

                //cpChart.Chart.PaintChart();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void pnlStrategy_Click(object sender, EventArgs e)
        {

        }
    }
}
