using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AAA.ResultSet;
using AAA.Command.WCF;
using AAA.PublisherService.Command;
using AAA.Base.Util.Reader;
using System.IO;
using System.Reflection;
using AAA.WebPublisher;

namespace AAA.PublisherManager
{
    public partial class AccountManagement : Form
    {
        public AccountManagement()
        {
            InitializeComponent();
            InitTable();
            InitFunctions();
        }

        private void InitFunctions()
        {
            IniReader iniReader = new IniReader(Environment.CurrentDirectory + @"\cfg\system.ini");
            string strArticleFolder;
            string strPublisherFolder;
            string[] strArticles;
            FileInfo[] filesInfos;
            Assembly asmb = null;
            IPublisher publisher;
            string strNamespace;

            try
            {
                strArticleFolder = iniReader.GetParam("ArticleFolder");
                strPublisherFolder = iniReader.GetParam("PublisherFolder");

                strArticles = Directory.GetDirectories(strArticleFolder);

                for (int i = 0; i < strArticles.Length; i++)
                    lstArticle.Items.Add(strArticles[i].Substring(strArticles[i].LastIndexOf('\\') + 1));

                DirectoryInfo directoryInfo = new DirectoryInfo(strPublisherFolder);
                filesInfos = directoryInfo.GetFiles("*.dll");

                for (int i = 0; i < filesInfos.Length; i++)
                {
                    strNamespace = filesInfos[i].Name.Replace(".dll", "");
                    asmb = Assembly.LoadFile(filesInfos[i].FullName);
                    publisher = (IPublisher)asmb.CreateInstance(strNamespace + "." + strNamespace.Substring(strNamespace.LastIndexOf('.') + 1));
                    if (publisher == null)
                        continue;
                    lstWebSite.Items.Add(publisher.WebSiteName);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void InitTable()
        {
            try
            {
                tblAccount.Columns.Add("Account", "帳號");
                tblAccount.Columns.Add("Password", "密碼");
                tblAccount.Columns.Add("StartDate", "建立日期");
                tblAccount.Columns.Add("ExpiredDate", "有效日期");
                tblAccount.Columns.Add("ActiveFlag", "是否有效");                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void btnGetAccountList_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> dicResult = new Dictionary<string,string>();
            int iRowCount;
            string[] strValues;
            ICommand command = null;
/*
            string strSQL = "SELECT Account, Password, StartDate, ExpiredDate, ActiveFlag FROM Account";

            DatabaseResultSet resultSet = new DatabaseResultSet(SystemConfig.DATABASE_TYPE,
                                                                SystemConfig.HOST,
                                                                SystemConfig.DATABASE,
                                                                SystemConfig.USERNAME,
                                                                SystemConfig.PASSWORD);
            resultSet.SQLStatement = strSQL;
*/


            command = new QueryAccountListCommand();
            command.Execute(dicResult);

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

        private void btnSaveMapping_Click(object sender, EventArgs e)
        {
            string strAccount;
            Dictionary<string, string> dicFunction = new Dictionary<string, string>();
            Dictionary<string, string> dicArticle = new Dictionary<string, string>();
            Dictionary<string, string> dicAccount = new Dictionary<string, string>();
            ICommand command;
            try
            {
                if (tblAccount.SelectedRows.Count == 0)
                {
                    MessageBox.Show("請選擇要更新權限的帳號");
                    return;
                }

                strAccount = tblAccount.SelectedRows[0].Cells["Account"].Value.ToString();

                for (int i = 0; i < lstArticle.CheckedIndices.Count; i++)
                {
                    dicArticle.Add(lstArticle.Items[lstArticle.CheckedIndices[i]].ToString().Split('.')[0] , strAccount);
                }

                command = new UpdateAccountArticleMappingCommand();
                command.Execute(dicArticle);

                for (int i = 0; i < lstWebSite.CheckedIndices.Count; i++)
                {
                    dicFunction.Add(lstWebSite.Items[lstWebSite.CheckedIndices[i]].ToString(), strAccount);
                }

                command = new UpdateAccountFunctionMappingCommand();
                command.Execute(dicFunction);

                dicAccount = new Dictionary<string, string>();
                dicAccount.Add("Account", strAccount);
                dicAccount.Add("ExpiredDate", dtExpiredDate.Value.ToString("yyyy/MM/dd"));
                dicAccount.Add("ActiveFlag", chkActive.Checked ? "Y" : "N");

                command = new UpdateAccountPrivilegeCommand();
                command.Execute(dicAccount);


                MessageBox.Show("儲存成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void tblAccount_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string strAccount = null;
            Dictionary<string, string> dicModel;
            ICommand command;
            try
            {
                dtExpiredDate.Value = DateTime.Parse(tblAccount.SelectedRows[e.RowIndex].Cells["ExpiredDate"].Value.ToString());
                chkActive.Checked = (tblAccount.SelectedRows[e.RowIndex].Cells["ActiveFlag"].Value.ToString() == "Y");
                strAccount = tblAccount.SelectedRows[e.RowIndex].Cells["Account"].Value.ToString();
                dicModel = new Dictionary<string, string>();
                dicModel.Add("Account", strAccount);
                
                command = new GetFunctionListCommand();
                command.Execute(dicModel);

                foreach (string strKey in dicModel.Keys)
                {
                    if (strKey == "Account")
                        continue;

                    if (lstWebSite.Items.IndexOf(strKey) >= 0)
                        lstWebSite.SetItemChecked(lstWebSite.Items.IndexOf(strKey), true);
                }


                dicModel = new Dictionary<string, string>();
                dicModel.Add("Account", strAccount);

                command = new GetArticleCategoryListCommand();
                command.Execute(dicModel);

                foreach (string strKey in dicModel.Keys)
                {
                    if (strKey == "Account")
                        continue;

                    if (lstArticle.Items.IndexOf(strKey + "." + dicModel[strKey]) >= 0)
                        lstArticle.SetItemChecked(lstArticle.Items.IndexOf(strKey + "." + dicModel[strKey]), true);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }
    }
}
