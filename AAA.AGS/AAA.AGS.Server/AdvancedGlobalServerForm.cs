using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AAA.Base.Util.Reader;
using AAA.AGS.DataSource;
using System.Reflection;
using System.Threading;
using AAA.Base.Util.WCF;
using System.ServiceModel;
using AAA.Meta.Quote.Data;
using AAA.AGS.DataStore.Writer;
using System.Xml;

namespace AAA.AGS.Server
{
    public partial class AdvancedGlobalServerForm : Form
    {
        private const int SYMBOL_ID = 0;
        private const int LAST_UPDATE_TIME = 1;

        private readonly string[] SYMBOL_MONITOR_HEADER = { "Symbol", "Status", "Last Update", "D1", "D2", "D3", "D4", "D5", "D6" };
        private List<IDataSource> _lstDataSource;
        private List<IDataReporter> _lstDataReporter;
        private List<string> _lstSymbol;
        private Dictionary<string, QuoteData> _dicDataSnapshot;
        private ServiceHost _serviceHost;
        private bool _isStartQuote;
        private int _iRequestInterval;
        private Thread _quoteThread;

        public AdvancedGlobalServerForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            _iRequestInterval = 500;
            InitTableHeader();
            //InitSymbolIni();
            //InitFileReader();
            InitSymbol();
            InitWCFServer();            
        }      

        private void InitWCFServer()
        {
            IniReader iniReader = new IniReader(Environment.CurrentDirectory + @"\config\system.ini");
            string strUrl = iniReader.GetParam("Host");

            Uri address = new Uri(strUrl);           
            System.ServiceModel.Channels.Binding binding = WCFUtil.CreateBinding(strUrl.Split(':')[0]);
            
            
            _serviceHost = new ServiceHost(typeof(AAA.AGS.Service.DefaultQuoteService), address);
            _serviceHost.AddServiceEndpoint(typeof(AAA.AGS.Service.IQuoteService), binding, address);
            _serviceHost.Open();

         
        }

        private void InitTableHeader()
        {
            foreach (string strHeader in SYMBOL_MONITOR_HEADER)
                tblSymbolMonitor.Columns.Add(strHeader, strHeader);
        }

        private void OnDataReceive(object oData)
        {
            try
            {
                string[] strItems = (string[])oData;
                TickInfo tickInfo = new TickInfo();
                QuoteData quoteData = new QuoteData();

                quoteData.SymbolId = strItems[SYMBOL_ID];
                quoteData.LastUpdateTime = strItems[LAST_UPDATE_TIME];
                quoteData.Items = new string[strItems.Length - 2];
                Array.Copy(strItems, 2, quoteData.Items, 0, quoteData.Items.Length);

                tickInfo.Data = quoteData;
                tickInfo.Id = quoteData.SymbolId;
                tickInfo.Ticks = DateTime.Now.Ticks;

                foreach (IDataReporter dataReport in _lstDataReporter)
                    dataReport.Report(tickInfo);

                //AAA.AGS.DataStore.DataTable.Instance().SetSymbolSnapshot(tickInfo.Id, tickInfo);

                if (tblSymbolMonitor.InvokeRequired)
                {
                    tblSymbolMonitor.Invoke((MethodInvoker)delegate()
                    {
                        UpdateTable(strItems);
                    });                   
                }
                else
                {
                    UpdateTable(strItems);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "," + ex.StackTrace);
            }
        }

        private void UpdateTable(string[] strItems)
        {
            int iIndex;

            iIndex = _lstSymbol.IndexOf(strItems[SYMBOL_ID]);
            if (iIndex < 0)
                return;
            tblSymbolMonitor.Rows[iIndex].Cells["Last Update"].Value = strItems[LAST_UPDATE_TIME];

            for (int i = 2; i < strItems.Length; i++)
            {
                tblSymbolMonitor.Rows[iIndex].Cells[i + 1].Value = strItems[i];
            }

        }

