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

namespace AAA.BlogPublisher
{    
    public partial class PublishForm : Form
    {
        private Dictionary<string, IPublisher> _dicPublisher;
        public PublishForm()
        {
            InitializeComponent();

            _dicPublisher = new Dictionary<string, IPublisher>();
        }

        private void PublishForm_Load(object sender, EventArgs e)
        {
            FileInfo[] filesInfo;
            Assembly asmb = null;
            IPublisher publisher;
            string strNamespace;
            try
            {
                
                DirectoryInfo directoryInfo = new DirectoryInfo(Environment.CurrentDirectory + @"\publisher");
                filesInfo = directoryInfo.GetFiles("*.dll");

                while(lstAuto.Items.Count > 0)
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void btnPublishAuto_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < lstAuto.CheckedItems.Count; i++)
                {
                    _dicPublisher[lstAuto.CheckedItems[i].ToString()].Login();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }
    }
}
