using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AAA.Base.Util.Reader;

namespace AAA.Scheduler
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitSetting();
        }

        private void InitSetting()
        {
            IniReader iniReader;

            try
            {

            }
            catch (Exception ex)
            {

            }
        }
    }
}
