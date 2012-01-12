using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AAA.Command.WCF;
using System.ServiceModel;
using AAA.Communication.WCFService;
using AAA.Base.Util.WCF;
using AAA.Base.Util.Reader;
using System.IO;
using AAA.PublisherService.Command;
using System.Reflection;
using AAA.WebPublisher;

namespace AAA.PublisherManager
{
    public partial class MainForm : Form
    {
        private ServiceHost _serviceHost;
        private ServiceHost _crossDomainserviceHost;


        private int childFormNumber = 0;

        public MainForm()
        {
            InitializeComponent();
            CommandConfig.Config().Init(Environment.CurrentDirectory + @"\AAA.PublisherService.dll",
                                        "AAA.PublisherService.Config.command.ini");
            ReturnCode.Config().Init(Environment.CurrentDirectory + @"\AAA.PublisherService.dll",
                                     "AAA.PublisherService.Config.return_code.ini");
            StartService();

            UpdateArticleCategory();
            UpdatePublisher();
            UpdateAccount();
            tCheckUser.Interval = 60 * 60 * 1000;
            tCheckUser.Enabled = true;

            UserAlarmForm childForm = new UserAlarmForm();            
            childForm.MdiParent = this;
            childForm.Show();
        }

        public void UpdateAccount()
        {            
            Dictionary<string, string> dicModel = new Dictionary<string, string>();
            ICommand command;
            try
            {
                command = new UpdateAccountActiveCommand();
                command.Execute(dicModel);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }

        }

        private void UpdatePublisher()
        {
            IniReader iniReader = new IniReader(Environment.CurrentDirectory + @"\cfg\system.ini");
            string strPublisherFolder;
            string[] strPublishers;
            string strPublisher;
            string strNamespace;
            Dictionary<string, string> dicModel = new Dictionary<string, string>();
            ICommand command;
            Assembly asmb;
            IPublisher publisher;
            try
            {
                strPublisherFolder = iniReader.GetParam("PublisherFolder");

                strPublishers = Directory.GetFiles(strPublisherFolder);

                for (int i = 0; i < strPublishers.Length; i++)
                {
                    strPublisher = strPublishers[i].Substring(strPublishers[i].LastIndexOf('\\') + 1);
                    strNamespace = strPublisher.Replace(".dll", "");
                    asmb = Assembly.LoadFile(strPublisherFolder + @"\" + strPublisher);
                    if (asmb == null)
                        continue;
                    publisher = (IPublisher)asmb.CreateInstance(strNamespace + "." + strNamespace.Substring(strNamespace.LastIndexOf('.') + 1));
                    if (publisher == null)
                        continue;
                    dicModel.Add(publisher.WebSiteName, strPublisher);
                }

                command = new UpdateFunctionInfoCommand();
                command.Execute(dicModel);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }


        private void UpdateArticleCategory()
        {
            IniReader iniReader = new IniReader(Environment.CurrentDirectory + @"\cfg\system.ini");
            string strArticleFolder;            
            string[] strArticles;
            string strArticle;
            Dictionary<string, string> dicModel = new Dictionary<string, string>();
            ICommand command;
            try
            {
                strArticleFolder = iniReader.GetParam("ArticleFolder");

                strArticles = Directory.GetDirectories(strArticleFolder);

                for (int i = 0; i < strArticles.Length; i++)
                {
                    strArticle = strArticles[i].Substring(strArticles[i].LastIndexOf('\\') + 1);
                    dicModel.Add(strArticle.Split('.')[0], strArticle.Split('.')[1]);
                }

                command = new UpdateArticleCategoryCommand();
                command.Execute(dicModel);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void StartService()
        {
/*
            _serviceHost = new ServiceHost(typeof(CommandService));
            _crossDomainserviceHost = new ServiceHost(typeof(CrossDomainService));

            _serviceHost.Open();
            _crossDomainserviceHost.Open();
*/

            string strUrl = "net.tcp://127.0.0.1:8100/AAA.Communication.WCFService/CommandService";
            Uri address = new Uri(strUrl);            
            System.ServiceModel.Channels.Binding binding = WCFUtil.CreateBinding(strUrl.Split(':')[0]);
            _serviceHost = new ServiceHost(typeof(AAA.Communication.WCFService.CommandService), address);

            _serviceHost.AddServiceEndpoint(typeof(AAA.Communication.WCFService.ICommandService), binding, address);

            _serviceHost.Open();

        }
        
        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void MaxChildForm(Form form)
        {

            if (form.FormBorderStyle == FormBorderStyle.Sizable)
            {
                Rectangle mdiClientArea = Rectangle.Empty;
                foreach (Control c in Controls)
                    if (c is MdiClient)
                        mdiClientArea = c.ClientRectangle;

                form.Bounds = mdiClientArea;
            }
            form.MdiParent = this;
        }

        private void AccountListItem_Click(object sender, EventArgs e)
        {
            AccountManagement childForm = new AccountManagement();
            MaxChildForm(childForm);
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void tCheckUser_Tick(object sender, EventArgs e)
        {
            try
            {
                if (DateTime.Now.ToString("HH") != "00")
                    return;

                ICommand command = new UpdateAccountActiveCommand();
                command.Execute(new Dictionary<string, string>());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }        
    }
}
