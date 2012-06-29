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
using AAA.Schedule;
using System.IO;
using AAA.Meta.Quote.Data;
using AAA.Meta.Quote;
using AAA.DataSource;

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

                CurrentTime currentTime = new CurrentTime();
                IDataSource dataSource = new DefaultDataSource();

                AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.TRADING_RULE] = new DefaultTradingRule();
                AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.SCHEDULE_MANAGER] = new ScheduleManager();
                AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.DATA_SOURCE] = dataSource;
                AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.CURRENT_TIME] = currentTime;
                currentTime.DataSource = dataSource;
                dataSource.Attach(currentTime);
                currentTime.TimeInterval = 60;
                
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

        private void offlineDataItem_Click(object sender, EventArgs e)
        {
            StreamReader sr = null;
            string strSymbolId;
            string strDataCompression;
            string strLine;
            string[] strValues;
            List<BarData> lstBarData;
            BarData barData;
            BarCompressionEnum eBarCompression;
            try
            {
                if (ofdOpenFile.ShowDialog() != DialogResult.OK)
                    return;

                foreach (string strFilename in ofdOpenFile.FileNames)
                {
                    sr = new StreamReader(strFilename);

                    strSymbolId = sr.ReadLine().Trim();
                    strDataCompression = sr.ReadLine().Trim();
                    lstBarData = new List<BarData>();
                    eBarCompression = (BarCompressionEnum)Enum.Parse(typeof(BarCompressionEnum), strDataCompression);
 
                    while ((strLine = sr.ReadLine()) != null)
                    {
                        strValues = strLine.Split('\t');
                        barData = new BarData();
                        barData.SymbolId = strSymbolId;
                        barData.BarCompression = eBarCompression;
                        barData.BarDateTime = DateTime.Parse(strValues[0]);
                        barData.Open = float.Parse(strValues[1]);
                        barData.High = float.Parse(strValues[2]);
                        barData.Low = float.Parse(strValues[3]);
                        barData.Close = float.Parse(strValues[4]);
                        barData.Volume = float.Parse(strValues[5]);
                        barData.Amount = float.Parse(strValues[6]);

                        lstBarData.Add(barData);
                    }

                    sr.Close();

                    ((IDataSource)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.DATA_SOURCE]).AddSymbol(strSymbolId, lstBarData);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
            finally
            {
                if (sr != null)
                    sr.Close();
            }
        }

        private void dataMonitorItem_Click(object sender, EventArgs e)
        {
            MdiFormUtil.AddChild(this, new DataMonitorForm(), false);
        }

        private void chartItem_Click(object sender, EventArgs e)
        {
            MdiFormUtil.AddChild(this, new ChartForm(), false);
        }
    }
}
