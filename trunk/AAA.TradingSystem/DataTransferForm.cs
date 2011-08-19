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

namespace AAA.TradingSystem
{
    public partial class DataTransferForm : Form
    {
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
            int iStartIndex = 0;
            StreamWriter sw = null;

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

                iniReader = new IniReader(Environment.CurrentDirectory + @"\cfg\system.ini");
                strPeriods = iniReader.GetParam("FileName", "Period").Split(',');
                strSheetNames = iniReader.GetParam("FileName", "SheetName").Split(',');

                strFiles = Directory.GetFiles(txtSourceDirectory.Text);

                foreach (string strFile in strFiles)
                {
                    for (int i = 0; i < strPeriods.Length; i++)
                        if ((iStartIndex = strFile.IndexOf(strPeriods[i])) > -1)
                        {
                            strSheetName = strSheetNames[i];
                            break;
                        }

                    sourceExcel = new ExcelResultSet(strFile, strFile.Substring(strFile.LastIndexOf('\\') + 1, iStartIndex - strFile.LastIndexOf('\\')) + strSheetName);
                    sourceExcel.Load();

                    while (sourceExcel.Read())
                    {

                    }

                }

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
