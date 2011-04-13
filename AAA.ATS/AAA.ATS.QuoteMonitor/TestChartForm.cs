using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AAA.Chart.Component;
using AAA.Chart.Indicator;
using AAA.Meta.Quote;
using AAA.Chart;

namespace AAA.ATS.QuoteMonitor
{
    public partial class TestChartForm : Form
    {
        public TestChartForm()
        {
            InitializeComponent();
            InitChart();
        }

        private void AddRecord(string strSymbolId)
        {
            AAA.Meta.Chart.Data.BarData barData = new AAA.Meta.Chart.Data.BarData(BarCompressionEnum.Min_1);
            barData.AddData(DateTime.Parse("2010/07/27 09:00"), 0, 0, 0, 7000, 100);
            barData.AddData(DateTime.Parse("2010/07/27 09:01"), 0, 0, 0, 7001, 500);
            barData.AddData(DateTime.Parse("2010/07/27 09:02"), 0, 0, 0, 7003, 300);
            barData.AddData(DateTime.Parse("2010/07/27 09:03"), 0, 0, 0, 7004, 200);
            barData.AddData(DateTime.Parse("2010/07/27 09:04"), 0, 0, 0, 7005, 150);
            barData.AddData(DateTime.Parse("2010/07/27 09:05"), 0, 0, 0, 7006, 130);
            barData.AddData(DateTime.Parse("2010/07/27 09:06"), 0, 0, 0, 7007, 1240);
            barData.AddData(DateTime.Parse("2010/07/27 09:07"), 0, 0, 0, 7008, 101);

            ccContainer.AddSymbol(strSymbolId, barData);
        }


        private void InitChart()
        {
            string strSymbolId = "TFHTX-TP";
            ChartX chart = CreateChart();
            chart.XDataType = ChartConstants.DATA_TYPE_VALUE;
            IIndicator indicator;
            ccContainer.AddChart(chart);

            AddRecord(strSymbolId);
            indicator = CreateIndicator(strSymbolId);
            chart.AddIndicator(indicator);
        }

        private IIndicator CreateIndicator(string strSymbolId)
        {
            IIndicator indicator = null;

            indicator = new PriceVolume(strSymbolId, "2010/07/21", "2010/07/22", "Volume");
            indicator.BaseStudy = strSymbolId;

            return indicator;
        }

        private ChartX CreateChart()
        {
            AAA.Chart.Component.ChartX chart = null;
            try
            {
                chart = new AAA.Chart.Component.ChartX();
                chart.AxisLineColor = Color.White;
                chart.ShowXAxis = true;
/*
                chart.ShowHourLine(true, Color.LightGray);
                chart.ShowDayLine(true, Color.Yellow);
 */ 
            }
            catch (Exception ex)
            {
            }
            return chart;
        }
    }
}
