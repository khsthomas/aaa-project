using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AAA.ResultSet;
using AAA.Base.Util.Reader;
using AAA.Meta.Chart;
using AAA.TeeChart;
using System.IO;
using AAA.DesignPattern.Observer;
using AAA.Meta.Chart.Data;
using AAA.Database;
using System.Data.Common;

namespace AAA.TradingSystem
{
    public partial class KBarForm : Form, IObserver
    {
        private Dictionary<string, Dictionary<string, List<string>>> _dicActiveSeries;        
        private Dictionary<string, List<string>> _dicChartIndicator;
        private Dictionary<string, List<string>> _dicActiveChartIndicator;
        private List<string> _lstSheetName;
        private List<string> _lstDateTimeFormat;
        private List<string> _lstFileType;
        private string _strDataFolder;

        private string _strHost;
        private string _strDatabase;
        private string _strUsername;
        private string _strPassword;
        private string _strSQLStatement;
        private string _strDatabaseType;
        private int _iSkipLine;

        // Chart Panel
        private TeeChartPanel[] _cpChartPanels;
        private string[] _strDataSourceNames = {"ExcelDataSource", "TextDataSource", "DatabaseDataSource"};
        private string[] _strChartConfigs = { "excel_chart.ini", "text_chart.ini", "database_chart.ini" };
        private string[] _strActiveCharts = { "excel_active_series.ini", "text_active_series.ini", "database_active_series.ini" };

        private int _iCurrentSymbolIndex = 0;
        private List<string> _lstSymbolId;

        public KBarForm()
        {
            InitializeComponent();
            Init();
        }

