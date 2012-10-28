using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AAA.Base.Util.Reader;
using AAA.Forms.Components.Util;

namespace AAA.ProgramTrade
{
    public partial class ScheduleForm : Form
    {
        public ScheduleForm()
        {
            InitializeComponent();
            InitTable();
            InitTask();
        }

        private void InitTable()
        {
            tblTask.Columns.Add("TaskName", "名稱");
            tblTask.Columns.Add("Classname", "類別名稱");
            tblTask.Columns.Add("Type", "執行方式");
            tblTask.Columns.Add("StartTime", "開始時間");
            tblTask.Columns.Add("EndTime", "結束時間");
            tblTask.Columns.Add("Interval", "執行間隔(分鐘)");
        }

        private void InitTask()
        {
            IniReader iniReader = null;
            try
            {
                iniReader = new IniReader(Environment.CurrentDirectory + @"\cfg\task.ini");

                foreach (string strTask in iniReader.Section)
                {
                    DataGridViewUtil.InsertRow(tblTask, new object[] { strTask,
                                                                       iniReader.GetParam(strTask, "Classname", ""),
                                                                       iniReader.GetParam(strTask, "TaskType", ""),
                                                                       iniReader.GetParam(strTask, "StartTime", ""),
                                                                       iniReader.GetParam(strTask, "EndTime", ""),
                                                                       iniReader.GetParam(strTask, "Interval", "")});

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

    }
}
