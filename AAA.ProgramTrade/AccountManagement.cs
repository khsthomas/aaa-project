﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AAA.Base.Util.Reader;
using AAA.Trade;
using AAA.Meta.Trade.Data;
using AAA.DesignPattern.Observer;
using System.IO;
using AAA.Schedule;

namespace AAA.ProgramTrade
{
    public partial class AccountManagement : Form
    {        
        public AccountManagement()
        {
            InitializeComponent();

            ITrade autoTrade = null;
            AccountInfo accountInfo = null;

            if (AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.AUTO_TRADE_PROGRAM] == null)
            {
                IniReader iniReader = new IniReader((string)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.PROGRAM_ROOT_PATH] + @"\cfg\system.ini");
                txtUsername.Text = iniReader.GetParam("Account", "Username");
                txtPassword.Text = iniReader.GetParam("Account", "Password");
                txtCAPassword.Text = iniReader.GetParam("Account", "CAPassword");
                txtCAPath.Text = iniReader.GetParam("Account", "CAPath");
                txtAccountType.Text = iniReader.GetParam("Account", "AccountType");
                AAA.DesignPattern.Singleton.SystemParameter.Parameter["Branch"] = iniReader.GetParam("Account", "Branch");
                AAA.DesignPattern.Singleton.SystemParameter.Parameter["AccountNo"] = iniReader.GetParam("Account", "AccountNo");

                autoTrade = SystemHelper.CreateTrade();
                accountInfo = new AccountInfo();

                accountInfo.IdNo = txtUsername.Text;
                accountInfo.Password = txtPassword.Text;
                accountInfo.CAPassword = txtCAPassword.Text;
                accountInfo.CAPath = txtCAPath.Text;
                accountInfo.AccountType = txtAccountType.Text;
                if (AAA.DesignPattern.Singleton.SystemParameter.Parameter["Branch"] != null)
                    accountInfo.Branch = (string)AAA.DesignPattern.Singleton.SystemParameter.Parameter["Branch"];
                if (AAA.DesignPattern.Singleton.SystemParameter.Parameter["AccountNo"] != null)
                    accountInfo.AccountNo = (string)AAA.DesignPattern.Singleton.SystemParameter.Parameter["AccountNo"];

                autoTrade.InitProgram(accountInfo);
                AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.AUTO_TRADE_PROGRAM] = autoTrade;

            }
            else
            {
                autoTrade = (ITrade)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.AUTO_TRADE_PROGRAM];

                txtUsername.Text = autoTrade.AccountInfo.IdNo;
                txtPassword.Text = autoTrade.AccountInfo.Password;
                txtCAPassword.Text = autoTrade.AccountInfo.CAPassword;
                txtCAPath.Text = autoTrade.AccountInfo.CAPath;
                txtAccountType.Text = accountInfo.AccountType;
            }

            // Init Logger
            if (Directory.Exists((string)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.PROGRAM_ROOT_PATH] + @"\trade_logs") == false)
                Directory.CreateDirectory((string)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.PROGRAM_ROOT_PATH] + @"\trade_logs");

            if (AAA.DesignPattern.Singleton.SystemParameter.Parameter["InitTrade"] == null)
            {
                autoTrade.OnMessage(new AAA.Meta.Trade.MessageEvent(OnMessageReceive));
                autoTrade.AddTradeLogger(new TradeLogger((string)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.PROGRAM_ROOT_PATH] + @"\trade_logs\autotrade-" + DateTime.Now.ToString("yyyyMMdd") + ".log"));
                AAA.DesignPattern.Singleton.SystemParameter.Parameter["InitTrade"] = "Y";
            }

            cboMode.Items.Add("模擬模式");
            cboMode.Items.Add("實單模式");
            cboMode.SelectedIndex = 0 ;            
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                ITrade autoTrade = null;
                AccountInfo accountInfo = null;
                string strRC;

                if (btnConnect.Text == "連線")
                {
                    if (AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.AUTO_TRADE_PROGRAM] == null)
                    {
                        autoTrade = SystemHelper.CreateTrade();
                        accountInfo = new AccountInfo();

                        accountInfo.IdNo = txtUsername.Text;
                        accountInfo.Password = txtPassword.Text;
                        accountInfo.CAPassword = txtCAPassword.Text;
                        accountInfo.CAPath = txtCAPath.Text;
                        accountInfo.AccountType = txtAccountType.Text;
                        if (AAA.DesignPattern.Singleton.SystemParameter.Parameter["Branch"] != null)
                            accountInfo.Branch = (string)AAA.DesignPattern.Singleton.SystemParameter.Parameter["Branch"];
                        if (AAA.DesignPattern.Singleton.SystemParameter.Parameter["AccountNo"] != null)
                            accountInfo.AccountNo = (string)AAA.DesignPattern.Singleton.SystemParameter.Parameter["AccountNo"];

                        autoTrade.InitProgram(accountInfo);
                        AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.AUTO_TRADE_PROGRAM] = autoTrade;
                    }
                    else
                    {
                        autoTrade = (ITrade)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.AUTO_TRADE_PROGRAM];
                    }

                    strRC = (string)autoTrade.Login();
                    strRC += "\n" + (string)autoTrade.CA();
                    autoTrade.TradeMode = AAA.Meta.Trade.TradeModeEnum.Simulation;

                    IMessageInfo messageInfo = new MessageInfo();
                    messageInfo.MessageSubject = "Login";

                    MessageSubject.Instance().Subject.Notify(messageInfo);

                    MessageBox.Show(strRC);
                    btnConnect.Text = "中斷";
                }
                else
                {
                    autoTrade = (ITrade)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.AUTO_TRADE_PROGRAM];
                    autoTrade.Logout();

                    IMessageInfo messageInfo = new MessageInfo();
                    messageInfo.MessageSubject = "Logout";

                    MessageSubject.Instance().Subject.Notify(messageInfo);

                    btnConnect.Text = "連線";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void btnChangeMode_Click(object sender, EventArgs e)
        {
            if (AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.AUTO_TRADE_PROGRAM] == null)
            {
                MessageBox.Show("請先連線後, 再切換模式");
                return;
            }

            switch (cboMode.Text)
            {
                case "模擬模式":
                    ((ITrade)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.AUTO_TRADE_PROGRAM]).TradeMode = AAA.Meta.Trade.TradeModeEnum.Simulation;
                    break;

                case "實單模式":
                    ((ITrade)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.AUTO_TRADE_PROGRAM]).TradeMode = AAA.Meta.Trade.TradeModeEnum.Real;
                    break;
            }

            IMessageInfo messageInfo = new MessageInfo();
            messageInfo.MessageSubject = "ChangeTradeMode";

            MessageSubject.Instance().Subject.Notify(messageInfo);
        }


        private void OnMessageReceive(Dictionary<string, object> dicReturn)
        {
            try
            {

                MessageInfo messageInfo = new MessageInfo();
                messageInfo.MessageSubject = "OnTradeMessageReceive";
                messageInfo.Message = dicReturn;
                messageInfo.MessageTicks = DateTime.Now.Ticks;
                MessageSubject.Instance().Subject.Notify(messageInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void btnStartSchedule_Click(object sender, EventArgs e)
        {
            try
            {
                ((ScheduleManager)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.SCHEDULE_MANAGER]).Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

    }
}