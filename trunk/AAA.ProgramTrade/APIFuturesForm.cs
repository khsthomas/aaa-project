﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AAA.TradeAPI.Polaris;
using AAA.Meta.Trade.Data;
using AAA.Trade;

namespace AAA.ProgramTrade
{
    public partial class APIFuturesForm : Form
    {
        private PolarisBase _polarisBase;
        private AccountInfo _accountInfo;

        private Dictionary<string, Dictionary<string, object>> _dicExecuteResult;

        public APIFuturesForm()
        {
            InitializeComponent();

            _dicExecuteResult = new Dictionary<string, Dictionary<string, object>>();

            try
            {
                PolarisStructure structure;

                _accountInfo = ((AccountInfo)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.ACCOUNT_INFO]);
                _polarisBase = new PolarisBase();
                _polarisBase.OnMessage(new AAA.Meta.Trade.MessageEvent(OnMessageReceive));

                _polarisBase.InitProgram(_accountInfo);
                //_polarisBase.Login();

                AddStructure(new LoginStructure());
                AddStructure(new EquityStructure());                
                AddStructure(new FuturesHistoryCoverReportStructure());
                AddStructure(new FuturesHistoryReportStructure());
                AddStructure(new FuturesMATReportStructure());
                AddStructure(new FuturesOrderReportStructure());
                AddStructure(new FuturesOrderStructure());
                AddStructure(new FuturesStoreClassifyStructure());
                AddStructure(new FuturesStoreSimplyStructure());
                AddStructure(new FuturesTradeReportStructure());
                AddStructure(new KLineStructure());
                AddStructure(new RealReport3Structure());
                AddStructure(new RealReportMerge3Structure());
                AddStructure(new StockAverageStructure());
                AddStructure(new WatchListStructure());
                AddStructure(new WatchListAllStructure());

                tabFunction.SelectedIndex = 0;

                tblInputParent.Columns.Add("Name", "變數名");
                tblInputParent.Columns.Add("Type", "變數型別");
                tblInputParent.Columns.Add("Value", "變數值");

                tblOutputParent.Columns.Add("Name", "變數名");
                tblOutputParent.Columns.Add("Type", "變數型別");
                tblOutputParent.Columns.Add("Value", "變數值");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void AddStructure(PolarisStructure structure)
        {
            tabFunction.TabPages.Add(structure.ClientName + "(" + structure.ApiId + ")");
            _polarisBase.AddMessageStructure(structure);
        }

        public void FillParentTable(DataGridView tblData, Dictionary<string, object> dicReturn, string[] strNames, string[] strTypes)
        {
            while (tblData.Rows.Count > 0)
                tblData.Rows.RemoveAt(0);

            for (int i = 0; i < strNames.Length; i++)            
                tblData.Rows.Add(strNames[i], strTypes[i], dicReturn[strNames[i]]);            
        }

        public void FillChildrenTable(DataGridView tblData, Dictionary<string, object> dicReturn, 
                                      string strRowCount, string strNodeName, string[] strNames, string[] strTypes)
        {
            Dictionary<string, object> dicChildren;
            object[] oValues;

            while (tblData.Rows.Count > 0)
                tblData.Rows.RemoveAt(0);

            while (tblData.Columns.Count > 0)
                tblData.Columns.RemoveAt(0);

            for (int i = 0; i < strNames.Length; i++)
            {
                tblData.Columns.Add(strNames[i], strNames[i]);
            }

            tblData.Rows.Add(strTypes);

            for (int i = 0; i < int.Parse(dicReturn[strRowCount].ToString()); i++)
            {
                if(dicReturn.ContainsKey(strNodeName + i) == false)
                    continue;

                dicChildren = (Dictionary<string, object>)dicReturn[strNodeName + i];
                oValues = new object[strNames.Length];

                for (int j = 0; j < strNames.Length; j++)
                    oValues[j] = dicChildren[strNames[j]];

                tblData.Rows.Add(oValues);
            }
        }

        private string ParseFunctionCode(string strText)
        {
            return strText.Substring(strText.IndexOf("(") + 1,
                                     strText.IndexOf(")") - strText.IndexOf("(") - 1);
        }

        private void FillMessageTable(PolarisStructure structure, Dictionary<string, object> dicReturn)
        {
            if (structure == null)
                return;

            if (structure.GetNames(PolarisStructure.OUTPUT_PARENT) == null)
                return;

            FillParentTable(tblOutputParent, dicReturn, structure.GetNames(PolarisStructure.OUTPUT_PARENT), structure.GetTypes(PolarisStructure.OUTPUT_PARENT));

            if (structure.GetNames(PolarisStructure.OUTPUT_CHILDREN) == null)
                return;

            FillChildrenTable(tblOutputChildren, dicReturn,
                              "RecordCount", "Children",
                              structure.GetNames(PolarisStructure.OUTPUT_CHILDREN), structure.GetTypes(PolarisStructure.OUTPUT_CHILDREN));

        }

        public void OnMessageReceive(Dictionary<string, object> dicReturn)
        {
            tabFunction.Enabled = true;

            if (dicReturn[PolarisBase.RETURN_MESSAGE].ToString() != PolarisBase.SUCCESS_RETURN_MESSAGE)
            {
                MessageBox.Show(dicReturn[PolarisBase.RETURN_MESSAGE].ToString());
                return;
            }

            string strFunctionCode = ParseFunctionCode(tabFunction.TabPages[tabFunction.SelectedIndex].Text);
            PolarisStructure structure = _polarisBase.GetMessageStructure(strFunctionCode);

            FillMessageTable(structure, dicReturn);

            if (_dicExecuteResult.ContainsKey(strFunctionCode))
            {
                _dicExecuteResult[strFunctionCode] = dicReturn;
            }
            else
            {
                _dicExecuteResult.Add(strFunctionCode, dicReturn);
            }
        }

        public void ClearTables()
        {
            while (tblInputParent.Rows.Count > 0)
                tblInputParent.Rows.RemoveAt(0);

            while (tblInputChildren.Rows.Count > 0)
                tblInputChildren.Rows.RemoveAt(0);
            while (tblInputChildren.Columns.Count > 0)
                tblInputChildren.Columns.RemoveAt(0);

            while (tblOutputParent.Rows.Count > 0)
                tblOutputParent.Rows.RemoveAt(0);

            while (tblOutputChildren.Rows.Count > 0)
                tblOutputChildren.Rows.RemoveAt(0);
            while (tblOutputChildren.Columns.Count > 0)
                tblOutputChildren.Columns.RemoveAt(0);

            while (tblOutputGrandChildren.Rows.Count > 0)
                tblOutputGrandChildren.Rows.RemoveAt(0);
            while (tblOutputGrandChildren.Columns.Count > 0)
                tblOutputGrandChildren.Columns.RemoveAt(0);
        }

        private void FillCacheData(string strFunctionCode, PolarisStructure structure)
        {
            if (_dicExecuteResult.ContainsKey(strFunctionCode))
                FillMessageTable(structure, (Dictionary<string, object>)_dicExecuteResult[strFunctionCode]);
        }

        private void tabFunction_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearTables();

            string strFunctionCode = ParseFunctionCode(tabFunction.TabPages[tabFunction.SelectedIndex].Text);            
            PolarisStructure structure = _polarisBase.GetMessageStructure(strFunctionCode);

            if (structure == null)
                return;

            string[] strNames = structure.GetNames(PolarisStructure.INPUT_PARENT);
            string[] strTypes = structure.GetTypes(PolarisStructure.INPUT_PARENT);

            if (strNames == null)
            {
                FillCacheData(strFunctionCode, structure);
                return;
            }

            for (int i = 0; i < strNames.Length; i++)
                tblInputParent.Rows.Add(new object[] { strNames[i], 
                                                 strTypes[i], 
                                                 strNames[i] == "AccountInfo" 
                                                    ? Util.FillSpace(_accountInfo.AccountType + _accountInfo.AccountNo, 22)
                                                    : ""});

            strNames = structure.GetNames(PolarisStructure.INPUT_CHILDREN);
            strTypes = structure.GetTypes(PolarisStructure.INPUT_CHILDREN);
            if (strNames == null)
            {
                FillCacheData(strFunctionCode, structure);
                return;
            }

            for (int i = 0; i < strNames.Length; i++)
            {
                tblInputChildren.Columns.Add(strNames[i], strNames[i]);
            }
            tblInputChildren.Rows.Add(strTypes);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {

            tabFunction.Enabled = false;

            string strFunctionCode = tabFunction.TabPages[tabFunction.SelectedIndex].Text;

            strFunctionCode = strFunctionCode.Substring(strFunctionCode.IndexOf("(") + 1,
                                                        strFunctionCode.IndexOf(")") - strFunctionCode.IndexOf("(") - 1);
            PolarisStructure structure = _polarisBase.GetMessageStructure(strFunctionCode);

            if (structure == null)
                return;

            if (structure.ClientName == "Login")
            {
                _polarisBase.Login();
                return;
            }

            string[] strNames = structure.GetNames(PolarisStructure.INPUT_PARENT);
            string[] strTypes = structure.GetTypes(PolarisStructure.INPUT_PARENT);

            if (strNames == null)
                return;

            Dictionary<string, object> dicValue = new Dictionary<string, object>();
            Dictionary<string, string> dicChildren = new Dictionary<string, string>();

            for (int i = 0; i < tblInputParent.Rows.Count; i++)
                dicValue.Add(tblInputParent.Rows[i].Cells["Name"].Value.ToString(),
                             tblInputParent.Rows[i].Cells["Value"].Value.ToString());


            for (int i = 1; i < tblInputChildren.Rows.Count; i++)
            {
                dicChildren = new Dictionary<string, string>();
                for (int j = 0; j < tblInputChildren.Columns.Count; j++)
                {
                    dicChildren.Add(tblInputChildren.Columns[j].Name,
                                    tblInputChildren.Rows[i].Cells[j].Value.ToString());
                }
                dicValue.Add("Children" + (i - 1), dicChildren);
            }

            _polarisBase.MessageSend(strFunctionCode, dicValue);
        }

        private void tblInputParent_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode != Keys.Return)
                    return;
                
                if (tblInputParent.Rows[tblInputParent.CurrentRow.Index - 1].Cells[0].Value.ToString() != "Count")
                    return;

                int iRowCount = int.Parse(tblInputParent.Rows[tblInputParent.CurrentRow.Index - 1].Cells[2].Value.ToString());

                while (tblInputChildren.Rows.Count < iRowCount + 1)
                    tblInputChildren.Rows.Add();

                for(int i = 0; i < tblInputChildren.Columns.Count; i++)
                    if (tblInputChildren.Columns[i].Name == "AccountInfo")
                    {
                        for (int j = 1; j < tblInputChildren.Rows.Count; j++)
                        {
                            tblInputChildren.Rows[j].Cells[i].Value = Util.FillSpace(_accountInfo.AccountType + _accountInfo.AccountNo, 22);
                        }
                        break;
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }
    }
}
