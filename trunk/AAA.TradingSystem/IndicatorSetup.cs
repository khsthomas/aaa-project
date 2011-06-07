using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AAA.Forms.Components.Util;

namespace AAA.TradingSystem
{
    public partial class IndicatorSetup : Form
    {
        public IndicatorSetup()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                ListBoxUtil.MoveItem(lstSourceIndicator, lstTargetIndicator, AAA.Forms.Components.SelectionTypeEnym.Selected);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                ListBoxUtil.MoveItem(lstTargetIndicator, lstSourceIndicator, AAA.Forms.Components.SelectionTypeEnym.Selected);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }
    }
}
