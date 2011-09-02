using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AAA.ResultSet;
using System.IO;
using AAA.Base.Util.Reader;
using AAA.TradingSystem.Indicator;

namespace AAA.TradingSystem
{
    public partial class DataTransferForm : Form
    {
        private const int INDICATOR_COUNT = 10;        

        public DataTransferForm()
        {
            InitializeComponent();
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            IResultSet sourceExcel = null;
            string[] strFiles;
            IniReader iniReader;
            string[] strPeriods;
            string[] strSheetNames;
            string strSheetName = "";
            string strPeriod = "";
            int iStartIndex = 0;
            StreamWriter sw = null;
            List<string> lstField;
            string strLine;
            string[] strRawFields;
            string[] strIndicators;
            string[] strRemarks;
            string[] strValues;
            string strExportFile;
            List<string[]> lstResult;
            List<AbstractIndicator> lstIndicator;
            AbstractIndicator indicator;            

            try
            {                
                if (txtSourceDirectory.Text.Trim() == "")
                {
                    MessageBox.Show("請輸入Excel來源目錄");
                    return;
                }

                if (txtDestinationDirectory.Text.Trim() == "")
                {
                    MessageBox.Show("請輸入Text輸出目錄");
                    return;
                }

                lstIndicator = new List<AbstractIndicator>();                                

                iniReader = new IniReader(Environment.CurrentDirectory + @"\cfg\system.ini");
                strPeriods = iniReader.GetParam("FileName", "Period").Split(',');
                strSheetNames = iniReader.GetParam("FileName", "SheetName").Split(',');

                strRawFields = iniReader.GetParam("TextDataSource", "SymbolList").Split(',');
                strIndicators = iniReader.GetParam("TextDataSource", "IndicatorExtraTitle").Split(',');                

                strValues = new string[strRawFields.Length + 1 + strIndicators.Length * 11]; // One Indicator has 10 remarks.

                strFiles = Directory.GetFiles(txtSourceDirectory.Text);

                // Create Indicator
                indicator = new MACross();
                lstIndicator.Add(indicator);
                indicator.RawDataCount = strRawFields.Length;
                indicator.IndicatorCount = strIndicators.Length;

                indicator = new MAArrange();
                lstIndicator.Add(indicator);
                indicator.RawDataCount = strRawFields.Length;
                indicator.IndicatorCount = strIndicators.Length;

                indicator = new KDCross();
                lstIndicator.Add(indicator);
                indicator.RawDataCount = strRawFields.Length;
                indicator.IndicatorCount = strIndicators.Length;


                lstField = new List<string>();
                foreach (string strField in strIndicators)
                    lstField.Add(strField);

                foreach (string strFile in strFiles)
                {
                    if (strFile.EndsWith("xls") == false)
                        continue;

                    for (int i = 0; i < strPeriods.Length; i++)
                        if ((iStartIndex = strFile.IndexOf(strPeriods[i])) > -1)
                        {
                            strSheetName = strSheetNames[i];
                            strPeriod = strPeriods[i];
                            break;
                        }

                    strExportFile = strFile.Substring(strFile.LastIndexOf('\\') + 1);
                    strExportFile = strExportFile.Substring(0, strExportFile.IndexOf(strPeriod) + strPeriod.Length);
                    sw = new StreamWriter(txtDestinationDirectory.Text + @"\" + strExportFile + ".txt");

                    sourceExcel = new ExcelResultSet(strFile, strFile.Substring(strFile.LastIndexOf('\\') + 1, iStartIndex - strFile.LastIndexOf('\\') - 1) + strSheetName);
                    sourceExcel.Load();

                    lstResult = new List<string[]>();

                    while (sourceExcel.Read())
                    {
                        strValues = new string[strValues.Length];
                        strValues[0] = sourceExcel.Cells("日期").ToString();

                        for (int i = 0; i < strRawFields.Length; i++)
                        {
                            strValues[i + 1] = sourceExcel.Cells(strRawFields[i]).ToString();
                        }

                        for (int i = strRawFields.Length; i < strValues.Length; i++)
                            strValues[i] = "0";

                        lstResult.Add(strValues);
                    }

                    for (int i = 0; i < lstIndicator.Count; i++)
                        lstIndicator[i].Calculate(i, lstField, lstResult);

                    // Header Line1
                    strLine = "X-axis";
                    for (int i = 1; i < strRawFields.Length; i++)
                        strLine += "\tDATA" + i.ToString("00");
                    for (int i = 0; i < strIndicators.Length; i++)
                        strLine += "\tindicator" + (i + 1).ToString("00");
                    for (int i = 0; i < strIndicators.Length; i++)
                        for(int j = 0; j < 10; j++)
                            strLine += "\tDATA" + (i + 1).ToString("00");
                    sw.WriteLine(strLine);

                    // Header Line2
                    strLine = "time";
                    for (int i = 0; i < strRawFields.Length; i++)
                        strLine += "\t" + strRawFields[i];
                    sw.WriteLine(strLine);

                    // Header Line3
                    strLine = "y axis";
                    for (int i = 1; i < strRawFields.Length; i++)
                        strLine += "\tauto";
                    sw.WriteLine(strLine);

                    // Header Line4
                    strLine = "y level";
                    for (int i = 1; i < strRawFields.Length; i++)
                        strLine += "\tyes";
                    sw.WriteLine(strLine);

                    // Header Line5
                    strLine = "y height";
                    for (int i = 1; i < strRawFields.Length; i++)
                        strLine += "\t100";
                    sw.WriteLine(strLine);

                    for (int i = 0; i < lstResult.Count; i++)
                    {
                        strLine = "";
                        for (int j = 0; j < lstResult[i].Length; j++)                        
                            strLine = strLine + "\t" + lstResult[i][j];
                        sw.WriteLine(strLine.Substring(1));
                    }
                }

                MessageBox.Show("轉換完畢");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
            finally
            {
                if (sw != null)
                    sw.Close();
            }
        }
    }
}
