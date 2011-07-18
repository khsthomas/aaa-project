using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AAA.Base.Util.Reader;

namespace ESWJ
{
    public partial class ProfileMgrFrm : Form
    {
        public ProfileMgrFrm()
        {
            InitializeComponent();
            Init();
        }

        private void Init() {
            IniReader iniReader = new IniReader(Environment.CurrentDirectory + @"\cfg\Account.ini");
            string[] strAccounts = iniReader.GetParam("AccountList").Split(',');
            for (int i = 0; i < strAccounts.Length; i++) {
                dgProfile.Rows.Add(new object[] {iniReader.GetParam(strAccounts[i], "Username"),
                                                 iniReader.GetParam(strAccounts[i], "Password"),
                                                 iniReader.GetParam(strAccounts[i], "Servername"),
                                                 iniReader.GetParam(strAccounts[i], "Url1"),
                                                 iniReader.GetParam(strAccounts[i], "Url2")});
            }
        }

        private void dgProfile_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FlashChildFrm flashForm = new FlashChildFrm();

            flashForm.FlashVars = dgProfile.Rows[e.RowIndex].Cells["Url1"].Value.ToString();
            flashForm.Movie = dgProfile.Rows[e.RowIndex].Cells["Url2"].Value.ToString();
            flashForm.MdiParent = this.MdiParent;
            flashForm.Show();
        }
    }
}
