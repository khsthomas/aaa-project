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
    public partial class HappyZoneMasterForm : Form
    {
        public HappyZoneMasterForm()
        {
            InitializeComponent();
            InitTable();
        }

        private void InitTable()
        {
            try
            {
                tblSymbolGrid.Columns.Add("SymbolId", "商品代碼");
                tblSymbolGrid.Columns.Add("SymbolName", "商品名稱");
                tblSymbolGrid.Columns.Add("Price", "目前報價");                
                tblSymbolGrid.Columns.Add("LongEntryPrice", "多方進場價");
                tblSymbolGrid.Columns.Add("ShortEntryPrice", "空方進場價");
                tblSymbolGrid.Columns.Add("Position", "目前倉位");
                tblSymbolGrid.Columns.Add("AddPrice", "加碼進場價");
                tblSymbolGrid.Columns.Add("StopPrice", "停損出場價");

                tblSymbolGrid.Rows.Add(new object[] { "2330", "台積電", "0", "0", "0", "0", "0", "0"});

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void DisplayDetail(int iSelectedRow)
        {
            Form happyZoneDetailForm;
            string strSymbolId;
            string strSymbolName;
            try
            {
                if (iSelectedRow < 0)
                    return;

                strSymbolId = tblSymbolGrid.Rows[iSelectedRow].Cells["SymbolId"].Value.ToString();
                strSymbolName = tblSymbolGrid.Rows[iSelectedRow].Cells["SymbolName"].Value.ToString();

                happyZoneDetailForm = new HappyZoneDetailForm(strSymbolId, strSymbolName);
                MdiFormUtil.AddChild(this.MdiParent, happyZoneDetailForm, false);

            }
            catch (Exception ex)
            {
            }
        }

        private void tblSymbolGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DisplayDetail(e.RowIndex);            
        }

        private void tblSymbolGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DisplayDetail(e.RowIndex);
        }

        
    }
}
