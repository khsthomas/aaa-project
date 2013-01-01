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
using AAA.Base.Util.Reflection;
using AAA.Trade.SignalCatcher;

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
            int iScheduleInterval = 100;
            try
            {
                iniReader = new IniReader(Environment.CurrentDirectory + @"\cfg\system.ini");
                foreach (string strKey in iniReader.GetKey("System"))
                {
                    AAA.DesignPattern.Singleton.SystemParameter.Parameter[strKey] = iniReader.GetParam("System", strKey);
                }

                iScheduleInterval = int.Parse(iniReader.GetParam("System", "ScheduleInterval", "100"));

                MessageSubject.Instance().Subject.Attach(this);

                CurrentTime currentTime = new CurrentTime();
                PositionManager positionManager = new PositionManager();
                IDataSource dataSource = new DefaultDataSource();
                ScheduleManager scheduleManager = new ScheduleManager();
                StrategyManager strategyManager = new StrategyManager();
                
                scheduleManager.TimerInterval = iScheduleInterval;
                strategyManager.CurrentTime = currentTime;
                strategyManager.PositionManager = positionManager;

                currentTime.SessionStartTime = new DateTime(1900, 01, 01, 8, 45, 00);
                currentTime.SessionEndTime = new DateTime(1900, 01, 01, 13, 45, 00);
                currentTime.BaseSymbolId = iniReader.GetParam("System", "BaseSymbolId", "TFHTX-TP");

                AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.PROGRAM_ROOT_PATH] = Environment.CurrentDirectory;
                AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.TRADING_RULE] = new DefaultTradingRule();
                AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.SCHEDULE_MANAGER] = scheduleManager;
                AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.DATA_SOURCE] = dataSource;
                AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.CURRENT_TIME] = currentTime;
                AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.POSITION_MANAGER] = positionManager;
                AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.STRATEGY_MANAGER] = strategyManager;
                AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.SIGNAL_CATCHER] = new List<SignalCatcher>();
                currentTime.DataSource = dataSource;
                //dataSource.Attach(currentTime);
                currentTime.TimeInterval = 60;

                InitTask(Environment.CurrentDirectory + @"\cfg\task.ini");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }

        }

        private void InitTask(string strConfigFilename)
        {
            ScheduleManager scheduleManager = (ScheduleManager)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.SCHEDULE_MANAGER];
            IniReader iniReader = new IniReader(strConfigFilename);
            ITask task;
            string strClassname;
            string strRootPath = (string)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.PROGRAM_ROOT_PATH];
            TaskTypeEnum eType;
            DateTime dtStartTime;            
            DateTime dtEndTime;
            int iInterval;
            
            try
            {
                foreach (string strSection in iniReader.Section)
                {
                    try
                    {
                        dtEndTime = DateTime.MaxValue;
                        iInterval = int.MaxValue;

                        strClassname = iniReader.GetParam(strSection, "Classname");
                        eType = (TaskTypeEnum)Enum.Parse(typeof(TaskTypeEnum), iniReader.GetParam(strSection, "TaskType"));
                        dtStartTime = DateTime.Parse(DateTime.Now.ToString("yyyy/MM/dd ") + iniReader.GetParam(strSection, "StartTime"));

                        if (eType != TaskTypeEnum.Once)
                        {
                            dtEndTime = DateTime.Parse(DateTime.Now.ToString("yyyy/MM/dd ") + iniReader.GetParam(strSection, "EndTime"));
                            iInterval = int.Parse(iniReader.GetParam(strSection, "Interval")) * 60 * 1000; // Convert to minute
                        }

                        task = (ITask)Builder.CreateInstance<ITask>(strRootPath + @"\AAA.ProgramTrade.exe", strClassname);
                        task.TaskName = strSection;
                        task.StartTime = dtStartTime;
                        task.EndTime = dtEndTime;
                        task.Interval = iInterval;
                        task.TaskType = eType;                        
                        scheduleManager.AddTask(task);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + "," + ex.StackTrace);
                    }
                }
//                scheduleManager.Start();
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
            if (AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.AUTO_TRADE_PROGRAM] == null)
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
            try
            {
                if (ofdOpenFile.ShowDialog() != DialogResult.OK)
                    return;

                foreach (string strFilename in ofdOpenFile.FileNames)
                {
                    ProgramUtil.LoadOfflineData(strFilename, true);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }

        }

        private void dataMonitorItem_Click(object sender, EventArgs e)
        {
            MdiFormUtil.AddChild(this, new DataMonitorForm(), false);
        }

        private void chartItem_Click(object sender, EventArgs e)
        {
            MdiFormUtil.AddChild(this, new ChartXForm(), false);
        }

        private void calculateItem_Click(object sender, EventArgs e)
        {
            MdiFormUtil.AddChild(this, new IndicatorForm(), false);
        }

        private void performanceReportItem_Click(object sender, EventArgs e)
        {
            MdiFormUtil.AddChild(this, new PerformanceReportForm(), false);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if(AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.SCHEDULE_MANAGER] != null)
                    ((ScheduleManager)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.SCHEDULE_MANAGER]).Stop();                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Application.Exit();
        }

        private void offlineDataFeedItem_Click(object sender, EventArgs e)
        {
            MdiFormUtil.AddChild(this, new OfflineDataFeedForm(), false);
        }

        private void dataDownloadItem_Click(object sender, EventArgs e)
        {
            MdiFormUtil.AddChild(this, new DataDownloadForm(), false);
        }

        private void scheduleItem_Click(object sender, EventArgs e)
        {
            MdiFormUtil.AddChild(this, new ScheduleForm(), false);
        }

        private void realtimeStrategyItem_Click(object sender, EventArgs e)
        {
            MdiFormUtil.AddChild(this, new RealTimeStrategyForm(), false);
        }

        private void dailyReportItem_Click(object sender, EventArgs e)
        {
            if (AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.AUTO_TRADE_PROGRAM] == null)
            {
                MessageBox.Show("請先登入系統, 謝謝!!");
                return;
            }
            MdiFormUtil.AddChild(this, new DailyReportForm(), false);
        }

        private void futuresAPIMenu_Click(object sender, EventArgs e)
        {
            if (AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.ACCOUNT_INFO] == null)
            {
                MessageBox.Show("請先點選登入, 以讀取帳號資料, 謝謝!!");
                return;
            }
            MdiFormUtil.AddChild(this, new APIFuturesForm(), false);
        }
    }
}
