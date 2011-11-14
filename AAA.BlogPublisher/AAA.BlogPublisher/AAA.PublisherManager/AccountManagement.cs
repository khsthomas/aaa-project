using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AAA.PublisherManager
{
    public partial class AccountManagement : Form
    {
        public AccountManagement()
        {
            InitializeComponent();
            InitTable();
        }

        private void InitTable()
        {
            try
            {
                tblAccount.Columns.Add("Account", "帳號");
                tblAccount.Columns.Add("Password", "密碼");
                tblAccount.Columns.Add("StartDate", "建立日期");
                tblAccount.Columns.Add("EndDate", "有效日期");
                tblAccount.Columns.Add("ActiveFlag", "是否有效");                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void btnGetAccountList_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> dicResult;
            int iRowCount;
            string[] strValues;
            AAA.PublisherClient.PublisherClient publisherClient = new AAA.PublisherClient.PublisherClient();
            publisherClient.Connect();
            dicResult = publisherClient.QueryAccountList();

            while (tblAccount.Rows.Count > 0)
                tblAccount.Rows.RemoveAt(0);

            if (dicResult.ContainsKey("RowCount") == false)
            {
                MessageBox.Show("無帳號資料");
                return;
            }

            iRowCount = int.Parse(dicResult["RowCount"]);

            for (int i = 0; i < iRowCount; i++)
            {
                strValues = dicResult["Row" + i].Split(',');
                tblAccount.Rows.Add(strValues);
            }


        }
    }
}
