using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using AAA.Forms.Components.Util;
using AAA.TradeLanguage.Data;

namespace AAA.ProgramTrade.Component
{
    public partial class TradeSymbolSettingPanel : UserControl
    {
        private string _strConfigName;

        public string ConfigName
        {
            get { return _strConfigName; }
            set { _strConfigName = value; }
        }

        public TradeSymbolSettingPanel()
        {
            InitializeComponent();
            InitUI();
        }

        private void InitUI()
        {
            //商品類別選項
            cboSymbolType.Items.Add("台指");
            cboSymbolType.Items.Add("小台");
            cboSymbolType.Items.Add("選擇權買權");
            cboSymbolType.Items.Add("選擇權賣權");
            cboSymbolType.SelectedIndex = 0;

            cboPriceType.Items.Add("市價單");
            cboPriceType.Items.Add("限價單");
            cboPriceType.SelectedIndex = 0;

            //期貨設定
            cboFuturesMonth.Items.Add("近月");
            cboFuturesMonth.Items.Add("遠月");
            cboFuturesMonth.Items.Add("季月1");
            cboFuturesMonth.Items.Add("季月2");
            cboFuturesMonth.Items.Add("季月3");
            cboFuturesMonth.SelectedIndex = 0;

            //選擇權設定
            cboOptionsSide.Items.Add("買方");
            cboOptionsSide.Items.Add("賣方");
            cboOptionsSide.SelectedIndex = 0;

            cboExecutePrice.Items.Add("價平");
            cboExecutePrice.Items.Add("價內");
            cboExecutePrice.Items.Add("價外");
            cboExecutePrice.SelectedIndex = 0;

            cboPriceZone.Items.Add("0");
            cboPriceZone.Items.Add("1");
            cboPriceZone.Items.Add("2");
            cboPriceZone.Items.Add("3");
            cboPriceZone.Items.Add("4");
            cboPriceZone.Items.Add("5");
            cboPriceZone.Items.Add("6");
            cboPriceZone.Items.Add("7");
            cboPriceZone.Items.Add("8");
            cboPriceZone.SelectedIndex = 0;

            cboOptionsMonth.Items.Add("近月");
            cboOptionsMonth.Items.Add("遠月");
            cboOptionsMonth.Items.Add("季月1");
            cboOptionsMonth.Items.Add("季月2");
            cboOptionsMonth.Items.Add("季月3");
            cboOptionsMonth.SelectedIndex = 0;

            //策略列表
            //tblStrategy.Columns.Add("IsActive", "啟動");
            DataGridViewCheckBoxColumn checkBox = new DataGridViewCheckBoxColumn();
            checkBox.Name = "啟動";
            tblStrategy.Columns.Add(checkBox);
            tblStrategy.Columns.Add("Strategy", "策略名稱");
            tblStrategy.Columns.Add("SymbolType", "商品別");
            tblStrategy.Columns.Add("SymbolSeq", "商品序號");
            tblStrategy.Columns.Add("PriceType", "價格別");
            tblStrategy.Columns.Add("DayTrade", "當沖");
            tblStrategy.Columns.Add("Volume", "下單口數");
            tblStrategy.Columns.Add("ExitSignal", "送出平倉訊號");
            tblStrategy.Columns.Add("ContractType", "合約別");
            tblStrategy.Columns.Add("Slippage", "滑價");
            tblStrategy.Columns.Add("OrderDirection", "買賣別");
            tblStrategy.Columns.Add("ExecutePrice", "履約價別");
            tblStrategy.Columns.Add("PriceZone", "檔次");
        }

        private void InitStrategy()
        {
            StreamReader sr = null;
            string strLine;
            string[] strValues;
            TradeSymbol tradeSymbol;
            try
            {
                if (File.Exists((string)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.PROGRAM_ROOT_PATH] + @"\cfg\strategy.cfg") == false)
                    return;

                sr = new StreamReader((string)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.PROGRAM_ROOT_PATH] + @"\cfg\strategy.cfg", Encoding.Default);

                sr.ReadLine();

                while ((strLine = sr.ReadLine()) != null)
                {
                    strValues = strLine.Split('\t');
                    DataGridViewUtil.InsertRow(tblStrategy, strValues);
//                    RestoreStrategy(tblStrategy.Rows.Count - 1);
                    tradeSymbol = new TradeSymbol();
//                    BuildStrategy(tradeSymbol);
//                    _tradingRule.AddSignalSymbolMapping(txtStrategyName.Text, tradeSymbol);

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

    }
}
