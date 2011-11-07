using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace AAA.BlogPublisher
{
    public partial class PublishForm : Form
    {
        public PublishForm()
        {
            InitializeComponent();
        }

        private void PublishForm_Load(object sender, EventArgs e)
        {
            FileInfo[] filesInfo;
            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(Environment.CurrentDirectory + @"\publisher");
                filesInfo = directoryInfo.GetFiles("*.dll");

                for (int i = 0; i < filesInfo.Length; i++)
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }
    }
}
