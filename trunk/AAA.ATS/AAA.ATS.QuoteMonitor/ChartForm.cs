using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AAA.Chart.Component;
using System.Xml;
using AAA.Base.Util.Reader;
using AAA.AGS.Client;
using AAA.Meta.Quote.Data;
using AAA.Chart.Style;
using AAA.Chart.Indicator;
using AAA.Chart.Data;
using AAA.Meta.Chart;
using AAA.Meta.Quote;
using AAA.Meta.Chart.Data;

namespace AAA.ATS.QuoteMonitor
{
    public partial class ChartForm : Form
    {
        private Client _client;
//        private IDataSource _dataSource;        

        public ChartForm(Client client) : this(client, null) { }

        public ChartForm(Client client,string strConfig)
        {            
            InitializeComponent();
            
            _client = client;
            if (strConfig != null)
                InitChartConfig(strConfig);
            VisibleChanged += new EventHandler(OnVisibleChanged);

            _client.DataHandler += new DataHandler(OnDataReceive);

        }

        public void OnVisibleChanged(object sender, EventArgs e)
        {
            if(Visible == true)
                ccChartContainer.RedrawChart();
        }

        public void OnDataReceive(QuoteData quoteData)
        {
            AAA.Meta.Chart.Data.BarData barData = ccChartContainer.GetData(quoteData.SymbolId);

            barData.AddTick(DateTime.Parse(quoteData.LastUpdateTime),
                            float.Parse(quoteData.Items[3]),
                            float.Parse(quoteData.Items[4]));

            ccChartContainer.AddTick(quoteData.SymbolId, 
                                     float.Parse(quoteData.Items[3]),
                                     float.Parse(quoteData.Items[4]));

            ccChartContainer.GetPriceVolume(quoteData.SymbolId).AddData(float.Parse(quoteData.Items[3]),
                                                                        float.Parse(quoteData.Items[4]));
            ccChartContainer.RedrawChart();
        }

        private float AddRecord(string strSymbolId, string strBarCompression, string strStartDateTime, string strEndDateTime)
        {
            Dictionary<string, string> queryProperties = new Dictionary<string, string>();
            float fLastPrice = -1;
            queryProperties.Add("SymbolId", strSymbolId);
            queryProperties.Add("StartDateTime", strStartDateTime);
            queryProperties.Add("EndDateTime", strEndDateTime);

            AAA.Meta.Chart.Data.BarData barData = new AAA.Meta.Chart.Data.BarData((BarCompressionEnum)Enum.Parse(typeof(BarCompressionEnum), strBarCompression));
            List<BarRecord> lstBarRecord = _client.GetData(queryProperties);
            foreach (BarRecord barRecord in lstBarRecord)
                barData.AddData(barRecord.BarDateTime, barRecord.V0, barRecord.V1, barRecord.V2, barRecord.V3, barRecord.V4);
            ccChartContainer.AddSymbol(strSymbolId, barData);
            if(lstBarRecord.Count > 0)
                fLastPrice = lstBarRecord[lstBarRecord.Count - 1].V3;

            Dictionary<string, AAA.Meta.Chart.Data.PriceVolumeData> dicPriceVolumeData = _client.GetPriceVolume(queryProperties);
            ccChartContainer.AddSymbol(strSymbolId, dicPriceVolumeData);
            return fLastPrice;
        }

