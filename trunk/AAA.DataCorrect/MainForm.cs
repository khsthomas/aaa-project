using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AAA.Base.Util.Reader;
using AAA.Database;

namespace AAA.DataCorrect
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            IniReader iniReader;
            IDatabase database;
            string[] strTasks;
            string[] strTaskDescs;
            try
            {
                btnStart.Enabled = false;
                iniReader = new IniReader(Environment.CurrentDirectory + @"\cfg\database_update.ini");
                database = new AccessDatabase();
                database.Open(Environment.CurrentDirectory + @"\" + iniReader.GetParam("Database"),
                              iniReader.GetParam("Username"),
                              iniReader.GetParam("Password"));

                strTasks = iniReader.GetParam("Task").Split(',');
                strTaskDescs = iniReader.GetParam("TaskDesc").Split(',');

                for (int i = 0; i < strTasks.Length; i++)
                {
                    Application.DoEvents();
                    lstMessage.Items.Add("開始修正 : " + strTaskDescs[i]);
                    lstMessage.Update();

                    database.ExecuteUpdate(iniReader.GetParam(strTasks[i] + "SQL"));
                    if (database.ErrorMessage != "")
                        MessageBox.Show(database.ErrorMessage);

                    lstMessage.Items.Add("修正完畢 : " + strTaskDescs[i]);
                    lstMessage.Update();
                }
                database.Close();
                MessageBox.Show("資料修正完畢");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
            finally
            {
                btnStart.Enabled = false;
            }
        }
    }
}
