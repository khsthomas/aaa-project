using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AAA.TradingTool
{
    public partial class KeyGeneratorForm : Form
    {
        private const string DEFAULT_KEY = "!alex.kuo@0937311250";
        private const int[] INDEX = new int[] {15, 28, 46, 81, 75, 99, 61, 25, 53, 36, 
                                               47,  8, 29, 33, 83, 77, 68,  3, 19, 93,
                                               27, 73, 53, 61, 87};
        //ID = 10
        //PW = 7
        //Date = 8;

        public KeyGeneratorForm()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            
        }
    }
}
