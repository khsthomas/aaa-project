using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using AAA.Database;
using AAA.Meta.Quote;
using AAA.Base.Util.Reader;

namespace AAA.Maintain.DB
{
    public partial class WriteTicksToDB : Form
    {
        string[] _strHosts;
        Dictionary<string, IDatabase> _DBHosts;

        public WriteTicksToDB()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            try
            {
                _DBHosts = new Dictionary<string,IDatabase>();
                IniReader iniReader = new IniReader(Environment.CurrentDirectory + @"\Cfg\config.ini");

                _strHosts = iniReader.GetParam("Host").Split(',');
                string strDatabase = iniReader.GetParam("Database");
                string strUsername = iniReader.GetParam("Username");
                string strPassword = iniReader.GetParam("Password");
                foreach (string strHost in _strHosts)
                {
                    IDatabase mssql_db = new MSSqlDatabase();
                    _DBHosts.Add(strHost, mssql_db);
                    _DBHosts[strHost].Open(strHost, strDatabase, strUsername, strPassword);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void SaveTick_Click(object sender, EventArgs e)
        {
            try
            {
                List<object> strValues = new List<object>();
                string strSQL = "INSERT INTO TWFE_Futures_Tick(ExTime, SymbolId, ForBuyVol, ForSellVol, DealVol, ForBuyPrice, ForSellPrice, DealPrice) VALUES('{0}', '{1}', {2}, {3}, {4}, {5}, {6}, {7})";
                strValues.Add(DateTime.Now.ToString());
                strValues.Add("TWFE_TFHTE");
                strValues.Add(100);
                strValues.Add(101);
                strValues.Add(102);
                strValues.Add(103.001);
                strValues.Add(104.002);
                strValues.Add(105.0004);
                _DBHosts["192.168.11.6"].ExecuteUpdate(strSQL, strValues.ToArray());
                _DBHosts["192.168.11.6"].Commit();
                strValues.Clear();
            }
            catch(Exception ex) {
                listBox1.Items.Add(ex.Message.ToString());
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void WriteTicksToDB_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (string strHost in _strHosts)
            {
                _DBHosts[strHost].Close();
            }
        }

    }
}
