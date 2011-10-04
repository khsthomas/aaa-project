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
using AAA.ResultSet;

namespace AAA.TradingSystem
{
    public partial class DataQueryForm : Form
    {
        public DataQueryForm()
        {
            InitializeComponent();
            InitTable();
        }

        private void InitTable()
        {
            try
            {
                tblDailyData.Columns.Add("ExDate", "交易日");
                tblDailyData.Columns.Add("OpenPrice", "開盤價");
                tblDailyData.Columns.Add("HighestPrice", "最高價");
                tblDailyData.Columns.Add("LowestPrice", "最低價");
                tblDailyData.Columns.Add("ClosePrice", "收盤價");
                tblDailyData.Columns.Add("Vol", "交易量");
                tblDailyData.Columns.Add("Amt", "交易額");
                tblDailyData.Columns.Add("PreClose", "昨日收盤價");

                tblIndicator.Columns.Add("ExDate", "交易日");
                tblIndicator.Columns.Add("MA3", "3日均價");
                tblIndicator.Columns.Add("MA6", "6日均價");
                tblIndicator.Columns.Add("MA18", "18日均價");
                tblIndicator.Columns.Add("MA72", "72日均價");
                tblIndicator.Columns.Add("VolMA3", "3日均量");
                tblIndicator.Columns.Add("VolMA6", "6日均量");
                tblIndicator.Columns.Add("VolMA18", "18日均量");
                tblIndicator.Columns.Add("Bias", "乖離值");
                tblIndicator.Columns.Add("AValue", "A值");
                tblIndicator.Columns.Add("BValue", "B值");
                tblIndicator.Columns.Add("CValue", "C值");
                tblIndicator.Columns.Add("RedValue", "紅值");
                tblIndicator.Columns.Add("BlackValue", "黑值");

                tblJoin.Columns.Add("ExDate", "交易日");
                tblJoin.Columns.Add("OpenPrice", "開盤價");
                tblJoin.Columns.Add("HighestPrice", "最高價");
                tblJoin.Columns.Add("LowestPrice", "最低價");
                tblJoin.Columns.Add("ClosePrice", "收盤價");
                tblJoin.Columns.Add("Vol", "交易量");
                tblJoin.Columns.Add("Amt", "交易額");
                tblJoin.Columns.Add("PreClose", "昨日收盤價");
                tblJoin.Columns.Add("MA3", "3日均價");
                tblJoin.Columns.Add("MA6", "6日均價");
                tblJoin.Columns.Add("MA18", "18日均價");
                tblJoin.Columns.Add("MA72", "72日均價");
                tblJoin.Columns.Add("VolMA3", "3日均量");
                tblJoin.Columns.Add("VolMA6", "6日均量");
                tblJoin.Columns.Add("VolMA18", "18日均量");
                tblJoin.Columns.Add("Bias", "乖離值");
                tblJoin.Columns.Add("AValue", "A值");
                tblJoin.Columns.Add("BValue", "B值");
                tblJoin.Columns.Add("CValue", "C值");
                tblJoin.Columns.Add("RedValue", "紅值");
                tblJoin.Columns.Add("BlackValue", "黑值");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            IniReader iniReader;
            IResultSet resultSet;
            string strStartDate;
            string strEndDate;

            string strDatabase;
            string strUsername;
            string strPassword;

            try
            {
                if (txtSymbolId.Text.Trim() == "")
                {
                    MessageBox.Show("請輸入股票代碼");
                    return;
                }

                if (txtStartDate.Text.Trim() == "")
                    strStartDate = "1900/01/01";
                else
                    strStartDate = txtStartDate.Text;

                if (txtEndDate.Text.Trim() == "")
                    strEndDate = DateTime.Now.ToString("yyyy/MM/dd");
                else
                    strEndDate = txtEndDate.Text;

                iniReader = new IniReader(Environment.CurrentDirectory + @"\cfg\system.ini");

                strDatabase = iniReader.GetParam("DataSource", "Database");
                strUsername = iniReader.GetParam("DataSource", "Username");
                strPassword = iniReader.GetParam("DataSource", "Password");

                if (strDatabase.StartsWith("."))
                    strDatabase = Environment.CurrentDirectory + strDatabase.Substring(1);

                resultSet = new DatabaseResultSet(DatabaseTypeEnum.Access, "", strDatabase, strUsername, strPassword);
                ((DatabaseResultSet)resultSet).SQLStatement = String.Format("SELECT ExDate, OpenPrice, HighestPrice, LowestPrice, ClosePrice, Vol, Amt, PreClose FROM TWSE_Stock_D_Deal WHERE SymbolId = '{0}' AND ExDate BETWEEN CDATE('{1}') AND CDATE('{2}') ORDER BY ExDate", new string[] { txtSymbolId.Text, strStartDate, strEndDate});
                resultSet.Load();

                while (tblDailyData.Rows.Count > 0)
                    tblDailyData.Rows.RemoveAt(0);

                while (resultSet.Read())
                {
                    tblDailyData.Rows.Add(new string[] {resultSet.Cells("ExDate").ToString(), 
                                                        resultSet.Cells("OpenPrice").ToString(), 
                                                        resultSet.Cells("HighestPrice").ToString(), 
                                                        resultSet.Cells("LowestPrice").ToString(), 
                                                        resultSet.Cells("ClosePrice").ToString(), 
                                                        resultSet.Cells("Vol").ToString(), 
                                                        resultSet.Cells("Amt").ToString(), 
                                                        resultSet.Cells("PreClose").ToString()});
                }

                resultSet = new DatabaseResultSet(DatabaseTypeEnum.Access, "", strDatabase, strUsername, strPassword);
                ((DatabaseResultSet)resultSet).SQLStatement = String.Format("SELECT ExDate, Index1 AS MA3, Index2 AS MA6, Index3 AS MA18, Index4 AS MA72, (Index5 / 1000) AS VolMA3, (Index6 / 1000) AS VolMA6, (Index7 / 1000) AS VolMA18, Index8 AS Bias, Index9 AS AValue, Index10 AS BValue, Index11 AS CValue, Index12 AS RedValue, Index13 AS BlackValue FROM TWSE_Stock_D_Index WHERE SymbolId = '{0}'  AND ExDate BETWEEN CDATE('{1}') AND CDATE('{2}') ORDER BY ExDate", new string[] { txtSymbolId.Text, strStartDate, strEndDate });
                resultSet.Load();

                while (tblIndicator.Rows.Count > 0)
                    tblIndicator.Rows.RemoveAt(0);

                while (resultSet.Read())
                {
                    tblIndicator.Rows.Add(new string[] {resultSet.Cells("ExDate").ToString(),                                                     
                                                        resultSet.Cells("MA3").ToString(), 
                                                        resultSet.Cells("MA6").ToString(), 
                                                        resultSet.Cells("MA18").ToString(), 
                                                        resultSet.Cells("MA72").ToString(), 
                                                        resultSet.Cells("VolMA3").ToString(), 
                                                        resultSet.Cells("VolMA6").ToString(), 
                                                        resultSet.Cells("VolMA18").ToString(), 
                                                        resultSet.Cells("Bias").ToString(), 
                                                        resultSet.Cells("AValue").ToString(), 
                                                        resultSet.Cells("BValue").ToString(), 
                                                        resultSet.Cells("CValue").ToString(), 
                                                        resultSet.Cells("RedValue").ToString(), 
                                                        resultSet.Cells("BlackValue").ToString()});
                }

                resultSet = new DatabaseResultSet(DatabaseTypeEnum.Access, "", strDatabase, strUsername, strPassword);
                ((DatabaseResultSet)resultSet).SQLStatement = String.Format("SELECT a.ExDate AS ExDate, a.OpenPrice AS OpenPrice, a.HighestPrice AS HighestPrice, a.LowestPrice AS LowestPrice, a.ClosePrice AS ClosePrice, a.Vol AS Vol, a.Amt AS Amt, a.PreClose AS PreClose, b.Index1 AS MA3, b.Index2 AS MA6, b.Index3 AS MA18, b.Index4 AS MA72, (b.Index5 / 1000) AS VolMA3, (b.Index6 / 1000) AS VolMA6, (b.Index7 / 1000) AS VolMA18, b.Index8 AS Bias, b.Index9 AS AValue, b.Index10 AS BValue, b.Index11 AS CValue, b.Index12 AS RedValue, b.Index13 AS BlackValue FROM TWSE_Stock_D_Deal a, TWSE_Stock_D_Index b WHERE a.SymbolId = b.SymbolId AND a.ExDate = b.ExDate AND a.SymbolId = '{0}'  AND a.ExDate BETWEEN CDATE('{1}') AND CDATE('{2}') ORDER BY a.ExDate", new string[] { txtSymbolId.Text, strStartDate, strEndDate });
                resultSet.Load();

                while (tblJoin.Rows.Count > 0)
                    tblJoin.Rows.RemoveAt(0);

                while (resultSet.Read())
                {
                    tblJoin.Rows.Add(new string[] {resultSet.Cells("ExDate").ToString(), 
                                                    resultSet.Cells("OpenPrice").ToString(), 
                                                    resultSet.Cells("HighestPrice").ToString(), 
                                                    resultSet.Cells("LowestPrice").ToString(), 
                                                    resultSet.Cells("ClosePrice").ToString(), 
                                                    resultSet.Cells("Vol").ToString(), 
                                                    resultSet.Cells("Amt").ToString(), 
                                                    resultSet.Cells("PreClose").ToString(),
                                                    resultSet.Cells("MA3").ToString(), 
                                                    resultSet.Cells("MA6").ToString(), 
                                                    resultSet.Cells("MA18").ToString(), 
                                                    resultSet.Cells("MA72").ToString(), 
                                                    resultSet.Cells("VolMA3").ToString(), 
                                                    resultSet.Cells("VolMA6").ToString(), 
                                                    resultSet.Cells("VolMA18").ToString(), 
                                                    resultSet.Cells("Bias").ToString(), 
                                                    resultSet.Cells("AValue").ToString(), 
                                                    resultSet.Cells("BValue").ToString(), 
                                                    resultSet.Cells("CValue").ToString(), 
                                                    resultSet.Cells("RedValue").ToString(), 
                                                    resultSet.Cells("BlackValue").ToString()});
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }
    }
}
