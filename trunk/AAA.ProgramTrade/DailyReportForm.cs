using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AAA.Trade;
using AAA.Base.Util.Reader;
using AAA.DesignPattern.Observer;
using AAA.Forms.Components.Util;
using AAA.ProgramTrade.Parser;
using AAA.ProgramTrade.Quote;
using AAA.Meta.Quote.Data;
using System.IO;
using AAA.Writer.Format;
using AAA.Writer;
using AAA.ResultSet;

namespace AAA.ProgramTrade
{
    public partial class DailyReportForm : Form, IObserver
    {
        private ITrade _autoTrade = null;
        private PolarisHistoryQuote _historyQuote = null;
        private const string MONTH = "ABCDEFGHIJKLMNOPQRSTUVWX";

        public DailyReportForm()
        {
            try
            {
                InitializeComponent();
                
                _autoTrade = (ITrade)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.AUTO_TRADE_PROGRAM];               
                _historyQuote = new PolarisHistoryQuote();                

                MessageSubject.Instance().Subject.Attach(this);
                InitTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void InitTable()
        {
            //今日權益數
            tblEquity.Columns.Add("ItemName", "項目");
            tblEquity.Columns.Add("ItemValue", "值");

            //目前部位
            tblOpenPosition.Columns.Add("code", "商品代碼");
            tblOpenPosition.Columns.Add("ord_no", "委託書號");
            tblOpenPosition.Columns.Add("ord_bs", "買賣別");
            tblOpenPosition.Columns.Add("currency", "幣別");
            tblOpenPosition.Columns.Add("vol", "口數");
            tblOpenPosition.Columns.Add("avg_price", "成交均價");

            //成交回報
            tblDeal.Columns.Add("account", "帳號");
            tblDeal.Columns.Add("ord_time", "成交日期");
            tblDeal.Columns.Add("code", "商品名稱");
            tblDeal.Columns.Add("oct", "新/平倉");
            tblDeal.Columns.Add("trade_type", "買賣別");
            tblDeal.Columns.Add("contractqty", "成交量");
            tblDeal.Columns.Add("contractprice", "成交價");
            tblDeal.Columns.Add("premium", "權利金收付");
            tblDeal.Columns.Add("fee", "手續費");
            tblDeal.Columns.Add("tax", "交易稅");

            //沖銷明細
            tblEven.Columns.Add("cover_date", "平倉日期");
            tblEven.Columns.Add("cover_seq", "流水號");
            tblEven.Columns.Add("ori_trade_date", "成交日期");
            tblEven.Columns.Add("code", "商品名稱");
            tblEven.Columns.Add("price", "成交價");
            tblEven.Columns.Add("trade_type", "買賣別");
            tblEven.Columns.Add("day_trade", "當沖");
            tblEven.Columns.Add("source", "來源");
            tblEven.Columns.Add("qty", "口數");
            tblEven.Columns.Add("total_profit", "平倉/到期損益");
            tblEven.Columns.Add("fee", "手續費");
            tblEven.Columns.Add("tax", "交易稅");

            //理論價
            tblTheory.Columns.Add("CallTheoryPrice", "理論價");
            tblTheory.Columns.Add("CallDealPrice", "成交價");
            tblTheory.Columns.Add("CallBias", "乖離");
            tblTheory.Columns.Add("CallVolatility", "波動率");
            tblTheory.Columns.Add("CallDelta", "Delta");
            tblTheory.Columns.Add("CallGamma", "Gamma");
            tblTheory.Columns.Add("CallVega", "Vega");
            tblTheory.Columns.Add("StrikePrice", "履約價");
            tblTheory.Columns.Add("PutTheoryPrice", "理論價");
            tblTheory.Columns.Add("PutDealPrice", "成交價");
            tblTheory.Columns.Add("PutBias", "乖離");
            tblTheory.Columns.Add("PutVolatility", "波動率");
            tblTheory.Columns.Add("PutDelta", "Delta");
            tblTheory.Columns.Add("PutGamma", "Gamma");
            tblTheory.Columns.Add("PutVega", "Vega");            


            //大盤指數
            tblIndex.Columns.Add("date", "日期");
            tblIndex.Columns.Add("index", "大盤");
            tblIndex.Columns.Add("volume", "成交量(億)");
        }

        private string[] ParseSymbolId(string strSymbolId)
        {
            // strSymbolId : TXO07600L2
            string[] strReturns = new string[4]; //StrikePrice, P/C, Year, Month

            strReturns[0] = strSymbolId.Substring(3, 5);            
            strReturns[2] = (Math.Floor(DateTime.Now.Year / 10.0) * 10 + int.Parse(strSymbolId.Substring(9, 1))).ToString("0");
            strReturns[3] = strSymbolId.Substring(8, 1);
            strReturns[1] = MONTH.IndexOf(strReturns[3]) > 12 ? "P" : "C";
            
            return strReturns;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> dicParam;
            string[] strSymbolParams;
            try
            {
                _autoTrade.GetPositionReport();
                _autoTrade.GetTodayEquity();

                _autoTrade.GetDealReport(dpStartDate.Value.ToString("yyyy/MM/dd"), 
                                         dpEndDate.Value.ToString("yyyy/MM/dd"));
                _autoTrade.GetCoverReport(dpStartDate.Value.ToString("yyyy/MM/dd"),
                                          dpEndDate.Value.ToString("yyyy/MM/dd"));


                dicParam = new Dictionary<string, object>();
                dicParam.Add("AccountType", _autoTrade.AccountInfo.AccountType);
                dicParam.Add("AccountNo", _autoTrade.AccountInfo.AccountNo);
                dicParam.Add("Password", _autoTrade.AccountInfo.Password);

                _historyQuote.InitProgram(dicParam);
                DataGridViewUtil.Clear(tblIndex);
                List<BarRecord> lstIndex = _historyQuote.GetBarData("100000_TWSE_Day_1", 
                                                                    dpEndDate.Value.AddDays(-1 * ((int)nudBackDays.Value)), 
                                                                    dpEndDate.Value);

                foreach (BarRecord barRecord in lstIndex)
                    tblIndex.Rows.Add(new object[] { barRecord.BarDateTime.ToString("yyyy/MM/dd"),
                                                     barRecord["Close"].ToString("0.00"),
                                                     (barRecord["Volume"] / 10000.0).ToString("0.00")});

                DataGridViewUtil.Clear(tblTheory);
                Dictionary<string, List<BarRecord>> dicTheory = _historyQuote.GetBarRecord("OptionsTheroreticalPrice_Hot",
                                                                                           "f2",
                                                                                            dpEndDate.Value,
                                                                                            dpEndDate.Value);
                Dictionary<string, int> dicRowIndex = new Dictionary<string, int>();
                List<object> lstRow;
                BarRecord theoryBarRecord;
                int iRowIndex;

                foreach (string strSymbolId in dicTheory.Keys)
                {
                    theoryBarRecord = dicTheory[strSymbolId][0];
                    strSymbolParams = ParseSymbolId(strSymbolId);//StrikePrice, P/C, Year, Month

                    lstRow = new List<object>();
                    lstRow.Add(theoryBarRecord["TheoreticalPrice"]);
                    lstRow.Add(theoryBarRecord["DealPrice"]);
                    lstRow.Add(theoryBarRecord["DealPrice"] - theoryBarRecord["TheoreticalPrice"]);
                    lstRow.Add(theoryBarRecord["Volatility"]);
                    lstRow.Add(theoryBarRecord["Delta"]);
                    lstRow.Add(theoryBarRecord["Gamma"]);
                    lstRow.Add(theoryBarRecord["Vega"]);

                    if (dicRowIndex.ContainsKey(strSymbolParams[0]))
                    {
                        iRowIndex = dicRowIndex[strSymbolParams[0]];

                        if (strSymbolParams[1] == "C")
                        {
                            lstRow.Add(strSymbolParams[0]);
                            for (int i = 0; i < 7; i++)
                                lstRow.Add(tblTheory.Rows[iRowIndex].Cells[i + 8].Value);
                        }
                        else
                        {
                            lstRow.Insert(0, strSymbolParams[0]);
                            for (int i = 0; i < 7; i++)
                                lstRow.Insert(i, tblTheory.Rows[iRowIndex].Cells[i].Value);
                        }
                        DataGridViewUtil.UpdateRow(tblTheory,
                                                   new string[] { "StrikePrice" },
                                                   lstRow.ToArray<object>(),
                                                   lstRow.ToArray<object>());
                    }
                    else
                    {                        
                        if (strSymbolParams[1] == "C")
                        {
                            lstRow.Add(strSymbolParams[0]);
                            for (int i = 0; i < 7; i++)
                                lstRow.Add("");
                        }
                        else
                        {
                            lstRow.Insert(0, strSymbolParams[0]);
                            for (int i = 0; i < 7; i++)
                                lstRow.Insert(0, "");
                        }
                        DataGridViewUtil.InsertRow(tblTheory,
                                                   (object[])lstRow.ToArray<object>());
                        dicRowIndex.Add(strSymbolParams[0], tblTheory.RowCount - 1);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string strPath = AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.PROGRAM_ROOT_PATH].ToString() + @"\Summary";
            ExcelFormat excelFormat = null;
            IResultSetGroup resultGroup = new DefaultResultSetGroup();
            DataGridViewResultSet resultSet = null;
            DataGridView[] dataSources = new DataGridView[] { tblOpenPosition, tblEquity, tblTheory, tblDeal, tblEven, tblIndex};
            IWriter excelWriter = new ExcelWriter();
            try
            {
                if (Directory.Exists(strPath) == false)
                    Directory.CreateDirectory(strPath);

                excelWriter.IsAppend = false;
                //excelWriter.SourceFile = strPath + @"\Summary_" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx";
                excelWriter.SourceFile = "";
                excelWriter.TargetFile = strPath + @"\Summary_" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx";
                                
                for (int i = 0; i < tabFunction.TabCount; i++)
                {
                    excelFormat = new ExcelFormat();
                    excelFormat.IsVisible = true;
                    excelFormat.StartCol = 1;
                    excelFormat.StartRow = 1;
                    excelFormat.HasColumnName = true;
                    excelFormat.WorksheetName = tabFunction.TabPages[i].Text;
                    resultSet = new DataGridViewResultSet(dataSources[i]);
                    resultSet.Load();                    
                    excelFormat.ColumnNames = resultSet.ColumnHeaders().ToArray<string>();
                    resultGroup.AddResultSet(tabFunction.TabPages[i].Text, resultSet, excelFormat);
                }

                excelWriter.Write((IResultSet)resultGroup, excelFormat);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        #region IObserver Members

        public void Update(object oSource, IMessageInfo miMessage)
        {
            Dictionary<string, string> dicParam;
            Dictionary<string, object> dicEquity;
            string[] strFields;
            string[] strTitles;
            Dictionary<string, string> dicRecord;
            Dictionary<string, object> dicReturn;
            int iRecordCount;
            string[] strValues;

            try
            {
                switch (miMessage.MessageSubject)
                {
                    case "OnTradeMessageReceive":


                        dicReturn = (Dictionary<string, object>)miMessage.Message;
                        if (dicReturn.ContainsKey("name") == false)
                            break;

                        switch (dicReturn["name"].ToString())
                        {
                            case "QueryTodayEquity": //當日權益數
                                DataGridViewUtil.Clear(tblEquity);

                                dicEquity = PolarisMessageParser.ParseEquity(dicReturn);
                                strFields = (string[])dicEquity["fields"];
                                strTitles = (string[])dicEquity["titles"];

                                dicRecord = (Dictionary<string, string>)dicEquity["record0"];

                                for (int i = 0; i < strFields.Length; i++)
                                {
                                    if (strTitles[i] == "未啟用")
                                        continue;

                                    try
                                    {
                                        DataGridViewUtil.InsertRow(tblEquity, new string[] { strTitles[i], double.Parse(dicRecord[strFields[i]]).ToString("0.00") });
                                    }
                                    catch
                                    {
                                        DataGridViewUtil.InsertRow(tblEquity, new string[] { strTitles[i], dicRecord[strFields[i]] });
                                    }
                                }
                                break;

                            case "QueryTodayPosition": //目前庫存
                                DataGridViewUtil.Clear(tblOpenPosition);
                                dicReturn = PolarisMessageParser.ParseTodayPosition(dicReturn);

                                iRecordCount = int.Parse(dicReturn["recordcount"].ToString());

                                for (int i = 0; i < iRecordCount; i++)
                                {
                                    dicRecord = (Dictionary<string, string>)dicReturn["record" + i];
                                    strValues = new string[tblOpenPosition.ColumnCount];
                                    for (int j = 0; j < strValues.Length; j++)
                                    {
                                        strValues[j] = dicRecord[tblOpenPosition.Columns[j].Name].ToString();
                                    }
                                    DataGridViewUtil.InsertRow(tblOpenPosition, strValues);
                                }
                                break;
/*
                            case "QueryOrderListByDiff": //委託回報
                                DataGridViewUtil.Clear(tblTrust);
                                dicReturn = PolarisMessageParser.ParseTrustReport(dicReturn);

                                iRecordCount = int.Parse(dicReturn["recordcount"].ToString());

                                for (int i = 0; i < iRecordCount; i++)
                                {
                                    dicRecord = (Dictionary<string, string>)dicReturn["record" + i];
                                    strValues = new string[tblTrust.ColumnCount];
                                    for (int j = 0; j < strValues.Length; j++)
                                    {
                                        strValues[j] = dicRecord[tblTrust.Columns[j].Name].ToString();
                                    }
                                    if (tblTrust.ColumnCount > 0)
                                        DataGridViewUtil.InsertRow(tblTrust, strValues);
                                }

                                break;
*/
                            case "QueryDealReport": //成交回報
                                DataGridViewUtil.Clear(tblDeal);

                                dicReturn = PolarisMessageParser.ParseDealReport(dicReturn);

                                iRecordCount = int.Parse(dicReturn["recordcount"].ToString());

                                for (int i = 0; i < iRecordCount; i++)
                                {
                                    dicRecord = (Dictionary<string, string>)dicReturn["record" + i];
                                    strValues = new string[tblDeal.ColumnCount];
                                    for (int j = 0; j < strValues.Length; j++)
                                    {
                                        strValues[j] = dicRecord[tblDeal.Columns[j].Name].ToString();
                                    }
                                    DataGridViewUtil.InsertRow(tblDeal, strValues);
                                }
                                break;
                            case "CoverReport":

                                break;
                        }

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }            
        }

        #endregion

    }
}
