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
using System.IO;

namespace AAA.TradingSystem
{
    public partial class UserDefineSymbolForm : Form
    {
        public UserDefineSymbolForm()
        {
            InitializeComponent();
        }

        private void UserDefineSymbolForm_Load(object sender, EventArgs e)
        {
            CreateTable();
            InitGroupId();
            InitSymbolId();
        }

        private void CreateTable()
        {
            if (File.Exists(Environment.CurrentDirectory + @"\create_table.ini") == false)
                return;

            IDatabase database = new AccessDatabase();
            IniReader iniReader = new IniReader(Environment.CurrentDirectory + @"\cfg\system.ini");
            string strUsername;
            string strPassword;
            string strSQL;
            StreamReader sr = null;

            try
            {
                strUsername = iniReader.GetParam("DataSource", "Username");
                strPassword = iniReader.GetParam("DataSource", "Password");
                database.Open(Environment.CurrentDirectory + @"\stocks.mdb", strUsername, strPassword);

                sr = new StreamReader(Environment.CurrentDirectory + @"\create_table.ini");

                while ((strSQL = sr.ReadLine()) != null)
                {
                    database.ExecuteUpdate(strSQL);
                }

                database.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
            finally
            {
                if (sr != null)
                    sr.Close();
                File.Delete(Environment.CurrentDirectory + @"\create_table.ini");
            }

        }

        private void InitGroupId()
        {
            IDatabase database = new AccessDatabase();
            IniReader iniReader = new IniReader(Environment.CurrentDirectory + @"\cfg\system.ini");
            string strUsername;
            string strPassword;
            string strSelectSQL;
            DbDataReader dataReader = null;
            try
            {
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

        private void InitSymbolId()
        {
            IniReader iniReader = null;
            string strUsername;
            string strPassword;

            try
            {
                tblSource.Columns.Add("SymbolId", "股票代碼");
                tblSource.Columns.Add("SymbolName", "股票名稱");
                tblTarget.Columns.Add("SymbolId", "股票代碼");
                tblTarget.Columns.Add("SymbolName", "股票名稱");

                iniReader = new IniReader(Environment.CurrentDirectory + @"\cfg\system.ini");                
                strUsername = iniReader.GetParam("DataSource", "Username");
                strPassword = iniReader.GetParam("DataSource", "Password");

                if (iniReader.GetParam("DataSource", "InitSymbolIdSQL") != null)
                {

                    IDatabase database = new AccessDatabase();
                    database.Open(Environment.CurrentDirectory + @"\stocks.mdb", strUsername, strPassword);
                    string strSQL = iniReader.GetParam("DataSource", "InitSymbolIdSQL");
                    DbDataReader dataReader = database.ExecuteQuery(strSQL);


                    while (dataReader.Read())
                    {
                        tblSource.Rows.Add(new string[] { dataReader["SymbolId"].ToString(), dataReader["SymbolName"].ToString()});
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (tblSource.SelectedRows.Count == 0)
                    return;

                int iRowIndex = tblSource.SelectedRows[0].Index;
                object[] oValues = new object[tblSource.Columns.Count];

                for (int i = 0; i < tblSource.Columns.Count; i++)
                {
                    oValues[i] = tblSource.Rows[iRowIndex].Cells[i].Value.ToString(); ;
                }

                for (int i = 0; i < tblTarget.Rows.Count; i++)
                {
                    if (tblTarget.Rows[i].Cells["SymbolId"].Value.ToString() == oValues[0].ToString())
                    {
                        MessageBox.Show(oValues[0].ToString() + "已存在自選股內");
                        return;
                    }
                }

                tblTarget.Rows.Add(oValues);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (tblTarget.SelectedRows.Count == 0)
                    return;
                int iRowIndex = tblTarget.SelectedRows[0].Index;

                tblTarget.Rows.RemoveAt(iRowIndex);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            IDatabase database = new AccessDatabase();
            IniReader iniReader = new IniReader(Environment.CurrentDirectory + @"\cfg\system.ini");
            string strUsername;
            string strPassword;
            string strDeleteSQL;
            string strInsertSQL;
            try
            {
                strUsername = iniReader.GetParam("DataSource", "Username");
                strPassword = iniReader.GetParam("DataSource", "Password");
                database.Open(Environment.CurrentDirectory + @"\stocks.mdb", strUsername, strPassword);

                strDeleteSQL = "DELETE FROM UserDefineSymbol WHERE GroupId = '{0}'";
                strInsertSQL = "INSERT INTO UserDefineSymbol(GroupId, SymbolSeq, SymbolId) VALUES('{0}', {1}, '{2}')";

                database.ExecuteUpdate(strDeleteSQL, new string[] { cboGroupId.Text });

                for (int i = 0; i < tblTarget.Rows.Count; i++)
                {
                    database.ExecuteUpdate(strInsertSQL, new string[] { cboGroupId.Text, i.ToString(), tblTarget.Rows[i].Cells["SymbolId"].Value.ToString() });
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
            finally
            {
                database.Close();
                InitGroupId();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            IDatabase database = new AccessDatabase();
            IniReader iniReader = new IniReader(Environment.CurrentDirectory + @"\cfg\system.ini");
            string strUsername;
            string strPassword;
            string strDeleteSQL;

            try
            {
                strUsername = iniReader.GetParam("DataSource", "Username");
                strPassword = iniReader.GetParam("DataSource", "Password");
                database.Open(Environment.CurrentDirectory + @"\stocks.mdb", strUsername, strPassword);

                strDeleteSQL = "DELETE FROM UserDefineSymbol WHERE GroupId = '{0}'";

                database.ExecuteUpdate(strDeleteSQL, new string[] { cboGroupId.Text });

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
            finally
            {
                database.Close();
                InitGroupId();
            }
        }

        private void cboGroupId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tblTarget.ColumnCount == 0)
                return;

            if (cboGroupId.Text.Trim() == "")
                return;

            IDatabase database = new AccessDatabase();
            IniReader iniReader = new IniReader(Environment.CurrentDirectory + @"\cfg\system.ini");
            string strUsername;
            string strPassword;
            string strSelectSQL;
            DbDataReader dataReader = null;
            try
            {
                strUsername = iniReader.GetParam("DataSource", "Username");
                strPassword = iniReader.GetParam("DataSource", "Password");
                database.Open(Environment.CurrentDirectory + @"\stocks.mdb", strUsername, strPassword);

                strSelectSQL = "SELECT a.SymbolSeq AS SymbolSeq, a.SymbolId AS SymbolId, b.SymbolName AS SymbolName FROM UserDefineSymbol a, SymbolProfile b WHERE a.SymbolId = b.SymbolId AND GroupId = '{0}' ORDER BY SymbolSeq";

                dataReader = database.ExecuteQuery(strSelectSQL, new string[] { cboGroupId.Text });

                while (tblTarget.Rows.Count > 0)
                    tblTarget.Rows.RemoveAt(0);

                while (dataReader.Read())
                {
                    tblTarget.Rows.Add(new string[] { dataReader["SymbolId"].ToString(), dataReader["SymbolName"].ToString() });
                }

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

        private void tblTarget_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                IMessageInfo miMessage = new MessageInfo();
                miMessage.MessageTicks = DateTime.Now.Ticks;
                miMessage.MessageSubject = "StockSelected";
                miMessage.Message = tblTarget.Rows[e.RowIndex].Cells[0].Value.ToString();
                MessageSubject.Instance().Subject.Notify(miMessage);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void tblSource_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                IMessageInfo miMessage = new MessageInfo();
                miMessage.MessageTicks = DateTime.Now.Ticks;
                miMessage.MessageSubject = "StockSelected";
                miMessage.Message = tblSource.Rows[e.RowIndex].Cells[0].Value.ToString();
                MessageSubject.Instance().Subject.Notify(miMessage);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }
    }
}
