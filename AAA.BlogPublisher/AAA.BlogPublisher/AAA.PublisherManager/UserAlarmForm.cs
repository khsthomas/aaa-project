using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AAA.Command.WCF;
using AAA.PublisherService.Command;
using AAA.Base.Util;

namespace AAA.PublisherManager
{
    public partial class UserAlarmForm : Form
    {
        public UserAlarmForm()
        {
            InitializeComponent();

            tblUserList.Columns.Add("Account", "帳號");
            tblUserList.Columns.Add("ExpiredDate", "到期日");
            RefreshAccountList();
            timerRefresh.Enabled = true;
        }

        public void RefreshAccountList()
        {
            Dictionary<string, string> dicModel = new Dictionary<string, string>();
            int iRowCount;
            string[] strAttributes;
            string[] strFieldNames;
            int iActiveFlag = -1;
            int iExpiredDate = -1;
            int iAccount = -1;
            TimeSpan timeSpan;

            try
            {
                while(tblUserList.Rows.Count > 0)
                    tblUserList.Rows.RemoveAt(0);

                ICommand command = new QueryAccountListCommand();
                command.Execute(dicModel);
                iRowCount = int.Parse(dicModel["RowCount"]);
                strFieldNames = dicModel["FieldName"].Split(',');

                for (int i = 0; i < strFieldNames.Length; i++)
                {
                    if (strFieldNames[i] == "Account")
                        iAccount = i;
                    if (strFieldNames[i] == "ExpiredDate")
                        iExpiredDate = i;
                    if (strFieldNames[i] == "ActiveFlag")
                        iActiveFlag = i;
                }

                for (int i = 0; i < iRowCount; i++)
                {
                    strAttributes = dicModel["Row" + i].Split(',');

                    if (strAttributes[iActiveFlag] == "N")
                        continue;                    

                    try
                    {
                        if (DateTimeHelper.DateDiff(DateTimeHelper.DAY, strAttributes[iExpiredDate], DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")) < 30)
                        {
                            tblUserList.Rows.Add(new string[] { strAttributes[iAccount], strAttributes[iExpiredDate] });
                        }
                    }
                    catch { }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            RefreshAccountList();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshAccountList();
        }
    }
}
