using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ESWJ
{
    public partial class WebFlashMaster : Form
    {
        private int childFormNumber = 0;

        public WebFlashMaster()
        {
            InitializeComponent();
            Init();
        }

        private void Init() {
            ProfileMgrFrm ProfileForm = new ProfileMgrFrm();
            ProfileForm.MdiParent = this;
            ProfileForm.Show();
        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
