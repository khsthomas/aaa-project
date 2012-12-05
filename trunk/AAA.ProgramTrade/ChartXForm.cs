using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AAA.DataSource;
using AAA.Meta.Quote.Data;

namespace AAA.ProgramTrade
{
    public partial class ChartXForm : Form
    {
        public ChartXForm()
        {
            InitializeComponent();
            RefreshSymbolList();
        }

        private void RefreshSymbolList()
        {
            IDataSource dataSource = ((IDataSource)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.DATA_SOURCE]);
            List<string> lstSymbolId = dataSource.GetSymbolList();

            cboSymbolId.Items.Clear();

            foreach (string strSymbolId in lstSymbolId)
                cboSymbolId.Items.Add(strSymbolId);

            if (cboSymbolId.Items.Count > 0)
                cboSymbolId.SelectedIndex = 0;

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshSymbolList();
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                List<BarRecord> lstBarRecord;

                lstBarRecord = ((IDataSource)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.DATA_SOURCE]).GetBar(cboSymbolId.Text);

                if (lstBarRecord == null)
                    return;

                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }


    }
}
