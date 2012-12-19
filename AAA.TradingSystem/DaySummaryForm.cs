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
using AAA.Forms.Components.Util;
using AAA.Base.Util;

namespace AAA.TradingSystem
{
    public partial class DaySummaryForm : Form
    {
        private IDatabase _databaseQuery;

        public DaySummaryForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            

            txtStartDate.Text = DateTime.Now.AddDays(-7).ToString("yyyy/MM/dd");
            txtEndDate.Text = DateTime.Now.ToString("yyyy/MM/dd");


            tblTechSummary.Columns.Add("ExDate", "日期");
            //tblTechSummary.Columns.Add("TotalCount", "總股數");
            tblTechSummary.Columns.Add("Highest20", "創20日新高股數");
            tblTechSummary.Columns.Add("Lowest20", "創20日新低股數");
            tblTechSummary.Columns.Add("Demand", "價量齊揚股數");
            tblTechSummary.Columns.Add("AntiDemand", "價量齊跌股數");
            tblTechSummary.Columns.Add("PosBias20", "站上20均線股數");
            tblTechSummary.Columns.Add("NegBias20", "跌破20均線股數");
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            IniReader iniReader = new IniReader(Environment.CurrentDirectory + @"\cfg\system.ini");
            string strDatabase = iniReader.GetParam("DataSource", "Database");
            string strUsername = iniReader.GetParam("DataSource", "Username");
            string strPassword = iniReader.GetParam("DataSource", "Password");

            if (strDatabase.StartsWith("."))
                strDatabase = Environment.CurrentDirectory + strDatabase.Substring(1);

            _databaseQuery = new AccessDatabase();
            _databaseQuery.Open(strDatabase, strUsername, strPassword);

            string strSummarySQL = "SELECT a.ExDate, COUNT(*) AS TotalCount, " +
                                   "                 SUM(a.Index26) AS Highest20, " +
                                   "                 SUM(a.Index27) AS Lowest20, " +
                                   "                 SUM(a.Index28) AS Demand20, " +
                                   "                 SUM(a.Index30) AS AntiDemand20, " +
                                   "                 SUM(a.Index29) AS PosBias20, " +
                                   "                 SUM(a.Index31) AS NegBias20 " +
                                   "  FROM TWSE_Stock_D_Index a " +
                                   " WHERE a.ExDate BETWEEN CDATE('{0}') AND CDATE('{1}') " +
                                   "   AND a.SymbolId IN (SELECT SymbolId FROM SymbolProfile b" +
                                   "   WHERE b.MarketPlace = '上市' " +
                                   "   AND b.Industral <> '指數') " +
                                   " GROUP BY a.ExDate ";

            List<string> lstDate = new List<string>();

            DbDataReader dataReader = null;

            dataReader = _databaseQuery.ExecuteQuery(strSummarySQL, new string[] {txtStartDate.Text, txtEndDate.Text});
            while(dataReader.Read())
            {
                DataGridViewUtil.InsertRow(tblTechSummary,
                               new object[] { DateTime.Parse(dataReader["ExDate"].ToString()).ToString("yyyy/MM/dd"), 
//                                              dataReader["TotalCount"], 
                                              dataReader["Highest20"], 
                                              dataReader["Lowest20"], 
                                              dataReader["Demand20"], 
                                              dataReader["AntiDemand20"], 
                                              dataReader["PosBias20"],
                                              dataReader["NegBias20"],
                                              "0"});
            }
            dataReader.Close();
            _databaseQuery.Close();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelHelper.DataGridViewToExcel(tblTechSummary);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }
    }
}