        private void InitChartConfig(string strConfig)
        {
            XmlParser xmlParser = new XmlParser(strConfig);
            
            AAA.Chart.Component.ChartX chart;
            IIndicator indicator;
            XmlNode chartNode;
            string strBaseSymbolId;
            string strStartDateTime = "";
            string strEndDateTime = "";
            string strBarCompression;
            string strOrientation;
            int iXScale;
            int iUpdateFreq;
            string strSymbolId;
            string strName;
            string strType;
            string[] strValues;
            string strXMin;
            string strYMin;
            string strRangeType;
            int iDaysBack;            
            string strYMinValue;
            string strYMaxValue;
            string strPriceRange;
            float fLastPrice;
            //ccChartContainer.Orientation = Orientation.Vertical;
            

            //_dataSource = new DefaultDataSource();
            Text = xmlParser.GetSingleNode("/chart-container/name").InnerText;
            strBarCompression = xmlParser.GetSingleNode("/chart-container/compression").InnerText;
            strOrientation = xmlParser.GetSingleNode("/chart-container/orientation").InnerText;
            iXScale = int.Parse(xmlParser.GetSingleNode("/chart-container/xscale").InnerText);
            strBaseSymbolId = xmlParser.GetSingleNode("/chart-container/date-range/base-symbol").InnerText;
            strRangeType = xmlParser.GetSingleNode("/chart-container/date-range/type").InnerText;

            ccChartContainer.Orientation = (Orientation)Enum.Parse(typeof(Orientation), strOrientation); //Orientation.Horizontal;
            ccChartContainer.XScale = iXScale;

            switch (strRangeType)
            {
                case "FromTo":
                    strStartDateTime = xmlParser.GetSingleNode("/chart-container/date-range/from-date").InnerText;
                    strEndDateTime = xmlParser.GetSingleNode("/chart-container/date-range/to-date").InnerText;
                    break;
                case "DaysBack":
                    strEndDateTime = xmlParser.GetSingleNode("/chart-container/date-range/to-date").InnerText;
                    if (strEndDateTime == "-")
                        strEndDateTime = DateTime.Now.ToString("yyyy/MM/dd");
                    iDaysBack = int.Parse(xmlParser.GetSingleNode("/chart-container/date-range/days-back").InnerText);
                    strStartDateTime = DateTime.Parse(strEndDateTime).AddDays(-iDaysBack).ToString("yyyy/MM/dd");
                    break;
            }

            fLastPrice = AddRecord(strBaseSymbolId, strBarCompression, strStartDateTime, strEndDateTime);            
            XmlNodeList nodeList = xmlParser.GetNodes("/chart-container/chart");
            XmlNodeList indicatorList;

            foreach (XmlNode node in nodeList)
            {
                chart = CreateChart();                
                //chartNode = xmlParser.GetSingleNode(node, "/chart-container/chart/position");
                chartNode = xmlParser.GetSingleNode(node, "position");

                chartNode = xmlParser.GetSingleNode(node, "top-pad");
                if (chartNode != null)
                    chart.TopPad = Int32.Parse(chartNode.InnerText);

                chartNode = xmlParser.GetSingleNode(node, "bottom-pad");
                if (chartNode != null)
                    chart.BottomPad = Int32.Parse(chartNode.InnerText);

                chartNode = xmlParser.GetSingleNode(node, "left-pad");
                if (chartNode != null)
                    chart.LeftPad = Int32.Parse(chartNode.InnerText);

                chartNode = xmlParser.GetSingleNode(node, "right-pad");
                if (chartNode != null)
                    chart.RightPad = Int32.Parse(chartNode.InnerText);

                chart.YScaleType = (ScaleTypeEnum)Enum.Parse(typeof(ScaleTypeEnum), xmlParser.GetSingleNode("/chart-container/y-scale-type").InnerText);
                switch (chart.YScaleType)
                {
                    case ScaleTypeEnum.Screen:
                        break;
                    case ScaleTypeEnum.UserDefine:
                        strYMinValue = xmlParser.GetSingleNode(node, "/chart-container/y-min").InnerText;
                        strYMaxValue = xmlParser.GetSingleNode(node, "/chart-container/y-max").InnerText;
                        chart.YMin = float.Parse(strYMinValue);
                        chart.YMax = float.Parse(strYMaxValue);
                        break;
                    case ScaleTypeEnum.Center:
                        strPriceRange = xmlParser.GetSingleNode(node, "/chart-container/price-range").InnerText;
                        if (fLastPrice != -1)
                        {
                            chart.YMin = fLastPrice - float.Parse(strPriceRange);
                            chart.YMax = fLastPrice + float.Parse(strPriceRange);
                        }
                        break;
                }
                                
                chart.YScaleType = (ScaleTypeEnum)Enum.Parse(typeof(ScaleTypeEnum), xmlParser.GetSingleNode("/chart-container/y-scale-type").InnerText);

                iUpdateFreq = int.Parse(xmlParser.GetSingleNode(node, "update-freq").InnerText);
                chart.UpdateFreq = iUpdateFreq;
                ccChartContainer.AddChart(chart);
                indicatorList = xmlParser.GetNodes(node, "indicator");
                foreach(XmlNode indicatorNode in indicatorList)
                {                    
                    strSymbolId = xmlParser.GetSingleNode(indicatorNode, "symbol").InnerText;
                    strName = xmlParser.GetSingleNode(indicatorNode, "name").InnerText;
                    strType = xmlParser.GetSingleNode(indicatorNode, "type").InnerText;
                    strValues = xmlParser.GetSingleNode(indicatorNode, "values").InnerText.Split(',');
                    strXMin = xmlParser.GetSingleNode(indicatorNode, "custom-x-min") == null ? null : xmlParser.GetSingleNode(indicatorNode, "custom-x-min").InnerText;
                    strYMin = xmlParser.GetSingleNode(indicatorNode, "custom-y-min") == null ? null : xmlParser.GetSingleNode(indicatorNode, "custom-y-min").InnerText;
                    //strValues = xmlParser.GetSingleNode(indicatorNode, "/chart-container/chart/indicator/values").InnerText.Split(',');

                   
                    if (ccChartContainer.ContainsSymbol(strSymbolId) == false)
                        AddRecord(strSymbolId, strBarCompression, strStartDateTime, strEndDateTime);

                    indicator = CreateIndicator(strSymbolId, strName, strType, strValues);                    

                    if (strXMin != null)
                        indicator.CustomXMin = float.Parse(strXMin);

                    if (strYMin != null)
                        indicator.CustomYMin = float.Parse(strYMin);

                    chart.XDataType = indicator.XDataType;
                    chart.AddIndicator(indicator);
                }
            }
        }

        private IIndicator CreateIndicator(string strSymbolId, string strName, string strType, string[] strValues)
        {
            IIndicator indicator = null;
            try
            {
                switch ((ChartStyleEnum)Enum.Parse(typeof(ChartStyleEnum), strType))
                {
                    case ChartStyleEnum.Line:                       
                        indicator = new Line((DataTypeEnum)Enum.Parse(typeof(DataTypeEnum), strValues[0]), strName);
                        break;

                    case ChartStyleEnum.Histogram:
                        indicator = new Volume();
                        break;

                    case ChartStyleEnum.CandleStick:
                        indicator = new CandleStick(strName);
                        break;

                    case ChartStyleEnum.PriceVolume:
                        indicator = new PriceVolume(strName, strValues[0], strValues[1], strValues[2]);
                        break;

                }
                indicator.BaseStudy = strSymbolId;
            }
            catch { }

            return indicator;
        }

        private AAA.Chart.Component.ChartX CreateChart()
        {
            AAA.Chart.Component.ChartX chart = null;
            try
            {
                chart = new AAA.Chart.Component.ChartX();
                chart.AxisLineColor = Color.White;
                chart.ShowXAxis = true;
                chart.ShowHourLine(true, Color.LightGray);
                chart.ShowDayLine(true, Color.Yellow);
            }
            catch (Exception ex)
            {
            }
            return chart;
        }
    }
}
