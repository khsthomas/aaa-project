using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AAA.Database;
using AAA.Base.Util.Reader;
using System.Data.Common;
using AAA.Base.Util;
using System.IO;
using AAA.ResultSet;
using AAA.Writer;
using AAA.Writer.Format;

namespace AAA.TradingSystem
{
    public partial class ExcelExportForm : Form
    {
        public ExcelExportForm()
        {
            InitializeComponent();
            InitParam();            
        }

        private void InitParam()
        {
            IDatabase database = new AccessDatabase();
            IniReader iniReader = new IniReader(Environment.CurrentDirectory + @"\cfg\system.ini");
            string strUsername;
            string strPassword;
            string strHost;
            string strDatabase;
            string strSelectSQL;
            DbDataReader dataReader = null;
            try
            {
                strHost = iniReader.GetParam("DataSource", "Host");
                strDatabase = IOHelper.ConvertDirectory(iniReader.GetParam("DataSource", "Database"));
                strUsername = iniReader.GetParam("DataSource", "Username");
                strPassword = iniReader.GetParam("DataSource", "Password");
                database.Open(strDatabase, strUsername, strPassword);

                strSelectSQL = "SELECT MIN(ExDate) AS MinDate, MAX(ExDate) AS MaxDate FROM TWSE_Stock_D_Deal ";

                dataReader = database.ExecuteQuery(strSelectSQL);

                while (dataReader.Read())
                {
                    txtStartDate.Text = dataReader["MinDate"].ToString();
                    txtEndDate.Text = dataReader["MaxDate"].ToString();
                }
                dataReader.Close();

                strSelectSQL = "SELECT DISTINCT GroupId FROM UserDefineSymbol ";

                dataReader = database.ExecuteQuery(strSelectSQL);

                while (cboGroupId.Items.Count > 0)
                    cboGroupId.Items.RemoveAt(0);


                cboGroupId.Items.Add("");
                while (dataReader.Read())
                {
                    if (dataReader["GroupId"].ToString().Trim() == "")
                        continue;

                    cboGroupId.Items.Add(dataReader["GroupId"].ToString());
                }

                if (cboGroupId.Items.Count > 0)
                    cboGroupId.SelectedIndex = 0;

                dataReader.Close();

                txtTemplateFile.Text = IOHelper.ConvertDirectory(iniReader.GetParam("DataSource", "TemplateFile"));
                txtOutputPath.Text = IOHelper.ConvertDirectory(iniReader.GetParam("DataSource", "ExportDirectory"));
                txtWorksheetName.Text = IOHelper.ConvertDirectory(iniReader.GetParam("DataSource", "WorksheetName"));
                txtHeaderRowCount.Text = IOHelper.ConvertDirectory(iniReader.GetParam("DataSource", "HeaderRowCount"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
            finally
            {
                if (dataReader != null)
                    dataReader.Close();
                database.Close();
            }
        }

        private void InitGroupId()
        {
            IDatabase database = new AccessDatabase();
            IniReader iniReader = new IniReader(Environment.CurrentDirectory + @"\cfg\system.ini");
            string strUsername;
            string strPassword;
            string strHost;
            string strDatabase;
            string strSelectSQL;
            DbDataReader dataReader = null;
            try
            {
                strHost = iniReader.GetParam("DataSource", "Host");
                strDatabase = iniReader.GetParam("DataSource", "Database");
                strUsername = iniReader.GetParam("DataSource", "Username");
                strPassword = iniReader.GetParam("DataSource", "Password");
                database.Open(Environment.CurrentDirectory + @"\stocks.mdb", strUsername, strPassword);

                strSelectSQL = "SELECT DISTINCT GroupId FROM UserDefineSymbol ";

                dataReader = database.ExecuteQuery(strSelectSQL);

                while (cboGroupId.Items.Count > 0)
                    cboGroupId.Items.RemoveAt(0);


                cboGroupId.Items.Add("");
                while (dataReader.Read())
                {
                    if (dataReader["GroupId"].ToString().Trim() == "")
                        continue;

                    cboGroupId.Items.Add(dataReader["GroupId"].ToString());
                }

                if (cboGroupId.Items.Count > 0)
                    cboGroupId.SelectedIndex = 0;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
            finally
            {
                if (dataReader != null)
                    dataReader.Close();
                database.Close();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (Directory.Exists(txtOutputPath.Text) == false)
                    Directory.CreateDirectory(txtOutputPath.Text);

                IniReader iniReader = new IniReader(Environment.CurrentDirectory + @"\cfg\system.ini");
                string strUsername;
                string strPassword;
                string strHost;
                string strDatabase;
                
                string strDealSQL = "SELECT ExDate, OpenPrice, HighestPrice, LowestPrice, ClosePrice, Vol FROM TWSE_Stock_D_Deal WHERE ExDate Between CDate('{0}') AND CDate('{1}') AND SymbolId = '{2}'";
                List<string> lstSymbolId = new List<string>();
                IWriter writer = new ExcelWriter();
                ExcelFormat excelFormat = new ExcelFormat();

                strHost = iniReader.GetParam("DataSource", "Host");
                strDatabase = IOHelper.ConvertDirectory(iniReader.GetParam("DataSource", "Database"));
                strUsername = iniReader.GetParam("DataSource", "Username");
                strPassword = iniReader.GetParam("DataSource", "Password");

                DatabaseResultSet dealResultSet = new DatabaseResultSet(DatabaseTypeEnum.Access, strHost, strDatabase, strUsername, strPassword);

                if (cboGroupId.Text == "")
                {
                    lstSymbolId.Add(txtSymbolId.Text);
                }
                else
                {
                    DatabaseResultSet symbolIdResultSet = new DatabaseResultSet(DatabaseTypeEnum.Access, strHost, strDatabase, strUsername, strPassword);
                    symbolIdResultSet.SQLStatement = string.Format("SELECT DISTINCT SymbolId FROM UserDefineSymbol WHERE GroupId = '{0}'", cboGroupId.Text);
                    symbolIdResultSet.Load();
                    while (symbolIdResultSet.Read())
                        lstSymbolId.Add(symbolIdResultSet.Cells("SymbolId").ToString());
                }

                excelFormat.IdentifyColumn = "A";
                excelFormat.StartRow = int.Parse(txtHeaderRowCount.Text) + 1;
                excelFormat.IsVisible = false;
                excelFormat.WorksheetName = txtWorksheetName.Text;

                foreach(string strSymbolId in lstSymbolId)
                {
                    dealResultSet.SQLStatement = string.Format(strDealSQL, new object[] {txtStartDate.Text, txtEndDate.Text, strSymbolId});
                    dealResultSet.Load();
                    writer.SourceFile = txtTemplateFile.Text;
                    writer.TargetFile = txtOutputPath.Text + @"\" + strSymbolId + ".xls";
                    writer.IsAppend = false;
                    writer.Write(dealResultSet, excelFormat);
                }
                MessageBox.Show("資料匯出完成!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

    }
}
