using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AAA.ResultSet;
using AAA.Database;
using AAA.Base.Util.Reader;
using AAA.Meta.Quote.Data;
using AAA.Meta;
using AAA.DesignPattern.Observer;

namespace AAA.TradingSystem
{
    public partial class BasicDataGetterForm : Form
    {
        public BasicDataGetterForm()
        {
            InitializeComponent();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            IResultSet resultSet;
            IniReader iniReader;
            IDatabase database = new AccessDatabase();
            string strDatabase;
            string strUsername;
            string strPassword;
            string strInsertSQL;
            string strUpdateSQL;

            string strSymbolId; //股票代碼
            //除權息資料
            string strExRightDate; //除權日
            string strExDividendDate; //除息日
            string strProfitPlacing; //盈餘配股
            string strReservePlacing; //公積配股
            string strCashDividend; //現金股利

            //股東會資料
            string strMeetingDate; //股東會日期
            string strDirectorElection; //是否董監改選
            string strLastBuyBackDate; //融券最後回補日
            string strStopLoanStartDate; //停券日開始
            string strStopLoanEndDate; //停券日結束
            string strStopMarginStartDate; //停資日開始
            string strStopMarginEndDate; //停資日結束
            string strStopTransferStartDate; //停止過戶日開始
            string strStopTransferEndDate; //停止過戶日結束
            string strLastTransferDate; //最後過戶日

            try
            {
                iniReader = new IniReader(Environment.CurrentDirectory + @"\cfg\system.ini");
                strDatabase = iniReader.GetParam("DataSource", "Database").StartsWith(".")
                                ? Environment.CurrentDirectory + iniReader.GetParam("DataSource", "Database").Substring(1)
                                : iniReader.GetParam("DataSource", "Database");
                strUsername = iniReader.GetParam("DataSource", "Username");
                strPassword = iniReader.GetParam("DataSource", "Password");

                if (database.Open(strDatabase, strUsername, strPassword) == false)
                {
                    MessageBox.Show(database.ErrorMessage);
                    return;
                }
                strInsertSQL = "INSERT INTO TWSE_Stock_Dividend(ProfitPlacing, ReservePlacing, CashDividend, SymbolId, ExRightDate, ExDividendDate) VALUES({0}, {1}, {2}, '{3}', '{4}', '{5}')";
                strUpdateSQL = "UPDATE TWSE_Stock_Dividend SET ProfitPlacing = {0}, ReservePlacing = {1}, CashDividend = {2} WHERE SymbolId = '{3}' AND ExRightDate = '{4}' AND ExDividendDate = '{5}'";
/*
                resultSet = new ExcelResultSet(Environment.CurrentDirectory + @"\除權息表.xls", "除權息表");
                if (resultSet.Load() == false)
                {
                    MessageBox.Show(resultSet.ErrorMessage);
                    return;
                }
                
                while (resultSet.Read())
                {
                    strSymbolId = resultSet.Cells("股票").ToString().Split(' ')[0];
                    strExRightDate = resultSet.Cells("除權日").ToString();
                    strExDividendDate = resultSet.Cells("除息日").ToString();
                    strProfitPlacing = resultSet.Cells("盈餘配股(元)").ToString();
                    strReservePlacing = resultSet.Cells("公積配股(元)").ToString();
                    strCashDividend = resultSet.Cells("現金股利(元)").ToString();

                    if (database.ExecuteUpdate(strInsertSQL, new string[] { (strProfitPlacing.Trim() == "" ? "0" : strProfitPlacing),
                                                                            (strReservePlacing.Trim() == "" ? "0" : strReservePlacing),
                                                                            (strCashDividend.Trim() == "" ? "0" : strCashDividend),
                                                                            strSymbolId,
                                                                            strExRightDate,
                                                                            strExDividendDate}) != 1)
                        if (database.ExecuteUpdate(strUpdateSQL, new string[] { (strProfitPlacing.Trim() == "" ? "0" : strProfitPlacing),
                                                                            (strReservePlacing.Trim() == "" ? "0" : strReservePlacing),
                                                                            (strCashDividend.Trim() == "" ? "0" : strCashDividend),
                                                                            strSymbolId,
                                                                            strExRightDate,
                                                                            strExDividendDate}) != 1)
                            MessageBox.Show(database.ErrorMessage);

                }
*/

                strInsertSQL = "INSERT INTO TWSE_Shareholder_Meeting_Date(DirectorElection, LastBuyBackDate, StopLoanStartDate, StopLoanEndDate, StopMarginStartDate, StopMarginEndDate, StopTransferStartDate, StopTransferEndDate, LastTransferDate, SymbolId, MeetingDate) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}')";
                strUpdateSQL = "UPDATE TWSE_Shareholder_Meeting_Date SET DirectorElection = '{0}', LastBuyBackDate = '{1}', StopLoanStartDate = '{2}', StopLoadEndDate = '{3}', StopMarginStartDate = '{4}', StopMarginEndDate = '{5}', StopTransferStartDate = '{6}', StopTransferEndDate = '{7}', LastTransferDate = '{8}' WHERE SymbolId = '{9}' AND MeetingDate = '{10}'";

                resultSet = new ExcelResultSet(Environment.CurrentDirectory + @"\除權息表.xls", "股東會表", true, true);
                if (resultSet.Load() == false)
                {
                    MessageBox.Show(resultSet.ErrorMessage);
                    return;
                }

                while (resultSet.Read())
                {
                    strSymbolId = resultSet.Cells("股票").ToString().Split(' ')[0];
                    strMeetingDate = resultSet.Cells("日期").ToString();
                    strDirectorElection = resultSet.Cells("董監改選").ToString().Trim() == "無" ? "N" : "Y";
                    strLastBuyBackDate = resultSet.Cells("融券最後回補日").ToString().Trim() == "" ? "1900/01/01 00:00:00" : resultSet.Cells("融券最後回補日").ToString();
                    strStopLoanStartDate = resultSet.Cells("停券日").ToString().Trim() == "" ? "1900/01/01 00:00:00" : resultSet.Cells("停券日").ToString().Substring(1).Trim() + " 00:00:00";
                    strStopMarginStartDate = resultSet.Cells("停資日").ToString().Trim() == "" ? "1900/01/01 00:00:00" : resultSet.Cells("停資日").ToString().Substring(1).Trim() + " 00:00:00";
                    strStopTransferStartDate = resultSet.Cells("停止過戶").ToString().Trim() == "" ? "1900/01/01 00:00:00" : resultSet.Cells("停止過戶").ToString().Substring(1).Trim() + " 00:00:00";
                    strLastTransferDate = resultSet.Cells("最後過戶日").ToString().Trim() == "" ? "1900/01/01 00:00:00" : resultSet.Cells("最後過戶日").ToString().Trim();

                    if (resultSet.Read() == false)
                        break;

                    while (resultSet.Cells("股票").ToString().Trim() != "")
                    {
                        strStopLoanEndDate = "1900/01/01 00:00:00";
                        strStopMarginEndDate = "1900/01/01 00:00:00";
                        strStopTransferEndDate = "1900/01/01 00:00:00";

                        if (database.ExecuteUpdate(strInsertSQL, new string[] { strDirectorElection,
                                                                            strLastBuyBackDate,
                                                                            strStopLoanStartDate,
                                                                            strStopLoanEndDate,
                                                                            strStopMarginStartDate,
                                                                            strStopMarginEndDate,
                                                                            strStopTransferStartDate,
                                                                            strStopTransferEndDate,
                                                                            strLastTransferDate,
                                                                            strSymbolId,
                                                                            strMeetingDate}) != 1)
/*
                            if (database.ExecuteUpdate(strUpdateSQL, new string[] { strDirectorElection,
                                                                            strLastBuyBackDate,
                                                                            strStopLoanStartDate,
                                                                            strStopLoanEndDate,
                                                                            strStopMarginStartDate,
                                                                            strStopMarginEndDate,
                                                                            strStopTransferStartDate,
                                                                            strStopTransferEndDate,
                                                                            strLastTransferDate,
                                                                            strSymbolId,
                                                                            strMeetingDate}) != 1)
 */ 
                                MessageBox.Show(database.ErrorMessage);


                        strSymbolId = resultSet.Cells("股票").ToString().Split(' ')[0];
                        strMeetingDate = resultSet.Cells("日期").ToString();
                        strDirectorElection = resultSet.Cells("董監改選").ToString().Trim() == "無" ? "N" : "Y";
                        strLastBuyBackDate = resultSet.Cells("融券最後回補日").ToString().Trim() == "" ? "1900/01/01 00:00:00" : resultSet.Cells("融券最後回補日").ToString();
                        strStopLoanStartDate = resultSet.Cells("停券日").ToString().Trim() == "" ? "1900/01/01 00:00:00" : resultSet.Cells("停券日").ToString().Substring(1).Trim() + " 00:00:00";
                        strStopMarginStartDate = resultSet.Cells("停資日").ToString().Trim() == "" ? "1900/01/01 00:00:00" : resultSet.Cells("停資日").ToString().Substring(1).Trim() + " 00:00:00";
                        strStopTransferStartDate = resultSet.Cells("停止過戶").ToString().Trim() == "" ? "1900/01/01 00:00:00" : resultSet.Cells("停止過戶").ToString().Substring(1).Trim() + " 00:00:00";
                        strLastTransferDate = resultSet.Cells("最後過戶日").ToString().Trim() == "" ? "1900/01/01 00:00:00" : resultSet.Cells("最後過戶日").ToString().Trim();

                        if (resultSet.Read() == false)
                            break;
                    }

                    strStopLoanEndDate = resultSet.Cells("停券日").ToString().Trim() == "" ? "1900/01/01 00:00:00" : resultSet.Cells("停券日").ToString().Substring(1).Trim() + " 00:00:00";
                    strStopMarginEndDate = resultSet.Cells("停資日").ToString().Trim() == "" ? "1900/01/01 00:00:00" : resultSet.Cells("停資日").ToString().Substring(1).Trim() + " 00:00:00";
                    strStopTransferEndDate = resultSet.Cells("停止過戶").ToString().Trim() == "" ? "1900/01/01 00:00:00" : resultSet.Cells("停止過戶").ToString().Substring(1).Trim() + " 00:00:00";

                    if (database.ExecuteUpdate(strInsertSQL, new string[] { strDirectorElection,
                                                                            strLastBuyBackDate,
                                                                            strStopLoanStartDate,
                                                                            strStopLoanEndDate,
                                                                            strStopMarginStartDate,
                                                                            strStopMarginEndDate,
                                                                            strStopTransferStartDate,
                                                                            strStopTransferEndDate,
                                                                            strLastTransferDate,
                                                                            strSymbolId,
                                                                            strMeetingDate}) != 1)
/*
                        if (database.ExecuteUpdate(strUpdateSQL, new string[] { strDirectorElection,
                                                                            strLastBuyBackDate,
                                                                            strStopLoanStartDate,
                                                                            strStopLoanEndDate,
                                                                            strStopMarginStartDate,
                                                                            strStopMarginEndDate,
                                                                            strStopTransferStartDate,
                                                                            strStopTransferEndDate,
                                                                            strLastTransferDate,
                                                                            strSymbolId,
                                                                            strMeetingDate}) != 1)
 */ 
                            MessageBox.Show(database.ErrorMessage);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private int ProcessBackwardData(List<BarData> lstBarData, int iStartIndex, string strStartDate, string strEndDate, BarData barData)
        {
            float fOpen = float.NaN;
            float fHigh = float.NaN;
            float fLow = float.NaN;
            float fClose = float.NaN;
            string strSymbolId = null;
            int iEndIndex = iStartIndex;
            try
            {
                for (int i = iStartIndex; i < lstBarData.Count; i++)
                {
                    iEndIndex = i;
                    if (lstBarData[i].BarDateTime.ToString("yyyy/MM/dd").CompareTo(strStartDate) < 0)
                        continue;

                    if (lstBarData[i].BarDateTime.ToString("yyyy/MM/dd").CompareTo(strEndDate) >= 0)
                        break;
                    
                    if(float.IsNaN(fOpen))
                    {
                        fOpen = lstBarData[i].Open;
                        fHigh = lstBarData[i].High;
                        fLow = lstBarData[i].Low;
                        fClose = lstBarData[i].Close;
                        strSymbolId = lstBarData[i].SymbolId;
                    }

                    fHigh = Math.Max(fHigh, lstBarData[i].High);
                    fLow = Math.Min(fLow, lstBarData[i].Low);
                    fClose = lstBarData[i].Close;
                }

                barData.Open = fOpen;
                barData.High = fHigh;
                barData.Low = fLow;
                barData.Close = fClose;
                barData.SymbolId = strSymbolId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
            return iEndIndex == lstBarData.Count ? -1 : iEndIndex;
        }

        private void InitTable()
        {
            try
            {
                while (tblDividendData.Rows.Count > 0)
                    tblDividendData.Rows.RemoveAt(0);

                while (tblDividendData.Columns.Count > 0)
                    tblDividendData.Columns.RemoveAt(0);

                DividendData dividendData;                
                tblDividendData.Columns.Add("SymbolId", "股票代碼");
                tblDividendData.Columns.Add("ProfitPlacing", "盈餘配股");
                tblDividendData.Columns.Add("ReservePlacing", "公積配股");
                tblDividendData.Columns.Add("CashDividend", "現金股利");                
                tblDividendData.Columns.Add("DividendDate", "除息日");
                tblDividendData.Columns.Add("BackwardOpen", "除息前-開");
                tblDividendData.Columns.Add("BackwardHigh", "除息前-高");
                tblDividendData.Columns.Add("BackwardLow", "除息前-低");
                tblDividendData.Columns.Add("BackwardClose", "除息前-收");
                tblDividendData.Columns.Add("DividendOpen", "除息日-開");
                tblDividendData.Columns.Add("DividendHigh", "除息日-高");
                tblDividendData.Columns.Add("DividendLow", "除息日-低");
                tblDividendData.Columns.Add("DividendClose", "除息日-收");
                tblDividendData.Columns.Add("ForwardOpen", "除息後-開");
                tblDividendData.Columns.Add("ForwardHigh", "除息後-高");
                tblDividendData.Columns.Add("ForwardLow", "除息後-低");
                tblDividendData.Columns.Add("ForwardClose", "除息後-收");
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            IResultSet resultSet;            
            IniReader iniReader;
            string strDatabase;
            string strUsername;
            string strPassword;

            string strSymbolId;
            List<string> lstSymbolId;
            List<BarData> lstBarData;
            List<DividendData> lstDividendDate;
            BarData barData;
            DividendData dividendData;
            Dictionary<string, DividendData> dicDividendDate;

            string strCurrentYear;
            string strStartDate;
            string strEndDate;
            BarData backwardBar;
            BarData forwardBar;
            BarData dividendBar;

            try
            {
                InitTable();

                iniReader = new IniReader(Environment.CurrentDirectory + @"\cfg\system.ini");
                strDatabase = iniReader.GetParam("DataSource", "Database");
                strUsername = iniReader.GetParam("DataSource", "Username");
                strPassword = iniReader.GetParam("DataSource", "Password");
                
                resultSet = new DatabaseResultSet(DatabaseTypeEnum.Access, "", strDatabase, strUsername, strPassword);
                ((DatabaseResultSet)resultSet).SQLStatement = "SELECT SymbolId FROM SymbolProfile WHERE Industral <> '指數'";
                if (!resultSet.Load())
                {
                    MessageBox.Show(resultSet.ErrorMessage);
                    return;
                }

                lstSymbolId = new List<string>();
                while (resultSet.Read())
                {
                    lstSymbolId.Add(resultSet.Cells("SymbolId").ToString());
                }

                resultSet.Close();

                for(int i = 0; i < lstSymbolId.Count; i++)
                {
                    strSymbolId = lstSymbolId[i];

                    // Get Dividend Date
                    lstDividendDate = new List<DividendData>();                    
                    ((DatabaseResultSet)resultSet).SQLStatement = String.Format("SELECT ExRightDate, ExDividendDate, ProfitPlacing, ReservePlacing, CashDividend FROM TWSE_Stock_Dividend WHERE SymbolId = '{0}' ORDER BY ExDividendDate", strSymbolId);
                    if (!resultSet.Load())
                    {
                        MessageBox.Show(resultSet.ErrorMessage);
                        return;
                    }
                    dicDividendDate = new Dictionary<string, DividendData>();
                    while (resultSet.Read())
                    {
                        dividendData = new DividendData();
                        dividendData.SymbolId = strSymbolId;
                        dividendData.ExRightDate = DateTime.Parse(resultSet.Cells("ExRightDate").ToString());
                        dividendData.ExDividendDate = DateTime.Parse(resultSet.Cells("ExDividendDate").ToString());
                        dividendData.ProfitPlacing = float.Parse(resultSet.Cells("ProfitPlacing").ToString());
                        dividendData.ReservePlacing = float.Parse(resultSet.Cells("ReservePlacing").ToString());
                        dividendData.CashDividend = float.Parse(resultSet.Cells("CashDividend").ToString());
                        lstDividendDate.Add(dividendData);
                        if (dicDividendDate.ContainsKey(dividendData.ExDividendDate.ToString("yyyy")))
                            dicDividendDate[dividendData.ExDividendDate.ToString("yyyy")] = dividendData;
                        else
                            dicDividendDate.Add(dividendData.ExDividendDate.ToString("yyyy"), dividendData);
                    }
                    resultSet.Close();


                    // Get BarData                    
                    lstBarData = new List<BarData>();
                    ((DatabaseResultSet)resultSet).SQLStatement = String.Format("SELECT ExDate, OpenPrice, HighestPrice, LowestPrice, ClosePrice, Vol FROM TWSE_Stock_D_Deal WHERE SymbolId = '{0}' AND ExDate >= CDate('{1}') ORDER BY ExDate", new string[] {strSymbolId, txtStartYear.Text + "/01/01 00:00:00"});
                    if (!resultSet.Load())
                    {
                        MessageBox.Show(resultSet.ErrorMessage);
                        return;
                    }

                    while(resultSet.Read())
                    {
                        barData = new BarData();
                        barData.BarCompression = AAA.Meta.Quote.BarCompressionEnum.Daily;
                        barData.BarDateTime = DateTime.Parse(resultSet.Cells("ExDate").ToString());
                        barData.Open = float.Parse(resultSet.Cells("OpenPrice").ToString());
                        barData.High = float.Parse(resultSet.Cells("HighestPrice").ToString());
                        barData.Low = float.Parse(resultSet.Cells("LowestPrice").ToString());
                        barData.Close = float.Parse(resultSet.Cells("ClosePrice").ToString());
                        barData.Volume = float.Parse(resultSet.Cells("Vol").ToString());
                        lstBarData.Add(barData);
                    }
                    resultSet.Close();

                    // Calculate Monthly Data
                    strCurrentYear = "";
                    for (int j = 0; j < lstBarData.Count; j++)
                    {
                        if (lstBarData[j].BarDateTime.ToString("yyyy") != strCurrentYear)
                        {
                            strCurrentYear = lstBarData[j].BarDateTime.ToString("yyyy");
                            if (dicDividendDate.ContainsKey(strCurrentYear))
                            {
                                if (rbStartDate.Checked)
                                {
                                    strStartDate = strCurrentYear + "/" + dtpExportStartDate.Value.ToString("MM/dd");
                                }
                                else
                                {
                                    strStartDate = dicDividendDate[strCurrentYear].ExDividendDate.AddDays(int.Parse(txtBackDays.Text) * -1).ToString("yyyy/MM/dd");
                                }
                                strEndDate = dicDividendDate[strCurrentYear].ExDividendDate.ToString("yyyy/MM/dd");
                                backwardBar = new BarData();
                                j = ProcessBackwardData(lstBarData, j, strStartDate, strEndDate, backwardBar);

                                if (j < 0)
                                    continue;

                                dividendBar = new BarData();
                                dividendBar.Open = lstBarData[j].Open;
                                dividendBar.High = lstBarData[j].High;
                                dividendBar.Low = lstBarData[j].Low;
                                dividendBar.Close = lstBarData[j].Close;

                                strStartDate = dicDividendDate[strCurrentYear].ExDividendDate.AddDays(1).ToString("yyyy/MM/dd");
                                strEndDate = dicDividendDate[strCurrentYear].ExDividendDate.AddDays(int.Parse(txtForwardDays.Text) + 1).ToString("yyyy/MM/dd");
                                strEndDate = dicDividendDate[strCurrentYear].ExDividendDate.AddDays(int.Parse(txtForwardDays.Text) + 1).ToString("yyyy/MM/dd");
                                forwardBar = new BarData();
                                j = ProcessBackwardData(lstBarData, j, strStartDate, strEndDate, forwardBar);

                                tblDividendData.Rows.Add(new string[] {strSymbolId,
                                                                       dicDividendDate[strCurrentYear].ProfitPlacing.ToString("0.00"),
                                                                       dicDividendDate[strCurrentYear].ReservePlacing.ToString("0.00"),
                                                                       dicDividendDate[strCurrentYear].CashDividend.ToString("0.00"),
                                                                       dicDividendDate[strCurrentYear].ExDividendDate.ToString("yyyy/MM/dd"),
                                                                       backwardBar.Open.ToString(),
                                                                       backwardBar.High.ToString(),
                                                                       backwardBar.Low.ToString(),
                                                                       backwardBar.Close.ToString(),
                                                                       dividendBar.Open.ToString(),
                                                                       dividendBar.High.ToString(),
                                                                       dividendBar.Low.ToString(),
                                                                       dividendBar.Close.ToString(),
                                                                       forwardBar.Open.ToString(),
                                                                       forwardBar.High.ToString(),
                                                                       forwardBar.Low.ToString(),
                                                                       forwardBar.Close.ToString()});

                            }
                        }
                    }
                    

                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void ChangeEnabled()
        {
            if (rbStartDate.Checked == true)
            {
                dtpExportStartDate.Enabled = true;
                txtBackDays.Enabled = false;
            }
            else
            {
                dtpExportStartDate.Enabled = false;
                txtBackDays.Enabled = true;
            }

        }

        private void rbStartDate_CheckedChanged(object sender, EventArgs e)
        {
            ChangeEnabled();
        }

        private void rbBackDays_CheckedChanged(object sender, EventArgs e)
        {
            ChangeEnabled();
        }

        private void tblDividendData_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                IMessageInfo miMessage = new MessageInfo();
                miMessage.MessageTicks = DateTime.Now.Ticks;
                miMessage.MessageSubject = "StockSelected";
                miMessage.Message = tblDividendData.Rows[e.RowIndex].Cells[0].Value.ToString();
                MessageSubject.Instance().Subject.Notify(miMessage);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }
    }
}
