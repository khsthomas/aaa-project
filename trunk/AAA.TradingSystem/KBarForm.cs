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
            List<string> lstSection;
            string[] strValues;
            string[] strFieldNames;
            string[] strChartNames;
            string[] strChartSizes;
            string strSeriesName;            
            Color cControlLineColor;
            Dictionary<string, List<string>> dicActiveSeries;

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
                _strSQLStatement = iniReader.GetParam("DatabaseDataSource", "DS1SQL");                

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

                // Add Active Series
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
                }
                MessageSubject.Instance().Subject.Attach(this);
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
            Display();
        }

        private void Display()
        {
            try
            {

                IResultSet resultSet = null;

                switch (cboFileType.Text)
                {
                    case "Text":
                        resultSet = new TextResultSet(GetFilename(txtSymbolId.Text, cboPeriod.Text, _lstFileType[cboFileType.SelectedIndex]), '\t');
                        break;

                    case "Excel":
                        resultSet = new ExcelResultSet(GetFilename(txtSymbolId.Text, cboPeriod.Text, _lstFileType[cboFileType.SelectedIndex]), txtSymbolId.Text + _lstSheetName[cboPeriod.SelectedIndex]);
                        break;

                    case "Database":
                        resultSet = new DatabaseResultSet(DatabaseTypeEnum.MSSql, _strHost, _strDatabase, _strUsername, _strPassword);
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
                _cpChartPanels[cboFileType.SelectedIndex].Draw();
                for (int i = 0; i < _cpChartPanels.Length; i++)
                {
                    _cpChartPanels[i].Visible = (i == cboFileType.SelectedIndex);
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
