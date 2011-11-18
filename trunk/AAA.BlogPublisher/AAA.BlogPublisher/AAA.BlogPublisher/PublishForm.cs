using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using AAA.WebPublisher;
using AAA.Base.Util.Reader;
using AAA.FTP;
using System.Threading;

namespace AAA.BlogPublisher
{    
    public partial class PublishForm : Form
    {
        private Dictionary<string, IPublisher> _dicPublisher;
        private Dictionary<string, string> _dicAccount;
        private Dictionary<string, string> _dicBlogname;
        private string _strAccount;
        private string _strPassword;

        public PublishForm()
        {
            InitializeComponent();

            _dicPublisher = new Dictionary<string, IPublisher>();
            _dicAccount = new Dictionary<string, string>();
            _dicBlogname = new Dictionary<string, string>();
        }

        private void PublishForm_Load(object sender, EventArgs e)
        {
            FileInfo[] filesInfo;
            Assembly asmb = null;
            IPublisher publisher;
            string strNamespace;
            IniReader iniReader = null;
            int iAccountCount;
            string[] strValues;

            string strFTPHost = null;
            string strFTPPort = null;
            string strFTPUsername = null;
            string strFTPPassword = null;
            string[] strCategories = null;
            string[] strDates = null;
            string[] strDownloadFiles = null;
            FTPClient ftpClient = null;
            Dictionary<string, string> dicCategoryDate = null;
            string strLastDate;
            StreamWriter sw = null;

            try
            {

                // Load publishers from local publisher's folder
                DirectoryInfo directoryInfo = new DirectoryInfo(Environment.CurrentDirectory + @"\publisher");
                filesInfo = directoryInfo.GetFiles("*.dll");

                while (lstAuto.Items.Count > 0)
                    lstAuto.Items.RemoveAt(0);

                while (lstCheck.Items.Count > 0)
                    lstCheck.Items.RemoveAt(0);

                for (int i = 0; i < filesInfo.Length; i++)
                {
                    try
                    {
                        strNamespace = filesInfo[i].Name.Replace(".dll", "");
                        asmb = Assembly.LoadFile(filesInfo[i].FullName);
                        publisher = (IPublisher)asmb.CreateInstance(strNamespace + "." + strNamespace.Substring(strNamespace.LastIndexOf('.') + 1));

                        _dicPublisher.Add(publisher.WebSiteName, publisher);

                        if (publisher.NeedPictureValidate)
                        {
                            lstCheck.Items.Add(publisher.WebSiteName);
                        }
                        else
                        {
                            lstAuto.Items.Add(publisher.WebSiteName);
                        }
                    }
                    catch
                    {
                    }
                }

                // Read the publisher account from account setting
                iniReader = new IniReader(Environment.CurrentDirectory + @"\cfg\account.ini");
                iAccountCount = int.Parse(iniReader.GetParam("AccountCount"));

                for (int i = 0; i < iAccountCount; i++)
                {
                    strValues = iniReader.GetParam("Account" + (i + 1)).Split(',');
                    lstAccount.Items.Add(strValues[1]);
                    _dicBlogname.Add(strValues[1], strValues[0]);
                    _dicAccount.Add(strValues[1], strValues[2]);
                }

                // Check login account and password
                if (File.Exists(Environment.CurrentDirectory + @"\user.ini") == false)
                {
                    MessageBox.Show("請先登入系統");
                    Application.Exit();
                }

                iniReader = new IniReader(Environment.CurrentDirectory + @"\user.ini");
                _strAccount = iniReader.GetParam("Account");
                _strPassword = iniReader.GetParam("Password");

                strFTPHost = iniReader.GetParam("FTPHost");
                strFTPPort = iniReader.GetParam("FTPPort");
                strFTPUsername = iniReader.GetParam("FTPUsername");
                strFTPPassword = iniReader.GetParam("FTPPassword");

//                File.Delete(Environment.CurrentDirectory + @"\user.ini");

                // Download new article from FTP server
                lstNewArticle.Items.Clear();
                AAA.PublisherClient.PublisherClient publishClient = new AAA.PublisherClient.PublisherClient();
                publishClient.Connect();
                strCategories = publishClient.GetArticleCategories(_strAccount);

                dicCategoryDate = new Dictionary<string, string>();
                iniReader = new IniReader(Environment.CurrentDirectory + @"\cfg\article.ini");
                for (int i = 0; i < strCategories.Length; i++)
                    dicCategoryDate.Add(strCategories[i], iniReader.GetParam("Default", strCategories[i], "19000101"));

                ftpClient = new FTPClient(strFTPHost, int.Parse(strFTPPort));
                ftpClient.Login(strFTPUsername, strFTPPassword);

                ftpClient.Chdir("Article");
                for (int i = 0; i < strCategories.Length; i++)
                {
                    strLastDate = dicCategoryDate[strCategories[i]];
                    ftpClient.Chdir(strCategories[i]);
                    strDates = ftpClient.Dir();

                    for (int j = 0; j < strDates.Length; j++)
                    {
                        if (strDates[j].CompareTo(strLastDate) <= 0)
                            continue;
                        ftpClient.Chdir(strDates[j]);
                        strDownloadFiles = ftpClient.Dir();

                        for (int k = 0; k < strDownloadFiles.Length; k++)
                        {
                            ftpClient.Get(Environment.CurrentDirectory + @"\articles\" + strDownloadFiles[k], strDownloadFiles[k]);
                            if (lstNewArticle.Items.IndexOf(strDownloadFiles[k]) < 0)
                                lstNewArticle.Items.Add(strDownloadFiles[k]);
                        }

                        ftpClient.Chdir("..");
                    }
                    dicCategoryDate[strCategories[i]] = strDates[strDates.Length - 1];
                    ftpClient.Chdir("..");
                }

                sw = new StreamWriter(Environment.CurrentDirectory + @"\cfg\article.ini");
                foreach (string strKey in dicCategoryDate.Keys)
                    sw.WriteLine(strKey + "=" + dicCategoryDate[strKey]);
                sw.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
            finally
            {
                if (sw != null)
                    sw.Close();

                filesInfo = (new DirectoryInfo(Environment.CurrentDirectory + @"\articles")).GetFiles();
                for (int i = 0; i < filesInfo.Length; i++)
                {
                    if (lstNewArticle.Items.IndexOf(filesInfo[i].Name) < 0)
                        lstNewArticle.Items.Add(filesInfo[i].Name);
                }

            }
        }

        private void btnPublishAuto_Click(object sender, EventArgs e)
        {
            string strAccount;
            string strPassword;
            string strBlogname;

            try
            {
                for (int i = 0; i < lstAuto.CheckedItems.Count; i++)
                {
                    Application.DoEvents();
                    while(pnlBrowser.Controls.Count > 0)
                        pnlBrowser.Controls.RemoveAt(0);
                    
                    pnlBrowser.Controls.Add(_dicPublisher[lstAuto.CheckedItems[i].ToString()].WebBrowser);

                    _dicPublisher[lstAuto.CheckedItems[i].ToString()].WebBrowser.Visible = true;
                    _dicPublisher[lstAuto.CheckedItems[i].ToString()].WebBrowser.Dock = DockStyle.Fill;
                    _dicPublisher[lstAuto.CheckedItems[i].ToString()].WebBrowser.ScrollBarsEnabled = true;

                    for (int j = 0; j < lstAccount.CheckedItems.Count; j++)
                    {
                        strAccount = lstAccount.Items[lstAccount.CheckedIndices[j]].ToString();
                        strPassword = _dicAccount[strAccount];
                        strBlogname = _dicBlogname[strAccount];

                        _dicPublisher[lstAuto.CheckedItems[i].ToString()].Logout();

                        _dicPublisher[lstAuto.CheckedItems[i].ToString()].Username = strAccount;
                        _dicPublisher[lstAuto.CheckedItems[i].ToString()].Password = strPassword;
                        _dicPublisher[lstAuto.CheckedItems[i].ToString()].Blogname = strBlogname;
                        if (_dicPublisher[lstAuto.CheckedItems[i].ToString()].Login() == false)
                        {
                            MessageBox.Show(_dicPublisher[lstAuto.CheckedItems[i].ToString()].ErrorMessage);
                            continue;
                        }

                        for (int k = 0; k < lstNewArticle.CheckedItems.Count; k++)
                        {
                            _dicPublisher[lstAuto.CheckedItems[i].ToString()].UploadPicture("");
                            if (_dicPublisher[lstAuto.CheckedItems[i].ToString()].PostArticle(Environment.CurrentDirectory + @"\articles\" + lstNewArticle.Items[lstNewArticle.CheckedIndices[k]]) == false)
                            {
                                MessageBox.Show(_dicPublisher[lstAuto.CheckedItems[i].ToString()].ErrorMessage);
                                continue;
                            }
                        }
                        Thread.Sleep(3000);
                        if(_dicPublisher[lstAuto.CheckedItems[i].ToString()].Logout() == false)
                            MessageBox.Show(_dicPublisher[lstAuto.CheckedItems[i].ToString()].ErrorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }
    }
}
