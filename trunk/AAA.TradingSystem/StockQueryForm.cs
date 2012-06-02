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
using AAA.DesignPattern.Observer;

namespace AAA.TradingSystem
{
    public partial class StockQueryForm : Form
    {
        private const int QUERY_RATIO = 1;
        private const int QUERY_RED_BLACK = 2;

        private int[] _iQueryTypes = {QUERY_RATIO, QUERY_RED_BLACK };

        public StockQueryForm()
        {
            InitializeComponent();
        }

        private void StockQueryForm_Load(object sender, EventArgs e)
        {
            cboRatioDirection.SelectedIndex = 0;
            cboDirection.SelectedIndex = 0;
            cboVolume.SelectedIndex = 0;
            cboBCValue.SelectedIndex = 0;
            cboRedBlack3Compare.SelectedIndex = 0;

            txtDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
            tblStock.Columns.Add("SymbolId", "股票代碼");
            tblStock.Columns.Add("SymbolName", "股票名稱");            
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            IDatabase database;
            IniReader iniReader = new IniReader(Environment.CurrentDirectory + @"\cfg\system.ini");
            string strHost;
            string strDatabase;
            string strUsername;
            string strPassword;
            string strSQL;
            DbDataReader dataReader;
            string[] strValues;
            int iParamIndex;
            int iQueryType;

            try
            {
                while (tblStock.Rows.Count > 0)
                    tblStock.Rows.RemoveAt(0);

                strValues = txtDate.Text.Split('/');
                if (strValues.Length != 3)
                {
                    MessageBox.Show("請輸入查詢日期, 日期格式為yyyy/mm/dd!");
                    return;
                }

                strHost = iniReader.GetParam("DataSource", "Host");
                strDatabase = iniReader.GetParam("DataSource", "Database");
                strUsername = iniReader.GetParam("DataSource", "Username");
                strPassword = iniReader.GetParam("DataSource", "Password");
                database = new AccessDatabase();
                database.Open(strDatabase.StartsWith(".") ? Environment.CurrentDirectory + strDatabase.Substring(1) : strDatabase,
                              strUsername,
                              strPassword);

                strSQL = "SELECT a.SymbolId AS SymbolId, c.SymbolName AS SymbolName " +
                         "  FROM TWSE_Stock_D_Deal a, " +
                         "       TWSE_Stock_D_Index b, " +
                         "       SymbolProfile c " +
                         " WHERE a.ExDate = b.ExDate " +
                         "   AND a.SymbolId = b.SymbolId " +
                         "   AND a.SymbolId = c.SymbolId " +
                         "   AND a.ExDate = CDATE('{0}') ";
                
                if(chkDirection.Checked)
                {
                    switch (cboDirection.Text)
                    {
                        case "上漲":
                            strSQL += "   AND a.ClosePrice > a.PreClose AND a.PreClose <> 0 AND a.ClosePrice <> 0 ";
                            break;
                        case "下跌":
                            strSQL += "   AND a.ClosePrice < a.PreClose AND a.PreClose <> 0 AND a.ClosePrice <> 0 ";
                            break;
                    }
                }

                if(chkVolume.Checked)
                {
                    switch (cboVolume.Text)
                    {
                        case "量大於前一天":
                            strSQL += "   AND a.Vol > b.Index14 ";
                            break;
                        case "量大於前三天":
                            strSQL += "   AND a.Vol > b.Index15 ";
                            break;
                        case "量大於前五天":
                            strSQL += "   AND a.Vol > b.Index17 ";
                            break;
                        case "量縮":
                            strSQL += "   AND a.Vol < b.Index14 ";
                            break;
                    }
                }

                if (chkBCValue.Checked)
                {
                    switch (cboBCValue.Text)
                    {
                        case "BC值高":
                            strSQL += "   AND a.ClosePrice < b.Index10 AND a.ClosePrice < b.Index11 ";
                            break;
                        case "BC值低":
                            strSQL += "   AND a.ClosePrice > b.Index10 AND a.ClosePrice > b.Index11 ";
                            break;
                    }
                }

                iQueryType = 0;

                if (chkRatioDirection.Checked)
                    iQueryType += QUERY_RATIO;

                if (chkRedBlack3.Checked)
                    iQueryType += QUERY_RED_BLACK;

                iParamIndex = 1;

                for (int i = 0; i < _iQueryTypes.Length; i++)
                {
                    if ((iQueryType & _iQueryTypes[i]) == _iQueryTypes[i])
                    {
                        switch (_iQueryTypes[i])
                        {
                            case QUERY_RATIO:
                                switch (cboRatioDirection.Text)
                                {
                                    case "漲幅":
                                        strSQL += "   AND IIF(a.PreClose = 0, 0, ((a.ClosePrice - a.PreClose) / a.PreClose) * 100) > {" + (iParamIndex++) + "} ";
                                        break;
                                    case "跌幅":
                                        strSQL += "   AND IIF(a.PreClose = 0, 0, ((a.ClosePrice - a.PreClose) / a.PreClose) * 100) < {" + (iParamIndex++) + "} ";
                                        break;
                                }
                                break;

                            case QUERY_RED_BLACK:
                                switch (cboRedBlack3Compare.Text)
                                {
                                    case ">=":
                                        strSQL += "   AND b.Index18 >= {" + (iParamIndex++) + "} ";
                                        break;
                                    case "<=":                                        
                                        strSQL += "   AND b.Index18 <= {" + (iParamIndex++) + "} ";
                                        break;
                                }
                                break;
                        }
                    }
                }

                switch (iQueryType)
                {
                    case 1:
                        dataReader = database.ExecuteQuery(strSQL, new object[] {txtDate.Text, txtRatio.Text });
                        break;
                    
                    case 2:
                        dataReader = database.ExecuteQuery(strSQL, new object[] {txtDate.Text, txtRedBlack3.Text });
                        break;

                    case 3:
                        dataReader = database.ExecuteQuery(strSQL, new object[] { txtDate.Text, txtRatio.Text, txtRedBlack3.Text });
                        break;
                    default:
                        dataReader = database.ExecuteQuery(strSQL, new object[] { txtDate.Text });
                        break;
                }
                   
                while (dataReader.Read())
                {
                    tblStock.Rows.Add(new object[] {dataReader["SymbolId"].ToString(), dataReader["SymbolName"].ToString() });
                }

                if (tblStock.Rows.Count == 0)
                    MessageBox.Show("沒有符合條件的股票");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void tblStock_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                IMessageInfo miMessage = new MessageInfo();
                miMessage.MessageTicks = DateTime.Now.Ticks;
                miMessage.MessageSubject = "StockSelected";
                miMessage.Message = tblStock.Rows[e.RowIndex].Cells[0].Value.ToString();
                MessageSubject.Instance().Subject.Notify(miMessage);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }

        }


    }
}