        private void ResizeChartPanel()
        {
            try
            {
                cpExcel.Top = cpDatabase.Top;
                cpText.Top = cpDatabase.Top;
                cpExcel.Left = cpDatabase.Left;
                cpText.Left = cpDatabase.Left;
                cpExcel.Height = cpDatabase.Height;
                cpText.Height = cpDatabase.Height;
                cpExcel.Width = cpDatabase.Width;
                cpText.Width = cpDatabase.Width;

                cpExcel.IsShowInfoTable = cpDatabase.IsShowInfoTable;
                cpExcel.IsShowLightPane = cpDatabase.IsShowLightPane;
                cpExcel.IsShowScale = cpDatabase.IsShowScale;

                cpText.IsShowInfoTable = cpDatabase.IsShowInfoTable;
                cpText.IsShowLightPane = cpDatabase.IsShowLightPane;
                cpText.IsShowScale = cpDatabase.IsShowScale;

                cpExcel.Anchor = cpDatabase.Anchor;
                cpText.Anchor = cpDatabase.Anchor;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void Init()
        {
            IniReader iniReader = null;
            List<string> lstFieldName;
            List<string> lstTitleName;
            List<string> lstSection;
            List<string> lstColor;
            string[] strValues;
            string[] strRGBs;
            string[] strFieldNames;
            string[] strTitleNames;
            string[] strChartNames;
            string[] strChartSizes;
            string strSeriesName;            
            Color cControlLineColor;


            pnlInfo.Visible = true; // 顯示開, 高, 低, 收, 量
            pnlDataSource.Visible = false; // 顯示DataSource的選項
            cpDatabase.IsShowInfoTable = false; // 在右邊顯示資料細項
            cpDatabase.IsShowScale = false; // 顯示放大縮小按鈕
            cpDatabase.IsShowLightPane = false; // 顯示燈號
            btnConfig.Visible = false; // 顯示指標設定

            _cpChartPanels = new TeeChartPanel[] {cpExcel, cpText, cpDatabase};

            ResizeChartPanel();

            try
            {
                iniReader = new IniReader(Environment.CurrentDirectory + @"\cfg\system.ini");
                strValues = iniReader.GetParam("FileName", "Period").Split(',');
                for (int i = 0; i < strValues.Length; i++)
                    cboPeriod.Items.Add(strValues[i]);
                if (cboPeriod.Items.Count > 0)
                    cboPeriod.SelectedIndex = 1;

                _strHost = iniReader.GetParam("DataSource", "Host");
                _strDatabase = iniReader.GetParam("DataSource", "Database");
                _strUsername = iniReader.GetParam("DataSource", "Username");
                _strPassword = iniReader.GetParam("DataSource", "Password");
                _strDatabaseType = iniReader.GetParam("DataSource", "DatabaseType");
                _strSQLStatement = iniReader.GetParam("DatabaseDataSource", "DS1SQL");
                cboPeriod.Text = iniReader.GetParam("DataSource", "DefaultPeriod");

                _iSkipLine = int.Parse(iniReader.GetParam("DataSource", "SkipLine"));

                _strDataFolder = iniReader.GetParam("DataSource", "FileFolder");
                if (_strDataFolder.StartsWith("."))
                    _strDataFolder = Environment.CurrentDirectory + _strDataFolder.Substring(1);

                _lstSheetName = new List<string>();
                strValues = iniReader.GetParam("FileName", "SheetName").Split(',');
                for (int i = 0; i < strValues.Length; i++)
                    _lstSheetName.Add(strValues[i]);

                _lstDateTimeFormat = new List<string>();
                strValues = iniReader.GetParam("FileName", "DateTimeFormat").Split(',');
                for (int i = 0; i < strValues.Length; i++)
                    _lstDateTimeFormat.Add(strValues[i]);

                _lstFileType = new List<string>();
                strValues = iniReader.GetParam("DataSource", "FileType").Split(',');
                for (int i = 0; i < strValues.Length; i++)
                    _lstFileType.Add(strValues[i]);

                strValues = iniReader.GetParam("DataSource", "DataSourceType").Split(',');
                for (int i = 0; i < strValues.Length; i++)
                    cboFileType.Items.Add(strValues[i]);
                if (cboFileType.Items.Count > 0)
                    cboFileType.SelectedIndex = 2;
                    //cboFileType.SelectedIndex = 1;

                txtSymbolId.Text = iniReader.GetParam("DataSource", "DefaultSymbolId");

                if (iniReader.GetParam("DataSource", "InitSymbolIdSQL") != null)
                {
                    _iCurrentSymbolIndex = 0;
                    _lstSymbolId = new List<string>();

                    IDatabase database = new AccessDatabase();
                    database.Open(Environment.CurrentDirectory + @"\stocks.mdb", _strUsername, _strPassword);
                    string strSQL = iniReader.GetParam("DataSource", "InitSymbolIdSQL");
                    DbDataReader dataReader = database.ExecuteQuery(strSQL);
                    

                    while (dataReader.Read())
                        _lstSymbolId.Add(dataReader[0].ToString());
                }

                for (int iDataSource = 0; iDataSource < _strDataSourceNames.Length; iDataSource++)
                {
                    _cpChartPanels[iDataSource].PointPerPage = int.Parse(iniReader.GetParam("DataSource", "PointPerPage"));
                    _cpChartPanels[iDataSource].ShowVerticalCursor = true;
//                    _cpChartPanels[iDataSource].IsShowInfoTable = false;
//                    _cpChartPanels[iDataSource].IsShowScale = false;
                    _cpChartPanels[iDataSource].OnPositionChange += new PositionChangeEventHandler(OnPositionChange);
                    
                    _cpChartPanels[iDataSource].DateTimeFormat = _lstDateTimeFormat[cboPeriod.Items.IndexOf(cboPeriod.Text)];
                    // Add Series Field
                    strValues = iniReader.GetParam(_strDataSourceNames[iDataSource], "SymbolList").Split(',');

                    for (int i = 0; i < strValues.Length; i++)
                    {
                        lstFieldName = new List<string>();
                        strFieldNames = iniReader.GetParam(_strDataSourceNames[iDataSource], strValues[i]).Split(',');
                        for (int j = 0; j < strFieldNames.Length; j++)
                            lstFieldName.Add(strFieldNames[j]);
                        _cpChartPanels[iDataSource].AddSeriesField(strValues[i], lstFieldName);
                    }

                    if (iniReader.GetParam(_strDataSourceNames[iDataSource], "ExtraInfo") != null)
                    {
                        strValues = iniReader.GetParam(_strDataSourceNames[iDataSource], "ExtraInfo").Split(',');

                        for (int i = 0; i < strValues.Length; i++)
                        {
                            lstFieldName = new List<string>();
                            strFieldNames = iniReader.GetParam(_strDataSourceNames[iDataSource], strValues[i]).Split(',');
                            for (int j = 0; j < strFieldNames.Length; j++)
                                lstFieldName.Add(strFieldNames[j]);

                            lstTitleName = new List<string>();
                            if(iniReader.GetParam(_strDataSourceNames[iDataSource], strValues[i] + "Title") != null)
                                strTitleNames = iniReader.GetParam(_strDataSourceNames[iDataSource], strValues[i] + "Title").Split(',');
                            else
                                strTitleNames = iniReader.GetParam(_strDataSourceNames[iDataSource], strValues[i]).Split(',');

                            for (int j = 0; j < strTitleNames.Length; j++)
                            {
                                lstTitleName.Add(strTitleNames[j]);
                                _cpChartPanels[iDataSource].SignalInfoPane.AddTitleMapping(strTitleNames[j], strFieldNames[j]);
                            }
                            _cpChartPanels[iDataSource].AddExtraInfo(strValues[i], lstFieldName, lstTitleName);

                            if (iniReader.GetParam(_strDataSourceNames[iDataSource], "DisplayLight") != null)
                            {
                                if (iniReader.Section.IndexOf("Color") > -1)
                                {
                                    lstColor = iniReader.GetKey("Color");
                                    for (int j = 0; j < lstColor.Count; j++)
                                    {
                                        strRGBs = iniReader.GetParam("Color", lstColor[j]).Split(',');
                                        _cpChartPanels[iDataSource].SignalInfoPane.AddColorMapping(lstColor[j], Color.FromArgb(int.Parse(strRGBs[0]), int.Parse(strRGBs[1]), int.Parse(strRGBs[2])));
                                    }
                                }
                            }

/*
                            if(iniReader.GetParam(_strDataSourceNames[iDataSource], "DisplayLight") != null)
                            {                                
                                signalPane.DisplayKey = iniReader.GetParam(_strDataSourceNames[iDataSource], "DisplayLight");
                                if(((string)signalPane.DisplayKey) != strValues[i])
                                    continue;
                                for (int j = 0; j < lstTitleName.Count; j++)
                                    signalPane.AddTitle(lstTitleName[j]);

                                if (iniReader.Section.IndexOf("Color") > -1)
                                {
                                    lstColor = iniReader.GetKey("Color");
                                    for (int j = 0; j < lstColor.Count; j++)
                                    {
                                        strRGBs = iniReader.GetParam("Color", lstColor[j]).Split(',');                                        
                                        signalPane.AddColorMapping(lstColor[j], Color.FromArgb(int.Parse(strRGBs[0]), int.Parse(strRGBs[1]), int.Parse(strRGBs[2])));
                                    }
                                }
                            }
*/
                            //_cpChartPanels[iDataSource].AddSeriesField(strValues[i], lstFieldName);
                            
                        }
                    }
                }

                // Add Chart

                for (int iDataSource = 0; iDataSource < _strChartConfigs.Length; iDataSource++)
                {
                    iniReader = new IniReader(Environment.CurrentDirectory + @"\cfg\" +_strChartConfigs[iDataSource]);
                    lstSection = iniReader.Section;
                    strChartNames = iniReader.GetParam("ChartList").Split(',');
                    strChartSizes = iniReader.GetParam("ChartSize").Split(',');

                    if (iniReader.GetParam("BaseSeriesName") != null)
                        _cpChartPanels[iDataSource].BaseSeriesName = iniReader.GetParam("BaseSeriesName");

                    for (int i = 0; i < strChartNames.Length; i++)
                    {
                        _cpChartPanels[iDataSource].AddChart(strChartNames[i]);
                        
                        strValues = iniReader.GetParam(strChartNames[i]).Split(',');

                        if (iniReader.GetParam(strChartNames[i], "YAxisFormat") != null)
                            _cpChartPanels[iDataSource].SetYAxisFormat(strChartNames[i], iniReader.GetParam(strChartNames[i], "YAxisFormat"));
                        else
                            _cpChartPanels[iDataSource].SetYAxisFormat(strChartNames[i], "0.00");

                        if (iniReader.GetParam(strChartNames[i], "LabelAlignment") != null)
                            _cpChartPanels[iDataSource].SetLabelAlignment(strChartNames[i], (LabelAlignmentEnum)Enum.Parse(typeof(LabelAlignmentEnum), iniReader.GetParam(strChartNames[i], "LabelAlignment")));

                        for (int j = 0; j < strValues.Length; j++)
                        {
                            strSeriesName = lstSection.IndexOf(strValues[j]) < 0 ? "DefaultFormat" : strValues[j];
                            _cpChartPanels[iDataSource].AdddSeries(strChartNames[i],
                                                                   strValues[j],
                                                                   (ScaleTypeEnum)Enum.Parse(typeof(ScaleTypeEnum),
                                                                                             iniReader.GetParam(strSeriesName, "Scale")),
                                                                   (DataFieldTypeEnum)Enum.Parse(typeof(DataFieldTypeEnum),
                                                                                                 iniReader.GetParam(strSeriesName, "DataField")),
                                                                   (ChartStyleEnum)Enum.Parse(typeof(ChartStyleEnum),
                                                                                              iniReader.GetParam(strSeriesName, "Style")));
                            _cpChartPanels[iDataSource].SetChartSize(strChartNames[i], float.Parse(strChartSizes[i]));
                        }

                        if (iniReader.GetParam(strChartNames[i], "ControlStyle") != null)
                        {
                            strValues = iniReader.GetParam(strChartNames[i], "ControlColor").Split(',');
                            cControlLineColor = Color.FromArgb(int.Parse(strValues[0]),
                                                               int.Parse(strValues[1]),
                                                               int.Parse(strValues[2]));

                            strValues = iniReader.GetParam(strChartNames[i], "ControlValue").Split(',');
                            for (int j = 0; j < strValues.Length; j++)
                            {
                                _cpChartPanels[iDataSource].AddControlLine(strChartNames[i],
                                                                           (DirectionEnum)Enum.Parse(typeof(DirectionEnum), iniReader.GetParam(strChartNames[i], "ControlStyle")),
                                                                           float.Parse(strValues[j]),
                                                                           cControlLineColor);
                            }
                        }
                    }
                }

                MessageSubject.Instance().Subject.Attach(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void OnPositionChange(Dictionary<string, string> dicValue)
        {
            try
            {
                txtDateTime.Text = dicValue["時間"];

                if(dicValue.ContainsKey("開盤價"))
                    txtOpen.Text = dicValue["開盤價"];
                if (dicValue.ContainsKey("最高價"))
                    txtHigh.Text = dicValue["最高價"];
                if (dicValue.ContainsKey("最低價"))
                    txtLow.Text = dicValue["最低價"];
                if (dicValue.ContainsKey("收盤價"))
                    txtClose.Text = dicValue["收盤價"];

                try
                {
                    txtVolume.Text = float.Parse(dicValue["成交量"]).ToString("0");
                }
                catch
                {
                    txtVolume.Text = "";
                }
                try
                {
                    txtDiff.Text = float.Parse(dicValue["漲跌"]).ToString("0.00");
                }
                catch
                {
                    txtDiff.Text = "";
                }

                try
                {
                    txtDiffRatio.Text = float.Parse(dicValue["漲跌%"]).ToString("0.00");
                }
                catch 
                {
                    txtDiffRatio.Text = "";
                }
//                txtClose.Text = dicValue["收盤價"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private string GetFilename(string strSymbolId, string strPeriod, string strFileType)
        {
            string strFilename = null;
            string[] strFiles = Directory.GetFiles(_strDataFolder, strSymbolId + strPeriod + "*." + strFileType); 
            
            try
            {                
                Array.Sort(strFiles);
                strFilename = strFiles.Length == 0 ? null : strFiles[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }

            return strFilename;
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            if(_lstSymbolId != null)
                _iCurrentSymbolIndex = _lstSymbolId.IndexOf(txtSymbolId.Text);

            Display();
        }

        private void InitActiveChart()
        {
            IniReader iniReader = null;
            Dictionary<string, List<string>> dicActiveSeries;
            string[] strChartNames;
            string[] strExtraInfo;
            string[] strValues;

            try
            {
                // Add Active Series && ExtraInfo
                _dicActiveSeries = new Dictionary<string, Dictionary<string, List<string>>>();
                for (int iDataSource = 0; iDataSource < _strActiveCharts.Length; iDataSource++)
                {
                    iniReader = new IniReader(Environment.CurrentDirectory + @"\cfg\" + _strActiveCharts[iDataSource]);
                    dicActiveSeries = new Dictionary<string, List<string>>();
                    strChartNames = iniReader.GetParam("ChartList").Split(',');

                    for (int i = 0; i < strChartNames.Length; i++)
                    {
                        strValues = iniReader.GetParam(strChartNames[i]).Split(',');
                        dicActiveSeries.Add(strChartNames[i], new List<string>());
                        for (int j = 0; j < strValues.Length; j++)
                        {
                            _cpChartPanels[iDataSource].AddActiveSeries(strChartNames[i], strValues[j]);
                            dicActiveSeries[strChartNames[i]].Add(strValues[j]);
                        }
                    }
                    _dicActiveSeries.Add(_strDataSourceNames[iDataSource], dicActiveSeries);

                    if (iniReader.GetParam("ExtraInfo") != null)
                    {
                        strExtraInfo = iniReader.GetParam("ExtraInfo").Split(',');
                        for(int i = 0; i < strExtraInfo.Length; i++)
                        {
                            strValues = strExtraInfo[i].Split('~');
                            _cpChartPanels[iDataSource].AddActiveExtraInfo(strValues[0], strValues[1]);
                            _cpChartPanels[iDataSource].SignalInfoPane.DisplayKey = strValues[1];
                            //_cpChartPanels[iDataSource].SignalInfoPane.AddActiveTitle(strValues[1]);
                        }
                    }
                }                                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void Display()
        {
            IResultSet resultSet = null;
            InitActiveChart();
            try
            {
                switch (cboFileType.Text)
                {
                    case "Text":
                        resultSet = new TextResultSet(GetFilename(txtSymbolId.Text, cboPeriod.Text, _lstFileType[cboFileType.SelectedIndex]), '\t', false, _iSkipLine);
                        break;

                    case "Excel":
                        resultSet = new ExcelResultSet(GetFilename(txtSymbolId.Text, cboPeriod.Text, _lstFileType[cboFileType.SelectedIndex]), txtSymbolId.Text + _lstSheetName[cboPeriod.SelectedIndex]);
                        break;

                    case "Database":
                        resultSet = new DatabaseResultSet((DatabaseTypeEnum)Enum.Parse(typeof(DatabaseTypeEnum), _strDatabaseType), _strHost, _strDatabase, _strUsername, _strPassword);
                        //resultSet = new DatabaseResultSet(DatabaseTypeEnum.MSSql, _strHost, _strDatabase, _strUsername, _strPassword);
                        //resultSet = new DatabaseResultSet(DatabaseTypeEnum.Access, _strHost, _strDatabase, _strUsername, _strPassword);
                        ((DatabaseResultSet)resultSet).SQLStatement = string.Format(_strSQLStatement, txtSymbolId.Text);
                        break;
 
                }

                if (resultSet == null)
                {
                    MessageBox.Show("找不到商品資料來源");
                    return;
                }

                List<string> lstSeriesName;
                
                if (resultSet.Load() == false)
                {
                    MessageBox.Show(resultSet.ErrorMessage);
                    return;
                }

                if (resultSet.RowCount == 0)
                {
                    MessageBox.Show("查無資料");
                    return;
                }

                if(cboFileType.Text == "Database")
                    txtSymbolName.Text = resultSet.GetColumn("SymbolName")[0].ToString();

                for (int i = 0; i < resultSet.ColumnCount; i++)
                {
                    if(resultSet.ColumnNames()[i] == "ExDate")
                        resultSet.GetColumn(i).Add(DateTime.MinValue.ToString());
                    else
                        resultSet.GetColumn(i).Add("");
                }

                _cpChartPanels[cboFileType.SelectedIndex].DateTimeFormat = _lstDateTimeFormat[cboPeriod.SelectedIndex];
                foreach (string strChartName in _dicActiveSeries[_strDataSourceNames[cboFileType.SelectedIndex]].Keys)
                {
                    lstSeriesName = _dicActiveSeries[_strDataSourceNames[cboFileType.SelectedIndex]][strChartName];

                    for (int i = 0; i < lstSeriesName.Count; i++)
                        _cpChartPanels[cboFileType.SelectedIndex].ProcessResultSet(strChartName, lstSeriesName[i], resultSet);                    
                }
                _cpChartPanels[cboFileType.SelectedIndex].ProcessExtraInfo(resultSet);

                _cpChartPanels[cboFileType.SelectedIndex].Draw();
                for (int i = 0; i < _cpChartPanels.Length; i++)
                {
                    _cpChartPanels[i].Visible = (i == cboFileType.SelectedIndex);

                    if (_cpChartPanels[i].Visible)
                        _cpChartPanels[i].ScrollToMax(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        #region IObserver Members

        public void Update(object oSource, IMessageInfo miMessage)
        {
            try
            {
                switch (miMessage.MessageSubject)
                {
                    case "StockSelected":
                        txtSymbolId.Text = (string)miMessage.Message;
                        break;
                }
                Display();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }

        }

        #endregion

        private void txtSymbolId_KeyUp(object sender, KeyEventArgs e)
        {
            if (_lstSymbolId == null)
                return;

            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (_iCurrentSymbolIndex > 0)
                        _iCurrentSymbolIndex--;
                    txtSymbolId.Text = _lstSymbolId[_iCurrentSymbolIndex];
                    Display();
                    break;
                case Keys.Down:
                    if (_iCurrentSymbolIndex < _lstSymbolId.Count - 1)
                        _iCurrentSymbolIndex++;
                    txtSymbolId.Text = _lstSymbolId[_iCurrentSymbolIndex];
                    Display();
                    break;
/*
                case Keys.Return:
                    txtSymbolId.Text = _lstSymbolId[_iCurrentSymbolIndex];
                    Display();
                    break;
 */ 
            }
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            IniReader iniReader = null;
            string[] strChartList;
            string[] strIndicators;
            List<string> lstIndicator;
            
            try
            {
                _dicChartIndicator = new Dictionary<string,List<string>>();
                _dicActiveChartIndicator = new Dictionary<string, List<string>>();

                iniReader = new IniReader(Environment.CurrentDirectory + @"\cfg\" + _strChartConfigs[cboFileType.SelectedIndex]);
                strChartList = iniReader.GetParam("ChartList").Split(',');

                cboChart.Items.Clear();
                for(int i = 0; i < strChartList.Length; i++)
                {
                    cboChart.Items.Add(strChartList[i]);
                    
                    lstIndicator = new List<string>();
                    strIndicators = iniReader.GetParam(strChartList[i]).Split(',');

                    foreach(string strIndicator in strIndicators)
                        lstIndicator.Add(strIndicator);

                    _dicChartIndicator.Add(strChartList[i], lstIndicator);

                }

                iniReader = new IniReader(Environment.CurrentDirectory + @"\cfg\" + _strActiveCharts[cboFileType.SelectedIndex]);
                strChartList = iniReader.GetParam("ChartList").Split(',');

                for (int i = 0; i < strChartList.Length; i++)
                {
                    lstIndicator = new List<string>();
                    strIndicators = iniReader.GetParam(strChartList[i]).Split(',');

                    foreach (string strIndicator in strIndicators)
                        lstIndicator.Add(strIndicator);

                    _dicActiveChartIndicator.Add(strChartList[i], lstIndicator);

                }
                gbIndicatorSetup.Visible = true;

                if (cboChart.Items.Count > 0)
                    cboChart.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
                gbIndicatorSetup.Visible = false;
            }
        }

        private void cboChart_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> lstIndicator;
            try
            {
                if(_dicChartIndicator.ContainsKey(cboChart.Text) == false)
                    return;

                lstIndicator = _dicChartIndicator[cboChart.Text];
                lstSourceIndicator.Items.Clear();

                foreach(string strIndicator in lstIndicator)
                    lstSourceIndicator.Items.Add(strIndicator);

                if (_dicActiveChartIndicator.ContainsKey(cboChart.Text) == false)
                    return;

                lstIndicator = _dicActiveChartIndicator[cboChart.Text];
                lstChartIndicator.Items.Clear();

                foreach (string strIndicator in lstIndicator)
                    lstChartIndicator.Items.Add(strIndicator);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            StreamWriter sw = null;
            StreamReader sr = null;
            string strLine;
            List<string> lstParam;
            List<string> lstLine;
            List<string> lstIndicator;


            try
            {
                gbIndicatorSetup.Visible = false;

                sr = new StreamReader(Environment.CurrentDirectory + @"\cfg\" + _strActiveCharts[cboFileType.SelectedIndex]);
                lstParam = new List<string>();
                lstLine = new List<string>();

                while ((strLine = sr.ReadLine()) != null)
                {
                    lstParam.Add(strLine.Split('=')[0]);
                    lstLine.Add(strLine);
                }
                sr.Close();


                sw = new StreamWriter(Environment.CurrentDirectory + @"\cfg\" + _strActiveCharts[cboFileType.SelectedIndex] + ".tmp", false,Encoding.Default);
                for(int i = 0; i < lstParam.Count; i++)
                {
                    if (_dicActiveChartIndicator.ContainsKey(lstParam[i]))
                    {
                        lstIndicator = _dicActiveChartIndicator[lstParam[i]];
                        strLine = "";

                        foreach (string strIndicator in lstIndicator)
                            strLine += "," + strIndicator;
                        
                        if(strLine.Trim().Length > 0)
                            sw.WriteLine(lstParam[i] + "=" + strLine.Substring(1));

                    }
                    else
                    {
                        if(lstLine[i].Trim().Length > 0)
                            sw.WriteLine(lstLine[i]);
                    }
                }

                sw.Close();

                if (File.Exists(Environment.CurrentDirectory + @"\cfg\" + _strActiveCharts[cboFileType.SelectedIndex] + ".bak"))
                    File.Delete(Environment.CurrentDirectory + @"\cfg\" + _strActiveCharts[cboFileType.SelectedIndex] + ".bak");

                File.Move(Environment.CurrentDirectory + @"\cfg\" + _strActiveCharts[cboFileType.SelectedIndex], Environment.CurrentDirectory + @"\cfg\" + _strActiveCharts[cboFileType.SelectedIndex] + ".bak");
                File.Move(Environment.CurrentDirectory + @"\cfg\" + _strActiveCharts[cboFileType.SelectedIndex] + ".tmp", Environment.CurrentDirectory + @"\cfg\" + _strActiveCharts[cboFileType.SelectedIndex]);
                 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
            finally
            {
                if (sr != null)
                    sr.Close();

                if (sw != null)
                    sw.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                gbIndicatorSetup.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstSourceIndicator.SelectedIndex < 0)
                    return;

                if (lstChartIndicator.Items.IndexOf(lstSourceIndicator.Items[lstSourceIndicator.SelectedIndex]) > -1)
                    return;

                lstChartIndicator.Items.Add(lstSourceIndicator.SelectedItem);
                _dicActiveChartIndicator[cboChart.Text].Add(lstSourceIndicator.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstChartIndicator.SelectedIndex < 0)
                    return;

                _dicActiveChartIndicator[cboChart.Text].Remove(lstChartIndicator.SelectedItem.ToString());
                lstChartIndicator.Items.Remove(lstChartIndicator.SelectedItem);                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void txtDateTime_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Left:
                        _cpChartPanels[cboFileType.SelectedIndex].MoveLeft();
/*
                        for (int i = 0; i < _cpChartPanels.Length; i++)
                            try
                            {
                                _cpChartPanels[i].MoveLeft();                                
                            }
                            catch { }
 */ 
                        break;
                    case Keys.Right:
                        _cpChartPanels[cboFileType.SelectedIndex].MoveRight();
/*
                        for (int i = 0; i < _cpChartPanels.Length; i++)
                            try
                            {
                                _cpChartPanels[i].MoveRight();
                            }
                            catch { }
 */ 
                        break;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }


    }
}
