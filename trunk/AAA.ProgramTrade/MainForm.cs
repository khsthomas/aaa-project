using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AAA.Forms.Components.Util;
using AAA.Base.Util.Reader;
using AAA.DesignPattern.Observer;
using AAA.TradeLanguage;

namespace AAA.ProgramTrade
{
    public partial class MainForm : Form, IObserver
    {
        private int childFormNumber = 0;

        public MainForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            IniReader iniReader = null;
            
            try
            {
                iniReader = new IniReader(Environment.CurrentDirectory + @"\cfg\system.ini");
                foreach (string strKey in iniReader.GetKey("System"))
                {
                    AAA.DesignPattern.Singleton.SystemParameter.Parameter[strKey] = iniReader.GetParam(strKey);
                }

                MessageSubject.Instance().Subject.Attach(this);

                AAA.DesignPattern.Singleton.SystemParameter.Parameter["TradingRule"] = new DefaultTradingRule();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }

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

        private void catcherItem_Click(object sender, EventArgs e)
        {
            MdiFormUtil.AddChild(this, new SignalForm(), false);
        }

        private void autoTradeItem_Click(object sender, EventArgs e)
        {
            if (AAA.DesignPattern.Singleton.SystemParameter.Parameter["AutoTrade"] == null)
            {
                MessageBox.Show("請先登入系統, 謝謝!!");
                return;

            }

            MdiFormUtil.AddChild(this, new AutoTradeForm(), false);
        }

        private void loginItem_Click(object sender, EventArgs e)
        {
            MdiFormUtil.AddChild(this, new AccountManagement(), false);
        }

        #region IObserver Members

        public void Update(object oSource, IMessageInfo miMessage)
        {
            try
            {
                switch (miMessage.MessageSubject)
                {
                    case "Login":
                        statusStrip.Items["loginStatus"].Text = "已連線";
                        break;
                    case "Logout":
                        statusStrip.Items["loginStatus"].Text = "未連線";
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }

        }

        #endregion

        private void speedOrderItem_Click(object sender, EventArgs e)
        {
            MdiFormUtil.AddChild(this, new SpeedOrderForm(), false);
        }
    }
}
