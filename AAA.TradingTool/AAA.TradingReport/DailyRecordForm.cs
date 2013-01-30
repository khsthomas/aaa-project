using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AAA.TradeAPI.SPF;
using AAA.Meta.Trade.Data;

namespace AAA.TradingReport
{
    public partial class DailyRecordForm : Form
    {
        private SPFStructure _orderStatusTaiwanStructure;
        private SPFStructure _todayEquityStructure;
        private SPFStructure _historyEquityStructure;
        private AccountInfo _accountInfo;
        private SPFBase _spfBase;

        public DailyRecordForm()
        {
            InitializeComponent();

            dtpStartDate.Value = DateTime.Today.AddMonths(-2).AddDays(1);
            InitTable();
            _spfBase = new SPFBase();
            _spfBase.OnMessage(new AAA.Meta.Trade.MessageEvent(OnMessageReceive));
        }

        private void InitTable()
        {
            tblReport.Columns.Add("tdate", "交易日期");
            tblReport.Columns.Add("fee", "手續費");
            tblReport.Columns.Add("tax", "交易稅");
            tblReport.Columns.Add("fcon", "平倉損益");
            tblReport.Columns.Add("bid_qty", "買進口數");
            tblReport.Columns.Add("ask_qty", "賣出口數");

            tblOrderRecord.Columns.Add("OrderTime", "時間");
            tblOrderRecord.Columns.Add("TradeType", "異動");
            tblOrderRecord.Columns.Add("Code", "商品代碼");
            tblOrderRecord.Columns.Add("Price", "委託價");
            tblOrderRecord.Columns.Add("ContractPrice", "成交價");
            tblOrderRecord.Columns.Add("CancelQty", "刪單量");
            tblOrderRecord.Columns.Add("ContractQty", "成交量");
            tblOrderRecord.Columns.Add("StatusMessage", "類別");            
            tblOrderRecord.Columns.Add("ErrorCode", "回應碼");
            tblOrderRecord.Columns.Add("ErrorMessage", "訊息");
        }

        private void OnMessageReceive(Dictionary<string, object> dicReturn)
        {
            if (!dicReturn.ContainsKey("name"))
                return;

            string strName = dicReturn["name"].ToString();
            int iRecordCount;
            Dictionary<string, object> dicChildren;

            if (strName == _historyEquityStructure.ClientName)
            {
                iRecordCount = int.Parse(dicReturn["Count"].ToString());

                for (int i = 0; i < iRecordCount; i++)
                {
                    dicChildren = (Dictionary<string, object>)dicReturn["Children" + i];
                    tblReport.Rows.Add(new object[] { dicChildren["TDate"].ToString(), 
                                                      double.Parse(dicChildren["Fee"].ToString()).ToString("0"),
                                                      double.Parse(dicChildren["Tax"].ToString()).ToString("0"),
                                                      double.Parse(dicChildren["FCon"].ToString()).ToString("0"),
                                                      double.Parse(dicChildren["BidQty"].ToString()).ToString("0"),
                                                      double.Parse(dicChildren["AskQty"].ToString()).ToString("0")
                                                    });
                }

                tblReport.Rows.Add(new object[] { "總計",
                                                  double.Parse(dicReturn["FeeTotal"].ToString()).ToString("0"),
                                                  double.Parse(dicReturn["TaxTotal"].ToString()).ToString("0"),
                                                  double.Parse(dicReturn["FConTotal"].ToString()).ToString("0"),
                                                  double.Parse(dicReturn["BidTotal"].ToString()).ToString("0"),
                                                  double.Parse(dicReturn["AskTotal"].ToString()).ToString("0")
                                                });
                txtProfit.Text = (double.Parse(dicReturn["FConTotal"].ToString()) -
                                  double.Parse(dicReturn["FeeTotal"].ToString()) -
                                  double.Parse(dicReturn["TaxTotal"].ToString())).ToString("0");
            }


            if (strName == _orderStatusTaiwanStructure.ClientName)
            {
                iRecordCount = int.Parse(dicReturn["Count"].ToString());

                for (int i = 0; i < iRecordCount; i++)
                {
                    dicChildren = (Dictionary<string, object>)dicReturn["Children" + i];
                    tblOrderRecord.Rows.Add(new object[] { dicChildren["OrderTime"].ToString(), 
                                                          dicChildren["TradeType"].ToString(),
                                                          dicChildren["Code"].ToString(),
                                                          double.Parse(dicChildren["Price"].ToString()).ToString("0"),
                                                          double.Parse(dicChildren["ContractPrice"].ToString()).ToString("0"),
                                                          double.Parse(dicChildren["CancelQty"].ToString()).ToString("0"),
                                                          double.Parse(dicChildren["ContractQty"].ToString()).ToString("0"),
                                                          dicChildren["StatusMessage"].ToString(),
                                                          dicChildren["ErrorCode"].ToString(),
                                                          dicChildren["ErrorMessage"].ToString()
                                                        });
                }
            }
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            
            _accountInfo = new AccountInfo();     
            object oReturn;
            Dictionary<string, object> dicValue;            

            _orderStatusTaiwanStructure = new OrderStatusTaiwanStructure();
            _todayEquityStructure = new TodayEquityStructure();
            _historyEquityStructure = new HistoryEquityStructure();

            _spfBase.AddMessageStructure(_orderStatusTaiwanStructure);
            _spfBase.AddMessageStructure(_todayEquityStructure);
            _spfBase.AddMessageStructure(_historyEquityStructure);

            try
            {
                


                _spfBase.InitProgram(_accountInfo);
                oReturn = _spfBase.Login();

                txtAccount.Text = _accountInfo.AccountName + "(" + _accountInfo.AccountNo + ")";

                _spfBase.MessageSend(_orderStatusTaiwanStructure.ClientName, new Dictionary<string,object>());


                dicValue = new Dictionary<string, object>();
                dicValue.Add(TodayEquityStructure.BRANCH, _accountInfo.Branch);
                dicValue.Add(TodayEquityStructure.ACCOUNT_NO, _accountInfo.AccountNo);
                _spfBase.MessageSend(_todayEquityStructure.ClientName, dicValue);


                dicValue = new Dictionary<string, object>();
                dicValue.Add(HistoryEquityStructure.BRANCH, _accountInfo.Branch);
                dicValue.Add(HistoryEquityStructure.ACCOUNT_NO, _accountInfo.AccountNo);
                dicValue.Add(HistoryEquityStructure.START_DATE, dtpStartDate.Value.ToString("yyyyMMdd"));
                dicValue.Add(HistoryEquityStructure.END_DATE, dtpEndDate.Value.ToString("yyyyMMdd"));
                _spfBase.MessageSend(_historyEquityStructure.ClientName, dicValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }

        private void DailyRecordForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_spfBase != null)
                _spfBase.Login();
        }


    }
}
