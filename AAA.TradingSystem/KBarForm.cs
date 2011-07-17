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

namespace AAA.TradingSystem
{
    public partial class KBarForm : Form, IObserver
    {
        private Dictionary<string, Dictionary<string, List<string>>> _dicActiveSeries;        
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

        public KBarForm()
        {
            InitializeComponent();
            Init();
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


            pnlInfo.Visible = true;
            pnlDataSource.Visible = false;
            _cpChartPanels = new TeeChartPanel[] {cpExcel, cpText, cpDatabase};            

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

                txtSymbolId.Text = iniReader.GetParam("DataSource", "DefaultSymbolId");

                for (int iDataSource = 0; iDataSource < _strDataSourceNames.Length; iDataSource++)
                {
                    _cpChartPanels[iDataSource].PointPerPage = int.Parse(iniReader.GetParam("DataSource", "PointPerPage"));
                    _cpChartPanels[iDataSource].ShowVerticalCursor = true;
                    _cpChartPanels[iDataSource].IsShowInfoTable = false;
                    _cpChartPanels[iDataSource].IsShowScale = false;
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
                                lstTitleName.Add(strTitleNames[j]);
                            _cpChartPanels[iDataSource].AddExtraInfo(strValues[i], lstFieldName, lstTitleName);                                                        

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

                    for (int i = 0; i < strChartNames.Length; i++)
                    {
                        _cpChartPanels[iDataSource].AddChart(strChartNames[i]);

                        strValues = iniReader.GetParam(strChartNames[i]).Split(',');

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
                txtOpen.Text = dicValue["開盤價"];
                txtHigh.Text = dicValue["最高價"];
                txtLow.Text = dicValue["最低價"];
                txtClose.Text = dicValue["收盤價"];
                txtVolume.Text = dicValue["成交量"];
                txtDiff.Text = float.Parse(dicValue["漲跌"]).ToString("0.00");
                txtDiffRatio.Text = float.Parse(dicValue["漲跌%"]).ToString("0.00");
//                txtClose.Text = dicValue["收盤價"];
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message + "," + ex.StackTrace);
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


    }
}
