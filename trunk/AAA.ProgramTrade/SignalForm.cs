using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AAA.Trade.SignalCatcher;
using AAA.Base.Util.Reader;
using AAA.Base.Util.Reflection;
using AAA.Meta.Trade;
using AAA.Meta.Trade.Data;
using System.Threading;
using AAA.Forms.Components.Util;
using AAA.DesignPattern.Observer;

namespace AAA.ProgramTrade
{
    public partial class SignalForm : Form
    {
        private Dictionary<string, SignalCatcher> _dicSignalCatcher;

        public SignalForm()
        {
//            CheckForIllegalCrossThreadCalls = false;            
            InitializeComponent();
            InitSystem();
        }

        private void InitSystem()
        {
            IniReader iniReader;
            List<string> lstCatcherName;
            SignalCatcher signalCatcher;
            string[] strCatcherParams;

            try
            {
                iniReader = new IniReader(Environment.CurrentDirectory + @"\cfg\system.ini");

                //Init SignalCatcher
                while (tblSignalCatcher.Rows.Count > 0)
                    tblSignalCatcher.Rows.RemoveAt(0);
                while (tblSignalCatcher.Columns.Count > 0)
                    tblSignalCatcher.Columns.RemoveAt(0);

                tblSignalCatcher.Columns.Add("CatcherName", "Catcher Name");
                tblSignalCatcher.Columns.Add("Instance", "Instance");

                while (tblSignalList.Rows.Count > 0)
                    tblSignalList.Rows.RemoveAt(0);
                while (tblSignalList.Columns.Count > 0)
                    tblSignalList.Columns.RemoveAt(0);
                tblSignalList.Columns.Add("Strategy", "Strategy");
                tblSignalList.Columns.Add("Symbol", "Symbol");
                tblSignalList.Columns.Add("Order", "Order");
                tblSignalList.Columns.Add("OrderType", "Order Type");
                tblSignalList.Columns.Add("Signal", "Signal");
                tblSignalList.Columns.Add("TimeFilled", "Time Filled");
                tblSignalList.Columns.Add("TimePlaced", "Time Placed");
                tblSignalList.Columns.Add("TimeTriggered", "Time Trigger");
                tblSignalList.Columns.Add("FillPrice", "Fill Price");                

                while (tblOpenPosition.Rows.Count > 0)
                    tblOpenPosition.Rows.RemoveAt(0);
                while (tblOpenPosition.Columns.Count > 0)
                    tblOpenPosition.Columns.RemoveAt(0);

                tblOpenPosition.Columns.Add("Strategy", "Strategy");
                tblOpenPosition.Columns.Add("Symbol", "Symbol");
                tblOpenPosition.Columns.Add("Order", "Order");
                tblOpenPosition.Columns.Add("OrderType", "Order Type");
                tblOpenPosition.Columns.Add("Signal", "Signal");
                tblOpenPosition.Columns.Add("EntryTime", "Entry Time");
                tblOpenPosition.Columns.Add("EntryPrice", "Entry Price");
                tblOpenPosition.Columns.Add("ExitPrice", "Exit Price");


                lstCatcherName = iniReader.GetKey("SignalCatcher");
                foreach (string strCatcherName in lstCatcherName)
                {
                    try
                    {
                        strCatcherParams = iniReader.GetParam("SignalCatcher", strCatcherName).Split(',');
                        signalCatcher = (SignalCatcher)Builder.CreateInstance<SignalCatcher>(strCatcherParams[0], strCatcherParams[1]);
                        signalCatcher.OnFilledOrderEvent += new FilledOrderEvent(FilledOrder);
                        signalCatcher.OnActiveOrderEvent += new ActiveOrderEvent(ActiveOrder);
                        signalCatcher.OnCanceledOrderEvent += new CanceledOrderEvent(CancelOrder);
                        signalCatcher.OnOpenPositionEvent += new OpenPositionEvent(OpenPosition);                        
                        tblSignalCatcher.Rows.Add(new object[] {strCatcherName, signalCatcher.ToString()});
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + "," + ex.StackTrace);
                        lstLog.Items.Add(ex.Message + "," + ex.StackTrace);
                    }

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void FilledOrder(SignalInfo signalInfo)
        {
            try
            {
                DataGridViewUtil.InsertRow(tblSignalList,
                                            new string[] {signalInfo.Strategy,
                                                          signalInfo.Symbol,
                                                          signalInfo.Order,
                                                          signalInfo.OrderType,
                                                          signalInfo.Signal,
                                                          signalInfo.TimeFilled.ToString("yyyy/MM/dd HH:mm:ss"),
                                                          signalInfo.TimePlaced.ToString("yyyy/MM/dd HH:mm:ss"),
                                                          DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                                                          signalInfo.FillPrice});
                
                IMessageInfo messageInfo = new MessageInfo();
                messageInfo.MessageSubject = "FilledOrder";
                messageInfo.Message = signalInfo;
                MessageSubject.Instance().Subject.Notify(messageInfo);

                
            }
            catch (Exception ex)
            {
                lstLog.Items.Add(ex.Message + "," + ex.StackTrace);
            }
        }

        private void ActiveOrder(SignalInfo signalInfo)
        {
            try
            {
/*
                DataGridViewUtil.InsertRow(tblSignalList,
                                            new string[] { signalInfo.Symbol,
                                                          signalInfo.Order,
                                                          signalInfo.OrderType,
                                                          signalInfo.Signal,
                                                          signalInfo.TimeFilled.ToString("yyyy/MM/dd HH:mm:ss"),
                                                          signalInfo.TimePlaced.ToString("yyyy/MM/dd HH:mm:ss"),
                                                          signalInfo.FillPrice,
                                                          signalInfo.Strategy});
 */ 
            }
            catch (Exception ex)
            {
                lstLog.Items.Add(ex.Message + "," + ex.StackTrace);
            }

        }

        private void CancelOrder(SignalInfo signalInfo)
        {
        }

        private void OpenPosition(SignalInfo signalInfo)
        {
            try
            {
                DataGridViewUtil.InsertRow(tblOpenPosition,
                                            new string[] {signalInfo.Strategy,
                                                          signalInfo.Symbol,
                                                          signalInfo.Order,
                                                          signalInfo.OrderType,
                                                          signalInfo.Signal,
                                                          signalInfo.TimeFilled.ToString("yyyy/MM/dd HH:mm:ss"),
                                                          signalInfo.EntryPrice,
                                                          ""
                                            });

            }
            catch (Exception ex)
            {
                lstLog.Items.Add(ex.Message + "," + ex.StackTrace);
            }

        }

    }
}
