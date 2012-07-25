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
            CurrentTime currentTime = (CurrentTime)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.CURRENT_TIME];
            IFunction function;
            int iOriginalInterval;
            try
            {                                
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
                LoadSymbolId();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }
    }
}
