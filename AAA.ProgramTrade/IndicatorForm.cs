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

        private void LoadIndicator()
        {
            try
            {
                _lstFunction = (List<IFunction>)Builder.LoadLibrary<IFunction>(Environment.CurrentDirectory + @"\Function");

                while (cboIndicator.Items.Count > 0)
                    cboIndicator.Items.RemoveAt(0);

                foreach (IFunction function in _lstFunction)
                    cboIndicator.Items.Add(function.DisplayName);
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

                strNames = function.VariableNames;
                strDescs = function.VariableDescs;
                oValues = function.DefaultValues;

                for(int i = 0; i < strNames.Length; i++)
                    DataGridViewUtil.InsertRow(tblParameter, new object[] {strNames[i], strDescs[i], oValues[i]});

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }
    }
}
