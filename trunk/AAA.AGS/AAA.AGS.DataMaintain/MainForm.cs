using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using AAA.Database;

namespace AAA.AGS.DataMaintain
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            cboServer.SelectedIndex = 0;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string[] strBarData = { "TXF_1m_db.txt", "TEF_1m_db.txt", "TFF_1m_db.txt"};
            string[] strPVData = { "TFHTX-TP-PV.txt", "TFHTE-TP-PV.txt", "TFHTF-TP-PV.txt" };
            StreamReader sr = null;
            string strLine;
            string[] strValues;
            string strInsertSQL;
            string strDeleteSQL;
            IDatabase database = new MSSqlDatabase();

            try
            {

                database.Open(cboServer.Text, txtDatabase.Text, txtUsername.Text, txtPassword.Text);
                strDeleteSQL = "DELETE FROM TWFE_Futures_M_Deal WHERE ExTime BETWEEN '{0}' AND '{1}'";
                strInsertSQL = "INSERT INTO TWFE_Futures_M_Deal(ExTime, SymbolId, OpenPrice, HighPrice, LowPrice, ClosePrice, DealVol, DealAmt) VALUES('{0}', '{1}', {2}, {3}, {4}, {5}, {6}, {7})";

                database.ExecuteUpdate(strDeleteSQL, new string[] {txtStartDate.Text, txtEndDate.Text});
                database.Commit();

                for (int i = 0; i < strBarData.Length; i++)
                {
                    sr = new StreamReader(Environment.CurrentDirectory + @"\" + strBarData[i]);

                    while ((strLine = sr.ReadLine()) != null)
                    {
                        strValues = strLine.Split(',');
                        if ((strValues[0].CompareTo(txtStartDate.Text) < 0) ||
                            (strValues[0].CompareTo(txtEndDate.Text) > 0))
                            continue;

                        if (database.ExecuteUpdate(strInsertSQL, strValues) != 1)
                            ;//lMessageBox.Show(database.ErrorMessage);
                    }
                }

                sr.Close();

                strDeleteSQL = "DELETE FROM TWFE_Futures_M_VolAtPrice WHERE ExTime BETWEEN '{0}' AND '{1}'";
                strInsertSQL = "INSERT INTO TWFE_Futures_M_VolAtPrice(ExTime, SymbolId, Price, DealVol, DealTick) VALUES('{0}', '{1}', {2}, {3}, {4})";

                database.ExecuteUpdate(strDeleteSQL, new string[] { txtStartDate.Text, txtEndDate.Text });
                database.Commit();

                for (int i = 0; i < strPVData.Length; i++)
                {
                    sr = new StreamReader(Environment.CurrentDirectory + @"\" + strPVData[i]);

                    while ((strLine = sr.ReadLine()) != null)
                    {
                        strValues = strLine.Split(',');
                        if ((strValues[0].CompareTo(txtStartDate.Text) < 0) ||
                            (strValues[0].CompareTo(txtEndDate.Text) > 0))
                            continue;

                        if (database.ExecuteUpdate(strInsertSQL, strValues) != 1)
                            ;// MessageBox.Show(database.ErrorMessage);
                    }
                }
                sr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
            finally
            {
                if (sr != null)
                    sr.Close();
            }
        }
    }
}
