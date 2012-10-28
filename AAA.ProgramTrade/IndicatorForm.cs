using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AAA.Base.Util.Reflection;
using AAA.TradeLanguage;
using AAA.Forms.Components.Util;
using AAA.DataSource;
using AAA.Meta.Quote.Data;
using AAA.Quote;
using AAA.Meta.Quote;

namespace AAA.ProgramTrade
{
    public partial class IndicatorForm : Form
    {
        List<IFunction> _lstFunction;
        public IndicatorForm()
        {
            InitializeComponent();
            Init();
            LoadIndicator();
            LoadSymbolId();
        }

        private void Init()
        {
            try
            {
                tblParameter.Columns.Add("ItemName", "項目");
                tblParameter.Columns.Add("ItemDesc", "項目描述");
                tblParameter.Columns.Add("ItemValue", "參數值");

                cboTimeUnit.Items.Add("Min");
                cboTimeUnit.Items.Add("Daily");
                cboTimeUnit.Items.Add("Week");
                cboTimeUnit.Items.Add("Month");
                cboTimeUnit.Items.Add("Year");                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void LoadSymbolId()
        {
            IDataSource dataSource;
            List<string> lstSymbolId;
            try
            {
                dataSource = (IDataSource)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.DATA_SOURCE];
                lstSymbolId = dataSource.GetSymbolList();

                while (cboBaseSymbolId.Items.Count > 0)
                    cboBaseSymbolId.Items.RemoveAt(0);

                foreach (string strSymbolId in lstSymbolId)
                {
                    cboBaseSymbolId.Items.Add(strSymbolId);
                }

                if (cboBaseSymbolId.Items.Count > 0)
                    cboBaseSymbolId.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void LoadIndicator()
        {
            try
            {
                _lstFunction = (List<IFunction>)Builder.LoadClasses<IFunction>((string)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.PROGRAM_ROOT_PATH] + @"\Function");

                while (cboIndicator.Items.Count > 0)
                    cboIndicator.Items.RemoveAt(0);

                foreach (IFunction function in _lstFunction)
                    cboIndicator.Items.Add(function.DisplayName);

                if (cboIndicator.Items.Count > 0)
                    cboIndicator.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);                     
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                LoadIndicator();
                LoadSymbolId();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void cboIndicator_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (_lstFunction.Count == 0)
                    return;

                IFunction function = _lstFunction[cboIndicator.SelectedIndex];
                string[] strNames;
                string[] strDescs;
                object[] oValues;

                while (tblParameter.Rows.Count > 0)
                    tblParameter.Rows.RemoveAt(0);

                strNames = function.InputVariableNames;
                strDescs = function.InputVariableDescs;
                oValues = function.DefaultValues;

                for(int i = 0; i < strNames.Length; i++)
                    DataGridViewUtil.InsertRow(tblParameter, new object[] {strNames[i], strDescs[i], oValues[i]});

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> dicParam = new Dictionary<string,object>();

/*
            CurrentTime currentTime = (CurrentTime)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.CURRENT_TIME];
            IFunction function;
            int iOriginalInterval;
 */ 
            try
            {
                for (int i = 0; i < tblParameter.Rows.Count; i++)
                {
                    dicParam.Add(tblParameter.Rows[i].Cells["ItemName"].Value.ToString(),
                                 tblParameter.Rows[i].Cells["ItemValue"].Value);
                }

                ProgramUtil.RunFunction(_lstFunction[cboIndicator.SelectedIndex],
                                         cboBaseSymbolId.Text,
                                         dicParam);

/*
                function = _lstFunction[cboIndicator.SelectedIndex];
                function.SetCurrentTime(currentTime);
                function.BaseSymbolId = cboBaseSymbolId.Text;
                
                for (int i = 0; i < tblParameter.Rows.Count; i++)
                {
                    function.InputVariable(tblParameter.Rows[i].Cells["ItemName"].Value.ToString(),
                                           tblParameter.Rows[i].Cells["ItemValue"].Value);
                }

                iOriginalInterval = currentTime.TimeInterval;

                currentTime.RemoveSymbol(function.InputVariable("TransferSymbolId").ToString());
                currentTime.Reset();
                currentTime.TimeInterval = 60 * function.DataCompression.Interval;
                while (currentTime.CurrentDateTime.CompareTo(currentTime.DataEndTime) < 0)
                {
                    function.Calculate(function.InputVariable("TransferSymbolId").ToString().Trim() == "" ? null : function.InputVariable("TransferSymbolId").ToString().Trim());
                    currentTime.MoveNext();
                }
                currentTime.TimeInterval = iOriginalInterval;
 */ 
                LoadSymbolId();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            IDataSource dataSource;
            List<BarRecord> lstBarRecord = null; 
            List<BarRecord> lstTransfered = null;
            DataSummary dataSummary = new DataSummary();
            try
            {
                dataSource = (IDataSource)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.DATA_SOURCE];
                lstBarRecord = dataSource.GetBar(cboBaseSymbolId.Text);

                dataSummary.SessionStartTime = (dataSource.GetSessionStartTime(cboBaseSymbolId.Text) == null)
                                                ? "08:45"
                                                : dataSource.GetSessionStartTime(cboBaseSymbolId.Text);

                dataSummary.SessionEndTime = (dataSource.GetSessionEndTime(cboBaseSymbolId.Text) == null)
                                                ? "13:45"
                                                : dataSource.GetSessionEndTime(cboBaseSymbolId.Text);
                if(lstBarRecord == null)
                {
                    MessageBox.Show("所選之商品不存在, 謝謝");
                    return;
                }

                if (lstBarRecord.Count == 0)
                {
                    MessageBox.Show("所選之商品無資料, 謝謝");
                    return;
                }

                if (lstBarRecord[0].CompressionInterval != 1)
                {
                    MessageBox.Show("請選擇時間長度為1的商品, 謝謝");
                    return;
                }

                switch (lstBarRecord[0].BarCompression)
                {
                    case BarCompressionEnum.Min:
                        dataSummary.SetMinuteData(lstBarRecord);                        
                        break;
                    case BarCompressionEnum.Daily:
                        dataSummary.SetDayData(lstBarRecord);
                        break;
                    case BarCompressionEnum.Week:
                        dataSummary.SetWeekData(lstBarRecord);
                        break;
                    case BarCompressionEnum.Year:
                        dataSummary.SetYearData(lstBarRecord);
                        break;
                }

                switch ((BarCompressionEnum)Enum.Parse(typeof(BarCompressionEnum), cboTimeUnit.Text))
                {
                    case BarCompressionEnum.Min:
                        lstTransfered = dataSummary.ToMinuteData((int)nudTimeInterval.Value);
                        break;
                    case BarCompressionEnum.Daily:
                        lstTransfered = dataSummary.ToDailyData();
                        break;
                    case BarCompressionEnum.Week:
                        break;
                    case BarCompressionEnum.Month:
                        break;
                    case BarCompressionEnum.Year:
                        break;
                }

                if (lstTransfered != null)
                {
                    dataSource.AddSymbol(txtTransferSymbolId.Text, lstTransfered);
                    dataSource.SetSessionStartTime(txtTransferSymbolId.Text, dataSummary.SessionStartTime);
                    dataSource.SetSessionEndTime(txtTransferSymbolId.Text, dataSummary.SessionEndTime);
                    LoadSymbolId();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

    }
}
