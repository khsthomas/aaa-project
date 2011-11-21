using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using AAA.FTP;
using System.IO;
using AAA.Base.Util.Reader;

namespace AAA.Publisher.VersionCheck
{
    public partial class MainForm : Form
    {
        private string _strFTPHost;
        private string _strFTPPort;
        private string _strFTPUsername;
        private string _strFTPPassword;
        

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> dicResult;
            try
            {
                AAA.PublisherClient.PublisherClient publisherClient = new AAA.PublisherClient.PublisherClient();

                publisherClient.Connect();
                dicResult = publisherClient.LoginServer(txtAccount.Text, txtPassword.Text);
                MessageBox.Show(dicResult["ReturnMessage"]);

                if (dicResult["ReturnMessage"] == "登入成功")
                {
                    CheckVersion();
                    DownloadDll();
                    StartPublisher(txtAccount.Text, txtPassword.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        public void DownloadDll()
        {
            Dictionary<string, string> dicResult;
            string[] strDllList;
            string[] strDllFiles;
            FTPClient ftpClient = null;

            try
            {
                AAA.PublisherClient.PublisherClient publisherClient = new AAA.PublisherClient.PublisherClient();

                publisherClient.Connect();
                dicResult = publisherClient.GetFunctionList(txtAccount.Text);

                strDllList = dicResult["DllList"].Split(',');

                strDllFiles = Directory.GetFiles(Environment.CurrentDirectory + @"\publisher");

                for (int i = 0; i < strDllFiles.Length; i++)
                    try
                    {
                        File.Delete(strDllFiles[i]);
                    }
                    catch { }


                ftpClient = new FTPClient(_strFTPHost);
                ftpClient.Login(_strFTPUsername, _strFTPPassword);
                ftpClient.Chdir("Publisher");
                ftpClient.TransferType = FTPTransferType.BINARY;
                for (int i = 0; i < strDllList.Length; i++)
                {                  
                    ftpClient.Get(Environment.CurrentDirectory + @"\publisher\" + strDllList[i], strDllList[i]);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        public void CheckVersion()
        {
            Dictionary<string, string> dicResult;
            FTPClient ftpClient = null;
            
            IniReader iniReader = null;
            float fLocalVersion;
            float fServerVersion;
            string[] strFiles;

            try
            {
                AAA.PublisherClient.PublisherClient publisherClient = new AAA.PublisherClient.PublisherClient();
                
                publisherClient.Connect();
                dicResult = publisherClient.VersionCheckInfo();

                if (File.Exists(Environment.CurrentDirectory + @"\" + dicResult["VersionInfo"]) == false)
                {
                    fLocalVersion = 0;
                }
                else
                {
                    iniReader = new IniReader(Environment.CurrentDirectory + @"\" + dicResult["VersionInfo"]);
                    fLocalVersion = float.Parse(iniReader.GetParam("Version"));                    
                }

                _strFTPHost = dicResult["Host"];
                _strFTPPort = dicResult["Port"];
                _strFTPUsername = dicResult["Username"];
                _strFTPPassword = dicResult["Password"];

                ftpClient = new FTPClient(_strFTPHost, int.Parse(_strFTPPort));
                ftpClient.Login(_strFTPUsername, _strFTPPassword);
                ftpClient.Chdir(dicResult["PathName"]);

                ftpClient.TransferType = FTPTransferType.ASCII;
                ftpClient.Get(Environment.CurrentDirectory + @"\" + dicResult["VersionInfo"], dicResult["VersionInfo"]);
                

                iniReader = new IniReader(Environment.CurrentDirectory + @"\" + dicResult["VersionInfo"]);
                fServerVersion = float.Parse(iniReader.GetParam("Version"));
                strFiles = iniReader.GetParam("FileList").Split(',');

                if (fServerVersion > fLocalVersion)
                {
                    ftpClient.TransferType = FTPTransferType.BINARY;
                    for(int i = 0; i < strFiles.Length; i++)
                        ftpClient.Get(Environment.CurrentDirectory + @"\" + strFiles[i], strFiles[i]);
                }

                ftpClient.Quit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        public void StartPublisher(string strAccount, string strPassword)
        {
            StreamWriter sw = null;
            try
            {
                /*
                                Process process = new Process();
                                process.StartInfo.WorkingDirectory = Environment.CurrentDirectory;
                                process.StartInfo.FileName = "AAA.BlogPublisher.exe";
                                process.Start(); 
                */

                sw = new StreamWriter(Environment.CurrentDirectory + @"\user.ini");
                sw.WriteLine("Account=" + txtAccount.Text);
                sw.WriteLine("Password=" + txtPassword.Text);
                sw.WriteLine("FTPHost=" + _strFTPHost);
                sw.WriteLine("FTPPort=" + _strFTPPort);
                sw.WriteLine("FTPUsername=" + _strFTPUsername);
                sw.WriteLine("FTPPassword=" + _strFTPPassword);

                ProcessStartInfo Info = new ProcessStartInfo();
                //設定外部啟動程式名稱 
                Info.FileName = "AAA.BlogPublisher.exe";
                //設定外部啟動工作目錄 
                Info.WorkingDirectory = Environment.CurrentDirectory;
                //啟動外部程式 
                Process Star = Process.Start(Info);
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
            finally
            {
                if (sw != null)
                    sw.Close();
            }

        }
    }
}
