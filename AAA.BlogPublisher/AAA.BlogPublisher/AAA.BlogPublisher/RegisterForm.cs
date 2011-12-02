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

namespace AAA.BlogPublisher
{
    public partial class RegisterForm : Form
    {
        private Dictionary<string, IPublisher> _dicPublisher;
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
                _dicPublisher = new Dictionary<string, IPublisher>();
                while (lstAuto.Items.Count > 0)
                    lstAuto.Items.RemoveAt(0);

                lstPublisher = loadLibrary.LoadPublisher(Environment.CurrentDirectory + @"\publisher");

                for (int i = 0; i < lstPublisher.Count; i++)
                {
                    if (((AbstractPublisher)lstPublisher[i]).IsRegisterReleased == false)
                        continue;

                    lstAuto.Items.Add(lstPublisher[i].WebSiteName);

                    _dicPublisher.Add(lstPublisher[i].WebSiteName, lstPublisher[i]);
                }
                
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
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {

        }
    }
}
