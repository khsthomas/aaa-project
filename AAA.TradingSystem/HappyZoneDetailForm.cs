using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AAA.TradingSystem
{
    public partial class HappyZoneDetailForm : Form
    {        
        public HappyZoneDetailForm() : this("2330", "台積電")
        {
        }

        public HappyZoneDetailForm(string strSymbolId, string strSymbolName)
        {
            InitializeComponent();
            InitTable();
            txtSymbolName.Text = strSymbolId + "-" + strSymbolName;
        }

        private void InitTable()
        {
            try
            {
                tblSymbolGrid.Columns.Add("EntryPoint", "進場點");
                tblSymbolGrid.Columns.Add("AddPoint", "加碼點");
                tblSymbolGrid.Columns.Add("TrailingStop", "Trailing Stop");
                tblSymbolGrid.Columns.Add("ExitLong", "六日價格通道");
                tblSymbolGrid.Columns.Add("ExitShort", "六日價格通道");
                tblSymbolGrid.Columns.Add("ATR14D", "ATR(14D)");
                tblSymbolGrid.Columns.Add("ExDate", "Date");

                tblLongPosition.Columns.Add("Position", "倉位");
                tblLongPosition.Columns.Add("Price", "價格");
                tblLongPosition.Columns.Add("StopPoint", "停損點");
                tblLongPosition.Columns.Add("CurrentProfit", "浮動損益");
                tblLongPosition.Columns.Add("StopProfit", "停損後損益");

                tblShortPosition.Columns.Add("Position", "倉位");
                tblShortPosition.Columns.Add("Price", "價格");
                tblShortPosition.Columns.Add("StopPoint", "停損點");
                tblShortPosition.Columns.Add("CurrentProfit", "浮動損益");
                tblShortPosition.Columns.Add("StopProfit", "停損後損益");

                tblEquality.Columns.Add("One", "一口");
                tblEquality.Columns.Add("Two", "二口");
                tblEquality.Columns.Add("Three", "三口");
                tblEquality.Columns.Add("Four", "四口");
                tblEquality.Columns.Add("Five", "五口");
            }
            catch (Exception ex)
            {
            }
        }
    }
}