        private void InitFileReader()
        {
            IDataSource dataSource;
            IRTDataSource realtimeDataSource = null;
            IHisDataSource historicalDataSource = null;
            IPriceVolumeDataSource priceVolumeDataSource = null;

            _lstDataSource = new List<IDataSource>();
            _lstSymbol = new List<string>();
            _dicDataSnapshot = new Dictionary<string, QuoteData>();

            dataSource = new DefaultDataSource();
            _lstDataSource.Add(dataSource);
            _lstSymbol.Add("TFHTX-TP");

            realtimeDataSource = new TickFileDataSource("TFHTX-TP", @"D:\20100730", new string[] { "Price", "Price", "Price", "Price", "Volume" });

            if (realtimeDataSource != null)
            {
                dataSource.RealtimeDataSource = realtimeDataSource;
                dataSource.DataReceiveEvent += new DataReceiveEvent(OnDataReceive);
                dataSource.DataStoreEvent += new DataStoreEvent(OnDataStore);
            }

            tblSymbolMonitor.Rows.Add(new string[] { "TFHTX-TP", realtimeDataSource.Status, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), "0", "0", "0", "0", "0", "0" });

            historicalDataSource = new FileDataSource(@"d:\DB\TXF_1m.txt", "TFHTX-TP", "Min_1");
            if (historicalDataSource != null)
            {
                dataSource.HistoricalDataSource = historicalDataSource;
                AAA.AGS.DataStore.HistoricalDataTable.Instance().SetDataSource("TFHTX-TP", historicalDataSource);
            }
/*
            priceVolumeDataSource = new PriceVolumeFileDataSource(@"d:\DB\TXF_1m.txt", "TFHTX-TP", "Min_1");
            if (priceVolumeDataSource != null)
            {
                dataSource.Price = priceVolumeDataSource;
                AAA.AGS.DataStore.HistoricalDataTable.Instance().SetPriceVolume("TFHTX-TP", priceVolumeDataSource);
            }
 */
        }

        private void Quote()
        {
            while (_isStartQuote)
            {
                foreach (IDataSource dataSource in _lstDataSource)
                {
                    if (dataSource.RealtimeDataSource.Status != "Connected")
                        continue;
                    dataSource.Quote();
                }
                Thread.Sleep(_iRequestInterval);
            }
        }

        private void InitSymbol()
        {
            XmlParser xmlParser = new XmlParser(Environment.CurrentDirectory + @"\config\symbol_list.xml");
            Assembly asmb;
            IDataSource dataSource;
            IRTDataSource realtimeDataSource = null;
            IHisDataSource historicalDataSource = null;
            IPriceVolumeDataSource priceVolumeDataSource = null;
            MinuteDBWriter minuteWriter;
            PriceVolumeDBWriter pvWriter;
            TickFileWriter tickWriter;
            XmlNodeList symbolList;
            XmlNode dataSourceNode;
            string strSymbolId;
            string strSymbolDesc;

            try
            {
                _lstDataSource = new List<IDataSource>();
                _lstSymbol = new List<string>();
                _dicDataSnapshot = new Dictionary<string, QuoteData>();

                minuteWriter = new MinuteDBWriter(Environment.CurrentDirectory + @"\config\" + xmlParser.GetSingleNode("/symbol-list/bar-data-writer").InnerText);
                minuteWriter.Init();
                minuteWriter.Start();

                pvWriter = new PriceVolumeDBWriter(Environment.CurrentDirectory + @"\config\" + xmlParser.GetSingleNode("/symbol-list/pv-data-writer").InnerText);
                pvWriter.Init();
                pvWriter.Start();

                try
                {
                    _iRequestInterval = int.Parse(xmlParser.GetSingleNode("/symbol-list/request-interval").InnerText);
                }
                catch { }

                symbolList = xmlParser.GetNodes("/symbol-list/symbol");

                foreach (XmlNode symbolNode in symbolList)
                {
                    strSymbolId = xmlParser.GetSingleNode(symbolNode, "symbol-id").InnerText;
                    strSymbolDesc = xmlParser.GetSingleNode(symbolNode, "symbol-desc").InnerText;

                    dataSourceNode = xmlParser.GetSingleNode(symbolNode, "real-time");
                    asmb = Assembly.LoadFrom(xmlParser.GetSingleNode(dataSourceNode, "dll").InnerText);
                    dataSource = new DefaultDataSource();
                    _lstDataSource.Add(dataSource);
                    _lstSymbol.Add(strSymbolId);

                    switch (xmlParser.GetSingleNode(dataSourceNode, "init-type").InnerText)
                    {
                        case "DDE":
                            realtimeDataSource = InitDDE(asmb, strSymbolId, xmlParser, dataSourceNode);
                            break;
                        default:
                            break;
                    }

                    if (realtimeDataSource != null)
                    {
                        dataSource.RealtimeDataSource = realtimeDataSource;
                        dataSource.DataReceiveEvent += new DataReceiveEvent(OnDataReceive);
                        dataSource.DataStoreEvent += new DataStoreEvent(OnDataStore);
                    }

                    tblSymbolMonitor.Rows.Add(new string[] { strSymbolId, realtimeDataSource.Status, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), "0", "0", "0", "0", "0", "0" });


                    dataSourceNode = xmlParser.GetSingleNode(symbolNode, "historical-data");
                    if (dataSourceNode != null)
                    {
                        asmb = Assembly.LoadFrom(xmlParser.GetSingleNode(dataSourceNode, "dll").InnerText);

                        switch (xmlParser.GetSingleNode(dataSourceNode, "init-type").InnerText)
                        {
                            case "File":
                                historicalDataSource = InitFile(asmb, strSymbolId, xmlParser, dataSourceNode);
                                break;

                            case "DB":
                                historicalDataSource = InitDB(asmb, strSymbolId, xmlParser, dataSourceNode);
                                break;

                            default:
                                break;
                        }

                        if (historicalDataSource != null)
                        {
                            dataSource.HistoricalDataSource = historicalDataSource;
                            AAA.AGS.DataStore.HistoricalDataTable.Instance().SetDataSource(strSymbolId, historicalDataSource);
                        }
                    }

                    dataSourceNode = xmlParser.GetSingleNode(symbolNode, "price-volume-data");
                    if (dataSourceNode != null)
                    {
                        asmb = Assembly.LoadFrom(xmlParser.GetSingleNode(dataSourceNode, "dll").InnerText);

                        switch (xmlParser.GetSingleNode(dataSourceNode, "init-type").InnerText)
                        {
                            case "File":
                                priceVolumeDataSource = InitPriceVolumeFile(asmb, strSymbolId, xmlParser, dataSourceNode);
                                break;
                            case "DB":
                                priceVolumeDataSource = InitPriceVolumeDB(asmb, strSymbolId, xmlParser, dataSourceNode);
                                break;
                            default:
                                break;
                        }

                        if (priceVolumeDataSource != null)
                        {
                            dataSource.PriceVolumeDataSource = priceVolumeDataSource;
                            AAA.AGS.DataStore.HistoricalDataTable.Instance().SetPriceVolume(strSymbolId, priceVolumeDataSource);
                        }
                    }
//                    dataSource.StartReteive();
                }

                _lstDataReporter = new List<IDataReporter>();
                _lstDataReporter.Add(new DataTableReporter());

                _isStartQuote = true;
                _quoteThread = new Thread(new ThreadStart(Quote));
                _quoteThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }

        }

        private void InitSymbolIni()
        {                        
            IniReader iniReader = new IniReader(Environment.CurrentDirectory + @"\config\symbol_list.ini");
            Assembly asmb;
            IDataSource dataSource;
            IRTDataSource realtimeDataSource = null;
            IHisDataSource historicalDataSource = null;
            MinuteFileWriter minuteWriter;
            TickFileWriter tickWriter;

            _lstDataSource = new List<IDataSource>();
            _lstSymbol = new List<string>();
            _dicDataSnapshot = new Dictionary<string, QuoteData>();

            foreach (string strSection in iniReader.Section)
            {
                asmb = Assembly.LoadFrom(iniReader.GetParam(strSection, "RTDll"));
                dataSource = new DefaultDataSource();
                _lstDataSource.Add(dataSource);
                _lstSymbol.Add(strSection);

                minuteWriter = new MinuteFileWriter(strSection, @"D:\" + strSection + ".txt", true);
                minuteWriter.Start();

                tickWriter = new TickFileWriter(strSection, @"D:\" + strSection + "_Tick.txt", true);
                tickWriter.Start();

                switch (iniReader.GetParam(strSection, "RTInitType"))
                {
                    case "DDE":
                        realtimeDataSource = InitDDE(asmb, strSection, iniReader);
                        break;
                    default:
                        break;
                }

                if (realtimeDataSource != null)
                {
                    dataSource.RealtimeDataSource = realtimeDataSource;
                    dataSource.DataReceiveEvent += new DataReceiveEvent(OnDataReceive);
                    dataSource.DataStoreEvent += new DataStoreEvent(OnDataStore);
                }

                tblSymbolMonitor.Rows.Add(new string[] { strSection, realtimeDataSource.Status, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), "0", "0", "0", "0", "0", "0" });

                asmb = Assembly.LoadFrom(iniReader.GetParam(strSection, "HisDll"));
                switch (iniReader.GetParam(strSection, "HisInitType"))
                {
                    case "File":
                        historicalDataSource = InitFile(asmb, strSection, iniReader);
                        break;
                    default:
                        break;
                }

                if (historicalDataSource != null)
                {
                    dataSource.HistoricalDataSource = historicalDataSource;
                    AAA.AGS.DataStore.HistoricalDataTable.Instance().SetDataSource(strSection, historicalDataSource);
                }

            }
        }

        private void OnDataStore(object oData)
        {
            string[] strData = (string[])oData;
            QuoteData quoteData;
            try
            {                
                quoteData = new QuoteData();
                quoteData.SymbolId = strData[SYMBOL_ID];
                quoteData.LastUpdateTime = strData[LAST_UPDATE_TIME];
                quoteData.Items = new string[strData.Length - 2];
                Array.Copy(strData, 2, quoteData.Items, 0, quoteData.Items.Length);

                if (_dicDataSnapshot.ContainsKey(strData[SYMBOL_ID]))
                    _dicDataSnapshot[strData[SYMBOL_ID]] = quoteData;
                else
                    _dicDataSnapshot.Add(strData[SYMBOL_ID], quoteData);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "," + ex.StackTrace);
            }
        }

        private IRTDataSource InitDDE(Assembly asmb, string strSymbolId, XmlParser xmlParser, XmlNode xmlNode)
        {
            IRTDataSource dataSource = null;
            Type type;

            try
            {
                type = asmb.GetType(xmlParser.GetSingleNode(xmlNode, "class-name").InnerText);
                dataSource = (IRTDataSource)Activator.CreateInstance(type,
                                                                     new object[] { strSymbolId, 
                                                                                    int.Parse(xmlParser.GetSingleNode(xmlNode, "request-interval").InnerText),
                                                                                    xmlParser.GetSingleNode(xmlNode, "start-time").InnerText,
                                                                                    xmlParser.GetSingleNode(xmlNode, "end-time").InnerText,                                                                                    
                                                                                    xmlParser.GetSingleNode(xmlNode, "application").InnerText,
                                                                                    xmlParser.GetSingleNode(xmlNode, "topic").InnerText,
                                                                                    xmlParser.GetSingleNode(xmlNode, "items").InnerText.Split(','),
                                                                                    xmlParser.GetSingleNode(xmlNode, "items-cal").InnerText.Split(','),
                                                                                    xmlParser.GetSingleNode(xmlNode, "identify-field").InnerText});
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
            return dataSource;
        }


        private IRTDataSource InitDDE(Assembly asmb, string strSection, IniReader iniReader)
        {
            IRTDataSource dataSource = null;
            Type type;

            try
            {
                type = asmb.GetType(iniReader.GetParam(strSection, "RTClass"));
                dataSource = (IRTDataSource)Activator.CreateInstance(type,
                                                                   new object[] { strSection, 
                                                                                  iniReader.GetParam(strSection, "RTInterval"),
                                                                                  iniReader.GetParam(strSection, "RTStartTime"),
                                                                                  iniReader.GetParam(strSection, "RTEndTime"),
                                                                                  iniReader.GetParam(strSection, "RTApplication"),
                                                                                  iniReader.GetParam(strSection, "RTTopic"),
                                                                                  iniReader.GetParam(strSection, "RTItems").Split(','),
                                                                                  iniReader.GetParam(strSection, "RTItemsCalculate").Split(','),
                                                                                  iniReader.GetParam(strSection, "RTIdentifyField"),});
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
            return dataSource;
        }

        private IPriceVolumeDataSource InitPriceVolumeDB(Assembly asmb, string strSymbolId, XmlParser xmlParser, XmlNode xmlNode)
        {
            IPriceVolumeDataSource dataSource = null;
            Type type;

            try
            {
                type = asmb.GetType(xmlParser.GetSingleNode(xmlNode, "class-name").InnerText);
                dataSource = (IPriceVolumeDataSource)Activator.CreateInstance(type,
                                                                        new object[] { Environment.CurrentDirectory + @"\config\" + xmlParser.GetSingleNode(xmlNode, "filename").InnerText,
                                                                                       strSymbolId});
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
            return dataSource;
        }


        private IPriceVolumeDataSource InitPriceVolumeFile(Assembly asmb, string strSymbolId, XmlParser xmlParser, XmlNode xmlNode)
        {
            IPriceVolumeDataSource dataSource = null;
            Type type;

            try
            {
                type = asmb.GetType(xmlParser.GetSingleNode(xmlNode, "class-name").InnerText);
                dataSource = (IPriceVolumeDataSource)Activator.CreateInstance(type,
                                                                        new object[] { xmlParser.GetSingleNode(xmlNode, "filename").InnerText,
                                                                                       strSymbolId});
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
            return dataSource;
        }

        private IHisDataSource InitDB(Assembly asmb, string strSymbolId, XmlParser xmlParser, XmlNode xmlNode)
        {
            IHisDataSource dataSource = null;
            Type type;

            try
            {
                type = asmb.GetType(xmlParser.GetSingleNode(xmlNode, "class-name").InnerText);
                dataSource = (IHisDataSource)Activator.CreateInstance(type,
                                                                        new object[] { Environment.CurrentDirectory + @"\config\" + xmlParser.GetSingleNode(xmlNode, "filename").InnerText,
                                                                                       strSymbolId,
                                                                                       xmlParser.GetSingleNode(xmlNode, "compression").InnerText});
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
            return dataSource;
        }


        private IHisDataSource InitFile(Assembly asmb, string strSymbolId, XmlParser xmlParser, XmlNode xmlNode)
        {
            IHisDataSource dataSource = null;
            Type type;

            try
            {
                type = asmb.GetType(xmlParser.GetSingleNode(xmlNode, "class-name").InnerText);
                dataSource = (IHisDataSource)Activator.CreateInstance(type,
                                                                        new object[] { xmlParser.GetSingleNode(xmlNode, "filename").InnerText,
                                                                                       strSymbolId,
                                                                                       xmlParser.GetSingleNode(xmlNode, "compression").InnerText});
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
            return dataSource;
        }

        private IHisDataSource InitFile(Assembly asmb, string strSection, IniReader iniReader)
        {
            IHisDataSource dataSource = null;
            Type type;

            try
            {
                type = asmb.GetType(iniReader.GetParam(strSection, "HisClass"));
                dataSource = (IHisDataSource)Activator.CreateInstance(type,
                                                                   new object[] { iniReader.GetParam(strSection, "HisFilename"),
                                                                                  strSection,
                                                                                  iniReader.GetParam(strSection, "HisCompression")});
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
            return dataSource;
        }


        private void tblSymbolMonitor_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= tblSymbolMonitor.Rows.Count)
                return;

            if (tblSymbolMonitor.Rows[e.RowIndex].Cells["Status"].Value.ToString() != "Connected")
                _lstDataSource[e.RowIndex].StartReteive();
            
            if (tblSymbolMonitor.Rows[e.RowIndex].Cells["Status"].Value.ToString() == "Connected")
                _lstDataSource[e.RowIndex].StopReteive();
            
            tblSymbolMonitor.Rows[e.RowIndex].Cells["Status"].Value = _lstDataSource[e.RowIndex].RealtimeDataSource.Status;
            
        }

        private void AdvancedGlobalServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                _isStartQuote = false;
                _quoteThread.Abort();
                _serviceHost.Abort();
                _serviceHost.Close();

                foreach (IDataSource dataSource in _lstDataSource)
                    dataSource.StopReteive();
                //Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }
    }
}
