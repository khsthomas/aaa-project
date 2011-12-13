using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AAA.Base.Util.Reader;
using AAA.WebPublisher;
using System.IO;

namespace AAA.BlogPublisher
{
    public partial class RegisterForm : Form
    {
        private Dictionary<string, AbstractPublisher> _dicPublisher;
        private string _strOriginalAccount;
        public RegisterForm()
        {
            InitializeComponent();
            txtConfigFile.Text = Environment.CurrentDirectory + @"\cfg\register.ini";
            InitTable();
            LoadLibrary();
        }

        private void LoadLibrary()
        {
            List<IPublisher> lstPublisher;
            LoadLibrary loadLibrary = new LoadLibrary();
            try
            {
                _dicPublisher = new Dictionary<string, AbstractPublisher>();
                while (lstAuto.Items.Count > 0)
                    lstAuto.Items.RemoveAt(0);

                while (cboPublisher.Items.Count > 0)
                    cboPublisher.Items.RemoveAt(0);

                lstPublisher = loadLibrary.LoadPublisher(Environment.CurrentDirectory + @"\publisher");

                for (int i = 0; i < lstPublisher.Count; i++)
                {
                    if (((AbstractPublisher)lstPublisher[i]).IsRegisterReleased == false)
                        continue;

                    lstAuto.Items.Add(lstPublisher[i].WebSiteName);
                    cboPublisher.Items.Add(lstPublisher[i].WebSiteName);
                    _dicPublisher.Add(lstPublisher[i].WebSiteName, (AbstractPublisher)lstPublisher[i]);
                }

                if (cboPublisher.Items.Count > 0)
                    cboPublisher.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void InitTable()
        {
            while (tblAccountInfo.Rows.Count > 0)
                tblAccountInfo.Rows.RemoveAt(0);

            tblAccountInfo.Columns.Add("ParamName", "項目");
            tblAccountInfo.Columns.Add("ParamValue", "內容");
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            IniReader iniReader = new IniReader(txtConfigFile.Text);
            
            foreach (string strName in iniReader.GetKey("Default"))
            {
                tblAccountInfo.Rows.Add(new string[] { strName, iniReader.GetParam(strName)});
                if (strName == "帳號")
                    _strOriginalAccount = iniReader.GetParam(strName);
            }
            chkAutoSeries.Checked = true;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> dicInfo;
            AbstractPublisher publisher = null;
            try
            {


                dicInfo = new Dictionary<string, string>();
                for (int i = 0; i < tblAccountInfo.Rows.Count; i++)
                    dicInfo.Add(tblAccountInfo.Rows[i].Cells["ParamName"].Value.ToString(),
                                tblAccountInfo.Rows[i].Cells["ParamValue"].Value.ToString());


                Application.DoEvents();
                while (pnlBrowser.Controls.Count > 0)
                    pnlBrowser.Controls.RemoveAt(0);

                publisher = _dicPublisher[cboPublisher.Text];

                pnlBrowser.Controls.Add(publisher.WebBrowser);

                publisher.WebBrowser.Visible = true;
                publisher.WebBrowser.Dock = DockStyle.Fill;
                publisher.WebBrowser.ScrollBarsEnabled = true;
                publisher.RegisterInfo = dicInfo;

                publisher.Logout();

                if (publisher.Register() == false)
                {
                    MessageBox.Show(publisher.ErrorMessage);
                }
                else
                {
                    WriteAccountInfo(publisher, dicInfo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }

/*
            Dictionary<string, string> dicInfo;

            try
            {
                

                dicInfo = new Dictionary<string, string>();
                for (int i = 0; i < tblAccountInfo.Rows.Count; i++)
                    dicInfo.Add(tblAccountInfo.Rows[i].Cells["ParamName"].Value.ToString(),
                                tblAccountInfo.Rows[i].Cells["ParamValue"].Value.ToString());

                for (int i = 0; i < lstAuto.CheckedItems.Count; i++)
                {
                    Application.DoEvents();
                    while (pnlBrowser.Controls.Count > 0)
                        pnlBrowser.Controls.RemoveAt(0);

                    pnlBrowser.Controls.Add(_dicPublisher[lstAuto.CheckedItems[i].ToString()].WebBrowser);

                    _dicPublisher[lstAuto.CheckedItems[i].ToString()].WebBrowser.Visible = true;
                    _dicPublisher[lstAuto.CheckedItems[i].ToString()].WebBrowser.Dock = DockStyle.Fill;
                    _dicPublisher[lstAuto.CheckedItems[i].ToString()].WebBrowser.ScrollBarsEnabled = true;
                    _dicPublisher[lstAuto.CheckedItems[i].ToString()].RegisterInfo = dicInfo;

                    _dicPublisher[lstAuto.CheckedItems[i].ToString()].Logout();

                    if (_dicPublisher[lstAuto.CheckedItems[i].ToString()].Register() == false)
                    {
                        MessageBox.Show(_dicPublisher[lstAuto.CheckedItems[i].ToString()].ErrorMessage);
                        continue;
                    }
                    WriteAccountInfo(_dicPublisher[lstAuto.CheckedItems[i].ToString()]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
 */ 
        }

        private void WriteAccountInfo(AbstractPublisher publisher, Dictionary<string, string> dicInfo)
        {
            StreamReader sr = null;
            StreamWriter sw = null;
            string strLine = null;
            List<string> lstLine;
            int iAccountCount = 0;
            try
            {
                lstLine = new List<string>();
                sr = new StreamReader(Environment.CurrentDirectory + @"\cfg\account.ini", Encoding.Default);

                while ((strLine = sr.ReadLine()) != null)
                {
                    lstLine.Add(strLine);
                    if (strLine.StartsWith("AccountCount"))
                    {
                        iAccountCount = int.Parse(strLine.Split('=')[1]);
                        lstLine[lstLine.Count - 1] = "AccountCount=" + (iAccountCount + 1).ToString();
                    }
                }
                sr.Close();

                sw = new StreamWriter(Environment.CurrentDirectory + @"\cfg\account.ini", false, Encoding.Default);

                for (int i = 0; i < lstLine.Count; i++)
                    sw.WriteLine(lstLine[i]);

                sw.WriteLine("Account" + (iAccountCount + 1).ToString() + "=" +
                             dicInfo["帳號"] + "," +
                             publisher.Blogname + "," +
                             publisher.Username + "," +
                             publisher.Password + "," +
                             publisher.WebSiteName);


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

        private void chkAutoSeries_CheckedChanged(object sender, EventArgs e)
        {
            int iRowIndex = 0;
            Random random = new Random();

            for (iRowIndex = 0; iRowIndex < tblAccountInfo.Rows.Count; iRowIndex++)
            {
                if (tblAccountInfo.Rows[iRowIndex].Cells["ParamName"].Value.ToString() == "帳號")
                    break;
            }

            if (iRowIndex < tblAccountInfo.Rows.Count)
            {
                if (chkAutoSeries.Checked)
                {
                    tblAccountInfo.Rows[iRowIndex].Cells["ParamValue"].Value = _strOriginalAccount + (random.NextDouble() * 1000000).ToString("0");
                }
                else
                {
                    tblAccountInfo.Rows[iRowIndex].Cells["ParamValue"].Value = _strOriginalAccount;
                }
            }
        }

        private void btnCreateBlog_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> dicInfo;
            AbstractPublisher publisher = null;
            try
            {


                dicInfo = new Dictionary<string, string>();
                for (int i = 0; i < tblAccountInfo.Rows.Count; i++)
                    dicInfo.Add(tblAccountInfo.Rows[i].Cells["ParamName"].Value.ToString(),
                                tblAccountInfo.Rows[i].Cells["ParamValue"].Value.ToString());


                Application.DoEvents();
                while (pnlBrowser.Controls.Count > 0)
                    pnlBrowser.Controls.RemoveAt(0);

                publisher = _dicPublisher[cboPublisher.Text];

                pnlBrowser.Controls.Add(publisher.WebBrowser);

                publisher.WebBrowser.Visible = true;
                publisher.WebBrowser.Dock = DockStyle.Fill;
                publisher.WebBrowser.ScrollBarsEnabled = true;
                publisher.RegisterInfo = dicInfo;

                publisher.Logout();

                if (publisher.CreateBlog() == false)
                {
                    MessageBox.Show(publisher.ErrorMessage);
                }
                else
                {
                    WriteAccountInfo(publisher, dicInfo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
            
        }
    }
}
